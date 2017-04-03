using System;
using System.Collections.Generic;
using EIDSS.Reports.BaseControls.Report;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.Reports
{
    [TestClass]
    public class ReportParametersTest
    {
        [TestMethod]
        public void GetStringParameterTest()
        {
            string val = BaseDocumentReport.GetStringParameter(new Dictionary<string, string> {{"@ObjID", "xxx"}}, "@ObjID");
            Assert.AreEqual("xxx", val);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void GetStringParameterNullTest()
        {
            BaseDocumentReport.GetStringParameter(new Dictionary<string, string>(), "@ObjID");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void GetStringParameterEmptyTest()
        {
            BaseDocumentReport.GetStringParameter(new Dictionary<string, string> {{"@ObjID", ""}}, "@ObjID");
        }

        [TestMethod]
        public void TryGetStringParameterTest()
        {
            string val;
            Assert.IsTrue(BaseDocumentReport.TryGetStringParameter(new Dictionary<string, string> {{"@ObjID", "xxx"}}, "@ObjID", out val));
            Assert.AreEqual("xxx", val);
        }

        [TestMethod]
        public void TryGetStringParameterNullTest()
        {
            string val;
            Assert.IsFalse(BaseDocumentReport.TryGetStringParameter(new Dictionary<string, string> (), "@ObjID", out val));
        }

        [TestMethod]
        public void TryGetStringParameterEmptyTest()
        {
            string val;
            Assert.IsFalse(BaseDocumentReport.TryGetStringParameter(new Dictionary<string, string> { { "@ObjID", "" } }, "@ObjID", out val));
        }

        [TestMethod]
        public void TryGetLongParameterTest()
        {
            long val;
            Assert.IsTrue(BaseDocumentReport.TryGetLongParameter(new Dictionary<string, string> { { "@ObjID", "123" } }, "@ObjID", out val));
            Assert.AreEqual(123, val);
        }
        [TestMethod]
        public void GetLongParameterTest()
        {
            long val = BaseDocumentReport.GetLongParameter(new Dictionary<string, string> { { "@ObjID", "123" } }, "@ObjID");
            Assert.AreEqual(123, val);
        }
    }
}