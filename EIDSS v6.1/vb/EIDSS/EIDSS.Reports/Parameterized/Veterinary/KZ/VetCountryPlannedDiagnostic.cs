using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ
{
    [NullableAdapters]
    public sealed partial class VetCountryPlannedDiagnostic : BaseIntervalReport
    {
        public VetCountryPlannedDiagnostic()
        {
            InitializeComponent();
        }

        public void SetParameters(DiagnosticInvestigationModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters( model, manager, archiveManager);

            spRepVetPlannedDiagnosticCountryTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepVetPlannedDiagnosticCountryTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
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
        }
    }
}