using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.common.Core;
using bv.common.db.Core;
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
using eidss.web.common.Utils;

namespace eidss.avr.mweb.Controllers
{
    [AuthorizeEIDSS]
    public class LayoutController : Controller
    {
        private const string StoragePrefix = "PIVOT";
        private const string ViewStoragePrefix = "VIEW";
        public WebLayoutDB LayoutDBService { get; private set; }
        private string m_ErrorMessage;

        [HttpGet]
        public ActionResult Layout(long queryId, long layoutId)
        {
            ViewBag.LayoutId = layoutId;
            if (Request.QueryString.AllKeys.Contains("clearcache") && Request.QueryString["clearcache"] == "1")
            {
                ModelStorage.Remove(Session.SessionID, layoutId, StoragePrefix);
            }
            AvrPivotGridModel model = GetModelFromSession(layoutId, queryId);
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.IsFirstLoad = true;
            ViewBag.Title = string.Format(Translator.GetMessageString("webPivotGridTitle"),
                ((LayoutDetailDataSet.LayoutRow) (model.PivotSettings.LayoutDataset.Layout.Rows[0])).strLayoutName);
            return View(model);
        }

        //[HttpGet]
        public ActionResult OnRefreshData(string text)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
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
                Data = new {result = "noask", function = "RefeshData"}
            };
        }

        [HttpGet]
        public ActionResult OnCancelChanges()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
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
                        messageText = Translator.GetBvMessageString("Cancel changes?"),
                        yesFunction = String.Format("document.location.href='{0}'", Url.Action("CancelChanges", "Layout")),
                        noFunction = ""
                    }
                };
            }
            // finish, don't show confirmation
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new {result = "noask"}};
        }

        [HttpGet]
        public ActionResult OnClose()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model != null && model.PivotSettings != null)
            {
                ModelStorage.Remove(Session.SessionID, model.PivotSettings.LayoutId, StoragePrefix);
            }
            // finish, don't show confirmation
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult CancelChanges()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model != null)
            {
                ModelStorage.Remove(Session.SessionID, model.PivotSettings.LayoutId, StoragePrefix);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult RefeshData()
        {
            string error = RefreshPivotData();
            if (!string.IsNullOrEmpty(error))
            {
                return View("AvrServiceError", (object) error);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult RefeshData2()
        {
            string url = HttpContext.Request.UrlReferrer.AbsoluteUri;
            int ind = url.IndexOf("&clearcache");
            if (ind > 0)
                url = url.Substring(0, ind);

            AvrPivotGridModel model = GetModelFromSession();
            if (model != null)
            {
                if (model.PivotSettings.SelectedField != null)
                    model.PivotSettings.SelectedField.Action = WebFieldAction.None;
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
                return View("AvrServiceError", (object) error);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult PivotGridPartial()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            return PartialView(model);
        }

        public ActionResult ColumnAttributesPartial()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            return PartialView(model);
        }

        public ActionResult FieldsListCombo()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            return PartialView(model);
        }

        public ActionResult ShowMissedValues(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.ShowMissedValues = value;
            model.PivotSettings.ShowMissedValuesSaved = model.PivotSettings.ShowMissedValues;
            model.PivotSettings.ShowDataInPivot = true;
            if (model.PivotSettings.ShowMissedValues)
            {
                List<IAvrPivotGridField> fields = model.PivotSettings.Fields.Cast<IAvrPivotGridField>().ToList();
                AvrPivotGridHelper.AddMissedValuesInRowColumnArea(model, fields);
            }
            else
            {
                bool isNewObject;
                model.PivotData = GetPivotData(model.PivotSettings.LayoutDataset, model.PivotSettings.QueryId,
                    model.PivotSettings.LayoutId, model.PivotSettings.UseArchiveData, out isNewObject);
            }
            //return RedirectToAction("Layout", new { queryId = model.PivotSettings.QueryId, model.PivotSettings.LayoutId });
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok"};
            //return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult ShowData(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.ShowDataInPivot = value;

            model.PivotSettings.ShowMissedValues = model.PivotSettings.ShowDataInPivot && model.PivotSettings.ShowMissedValuesSaved;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new {showMissedValues = model.PivotSettings.ShowMissedValues}
            };
        }

        public ActionResult CompactLayout(bool isCompactLayout)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.CompactLayout = isCompactLayout;
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok"};
        }

        public ActionResult UseArchiveData(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.UseArchiveData = value;
            bool isNewObject;
            model.PivotData = GetPivotData(model.PivotSettings.LayoutDataset, model.PivotSettings.QueryId,
                model.PivotSettings.LayoutId, model.PivotSettings.UseArchiveData, out isNewObject);
            if (model.PivotSettings.ShowMissedValues)
            {
                List<IAvrPivotGridField> fields = model.PivotSettings.Fields.Cast<IAvrPivotGridField>().ToList();
                AvrPivotGridHelper.AddMissedValuesInRowColumnArea(model, fields);
            }
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok"};
        }

        public ActionResult FreezeRowHeaders(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.FreezeRowHeaders = value;
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok"};
        }

        public ActionResult ApplyFilter(bool value)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.ApplyFilter = value;
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok"};
        }

        public ActionResult ShowPrefilter()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.ShowPrefilter = true;
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok"};
        }

        private DataTable GetPivotData(LayoutDetailDataSet ds, long queryId, long layoutId, bool useArchiveData, out bool isNewObject)
        {
            CachedQueryResult queryResult = ServiceClientHelper.ExecQuery(queryId, useArchiveData);
            isNewObject = ds.LayoutSearchField.Count == 0;
            return AvrPivotGridHelper.GetPreparedDataSource(ds.LayoutSearchField, queryId, layoutId, queryResult.QueryTable, isNewObject);
        }

        public AvrPivotGridModel FillData(long queryId, long layoutId)
        {
            LayoutDBService = new WebLayoutDB();
            var sessionDataSet = (LayoutDetailDataSet) LayoutDBService.GetDetail(layoutId);
            var helper = new LayoutHelper(sessionDataSet);

            var pivotSettings = new AvrPivotSettings(queryId, layoutId);
            helper.InitAvrPivotSettings(pivotSettings);
            bool isNewObject;
            DataTable pivotData = GetPivotData(helper.LayoutDataSet, queryId, layoutId, pivotSettings.UseArchiveData, out isNewObject);

            pivotSettings.Fields = AvrPivotGridHelper.CreateFields<WebPivotGridField>(pivotData);
            helper.PrepareWebFields(pivotSettings);
            var fields = pivotSettings.Fields.Cast<IAvrPivotGridField>().ToList();
            helper.LoadPivotFromDB(new AvrPivotGridData(pivotData), 
                fields, isNewObject);
            //helper.FillCustomSummaryTypes();

            return new AvrPivotGridModel(pivotSettings, pivotData);
        }

        [HttpPost]
        public ActionResult HasChanges()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
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
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "no"};
        }

        [HttpPost]
        public ActionResult OnSwitchToView()
        {
            AvrPivotGridModel model = GetModelFromSession();

            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
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
                            String.Format("document.location.href='{0}'", Url.Action("SwitchToView", "Layout", new {saveData = true})),
                        noFunction = ""
                    }
                };
            }
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new {result = "noask", function = "SwitchToView?saveData=false"}
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
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            return
                new RedirectResult(Url.Action("ViewLayout", "ViewLayout",
                    new {queryId = model.PivotSettings.QueryId, model.PivotSettings.LayoutId}));
        }

        public ActionResult TotalsChanged(FormCollection form)
        {
            AvrPivotGridModel model = GetModelFromSession();

            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;

            string[] totalValues = (form != null && form.Count > 0) ? form[0].Split(',') : "".Split(',');
            model.PivotSettings.ShowColumnTotals = totalValues.Count(c => c == "1") > 0;
            model.PivotSettings.ShowRowTotals = totalValues.Count(c => c == "2") > 0;
            model.PivotSettings.ShowColumnGrandTotals = totalValues.Count(c => c == "3") > 0;
            model.PivotSettings.ShowRowGrandTotals = totalValues.Count(c => c == "4") > 0;
            model.PivotSettings.ShowTotalsForSingleValues = totalValues.Count(c => c == "5") > 0;
            return new JsonResult {Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult DefaultGroupDateChanged(long value)
        {
            AvrPivotGridModel model = GetModelFromSession();

            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.HasChanges = true;
            model.PivotSettings.DefaultGroupInterval = value;
            model.PivotSettings.UpdateGroupInterval = true;

            return new JsonResult {Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
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
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            model.PivotSettings.SelectedField = !string.IsNullOrEmpty(text) 
                ? model.PivotSettings.Fields.FirstOrDefault(f => f.FieldName == text) 
                : null;
            return new JsonResult {Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        //[HttpPost]
        // public ActionResult OnSaveFieldChanges() 
        public ActionResult AggregateFunctionChanged(string aggregateFunctionId)
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
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
                    string strPrecision = LookupCache.GetLookupValue((long) summaryTypeType, LookupTables.AggregateFunction,
                        "intDefaultPrecision");
                    intPrecision = int.TryParse(strPrecision, out intPrecision)
                        ? intPrecision
                        : -1;
                }
            }
            return new JsonResult {Data = new {precision = (decimal) intPrecision}, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult OnSaveFieldChanges
            (string caption, string captionEn, string aggregateFunctionId, string precision, string adminUnitField, string dateField,
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
                    model.PivotSettings.SelectedField.GetClonedField(model.PivotSettings.LayoutDataset);
                if (ModelUserContext.CurrentLanguage != Localizer.lngEn)
                {
                    clonedField.Caption = caption;
                }
                clonedField.CaptionEn = captionEn;
                clonedField.AggregateFunctionId = bv.common.Core.Utils.ToLong(aggregateFunctionId);
                clonedField.Precision = bv.common.Core.Utils.ToNullableInt(precision);
                clonedField.UnitLayoutSearchFieldId = bv.common.Core.Utils.ToNullableLong(adminUnitField);
                clonedField.DateLayoutSearchFieldId = bv.common.Core.Utils.ToNullableLong(dateField);
                clonedField.PrivateGroupInterval = bv.common.Core.Utils.ToNullableLong(groupInterval);
                clonedField.AddMissedValues = bool.Parse(addMissedValue);
                clonedField.DiapasonStartDate = bv.common.Core.Utils.ToDateNullable(startDate);
                clonedField.DiapasonEndDate = bv.common.Core.Utils.ToDateNullable(endDate);
                string error = ValidateFieldClone(clonedField, model.PivotSettings.SelectedField.IsDateTimeField);
                if (!string.IsNullOrEmpty(error))
                {
                    return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet,
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
                    model.PivotSettings.SelectedField.Action = WebFieldAction.Edit;
                model.PivotSettings.UpdatedField = model.PivotSettings.SelectedField;
                if (model.PivotSettings.SelectedField.HasChanges)
                {
                    model.PivotSettings.HasChanges = true;
                }
            }
            if (model.PivotSettings.SelectedField.Action != WebFieldAction.Add)
                return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { result="refresh", function = "RefeshData2" }
            };
        }

        private string ValidateFieldClone(WebPivotGridFieldClone clonedField, bool isDateTimeField)
        {
            string error = String.Empty;
            const string lineSeparator = "<br/>";
            if (string.IsNullOrEmpty(clonedField.CaptionEn))
            {
                bv.common.Core.Utils.AppendLine(ref error,
                    string.Format(Translator.GetBvMessageString("ErrMandatoryFieldRequired"),
                        Translator.GetMessageString("strNewColumnNameEn")), lineSeparator);
            }
            if (ModelUserContext.CurrentLanguage != Localizer.lngEn && string.IsNullOrEmpty(clonedField.Caption))
            {
                bv.common.Core.Utils.AppendLine(ref error,
                    string.Format(Translator.GetBvMessageString("ErrMandatoryFieldRequired"),
                        Translator.GetMessageString("strNewColumnName")), lineSeparator);
            }

            if (clonedField.AddMissedValues && isDateTimeField)
            {
                if (clonedField.DiapasonStartDate == null)
                {
                    bv.common.Core.Utils.AppendLine(ref error,
                        string.Format(Translator.GetBvMessageString("ErrMandatoryFieldRequired"), Translator.GetMessageString("DateFrom")),
                        lineSeparator);
                }
                if (clonedField.DiapasonEndDate == null)
                {
                    bv.common.Core.Utils.AppendLine(ref error,
                        string.Format(Translator.GetBvMessageString("ErrMandatoryFieldRequired"), Translator.GetMessageString("DateTo")),
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
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            if (model.PivotSettings.SelectedField != null)
            {
                model.PivotSettings.SelectedField.CancelChanges(model.PivotSettings.LayoutDataset);
            }
            if (model.PivotSettings.SelectedField.Action != WebFieldAction.Add)
                return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

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
                return View("AvrServiceError", (object) m_ErrorMessage);
            }
            if (string.IsNullOrEmpty(fieldId))
            {
                return new JsonResult {Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
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
                return View("AvrServiceError", (object) m_ErrorMessage);
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
            return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new {result = "noask"}};
        }

        public ActionResult DeleteFieldCopy()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
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
            return new JsonResult {Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        private AvrPivotGridModel GetModelFromSession(long layoutId = -1, long queryId = -1)
        {
            if (layoutId <= 0)
            {
                NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
                layoutId = Convert.ToInt64(nameValueCollection["layoutId"]);
            }
            var model = ModelStorage.Get(Session.SessionID, layoutId, StoragePrefix, false) as AvrPivotGridModel;
            if (model == null)
            {
                try
                {
                    AvrServiceAccessability access = AvrServiceAccessability.Check();
                    if (!access.IsOk)
                    {
                        m_ErrorMessage = access.ErrorMessage;
                        return null;
                    }
                    if (queryId <= 0)
                    {
                        NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
                        queryId = Convert.ToInt64(nameValueCollection["queryId"]);
                    }
                    model = FillData(queryId, layoutId);
                }
                catch (Exception ex)
                {
                    m_ErrorMessage = ex.Message;
                    return null;
                }
                ModelStorage.Put(Session.SessionID, queryId, layoutId, StoragePrefix, model);
            }
            return model;
        }

        private ActionResult SaveData()
        {
            AvrPivotGridModel model = GetModelFromSession();
            if (model == null)
            {
                return View("AvrServiceError", (object) m_ErrorMessage);
            }

            var helper = new LayoutHelper(model.PivotSettings.LayoutDataset);
            if (helper.SaveData(model.PivotSettings))
            {
                model.PivotSettings.HasChanges = false;
                model.PivotSettings.Fields.ForEach(f => f.HasChanges = false);
                ModelStorage.Remove(Session.SessionID, model.PivotSettings.LayoutId, ViewStoragePrefix);
            }
            return new JsonResult {Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
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
                using (var wrapper = new ServiceClientWrapper())
                {
                    wrapper.InvalidateQueryCacheForLanguage(model.PivotSettings.QueryId, ModelUserContext.CurrentLanguage);
                }
                ModelStorage.Remove(Session.SessionID, model.PivotSettings.LayoutId, StoragePrefix);
            }
            return string.Empty;
        }
    }
}