using System.Collections.Generic;
using System.Data.SqlClient;
using bv.common.Configuration;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.Veterinary.LivestockInvestigation;
using EIDSS.Reports.Factory;
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

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            RebindAccessRigths();

            long caseId = (GetLongParameter(parameters, "@ObjID"));
            long diagnosisId = (GetLongParameter(parameters, "@DiagnosisID"));
            long includeMapInt;
            bool includeMap = TryGetLongParameter(parameters, "@IncludeMap", out includeMapInt) && includeMapInt ==1;
            

            VetObservationData observationData = LivestockInvestigationReport.GetVetCaseObservationData(manager, caseId);

            AvianCaseTableAdapter.Connection = (SqlConnection) manager.Connection;
            AvianCaseTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
            AvianCaseTableAdapter.CommandTimeout = CommandTimeout;

            AvianInvestigationDataSet.EnforceConstraints = false;
            AvianCaseTableAdapter.Fill(AvianInvestigationDataSet.spRepVetAvianCase, caseId, lang);
            FillBarcode();

            ClinicalInvestigationSubreport.Visible = false;
            m_ClinicalContainer.SetObservations(observationData.SpeciesObservationIdList, diagnosisId);

            FlexFactory.CreateAvianEpiReport(EpiSubreport, observationData.FarmObservationId, diagnosisId);

            ((FlockReport) xrSubreportFlock.ReportSource).SetParameters(lang, caseId, manager, archiveManager);
            ((VaccinationReport)xrSubreportVaccination.ReportSource).SetParameters( lang, caseId, manager, archiveManager);
            ((RapidTestReport)xrSubreportRapidTest.ReportSource).SetParameters( lang, caseId, manager, archiveManager);
            ((DiagnosisReport)xrSubreportDiagnosis.ReportSource).SetParameters( lang, caseId, manager, archiveManager);
            ((SampleReport) xrSubreportSampleReport.ReportSource).SetParameters(lang, caseId, manager, archiveManager);

            DetailReportMap.Visible = BaseSettings.PrintMapInVetReports;
            if (includeMap)
            {
                MapPictureBox.Image = PrintMapHelper.GetPrintMap(AvianInvestigationDataSet.spRepVetAvianCase);
            }

            ReportRtlHelper.SetRTL(this);
            ReportRebinder.RebindDateAndFontForReport();
        }

        private void FillBarcode()
        {
            if (AvianInvestigationDataSet.spRepVetAvianCase.Count > 0)
            {
                var row = AvianInvestigationDataSet.spRepVetAvianCase[0];

                cellBarcode.Text = row.IsCaseIdentifierNull()
                    ? string.Empty
                    : m_BarCode.Code128(row.CaseIdentifier);
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