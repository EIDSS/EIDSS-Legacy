using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Enums;

namespace eidss.model.Reports
{
    public interface IReportFactory
    {
        void ResetLanguage();

        #region Common Human Reports

        [MenuReportCustomization]
        void HumAggregateCase(AggregateReportParameters aggrParams);
        [MenuReportCustomization]
        void HumAggregateCaseSummary(AggregateSummaryReportParameters aggrParams);

        [MenuReportCustomization]
        void HumCaseInvestigation(long caseId, long epiId, long csId, long diagnosisId);

        [MenuReportCustomization(Forbidden = new[] { CustomizationPackage.Tanzania})]
        void HumUrgentyNotification(long caseId);

        [MenuReportCustomization(CustomizationPackage.Tanzania)]
        void HumUrgentyNotificationTanzania(long caseId);

        [MenuReportCustomization(CustomizationPackage.DTRA)]
        void HumUrgentyNotificationDTRA(long caseId);

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumDiagnosisToChangedDiagnosis", 400)]
        [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Azerbaijan})]
        void HumDiagnosisToChangedDiagnosis();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumMonthlyMorbidityAndMortality", 390)]
        [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Azerbaijan})]
        void HumMonthlyMorbidityAndMortality();

        #endregion

        #region Common Veterinary reports
        [MenuReportCustomization]
        void VetAggregateCase(AggregateReportParameters aggrParams);
        [MenuReportCustomization]
        void VetAggregateCaseSummary(AggregateSummaryReportParameters aggrParams);
        [MenuReportCustomization]
        void VetAggregateCaseActions(AggregateActionsParameters aggrParams);
        [MenuReportCustomization]
        void VetAggregateCaseActionsSummary(AggregateActionsSummaryParameters aggrParams);

        [MenuReportCustomization]
        void VetAvianInvestigation(long caseId, long diagnosisId, bool includeMap);
        [MenuReportCustomization]
        void VetLivestockInvestigation(long caseId, long diagnosisId, bool includeMap);
        [MenuReportCustomization]
        void VetActiveSurveillanceSampleCollected(long id);

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetSamplesCount", 1310)]
        [MenuReportCustomization(
            Forbidden = new[]
            {
                CustomizationPackage.DTRA, CustomizationPackage.Georgia,
                CustomizationPackage.Azerbaijan, CustomizationPackage.Thailand,
                CustomizationPackage.Armenia
            })]
        void VetSamplesCount();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetSamplesReportBySampleType", 1320)]
        [MenuReportCustomization(
            Forbidden = new[]
            {
                CustomizationPackage.DTRA, CustomizationPackage.Georgia,
                CustomizationPackage.Azerbaijan, CustomizationPackage.Thailand,
                CustomizationPackage.Armenia
            })]
        void VetSamplesBySampleType();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetSamplesReportBySampleTypesWithinRegions", 1330)]
        [MenuReportCustomization(
            Forbidden = new[]
            {
                CustomizationPackage.DTRA, CustomizationPackage.Georgia,
                CustomizationPackage.Azerbaijan, CustomizationPackage.Thailand,
                CustomizationPackage.Armenia
            })]
        void VetSamplesBySampleTypesWithinRegions();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetYearlySituation", 1340)]
        [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Azerbaijan, CustomizationPackage.Thailand})]
        void VetYearlySituation();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsActiveSurveillance", 1350)]
        [MenuReportCustomization(Forbidden = new[] {CustomizationPackage.Azerbaijan, CustomizationPackage.Thailand})]
        void VetActiveSurveillance();

        #endregion

        #region Common Syndromic Surviellance

        [MenuReportDescription(ReportSubMenu.Aberration, "ReportsHumAberrationAnalysis", 60000, (int) MenuIconsSmall.HumanAberrationReport)]
        [MenuReportCustomization(AbsentInWeb = true, Forbidden = new[] {CustomizationPackage.Azerbaijan})]
        void HumAberrationAnalysis();

        [MenuReportDescription(ReportSubMenu.Aberration, "ReportsVetAberrationAnalysis", 60001, (int) MenuIconsSmall.VetAberrationReport)]
        [MenuReportCustomization(AbsentInWeb = true, Forbidden = new[] {CustomizationPackage.Thailand, CustomizationPackage.Azerbaijan})]
        void VetAberrationAnalysis();

        [MenuReportDescription(ReportSubMenu.Aberration, "ReportsSyndrAberrationAnalysis", 60002, (int) MenuIconsSmall.BssAberrationReport)]
        [MenuReportCustomization(AbsentInWeb = true,
            Forbidden = new[] {CustomizationPackage.Thailand, CustomizationPackage.Armenia, CustomizationPackage.Azerbaijan})]
        void SyndrAberrationAnalysis();

        [MenuReportDescription(ReportSubMenu.Aberration, "ReportsILISyndrAberrationAnalysis", 6000, (int) MenuIconsSmall.BssAggregateList)]
        [MenuReportCustomization(AbsentInWeb = true,
            Forbidden = new[] {CustomizationPackage.Thailand, CustomizationPackage.Armenia, CustomizationPackage.Azerbaijan})]
        void ILISyndrAberrationAnalysis();

        #endregion

        #region Common Lab module reports

        [MenuReportCustomization]
        void LimSampleTransfer(long id);

        [MenuReportCustomization]
        void LimTestResult(long id, long csId, long typeId);
        [MenuReportCustomization]
        void LimTest(long id, bool isHuman);
        [MenuReportCustomization]
        void LimBatchTest(long id, long typeId);
        [MenuReportCustomization]
        void LimSample(long id);
        [MenuReportCustomization]
        void LimContainerContent(long? contId, long? freeserId);
        [MenuReportCustomization]
        void LimAccessionIn(long caseId);
        [MenuReportCustomization]
        void LimSampleDestruction(IEnumerable<long> sampleId);

        #endregion

        #region Other reports

        [MenuReportCustomization]
        void Outbreak(long id);

        [MenuReportCustomization]
        void VectorSurveillanceSessionSummary(long id);

        [MenuReportDescription(ReportSubMenu.Admin, "ReportsAdmEventLog", 100)]
        [MenuReportCustomization]
        void AdmEventLog();

        #endregion

        #region Human GG reports

        [MenuReportDescription(ReportSubMenu.Human, "ReportsJournal60BReportCard", 320)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void Hum60BJournal();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "ReportsHumInfectiousDiseaseMonthV4", 370,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase})]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumMonthInfectiousDiseaseV4();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "ReportsHumInfectiousDiseaseMonthV5", 343,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase})]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumMonthInfectiousDiseaseV5();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "ReportsHumInfectiousDiseaseMonthV6", 333,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase})]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumMonthInfectiousDiseaseV6();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumInfectiousDiseaseMonthV61", 333,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase})]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumMonthInfectiousDiseaseV61();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "HumInfectiousDiseaseIntermediateMonthV4", 380,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase})]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumIntermediateMonthInfectiousDiseaseV4();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "HumInfectiousDiseaseIntermediateMonthV5", 345,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase})]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumIntermediateMonthInfectiousDiseaseV5();

        [MenuReportDescription(ReportSubMenu.HumanGGOldRevision, "HumInfectiousDiseaseIntermediateMonthV6", 335,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase})]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumIntermediateMonthInfectiousDiseaseV6();

        [MenuReportDescription(ReportSubMenu.Human, "HumInfectiousDiseaseIntermediateMonthV61", 340,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase})]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void HumIntermediateMonthInfectiousDiseaseV61();

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

        #region Vet GG reports

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetRabiesBulletinEurope", 1335)]
        [MenuReportCustomization(CustomizationPackage.Georgia)]
        void VetRabiesBulletinEurope();

        #endregion

        #region Human AZ reports

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN1A3", 260)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumFormN1A3();

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN1A4", 270)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumFormN1A4();

        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        [MenuReportDescription(ReportSubMenu.Human, "HumDataQualityIndicators", 280,
            PermissionObjects = new[] {EIDSSPermissionObject.CanSignReport},
            PermissionActions = new[] {PermissionHelper.Execute})]
        void HumDataQualityIndicators();

        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeReport", 320)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumComparativeAZReport();

        [MenuReportDescription(ReportSubMenu.Human, "HumExternalComparativeReport", 330)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumExternalComparativeReport();

        [MenuReportDescription(ReportSubMenu.Human, "HumSummaryByRayonDiagnosisAgeGroups", 340)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumSummaryByRayonDiagnosisAgeGroups();

        [MenuReportDescription(ReportSubMenu.Human, "HumMainIndicatorsOfAFPSurveillance", 360)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumMainIndicatorsOfAFPSurveillance();

        [MenuReportDescription(ReportSubMenu.Human, "HumAdditionalIndicatorsOfAFPSurveillance", 370)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumAdditionalIndicatorsOfAFPSurveillance();

        [MenuReportDescription(ReportSubMenu.Human, "HumWhoMeaslesRubellaReport", 380)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumWhoMeaslesRubellaReport();

        #endregion

        #region Lab AZ reports

        [MenuReportDescription(ReportSubMenu.Lab, "AssignmentLabDiagnosticAZ", 360,
            PermissionObjects = new[] {EIDSSPermissionObject.HumanCase},
            PermissionActions = new[] {PermissionHelper.Select})]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void AssignmentLabDiagnosticAZ();

        [MenuReportDescription(ReportSubMenu.Lab, "LabTestingResultsAZ", 370)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void LabTestingResultsAZ();

        #endregion

        #region Veterinary AZ reports

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryFormVet1", 440, PermissionObjects = new []{EIDSSPermissionObject.VetCase})]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinaryFormVet1();

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryFormVet1A", 450,
            PermissionObjects =
                new[]
                {
                    EIDSSPermissionObject.VetCase, EIDSSPermissionObject.AccessToVetAggregateAction,
                    EIDSSPermissionObject.MonitoringSession
                })]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinaryFormVet1A();

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinarySummaryAZ", 460,
            PermissionObjects =
                new[]
                {
                    EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase,
                    EIDSSPermissionObject.AccessToVetAggregateAction
                })]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinarySummaryAZ();

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryLaboratoriesAZ", 470)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinaryLaboratoriesAZ();

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryCasesReport", 480)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void VeterinaryCasesReportAZ();

        #endregion

        #region Zoonotic AZ reports

        [MenuReportDescription(ReportSubMenu.Zoonotic, "ZoonoticComparativeAZ", 360)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void ZoonoticComparativeAZ();

        #endregion

        #region Simplified AZ reports

        [MenuReportDescription(ReportSubMenu.Simplified, "HumDataQualityIndicatorsRayons", 290)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumDataQualityIndicatorsRayons();

        [MenuReportDescription(ReportSubMenu.Simplified, "HumBorderRayonsComparativeReport", 300,
            PermissionObjects = new[] {EIDSSPermissionObject.HumanCase},
            PermissionActions = new[] {PermissionHelper.Insert})]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumBorderRayonsComparativeReport();

        [MenuReportDescription(ReportSubMenu.Simplified, "HumComparativeReportOfTwoYears", 310,
            PermissionObjects = new[] {EIDSSPermissionObject.HumanCase},
            PermissionActions = new[] {PermissionHelper.Insert})]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumComparativeReportOfTwoYears();

        [MenuReportDescription(ReportSubMenu.Simplified, "HumTuberculosisCasesTested", 350,
            PermissionObjects = new[] {EIDSSPermissionObject.HumanCase},
            PermissionActions = new[] {PermissionHelper.Insert})]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void HumTuberculosisCasesTested();

        // note: dublicate of ZoonoticComparativeAZ in menu "Simplified"
        [MenuReportDescription(ReportSubMenu.Simplified, "ZoonoticComparativeAZ", 360)]
        [MenuReportCustomization(CustomizationPackage.Azerbaijan)]
        void SimplifiedComparativeAZ();

        #endregion

        #region TH reports

        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeReportOfSeveralYearsTH", 100,
            PermissionObjects = new[] {EIDSSPermissionObject.HumanCase},
            PermissionActions = new[] {PermissionHelper.Insert})]
        [MenuReportCustomization(CustomizationPackage.Thailand)]
        void HumComparativeReportOfSeveralYearsTH();

        [MenuReportDescription(ReportSubMenu.Human, "HumReportedCasesDeathsByProvinceMonthTH", 200,
            PermissionObjects = new[] {EIDSSPermissionObject.HumanCase},
            PermissionActions = new[] {PermissionHelper.Insert})]
        [MenuReportCustomization(CustomizationPackage.Thailand)]
        void HumReportedCasesDeathsByProvinceMonthTH();

        [MenuReportDescription(ReportSubMenu.Human, "HumNumberOfCasesDeathsMorbidityMortalityTH", 300,
            PermissionObjects = new[] {EIDSSPermissionObject.HumanCase},
            PermissionActions = new[] {PermissionHelper.Insert})]
        [MenuReportCustomization(CustomizationPackage.Thailand)]
        void HumNumberOfCasesDeathsMorbidityMortalityTH();

        #endregion

        #region ARM reports

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN85", 500,
            PermissionObjects = new[] {EIDSSPermissionObject.AccessToHumanAggregateCase, EIDSSPermissionObject.HumanCase},
            PermissionActions = new[] {PermissionHelper.Insert})]
        [MenuReportCustomization(CustomizationPackage.Armenia)]
        void HumFormN85();

        #endregion

        #region IQ reports

        [MenuReportDescription(ReportSubMenu.Human, "WeeklySituationDiseasesByDistricts", 610)]
        [MenuReportCustomization(CustomizationPackage.Iraq)]
        void WeeklySituationDiseasesByDistricts();

        [MenuReportDescription(ReportSubMenu.Human, "MonthlySituationDiseasesByDistricts", 620)]
        [MenuReportCustomization(CustomizationPackage.Iraq)]
        void MonthlySituationDiseasesByDistricts();

        [MenuReportDescription(ReportSubMenu.Human, "WeeklySituationDiseasesByAgeGroupAndSex", 630)]
        [MenuReportCustomization(CustomizationPackage.Iraq)]
        void WeeklySituationDiseasesByAgeGroupAndSex();

        [MenuReportDescription(ReportSubMenu.Human, "MonthlySituationDiseasesByAgeGroupAndSex", 640)]
        [MenuReportCustomization(CustomizationPackage.Iraq)]
        void MonthlySituationDiseasesByAgeGroupAndSex();

        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeIQReport", 650)]
        [MenuReportCustomization(CustomizationPackage.Iraq)]
        void HumComparativeIQReport();

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
    }
}