using System;
using System.Reflection;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.Human.CaseInvestigation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;

namespace bv.tests.Reports
{
    [TestClass]
    public class ReportDateRebinderTests
    {
        private readonly DateTime m_TestDatetime = new DateTime(2000, 1, 30, 11, 12, 13);
        private readonly BaseReport m_Report = new BaseReport();

        [TestInitialize]
        public void TestInitialize()
        {
            BaseReportTests.InitSupportedLanguages();
        }


        [TestMethod]
        public void ReflectionTest()
        {
            var report = new CaseInvestigationReport();
            FieldInfo field = typeof (CaseInvestigationReport).GetField("xrTableCell12",
                                                                        BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(field);
            var cell = (XRTableCell) field.GetValue(report);
            Assert.AreEqual("{0:dd/MM/yyyy}", cell.DataBindings[0].FormatString);

            var rebinder = new ReportRebinder("en", report);
            rebinder.RebindDateAndFontForReport();

            cell = (XRTableCell) field.GetValue(report);
            Assert.AreEqual("{0:M/d/yyyy}", cell.DataBindings[0].FormatString);
        }

        [TestMethod]
        public void ReflectionRussianTest()
        {
            var report = new CaseInvestigationReport();
            FieldInfo field = typeof (CaseInvestigationReport).GetField("xrTableCell12",
                                                                        BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(field);
            var cell = (XRTableCell) field.GetValue(report);
            Assert.AreEqual("{0:dd/MM/yyyy}", cell.DataBindings[0].FormatString);

            var rebinder = new ReportRebinder("ru", report);
            rebinder.RebindDateAndFontForReport();

            cell = (XRTableCell) field.GetValue(report);
            Assert.AreEqual("{0:dd.MM.yyyy}", cell.DataBindings[0].FormatString);
        }

        [TestMethod]
        public void RebinderDateRuTest()
        {
            var rebinder = new ReportRebinder("ru", m_Report);

            string dateString = rebinder.ToDateString(m_TestDatetime);
            Assert.AreEqual("30.01.2000", dateString);
        }

        [TestMethod]
        public void RebinderDateEnTest()
        {
            var rebinder = new ReportRebinder("en", m_Report);
            string dateString = rebinder.ToDateString(m_TestDatetime);
            Assert.AreEqual("1/30/2000", dateString);
        }

        [TestMethod]
        public void RebinderTimeRuTest()
        {
            var rebinder = new ReportRebinder("ru", m_Report);

            string dateString = rebinder.ToTimeString(m_TestDatetime);
            Assert.AreEqual("11:12", dateString);
        }

        [TestMethod]
        public void RebinderTimeEnTest()
        {
            var rebinder = new ReportRebinder("en", m_Report);
            string dateString = rebinder.ToTimeString(m_TestDatetime);
            Assert.AreEqual("11:12", dateString);
        }

        [TestMethod]
        public void RebinderDateTimeRuTest()
        {
            var rebinder = new ReportRebinder("ru", m_Report);

            string dateString = rebinder.ToDateTimeString(m_TestDatetime);
            Assert.AreEqual("30.01.2000 11:12", dateString);
        }

        [TestMethod]
        public void RebinderDateTimeEnTest()
        {
            var rebinder = new ReportRebinder("en", m_Report);
            string dateString = rebinder.ToDateTimeString(m_TestDatetime);
            Assert.AreEqual("1/30/2000 11:12", dateString);
        }
    }
}