using System;
using System.Collections.Generic;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;

namespace bv.tests.Reports
{
    [TestClass]
    public class VetLabReportTests
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
        public void RemoveTestColumnsEmptyTest()
        {
            var data = new VetLabReportDataSet();
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("intTest_1"));

            VetLabReport.RemoveTestColumnsIfEmpty(data.spRepVetLabReportAZ);
            Assert.IsFalse(data.spRepVetLabReportAZ.Columns.Contains("intTest_1"));
        }

        [TestMethod]
        public void RemoveTestColumnsFullTest()
        {
            VetLabReportDataSet data = GetFilledDataSet("test_name");

            VetLabReport.RemoveTestColumnsIfEmpty(data.spRepVetLabReportAZ);
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("intTest_1"));
        }

        [TestMethod]
        public void SetTestNameCaptionsTest()
        {
            VetLabReportDataSet data = GetFilledDataSet("test_name");
            List<string> nameCaptions = VetLabReport.SetTestNameCaptions(data.spRepVetLabReportAZ);
            Assert.AreEqual(1, nameCaptions.Count);
            Assert.AreEqual("test_name", nameCaptions[0]);

            Assert.AreEqual("test_name", data.spRepVetLabReportAZ.Columns["strTestName_1"].Caption);
        }

        [TestMethod]
        public void AddMissingColumnsTest()
        {
            VetLabReportDataSet data = GetFilledDataSet("test_name");
            VetLabReport.SetTestNameCaptions(data.spRepVetLabReportAZ);
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("strTestName_1"));
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("intTest_1"));

            var nameCaptions = new List<string> {"test_aaa", "test_name", "test_zzz"};
            VetLabReport.AddMissingColumns(data.spRepVetLabReportAZ, nameCaptions);

            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("strTestName_1"));
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("intTest_1"));
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("strTestName_2"));
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("intTest_2"));
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("strTestName_3"));
            Assert.IsTrue(data.spRepVetLabReportAZ.Columns.Contains("intTest_3"));

            Assert.AreEqual("test_aaa", data.spRepVetLabReportAZ.Columns["strTestName_1"].Caption);
            Assert.AreEqual("test_name", data.spRepVetLabReportAZ.Columns["strTestName_2"].Caption);
            Assert.AreEqual("test_zzz", data.spRepVetLabReportAZ.Columns["strTestName_3"].Caption);
            Assert.AreEqual(DBNull.Value, data.spRepVetLabReportAZ.Rows[0]["intTest_1"]);
            Assert.AreEqual(2, data.spRepVetLabReportAZ.Rows[0]["intTest_2"]);
            Assert.AreEqual(DBNull.Value, data.spRepVetLabReportAZ.Rows[0]["intTest_3"]);
        }

        private static VetLabReportDataSet GetFilledDataSet(string strTestName)
        {
            var data = new VetLabReportDataSet();
            VetLabReportDataSet.spRepVetLabReportAZRow row = data.spRepVetLabReportAZ.NewspRepVetLabReportAZRow();
            row.strDiagnosisSpeciesKey = "11_222";
            row.idfsDiagnosis = 11;
            row.idfsSpeciesType = 22;
            row.intTest_1 = 2;
            row.strTestName_1 = strTestName;
            row.strDiagnosisName = "xxx";
            row.AmountOfSpecimenTaken = 1;
            data.spRepVetLabReportAZ.AddspRepVetLabReportAZRow(row);
            return data;
        }
    }
}