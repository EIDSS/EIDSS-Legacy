using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Linq;
using DevExpress.Data;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Mvc;
using eidss.model.Avr.View;
using eidss.web.common.Utils;
using eidss.avr.db.Common;
using bv.common.Core;
using bv.common.Configuration;
using eidss.model.Resources;

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

        #region Export
        static Dictionary<string, ExportType> exportTypes;
        public static Dictionary<string, ExportType> ExportTypes
        {
            get
            {
                if (exportTypes == null)
                    exportTypes = CreateExportTypes();
                return exportTypes;
            }
        }
        static Dictionary<string, ExportType> CreateExportTypes()
        {
            Dictionary<string, ExportType> types = new Dictionary<string, ExportType>();
            types.Add("PDF", new ExportType { Title = Translator.GetMessageString("ExporttoPDF"), Method = GridViewExtension.ExportToPdf });
            types.Add("XLS", new ExportType { Title = Translator.GetMessageString("ExporttoXLS"), Method = GridViewExtension.ExportToXls });
            types.Add("XLSX", new ExportType { Title = Translator.GetMessageString("ExporttoXLSX"), Method = GridViewExtension.ExportToXlsx });
            types.Add("RTF", new ExportType { Title = Translator.GetMessageString("ExporttoRTF"), Method = GridViewExtension.ExportToRtf });
            return types;
        }
        #endregion

        public static void Grid_PreRender(object s, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)s;
            var viewModel = GetModelFromSession(grid);

            grid.FilterExpression = viewModel.ViewHeader.GetFilterExpression();
        }

        public static void Grid_ClientLayout(object s, ASPxClientLayoutArgs e)
        {
            MVCxGridView grid = (MVCxGridView)s;
            var viewModel = GetModelFromSession(grid);

            if (e.LayoutMode == ClientLayoutMode.Saving)
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
                            //save orders
                            /*if (col.Order != MVCcolumn.VisibleIndex + 1 &&
                                (col.Order_Pivot != MVCcolumn.VisibleIndex ||
                                (col.Order_Pivot == MVCcolumn.VisibleIndex && col.Order != 0))
                               )
                            {
                                //save orders of all band collumns
                                foreach (CollectionItem ci in MVCcolumn.Collection)
                                {
                                    if (ci is MVCxGridViewColumn)
                                    {
                                        var col_neibour = viewModel.ViewHeader.GetColumnByOriginalName(((MVCxGridViewColumn)ci).Name);
                                        //col_neibour.Order = ((MVCxGridViewColumn)ci).VisibleIndex + 1;
                                    }
                                }
                            }*/
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
/*                            if (band.Order != MVCband.VisibleIndex + 1 &&
                                (band.Order_Pivot != MVCband.VisibleIndex ||
                                (band.Order_Pivot == MVCband.VisibleIndex && band.Order != 0))
                               )
                            {
                                //save orders of all band bands
                                foreach (CollectionItem ci in MVCband.Collection)
                                {
                                    if (ci is MVCxGridViewBandColumn)
                                    {
                                        var band_neibour = viewModel.ViewHeader.GetBandByOriginalName(((MVCxGridViewBandColumn)ci).Name);
                                        //band_neibour.Order = ((MVCxGridViewBandColumn)ci).VisibleIndex + 1;
                                    }
                                }
                            }
*/
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

/*        public static void Grid_DataBound(object s, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)s;
            var viewModel = GetModelFromSession(grid);

            GridViewDataColumn c = new GridViewDataColumn();
            c.FieldName = "Total";
            c.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;

//            grid.Columns.Add(c);
        }*/

        public static void Grid_CustomUnboundColumnData(object s, ASPxGridViewColumnDataEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)s;
            var viewModel = GetModelFromSession(grid);

            var col = viewModel.ViewHeader.GetColumnByOriginalName(e.Column.FieldName);
            if (col.IsAggregate)
            {
                //decimal price = (decimal)1;// e.GetListSourceFieldValue("UnitPrice");
                //int quantity = Convert.ToInt32("3");//e.GetListSourceFieldValue("Quantity"));

                e.Value = AggregateCasheWeb.GetValue(grid.Request.RequestContext.HttpContext.Session.SessionID,
                    GetLayoutId(grid),
                    e.Column.FieldName, e.ListSourceRowIndex,
                    (System.Data.DataTable)grid.DataSource, col);//price * quantity;
            }
        }
        
        
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

            // filtration
            settings.Settings.ShowHeaderFilterButton = true;
            settings.Settings.ShowFilterBar = GridViewStatusBarMode.Hidden;

            // Aggregate functions
            //settings.DataBound = Grid_DataBound;
            settings.CustomUnboundColumnData = Grid_CustomUnboundColumnData;

            // Add columns (and bands)
            AddToGrid(Model, settings.Columns);

            // Custom filter
            settings.HeaderFilterFillItems = (sender, e) =>
            {
                var col = Model.GetColumnByOriginalName(e.Column.FieldName);
                if (col != null && !string.IsNullOrEmpty(col.ColumnFilter) && (col.ColumnFilter.Contains(" Or ") || col.ColumnFilter.Contains(" And ") || !col.ColumnFilter.Contains(" = ")))
                {
                    e.AddValue(col.ColumnFilter.Replace("[" + e.Column.FieldName + "] ", ""), string.Empty, col.ColumnFilter);
                }
            };
            settings.HtmlDataCellPrepared = (sender, e) =>
            {
                DisplayAsterisk(e);
            };

            // Events
            settings.ClientLayout = Grid_ClientLayout;
            settings.PreRender = Grid_PreRender;

            settings.ClientSideEvents.CustomizationWindowCloseUp = "viewGridForm.grid_CustomizationWindowCloseUp";
            settings.ClientSideEvents.ColumnResized = "viewGridForm.grid_ColumnResized";
            settings.ClientSideEvents.ColumnMoving = "viewGridForm.grid_ColumnMoving";
            settings.ClientSideEvents.CallbackError = "viewGridForm.grid_CallbackError";
            //settings.ClientSideEvents.SelectionChanged = "viewGridForm.grid_SelectionChanged";
            settings.Theme = GeneralSettings.Theme;
            Model.GridViewSettings = settings;
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
            // link to datasource
            if (!col.IsAggregate)
            {
                column.Name = col.UniquePath;
                column.FieldName = col.UniquePath;
                column.HeaderStyle.CssClass = "gridColumnHeader";
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
                /*else
                {
                    column.ColumnType = MVCxGridViewColumnType.SpinEdit;
                    column.PropertiesEdit.DisplayFormatString = String.IsNullOrEmpty(col.PrecisionStringWeb) ? "" : "N" + col.PrecisionStringWeb;
                }*/
            }
            else
            {
                //temporary - till aggrcashe
                column.Name = col.UniquePath;
                column.FieldName = col.UniquePath;
                // field type
                column.ColumnType = MVCxGridViewColumnType.TextBox;
                column.PropertiesEdit.DisplayFormatString = String.IsNullOrEmpty(col.PrecisionStringWeb) ? "" : col.PrecisionStringWeb;

                // field type
                /*if (col.FieldType == typeof(string))
                {
                    column.UnboundType = DevExpress.Data.UnboundColumnType.String;
                }
                else
                {
                    column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                    column.PropertiesEdit.DisplayFormatString = String.IsNullOrEmpty(col.Precision_) ? "" : "N" + col.Precision_;
                }*/
            }

            column.Caption = col.DisplayText;
            column.ReadOnly = true;
            column.MinWidth = 10;
            // filtration
            column.Settings.HeaderFilterMode = HeaderFilterMode.List;//CheckedList

            // visability
            column.Visible = col.IsVisible;
            //column.VisibleIndex = visibleIndex;
            // freesing
            column.FixedStyle = col.IsFreezed ? GridViewColumnFixedStyle.Left : GridViewColumnFixedStyle.None;
            // width
            column.Width = Unit.Pixel(col.ColumnWidth);

            // sorting
            if (col.SortOrder.HasValue && col.SortOrder.Value >= 0)
            {
                column.SortOrder = col.IsSortAscending ? ColumnSortOrder.Ascending : ColumnSortOrder.Descending;
                column.SortIndex = col.SortOrder.Value;
            }

        }

        private static void DisplayAsterisk(ASPxGridViewTableDataCellEventArgs e)
        {
            if (BaseSettings.ShowAvrAsterisk && (e.CellValue == null || String.IsNullOrEmpty(e.CellValue.ToString())))
            {
                e.Cell.Text = BaseSettings.Asterisk;
            }
        }

        
        #endregion

        private static long GetLayoutId(ASPxGridView grid)
        {
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(grid.Request.UrlReferrer.Query);
            string layoutId = nameValueCollection["layoutId"];
            return long.Parse(layoutId);
        }

        private static AvrPivotViewModel GetModelFromSession(ASPxGridView grid)
        {
            return ModelStorage.Get(grid.Request.RequestContext.HttpContext.Session.SessionID, GetLayoutId(grid), storagePrefix) as AvrPivotViewModel;
        }

    }
}