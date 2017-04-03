#region Using

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using bv.common;
using bv.common.Core;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.QueryBuilder;
using NUnit.Framework;
using GlobalSettings=bv.common.GlobalSettings;

#endregion

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class DbTests:BaseTests
    {
        [Test]
        public void GetDataTableTest()
        {
            const string queryString = "Select 'a' as [Additional Comments] ";

            BaseRamDbService db = new BaseRamDbService(); //GetDbManager();

            DataTable dataTable = db.GetQueryResult(queryString);

            Assert.IsNotNull(dataTable);
            Assert.AreEqual(1, dataTable.Columns.Count);
        }

        [Test]
        public void GetFieldTranslationTest()
        {
            
            Dictionary<string, string> translations = QueryTranslations.GetTranslations(QueryId);
            Assert.IsTrue(translations.ContainsKey("sflHC_CaseID"), "translation for Case ID field not found");
            Assert.AreEqual("Human Case ID", translations["sflHC_CaseID"], "Wrong translation");
        }

        #region DBService test

        #region Layout DBService test

        [Test]
        [Ignore("Not Implemented")]
        public void LayoutExistsPivotForm_DBTest()
        {
//            PivotForm_DB dbService = new PivotForm_DB();
            //            Assert.IsFalse(dbService.IsLayoutExists("xxx", "strLayoutName"));
//            string name = GetField((SqlConnection) dbService.Connection, "en");
            //            Assert.IsTrue(dbService.IsLayoutExists(name, "strLayoutName"));
            //            Assert.IsFalse(dbService.IsLayoutExists("xxx", "strDefaultLayoutName"));
//            name = GetField((SqlConnection) dbService.Connection, "en");
            //            Assert.IsTrue(dbService.IsLayoutExists(name, "strDefaultLayoutName"));
        }

        [Test]
        [Ignore("Not Implemented")]
        public void LayoutGetValueWithPrefixTest()
        {
//            PivotForm_DB dbService = new PivotForm_DB();
//            string name = GetField((SqlConnection) dbService.Connection, "en");
            //            Assert.IsTrue(dbService.IsLayoutExists(name, "strLayoutName"));
            //            string newName = dbService.GetValueWithPrefix(name, "strLayoutName", "en");
//            Console.WriteLine(newName);
//            Assert.AreEqual("Copy of Human - Disease counts by age group", newName);
//
//            name = GetField((SqlConnection) dbService.Connection, "ru");
            //            newName = dbService.GetValueWithPrefix(name, "strLayoutName", "ru");
//            Console.WriteLine(newName);
//            Assert.AreEqual("Копия Количество заболеваний по возрастным группам", newName);
        }

        private static string GetField(SqlConnection connection, string lang)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNull(connection, "connection");

            const string getLayoutQuery =
                @"SELECT TOP 1 rf.[Name] from tasLayout l
inner join
dbo.fnReference('{0}', 19000050) rf
on rf.idfsReference = l.idflPivotName
";
            string cmdText = string.Format(getLayoutQuery, lang);
            using (SqlCommand command = new SqlCommand(cmdText))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command.Connection = connection;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null)
                    {
                        if (!reader.HasRows)
                            throw new ApplicationException("No layout found");
                        reader.Read();
                        object value = reader.GetValue(0);
                        return Utils.Str(value);
                    }
                    throw new ApplicationException("Could not get layout ");
                }
            }
        }

        #endregion

        [Test]
        public void GetDetailRAMReportControl_DBTest()
        {
            BaseRamDbService db = new BaseRamDbService();
            DataSet dataSet = db.GetDetail(-1);
            Assert.IsNotNull(dataSet);
            Assert.AreEqual(0, dataSet.Tables.Count);
        }

        [Test]
        public void PostRamDbServiceTest()
        {
            BaseRamDbService dbService = new BaseRamDbService();
            Assert.IsTrue(dbService.Post(new DataSet(), 0));
        }

        [Test]
        public void PostQueryInfo_DBTest()
        {
            QueryInfo_DB dbService = new QueryInfo_DB();
            Assert.IsTrue(dbService.PostDetail(new DataSet(), 0, null));
        }

        [Test]
        public void FailRAMReportControl_DBTest()
        {
            try
            {
                BaseRamDbService db = new BaseRamDbService();
                db.GetQueryResult("xxx");
            }
            catch (RamDbException ex)
            {
                Assert.AreEqual("Error while executing query :'xxx'", ex.Message);
            }
        }

        #endregion
    }
}