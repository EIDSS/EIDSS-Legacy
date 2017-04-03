using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ
{
    public sealed partial class VetCountryProphilacticMeasures : BaseIntervalReport
    {
        public VetCountryProphilacticMeasures()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, SanitaryModel model)
        {
            SetParameters(manager, (BaseIntervalModel) model);

            spRepVetProphilacticMeasuresTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepVetProphilacticMeasuresTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
            spRepVetProphilacticMeasuresTableAdapter1.CommandTimeout = CommandTimeout;
            vetProphMeasuresDataSet1.EnforceConstraints = false;
            string typesXml = FilterHelper.GetXmlFromList(model.CheckedMeasureTypes);

            spRepVetProphilacticMeasuresTableAdapter1.Fill(
                vetProphMeasuresDataSet1.spRepVetProphilacticMeasures_Country,
                model.Language, model.StartDate, model.EndDate, typesXml, null);

            bool visible = vetProphMeasuresDataSet1.spRepVetProphilacticMeasures_Country.Count > 0;
            DetailReport.Visible = visible;
            PageHeader.Visible = visible;

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}