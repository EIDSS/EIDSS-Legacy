using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public sealed partial class HerdReport : XtraReport
    {
        public HerdReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, string lang, long caseId)
        {
            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            m_Adapter.Connection = (SqlConnection) manager.Connection;
            m_Adapter.Transaction = (SqlTransaction)manager.Transaction;
            m_Adapter.CommandTimeout = BaseReport.CommandTimeout;
            m_DataSet.EnforceConstraints = false;

            m_Adapter.Fill(m_DataSet.spRepVetHerdDetails, caseId, lang);

            var defaultView = m_DataSet.spRepVetHerdDetails.DefaultView;
            defaultView.RowFilter = "SpeciesID is not null";
            defaultView.Sort = "idfHerd, idfSpecies";
        }
    }
}