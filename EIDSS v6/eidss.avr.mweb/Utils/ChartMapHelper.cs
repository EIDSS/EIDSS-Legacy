using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DevExpress.XtraCharts;
using eidss.avr.db.Common;
using eidss.model.Avr.Chart;
using eidss.model.Avr.View;
using eidss.model.Resources;

namespace eidss.avr.mweb.Utils
{
    public class ChartMapHelper
    {
/*        public static class ChartSerieElementProvider
        {
            public static IList<ChartSerieElement> GetChartSerieElements(DataTable data)
            {
                List<ChartSerieElement> result = new List<ChartSerieElement>();
                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        for (int i = 1; i < data.Columns.Count; i++)
                            result.Add(new ChartSerieElement(row[0].ToString(), data.Columns[i].Caption, bv.common.Core.Utils.IsEmpty(row[i]) ? 0 : Double.Parse(row[i].ToString())));
                    }
                }
                return result;
            }
        }

        public class ChartModel
        {
            long layoutId;
            string chartType;
            string caption;
            string footer;
            IList<ChartSerieElement> list;

            public long LayoutID { get { return layoutId; } }
            public string ChartType { get { return chartType; } }
            public string Caption { get { return caption; } }
            public string Footer { get { return footer; } }
            public IList<ChartSerieElement> List { get { return list; } }

            public ChartModel(long layoutId, string chartType, string caption, string footer, DataTable data)
            {
                this.layoutId = layoutId;
                this.chartType = chartType;
                this.caption = caption;
                this.footer = footer;
                list = ChartSerieElementProvider.GetChartSerieElements(data);
            }
        }

        public class ChartSerieElement
        {
            string argument;
            string dataColumn;
            double value;

            public string Argument { get { return argument; } }
            public string DataColumn { get { return dataColumn; } }
            public double Value { get { return value; } }

            public ChartSerieElement(string argument, string dataColumn, double value)
            {
                this.argument = argument;
                this.dataColumn = dataColumn;
                this.value = value;
            }
        }*/

        public class ChartModel
        {
            long layoutId;
            string chartType;
            string data;
            string class_;

            public long LayoutID { get { return layoutId; } }
            public string ChartType { get { return chartType; } }
            public string Data { get { return data; } }
            public string Class { get { return class_; } }

            public ChartModel(long layoutId, string chartType, string data)
            {
                this.layoutId = layoutId;
                this.chartType = chartType == null ? "" : chartType;
                this.data = data == null ? "" : data;
                this.class_ = string.IsNullOrEmpty(data) ? "invisible" : "";
            }
        }

/*        public static ChartModel TryToPrepareChartData(AvrPivotViewModel viewModel)
        {
            string columnName = viewModel.ViewHeader.ChartXAxisViewColumn;
            string chb = viewModel.ViewHeader.GetColumnsBooleans("IsChartSeries");
            // remember columns for future DataTable
            List<AvrViewColumn> chartColumns = FillSeriesColumns(viewModel.ViewHeader, chb, null);

            // remember rows for future DataTable
            Dictionary<int, DataRow> xAxisRows = FillXAxisData(viewModel.ViewData, columnName, viewModel.ViewHeader.GrandTotalSuffix, viewModel.ViewHeader.TotalSuffix);

            // fill DataSet with 2 DataTable !!!
            DataTable data = CreateDataForChart(columnName, chartColumns, xAxisRows, viewModel.ViewHeader);

            return new ChartModel(viewModel.ViewHeader.LayoutID, viewModel.ViewHeader.ChartType, viewModel.ViewHeader.LayoutName, data.Columns[0].Caption, data);
        }*/

        public static DataTable TryToPrepareChartData(AvrPivotViewModel viewModel)
        {
            string columnName = viewModel.ViewHeader.ChartXAxisViewColumn;
            string chb = viewModel.ViewHeader.GetColumnsBooleans("IsChartSeries");
            // remember columns for future DataTable
            List<AvrViewColumn> chartColumns = FillSeriesColumns(viewModel.ViewHeader, chb, null);

            // remember rows for future DataTable
            //viewModel.ViewHeader.GetAllColumns();
            //DataTable dt = viewModel.ViewData.Select();
            Dictionary<int, DataRow> xAxisRows = FillXAxisData(viewModel.ViewData, columnName, viewModel.ViewHeader);

            // fill DataSet with 2 DataTable !!!
            return CreateDataForChart(columnName, chartColumns, xAxisRows, viewModel.ViewHeader);
        }

        public static ChartModel GetEmptyChartData(AvrPivotViewModel viewModel)
        {
            return new ChartModel(viewModel.ViewHeader.LayoutID, viewModel.ViewHeader.ChartType, "");
        }


        public static string TryToPrepareMapData(AvrPivotViewModel viewModel, out DataSet data)
        {
            string columnName = viewModel.ViewHeader.MapAdminUnitViewColumn;
            if (viewModel.ViewData.Columns.Contains(columnName + "hasc"))
                columnName = columnName + "hasc";

            // remember columns for future DataTable
            List<AvrViewColumn> mapColumns = FillSeriesColumns(viewModel.ViewHeader, viewModel.ViewHeader.GetColumnsBooleans("IsMapDiagramSeries"), viewModel.ViewHeader.GradientColumn);

            // remember rows for future DataTable
            Dictionary<int, DataRow> xAxisRows = FillXAxisData(viewModel.ViewData, columnName, viewModel.ViewHeader);

            //remove * strings
            xAxisRows.ToList().FindAll(d => ((string)d.Value[columnName]).Equals("*")).ForEach(d => xAxisRows.Remove(d.Key));

            // have we duplicates? - remove everything
            var l = new List<DataRow>(xAxisRows.Values);
            if (AvrViewHelper.hasDuplicates(l.ConvertAll(v => v[columnName])))
            {
                data = new DataSet();
                return EidssMessages.Get("msgDuplicatesInAdmUnit");
            }

            // fill DataSet with 2 DataTable !!!
            data = CreateDataForMap(columnName, mapColumns, xAxisRows, viewModel.ViewHeader);
            return String.Empty;
        }

        private static List<AvrViewColumn> FillSeriesColumns(AvrView view, string chb, string cb)
        {
            List<AvrViewColumn> seriesColumns;

            // fill selected cells
            /*GridCell[] selectedCells = view.GetSelectedCells();
            if (selectedCells.Length > 1)
            {
                seriesColumns = FillSelectedColumns(selectedCells);
            }
            // fill default series
            else*/
            if ((chb != null && chb.Length > 0) || (cb != null && cb.Length > 0))
            {
                seriesColumns = AvrViewHelper.FillSeriesFromCombosWeb(view, chb, cb);
            }
            // fill whole table
            else
            {
                seriesColumns = view.GetVisibleRowAdminColumns(false, null, false);
            }

            return seriesColumns;
        }

        // remember data of all rows of selected in combo column
        private static Dictionary<int, DataRow> FillXAxisData(DataTable dt, string xName, AvrView view)
        {
            // fill selected rows or  fill whole column
            Dictionary<int, DataRow> xAxisData = /*view.GetSelectedCells().Length > 1
                ? FillSelectedRows(view)
                :*/ FillAllRows(dt, view);

            return AvrViewHelper.FillXAxisData(xAxisData, xName, view.GrandTotalSuffix, view.TotalSuffix);
        }

        private static Dictionary<int, DataRow> FillAllRows(DataTable tbl, AvrView view)
        {
            string filter = view.GetFilterExpression(true);
            string sort = view.GetSortExpression();
            DataRow[] result = tbl.Select(filter, sort);
            var rows = new Dictionary<int, DataRow>();
            for (int i = 0; i < result.Count(); i++)
            {
                rows.Add(i, result[i]);
            }
            return rows;
        }

        // Main function of prepairing data for map
        private static DataSet CreateDataForMap(string rowColumn, List<AvrViewColumn> columns, Dictionary<int, DataRow> rows, AvrView view)
        {
            var ds = AvrViewHelper.PrepareMapTable(view.LayoutName, columns);
            DataTable dtData = ds.Tables["Data"];

            if (rows != null && rows.Count > 0)
            {
                dtData.Columns.Add("UniquePath", typeof(string));

                // fill rows of table
                dtData.BeginLoadData();
                foreach (int i in rows.Keys)
                {
                    DataRow nRow = dtData.NewRow();

                    var r = (string)rows[i][rowColumn];
                    if (r.EndsWith(view.TotalSuffix))
                    {
                        r = r.Substring(0, r.Length - view.TotalSuffix.Length);
                    }
                    nRow["UniquePath"] = r.Trim();

                    FillMapOrChartValues(columns, rows, i, nRow);

                    dtData.Rows.Add(nRow);
                }
                AvrViewHelper.ConvertMapDataForGis(ref dtData);
                dtData.Columns.Remove("UniquePath");
                dtData.EndLoadData();
                dtData.AcceptChanges();
            }

            return ds;
        }

        // Main function of prepairing data for chart
        private static DataTable CreateDataForChart(string rowColumn, List<AvrViewColumn> columns, Dictionary<int, DataRow> rows, AvrView view)
        {
            var rowColAvr = view.GetColumnByOriginalName(rowColumn);
            var ds = AvrViewHelper.PrepareChartTable(view.LayoutName, columns, rowColAvr);
            var dt = ds.Tables["Data"];

            if (rows != null && rows.Count > 0)
            {
                // fill rows of table
                dt.BeginLoadData();
                foreach (int i in rows.Keys)
                {
                    DataRow nRow = dt.NewRow();

                    nRow[rowColAvr.UniquePath] = rows[i][rowColumn];

                    FillMapOrChartValues(columns, rows, i, nRow);

                    dt.Rows.Add(nRow);
                }
                dt.EndLoadData();
                dt.AcceptChanges();
            }

            return dt;
        }


        private static void FillMapOrChartValues
            (IEnumerable<AvrViewColumn> columns, Dictionary<int, DataRow> rows, int i, DataRow nRow)
        {
            foreach (AvrViewColumn col in columns)
            {
                object val = null;
                if (rows!= null && rows.Count > 0 && rows[i].Table.Columns.Contains(col.UniquePath))
                {
                    val = rows[i][col.UniquePath];
                }

                bool badValue = bv.common.Core.Utils.IsEmpty(val) ||
                                (val is double && (double.IsInfinity((double)val) || double.IsNaN((double)val)));

                if (!badValue && col.Precision.HasValue && col.Precision.Value >= 0)
                {
                    if (col.IsAggregate &&
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


        public static List<System.Web.Mvc.SelectListItem> GetBarViews()
        {
            var lst = new List<System.Web.Mvc.SelectListItem>() {
                new System.Web.Mvc.SelectListItem() { Text = "", Value = "" },
                new System.Web.Mvc.SelectListItem() { Text = "Area", Value = ViewType.Area.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Area", Value = ViewType.Area3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Bar", Value = ViewType.Bar.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Bar", Value = ViewType.Bar3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Doughnut", Value = ViewType.Doughnut.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Doughnut", Value = ViewType.Doughnut3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Full-Stacked Bar", Value = ViewType.FullStackedBar.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Full-Stacked Bar", Value = ViewType.FullStackedBar3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Line", Value = ViewType.Line.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Line", Value = ViewType.Line3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Pie", Value = ViewType.Pie.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Pie", Value = ViewType.Pie3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Point", Value = ViewType.Point.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Spline", Value = ViewType.Spline.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Spline Area", Value = ViewType.SplineArea3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Stacked Bar", Value = ViewType.StackedBar.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Stacked Bar", Value = ViewType.StackedBar3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Step Line", Value = ViewType.StepLine.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Step Line", Value = ViewType.StepLine3D.ToString() }
            };
            return lst;
        }

        public static List<System.Web.Mvc.SelectListItem> GetBarViews2()
        {
            var lst = new List<System.Web.Mvc.SelectListItem>() {
                new System.Web.Mvc.SelectListItem() { Text = "", Value = "" },
                new System.Web.Mvc.SelectListItem() { Text = "Area", Value = DBChartType.chrArea.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Area", Value = DBChartType.chrArea3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Bar", Value = DBChartType.chrBar.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Bar", Value = DBChartType.chrBar3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Doughnut", Value = DBChartType.chrDoughnut.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Doughnut", Value = DBChartType.chrDoughnut3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Full-Stacked Bar", Value = DBChartType.chrFullStackedBar.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Full-Stacked Bar", Value = DBChartType.chrFullStackedBar3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Line", Value = DBChartType.chrLine.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Line", Value = DBChartType.chrLine3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Pie", Value = DBChartType.chrPie.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Pie", Value = DBChartType.chrPie3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Point", Value = DBChartType.chrPoint.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Spline", Value = DBChartType.chrSpline.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Spline Area", Value = DBChartType.chrSpline3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Stacked Bar", Value = DBChartType.chrStackedBar.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Stacked Bar", Value = DBChartType.chrStackedBar3D.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "Step Line", Value = DBChartType.chrStepLine.ToString() },
                new System.Web.Mvc.SelectListItem() { Text = "3D Step Line", Value = DBChartType.chrStepLine3D.ToString() }
            };
            return lst;
        }
    }
}