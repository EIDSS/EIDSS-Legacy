using eidss.model.Enums;

namespace eidss.model.Reports
{
    public interface IReportFactory
    {
        void ResetLanguage();

        #region Common Human Reports

        void HumAggregateCase(AggregateReportParameters aggrParams);
        void HumAggregateCaseSummary(AggregateSummaryReportParameters aggrParams);

        void HumCaseInvestigation(long caseId, long epiId, long csId, long diagnosisId);
        void HumUrgentyNotification(long caseId);

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumDiagnosisToChangedDiagnosis", 400)]
        [MenuReportCustomization(PresentInDtraCustomization = true, ForbiddenCountry = new[] {Country.Azerbaijan})]
        void HumDiagnosisToChangedDiagnosis();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumMonthlyMorbidityAndMortality", 390)]
        [MenuReportCustomization(PresentInDtraCustomization = true, ForbiddenCountry = new[] {Country.Azerbaijan})]
        void HumMonthlyMorbidityAndMortality();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumSummaryOfInfectiousDiseases", 240)]
        [MenuReportCustomization(ForbiddenCountry = new[] {Country.Georgia, Country.Azerbaijan})]
        void HumSummaryOfInfectiousDiseases();

        #endregion

        #region Human GG reports

        [MenuReportDescription(ReportSubMenu.Human, "ReportsJournal60BReportCard", 320)]
        [MenuReportCustomization(Country.Georgia)]
        void Hum60BJournal();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumInfectiousDiseaseMonth", 370)]
        [MenuReportCustomization(Country.Georgia)]
        void HumMonthInfectiousDisease();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumInfectiousDiseaseMonthNew", 330)]
        [MenuReportCustomization(Country.Georgia)]
        void HumMonthInfectiousDiseaseNew();

        [MenuReportDescription(ReportSubMenu.Human, "HumInfectiousDiseaseIntermediateMonth", 380)]
        [MenuReportCustomization(Country.Georgia)]
        void HumIntermediateMonthInfectiousDisease();

        [MenuReportDescription(ReportSubMenu.Human, "HumInfectiousDiseaseIntermediateMonthNew", 340)]
        [MenuReportCustomization(Country.Georgia)]
        void HumIntermediateMonthInfectiousDiseaseNew();

        [MenuReportDescription(ReportSubMenu.Human, "ReportsHumInfectiousDiseaseYear", 350)]
        [MenuReportCustomization(Country.Georgia)]
        void HumAnnualInfectiousDisease();

        [MenuReportDescription(ReportSubMenu.Human, "HumInfectiousDiseaseIntermediateYear", 360)]
        [MenuReportCustomization(Country.Georgia)]
        void HumIntermediateAnnualInfectiousDisease();

        [MenuReportDescription(ReportSubMenu.Lab, "ReportsHumSerologyResearchCard", 410)]
        [MenuReportCustomization(Country.Georgia)]
        [ForbiddenDataGroup(PersonalDataGroup.Human_PersonName, PersonalDataGroup.Human_PersonAge)]
        void HumSerologyResearchCard();

        [MenuReportDescription(ReportSubMenu.Lab, "ReportsHumMicrobiologyResearchCard", 420)]
        [MenuReportCustomization(Country.Georgia)]
        [ForbiddenDataGroup(PersonalDataGroup.Human_PersonName, PersonalDataGroup.Human_PersonAge)]
        void HumMicrobiologyResearchCard();

        [MenuReportDescription(ReportSubMenu.Lab, "HumAntibioticResistanceCard", 430)]
        [MenuReportCustomization(Country.Georgia)]
        void HumAntibioticResistanceCard();

        #endregion

        #region Human AZ reports

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN1A3", 260)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumFormN1A3();

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN1A4", 270)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumFormN1A4();

 
        //[MenuReportDescription(ReportSubMenu.Human, "HumDataQualityIndicators", 280, Permission = EIDSSPermissionObject.Report)]
        [MenuReportCustomization(Country.Azerbaijan)]
//        [MenuReportCustomization(PresentInDtraCustomization = true)]
        [MenuReportDescription(ReportSubMenu.Human, "HumDataQualityIndicators", 280, Permission = EIDSSPermissionObject.CanSignReport)]
        void HumDataQualityIndicators();

        [MenuReportDescription(ReportSubMenu.Human, "HumDataQualityIndicatorsRayons", 285)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumDataQualityIndicatorsRayons();

        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeReport", 290)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumComparativeAZReport();

        [MenuReportDescription(ReportSubMenu.Human, "HumSummaryByRayonDiagnosisAgeGroups", 300)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumSummaryByRayonDiagnosisAgeGroups();

        [MenuReportDescription(ReportSubMenu.Human, "HumExternalComparativeReport", 310)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumExternalComparativeReport();

        [MenuReportDescription(ReportSubMenu.Human, "HumMainIndicatorsOfAFPSurveillance", 320)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumMainIndicatorsOfAFPSurveillance();

        [MenuReportDescription(ReportSubMenu.Human, "HumAdditionalIndicatorsOfAFPSurveillance", 330)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumAdditionalIndicatorsOfAFPSurveillance();

        [MenuReportDescription(ReportSubMenu.Human, "HumWhoMeaslesRubellaReport", 340)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumWhoMeaslesRubellaReport();


        // todo: [ivan] uncomment after testing patch
        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeReportOfTwoYears", 350)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void HumComparativeReportOfTwoYears();

        #endregion

        #region Veterinary AZ reports

        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryCasesReport", 440)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void VeterinaryCasesReportAZ();

     
        [MenuReportDescription(ReportSubMenu.Vet, "VeterinaryLaboratoriesAZ", 450)]
        [MenuReportCustomization(Country.Azerbaijan)]
        void VeterinaryLaboratoriesAZ();

        #endregion

        #region ARM reports

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN85Annual", 500)]
        [MenuReportCustomization(Country.Armenia)]
        void HumFormN85Annual();

        [MenuReportDescription(ReportSubMenu.Human, "HumFormN85Monthly", 510)]
        [MenuReportCustomization(Country.Armenia)]
        void HumFormN85Monthly();

        #endregion

        #region IQ reports

        [MenuReportDescription(ReportSubMenu.Human, "WeeklySituationDiseasesByDistricts", 610)]
        [MenuReportCustomization(Country.Iraq)]
        void WeeklySituationDiseasesByDistricts();

        [MenuReportDescription(ReportSubMenu.Human, "WeeklySituationDiseasesByAgeGroupAndSex", 620)]
        [MenuReportCustomization(Country.Iraq)]
        void WeeklySituationDiseasesByAgeGroupAndSex();

        [MenuReportDescription(ReportSubMenu.Human, "HumComparativeIQReport", 630)]
        [MenuReportCustomization(Country.Iraq)]
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
        [MenuReportCustomization(ForbiddenCountry = new[] {Country.Georgia, Country.Azerbaijan})]
        void VetSamplesCount();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetSamplesReportBySampleType", 1320)]
        [MenuReportCustomization(ForbiddenCountry = new[] {Country.Georgia, Country.Azerbaijan})]
        void VetSamplesBySampleType();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetSamplesReportBySampleTypesWithinRegions", 1330)]
        [MenuReportCustomization(ForbiddenCountry = new[] {Country.Georgia, Country.Azerbaijan})]
        void VetSamplesBySampleTypesWithinRegions();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsVetYearlySituation", 1340)]
        [MenuReportCustomization(PresentInDtraCustomization = true, ForbiddenCountry = new[] { Country.Azerbaijan })]
        void VetYearlySituation();

        [MenuReportDescription(ReportSubMenu.Vet, "ReportsActiveSurveillance", 1350)]
        [MenuReportCustomization(PresentInDtraCustomization = true, ForbiddenCountry = new[] { Country.Azerbaijan })]
        void VetActiveSurveillance();

        #endregion

        #region Veterinary KZ reports

        [MenuReportDescription(ReportSubMenu.Vet, "VetCountryPlannedDiagnosticTestsReport", 450)]
        [MenuReportCustomization(Country.Kazakhstan)]
        void VetCountryPlannedDiagnosticTests();


        [MenuReportDescription(ReportSubMenu.Vet, "VetRegionPlannedDiagnosticTestsReport", 460)]
        [MenuReportCustomization(Country.Kazakhstan)]
        void VetOblastPlannedDiagnosticTests();

        [MenuReportDescription(ReportSubMenu.Vet, "VetCountryPreventiveMeasuresReport", 470)]
        [MenuReportCustomization(Country.Kazakhstan)]
        void VetCountryPreventiveMeasures();

        [MenuReportDescription(ReportSubMenu.Vet, "VetRegionPreventiveMeasuresReport", 480)]
        [MenuReportCustomization(Country.Kazakhstan)]
        void VetOblastPreventiveMeasures();

        [MenuReportDescription(ReportSubMenu.Vet, "VetCountryProphilacticMeasuresReport", 490)]
        [MenuReportCustomization(Country.Kazakhstan)]
        void VetCountrySanitaryMeasures();

        [MenuReportDescription(ReportSubMenu.Vet, "VetRegionProphilacticMeasuresReport", 500)]
        [MenuReportCustomization(Country.Kazakhstan)]
        void VetOblastSanitaryMeasures();
        

        #endregion

        #region Lab module reports

        void LimSampleTransfer(long id);

        void LimTestResult(long id, long csId, long typeId);
        void LimTest(long id, bool isHuman);
        void LimBatchTest(long id, long typeId);
        void LimContainerDetails(long id);
        void LimContainerContent(long? contId, long? freeserId);

        void LimAccessionIn(long caseId);

        #endregion

        void Outbreak(long id);


        void VectorSurveillanceSessionSummary(long id);



        [MenuReportCustomization(PresentInDtraCustomization = true)]
        [MenuReportDescription(ReportSubMenu.Admin, "ReportsAdmEventLog", 100)]
        void AdmEventLog();



    }
}