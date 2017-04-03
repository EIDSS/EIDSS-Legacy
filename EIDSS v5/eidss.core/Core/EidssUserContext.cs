using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using BLToolkit.Data;
using BLToolkit.Reflection;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using DataException = BLToolkit.Data.DataException;
using bv.common.Diagnostics;
using eidss.model.Core.Security;

namespace eidss.model.Core
{
    [Serializable]
    public class EidssUserContext : ModelUserContext
    {
        public long DataAuditEvent { get; private set; }

        private readonly List<long> m_EventIdents = new List<long>();        

        protected EidssUserContext(string clientID, IsProcessedDelegate isProcessed)
            : base(clientID)
        {
            IsProcessed = isProcessed;
            m_User = new EidssUser();
        }

        //public const string AppTest = "AppTest";
        private static readonly IsProcessedDelegate g_defaultIsProcessed = () => 0;
        public static void Init(IsProcessedDelegate isProcessed = null)
        {
            Creator = () => new EidssUserContext(ClientID, isProcessed ?? g_defaultIsProcessed);
        }

        public static void Clear()
        {
            Creator = null;
            Instance = null;
        }

        private EidssUser m_User = new EidssUser();

        public static EidssUser User
        {
            get { return ((EidssUserContext) Instance).m_User; }
            set { ((EidssUserContext) Instance).m_User = value; }
        }

        public override IUser CurrentUser
        {
            get { return m_User; }
        }

        public override void CreateContextData()
        {
            if (DbManagerFactory.Factory == null)
                return;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(this))
            {
                try
                {
                    manager.SetSpCommand("dbo.spSetContextData",
                                         manager.Parameter("@idfEventID", DBNull.Value),
                                         manager.Parameter("@idfDataAuditEvent", DBNull.Value)
                        ).ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    
                    Dbg.Debug("error during context creating: {0}", e.ToString());

                    //Exception throwing is commented because this method  can be called before creating valid DbManagerFactory with correct connection.
                    //if (e is DataException)
                    //{
                    //    throw DbModelException.Create(e as DataException);
                    //}
                    //throw;
                }
            }
        }

        public override void DeleteContextData()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(this))
            {
                try
                {
                    manager.SetCommand("dbo.spDeleteContextData").ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    if (e is DataException)
                    {
                        throw DbModelException.Create(e as DataException);
                    }
                    throw;
                }
            }
        }

        public override void SetContext(DbManagerProxy manager)
        {
            try
            {
                IDbDataParameter parameter = manager.Parameter("@ContextString", ClientID);
                manager.SetSpCommand("dbo.spSetContext", parameter).ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Dbg.Debug("error during context creating: {0}", e.ToString());

                //Exception throwing is commented because this method can be called before creating valid DbManagerFactory with correct connection.
                //if (e is DataException)
                //{
                //    throw DbModelException.Create(e as DataException);
                //}
                //throw;
            }
        }

        public override void ClearContext(DbManagerProxy manager)
        {
            try
            {
                manager.SetSpCommand("dbo.spSetContext", manager.Parameter("@ContextString", "")).ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Dbg.Debug("error during context clear: {0}", e.ToString());

                //Exception throwing is commented because this method can be called before creating valid DbManagerFactory with correct connection.
                //if (e is DataException)
                //{
                //    throw DbModelException.Create(e as DataException);
                //}
                //throw;
            }
        }

        public override long Audit(DbManagerProxy manager, params object[] auditData)
        {
            return CreateAuditEvent(manager,
                                    (AuditEventType) auditData[0],
                                    (EIDSSAuditObject) auditData[1],
                                    (AuditTable) auditData[2],
                                    (long?) auditData[3]);
        }

        public override void Event(DbManagerProxy manager, int isProcessed, params object[] eventData)
        {
            CreateEvent(manager,
                        isProcessed,
                        (EventType) eventData[0],
                        (long?) eventData[1],
                        (string) eventData[2]);
        }

        public override void Filtration(long id)
        {
            FiltrationManager.AddAuditEvent(id);
        }

        public override bool CanDo(string permission)
        {
            bool ret = true;
            if ((User.Permissions != null) && User.Permissions.ContainsKey(permission))
                ret = User.Permissions[permission];
            return ret;
        }
        public static void CheckUserLoggedIn()
        {
            if (User != null && User.ID != null)
                return;

            throw new ApplicationException(BvMessages.Get("msgUserNotLoggedIn", "msgUserNotLoggedIn"));
        }

        private long CreateAuditEvent(DbManagerProxy manager, AuditEventType auditEventType, EIDSSAuditObject eidssAuditObject, AuditTable auditTable,
                                      long? objectId)
        {
            try
            {
                DataAuditEvent = manager.SetSpCommand("dbo.spAudit_CreateNewEvent",
                                                      auditEventType,
                                                      eidssAuditObject,
                                                      auditTable,
                                                      objectId,
                                                      DBNull.Value,
                                                      DBNull.Value
                    ).ExecuteScalar<long>(ScalarSourceType.OutputParameter, "idfDataAuditEvent");
                return DataAuditEvent;
            }
            catch (Exception e)
            {
                if (e is DataException)
                {
                    throw DbModelException.Create(e as DataException);
                }
                throw;
            }
        }

        private void CreateEvent(DbManagerProxy manager, int isProcessed, EventType eventType, long? objectIdent, string info)
        {
            try
            {
                Type cacheManager = Type.GetType("bv.common.db.Core.LookupCache, bvdb_common");
                if (cacheManager != null)
                {
                    var method = cacheManager.GetMethod("Refresh", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string), typeof(bool), typeof(IDbTransaction), typeof(object) }, null);
                    if (method != null)
                    {
                        method.Invoke(null, new object[] {info, false, manager.Transaction, null});
                    }
                }

                var lEventID = manager.SetSpCommand("dbo.spEventLog_CreateNewEvent",
                                                    eventType,
                                                    objectIdent,
                                                    info,
                                                    DBNull.Value,
                                                    ClientID,
                                                    DBNull.Value,
                                                    isProcessed,
                                                    DBNull.Value,
                                                    DBNull.Value
                    ).ExecuteScalar<long>(ScalarSourceType.OutputParameter, "EventID");

                m_EventIdents.Add(lEventID);
            }
            catch (Exception e)
            {
                if (e is DataException)
                {
                    throw DbModelException.Create(e as DataException);
                }
                throw;
            }
        }

    }
}
