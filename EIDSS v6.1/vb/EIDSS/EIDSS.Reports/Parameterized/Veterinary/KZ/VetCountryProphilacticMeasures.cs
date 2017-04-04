using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ
{
    [NullableAdapters]
    public sealed partial class VetCountryProphilacticMeasures : BaseIntervalReport
    {
        public VetCountryProphilacticMeasures()
        {
            InitializeComponent();
        }

        public void SetParameters( SanitaryModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {

            base.SetParameters(model, manager, archiveManager);

            spRepVetProphilacticMeasuresTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepVetProphilacticMeasuresTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            spRepVetProphilacticMeasuresTableAdapter1.CommandTimeout = CommandTimeout;
            vetProphMeasuresDataSet1.EnforceConstraints = false;
            string typesXml = FilterHelper.GetXmlFromList(model.CheckedMeasureTypes);

            spRepVetProphilacticMeasuresTableAdapter1.Fill(
                vetProphMeasuresDataSet1.spRepVetProphilacticMeasures_Country,
                model.Language, model.StartDate, model.EndDate, typesXml, null);

            bool visible = vetProphMeasuresDataSet1.spRepVetProphilacticMeasures_Country.Count > 0;
            DetailReport.Visible = visible;
            PageHeader.Visible = visible;
        }
    }
}