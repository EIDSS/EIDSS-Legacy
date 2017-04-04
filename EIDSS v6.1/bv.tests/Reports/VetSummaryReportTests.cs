using System.Collections.Generic;
using System.Data;
using bv.tests.common;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.Reports
{
    [TestClass]
    public class VetSummaryReportTests
    {
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.LoadAssemblies();
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
        }

     
        [TestMethod]
        public void RemoveAndAddColumnToArchiveTest()
        {
            VetSummaryDataSet actual = GetActualDataSet();
            VetSummaryDataSet archive = GetArchiveDataSet();

            ReportArchiveHelper.RemoveAndAddColumnToArchive(actual.spRepVetSummaryAZ, archive.spRepVetSummaryAZ);


            var row = archive.spRepVetSummaryAZ[0];
            Assert.AreEqual("Horse", row["strSpecies_1"]);
            Assert.AreEqual("Hare/Rabbit", row["strSpecies_3"]);

            Assert.AreEqual(21, row["intFirstSubcolumn_1"]);
            Assert.AreEqual(22, row["intSecondSubcolumn_1"]);
        }

        private static VetSummaryDataSet GetActualDataSet()
        {
            var data = new VetSummaryDataSet();
            VetSummaryDataSet.spRepVetSummaryAZRow row = data.spRepVetSummaryAZ.NewspRepVetSummaryAZRow();
            row.intRegionOrder = 1;
            row.strRegion = "Baku";
            row.strRayon = "Binegedi (Baku)";

            row.strSpecies_1 = "Horse";
            row.intFirstSubcolumn_1 = 11;
            row.intSecondSubcolumn_1 = 12;

            row.strSpecies_2 = "Cat";
            row.intFirstSubcolumn_2 = 21;
            row.intSecondSubcolumn_2 = 22;

            row.strSpecies_3 = "Hare/Rabbit";
            row.intFirstSubcolumn_3 = 31;
            row.intSecondSubcolumn_3 = 32;
            data.spRepVetSummaryAZ.AddspRepVetSummaryAZRow(row);
            return data;
        }

        private static VetSummaryDataSet GetArchiveDataSet()
        {
            var data = new VetSummaryDataSet();
            VetSummaryDataSet.spRepVetSummaryAZRow row = data.spRepVetSummaryAZ.NewspRepVetSummaryAZRow();

            row.intRegionOrder = 1;
            row.strRegion = "Baku";
            row.strRayon = "Binegedi (Baku)";

            row.strSpecies_1 = "Small cattle";
            row.intFirstSubcolumn_1 = 11;
            row.intSecondSubcolumn_1 = 12;

            row.strSpecies_2 = "Horse";
            row.intFirstSubcolumn_2 = 21;
            row.intSecondSubcolumn_2 = 22;

            row.strSpecies_3 = "Hare/Rabbit";
            row.intFirstSubcolumn_3 = 31;
            row.intSecondSubcolumn_3 = 32;

            data.spRepVetSummaryAZ.AddspRepVetSummaryAZRow(row);
            return data;
        }
    }
}