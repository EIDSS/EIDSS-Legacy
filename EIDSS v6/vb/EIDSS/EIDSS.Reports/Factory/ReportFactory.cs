using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Form;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.ActiveSurveillance;
using EIDSS.Reports.Document.Human.Aggregate;
using EIDSS.Reports.Document.Human.CaseInvestigation;
using EIDSS.Reports.Document.Human.EmergencyNotification;
using EIDSS.Reports.Document.Human.TZ;
using EIDSS.Reports.Document.Lim.Batch;
using EIDSS.Reports.Document.Lim.Case;
using EIDSS.Reports.Document.Lim.ContainerContent;
using EIDSS.Reports.Document.Lim.ContainerDetails;
using EIDSS.Reports.Document.Lim.SampleDestruction;
using EIDSS.Reports.Document.Lim.TestResult;
using EIDSS.Reports.Document.Lim.Transfer;
using EIDSS.Reports.Document.Uni.AccessionIn;
using EIDSS.Reports.Document.Uni.Outbreak;
using EIDSS.Reports.Document.Veterinary.Aggregate;
using EIDSS.Reports.Document.Veterinary.AvianInvestigation;
using EIDSS.Reports.Document.Veterinary.LivestockInvestigation;
using EIDSS.Reports.Parameterized.AberrationAnalysis.Keepers;
using EIDSS.Reports.Parameterized.ActiveSurveillance;
using EIDSS.Reports.Parameterized.Human.AJ.Keepers;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using EIDSS.Reports.Parameterized.Human.ARM.Report;

using EIDSS.Reports.Parameterized.Human.DToChangedD;
using EIDSS.Reports.Parameterized.Human.GG.Keeper;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using EIDSS.Reports.Parameterized.Human.IQ.Keepers;
using EIDSS.Reports.Parameterized.Human.KZ;
using EIDSS.Reports.Parameterized.Human.MMM;
using EIDSS.Reports.Parameterized.Uni.EventLog;
using EIDSS.Reports.Parameterized.Veterinary.KZ;
using EIDSS.Reports.Parameterized.Veterinary.KZ.Keepers;
using EIDSS.Reports.Parameterized.Veterinary.SamplesCount;
using EIDSS.Reports.Parameterized.Veterinary.SamplesType;
using EIDSS.Reports.Parameterized.Veterinary.Situation;
using EIDSS.Reports.Parameterized.Veterinary.TestType;

namespace EIDSS.Reports.Factory
{
    internal delegate IReportForm CreateReportFormDelegate();

    public class ReportFactory : IReportFactory
    {
        private static CreateReportFormDelegate m_CreateReportFormHandler = () => new ReportForm();
        private static readonly List<IReportForm> m_ReportForms = new List<IReportForm>();

        public void ResetLanguage()
        {
            foreach (IReportForm form in m_ReportForms)
            {
                form.Close();
            }
            m_ReportForms.Clear();
        }

        #region Standard Reports

        public void HumAberrationAnalysis()
        {
            BaseReportKeeper reportKeeper = new HumAberrationKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void VetAberrationAnalysis()
        {
            BaseReportKeeper reportKeeper = new VetAberrationKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void SyndrAberrationAnalysis()
        {
            BaseReportKeeper reportKeeper = new SyndromicAberrationKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void ILISyndrAberrationAnalysis()
        {
            BaseReportKeeper reportKeeper = new ILISyndromicAberrationKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Human reports

        #region Human Document report

        public void HumAggregateCase(AggregateReportParameters parameters)
        {
            Dictionary<string, string> parameterList = ReportHelper.CreateHumAggregateCaseParameters(parameters);

            InitDocumentReport<CaseAggregateReport>(parameterList);
        }

        public void HumAggregateCaseSummary(AggregateSummaryReportParameters aggrParams)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateAggrParameters(aggrParams.AggrXml);
            ReportHelper.AddObservationListToParameters(aggrParams.ObservationList, parameters, "@observationId");

            InitDocumentReport<SummaryAggregateReport>(parameters);
        }

        public void HumCaseInvestigation(long caseId, long epiId, long csId, long diagnosisId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateHumCaseInvestigationParameters(caseId, epiId, csId, diagnosisId);

            InitDocumentReport<CaseInvestigationReport>(parameters);
        }

        public void HumUrgentyNotification(long caseId)
        {
            if (EidssSiteContext.Instance.CountryID == 2250000000)
            {
                InitDocumentReport<TanzaniaCaseInvestigation>(ReportHelper.CreateParameters(caseId));
            }
            else
            {
                InitDocumentReport<EmergencyNotificationReport>(ReportHelper.CreateParameters(caseId));
            }
        }

        #endregion

        #region Human common reports

        public void HumDiagnosisToChangedDiagnosis()
        {
            BaseReportKeeper reportKeeper = new DToChangedDKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumMonthlyMorbidityAndMortality()
        {
            InitDateReport<MMMReport>();
        }

       

        #endregion

        #region Human GG reports

        public void Hum60BJournal()
        {
            BaseReportKeeper reportKeeper = new Journal60BKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumMonthInfectiousDiseaseNew()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesMonthKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        public void HumIntermediateMonthInfectiousDiseaseNew()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesIntermediateMonthKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        public void HumAnnualInfectiousDisease()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesYearKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumIntermediateAnnualInfectiousDisease()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesIntermediateYearKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumMonthInfectiousDisease()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesMonthKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        public void HumIntermediateMonthInfectiousDisease()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesIntermediateMonthKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Lab  GG reports

        public void HumSerologyResearchCard()
        {
            InitBaseSampleReport<SerologyResearchCardReport>();
        }

        public void HumMicrobiologyResearchCard()
        {
            InitBaseSampleReport<MicrobiologyResearchCardReport>();
        }

        public void HumAntibioticResistanceCard()
        {
            InitBaseSampleReport<AntibioticResistanceCardReport>();
        }

        public void VetLaboratoryResearchResult()
        {
            BaseReportKeeper reportKeeper = new LaboratoryResearchKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumAntibioticResistanceCardLma()
        {
            InitBaseSampleReport<AntibioticResistanceCardReport>(SampleReportModelType.VetLabSampleModel);
        }

        #endregion

        #region Human AZ reports

        public void HumFormN1A3()
        {
            InitFormN1Report(true);
        }

        public void HumFormN1A4()
        {
            InitFormN1Report(false);
        }

        public void HumDataQualityIndicators()
        {
            var reportKeeper = new DataQualityIndicatorsKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        public void HumDataQualityIndicatorsRayons()
        {
            var reportKeeper = new DataQualityIndicatorsKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        public void HumComparativeAZReport()
        {
            var reportKeeper = new ComparativeAZReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumSummaryByRayonDiagnosisAgeGroups()
        {
            var reportKeeper = new SummaryReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumExternalComparativeReport()
        {
            var reportKeeper = new ExternalComparativeReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumMainIndicatorsOfAFPSurveillance()
        {
            var reportKeeper = new AFPIndicatorsReportKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        public void HumAdditionalIndicatorsOfAFPSurveillance()
        {
            var reportKeeper = new AFPIndicatorsReportKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        public void HumWhoMeaslesRubellaReport()
        {
            var reportKeeper = new WhoMeaslesRubellaKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void HumComparativeReportOfTwoYears()
        {
            var reportKeeper = new ComparativeTwoYearsAZReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void LabTestingResultsAZ()
        {
            InitBaseSampleReport<LabTestingTesultsReport>(SampleReportModelType.VetLabSampleModel);
        }

        public void AssignmentLabDiagnosticAZ()
        {
            InitBaseSampleReport<AssignmentLabDiagnosticReport>(SampleReportModelType.LabCaseModel);
        }

        #endregion

        #region Human ARM reports

        public void HumFormN85Annual()
        {
            InitYearReport<FormN85AnnualReport>();
        }

        public void HumFormN85Monthly()
        {
            BaseDateKeeper keeper = InitDateReport<FormN85MonthlyReport>();
            keeper.SetMandatory();
        }

        #endregion

        #region Human IQ reports

        public void WeeklySituationDiseasesByDistricts()
        {
            var reportKeeper = new WeeklySituationDiseasesKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        public void WeeklySituationDiseasesByAgeGroupAndSex()
        {
            var reportKeeper = new WeeklySituationDiseasesKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        public void HumComparativeIQReport()
        {
            var reportKeeper = new ComparativeIQReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #endregion

        #region Veterinary Reports

        #region Veterinary Document report

        public void VetAggregateCaseSummary(AggregateSummaryReportParameters aggrParams)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateAggrParameters(aggrParams.AggrXml);

            ReportHelper.AddObservationListToParameters(aggrParams.ObservationList, parameters, "@observationId");

            InitDocumentReport<VetAggregateCaseSummaryReport>(parameters);
        }

        public void VetAggregateCaseActions(AggregateActionsParameters aggrParams)
        {
            Dictionary<string, string> ps = ReportHelper.CreateVetAggregateCaseActionsParameters(aggrParams);

            InitDocumentReport<VetAggregateActionsReport>(ps);
        }

        public void VetAggregateCaseActionsSummary(AggregateActionsSummaryParameters aggrParams)
        {
            Dictionary<string, string> ps = ReportHelper.CreateVetAggregateCaseActionsSummaryPs(aggrParams);

            InitDocumentReport<VetAggregateActionsSummaryReport>(ps);
        }

        public void VetAvianInvestigation(long caseId, long diagnosisId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateParameters(caseId);
            parameters.Add("@DiagnosisID", diagnosisId.ToString(CultureInfo.InvariantCulture));

            InitDocumentReport<AvianInvestigationReport>(parameters);
        }

        public void VetLivestockInvestigation(long caseId, long diagnosisId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateParameters(caseId);
            parameters.Add("@DiagnosisID", diagnosisId.ToString(CultureInfo.InvariantCulture));

            InitDocumentReport<LivestockInvestigationReport>(parameters);
        }

        public void VetActiveSurveillanceSampleCollected(long id)
        {
            InitDocumentReport<SessionReport>(ReportHelper.CreateParameters(id));
        }

        #endregion

        #region Vet common reports

        public void VetSamplesCount()
        {
            InitYearReport<VetSamplesCountReport>();
        }

        public void VetSamplesBySampleType()
        {
            InitYearReport<VetSamplesTypeReport>();
        }

        public void VetSamplesBySampleTypesWithinRegions()
        {
            InitYearReport<VetTestTypeReport>();
        }

        public void VetYearlySituation()
        {
            InitYearReport<VetSituationReport>();
        }

        public void VetActiveSurveillance()
        {
            InitYearReport<ActiveSurveillanceReport>();
        }

        #endregion


        #region Human KZ reports

        public void HumInfectiousParasiticKZ()
        {
            var reportKeeper = new InfectiousParasiticKZKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Vet KZ reports

        public void VetCountryPlannedDiagnosticTests()
        {
            BaseReportKeeper reportKeeper = new VetPlannedDiagnosticKeeper(typeof (VetCountryPlannedDiagnostic));
            PlaceReportKeeper(reportKeeper);
        }

        public void VetOblastPlannedDiagnosticTests()
        {
            BaseReportKeeper reportKeeper = new VetPlannedDiagnosticKeeper(typeof (VetRegionPlannedDiagnostic));
            PlaceReportKeeper(reportKeeper);
        }

        public void VetCountryPreventiveMeasures()
        {
            BaseReportKeeper reportKeeper = new VetPrevMeasuresKeeper(typeof (VetCountryPreventiveMeasures));
            PlaceReportKeeper(reportKeeper);
        }

        public void VetOblastPreventiveMeasures()
        {
            BaseReportKeeper reportKeeper = new VetPrevMeasuresKeeper(typeof (VetRegionPreventiveMeasures));
            PlaceReportKeeper(reportKeeper);
        }

        public void VetCountrySanitaryMeasures()
        {
            BaseReportKeeper reportKeeper = new VetProphMeasuresKeeper(typeof (VetCountryProphilacticMeasures));
            PlaceReportKeeper(reportKeeper);
        }

        public void VetOblastSanitaryMeasures()
        {
            BaseReportKeeper reportKeeper = new VetProphMeasuresKeeper(typeof (VetRegionProphilacticMeasures));
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Vet AZ reports

        public void VeterinaryCasesReportAZ()
        {
            BaseReportKeeper reportKeeper = new VetKeeper(VetReportType.Case);
            PlaceReportKeeper(reportKeeper);
        }

        public void VeterinaryLaboratoriesAZ()
        {
            BaseReportKeeper reportKeeper = new VetLabKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        public void VeterinaryFormVet1()
        {
            BaseReportKeeper reportKeeper = new VetKeeper(VetReportType.FormVet1);
            PlaceReportKeeper(reportKeeper);
        }

        public void VeterinaryFormVet1A()
        {
            BaseReportKeeper reportKeeper = new VetKeeper(VetReportType.FormVet1A);
            PlaceReportKeeper(reportKeeper);
        }

        public void VeterinarySummaryAZ()
        {
            var reportKeeper = new SummaryReportKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Vet GG reports

        public void VetRabiesBulletinEurope()
        {
            BaseReportKeeper reportKeeper = new RBEReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #endregion

        #region Lab module  Reports

        public void LimSampleTransfer(long id)
        {
            InitDocumentReport<TransferReport>(ReportHelper.CreateParameters(id));
        }

        public void LimTestResult(long id, long csId, long typeId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateLimTestResultParameters(id, csId, typeId);

            InitDocumentReport<TestResultReport>(parameters);
        }

        public void LimTest(long id, bool isHuman)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateParameters(id);
            parameters.Add("@IsHuman", isHuman.ToString(CultureInfo.InvariantCulture));

            InitDocumentReport<TestReport>(parameters);
        }

        public void LimBatchTest(long id, long typeId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateParameters(id);
            parameters.Add("@TypeID", typeId.ToString(CultureInfo.InvariantCulture));

            InitDocumentReport<BatchTestReport>(parameters);
        }

        public void LimSample(long id)
        {
            InitDocumentReport<LimSampleReport>(ReportHelper.CreateParameters(id));
        }

        public void LimContainerContent(long? contId, long? freeserId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateLimSampleParameters(contId, freeserId);

            InitDocumentReport<ContainerContentReport>(parameters);
        }

        public void VetAggregateCase(AggregateReportParameters parameters)
        {
            Dictionary<string, string> parameterList = ReportHelper.CreateVetAggregateCaseParameters(parameters);

            InitDocumentReport<VetAggregateReport>(parameterList);
        }

        public void LimAccessionIn(long caseId)
        {
            InitDocumentReport<AccessionInReport>(ReportHelper.CreateParameters(caseId));
        }

        public void LimSampleDestruction(IEnumerable<long> sampleIds)
        {
            Dictionary<string, string> parameters = SampleDestructionReport.ConvertSampeIdsToParameters(sampleIds);
            InitDocumentReport<SampleDestructionReport>(parameters);
        }

        #endregion

        #region Outbreaks  Reports

        public void Outbreak(long id)
        {
            InitDocumentReport<OutbreakReport>(ReportHelper.CreateParameters(id));
        }

        #endregion

        #region Vector Surveillance  Reports

        public void VectorSurveillanceSessionSummary(long id)
        {
            InitDocumentReport<Document.VectorSurveillance.SessionReport>(ReportHelper.CreateParameters(id));
        }

        #endregion

        #region Administrative Parameterized Reports

        public void AdmEventLog()
        {
            InitIntervalReport<EventLogReport>();
        }

        #endregion

        #region Helper methods

        internal static CreateReportFormDelegate CreateReportFormHandler
        {
            get { return m_CreateReportFormHandler; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                m_CreateReportFormHandler = value;
            }
        }

        private static void InitDocumentReport<TR>(Dictionary<string, string> parameters)
            where TR : BaseDocumentReport
        {
            BaseReportKeeper reportKeeper = new BaseDocumentKeeper(typeof (TR), parameters);
            PlaceReportKeeper(reportKeeper);
        }

        private static void InitYearReport<TR>()
            where TR : BaseYearReport
        {
            BaseReportKeeper reportKeeper = new BaseYearKeeper(typeof (TR));
            PlaceReportKeeper(reportKeeper);
        }

        private static void InitIntervalReport<TR>()
            where TR : BaseIntervalReport
        {
            BaseReportKeeper reportKeeper = new BaseIntervalKeeper(typeof (TR));
            PlaceReportKeeper(reportKeeper);
        }

        private static BaseDateKeeper InitDateReport<TR>()
            where TR : BaseDateReport
        {
            var reportKeeper = new BaseDateKeeper(typeof (TR));
            PlaceReportKeeper(reportKeeper);
            return reportKeeper;
        }

        private static void InitFormN1Report(bool isA3Format)
        {
            var reportKeeper = new FormN1Keeper {IsA3Format = isA3Format};
            PlaceReportKeeper(reportKeeper);
        }

        private static void InitBaseSampleReport<TR>(SampleReportModelType modelType = SampleReportModelType.HumanLabSampleModel)
            where TR : BaseSampleReport
        {
            BaseReportKeeper reportKeeper = new BaseSampleKeeper(typeof (TR), modelType);
            PlaceReportKeeper(reportKeeper);
        }

        private static void PlaceReportKeeper(BaseReportKeeper reportKeeper)
        {
            using (reportKeeper.ContextKeeper.CreateNewContext(ContextValue.ReportFormLoading))
            {
                IReportForm reportForm = CreateReportFormHandler();
                m_ReportForms.Add(reportForm);
                reportForm.FormClosed += reportForm_FormClosed;
                reportForm.ShowReport(reportKeeper);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    using (reportKeeper.ContextKeeper.CreateNewContext(ContextValue.ReportKeeperFirstLoading))
                    {
                        reportKeeper.ApplyResources(manager);
                    }
                }
                Application.DoEvents();
            }
            if (reportKeeper.ReloadReportOnLanguageChanged)
            {
                reportKeeper.ReloadReportIfFormLoaded();
            }
        }

        private static void reportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(sender is IReportForm))
            {
                return;
            }

            m_ReportForms.Remove((IReportForm) sender);
        }

        #endregion
    }
}