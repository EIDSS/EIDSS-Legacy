using System.Collections.Generic;
using System.Data;
using EIDSS.RAM.Components;
using EIDSS.Tests.RAM.Helpers;
using NUnit.Framework;

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class DistinctCounterTests
    {
        [Test]
        public void OneColumnSmallTest()
        {
            DataTable dataTable = DataHelper.GenerateTestTable();
            DistinctCounter counter = new DistinctCounter(dataTable);

            int count1 = counter.DistinctCount(PrepareList(new string[] {"column1"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(5, count1);

            int count3 = counter.DistinctCount(PrepareList(new string[] {"column3"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(3, count3);
        }

        [Test]
        public void MiltiColumnSmallTest()
        {
            DataTable dataTable = DataHelper.GenerateTestTable();
            DistinctCounter counter = new DistinctCounter(dataTable);

            int count13 = counter.DistinctCount(PrepareList(new string[] {"column1", "column3"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(10, count13);

            int count31 = counter.DistinctCount(PrepareList(new string[] {"column3", "column1"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(10, count31);
        }

        [Test]
        public void OneColumnBigTest()
        {
            DataTable dataTable = GenerateCounterTable();
            DistinctCounter counter = new DistinctCounter(dataTable);

            int count1 = counter.DistinctCount(PrepareList(new string[] {"column1"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(5, count1);

            int count2 = counter.DistinctCount(PrepareList(new string[] {"column2"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(4, count2);

            int count3 = counter.DistinctCount(PrepareList(new string[] {"column3"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(3, count3);
        }

        [Test]
        public void MiltiColumnBigTest()
        {
            DataTable dataTable = GenerateCounterTable();
            DistinctCounter counter = new DistinctCounter(dataTable);

            int count12 = counter.DistinctCount(PrepareList(new string[] {"column1", "column2"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(20, count12);
            int count21 = counter.DistinctCount(PrepareList(new string[] {"column2", "column1"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(20, count21);

            int count13 = counter.DistinctCount(PrepareList(new string[] {"column1", "column3"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(15, count13);
            int count31 = counter.DistinctCount(PrepareList(new string[] {"column3", "column1"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(15, count31);

            int count23 = counter.DistinctCount(PrepareList(new string[] {"column2", "column3"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(12, count23);
            int count32 = counter.DistinctCount(PrepareList(new string[] {"column3", "column2"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(12, count32);

            int count123 = counter.DistinctCount(PrepareList(new string[] {"column1", "column2", "column3"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(60, count123);
            int count321 = counter.DistinctCount(PrepareList(new string[] {"column3", "column2", "column1"}), "[sflHC_CaseID] Is Not Null And [sflHC_PatientAge] < 100");
            Assert.AreEqual(60, count321);
        }

        private static List<string> PrepareList(IEnumerable<string> items)
        {
            List<string> result = new List<string>();
            result.AddRange(items);
            return result;
        }

        public static DataTable GenerateCounterTable()
        {
            DataTable dataTable = new DataTable("testTable");
            dataTable.Columns.Add(DataHelper.GenerateColumn("column1", typeof (int)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("column2", typeof (int)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("column3", typeof (int)));
            dataTable.Columns.Add(DataHelper.GenerateColumn("column4", typeof (string)));
            for (int i = 0; i < 300; i++)
            {
                DataRow workRow = dataTable.NewRow();
                workRow[0] = i%5;
                workRow[1] = i%4;
                workRow[2] = i%3;
                workRow[3] = "test" + i;
                dataTable.Rows.Add(workRow);
            }
            return dataTable;
        }
    }
}