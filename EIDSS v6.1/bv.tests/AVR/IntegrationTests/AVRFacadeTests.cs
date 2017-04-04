using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.tests.AVR.Helpers;
using BLToolkit.Data;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Complexity;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.Trace;
using eidss.model.WindowsService;
using eidss.model.WindowsService.Serialization;
using EIDSS;
using EIDSS.AVR.Service.Scheduler;
using EIDSS.AVR.Service.WcfFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using StructureMap;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class AVRFacadeTests
    {
        private static int m_FieldCount;
        private static IContainer m_Container;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            m_Container = StructureMapContainerInit();

            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            m_FieldCount = DataHelper.GetQueryFieldsCount(49539640000000);
            EIDSS_LookupCacheHelper.Init();
        }

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { r.For<ITraceStrategy>().Use<TraceHelper>(); });
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use<SchedulerConfigurationStrategy>(); });
            return c;
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        [ExpectedException(typeof (AvrDataException))]
        public void FailGetCachedQueryTest()
        {
            (new AVRFacade(m_Container)).GetCachedQueryTableHeader(1, "en", false);
        }

        [TestMethod]
        public void RefreshedCacheOnUserCallAfterDaysTest()
        {
            var configuration = new SchedulerConfigurationSection
            {
                TimeOfSchedulerRuns = new TimeSpan(0, 0, 0, 0),
                ImmediatelyRunScheduler = false,
                RefreshedCacheOnUserCallAfterDays = 1,
                SecondsBetweenSchedulerTasks = 0,
            };

            var mocks = new Mockery();
            var configStrategy = mocks.NewMock<ISchedulerConfigurationStrategy>();
            Expect.Once.On(configStrategy).Method("GetConfigurationSection").Will(Return.Value(configuration));
            Expect.Once.On(configStrategy).Method("GetServiceDisplayName").Will(Return.Value("service name"));

            Container c = new Container();
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use(configStrategy); });
            Assert.AreEqual(1, (c.GetInstance<AVRFacade>()).RefreshedCacheOnUserCallAfterDays);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void RefreshedCacheOnUserCallAfterDaysConfigTest()
        {
            Assert.AreEqual(7, (new AVRFacade(m_Container)).RefreshedCacheOnUserCallAfterDays);
        }

        [TestMethod]
        public void GetCachedQueryTest()
        {
            AVRFacade facade;
            using (new StopwathTransaction("AVRFacade .ctor"))
            {
                facade = new AVRFacade(m_Container);
            }
            QueryTableHeaderDTO headerDTO;
            using (new StopwathTransaction("GetCachedQueryTableHeader"))
            {
                //fn_AVR_HumanCaseReport
                headerDTO = facade.GetCachedQueryTableHeader(49539640000000, "en", false);
            }
            var headerModel = new QueryTableHeaderModel(headerDTO);
            Assert.AreEqual(m_FieldCount, headerModel.ColumnCount);
            Assert.IsTrue(headerModel.ColumnTypeByName.Exists(c => c.Name == "sflHC_FinalDiagnosis"));
            Type stringType = headerModel.ColumnTypeByName.Find(c => c.Name == "sflHC_FinalDiagnosis").FinalType;
            Assert.AreEqual(typeof (string), stringType);
            Assert.IsTrue(headerModel.ColumnTypeByName.Exists(c => c.Name == "sflHC_FinalDiagnosisDate"));
            stringType = headerModel.ColumnTypeByName.Find(c => c.Name == "sflHC_FinalDiagnosisDate").FinalType;
            Assert.AreEqual(typeof (DateTime), stringType);

            for (int i = 0; i < headerDTO.PacketCount; i++)
            {
                QueryTablePacketDTO packetDTO;
                using (new StopwathTransaction("GetCachedQueryTablePacket " + i))
                {
                    packetDTO = facade.GetCachedQueryTablePacket(headerModel.QueryCacheId, i, headerDTO.PacketCount);
                }
                QueryTablePacketDTO unzipped;
                using (new StopwathTransaction(string.Format("-Unzip Packet #{0}", i)))
                {
                    unzipped = BinaryCompressor.Unzip(packetDTO);
                }
                StreamTablePacketDTO unzippedStream;
                using (new StopwathTransaction(string.Format("-Unzip Packet #{0} into stream", i)))
                {
                    unzippedStream = BinaryCompressor.UnzipStream(packetDTO);
                }

                AvrDataTable deserialized = new AvrDataTable(headerModel, 10240);
                using (new StopwathTransaction(string.Format("--Deserialize Packet #{0}", i)))
                {
                    BinarySerializer.DeserializeBodyPacket(unzipped, headerModel.ColumnTypes, deserialized);
                }

                AvrDataTable deserializedStream = new AvrDataTable(headerModel, 10240);
                using (new StopwathTransaction(string.Format("--Deserialize Packet #{0} into stream", i)))
                {
                    BinarySerializer.DeserializeBodyPacket(unzippedStream, headerModel.ColumnTypes, deserializedStream);
                }

                Assert.AreNotSame(deserialized, deserializedStream);
                Assert.AreEqual(deserialized.Count, deserializedStream.Count);
                Assert.AreEqual(deserialized.Columns.Count, deserializedStream.Columns.Count);

                int diagnosisIndex = headerModel.ColumnTypeByName
                    .Select(c => c.Name)
                    .TakeWhile(key => key != "sflHC_FinalDiagnosis")
                    .Count();

                bool found = false;
                for (int j = 0; j < deserialized.Count; j++)
                {
                    var row = (AvrDataRowEx) deserialized[j];
                    var rowStream = (AvrDataRowEx) deserializedStream[j];

                    Assert.AreNotSame(row, rowStream);
                    Assert.AreEqual(row.Count, rowStream.Count);
                    for (int k = 0; k < row.Count; k++)
                    {
                        Assert.AreEqual(row[k], rowStream[k]);
                    }

                    if (row[diagnosisIndex].ToString() == "Smallpox")
                    {
                        found = true;
                    }
                }

                Assert.IsTrue(found);
            }
        }

        [TestMethod]
        public void GetCachedMultiThreadQueryTest()
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManager command =
                    avrTran.Manager.SetCommand(
                        @" delete from dbo.ViewCachePacket delete from dbo.ViewCache delete from dbo.QueryCachePacket delete from dbo.QueryCache");
                command.ExecuteNonQuery();
            }

            var facade = new AVRFacade(m_Container);
            //fn_AVR_HumanCaseReport
            Func<int, string, QueryTableHeaderDTO> createDataTable = (timeout, lang) =>
            {
                Thread.Sleep(timeout);
                try
                {
                    return facade.GetCachedQueryTableHeader(49539640000000, lang, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return new QueryTableHeaderDTO();
                }
            };
            Action<int, string> invalidate = (timeout, lang) =>
            {
                Thread.Sleep(timeout);
                try
                {
                    facade.InvalidateQueryCacheForLanguage(49539640000000, lang);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            };
            Func<QueryTableHeaderDTO> getHeader = () =>
            {
                try
                {
                    return facade.GetCachedQueryTableHeader(49540070000000, "en", false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return new QueryTableHeaderDTO();
                }
            };

            var runningTasks = new List<Task<QueryTableHeaderDTO>>();
            // TODO: [ivan] make call of 100 tasks, but no more than 10 of them should run simultaneously
            for (int i = 0; i < 10; i++)
            {
                int tmp = i;
                Task.Factory.StartNew(() => invalidate(10 * tmp, "en"));
                runningTasks.Add(Task.Factory.StartNew(() => createDataTable(tmp, "en")));
                Task.Factory.StartNew(() => invalidate(10 * tmp, "ru"));
                runningTasks.Add(Task.Factory.StartNew(() => createDataTable(tmp, "ru")));
                Task.Factory.StartNew(getHeader);
            }

            Task.WaitAll(runningTasks.Select(t => (Task) t).ToArray());

            Task<QueryTableHeaderDTO> taskEn = runningTasks[0];
            Assert.IsTrue(taskEn.Result.PacketCount > 0);
            Assert.IsTrue(taskEn.Result.QueryCacheId > 0);
            Assert.IsTrue(taskEn.Result.BinaryHeader.RowCount > 0);

            Task<QueryTableHeaderDTO> taskRu = runningTasks[1];
            Assert.IsTrue(taskRu.Result.PacketCount > 0);
            Assert.IsTrue(taskRu.Result.QueryCacheId > 0);
            Assert.IsTrue(taskRu.Result.BinaryHeader.RowCount > 0);
        }

        [TestMethod]
        [ExpectedException(typeof (AvrException))]
        public void GetCachedQueryTwiceFailTest()
        {
            const long queryId = 49539640000000;
            const string lang = "en";

            var facade = new AVRFacade(m_Container);
            facade.InvalidateQueryCacheForLanguage(queryId, lang);

            //first run
            var receiver = new AvrCacheReceiver(facade);
            receiver.GetCachedQueryTable(queryId, lang, false, string.Empty, new LayoutSilentValidatorWaiter());
            receiver.GetCachedQueryTable(queryId, lang, false, string.Empty, new LayoutSilentValidatorWaiter());
        }

        [TestMethod]
        public void GetCachedQueryAndProcessTest()
        {
            const long queryId = 49539640000000;
            const string lang = "en";

            var facade = new AVRFacade(m_Container);
            facade.InvalidateQueryCacheForLanguage(queryId, lang);

            //first run
            var receiver = new AvrCacheReceiver(facade);
            CachedQueryResult result;

            using (new StopwathTransaction("+++GetCachedQueryTable+++"))
            {
                result = receiver.GetCachedQueryTable(queryId, lang, false, string.Empty, new LayoutSilentValidatorWaiter());
            }
            Assert.IsNotNull(result);
            Assert.AreEqual(m_FieldCount * 2, result.QueryTable.Columns.Count);
            Assert.IsTrue(1500 < result.QueryTable.Rows.Count);

            //second run
            receiver = new AvrCacheReceiver(facade);
            using (new StopwathTransaction("+++GetCachedQueryTable+++"))
            {
                result = receiver.GetCachedQueryTable(queryId, lang, false, string.Empty, new LayoutSilentValidatorWaiter());
            }
            Assert.IsNotNull(result);
            Assert.AreEqual(m_FieldCount * 2, result.QueryTable.Columns.Count);
            Assert.IsTrue(1500 < result.QueryTable.Rows.Count);
        }

        [TestMethod]
        public void GetConcreteCachedQueryAndProcessTest()
        {
            const long queryId = 49539640000000;
            const string lang = "en";
            var facade = new AVRFacade(m_Container);
            QueryTableHeaderDTO header = facade.GetConcreteCachedQueryTableHeader(0, queryId, lang, false);
            Assert.IsTrue(header.PacketCount > 0);
        }

        [TestMethod]
        public void GetArchiveCachedQueryAndProcessTest()
        {
            const long queryId = 49539640000000;
            const string lang = "en";

            var facade = new AVRFacade(m_Container);
            facade.InvalidateQueryCacheForLanguage(queryId, lang);

            //first run
            var receiver = new AvrCacheReceiver(facade);
            CachedQueryResult result;
            using (new StopwathTransaction("+++GetCachedQueryTable+++"))
            {
                result = receiver.GetCachedQueryTable(queryId, lang, true, string.Empty, new LayoutSilentValidatorWaiter());
            }
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.QueryTable);
            Assert.AreEqual(m_FieldCount * 2, result.QueryTable.Columns.Count);
            Assert.IsTrue(1500 * 2 < result.QueryTable.Rows.Count);
        }
    }
}