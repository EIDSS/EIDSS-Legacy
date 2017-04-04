using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.Core;
using eidss.model.Schema;

namespace bv.tests.db.tests
{
    [TestClass]
    public class AddressTest : EidssEnvWithLogin
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
        public void TestHumanCaseAddresses()
        {
            Address addr = Address.Accessor.Instance(null).CreateNewT(manager, null);

            // addresses
            Assert.IsNotNull(addr);
            // If the Region has been changed or cleared, the Rayon, Town or Village, Street, Postal Code and Building/House/Apt. become blank and Street, Postal Code and Building/House/Apt. become disabled.
            // If the Rayon has been changed or cleared, the Rayon, Town or Village, Street, Postal Code and Building/House/Apt. become blank and Street, Postal Code and Building/House/Apt. become disabled.
            // After the Town or Village is specified, the Street, Postal Code and Building/House/Apt. become enabled. Each time the Town or Village is changed with not blank value, the Street, Postal Code and Building/House/Apt. become blank.
            // If the Town or Village has been cleared, the Street, Postal Code and Building/House/Apt. become blank and disabled.
            Assert.AreEqual("", addr.strStreetName);
            Assert.AreEqual("", addr.strPostCode);
            Assert.AreEqual("", addr.strHouse);
            Assert.AreEqual("", addr.strBuilding);
            Assert.AreEqual("", addr.strApartment);
            Assert.IsNotNull(addr.Country);
            Assert.AreEqual("Georgia", addr.Country.strCountryName);

            addr.Region = addr.RegionLookup.SingleOrDefault(c => c.strRegionName == "Abkhazia");
            addr.Rayon = addr.RayonLookup.SingleOrDefault(c => c.strRayonName == "Gagra");
            addr.Settlement = addr.SettlementLookup.SingleOrDefault(c => c.strSettlementName == "Zegani");

            addr.strStreetName = "1";
            addr.strPostCode = "2";
            addr.strHouse = "3";
            addr.strBuilding = "4";
            addr.strApartment = "5";
            Assert.AreEqual("1", addr.strStreetName);
            Assert.AreEqual("2", addr.strPostCode);
            Assert.AreEqual("3", addr.strHouse);
            Assert.AreEqual("4", addr.strBuilding);
            Assert.AreEqual("5", addr.strApartment);
            addr.Settlement = null;
            Assert.AreEqual("", addr.strStreetName);
            Assert.AreEqual("", addr.strPostCode);
            Assert.AreEqual("", addr.strHouse);
            Assert.AreEqual("", addr.strBuilding);
            Assert.AreEqual("", addr.strApartment);
        }
    }
}