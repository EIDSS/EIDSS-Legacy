using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EIDSS.Reports.Service.WcfFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace bv.tests.Reports
{
    [TestClass]
    public class ExportTests
    {
        private static IReportFacade m_Facade;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.LoadAssemblies();
            m_Facade = new ReportFacade();
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
        }

        #region PDF Human reports

        [TestMethod]
        public void PdfHumAggregateCaseTest()
        {
            AssertPDF(m_Facade.ExportHumAggregateCase(new AggregateModel("en", 1, 1, 2, false)));
        }

        [TestMethod]
        public void PdfHumAggregateCaseArchiveTest()
        {
            AssertPDF(m_Facade.ExportHumAggregateCase(new AggregateModel("en", 1, 1, 2, true)));
        }

        [TestMethod]
        public void PdfHumAggregateCaseSummaryTest()
        {
            const string aggrXml =
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""satCountry""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""sptYear""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2011-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>";
            var observations = new List<long> {1, 2};
            AssertPDF(m_Facade.ExportHumAggregateCaseSummary(
                new AggregateSummaryModel("en", aggrXml, observations, false)));
        }

        [TestMethod]
        public void PdfHumUrgentyNotificationTest()
        {
            AssertPDF(m_Facade.ExportHumUrgentyNotification(new BaseIdModel("en", 45820000633, false)));
        }

        [TestMethod]
        public void PdfHumUrgentyNotificationArchiveTest()
        {
            AssertPDF(m_Facade.ExportHumUrgentyNotification(new BaseIdModel("en", 45820000633, true)));
        }

        [TestMethod]
        public void PdfHumCaseInvestigationTest()
        {
            AssertPDF(m_Facade.ExportHumCaseInvestigation(
                new HumIdModel("en", 45820000633, 45830000633, 45840000633, 784230000000, false)));
        }

        [TestMethod]
        public void PdfHumCaseInvestigationArchiveTest()
        {
            AssertPDF(m_Facade.ExportHumCaseInvestigation(
                new HumIdModel("en", 45820000633, 45830000633, 45840000633, 784230000000, true)));
        }

        [TestMethod]
        public void PdfHumDiagnosisToChangedDiagnosist()
        {
            var model = new BaseIntervalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false);

            AssertPDF(m_Facade.ExportHumDiagnosisToChangedDiagnosis(model));
        }

        [TestMethod]
        public void ExcelHumDiagnosisToChangedDiagnosist()
        {
            var model = new BaseIntervalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false)
                {
                    ExportFormat = ReportExportType.Xlsx.ToString()
                };
            byte[] bytes = m_Facade.ExportHumDiagnosisToChangedDiagnosis(model);
            AssertXLSX(bytes);
        }

        [TestMethod]
        public void JpegHumDiagnosisToChangedDiagnosist()
        {
            var model = new BaseIntervalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false)
                {
                    ExportFormat = ReportExportType.Jpeg.ToString()
                };

            byte[] bytes =
                m_Facade.ExportHumDiagnosisToChangedDiagnosis(model);
            //File.WriteAllBytes("C:\\1.jpg", bytes);
            AssertJpeg(bytes);
        }

        [TestMethod]
        public void RtfHumDiagnosisToChangedDiagnosist()
        {
            var model = new BaseIntervalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false)
                {
                    ExportFormat = ReportExportType.Rtf.ToString()
                };

            byte[] bytes =
                m_Facade.ExportHumDiagnosisToChangedDiagnosis(model);
            //     File.WriteAllBytes("C:\\1.rtf", bytes);
            AssertRTF(bytes);
        }

        [TestMethod]
        public void PdfHumMonthlyMorbidityAndMortality()
        {
            AssertPDF(m_Facade.ExportHumMonthlyMorbidityAndMortality(new BaseDateModel("en", 2012, 1, false)));
        }

        [TestMethod]
        public void PdfExportHumSummaryOfInfectiousDiseases()
        {
            var model = new BaseIntervalModel("en", DateTime.Now.AddMonths(-1), DateTime.Now, false);

            AssertPDF(m_Facade.ExportHumSummaryOfInfectiousDiseases(model));
        }

        #endregion

        #region PDF Veterinary reports

        [TestMethod]
        public void PdfVetAggregateCaseTest()
        {
            AssertPDF(m_Facade.ExportVetAggregateCase(new AggregateModel("en", 1, 1, 2, false)));
        }

        [TestMethod]
        public void PdfVetAggregateCaseSummaryTest()
        {
            const string aggrXml =
                @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""satCountry""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""sptYear""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2011-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>";
            var observations = new List<long> {1, 2};
            AssertPDF(m_Facade.ExportVetAggregateCaseSummary(
                new AggregateSummaryModel("en", aggrXml, observations, false)));
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
            AssertPDF(m_Facade.ExportVetAggregateCaseActions(
                new AggregateActionsModel("en", 1, 2, 3, 4, 5, 6, 7, labels, false)));
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
            var ps = new AggregateActionsSummaryModel("en", aggrXml, observations, observations, observations, labels, false);
            AssertPDF(m_Facade.ExportVetAggregateCaseActionsSummary(ps));
        }

        [TestMethod]
        public void PdfVetAvianInvestigationTest()
        {
            AssertPDF(m_Facade.ExportVetAvianInvestigation(new VetIdModel("en", 1, 2, false)));
        }

        [TestMethod]
        public void PdfVetLivestockInvestigationTest()
        {
            AssertPDF(m_Facade.ExportVetLivestockInvestigation(new VetIdModel("en", 1, 2, false)));
        }

        [TestMethod]
        public void PdfVetActiveSurveillanceSampleCollectedTest()
        {
            AssertPDF(m_Facade.ExportVetActiveSurveillanceSampleCollected(new BaseIdModel("en", 1, false)));
        }

        #endregion

        #region  Lab module

        [TestMethod]
        public void PdfLimTestResultTest()
        {
            AssertPDF(m_Facade.ExportLimTestResult(new LimTestResultModel("en", 1, 2, 3, false)));
        }

        [TestMethod]
        public void PdfLimSampleTransferTest()
        {
            AssertPDF(m_Facade.ExportLimSampleTransfer(new BaseIdModel("en", 1, false)));
        }

        [TestMethod]
        public void PdfLimTestTest()
        {
            AssertPDF(m_Facade.ExportLimTest(new LimTestModel("en", 1, true, false)));
        }

        [TestMethod]
        public void PdfLimBatchTestTest()
        {
            AssertPDF(m_Facade.ExportLimBatchTest(new LimBatchTestModel("en", 1, 2, false)));
        }

        [TestMethod]
        public void PdfLimContainerDetailsTest()
        {
            AssertPDF(m_Facade.ExportLimContainerDetails(new BaseIdModel("en", 1, false)));
        }

        [TestMethod]
        public void PdfLimContainerContentPdfTest()
        {
            AssertPDF(m_Facade.ExportLimContainerContent(new LimContainerContentModel("en", 1, null, false)));
        }

        [TestMethod]
        public void PdfLimAccessionInTest()
        {
            AssertPDF(m_Facade.ExportLimAccessionIn(new BaseIdModel("en", 1, false)));
        }

        #endregion

        [TestMethod]
        public void UniOutbreakPdfTest()
        {
            AssertPDF(m_Facade.ExportOutbreak(new BaseIdModel("en", 1, false)));
        }

        [TestMethod]
        public void UniOutbreakPdfArchiveTest()
        {
            AssertPDF(m_Facade.ExportOutbreak(new BaseIdModel("en", 1, true)));
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
                AssertPDF(m_Facade.ExportHumAggregateCase(
                    new AggregateModel("en", 1, 1, 2, false)));

            Action humAggregateCaseSummary =
                () =>
                AssertPDF(m_Facade.ExportHumAggregateCaseSummary(
                    new AggregateSummaryModel("en", aggrXml, observations, false)));

            Action humUrgentyNotification =
                () => AssertPDF(m_Facade.ExportHumUrgentyNotification(new BaseIdModel("en", 45820000633, false)));

            Action humCaseInvestigation =
                () =>
                AssertPDF(m_Facade.ExportHumCaseInvestigation(
                    new HumIdModel("en", 45820000633, 45830000633, 45840000633, 784230000000, false)));

            Action vetAggregateCase =
                () =>
                AssertPDF(m_Facade.ExportVetAggregateCase(
                    new AggregateModel("en", 1, 1, 2, false)));

            Action vetAggregateCaseActions =
                () =>
                AssertPDF(m_Facade.ExportVetAggregateCaseActions(
                    new AggregateActionsModel("en", 1, 2, 3, 4, 5, 6, 7, labels, false)));

            Action vetAggregateCaseSummary =
                () =>
                AssertPDF(m_Facade.ExportVetAggregateCaseSummary(
                    new AggregateSummaryModel("en", aggrXml, observations, false)));

            var parameters = new AggregateActionsSummaryModel("en", aggrXml, observations, observations, observations, labels, false);
            Action vetAggregateCaseActionsSummary =
                () => AssertPDF(m_Facade.ExportVetAggregateCaseActionsSummary(parameters));

            Action vetAvianInvestigation =
                () => AssertPDF(m_Facade.ExportVetAvianInvestigation(new VetIdModel("en", 1, 2, false)));

            Action vetLivestockInvestigation =
                () => AssertPDF(m_Facade.ExportVetLivestockInvestigation(new VetIdModel("en", 1, 2, false)));

            Action vetActiveSurveillanceSampleCollected =
                () => AssertPDF(m_Facade.ExportVetActiveSurveillanceSampleCollected(new BaseIdModel("en", 1, false)));

            Action limTestResult = () => AssertPDF(m_Facade.ExportLimTestResult(new LimTestResultModel("en", 1, 2, 3, false)));

            Action limSampleTransfer = () => AssertPDF(m_Facade.ExportLimSampleTransfer(new BaseIdModel("en", 1, false)));

            Action limTest = () => AssertPDF(m_Facade.ExportLimTest(new LimTestModel("en", 1, true, false)));

            Action batchTest = () => AssertPDF(m_Facade.ExportLimBatchTest(new LimBatchTestModel("en", 1, 2, false)));

            Action containerDetails = () => AssertPDF(m_Facade.ExportLimContainerDetails(new BaseIdModel("en", 1, false)));

            Action containerContent =
                () =>
                AssertPDF(m_Facade.ExportLimContainerContent(new LimContainerContentModel("en", 1, null, false)));

            Action limAccessionIn = () => AssertPDF(m_Facade.ExportLimAccessionIn(new BaseIdModel("en", 1, false)));

            Action outbreak = () => AssertPDF(m_Facade.ExportOutbreak(new BaseIdModel("en", 1, false)));

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

        public static void AssertPDF(byte[] bytes)
        {
            Assert.IsTrue(bytes.Length > 0);
            Assert.AreEqual(bytes[0], 0x25); // %
            Assert.AreEqual(bytes[1], 0x50); // P
            Assert.AreEqual(bytes[2], 0x44); // D
            Assert.AreEqual(bytes[3], 0x46); // F
        }

        public static void AssertXLSX(byte[] bytes)
        {
            Assert.IsTrue(bytes.Length > 0);
            Assert.AreEqual(bytes[0], 0x50); // P
            Assert.AreEqual(bytes[1], 0x4B); // K
            Assert.AreEqual(bytes[2], 0x03); // 
            Assert.AreEqual(bytes[3], 0x04); // 
        }

        public static void AssertJpeg(byte[] bytes)
        {
            Assert.IsTrue(bytes.Length > 0);
            Assert.AreEqual(bytes[0], 0xFF); // 
            Assert.AreEqual(bytes[1], 0xD8); // K
            Assert.AreEqual(bytes[2], 0xFF); // 
            Assert.AreEqual(bytes[3], 0xE0); // 
        }

        public static void AssertRTF(byte[] bytes)
        {
            Assert.IsTrue(bytes.Length > 0);
            Assert.AreEqual(bytes[0], 0x7B); // {
            Assert.AreEqual(bytes[1], 0x5C); // \
            Assert.AreEqual(bytes[2], 0x72); // r
            Assert.AreEqual(bytes[3], 0x74); // t
        }
    }
}