using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public sealed partial class VaccinationReport : XtraReport
    {
        public VaccinationReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long caseId)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            vaccinationDataSet1.EnforceConstraints = false;

            sp_rep_VET_AvianCase_VaccinationTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_rep_VET_AvianCase_VaccinationTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
            sp_rep_VET_AvianCase_VaccinationTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

            sp_rep_VET_AvianCase_VaccinationTableAdapter.Fill(vaccinationDataSet1.spRepVetVaccination, lang, caseId);
        }
    }
}