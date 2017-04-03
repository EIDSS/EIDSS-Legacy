using System;
using System.Collections.Generic;
using System.Diagnostics;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.ActiveSurveillance;
using EIDSS.Reports.Document.Human.Aggregate;
using EIDSS.Reports.Document.Human.CaseInvestigation;
using EIDSS.Reports.Document.Human.EmergencyNotification;
using EIDSS.Reports.Document.Lim.Batch;
using EIDSS.Reports.Document.Lim.Case;
using EIDSS.Reports.Document.Lim.ContainerContent;
using EIDSS.Reports.Document.Lim.ContainerDetails;
using EIDSS.Reports.Document.Lim.TestResult;
using EIDSS.Reports.Document.Lim.Transfer;
using EIDSS.Reports.Document.Uni.AccessionIn;
using EIDSS.Reports.Document.Uni.Outbreak;
using EIDSS.Reports.Document.Veterinary.Aggregate;
using EIDSS.Reports.Document.Veterinary.AvianInvestigation;
using EIDSS.Reports.Document.Veterinary.LivestockInvestigation;
using EIDSS.Reports.Parameterized.ActiveSurveillance;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using EIDSS.Reports.Parameterized.Human.ARM.Report;
using EIDSS.Reports.Parameterized.Human.DSummary;
using EIDSS.Reports.Parameterized.Human.DToChangedD;
using EIDSS.Reports.Parameterized.Human.GG.Report;
using EIDSS.Reports.Parameterized.Human.MMM;
using EIDSS.Reports.Parameterized.Uni.EventLog;
using EIDSS.Reports.Parameterized.Veterinary.KZ;
using EIDSS.Reports.Parameterized.Veterinary.SamplesCount;
using EIDSS.Reports.Parameterized.Veterinary.SamplesType;
using EIDSS.Reports.Parameterized.Veterinary.Situation;
using EIDSS.Reports.Parameterized.Veterinary.TestType;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;

namespace bv.tests.Reports
{
    [TestClass]
    public class GenerateTests : EidssEnvWithLogin
    {
        private readonly Dictionary<string, string> m_ObjIdParameters = new Dictionary<string, string> {{"@ObjID", "1"}};

        private const string AggrXml =
            @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""satCountry""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""sptYear""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2011-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>";

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void HumAggregateCase()
        {
            var parameters = new Dictionary<string, string>
                                 {{"@ObjID", "1"}, {"@observationId", "2"}, {"@idFormTemplate", "3"}, {"@idfsAggrCaseType", "4"}};

            SetReportParameters(new CaseAggregateReport(), parameters);
        }

        [TestMethod]
        public void HumAggregateCaseSummary()
        {
            SetReportParameters(new SummaryAggregateReport(), new Dictionary<string, string> {{"@AggrXml", AggrXml}});
        }

        [TestMethod]
        public void HumCaseInvestigation()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     {"@ObjID", "1"},
                                     {"@EPIObjID", "2"},
                                     {"@CSObjID", "3"},
                                     {"@DiagnosisID", "4"}
                                 };
            SetReportParameters(new CaseInvestigationReport(), parameters);
        }

        [TestMethod]
        public void HumUrgentyNotification()
        {
            SetReportParameters(new EmergencyNotificationReport(), m_ObjIdParameters);
        }

        [TestMethod]
        public void HumDiagnosisToChangedDiagnosis()
        {
            SetReportParameters(new DToChangedDReport());
        }

        [TestMethod]
        public void HumMonthlyMorbidityAndMortality()
        {
            SetReportParameters(new MMMReport());
        }

        [TestMethod]
        public void HumSummaryOfInfectiousDiseases()
        {
            SetReportParameters(new DSummaryReport());
        }

        #region Human GG reports

        [TestMethod]
        public void HumSerologyResearchCard()
        {
            SetReportParameters(new SerologyResearchCardReport());
        }

        [TestMethod]
        public void HumMicrobiologyResearchCard()
        {
            SetReportParameters(new MicrobiologyResearchCardReport());
        }

        [TestMethod]
        public void HumAntibioticResistanceCard()
        {
            SetReportParameters(new AntibioticResistanceCardReport());
        }

        [TestMethod]
        public void Hum60BJournal()
        {
            SetReportParameters(new Journal60BReport());
        }

        [TestMethod]
        public void HumMonthInfectiousDisease()
        {
            SetReportParameters(new InfectiousDiseasesMonth());
        }

        [TestMethod]
        public void HumMonthInfectiousDiseaseNew()
        {
            SetReportParameters(new InfectiousDiseasesMonthNew());
        }

        [TestMethod]
        public void HumAnnualInfectiousDisease()
        {
            SetReportParameters(new InfectiousDiseasesYear());
        }

        #endregion

        #region Human AZ reports

        [TestMethod]
        public void HumFormN1A3()
        {
            SetReportParameters(new FormN1Report());
        }
        

        [TestMethod]
        public void HumSummaryByRayonDiagnosisAgeGroups()
        {
            SetReportParameters(new SummaryReport());
        }

        [TestMethod]
        public void HumComparativeReport()
        {
            SetReportParameters(new ComparativeAZReport());
        }

        [TestMethod]
        public void HumMainIndicatorsOfAFPSurveillance()
        {
            SetReportParameters(new MainAFPIndicatorsReport());
        }

        [TestMethod]
        public void HumAdditionalIndicatorsOfAFPSurveillance()
        {
            SetReportParameters(new AdditionalAFPIndicatorsReport());
        }

        #endregion

        #region ARM reports

        [TestMethod]
        public void HumFormN85Annual()
        {
            SetReportParameters(new FormN85AnnualReport());
        }

        [TestMethod]
        public void HumFormN85Monthly()
        {
            SetReportParameters(new FormN85MonthlyReport());
        }

        #endregion

        #region Veterinary reports

        [TestMethod]
        public void VetAggregateCase()
        {
            var parameters = new Dictionary<string, string>
                                 {{"@ObjID", "1"}, {"@observationId", "2"}, {"@idFormTemplate", "3"}, {"@idfsAggrCaseType", "4"}};
            SetReportParameters(new VetAggregateReport(), parameters);
        }

        [TestMethod]
        public void VetAggregateCaseSummary()
        {
            SetReportParameters(new VetAggregateCaseSummaryReport(), new Dictionary<string, string> {{"@AggrXml", AggrXml}});
        }

        [TestMethod]
        public void VetAggregateCaseActions()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     {"@ObjID", "1"},
                                     {"@idfsAggrCaseType", "2"},
                                     {"@diagnosticObservation", "3"},
                                     {"@prophylacticObservation", "4"},
                                     {"@sanitaryObservation", "5"},
                                     {"@diagnosticFormTemplate", "6"},
                                     {"@sanitaryFormTemplate", "7"},
                                     {"@prophylacticFormTemplate", "6"},
                                     {"@diagnosticTexten", "x"},
                                     {"@sanitaryTexten", "y"},
                                     {"@prophylacticTexten", "z"}
                                 };

            SetReportParameters(new VetAggregateActionsReport(), parameters);
        }

        [TestMethod]
        public void VetAggregateCaseActionsSummary()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     {"@AggrXml", AggrXml},
                                     {"@diagnosticObservation0", "1"},
                                     {"@diagnosticObservation1", "2"},
                                     {"@prophylacticObservation0", "3"},
                                     {"@prophylacticObservation1", "4"},
                                     {"@sanitaryObservation0", "5"},
                                     {"@sanitaryObservation1", "6"},
                                     {"@diagnosticTexten", "x"},
                                     {"@sanitaryTexten", "y"},
                                     {"@prophylacticTexten", "z"}
                                 };

            SetReportParameters(new VetAggregateActionsSummaryReport(), parameters);
        }

        [TestMethod]
        public void VetAvianInvestigation()
        {
            var parameters = new Dictionary<string, string> {{"@ObjID", "1"}, {"@DiagnosisID", "2"}};
            SetReportParameters(new AvianInvestigationReport(), parameters);
        }

        [TestMethod]
        public void VetLivestockInvestigation()
        {
            var parameters = new Dictionary<string, string> {{"@ObjID", "1"}, {"@DiagnosisID", "2"}};
            SetReportParameters(new LivestockInvestigationReport(), parameters);
        }

        [TestMethod]
        public void VetSamplesCount()
        {
            SetReportParameters(new VetSamplesCountReport());
        }

        [TestMethod]
        public void VetSamplesBySampleType()
        {
            SetReportParameters(new VetSamplesTypeReport());
        }

        [TestMethod]
        public void VetSamplesBySampleTypesWithinRegions()
        {
            SetReportParameters(new VetTestTypeReport());
        }

        [TestMethod]
        public void VetYearlySituation()
        {
            SetReportParameters(new VetSituationReport());
        }

        [TestMethod]
        public void VetActiveSurveillance()
        {
            SetReportParameters(new ActiveSurveillanceReport());
        }

        [TestMethod]
        public void VetActiveSurveillanceSampleCollected()
        {
            SetReportParameters(new SessionReport(), m_ObjIdParameters);
        }

        #region Veterinary KZ reports

        [TestMethod]
        public void VetCountryPreventiveMeasures()
        {
            SetReportParameters(new VetCountryPreventiveMeasures());
        }

        [TestMethod]
        public void VetCountrySanitaryMeasures()
        {
            SetReportParameters(new VetCountryProphilacticMeasures());
        }

        [TestMethod]
        public void VetCountryPlannedDiagnosticTests()
        {
            SetReportParameters(new VetCountryPlannedDiagnostic());
        }

        [TestMethod]
        public void VetOblastPreventiveMeasures()
        {
            SetReportParameters(new VetRegionPreventiveMeasures());
        }

        [TestMethod]
        public void VetOblastSanitaryMeasures()
        {
            SetReportParameters(new VetRegionProphilacticMeasures());
        }

        [TestMethod]
        public void VetOblastPlannedDiagnosticTests()
        {
            SetReportParameters(new VetRegionPlannedDiagnostic());
        }

        #endregion

        #endregion

        #region Lab module reports

        [TestMethod]
        public void LimSampleTransfer()
        {
            SetReportParameters(new TransferReport(), m_ObjIdParameters);
        }

        [TestMethod]
        public void LimTestResult()
        {
            SetReportParameters(new TestResultReport(),
                                new Dictionary<string, string> {{"@ObjID", "1"}, {"@CSObjID", "1"}, {"@TypeID", "2"}});
        }

        [TestMethod]
        public void LimTest()
        {
            SetReportParameters(new TestReport(), new Dictionary<string, string> {{"@ObjID", "1"}, {"@IsHuman", "true"}});
            SetReportParameters(new TestReport(), new Dictionary<string, string> {{"@ObjID", "1"}, {"@IsHuman", "false"}});
        }


        [TestMethod]
        public void LimBatchTest()
        {
            SetReportParameters(new BatchTestReport(), new Dictionary<string, string> {{"@ObjID", "1"}, {"@TypeID", "2"}});
        }

        
        
        [TestMethod]
        public void LimContainerDetails()
        {
            SetReportParameters(new ContainerDetailsReport(), m_ObjIdParameters);
        }

        [TestMethod]
        public void LimContainerContent()
        {
            SetReportParameters(new ContainerContentReport(),
                                new Dictionary<string, string> {{"@ObjID", "1"}, {"@ContID", "2"}, {"@FreezerID", ""}});
            SetReportParameters(new ContainerContentReport(),
                                new Dictionary<string, string> {{"@ObjID", "1"}, {"@ContID", ""}, {"@FreezerID", "2"}});
        }

        [TestMethod]
        public void LimAccessionIn()
        {
            SetReportParameters(new AccessionInReport(), m_ObjIdParameters);
        }

        #endregion

        [TestMethod]
        public void Outbreak()
        {
            SetReportParameters(new OutbreakReport(), m_ObjIdParameters);
        }

        [TestMethod]
        public void AdmEventLog()
        {
            SetReportParameters(new EventLogReport());
        }

        #region Helper methods

        private void SetReportParameters(BaseDocumentReport report, Dictionary<string, string> parameters)
        {
            report.SetParameters(manager, "en", parameters);
        }

        private void SetReportParameters(BaseIntervalReport report)
        {
            report.SetParameters(manager, new BaseIntervalModel("en", new DateTime(2000, 01, 01), new DateTime(2020, 01, 01), false)
                {
                    ExportFormat = "PDF",
                });
        }

        private void SetReportParameters(BaseDateReport report)
        {
            report.SetParameters(manager, new BaseDateModel("en", 2010, 1, 12, false));
        }

        private void SetReportParameters(BaseYearReport report)
        {
            report.SetParameters(manager, new BaseYearModel("en", 2010, false));
        }

        private void SetReportParameters(BaseSampleReport report)
        {
            report.SetParameters(manager, new LabSampleModel("en", "123", "", "", false));
        }

        private void SetReportParameters(ComparativeAZReport report)
        {
            report.SetParameters(manager, new ComparativeSurrogateModel("en", 1, null,null,2010, 2012, null, null, null, null, null, false));
        }

        #endregion
    }
}