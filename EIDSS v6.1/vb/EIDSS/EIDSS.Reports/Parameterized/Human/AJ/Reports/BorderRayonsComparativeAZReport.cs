using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class BorderRayonsComparativeAZReport : BaseDateReport
    {
        private const int MaxDiagnosisCount = 12;

        private int m_RowNumber;
        private int m_RayonNumber;

        public BorderRayonsComparativeAZReport()
        {
            InitializeComponent();
        }

        public void SetParameters(BorderRayonsSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            BindHeader(model);

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;

                m_DataSet.EnforceConstraints = false;

                string diagnosisXml = FilterHelper.GetXmlFromList(model.DiagnosisCheckedItems);
                m_Adapter.Fill(m_DataSet.BorderRayonsTable,
                    model.Language,
                    model.Year, model.Month, model.MonthEnd,
                    FilterHelper.GetXmlFromList(model.Counters),
                    model.RegionId, model.RayonId,
                    diagnosisXml,
                    model.SiteId);
            });
            var keyName = new[] {"idfsRayon"};
            var ignoreName = new[]
            {
                "intCounter", "intRowNum", "idfsDiagnosis_1", "idfsDiagnosis_2", "idfsDiagnosis_3",
                "idfsDiagnosis_4", "idfsDiagnosis_5", "idfsDiagnosis_6", "idfsDiagnosis_7",
                "idfsDiagnosis_8", "idfsDiagnosis_9", "idfsDiagnosis_10", "idfsDiagnosis_11", "idfsDiagnosis_12"
            };
            FillDataTableWithArchive(action,
                BeforeMergeWithArchive,
                manager, archiveManager,
                m_DataSet.BorderRayonsTable,
                model.Mode,
                keyName,
                ignoreName);
            m_DataSet.BorderRayonsTable.DefaultView.Sort = "intRowNum";

            RoundData();
            m_RayonNumber = 1;
            m_RowNumber = 0;

            var totalRow = m_DataSet.BorderRayonsTable.FirstOrDefault(r => r.idfsRayon < 0);
            if (totalRow!=null)
                totalRow.strRayonName = HeaderTotal1Cell.Text;

            var counters = ExtractCountersFromModel(model);

            InitChartSettings(model.DiagnosisCheckedItems.Length > 0, counters.Item1, counters.Item2);

            RemoveUnusedCells(model.Counters.Length < 2);

            ReportRtlHelper.SetRTL(this);
        }

        private void BeforeMergeWithArchive(DataTable sourceData, DataTable archiveData)
        {
            var source = (BorderRayonsComparativeAZDataSet.BorderRayonsTableDataTable) sourceData;
            var archive = (BorderRayonsComparativeAZDataSet.BorderRayonsTableDataTable) archiveData;

            var rowsToRemove = Enumerable.Where(archive, row => source.FindBystrKey(row.strKey) == null).ToList();

            archive.BeginLoadData();
            foreach (var row in rowsToRemove)
            {
                archive.Rows.Remove(row);
            }
            archive.EndLoadData();
        }

        private void BindHeader(BorderRayonsSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");
            string monthRange = string.Empty;
            if (model.Month.HasValue && model.MonthEnd.HasValue)
            {
                List<ItemWrapper> monthCollection = FilterHelper.GetWinMonthList();
                if (model.Month.Value == model.MonthEnd.Value)
                {
                    monthRange = string.Format("{0}", monthCollection[model.Month.Value - 1]);
                }
                else
                {
                    monthRange = string.Format("{0} - {1}",
                        monthCollection[model.Month.Value - 1], monthCollection[model.MonthEnd.Value - 1]);
                }
            }
            string location = AddressModel.GetLocation(model.Language, EidssMessages.Get("strReportRepublic"),
                model.RegionId, model.RegionName, model.RayonId, model.RayonName, true);

            HeaderLabel2.Text = string.Format(HeaderLabel2.Text, model.Year, monthRange, location);
        }

        private void RemoveUnusedCells(bool singleCounter)
        {
            HeaderTable.BeginInit();
            DetailTable.BeginInit();

            if (singleCounter)
            {
                HeaderRow1.DeleteCell(HeaderCounter1Cell);
                HeaderRow2.DeleteCell(HeaderCounter2Cell);

                DetailRow.DeleteCell(CounterCell);
            }

            if (m_DataSet.BorderRayonsTable.Count > 0)
            {
                BorderRayonsComparativeAZDataSet.BorderRayonsTableRow row = m_DataSet.BorderRayonsTable[0];

                ChangeCellFont(HeaderDiagnosis1Cell, HeaderDiagnosis2Cell, HeaderDiagnosis3Cell, HeaderDiagnosis4Cell,
                    HeaderDiagnosis5Cell, HeaderDiagnosis6Cell, HeaderDiagnosis7Cell, HeaderDiagnosis8Cell,
                    HeaderDiagnosis9Cell, HeaderDiagnosis10Cell, HeaderDiagnosis11Cell, HeaderDiagnosis12Cell);

                RemoveCells(HeaderDiagnosis1Cell, HeaderICD1Cell, Diagnosis1Cell, row.IsidfsDiagnosis_1Null());
                RemoveCells(HeaderDiagnosis2Cell, HeaderICD2Cell, Diagnosis2Cell, row.IsidfsDiagnosis_2Null());
                RemoveCells(HeaderDiagnosis3Cell, HeaderICD3Cell, Diagnosis3Cell, row.IsidfsDiagnosis_3Null());
                RemoveCells(HeaderDiagnosis4Cell, HeaderICD4Cell, Diagnosis4Cell, row.IsidfsDiagnosis_4Null());
                RemoveCells(HeaderDiagnosis5Cell, HeaderICD5Cell, Diagnosis5Cell, row.IsidfsDiagnosis_5Null());
                RemoveCells(HeaderDiagnosis6Cell, HeaderICD6Cell, Diagnosis6Cell, row.IsidfsDiagnosis_6Null());
                RemoveCells(HeaderDiagnosis7Cell, HeaderICD7Cell, Diagnosis7Cell, row.IsidfsDiagnosis_7Null());
                RemoveCells(HeaderDiagnosis8Cell, HeaderICD8Cell, Diagnosis8Cell, row.IsidfsDiagnosis_8Null());
                RemoveCells(HeaderDiagnosis9Cell, HeaderICD9Cell, Diagnosis9Cell, row.IsidfsDiagnosis_9Null());
                RemoveCells(HeaderDiagnosis10Cell, HeaderICD10Cell, Diagnosis10Cell, row.IsidfsDiagnosis_10Null());
                RemoveCells(HeaderDiagnosis11Cell, HeaderICD11Cell, Diagnosis11Cell, row.IsidfsDiagnosis_11Null());
                RemoveCells(HeaderDiagnosis12Cell, HeaderICD12Cell, Diagnosis12Cell, row.IsidfsDiagnosis_12Null());

                bool totalInvisible = row.IsblnTotalVisibleNull() || !row.blnTotalVisible;
                RemoveCells(HeaderTotal1Cell, HeaderTotal2Cell, TotalCell, totalInvisible);
            }
            DetailTable.EndInit();
            HeaderTable.EndInit();
        }

        private void ChangeCellFont(params XRTableCell[] cells)
        {
            foreach (XRTableCell cell in cells)
            {
                cell.Font = new Font(cell.Font.FontFamily, cell.Font.Size - 1);
            }
        }

        private void RemoveCells(XRTableCell header1Cell, XRTableCell header2Cell, XRTableCell detailCell, bool needRemove)
        {
            if (needRemove)
            {
                if (header1Cell != null)
                {
                    HeaderRow1.Cells.Remove(header1Cell);
                }
                if (header2Cell != null)
                {
                    HeaderRow2.Cells.Remove(header2Cell);
                }
                if (detailCell != null)
                {
                    DetailRow.Cells.Remove(detailCell);
                }
            }
        }

        private static Tuple<int, int?> ExtractCountersFromModel(BorderRayonsSurrogateModel model)
        {
            if (model.Counters == null || model.Counters.Length == 0)
            {
                model.Counters = new[] {"1"};
            }
            int firstCounter;
            if (!int.TryParse(model.Counters[0], out firstCounter))
            {
                firstCounter = 1;
            }

            int secondCounter = 0;
            if (model.Counters.Length > 1)
            {
                int.TryParse(model.Counters[1], out secondCounter);
            }
            Tuple<int, int?> counters = new Tuple<int, int?>(firstCounter, secondCounter > 0 ? secondCounter : (int?) null);
            return counters;
        }

        private void NumberRayonCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            if (cell != null)
            {
                if (ReferenceEquals(cell, NumberCell))
                {
                    cell.Text = m_RayonNumber.ToString();
                    m_RowNumber++;
                }
                if (m_RowNumber > 0 && m_RowNumber <= m_DataSet.BorderRayonsTable.Count)
                {
                    cell.Borders = BorderSide.Left | BorderSide.Right;

                    var row = m_DataSet.BorderRayonsTable[m_RowNumber - 1];
                    if (m_RowNumber > 1 &&
                        (m_DataSet.BorderRayonsTable[m_RowNumber - 2].idfsRayon == row.idfsRayon))
                    {
                        cell.Text = string.Empty;
                    }
                    else
                    {
                        cell.Borders |= BorderSide.Top;
                        if (ReferenceEquals(cell, NumberCell))
                        {
                            m_RayonNumber++;
                        }
                    }
                }
            }
        }

        private void CounterCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            if (cell != null)
            {
                int counter;
                if (int.TryParse(cell.Text, out counter))
                {
                    cell.Text = GetCounterName(counter);
                }
            }
        }

        private void DiagnosisCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            if (cell != null)
            {
                if (m_RowNumber > 0 && m_RowNumber <= m_DataSet.BorderRayonsTable.Count)
                {
                    var row = m_DataSet.BorderRayonsTable[m_RowNumber - 1];

                    if (row.intCounter == 1 && cell.Text.Length > 3)
                    {
                        cell.Text = cell.Text.Substring(0, cell.Text.Length - 3);
                    }
                }

                if (string.IsNullOrEmpty(cell.Text))
                {
                    cell.Text = "-";
                }
            }
        }

        private void RoundData()
        {
            foreach (BorderRayonsComparativeAZDataSet.BorderRayonsTableRow row in m_DataSet.BorderRayonsTable)
            {
                int digits = row.intCounter == 1 ? 0 : 2;

                if (!row.IsdblTotalNull())
                {
                    row.dblTotal = Math.Round(row.dblTotal, digits);
                }
                if (!row.IsdblValue_1Null())
                {
                    row.dblValue_1 = Math.Round(row.dblValue_1, digits);
                }
                if (!row.IsdblValue_2Null())
                {
                    row.dblValue_2 = Math.Round(row.dblValue_2, digits);
                }
                if (!row.IsdblValue_3Null())
                {
                    row.dblValue_3 = Math.Round(row.dblValue_3, digits);
                }
                if (!row.IsdblValue_4Null())
                {
                    row.dblValue_4 = Math.Round(row.dblValue_4, digits);
                }
                if (!row.IsdblValue_5Null())
                {
                    row.dblValue_5 = Math.Round(row.dblValue_5, digits);
                }
                if (!row.IsdblValue_6Null())
                {
                    row.dblValue_6 = Math.Round(row.dblValue_6, digits);
                }
                if (!row.IsdblValue_7Null())
                {
                    row.dblValue_7 = Math.Round(row.dblValue_7, digits);
                }
                if (!row.IsdblValue_8Null())
                {
                    row.dblValue_8 = Math.Round(row.dblValue_8, digits);
                }
                if (!row.IsdblValue_9Null())
                {
                    row.dblValue_9 = Math.Round(row.dblValue_9, digits);
                }
                if (!row.IsdblValue_10Null())
                {
                    row.dblValue_10 = Math.Round(row.dblValue_10, digits);
                }
                if (!row.IsdblValue_11Null())
                {
                    row.dblValue_11 = Math.Round(row.dblValue_11, digits);
                }
                if (!row.IsdblValue_12Null())
                {
                    row.dblValue_12 = Math.Round(row.dblValue_12, digits);
                }
            }
        }

        private static string GetCounterName(int counter)
        {
            return EidssMessages.Instance.GetString("cbCounter" + (counter - 1));
        }

        private static string GetSeriesName(object diagnosis, int counter)
        {
            var diagnosisName = Utils.Str(diagnosis);
            string counterName = GetCounterName(counter);
            string separator = diagnosisName.Length + counterName.Length > 50
                ? Environment.NewLine
                : String.Empty;
            return string.Format("{0} - {1}{2}", diagnosis, separator, counterName);
        }

        private void InitChartSettings(bool hasDiagnosis, int counter, int? additionalCounter)
        {
            var diagram = (XYDiagram) ChartBorderRayons.Diagram;
            diagram.SecondaryAxesY[0].Visibility = additionalCounter.HasValue
                ? DefaultBoolean.True
                : DefaultBoolean.False;
            foreach (BorderRayonsComparativeAZDataSet.BorderRayonsTableRow row in m_DataSet.BorderRayonsTable)
            {
                if (row.idfsRayon > 0)
                {
                    if (row.intCounter == counter)
                    {
                        BorderRayonsComparativeAZDataSet.ChartBarTableRow chartRow = m_DataSet.ChartBarTable.NewChartBarTableRow();
                        m_DataSet.ChartBarTable.AddChartBarTableRow(chartRow);
                        chartRow.idfsRayon = row.idfsRayon;
                        chartRow.strRayonName = row.strRayonName;

                        if (!row.IsdblTotalNull())
                        {
                            chartRow.dblTotal = row.dblTotal;
                            chartRow.dblTotali = row.dblTotal;
                        }
                        if (!row.IsblnTotalVisibleNull())
                        {
                            chartRow.blnTotalVisible = row.blnTotalVisible;
                        }

                        for (int i = 1; i <= MaxDiagnosisCount; i++)
                        {
                            var diagnosisIdColumn = "idfsDiagnosis_" + i;
                            chartRow[diagnosisIdColumn] = row[diagnosisIdColumn];

                            var diagnosisNameColumn = "strDiagnosis_" + i;
                            chartRow[diagnosisNameColumn] = row[diagnosisNameColumn];

                            var valueColumn = "dblValue_" + i;
                            chartRow[valueColumn] = row[valueColumn];
                            chartRow[valueColumn + "i"] = row[valueColumn];
                        }
                    }
                    else
                    {
                        var chartRow = m_DataSet.ChartBarTable.FindByidfsRayon(row.idfsRayon);
                        if (chartRow == null)
                        {
                            throw new ApplicationException("Could not prepare data for chart");
                        }

                        if (!row.IsdblTotalNull())
                        {
                            chartRow.dblTotali = row.dblTotal;
                        }
                        for (int i = 1; i <= MaxDiagnosisCount; i++)
                        {
                            var valueColumn = "dblValue_" + i;
                            chartRow[valueColumn + "i"] = row[valueColumn];
                        }
                    }
                }
            }
            if (m_DataSet.ChartBarTable.Count > 0)
            {
                var row = m_DataSet.ChartBarTable[0];

                bool totalInvisible = hasDiagnosis || row.IsblnTotalVisibleNull() || !row.blnTotalVisible;

                ChartBorderRayons.Series["Total"].Visible = !totalInvisible;
                ChartBorderRayons.Series["Totali"].Visible = !totalInvisible&& additionalCounter.HasValue;

                if (additionalCounter.HasValue)
                {
                    ((LineSeriesView) ChartBorderRayons.Series["Totali"].View).AxisY = diagram.SecondaryAxesY[0];
                }

                ChartBorderRayons.Series["Total"].View.Color = Color.FromArgb(150, ReportChartColors.SeriesColor[0]);
                ChartBorderRayons.Series["Totali"].View.Color = ReportChartColors.SeriesColor[0];
                ChartBorderRayons.Series["Total"].Name = GetSeriesName(HeaderTotal1Cell.Text, counter);
                ChartBorderRayons.Series["Totali"].Name = GetSeriesName(HeaderTotal1Cell.Text, additionalCounter ?? counter);

                for (int i = 1; i <= MaxDiagnosisCount; i++)
                {
                    var diagnosisVisible = !(row["idfsDiagnosis_" + i] is DBNull);
                    var diagnosisNameColumn = "strDiagnosis_" + i;
                    ChartBorderRayons.Series[diagnosisNameColumn].Visible = diagnosisVisible ;
                    ChartBorderRayons.Series[diagnosisNameColumn + "i"].Visible = diagnosisVisible&& additionalCounter.HasValue;

                    ChartBorderRayons.Series[diagnosisNameColumn].View.Color = Color.FromArgb(150, ReportChartColors.SeriesColor[i]);
                    ChartBorderRayons.Series[diagnosisNameColumn + "i"].View.Color = ReportChartColors.SeriesColor[i];
                    if (additionalCounter.HasValue)
                    {
                        ((LineSeriesView) ChartBorderRayons.Series[diagnosisNameColumn + "i"].View).AxisY = diagram.SecondaryAxesY[0];
                    }

                    ChartBorderRayons.Series[diagnosisNameColumn].Name = GetSeriesName(row[diagnosisNameColumn], 1);
                    ChartBorderRayons.Series[diagnosisNameColumn + "i"].Name =
                        GetSeriesName(row[diagnosisNameColumn], additionalCounter ?? counter);
                }

                var maxValues = new List<double> {0};
                foreach (var r in m_DataSet.ChartBarTable)
                {
                    if (r.idfsRayon > 0)
                    {
                        if (totalInvisible)
                        {
                            for (int i = 1; i <= MaxDiagnosisCount; i++)
                            {
                                var valueColumn = "dblValue_" + i;
                                if (r[valueColumn] is double)
                                {
                                    maxValues.Add((double) r[valueColumn]);
                                }
                            }
                        }
                        else
                        {
                            maxValues.Add(r.IsdblTotalNull() ? 0 : r.dblTotal);
                        }
                    }
                }
                ChartHelper.DesignAxisY(ChartBorderRayons.Diagram as XYDiagram, maxValues.Max());
            }
        }
    }
}