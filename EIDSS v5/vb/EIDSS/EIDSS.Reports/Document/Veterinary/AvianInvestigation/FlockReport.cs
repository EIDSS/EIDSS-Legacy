using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Veterinary.AvianInvestigation
{
    public sealed partial class FlockReport : XtraReport
    {
        public FlockReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long caseId)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            sp_Rep_Vet_HerdDetailsTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_Rep_Vet_HerdDetailsTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
            sp_Rep_Vet_HerdDetailsTableAdapter.CommandTimeout = BaseReport.CommandTimeout;
            herdDataSet1.EnforceConstraints = false;

            sp_Rep_Vet_HerdDetailsTableAdapter.Fill(herdDataSet1.spRepVetHerdDetails, caseId, lang);
        }
    }
}