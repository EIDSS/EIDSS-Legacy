using System.Collections.Generic;
using System.Data;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.QueryBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;
using bv.common.db;
using bv.tests.common;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class DbTests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void GetDataTableTest()
        {
            const string queryString = "Select 'a' as [Additional Comments] ";

            var db = new BaseRamDbService();
            DataTable dataTable = RamFormPresenter.GetQueryResult(db, queryString, "",false);

            Assert.IsNotNull(dataTable);
            Assert.AreEqual(1, dataTable.Columns.Count);
        }

        [TestMethod]
        public void GetFieldTranslationTest()
        {
            Dictionary<string, string> translations = QueryProcessor.GetTranslations(BaseReportTests.QueryId);
            Assert.IsTrue(translations.ContainsKey("sflHC_CaseID"), "translation for Case ID field not found");
            Assert.AreEqual("Human Case ID", translations["sflHC_CaseID"], "Wrong translation");
        }

        #region DBService test

        [TestMethod]
        public void GetDetailRAMReportControl_DBTest()
        {
            var db = new BaseRamDbService();
            DataSet dataSet = db.GetDetail(-1);
            Assert.IsNotNull(dataSet);
            Assert.AreEqual(0, dataSet.Tables.Count);
        }

        [TestMethod]
        public void PostRamDbServiceTest()
        {
            var dbService = new BaseRamDbService();
            Assert.IsTrue(dbService.Post(new DataSet()));
        }

        [TestMethod]
        public void PostQueryInfo_DBTest()
        {
            var dbService = new QueryInfo_DB();
            Assert.IsTrue(dbService.PostDetail(new DataSet(), 0, null));
        }

        [TestMethod]
        public void FailRAMReportControl_DBTest()
        {
            try
            {
                var db = new BaseRamDbService();
                RamFormPresenter.GetQueryResult(db, "xxx", "",false);
            }
            catch (RamDbException ex)
            {
                Assert.AreEqual("Error while executing query :'xxx'", ex.Message);
            }
        }

        [TestMethod]
        public void MultipleIdTest()
        {
            List<long> ids = BaseDbService.NewListIntID(2);
            Assert.IsNotNull(ids);
            Assert.AreEqual(2, ids.Count);
        }

        #endregion
    }
}
