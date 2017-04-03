using System;
using bv.common.win;
using EIDSS.Reports.BaseControls.Transaction;
using NUnit.Framework;

namespace EIDSS.Tests.Reports
{
    [TestFixture]
    public class WaitDialogTests
    {
        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }
        [Test]
        public void WaitDialogTransactionTest()
        {
            using (WaitDialog transaction = new WaitDialog("caption", "title"))
            {
                Assert.AreEqual("title", transaction.Title);
                Assert.AreEqual("caption", transaction.Caption);
                transaction.Caption = "test";
                Assert.AreEqual("test", transaction.Caption);
            }
        }
    }
}