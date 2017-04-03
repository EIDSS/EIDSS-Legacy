using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Veterinary.AvianInvestigation
{
    public sealed partial class SampleReport : XtraReport
    {
        public SampleReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long cmId)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            sampleDataSet1.EnforceConstraints = false;

            sp_rep_VET_SamplesCollectionAvianTableAdapter.Connection = (SqlConnection) manager.Connection;
            sp_rep_VET_SamplesCollectionAvianTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
            sp_rep_VET_SamplesCollectionAvianTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

            sp_rep_VET_SamplesCollectionAvianTableAdapter.Fill(sampleDataSet1.spRepVetSamplesCollectionAvian, cmId, lang);
        }
    }
}