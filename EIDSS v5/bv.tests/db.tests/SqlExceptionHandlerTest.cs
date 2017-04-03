using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.model.BLToolkit;
using bv.winclient.Core;

namespace bv.tests.db.tests
{
    [TestClass]
    public class SqlExceptionHandlerTest
    {
        [TestMethod]
        public void GetExceptionDescriptionTest()
        {
            try
            {
                using (var connection = new SqlConnection("Persist Security Info=true;Initial Catalog=xxx;Data Source=xxx;"))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "select 1;";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string description = SqlExceptionHandler.GetExceptionDescription(ex);
                Assert.AreNotEqual(string.Empty, description);
            }
        }

        [TestMethod]
        public void GetInnerExceptionDescriptionTest()
        {
            try
            {
                DbManagerFactory.SetSqlFactory("Persist Security Info=true;Initial Catalog=xxx;Data Source=xxx;");
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    manager.SetCommand("select 1;");
                    manager.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string description = SqlExceptionHandler.GetExceptionDescription(ex);
                Assert.AreNotEqual(string.Empty, description);
            }
        }
    }
}