using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Human.CaseInvestigation
{
    public sealed partial class TherapyReport : XtraReport
    {
        public TherapyReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long caseId)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            sp_rep_HUM_TherapyTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_rep_HUM_TherapyTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
            sp_rep_HUM_TherapyTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

            sp_rep_HUM_TherapyTableAdapter.Fill(therapyDataSet1.spRepHumTherapy, lang, caseId);
        }
    }
}