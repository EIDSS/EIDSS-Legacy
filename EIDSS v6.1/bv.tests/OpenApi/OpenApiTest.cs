using System;
using System.Collections.Generic;
using System.Linq;
using bv.tests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Enums;
using eidss.openapi.bll.Bll;
using eidss.openapi.contract;
using eidss.openapi.bll.Converters;

namespace bv.tests.openapi
{
    [TestClass]
    public class OpenApiTest : EidssEnvWithLogin
    {

        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [Ignore]
        public void OpenApiTestAutoMap()
        {
            AutoConverter.Check();
        }
        /*
         */
    }
}
