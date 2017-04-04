using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using DevExpress.XtraReports.UI;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;
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

        public override void SetParameters
            (string lang, Dictionary<string, string> parameters, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            base.SetParameters(lang, parameters, manager, archiveManager);

            RebindAccessRigths();

            long caseId = (GetLongParameter(parameters, "@ObjID"));
            long diagnosisId = (GetLongParameter(parameters, "@DiagnosisID"));
            long includeMapInt;
            bool includeMap = TryGetLongParameter(parameters, "@IncludeMap", out includeMapInt) && includeMapInt == 1;


            VetObservationData observationData = GetVetCaseObservationData(manager, caseId);

            LivestockCaseTableAdapter.Connection = (SqlConnection) manager.Connection;
            LivestockCaseTableAdapter.Transaction = (SqlTransaction) manager.Transaction;
            LivestockCaseTableAdapter.CommandTimeout = CommandTimeout;
            LivestockInvestigationDataSet.EnforceConstraints = false;

            LivestockCaseTableAdapter.Fill(LivestockInvestigationDataSet.spRepVetLivestockCase, caseId, lang);
            FillBarcode();

            ((HerdReport) xrSubreportHerd.ReportSource).SetParameters(lang, caseId, manager, archiveManager);
            FlexFactory.CreateLivestockEpiReport(EpiSubreport, observationData.FarmObservationId, diagnosisId);
            ClinicalInvestigationSubreport.Visible = false;
            m_ClinicalContainer.SetObservations(observationData.SpeciesObservationIdList, diagnosisId);
            FlexFactory.CreateControlMeasuresReport(ControlMeasuresSubreport, observationData.CaseObservationId, diagnosisId);
            ((DiagnosisReport) DiagnosisSubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager);
            ((VaccinationReport) VaccinationSubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager);
            ((LivestockSampleReport) SampleSubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager);
            ((LivestockAnimalCSReport) AnimalSubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager);
            ((RapidTestReport) RapidTestSubreport.ReportSource).SetParameters(lang, caseId, manager, archiveManager);

            DetailReportMap.Visible = BaseSettings.PrintMapInVetReports;
            if (includeMap)
            {
                MapPictureBox.Image = PrintMapHelper.GetPrintMap(LivestockInvestigationDataSet.spRepVetLivestockCase);
            }

            ReportRtlHelper.SetRTL(this);
            ReportRebinder.RebindDateAndFontForReport();
        }

        private void FillBarcode()
        {
            if (LivestockInvestigationDataSet.spRepVetLivestockCase.Count > 0)
            {
                var row = LivestockInvestigationDataSet.spRepVetLivestockCase[0];

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