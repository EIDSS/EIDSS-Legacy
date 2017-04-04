using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.model.BLToolkit;
using bv.common.Configuration;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.model.Enums;
using eidss.model.Core.Security;

namespace bv.tests.db.tests
{
    /// <summary>
    /// Summary description for FarmRoot
    /// </summary>
    [TestClass]
    public class FarmRoot
    {
        const string Organizaton = "NCDC&PH";
        const string Admin = "test_admin";
        const string User = "test_user";
        const string AdminPassword = "test";
        const string UserPassword = "test";

        public FarmRoot()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

       

        [TestMethod]
        public void CloneFarmFromRoot()
        {
            //DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            //using (var context = ModelUserContext.Instance as EidssUserContext)
            //{
            //    using (var manager = DbManagerFactory.Factory.Create(context))
            //    {
            //        var acc = FarmRootPanel.Accessor.Instance(null);
            //        long rootId = 4581330000000l;

            //        var root = acc.SelectByKey(manager, rootId);
            //        var farm = root.GetFarmFromRoot();

            //        Assert.AreEqual(root.idfFarm, farm.idfRootFarm);
            //        Assert.AreEqual(farm.FarmTree.Count, root.FarmAvianTree.Count + root.FarmLivestockTree.Count);
            //        Assert.AreEqual(farm.blnIsAvian, root.blnIsAvian);
            //        Assert.AreEqual(farm.intBirdsPerBuilding, root.intBirdsPerBuilding);
            //        Assert.AreEqual(farm.intBuidings, root.intBuidings);
            //        Assert.AreEqual(farm.idfsMovementPattern, root.idfsMovementPattern);
            //        Assert.AreEqual(farm.idfsGrazingPattern, root.idfsGrazingPattern);
            //        Assert.AreEqual(farm.idfsIntendedUse, root.idfsIntendedUse);

            //        farm.Validation += farm_Validation;
            //        FarmPanel.Accessor.Instance(null).Post(manager, farm);
            //        farm.Validation -= farm_Validation;        
            //    }
            //}
        }

        void farm_Validation(object sender, ValidationEventArgs args)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void RootFarmCollection()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var acc = FarmRootPanel.Accessor.Instance(null);

                    var panel = acc.Create(manager, null, HACode: null);

                    var herdaccessor = RootFarmTree.Accessor.Instance(null);
                    RootFarmTree farm =panel.FarmLivestockTree[0];
                    RootFarmTree herd = herdaccessor.CreateHerd(manager, panel, farm);
                    RootFarmTree spec = herdaccessor.CreateSpecies(manager, panel, herd);
                    spec.SpeciesType = spec.SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == 837790000000);
                    //spec.idfsSpeciesTypeReference = 837790000000;
                    panel.FarmLivestockTree.Add(herd);
                    panel.FarmLivestockTree.Add(spec);

                    panel.Address.Region = panel.Address.RegionLookup.FirstOrDefault();
                    panel.Address.Rayon = panel.Address.RayonLookup.FirstOrDefault();
                    panel.Address.Settlement = panel.Address.SettlementLookup.FirstOrDefault();
                    //panel.Location.CopyAddressValues(panel.Address);

                    //panel.Validation += new ValidationEvent(panel_Validation);
                    //panel.blnIsLivestock = true;
                    //acc.Post(manager, panel);

                    //panel.Validation -= panel_Validation;

                    //var savedpanel = acc.SelectByKey(manager, panel.idfFarm);
                    
                    //Assert.AreEqual(panel.FarmLivestockTree.Count, savedpanel.FarmLivestockTree.Count);
                    //Assert.AreNotEqual(savedpanel.FarmLivestockTree.Count, savedpanel.FarmAvianTree.Count);
                    //Assert.AreEqual(panel.FarmAvianTree.Count, 1);
                    //Assert.AreEqual(farm._HACode, (int)HACode.Livestock);
                    //Assert.AreEqual(herd._HACode, (int)HACode.Livestock);
                    //Assert.AreEqual(spec._HACode, (int)HACode.Livestock);
                    //Assert.AreNotEqual(spec.SpeciesTypeLookup.Count, 1);
                }
            }
        }


        [TestMethod]
        public void FarmPanelCollection()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();

                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var acc = VetCase.Accessor.Instance(null);
                    var vetcase = (VetCase)acc.CreateNew(manager, null, (int)HACode.Livestock);
                    
                    var panel = vetcase.Farm;

                    var herdaccessor = VetFarmTree.Accessor.Instance(null);
                    VetFarmTree farm = panel.FarmTree[0];
                    VetFarmTree herd = herdaccessor.CreateHerd(manager, panel, farm);
                    VetFarmTree spec = herdaccessor.CreateSpecies(manager, panel, herd);
                    spec.SpeciesType = spec.SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == 837790000000);
                    //spec.idfsSpeciesTypeReference = 837790000000;
                    panel.FarmTree.Add(herd);
                    panel.FarmTree.Add(spec);

                    panel.Address.Region = panel.Address.RegionLookup.FirstOrDefault();
                    panel.Address.Rayon = panel.Address.RayonLookup.FirstOrDefault();
                    panel.Address.Settlement = panel.Address.SettlementLookup.FirstOrDefault();

                    var animal = (AnimalListItem)AnimalListItem.Accessor.Instance(null).CreateNew(manager, vetcase, (int)HACode.Livestock);
                    animal.idfSpecies = spec.idfParty;
                    animal.idfHerd = herd.idfParty;
                    animal.idfCase = vetcase.idfCase;

                    vetcase.AnimalList.Add(animal);
                    //vetcase.Validation += new ValidationEvent(panel_Validation);

                    
                    //acc.Post(manager, vetcase);
                    //vetcase.Validation -= panel_Validation;
                 
                }
            }
        }
        void panel_Validation(object sender, ValidationEventArgs args)
        {
            throw new Exception("Validation is not passed");
        }
    }
}
