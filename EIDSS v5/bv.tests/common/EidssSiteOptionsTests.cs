using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Configuration;
using bv.tests.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace bv.tests.common
{
    [TestClass]
    public class EidssSiteOptionsTests : EidssEnvWithLogin
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }
        [TestMethod]
        public void GetSiteInfoTest()
        {
            Assert.AreEqual(780000000, EidssSiteContext.Instance.CountryID);
            Assert.AreEqual("Georgia",EidssSiteContext.Instance.CountryName);
            Assert.IsNotNull(EidssSiteContext.Instance.CountryHascCode);
            Assert.IsTrue(EidssSiteContext.Instance.OrganizationID > 0);
            Assert.IsNotNull(EidssSiteContext.Instance.OrganizationName);
            Assert.IsTrue(EidssSiteContext.Instance.RegionID > 0);
            Assert.IsNotNull(EidssSiteContext.Instance.SiteABR);
            Assert.IsNotNull(EidssSiteContext.Instance.SiteCode); 
            Assert.IsNotNull(EidssSiteContext.Instance.SiteHASCCode);
            Assert.AreNotEqual(SiteType.Undefined, EidssSiteContext.Instance.SiteType);
            Assert.IsTrue(EidssSiteContext.Instance.SiteID > 0);
            Assert.IsNotNull(EidssSiteContext.Instance.SiteTypeName);
        }

        [TestMethod]
        public void GetSiteOptionsTest()
        {
            Assert.IsNotNull(EidssSiteContext.Instance.GetSiteOption("DatabaseVersion"));
            Assert.IsNull(EidssSiteContext.Instance.GetSiteOption("XXX"));
        }
        [TestMethod]
        public void GetGlobalSiteOptionsTest()
        {
            Assert.IsNull(EidssSiteContext.Instance.GetGlobalSiteOption("XXX"));
        }
    }
}
