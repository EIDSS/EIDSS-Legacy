//using System.Collections.Generic;
//using System.Data;
//using System.Threading;
//using EIDSS.RAM_DB.Common;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//
//namespace bv.tests.AVR.UnitTests
//{
//    [TestClass]
//    public class DataTableCleanerTests
//    {
//        [TestMethod]
//        public void ConstructorTest()
//        {
//            using (new DataTableCleaner())
//            {
//            }
//        }
//
//        [TestMethod]
//        public void DoubleDisposeTest()
//        {
//            var cleaner = new DataTableCleaner();
//            cleaner.Dispose();
//            cleaner.Dispose();
//        }
//
//        [TestMethod]
//        public void CleanTest()
//        {
//            using (var cleaner = new DataTableCleaner())
//            {
//                Assert.AreEqual(0, cleaner.QueueCount);
//                const int tableCount = 10;
//                var tables = new List<DataTable>();
//                for (int i = 0; i < tableCount; i++)
//                {
//                    DataTable table = CreateTestTable();
//                    tables.Add(table);
//                    Assert.AreEqual(1, table.Rows.Count);
//                }
//
//                foreach (DataTable table in tables)
//                {
//                    cleaner.Enqueue(table);
//                }
//
//                Assert.IsTrue(cleaner.QueueCount > 0);
//                Thread.Sleep(1000);
//
//                Assert.AreEqual(0, cleaner.QueueCount);
//                foreach (DataTable table in tables)
//                {
//                    Assert.AreEqual(0, table.Rows.Count);
//                }
//            }
//        }
//
//        [TestMethod]
//        public void ParallelTest()
//        {
//            var cleaner1 = new DataTableCleaner();
//            var cleaner2 = new DataTableCleaner();
//            DataTable table1 = CreateTestTable();
//            cleaner1.Enqueue(table1);
//            Assert.AreEqual(1, cleaner1.QueueCount);
//            Assert.AreEqual(0, cleaner2.QueueCount);
//            Thread.Sleep(200);
//            Assert.AreEqual(0, cleaner1.QueueCount);
//
//            cleaner1.Dispose();
//            cleaner2.Dispose();
//        }
//
//        private static DataTable CreateTestTable()
//        {
//            var table = new DataTable();
//            table.Columns.Add("xx");
//            table.Rows.Add(table.NewRow());
//            return table;
//        }
//    }
//}