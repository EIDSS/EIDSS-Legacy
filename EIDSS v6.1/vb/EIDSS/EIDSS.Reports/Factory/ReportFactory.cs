using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
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
using EIDSS.Reports.Parameterized.Human.ARM.Keeper;
using EIDSS.Reports.Parameterized.Human.DToChangedD;
using EIDSS.Reports.Parameterized.Human.GG.Keeper;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using EIDSS.Reports.Parameterized.Human.IQ.Keepers;
using EIDSS.Reports.Parameterized.Human.KZ;
using EIDSS.Reports.Parameterized.Human.MMM;
using EIDSS.Reports.Parameterized.Human.TH.Keepers;
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumAberrationAnalysis()
        {
            BaseReportKeeper reportKeeper = new HumAberrationKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetAberrationAnalysis()
        {
            BaseReportKeeper reportKeeper = new VetAberrationKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SyndrAberrationAnalysis()
        {
            BaseReportKeeper reportKeeper = new SyndromicAberrationKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ILISyndrAberrationAnalysis()
        {
            BaseReportKeeper reportKeeper = new ILISyndromicAberrationKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Human reports

        #region Human Document report

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumAggregateCase(AggregateReportParameters parameters)
        {
            Dictionary<string, string> parameterList = ReportHelper.CreateHumAggregateCaseParameters(parameters);

            InitDocumentReport<CaseAggregateReport>(parameterList);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumAggregateCaseSummary(AggregateSummaryReportParameters aggrParams)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateAggrParameters(aggrParams.AggrXml);
            ReportHelper.AddObservationListToParameters(aggrParams.ObservationList, parameters, "@observationId");

            InitDocumentReport<SummaryAggregateReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumCaseInvestigation(long caseId, long epiId, long csId, long diagnosisId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateHumCaseInvestigationParameters(caseId, epiId, csId, diagnosisId);

            InitDocumentReport<CaseInvestigationReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumUrgentyNotification(long caseId)
        {
            InitDocumentReport<EmergencyNotificationReport>(ReportHelper.CreateParameters(caseId));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumUrgentyNotificationTanzania(long caseId)
        {
            InitDocumentReport<TanzaniaCaseInvestigation>(ReportHelper.CreateParameters(caseId));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumUrgentyNotificationDTRA(long caseId)
        {
            InitDocumentReport<EmergencyNotificationDTRAReport>(ReportHelper.CreateParameters(caseId));
        }

        #endregion

        #region Human common reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumDiagnosisToChangedDiagnosis()
        {
            BaseReportKeeper reportKeeper = new DToChangedDKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumMonthlyMorbidityAndMortality()
        {
            InitDateReport<MMMReport>();
        }

        #endregion

        #region Human GG reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Hum60BJournal()
        {
            BaseReportKeeper reportKeeper = new Journal60BKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumAnnualInfectiousDisease()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesYearKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumIntermediateAnnualInfectiousDisease()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesIntermediateYearKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumMonthInfectiousDiseaseV4()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesMonthKeeper(ReportVersion.Version4);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumIntermediateMonthInfectiousDiseaseV4()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesIntermediateMonthKeeper(ReportVersion.Version4);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumMonthInfectiousDiseaseV5()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesMonthKeeper(ReportVersion.Version5);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumIntermediateMonthInfectiousDiseaseV5()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesIntermediateMonthKeeper(ReportVersion.Version5);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumMonthInfectiousDiseaseV6()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesMonthKeeper(ReportVersion.Version6);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumMonthInfectiousDiseaseV61()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesMonthKeeper(ReportVersion.Version61);
            PlaceReportKeeper(reportKeeper);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumIntermediateMonthInfectiousDiseaseV6()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesIntermediateMonthKeeper(ReportVersion.Version6);
            PlaceReportKeeper(reportKeeper);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumIntermediateMonthInfectiousDiseaseV61()
        {
            BaseReportKeeper reportKeeper = new InfectiousDiseasesIntermediateMonthKeeper(ReportVersion.Version61);
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Lab  GG reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumSerologyResearchCard()
        {
            InitBaseSampleReport<SerologyResearchCardReport>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumMicrobiologyResearchCard()
        {
            InitBaseSampleReport<MicrobiologyResearchCardReport>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumAntibioticResistanceCard()
        {
            InitBaseSampleReport<AntibioticResistanceCardReport>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetLaboratoryResearchResult()
        {
            BaseReportKeeper reportKeeper = new LaboratoryResearchKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumAntibioticResistanceCardLma()
        {
            InitBaseSampleReport<AntibioticResistanceCardReport>(SampleReportModelType.VetLabSampleModel);
        }

        #endregion

        #region Human AZ reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumFormN1A3()
        {
            InitFormN1Report(true);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumFormN1A4()
        {
            InitFormN1Report(false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumDataQualityIndicators()
        {
            var reportKeeper = new DataQualityIndicatorsKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumDataQualityIndicatorsRayons()
        {
            var reportKeeper = new DataQualityIndicatorsKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumComparativeAZReport()
        {
            var reportKeeper = new ComparativeAZReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumSummaryByRayonDiagnosisAgeGroups()
        {
            var reportKeeper = new HumSummaryReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumTuberculosisCasesTested()
        {
            var reportKeeper = new TuberculosisComparativeReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumExternalComparativeReport()
        {
            var reportKeeper = new ExternalComparativeReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumMainIndicatorsOfAFPSurveillance()
        {
            var reportKeeper = new AFPIndicatorsReportKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumAdditionalIndicatorsOfAFPSurveillance()
        {
            var reportKeeper = new AFPIndicatorsReportKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumWhoMeaslesRubellaReport()
        {
            var reportKeeper = new WhoMeaslesRubellaKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumComparativeReportOfTwoYears()
        {
            var reportKeeper = new ComparativeTwoYearsAZReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumBorderRayonsComparativeReport()
        {
            var reportKeeper = new BorderRayonsComparativeReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LabTestingResultsAZ()
        {
            
            var reportKeeper = new LabTestingTesultsReportKeeper();
            PlaceReportKeeper(reportKeeper);
            //InitBaseSampleReport<LabTestingTesultsReport>(SampleReportModelType.VetLabSampleModel);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void AssignmentLabDiagnosticAZ()
        {
            var reportKeeper = new AssignmentLabDiagnosticReportKeeper();
            PlaceReportKeeper(reportKeeper);

           //InitBaseSampleReport<AssignmentLabDiagnosticReport>(SampleReportModelType.LabCaseModel);
 
        }

        #endregion

        #region Zoonotic AZ reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ZoonoticComparativeAZ()
        {
            var reportKeeper = new ZoonoticComparativeReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Simplified AZ reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SimplifiedComparativeAZ()
        {
            var reportKeeper = new ZoonoticComparativeReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region TH reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumComparativeReportOfSeveralYearsTH()
        {
            var reportKeeper = new ComparativeSeveralYearsTHReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumReportedCasesDeathsByProvinceMonthTH()
        {
            var reportKeeper = new NumberOfCasesDeathsMonthTHReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumNumberOfCasesDeathsMorbidityMortalityTH()
        {
            var reportKeeper = new NumberOfCasesDeathsMortalityTHReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Human ARM reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumFormN85()
        {
            var reportKeeper = new FormN85Keeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Human IQ reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void WeeklySituationDiseasesByDistricts()
        {
            var reportKeeper = new WeeklySituationDiseasesKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MonthlySituationDiseasesByDistricts()
        {
            var reportKeeper = new MonthlySituationDiseasesKeeper(true);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void WeeklySituationDiseasesByAgeGroupAndSex()
        {
            var reportKeeper = new WeeklySituationDiseasesKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MonthlySituationDiseasesByAgeGroupAndSex()
        {
            var reportKeeper = new MonthlySituationDiseasesKeeper(false);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumComparativeIQReport()
        {
            var reportKeeper = new ComparativeIQReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #endregion

        #region Veterinary Reports

        #region Veterinary Document report

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetAggregateCaseSummary(AggregateSummaryReportParameters aggrParams)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateAggrParameters(aggrParams.AggrXml);

            ReportHelper.AddObservationListToParameters(aggrParams.ObservationList, parameters, "@observationId");

            InitDocumentReport<VetAggregateCaseSummaryReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetAggregateCaseActions(AggregateActionsParameters aggrParams)
        {
            Dictionary<string, string> ps = ReportHelper.CreateVetAggregateCaseActionsParameters(aggrParams);

            InitDocumentReport<VetAggregateActionsReport>(ps);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetAggregateCaseActionsSummary(AggregateActionsSummaryParameters aggrParams)
        {
            Dictionary<string, string> ps = ReportHelper.CreateVetAggregateCaseActionsSummaryPs(aggrParams);

            InitDocumentReport<VetAggregateActionsSummaryReport>(ps);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetAvianInvestigation(long caseId, long diagnosisId, bool includeMap)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateParameters(caseId);
            parameters.Add("@DiagnosisID", diagnosisId.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@IncludeMap", includeMap ? "1" : "0");

            InitDocumentReport<AvianInvestigationReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetLivestockInvestigation(long caseId, long diagnosisId, bool includeMap)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateParameters(caseId);
            parameters.Add("@DiagnosisID", diagnosisId.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@IncludeMap", includeMap ? "1" : "0");

            InitDocumentReport<LivestockInvestigationReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetActiveSurveillanceSampleCollected(long id)
        {
            InitDocumentReport<SessionReport>(ReportHelper.CreateParameters(id));
        }

        #endregion

        #region Vet common reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetSamplesCount()
        {
            InitYearReport<VetSamplesCountReport>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetSamplesBySampleType()
        {
            InitYearReport<VetSamplesTypeReport>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetSamplesBySampleTypesWithinRegions()
        {
            InitYearReport<VetTestTypeReport>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetYearlySituation()
        {
            InitYearReport<VetSituationReport>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetActiveSurveillance()
        {
            InitYearReport<ActiveSurveillanceReport>();
        }

        #endregion

        #region Human KZ reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void HumInfectiousParasiticKZ()
        {
            var reportKeeper = new InfectiousParasiticKZKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Vet KZ reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetCountryPlannedDiagnosticTests()
        {
            BaseReportKeeper reportKeeper = new VetPlannedDiagnosticKeeper(typeof (VetCountryPlannedDiagnostic));
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetOblastPlannedDiagnosticTests()
        {
            BaseReportKeeper reportKeeper = new VetPlannedDiagnosticKeeper(typeof (VetRegionPlannedDiagnostic));
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetCountryPreventiveMeasures()
        {
            BaseReportKeeper reportKeeper = new VetPrevMeasuresKeeper(typeof (VetCountryPreventiveMeasures));
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetOblastPreventiveMeasures()
        {
            BaseReportKeeper reportKeeper = new VetPrevMeasuresKeeper(typeof (VetRegionPreventiveMeasures));
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetCountrySanitaryMeasures()
        {
            BaseReportKeeper reportKeeper = new VetProphMeasuresKeeper(typeof (VetCountryProphilacticMeasures));
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetOblastSanitaryMeasures()
        {
            BaseReportKeeper reportKeeper = new VetProphMeasuresKeeper(typeof (VetRegionProphilacticMeasures));
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Vet AZ reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VeterinaryCasesReportAZ()
        {
            BaseReportKeeper reportKeeper = new VetKeeper(VetReportType.Case);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VeterinaryLaboratoriesAZ()
        {
            BaseReportKeeper reportKeeper = new VetLabKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VeterinaryFormVet1()
        {
            BaseReportKeeper reportKeeper = new VetKeeper(VetReportType.FormVet1);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VeterinaryFormVet1A()
        {
            BaseReportKeeper reportKeeper = new VetKeeper(VetReportType.FormVet1A);
            PlaceReportKeeper(reportKeeper);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VeterinarySummaryAZ()
        {
            var reportKeeper = new VetSummaryReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #region Vet GG reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetRabiesBulletinEurope()
        {
            BaseReportKeeper reportKeeper = new RBEReportKeeper();
            PlaceReportKeeper(reportKeeper);
        }

        #endregion

        #endregion

        #region Lab module  Reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LimSampleTransfer(long id)
        {
            InitDocumentReport<TransferReport>(ReportHelper.CreateParameters(id));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LimTestResult(long id, long csId, long typeId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateLimTestResultParameters(id, csId, typeId);

            InitDocumentReport<TestResultReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LimTest(long id, bool isHuman)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateParameters(id);
            parameters.Add("@IsHuman", isHuman.ToString(CultureInfo.InvariantCulture));

            InitDocumentReport<TestReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LimBatchTest(long id, long typeId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateParameters(id);
            parameters.Add("@TypeID", typeId.ToString(CultureInfo.InvariantCulture));

            InitDocumentReport<BatchTestReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LimSample(long id)
        {
            InitDocumentReport<LimSampleReport>(ReportHelper.CreateParameters(id));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LimContainerContent(long? contId, long? freeserId)
        {
            Dictionary<string, string> parameters = ReportHelper.CreateLimSampleParameters(contId, freeserId);

            InitDocumentReport<ContainerContentReport>(parameters);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VetAggregateCase(AggregateReportParameters parameters)
        {
            Dictionary<string, string> parameterList = ReportHelper.CreateVetAggregateCaseParameters(parameters);

            InitDocumentReport<VetAggregateReport>(parameterList);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LimAccessionIn(long caseId)
        {
            InitDocumentReport<AccessionInReport>(ReportHelper.CreateParameters(caseId));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LimSampleDestruction(IEnumerable<long> sampleIds)
        {
            Dictionary<string, string> parameters = ReportHelper.ConvertSampeIdsToParameters(sampleIds);
            InitDocumentReport<SampleDestructionReport>(parameters);
        }

        #endregion

        #region Outbreaks  Reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Outbreak(long id)
        {
            InitDocumentReport<OutbreakReport>(ReportHelper.CreateParameters(id));
        }

        #endregion

        #region Vector Surveillance  Reports

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void VectorSurveillanceSessionSummary(long id)
        {
            InitDocumentReport<Document.VectorSurveillance.SessionReport>(ReportHelper.CreateParameters(id));
        }

        #endregion

        #region Administrative Parameterized Reports

        [MethodImpl(MethodImplOptions.NoInlining)]
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

        private static void InitDateReport<TR>()
            where TR : BaseDateReport
        {
            var reportKeeper = new BaseDateKeeper(typeof (TR));
            PlaceReportKeeper(reportKeeper);
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