using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Lim.TestResult
{
    [NullableAdapters]
    public partial class TestResultAmendmentHistoryReport : XtraReport
    {
        public TestResultAmendmentHistoryReport()
        {
            InitializeComponent();
        }

        public void SetParameters(string lang, long id, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = BaseReport.CommandTimeout;
            m_DataSet.EnforceConstraints = false;
            m_Adapter.Fill(m_DataSet.TestResultsAmendmentHistory, lang, id);
        }
    }
}