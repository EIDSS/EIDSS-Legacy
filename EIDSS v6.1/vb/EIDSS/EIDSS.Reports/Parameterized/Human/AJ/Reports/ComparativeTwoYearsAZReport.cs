using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class ComparativeTwoYearsAZReport : BaseReport
    {
        private int m_RowNumber;

        public ComparativeTwoYearsAZReport()
        {
            InitializeComponent();
        }

        public void SetParameters(ComparativeTwoYearsSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            SetLanguage(model, manager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, 1, 1), model.UseArchive);

            BindHeader(model);

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_DataAdapter.Connection = connection;
                m_DataAdapter.Transaction = transaction;
                m_DataAdapter.CommandTimeout = CommandTimeout;
                m_DataSet.EnforceConstraints = false;

                m_DataAdapter.Fill(m_DataSet.ComparativeTwoYears,
                    model.Language,
                    model.Year1, model.Year2,
                    FilterHelper.GetXmlFromList(model.Counters),
                    model.DiagnosisId,
                    model.RegionId, model.RayonId,
                    model.SiteId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_DataSet.ComparativeTwoYears,
                model.Mode,
                new[] {"strKey"}, new[] {"intYear", "intCounter"});
            m_DataSet.ComparativeTwoYears.DefaultView.Sort = "intYear desc, intCounter";

            var singleCounter = model.Counters == null || model.Counters.Length < 2;
            if (singleCounter)
            {
                HeaderTable.BeginInit();
                DetailsTable.BeginInit();
                HeaderRow.DeleteCell(CounterHeaderCell);
                DetailsRow.DeleteCell(CounterCell);
                HeaderTable.EndInit();
                DetailsTable.EndInit();
            }

            m_RowNumber = 0;

            RoundData();

            FillChartData(singleCounter);
        }

        private void BindHeader(ComparativeTwoYearsSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");

            string years = string.Format("{1} - {0}", model.Year1, model.Year2);
            string location = AddressModel.GetLocation(model.Language,
                EidssMessages.Get("strReportRepublic"),
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName, true);

            HeaderLabelCell1.Text = model.DiagnosisId.HasValue
                ? string.Format(HeaderLabelCell1.Text, model.DiagnosisName)
                : HeaderLabel.Text;

            HeaderLabelCell2.Text = string.Format(HeaderLabelCell2.Text, years, location);
        }

        private void YearCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            if (cell != null && m_RowNumber >= 0 && m_RowNumber < m_DataSet.ComparativeTwoYears.Count)
            {
                var row = m_DataSet.ComparativeTwoYears[m_RowNumber];

                if (m_RowNumber != 0 &&
                    (m_DataSet.ComparativeTwoYears[m_RowNumber - 1].intYear == row.intYear))
                {
                    cell.Text = string.Empty;
                }
                cell.Borders = BorderSide.Left | BorderSide.Right;
                if (m_RowNumber == m_DataSet.ComparativeTwoYears.Count - 1 ||
                    (m_DataSet.ComparativeTwoYears[m_RowNumber + 1].intYear != row.intYear))
                {
                    cell.Borders |= BorderSide.Bottom;
                }
                m_RowNumber++;
            }
        }

        private void MonthCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (m_RowNumber > 0 && m_RowNumber <= m_DataSet.ComparativeTwoYears.Count)
            {
                var row = m_DataSet.ComparativeTwoYears[m_RowNumber - 1];
                var cell = sender as XRTableCell;
                if (row.intCounter == 1 && cell != null && cell.Text.Length > 3)
                {
                    cell.Text = cell.Text.Substring(0, cell.Text.Length - 3);
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

        private void FillChartData(bool isCounterSingle)
        {
            var diagram = (Chart.Diagram as XYDiagram);
            if (diagram != null && diagram.SecondaryAxesY.Count > 0)
            {
                diagram.SecondaryAxesY[0].Visibility = isCounterSingle
                    ? DefaultBoolean.False
                    : DefaultBoolean.True;
            }
            if (m_DataSet.ComparativeTwoYears.Rows.Count >= 2)
            {
                ((ISupportInitialize) (Chart)).BeginInit();
                ((ISupportInitialize) (Chart.Diagram)).BeginInit();

                foreach (KeyValuePair<int, string> month in GetMonthNames())
                {
                    ComparativeTwoYearsChartDataSet.ChartDataRow row = m_ChartDataSet.ChartData.NewChartDataRow();
                    row.Order = month.Key;
                    row.Month = month.Value;
                    m_ChartDataSet.ChartData.AddChartDataRow(row);
                }

                var seriesList = new List<Series>();
                ComparativeTwoYearsChartDataSet.ChartDataDataTable data = m_ChartDataSet.ChartData;
                var maxValues = new List<double>();
                int year = -1;
                int yearCounter = 0;
                for (int index = 0; index < m_DataSet.ComparativeTwoYears.Count; index++)
                {
                    ComparativeTroYearsDataSet.ComparativeTwoYearsRow yearRow = m_DataSet.ComparativeTwoYears[index];
                    string valueColumnName = string.Format("Year{0}Value", index + 1);
                    if (!data.Columns.Contains(valueColumnName))
                    {
                        // Note: if exception throws, you need to add extra column to ComparativeTwoYearsChartDataSet.ChartDataDataTable
                        throw new ArgumentOutOfRangeException(string.Format("Column {0} doesn't exist.", valueColumnName));
                    }
                    IList<double> monthValues = ComparativeTwoYearsChartHelper.GetMonthValues(yearRow);

                    for (int monthCount = 0; monthCount < data.Count; monthCount++)
                    {
                        var showValues = yearRow.intYear < DateTime.Now.Year ||
                                         monthCount < DateTime.Now.Month ||
                                         monthValues[monthCount] > 0;
                        data[monthCount][valueColumnName] = showValues
                            ? (object) monthValues[monthCount]
                            : DBNull.Value;
                    }
                    bool firstSeriesOfYear = yearRow.intYear != year;
                    if (firstSeriesOfYear)
                    {
                    maxValues.Add(monthValues.Max());
                        year = yearRow.intYear;
                        yearCounter++;
                    }
                    Color color = ReportChartColors.SeriesColor[yearCounter % ReportChartColors.SeriesColor.Length];
                    string seriesName = string.Format("{0} - {1}", yearRow.intYear, GetCounterName(yearRow.intCounter));
                    Series series;
                    if (isCounterSingle)
                    {
                        series = ComparativeTwoYearsChartHelper.CreateLineSeriesForYear(seriesName, valueColumnName, color);
                    }
                    else
                    {
                        series = firstSeriesOfYear
                            ? ComparativeTwoYearsChartHelper.CreateBarSeriesForYear(seriesName, valueColumnName, color)
                            : ComparativeTwoYearsChartHelper.CreateLineSeriesForYear(seriesName, valueColumnName, color, false);
                    }

                    seriesList.Add(series);
                }

                ChartHelper.DesignAxisY(Chart.Diagram as XYDiagram, maxValues.Max());

                Chart.SeriesSerializable = seriesList.ToArray();

                ((ISupportInitialize) (Chart.Diagram)).EndInit();
                ((ISupportInitialize) (Chart)).EndInit();
            }
        }

        private static string GetCounterName(int counter)
        {
            return EidssMessages.Instance.GetString("cbCounter" + (counter - 1));
        }

        private Dictionary<int, string> GetMonthNames()
        {
            return new Dictionary<int, string>
            {
                {0, JanuaryHeaderCell.Text},
                {1, FebruaryHeaderCell.Text},
                {2, MarchHeaderCell.Text},
                {3, AprilHeaderCell.Text},
                {4, MayHeaderCell.Text},
                {5, JuneHeaderCell.Text},
                {6, JulyHeaderCell.Text},
                {7, AugustHeaderCell.Text},
                {8, SeptemberHeaderCell.Text},
                {9, OctoberHeaderCell.Text},
                {10, NovemberHeaderCell.Text},
                {11, DecemberHeaderCell.Text}
            };
        }

        private void RoundData()
        {
            foreach (ComparativeTroYearsDataSet.ComparativeTwoYearsRow row in m_DataSet.ComparativeTwoYears.Rows)
            {
                int digits = row.intCounter == 1 ? 0 : 2;

                row.intJanuary = Math.Round(row.intJanuary, digits);
                row.intFebruary = Math.Round(row.intFebruary, digits);
                row.intMarch = Math.Round(row.intMarch, digits);
                row.intApril = Math.Round(row.intApril, digits);
                row.intMay = Math.Round(row.intMay, digits);
                row.intJune = Math.Round(row.intJune, digits);
                row.intJuly = Math.Round(row.intJuly, digits);
                row.intAugust = Math.Round(row.intAugust, digits);
                row.intSeptember = Math.Round(row.intSeptember, digits);
                row.intOctober = Math.Round(row.intOctober, digits);
                row.intNovember = Math.Round(row.intNovember, digits);
                row.intDecember = Math.Round(row.intDecember, digits);
                row.intTotal = Math.Round(row.intTotal, digits);
            }
        }
    }
}