using System.Collections.Generic;
using System.Data.SqlClient;
using bv.common.Configuration;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.Veterinary.LivestockInvestigation;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Veterinary.AvianInvestigation
{
    public sealed partial class AvianInvestigationReport : BaseDocumentReport
    {
        private readonly FlexVetClinicalContainer m_ClinicalContainer;

        public AvianInvestigationReport()
        {
            InitializeComponent();
            int width = PageWidth - Margins.Left - Margins.Right;
            m_ClinicalContainer = new FlexVetClinicalContainer(DetailInvestigation, width, true);
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            RebindAccessRigths();

            long caseId = (GetLongParameter(parameters, "@ObjID"));
            long diagnosisId = (GetLongParameter(parameters, "@DiagnosisID"));

            VetObservationData observationData = LivestockInvestigationReport.GetVetCaseObservationData(manager, caseId);

            AvianCaseTableAdapter.Connection = (SqlConnection) manager.Connection;
            AvianCaseTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
            AvianCaseTableAdapter.CommandTimeout = CommandTimeout;

            AvianInvestigationDataSet.EnforceConstraints = false;
            AvianCaseTableAdapter.Fill(AvianInvestigationDataSet.spRepVetAvianCase, caseId, lang);

            ClinicalInvestigationSubreport.Visible = false;
            m_ClinicalContainer.SetObservations(observationData.SpeciesObservationIdList, diagnosisId);

            FlexFactory.CreateAvianEpiReport(EpiSubreport, observationData.FarmObservationId, diagnosisId);

            ((FlockReport) xrSubreportFlock.ReportSource).SetParameters(manager, lang, caseId);
            ((VaccinationReport) xrSubreportVaccination.ReportSource).SetParameters(manager, lang, caseId);
            ((RapidTestReport) xrSubreportRapidTest.ReportSource).SetParameters(manager, lang, caseId);
            ((DiagnosisReport) xrSubreportDiagnosis.ReportSource).SetParameters(manager, lang, caseId);
            ((SampleReport) xrSubreportSampleReport.ReportSource).SetParameters(manager, lang, caseId);

            DetailReportMap.Visible = BaseSettings.PrintMapInVetReports;
            if (BaseSettings.PrintMapInVetReports)
            {
                MapPictureBox.Image = PrintMapHelper.GetPrintMap(AvianInvestigationDataSet.spRepVetAvianCase);
            }
        }

        private void RebindAccessRigths()
        {
            if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_Contact_Details))
            {
                xrTableCell25.DataBindings.Clear();
                xrTableCell25.DataBindings.Add(new XRBinding("Text", null, "spRepVetAvianCase.FarmAddressDenyRightsDetailed"));
            }
            if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_Contact_Settlement))
            {
                xrTableCell25.DataBindings.Clear();
                xrTableCell25.DataBindings.Add(new XRBinding("Text", null, "spRepVetAvianCase.FarmAddressDenyRightsSettlement"));
            }
        }
    }
}