using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Enums;

namespace bv.tests.db.tests
{
    [Serializable]
    public class TestUserContext : EidssUserContext
    {
        protected TestUserContext(string appID)
            : base(appID, null)
        {
        }

        public static void Init()
        {
            Creator = () => new TestUserContext("");
        }

        public new static void Clear()
        {
            Creator = null;
        }

        public override bool CanDo(string permission)
        {
            string[] ss = permission.Split('.');
            if (ss.Length > 1)
            {
                permission = ss[1];
            }
            switch (permission)
            {
                case "Select":
                    return true;
                case "Insert":
                    return false;
                case "Delete":
                    return false;
                case "Update":
                    return false;
                case "Execute":
                    return false;
            }
            return true;
        }
    }

    [TestClass]
    public class EidssModelTest
    {
        private const string Organizaton = "NCDC&PH";
        private const string Admin = "test_admin";
        private const string User = "test_user";
        private const string AdminPassword = "test";
        private const string UserPassword = "test";

        [TestMethod]
        public void TestSpPermissions()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));

            EidssUserContext.Init();
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, User, UserPassword);
                Assert.AreEqual(0, result);

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    manager.BeginTransaction();

                    VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                    VetCase vc = vcacc.CreateNewT(manager, null, (int)HACode.Livestock); //livestock
                    Assert.IsNotNull(vc);

                    vc.Validation += vcValidationContinue;
                    try
                    {
                        Assert.IsFalse(vcacc.Post(manager, vc));
                    }
                    catch (Exception e)
                    {
                        //Assert.IsInstanceOfType(e, typeof (DbModelRaiserrorException));
                        //Assert.AreEqual("msgVetCasePermission", ((DbModelRaiserrorException) e).MessageId);
                        Assert.IsInstanceOfType(e, typeof(PermissionException));
                        Assert.AreEqual("VetCase", ((PermissionException)e).ObjectName);
                        Assert.AreEqual("Insert", ((PermissionException)e).ActionName);
                    }
                    vc.Validation -= vcValidationContinue;

                    HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
                    HumanCase hc = acc.CreateNewT(manager, null);
                    Assert.IsNotNull(hc);

                    hc.Validation += vcValidationContinue;
                    try
                    {
                        Assert.IsFalse(acc.Post(manager, hc));
                    }
                    catch (Exception e)
                    {
                        //Assert.IsInstanceOfType(e, typeof (DbModelRaiserrorException));
                        //Assert.AreEqual("msgHumanCasePermission", ((DbModelRaiserrorException) e).MessageId);
                        Assert.IsInstanceOfType(e, typeof(PermissionException));
                        Assert.AreEqual("HumanCase", ((PermissionException)e).ObjectName);
                        Assert.AreEqual("Insert", ((PermissionException)e).ActionName);
                    }
                    hc.Validation -= vcValidationContinue;

                    manager.RollbackTransaction();
                }
            }
            EidssUserContext.Clear();

            EidssUserContext.Init();
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    manager.BeginTransaction();
                    VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                    VetCase vc = vcacc.CreateNewT(manager, null, (int)HACode.Livestock); //livestock

                    vc.Validation += vcValidationContinue;
                    Assert.IsTrue(vcacc.Post(manager, vc));
                    vc.Validation -= vcValidationContinue;

                    HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
                    HumanCase hc = acc.CreateNewT(manager, null);
                    Assert.IsNotNull(hc);

                    hc.Validation += vcValidationContinue;
                    Assert.IsTrue(acc.Post(manager, hc));
                    hc.Validation -= vcValidationContinue;
                    manager.RollbackTransaction();
                }
            }
            EidssUserContext.Clear();
        }

        [TestMethod]
        public void TestPermissions()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));

            long id;
            EidssUserContext.Init();
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                    {
                        VetCase vc = vcacc.CreateNewT(manager, null, (int)HACode.Livestock); //livestock
                        id = vc.idfCase;

                        vc.Validation += vcValidationContinue;
                        Assert.IsTrue(vcacc.Post(manager, vc));
                        vc.Validation -= vcValidationContinue;
                    }
                }
            }
            EidssUserContext.Clear();

            TestUserContext.Init();
            using (ModelUserContext context = ModelUserContext.Instance)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                    FarmPanel.Accessor fmacc = FarmPanel.Accessor.Instance(null);
                    try
                    {
                        VetCase vc = vcacc.CreateNewT(manager, null, (int)HACode.Livestock); //livestock
                        Assert.IsFalse(vc.GetPermissions().CanInsert);
                        vc.Validation += vcValidationContinue;
                        Assert.IsTrue(vcacc.Post(manager, vc));
                        vc.Validation -= vcValidationContinue;
                    }
                    catch (Exception e)
                    {
                        Assert.IsInstanceOfType(e, typeof (PermissionException));
                        var pe = (PermissionException)e;
                        Assert.AreEqual("VetCase", pe.ObjectName);
                        Assert.AreEqual("Insert", pe.ActionName);
                    }

                    try
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.IsTrue(vc.GetPermissions().CanSelect);
                        Assert.IsFalse(vc.GetPermissions().CanUpdate);
                        vcacc.Post(manager, vc);
                    }
                    catch (Exception e)
                    {
                        Assert.IsInstanceOfType(e, typeof (PermissionException));
                        var pe = (PermissionException)e;
                        Assert.AreEqual("VetCase", pe.ObjectName);
                        Assert.AreEqual("Update", pe.ActionName);
                    }

                    try
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.IsFalse(vc.GetPermissions().CanDelete);
                        vc.MarkToDelete();
                        vcacc.Post(manager, vc);
                    }
                    catch (Exception e)
                    {
                        Assert.IsInstanceOfType(e, typeof (PermissionException));
                        var pe = (PermissionException)e;
                        Assert.AreEqual("VetCase", pe.ObjectName);
                        Assert.AreEqual("Delete", pe.ActionName);
                    }

                    try
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.IsFalse(vc.Farm.GetPermissions().CanExecute("CreateHerd"));
                        fmacc.CreateHerd(manager, vc.Farm);
                    }
                    catch (Exception e)
                    {
                        Assert.IsInstanceOfType(e, typeof (PermissionException));
                        var pe = (PermissionException)e;
                        Assert.AreEqual("VetCase", pe.ObjectName);
                        Assert.AreEqual("CreateHerd", pe.ActionName);
                    }
                }
            }
            TestUserContext.Clear();

            EidssUserContext.Init();
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.IsTrue(vc.MarkToDelete());
                        Assert.IsTrue(vcacc.Post(manager, vc));
                    }
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.IsNull(vc);
                    }
                }
            }
            EidssUserContext.Clear();
        }

        [TestMethod]
        public void TestContext()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            string clientID = ModelUserContext.ClientID;

            EidssUserContext.Init();
            ModelUserContext.Instance.Close();
            EidssUserContext.Clear();

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                Assert.AreEqual("", manager.SetCommand("select dbo.fnGetContext()").ExecuteScalar().ToString());
                Assert.AreEqual(0,
                                (int)
                                manager.SetCommand(
                                    "select count(*) from tstLocalConnectionContext where strConnectionContext = '" +
                                    clientID + "'").ExecuteScalar());
            }

            EidssUserContext.Init();
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    Assert.AreEqual(clientID, manager.SetCommand("select dbo.fnGetContext()").ExecuteScalar().ToString());
                    Assert.AreEqual(1,
                                    (int)
                                    manager.SetCommand(
                                        "select count(*) from tstLocalConnectionContext where strConnectionContext = '" +
                                        clientID + "'").ExecuteScalar());

                    VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                    long id;
                    {
                        VetCase vc = vcacc.CreateNewT(manager, null, (int)HACode.Livestock); //livestock
                        id = vc.idfCase;

                        vc.Validation += vcValidationContinue;
                        Assert.IsTrue(vcacc.Post(manager, vc));
                        vc.Validation -= vcValidationContinue;
                        Assert.AreEqual(context.DataAuditEvent,
                                        manager.SetCommand(
                                            "select idfDataAuditEvent from tstLocalConnectionContext where strConnectionContext = '" +
                                            clientID + "'").ExecuteScalar<long>());
                        Assert.AreEqual(id,
                                        manager.SetCommand(
                                            "select idfMainObject from tauDataAuditEvent where idfDataAuditEvent = " +
                                            context.DataAuditEvent).ExecuteScalar<long>());
                        Assert.AreEqual(clientID,
                                        manager.SetCommand(
                                            "select strClient from tstEvent where idfsEventTypeID = 10025014 and idfObjectID = " +
                                            id).ExecuteScalar<string>());
                    }
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        vc.CaseProgressStatus =
                            vc.CaseProgressStatusLookup.Where(c => c.name == "Closed").SingleOrDefault();
                        Assert.IsNotNull(vc.CaseProgressStatus);
                        vc.FinalDiagnosis =
                            vc.FinalDiagnosisLookup.Where(c => c.name == "African Swine Fever").SingleOrDefault();
                        Assert.IsNotNull(vc.FinalDiagnosis);

                        vc.Validation += vcValidationContinue;
                        Assert.IsTrue(vcacc.Post(manager, vc));
                        vc.Validation -= vcValidationContinue;
                        Assert.AreEqual(context.DataAuditEvent,
                                        manager.SetCommand(
                                            "select idfDataAuditEvent from tstLocalConnectionContext where strConnectionContext = '" +
                                            clientID + "'").ExecuteScalar<long>());
                        Assert.AreEqual(id,
                                        manager.SetCommand(
                                            "select idfMainObject from tauDataAuditEvent where idfDataAuditEvent = " +
                                            context.DataAuditEvent).ExecuteScalar<long>());
                        Assert.AreEqual(clientID,
                                        manager.SetCommand(
                                            "select strClient from tstEvent where idfsEventTypeID = 10025005 and idfObjectID = " +
                                            id).ExecuteScalar<string>());
                        Assert.AreEqual(clientID,
                                        manager.SetCommand(
                                            "select strClient from tstEvent where idfsEventTypeID = 10025007 and idfObjectID = " +
                                            id).ExecuteScalar<string>());
                    }
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);

                        Assert.AreEqual("Closed", vc.CaseProgressStatus.name);

                        Assert.IsTrue(vc.MarkToDelete());
                        Assert.IsTrue(vcacc.Post(manager, vc));
                        Assert.AreEqual(context.DataAuditEvent,
                                        manager.SetCommand(
                                            "select idfDataAuditEvent from tstLocalConnectionContext where strConnectionContext = '" +
                                            clientID + "'").ExecuteScalar<long>());
                        Assert.AreEqual(id,
                                        manager.SetCommand(
                                            "select idfMainObject from tauDataAuditEvent where idfDataAuditEvent = " +
                                            context.DataAuditEvent).ExecuteScalar<long>());
                    }
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.IsNull(vc);
                    }
                }
            }
            EidssUserContext.Clear();

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                Assert.AreEqual("", manager.SetCommand("select dbo.fnGetContext()").ExecuteScalar().ToString());
                Assert.AreEqual(0,
                                (int)
                                manager.SetCommand(
                                    "select count(*) from tstLocalConnectionContext where strConnectionContext = '" +
                                    clientID + "'").ExecuteScalar());
            }
        }

        private void vcValidationContinue(object sender, ValidationEventArgs args)
        {
            args.Continue = true;
        }

        [TestMethod]
        public void TestCacheByLang()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            EidssUserContext.Init();
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    manager.BeginTransaction();

                    ModelUserContext.CurrentLanguage = "en";

                    VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                    long id;
                    {
                        VetCase vc = vcacc.CreateNewT(manager, null, (int)HACode.Livestock); //livestock
                        id = vc.idfCase;

                        vc.Validation += vcValidationContinue;
                        Assert.IsTrue(vcacc.Post(manager, vc));
                        vc.Validation -= vcValidationContinue;
                    }
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        vc.FinalDiagnosis =
                            vc.FinalDiagnosisLookup.Where(c => c.name == "African Swine Fever").SingleOrDefault();
                        Assert.IsNotNull(vc.FinalDiagnosis);

                        vc.Validation += vcValidationContinue;
                        Assert.IsTrue(vcacc.Post(manager, vc));
                        vc.Validation -= vcValidationContinue;
                    }

                    ModelUserContext.CurrentLanguage = "ru";

                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.AreEqual(vc.FinalDiagnosis,
                            vc.FinalDiagnosisLookup.Where(c => c.name == "Африканская чума свиней").SingleOrDefault());
                    }

                    ModelUserContext.CurrentLanguage = "en";

                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.AreEqual(vc.FinalDiagnosis,
                            vc.FinalDiagnosisLookup.Where(c => c.name == "African Swine Fever").SingleOrDefault());
                    }

                    manager.RollbackTransaction();
                }
                EidssUserContext.Clear();
            }
        }

        [TestMethod]
        public void TestMetaActions()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            EidssUserContext.Init();
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    List<ActionMetaItem> actions_caselist = VetCaseListItem.Meta.Actions;
                    List<ActionMetaItem> actions_case = VetCase.Meta.Actions;
                    List<ActionMetaItem> actions_farm = FarmPanel.Meta.Actions;
                    Assert.AreEqual(10, actions_caselist.Count);
                    Assert.AreEqual(6, actions_case.Count);
                    Assert.AreEqual(10, actions_farm.Count);
                    Assert.AreEqual(5, actions_farm.Where(c => !c.IsExtended).Count());
                    Assert.AreEqual(5, actions_farm.Where(c => c.IsExtended).Count());

                    ActionMetaItem createAction = actions_caselist.Where(c => c.Name == "CreateLivestock").SingleOrDefault();
                    var livestock =
                        (VetCase) createAction.RunAction(manager, null, new List<object> {null, null, null}).obj;
                    Assert.IsNotNull(livestock);

                    ActionMetaItem createHerdAction = actions_farm.Where(c => c.Name == "CreateHerd").SingleOrDefault();
                    Assert.IsTrue(createHerdAction.RunAction(manager, livestock.Farm, new List<object>()).result);
                    Assert.AreEqual(2, livestock.Farm.FarmTree.Count);
                    ActionMetaItem createSpeciesAction =
                        actions_farm.Where(c => c.Name == "CreateSpecies").SingleOrDefault();
                    Assert.IsTrue(createSpeciesAction.RunAction(manager, livestock.Farm,
                                                                        new List<object> {livestock.Farm.FarmTree[1]}).result);
                    Assert.AreEqual(3, livestock.Farm.FarmTree.Count);
                }
                EidssUserContext.Clear();
            }
        }

        [TestMethod]
        public void TestVetCaseList()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            EidssUserContext.Init();
            var target = new EidssSecurityManager();
            int result = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, result);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                VetCaseListItem.Accessor vcacc = VetCaseListItem.Accessor.Instance(null);
                {
                    VetCaseListItem obj_null = vcacc.CreateNewT(manager, null);
                    VetCaseListItem obj = vcacc.CreateNewT(manager, null);
                    obj.Country = obj.CountryLookup.Where(c => c.idfsCountry == 780000000).SingleOrDefault();
                    Assert.AreEqual("Georgia", obj.Country.strCountryName);
                    Assert.IsTrue(obj.RegionLookup.Count > 1);
                    Assert.IsTrue(obj.RayonLookup.Count == 1);
                    Assert.IsTrue(obj.SettlementLookup.Count == 1);

                    obj.Region = obj.RegionLookup.Where(c => c.idfsRegion == 37020000000).SingleOrDefault();
                    Assert.AreEqual("Abkhazia", obj.Region.strRegionName);
                    Assert.IsTrue(obj.RayonLookup.Count > 1);
                    Assert.IsTrue(obj.SettlementLookup.Count == 1);

                    obj.Rayon = obj.RayonLookup.Where(c => c.idfsRayon == 3260000000).SingleOrDefault();
                    Assert.AreEqual("Gagra", obj.Rayon.strRayonName);
                    Assert.IsTrue(obj.SettlementLookup.Count > 1);

                    obj.Settlement = obj.SettlementLookup.Where(c => c.idfsSettlement == 259730000000).SingleOrDefault();
                    Assert.AreEqual("Achmarda", obj.Settlement.strSettlementName);

                    obj.Region = obj.RegionLookup.Where(c => c.idfsRegion == 37030000000).SingleOrDefault();
                    Assert.AreEqual("Adjara", obj.Region.strRegionName);
                    Assert.IsNull(obj.Rayon);
                    Assert.IsNull(obj.Settlement);
                    Assert.IsTrue(obj.RayonLookup.Count > 1);
                    Assert.IsTrue(obj.SettlementLookup.Count == 1);

                    obj.Region = obj.RegionLookup.Where(c => c.idfsRegion == 37020000000).SingleOrDefault();
                    obj.Rayon = obj.RayonLookup.Where(c => c.idfsRayon == 3260000000).SingleOrDefault();
                    obj.Settlement = obj.SettlementLookup.Where(c => c.idfsSettlement == 259730000000).SingleOrDefault();

                    var filters = new FilterParams();
                    filters.Add("idfsCountry", "=", 780000000L);
                    filters.Add("idfsRegion", "=", 37020000000);
                    filters.Add("idfsRayon", "=", 3260000000L);
                    filters.Add("idfsSettlement", "=", 259730000000);
                    /*new database!!
                    var list = vcacc.SelectList(manager, filters);
                    Assert.IsTrue(list.Count > 0);
*/
                    //obj.Region = obj.RegionLookup.Where(c => c.idfsRegion == 37210000000).SingleOrDefault();
                    //list = vcacc.SelectList(manager, obj, obj_null);
                    //Assert.IsTrue(list.Count == 0);
                }
            }
        }


        [TestMethod]
        public void TestVetCase2()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(context))
                {
                    VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                    //manager.BeginTransaction();

                    long id;
                    {
                        VetCase vc = vcacc.CreateNewT(manager, null, (int)HACode.Livestock); //livestock
                        id = vc.idfCase;

                        Assert.AreEqual("In process", vc.CaseProgressStatus.name);
                        Assert.IsNull(vc.datTentativeDiagnosisDate);
                        vc.TentativeDiagnosis =
                            vc.TentativeDiagnosisLookup.Where(c => c.name == "African Swine Fever").Single();
                        vc.TentativeDiagnosis1 = vc.TentativeDiagnosis1Lookup.Where(c => c.name == "Anthrax").Single();
                        vc.TentativeDiagnosis2 = vc.TentativeDiagnosis2Lookup.Where(c => c.name == "Glanders").Single();
                        vc.FinalDiagnosis = vc.FinalDiagnosisLookup.Where(c => c.name == "Anthrax - Unspecified").Single();
                        Assert.IsNotNull(vc.idfsTentativeDiagnosis);
                        Assert.IsNotNull(vc.datTentativeDiagnosisDate);

                        vc.Validation += vc_Validation1;
                        vc.strSummaryNotes = "aaa";
                        Assert.AreEqual("aaa", vc.strSummaryNotes);
                        vc.Validation -= vc_Validation1;

                        vc.strTestNotes = "bbb";
                        vc.strSummaryNotes = "aaa";
                        Assert.AreEqual("aaa", vc.strSummaryNotes);

                        vc.strSampleNotes = "AAA";
                        vc.Validation += vc_Validation2;
                        vc.strSummaryNotes = "bbb";
                        Assert.AreEqual("bbb", vc.strSummaryNotes);
                        vc.Validation -= vc_Validation2;

                        vc.Validation += vc_Validation3;
                        Assert.IsFalse(vcacc.Post(manager, vc));
                        vc.Validation -= vc_Validation3;

                        vc.Farm.Location.Region =
                            vc.Farm.Location.RegionLookup.Where(c => c.idfsRegion == 37020000000).SingleOrDefault();
                        Assert.AreEqual("Abkhazia", vc.Farm.Location.Region.strRegionName);
                        Assert.IsTrue(vc.Farm.Location.RayonLookup.Count > 1);
                        Assert.IsTrue(vc.Farm.Location.SettlementLookup.Count == 1);

                        vc.Farm.Location.Rayon =
                            vc.Farm.Location.RayonLookup.Where(c => c.idfsRayon == 3260000000).SingleOrDefault();
                        Assert.AreEqual("Gagra", vc.Farm.Location.Rayon.strRayonName);
                        Assert.IsTrue(vc.Farm.Location.SettlementLookup.Count > 1);

                        vc.Farm.Location.Settlement =
                            vc.Farm.Location.SettlementLookup.Where(c => c.idfsSettlement == 259730000000).
                                SingleOrDefault();
                        Assert.AreEqual("Achmarda", vc.Farm.Location.Settlement.strSettlementName);

                        vc.datAssignedDate = DateTime.Now.AddDays(-3);
                        vc.datReportDate = DateTime.Now.AddDays(-4);
                        vc.datTentativeDiagnosisDate = DateTime.Now.AddDays(-2);
                        vc.datTentativeDiagnosis1Date = DateTime.Now.AddDays(-1);
                        vc.datTentativeDiagnosis2Date = DateTime.Now.AddDays(-1);

                        vc.strClinicalNotes = "cln";
                        vc.strSampleNotes = "BBB";

                        vc.Validation += vc_Validation4;
                        Assert.IsTrue(vcacc.Post(manager, vc));
                        vc.Validation -= vc_Validation4;
                    }
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);
                        Assert.IsNotNull(vc);
                        Assert.AreEqual("In process", vc.CaseProgressStatus.name);

                        vc.MarkToDelete();
                        vcacc.Post(manager, vc);
                    }
                    {
                        VetCase vc = vcacc.SelectByKey(manager, id);

                        Assert.IsNull(vc);
                    }

                    //manager.RollbackTransaction();
                }
                EidssUserContext.Clear();
            }
        }

        private void vc_Validation1(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
            Assert.AreEqual("strTestNotes", args.FieldName);
        }

        private void vc_Validation2(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("AAA", args.MessageId);
            Assert.AreEqual("", args.FieldName);
        }

        private void vc_Validation3(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
            //Assert.AreEqual("strClinicalNotes", args.FieldName);
        }

        private void vc_Validation4(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("ErrMandatoryFieldRequired", args.MessageId);
            args.Continue = true;
        }

        /*new database!!
        [TestMethod]
        public void TestVetCase()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                VetCase.Accessor vcacc = VetCase.Accessor.Instance(null);
                VetCase vc = vcacc.SelectByKey(manager, 1532470000000L);

                Assert.AreEqual("VGETBTB0110001", vc.strCaseID);
                Assert.AreEqual("FGETBTB0110001", vc.Farm.strFarmCode);
                Assert.AreEqual(3260000000L, vc.Farm.Location.idfsRayon);
                Assert.AreEqual("street", vc.Farm.Address.strStreetName);
                Assert.AreEqual(6, vc.Farm.FarmTree.Count);
                Assert.AreEqual("FGETBTB0110001", vc.Farm.FarmTree[0].strName);
                Assert.AreEqual("IGETBTB0110001", vc.Farm.FarmTree[1].strName);
                Assert.AreEqual("837800000000", vc.Farm.FarmTree[2].strName);
                Assert.AreEqual("837830000000", vc.Farm.FarmTree[3].strName);
                Assert.AreEqual("IGETBTB0110002", vc.Farm.FarmTree[4].strName);
                Assert.AreEqual("837790000000", vc.Farm.FarmTree[5].strName);
                Assert.AreEqual("In process", vc.CaseProgressStatus.name);

                vc.TentativeDiagnosis = null;
                Assert.IsNull(vc.idfsTentativeDiagnosis);
                Assert.IsNull(vc.datTentativeDiagnosisDate);
                vc.TentativeDiagnosis = vc.TentativeDiagnosisLookup.Where(c => c.name == "Brucellosis").Single();
                Assert.IsNotNull(vc.idfsTentativeDiagnosis);
                Assert.IsNotNull(vc.datTentativeDiagnosisDate);

                vc.strClinicalNotes = "cln";
                vc.TentativeDiagnosis1 = vc.TentativeDiagnosis1Lookup.Where(c => c.name == "Brucellosis").Single();
                vcacc.Post(manager, vc);
            }
        }
        */

        [TestMethod]
        public void TestSerialization()
        {
            //DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            //using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            //{
            //    VetCase.Accessor vcacc = VetCase.Accessor.Instance;
            //    VetCase vc = vcacc.SelectByKey(manager, 1532470000000L);

            //    string xml = Serializer.ToXmlString(vc);
            //    VetCase vc2 = Serializer.FromXmlString<VetCase>(xml);

            //    vc2.strClinicalNotes = "cln2";
            //    vc2.TentativeDiagnosis1 = vc2.TentativeDiagnosis1Lookup.Where(c => c.Name == "Brucellosis").Single();
            //    vcacc.Post(manager, vc2);
            //}
        }

        private string SqlForParams(string sp)
        {
            return String.Format(
                @"SELECT
	[Name] = N'@RETURN_VALUE',
	[ID] = 0,
	[Direction] = 6,
	[UserType] = NULL,
	[SystemType] = N'int',
	[Type] = N'Int32',
	[Size] = 4,
	[Precision] = 10,
	[Scale] = 0
WHERE
	OBJECTPROPERTY(OBJECT_ID(N'{0}'), 'IsProcedure') = 1
UNION
SELECT
	[Name] = CASE WHEN p.name <> '' THEN p.name ELSE '@RETURN_VALUE' END,
	[ID] = p.parameter_id,
	[Direction] = CASE WHEN p.is_output = 0 THEN 1 WHEN p.parameter_id > 0 AND p.is_output = 1 THEN 3 ELSE 6 END,
	[UserType] = CASE WHEN ut.is_assembly_type = 1 THEN SCHEMA_NAME(ut.schema_id) + '.' + ut.name ELSE NULL END,
	[SystemType] = CASE WHEN ut.is_assembly_type = 0 AND ut.user_type_id = ut.system_type_id THEN ut.name WHEN ut.is_user_defined = 1 OR ut.is_assembly_type = 0 THEN st.name ELSE 'UDT' END,
	[Type] = 
		CASE 
			WHEN ut.name = 'bit' THEN 'Boolean'
			WHEN ut.name = 'int' THEN 'Int32?'
			WHEN ut.name = 'bigint' THEN 'Int64?'
			WHEN ut.name = 'char' THEN 'String'
			WHEN ut.name = 'nchar' THEN 'String'
			WHEN ut.name = 'varchar' THEN 'String'
			WHEN ut.name = 'nvarchar' THEN 'String'
			WHEN ut.name = 'datetime' THEN 'DateTime?'
			ELSE '' 
		END,
	[Size] = CONVERT(int, CASE WHEN st.name IN (N'text', N'ntext', N'image') AND p.max_length = 16 THEN -1 WHEN st.name IN (N'nchar', N'nvarchar', N'sysname') AND p.max_length >= 0 THEN p.max_length/2 ELSE p.max_length END),
	[Precision] = p.precision,
	[Scale] = p.scale
FROM
	sys.all_parameters p
	INNER JOIN sys.types ut ON p.user_type_id = ut.user_type_id
	LEFT OUTER JOIN sys.types st ON ut.system_type_id = st.user_type_id AND ut.system_type_id = st.system_type_id
WHERE
	object_id = OBJECT_ID(N'{0}')
ORDER BY
	2
",
                sp);
        }

        private void GetSchema(DbManagerProxy manager, string sp)
        {
            try
            {
                var listParams = new List<string>();
                string sqlParams = SqlForParams(sp);
                using (var commParams = new SqlCommand())
                {
                    commParams.Connection = manager.Connection as SqlConnection;
                    commParams.CommandText = sqlParams;
                    commParams.CommandType = CommandType.Text;
                    SqlDataReader rdr = commParams.ExecuteReader();
                    while (rdr.Read())
                    {
                        if ((int) rdr["Direction"] != 6)
                        {
                            var name = (string) rdr["Name"];
                            var typename = (string) rdr["SystemType"];
                            var type = (string) rdr["Type"];
                            var direction = (int) rdr["Direction"];
                            listParams.Add(name);
                        }
                    }
                    rdr.Close();
                }

                using (var commReturn = new SqlCommand())
                {
                    commReturn.Connection = manager.Connection as SqlConnection;
                    if (sp.StartsWith("fn"))
                    {
                        commReturn.CommandText = "select * from dbo." + sp + "(";
                        foreach (string p in listParams)
                        {
                            if (!commReturn.CommandText.EndsWith("("))
                            {
                                commReturn.CommandText += ", ";
                            }
                            commReturn.CommandText += p;
                        }
                        commReturn.CommandText += ")";
                        commReturn.CommandType = CommandType.Text;
                    }
                    else
                    {
                        commReturn.CommandText = sp;
                        commReturn.CommandType = CommandType.StoredProcedure;
                    }
                    foreach (string p in listParams)
                    {
                        var param = new SqlParameter(p, DBNull.Value);
                        commReturn.Parameters.Add(param);
                    }

                    SqlDataReader rdr = commReturn.ExecuteReader();

                    do
                    {
                        DataTable schema = rdr.GetSchemaTable();
                        if (schema != null && schema.Rows != null)
                        {
                            foreach (DataRow line in schema.Rows)
                            {
                                var name = (string) line["ColumnName"];
                                var typename = (string) line["DataTypeName"];
                                var size = (int) line["ColumnSize"];
                                var type = (Type) line["DataType"];
                                var nullable = line["AllowDBNull"] as bool?;
                            }
                        }
                    } while (rdr.NextResult());
                    rdr.Close();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("SP: " + sp, e);
            }
        }

        [TestMethod]     
        [Ignore]
        public void TestModelStoredProcs()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                string fileName = Utils.GetFilePathNearAssembly(Assembly.GetExecutingAssembly(), "eidss.model.dll");

                Assembly asm = Assembly.LoadFrom(fileName);
                Type[] types = asm.GetTypes();
                foreach (Type type in types.Where(c => c.FullName.EndsWith("+Meta")))
                {
                    var container = new List<string>();
                    spName(type, "spSelect", container);
                    //spName(type, "spCount", container);
                    spName(type, "spPost", container);
                    spName(type, "spInsert", container);
                    spName(type, "spUpdate", container);
                    //spName(type, "spDelete", container);
                    //spName(type, "spCanDelete", container);
                    foreach (string sp in container)
                    {
                        GetSchema(manager, sp);
                    }
                }
            }
        }

        private static void spName(Type type, string name, List<string> container)
        {
            FieldInfo fld = type.GetField(name, BindingFlags.Static | BindingFlags.Public);
            if (fld != null)
            {
                var sp = fld.GetValue(null) as string;
                if (!string.IsNullOrEmpty(sp))
                {
                    container.Add(sp);
                }
            }
        }
    }
}
