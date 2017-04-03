using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ
{
    public sealed partial class VetCountryPlannedDiagnostic : BaseIntervalReport
    {
        public VetCountryPlannedDiagnostic()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, DiagnosticInvestigationModel model)
        {
            SetParameters(manager, (BaseIntervalModel) model);

            spRepVetPlannedDiagnosticCountryTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepVetPlannedDiagnosticCountryTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
            spRepVetPlannedDiagnosticCountryTableAdapter1.CommandTimeout = CommandTimeout;
                                               
            vetPlannedDiagnosticTestsDataSet1.EnforceConstraints = false;

            string diagnosisXml = FilterHelper.GetXmlFromList(model.CheckedDiagnosis);
            string speciesXml = FilterHelper.GetXmlFromList(model.CheckedSpecies);
            string typesXml = FilterHelper.GetXmlFromList(model.CheckedInvestigationTypes);

            spRepVetPlannedDiagnosticCountryTableAdapter1.Fill(
                vetPlannedDiagnosticTestsDataSet1.spRepVetPlannedDiagnosticTests_Country,
                model.Language, model.StartDate, model.EndDate, diagnosisXml, typesXml, speciesXml, null);

            bool visible = vetPlannedDiagnosticTestsDataSet1.spRepVetPlannedDiagnosticTests_Country.Count > 0;
            DetailReport.Visible = visible;
            PageHeader.Visible = visible;

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}