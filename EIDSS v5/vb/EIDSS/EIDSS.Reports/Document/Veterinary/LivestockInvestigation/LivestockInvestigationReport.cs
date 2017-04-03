using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using DevExpress.XtraReports.UI;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Flexible;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public sealed partial class LivestockInvestigationReport : BaseDocumentReport
    {
        private readonly FlexVetClinicalContainer m_ClinicalContainer;

        public LivestockInvestigationReport()
        {
            InitializeComponent();
            int width = PageWidth - Margins.Left - Margins.Right;
            m_ClinicalContainer = new FlexVetClinicalContainer(DetailClinical, width, false);
        }

        public override void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            base.SetParameters(manager, lang, parameters);

            RebindAccessRigths();

            long caseId = (GetLongParameter(parameters, "@ObjID"));
            long diagnosisId = (GetLongParameter(parameters, "@DiagnosisID"));

            VetObservationData observationData = GetVetCaseObservationData(manager, caseId);

            sp_rep_VET_LivestockCaseTableAdapter1.Connection = (SqlConnection) manager.Connection;
            sp_rep_VET_LivestockCaseTableAdapter1.Transaction = (SqlTransaction) manager.Transaction;
            sp_rep_VET_LivestockCaseTableAdapter1.CommandTimeout = CommandTimeout;
            livestockInvestigationDataSet1.EnforceConstraints = false;

            sp_rep_VET_LivestockCaseTableAdapter1.Fill(livestockInvestigationDataSet1.spRepVetLivestockCase, lang, caseId);

            herdReport1.SetParameters(manager, lang, caseId);
            vaccinationReport1.SetParameters(manager, lang, caseId);
            rapidTestReport1.SetParameters(manager, lang, caseId);
            diagnosisReport1.SetParameters(manager, lang, caseId);

            ClinicalInvestigationSubreport.Visible = false;
            m_ClinicalContainer.SetObservations(observationData.SpeciesObservationIdList, diagnosisId);

            FlexFactory.CreateLivestockEpiReport(EpiSubreport, observationData.FarmObservationId, diagnosisId);
            FlexFactory.CreateControlMeasuresReport(ControlMeasuresSubreport, observationData.CaseObservationId, diagnosisId);

            sampleReport1.SetParameters(manager, lang, caseId);
        }

        private void RebindAccessRigths()
        {
            if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_Contact_Details))
            {
                xrTableCell25.DataBindings.Clear();
                xrTableCell25.DataBindings.Add(new XRBinding("Text", null, "spRepVetLivestockCase.FarmAddressDenyRightsDetailed"));
            }
            if (AccessRigthsRebinder.ForbiddenAccess(PersonalDataGroup.Human_Contact_Settlement))
            {
                xrTableCell25.DataBindings.Clear();
                xrTableCell25.DataBindings.Add(new XRBinding("Text", null, "spRepVetLivestockCase.FarmAddressDenyRightsSettlement"));
            }
        }

        internal static VetObservationData GetVetCaseObservationData(DbManagerProxy manager, long caseId)
        {
            var observationDataSet = new DataSet();
            using (var adapter = new SqlDataAdapter())
            {
                SqlCommand command = ((SqlConnection) manager.Connection).CreateCommand();
                command.Transaction = (SqlTransaction) manager.Transaction;
                command.CommandTimeout = CommandTimeout;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spRepVetGetObservations";
                command.Parameters.Add(new SqlParameter("@ObjID", caseId));
                command.Parameters.Add(new SqlParameter("@LangID", ModelUserContext.CurrentLanguage));

                adapter.SelectCommand = command;
                adapter.Fill(observationDataSet);
            }
            DataTable caseObservation = observationDataSet.Tables[0];
            DataTable speciesObservation = observationDataSet.Tables[1];
            DataTable animalObservation = observationDataSet.Tables[2];
            var observationData = new VetObservationData();
            if (caseObservation.Rows.Count > 0)
            {
                observationData.CaseId = (long) caseObservation.Rows[0]["idfCase"];
                if (!(caseObservation.Rows[0]["idfCaseObservation"] is DBNull))
                {
                    observationData.CaseObservationId = (long) caseObservation.Rows[0]["idfCaseObservation"];
                }
                if (!(caseObservation.Rows[0]["idfFarmObservation"] is DBNull))
                {
                    observationData.FarmObservationId = (long) caseObservation.Rows[0]["idfFarmObservation"];
                }
                foreach (DataRow speciesRow in speciesObservation.Rows)
                {
                    if (!(speciesRow["idfSpeciesObservation"] is DBNull))
                    {
                        observationData.SpeciesObservationIdList.Add((long) speciesRow["idfSpeciesObservation"],
                            speciesRow["strHerdCode"] + "/" + speciesRow["strSpeciesName"]);
                    }
                }
                foreach (DataRow animalRow in animalObservation.Rows)
                {
                    if (!(animalRow["idfAnimalObservation"] is DBNull))
                    {
                        observationData.AnimalObservationIdList.Add((long) animalRow["idfAnimalObservation"],
                            animalRow["strAnimalName"].ToString());
                    }
                }
            }
            return observationData;
        }
    }
}