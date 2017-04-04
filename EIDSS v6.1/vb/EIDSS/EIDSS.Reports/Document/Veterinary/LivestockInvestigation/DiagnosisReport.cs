using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public sealed partial class DiagnosisReport : XtraReport
    {
        public DiagnosisReport()
        {
            InitializeComponent();
        }

        public void SetParameters(string lang, long caseId, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            diagnosisDataSet1.EnforceConstraints = false;

            spRepVetDiagnosisTableAdapter.Connection = (SqlConnection) manager.Connection;
            spRepVetDiagnosisTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
            spRepVetDiagnosisTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

            spRepVetDiagnosisTableAdapter.Fill(diagnosisDataSet1.spRepVetDiagnosis, caseId, lang);
        }
    }
}