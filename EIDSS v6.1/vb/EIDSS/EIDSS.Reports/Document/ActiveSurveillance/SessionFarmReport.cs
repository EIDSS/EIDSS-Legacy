using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.ActiveSurveillance
{
    [NullableAdapters]
    public sealed partial class SessionFarmReport : XtraReport
    {
        private int m_No;

        public SessionFarmReport()
        {
            InitializeComponent();
        }

        public void SetParameters(string lang, long id, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            m_SessionFarmAdapter.Connection = (SqlConnection) manager.Connection;
            m_SessionFarmAdapter.Transaction = (SqlTransaction) manager.Transaction;
            m_SessionFarmAdapter.CommandTimeout = BaseReport.CommandTimeout;

            m_SessionFarmReportDataSet.EnforceConstraints = false;
            m_SessionFarmAdapter.Fill(m_SessionFarmReportDataSet.SessionFarm, id, lang);
        }

        private void cellFarm_BeforePrint(object sender, PrintEventArgs e)
        {
            m_No = 1;
        }

        private void cellNo_BeforePrint(object sender, PrintEventArgs e)
        {
            cellNo.Text = m_No.ToString();
            m_No++;
        }
    }
}