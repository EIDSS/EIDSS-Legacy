using eidss.model.AVR.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Configuration;
using bv.model.BLToolkit;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class QueryHelperTests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        public void GetQueryFunctionNameTest()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                Assert.AreEqual("fn_AVR_HumanCaseReport", QueryHelper.GetQueryFunctionName(manager, 49539640000000));
            }
        }

        [TestMethod]
        public void GetQueryTextTest()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                var queryText = QueryHelper.GetQueryText(manager, 49539640000000,  true);
                Assert.IsTrue(queryText.Contains("[sflHC_PatientAge]"));
                Assert.IsTrue(queryText.Contains("[sflHC_PatientAge_Copy]"));
                Assert.IsTrue(queryText.Contains("[sflHC_PatientSex]"));
                Assert.IsTrue(queryText.Contains("[sflHC_PatientSex_Copy]"));
                Assert.IsTrue(queryText.Contains("[sflHC_CaseID]"));
                Assert.IsTrue(queryText.Contains("[sflHC_CaseID_Copy]"));

                queryText = QueryHelper.GetQueryText(manager, 49539640000000, false);
                Assert.IsTrue(queryText.Contains("[sflHC_PatientAge]"));
                Assert.IsFalse(queryText.Contains("[sflHC_PatientAge_Copy]"));
                Assert.IsTrue(queryText.Contains("[sflHC_PatientSex]"));
                Assert.IsFalse(queryText.Contains("[sflHC_PatientSex_Copy]"));
                Assert.IsTrue(queryText.Contains("[sflHC_CaseID]"));
                Assert.IsFalse(queryText.Contains("[sflHC_CaseID_Copy]"));
            }
        }
    }
}