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
using EIDSS.Reports.Parameterized.ActiveSurveillance.ActiveSurveillanceDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public partial class AdditionalAFPIndicatorsReport : BaseIntervalReport
    {
        private bool m_IsRegionPrint = true;

        public AdditionalAFPIndicatorsReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, AFPModel model)
        {
            base.SetParameters(manager,(BaseIntervalModel) model);
            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(model.Language, this);
            DateTimeLabel.Text = rebinder.ToDateTimeString(DateTime.Now);
            HeaderPeriodLabel.Text = model.Header;

            Action<SqlConnection> action = (connection =>
                                                {
                                                    m_AFPAdapter.Connection = connection;
                                                    m_AFPAdapter.Transaction = (SqlTransaction)manager.Transaction;
                                                    m_AFPAdapter.CommandTimeout = CommandTimeout;
                                                    m_APFDataSet.EnforceConstraints = false;

                                                    m_AFPAdapter.Fill(m_APFDataSet.spRepHumAdditionalAFPIndicators, model.Language,
                                                                      model.StartDate.ToString("s"), model.EndDate.ToString("s"));
                                                });
            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     m_APFDataSet.spRepHumAdditionalAFPIndicators,
                                     model.UseArchive,
                                     new[] {"strRegion", "strRayon"});
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

        private void PercentCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (!(sender is XRTableCell))
            {
                return;
            }
            var currentCell = ((XRTableCell) sender);

            int nominator;
            int denominator;
            if (int.TryParse(currentCell.Text, out nominator) &&
                int.TryParse(TotalNumberCell.Text, out denominator))
            {
                double result = (denominator == 0)
                                    ? 0
                                    : (100.0 * nominator) / denominator;

                currentCell.Text = result.ToString("0.00");
            }
        }

        private int m_TotalDenominator;

        private void TotalNumberCell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            int.TryParse(e.Text, out m_TotalDenominator);
        }

        private void Cell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            int nominator;
            if (int.TryParse(e.Text, out nominator) && (m_TotalDenominator != 0))
            {
                double result = (100.0 * nominator) / m_TotalDenominator;
                e.Text = result.ToString("0.00");
            }
            else
            {
                e.Text = string.Empty;
            }
        }
    }
}