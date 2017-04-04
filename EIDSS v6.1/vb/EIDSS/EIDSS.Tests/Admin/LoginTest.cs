using System;
using System.Data;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using NUnit.Framework;
namespace EIDSS.Tests.Admin
{
    [TestFixture]
    public class LoginTest
    {
        private static int DoLogin(string organization, string user, string password, string moduleName, string moduleVersion)
        {
            IDbCommand cmd = BaseDbService.CreateSPCommand("spLogin",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            BaseDbService.AddParam(cmd, "@Organization", organization, ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@UserName", user, ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@Password", password, ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@ModulName", moduleName, ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@ModulVersion", moduleVersion, ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@ClientID", "111", ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@Result", 0, ParameterDirection.InputOutput);
            BaseDbService.ExecCommand(cmd, ConnectionManager.DefaultInstance.Connection, null, true);
            return (int) BaseDbService.GetParamValue(cmd, "@Result");
        
        }
        private static void DeleteTestVersion()
        {
            BaseDbService.ExecSql("DELETE FROM tstVersionCompare WHERE strModuleName='test'", ConnectionManager.DefaultInstance.Connection, null, true);
        }
        private static void UnblockUser()
        {
            BaseDbService.ExecSql("UPDATE tstUserTable SET intTry = NULL, datTryDate = NULL WHERE strAccountName = 'super'", ConnectionManager.DefaultInstance.Connection, null, true);
        }
        private static void UpdateTestVersion(string version, string dbVersion)
        {
            DeleteTestVersion();
            string sql =
                string.Format(
                    "INSERT INTO tstVersionCompare(strModuleName,strModuleVersion,strDatabaseVersion) VALUES ('test', '{0}', '{1}')",
                    version, dbVersion);
            
                BaseDbService.ExecSql(sql, ConnectionManager.DefaultInstance.Connection, null, true);
            
        }
        private string DBVersion;
        [SetUp]
        public void Init()
        {
            IDbCommand cmd = BaseDbService.CreateSPCommand("spTempSetupSite",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            ErrorMessage err = null;
            object ver =
                BaseDbService.ExecScalar(
                    "SELECT strDatabaseVersion FROM tstVersionCompare WHERE strModuleName = 'MainDatabaseVersion'",
                    ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            if (!Utils.IsEmpty(ver))
                DBVersion = ver.ToString();
            UpdateTestVersion("3.0.0", DBVersion);
            UnblockUser();

        }
        [TearDown]
        void Deinit()
        {
            DeleteTestVersion();
            UnblockUser();
            GC.Collect();
        }


        [Test, Ignore("Requires refactoring")]
        public void Login_Test()
        {
            int result = DoLogin("NCDC", "super", "super","test","3.0.0.0");
            Assert.AreEqual(0,result);
            result = DoLogin("", "super", "super","test","3.0.0.0");
            Assert.AreEqual(1,result);
            result = DoLogin("ABC", "super", "super", "test", "3.0.0.0");
            Assert.AreEqual(2, result);
            UpdateTestVersion("3.0.0", "4.0.0");
            result = DoLogin("NCDC", "super", "super", "test", "3.0.0.0");
            Assert.AreEqual(3, result);
            UpdateTestVersion("3.0.0", DBVersion);
            result = DoLogin("NCDC", "super", "super", "test", "2.0.0.0");
            Assert.AreEqual(4, result);
            result = DoLogin("NCDC", "super", "xx", "test", "3.0.0.0");
            Assert.AreEqual(2, result);
            result = DoLogin("NCDC", "super", "xx", "test", "3.0.0.0");
            Assert.AreEqual(2, result);
            result = DoLogin("NCDC", "super", "xx", "test", "3.0.0.0");
            Assert.AreEqual(6, result);
            result = DoLogin("NCDC", "super", "super", "test", "3.0.0.0");
            Assert.AreEqual(6, result);
        }
        
    }
}