using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using EIDSS.Reports.Service.WcfService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.tests.ReportPdfService;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.KZ;
using eidss.webclient.Controllers;

namespace bv.tests.Reports
{
    [TestClass]
    public class PDFServiceTests
    {
        private static readonly object m_SyncRoot = new object();
        private static int m_TotalCount;

        public class ReportClientWrapper : IDisposable
        {
            private readonly ReportFacadeClient m_Client;

            public ReportClientWrapper()
            {
                string address = Config.GetSetting("ReportServiceHostURL", "http://localhost:8098/");
                m_Client = new ReportFacadeClient("BasicHttpBinding_IReportFacade", address);
            }

            public ReportFacadeClient Client
            {
                get { return m_Client; }
            }

            public void Dispose()
            {
                m_Client.Close();
            }
        }

        private static HostKeeper m_HostKeeper;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            m_HostKeeper = new HostKeeper();
            m_HostKeeper.Open();
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
            m_HostKeeper.Close();
        }

        [TestInitialize]
        public void TestInit()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials().ConnectionString);
            EidssUserContext.Init();
        }

        #region PDF Human reports

        [TestMethod]
        public void ServiceVersionTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                Version version = wrapper.Client.GetServiceVersion();
                Assert.IsTrue(version.ToString().Contains("5.0"));
            }
        }

        [TestMethod]
        public void PdfHumAggregateCaseTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumAggregateCase(new AggregateModel("en", 1, 1, 2, false)));
            }
        }

        [TestMethod]
        public void PdfHumAggregateCaseSummaryTest()
        {
            const string aggrXml =
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""satCountry""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""sptYear""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2011-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>";
            var observations = new List<long> {1, 2};
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumAggregateCaseSummary(
                    new AggregateSummaryModel("en", aggrXml, observations, false)));
            }
        }

        [TestMethod]
        public void PdfHumUrgentyNotificationTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumUrgentyNotification(new BaseIdModel("en", 1, false)));
            }
        }

        [TestMethod]
        public void PdfHumCaseInvestigationTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumCaseInvestigation(new HumIdModel("en", 1, 2, 3, 4, false)));
            }
        }

        [TestMethod]
        public void PdfHumDiagnosisToChangedDiagnosistTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new BaseIntervalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false);
                AssertPDF(wrapper.Client.ExportHumDiagnosisToChangedDiagnosis(model));
            }
        }

        [TestMethod]
        public void PdfHumMonthlyMorbidityAndMortalityTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumMonthlyMorbidityAndMortality(
                    new BaseDateModel("en", 2012, 1, false)));
            }
        }

        [TestMethod]
        public void PdfExportHumSummaryOfInfectiousDiseasesTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new BaseIntervalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false);
                AssertPDF(wrapper.Client.ExportHumSummaryOfInfectiousDiseases(model));
            }
        }

        [TestMethod]
        public void PdfHumFormN1Test()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new FormNo1SurrogateModel("en", 2012, 1, 10, true, null, null,null, null, null, null, false);
                AssertPDF(wrapper.Client.ExportHumFormN1(model));
                model.IsA3Format = false;
                AssertPDF(wrapper.Client.ExportHumFormN1(model));
            }
        }

        [TestMethod]
        public void PdfHumDataQualityIndicatorsTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new DataQualityIndicatorsModel("en", 2012, new[] {"2955880000000", "784620000000"}, 0, 0, false);
                AssertPDF(wrapper.Client.ExportHumDataQualityIndicators(model));
            }
        }

        [TestMethod]
        public void PdfHumDataQualityIndicatorsRayonsTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new DataQualityIndicatorsModel("en", 2012, new[] {"2955880000000", "784620000000"}, 0, 0, false);
                AssertPDF(wrapper.Client.ExportHumDataQualityIndicatorsRayons(model));
            }
        }

        [TestMethod]
        public void PdfExportHumSummaryByRayonDiagnosisAgeGroupsTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new SummaryByRayonDiagnosisAgeGroupsModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false);
                AssertPDF(wrapper.Client.ExportHumSummaryByRayonDiagnosisAgeGroups(model));
            }
        }

        [TestMethod]
        public void PdfHumComparativeAZReportTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumComparativeAZReport(
                    new ComparativeSurrogateModel("en", 1, 2, 3, 2010, 2012, null, null,
                                                  null, null, null, false)));
            }
        }

        [TestMethod]
        public void PdfHumExternalComparativeReportTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumExternalComparativeReport(
                    new ExternalComparativeSurrogateModel("en", null, null, 2010,
                                                          2012, 1, 2, false)));
            }
        }

        [TestMethod]
        public void PdfHumMainIndicatorsOfAFPSurveillanceTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new AFPModel("en", 2012, 0, 0, false);
                AssertPDF(wrapper.Client.ExportHumMainIndicatorsOfAFPSurveillance(model));
            }
        }

        [TestMethod]
        public void PdfHumAdditionalIndicatorsOfAFPSurveillanceTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new AFPModel("en", 2012, 0, 0, false);
                AssertPDF(wrapper.Client.ExportHumAdditionalIndicatorsOfAFPSurveillance(model));
            }
        }

        [TestMethod]
        public void PdfHumWhoMeaslesRubellaReportTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumWhoMeaslesRubellaReport(new BaseDateModel("en", 2012, 1, false)));
            }
        }


        [TestMethod]
        public void PdfHumComparativeReportOfTwoYearsTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumComparativeReportOfTwoYears(new ComparativeTwoYearsSurrogateModel("en", 2010,2011,1,null,null,null,null,null,null,null,null, false)));
            }
        }

        [TestMethod]
        public void PdfVeterinaryCasesReportTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new VetCasesSurrogateModel("en", null, null, "", "", null, "", 2010, 2012, 1, 2, false);
                AssertPDF(wrapper.Client.ExportVeterinaryCasesReport(model));
            }
        }

        [TestMethod]
        public void PdfVeterinaryLabReportTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new VetLabSurrogateModel("en", 2013, 1, 2, null,"", null,null,"","",false);
                AssertPDF(wrapper.Client.ExportVeterinaryLaboratoriesAZReport(model));
            }
        }

        [TestMethod]
        public void PdfHumSerologyResearchCardTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumSerologyResearchCard(
                    new LabSampleModel("en", "123", "", "", false)));
            }
        }

        [TestMethod]
        public void PdfHumMicrobiologyResearchCardTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumMicrobiologyResearchCard(
                    new LabSampleModel("en", "123", "", "", false)));
            }
        }

        [TestMethod]
        public void PdfHumAntibioticResistanceCardTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportHumAntibioticResistanceCard(
                    new LabSampleModel("en", "123", "", "", false)));
            }
        }

        [TestMethod]
        public void PdfHum60BJournalTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new Hum60BJournalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false);
                AssertPDF(wrapper.Client.ExportHum60BJournal(model));
            }
        }

        [TestMethod]
        public void PdfHumMonthInfectiousDiseaseTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new MonthInfectiousDiseaseModel("en", 2012, 1, true, false);
                AssertPDF(wrapper.Client.ExportHumMonthInfectiousDisease(model));
            }
        }

        [TestMethod]
        public void PdfHumMonthInfectiousDiseaseNewTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new MonthInfectiousDiseaseModel("en", 2012, 1, true, false);
                AssertPDF(wrapper.Client.ExportHumMonthInfectiousDiseaseNew(model));
            }
        }

        [TestMethod]
        public void PdfHumIntermediateMonthInfectiousDiseaseTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new IntermediateInfectiousDiseaseSurrogateModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, null, null, "",
                                                                            "", false);
                AssertPDF(wrapper.Client.ExportHumIntermediateMonthInfectiousDisease(model));
            }
        }

        [TestMethod]
        public void PdfHumIntermediateMonthInfectiousDiseaseNewTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new IntermediateInfectiousDiseaseSurrogateModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, null, null, "",
                                                                            "", false);
                AssertPDF(wrapper.Client.ExportHumIntermediateMonthInfectiousDiseaseNew(model));
            }
        }

        [TestMethod]
        public void PdfHumAnnualInfectiousDiseaseTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new AnnualInfectiousDiseaseModel("en", 2012, false);
                AssertPDF(wrapper.Client.ExportHumAnnualInfectiousDisease(model));
            }
        }

        [TestMethod]
        public void PdfHumIntermediateAnnualInfectiousDiseaseTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new IntermediateInfectiousDiseaseSurrogateModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, null, null, "",
                                                                            "", false);
                AssertPDF(wrapper.Client.ExportHumIntermediateAnnualInfectiousDisease(model));
            }
        }

        #endregion

        #region PDF Veterinary reports

        [TestMethod]
        public void PdfVetAggregateCaseTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetAggregateCase(new AggregateModel("en", 1, 1, 2, false)));
            }
        }

        [TestMethod]
        public void PdfVetAggregateCaseSummaryTest()
        {
            const string aggrXml =
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""satCountry""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""sptYear""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2011-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>";
            var observations = new List<long> {1, 2};
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetAggregateCaseSummary(
                    new AggregateSummaryModel("en", aggrXml, observations, false)));
            }
        }

        [TestMethod]
        public void PdfVetAggregateCaseActionsTest()
        {
            var labels = new Dictionary<string, string>
                {
                    {"@diagnosticTexten", "x"},
                    {"@sanitaryTexten", "y"},
                    {"@prophylacticTexten", "z"}
                };
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetAggregateCaseActions(
                    new AggregateActionsModel("en", 1, 2, 3, 4, 5, 6, 7, labels, false)));
            }
        }

        [TestMethod]
        public void PdfVetAggregateCaseActionsSummaryTest()
        {
            const string aggrXml =
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""satCountry""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""sptYear""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2011-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>";
            var observations = new long[] {1, 2};
            var labels = new Dictionary<string, string>
                {
                    {"@diagnosticTexten", "x"},
                    {"@sanitaryTexten", "y"},
                    {"@prophylacticTexten", "z"}
                };
            using (var wrapper = new ReportClientWrapper())
            {
                var ps = new AggregateActionsSummaryModel("en", aggrXml, observations, observations, observations, labels, false);
                AssertPDF(wrapper.Client.ExportVetAggregateCaseActionsSummary(ps));
            }
        }

        [TestMethod]
        public void PdfVetAvianInvestigationTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetAvianInvestigation(new VetIdModel("en", 1, 2, false)));
            }
        }

        [TestMethod]
        public void PdfVetLivestockInvestigationTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetLivestockInvestigation(new VetIdModel("en", 1, 2, false)));
            }
        }

        [TestMethod]
        public void PdfVetActiveSurveillanceSampleCollectedTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetActiveSurveillanceSampleCollected(new BaseIdModel("en", 1, false)));
            }
        }

        [TestMethod]
        public void PdfVetSamplesCountTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetSamplesCount(new BaseYearModel("en", 2012, false)));
            }
        }

        [TestMethod]
        public void PdfExportVetSamplesBySampleTypeTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetSamplesBySampleType(new BaseYearModel("en", 2012, false)));
            }
        }

        [TestMethod]
        public void PdfExportVetSamplesBySampleTypesWithinRegionsTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetSamplesBySampleTypesWithinRegions(
                    new BaseYearModel("en", 2012, false)));
            }
        }

        [TestMethod]
        public void PdfVetYearlySituationTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetYearlySituation(new BaseYearModel("en", 2012, false)));
            }
        }

        [TestMethod]
        public void PdfVetPlannedDiagnosticTest()
        {
            var kzPdDiagnosis = new[] {"6618180000000"};
            var kzPdSpecies = new[] {"6619290000000", "952120000000"};
            var kzPdInvestigation = new[] {"837780000000", "837840000000"};

            using (var wrapper = new ReportClientWrapper())
            {
                var model = new DiagnosticInvestigationModel("ru", DateTime.Now.AddMonths(-1), DateTime.Now, null,
                                                             kzPdDiagnosis, kzPdInvestigation, kzPdSpecies, false);
                AssertPDF(wrapper.Client.ExportVetCountryPlannedDiagnosticTests(model));

                model.RegionFilter.RegionId = 41180000000;
                AssertPDF(wrapper.Client.ExportVetCountryPlannedDiagnosticTests(model));
            }
        }

        [TestMethod]
        public void PdfVetPreventiveMeasuresTest()
        {
            var kzPmDiagnosis = new[] {"6618460000000"};
            var kzPmSpecies = new[] {"838110000000"};
            var kzPmMeasures = new[] {"952180000000"};
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new ProphylacticModel("ru", DateTime.Now.AddMonths(-1), DateTime.Now, null,
                                                  kzPmDiagnosis, kzPmSpecies, kzPmMeasures, false);

                AssertPDF(wrapper.Client.ExportVetCountryPreventiveMeasures(model));

                model.RegionFilter.RegionId = 41180000000;
                AssertPDF(wrapper.Client.ExportVetCountryPreventiveMeasures(model));
            }
        }

        [TestMethod]
        public void PdfVetSanitaryMeasuresTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new SanitaryModel("ru", DateTime.Now.AddMonths(-1), DateTime.Now, null, new[] {"952220000000"}, false);

                AssertPDF(wrapper.Client.ExportVetCountrySanitaryMeasures(model));

                model.RegionFilter.RegionId = 41180000000;
                AssertPDF(wrapper.Client.ExportVetCountrySanitaryMeasures(model));
            }
        }

        [TestMethod]
        public void PdfVetActiveSurveillanceTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportVetActiveSurveillance(new BaseYearModel("en", 2012, false)));
            }
        }

        #endregion

        #region  Lab module

        [TestMethod]
        public void PdfLimTestResultTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportLimTestResult(new LimTestResultModel("en", 1, 2, 3, false)));
            }
        }

        [TestMethod]
        public void PdfLimSampleTransferTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportLimSampleTransfer(new BaseIdModel("en", 1, false)));
            }
        }

        [TestMethod]
        public void PdfLimTestTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportLimTest(new LimTestModel("en", 1, true, false)));
            }
        }

        [TestMethod]
        public void PdfLimBatchTestTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportLimBatchTest(new LimBatchTestModel("en", 1, 2, false)));
            }
        }

        [TestMethod]
        public void PdfLimContainerDetailsTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportLimContainerDetails(new BaseIdModel("en", 1, false)));
            }
        }

        [TestMethod]
        public void PdfLimContainerContentPdfTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportLimContainerContent(
                    new LimContainerContentModel("en", 1, null, false)));
            }
        }

        [TestMethod]
        public void PdfLimAccessionInTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportLimAccessionIn(new BaseIdModel("en", 1, false)));
            }
        }

        #endregion

        [TestMethod]
        public void UniOutbreakPdfTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportOutbreak(new BaseIdModel("en", 1, false)));
            }
        }

        [TestMethod]
        public void AdmEventLogPdfTest()
        {
            using (var wrapper = new ReportClientWrapper())
            {
                AssertPDF(wrapper.Client.ExportAdmEventLog(
                    new BaseIntervalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false)));
            }
        }

        [TestMethod]
        public void PdfParallelAccessTest()
        {
            List<Task> tasks = CreateTasks();
            foreach (Task task in tasks)
            {
                task.Start();
            }
            Task.WaitAll(tasks.ToArray());
        }

        [TestMethod]
        public void ReportControllerMethodChainTests()
        {
            var controller = new ReportController();

            List<MethodInfo> methodInfos =
                controller.GetType().GetMethods().Where(
                    m => !m.GetParameters().Any() && typeof (ActionResult).IsAssignableFrom(m.ReturnType)
                    ).ToList();

            m_HostKeeper.Trace.TraceInfo("Service", "Test of {0} Actions of ReportController started", methodInfos.Count);
            foreach (MethodInfo info in methodInfos)
            {
                info.Invoke(controller, new object[0]);
                Assert.IsNotNull(controller.ViewBag.Title, string.Format("Report title not set in mehtod {0}", info.Name));
                Assert.IsNotNull(controller.ViewBag.GetReportActionName, string.Format("Report name not set in mehtod {0}", info.Name));

                string actionName = controller.ViewBag.GetReportActionName.ToString();
                MethodInfo action = controller.GetType().GetMethod(actionName);
                Assert.IsNotNull(action, string.Format("Controller hasn't action {0}", actionName));

                ParameterInfo[] parameterInfos = action.GetParameters();
                Assert.IsTrue(parameterInfos.Length == 1, string.Format("Controller action {0} should have 1 parameter", actionName));

                var parameter = Activator.CreateInstance(parameterInfos[0].ParameterType) as BaseModel;
                Assert.IsNotNull(parameter,
                                 string.Format("parameter of mehtod {0} has wrong type {1}", actionName, parameterInfos[0].ParameterType));
                parameter.Language = "en";
                object result = action.Invoke(controller, new[] {(object) parameter});
                Assert.IsNotNull(result, string.Format("Controller action {0} return null value", actionName));
                Assert.IsTrue(result is FileContentResult, string.Format("Controller action {0} return vrong type value", actionName));

                ExportTests.AssertPDF((result as FileContentResult).FileContents);
            }
        }

        private static List<Task> CreateTasks()
        {
            const string aggrXml =
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""satCountry""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""sptYear""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2011-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>";
            var observations = new List<long> {1, 2};
            var labels = new Dictionary<string, string>
                {
                    {"@diagnosticTexten", "x"},
                    {"@sanitaryTexten", "y"},
                    {"@prophylacticTexten", "z"}
                };

            Action humAggregateCase =
                () =>
                AssertPdfAction(
                    wrapper => wrapper.Client.ExportHumAggregateCase(new AggregateModel("en", 1, 1, 2, false)),
                    "PdfHumAggregateCase");

            Action humAggregateCaseSummary =
                () =>
                AssertPdfAction(
                    wrapper =>
                    wrapper.Client.ExportHumAggregateCaseSummary(
                        new AggregateSummaryModel("en", aggrXml, observations, false)),
                    "PdfHumAggregateCaseSummary");
            Action humUrgentyNotification =
                () =>
                AssertPdfAction(
                    wrapper =>
                    wrapper.Client.ExportHumUrgentyNotification(new BaseIdModel("en", 45820000633, false)),
                    "PdfHumUrgentyNotification");

            Action humCaseInvestigation =
                () =>
                AssertPdfAction(
                    wrapper =>
                    wrapper.Client.ExportHumCaseInvestigation(new HumIdModel("en", 1, 2, 3, 4, false)),
                    "PdfHumCaseInvestigation");

            Action vetAggregateCase =
                () =>
                AssertPdfAction(
                    wrapper => wrapper.Client.ExportVetAggregateCase(new AggregateModel("en", 1, 1, 2, false)),
                    "PdfVetAggregateCase");

            Action vetAggregateCaseActions =
                () =>
                AssertPdfAction(
                    wrapper =>
                    wrapper.Client.ExportVetAggregateCaseActions(
                        new AggregateActionsModel("en", 1, 2, 3, 4, 5, 6, 7, labels, false)),
                    "PdfVetAggregateCaseActions");

            Action vetAggregateCaseSummary =
                () =>
                AssertPdfAction(
                    wrapper =>
                    wrapper.Client.ExportVetAggregateCaseSummary(
                        new AggregateSummaryModel("en", aggrXml, observations, false)),
                    "PdfVetAggregateCaseSummary");

            var asm = new AggregateActionsSummaryModel("en", aggrXml, observations, observations, observations, labels, false);
            Action vetAggregateCaseActionsSummary =
                () =>
                AssertPdfAction(
                    wrapper =>
                    wrapper.Client.ExportVetAggregateCaseActionsSummary(asm),
                    "PdfVetAggregateCaseActionsSummary");

            Action vetAvianInvestigation =
                () =>
                AssertPdfAction(
                    wrapper => wrapper.Client.ExportVetAvianInvestigation(new VetIdModel("en", 1, 2, false)),
                    "PdfVetAvianInvestigation");

            Action vetLivestockInvestigation =
                () =>
                AssertPdfAction(
                    wrapper => wrapper.Client.ExportVetLivestockInvestigation(new VetIdModel("en", 1, 2, false)),
                    "PdfVetLivestockInvestigation");

            Action vetActiveSurveillanceSampleCollected =
                () =>
                AssertPdfAction(
                    wrapper =>
                    wrapper.Client.ExportVetActiveSurveillanceSampleCollected(new BaseIdModel("en", 1, false)),
                    "PdfVetActiveSurveillanceSampleCollected");

            Action limTestResult =
                () =>
                AssertPdfAction(
                    wrapper => wrapper.Client.ExportLimTestResult(new LimTestResultModel("en", 1, 2, 3, false)),
                    "PdfLimTestResult");

            Action limSampleTransfer =
                () =>
                AssertPdfAction(wrapper => wrapper.Client.ExportLimSampleTransfer(new BaseIdModel("en", 1, false)),
                                "PdfLimSampleTransfer");

            Action limTest =
                () =>
                AssertPdfAction(wrapper => wrapper.Client.ExportLimTest(new LimTestModel("en", 1, true, false)),
                                "PdfLimTest");

            Action batchTest =
                () =>
                AssertPdfAction(
                    wrapper => wrapper.Client.ExportLimBatchTest(new LimBatchTestModel("en", 1, 2, false)),
                    "PdfLimBatchTest");

            Action containerDetails =
                () =>
                AssertPdfAction(
                    wrapper => wrapper.Client.ExportLimContainerDetails(new BaseIdModel("en", 1, false)),
                    "PdfLimContainerDetails");

            Action containerContent =
                () =>
                AssertPdfAction(
                    wrapper =>
                    wrapper.Client.ExportLimContainerContent(new LimContainerContentModel("en", 1, null, false)),
                    "PdfLimContainerContent");

            Action limAccessionIn =
                () =>
                AssertPdfAction(wrapper => wrapper.Client.ExportLimAccessionIn(new BaseIdModel("en", 1, false)),
                                "PdfLimAccessionIn");

            Action outbreak =
                () =>
                AssertPdfAction(wrapper => wrapper.Client.ExportOutbreak(new BaseIdModel("en", 1, false)),
                                "PdfOutbreak");

            var tasks = new List<Task>();

            tasks.Add(new Task(outbreak));
            tasks.Add(new Task(humAggregateCase));
            tasks.Add(new Task(humAggregateCaseSummary));
            tasks.Add(new Task(humUrgentyNotification));
            tasks.Add(new Task(humCaseInvestigation));

            tasks.Add(new Task(vetAggregateCase));
            tasks.Add(new Task(vetAggregateCaseSummary));
            tasks.Add(new Task(vetAggregateCaseActions));
            tasks.Add(new Task(vetAggregateCaseActionsSummary));
            tasks.Add(new Task(vetAvianInvestigation));
            tasks.Add(new Task(vetLivestockInvestigation));
            tasks.Add(new Task(vetActiveSurveillanceSampleCollected));

            tasks.Add(new Task(limTestResult));
            tasks.Add(new Task(limSampleTransfer));
            tasks.Add(new Task(limTest));
            tasks.Add(new Task(batchTest));
            tasks.Add(new Task(containerDetails));
            tasks.Add(new Task(containerContent));
            tasks.Add(new Task(limAccessionIn));

            return tasks;
        }

        private static void AssertPdfAction(Func<ReportClientWrapper, byte[]> pdfReportAction, string reportName)
        {
            int count;
            lock (m_SyncRoot)
            {
                m_TotalCount++;
                count = m_TotalCount;
            }
            DateTime oldTime = DateTime.Now;
            Console.WriteLine("->{0} {1} called.", count, reportName);
            using (var wrapper = new ReportClientWrapper())
            {
                byte[] pdfHumUrgentyNotification = pdfReportAction(wrapper);
                AssertPDF(pdfHumUrgentyNotification);
            }
            Console.WriteLine("<-{0} {1} received. Executing time: {2}", count, reportName, DateTime.Now - oldTime);
        }

        public static void AssertPDF(byte[] bytes)
        {
            ExportTests.AssertPDF(bytes);
        }
    }
}