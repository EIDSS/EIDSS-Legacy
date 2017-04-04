using System;
using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using bv.tests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Model.Smartphone;
using eidss.model.Schema.Smartphone;

namespace bv.tests.Smph
{
    [TestClass]
    public class SmphTest : EidssEnvWithLogin
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
        public void SmphTestFF()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var ret = SmphFFLookups.Accessor.Instance(null).SelectByKey(manager);
                Assert.IsTrue(ret.FFTemplate.Count > 0);
            }
        }

        [TestMethod]
        public void SmphTestFFModel()
        {
            var model = FFModel.Get();
            Assert.IsTrue(model.templates.Count > 0);
        }
    }

}
