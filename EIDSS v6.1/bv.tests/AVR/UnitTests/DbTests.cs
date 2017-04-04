using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using bv.model.BLToolkit;
using bv.tests.common;
using bv.tests.Core;
using eidss.avr.BaseComponents;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.MainForm;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.SourceData;
using eidss.model.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class DbTests
    {
        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }
        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.InitDBAndLogin();
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        public void AvrSearchObjectCheckTest()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                try
                {
                    manager.BeginTransaction();
                    manager.CommandTimeout = 120;

                    string scriptPath =
                        PathToTestFolder.Get(TestFolders.Db) + @"..\..\Sources\EIDSS\eidss.db\Scripts\AVR Check script\Search objects check script.sql";

                    if (!File.Exists(scriptPath))
                    scriptPath =
                        PathToTestFolder.Get(TestFolders.Db) + @"..\..\eidss.db\Scripts\AVR Check script\Search objects check script.sql";

                    IEnumerable<string> scripts = ScriptLoader.LoadScript(scriptPath);
                    foreach (string script in scripts)
                    {
                        if (String.IsNullOrWhiteSpace(script))
                        {
                            continue;
                        }
                        manager.SetCommand(script.Trim()).ExecuteNonQuery();
                    }
                }
                finally
                {
                    manager.RollbackTransaction();
                }
            }
        }

       

        [TestMethod]
        public void GetFieldTranslationTest()
        {
            Dictionary<string, string> translations = QueryProcessor.GetTranslations(BaseReportTests.QueryId);
            Assert.IsTrue(translations.ContainsKey("sflHC_CaseID"), "translation for Case ID field not found");
            Assert.AreEqual("Human Case - Case ID", translations["sflHC_CaseID"], "Wrong translation");
        }

        [TestMethod]
        public void LanguageConfigurationTest()
        {
            IList<string> languages = LanguageDbLoader.GetLanguages();
            Assert.IsNotNull(languages);
            Assert.IsTrue(languages.Count > 0);
            Assert.IsTrue(languages.Contains(Localizer.lngEn));
        }

        #region DBService test

        [TestMethod]
        public void GetAvrDbServiceTest()
        {
            var db = new BaseAvrDbService();
            DataSet dataSet = db.GetDetail(-1);
            Assert.IsNotNull(dataSet);
            Assert.AreEqual(0, dataSet.Tables.Count);
        }

        [TestMethod]
        public void PostAvrDbServiceTest()
        {
            var dbService = new BaseAvrDbService();
            Assert.IsTrue(dbService.Post(new DataSet()));
        }

        [TestMethod]
        public void PostQueryInfo_DBTest()
        {
            var dbService = new QueryInfo_DB();
            Assert.IsTrue(dbService.PostDetail(new DataSet(), 0, null));
        }

        [TestMethod]
        public void FailExecQueryTest()
        {
            try
            {
                AvrMainFormPresenter.ExecQueryForPresenter(new SharedPresenter(StructureMapContainerInit(),new BaseForm()), null, 111,string.Empty);
            }
            catch (AvrDbException ex)
            {
                Assert.AreEqual("Error while executing query with id '111'", ex.Message);
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