using System;
using bv.common.Core;
using bv.common.win;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.Reports
{
    [TestClass]
    public class WaitDialogTests
    {
        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void WaitDialogTransactionTest()
        {
            using (var transaction = new WaitDialog("caption", "title"))
            {
                Assert.AreEqual("title", transaction.Title);
                Assert.AreEqual("caption", transaction.Caption);
                transaction.Caption = "test";
                Assert.AreEqual("test", transaction.Caption);
            }
        }
    }
}