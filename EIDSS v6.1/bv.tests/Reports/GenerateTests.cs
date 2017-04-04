using System;
using System.Collections.Generic;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.common;
using eidss.model.Enums;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.ActiveSurveillance;
using EIDSS.Reports.Document.Human.Aggregate;
using EIDSS.Reports.Document.Human.CaseInvestigation;
using EIDSS.Reports.Document.Human.EmergencyNotification;
using EIDSS.Reports.Document.Lim.Batch;
using EIDSS.Reports.Document.Lim.Case;
using EIDSS.Reports.Document.Lim.ContainerDetails;
using EIDSS.Reports.Document.Lim.TestResult;
using EIDSS.Reports.Document.Lim.Transfer;
using EIDSS.Reports.Document.Uni.AccessionIn;
using EIDSS.Reports.Document.Uni.Outbreak;
using EIDSS.Reports.Document.Veterinary.Aggregate;
using EIDSS.Reports.Document.Veterinary.AvianInvestigation;
using EIDSS.Reports.Document.Veterinary.LivestockInvestigation;
using EIDSS.Reports.Parameterized.AberrationAnalysis.Reports;
using EIDSS.Reports.Parameterized.ActiveSurveillance;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using EIDSS.Reports.Parameterized.Human.ARM.Report;
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
using SampleReport = EIDSS.Reports.Document.Lim.ContainerContent.ContainerContentReport;

namespace bv.tests.Reports
{
    [TestClass]
    public class GenerateTests
    {
        private readonly Dictionary<string, string> m_ObjIdParameters = new Dictionary<string, string> {{"@ObjID", "1"}};

        private const string AggrXml =
            @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""satCountry""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""sptYear""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2011-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>";

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.LoadAssemblies();
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void HumAggregateCase()
        {
            var parameters = new Dictionary<string, string>
            {
                {"@ObjID", "12695830000000"},
                {"@observationId", "12695840000000"},
                {"@idFormTemplate", "6707760000000"},
                {"@idfsAggrCaseType", "10102001"}
            };

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
            SetReportParameters(new InfectiousDiseasesMonthV4());
        }

        [TestMethod]
        public void HumMonthInfectiousDiseaseNew()
        {
            SetReportParameters(new InfectiousDiseasesMonthV5());
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
            SetReportParameters(new HumSummaryReport());
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
        public void HumFormN85()
        {
            SetReportParameters(new FormN85JointReport());
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
            SetReportParameters(new LimSampleReport(), m_ObjIdParameters);
        }

        [TestMethod]
        public void LimContainerContent()
        {
            SetReportParameters(new SampleReport(),
                new Dictionary<string, string> {{"@ObjID", "1"}, {"@ContID", "2"}, {"@FreezerID", ""}});
            SetReportParameters(new SampleReport(),
                new Dictionary<string, string> {{"@ObjID", "1"}, {"@ContID", ""}, {"@FreezerID", "2"}});
        }

        [TestMethod]
        public void LimAccessionIn()
        {
            SetReportParameters(new AccessionInReport(), m_ObjIdParameters);
        }

        #endregion

        #region Aberration

        [TestMethod]
        public void HumAberration()
        {
            SetReportParameters(new HumAberrationReport());
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
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                report.SetParameters("en", parameters, manager, null);
            }
        }

        private void SetReportParameters(BaseIntervalReport report)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                report.SetParameters(new BaseIntervalModel("en", new DateTime(2000, 01, 01), new DateTime(2020, 01, 01), false), manager,
                    null);
            }
        }

        private void SetReportParameters(BaseDateReport report)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                report.SetParameters(new BaseDateModel("en", 2010, 1, 12, false), manager, null);
            }
        }

        private void SetReportParameters(BaseYearReport report)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                report.SetParameters(new BaseYearModel("en", 2010, false), manager, null);
            }
        }

        private void SetReportParameters(BaseSampleReport report)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                report.SetParameters(new HumanLabSampleModel("en", "123", "", "", false), manager, null);
            }
        }

        private void SetReportParameters(ComparativeAZReport report)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var model = new ComparativeSurrogateModel("en", 1, 1, 10, 2010, 2012, null, null, null, null, 1, null,
                    new List<PersonalDataGroup>(), false);
                report.SetParameters(model, manager, null);
            }
        }

        #endregion
    }
}