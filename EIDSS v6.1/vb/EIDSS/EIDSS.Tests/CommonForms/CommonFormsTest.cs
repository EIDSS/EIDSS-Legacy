using System;
using System.Data;
using bv.common;
using bv.common.db;
using bv.common.win;
using EIDSS.Tests.Core;
using NUnit.Framework;
using GlobalSettings = bv.common.GlobalSettings;

namespace EIDSS.Tests.CommonForms
{
    [TestFixture]
    public class CommonFormsTest : BaseFormTest
    {
       

        #region Private methods
        private static void checkEmptyAddress(AddressLookup address)
        {
            DataRow row = address.baseDataSet.Tables["Address"].Rows[0];
            Assert.AreEqual(row["idfsCountry"], eidss.model.Core.EidssSiteContext.Instance.CountryID);

            DataView RegionView = WinControlHelper.GetLookUpEditDatasource(address, "cbRegion", null);
            DataView RayonView = WinControlHelper.GetLookUpEditDatasource(address, "cbRayon", null);
            DataView SettlementView = WinControlHelper.GetLookUpEditDatasource(address, "cbSettlement", null);
            //Check address initial state
            if (eidss.model.Core.EidssSiteContext.Instance.CountryID != (long)Country.Georgia)
            {
                row["idfsCountry"] = (long)Country.Georgia;
                DataEventManager.Flush();
            }
            Assert.AreEqual(12, RegionView.Count);
            Assert.AreEqual(0, RayonView.Count);
            Assert.AreEqual(0, SettlementView.Count);
            Assert.AreEqual(DBNull.Value, row["idfsRegion"]);
            Assert.AreEqual(DBNull.Value, row["idfsRayon"]);
            Assert.AreEqual(DBNull.Value, row["idfsSettlement"]);
            Assert.AreEqual(DBNull.Value, row["strStreetName"]);
            Assert.AreEqual(DBNull.Value, row["strPostCode"]);
            Assert.AreEqual(DBNull.Value, row["strHouse"]);
            Assert.AreEqual(DBNull.Value, row["strBuilding"]);
            Assert.AreEqual(DBNull.Value, row["strApartment"]);

        }
        private static void assignTestAddressData(AddressLookup address)
        {
            DataRow row = address.baseDataSet.Tables["Address"].Rows[0];
            DataView RegionView = WinControlHelper.GetLookUpEditDatasource(address, "cbRegion", null);
            DataView RayonView = WinControlHelper.GetLookUpEditDatasource(address, "cbRayon", null);
            DataView SettlementView = WinControlHelper.GetLookUpEditDatasource(address, "cbSettlement", null);
            row["idfsRegion"] = 37020000000; //Abhazia
            DataEventManager.Flush();
            Assert.IsTrue(RayonView.Count == 6);
            row["idfsRayon"] = 3260000000; //Gagra
            DataEventManager.Flush();
            Assert.GreaterOrEqual(SettlementView.Count, 1);
            row["idfsSettlement"] = 259730000000;//Achmarda
            DataEventManager.Flush();
            row["strStreetName"] = "test";
            row["strPostCode"] = "111";
            row["strHouse"] = "1";
            row["strBuilding"] = "1";
            row["strApartment"] = "1";
        }
        private static void checkTestAddressData(AddressLookup address)
        {
            DataRow row = address.baseDataSet.Tables["Address"].Rows[0];
            DataView RegionView = WinControlHelper.GetLookUpEditDatasource(address, "cbRegion", null);
            DataView RayonView = WinControlHelper.GetLookUpEditDatasource(address, "cbRayon", null);
            DataView SettlementView = WinControlHelper.GetLookUpEditDatasource(address, "cbSettlement", null);
            Assert.AreEqual(12, RegionView.Count);
            Assert.AreEqual(6, RayonView.Count);
            Assert.GreaterOrEqual(SettlementView.Count, 1);
            Assert.AreEqual(37020000000, row["idfsRegion"]);//Abhazia
            Assert.AreEqual(3260000000, row["idfsRayon"]);//Gagra
            Assert.AreEqual(259730000000, row["idfsSettlement"]); //Achmarda
            Assert.AreEqual("test", row["strStreetName"]);
            Assert.AreEqual("111", row["strPostCode"]);
            Assert.AreEqual("1", row["strHouse"]);
            Assert.AreEqual("1", row["strBuilding"]);
            Assert.AreEqual("1", row["strApartment"]);

        }
        
        #endregion

        #region Auto Tests
        [Test]
        public void AddressDialogTest()
        {
            object ID = BaseDbService.NewIntID(null);
            AddressSelectDialog addressDlg = new AddressSelectDialog();
            AddressLookup address = addressDlg.Children[0] as AddressLookup;

            BaseForm.ShowNormal(addressDlg, ID, null);
            checkEmptyAddress(address);
            assignTestAddressData(address);
            addressDlg.Post(PostType.FinalPosting);
            addressDlg.DoOk();
            //Load existing address
            addressDlg = new AddressSelectDialog();
            address = addressDlg.Children[0] as AddressLookup;
            BaseForm.ShowNormal(addressDlg, ID, null);
            checkTestAddressData(address);
            addressDlg.Post(PostType.FinalPosting);
            addressDlg.DoOk();

            //Check Search and Browse mode
            ID = GlobalSettings.SEARCH_MODE_ID;
            addressDlg = new AddressSelectDialog();
            address = addressDlg.Children[0] as AddressLookup;
            BaseForm.ShowNormal(addressDlg, ID, null);
            checkEmptyAddress(address);
            assignTestAddressData(address);
            addressDlg.Post(PostType.FinalPosting);
            addressDlg.DoOk();
            Assert.AreEqual((long)Country.Georgia, address.CountryID);//Abhazia
            Assert.AreEqual(37020000000, address.RegionID);//Abhazia
            Assert.AreEqual(3260000000, address.RayonID);//Gagra
            Assert.AreEqual(259730000000, address.SettlementID); //Achmarda
            Assert.AreEqual("test", address.Street);
            Assert.AreEqual("111", address.PostalCode);
            Assert.AreEqual("1", address.House);
            Assert.AreEqual("1", address.Building);
            Assert.AreEqual("1", address.Apartment);
            addressDlg = new AddressSelectDialog();
            address = addressDlg.Children[0] as AddressLookup;
            BaseForm.ShowNormal(addressDlg, ID, null);
            checkEmptyAddress(address);
            addressDlg.DoClose();


        }

        [Test]
        public void LocationDialogTest()
        {
            object ID = BaseDbService.NewIntID(null);
            LocationSelectDialog locationDlg = new LocationSelectDialog();
            LocationLookup location = locationDlg.Children[0] as LocationLookup;
            BaseForm.ShowNormal(locationDlg, ID, null);
            DataRow locRow = location.baseDataSet.Tables["GeoLocation"].Rows[0];
            Assert.AreEqual(locRow["idfsCountry"], eidss.model.Core.EidssSiteContext.Instance.CountryID);

            DataView RegionView = WinControlHelper.GetLookUpEditDatasource(location, "cbRegion", "RelativeLocationGroupBox");
            DataView RayonView = WinControlHelper.GetLookUpEditDatasource(location, "cbRayon", "RelativeLocationGroupBox");
            DataView SettlementView = WinControlHelper.GetLookUpEditDatasource(location, "cbSettlement", "RelativeLocationGroupBox");

            if (eidss.model.Core.EidssSiteContext.Instance.CountryID != (long)Country.Georgia)
            {
                locRow["idfsCountry"] = (long)Country.Georgia;
                DataEventManager.Flush();
            }

            Assert.AreEqual(12, RegionView.Count);
            Assert.AreEqual(0, RayonView.Count);
            Assert.AreEqual(0, SettlementView.Count);
            Assert.AreEqual(DBNull.Value, locRow["idfsRegion"]);
            Assert.AreEqual(DBNull.Value, locRow["idfsRayon"]);
            Assert.AreEqual(DBNull.Value, locRow["idfsSettlement"]);
            Assert.AreEqual(DBNull.Value, locRow["dblLatitude"]);
            Assert.AreEqual(DBNull.Value, locRow["dblLongitude"]);
            Assert.AreEqual(DBNull.Value, locRow["dblAccuracy"]);
            Assert.AreEqual(DBNull.Value, locRow["dblDistance"]);
            Assert.AreEqual(DBNull.Value, locRow["dblAlignment"]);
            Assert.AreEqual(DBNull.Value, locRow["strDescription"]);

            locRow["idfsRegion"] = 37020000000; //Abhazia
            DataEventManager.Flush();
            Assert.IsTrue(RayonView.Count == 6);
            locRow["idfsRayon"] = 3260000000; //Gagra
            DataEventManager.Flush();
            Assert.GreaterOrEqual(SettlementView.Count, 1);
            locRow["dblLatitude"] = 10;
            locRow["dblLongitude"] = 20;
            locRow["dblAccuracy"] = 0.1;
            locationDlg.Post(PostType.FinalPosting);

            locationDlg.LoadData(ID);
            locRow = location.baseDataSet.Tables["GeoLocation"].Rows[0];
            Assert.AreEqual(37020000000, locRow["idfsRegion"]);
            Assert.AreEqual(3260000000, locRow["idfsRayon"]);
            Assert.AreEqual(DBNull.Value, locRow["idfsSettlement"]);
            Assert.AreEqual(10, locRow["dblLatitude"]);
            Assert.AreEqual(20, locRow["dblLongitude"]);
            Assert.AreEqual(0.1, locRow["dblAccuracy"]);
            Assert.AreEqual(DBNull.Value, locRow["dblDistance"]);
            Assert.AreEqual(DBNull.Value, locRow["dblAlignment"]);
            Assert.AreEqual(DBNull.Value, locRow["strDescription"]);

            // BaseForm.ShowModal(new LocationSelectDialog(), ref ID, null, null, -1, -1);
        }

        [Test]
        public void TestResult2Test_Test()
        {
            RunAutoBaseFormTest("TestResult2TestDetail", null, false);
        }
        
        [Test]
        public void EventList_Test()
        {
            RunDefaultListFormTest("EventList");
        }
        
        [Test]
        public void EventSubscription_Test()
        {
            RunAutoBaseFormTest("NotificationSubscriptionDetail", null, false);
        }
        [Test]
        public void OutbreakList_Test()
        {
            RunDefaultListFormTest("OutbreakList");
        }
        [Test]
        public void OutbreakDetail_Test()
        {
            RunAutoBaseFormTest("OutbreakDetail", null);
        }

        #endregion       



        #region Manual tests
        [Test, Ignore("manual test")]
        public void OutbreakListManual_Test()
        {
            RunManualBaseFormTest("OutbreakList");
        }
        [Test, Ignore("manual test")]
        public void OutbreakDetailManual_Test()
        {
            RunManualBaseFormTest("OutbreakDetail");
        }
        [Test, Ignore("manual test")]
        public void AddressManual_Test()
        {
            RunManualBaseFormTest("AddressSelectDialog");
        }

        #endregion
    }
}