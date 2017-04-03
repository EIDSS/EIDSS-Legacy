using System;
using System.ServiceModel;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Service.WcfFacade
{
    [ServiceContract]
    public interface IReportFacade
    {
        #region Common Human Reports

        [OperationContract]
        byte[] ExportHumAggregateCase( AggregateModel model);

        [OperationContract]
        byte[] ExportHumAggregateCaseSummary( AggregateSummaryModel model);

        [OperationContract]
        byte[] ExportHumCaseInvestigation( HumIdModel model);

        [OperationContract]
        byte[] ExportHumUrgentyNotification( BaseIdModel model);

        [OperationContract]
        byte[] ExportHumDiagnosisToChangedDiagnosis( BaseIntervalModel model);

        [OperationContract]
        byte[] ExportHumMonthlyMorbidityAndMortality( BaseDateModel model);

        [OperationContract]
        byte[] ExportHumSummaryOfInfectiousDiseases( BaseIntervalModel model);

        #endregion

        #region Human GG reports

        [OperationContract]
        byte[] ExportHumSerologyResearchCard( LabSampleModel model);

        [OperationContract]
        byte[] ExportHumMicrobiologyResearchCard( LabSampleModel model);

        [OperationContract]
        byte[] ExportHumAntibioticResistanceCard( LabSampleModel model);

        [OperationContract]
        byte[] ExportHum60BJournal( Hum60BJournalModel model);

        [OperationContract]
        byte[] ExportHumMonthInfectiousDisease( MonthInfectiousDiseaseModel model);

        [OperationContract]
        byte[] ExportHumMonthInfectiousDiseaseNew( MonthInfectiousDiseaseModel model);

        [OperationContract]
        byte[] ExportHumIntermediateMonthInfectiousDisease( IntermediateInfectiousDiseaseSurrogateModel model);

        [OperationContract]
        byte[] ExportHumIntermediateMonthInfectiousDiseaseNew
            ( IntermediateInfectiousDiseaseSurrogateModel model);

        [OperationContract]
        byte[] ExportHumAnnualInfectiousDisease( AnnualInfectiousDiseaseModel model);

        [OperationContract]
        byte[] ExportHumIntermediateAnnualInfectiousDisease( IntermediateInfectiousDiseaseSurrogateModel model);

        #endregion

        #region Human AZ reports

        [OperationContract]
        byte[] ExportHumFormN1( FormNo1SurrogateModel model);

        [OperationContract]
        byte[] ExportHumDataQualityIndicators( DataQualityIndicatorsModel model);

        [OperationContract]
        byte[] ExportHumDataQualityIndicatorsRayons( DataQualityIndicatorsModel model);

        [OperationContract]
        byte[] ExportHumSummaryByRayonDiagnosisAgeGroups( SummaryByRayonDiagnosisAgeGroupsModel model);

        [OperationContract]
        byte[] ExportHumComparativeAZReport( ComparativeSurrogateModel model);

        [OperationContract]
        byte[] ExportHumExternalComparativeReport( ExternalComparativeSurrogateModel model);

        [OperationContract]
        byte[] ExportHumMainIndicatorsOfAFPSurveillance( AFPModel model);

        [OperationContract]
        byte[] ExportHumAdditionalIndicatorsOfAFPSurveillance( AFPModel model);

        [OperationContract]
        byte[] ExportHumWhoMeaslesRubellaReport( BaseDateModel model);

        [OperationContract]
        byte[] ExportHumComparativeReportOfTwoYears(ComparativeTwoYearsSurrogateModel model);

        #endregion

        #region Veterinary AZ reports

        [OperationContract]
        byte[] ExportVeterinaryCasesReport( VetCasesSurrogateModel model);

        [OperationContract]
        byte[] ExportVeterinaryLaboratoriesAZReport(VetLabSurrogateModel model);

        #endregion

        #region Common Veterinary reports

        [OperationContract]
        byte[] ExportVetAggregateCase( AggregateModel model);

        [OperationContract]
        byte[] ExportVetAggregateCaseSummary( AggregateSummaryModel model);

        [OperationContract]
        byte[] ExportVetAggregateCaseActions( AggregateActionsModel model);

        [OperationContract]
        byte[] ExportVetAggregateCaseActionsSummary( AggregateActionsSummaryModel model);

        [OperationContract]
        byte[] ExportVetAvianInvestigation( VetIdModel model);

        [OperationContract]
        byte[] ExportVetLivestockInvestigation( VetIdModel model);

        [OperationContract]
        byte[] ExportVetActiveSurveillanceSampleCollected( BaseIdModel model);

        [OperationContract]
        byte[] ExportVetSamplesCount( BaseYearModel model);

        [OperationContract]
        byte[] ExportVetSamplesBySampleType( BaseYearModel model);

        [OperationContract]
        byte[] ExportVetSamplesBySampleTypesWithinRegions( BaseYearModel model);

        [OperationContract]
        byte[] ExportVetYearlySituation( BaseYearModel model);

        [OperationContract]
        byte[] ExportVetActiveSurveillance( BaseYearModel model);

        #endregion

        #region KZ Veterinary reports

        [OperationContract]
        byte[] ExportVetCountryPreventiveMeasures( ProphylacticModel model);

        [OperationContract]
        byte[] ExportVetCountrySanitaryMeasures( SanitaryModel model);

        [OperationContract]
        byte[] ExportVetCountryPlannedDiagnosticTests( DiagnosticInvestigationModel model);

        [OperationContract]
        byte[] ExportVetOblastPreventiveMeasures( ProphylacticModel model);

        [OperationContract]
        byte[] ExportVetOblastSanitaryMeasures( SanitaryModel model);

        [OperationContract]
        byte[] ExportVetOblastPlannedDiagnosticTests( DiagnosticInvestigationModel model);

        #endregion

        #region Lab module reports

        [OperationContract]
        byte[] ExportLimTestResult( LimTestResultModel model);

        [OperationContract]
        byte[] ExportLimSampleTransfer( BaseIdModel model);

        [OperationContract]
        byte[] ExportLimTest( LimTestModel model);

        [OperationContract]
        byte[] ExportLimBatchTest( LimBatchTestModel model);

        [OperationContract]
        byte[] ExportLimContainerDetails( BaseIdModel model);

        [OperationContract]
        byte[] ExportLimContainerContent( LimContainerContentModel model);

        [OperationContract]
        byte[] ExportLimAccessionIn( BaseIdModel model);

        #endregion

        #region  Outbreak reports

        [OperationContract]
        byte[] ExportOutbreak( BaseIdModel model);

        #endregion

        #region Administrative reports

        [OperationContract]
        byte[] ExportAdmEventLog( BaseIntervalModel model);

        #endregion


        #region Vector Surveillance reports

        byte[] ExportVectorSurveillanceSessionSummary(BaseIdModel model);

        #endregion

        [OperationContract]
        Version GetServiceVersion();
    }
}