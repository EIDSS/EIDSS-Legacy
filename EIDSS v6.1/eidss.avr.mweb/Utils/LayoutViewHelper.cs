using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Linq;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using eidss.model.Avr.View;
using eidss.web.common.Utils;
using eidss.avr.db.Common;
using bv.common.Core;
using bv.common.Configuration;
using eidss.model.Resources;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using System.Threading;

namespace eidss.avr.mweb.Utils
{
    public enum GridViewExportType { None, Pdf, Xls, Xlsx, Rtf } 

    public delegate ActionResult ExportMethod(GridViewSettings settings, object dataObject);

    public class ExportType
    {
        public string Title { get; set; }
        public ExportMethod Method { get; set; }
    }

    public class LayoutViewHelper
    {
        private static string storagePrefix = "VIEW";
        private static DisplayTextHandler m_DisplayTextHandler;

        #region Export
        static Dictionary<string, Dictionary<string, ExportType>> exportTypes;
        public static Dictionary<string, ExportType> ExportTypes
        {
            get
            {
                var ci = Thread.CurrentThread.CurrentUICulture;
                if (exportTypes == null)
                    exportTypes = new Dictionary<string, Dictionary<string, ExportType>>();
                if (!exportTypes.ContainsKey(ci.Name))
                    exportTypes.Add(ci.Name, CreateExportTypes());
                return exportTypes[ci.Name];
            }
        }
        static Dictionary<string, ExportType> CreateExportTypes()
        {
            Dictionary<string, ExportType> types = new Dictionary<string, ExportType>();
            types.Add("PDF", new ExportType { Title = Translator.GetMessageString("ExporttoPDF"), Method = LayoutViewHelper.ExportToPdf });
            types.Add("XLS", new ExportType { Title = Translator.GetMessageString("ExporttoXLS"), Method = GridViewExtension.ExportToXls });
            types.Add("XLSX", new ExportType { Title = Translator.GetMessageString("ExporttoXLSX"), Method = GridViewExtension.ExportToXlsx });
            types.Add("RTF", new ExportType { Title = Translator.GetMessageString("ExporttoRTF"), Method = GridViewExtension.ExportToRtf });
            return types;
        }

        static ActionResult ExportToPdf(GridViewSettings settings, object dataObject)
        {
            var fontName = BaseSettings.SystemFontName;
            var ci = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            if (ci == Localizer.lngGe || ci == Localizer.lngAr)
            {
                fontName = BaseSettings.GGSystemFontName;
            }
            else if (ci == Localizer.lngThai)
            {
                fontName = BaseSettings.THReportsFontName;
            }
            settings.SettingsExport.Styles.Title.Font.Name = fontName;
            settings.SettingsExport.Styles.Header.Font.Name = fontName;
            settings.SettingsExport.Styles.Cell.Font.Name = fontName;
            return GridViewExtension.ExportToPdf(settings, dataObject);
        }
        #endregion

        public static void Grid_PreRender(object s, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)s;
            var viewModel = GetModelFromSession(grid);
            if (viewModel != null)
            grid.FilterExpression = viewModel.ViewHeader.GetFilterExpression();
        }

        public static void Grid_ClientLayout(object s, ASPxClientLayoutArgs e)
        {
            MVCxGridView grid = (MVCxGridView)s;
            var viewModel = GetModelFromSession(grid);

            if (e.LayoutMode == ClientLayoutMode.Saving && viewModel != null)
            {
                bool bSortChanged = false;
                foreach (GridViewColumn column in grid.AllColumns)
                {
                    if (column is MVCxGridViewColumn)
                    {
                        MVCxGridViewColumn MVCcolumn = (MVCxGridViewColumn)column;
                        var col = viewModel.ViewHeader.GetColumnByOriginalName(MVCcolumn.FieldName);
                        if (col != null)
                        {
                            col.IsVisible = MVCcolumn.Visible;
                            if ((!col.SortOrder.HasValue && MVCcolumn.SortIndex != -1) ||
                                (col.SortOrder.HasValue && col.SortOrder.Value != MVCcolumn.SortIndex) ||
                                (col.SortOrder.HasValue && col.IsSortAscending == (MVCcolumn.SortOrder == ColumnSortOrder.Descending))
                                )
                                bSortChanged = true;

                            col.SortOrder = MVCcolumn.SortIndex;
                            col.IsSortAscending = !(MVCcolumn.SortOrder == ColumnSortOrder.Descending);
                            col.ColumnFilter = ((GridViewDataColumn)MVCcolumn).FilterExpression;
                            col.ColumnWidth = MVCcolumn.Width.IsEmpty ? AvrView.DefaultFieldWidth : (int)MVCcolumn.Width.Value;
                        }
                    }
                    else if (column is MVCxGridViewBandColumn)
                    {
                        MVCxGridViewBandColumn MVCband = (MVCxGridViewBandColumn)column;
                        var band = viewModel.ViewHeader.GetBandByOriginalName(MVCband.Name);
                        if (band != null)
                        {
                            band.IsVisible = MVCband.Visible;
                        }
                    }
                }
                if(bSortChanged)
                    viewModel.ViewHeader.GetAggregateColumnsList().ForEach(c => AggregateCasheWeb.FillAggregateColumn(viewModel.ViewData, c, viewModel.ViewHeader.GetSortExpression()));
            }
            else
            {
            }
        }

        //public static void Grid_CustomUnboundColumnData(object s, ASPxGridViewColumnDataEventArgs e)
        //{
        //    ASPxGridView grid = (ASPxGridView)s;
        //    var viewModel = GetModelFromSession(grid);
        //    if (viewModel != null)
        //    {
        //        var col = viewModel.ViewHeader.GetColumnByOriginalName(e.Column.FieldName);
        //            if (col.IsAggregate && grid.Request.RequestContext.HttpContext.Session != null)
        //        {
        //            e.Value = AggregateCasheWeb.GetValue(grid.Request.RequestContext.HttpContext.Session.SessionID,
        //                GetLayoutId(grid),
        //                e.Column.FieldName, e.ListSourceRowIndex,
        //                (System.Data.DataTable)grid.DataSource, col);
        //        }
        //    }
        //}
        
        
        #region Add To Grid

        public static GridViewSettings GetGridViewSettings(AvrView Model)
        {
            if (Model.GridViewSettings != null && Model.GridViewSettings is GridViewSettings)
                return Model.GridViewSettings as GridViewSettings;
            return CreateGridViewSettings(Model);
        }

        public static GridViewSettings CreateGridViewSettings(AvrView Model)
        {
            GridViewSettings settings = new GridViewSettings();
            var CanUpdate = !Model.IsReadOnly && eidss.model.Core.AvrPermissions.UpdatePermission;

            settings.Name = "layoutViewGrid";
            settings.CallbackRouteValues = new { Controller = "ViewLayout", Action = "ViewGridView", layoutId = Model.LayoutID };
            settings.KeyFieldName = "ID";

            // Behavior
            settings.SettingsBehavior.AllowSort = true;
            settings.SettingsBehavior.EnableCustomizationWindow = CanUpdate;
            settings.SettingsBehavior.ColumnResizeMode = ColumnResizeMode.Control;
            settings.SettingsBehavior.AllowDragDrop = CanUpdate;
            settings.SettingsBehavior.AllowSelectByRowClick = true;
            settings.SettingsBehavior.AllowSelectSingleRowOnly = false;

            // Context menu
            settings.SettingsContextMenu.Enabled = true;
            settings.SettingsContextMenu.EnableColumnMenu = DevExpress.Utils.DefaultBoolean.True;
            settings.SettingsContextMenu.EnableRowMenu = DevExpress.Utils.DefaultBoolean.False;
            settings.ClientSideEvents.ContextMenu = "viewGridForm.grid_OnContextMenu";
            /*settings.FillContextMenuItems = (sender, e) => {
                e.Items.Add(EidssMessages.Get("RenameColumnBand"), "RenameColumnBand");
                e.Items.Add(EidssMessages.Get("btAddAggregateColumn"), "btAddAggregateColumn");
                // now we can't find which column we clicked - we cant differentiate menu for aggregate columns
                ASPxGridView grid = (ASPxGridView)sender;
                e.Items.Add(EidssMessages.Get("DeleteAggregateColumn"), "DeleteAggregateColumn");
            };*/

            // show
            settings.Width = Unit.Percentage(100);
            settings.SettingsPager.Mode = GridViewPagerMode.ShowPager;
            settings.SettingsPager.PageSize = 15;
            settings.Settings.HorizontalScrollBarMode = ScrollBarMode.Visible;
            settings.Styles.Header.Font.Bold = true;
            settings.Styles.LoadingDiv.CssClass = "center";

            // filtration
            settings.Settings.ShowHeaderFilterButton = true;
            settings.Settings.ShowFilterBar = GridViewStatusBarMode.Hidden;

            // Aggregate functions
            //settings.CustomUnboundColumnData = Grid_CustomUnboundColumnData;

            // Add columns (and bands)
            AddToGrid(Model, settings.Columns);

            // Custom filter
            settings.HeaderFilterFillItems = (sender, e) =>
            {
                var col = Model.GetColumnByOriginalName(e.Column.FieldName);
                if (col != null && !string.IsNullOrEmpty(col.ColumnFilter) &&
                    !col.ColumnFilter.StartsWith("IsNullOrEmpty") && !col.ColumnFilter.StartsWith("Not IsNullOrEmpty") &&
                    !col.ColumnFilter.EndsWith(" Null") &&
                    (col.ColumnFilter.Contains(" Or ") || col.ColumnFilter.Contains(" And ") || !col.ColumnFilter.Contains(" = ")))
                {

                    e.AddValue(col.ColumnFilter.Replace("[" + e.Column.FieldName + "] ", ""), string.Empty, col.ColumnFilter);
                }
            };

            // Events
            settings.HtmlDataCellPrepared = (sender, e) =>
            {
                DisplayAsterisk(Model, e);
            };
            settings.ClientLayout = Grid_ClientLayout;
            settings.PreRender = Grid_PreRender;

            settings.ClientSideEvents.CustomizationWindowCloseUp = "viewGridForm.grid_CustomizationWindowCloseUp";
            settings.ClientSideEvents.ColumnResized = "viewGridForm.grid_ColumnResized";
            settings.ClientSideEvents.ColumnMoving = "viewGridForm.grid_ColumnMoving";
            settings.ClientSideEvents.CallbackError = "viewGridForm.grid_CallbackError";
            //settings.ClientSideEvents.SelectionChanged = "viewGridForm.grid_SelectionChanged";
            settings.Theme = GeneralSettings.Theme;
            settings.RightToLeft = Cultures.IsRtl ? DefaultBoolean.True : DefaultBoolean.False;
            Model.GridViewSettings = settings;
            ResetDisplayTextHandler();
            return settings;
        }

        // create in grid(control) the children of current view
        public static void AddToGrid(BaseBand obj, MVCxGridViewColumnCollection Columns)
        {
            // at first put bands that were reordered by user
            // after that put bands that were not reordered by user in pivot order
            obj.Bands.FindAll(x => !x.IsToDelete).OrderBy(x => x.Order_ForUse).ToList().ForEach(b => AddToGrid(b, Columns));
            // at first put columns that were reordered by user
            // after that put columns that were not reordered by user in pivot order
            obj.Columns.FindAll(x => !x.IsToDelete).OrderBy(x => x.Order_ForUse).ToList().ForEach(c => AddToGrid(c, Columns));
        }

        // create in grid(control) the children of current band
        // only here we set properties of grid(control) band
        private static void AddToGrid(AvrViewBand obj, MVCxGridViewColumnCollection Columns)
        {
            Columns.AddBand(newband =>
                {
                    newband.Name = obj.UniquePath;
                    newband.Caption = obj.DisplayText;
                    newband.Visible = obj.IsVisible;
                    newband.FixedStyle = obj.IsFreezed ? GridViewColumnFixedStyle.Left : GridViewColumnFixedStyle.None;
                    newband.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    obj.Bands.FindAll(x => !x.IsToDelete).OrderBy(x => x.Order_ForUse).ToList().ForEach(b => AddToGrid(b, newband.Columns));
                    obj.Columns.FindAll(x => !x.IsToDelete).OrderBy(x => x.Order_ForUse).ToList().ForEach(c => AddToGrid(c, newband.Columns));
                });
        }

        // create in grid(control) the child - column of current band
        private static void AddToGrid(AvrViewColumn obj, MVCxGridViewColumnCollection Columns)
        {
            Columns.Add(column => 
            {
                LayoutViewHelper.SetNewColumn(column, obj);
            });

        }

        private static void SetNewColumn(MVCxGridViewColumn column, AvrViewColumn col)
        {
            column.Name = col.UniquePath;
            column.FieldName = col.UniquePath;
            column.HeaderStyle.CssClass = "gridColumnHeader";

            // link to datasource
            if (!col.IsAggregate)
            {
                if (col.FieldType == typeof(DateTime))
                {
                    column.ColumnType = MVCxGridViewColumnType.DateEdit;
                    column.PropertiesEdit.DisplayFormatString = "d"; //col.PrecisionStringWeb;
                }
                else //if (col.FieldType == typeof(string))
                {
                    column.ColumnType = MVCxGridViewColumnType.TextBox;

                    if (col.FieldType.IsNumeric() && !String.IsNullOrEmpty(col.PrecisionStringWeb))
                        column.PropertiesEdit.DisplayFormatString = col.PrecisionStringWeb;
                }
                // sorting
                if (col.SortOrder.HasValue && col.SortOrder.Value >= 0)
                {
                    column.SortOrder = col.IsSortAscending ? ColumnSortOrder.Ascending : ColumnSortOrder.Descending;
                    column.SortIndex = col.SortOrder.Value;
                }
            }
            else
            {
                // field type
                column.ColumnType = MVCxGridViewColumnType.TextBox;
                column.PropertiesEdit.DisplayFormatString = String.IsNullOrEmpty(col.PrecisionStringWeb) ? "" : col.PrecisionStringWeb;

                // sorting
                // aggregate columns are unsortable
                column.Settings.AllowSort = DefaultBoolean.False;
            }

            column.Caption = col.DisplayText;
            column.ReadOnly = true;
            // filtration
            column.Settings.HeaderFilterMode = HeaderFilterMode.List;//CheckedList

            // visability
            column.Visible = col.IsVisible;
            // freesing
            column.FixedStyle = col.IsFreezed ? GridViewColumnFixedStyle.Left : GridViewColumnFixedStyle.None;
            // width
            column.MinWidth = 30;
            column.Width = Unit.Pixel(col.ColumnWidth);


        }

        private static void DisplayAsterisk(AvrView Model, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.CellValue == null || String.IsNullOrEmpty(e.CellValue.ToString()))
            {
                var col = Model.GetColumnByOriginalName(e.DataColumn.FieldName);
                m_DisplayTextHandler.DisplayAsterisk(col, new WebGridCellDisplayTextEventArgs(e));

                /*if (e.DataColumn.FieldName.Substring(0, 15) == "AggregateColumn")
                {
                    e.Cell.Text = Translator.GetMessageString("strErrorCustomAggregate");
                }
                else if (BaseSettings.ShowAvrAsterisk)
                {
                    e.Cell.Text = BaseSettings.Asterisk;
                }*/
            }
        }

        
        #endregion

        private static long GetLayoutId(ASPxGridView grid)
        {
            string layoutId = "";
            if (grid.Request.UrlReferrer != null)
            {
                NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(grid.Request.UrlReferrer.Query);
                layoutId = nameValueCollection["layoutId"];
            }
            if (string.IsNullOrEmpty(layoutId))
            {
                layoutId = grid.Request.Params["layoutId"];
            }
            long id;
            if (long.TryParse(layoutId, out id))
                return id;
            return 0;
        }

        private static AvrPivotViewModel GetModelFromSession(ASPxGridView grid)
        {
            if (grid.Request.RequestContext.HttpContext.Session != null)
            {
                ResetDisplayTextHandler();
                return ObjectStorage.Using<AvrPivotViewModel, AvrPivotViewModel>(o => o,
                    grid.Request.RequestContext.HttpContext.Session.SessionID, GetLayoutId(grid), storagePrefix);
            }
            else return null;

        }

        public static void ResetDisplayTextHandler()
        {
            if (m_DisplayTextHandler == null)
            {
                m_DisplayTextHandler = new DisplayTextHandler();
            }
        }

    }
}