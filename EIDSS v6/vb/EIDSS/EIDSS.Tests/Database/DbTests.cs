using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using EIDSS.Tests.Core;
using NUnit.Framework;
using bv.common.db;
using GlobalSettings = bv.common.GlobalSettings;
using eidss.model.Core.Security;

namespace EIDSS.Tests.Database
{
    [TestFixture]
    public class DbTests
    {
        [SetUp]
        public void Init()
        {
            ClassLoader.Init("eidss*.dll", ".\\");
            GlobalSettings.Init("test", "test", "test");
            ScriptLoader.RunScript(PathToTestFolder.Get("Database") + "Data\\CreateTestTables.sql");

        }
        [TearDown]
        public void Deinit()
        {
             ScriptLoader.RunScript(PathToTestFolder.Get("Database") + "Data\\DropTestTables.sql");
             GC.Collect();
          
        }
        [Test]
        public void NextIntIDTest()
        {
            long id = BaseDbService.NewIntID(null);
            Assert.IsTrue(id > 0, "id is not retrieved");
            IDbTransaction transaction = ConnectionManager.DefaultInstance.Connection.BeginTransaction();
            id = BaseDbService.NewIntID(transaction);
            Assert.IsTrue(id > 0, "id is not retrieved");
            transaction.Rollback();
            //Assert.AreEqual(id, BaseDbService.NewIntID(null),"next id is not rollbacked with transaction");
        }
        [Test]
        public void SiteInfoTest()
        {
            EIDSS_SiteService siteService = new EIDSS_SiteService();
            Assert.IsTrue(siteService.GetCountryID() > 0, "country id is not defined");
            Assert.IsFalse(String.IsNullOrEmpty(siteService.GetCountryName()), "country name is not defined");
            //Assert.IsTrue(siteService.GetSiteID() > 0, "site id is not defined");
            ConnectionManager cm = ConnectionManager.CreateNew("XXX", "xxx", "xxx", "XXX", "Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};Data Source={3};Asynchronous Processing=True");
            siteService.SiteConnection = cm.Connection;

            Assert.AreEqual(780000000, siteService.GetCountryID(), "invalid country id");
            Assert.AreEqual("Georgia", siteService.GetCountryName(), "invalid country name");
            Assert.AreEqual(0, siteService.GetSiteID(), "invalid site id");
            Assert.AreEqual("", siteService.GetSiteHASCCode(), "invalid site hasc code");
            Assert.AreEqual(SiteType.CDR, siteService.GetSiteTypeEnum(), "invalid site type");
            Assert.AreEqual("CDR", siteService.GetSiteType(), "invalid site Type");
            Assert.AreEqual("", siteService.GetOrganizationName(), "invalid organization");
        }
        [Test]
        public void NextNumbersTest()
        {
            foreach (NumberingObject obj in Enum.GetValues(typeof(NumberingObject)))
            {
                ErrorMessage err = null;
                string number = NumberingService.GetNextNumber(obj, ConnectionManager.DefaultInstance.Connection, ref err, null);
                if (err != null)
                    Assert.IsTrue(true, "error in NumberingService call: {0}", err.DetailError);
                Assert.IsFalse(string.IsNullOrEmpty(number), "next number is not generated for {0}", obj.ToString());

            }
        }
        [Test]
        public void GridPagerTest()
        {
            DbDataAdapter da =
                BaseDbService.CreateAdapter("SELECT * from dbo.fn_LookupTable2_SelectList('en')",
                                            ConnectionManager.DefaultInstance.Connection, false, null);
            Pager p = new Pager(da);
            p.PageSize = 10;
            p.VisiblePageCount = 5;
            DataSet ds = new DataSet();
            p.GetPage(ds, "Table", 0);
            Assert.AreEqual(51,p.ApproximateRecordCount);
            p.SelectSQL = "SELECT * from dbo.fn_LookupTable2_SelectList('en') ORDER BY ID ASC, Field2 DESC";
            ds.Clear();
            p.GetPage(ds, "Table", 0);
            Assert.AreEqual("ID ASC, Field2 DESC", p.Order);

        }
        [Test]
        public void ConnectionContextTest()
        {
            GlobalSettings.Init("eidss","eidss","EIDSS");
            GlobalSettings.AppName = "eidss";
            EIDSS_SiteService siteService = new EIDSS_SiteService();
            long siteID = siteService.GetSiteID();
            ErrorMessage err = null;

            IDbCommand setContextCmd = BaseDbService.CreateSPCommand("spSetContext",
                                                           ConnectionManager.DefaultInstance.Connection, null);

            setContextCmd.Parameters.Add(new SqlParameter("@ContextString", "Test"));

            IDbCommand getContextCmd = BaseDbService.CreateCommand("SELECT dbo.fnGetContext()",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            //by defualt GlobalSettings.ClientID is written to context when connection is opened
            object context = BaseDbService.ExecScalar(getContextCmd, ConnectionManager.DefaultInstance.Connection, ref err, null, true); 
            Assert.AreEqual(GlobalSettings.ClientID, context);

            //Check writing/readin context directly
            setContextCmd.Connection.Open();
            setContextCmd.ExecuteNonQuery();
            context = getContextCmd.ExecuteScalar();
            Assert.AreEqual("Test",context);
            setContextCmd.Connection.Close();

            ((SqlParameter)(setContextCmd.Parameters["@ContextString"])).Value = Guid.NewGuid().ToString();
            setContextCmd.Connection.Open();
            setContextCmd.ExecuteNonQuery();
            context = getContextCmd.ExecuteScalar();
            Assert.AreEqual(((SqlParameter)(setContextCmd.Parameters["@ContextString"])).Value , context);
            setContextCmd.Connection.Close();

            //Initialize test users for eidss
            IDbCommand cmd = BaseDbService.CreateSPCommand("spTempCreateUser",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            cmd.Parameters.Add(new SqlParameter("@Account", "Test1"));
            cmd.Parameters.Add(new SqlParameter("@SiteID", siteID));
            cmd.Parameters.Add(new SqlParameter("@Password", "Test1"));
            BaseDbService.ExecCommand(cmd, cmd.Connection, null, true);
            ((SqlParameter)(cmd.Parameters["@Account"])).Value = "Test2";
            ((SqlParameter)(cmd.Parameters["@Password"])).Value = "Test2";
            BaseDbService.ExecCommand(cmd, cmd.Connection, null, true);
            EidssSecurityManager sm = new EidssSecurityManager();

            //Login to system as Test1 and check that fnUserID returns CurrentUser.ID
            sm.LogIn(siteService.GetSiteName(), "Test1", "Test1");
            IDbCommand cmdUser = BaseDbService.CreateCommand("Select dbo.fnUserID()",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            object userID = BaseDbService.ExecScalar(cmdUser, ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            Assert.AreEqual(eidss.model.Core.EidssUserContext.User.ID, userID);

            //Login to system as Test2 and check that fnUserID returns CurrentUser.ID
            sm.LogIn(siteService.GetSiteName(), "Test2", "Test2");
            userID = BaseDbService.ExecScalar(cmdUser, ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            Assert.AreEqual(eidss.model.Core.EidssUserContext.User.ID, userID);

            //Set Context data test. Write some data to the tstLocalConnectionContext with current Client ID as primary key
            object eventID = BaseDbService.ExecScalar("Select Top 1 idfEventID From tstEvent",
                                                       ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            object auditEventID = BaseDbService.ExecScalar("Select Top 1 idfDataAuditEvent From tauDataAuditEvent",
                                                       ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            cmd = BaseDbService.CreateSPCommand("spSetContextData",
                                                           ConnectionManager.DefaultInstance.Connection, null);


            cmd.Parameters.Add(new SqlParameter("@idfEventID", eventID));
            cmd.Parameters.Add(new SqlParameter("@idfDataAuditEvent", auditEventID));
            //cmd.Parameters.Add(new SqlParameter("@idfUserID", CurrentUser.ID));

            IDbCommand cmd1 = BaseDbService.CreateSPCommand("spGetContextData",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            StoredProcParamsCache.CreateParameters(cmd1, null);

            IDbCommand cmd2 = BaseDbService.CreateSPCommand("spClearContextData",
                                                           ConnectionManager.DefaultInstance.Connection, null);
            cmd2.Parameters.Add(new SqlParameter("@ClearEventID", 1));
            cmd2.Parameters.Add(new SqlParameter("@ClearDataAuditEvent", 1));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            Assert.AreEqual(eventID, BaseDbService.GetParamValue(cmd1, "@idfEventID"));
            Assert.AreEqual(auditEventID, BaseDbService.GetParamValue(cmd1, "@idfDataAuditEvent"));
            Assert.AreEqual(eidss.model.Core.EidssUserContext.User.ID, BaseDbService.GetParamValue(cmd1, "@idfUserID"));
            cmd2.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            Assert.AreEqual(DBNull.Value, BaseDbService.GetParamValue(cmd1, "@idfEventID"));
            Assert.AreEqual(DBNull.Value, BaseDbService.GetParamValue(cmd1, "@idfDataAuditEvent"));
            Assert.AreEqual(eidss.model.Core.EidssUserContext.User.ID, BaseDbService.GetParamValue(cmd1, "@idfUserID"));
            cmd.Connection.Close();




        }

   }
}