using System;
using System.Globalization;
using System.Threading;
using EIDSS.Reports.BaseControls.Transaction;
using NUnit.Framework;

namespace EIDSS.Tests.Reports
{
    [TestFixture]
    public class CultureInfoExTests
    {
        [TearDown]
        public void TearDown()
        {
            CultureInfo info = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = info;
            Thread.CurrentThread.CurrentCulture = info;
            GC.Collect();
        }

        [Test]
        public void CultureInfoExTest()
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            CultureInfoEx ex = new CultureInfoEx(cultureInfo, "ru-RU");
            Console.WriteLine(ex);
            Assert.AreEqual(cultureInfo, ex.CultureInfo);
            Assert.AreEqual("ru-RU", ex.ShortName);
            Assert.AreEqual(cultureInfo.NativeName, ex.ToString());
        }

        [Test]
        public void CultureInfoTtransactionTest()
        {
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