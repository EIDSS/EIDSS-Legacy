using System.Collections.Generic;
using eidss.model.Enums;

namespace eidss.model.Reports
{
    public interface IReportFactory
    {
        void ResetLanguage();

        #region Syndromic Surviellance

        [MenuReportDescription(ReportSubMenu.Aberration, "ReportsHumAberrationAnalysis", 60000, (int) MenuIconsSmall.HumanAberrationReport)]
        [MenuReportCustomization(AbsentInWeb = true)]
        void HumAberrationAnalysis();

        [MenuReportDescription(ReportSubMenu.Aberration, "ReportsVetAberrationAnalysis", 60001, (int) MenuIconsSmall.VetAberrationReport)]
        [MenuReportCustomization(AbsentInWeb = true)]
        void VetAberrationAnalysis();

        [MenuReportDescription(ReportSubMenu.Aberration, "ReportsSyndrAberrationAnalysis", 60002, (int) MenuIconsSmall.BssAberrationReport)]
        [MenuReportCustomization(AbsentInWeb = true)]
        void SyndrAberrationAnalysis();

        [MenuReportDescription(ReportSubMenu.Aberration, "ReportsILISyndrAberrationAnalysis", 6000, (int) MenuIconsSmall.BssAggregateList)]
        [MenuReportCustomization(AbsentInWeb = true)]
        void ILISyndrAberrationAnalysis();

        #endregion

        #region Common Human Reports

        void HumAggregateCase(AggregateReportParameters aggrParams);
        void HumAggregateCaseSummary(AggregateSummaryReportParameters aggrParams);

        void HumCaseInvestigation(long caseId, long epiId, long csId, long diagnosisId);
        void HumUrgentyNotification(long caseId);

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumDiagnosisToChangedDiagnosis", 400)]
        [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Azerbaijan})]
        void HumDiagnosisToChangedDiagnosis();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumMonthlyMorbidityAndMortality", 390)]
        [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Azerbaijan})]
        void HumMonthlyMorbidityAndMortality();

       

        #endregion

        #region Human GG reports

        [MenuReportDescription(ReportSubMenu.Human, "ReportsJournal60BReportCard", 320)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void Hum60BJournal();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "ReportsHumInfectiousDiseaseMonth", 370)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumMonthInfectiousDisease();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumInfectiousDiseaseMonthNew", 330)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumMonthInfectiousDiseaseNew();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "HumInfectiousDiseaseIntermediateMonth", 380)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumIntermediateMonthInfectiousDisease();

        [MenuReportDescription(ReportSubMenu.Human, "HumInfectiousDiseaseIntermediateMonthNew", 340)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumIntermediateMonthInfectiousDiseaseNew();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "ReportsHumInfectiousDiseaseYear", 350)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumAnnualInfectiousDisease();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "HumInfectiousDiseaseIntermediateYear", 360)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumIntermediateAnnualInfectiousDisease();

        #endregion

        #region Lab GG reports

        [MenuReportDescription(ReportSubMenu.Lab, "VetLaboratoryResearchResult", 440)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void VetLaboratoryResearchResult();

        [MenuReportDescription(ReportSubMenu.Lab, "ReportsHumSerologyResearchCard", 410)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        [ForbiddenDataGroup(PersonalDataGroup.Human_PersonName, PersonalDataGroup.Human_PersonAge)]
        void HumSerologyResearchCard();

        [MenuReportDescription(ReportSubMenu.Lab, "ReportsHumMicrobiologyResearchCard", 420)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        [ForbiddenDataGroup(PersonalDataGroup.Human_PersonName, PersonalDataGroup.Human_PersonAge)]
        void HumMicrobiologyResearchCard();

        [MenuReportDescription(ReportSubMenu.Lab, "HumAntibioticResistanceCard", 430)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumAntibioticResistanceCard();

        [MenuReportDescription(ReportSubMenu.Lab, "HumAntibioticResistanceCardLma", 450)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumAntibioticResistanceCardLma();

        #endregion

        #region Human AZ reports

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN1A3", 260)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumFormN1A3();

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN1A4", 270)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumFormN1A4();

        //[MenuReportDescription(ReportSubMenu.Human, "HumDataQualityIndicators", 280, Permission = EIDSSPermissionObject.Report)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        [MenuReportDescription(ReportSubMenu.Human, "HumDataQualityIndicators", 280, Permission = EIDSSPermissionObject.CanSignReport)]
        void HumDataQualityIndicators();

        [MenuReportDescription(ReportSubMenu.Human, "HumDataQualityIndicatorsRayons", 285)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumDataQualityIndicatorsRayons();

        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeReport", 290)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumComparativeAZReport();

        [MenuReportDescription(ReportSubMenu.Human, "HumSummaryByRayonDiagnosisAgeGroups", 300)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumSummaryByRayonDiagnosisAgeGroups();

        [MenuReportDescription(ReportSubMenu.Human, "HumExternalComparativeReport", 310)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumExternalComparativeReport();

        [MenuReportDescription(ReportSubMenu.Human, "HumMainIndicatorsOfAFPSurveillance", 320)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumMainIndicatorsOfAFPSurveillance();

        [MenuReportDescription(ReportSubMenu.Human, "HumAdditionalIndicatorsOfAFPSurveillance", 330)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumAdditionalIndicatorsOfAFPSurveillance();

        [MenuReportDescription(ReportSubMenu.Human, "HumWhoMeaslesRubellaReport", 340)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumWhoMeaslesRubellaReport();

        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeReportOfTwoYears", 350)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumComparativeReportOfTwoYears();

        [MenuReportDescription(ReportSubMenu.Human, "AssignmentLabDiagnosticAZ", 360)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void AssignmentLabDiagnosticAZ();

        [MenuReportDescription(ReportSubMenu.Human, "LabTestingResultsAZ", 370)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void LabTestingResultsAZ();

        #endregion

        #region Veterinary AZ reports

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryCasesReport", 440)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinaryCasesReportAZ();

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryLaboratoriesAZ", 450)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinaryLaboratoriesAZ();

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryFormVet1", 460)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinaryFormVet1();

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryFormVet1A", 470)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinaryFormVet1A();

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinarySummaryAZ", 480)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinarySummaryAZ();

        #endregion

        #region ARM reports

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN85Annual", 500)]
        [MenuReportCustomization(CustomizationPackage.Armenia)]
        void HumFormN85Annual();

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN85Monthly", 510)]
        [MenuReportCustomization(CustomizationPackage.Armenia)]
        void HumFormN85Monthly();

        #endregion

        #region IQ reports

        [MenuReportDescription(ReportSubMenu.Human, "WeeklySituationDiseasesByDistricts", 610)]
        [MenuReportCustomization(CustomizationPackage.Iraq)]
        void WeeklySituationDiseasesByDistricts();

        [MenuReportDescription(ReportSubMenu.Human, "WeeklySituationDiseasesByAgeGroupAndSex", 620)]
        [MenuReportCustomization(CustomizationPackage.Iraq)]
        void WeeklySituationDiseasesByAgeGroupAndSex();

        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeIQReport", 630)]
        [MenuReportCustomization(CustomizationPackage.Iraq)]
        void HumComparativeIQReport();

        #endregion

        #region Veterinary reports

        void VetAggregateCase(AggregateReportParameters aggrParams);
        void VetAggregateCaseSummary(AggregateSummaryReportParameters aggrParams);
        void VetAggregateCaseActions(AggregateActionsParameters aggrParams);
        void VetAggregateCaseActionsSummary(AggregateActionsSummaryParameters aggrParams);

        void VetAvianInvestigation(long caseId, long diagnosisId);
        void VetLivestockInvestigation(long caseId, long diagnosisId);
        void VetActiveSurveillanceSampleCollected(long id);

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetSamplesCount", 1310)]
        [MenuReportCustomization(
            Forbidden = new[] {CustomizationPackage.DTRA, CustomizationPackage.Georgia, CustomizationPackage.Azerbaijan})]
        void VetSamplesCount();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetSamplesReportBySampleType", 1320)]
        [MenuReportCustomization(
            Forbidden = new[] {CustomizationPackage.DTRA, CustomizationPackage.Georgia, CustomizationPackage.Azerbaijan})]
        void VetSamplesBySampleType();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetSamplesReportBySampleTypesWithinRegions", 1330)]
        [MenuReportCustomization(
            Forbidden = new[] {CustomizationPackage.DTRA, CustomizationPackage.Georgia, CustomizationPackage.Azerbaijan})]
        void VetSamplesBySampleTypesWithinRegions();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetRabiesBulletinEurope", 1335)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void VetRabiesBulletinEurope();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetYearlySituation", 1340)]
        [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Azerbaijan})]
        void VetYearlySituation();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsActiveSurveillance", 1350)]
        [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Azerbaijan})]
        void VetActiveSurveillance();

        #endregion

        #region Human KZ reports

        [MenuReportDescription(ReportSubMenu.Human, "HumInfectiousParasiticKZ", 500)]
        [MenuReportCustomization(CustomizationPackage.KazakhstanMoH)]
        void HumInfectiousParasiticKZ();
        #endregion
        
        #region Veterinary KZ reports

        [MenuReportDescription(ReportSubMenu.Vet, "VetCountryPlannedDiagnosticTestsReport", 450)]
        [MenuReportCustomization(CustomizationPackage.KazakhstanMoA)]
        void VetCountryPlannedDiagnosticTests();

        [MenuReportDescription(ReportSubMenu.Vet, "VetRegionPlannedDiagnosticTestsReport", 460)]
        [MenuReportCustomization(CustomizationPackage.KazakhstanMoA)]
        void VetOblastPlannedDiagnosticTests();

        [MenuReportDescription(ReportSubMenu.Vet, "VetCountryPreventiveMeasuresReport", 470)]
        [MenuReportCustomization(CustomizationPackage.KazakhstanMoA)]
        void VetCountryPreventiveMeasures();

        [MenuReportDescription(ReportSubMenu.Vet, "VetRegionPreventiveMeasuresReport", 480)]
        [MenuReportCustomization(CustomizationPackage.KazakhstanMoA)]
        void VetOblastPreventiveMeasures();

        [MenuReportDescription(ReportSubMenu.Vet, "VetCountryProphilacticMeasuresReport", 490)]
        [MenuReportCustomization(CustomizationPackage.KazakhstanMoA)]
        void VetCountrySanitaryMeasures();

        [MenuReportDescription(ReportSubMenu.Vet, "VetRegionProphilacticMeasuresReport", 500)]
        [MenuReportCustomization(CustomizationPackage.KazakhstanMoA)]
        void VetOblastSanitaryMeasures();

        #endregion

        #region Lab module reports

        void LimSampleTransfer(long id);

        void LimTestResult(long id, long csId, long typeId);
        void LimTest(long id, bool isHuman);
        void LimBatchTest(long id, long typeId);
        void LimSample(long id);
        void LimContainerContent(long? contId, long? freeserId);
        void LimAccessionIn(long caseId);
        void LimSampleDestruction(IEnumerable<long> sampleId);

        #endregion

        void Outbreak(long id);

        void VectorSurveillanceSessionSummary(long id);

        [MenuReportDescription(ReportSubMenu.Admin, "ReportsAdmEventLog", 100)]
        [MenuReportCustomization]
        void AdmEventLog();
    }
}