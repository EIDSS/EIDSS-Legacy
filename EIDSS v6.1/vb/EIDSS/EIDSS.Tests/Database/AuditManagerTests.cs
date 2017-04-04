using System;
using System.Data;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Objects;
using bv.common.win.Core;
using NUnit.Framework;
using bv.common.db;
using GlobalSettings = bv.common.GlobalSettings;
namespace EIDSS.Tests.Database
{

    [TestFixture]
    public class AuditManagerTests
    {
        [SetUp]
        public void Init()
        {
            ClassLoader.Init("eidss*.dll", ".\\");
            GlobalSettings.Init("test", "test", "test");
            GlobalSettings.AppName = "eidss";
            GlobalSettings.CurrentLanguage = GlobalSettings.lngEn;
            WinClient.Init();
            if (ClientAccessor.SecurityManager.LogIn(BaseSettings.DefaultOrganization, BaseSettings.DefaultUser, BaseSettings.DefaultPassword, null, null, null, null,false) != 0)
                throw (new Exception("login failed"));
        }
        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        private static void CreateAuditRecord(AuditObject auditData, AuditEventType auditEventType, IDbCommand cmd)
        {
            auditData.EventType = auditEventType;
            object auditID = AuditManager.CreateAuditEvent(auditData, cmd.Transaction, true);
            BaseDbService.SetParam(cmd, "@auditID", auditID, ParameterDirection.Input);
            IDbDataAdapter da = BaseDbService.CreateAdapter(cmd, false);
            using (DataSet ds = new DataSet())
            {
                da.Fill(ds);
                Assert.AreEqual(1, ds.Tables.Count);
                Assert.AreEqual(1, ds.Tables[0].Rows.Count);
                DataRow row = ds.Tables[0].Rows[0];

                Assert.AreEqual(auditData.Key, row["idfMainObject"]);
                Assert.AreEqual(auditData.AuditTable, row["idfMainObjectTable"]);
                Assert.AreEqual(auditData.Name, row["idfsDataAuditObjectType"]);
                Assert.AreEqual((long)auditData.EventType, row["idfsDataAuditEventType"]);
                Assert.AreEqual(auditData.LastAuditEventID, row["idfDataAuditEvent"]);
                CheckConnectionContext(auditData.LastAuditEventID, cmd.Connection, cmd.Transaction);

            }
        }
        private static void CheckConnectionContext(object auditId, IDbConnection connection, IDbTransaction transaction)
        {
            IDbCommand cmd = BaseDbService.CreateSPCommand("spGetContextData", connection, transaction);
            StoredProcParamsCache.CreateParameters(cmd,null);
            BaseDbService.ExecCommand(cmd, connection, transaction, true);
            Assert.AreEqual(auditId, BaseDbService.GetParamValue( cmd, "@idfDataAuditEvent"));
            Assert.AreEqual(eidss.model.Core.EidssUserContext.User.ID, BaseDbService.GetParamValue(cmd, "@idfUserID"));
        }
        [Test]
        public void AuditManagerTest()
        {
            IDbConnection connection = ConnectionManager.DefaultInstance.Connection;
            IDbTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                AuditManager.ClearAuditContext(null, connection);
                transaction = connection.BeginTransaction();
                CheckConnectionContext(DBNull.Value, connection, transaction);
                AuditObject auditData  = new EIDSS.Core.EIDSSAuditObject((long)EIDSSAuditObject.daoTest, (long)AuditTable.tlbTesting);
                auditData.Key = 1;
                IDbCommand cmd = BaseDbService.CreateCommand("Select * from tauDataAuditEvent Where idfDataAuditEvent = @auditID", connection, transaction);
                BaseDbService.AddTypedParam(cmd, "@auditID", SqlDbType.BigInt, ParameterDirection.Input);
                CreateAuditRecord(auditData, AuditEventType.daeCreate, cmd);
                CreateAuditRecord(auditData, AuditEventType.daeDelete, cmd);
                CreateAuditRecord(auditData, AuditEventType.daeEdit, cmd);
                CreateAuditRecord(auditData, AuditEventType.daeFreeDataUpdate, cmd);
                transaction.Commit();
                CheckConnectionContext(auditData.LastAuditEventID, connection, transaction);
                transaction = null;
            }
            finally
            {
                if (transaction != null && transaction.Connection != null)
                {
                    transaction.Rollback();
                }
                transaction = null;
                AuditManager.ClearAuditContext(null, connection);
                CheckConnectionContext(DBNull.Value, connection, transaction);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}