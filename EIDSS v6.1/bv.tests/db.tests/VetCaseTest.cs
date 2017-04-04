using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace bv.tests.db.tests
{
    class VetCaseTest
    {
        [TestMethod]
        public void TestFarmPanel()
        {
             DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
             using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
             {
                 FarmPanel.Accessor acc = FarmPanel.Accessor.Instance(null);
                 FarmPanel farm = acc.CreateNewT(manager);

                 Assert.IsNotNull(farm.Location);

             }
        }
    }
}
