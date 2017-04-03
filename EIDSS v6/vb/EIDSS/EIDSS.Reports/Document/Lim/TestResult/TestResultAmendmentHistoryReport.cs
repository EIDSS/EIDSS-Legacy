using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Lim.TestResult
{
    public partial class TestResultAmendmentHistoryReport : XtraReport
    {
        public TestResultAmendmentHistoryReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long id)
        {
            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = BaseReport.CommandTimeout;
            m_DataSet.EnforceConstraints = false;
            m_Adapter.Fill(m_DataSet.TestResultsAmendmentHistory, lang, id);

            DataAdapter = null;
        }
    }
}