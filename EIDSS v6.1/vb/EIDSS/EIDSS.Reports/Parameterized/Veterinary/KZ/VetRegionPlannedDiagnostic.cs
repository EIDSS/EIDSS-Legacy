using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ
{
    [NullableAdapters]
    public sealed partial class VetRegionPlannedDiagnostic : BaseIntervalReport
    {
        public VetRegionPlannedDiagnostic()
        {
            InitializeComponent();
        }

        public void SetParameters( DiagnosticInvestigationModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(model, manager, archiveManager);

            spRepVetPlannedDiagnosticTestsTableAdapter1.Connection = (SqlConnection) manager.Connection;
            spRepVetPlannedDiagnosticTestsTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
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
        }
    }
}