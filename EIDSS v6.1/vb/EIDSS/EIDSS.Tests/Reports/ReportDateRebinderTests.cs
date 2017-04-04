using System;
using System.Reflection;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Document.Human.CaseInvestigation;
using NUnit.Framework;

namespace EIDSS.Tests.Reports
{
    [TestFixture]
    public class ReportDateRebinderTests : BaseTests
    {
        private readonly DateTime m_TestDatetime = new DateTime(2000, 1, 30, 11, 12, 13);
        private readonly BaseReport m_Report = new BaseReport();

       

        [Test]
        public void ReflectionTest()
        {
            CaseInvestigationReport report = new CaseInvestigationReport();
            FieldInfo field = typeof (CaseInvestigationReport).GetField("xrTableCell12",
                                                                        BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(field);
            XRTableCell cell = (XRTableCell) field.GetValue(report);
            Assert.AreEqual("{0:dd/MM/yyyy  HH:mm}", cell.DataBindings[0].FormatString);

            ReportRebinder rebinder = new ReportRebinder("en", report);
            rebinder.RebindDateForReport();

            cell = (XRTableCell) field.GetValue(report);
            Assert.AreEqual("{0:M/d/yyyy  HH:mm}", cell.DataBindings[0].FormatString);
        }

        [Test]
        public void ReflectionRussianTest()
        {
            CaseInvestigationReport report = new CaseInvestigationReport();
            FieldInfo field = typeof(CaseInvestigationReport).GetField("xrTableCell12",
                                                                        BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(field);
            XRTableCell cell = (XRTableCell)field.GetValue(report);
            Assert.AreEqual("{0:dd/MM/yyyy  HH:mm}", cell.DataBindings[0].FormatString);

            ReportRebinder rebinder = new ReportRebinder("ru", report);
            rebinder.RebindDateForReport();

            cell = (XRTableCell)field.GetValue(report);
            Assert.AreEqual("{0:dd.MM.yyyy  HH:mm}", cell.DataBindings[0].FormatString);
        }

        [Test]
        public void RebinderDateRuTest()
        {
            ReportRebinder rebinder = new ReportRebinder("ru", m_Report);

            string dateString = rebinder.ToDateString(m_TestDatetime);
            Assert.AreEqual("30.01.2000", dateString);
        }

        [Test]
        public void RebinderDateEnTest()
        {
            ReportRebinder rebinder = new ReportRebinder("en", m_Report);
            string dateString = rebinder.ToDateString(m_TestDatetime);
            Assert.AreEqual("1/30/2000", dateString);
        }

        [Test]
        public void RebinderTimeRuTest()
        {
            ReportRebinder rebinder = new ReportRebinder("ru", m_Report);

            string dateString = rebinder.ToTimeString(m_TestDatetime);
            Assert.AreEqual("11:12", dateString);
        }

        [Test]
        public void RebinderTimeEnTest()
        {
            ReportRebinder rebinder = new ReportRebinder("en", m_Report);
            string dateString = rebinder.ToTimeString(m_TestDatetime);
            Assert.AreEqual("11:12", dateString);
        }

        [Test]
        public void RebinderDateTimeRuTest()
        {
            ReportRebinder rebinder = new ReportRebinder("ru", m_Report);

            string dateString = rebinder.ToDateTimeString(m_TestDatetime);
            Assert.AreEqual("30.01.2000 11:12", dateString);
        }

        [Test]
        public void RebinderDateTimeEnTest()
        {
            ReportRebinder rebinder = new ReportRebinder("en", m_Report);
            string dateString = rebinder.ToDateTimeString(m_TestDatetime);
            Assert.AreEqual("1/30/2000 11:12", dateString);
        }
    }
}