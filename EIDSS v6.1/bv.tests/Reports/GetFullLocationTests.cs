using bv.tests.common;
using eidss.model.Enums;
using EIDSS.Reports.BaseControls.Report;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.Reports
{
    [TestClass]
    public class GetFullLocationTests
    {
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.LoadAssemblies();
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void CountryFullLocationTest()
        {
            string location = BaseDocumentReport.GetFullLocationFromAdmUnitId(1050000000,  GisReferenceType.Country);
            Assert.AreEqual("Iraq", location);
        }

        [TestMethod]
        public void RegionFullLocationTest()
        {
            string location = BaseDocumentReport.GetFullLocationFromAdmUnitId(37030000000, GisReferenceType.Region);
            Assert.AreEqual("Georgia, Adjara", location);
        }

        [TestMethod]
        public void RayonFullLocationTest()
        {
            string location = BaseDocumentReport.GetFullLocationFromAdmUnitId(1344490000000, GisReferenceType.Rayon);
            Assert.AreEqual("Azerbaijan, Other rayons, Absheron", location);
        }
        [TestMethod]
        public void SettlementFullLocationTest()
        {
            string location = BaseDocumentReport.GetFullLocationFromAdmUnitId(155310000000, GisReferenceType.Settlement);
            Assert.AreEqual("Georgia, Imereti, Samtredia, Melauri", location);
        }
        
    }
}