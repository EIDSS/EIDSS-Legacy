using System.Collections.Generic;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.Veterinary.LivestockInvestigation;
using EIDSS.Reports.Flexible;
using bv.model.BLToolkit;
using eidss.model.Enums;

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

            sp_rep_VET_AvianCaseTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_rep_VET_AvianCaseTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
            sp_rep_VET_AvianCaseTableAdapter1.CommandTimeout = CommandTimeout;

            avianInvestigationDataSet1.EnforceConstraints = false;
            sp_rep_VET_AvianCaseTableAdapter1.Fill(avianInvestigationDataSet1.spRepVetAvianCase, lang, caseId);

            flockReport1.SetParameters(manager, lang, caseId);

            ClinicalInvestigationSubreport.Visible = false;
            m_ClinicalContainer.SetObservations(observationData.SpeciesObservationIdList, diagnosisId);
            FlexFactory.CreateAvianEpiReport(EpiSubreport, observationData.FarmObservationId, diagnosisId);

            vaccinationReport1.SetParameters(manager, lang, caseId);
            rapidTestReport1.SetParameters(manager, lang, caseId);
            diagnosisReport1.SetParameters(manager, lang, caseId);
            sampleReport1.SetParameters(manager, lang, caseId);
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