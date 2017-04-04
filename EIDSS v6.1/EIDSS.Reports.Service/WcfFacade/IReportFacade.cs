using System;
using System.Collections.Generic;
using System.ServiceModel;
using bv.common.Core;
using eidss.model.Reports.ARM;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.IQ;
using eidss.model.Reports.KZ;
using eidss.model.Reports.TH;

namespace EIDSS.Reports.Service.WcfFacade
{
    [ServiceContract]
    public interface IReportFacade
    {
        #region Common Human Reports

        [OperationContract]
        byte[] ExportHumAggregateCase(AggregateModel model);

        [OperationContract]
        byte[] ExportHumAggregateCaseSummary(AggregateSummaryModel model);

        [OperationContract]
        byte[] ExportHumCaseInvestigation(HumIdModel model);

        [OperationContract]
        byte[] ExportHumUrgentyNotification(BaseIdModel model);

        [OperationContract]
        byte[] ExportHumUrgentyNotificationDTRA(BaseIdModel model);

        [OperationContract]
        byte[] ExportHumUrgentyNotificationTanzania(BaseIdModel model);

        [OperationContract]
        byte[] ExportHumDiagnosisToChangedDiagnosis(DToChangedDSurrogateModel model);

        [OperationContract]
        byte[] ExportHumMonthlyMorbidityAndMortality(BaseDateModel model);

        #endregion

        #region Human GG reports

        [OperationContract]
        byte[] ExportHum60BJournal(Hum60BJournalModel model);

        [OperationContract]
        byte[] ExportHumMonthInfectiousDiseaseV4(MonthInfectiousDiseaseModel model);

        [OperationContract]
        byte[] ExportHumMonthInfectiousDiseaseV5(MonthInfectiousDiseaseModel model);

        [OperationContract]
        byte[] ExportHumMonthInfectiousDiseaseV6(MonthInfectiousDiseaseModel model);

        [OperationContract]
        byte[] ExportHumMonthInfectiousDiseaseV61(MonthInfectiousDiseaseModel model);

        [OperationContract]
        byte[] ExportHumIntermediateMonthInfectiousDiseaseV4(IntermediateInfectiousDiseaseSurrogateModel model);

        [OperationContract]
        byte[] ExportHumIntermediateMonthInfectiousDiseaseV5(IntermediateInfectiousDiseaseSurrogateModel model);

        [OperationContract]
        byte[] ExportHumIntermediateMonthInfectiousDiseaseV6(IntermediateInfectiousDiseaseSurrogateModel model);

        [OperationContract]
        byte[] ExportHumIntermediateMonthInfectiousDiseaseV61(IntermediateInfectiousDiseaseSurrogateModel model);

        [OperationContract]
        byte[] ExportHumAnnualInfectiousDisease(AnnualInfectiousDiseaseModel model);

        [OperationContract]
        byte[] ExportHumIntermediateAnnualInfectiousDisease(IntermediateInfectiousDiseaseSurrogateModel model);

        #endregion

        #region Lab GG reports

        [OperationContract]
        byte[] ExportHumSerologyResearchCard(HumanLabSampleModel model);

        [OperationContract]
        byte[] ExportHumMicrobiologyResearchCard(HumanLabSampleModel model);

        [OperationContract]
        byte[] ExportHumAntibioticResistanceCard(HumanLabSampleModel model);

        [OperationContract]
        byte[] ExportHumAntibioticResistanceCardLma(VetLabSampleModel model);

        [OperationContract]
        byte[] ExportVetRabiesBulletinEurope(RBESurrogateModel model);

        [OperationContract]
        byte[] ExportVetLaboratoryResearchResult(VetLaboratoryResearchResultModel model);

        #endregion

        #region Human AZ reports

        [OperationContract]
        byte[] ExportHumFormN1(FormNo1SurrogateModel model);

        [OperationContract]
        byte[] ExportHumDataQualityIndicators(DataQualityIndicatorsSurrogateModel surrogateModel);

        [OperationContract]
        byte[] ExportHumDataQualityIndicatorsRayons(DataQualityIndicatorsSurrogateModel surrogateModel);

        [OperationContract]
        byte[] ExportHumSummaryByRayonDiagnosisAgeGroups(SummaryByRayonDiagnosisModel model);

        [OperationContract]
        byte[] ExportHumComparativeAZReport(ComparativeSurrogateModel model);

        [OperationContract]
        byte[] ExportHumExternalComparativeReport(ExternalComparativeSurrogateModel model);

        [OperationContract]
        byte[] ExportHumMainIndicatorsOfAFPSurveillance(AFPModel model);

        [OperationContract]
        byte[] ExportHumAdditionalIndicatorsOfAFPSurveillance(AFPModel model);

        [OperationContract]
        byte[] ExportHumWhoMeaslesRubellaReport(WhoMeaslesRubellaModel model);

        [OperationContract]
        byte[] ExportHumComparativeReportOfTwoYears(ComparativeTwoYearsSurrogateModel model);

        [OperationContract]
        byte[] ExportHumBorderRayonsComparativeReport(BorderRayonsSurrogateModel model);

        [OperationContract]
        byte[] ExportHumTuberculosisCasesTested(TuberculosisSurrogateModel model);

        [OperationContract]
        byte[] ExportLabTestingResultsAZ(LabTestingTesultsModel model);


        [OperationContract]
        byte[] ExportAssignmentLabDiagnosticAZ(AssignmentLabDiagnosticModel model);


        #endregion

        #region Zoonotic AZ reports

        [OperationContract]
        byte[] ExportZoonoticComparativeAZ(ZoonoticSurrogateModel model);

        #endregion

        #region Human IQ reports

        [OperationContract]
        byte[] ExportHumComparativeIQReport(ComparativeSurrogateModel model);

        [OperationContract]
        byte[] ExportWeeklySituationDiseasesByAgeGroupAndSex(SituationOnInfectiousDiseasesSurrogateModel model);

        [OperationContract]
        byte[] ExportMonthlySituationDiseasesByAgeGroupAndSex(SituationOnInfectiousDiseasesSurrogateModel model);

        [OperationContract]
        byte[] ExportWeeklySituationDiseasesByDistricts(SituationOnInfectiousDiseasesSurrogateModel model);

        [OperationContract]
        byte[] ExportMonthlySituationDiseasesByDistricts(SituationOnInfectiousDiseasesSurrogateModel model);

        #endregion

        #region Veterinary AZ reports

        [OperationContract]
        byte[] ExportVeterinaryCasesReport(VetCasesSurrogateModel model);

        [OperationContract]
        byte[] ExportVeterinaryLaboratoriesAZReport(VetLabSurrogateModel model);

        [OperationContract]
        byte[] ExportVeterinaryFormVet1(VetCasesSurrogateModel model);

        [OperationContract]
        byte[] ExportVeterinaryFormVet1A(VetCasesSurrogateModel model);

        [OperationContract]
        byte[] ExportVeterinarySummaryAZ(VetSummaryModel model);

        #endregion

        #region TH reports

        [OperationContract]
        byte[] ExportHumComparativeReportOfSeveralYearsTH(ComparativeSeveralYearsTHSurrogateModel model);

        [OperationContract]
        byte[] ExportHumNumberOfCasesDeathsMorbidityMortalityTH(NumberOfCasesDeathsMorbidityMortalityTHModel model);

        [OperationContract]
        byte[] ExportHumNumberOfCasesDeathsMonthTH(NumberOfCasesDeathsMonthTHModel model);

        #endregion

        #region ARM reports

        [OperationContract]
        byte[] ExportHumFormN85ARM(FormN85SurrogateModel model);

        #endregion

        #region Common Veterinary reports

        [OperationContract]
        byte[] ExportVetAggregateCase(AggregateModel model);

        [OperationContract]
        byte[] ExportVetAggregateCaseSummary(AggregateSummaryModel model);

        [OperationContract]
        byte[] ExportVetAggregateCaseActions(AggregateActionsModel model);

        [OperationContract]
        byte[] ExportVetAggregateCaseActionsSummary(AggregateActionsSummaryModel model);

        [OperationContract]
        byte[] ExportVetAvianInvestigation(VetIdModel model);

        [OperationContract]
        byte[] ExportVetLivestockInvestigation(VetIdModel model);

        [OperationContract]
        byte[] ExportVetActiveSurveillanceSampleCollected(BaseIdModel model);

        [OperationContract]
        byte[] ExportVetSamplesCount(BaseYearModel model);

        [OperationContract]
        byte[] ExportVetSamplesBySampleType(BaseYearModel model);

        [OperationContract]
        byte[] ExportVetSamplesBySampleTypesWithinRegions(BaseYearModel model);

        [OperationContract]
        byte[] ExportVetYearlySituation(BaseYearModel model);

        [OperationContract]
        byte[] ExportVetActiveSurveillance(BaseYearModel model);

        #endregion

        #region KZ Human reports

        [OperationContract]
        byte[] ExportInfectiousParasiticKZReport(InfectiousParasiticKZSurrogateModel model);

        #endregion

        #region KZ Veterinary reports

        [OperationContract]
        byte[] ExportVetCountryPreventiveMeasures(ProphylacticModel model);

        [OperationContract]
        byte[] ExportVetCountrySanitaryMeasures(SanitaryModel model);

        [OperationContract]
        byte[] ExportVetCountryPlannedDiagnosticTests(DiagnosticInvestigationModel model);

        [OperationContract]
        byte[] ExportVetOblastPreventiveMeasures(ProphylacticModel model);

        [OperationContract]
        byte[] ExportVetOblastSanitaryMeasures(SanitaryModel model);

        [OperationContract]
        byte[] ExportVetOblastPlannedDiagnosticTests(DiagnosticInvestigationModel model);

        #endregion

        #region Lab module reports

        [OperationContract]
        byte[] ExportLimTestResult(LimTestResultModel model);

        [OperationContract]
        byte[] ExportLimSampleTransfer(BaseIdModel model);

        [OperationContract]
        byte[] ExportLimTest(LimTestModel model);

        [OperationContract]
        byte[] ExportLimBatchTest(LimBatchTestModel model);

        [OperationContract]
        byte[] ExportLimSample(BaseIdModel model);

        [OperationContract]
        byte[] ExportLimContainerContent(LimContainerContentModel model);

        [OperationContract]
        byte[] ExportLimAccessionIn(BaseIdModel model);

        [OperationContract]
        byte[] ExportLimSampleDestruction(IdListModel model);

        #endregion

        #region  Outbreak reports

        [OperationContract]
        byte[] ExportOutbreak(BaseIdModel model);

        #endregion

        #region Administrative reports

        [OperationContract]
        byte[] ExportAdmEventLog(BaseIntervalModel model);

        #endregion

        #region Vector Surveillance reports

        [OperationContract]
        byte[] ExportVectorSurveillanceSessionSummary(BaseIdModel model);

        #endregion

        #region Barcode reports

        [OperationContract]
        byte[] ExportNewBarcodes(long barcodeType, int quantity);

        [OperationContract]
        byte[] ExportExistingBarcodes(long barcodeType, IList<long> idList);

        [OperationContract]
        byte[] ExportSampleBarcodes(IList<SampleBarcodeDTO> samples);

        #endregion

        [OperationContract]
        Version GetServiceVersion();
    }
}