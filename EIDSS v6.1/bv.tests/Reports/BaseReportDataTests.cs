using System;
using System.Data;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.tests.common;
using bv.tests.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.Reports
{
    [TestClass]
    public class BaseReportDataTests : EidssEnvWithLogin
    {

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.LoadAssemblies();
        }

        [TestInitialize]
        public override void MyTestInitialize()
        {
          
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials().ConnectionString);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
           
        }
        [TestMethod]
        public void FillPlainDataWithoutArchiveTest()
        {
            var report = new BaseReportStub();
            report.FillPlainData(ReportArchiveMode.ActualOnly);
            Assert.AreEqual(4, report.DataSet.Table.Count);

            DataTable table = report.DataSet.Table.DefaultView.ToTable();

            Assert.AreEqual(DBNull.Value, table.Rows[0]["Number"]);
            Assert.AreEqual(0.0, table.Rows[0]["Double"]);

            Assert.AreEqual(DBNull.Value, table.Rows[0]["Disease"]);
            Assert.AreEqual("A", table.Rows[1]["Disease"]);
        }

        [TestMethod]
        public void FillPlainlDataWithArchiveTest()
        {
            var report = new BaseReportStub();
            report.FillPlainData(ReportArchiveMode.ActualWithArchive);
            Assert.AreEqual(8, report.DataSet.Table.Count);

            DataTable table = report.DataSet.Table.DefaultView.ToTable();
            Assert.AreEqual(DBNull.Value, table.Rows[0]["Disease"]);
            Assert.AreEqual(DBNull.Value, table.Rows[1]["Disease"]);
            Assert.AreEqual("A", table.Rows[2]["Disease"]);
            Assert.AreEqual("B", table.Rows[3]["Disease"]);
            Assert.AreEqual("B", table.Rows[4]["Disease"]);
        }

        [TestMethod]
        public void FillSummaryDataWithoutArchiveTest()
        {
            var report = new BaseReportStub();
            report.FillSummaryData(ReportArchiveMode.ActualOnly);
            Assert.AreEqual(4, report.DataSet.Table.Count);

            DataTable table = report.DataSet.Table.DefaultView.ToTable();
            Assert.AreEqual("A", table.Rows[1]["Disease"]);
            Assert.AreEqual(1L, table.Rows[1]["Number"]);
            Assert.AreEqual(1.1, table.Rows[1]["Double"]);
        }

        [TestMethod]
        public void FillSummaryDataWithArchiveTest()
        {
            var report = new BaseReportStub();
            report.FillSummaryData(ReportArchiveMode.ActualWithArchive);
            Assert.AreEqual(5, report.DataSet.Table.Count);

            DataTable table = report.DataSet.Table.DefaultView.ToTable();
            Assert.AreEqual(DBNull.Value, table.Rows[0]["Disease"]);
            Assert.AreEqual("B", table.Rows[2]["Disease"]);
            Assert.AreEqual("C", table.Rows[3]["Disease"]);

            Assert.AreEqual(DBNull.Value, table.Rows[0]["Number"]);
            Assert.AreEqual(1L, table.Rows[1]["Number"]);
            Assert.AreEqual(20L, table.Rows[2]["Number"]);
            Assert.AreEqual(33L, table.Rows[3]["Number"]);
            Assert.AreEqual(40L, table.Rows[4]["Number"]);

            Assert.AreEqual(0.0, table.Rows[0]["Double"]);
            Assert.AreEqual(1.1, table.Rows[1]["Double"]);
            Assert.AreEqual(2.1, table.Rows[2]["Double"]);
            Assert.AreEqual(33.2, table.Rows[3]["Double"]);
            Assert.AreEqual(40.1, table.Rows[4]["Double"]);

            Assert.AreEqual(new DateTime(2000, 01, 02), table.Rows[1]["Date"]);
            Assert.AreEqual(new DateTime(2000, 02, 02), table.Rows[2]["Date"]);
            Assert.AreEqual(new DateTime(2000, 03, 02), table.Rows[3]["Date"]);
            Assert.AreEqual(new DateTime(2000, 04, 20), table.Rows[4]["Date"]);

            Assert.AreEqual("d1", table.Rows[1]["Description"]);
            Assert.AreEqual("d2", table.Rows[2]["Description"]);
            Assert.AreEqual("d3", table.Rows[3]["Description"]);
            Assert.AreEqual("d40", table.Rows[4]["Description"]);
        }

        [TestMethod]
        public void FillSummaryDataWithArchiveMultyKeysTest()
        {
            var report = new BaseReportStub();
            report.FillSummaryDataWithMultiKey(ReportArchiveMode.ActualWithArchive);
            Assert.AreEqual(6, report.DataSet.Table.Count);

            DataTable table = report.DataSet.Table.DefaultView.ToTable();

            Assert.AreEqual(DBNull.Value, table.Rows[0]["Disease"]);
            Assert.AreEqual("A", table.Rows[1]["Disease"]);
            Assert.AreEqual("B", table.Rows[2]["Disease"]);
            Assert.AreEqual("B", table.Rows[3]["Disease"]);
            Assert.AreEqual("C", table.Rows[4]["Disease"]);
            Assert.AreEqual("D", table.Rows[5]["Disease"]);
        }
    }
}