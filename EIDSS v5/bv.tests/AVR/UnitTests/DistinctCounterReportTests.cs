using System.Collections.Generic;
using System.Data;
using EIDSS.RAM.Tools;
using bv.tests.AVR.Helpers;
using EIDSS;
using EIDSS.RAM.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class DistinctCounterReportTests : BaseReportTests
    {
        const string Filter = "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100";

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
        public void OneColumnSmallTest()
        {
            DataTable dataTable = DataHelper.GenerateTestTable();
            var counter = new DistinctCounter(dataTable);

            int count1 = counter.DistinctCount(PrepareList(new[] { "sflHC_PatientAge" }),Filter);
            Assert.AreEqual(5, count1);

            int count3 = counter.DistinctCount(PrepareList(new[] { "sflHC_CaseID" }),Filter);
            Assert.AreEqual(3, count3);
        }

        [TestMethod]
        public void MiltiColumnSmallTest()
        {
            DataTable dataTable = DataHelper.GenerateTestTable();
            var counter = new DistinctCounter(dataTable);

            int count13 = counter.DistinctCount(PrepareList(new[] {"sflHC_PatientAge", "sflHC_CaseID"}),Filter);
            Assert.AreEqual(10, count13);

            int count31 = counter.DistinctCount(PrepareList(new[] {"sflHC_CaseID", "sflHC_PatientAge"}),Filter);
            Assert.AreEqual(10, count31);
        }

        [TestMethod]
        public void OneColumnBigTest()
        {
            DataTable dataTable = GenerateCounterTable();
            var counter = new DistinctCounter(dataTable);

            
            int count1 = counter.DistinctCount(PrepareList(new[] {"sflHC_PatientAge"}),Filter);
            Assert.AreEqual(5, count1);

            int count2 = counter.DistinctCount(PrepareList(new[] {"column2"}),Filter);
            Assert.AreEqual(4, count2);

            int count3 = counter.DistinctCount(PrepareList(new[] {"sflHC_CaseID"}),Filter);
            Assert.AreEqual(3, count3);
        }

        [TestMethod]
        public void MiltiColumnBigTest()
        {
            DataTable dataTable = GenerateCounterTable();
            var counter = new DistinctCounter(dataTable);

            int count12 = counter.DistinctCount(PrepareList(new[] {"sflHC_PatientAge", "column2"}),Filter);
            Assert.AreEqual(20, count12);
            int count21 = counter.DistinctCount(PrepareList(new[] {"column2", "sflHC_PatientAge"}),Filter);
            Assert.AreEqual(20, count21);

            int count13 = counter.DistinctCount(PrepareList(new[] {"sflHC_PatientAge", "sflHC_CaseID"}),Filter);
            Assert.AreEqual(15, count13);
            int count31 = counter.DistinctCount(PrepareList(new[] {"sflHC_CaseID", "sflHC_PatientAge"}),Filter);
            Assert.AreEqual(15, count31);

            int count23 = counter.DistinctCount(PrepareList(new[] {"column2", "sflHC_CaseID"}),Filter);
            Assert.AreEqual(12, count23);
            int count32 = counter.DistinctCount(PrepareList(new[] {"sflHC_CaseID", "column2"}),Filter);
            Assert.AreEqual(12, count32);

            int count123 = counter.DistinctCount(PrepareList(new[] {"sflHC_PatientAge", "column2", "sflHC_CaseID"}),Filter);
            Assert.AreEqual(60, count123);
            int count321 = counter.DistinctCount(PrepareList(new[] {"sflHC_CaseID", "column2", "sflHC_PatientAge"}),Filter);
            Assert.AreEqual(60, count321);
        }

        private static List<string> PrepareList(IEnumerable<string> items)
        {
            var result = new List<string>();
            result.AddRange(items);
            return result;
        }

        public static DataTable GenerateCounterTable()
        {
            var dataTable = new DataTable("testTable");
            dataTable.Columns.Add(DataHelper.GenerateColumn("sflHC_PatientAge", typeof (long)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("column2", typeof(long)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("sflHC_CaseID", typeof(long)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("column4", typeof (string)));
            for (int i = 0; i < 300; i++)
            {
                DataRow workRow = dataTable.NewRow();
                workRow[0] = i % 5;
                workRow[1] = i % 4;
                workRow[2] = i % 3;
                workRow[3] = "test" + i;
                dataTable.Rows.Add(workRow);
            }
            return dataTable;
        }
    }
}
