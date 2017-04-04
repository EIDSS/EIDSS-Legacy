using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Human.CaseInvestigation
{
    [NullableAdapters]
    public sealed partial class DiagnosisHistoryReport : XtraReport
    {
        public DiagnosisHistoryReport()
        {
            InitializeComponent();
        }

        public void SetParameters(string lang, long caseId, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction) manager.Transaction;
            m_Adapter.CommandTimeout = BaseReport.CommandTimeout;

            m_Adapter.Fill(m_DataSet._DiagnosisHistory, caseId, lang);
        }
    }
}