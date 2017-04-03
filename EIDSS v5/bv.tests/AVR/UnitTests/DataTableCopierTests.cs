using System;
using System.Data;
using System.Threading;
using EIDSS.RAM_DB.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class DataTableCopierTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            using (new DataTableCopier(CreateTestTable()))
            {
            }
        }

        [TestMethod]
        public void DoubleDisposeTest()
        {
            var copier = new DataTableCopier(CreateTestTable());
            copier.Dispose();
            copier.Dispose();
        }

        [TestMethod]
        public void DisposeAndCopyTest()
        {
            try
            {
                var copier = new DataTableCopier(CreateTestTable());
                copier.Dispose();
                copier.GetCopy();
            }
            catch (ObjectDisposedException ex)
            {
                Assert.AreEqual("DataTableCopier", ex.ObjectName);
            }
        }

        [TestMethod]
        public void ImmediatlySingleCopyTest()
        {
            DataTable source = CreateTestTable();
            using (var copier = new DataTableCopier(source))
            {
                DataTable copy = copier.GetCopy();

                Assert.AreNotSame(source, copy);
                Assert.AreEqual(source.Rows.Count, copy.Rows.Count);
            }
        }

        [TestMethod]
        public void ImmediatlyForceMultiCopyTest()
        {
            DataTable source = CreateTestTable();
            using (var copier = new DataTableCopier(source))
            {
                Assert.AreEqual(0, copier.QueueCount);
                Thread.Sleep(100);
                Assert.AreEqual(0, copier.QueueCount);
                copier.ForceStart();
                

                Thread.Sleep(100);
                // copier thread already created copy 
                Assert.AreEqual(DataTableCopier.MaxCopies, copier.QueueCount);

                for (int i = 0; i < DataTableCopier.MaxCopies; i++)
                {
                    copier.GetCopy();
                }

                Thread.Sleep(100);
                // copier thread already created copy 
                Assert.AreEqual(DataTableCopier.MaxCopies, copier.QueueCount);
            }
        }

        [TestMethod]
        public void ImmediatlyMultiCopyTest()
        {
            DataTable source = CreateTestTable();
            using (var copier = new DataTableCopier(source))
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(@"Creating copy {0}", i);
                    DataTable copy = copier.GetCopy();

                    Assert.AreNotSame(source, copy);
                    Assert.AreEqual(source.Rows.Count, copy.Rows.Count);
                }
            }
        }

        [TestMethod]
        public void DefferedMultiCopyTest()
        {
            DataTable source = CreateTestTable();
            using (var copier = new DataTableCopier(source))
            {
                Thread.Sleep(100);
                Assert.AreEqual(0, copier.QueueCount);
                copier.GetCopy();

                Thread.Sleep(100);
                // copier thread already created copy 
                Assert.AreEqual(DataTableCopier.MaxCopies, copier.QueueCount);

                for (int i = 0; i < DataTableCopier.MaxCopies; i++)
                {
                    copier.GetCopy();
                }

                Thread.Sleep(100);
                // copier thread already created copy 
                Assert.AreEqual(DataTableCopier.MaxCopies, copier.QueueCount);
            }
        }

        public static DataTable CreateTestTable()
        {
            var table = new DataTable();
            table.Columns.Add("xx");
            table.Columns.Add("yy");
            table.Columns.Add("zz");
            for (int i = 0; i < 100; i++)
            {
                table.Rows.Add(table.NewRow());
            }
            return table;
        }
    }
}