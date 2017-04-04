using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using eidss.model.Reports.Common;
using eidss.model.Reports.TH;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.TH.DataSets;

namespace EIDSS.Reports.Parameterized.Human.TH.Reports
{
    public sealed partial class ComparativeSeveralYearsTHReport : BaseReport
    {
        private int m_Counter = 1;

        public ComparativeSeveralYearsTHReport()
        {
            InitializeComponent();
        }

        public void SetParameters(ComparativeSeveralYearsTHSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            SetLanguage(model, manager);

            m_Counter = model.Counter;

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.YearFrom, 1, 1), model.UseArchive);

            BindHeader(model);

            if (model.Counter == 1)
            {
                foreach (var cell in GetCounterCells())
                {
                    if (cell.DataBindings.Count > 0)
                    {
                        cell.DataBindings[0].FormatString = "{0:0.00000}";
                    }
                }
            }

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_DataAdapter.Connection = connection;
                m_DataAdapter.Transaction = transaction;
                m_DataAdapter.CommandTimeout = CommandTimeout;
                m_DataSet.EnforceConstraints = false;

                m_DataAdapter.Fill(m_DataSet.ComparativeTable,
                    model.Language,
                    model.YearFrom, model.YearTo,
                    model.Counter,
                    model.RegionId, model.RayonId,
                    model.Diagnoses.ToXml(),
                    model.SiteId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_DataSet.ComparativeTable,
                model.Mode,
                new[] {"idfsYear"});

            FillThaiYearsInDataSource();

            m_DataSet.ComparativeTable.DefaultView.Sort = "idfsYear";

            FillChartData();
        }

        private void BindHeader(ComparativeSeveralYearsTHSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");

            string years = string.Format("{0} - {1}", model.YearFrom + DeltaYear, model.YearTo + DeltaYear);
            string location = AddressModel.GetLocation(model.Language,
                CountryLabel.Text,
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName, true);

            HeaderLabelCell1.Text = string.Format(HeaderLabelCell1.Text, years, location);
            HeaderLabelCell2.Text = string.Format(HeaderLabelCell2.Text, model.Diagnoses);
            HeaderLabelRow2.Visible = model.Diagnoses.CheckedItems.Length > 0;
        }

        private void FillThaiYearsInDataSource()
        {
            if (ModelUserContext.CurrentLanguage == Localizer.lngThai)
            {
                m_DataSet.ComparativeTable.BeginLoadData();
                foreach (ComparativeSeveralYearsTHDataSet.ComparativeTableRow row in m_DataSet.ComparativeTable)
                {
                    row.idfsYear += DeltaYear;
                }
                m_DataSet.ComparativeTable.EndLoadData();
            }
        }

        private void FillChartData()
        {
            if (m_DataSet.ComparativeTable.Rows.Count >= 2)
            {
                ((ISupportInitialize) (Chart)).BeginInit();
                ((ISupportInitialize) (Chart.Diagram)).BeginInit();

                foreach (KeyValuePair<int, string> month in GetMonthNames())
                {
                    ComparativeSeveralYearsChartTHDataSet.ChartDataRow row = m_ChartDataSet.ChartData.NewChartDataRow();
                    row.Order = month.Key;
                    row.Month = month.Value;
                    m_ChartDataSet.ChartData.AddChartDataRow(row);
                }

                var valueSeriesList = new List<Series>();
                var percentSeriesList = new List<Series>();
                ComparativeSeveralYearsChartTHDataSet.ChartDataDataTable data = m_ChartDataSet.ChartData;
                var maxValues = new List<double>();
                for (int yearCount = 0; yearCount < m_DataSet.ComparativeTable.Count; yearCount++)
                {
                    ComparativeSeveralYearsTHDataSet.ComparativeTableRow yearRow = m_DataSet.ComparativeTable[yearCount];
                    string yearColumnName = string.Format("Year{0}Value", yearCount + 1);
                    string yearPercentColumnName = string.Format("Year{0}PercentValue", yearCount + 1);
                    // Note: if exception throws, you need to add extra column to ComparativeSeveralYearsChartDataSet.ChartDataDataTable
                    CheckColumnExists(data, yearColumnName);
                    CheckColumnExists(data, yearPercentColumnName);
                    IList<int> monthValues = ComparativeSeveralYearsChartHelper.GetMonthValues(yearRow);
                    maxValues.Add(monthValues.Max());
                    IList<double?> monthPercent = ComparativeSeveralYearsChartHelper.GetMonthPercent(yearRow);
                    for (int monthCount = 0; monthCount < data.Count; monthCount++)
                    {
                        data[monthCount][yearColumnName] = monthValues[monthCount];
                        data[monthCount][yearPercentColumnName] = monthPercent[monthCount] ?? (object) DBNull.Value;
                    }

                    Color color = ReportChartColors.SeriesColor[yearCount % ReportChartColors.SeriesColor.Length];
                    Series series = ComparativeSeveralYearsChartHelper.CreateValueSeriesForYear(yearColumnName, color);
                    series.Name = string.Format(AbsoluteNumberLabel.Text, yearRow.idfsYear);
                    valueSeriesList.Add(series);

                    series = ComparativeSeveralYearsChartHelper.CreatePercentSeriesForYear(yearPercentColumnName, color);
                    series.Name = string.Format(PercentageLabel.Text, yearRow.idfsYear);

                    percentSeriesList.Add(series);
                }
                ChartHelper.DesignAxisY(Chart.Diagram as XYDiagram, maxValues.Max());
                valueSeriesList.AddRange(percentSeriesList);
                Chart.SeriesSerializable = valueSeriesList.ToArray();

                ((ISupportInitialize) (Chart.Diagram)).EndInit();
                ((ISupportInitialize) (Chart)).EndInit();
            }
        }

        private static void CheckColumnExists(ComparativeSeveralYearsChartTHDataSet.ChartDataDataTable data, string columnName)
        {
            if (!data.Columns.Contains(columnName))
            {
                throw new ArgumentOutOfRangeException(string.Format("Column {0} doesn't exist.", columnName));
            }
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

        private List<XRTableCell> GetCounterCells()
        {
            return new List<XRTableCell>
            {
                JanuaryPercentCell,
                FebruaryPercentCell,
                MarchPercentCell,
                AprilPercentCell,
                MayPercentCell,
                JunePercentCell,
                JulyPercentCell,
                AugustPercentCell,
                SeptemberPercentCell,
                OctoberPercentCell,
                NovemberPercentCell,
                DecemberPercentCell
            };
        }

        private void CounterHeader_BeforePrint(object sender, PrintEventArgs e)
        {
            var label = (sender as XRLabel);
            if (label != null && m_Counter == 1)
            {
                label.Text = RatePerLabel.Text;
            }
        }
    }
}