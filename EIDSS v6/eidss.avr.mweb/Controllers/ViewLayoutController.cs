using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Mvc;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.mweb.Utils;
using eidss.model.Avr.View;
using eidss.web.common.Utils;


namespace eidss.avr.mweb.Controllers
{
    [AuthorizeEIDSS]
    public class ViewLayoutController : Controller
    {
        public const string storagePrefix = "VIEW";
        [HttpGet]
        public ActionResult ViewLayout(long queryId, long layoutId)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return View("AvrServiceError", (object)error);

            ViewBag.LayoutId = layoutId;
            ViewBag.Title = string.Format(Translator.GetMessageString("webLayoutViewTitle"), viewModel.ViewHeader.LayoutName);

            return View(viewModel);
        }

        public ActionResult OnSavePost(long layoutId)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return View("AvrServiceError", (object)error);

            SaveModelInDb(viewModel.ViewHeader);

            viewModel.ViewHeader.GridViewSettings = null;
            ViewBag.LayoutId = layoutId;
            return RedirectToAction("ViewLayout", new { queryId = 0, layoutId = layoutId });
        }

        [HttpPost]
        public ActionResult IsChanged(FormCollection form)
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            if (viewModel.ViewHeader.IsChanged)
            {
                // show confirmation
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText = Translator.GetBvMessageString("Save data?"),
                        yesFunction = String.Format("document.location.href='{0}'", Url.Action("OnSavePost", "ViewLayout", new { layoutId = LayoutId })),
                        noFunction = ""
                    }
                };
            }
            // finish, don't show confirmation
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "noask" } };
        }

        public ActionResult DropDownEdit()
        {
            return PartialView("DropDownEdit");
        }

        public ActionResult ViewGridView(long layoutId)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return View("AvrServiceError", (object)error);

            return PartialView("ViewGridView", viewModel);
        }

        #region Combos

        public PartialViewResult GetDataColumns(long layoutId, string viewName)
        {
            AvrPivotViewModel viewModel;
            string error;
            GetModelFromSession(out viewModel, out error);

            return PartialView(viewName, viewModel.ViewHeader);
        }

        public ActionResult OnMapDefDataChart(FormCollection form)
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            viewModel.ViewHeader.FillColumnsBooleans( form.Count == 0 ? "" : form[0], "IsMapDiagramSeries");
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult OnMapDefDataGradient(/*long layoutId,*/ string text)
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            viewModel.ViewHeader.FillColumnsBooleans(text, "IsMapGradientSeries");
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult OnMapDefAdminUnit(/*long layoutId,*/ string text)
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            viewModel.ViewHeader.MapAdminUnitViewColumn = text;
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult OnChartDefSeries(FormCollection form)
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            viewModel.ViewHeader.FillColumnsBooleans(form.Count == 0 ? "" : form[0], "IsChartSeries");
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult OnChartDefXaxis(/*long layoutId,*/ string text)
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };
            
            viewModel.ViewHeader.ChartXAxisViewColumn = text;
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion

        #region Add/Edit Column/Band Functions
        public ActionResult ColBandChanged(/*long layoutId,*/ string uniquePath)
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel != null)
                viewModel.ViewHeader.SelectedColBand = uniquePath;
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult ColumnMoving(/*long layoutId,*/ string source, string destination, bool isDropBefore)
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel != null)
            {
                viewModel.ViewHeader.SetOrderChanged(source);
                viewModel.ViewHeader.SetTempOrders(source, destination, isDropBefore);
            }
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult AggregateColumnDlg(long layoutId)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
            {
                return View("AvrServiceError", (object)error);
            }
            return PartialView(viewModel.ViewHeader);
        }

        // save renaming and editing from rename dialog and redisplay grid
        [HttpPost]
        public ActionResult AggregateColumnDlgSave([Bind]long layoutId, [Bind]string uniquePath, [Bind]string displayName, [Bind]long? cbAggregate_VI, [Bind]int? Precision, [Bind]string cbSourceColumn_VI, [Bind]string cbDenominator_VI)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return View("AvrServiceError", (object)error);

            AvrViewColumn col = viewModel.ViewHeader.GetColumnByOriginalName(uniquePath);
            if (col != null)
            {
                col.DisplayText = displayName;
                if (col.IsAggregate)
                {
                    col.AggregateFunction = cbAggregate_VI;
                    col.Precision = Precision;
                    col.SourceViewColumn = cbSourceColumn_VI;
                    col.DenominatorViewColumn = cbDenominator_VI;

                    AggregateCasheWeb.FillAggregateColumn(viewModel.ViewData, col, viewModel.ViewHeader.GetSortExpression());
                }
            }
            else
            {
                AvrViewBand band = viewModel.ViewHeader.GetBandByOriginalName(uniquePath);
                if (band != null)
                {
                    band.DisplayText = displayName;
                }
            }

            viewModel.ViewHeader.GridViewSettings = null;
            ViewBag.LayoutId = layoutId;
            return RedirectToAction("ViewLayout", new { queryId = 0, layoutId = layoutId });
        }

        [HttpPost]
        public ActionResult AddAggregate(long layoutId, string uniquePath)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            var aggrCol = viewModel.ViewHeader.SelectedBand.AddAggregateColumn();

            if (aggrCol != null)
            {
                viewModel.ViewHeader.GridViewSettings = null;

                viewModel.ViewHeader.SelectedColBand = aggrCol.UniquePath;
                viewModel.ViewData.Columns.Add(aggrCol.UniquePath, typeof(string));

                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ok",
                        colSelected = aggrCol == null ? null : aggrCol.UniquePath
                    }
                };
            }

            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult IsAggregate(long layoutId, string uniquePath)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            var col = viewModel.ViewHeader.GetColumnByOriginalName(uniquePath);
            if (col != null && col.IsAggregate)
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText = Translator.GetMessageString("msgDeleteAggregateColumn"),
                        yesFunction = String.Format("aggregateForm.DeleteColumn({0}, '{1}');", layoutId, uniquePath),
                        noFunction = ""
                    }
                };
            else
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "noask",
                        function = ""
                    }
                };
        }

        [HttpPost]
        public ActionResult DeleteAggregate(long layoutId, string uniquePath)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            viewModel.ViewHeader.DeleteAggregateColumn(uniquePath);

            viewModel.ViewHeader.GridViewSettings = null;
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion

        #region Refresh/Reset/Cancel Changes
        [HttpPost]
        public ActionResult OnRefreshData()
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };

            if (viewModel.ViewHeader.IsChanged)
            {
                // show confirmation
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText = Translator.GetBvMessageString("Save data?"),
                        yesFunction = String.Format("document.location.href='{0}'", Url.Action("OnRefreshDataPost", "ViewLayout", new { layoutId = LayoutId, save = true })),
                        noFunction = String.Format("document.location.href='{0}'", Url.Action("OnRefreshDataPost", "ViewLayout", new { layoutId = LayoutId, save = false }))
                    }
                };
            }
            // finish, don't show confirmation
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    result = "noask",
                    function = Url.Action("OnRefreshDataPost", "ViewLayout", new { layoutId = LayoutId, save = false })
                }
            };
        }

        public ActionResult OnRefreshDataPost(long layoutId, bool save)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return View("AvrServiceError", (object)error);

            if (save)
            {
                SaveModelInDb(viewModel.ViewHeader);
            }

            object ret = GetModelFromService(layoutId);
            if (ret is string)
                return View("AvrServiceError", (object)ret);
            var pivotResult = ret as AvrServicePivotResult;

            AdjustToNew(viewModel.ViewHeader, pivotResult.Model);

            ModelStorage.Put(Session.SessionID, layoutId, layoutId, storagePrefix, viewModel);

            viewModel.ViewHeader.GridViewSettings = null;
            ViewBag.LayoutId = layoutId;
            return RedirectToAction("ViewLayout", new { queryId = 0, layoutId = layoutId });
        }

        [HttpGet]
        public ActionResult OnResetView()
        {
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    messageText = Translator.GetMessageString("msgConfirmResetViewPanel"),
                    yesFunction = String.Format("document.location.href='{0}'", Url.Action("OnResetViewPost", "ViewLayout", new { layoutId = GetLayoutId() })),
                    noFunction = ""
                }
            };
        }

        public ActionResult OnResetViewPost(long layoutId)
        {
            object ret = GetModelFromService(layoutId);
            if (ret is string)
                return View("AvrServiceError", (object)ret);
            var pivotResult = ret as AvrServicePivotResult;

            AvrPivotViewModel model = pivotResult.Model;
            AdjustToNew(model.ViewHeader, model);

            ModelStorage.Put(Session.SessionID, layoutId, layoutId, storagePrefix, model);

            return RedirectToAction("ViewLayout", new { queryId = 0, layoutId = layoutId });
        }

        [HttpGet]
        public ActionResult OnCancelChanges()
        {
            AvrPivotViewModel viewModel;
            string error;
            long LayoutId = GetModelFromSession(out viewModel, out error);
            if (viewModel == null)
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "error", data = error } };


            if (viewModel.ViewHeader.IsChanged)
            {
                string text = "";
                if (viewModel.ViewHeader.IsNew)
                    text = Translator.GetMessageString("msgConfirmClearForm");
                else
                    text = Translator.GetMessageString("msgConfirmCancelChangesForm");

                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText = text,
                        yesFunction = String.Format("document.location.href='{0}'", Url.Action("OnCancelChangesPost", "ViewLayout", new { layoutId = LayoutId })),
                        noFunction = ""
                    }
                };
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "noask" } };
        }

        public ActionResult OnCancelChangesPost(long layoutId)
        {
            object ret = GetModelFromService(layoutId);
            if (ret is string)
                return View("AvrServiceError", (object)ret);
            var pivotResult = ret as AvrServicePivotResult;

            // get viewModel from database and merge it with pivotResult
            // add values of aggregate columns to datasource
            var viewModel = GetModelFromDb(layoutId, pivotResult);

            return RedirectToAction("ViewLayout", new { queryId = 0, layoutId = layoutId });
        }
        #endregion

        #region Export/Print
        public ActionResult ExportTo(long layoutId, string typeName)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return View("AvrServiceError", (object)error);
            return LayoutViewHelper.ExportTypes[typeName].Method(LayoutViewHelper.GetGridViewSettings(viewModel.ViewHeader), viewModel.ViewData);
        }

        public ActionResult Print(long layoutId)
        {
            string error;
            var viewModel = GetModelFromSession(layoutId, out error);
            if (viewModel == null)
                return View("AvrServiceError", (object)error);
            var options = new DevExpress.XtraPrinting.PdfExportOptions();
            options.ShowPrintDialogOnOpen = true;
            return DevExpress.Web.Mvc.GridViewExtension.ExportToPdf(LayoutViewHelper.GetGridViewSettings(viewModel.ViewHeader), viewModel.ViewData, false, options);
        }
        #endregion

        [HttpGet]
        public ActionResult OnClose()
        {
            ModelStorage.Remove(Session.SessionID, GetLayoutId(), storagePrefix);
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #region Private common functions

        private object GetModelFromService(long layoutId)
        {
            AvrServiceAccessability access = AvrServiceAccessability.Check();
            if (!access.IsOk)
            {
                return access.ErrorMessage;
            }
            AvrServicePivotResult pivotResult = ServiceClientHelper.GetAvrServicePivotResult(Session.SessionID, layoutId);
            if (!pivotResult.IsOk)
            {
                return pivotResult.ErrorMessage;
            }

            pivotResult.Model.ViewHeader.AssignOwnerAndUniquePath();

            DataTable dt = pivotResult.Model.ViewData;

            AvrViewHelper.AddIDColumn(ref dt);

            AvrViewHelper.RemoveHASCadditions(pivotResult.Model.ViewHeader, ref dt);
            pivotResult.Model.ViewData = dt;

            return pivotResult;
        }

        private void SaveModelInDb(AvrView model)
        {
            var dbService = new View_DB();
            model.SetOrders();
            dbService.avrView = model;
            dbService.PostDetail(null, 0);
        }

        private AvrView GetModelFromDb(long layoutId)
        {
            var dbService = new View_DB();
            dbService.GetDetail(layoutId);
            dbService.GetGeneralChartMapSettings();
            return dbService.avrView;
        }

        // get viewModel from database and merge it with pivotResult
        // add values of aggregate columns to datasource
        private AvrPivotViewModel GetModelFromDb(long layoutId, AvrServicePivotResult pivotResult)
        {
            var dbView = GetModelFromDb(layoutId);

            AdjustToNew(dbView, pivotResult.Model);

            dbView.GetAggregateColumnsList().ForEach(c => AggregateCasheWeb.FillAggregateColumn(pivotResult.Model.ViewData, c, dbView.GetSortExpression()));

            var model = new AvrPivotViewModel(dbView, pivotResult.Model.ViewData);
            ModelStorage.Put(Session.SessionID, layoutId, layoutId, storagePrefix, model);
            return model;
        }

        private long GetLayoutId()
        {
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
            string layoutId = nameValueCollection["layoutId"];
            return long.Parse(layoutId);
        }

        private long GetModelFromSession(out AvrPivotViewModel model, out string error)
        {
            long LayoutId = GetLayoutId();

            model = GetModelFromSession(LayoutId, out error);

            return LayoutId;
        }

        private AvrPivotViewModel GetModelFromSession(long layoutId, out string error)
        {
            error = null;
            if (layoutId <= 0)
                layoutId = GetLayoutId();
            var viewModel = ModelStorage.Get(Session.SessionID, layoutId, storagePrefix, false) as AvrPivotViewModel;
            if (viewModel == null)
            {
                object ret = GetModelFromService(layoutId);
                if (ret is string)
                {
                    error = ret as string;
                    return null;
                }
                var pivotResult = ret as AvrServicePivotResult;

                // get viewModel from database and merge it with pivotResult
                // add values of aggregate columns to datasource
                viewModel = GetModelFromDb(layoutId, pivotResult);
            }

            return viewModel;
        }

        private void AdjustToNew(AvrView view, AvrPivotViewModel model)
        {
            view.AdjustToNew(model.ViewHeader);
            view.setColumnsTypes(model.ViewData);
        }
        #endregion
    }
}