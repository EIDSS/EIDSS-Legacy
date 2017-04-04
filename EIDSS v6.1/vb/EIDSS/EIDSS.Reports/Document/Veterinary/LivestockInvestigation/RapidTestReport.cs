using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public sealed partial class RapidTestReport : XtraReport
    {
        public RapidTestReport()
        {
            InitializeComponent();
        }

        public void SetParameters(string lang, long caseId, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            rapidTestDataSet1.EnforceConstraints = false;

            sp_Rep_VET_PensideTestsListTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_Rep_VET_PensideTestsListTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
            sp_Rep_VET_PensideTestsListTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

            sp_Rep_VET_PensideTestsListTableAdapter.Fill(rapidTestDataSet1.spRepVetPensideTestsList, caseId, lang);
        }
    }
}