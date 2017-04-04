using System;
using System.Globalization;
using System.Threading;
using bv.tests.common;
using EIDSS.Reports.BaseControls.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Core.CultureInfo;

namespace bv.tests.Reports
{
    [TestClass]
    public class CultureInfoExTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            CultureInfo info = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = info;
            Thread.CurrentThread.CurrentCulture = info;
        }

        [TestMethod]
        public void CultureInfoExTest()
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            var ex = new CultureInfoEx(cultureInfo, "ru-RU");
            Assert.AreEqual(cultureInfo, ex.CultureInfo);
            Assert.AreEqual("ru-RU", ex.ShortName);
        }

        [TestMethod]
        public void CultureInfoTtransactionTest()
        {
            BaseReportTests.LoadAssemblies();
        
            BaseReportTests.InitDBAndLogin();

            CultureInfo info = CultureInfo.GetCultureInfo("ka-GE");
            Thread.CurrentThread.CurrentUICulture = info;
            Thread.CurrentThread.CurrentCulture = info;
            using (new CultureInfoTransaction(CultureInfo.GetCultureInfo("en-US")))
            {
                Console.WriteLine(Thread.CurrentThread.CurrentCulture);
                Assert.AreEqual("en-US", Thread.CurrentThread.CurrentCulture.Name);
                Assert.AreEqual("en-US", Thread.CurrentThread.CurrentUICulture.Name);
            }
            Assert.AreEqual(info, Thread.CurrentThread.CurrentCulture);
            Assert.AreEqual(info, Thread.CurrentThread.CurrentUICulture);
        }
    }
}