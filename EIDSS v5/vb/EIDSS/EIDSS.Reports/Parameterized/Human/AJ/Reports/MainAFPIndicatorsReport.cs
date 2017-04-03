using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
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
            base.SetParameters(manager, (BaseIntervalModel)model);
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
                                                                      model.StartDate.ToString("s"), model.EndDate.ToString("s"));
                                                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     m_APFDataSet.spRepHumMainAFPIndicators,
                                     model.UseArchive,
                                     new[] {"strRegion", "strRayon","intChildren"});
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

        private void Cell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            double value;
            if (double.TryParse(e.Text, out value))
            {
                e.Text = value.ToString("0.00");
            }
            else
            {
                e.Text = string.Empty;
            }
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
            if (double.TryParse(IndexAFPCell.Text, out registeredWithSamples) &&
                double.TryParse(NonPolioAFPCell.Text, out nonPolo))
            {
                double result = 100.0 * nonPolo * registeredWithSamples;
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
            if (m_TotalRegistered.HasValue && m_ChildrenRegistered.HasValue && m_ChildrenRegistered.Value != 0)
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
            if (double.TryParse(e.Text, out registeredWithSamples) && m_NonPolo.HasValue && m_TotalRegistered.HasValue)
            {
                double result = (m_NonPolo.Value * registeredWithSamples) / m_TotalRegistered.Value;
                e.Text = result.ToString("0.00");
            }
            else
            {
                e.Text = string.Empty;
            }
        }
    }
}