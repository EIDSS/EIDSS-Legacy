using System.Threading;
using eidss.model.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using bv.tests.Core;
using bv.common.Configuration;
using eidss.model.Core;
using BLToolkit.Data;
using bv.model.BLToolkit;
using System.Security.Cryptography;
using bv.common.Diagnostics;

namespace bv.tests
{


    /// <summary>
    ///This is a test class for EidssSecurityManagerTest and is intended
    ///to contain all EidssSecurityManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EidssSecurityManagerTest
    {

        private TestContext testContextInstance;
        static string Organizaton;
        const string Admin = "test_admin";
        const string User = "test_user";
        const string AdminPassword = "test";
        const string UserPassword = "test";
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
        private void CompareByteArrays( object expected, object actual)
        {
            Assert.AreEqual((expected as byte[]).Length, (actual as byte[]).Length);
            for (int i = 0; i < (expected as byte[]).Length; i++)
            {
                Assert.AreEqual((expected as byte[])[i], (actual as byte[])[i]);
            }
        }
        #region Additional test attributes
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", null));
            //EidssUserContext.Init();
            //EidssUserContext.ApplicationName = "test";
            ////ScriptLoader.RunScript(PathToTestFolder.Get(TestFolders.Db) + "Data\\DeleteTestAccount.sql", Config.GetSetting("EidssConnectionString", null));
            ////ScriptLoader.RunScript(PathToTestFolder.Get(TestFolders.Db) + "Data\\CreateTestAccount.sql", Config.GetSetting("EidssConnectionString", null));
            using (DbManager manager = DbManagerFactory.Factory.Create())
            {
                object dbVersion = manager.SetCommand("select strDatabaseVersion from tstVersionCompare where strModuleName = 'MainDatabaseVersion'").ExecuteScalar();
                Version ver = Version.Parse(EidssUserContext.Version);
                string appVersion = string.Format("{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
                string cmdText = string.Format("if exists (select strModuleName from tstVersionCompare where strModuleName = 'test') " +
                    " begin " +
                    " update tstVersionCompare set strDatabaseVersion = '{0}', strModuleVersion = '{1}' where strModuleName = 'test' " +
                    " end " +
                    " else " +
                    " begin " +
                    " insert into tstVersionCompare (strModuleName, strDatabaseVersion, strModuleVersion) values ('test', '{0}', '{1}') " +
                    " end "
                    , dbVersion.ToString(), appVersion);
                manager.SetCommand(cmdText).ExecuteNonQuery();
                object org = manager.SetCommand("select	top 1 left(Inst.name, 186) from	tstSite " +
                                                " inner join		dbo.fnInstitution('en') Inst " +
                                                " on				Inst.idfOffice = tstSite.idfOffice " +
                                                "				and Inst.intRowStatus = 0 " +
                                                " where			tstSite.idfsSite= dbo.fnSiteID() " +
                                                "				and tstSite.intRowStatus = 0 " +
                                                " order by		tstSite.idfsSite asc").ExecuteScalar();
                Organizaton = org.ToString();
            }
        }
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            //DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", null));
            //EidssUserContext.Clear();
            //EidssUserContext.Instance.DeleteContextData();
            ////ScriptLoader.RunScript(PathToTestFolder.Get(TestFolders.Db) + "Data\\DeleteTestAccount.sql", Config.GetSetting("EidssConnectionString", null));
        }

        private static object m_Lock = new object();
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            lock (m_Lock)
            {
                DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString", null));
                EidssUserContext.Init();
                EidssUserContext.ApplicationName = "test";
            }
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            lock (m_Lock)
            {
                EidssUserContext.Instance.Close();
                EidssUserContext.Clear();
            }
        }
        
        #endregion


        /// <summary>
        ///A test for EidssSecurityManager Constructor
        ///</summary>
        [TestMethod()]
        public void EidssSecurityManagerConstructorTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
        }

        /// <summary>
        ///A test for CalculatePassword
        ///</summary>
        [TestMethod()]
        [DeploymentItem("eidss.core.dll")]
        public void CalculatePasswordTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            string password = "test";
            byte[] challenge = Guid.NewGuid().ToByteArray();
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.CalculatePassword(password, challenge);
            using (DbManager manager = DbManagerFactory.Factory.Create())
            {
                byte[] passwordHash = SHA1.Create().ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(password));
                manager.SetSpCommand("spCalculatePasswordHash",
                    manager.Parameter("@Password", passwordHash, DbType.Binary, 100),
                    manager.Parameter("@Challenge", challenge, DbType.Binary, 100),
                    manager.Parameter(ParameterDirection.Output, "@PasswordHash", DbType.Binary, 100)).ExecuteNonQuery();
                expected = manager.Parameter("@PasswordHash").Value;
            }
            CompareByteArrays(expected, actual);
        }

        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            string newPassword = "test1";
            int expected = 0;
            int actual;
            actual = target.ChangePassword(Organizaton, Admin, AdminPassword, newPassword);
            Assert.AreEqual(expected, actual);
            actual = target.LogIn(Organizaton, Admin, newPassword);
            Assert.AreEqual(expected, actual);

            object userID = EidssUserContext.User.ID;
            actual = target.SetPassword(userID, AdminPassword);
            Assert.AreEqual(expected, actual);
            actual = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CheckVersion
        ///</summary>
        [TestMethod()]
        [DeploymentItem("eidss.core.dll")]
        public void CheckVersionTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            int expected = 0;
            int actual;
            actual = target.CheckVersion();
            Assert.AreEqual(expected, actual);
            EidssUserContext.ApplicationName = "";
            actual = target.CheckVersion();
            Assert.AreEqual(5, actual);
            EidssUserContext.ApplicationName = "test";
            using (DbManager manager = DbManagerFactory.Factory.Create())
            {
                manager.SetCommand("update tstVersionCompare set strDatabaseVersion='0.0.0' where strModuleName='test'").ExecuteNonQuery();
                actual = target.CheckVersion();
                Assert.AreEqual(3, actual);
                object dbver = manager.SetCommand("select strDatabaseVersion from tstVersionCompare where strModuleName='MainDatabaseVersion'").ExecuteScalar();
                manager.SetCommand(string.Format("update tstVersionCompare set strDatabaseVersion='{0}' where strModuleName='test'", dbver)).ExecuteNonQuery();
            }

        }

        /// <summary>
        ///A test for EvaluateHash
        ///</summary>
        [TestMethod()]
        [DeploymentItem("eidss.core.dll")]
        public void EvaluateHashTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            string password = "test";
            object hash = null; // TODO: Initialize to an appropriate value
            object hashExpected = null; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.EvaluateHash(password, ref hash);
            Assert.AreEqual(0, actual);
            using (DbManager manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                byte[] passwordHash = SHA1.Create().ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(password));
                object challenge = manager.SetCommand("select binChallenge from tstLocalConnectionContext where	strConnectionContext=@context",
                    manager.Parameter("@context", EidssUserContext.ClientID)).ExecuteScalar();
                manager.SetSpCommand("spCalculatePasswordHash",
                    manager.Parameter("@Password", passwordHash, DbType.Binary, 100),
                    manager.Parameter("@Challenge", challenge, DbType.Binary, 100),
                    manager.Parameter(ParameterDirection.Output, "@PasswordHash", DbType.Binary, 100)).ExecuteNonQuery();
                hashExpected = manager.Parameter("@PasswordHash").Value;
            }
            CompareByteArrays(hashExpected, hash);
        }

        /// <summary>
        ///A test for GetPermissions
        ///</summary>
        [TestMethod()]
        public void GetPermissionsTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            int result = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, result);
            IDictionary<string, bool> actual = EidssUserContext.User.Permissions;
            foreach (var value in actual)
            {
                if (value.Key == "UseSimplifiedHumanCaseReportForm.Execute")
                    Assert.IsFalse(value.Value);
                else
                    Assert.IsTrue(value.Value);
            }
            result = target.LogIn(Organizaton, User, UserPassword);
            Assert.AreEqual(0, result);
            actual = EidssUserContext.User.Permissions;
            foreach (string key in actual.Keys)
            {
                if (key.StartsWith("AVRReport."))
                    Assert.IsFalse(actual[key]);
                else if (key.StartsWith("AggregateSettings."))
                    Assert.IsTrue(actual[key]);
            }

        }

        /// <summary>
        ///A test for LogIn
        ///</summary>
        [TestMethod()]
        public void LogInTest()
        {
            EidssSecurityManager target = new EidssSecurityManager(); 
            int actual;
            actual = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, actual);
            actual = target.LogIn(Organizaton, User, UserPassword);
            Assert.AreEqual(0, actual);
            actual = target.LogIn(Organizaton+"1", Admin, AdminPassword);
            if (BaseSettings.UseOrganizationInLogin)
                Assert.AreEqual(2, actual);
            else
                Assert.AreEqual(0, actual);
            actual = target.LogIn(Organizaton, Admin, "invalidpassword");
            Assert.AreEqual(2, actual);
            actual = target.LogIn(Organizaton, Admin + "1", AdminPassword);
            Assert.AreEqual(2, actual);
            int invalidLoginCount = 3;
            using (DbManager manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                invalidLoginCount = manager.SetCommand("select top 1 intAccountTryCount from tstSecurityConfiguration").ExecuteScalar<int>();
            }
            for (int i = 0; i < invalidLoginCount - 1; i++)
            {
                actual = target.LogIn(Organizaton, Admin, "invalidpassword");
                Assert.AreEqual(2, actual);
            }
            actual = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(6, actual);
            using (DbManager manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                manager.SetCommand("update tstUserTableLocal set datTryDate = null, intTry=null " +
                    "from tstUserTable u " +
                    "where " +
	                "u.idfUserID = tstUserTableLocal.idfUserID "+
	                "and u.strAccountName = @strAccountName",
                    manager.Parameter("@strAccountName", Admin)).ExecuteNonQuery();
                actual = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, actual);
                manager.SetCommand("update tstUserTable set datPasswordSet = @date where strAccountName = @strAccountName",
                    manager.Parameter("@date", DateTime.Now.AddDays(-10000)),
                    manager.Parameter("@strAccountName", Admin)).ExecuteNonQuery();
                actual = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(9, actual);
                manager.SetCommand("update tstUserTable set datPasswordSet = @date where strAccountName = @strAccountName",
                    manager.Parameter("@date", DateTime.Now),
                    manager.Parameter("@strAccountName", Admin)).ExecuteNonQuery();
                actual = target.LogIn(Organizaton, Admin, AdminPassword);
                Assert.AreEqual(0, actual);
            }
        }

        /// <summary>
        ///A test for LogOut
        ///</summary>
        [TestMethod()]
        public void LogOutTest()
        {
            EidssSecurityManager target = new EidssSecurityManager(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, actual);
            target.LogOut();
            Assert.AreEqual(false, target.AccessGranted);
            using (DbManager manager = DbManagerFactory.Factory.Create())
            {

                DataTable dt = manager.SetCommand("select * from tstLocalConnectionContext where strConnectionContext=@clientID",
                    manager.Parameter("@clientID", EidssUserContext.ClientID)).ExecuteDataTable();
                Assert.AreEqual(1, dt.Rows.Count);
                DataRow row = dt.Rows[0];
                Assert.AreEqual(DBNull.Value, row["idfUserID"]);
                Assert.AreEqual(DBNull.Value, row["binChallenge"]);
                Assert.AreEqual(DBNull.Value, row["idfDataAuditEvent"]);
                Assert.AreEqual(DBNull.Value, row["idfEventID"]);
            }
        }

        /// <summary>
        ///A test for PasswordHash
        ///</summary>
        [TestMethod()]
        [DeploymentItem("eidss.core.dll")]
        public void PasswordHashTest()
        {
            EidssSecurityManager target = new EidssSecurityManager(); // TODO: Initialize to an appropriate value
            string password = "test";
            object expected = SHA1.Create().ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(password));
            object actual;
            actual = target.PasswordHash(password);
            CompareByteArrays(expected, actual);
        }

        /// <summary>
        ///A test for SetPassword
        ///</summary>
        [TestMethod()]
        public void SetPasswordTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            int actual;
            actual = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, actual);

            object userID = EidssUserContext.User.ID;
            string password = "changedPassword";
            actual = target.SetPassword(userID, password);
            Assert.AreEqual(0, actual);

            actual = target.LogIn(Organizaton, Admin, password);
            Assert.AreEqual(0, actual);

            actual = target.SetPassword(userID, AdminPassword);
            Assert.AreEqual(0, actual);

            actual = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, actual);

            actual = target.SetPassword("-1", "new password");
            Assert.AreEqual(2, actual);

        }

        /// <summary>
        ///A test for AccessGranted
        ///</summary>
        [TestMethod()]
        public void AccessGrantedTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            if (target.AccessGranted)
                target.LogOut();
            bool actual;
            actual = target.AccessGranted;
            Assert.IsFalse(actual);
            int res = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, res);
            actual = target.AccessGranted;
            Assert.IsTrue(actual);
            target.LogOut();
            actual = target.AccessGranted;
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        public void LogInByTicketTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            if (target.AccessGranted)
                target.LogOut();
            int res = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, res);
            string ticket = target.CreateTicket((long)EidssUserContext.User.ID);
            Assert.IsNotNull(ticket);
            target.LogOut();
            res = target.LogIn(ticket);
            Assert.AreEqual(0, res);
            Assert.IsTrue(target.AccessGranted);
            target.LogOut();
            res = target.LogIn(ticket);
            Assert.AreEqual(2, res);
            Assert.IsFalse(target.AccessGranted);
        }

        [TestMethod()]
        public void LogInByTicketDeadlockTest()
        {
            EidssSecurityManager target = new EidssSecurityManager();
            if (target.AccessGranted)
                target.LogOut();
            int res = target.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, res);
            m_Users[0] = (long) EidssUserContext.User.ID;
            //if (target.AccessGranted)
            //    target.LogOut();
            //res = target.LogIn(Organizaton, User, UserPassword);
            //Assert.AreEqual(0, res);
            //m_Users[1] = (long)EidssUserContext.User.ID;
            if (target.AccessGranted)
                target.LogOut();
            var threads = new List<Thread>();
            int threadCount = 100;
            for (int i = 0; i < threadCount; i++)
            {
                var thread  = new Thread(LoginByTicket);
                threads.Add(thread);
                thread.Start();
                Debug.WriteLine("login thread <{0}> is started", i);
                
            }
            while (true)
            {
                Thread.Sleep(100);
                for (int i = 0; i < threadCount; i++)
                {
                    if (threads[i].IsAlive)
                        break;
                    if (i == threadCount - 1)
                        return;
                }
            }
        }

        private void LoginByTicket()
        {
            var userId = m_Users[0];//new Random().Next(0, 1)
            LoginByTicketAsync(userId);
        }

        private readonly long[] m_Users = new long[2] ;
        private void LoginByTicketAsync(long userId)
        {
            EidssSecurityManager target = new EidssSecurityManager();
            string ticket = target.CreateTicket(userId);
            Assert.IsNotNull(ticket);
            var res = target.LogIn(ticket);
            Assert.AreEqual(0, res);
            Assert.IsTrue(target.AccessGranted);
            //target.LogOut();
        }

    }
}
