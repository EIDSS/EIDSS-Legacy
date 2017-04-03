using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.winclient.Core;
using System.Threading;

namespace bv.tests.WinClient
{
    [TestClass]
    public class OneInstanceAppTest
    {
        [TestMethod]
        public void OneInstanceTest()
        {

            bool firstInstanceCreated = OneInstanceApp.IsMutexCreated("eidss.main.exe5");
            Assert.AreEqual(true, firstInstanceCreated);
            bool secondInstanceCreated = OneInstanceApp.IsMutexCreated("eidss.main.exe5");
            Assert.AreEqual(false, secondInstanceCreated);

        }
    }
}
