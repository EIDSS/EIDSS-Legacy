using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.PivotGrid;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraPrinting.Native;
using EIDSS.Enums;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using eidss.avr.db.Common;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.mweb.Models;
using eidss.model.Avr.Chart;
using eidss.model.Avr.Pivot;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.web.common.Utils;
using PivotFieldEventArgs = DevExpress.Web.ASPxPivotGrid.PivotFieldEventArgs;
using PivotGridField = DevExpress.Web.ASPxPivotGrid.PivotGridField;

namespace eidss.avr.mweb.Utils
{
    public class LayoutPivotGridHelper
    {
        private const string StoragePrefix = "PIVOT";
        private static CustomSummaryHandler m_CustomSummaryHandler;
        private static DisplayTextHandler m_DisplayTextHandler;

        public static AvrPivotGridModel GetModelFromSession(HttpRequest request)
        {
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(request.Url.Query);
            long layoutId = Convert.ToInt64(nameValueCollection["layoutId"]);
            if (layoutId == 0)
            {
                nameValueCollection = HttpUtility.ParseQueryString(request.UrlReferrer.Query);
                layoutId = Convert.ToInt64(nameValueCollection["layoutId"]);
            }
            if (request.RequestContext.HttpContext.Session != null)
                return
                    ModelStorage.Get(request.RequestContext.HttpContext.Session.SessionID, layoutId, StoragePrefix,
                                     false) as AvrPivotGridModel;
            return null;
        }

        public static AvrPivotGridModel GetModelFromSession(HttpRequestBase request)
        {
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(request.Url.Query);
            long layoutId = Convert.ToInt64(nameValueCollection["layoutId"]);
            if (layoutId == 0)
            {
                nameValueCollection = HttpUtility.ParseQueryString(request.UrlReferrer.Query);
                layoutId = Convert.ToInt64(nameValueCollection["layoutId"]);
            }
            if (request.RequestContext.HttpContext.Session != null)
                return
                    ModelStorage.Get(request.RequestContext.HttpContext.Session.SessionID, layoutId, StoragePrefix,
                                     false) as AvrPivotGridModel;
            return null;
        }

        public static PivotGridSettings LayoutPivotGridSettings(HttpRequestBase request)
        {
            var model = GetModelFromSession(request);
            if (model.ControlPivotGridSettings == null || model.IsFirstLoad)
            {
                model.IsFirstLoad = false;
                m_CustomSummaryHandler = null;
                model.ControlPivotGridSettings = CreateLayoutPivotGridSettings(model);
            }
            return model.ControlPivotGridSettings;
        }

        private static PivotGridSettings CreateLayoutPivotGridSettings(AvrPivotGridModel model)
        {
            var settings = new PivotGridSettings();
            var readOnly = model.PivotSettings.IsPublished | !eidss.model.Core.AvrPermissions.UpdatePermission;

            settings.Name = "pivotGrid";
            settings.CallbackRouteValues =
                new
                    {
                        Controller = "Layout",
                        Action = "PivotGridPartial",
                        queryId = model.PivotSettings.QueryId,
                        layoutId = model.PivotSettings.LayoutId
                    };
            settings.CustomActionRouteValues =
                new
                    {
                        Controller = "Layout",
                        Action = "PivotGridPartial",
                        queryId = model.PivotSettings.QueryId,
                        layoutId = model.PivotSettings.LayoutId
                    };
            if (model.PivotSettings.FreezeRowHeaders)
                settings.Width = Unit.Percentage(99);
            settings.OptionsView.ShowFilterHeaders = false;
            settings.OptionsView.ShowHorizontalScrollBar = model.PivotSettings.FreezeRowHeaders;
            settings.OptionsView.ShowColumnHeaders = true;
            settings.OptionsView.ShowRowHeaders = true;
            settings.OptionsView.DataHeadersDisplayMode = PivotDataHeadersDisplayMode.Popup;
            settings.OptionsView.DataHeadersPopupMaxColumnCount = 3;
            //settings.OptionsDataField.RowHeaderWidth = 100;
            settings.OptionsPager.Position = PagerPosition.Bottom;
            settings.OptionsPager.RowsPerPage = BaseSettings.AvrRowsPerPage;

            // note: this option disables paging. commented by Ivan because of out of memory
            //  settings.OptionsPager.Visible = false;
            settings.OptionsBehavior.BestFitMode = PivotGridBestFitMode.FieldValue; // PivotGridBestFitMode.Cell;

            settings.CustomLoadCallbackState = CustomLoadCallbackState;

            settings.OptionsCustomization.AllowDrag = !readOnly;
            settings.OptionsCustomization.AllowExpand = !readOnly;
            settings.OptionsCustomization.AllowDragInCustomizationForm = true;
            settings.OptionsCustomization.AllowHideFields = AllowHideFieldsType.Always;
            settings.OptionsCustomization.CustomizationFormStyle = CustomizationFormStyle.Simple;
            settings.OptionsCustomization.AllowCustomizationForm = !readOnly;
            SetTotalSettings(settings.OptionsView, model.PivotSettings);
            settings.PivotCustomizationExtensionSettings.Name = "pivotCustomization";
            settings.PivotCustomizationExtensionSettings.Enabled = !readOnly;
            settings.PivotCustomizationExtensionSettings.Visible = !readOnly;
            settings.PivotCustomizationExtensionSettings.AllowedLayouts = CustomizationFormAllowedLayouts.TopPanelOnly;
            settings.PivotCustomizationExtensionSettings.Layout = CustomizationFormLayout.TopPanelOnly;
            settings.PivotCustomizationExtensionSettings.AllowSort = true;
            settings.PivotCustomizationExtensionSettings.AllowFilter = false;
            settings.PivotCustomizationExtensionSettings.Height = Unit.Percentage(100);
            settings.PivotCustomizationExtensionSettings.Width = Unit.Percentage(100);
            settings.OptionsCustomization.AllowPrefilter = false;
            settings.Prefilter.Enabled = model.PivotSettings.ApplyFilter;
            settings.OptionsView.EnableFilterControlPopupMenuScrolling = true;
            settings.Prefilter.Criteria = CriteriaOperator.TryParse(model.PivotSettings.FilterCriteriaString);
            settings.Styles.PrefilterBuilderCloseButtonStyle.CssClass = "invisible";
            settings.Styles.PrefilterBuilderHeaderStyle.CssClass = "roundbox";
            //    {

            //    };
            settings.FilterControlOperationVisibility = (sender, args) =>
                {
                    var webField = GetWebPivotGridFieldByName(model.PivotSettings.Fields, args.PropertyInfo.PropertyName);
                    if (webField == null)
                    {
                        args.Visible = false;
                        return;
                    }
                    switch (webField.SearchFieldType)
                    {
                        case SearchFieldType.ID://lookup 
                            args.Visible = IsValidLookupClause(args.Operation);
                            break;
                        case SearchFieldType.String:
                            args.Visible = IsValidStringClause(args.Operation);
                            break;

                        case SearchFieldType.Date:
                            args.Visible = IsValidDateClause(args.Operation);
                            break;
                        default:
                            args.Visible = IsValidDefaultClause(args.Operation);
                            break;

                    }
                };
            settings.FilterControlParseValue = (sender, args) =>
                {

                };
            settings.FilterControlCustomValueDisplayText = (sender, args) =>
                {
                    if (args.PropertyInfo.PropertyType == typeof(DateTime) && args.Value != null)
                    {
                        args.DisplayText = string.Format("{0:d}", args.Value);
                    }
                };
            //settings.CustomFilterPopupItems = (sender, args) =>
            //    {

            //    };

            //    settings.Prefilter.CriteriaString = model.PivotSettings.FilterCriteriaString;
            settings.OptionsCustomization.AllowFilterInCustomizationForm = true;
            settings.Theme = GeneralSettings.Theme;
            settings.Fields.Clear();

            foreach (
                WebPivotGridField webField in
                    model.PivotSettings.Fields.OrderBy(f => f.AreaIndex)) //Where(c => !c.IsHiddenFilterField).
            {
                settings.Fields.Add(webField);
            }

            settings.Init = (sender, args) =>
                {
                    var pivotGrid = (MVCxPivotGrid)sender;
                    pivotGrid.PrefilterCriteriaChanged += PrefilterCriteriaChanged;
                    pivotGrid.FieldAreaChanged += PivotGridOnFieldAreaChanged;
                };
            settings.PreRender = (sender, e) =>
                {
                    var pivotGrid = (MVCxPivotGrid)sender;
                    pivotGrid.BeginUpdate();
                    pivotGrid.EndUpdate();
                };

            settings.BeforeGetCallbackResult = (sender, e) =>
                {
                    var pivotGrid = (MVCxPivotGrid)sender;
                    if (model.ShowPrefilter)
                    {
                        pivotGrid.IsPrefilterPopupVisible = true;
                        CriteriaOperator criteria = CriteriaOperator.TryParse(model.PivotSettings.FilterCriteriaString);
                        criteria = ValidatePrefilterCriteria(criteria);
                        pivotGrid.Prefilter.Criteria = criteria;
                        model.ShowPrefilter = false;
                        return;
                    }
                    pivotGrid.Prefilter.Enabled = model.PivotSettings.ApplyFilter;
                    pivotGrid.BeginUpdate();
                    UpdatePivotGridField(pivotGrid, model.PivotSettings.UpdatedField);

                    model.PivotSettings.UpdatedField = null;
                    if (model.PivotSettings.UpdateGroupInterval)
                    {
                        var interval = GroupIntervalHelper.GetGroupInterval(model.PivotSettings.DefaultGroupInterval);
                        SetInterval(pivotGrid, interval);
                        model.PivotSettings.UpdateGroupInterval = false;
                    }
                    SetTotalSettings(pivotGrid.OptionsView, model.PivotSettings);
                    //if (pivotGrid.OptionsView.ShowHorizontalScrollBar != model.PivotSettings.FreezeRowHeaders)
                    //{
                    if (model.PivotSettings.FreezeRowHeaders)
                        pivotGrid.Width = Unit.Percentage(99);
                    else
                        pivotGrid.Width = Unit.Empty;
                    pivotGrid.OptionsView.ShowHorizontalScrollBar = model.PivotSettings.FreezeRowHeaders;
                    //}
                    //else
                    //    pivotGrid.Prefilter.Criteria = null;
                    pivotGrid.EndUpdate();
                    pivotGrid.ReloadData();
                };

            //settings.ClientSideEvents.EndCallback = "layoutPivotGrid.resizePivotGridEvent";

            settings.AfterPerformCallback = (sender, e) =>
            {
                var pivotGrid = (MVCxPivotGrid)sender;

                //    //if (ViewBag.saveLayout)
                //    {
                //        try
                //        {
                //            SaveLayout(pivotGrid);
                //        }
                //        finally
                //        {
                //            CookiesWrapper.SaveLayout = false;
                //        }
                //    }
            };

            settings.ClientSideEvents.CallbackError = "layoutPivotGrid.onCallbackError";

            settings.CustomCellDisplayText = (sender, e) =>
                {
                    if (m_DisplayTextHandler == null)
                    {
                        m_DisplayTextHandler = new DisplayTextHandler();
                    }
                    m_DisplayTextHandler.DisplayAsterisk(new WebPivotCellDisplayTextEventArgs(e));
                    if (e.DataField == null)
                    {
                        return;
                    }
                    if (model.PivotSettings.FieldsDictionary.ContainsKey(e.DataField.FieldName))
                    {
                        var field = model.PivotSettings.FieldsDictionary[e.DataField.FieldName];
                        m_DisplayTextHandler.DisplayCellText(new WebPivotCellDisplayTextEventArgs(e), field.CustomSummaryType, field.Precision);
                    }
                };

            settings.FieldValueDisplayText = (sender, e) =>
                {
                    if (m_DisplayTextHandler == null)
                    {
                        m_DisplayTextHandler = new DisplayTextHandler();
                    }
                    m_DisplayTextHandler.DisplayAsterisk(new WebPivotFieldDisplayTextEventArgs(e));

                    if (m_CustomSummaryHandler == null)
                    {
                        var helper = new AvrPivotGridHelperWeb((ASPxPivotGrid)sender);
                        m_CustomSummaryHandler = new CustomSummaryHandler(helper);
                    }
                    var summaryTypes = new List<CustomSummaryType>();
                    foreach (PivotGridFieldBase field in ((MVCxPivotGrid)sender).Fields)
                    {
                        if (field.Area == PivotArea.DataArea)
                        {
                            if (model.PivotSettings.FieldsDictionary.ContainsKey(field.FieldName))
                            {
                                var webPivotGridField = model.PivotSettings.FieldsDictionary[field.FieldName];
                                summaryTypes.Add(webPivotGridField.CustomSummaryType);
                            }
                        }
                        m_DisplayTextHandler.DisplayStatisticsTotalCaption(new WebPivotFieldDisplayTextEventArgs(e),
                                                                           summaryTypes);
                    }
                };

            settings.CustomSummary = (sender, e) =>
                {
                    if (m_CustomSummaryHandler == null)
                    {
                        var helper = new AvrPivotGridHelperWeb((ASPxPivotGrid)sender);
                        m_CustomSummaryHandler = new CustomSummaryHandler(helper);
                    }

                    var settingsField = model.PivotSettings.Fields.Find(f => f.FieldName == e.DataField.FieldName);
                    var field = e.DataField as IAvrPivotGridField;

                    if (settingsField != null && field != null && ((int)field.CustomSummaryType <= 0))
                    {
                        field.CustomSummaryType = settingsField.CustomSummaryType;
                        field.UnitLayoutSearchFieldId = settingsField.UnitLayoutSearchFieldId;
                        field.UnitSearchFieldAlias= settingsField.UnitSearchFieldAlias;
                    }
                    m_CustomSummaryHandler.OnCustomSummary(sender, new WebPivotGridCustomSummaryEventArgs(e));
                };
            settings.GridLayout = (sender, args) =>
                {
                    var pivotGrid = (MVCxPivotGrid)sender;
                    model.PivotSettings.HasChanges = true;
                    var fieldsToDelete = new List<PivotGridFieldBase>();
                    foreach (PivotGridField field in pivotGrid.Fields)
                    {
                        var webField = GetWebPivotGridFieldByFieldName(model.PivotSettings.Fields, field.FieldName);
                        if (webField != null)
                        {
                            PivotFieldItemBase visualField =
                                pivotGrid.Fields.Data.VisualItems.Data.FieldItems.SingleOrDefault(
                                    s => s.FieldName == field.FieldName);
                            Dbg.Assert(visualField != null, "field {0} is not found in pivot fields list",
                                       field.FieldName);
                            if (!visualField.Visible && visualField.Area != PivotArea.FilterArea)
                            {
                                webField.Area = PivotArea.FilterArea;
                                webField.AreaIndex = -1;
                            }
                            else
                            {
                                webField.Area = field.Area;
                                webField.AreaIndex = field.AreaIndex;
                                webField.Visible = field.Visible;
                                //if (webField.IsDateTimeField && webField.GroupInterval == PivotGroupInterval.Default)
                                //{
                                //    webField.DefaultGroupInterval = GroupIntervalHelper.GetGroupInterval(model.PivotSettings.DefaultGroupInterval);
                                //    field.GroupInterval = webField.GroupInterval;
                                //}
                            }

                        }
                        else
                            fieldsToDelete.Add(field);

                    }
                    foreach (PivotGridFieldBase field in fieldsToDelete)
                    {
                        field.Visible = false;
                        field.Area = PivotArea.FilterArea;
                        field.AreaIndex = -1;
                        pivotGrid.Fields.Remove(field);
                    }
                    if (model.PivotSettings.ShowMissedValues)
                    {
                        List<IAvrPivotGridField> fields = model.PivotSettings.Fields.Cast<IAvrPivotGridField>().ToList();
                        AvrPivotGridHelper.AddMissedValuesInRowColumnArea(model, fields);
                    }
                    if (fieldsToDelete.Count > 0)
                        pivotGrid.ReloadData();

                };
            return settings;
        }

        private static bool IsValidDefaultClause(ClauseType operation)
        {
            switch (operation)
            {
                case ClauseType.Equals:
                case ClauseType.IsNotNull:
                case ClauseType.IsNull:
                case ClauseType.DoesNotEqual:
                case ClauseType.Less:
                case ClauseType.LessOrEqual:
                case ClauseType.Greater:
                case ClauseType.GreaterOrEqual:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsValidDateClause(ClauseType operation)
        {
            switch (operation)
            {
                case ClauseType.Between:
                case ClauseType.NotBetween:
                case ClauseType.Like:
                case ClauseType.NotLike:
                case ClauseType.AnyOf:
                case ClauseType.NoneOf:
                case ClauseType.IsLaterThisMonth:
                case ClauseType.IsLaterThisWeek:
                case ClauseType.IsLaterThisYear:
                case ClauseType.IsTomorrow:
                case ClauseType.IsNextWeek:
                case ClauseType.IsBeyondThisYear:
                    return false;
                default:
                    return true;
            }
        }

        private static bool IsValidStringClause(ClauseType operation)
        {
            switch (operation)
            {
                case ClauseType.Equals:
                case ClauseType.DoesNotEqual:
                case ClauseType.Greater:
                case ClauseType.GreaterOrEqual:
                case ClauseType.Less:
                case ClauseType.LessOrEqual:
                case ClauseType.Contains:
                case ClauseType.DoesNotContain:
                case ClauseType.BeginsWith:
                case ClauseType.EndsWith:
                case ClauseType.Like:
                case ClauseType.NotLike:
                case ClauseType.IsNotNull:
                case ClauseType.IsNull:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsValidLookupClause(ClauseType operation)
        {
            switch (operation)
            {
                case ClauseType.Equals:
                case ClauseType.IsNotNull:
                case ClauseType.IsNull:
                case ClauseType.DoesNotEqual:
                    return true;
                default:
                    return false;
            }
        }

        private static void PrefilterCriteriaChanged(object sender, EventArgs e)
        {
            var pivotGrid = (MVCxPivotGrid)sender;
            var model = GetModelFromSession(pivotGrid.Request);
            model.PivotSettings.FilterCriteriaString = pivotGrid.Prefilter.CriteriaString;
            pivotGrid.Prefilter.Enabled = model.PivotSettings.ApplyFilter;
            model.PivotSettings.HasChanges = true;
        }

        private static CriteriaOperator ValidatePrefilterCriteria(CriteriaOperator criteria)
        {
            if (ReferenceEquals(criteria, null))
                return null;
            var validator = new FilterValidator();
            return criteria.Accept(validator) as CriteriaOperator;
        }

        private static void CustomLoadCallbackState
            (object sender, PivotGridCallbackStateEventArgs pivotGridCallbackStateEventArgs)
        {
            var pivotGrid = (MVCxPivotGrid)sender;

            //HttpContext.Current.Session["layoutGrid"] = pivotGrid.SaveLayoutToString();
        }

        private static void PivotGridOnFieldAreaChanged(object sender, PivotFieldEventArgs pivotFieldEventArgs)
        {
            var pivotGrid = (MVCxPivotGrid)sender;

            //HttpContext.Current.Session["layoutGrid"] = pivotGrid.SaveLayoutToString();
        }

        public static WebPivotGridField GetWebPivotGridFieldByFieldName
            (Dictionary<string, WebPivotGridField> fields, string fieldName)
        {
            if (fields.ContainsKey(fieldName))
            {
                return fields[fieldName];
            }
            return null;
        }

        public static WebPivotGridField GetWebPivotGridFieldByFieldName(List<WebPivotGridField> fields, string fieldName)
        {
            if (fields.Count(f => f.FieldName == fieldName) > 0)
                return fields.SingleOrDefault(f => f.FieldName == fieldName);
            return null;
        }

        public static WebPivotGridField GetWebPivotGridFieldByName(List<WebPivotGridField> fields, string name)
        {
            if (fields.Count(f => f.Name == name) > 0)
                return fields.SingleOrDefault(f => f.Name == name);
            return null;
        }

        public static PivotGridField GetPivotGridField(MVCxPivotGrid pivotGrid, string fieldName)
        {
            foreach (PivotGridField field in pivotGrid.Fields)
            {
                if (field.FieldName.Equals(fieldName))
                    return field;
            }
            return null;
        }
        private static void SetInterval(MVCxPivotGrid pivotGrid, PivotGroupInterval interval)
        {
            var model = GetModelFromSession(pivotGrid.Request);

            foreach (PivotGridField field in pivotGrid.Fields)
            {
                WebPivotGridField webField = GetWebPivotGridFieldByFieldName(model.PivotSettings.Fields, field.FieldName);
                if (webField != null)
                {
                    webField.DefaultGroupInterval = interval;
                    field.GroupInterval = webField.GroupInterval;
                    model.PivotSettings.DefaultGroupInterval = (long)GroupIntervalHelper.GetDBGroupInterval(interval);
                }
                else
                {
                    field.GroupInterval = interval;
                }
            }
        }

        public class CheckListItem
        {
            public CheckListItem(string id, string name)
            {
                ID = id;
                Name = name;
            }

            public string ID { get; set; }
            public string Name { get; set; }

        }

        public static List<CheckListItem> GetTotalsList(AvrPivotGridModel model)
        {
            var list = new List<CheckListItem>();
            list.Add(new CheckListItem("1", Translator.GetMessageString("itemCols")));
            list.Add(new CheckListItem("2", Translator.GetMessageString("itemRows")));
            list.Add(new CheckListItem("3", Translator.GetMessageString("itemColGrand")));
            list.Add(new CheckListItem("4", Translator.GetMessageString("itemRowGrand")));
            list.Add(new CheckListItem("5", Translator.GetMessageString("itemForSingle")));
            return list;
        }

        public static string GetTotalsText(AvrPivotGridModel model)
        {
            string text = "";
            const string sep = ", ";
            if (model.PivotSettings.ShowColumnTotals)
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemCols"), sep);
            if (model.PivotSettings.ShowRowTotals)
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemRows"), sep);
            if (model.PivotSettings.ShowColumnGrandTotals)
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemColGrand"), sep);
            if (model.PivotSettings.ShowRowGrandTotals)
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemRowGrand"), sep);
            if (model.PivotSettings.ShowTotalsForSingleValues)
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemForSingle"), sep);
            return text;
        }

        private static void SetTotalSettings(PivotGridWebOptionsView optionsView, AvrPivotSettings pivotSettings)
        {
            if (pivotSettings.CompactLayout)
            {
                optionsView.ShowRowTotals = true;
                optionsView.ShowTotalsForSingleValues = true;
                //optionsView.ShowRowHeaders = false;
                //optionsView.ShowRowTotals = true must be set before this call
                optionsView.RowTotalsLocation = PivotRowTotalsLocation.Tree;
            }
            else
            {
                //This call must be first statement because when optionsView.RowTotalsLocation = PivotRowTotalsLocation.Tree
                //optionsView.ShowRowTotals must be set to true
                optionsView.RowTotalsLocation = PivotRowTotalsLocation.Far;
                //optionsView.ShowRowHeaders = true;

                optionsView.ShowColumnTotals = pivotSettings.ShowColumnTotals;
                optionsView.ShowRowTotals = pivotSettings.ShowRowTotals;
                optionsView.ShowColumnGrandTotals = pivotSettings.ShowColumnGrandTotals;
                optionsView.ShowRowGrandTotals = pivotSettings.ShowRowGrandTotals;
                optionsView.ShowTotalsForSingleValues = pivotSettings.ShowTotalsForSingleValues;
                optionsView.ShowGrandTotalsForSingleValues = pivotSettings.ShowTotalsForSingleValues;

            }

        }


        public static void UpdatePivotGridField(MVCxPivotGrid pivotGrid, WebPivotGridField webField)
        {
            if (webField == null || webField.Action == WebFieldAction.None)
                return;
            PivotGridField field;
            switch (webField.Action)
            {
                case (WebFieldAction.Delete):
                    field = GetPivotGridField(pivotGrid, webField.FieldName);
                    pivotGrid.Fields.Remove(field);

                    break;
                case WebFieldAction.Add:
                    //pivotGrid.Fields.Add(webField);
                    break;
                case WebFieldAction.Edit:
                    field = GetPivotGridField(pivotGrid, webField.FieldName);
                    if (field == null)
                    {
                        field = webField;
                        pivotGrid.Fields.Add(field);
                    }
                    field.Caption = webField.Caption;
                    field.GroupInterval = webField.GroupInterval;
                    field.SummaryType = webField.SummaryType;
                    break;
            }
            webField.Action = WebFieldAction.None;
        }
        public static void SetMandatoryStyle(SettingsBase settings)
        {
            settings.ControlStyle.Border.BorderColor = Color.FromArgb(0xe3676f);
            settings.ControlStyle.Border.BorderStyle = BorderStyle.Solid;
            settings.ControlStyle.Border.BorderWidth = 1;
            settings.ControlStyle.BackColor = Color.FromArgb(0xffffe3);
        }
        public static bool EnableArchiveDataUsing
        {
            get
            {
                if (
                    EidssUserContext.User.HasPermission(
                        PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanReadArchivedData)))
                {
                    var archiveConnectionCredentials = new ConnectionCredentials(null, "Archive");
                    return archiveConnectionCredentials.IsCorrect;
                }
                return false;
            }
        }
    }
}