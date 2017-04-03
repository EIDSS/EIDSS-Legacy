using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using bv.model.Model.Core;

namespace bv.model.BLToolkit
{
    public class DbManagerProxy : DbManager
    {
        private bool m_bTransaction;
        private ModelUserContext m_Context;
        private readonly CacheScope m_CacheScope;
        private long m_AuditEvent;
        private int m_RefCount;

        internal const string NameDbManagerSlot = "DbManager";

        internal DbManagerProxy
            (DataProviderBase provider, string connectionString, ModelUserContext context, CacheScope cacheScope)
            : base(provider, connectionString)
        {
            CommandTimeout = 300;
            m_Context = context;
            m_CacheScope = cacheScope;
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

            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(NameDbManagerSlot);
            if (slot != null)
            {
                Thread.SetData(slot, null);
            }

            base.Dispose(disposing);
        }

        public object[] AuditParams { get; set; }
        private readonly Dictionary<string, object[]> m_EventParams = new Dictionary<string, object[]>();

        public void SetEventParams(string key, object[] val)
        {
            if (!m_EventParams.ContainsKey(key))
            {
                m_EventParams.Add(key, val);
            }
        }

        public int CommandTimeout { get; set; }

        protected override IDbCommand OnInitCommand(IDbCommand command)
        {
            IDbCommand ret = base.OnInitCommand(command);
            ret.CommandTimeout = CommandTimeout;
            return ret;
        }

        public override DbManager BeginTransaction(IsolationLevel il)
        {
            m_bTransaction = true;
            DbManager ret = base.BeginTransaction(il);
            if (Context != null && AuditParams != null)
            {
                m_AuditEvent = Context.Audit(this, AuditParams);
            }
            return ret;
        }

        public override DbManager CommitTransaction()
        {
            m_bTransaction = false;
            DbManager ret = base.CommitTransaction();
            if (Context != null && m_EventParams.Count > 0)
            {
                int isProcessed = Context.IsProcessed();
                base.BeginTransaction(IsolationLevel.ReadCommitted);
                foreach (KeyValuePair<string, object[]> eventParam in m_EventParams)
                {
                    Context.Event(this, isProcessed, eventParam.Value);
                }
                base.CommitTransaction();
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

        private static DbManagerFactory g_Factory;

        public static DbManagerFactory Factory
        {
            get { return g_Factory; }
        }

#if MONO
        public static void SetSqlileFactory(string connectionString)
        {
            g_Factory = new SqliteDbManagerFactory(connectionString);

            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DbManagerProxy.NameDbManagerSlot);
            if (slot != null)
            {
                Thread.SetData(slot, null);
            }
        }
#else
        public static void SetSqlFactory(string connectionString)
        {
            g_Factory = new SqlDbManagerFactory(connectionString);

            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DbManagerProxy.NameDbManagerSlot);
            if (slot != null)
            {
                Thread.SetData(slot, null);
            }
        }
#endif

        public static void SetRemoteFactory(string url = "")
        {
            g_Factory = new RemoteDbManagerFactory(url);
        }
    }

#if MONO
    internal class SqliteDbManagerFactory : DbManagerFactory
    {
        private readonly string m_ConnectionString;

        public SqliteDbManagerFactory(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return m_ConnectionString; }
        }

        public override DbManagerProxy Create(ModelUserContext context = null, CacheScope cacheScope = null)
        {
            DbManagerProxy ret;
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DbManagerProxy.NameDbManagerSlot);
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
                slot = Thread.AllocateNamedDataSlot(DbManagerProxy.NameDbManagerSlot);
            }
            ret = new DbManagerProxy(new SQLiteDataProvider(), m_ConnectionString, context, cacheScope);
            ret.IncrementRef();
            Thread.SetData(slot, ret);
            return ret;
        }
    }
#else
    internal class SqlDbManagerFactory : DbManagerFactory
    {
        private readonly string m_ConnectionString;

        public SqlDbManagerFactory(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return m_ConnectionString; }
        }

        public override DbManagerProxy Create(ModelUserContext context = null, CacheScope cacheScope = null)
        {
            DbManagerProxy ret;
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DbManagerProxy.NameDbManagerSlot);
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
                slot = Thread.AllocateNamedDataSlot(DbManagerProxy.NameDbManagerSlot);
            }

            var connectionString = (context != null && context.IsArchiveMode)
                ? context.DatabaseConnectionString
                : m_ConnectionString;
            ret = new DbManagerProxy(new SqlDataProvider(), connectionString, context, cacheScope);
            ret.IncrementRef();
            Thread.SetData(slot, ret);
            return ret;
        }
    }
#endif

    internal class RemoteDbManagerFactory : DbManagerFactory
    {
        private string m_url;
        public RemoteDbManagerFactory(string url = "")
        {
            m_url = url;
        }
        public override DbManagerProxy Create(ModelUserContext context = null, CacheScope cacheScope = null)
        {
            DbManagerProxy ret;
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DbManagerProxy.NameDbManagerSlot);
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
                slot = Thread.AllocateNamedDataSlot(DbManagerProxy.NameDbManagerSlot);
            }
            ret = new DbManagerProxy(new RemoteSqlDataProvider(), m_url, context, cacheScope);
            ret.IncrementRef();
            Thread.SetData(slot, ret);
            return ret;
        }
    }

}
