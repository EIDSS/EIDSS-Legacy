using System;
using System.Data;
using System.Text;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using NUnit.Framework;

namespace EIDSS.Tests.Admin
{
    [TestFixture]
    public class SecurityTest
    {
        [SetUp]
        public void Init()
        {
            //IDbCommand cmd = BaseDbService.CreateSPCommand("spTempSetupSite",
            //                                               ConnectionManager.DefaultInstance.Connection, null);
            //ErrorMessage err = null;
            //object ver =
            //    BaseDbService.ExecScalar(
            //        "SELECT strDatabaseVersion FROM tstVersionCompare WHERE strModuleName = 'MainDatabaseVersion'",
            //        ConnectionManager.DefaultInstance.Connection, ref err, null, true);

        }
        [TearDown]
        void Deinit()
        {
        }
        [Test]
        public void PasswordHashTest()
        {
            CheckPasswordHash("p@ssw0rd", "SessionID");
            CheckPasswordHash("русски… п@р0ль", "1234567");

        }
        [Test]
        public void PasswordValidationTest()
        {
            PasswordChecker checker = new PasswordChecker();
            Assert.AreEqual(1, checker.ValidatePassword( "abc"));
            Assert.AreEqual(2, checker.ValidatePassword("qwertyu"));
            Assert.AreEqual(2, checker.ValidatePassword("Qwertyu"));
            Assert.AreEqual(2, checker.ValidatePassword("Qwerty1"));
            Assert.AreEqual(2, checker.ValidatePassword("123456"));
            Assert.AreEqual(2, checker.ValidatePassword("@23456"));
            Assert.AreEqual(2, checker.ValidatePassword("@2345a"));
            Assert.AreEqual(2, checker.ValidatePassword("!@#$$%^&"));
            Assert.AreEqual(0, checker.ValidatePassword("Qwe@ty1"));
        }
        private void CheckPasswordHash(string password, string secureCode)
        {
            string codeHash = PasswordChecker.GetPasswordHash(password, secureCode);
            IDbCommand cmd = BaseDbService.CreateCommand("Select dbo.fnGetPasswordHash(@password,@additionalCode)",
                                                         ConnectionManager.DefaultInstance.Connection, null);
            BaseDbService.AddParam(cmd, "@password", password, ParameterDirection.Input);
            BaseDbService.AddParam(cmd, "@additionalCode", secureCode, ParameterDirection.Input);
            cmd.Connection.Open();
            object sqlHash = cmd.ExecuteScalar();
            cmd.Connection.Close();
            Assert.AreEqual(sqlHash, codeHash);
            
        }



    }
}