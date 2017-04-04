using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Localization;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Enums;
using bv.model.Model.Core;
using DevExpress.Data.PivotGrid;
using EIDSS;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.mweb.Models;
using eidss.avr.mweb.Utils;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;
using eidss.web.common.Utils;

namespace eidss.avr.mweb.Controllers
{
    [AuthorizeEIDSS]
    public class LayoutController : Controller
    {
        public const string StoragePrefix = "PIVOT";
        public WebLayoutDB LayoutDBService { get; private set; }
        private string m_ErrorMessage;

        [HttpGet]
        public ActionResult Layout(long layoutId)
        {
            ViewBag.LayoutId = layoutId;
            if (Request.QueryString.AllKeys.Contains("clearcache") && Request.QueryString["clearcache"] == "1")
            {
                RemovePivotViewObjects(layoutId);
            }
            AvrPivotGridModel model = GetModelFromSession(layoutId);
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            PivotGridFieldBase.DefaultTotalFormat.FormatString = PivotGridLocalizer.GetString(PivotGridStringId.TotalFormat);
            model.IsFirstLoad = true;
            ViewBag.Title = string.Format(Translator.GetMessageString("webPivotGridTitle"),
                ((LayoutDetailDataSet.LayoutRow)(model.PivotSettings.LayoutDataset.Layout.Rows[0])).strLayoutName);
            return View(model);
        }

        //[HttpGet]
        public ActionResult OnRefreshData(string text)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            if (!string.IsNullOrEmpty(text))
            {
                model.PivotSettings.HasChanges = true;
                model.PivotSettings.UseArchiveData = "true".Equals(text);
            }
            if (model.PivotSettings.HasChanges)
            {
                // show confirmation
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText = Translator.GetBvMessageString("Save data?"),
                        yesFunction = String.Format("document.location.href='{0}'", Url.Action("SaveAndRefeshData", "Layout")),
                        noFunction = String.Format("document.location.href='{0}'", Url.Action("RefeshData", "Layout"))
                    }
                };
            }
            // finish, don't show confirmation
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { result = "noask", function = "RefeshData" }
            };
        }

        [HttpGet]
        public ActionResult OnCancelChanges()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }

            if (model.PivotSettings.HasChanges)
            {
                // show confirmation
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText = Translator.GetBvMessageString("menuCancelChanges") + "?",
                        yesFunction = String.Format("document.location.href='{0}'", Url.Action("CancelChanges", "Layout")),
                        noFunction = ""
                    }
                };
            }
            // finish, don't show confirmation
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "noask" } };
        }

        [HttpGet]
        public ActionResult OnClose()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model != null && model.PivotSettings != null)
            {
                RemovePivotViewObjects(model.PivotSettings.LayoutId);
            }
            // finish, don't show confirmation
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult CancelChanges()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model != null)
            {
                RemovePivotViewObjects(model.PivotSettings.LayoutId);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult RefeshData()
        {
            string error = RefreshPivotData();
            if (!string.IsNullOrEmpty(error))
            {
                return View("AvrServiceError", (object)error);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult RefeshData2()
        {
            string url = HttpContext.Request.UrlReferrer.AbsoluteUri;
            int ind = url.IndexOf("&clearcache");
            if (ind > 0)
            {
                url = url.Substring(0, ind);
            }

            AvrPivotGridModel model = GetModelFromSession();
            if (model != null)
            {
                if (model.PivotSettings.SelectedField != null)
                {
                    model.PivotSettings.SelectedField.Action = WebFieldAction.None;
                }
            }

            return Redirect(url);
        }

        public ActionResult SaveAndRefeshData()
        {
            ActionResult result = SaveData();
            if (!(result is JsonResult))
            {
                return result;
            }
            string error = RefreshPivotData();
            if (!string.IsNullOrEmpty(error))
            {
                return View("AvrServiceError", (object)error);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult PivotGridPartial()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            return PartialView(model);
        }

        public ActionResult ColumnAttributesPartial()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            return PartialView(model);
        }

        public ActionResult FieldsListCombo()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            return PartialView(model);
        }

        public ActionResult ShowMissedValues(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.ShowMissedValues = value;
            model.PivotSettings.ShowMissedValuesSaved = model.PivotSettings.ShowMissedValues;
            model.PivotSettings.ShowDataInPivot = true;
            LayoutPivotGridHelper.AddMissedValues(model, true);
            //return RedirectToAction("Layout", new { queryId = model.PivotSettings.QueryId, model.PivotSettings.LayoutId });
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
            //return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult ShowData(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.ShowDataInPivot = value;
            model.PivotSettings.ShowMissedValues = model.PivotSettings.ShowDataInPivot && model.PivotSettings.ShowMissedValuesSaved;
            model.PivotSettings.HasChanges = true;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { showMissedValues = model.PivotSettings.ShowMissedValues }
            };
        }

        public ActionResult CompactLayout(bool isCompactLayout)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.CompactLayout = isCompactLayout;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        public ActionResult UseArchiveData(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.UseArchiveData = value;
            bool isNewObject;

            


            string errorMessage;
            model.PivotData = LayoutPivotGridHelper.GetPivotData(model.PivotSettings.LayoutDataset, model.PivotSettings.QueryId,
                model.PivotSettings.LayoutId, model.PivotSettings.UseArchiveData, out isNewObject,out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                m_ErrorMessage = errorMessage;
                return View("AvrServiceError", (object)m_ErrorMessage);
            }

            
            LayoutPivotGridHelper.AddMissedValues(model, false);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        public ActionResult FreezeRowHeaders(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.FreezeRowHeaders = value;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        public ActionResult ApplyFilter(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.ApplyFilter = value;

            LayoutPivotGridHelper.FillEmptyValuesInDataArea(model);

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        public ActionResult ShowPrefilter()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.ShowPrefilter = true;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        public static AvrPivotGridModel  FillData(ref long queryId, long layoutId)
        {
            var service = new WebLayoutDB();
            var sessionDataSet = (LayoutDetailDataSet) service.GetDetail(layoutId);
            if (queryId <= 0)
            {
                queryId = ((LayoutDetailDataSet.LayoutRow) sessionDataSet.Layout.Rows[0]).idflQuery;
            }
            var helper = new LayoutHelper(sessionDataSet);

            var pivotSettings = new AvrPivotSettings(queryId, layoutId);
            helper.InitAvrPivotSettings(pivotSettings);
            bool isNewObject;

            string errorMessage;
            AvrDataTable data = LayoutPivotGridHelper.GetPivotData(helper.LayoutDataSet, queryId, layoutId, pivotSettings.UseArchiveData,
                out isNewObject, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new AvrException(errorMessage);
            }

            pivotSettings.Fields = AvrPivotGridHelper.CreateFields<WebPivotGridField>(data);
            helper.PrepareWebFields(pivotSettings);
            List<IAvrPivotGridField> fields = pivotSettings.Fields.Cast<IAvrPivotGridField>().ToList();
            LayoutValidateResult result = helper.LoadPivotFromDB(new AvrPivotGridData(data), fields, isNewObject);
            var model = new AvrPivotGridModel(pivotSettings, data);
            if (result.IsCancelOrUserDialogCancel())
            {
                model.HideDataForComplexLayout();
            }
            return model;
        }

       

        [HttpPost]
        public ActionResult HasChanges()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }

            if (model.PivotSettings.HasChanges)
            {
                // show confirmation
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText = Translator.GetBvMessageString("Save data?"),
                        yesFunction =
                            String.Format("document.location.href='{0}'", Url.Action("SaveLayout", "Layout")),
                        noFunction = ""
                    }
                };
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "no" };
        }

        [HttpPost]
        public ActionResult OnSwitchToView()
        {
            AvrPivotGridModel model = GetModelFromSession();

            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            if (model.PivotSettings.HasChanges)
            {
                // show confirmation
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText = Translator.GetBvMessageString("Save data?"),
                        yesFunction =
                            String.Format("document.location.href='{0}'", Url.Action("SwitchToView", "Layout", new { saveData = true })),
                        noFunction = String.Format("document.location.href='{0}'", Url.Action("SwitchToView", "Layout", new { saveData = false })),
                    }
                };
            }
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { result = "noask", function = "SwitchToView?saveData=false" }
            };
        }

        public ActionResult SwitchToView(bool saveData)
        {
            if (saveData)
            {
                ActionResult result = SaveData();
                if (!(result is JsonResult))
                {
                    return result;
                }
            }
            else
            {
                AvrPivotGridModel model1 = GetModelFromSession();
                if (model1 != null)
                {
                    RemovePivotViewObjects(model1.PivotSettings.LayoutId);
                }

            }
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            return
                new RedirectResult(Url.Action("ViewLayout", "ViewLayout",
                    new { layoutId = model.PivotSettings.LayoutId }));
        }

        public ActionResult TotalsChanged(FormCollection form)
        {
            AvrPivotGridModel model = GetModelFromSession();

            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;

            string[] totalValues = (form != null && form.Count > 0) ? form[0].Split(',') : "".Split(',');
            model.PivotSettings.ShowColumnTotals = totalValues.Count(c => c == "1") > 0;
            model.PivotSettings.ShowRowTotals = totalValues.Count(c => c == "2") > 0;
            model.PivotSettings.ShowColumnGrandTotals = totalValues.Count(c => c == "3") > 0;
            model.PivotSettings.ShowRowGrandTotals = totalValues.Count(c => c == "4") > 0;
            model.PivotSettings.ShowTotalsForSingleValues = totalValues.Count(c => c == "5") > 0;
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult DefaultGroupDateChanged(long value)
        {
            AvrPivotGridModel model = GetModelFromSession();

            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.DefaultGroupInterval = value;
            model.PivotSettings.UpdateGroupInterval = true;
            if (model.PivotSettings.Fields.Any(
                    f =>
                    f.Visible && (f.Area == PivotArea.RowArea || f.Area == PivotArea.ColumnArea) && f.IsDateTimeField))
                LayoutPivotGridHelper.FillEmptyValuesInDataArea(model);


            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult SaveLayout()
        {
            ActionResult result = SaveData();
            if (!(result is JsonResult))
            {
                return result;
            }
            return new RedirectResult(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult FieldListChanged(string text)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            model.PivotSettings.SelectedField = !string.IsNullOrEmpty(text)
                ? model.PivotSettings.Fields.FirstOrDefault(f => f.FieldName == text)
                : null;
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //[HttpPost]
        // public ActionResult OnSaveFieldChanges() 
        public ActionResult AggregateFunctionChanged(string aggregateFunctionId)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            int intPrecision = -1;
            if (model.PivotSettings.SelectedField != null)
            {
                long aggrId = bv.common.Core.Utils.ToLong(aggregateFunctionId);
                CustomSummaryType summaryTypeType = AvrPivotGridHelper.ParseSummaryType(aggrId);
                if (model.PivotSettings.SelectedField.PrecisionDictionary.ContainsKey(summaryTypeType))
                {
                    intPrecision = model.PivotSettings.SelectedField.PrecisionDictionary[summaryTypeType];
                }
                else
                {
                    string strPrecision = LookupCache.GetLookupValue((long)summaryTypeType, LookupTables.AggregateFunction,
                        "intDefaultPrecision");
                    intPrecision = int.TryParse(strPrecision, out intPrecision)
                        ? intPrecision
                        : -1;
                }
            }
            return new JsonResult { Data = new { precision = (decimal)intPrecision }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult OnSaveFieldChanges
            (string caption, string captionEn, string aggregateFunctionId, string precision, string basicCountFunctionId, string adminUnitField, string dateField,
                string groupInterval, string addMissedValue, string startDate, string endDate)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "error", error = m_ErrorMessage }
                };
            }
            if (model.PivotSettings.SelectedField != null)
            {
                WebPivotGridFieldClone clonedField =
                    model.PivotSettings.SelectedField.GetClonedField(model.PivotSettings.LayoutDataset, false);
                if (ModelUserContext.CurrentLanguage != Localizer.lngEn)
                {
                    clonedField.Caption = caption;
                }
                clonedField.CaptionEn = captionEn;
                clonedField.AggregateFunctionId = bv.common.Core.Utils.ToLong(aggregateFunctionId);
                clonedField.BasicCountFunctionId = bv.common.Core.Utils.ToLong(basicCountFunctionId);
                clonedField.Precision = bv.common.Core.Utils.ToNullableInt(precision);
                clonedField.UnitLayoutSearchFieldId = bv.common.Core.Utils.ToNullableLong(adminUnitField);
                clonedField.DateLayoutSearchFieldId = bv.common.Core.Utils.ToNullableLong(dateField);
                bool updateMissedValues = (!clonedField.AddMissedValues.Equals(bool.Parse(addMissedValue)) ||
                                           !clonedField.DiapasonStartDate.Equals(bv.common.Core.Utils.ToDateNullable(startDate)) ||
                                           !clonedField.DiapasonEndDate.Equals(bv.common.Core.Utils.ToDateNullable(endDate)) ||
                                           !clonedField.PrivateGroupInterval.Equals(bv.common.Core.Utils.ToNullableLong(groupInterval)));
                clonedField.PrivateGroupInterval = bv.common.Core.Utils.ToNullableLong(groupInterval);
                bool fillEmptyValues =
                    LayoutPivotGridHelper.IsFieldGroupIntervalChanged(model.PivotSettings.SelectedField,
                    clonedField.PrivateGroupInterval.HasValue ? (PivotGroupInterval)clonedField.PrivateGroupInterval : model.PivotSettings.SelectedField.GroupInterval);
                clonedField.AddMissedValues = bool.Parse(addMissedValue);
                clonedField.DiapasonStartDate = bv.common.Core.Utils.ToDateNullable(startDate);
                clonedField.DiapasonEndDate = bv.common.Core.Utils.ToDateNullable(endDate);
                string error = ValidateFieldClone(clonedField, model.PivotSettings.SelectedField.IsDateTimeField);
                if (!string.IsNullOrEmpty(error))
                {
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { result = "error", error = error }
                    };
                }
                bool aggregateChanged =
                    !model.PivotSettings.SelectedField.AggregateFunctionId.Equals(clonedField.AggregateFunctionId);
                model.PivotSettings.SelectedField.FlashChanges(model.PivotSettings.LayoutDataset);
                if (aggregateChanged)
                {
                    WebPivotGridField field = model.PivotSettings.SelectedField;
                    CustomSummaryType summaryTypeType =
                        AvrPivotGridHelper.ParseSummaryType(model.PivotSettings.SelectedField.AggregateFunctionId);
                    field.SummaryDisplayType = PivotSummaryDisplayType.Default;

                    PivotSummaryType summaryType = summaryTypeType == CustomSummaryType.Count
                        ? PivotSummaryType.Count
                        : PivotSummaryType.Custom;
                    field.CustomSummaryType = summaryTypeType;
                    field.SummaryType = summaryType;
                }
                if (model.PivotSettings.SelectedField.Action != WebFieldAction.Add)
                {
                    model.PivotSettings.SelectedField.Action = WebFieldAction.Edit;
                }
                model.PivotSettings.UpdatedField = model.PivotSettings.SelectedField;
                if (model.PivotSettings.SelectedField.HasChanges)
                {
                    model.PivotSettings.HasChanges = true;
                }
                if (updateMissedValues)
                {
                    LayoutPivotGridHelper.CopyMissedValuesFromField(model.PivotSettings.SelectedField, model.PivotSettings.Fields);
                    LayoutPivotGridHelper.AddMissedValues(model, true);
                }
                else if (fillEmptyValues)
                {
                    LayoutPivotGridHelper.FillEmptyValuesInDataArea(model);

                }
                if (model.PivotSettings.SelectedField.Action != WebFieldAction.Add)
                {
                    return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { result = "refresh", function = "RefeshData2" }
            };
        }

        private string ValidateFieldClone(WebPivotGridFieldClone clonedField, bool isDateTimeField)
        {
            string error = String.Empty;
            const string lineSeparator = "<br/>";
            if (string.IsNullOrEmpty(clonedField.CaptionEn))
            {
                bv.common.Core.Utils.AppendLine(ref error,
                    StandardErrorHelper.Error(StandardError.Mandatory, Translator.GetMessageString("strNewColumnNameEn")),
                    lineSeparator);
            }
            if (ModelUserContext.CurrentLanguage != Localizer.lngEn && string.IsNullOrEmpty(clonedField.Caption))
            {
                bv.common.Core.Utils.AppendLine(ref error,
                    StandardErrorHelper.Error(StandardError.Mandatory, Translator.GetMessageString("strNewColumnName")),
                    lineSeparator);
            }

            if (clonedField.AddMissedValues && isDateTimeField)
            {
                if (clonedField.DiapasonStartDate == null)
                {
                    bv.common.Core.Utils.AppendLine(ref error,
                        StandardErrorHelper.Error(StandardError.Mandatory, Translator.GetMessageString("DateFrom")),
                        lineSeparator);
                }
                if (clonedField.DiapasonEndDate == null)
                {
                    bv.common.Core.Utils.AppendLine(ref error,
                        StandardErrorHelper.Error(StandardError.Mandatory, Translator.GetMessageString("DateTo")),
                        lineSeparator);
                }
                if (ModelState.IsValid && clonedField.DiapasonStartDate > clonedField.DiapasonEndDate)
                {
                    bv.common.Core.Utils.AppendLine(ref error,
                        string.Format(Translator.GetMessageString("ErrUnstrictChainDate"), Translator.GetMessageString("DateFrom"),
                            clonedField.DiapasonStartDate, Translator.GetMessageString("DateTo"), clonedField.DiapasonEndDate),
                        lineSeparator);
                }
            }
            return error;
        }

        public ActionResult OnCancelFieldChanges(string text)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            if (model.PivotSettings.SelectedField != null)
            {
                model.PivotSettings.SelectedField.CancelChanges(model.PivotSettings.LayoutDataset);
            }
            if (model.PivotSettings.SelectedField.Action != WebFieldAction.Add)
            {
                return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { function = "RefeshData2" }
            };
        }

        public ActionResult OnCopyField(string fieldId)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }
            if (string.IsNullOrEmpty(fieldId))
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            WebPivotGridField sourceField = model.PivotSettings.Fields.Find(f => f.FieldName == fieldId);

            var copy = AvrPivotGridHelper.CreateFieldCopy<WebPivotGridField>(sourceField,
                model.PivotSettings.LayoutDataset,
                model,
                model.PivotSettings.QueryId,
                model.PivotSettings.LayoutId);
            model.PivotSettings.AddField(copy);
            model.PivotSettings.SelectedField = copy;
            copy.Action = WebFieldAction.Add;
            model.PivotSettings.UpdatedField = copy;

            model.IsFirstLoad = true;
            return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult OnDeleteFieldCopy()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }

            if (model.PivotSettings.SelectedField != null)
            {
                // show confirmation
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = "ask",
                        messageText =
                            String.Format(Translator.GetBvMessageString("msgDeleteAVRFieldPrompt"),
                                model.PivotSettings.SelectedField.Caption),
                        yesFunction = "columnPopup.deleteCopy()",
                        noFunction = ""
                    }
                };
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { result = "noask" } };
        }

        public ActionResult DeleteFieldCopy()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }

            if (model.PivotSettings.SelectedField != null)
            {
                WebPivotGridField field = model.PivotSettings.SelectedField;
                field.Action = WebFieldAction.Delete;
                AvrPivotGridHelper.DeleteFieldCopy(field, model.PivotSettings.LayoutDataset, model);
                model.PivotSettings.DeleteField(field);
                model.PivotSettings.UpdatedField = field;
                model.PivotSettings.SelectedField = null;
                model.IsFirstLoad = true;
            }
            return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private AvrPivotGridModel GetModelFromSession(long layoutId = -1)
        {
            if (layoutId <= 0)
            {
                NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
                layoutId = Convert.ToInt64(nameValueCollection["layoutId"]);
            }
            //var model = ModelStorage.Get(Session.SessionID, layoutId, StoragePrefix, false) as AvrPivotGridModel;
            var model = ObjectStorage.Using<AvrPivotGridModel, AvrPivotGridModel>(o => o, Session.SessionID, layoutId, StoragePrefix, false);

            if (model == null)
            {
                long queryId = 0L;
                try
                {
                    AvrServiceAccessability access = AvrServiceAccessability.Check();
                    if (!access.IsOk)
                    {
                        m_ErrorMessage = access.ErrorMessage;
                        return null;
                    }

                    model = FillData(ref queryId, layoutId);
                }
                catch (Exception ex)
                {
                    m_ErrorMessage = ex.Message;
                    return null;
                }
                ObjectStorage.Put(Session.SessionID, queryId, layoutId, StoragePrefix, model);
            }
            LayoutPivotGridHelper.ResetDisplayTextHandler();

            return model;
        }

        private ActionResult SaveData()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object)m_ErrorMessage);
            }

            var helper = new LayoutHelper(model.PivotSettings.LayoutDataset);
            if (helper.SaveData(model.PivotSettings))
            {
                model.PivotSettings.HasChanges = false;
                model.PivotSettings.Fields.ForEach(f => f.HasChanges = false);
                ObjectStorage.Remove(Session.SessionID, model.PivotSettings.LayoutId, ViewLayoutController.StoragePrefix);

                ServiceClientHelper.AvrServiceClearViewCache(model.PivotSettings.LayoutId);
            }
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private string RefreshPivotData()
        {
            AvrServiceAccessability access = AvrServiceAccessability.Check();
            if (!access.IsOk)
            {
                return access.ErrorMessage;
            }
            AvrPivotGridModel model = GetModelFromSession();
            if (model != null)
            {
                ServiceClientHelper.AvrServiceClearQueryCache(model.PivotSettings.QueryId);
                RemovePivotViewObjects(model.PivotSettings.LayoutId);
            }
            return string.Empty;
        }

        private void RemovePivotViewObjects(long layoutId)
        {
            ObjectStorage.Remove(Session.SessionID, layoutId, StoragePrefix);
            ObjectStorage.Remove(Session.SessionID, layoutId, ViewLayoutController.StoragePrefix);
        }
    }
}