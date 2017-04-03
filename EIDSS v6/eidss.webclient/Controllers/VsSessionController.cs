using System;
using System.Web.Mvc;
using eidss.model.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using eidss.model.Reports.Common;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class VsSessionController : BvController
    {
        //
        // GET: /VsSession/

        public ActionResult Index()
        {
            return IndexInternal<VsSessionListItem.Accessor, VsSessionListItem, VsSessionListItem.VsSessionListItemGridModelList>
                (VsSessionListItem.Accessor.Instance(null), AutoGridRoots.VsSessionList, false);
        }

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<VsSessionListItem.Accessor, VsSessionListItem, VsSessionListItem.VsSessionListItemGridModelList>
                (form, VsSessionListItem.Accessor.Instance(null), AutoGridRoots.HumanCaseList, request);
        }

        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, VsSessionListItem item)
        {
            var result = item.MarkToDelete();
            return Json(new[] { item }.ToDataSourceResult(request, ModelState));
        }

        [HttpGet]
        public ActionResult Details(long? id, int? isret)
        {
            return DetailsInternal(id, VsSession.Accessor.Instance(null), (int)HACode.Vector
                , null
                , id.HasValue && isret.HasValue && isret == 1
                  ? (proxy, accessor) => (VsSession)ModelStorage.GetRoot(Session.SessionID, id.Value, String.Empty)
                  : (Func<DbManagerProxy, VsSession.Accessor, VsSession>)null
                , null
                ,c =>
                    {
                        if (isret.HasValue && (isret == 1))
                        {
                            ModelStorage.Put(Session.SessionID, c.idfVectorSurveillanceSession,
                                             c.idfVectorSurveillanceSession, String.Empty, c);
                        }
                    }
                );
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            return DetailsInternalAjax<VsSession.Accessor, VsSession>(form, VsSession.Accessor.Instance(null), null, null, null, null);
        }

        [HttpPost]
        public ActionResult StoreInSession(FormCollection form)
        {
            var idSessionList = form["idfVectorSurveillanceSession"];
            long idSession = 0;
            if (idSessionList != null)
            {
                var arr = idSessionList.Split(new []{","}, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length > 0) idSession = Convert.ToInt64(arr[arr.Length - 1]);
            }
            if (idSession > 0)
            {
                var session = (VsSession)ModelStorage.Get(Session.SessionID, idSession, null);
                session.ParseFormCollection(form);
            }
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private ActionResult _VsSessionPicker(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow, FilterParams filter)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.FunctionName = functionName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;
            ViewBag.IsMultiSelection = isMultiSelection;

            return IndexInternal<VsSessionListItem.Accessor, VsSessionListItem, VsSessionListItem.VsSessionListItemGridModelList>
                (VsSessionListItem.Accessor.Instance(null), AutoGridRoots.VsSessionPopUpSelectList, true, filter, "VsSessionPicker");
        }

        [HttpGet]
        public ActionResult VsSessionPickerForOutbreak(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow)
        {
            var rootObject = (Outbreak)ModelStorage.Get(Session.SessionID, long.Parse(objectId), null);
            FilterParams filter = null;
            if (rootObject.Diagnosis != null)
            {
                ViewBag.SearchHint = Translator.GetMessageString("msgSessionsWithDiagnosis");
                ViewBag.StaticFilter = new FilterParams().Add("bWithDiagnosisOnly", "=", true);

                filter = new FilterParams();
                if (rootObject.Diagnosis.blnGroup.HasValue && rootObject.Diagnosis.blnGroup.Value)
                    filter.Add("idfsDiagnosisGroup", "=", rootObject.Diagnosis.idfsDiagnosisOrDiagnosisGroup);
                else if (rootObject.Diagnosis.idfsDiagnosisGroup.HasValue && rootObject.Diagnosis.idfsDiagnosisGroup.Value != 0)
                    filter.Add("idfsDiagnosisGroup", "=", rootObject.Diagnosis.idfsDiagnosisGroup);
                else
                    filter.Add("idfsDiagnosis", "=", rootObject.Diagnosis.idfsDiagnosisOrDiagnosisGroup);
            }
            return _VsSessionPicker(objectId, functionName, isMultiSelection, showInInternalWindow, filter);
        }

        [HttpGet]
        public ActionResult VsSessionPicker(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow)
        {
            return _VsSessionPicker(objectId, functionName, isMultiSelection, showInInternalWindow, null);
        }

        [HttpGet]
        public ActionResult VsSessionReport(long id)
        {
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var model = new BaseIdModel(ModelUserContext.CurrentLanguage, id, ModelUserContext.Instance.IsArchiveMode);
                    report = wrapper.Client.ExportVectorSurveillanceSessionSummary(model);
                }
                return ReportResponse(report, "VectorSurveillanceSessionSummaryReport.pdf");
            }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }
    }
}
