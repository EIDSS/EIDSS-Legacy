using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.tests.Core;
using bv.tests.Reports;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Complexity;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.Avr.View;
using eidss.model.Trace;
using eidss.model.WindowsService.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class AvrCacheReceiverTests
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            string scriptPath = PathToTestFolder.Get(TestFolders.Db) + "Data\\CreateTestTables.sql";
            ScriptLoader.RunScript(scriptPath);
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString"));
        }

        [TestMethod]
        public void SimpleQueryTest()
        {
            var facadeStub = new AVRFacadeStub(123);
            var receiver = new AvrCacheReceiver(facadeStub);

            AvrDataTable dataTable;
            using (new StopwathTransaction("+++GetCachedQueryTable+++"))
            {
                CachedQueryResult result = receiver.GetCachedQueryTable(1, "en", false,  string.Empty,  new LayoutSilentValidatorWaiter());
                dataTable = result.QueryTable;
                Assert.IsNotNull(dataTable);
            }
            Assert.IsNotNull(dataTable);
            Assert.AreEqual(54 * 2, dataTable.Columns.Count);
            Assert.AreEqual(31, dataTable.Rows.Count);
            var caseIdIndex = dataTable.Columns["sflHC_CaseID"].Ordinal;

            AvrDataRowBase lastRow = dataTable.Rows.Find(r => Utils.Str(r[caseIdIndex]) == "HC1000031");
            Assert.AreEqual(new DateTime(1990, 02, 01), lastRow[0]);
            Assert.AreEqual(23, lastRow[1]);
            Assert.AreEqual(DBNull.Value, lastRow[3]);
            Assert.AreEqual("xxx", lastRow[4]);
            Assert.AreEqual("Male", lastRow[6]);
            Assert.AreEqual(DBNull.Value, lastRow[7]);
            Assert.AreEqual(DateTime.Now.Year, ((DateTime) lastRow[50]).Year);
            Assert.AreEqual(DateTime.Now.Year, lastRow[51]);
            Assert.AreEqual(25460000000m, lastRow[52]);
            Assert.AreEqual("Yes", lastRow[53]);
        }

        [TestMethod]
        public void LongQueryTest()
        {
            var facadeStub = new AVRFacadeStub(123, 200);
            var receiver = new AvrCacheReceiver(facadeStub);

            AvrDataTable dataTable;
            using (new StopwathTransaction("+++GetCachedQueryTable+++"))
            {
                CachedQueryResult result = receiver.GetCachedQueryTable(1, "en", false, string.Empty, new LayoutSilentValidatorWaiter());
                dataTable = result.QueryTable;
            }
            Assert.IsNotNull(dataTable);
            Assert.AreEqual(54 * 2, dataTable.Columns.Count);
            Assert.AreEqual(31 * 200, dataTable.Rows.Count);
        }

        [TestMethod]
        public void ViewReceiverTest()
        {
            var facadeStub = new AVRFacadeStub(123);
            var receiver = new AvrCacheReceiver(facadeStub);

            AvrPivotViewModel model;
            using (new StopwathTransaction("+++GetCachedView+++"))
            {
                model = receiver.GetCachedView("xx", -1, "en");
            }
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.ViewHeader);
            Assert.IsNotNull(model.ViewData);

            string viewXmlNew = AvrViewSerializer.Serialize(model.ViewHeader);
            Assert.AreEqual(SerializedViewStub.ViewXml, viewXmlNew);

            string dataXmlNew = DataTableSerializer.Serialize(model.ViewData);
            Assert.AreEqual(SerializedViewStub.DataXml, dataXmlNew);
        }

        [TestMethod]
        public void ExportChartToJpgTest()
        {
            var facadeStub = new AVRFacadeStub(123);
            var receiver = new AvrCacheReceiver(facadeStub);

            ChartExportDTO result;
            using (new StopwathTransaction("+++ExportChartToJpg+++"))
            {
                result = receiver.ExportChartToJpg(new ChartTableModel(-1, "en", new DataTable(), null, null, null, 100, 100));
            }
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.JpgBytes);
            ExportTests.AssertJpeg(result.JpgBytes);
        }

        [TestMethod]
        public void ViewFacedeTest()
        {
            var facade = new AVRFacadeStub(123);

            ViewDTO model = facade.GetCachedView("xxx", -1, "en");

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.BinaryViewHeader);
            Assert.IsNotNull(model.Header);
            Assert.IsNotNull(model.BodyPackets);

            byte[] unzippedViewStructure = BinaryCompressor.Unzip(model.BinaryViewHeader);
            string xmlViewStructure = BinarySerializer.DeserializeToString(unzippedViewStructure);
            AvrView view = AvrViewSerializer.Deserialize(xmlViewStructure);
            string viewXmlNew = AvrViewSerializer.Serialize(view);
            Assert.AreEqual(SerializedViewStub.ViewXml, viewXmlNew);

            BaseTableDTO unzippedDTO = BinaryCompressor.Unzip(model);
            DataTable viewData = BinarySerializer.DeserializeToTable(unzippedDTO);
            string dataXmlNew = DataTableSerializer.Serialize(viewData);
            Assert.AreEqual(SerializedViewStub.DataXml, dataXmlNew);
        }

        [TestMethod]
        public void ViewFacedeSemaphoreTest()
        {
            int taskNumber = 0;
            var facade = new AVRFacadeStub(123);

            const int taskCount = 10;
            Action act = () =>
            {
                var number = Interlocked.Increment(ref taskNumber);
                Console.WriteLine("->View task {0} started", number);
                ViewDTO model = facade.GetCachedView("xxx", -1, "en");
                Console.WriteLine("<-View task {0} finished", number);
            };
            Task[] tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = new Task(act);
            }
            foreach (var task in tasks)
            {
                task.Start();
            }
            Task.WaitAll(tasks);
        }
    }
}