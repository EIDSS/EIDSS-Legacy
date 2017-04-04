using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.Complexity;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.mweb.Models;
using EIDSS.Enums;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Helpers;
using eidss.web.common.Utils;
using Image = System.Web.UI.WebControls.Image;
using PivotFieldEventArgs = DevExpress.Web.ASPxPivotGrid.PivotFieldEventArgs;
using PivotGridField = DevExpress.Web.ASPxPivotGrid.PivotGridField;

namespace eidss.avr.mweb.Utils
{
    public class LayoutPivotGridHelper
    {
        private class HeaderTemplate : ITemplate
        {
            private readonly AvrPivotGridModel m_Model;

            public HeaderTemplate(AvrPivotGridModel model)
            {
                m_Model = model;
            }

            public void InstantiateIn(Control container)
            {
                var c = (PivotGridHeaderTemplateContainer)container;
                PivotGridHeaderHtmlTable table = c.CreateHeader();

                var cell = new TableCell { CssClass = "imagecell" };
                WebPivotGridField field = GetWebPivotGridFieldByName(m_Model.PivotSettings.Fields, c.Field.ID);
                cell.Controls.Add(new Image
                {
                    ImageUrl = string.Format("/Content/images/{0}", field == null ? "string.png" : field.FieldImage)
                });
                table.Rows[0].Cells.AddAt(0, cell);
                c.Controls.Add(table);
            }
        }

        private const string StoragePrefix = "PIVOT";
        private static CustomSummaryHandler m_CustomSummaryHandler;
        private static DisplayTextHandler m_DisplayTextHandler;
        //private static bool m_SkipFilterChange;
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
            {
                //return ModelStorage.Get(request.RequestContext.HttpContext.Session.SessionID, layoutId, StoragePrefix, false) as AvrPivotGridModel;
                return ObjectStorage.Using<AvrPivotGridModel, AvrPivotGridModel>(o => o,
                    request.RequestContext.HttpContext.Session.SessionID, layoutId, StoragePrefix, false);
            }
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
            {
                //return ModelStorage.Get(request.RequestContext.HttpContext.Session.SessionID, layoutId, StoragePrefix, false) as AvrPivotGridModel;
                return ObjectStorage.Using<AvrPivotGridModel, AvrPivotGridModel>(o => o,
                    request.RequestContext.HttpContext.Session.SessionID, layoutId, StoragePrefix, false);

            }
            return null;
        }

        public static PivotGridSettings LayoutPivotGridSettings(HttpRequestBase request)
        {
            AvrPivotGridModel model = GetModelFromSession(request);
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
            bool readOnly = model.PivotSettings.IsPublished | !AvrPermissions.UpdatePermission;

            settings.Name = "pivotGrid";
            settings.CallbackRouteValues =
                new
                {
                    Controller = "Layout",
                    Action = "PivotGridPartial",
                    //queryId = model.PivotSettings.QueryId,
                    layoutId = model.PivotSettings.LayoutId
                };
            settings.CustomActionRouteValues =
                new
                {
                    Controller = "Layout",
                    Action = "PivotGridPartial",
                    //queryId = model.PivotSettings.QueryId,
                    layoutId = model.PivotSettings.LayoutId
                };
            settings.OptionsView.HorizontalScrollBarMode = model.PivotSettings.FreezeRowHeaders ? ScrollBarMode.Auto : ScrollBarMode.Hidden;
            if (model.PivotSettings.FreezeRowHeaders)
            {
                settings.Width = Unit.Percentage(99);
            }
            settings.OptionsView.ShowFilterHeaders = false;
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
            if (!readOnly)
            {
                settings.PivotCustomizationExtensionSettings.Name = "pivotCustomization";
                settings.PivotCustomizationExtensionSettings.Enabled = true;
                settings.PivotCustomizationExtensionSettings.Visible = true;
                settings.PivotCustomizationExtensionSettings.AllowedLayouts =
                    CustomizationFormAllowedLayouts.TopPanelOnly;
                settings.PivotCustomizationExtensionSettings.Layout = CustomizationFormLayout.TopPanelOnly;
                settings.PivotCustomizationExtensionSettings.AllowSort = true;
                settings.PivotCustomizationExtensionSettings.AllowFilter = false;
                settings.PivotCustomizationExtensionSettings.Height = Unit.Percentage(100);
                settings.PivotCustomizationExtensionSettings.Width = Unit.Percentage(100);
            }
            settings.OptionsCustomization.AllowPrefilter = false;
            settings.Prefilter.Enabled = model.PivotSettings.ApplyFilter;
            settings.OptionsView.EnableFilterControlPopupMenuScrolling = true;
            settings.Prefilter.Criteria = CriteriaOperator.TryParse(model.PivotSettings.FilterCriteriaString);
            settings.Styles.PrefilterBuilderCloseButtonStyle.CssClass = "invisible";
            settings.Styles.PrefilterBuilderHeaderStyle.CssClass = "roundbox";
            settings.PopupMenuCreated += PopupMenuCreated;
            settings.Styles.PrefilterBuilderMainAreaStyle.CssClass = "filterwindow";
            settings.FilterControlOperationVisibility = (sender, args) =>
            {
                WebPivotGridField webField = GetWebPivotGridFieldByName(model.PivotSettings.Fields, args.PropertyInfo.PropertyName);
                if (webField == null)
                {
                    args.Visible = false;
                    return;
                }
                switch (webField.SearchFieldType)
                {
                    case SearchFieldType.ID: //lookup 
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
            settings.FilterControlCustomValueDisplayText = (sender, args) =>
            {
                if (args.Value == null)
                {
                    args.DisplayText = Translator.GetMessageString("FilterConrol_EmptyEnter");
                }
                else if (args.PropertyInfo.PropertyType == typeof(DateTime))
                {
                    args.DisplayText = string.Format("{0:d}", args.Value);
                }
            };
            settings.OptionsCustomization.AllowFilterInCustomizationForm = true;
            settings.Theme = GeneralSettings.Theme;
            settings.Fields.Clear();

            foreach (WebPivotGridField webField in
                model.PivotSettings.Fields.Where(f => f.Visible && f.Area != PivotArea.FilterArea).OrderBy(f => (long)f.Area * 100000 + f.AreaIndex))
            {
                settings.Fields.Add(webField);
            }
            foreach (WebPivotGridField webField in
                model.PivotSettings.Fields.Where(f => !f.Visible || f.Area == PivotArea.FilterArea).OrderBy(f => f.Caption))
            {
                settings.Fields.Add(webField);
            }

            settings.Init = (sender, args) =>
            {
                var pivotGrid = (MVCxPivotGrid)sender;
                if(model.ShowingPrefilter)
                    pivotGrid.PrefilterCriteriaChanged += PrefilterCriteriaChanged;
                pivotGrid.FieldAreaChanged += PivotGridOnFieldAreaChanged;
                pivotGrid.HeaderTemplate = new HeaderTemplate(model);
            };
            settings.PreRender = (sender, e) =>
            {
                var pivotGrid = (MVCxPivotGrid)sender;
                pivotGrid.BeginUpdate();
                pivotGrid.HeaderTemplate = new HeaderTemplate(model);
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
                    //model.PivotSettings.InitialFilterCriteriaString = pivotGrid.Prefilter.CriteriaString;
                    model.ShowPrefilter = false;
                    model.ShowingPrefilter = true;
                    return;
                }
                model.ShowingPrefilter = false;
                pivotGrid.BeginUpdate();
                try
                {
                    setPrefilterEnabled(pivotGrid, model.PivotSettings.ApplyFilter);
                    UpdatePivotGridField(pivotGrid, model);

                    model.PivotSettings.UpdatedField = null;
                    if (model.PivotSettings.UpdateGroupInterval)
                    {
                        PivotGroupInterval interval = GroupIntervalHelper.GetGroupInterval(model.PivotSettings.DefaultGroupInterval);
                        SetInterval(pivotGrid, interval);
                        model.PivotSettings.UpdateGroupInterval = false;
                    }
                    SetTotalSettings(pivotGrid.OptionsView, model.PivotSettings);
                    //if (pivotGrid.OptionsView.ShowHorizontalScrollBar != model.PivotSettings.FreezeRowHeaders)
                    //{
                    pivotGrid.OptionsView.HorizontalScrollBarMode = model.PivotSettings.FreezeRowHeaders ? ScrollBarMode.Auto : ScrollBarMode.Hidden;
                    if (model.PivotSettings.FreezeRowHeaders)
                        pivotGrid.Width = Unit.Percentage(99);
                    else
                        pivotGrid.Width = Unit.Empty;
                    pivotGrid.ReloadData();
                }
                finally
                {
                    pivotGrid.EndUpdate();
                }
            };

            //settings.ClientSideEvents.EndCallback = "layoutPivotGrid.resizePivotGridEvent";

            settings.AfterPerformCallback = (sender, e) =>
            {
                var pivotGrid = (MVCxPivotGrid)sender;

                if (pivotGrid.HeaderTemplate == null)
                {
                    pivotGrid.HeaderTemplate = new HeaderTemplate(model);
                }
                //pivotGrid.BeginUpdate();
                //pivotGrid.ReloadData();
                //pivotGrid.EndUpdate();
            };

            settings.ClientSideEvents.CallbackError = "layoutPivotGrid.onCallbackError";
            settings.ClientSideEvents.EndCallback = "layoutPivotGrid.onEndCallback";

            settings.CustomCellDisplayText = (sender, e) =>
            {
                InitDisplayTexthandler();

                m_DisplayTextHandler.DisplayAsterisk(new WebPivotCellDisplayTextEventArgs(e));
                if (e.DataField == null)
                {
                    return;
                }
                if (model.PivotSettings.FieldsDictionary.ContainsKey(e.DataField.FieldName))
                {
                    WebPivotGridField field = model.PivotSettings.FieldsDictionary[e.DataField.FieldName];
                    m_DisplayTextHandler.DisplayCellText(new WebPivotCellDisplayTextEventArgs(e), field.CustomSummaryType, field.Precision);
                }
            };

            settings.FieldValueDisplayText = (sender, e) =>
            {
                InitDisplayTexthandler();
                var eventArgs = new WebPivotFieldDisplayTextEventArgs(e);
                m_DisplayTextHandler.DisplayAsterisk(eventArgs);
                m_DisplayTextHandler.DisplayBool(eventArgs);

                if (m_CustomSummaryHandler == null)
                {
                    var helper = new AvrPivotGridHelperWeb((ASPxPivotGrid) sender)
                    {
                        SingleSearchObject = model.PivotSettings.IsSingleSearchObject
                    };

                    m_CustomSummaryHandler = new CustomSummaryHandler(helper);
                }
                var summaryTypes = new List<CustomSummaryType>();

                
                List<IAvrPivotGridField> dataFields = AvrPivotGridHelper.GetFieldCollectionFromArea(model.PivotSettings.Fields,
                    PivotArea.DataArea);
                foreach (IAvrPivotGridField field in dataFields)
                {
                    summaryTypes.Add(field.CustomSummaryType);
                    m_DisplayTextHandler.DisplayStatisticsTotalCaption(eventArgs, summaryTypes);
                }
            };

            settings.CustomSummary = (sender, e) =>
            {
                if (m_CustomSummaryHandler == null)
                {
                    var helper = new AvrPivotGridHelperWeb((ASPxPivotGrid)sender);

                    m_CustomSummaryHandler = new CustomSummaryHandler(helper);
                }

                WebPivotGridField settingsField = model.PivotSettings.Fields.Find(f => f.FieldName == e.DataField.FieldName);
                var field = e.DataField as IAvrPivotGridField;

                if (settingsField != null && field != null && ((int)field.CustomSummaryType <= 0))
                {
                    field.CustomSummaryType = settingsField.CustomSummaryType;
                    field.BasicCountFunctionId = settingsField.BasicCountFunctionId;
                    field.AggregateFunctionId = settingsField.AggregateFunctionId;


                    field.UnitLayoutSearchFieldId = settingsField.UnitLayoutSearchFieldId;
                    field.UnitSearchFieldAlias = settingsField.UnitSearchFieldAlias;
                    field.SearchFieldDataType = settingsField.SearchFieldDataType;

                    field.DefaultGroupInterval = settingsField.DefaultGroupInterval;

                    field.Ordinal = settingsField.Ordinal;
                    field.AddMissedValues = settingsField.AddMissedValues;
                    field.DiapasonStartDate = settingsField.DiapasonStartDate;
                    field.DiapasonEndDate = settingsField.DiapasonEndDate;
                    field.Precision = settingsField.Precision;

                    field.AggregateFunctionId = settingsField.AggregateFunctionId;
                    field.BasicCountFunctionId = settingsField.BasicCountFunctionId;
                    field.UnitLayoutSearchFieldId = settingsField.UnitLayoutSearchFieldId;
                    field.UnitSearchFieldAlias = settingsField.UnitSearchFieldAlias;
                    field.DateLayoutSearchFieldId = settingsField.DateLayoutSearchFieldId;
                    field.DateSearchFieldAlias = settingsField.DateSearchFieldAlias;

                    if (settingsField.IsDateTimeField)
                    {
                        field.GroupInterval = settingsField.DefaultGroupInterval;
                    }

                    field.AllowMissedReferenceValues = settingsField.AllowMissedReferenceValues;
                    field.LookupTableName = settingsField.LookupTableName;
                    field.GisReferenceTypeId = settingsField.GisReferenceTypeId;
                    field.ReferenceTypeId = settingsField.ReferenceTypeId;
                    field.LookupAttributeName = settingsField.LookupAttributeName;
                    field.HaCode = settingsField.HaCode;

                    field.AllPivotFields = settingsField.AllPivotFields;
                    field.FieldNamesDictionary = settingsField.FieldNamesDictionary;

                }
                m_CustomSummaryHandler.OnCustomSummary(sender, new WebPivotGridCustomSummaryEventArgs(e));
            };
            settings.CustomCellStyle = (sender, args) =>
            {
                var pivotGrid = (MVCxPivotGrid)sender;
                //pivotGrid.HeaderTemplate = new HeaderTemplate();
            };
            settings.HtmlCellPrepared = (sender, args) =>
            {
                var pivotGrid = (MVCxPivotGrid)sender;
                //pivotGrid.HeaderTemplate = new HeaderTemplate();
            };
            settings.HtmlFieldValuePrepared = (sender, args) =>
            {
                var pivotGrid = (MVCxPivotGrid)sender;
                //pivotGrid.HeaderTemplate = new HeaderTemplate();
            };
            settings.GridLayout = (sender, args) =>
            {
                var pivotGrid = (MVCxPivotGrid)sender;
                model.PivotSettings.HasChanges = true;
                var fieldsToDelete = new List<PivotGridFieldBase>();
                foreach (PivotGridField field in pivotGrid.Fields)
                {
                    WebPivotGridField webField = GetWebPivotGridFieldByFieldName(model.PivotSettings.Fields, field.FieldName);
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
                            webField.FilterValues.Clear();
                            webField.SortOrder = field.SortOrder;
                            webField.Width = field.Width;
                            ClearMissedValues(webField);
                        }
                        else
                        {
                            webField.Area = field.Area;
                            webField.AreaIndex = field.AreaIndex;
                            webField.Visible = field.Visible;
                            webField.SortOrder = field.SortOrder;
                            webField.Width = field.Width;
                            webField.FilterValues.Assign(field.FilterValues);
                            //if (webField.IsDateTimeField && webField.GroupInterval == PivotGroupInterval.Default)
                            //{
                            //    webField.DefaultGroupInterval = GroupIntervalHelper.GetGroupInterval(model.PivotSettings.DefaultGroupInterval);
                            //    field.GroupInterval = webField.GroupInterval;
                            //}
                        }
                    }
                    else
                    {
                        fieldsToDelete.Add(field);
                    }
                }
                foreach (PivotGridFieldBase field in fieldsToDelete)
                {
                    field.Visible = false;
                    field.Area = PivotArea.FilterArea;
                    field.AreaIndex = -1;
                    pivotGrid.Fields.Remove(field);
                }
                //if (model.PivotSettings.ShowMissedValues)
                //{
                //    List<IAvrPivotGridField> fields = model.PivotSettings.Fields.Cast<IAvrPivotGridField>().ToList();
                //    AvrPivotGridHelper.AddMissedValuesInRowColumnArea(model, fields);
                //}
                if (fieldsToDelete.Count > 0)
                {
                    pivotGrid.ReloadData();
                }
            };
            return settings;
        }

        private static void setPrefilterEnabled(MVCxPivotGrid pivotGrid, bool enabled)
        {
            //m_SkipFilterChange = true;
            if (pivotGrid.Prefilter.Enabled != enabled)
                pivotGrid.Prefilter.Enabled = enabled;
            //m_SkipFilterChange = false;

        }

        private static void PopupMenuCreated(object sender, PivotPopupMenuCreatedEventArgs e)
        {
            e.Menu.Items.Clear();
        }

        public static void ResetDisplayTextHandler()
        {
            if (m_DisplayTextHandler == null)
            {
                InitDisplayTexthandler();
            }
        }

        private static void InitDisplayTexthandler()
        {
            m_DisplayTextHandler = new DisplayTextHandler();
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
            //if (m_SkipFilterChange)
            //    return;
            var pivotGrid = (MVCxPivotGrid)sender;
            if (pivotGrid.IsCallback || pivotGrid.IsPrefilterPopupVisible)
                return;
            AvrPivotGridModel model = GetModelFromSession(pivotGrid.Request);
            if (model.PivotSettings.FilterCriteriaString != pivotGrid.Prefilter.CriteriaString)
            {
                model.PivotSettings.FilterCriteriaString = pivotGrid.Prefilter.CriteriaString;
                if (!string.IsNullOrEmpty(pivotGrid.Prefilter.CriteriaString))
                {                    
                    model.PivotSettings.ApplyFilter = true;
                    pivotGrid.JSProperties["cpApplyFilter"] = true;
                }
                setPrefilterEnabled(pivotGrid, model.PivotSettings.ApplyFilter);
                model.PivotSettings.HasChanges = true;
                FillEmptyValuesInDataArea(model);

                pivotGrid.JSProperties["cpNeedCallback"] = true;
                //pivotGrid.ReloadData();
            }
        }

        private static CriteriaOperator ValidatePrefilterCriteria(CriteriaOperator criteria)
        {
            if (ReferenceEquals(criteria, null))
            {
                return null;
            }
            var validator = new FilterValidator();
            return criteria.Accept(validator) as CriteriaOperator;
        }

        private static void CustomLoadCallbackState
            (object sender, PivotGridCallbackStateEventArgs pivotGridCallbackStateEventArgs)
        {
            //var pivotGrid = (MVCxPivotGrid) sender;

            //HttpContext.Current.Session["layoutGrid"] = pivotGrid.SaveLayoutToString();
        }

        private static void PivotGridOnFieldAreaChanged(object sender, PivotFieldEventArgs pivotFieldEventArgs)
        {
            var pivotGrid = (MVCxPivotGrid)sender;
            AvrPivotGridModel model = GetModelFromSession(pivotGrid.Request);
            PivotGridField field = pivotFieldEventArgs.Field;
            WebPivotGridField webField = GetWebPivotGridFieldByName(model.PivotSettings.Fields, field.ID);
            if (field.Area == webField.Area && field.AreaIndex == webField.AreaIndex && field.Visible == webField.Visible)
            {
                return;
            }

            bool copyAddMissedValues = field.Visible &&
                                       (field.Area == PivotArea.ColumnArea || field.Area == PivotArea.RowArea) &&
                                       (!webField.Visible || !(webField.Area == PivotArea.ColumnArea ||
                                                               webField.Area == PivotArea.RowArea));
            bool clearMissedValues = !field.Visible ||
                                     !(field.Area == PivotArea.ColumnArea || field.Area == PivotArea.RowArea);
            webField.Area = field.Area;
            webField.AreaIndex = field.AreaIndex;
            webField.Visible = field.Visible;
            if (copyAddMissedValues)
            {
                CopyMissedValuesToField(webField, model.PivotSettings.Fields);
            }
            else if (clearMissedValues)
            {
                ClearMissedValues(webField);
            }
            var adminUnitsList = AvrPivotGridHelper.GetAdministrativeUnitView(model.PivotSettings.QueryId,
                                                                              model.PivotSettings.Fields.ToList<IAvrPivotGridField>());
            foreach (PivotGridField f in pivotGrid.Fields)
            {
                WebPivotGridField webF = GetWebPivotGridFieldByName(model.PivotSettings.Fields, f.ID);
                if (f.Visible && f.Area == field.Area && f.ID != field.ID)
                {
                    webF.AreaIndex = f.AreaIndex;
                }
                if (webF.UnitLayoutSearchFieldId != -1 && webF.UnitLayoutSearchFieldId != 0)
                {
                    if (adminUnitsList == null || adminUnitsList.Count == 0 || webF.Area != PivotArea.RowArea)
                    {
                        webF.UnitLayoutSearchFieldId = -1L;
                    }
                    else if (!webF.UnitLayoutSearchFieldId.Equals(adminUnitsList[0]["Id"]))
                    {
                        webF.UnitLayoutSearchFieldId = DBNull.Value.Equals(adminUnitsList[0]["Id"])
                                                           ? -1L
                                                           : (long)adminUnitsList[0]["Id"];
                    }
                }

            }
            if (model.PivotSettings.ShowMissedValues)
            {
                AddMissedValues(model, true);
                pivotGrid.JSProperties["cpNeedCallback"] = true;
                //pivotGrid.ReloadData();
            }
            else
            {
                LayoutValidateResult validateResult = FillEmptyValuesInDataArea(model);
                pivotGrid.JSProperties["cpNeedCallback"] = validateResult.IsCancelOrUserDialogCancel();
            }
            // because AvrPivotGridHelperWeb which used inside m_CustomSummaryHandler should be re-initialized
            m_CustomSummaryHandler = null;
        }

        public static LayoutValidateResult FillEmptyValuesInDataArea(AvrPivotGridModel model, List<IAvrPivotGridField> fields = null)
        {
            if (fields == null)
            {
                fields = model.PivotSettings.Fields.ToList<IAvrPivotGridField>();
            }
            var avrDataSource = new AvrPivotGridData(model.PivotData);
            
            
            LayoutBaseValidator validator = CreateLayoutComplexityValidator();
            LayoutValidateResult result = AvrPivotGridHelper.FillEmptyValuesAndValidateComplexity(avrDataSource, fields,  validator);
            if (result.IsCancelOrUserDialogCancel())
            {
                model.HideDataForComplexLayout();
            }
            return result;
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
            {
                return fields.SingleOrDefault(f => f.FieldName == fieldName);
            }
            return null;
        }

        public static WebPivotGridField GetWebPivotGridFieldByName(List<WebPivotGridField> fields, string name)
        {
            if (fields.Count(f => f.Name == name) > 0)
            {
                return fields.SingleOrDefault(f => f.Name == name);
            }
            return null;
        }

        public static PivotGridField GetPivotGridField(MVCxPivotGrid pivotGrid, string fieldName)
        {
            foreach (PivotGridField field in pivotGrid.Fields)
            {
                if (field.FieldName.Equals(fieldName))
                {
                    return field;
                }
            }
            return null;
        }

        private static void SetInterval(MVCxPivotGrid pivotGrid, PivotGroupInterval interval)
        {
            AvrPivotGridModel model = GetModelFromSession(pivotGrid.Request);

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

        public static bool IsFieldGroupIntervalChanged(PivotGridField field, PivotGroupInterval interval)
        {
            return (field.Area == PivotArea.RowArea || field.Area == PivotArea.ColumnArea) && field.Visible &&
                   field.GroupInterval != interval;
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
            var list = new List<CheckListItem>
                {
                    new CheckListItem("0", "(" + Translator.GetMessageString("strSelectAll_Id") + ")"),
                    new CheckListItem("1", Translator.GetMessageString("itemCols")),
                    new CheckListItem("2", Translator.GetMessageString("itemRows")),
                    new CheckListItem("3", Translator.GetMessageString("itemColGrand")),
                    new CheckListItem("4", Translator.GetMessageString("itemRowGrand")),
                    new CheckListItem("5", Translator.GetMessageString("itemForSingle"))
                };
            return list;
        }

        public static string GetTotalsText(AvrPivotGridModel model)
        {
            string text = "";
            const string sep = ", ";
            if (model.PivotSettings.ShowColumnTotals)
            {
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemCols"), sep);
            }
            if (model.PivotSettings.ShowRowTotals)
            {
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemRows"), sep);
            }
            if (model.PivotSettings.ShowColumnGrandTotals)
            {
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemColGrand"), sep);
            }
            if (model.PivotSettings.ShowRowGrandTotals)
            {
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemRowGrand"), sep);
            }
            if (model.PivotSettings.ShowTotalsForSingleValues)
            {
                bv.common.Core.Utils.AppendLine(ref text, Translator.GetMessageString("itemForSingle"), sep);
            }
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

        public static void UpdatePivotGridField(MVCxPivotGrid pivotGrid, AvrPivotGridModel model)
        {
            var webField = model.PivotSettings.UpdatedField;
            if (webField == null || webField.Action == WebFieldAction.None)
            {
                return;
            }
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
                if (EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanReadArchivedData)))
                {
                    return ArchiveSqlHelper.IsCredentialsCorrect();
                }
                return false;
            }
        }

        public static void CopyMissedValues(WebPivotGridField source, WebPivotGridField dest)
        {
            dest.AddMissedValues = source.AddMissedValues;
            dest.DiapasonStartDate = source.DiapasonStartDate;
            dest.DiapasonEndDate = source.DiapasonEndDate;
            dest.UpdateImageIndex();
        }

        public static void ClearMissedValues(WebPivotGridField webField)
        {
            webField.AddMissedValues = false;
            webField.DiapasonStartDate = null;
            webField.DiapasonEndDate = null;
            webField.UpdateImageIndex();
        }

        public static void CopyMissedValuesFromField(WebPivotGridField webField, List<WebPivotGridField> fields)
        {
            IEnumerable<WebPivotGridField> copies =
                fields.Where(
                    f =>
                        !f.IsHiddenFilterField && f.OriginalFieldName == webField.OriginalFieldName && f.ID != webField.ID &&
                        ((f.Area == PivotArea.ColumnArea || f.Area == PivotArea.RowArea) && f.AreaIndex >= 0));
            foreach (WebPivotGridField copy in copies)
            {
                CopyMissedValues(webField, copy);
            }
        }

        public static void CopyMissedValuesToField(WebPivotGridField webField, List<WebPivotGridField> fields)
        {
            WebPivotGridField copy =
                fields.Find(
                    f =>
                        !f.IsHiddenFilterField && f.OriginalFieldName == webField.OriginalFieldName && f.ID != webField.ID &&
                        ((f.Area == PivotArea.ColumnArea || f.Area == PivotArea.RowArea) && f.AreaIndex >= 0));
            if (copy != null)
            {
                CopyMissedValues(copy, webField);
            }
        }

        public static AvrDataTable GetPivotData(LayoutDetailDataSet ds, long queryId, long layoutId, bool useArchiveData, out bool isNewObject, out string errorMessage)
        {
            CachedQueryResult queryResult = ServiceClientHelper.ExecQuery(queryId, useArchiveData);
            isNewObject = ds.LayoutSearchField.Count == 0;
            errorMessage = queryResult.ErrorMessage;
            return AvrPivotGridHelper.GetPreparedDataSource(ds.LayoutSearchField, queryId, layoutId, queryResult.QueryTable, isNewObject);
        }

        public static void AddMissedValues(AvrPivotGridModel model, bool forceRefill)
        {
            if (forceRefill)
            {
                bool isNewObject;
                string errorMessage;
                model.PivotData = GetPivotData(model.PivotSettings.LayoutDataset, model.PivotSettings.QueryId,
                    model.PivotSettings.LayoutId, model.PivotSettings.UseArchiveData, out isNewObject, out errorMessage);

                

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    //todo:[mike]     return ErrorMessage to user   
                }
                
            }

            List<IAvrPivotGridField> fields = model.PivotSettings.Fields.Cast<IAvrPivotGridField>().ToList();
            var result = new LayoutValidateResult() ;
            if (model.PivotSettings.ShowMissedValues)
            {
               
                LayoutBaseValidator validator = CreateLayoutComplexityValidator();
                result = AvrPivotGridHelper.AddMissedValuesAndValidateComplexity(model, fields,  validator);
            }
            
            if (result.IsCancelOrUserDialogCancel())
            {
                model.HideDataForComplexLayout();
            }
            else
            {
                FillEmptyValuesInDataArea(model, fields);
            }
                
        }

        public static int GetDeltaMemory(long initialMemory)
        {
            return (int)(GC.GetTotalMemory(false) - initialMemory) / (1024 * 1024);
        }
        public static LayoutBaseValidator CreateLayoutComplexityValidator()
        {
            return new LayoutSilentValidator();
        }

       
    }
}