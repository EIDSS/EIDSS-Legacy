using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using eidss.avr.BaseComponents;
using eidss.avr.db.Common;
using eidss.avr.db.Common.CommandProcessing.Commands.Export;
using eidss.avr.db.DBService;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Print;
using eidss.model.Avr.View;
using eidss.model.Resources;

namespace eidss.avr.ViewForm
{
    public sealed class ViewDetailPresenter : RelatedObjectPresenter
    {
        private readonly IViewDetailView m_ReportView;
        private readonly View_DB m_DbService;

        public ViewDetailPresenter(SharedPresenter sharedPresenter, IViewDetailView view)
            : base(sharedPresenter, view)
        {
            m_ReportView = view;

            m_DbService = new View_DB();
            m_ReportView.DBService = m_DbService;
        }

        public override void Process(Command cmd)
        {
            try
            {
                if (cmd is PivotGridDataLoadedCommand)
                {
                    m_ReportView.OnPivotDataLoaded((PivotGridDataLoadedCommand) cmd);
                }
                else if (cmd is ExportCommand)
                {
                    ProcessExport((ExportCommand) cmd);
                }
                else if (cmd is PrintCommand)
                {
                    ProcessPrint((PrintCommand) cmd);
                }
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        #region Operations on object

        public AvrView View
        {
            get { return m_DbService.avrView; }
            set { m_DbService.avrView = value; }
        }

        public bool HasChanges()
        {
            if (Utils.IsEmpty(View))
            {
                return false;
            }
            return View.IsChanged;
        }

        public long LayoutID()
        {
            if (Utils.IsEmpty(View))
            {
                return -1;
            }
            return View.LayoutID;
        }

        public bool HasFreezedBands()
        {
            if (Utils.IsEmpty(View))
            {
                return false;
            }
            return View.Bands.Exists(b => b.IsFreezed);
        }

        public bool HasFreezedColumns()
        {
            if (Utils.IsEmpty(View))
            {
                return false;
            }
            return View.Columns.Exists(b => b.IsFreezed);
        }

        public void Reset()
        {
            if (!Utils.IsEmpty(View))
            {
                View.ResetToPivot();
            }
        }

        // Adjust current view setting to newly obtained from Pivot, clear current settings if they are incompatible with new from Pivot
        public void AdjustToPivotView(AvrView pivotView)
        {
            View.AdjustToNew(pivotView);
        }

        #region Save Settings in Model

        public void FillColumnsBooleans(object value, string booleanName)
        {
            AvrViewHelper.FillColumnsBooleans(View, value, booleanName);
        }

        public void SaveColumnsDefs(string col, string defName)
        {
            View.SaveColumnsDefs(col, defName);
        }

        #endregion

        #endregion

        #region Prepairing Data for Chart/Map

        public static string[] GetCheckedComboSelValues(object value)
        {
            return AvrViewHelper.GetCheckedComboSelValues(value);
        }

        public List<AvrViewColumn> FillSeriesColumns(GridView view, CheckedComboBoxEdit chb, LookUpEdit cb)
        {
            List<AvrViewColumn> seriesColumns;

            // fill selected cells
            GridCell[] selectedCells = view.GetSelectedCells();
            if (selectedCells.Length > 1)
            {
                seriesColumns = FillSelectedColumns(selectedCells);
            }
                // fill default series only if combo with default series is filled or combo with default gradient
            else if ((chb.EditValue.ToString().Length > 0) || (cb != null && cb.EditValue != null && cb.EditValue.ToString().Length > 0))
            {
                seriesColumns = AvrViewHelper.FillSeriesFromCombos(View, (string) chb.EditValue, cb == null ? "" : (string) cb.EditValue);
            }
                // fill whole table
            else
            {
                seriesColumns = FillAllColumns(view.VisibleColumns);
            }

            return seriesColumns;
        }

        // remember original names of selected columns
        private List<AvrViewColumn> FillSelectedColumns(IEnumerable<GridCell> cells)
        {
            var selColumns = new List<AvrViewColumn>();

            foreach (GridCell cell in cells)
            {
                if (!((AvrViewColumn) cell.Column.Tag).IsRowArea && !selColumns.Contains((AvrViewColumn) cell.Column.Tag))
                {
                    ((AvrViewColumn) cell.Column.Tag).FieldType = cell.Column.ColumnType;
                    selColumns.Add((AvrViewColumn) cell.Column.Tag);
                }
            }

            return selColumns;
        }

        // remember original names of all columns
        private List<AvrViewColumn> FillAllColumns(GridColumnReadOnlyCollection cols)
        {
            var allColumns = new List<AvrViewColumn>();

            for (int i = 0; i < cols.Count; i++)
            {
                if (!((AvrViewColumn) cols[i].Tag).IsRowArea)
                {
                    allColumns.Add((AvrViewColumn) cols[i].Tag);
                }
            }

            return allColumns;
        }

        // remember data of all rows of selected in combo column
        public Dictionary<int, DataRow> FillXAxisData(GridView view, string xName)
        {
            // fill selected rows or  fill whole column
            Dictionary<int, DataRow> xAxisData = view.GetSelectedCells().Length > 1
                ? FillSelectedRows(view)
                : FillAllRows(view);

            return AvrViewHelper.FillXAxisData(xAxisData, xName, View.GrandTotalSuffix, View.TotalSuffix);
        }

        // remember data of selected rows
        private Dictionary<int, DataRow> FillSelectedRows(GridView view)
        {
            var rows = new Dictionary<int, DataRow>();

            for (int i = 0; i < view.SelectedRowsCount; i++)
            {
                if (view.GetSelectedRows()[i] >= 0)
                {
                    rows.Add(view.GetDataSourceRowIndex(view.GetSelectedRows()[i]),
                        view.GetDataRow(view.GetSelectedRows()[i]));
                }
            }

            return rows;
        }

        private Dictionary<int, DataRow> FillAllRows(GridView view)
        {
            var rows = new Dictionary<int, DataRow>();
            for (int i = 0; i < view.DataRowCount; i++)
            {
                var rowView = (DataRowView) view.GetRow(i);
                rows.Add(i, rowView.Row);
            }
            return rows;
        }

        // Main function of prepairing data for chart
        public DataTable CreateDataForChart
            (string rowColumn, List<AvrViewColumn> columns, Dictionary<int, DataRow> rows, AggregateCashe aggrCache, GridView view)
        {
            AvrViewColumn rowColAvr = View.GetColumnByOriginalName(rowColumn);
            DataSet ds = AvrViewHelper.PrepareChartTable(View.LayoutName, columns, rowColAvr);
            DataTable dt = ds.Tables["Data"];

            if (rows != null && rows.Count > 0)
            {
                // fill rows of table
                dt.BeginLoadData();
                foreach (int i in rows.Keys)
                {
                    DataRow nRow = dt.NewRow();

                    nRow[rowColAvr.UniquePath] = rows[i][rowColumn];

                    FillMapOrChartValues(columns, aggrCache, view, rows, i, nRow, false);

                    dt.Rows.Add(nRow);
                }
                dt.EndLoadData();
                dt.AcceptChanges();
            }

            return dt;
        }

        // Main function of prepairing data for map
        public DataSet CreateDataForMap
            (string rowColumn, List<AvrViewColumn> columns, Dictionary<int, DataRow> rows, AggregateCashe aggrCache, GridView view,
                bool useDefaults)
        {
            DataSet ds = AvrViewHelper.PrepareMapTable(View.LayoutName, columns, useDefaults);
            DataTable dtData = ds.Tables["Data"];

            if (rows != null && rows.Count > 0)
            {
                dtData.Columns.Add("UniquePath", typeof (string));

                // fill rows of table
                dtData.BeginLoadData();
                foreach (int i in rows.Keys)
                {
                    DataRow nRow = dtData.NewRow();

                    var r = (string) rows[i][rowColumn];
                    if (r.EndsWith(View.TotalSuffix))
                    {
                        r = r.Substring(0, r.Length - View.TotalSuffix.Length);
                    }
                    nRow["UniquePath"] = r.Trim();

                    FillMapOrChartValues(columns, aggrCache, view, rows, i, nRow, true);

                    dtData.Rows.Add(nRow);
                }
                AvrViewHelper.ConvertMapDataForGis(ref dtData);
                dtData.Columns.Remove("UniquePath");
                dtData.EndLoadData();
                dtData.AcceptChanges();
            }

            return ds;
        }

        private static void FillMapOrChartValues
            (IEnumerable<AvrViewColumn> columns, AggregateCashe aggrCache, GridView view, Dictionary<int, DataRow> rows, int i, DataRow nRow, bool IsMap)
        {
            foreach (AvrViewColumn col in columns)
            {
                object val;
                if (col.IsAggregate)
                {
                    GridColumn gridColumn = view.Columns.ColumnByFieldName(col.UniquePath);

                    int rowIndex = i; // view.GetDataSourceRowIndex(i);
                    val = aggrCache.GetValue(col.UniquePath, rowIndex, rows[i], view, gridColumn, col);
                }
                else
                {
                    val = rows[i][col.UniquePath];
                }

                bool badValue = Utils.IsEmpty(val) ||
                                (val is double && (double.IsInfinity((double) val) || double.IsNaN((double) val)));

                if (!badValue && col.Precision.HasValue && col.Precision.Value >= 0)
                {
                    if (IsMap && col.IsAggregate &&
                        (col.AggregateFunction == (long)ViewAggregateFunction.CumulativePercent ||
                         col.AggregateFunction == (long)ViewAggregateFunction.PercentOfColumn ||
                         col.AggregateFunction == (long)ViewAggregateFunction.PercentOfRow))
                    {
                        val = (double)val * 100;
                    }

                    val = AvrViewHelper.RoundVal(val, col.Precision.Value);
                }
                nRow[col.UniquePath] = badValue
                    ? DBNull.Value
                    : val;
            }
        }

        #endregion

        #region Aggregate Functions

        public object FillAggregateColumn
            (GridView view, CollectionBase colCollection, int rowIndex, DataRow row, AvrViewColumn col, ref Dictionary<int, object> dict)
        {
            switch (col.AggregateFunction)
            {
                case (long) ViewAggregateFunction.CumulativePercent:
                    return FillGridAggrFCumProcent(view, rowIndex, col.SourceViewColumn, ref dict);
                case (long) ViewAggregateFunction.PercentOfColumn:
                    return FillGridAggrFColProcent(view, row, col.SourceViewColumn, ref dict);
                case (long) ViewAggregateFunction.PercentOfRow:
                    return FillGridAggrFRowProcent(row, col.SourceViewColumn, colCollection);
                case (long) ViewAggregateFunction.Proportion:
                    return FillGridAggrFProportion(row, col.SourceViewColumn, col.DenominatorViewColumn);
                case (long) ViewAggregateFunction.Ratio:
                    return FillGridAggrFRatio(row, col);
                case (long) ViewAggregateFunction.MaxOfRow:
                    return FillGridAggrFMinMax(row, colCollection, true);
                case (long) ViewAggregateFunction.MinOfRow:
                    return FillGridAggrFMinMax(row, colCollection, false);
            }
            return DBNull.Value;
        }

        private object FillGridAggrFCumProcent
            (GridView view, int rowIndex, string refColumn, ref Dictionary<int, object> dict)
        {
            object ret = DBNull.Value;

            if (!Utils.IsEmpty(refColumn))
            {
                double sum = 0;
                List<AvrViewColumn> rowCols = View.GetVisibleRowAdminColumns(true, null, false);

                int rowHandle = view.GetRowHandle(rowIndex);
                if (!AvrViewHelper.GetRowTotalStatus(view.GetDataRow(rowHandle), rowCols.Count, View.GrandTotalSuffix, View.TotalSuffix))
                    //if regular value (not total)
                {
                    for (int i = 0; i <= rowHandle; i++)
                    {
                        object cur = view.GetRowCellValue(i, refColumn);
                        if (Utils.IsEmpty(cur))
                        {
                            continue;
                        }
                        double dCur;
                        if (double.TryParse(cur.ToString(), out dCur))
                        {
                            if (!AvrViewHelper.GetRowTotalStatus(view.GetDataRow(i), rowCols.Count, View.GrandTotalSuffix, View.TotalSuffix))
                                //if regular value (not total)
                            {
                                sum += dCur;
                            }
                        }
                    }

                    //if (Math.Abs(sum) > 1e-16)
                    //{
                    if (sum == 0)
                        ret = 0;
                    else
                        ret = sum / AvrViewHelper.GetColumnSum(view, rowCols.Count, View.GrandTotalSuffix, View.TotalSuffix, refColumn, ref dict);
                    //}
                }
            }

            return ret;
        }

        private object FillGridAggrFColProcent
            (GridView view, DataRow row, string refColumn, ref Dictionary<int, object> dict)
        {
            object ret = DBNull.Value;

            if (!Utils.IsEmpty(refColumn))
            {
                double dCur;
                List<AvrViewColumn> rowCols = View.GetVisibleRowAdminColumns(true, null, false);

                object cur = row[refColumn];
                bool status = AvrViewHelper.GetRowTotalStatus(row, rowCols.Count, View.GrandTotalSuffix, View.TotalSuffix);

                if (!Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dCur))
                {
                    // get Sum of refColumn
                    //double sumFull = GetColumnSum(view, refColumn, ref dict);

                    ret = dCur /
                          AvrViewHelper.GetColumnSum(view, rowCols.Count, View.GrandTotalSuffix, View.TotalSuffix, refColumn, ref dict);
                }
            }

            return ret;
        }

        private object FillGridAggrFRowProcent(DataRow row, string refColumn, CollectionBase colCollection)
        {
            object ret = DBNull.Value;

            if (!Utils.IsEmpty(refColumn))
            {
                double sum = 0;
                double dCol;

                object cur = row[refColumn];
                if (!Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dCol))
                {
                    // get Sum of rowIndex row
                    IEnumerator myEnumerator = colCollection.GetEnumerator();
                    while (myEnumerator.MoveNext())
                    {
                        var gCol = (GridColumn) myEnumerator.Current;
                        if (!gCol.Visible || ((AvrViewColumn) gCol.Tag).IsAggregate || !gCol.ColumnType.IsNumeric())
                        {
                            continue;
                        }
                        if (((AvrViewColumn) gCol.Tag).OriginalName.EndsWith(View.GrandTotalSuffix))
                        {
                            continue;
                        }
                        if (((AvrViewColumn) gCol.Tag).OriginalName.EndsWith(View.TotalSuffix))
                        {
                            continue;
                        }

                        cur = row[gCol.FieldName];
                        double dCur;
                        if (double.TryParse(cur.ToString(), out dCur))
                        {
                            sum += dCur;
                        }
                    }

                    ret = dCol / sum;
                }
            }

            return ret;
        }

        private object FillGridAggrFProportion(DataRow row, string refColumn, string denominator)
        {
            object ret = DBNull.Value;

            if (!Utils.IsEmpty(refColumn) && !Utils.IsEmpty(denominator))
            {
                double dRef;

                object cur = row[refColumn];
                if (!Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dRef))
                {
                    cur = row[denominator];
                    double dDen;
                    if (!Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dDen))
                    {
                        ret = dRef / dDen;
                    }
                }
            }

            return ret;
        }

        private object FillGridAggrFRatio(DataRow row, AvrViewColumn col)
        {
            object ret = DBNull.Value;

            if (!Utils.IsEmpty(col.SourceViewColumn) && !Utils.IsEmpty(col.DenominatorViewColumn))
            {
                double dRef;

                object cur = row[col.SourceViewColumn];
                if (!Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dRef))
                {
                    cur = row[col.DenominatorViewColumn];
                    double dDen;
                    if (!Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dDen))
                    {
                        ret = AvrViewHelper.GetRatio(dRef, dDen, col.Precision);
                    }
                }
            }

            return ret;
        }

        private object FillGridAggrFMinMax(DataRow row, CollectionBase colCollection, bool max)
        {
            object ret = DBNull.Value;

            DateTime? mmDt = null;
            double? mmN = null;
            IEnumerator myEnumerator = colCollection.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                var gCol = (GridColumn) myEnumerator.Current;

                if (!gCol.Visible || ((AvrViewColumn) gCol.Tag).IsAggregate || gCol.ColumnType == typeof (string))
                {
                    continue;
                }
                if (((AvrViewColumn) gCol.Tag).OriginalName.EndsWith(View.GrandTotalSuffix))
                {
                    continue;
                }
                if (((AvrViewColumn) gCol.Tag).OriginalName.EndsWith(View.TotalSuffix))
                {
                    continue;
                }

                object cur = row[gCol.FieldName];
                if (Utils.IsEmpty(cur))
                {
                    continue;
                }

                if (gCol.ColumnType == typeof (DateTime))
                {
                    DateTime c = Convert.ToDateTime(cur);
                    if (mmDt == null || (max && mmDt < c) || (!max && mmDt > c))
                    {
                        mmDt = c;
                    }
                }
                else
                {
                    double c;
                    if (!double.TryParse(cur.ToString(), out c))
                    {
                        continue;
                    }

                    if (mmN == null || (max && mmN < c) || (!max && mmN > c))
                    {
                        mmN = c;
                    }
                }
            }
            if (mmDt != null && mmN == null)
            {
                ret = mmDt;
            }
            else if (mmN != null && mmDt == null)
            {
                ret = mmN;
            }

            return ret;
        }

        #endregion

        #region PrintExport

        private void ProcessPrint(PrintCommand printCommand)
        {
            if (printCommand.PrintType != PrintType.View)
            {
                return;
            }
            Trace.WriteLine(Trace.Kind.Info, "PivotReportForm.Process(): executing Pivot Grid print command");

            m_ReportView.OnPrint();

            printCommand.State = CommandState.Processed;
        }

        private void ProcessExport(ExportCommand exportCommand)
        {
            if (exportCommand.ExportObject != ExportObject.View)
            {
                return;
            }

            Trace.WriteLine(Trace.Kind.Info, "PivotReportForm.Process(): executing Pivot Grid export command");

            exportCommand.State = CommandState.Pending;

            m_ReportView.OnExport(exportCommand.ExportType);

            exportCommand.State = CommandState.Processed;
        }

        #endregion

        #region Comboboxes Filling

        public void FillChartSeries(CheckedComboBoxEdit cb)
        {
            List<AvrViewColumn> visibleNotRowColumns = View.GetMapDefChartList();
            cb.Properties.DataSource = visibleNotRowColumns;
            cb.Properties.ValueMember = "UniquePath";
            cb.Properties.DisplayMember = "FullPath";

            string initial = "";
            foreach (AvrViewColumn col in visibleNotRowColumns.FindAll(c => c.IsChartSeries))
            {
                if (initial.Length > 0)
                {
                    initial += ", ";
                }
                initial += col.UniquePath;
            }
            cb.SetEditValue(initial);
        }

        public void FillMapDiagramSeries(CheckedComboBoxEdit cb)
        {
            List<AvrViewColumn> visibleNotRowColumns = View.GetMapDefChartList();
            cb.Properties.DataSource = visibleNotRowColumns;
            cb.Properties.ValueMember = "UniquePath";
            cb.Properties.DisplayMember = "FullPath";

            string initial = "";
            foreach (AvrViewColumn col in visibleNotRowColumns.FindAll(c => c.IsMapDiagramSeries))
            {
                if (initial.Length > 0)
                {
                    initial += ", ";
                }
                initial += col.UniquePath;
            }
            cb.SetEditValue(initial);
        }

        public void FillMapDataGradient(LookUpEdit cb)
        {
            // get nonrow columns + emty row
            List<AvrViewColumn> visibleNotRowColumns = View.GetMapDefGradientList();

            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] {new LookUpColumnInfo("FullPath", EidssMessages.Get("Columns"), 150)});
            cb.Properties.PopupWidth = 350;

            SetDataSource(cb, visibleNotRowColumns, "FullPath", "UniquePath");

            cb.EditValue = View.GradientColumn;
        }

        public void FillChartXAxis(LookUpEdit cb)
        {
            // get row columns + emty row
            List<AvrViewColumn> visibleNotRowColumns = View.GetChartXAxisList();

            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] {new LookUpColumnInfo("FullPath", EidssMessages.Get("Columns"), 150)});
            cb.Properties.PopupWidth = 350;

            SetDataSource(cb, visibleNotRowColumns, "FullPath", "UniquePath");

            cb.EditValue = visibleNotRowColumns.FindAll(col => col.UniquePath == View.ChartXAxisViewColumn).Count > 0
                ? View.ChartXAxisViewColumn
                : string.Empty;
        }

        public void FillMapAdminUnit(LookUpEdit cb)
        {
            // get (row & administrative) columns + emty row
            List<AvrViewColumn> visibleNotRowColumns = View.GetMapAdminUnitList();

            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] {new LookUpColumnInfo("FullPath", EidssMessages.Get("Columns"), 150)});
            cb.Properties.PopupWidth = 350;

            SetDataSource(cb, visibleNotRowColumns, "FullPath", "UniquePath");

            cb.EditValue = visibleNotRowColumns.FindAll(col => col.UniquePath == View.MapAdminUnitViewColumn).Count > 0
                ? View.MapAdminUnitViewColumn
                : "";
        }

        public void FillBandColumns(LookUpEdit cb, BaseBand band)
        {
            View.FillBandsFullPaths();

            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[] {new LookUpColumnInfo("FullPath", EidssMessages.Get("Columns"), 150)});
            cb.Properties.PopupWidth = 350;

            SetDataSource(cb, band.FillBandColumns(), "FullPath", "UniquePath");
        }

        #endregion

        #region Static Functions

        #region Comboboxes

        public static void SetDataSource(LookUpEdit cb, object ds, string displayMember, string valueMember)
        {
            cb.Properties.DataSource = null;
            cb.Properties.DataSource = ds;
            cb.Properties.DisplayMember = displayMember;
            cb.Properties.ValueMember = valueMember;

            cb.Properties.NullText = String.Empty;
            cb.Properties.ShowDropDown = ShowDropDown.SingleClick;
        }

        public static void AddClearButton(CheckedComboBoxEdit ctl)
        {
            IEnumerable<EditorButton> buttons = ctl.Properties.Buttons.Cast<EditorButton>();
            if (buttons.Any(b => b.Kind == ButtonPredefines.Delete))
            {
                return;
            }
            ctl.ButtonClick += ClearButtonClick;
            var btn = new EditorButton(ButtonPredefines.Delete, BvMessages.Get("btnClear", "Clear the field contents"));

            ctl.Properties.Buttons.Add(btn);
        }

        private static void ClearButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                ((CheckedComboBoxEdit) sender).SetEditValue("");
            }
        }

        #endregion

        #endregion
    }

    public class CustomFormatter : IFormatProvider, ICustomFormatter
    {
        private readonly DisplayTextTranslations m_Translations;

        public CustomFormatter()
        {
            m_Translations = new DisplayTextTranslations();
        }

        // The GetFormat method of the IFormatProvider interface.
        // This must return an object that provides formatting services for the specified type.
        public object GetFormat(Type type)
        {
            return this;
        }

        // The Format method of the ICustomFormatter interface.
        // This must format the specified value according to the specified format settings.
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string formatValue = arg.ToString();

            if (format == "m")
            {
                int formatV = int.Parse(formatValue);
                return m_Translations.MonthValues[formatV - 1];
            }
            if (format == "d")
            {
                int formatV = int.Parse(formatValue);
                return m_Translations.DayOfWeekValues[formatV - 1];
            }
            return formatValue;
        }
    }
}