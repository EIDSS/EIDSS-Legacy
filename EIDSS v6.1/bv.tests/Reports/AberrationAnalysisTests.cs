using bv.common.Core;
using EIDSS.Reports.AberrationAnalysis;
using EIDSS.Reports.Parameterized.AberrationAnalysis.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.Reports
{
    [TestClass]
    public class AberrationAnalysisTests
    {
        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void AberrationAlgorithmTest()
        {
            var dataTable = new AberrationDataSet.AberrationDataDataTable();
            dataTable.Rows.Add(0, "2001.01.01", 3);
            dataTable.Rows.Add(1, "2001.01.02", 2);
            dataTable.Rows.Add(2, "2001.01.03", 0);
            dataTable.Rows.Add(3, "2001.01.04", 15);
            dataTable.Rows.Add(4, "2001.01.05", 1);
            dataTable.Rows.Add(5, "2001.01.06", 17);
            dataTable.Rows.Add(6, "2001.01.07", 3);
            dataTable.Rows.Add(7, "2001.01.08", 0);
            dataTable.Rows.Add(8, "2001.01.09", 0);
            dataTable.Rows.Add(9, "2001.01.10", 4);
            dataTable.Rows.Add(10, "2001.01.11", 0);
            dataTable.Rows.Add(11, "2001.01.12", 5);
            dataTable.Rows.Add(12, "2001.01.13", 2);
            dataTable.Rows.Add(13, "2001.01.14", 1);
            dataTable.Rows.Add(14, "2001.01.15", 1);
            dataTable.Rows.Add(15, "2001.01.16", 4);
            dataTable.Rows.Add(16, "2001.01.17", 4);
            dataTable.Rows.Add(17, "2001.01.18", 7);
            dataTable.Rows.Add(18, "2001.01.19", 0);
            dataTable.Rows.Add(19, "2001.01.20", 2);
            dataTable.Rows.Add(20, "2001.01.21", 10);
            dataTable.Rows.Add(21, "2001.01.22", 4);
            dataTable.Rows.Add(22, "2001.01.23", 5);
            dataTable.Rows.Add(23, "2001.01.24", 4);
            //fill test values
            var expected_e = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0, 6.33, 6.33, 6, 6, 4.17, 4, 2, 1.83, 2, 2.17, 2.17, 2.83, 3.17, 2.83, 3, 4.5 };
            var aberrations_e = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.4722, 0.9257, 2.9161, 1.2997, 0.3159, 2.7656, 2.7076, 2.9982, 2.3579 };

            int Baseline = 6;
            int Lag = 2;
            int Threshold = 5;

            //run
            AberrationAlgorithm.Calculate(dataTable, Baseline, Lag, Threshold); //, out expected, out aberrations, out thresholds);

            //check result of test run
            for (int i = Baseline + Lag; i < dataTable.Rows.Count; i++)
            {
                Assert.AreEqual(expected_e[i], (double) (decimal) dataTable.Rows[i]["expected"], 0.01);
                Assert.AreEqual(aberrations_e[i], (double) (decimal) dataTable.Rows[i]["aberrations"], 0.0001);
            }
        }
    }
}