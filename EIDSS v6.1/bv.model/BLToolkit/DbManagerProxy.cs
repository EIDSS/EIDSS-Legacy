using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using bv.model.Model.Core;

namespace bv.model.BLToolkit
{
    public enum DatabaseType
    {
        Main = 0,
        Archive = 1,
        Avr = 2,
        AvrTicket = 3
    }

    public class DbManagerProxy : DbManager
    {
        private bool m_bTransaction;
        private ModelUserContext m_Context;
        private readonly CacheScope m_CacheScope;
        private readonly DatabaseType m_DatabaseType;
        private long m_AuditEvent;
        private int m_RefCount;
        private IsolationLevel m_DefaultIsolationLevel = IsolationLevel.ReadCommitted;

        internal static string NameDbManagerSlot(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.Main:
                    return "DbManager";
                case DatabaseType.Archive:
                    return "DbManagerArchive";
                case DatabaseType.Avr:
                    return "DbManagerAvr";
            }
            return "DbManager";
        }

        internal DbManagerProxy
            (DataProviderBase provider, string connectionString, ModelUserContext context, CacheScope cacheScope, DatabaseType databaseType)
            : base(provider, connectionString)
        {
            CommandTimeout = 300;
            m_Context = context;
            m_CacheScope = cacheScope;
            m_DatabaseType = databaseType;
            if (m_Context != null)
            {
                m_Context.SetContext(this);
            }
        }

        internal int IncrementRef()
        {
            return ++m_RefCount;
        }

        internal int DecrementRef()
        {
            return --m_RefCount;
        }

        public bool TestConnection()
        {
            int saveTimeout = CommandTimeout;
            try
            {
                CommandTimeout = 5;
                SetCommand("select 0").ExecuteScalar<int>();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CommandTimeout = saveTimeout;
            }
            return true;
        }

        public Exception TestConnectionEx()
        {
            int saveTimeout = CommandTimeout;
            try
            {
                CommandTimeout = 5;
                SetCommand("select 0").ExecuteScalar<int>();
            }
            catch (Exception e)
            {
                return e;
            }
            finally
            {
                CommandTimeout = saveTimeout;
            }
            return null;
        }

        public ModelUserContext Context
        {
            get { return m_Context; }
        }

        public CacheScope CacheScope
        {
            get { return m_CacheScope; }
        }

        protected override void Dispose(bool disposing)
        {
            if (DecrementRef() > 0)
            {
                return;
            }

            if (m_Context != null)
            {
                m_Context.ClearContext(this);
                m_Context = null;
            }

            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(NameDbManagerSlot(m_DatabaseType));
            if (slot != null)
            {
                Thread.SetData(slot, null);
            }

            base.Dispose(disposing);
        }

        public class EventParamsData
        {
            [CLSCompliant(false)]
            public bool _isStartReplication { get; set; }
            [CLSCompliant(false)]
            public object[] _val { get; set; }
        }

        public object[] AuditParams { get; set; }
        private readonly Dictionary<string, EventParamsData> m_EventParams = new Dictionary<string, EventParamsData>();

        public void SetEventParams(bool isStartReplication, string key, object[] val)
        {
            if (!m_EventParams.ContainsKey(key))
            {
                m_EventParams.Add(key, new EventParamsData(){ _isStartReplication = isStartReplication, _val = val });
            }
        }
        public void SetEventParams(bool isStartReplication, object[] val)
        {
            string key = ((Enum)val[0]).ToString() + "_" + val[1].ToString();
            if (!m_EventParams.ContainsKey(key))
            {
                m_EventParams.Add(key, new EventParamsData() { _isStartReplication = isStartReplication, _val = val });
            }
        }

        public int CommandTimeout { get; set; }

        public IsolationLevel DefaultIsolationLevel { get { return m_DefaultIsolationLevel; } set { m_DefaultIsolationLevel = value; } }

        protected override IDbCommand OnInitCommand(IDbCommand command)
        {
            IDbCommand ret = base.OnInitCommand(command);
            ret.CommandTimeout = CommandTimeout;
            return ret;
        }

        public override DbManager BeginTransaction(IsolationLevel il)
        {
            //long count = SetSpCommand("spSysGetTrCount").ExecuteScalar<long>(ScalarSourceType.OutputParameter);

            m_bTransaction = true;
            DbManager ret = base.BeginTransaction(il);

            //count = SetSpCommand("spSysGetTrCount").ExecuteScalar<long>(ScalarSourceType.OutputParameter);

            if (Context != null && AuditParams != null)
            {
                m_AuditEvent = Context.Audit(this, AuditParams);
            }
            return ret;
        }

        public override DbManager BeginTransaction()
        {
            return BeginTransaction(m_DefaultIsolationLevel);
        }

        public override DbManager CommitTransaction()
        {
            //long count = SetSpCommand("spSysGetTrCount").ExecuteScalar<long>(ScalarSourceType.OutputParameter);

            m_bTransaction = false;
            DbManager ret = base.CommitTransaction();

            //count = SetSpCommand("spSysGetTrCount").ExecuteScalar<long>(ScalarSourceType.OutputParameter);
            
            if (Context != null && m_EventParams.Count > 0)
            {
                bool isStartReplication = false;
                foreach (KeyValuePair<string, EventParamsData> eventParam in m_EventParams)
                {
                    if (eventParam.Value._isStartReplication)
                    {
                        isStartReplication = true;
                        break;
                    }
                }

                if (isStartReplication)
                {
                    isStartReplication = Context.IsStartReplicationQuestion();
                }

                base.BeginTransaction(IsolationLevel.ReadCommitted);
                foreach (KeyValuePair<string, EventParamsData> eventParam in m_EventParams)
                {
                    Context.Event(this, 2, eventParam.Value._val);
                }
                base.CommitTransaction();

                if (isStartReplication)
                {
                    Context.StartReplication();
                }
            }
            if (Context != null && m_AuditEvent != 0)
            {
                Context.Filtration(m_AuditEvent);
            }
            AuditParams = null;
            m_EventParams.Clear();
            m_AuditEvent = 0;
            return ret;
        }

        public override DbManager RollbackTransaction()
        {
            m_bTransaction = false;
            AuditParams = null;
            m_EventParams.Clear();
            m_AuditEvent = 0;
            return base.RollbackTransaction();
        }

        public bool IsTransactionStarted
        {
            get { return m_bTransaction; }
        }
    }

    public abstract class DbManagerFactory
    {
        public abstract DbManagerProxy Create(ModelUserContext context = null, CacheScope cacheScope = null);

        private static DbManagerFactory[] g_Factory = new DbManagerFactory[4];

        public static DbManagerFactory Factory
        {
            get { return g_Factory[(int)DatabaseType.Main]; }
        }

        public DbManagerFactory this[DatabaseType databaseType]
        {
            get { return g_Factory[(int)databaseType]; }
        }

        public static void SetSqlFactory(string connectionString, DatabaseType databaseType = DatabaseType.Main)
        {
            g_Factory[(int)databaseType] = new SqlDbManagerFactory(connectionString, databaseType);

            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DbManagerProxy.NameDbManagerSlot(databaseType));
            if (slot != null)
            {
                Thread.SetData(slot, null);
            }
        }

        public static void SetRemoteFactory(string url = "")
        {
            g_Factory[(int)DatabaseType.Main] = new RemoteDbManagerFactory(url);
        }
        public virtual string ConnectionString
        {
            get { return ""; }
        }
    }

    internal class SqlDbManagerFactory : DbManagerFactory
    {
        private readonly string m_ConnectionString;
        private readonly DatabaseType m_DatabaseType;

        internal SqlDbManagerFactory(string connectionString, DatabaseType databaseType)
        {
            m_ConnectionString = connectionString;
            m_DatabaseType = databaseType;
        }

        public override string ConnectionString
        {
            get { return m_ConnectionString; }
        }

        public override DbManagerProxy Create(ModelUserContext context = null, CacheScope cacheScope = null)
        {
            DbManagerProxy ret;
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DbManagerProxy.NameDbManagerSlot(m_DatabaseType));
            if (slot != null)
            {
                ret = Thread.GetData(slot) as DbManagerProxy;
                if (ret != null)
                {
                    ret.IncrementRef();
                    return ret;
                }
            }
            else
            {
                slot = Thread.AllocateNamedDataSlot(DbManagerProxy.NameDbManagerSlot(m_DatabaseType));
            }

            var connectionString = (context != null && context.IsArchiveMode)
                ? context.DatabaseConnectionString
                : m_ConnectionString;
            ret = new DbManagerProxy(new SqlDataProvider(), connectionString, context, cacheScope, m_DatabaseType);
            ret.IncrementRef();
            Thread.SetData(slot, ret);
            return ret;
        }
    }

    internal class RemoteDbManagerFactory : DbManagerFactory
    {
        private string m_url;
        private readonly DatabaseType m_DatabaseType;

        internal RemoteDbManagerFactory(string url = "", DatabaseType databaseType = DatabaseType.Main)
        {
            m_url = url;
            m_DatabaseType = databaseType;
        }
        public override DbManagerProxy Create(ModelUserContext context = null, CacheScope cacheScope = null)
        {
            DbManagerProxy ret;
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DbManagerProxy.NameDbManagerSlot(m_DatabaseType));
            if (slot != null)
            {
                ret = Thread.GetData(slot) as DbManagerProxy;
                if (ret != null)
                {
                    ret.IncrementRef();
                    return ret;
                }
            }
            else
            {
                slot = Thread.AllocateNamedDataSlot(DbManagerProxy.NameDbManagerSlot(m_DatabaseType));
            }
            ret = new DbManagerProxy(new RemoteSqlDataProvider(), m_url, context, cacheScope, m_DatabaseType);
            ret.IncrementRef();
            Thread.SetData(slot, ret);
            return ret;
        }
    }

}
