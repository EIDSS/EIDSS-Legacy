using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.db.tests
{
    [TestClass]
    public class VectorSurvaillanceTests
    {
        const string Organizaton = "NCDC&PH";
        const string Admin = "test_admin";
        //const string User = "test_user";
        const string AdminPassword = "test";
        //const string UserPassword = "test";

        [TestInitialize]
        public void TestInit()
        {
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", ""));
        }

        [TestMethod]
        public void VSSessionGeneral()
        {
            using (var context = ModelUserContext.Instance as EidssUserContext)
            {
                var target = new EidssSecurityManager();
                int result = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, result);

                using (var manager = DbManagerFactory.Factory.Create(context))
                {
                    var acc = VsSession.Accessor.Instance(null);
                    manager.BeginTransaction();

                    var vs = acc.CreateNewT(manager);
                    Assert.IsNotNull(vs);
                    long id = vs.idfVectorSurveillanceSession;

                    //The case could not be saved unless the diagnosis is given
                    vs.Validation += hc_Validation_idfsTentativeDiagnosis;
                    Assert.IsTrue(acc.Post(manager, vs));
                    vs.Validation -= hc_Validation_idfsTentativeDiagnosis;

                    vs = acc.SelectByKey(manager, id);
                    Assert.IsNotNull(vs);

                    manager.RollbackTransaction();
                }
                EidssUserContext.Clear();
            }
        }

        private void hc_Validation_idfsTentativeDiagnosis(object sender, ValidationEventArgs args)
        {
            Assert.AreEqual("idfsTentativeDiagnosis", args.FieldName);
        }
    }
}
