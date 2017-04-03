using System.Data.SqlClient;
using bv.common.db;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Human.CaseInvestigation
{
    public sealed partial class SpecimenReport : XtraReport
    {
        public SpecimenReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long caseId)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            sp_rep_HUM_CaseForm_SpecimensTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_rep_HUM_CaseForm_SpecimensTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
            sp_rep_HUM_CaseForm_SpecimensTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

            sp_rep_HUM_CaseForm_SpecimensTableAdapter.Fill(specimenDataSet1.spRepHumCaseFormSpecimens, lang, caseId);


            specimenDataSet1.spRepHumCaseFormSpecimens.Columns["DateTimeCpecimenReceivedLab"].ReadOnly = false;
            TimeUtils.UTC2Local(specimenDataSet1.spRepHumCaseFormSpecimens, "DateTimeCpecimenReceivedLab");
        }
    }
}