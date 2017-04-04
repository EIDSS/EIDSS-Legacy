using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    [CanWorkWithArchive]
    public partial class AdditionalAFPIndicatorsReport : BaseIntervalReport
    {
        private bool m_IsRegionPrint = true;

        public AdditionalAFPIndicatorsReport()
        {
            InitializeComponent();
        }

        public void SetParameters(AFPModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters((BaseIntervalModel) model, manager, archiveManager);
            DateTimeLabel.Text = ReportRebinder.ToDateTimeString(DateTime.Now);
            HeaderPeriodLabel.Text = model.Header;

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_AFPAdapter.Connection = connection;
                m_AFPAdapter.Transaction = transaction;
                m_AFPAdapter.CommandTimeout = CommandTimeout;
                m_APFDataSet.EnforceConstraints = false;

                m_AFPAdapter.Fill(m_APFDataSet.spRepHumAdditionalAFPIndicators, model.Language,
                    model.StartDate.ToString("s"), model.EndDate.ToString("s"));
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_APFDataSet.spRepHumAdditionalAFPIndicators,
                model.Mode,
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