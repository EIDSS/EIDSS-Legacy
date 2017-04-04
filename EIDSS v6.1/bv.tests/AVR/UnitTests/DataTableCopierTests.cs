using System;
using System.Threading;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.tests.AVR.IntegrationTests;
using bv.tests.Core;
using EIDSS;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Complexity;
using eidss.avr.db.DBService.DataTableCopier;
using eidss.model.AVR.SourceData;
using eidss.model.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class DataTableCopierTests
    {
        private static readonly object m_SyncLock = new object();
        private static CachedQueryResult m_TestTable;
        private static CachedQueryResult m_TestMixedTable;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            string scriptPath = PathToTestFolder.Get(TestFolders.Db) + "Data\\CreateTestTables.sql";
            DbManagerFactory.SetSqlFactory(Config.GetSetting("TestConnectionString"));
            ScriptLoader.RunScript(scriptPath);

            m_TestTable = CreateTestTable();
            m_TestMixedTable = CreateMixedTestTable();
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            EIDSS_LookupCacheHelper.Init();
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        public void ConstructorMultiThreadTest()
        {
            using (new AvrDataTableCopierMultiThread(CopyTestTable()))
            {
            }
        }

        [TestMethod]
        public void ConstructorSingleThreadTest()
        {
            using (new AvrDataTableCopier(CopyTestTable()))
            {
            }
        }

        [TestMethod]
        public void DoubleDisposeMultiThreadTest()
        {
            var copier = new AvrDataTableCopierMultiThread(CopyTestTable());
            copier.Dispose();
            copier.Dispose();
        }

        [TestMethod]
        public void DoubleDisposeSingleThreadTest()
        {
            var copier = new AvrDataTableCopier(CopyTestTable());
            copier.Dispose();
            copier.Dispose();
        }

        [TestMethod]
        public void DisposeAndCopyMultiThreadTest()
        {
            try
            {
                var copier = new AvrDataTableCopierMultiThread(CopyTestTable());
                copier.Dispose();
                copier.GetCopy();
            }
            catch (ObjectDisposedException ex)
            {
                Assert.AreEqual("DataTableCopier", ex.ObjectName);
            }
        }

        [TestMethod]
        public void DisposeAndCopySingleThreadTest()
        {
            try
            {
                var copier = new AvrDataTableCopier(CopyTestTable());
                copier.Dispose();
                copier.GetCopy(string.Empty);
            }
            catch (ObjectDisposedException ex)
            {
                Assert.AreEqual("DataTableCopier", ex.ObjectName);
            }
        }

        [TestMethod]
        public void ImmediatlyCopyMultiThreadTest()
        {
            CachedQueryResult source = CopyMixedTestTable();
            using (var copier = new AvrDataTableCopierMultiThread(source))
            {
                AvrDataTable copy1 = copier.GetCopy();

                Assert.AreSame(source.QueryTable, copy1);
                Assert.AreEqual(source.QueryTable.Rows.Count, copy1.Rows.Count);

                AvrDataTable copy2 = copier.GetCopy();
                Assert.AreNotSame(copy2, copy1);
                Assert.AreNotEqual(copy2.Rows.Count, copy1.Rows.Count);

                AvrDataTable copy3 = copier.GetCopy();
                Assert.AreNotSame(copy3, copy1);
                Assert.AreNotSame(copy3, copy2);
                Assert.AreNotEqual(copy3.Rows.Count, copy1.Rows.Count);
                Assert.AreEqual(copy3.Rows.Count, copy3.Rows.Count);
            }
        }

        [TestMethod]
        public void ImmediatlyCopySingleThreadTest()
        {
            CachedQueryResult source = CopyMixedTestTable();
            using (var copier = new AvrDataTableCopier(source))
            {
                AvrDataTable copy1 = copier.GetCopy(string.Empty);

                Assert.AreSame(source.QueryTable, copy1);
                Assert.AreEqual(source.QueryTable.Rows.Count, copy1.Rows.Count);

                AvrDataTable copy2 = copier.GetCopy(string.Empty);
                Assert.AreNotSame(copy2, copy1);
                Assert.AreNotEqual(copy2.Rows.Count, copy1.Rows.Count);

                AvrDataTable copy3 = copier.GetCopy(string.Empty);
                Assert.AreNotSame(copy3, copy1);
                Assert.AreNotSame(copy3, copy2);
                Assert.AreNotEqual(copy3.Rows.Count, copy1.Rows.Count);
                Assert.AreEqual(copy3.Rows.Count, copy3.Rows.Count);
            }
        }

        [TestMethod]
        public void ImmediatlyForceMultiCopyTest()
        {
            CachedQueryResult source = CopyTestTable();
            using (var copier = new AvrDataTableCopierMultiThread(source))
            {
                Assert.AreEqual(1, copier.QueueCount);
                copier.ForceStart();
                Thread.Sleep(300);
                // copier thread already created copy 
                Assert.AreEqual(AvrDataTableCopierMultiThread.MaxCopies, copier.QueueCount);

                for (int i = 0; i < AvrDataTableCopierMultiThread.MaxCopies; i++)
                {
                    copier.GetCopy();
                    copier.Continue();
                }

                Thread.Sleep(300);

                // copier thread already created copy 
                Assert.AreEqual(AvrDataTableCopierMultiThread.MaxCopies, copier.QueueCount);
            }
        }

        [TestMethod]
        public void ImmediatlyMultiCopyTest()
        {
            CachedQueryResult source = CopyTestTable();
            using (var copier = new AvrDataTableCopierMultiThread(source))
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(@"Creating copy {0} in sequance", i);
                    AvrDataTable copy = copier.GetCopy();
                    Thread.Sleep(100);

                    Assert.AreNotSame(source, copy);
                    Assert.AreEqual(source.QueryTable.Rows.Count, copy.Rows.Count);
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(@"Creating copy {0} in parallel", i);
                    AvrDataTable copy = copier.GetCopy();
                    copier.Continue();
                    Thread.Sleep(100);

                    Assert.AreNotSame(source, copy);
                    Assert.AreEqual(source.QueryTable.Rows.Count, copy.Rows.Count);
                }
            }
        }

        [TestMethod]
        public void DefferedMultiCopyTest()
        {
            CachedQueryResult source = CopyTestTable();
            using (var copier = new AvrDataTableCopierMultiThread(source))
            {
                Assert.AreEqual(1, copier.QueueCount);
                copier.GetCopy();
                Thread.Sleep(300);
                Assert.AreEqual(0, copier.QueueCount);

                copier.Continue();
                Thread.Sleep(500);
                // copier thread already created copy 
                Assert.AreEqual(AvrDataTableCopierMultiThread.MaxCopies, copier.QueueCount);

                for (int i = 0; i < AvrDataTableCopierMultiThread.MaxCopies; i++)
                {
                    copier.GetCopy();
                    copier.Continue();
                }

                Thread.Sleep(500);
                // copier thread already created copy 
                Assert.AreEqual(AvrDataTableCopierMultiThread.MaxCopies, copier.QueueCount);
            }
        }

        private static CachedQueryResult CopyMixedTestTable()
        {
            lock (m_SyncLock)
            {
                return new CachedQueryResult(1, m_TestMixedTable.QueryTable.Copy(), m_TestMixedTable.QueryHeader,
                    m_TestMixedTable.QueryPackets);
            }
        }

        private static CachedQueryResult CopyTestTable()
        {
            lock (m_SyncLock)
            {
                return new CachedQueryResult(1, m_TestTable.QueryTable.Copy(), m_TestTable.QueryHeader, m_TestTable.QueryPackets);
            }
        }

        private static CachedQueryResult CreateTestTable()
        {
            var avrFacade = new AVRFacadeStub(123);
            var receiver = new AvrCacheReceiver(avrFacade);

            CachedQueryResult result = receiver.GetCachedQueryTable(1, "en", false, string.Empty, new LayoutSilentValidatorWaiter());

            return result;
        }

        private static CachedQueryResult CreateMixedTestTable()
        {
            var table = new AvrDataTable();
            table.Columns.Add("xx", typeof (int));
            table.Columns.Add("yy", typeof (int));
            table.Columns.Add("zz", typeof (int));
            for (int i = 0; i < 200; i++)
            {
                AvrDataRowBase newRow = table.NewRow(new object[] {1, 2, 3});
                table.Rows.Add(newRow);
            }

            var avrFacade = new AVRFacadeStub(123);
            var receiver = new AvrCacheReceiver(avrFacade);

            CachedQueryResult result = receiver.GetCachedQueryTable(1, "en", false, string.Empty, new LayoutSilentValidatorWaiter());

            return new CachedQueryResult(1, table, result.QueryHeader, result.QueryPackets);
        }
    }
}