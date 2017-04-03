using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ
{
    public sealed partial class VetRegionPlannedDiagnostic : BaseIntervalReport
    {
        public VetRegionPlannedDiagnostic()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, DiagnosticInvestigationModel model)
        {
            SetParameters(manager, (BaseIntervalModel) model);

            spRepVetPlannedDiagnosticTestsTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepVetPlannedDiagnosticTestsTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
            spRepVetPlannedDiagnosticTestsTableAdapter1.CommandTimeout = CommandTimeout;

            vetPlannedDiagnosticTestsDataSet1.EnforceConstraints = false;

            string diagnosisXml = FilterHelper.GetXmlFromList(model.CheckedDiagnosis);
            string speciesXml = FilterHelper.GetXmlFromList(model.CheckedSpecies);
            string typesXml = FilterHelper.GetXmlFromList(model.CheckedInvestigationTypes);

            spRepVetPlannedDiagnosticTestsTableAdapter1.Fill(
                vetPlannedDiagnosticTestsDataSet1.spRepVetPlannedDiagnosticTests,
                model.Language, model.StartDate, model.EndDate, diagnosisXml, speciesXml, typesXml, model.RegionFilter.RegionId);

            bool visible = vetPlannedDiagnosticTestsDataSet1.spRepVetPlannedDiagnosticTests.Count > 0;
            DetailReport.Visible = visible;
            PageHeader.Visible = visible;

            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}