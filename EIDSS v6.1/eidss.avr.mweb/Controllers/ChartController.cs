using System.Web.Mvc;
using eidss.model.AVR.DataBase;
using eidss.model.Avr.View;
using eidss.web.common.Utils;
using eidss.avr.mweb.Utils;
using System.Xml;
using eidss.avr.db.Common;
using eidss.avr.db.CacheReceiver;
using eidss.model.AVR.ServiceData;
using eidss.model.Core;
using eidss.model.Avr.Chart;
using System;
using System.Data;
using System.Collections.Generic;

namespace eidss.avr.mweb.Controllers
{
    [AuthorizeEIDSS]
    public class ChartController : Controller
    {
        private string m_ErrorMessage;
        private const string storagePrefix = "CHART";
        private const string storagePrefixData = "CHART_DATA";

        [HttpGet]
        public ActionResult Index(long layoutId, int width, int height)
        {
            ObjectStorage.Remove(Session.SessionID, layoutId, storagePrefixData);

            return ObjectStorage.Using<AvrPivotViewModel, ActionResult>(viewModel =>
                {
                    viewModel.ViewHeader.ChartType = "";

                    ViewBag.Title = string.Format(Translator.GetMessageString("webChartTitle"), viewModel.ViewHeader.LayoutName);
                    ViewBag.LayoutId = layoutId;

                    if (!bv.common.Core.Utils.IsEmpty(viewModel.ViewHeader.ChartLocalSettingsXml))
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(viewModel.ViewHeader.ChartLocalSettingsXml);
                            if (doc.SelectSingleNode("//ChartType") != null)
                            {
                                long ltp;
                                if (long.TryParse(doc.SelectSingleNode("//ChartType").InnerText, out ltp))
                                {
                                    var tp = (DBChartType)ltp;
                                    viewModel.ViewHeader.ChartType = tp.ToString();
                                }
                            }


                            return GetShowImage(layoutId, viewModel, width, height);
                        }
                        catch (System.Exception e)
                        {
                            return View("AvrServiceError", (object)e.Message);
                        }
                    }
                    else
                    {
                    }
                    return View("Index", ChartMapHelper.GetEmptyChartData(viewModel));
                }, Session.SessionID, layoutId, ViewLayoutController.StoragePrefix, false);
        }

        public ActionResult GetShowImage(long layoutId, AvrPivotViewModel viewModel, int width, int height)
        {
            // have we anything selected in combo Xaxis? 
            if (!string.IsNullOrEmpty(viewModel.ViewHeader.ChartXAxisViewColumn))
            {
                string img = GetChartStringFromService(layoutId, viewModel, width, height);
                if (img == "")
                    return View("AvrServiceError", (object)m_ErrorMessage);

                return View("Index", new ChartMapHelper.ChartModel(viewModel.ViewHeader.LayoutID, viewModel.ViewHeader.ChartType, img));
            }
            return View("Index", ChartMapHelper.GetEmptyChartData(viewModel));
        }

        [HttpPost]
        public ActionResult ChartTypeChanged(long layoutId, string value, int width, int height)
        {
            return ObjectStorage.Using<AvrPivotViewModel, ActionResult>(model =>
                {
                    if (model != null)
                    {
                        model.ViewHeader.ChartType = value;

                        string img = GetChartStringFromService(layoutId, model, width, height);
                        if (img == "")
                            return new JsonResult { Data = new { result = "error", text = m_ErrorMessage }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                        return new JsonResult { Data = new { result = "success", text = img }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }

                    return new JsonResult { Data = new { result = "error", text = "Model not found in Session." }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }, Session.SessionID, layoutId, ViewLayoutController.StoragePrefix);
        }

        public ActionResult ChartTypeCombo(long layoutId)
        {
            return ObjectStorage.Using<AvrPivotViewModel, ActionResult>(viewModel =>
                {
                    return PartialView("ChartTypeCombo", (object)viewModel.ViewHeader.ChartType);
                }, Session.SessionID, layoutId, ViewLayoutController.StoragePrefix);
        }

        public ActionResult SaveImage(long layoutId)
        {
            return ObjectStorage.Using<byte[], ActionResult>(ret =>
                {
                    if (ret != null)
                    {
                        string contentType = "application/octet-stream";

                        return File(ret, contentType, "chart.jpg");
                    }
                    else return null;
                }, Session.SessionID, layoutId, storagePrefix, false);
        }

        private string GetChartStringFromService(long layoutId, AvrPivotViewModel viewModel, int width, int height)
        {
            var ret = GetChartBytesFromService(layoutId, viewModel, width, height);
            if (ret == null)
            {
                return "";
            }

            string base64String;
            try
            {
                base64String = System.Convert.ToBase64String(ret, 0, ret.Length);
                return base64String;
            }
            catch (System.ArgumentNullException)
            {
                m_ErrorMessage = "Binary data array is null.";
                return "";
            }
        }

        private byte[] GetChartBytesFromService(long layoutId, AvrPivotViewModel viewModel, int width, int height)
        {
            m_ErrorMessage = "";

            DBChartType? chtp = null;
            if (viewModel.ViewHeader.ChartType != null && viewModel.ViewHeader.ChartType != "")
                chtp = (DBChartType)Enum.Parse(typeof(DBChartType), viewModel.ViewHeader.ChartType);

            var toTable = GetChartDataFromSession(layoutId, viewModel);
            var textPatterns = new Dictionary<string, object>();
            foreach (DataColumn col in toTable.Columns)
            {
                if (col.ExtendedProperties.ContainsKey("TextPattern"))
                    textPatterns.Add(col.ColumnName, col.ExtendedProperties["TextPattern"]);
            }

            var tbl = new ChartTableModel(viewModel.ViewHeader.ViewID,
                                    EidssUserContext.CurrentLanguage,
                                    toTable,
                                    viewModel.ViewHeader.ChartLocalSettingsZip,
                                    chtp,
                                    textPatterns,
                                    width, height);


            AvrServiceChartResult result = ServiceClientHelper.GetAvrServiceChartResult(tbl);
            if (!result.IsOk)
            {
                m_ErrorMessage = result.ErrorMessage;
                return null;
            }

            ObjectStorage.Put(Session.SessionID, 0, layoutId, storagePrefix, result.Model.JpgBytes);
            return result.Model.JpgBytes;
        }

        private DataTable GetChartDataFromSession(long layoutId, AvrPivotViewModel viewModel)
        {
            //var data = ModelStorage.Get(Session.SessionID, layoutId, storagePrefixData, false) as DataTable;
            return ObjectStorage.Using<DataTable, DataTable>(data =>
            {
                if (data == null)
                {
                    data = ChartMapHelper.TryToPrepareChartData(viewModel);
                    ObjectStorage.Put(Session.SessionID, 0, layoutId, storagePrefixData, data);
                }

                return data;
            }, Session.SessionID, layoutId, storagePrefixData, false);
        }

    }
}
