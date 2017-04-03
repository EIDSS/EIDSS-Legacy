using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Configuration;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public partial class MainAFPIndicatorsReport : BaseIntervalReport
    {
        private bool m_IsRegionPrint = true;
        private int? m_ChildrenRegistered;
        private int? m_TotalRegistered;
        private double? m_NonPolo;

        public MainAFPIndicatorsReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, AFPModel model)
        {
            base.SetParameters(manager, (BaseIntervalModel) model);
            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeLabel.Text = rebinder.ToDateTimeString(DateTime.Now);
            HeaderPeriodLabel.Text = model.Header;

            Action<SqlConnection> action = (connection =>
            {
                m_AFPAdapter.Connection = connection;
                m_AFPAdapter.Transaction = (SqlTransaction) manager.Transaction;
                m_AFPAdapter.CommandTimeout = CommandTimeout;

                m_APFDataSet.EnforceConstraints = false;

                m_AFPAdapter.Fill(m_APFDataSet.spRepHumMainAFPIndicators, model.Language,
                    model.StartDate, model.EndDate);
            });

            string[] ignoreNames = (model.Mode == ReportArchiveMode.ActualWithArchive)
                ? new[] {"intChildren"}
                : new[] {"intChildren", "intRegisteredAFP", "intRegisteredAFPWithSamples"};
            var archiveCredentials = new ConnectionCredentials(null, "Archive");

            ReportArchiveMode mode = archiveCredentials.IsCorrect && model.Mode == ReportArchiveMode.ActualOnly
                ? ReportArchiveMode.ActualWithArchive
                : model.Mode;
            var functionDictionary = new Dictionary<string, Func<double, double, double>>
            {
                {"intLastParalisysOnsetYear", Math.Max}
            };
            FillDataTableWithArchive(action,
                (SqlConnection) manager.Connection,
                m_APFDataSet.spRepHumMainAFPIndicators,
                mode,
                new[] {"strRegion", "strRayon"}, ignoreNames, functionDictionary);

            foreach (MainAFPIndicatorsDataSet.spRepHumMainAFPIndicatorsRow row in m_APFDataSet.spRepHumMainAFPIndicators)
            {
                if (!row.IsintChildrenNull() && row.intChildren > 0)
                {
                    double frequency = row.intChildren / 100000.0;
                    if (frequency > 1)
                    {
                        row.intExpectedCase = (int) Math.Round(frequency);
                    }
                    else if (!row.IsintLastParalisysOnsetYearNull())
                    {
                        int pastYears = model.Year - row.intLastParalisysOnsetYear;
                        var result = (int) Math.Round(pastYears * frequency);
                        row.intExpectedCase = result < 1
                            ? 0
                            : 1;
                    }
                }
            }
        }

        private void RegionGroupCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!m_IsRegionPrint)
            {
                RegionDetailCell.Text = string.Empty;
                RegionDetailCell.Borders = BorderSide.Left | BorderSide.Right;
            }
            else
            {
                RegionDetailCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
            }
            m_IsRegionPrint = false;
        }

        private void SubtotalCell_BeforePrint(object sender, PrintEventArgs e)
        {
            m_IsRegionPrint = true;
        }

        private void NonPolioAFPCell_BeforePrint(object sender, PrintEventArgs e)
        {
            int nominator;
            int denominator;
            if (int.TryParse(RegisteredAFPCell.Text, out nominator) &&
                int.TryParse(Under15Cell.Text, out denominator) &&
                denominator != 0)
            {
                double result = (100000.0 * nominator) / denominator;
                NonPolioAFPCell.Text = result.ToString("0.00");
            }
            else
            {
                NonPolioAFPCell.Text = string.Empty;
            }
        }

        private void IndexAFPCell_BeforePrint(object sender, PrintEventArgs e)
        {
            double nonPolo;
            double registeredWithSamples;
            int childrenRegistered;
            if (double.TryParse(IndexAFPCell.Text, out registeredWithSamples) &&
                double.TryParse(NonPolioAFPCell.Text, out nonPolo) &&
                int.TryParse(Under15Cell.Text, out childrenRegistered))
            {
                double max = Math.Max(childrenRegistered, nonPolo);
                double result = 100.0 * max * registeredWithSamples;
                IndexAFPCell.Text = result.ToString("0.00");
            }
            else
            {
                IndexAFPCell.Text = string.Empty;
            }
        }

        private void Under15Cell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            int tmp;
            m_ChildrenRegistered = int.TryParse(e.Text, out tmp)
                ? (int?) tmp
                : null;
        }

        private void RegisteredAFPCell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            int tmp;
            m_TotalRegistered = int.TryParse(e.Text, out tmp)
                ? (int?) tmp
                : null;
        }

        private void NonPolioAFPCell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (m_TotalRegistered.HasValue &&
                m_ChildrenRegistered.HasValue &&
                m_ChildrenRegistered.Value != 0)
            {
                m_NonPolo = (100000.0 * m_TotalRegistered.Value) / m_ChildrenRegistered.Value;
                e.Text = m_NonPolo.Value.ToString("0.00");
            }
            else
            {
                e.Text = string.Empty;
                m_NonPolo = null;
            }
        }

        private void IndexAFPCell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            double registeredWithSamples;
            if (double.TryParse(e.Text, out registeredWithSamples) &&
                m_NonPolo.HasValue &&
                m_TotalRegistered.HasValue &&
                m_ChildrenRegistered.HasValue)
            {
                double max = Math.Max(m_ChildrenRegistered.Value, m_NonPolo.Value);
                double result = (max * registeredWithSamples) / m_TotalRegistered.Value;
                e.Text = result.ToString("0.00");
            }
            else
            {
                e.Text = string.Empty;
            }
        }

        private void ExpectedCase_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Text == "0")
            {
                e.Text = string.Empty;
            }
        }
    }
}