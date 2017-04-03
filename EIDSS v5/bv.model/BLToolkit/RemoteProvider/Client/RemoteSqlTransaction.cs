using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace bv.model.BLToolkit.RemoteProvider.Client
{
    public class RemoteSqlTransaction : DbTransaction
    {
        private RemoteSqlClient m_proxy;
        private DbConnection m_conn;
        private IsolationLevel m_iso;

        public RemoteSqlTransaction(RemoteSqlClient proxy, IsolationLevel iso, DbConnection conn)
        {
            m_proxy = proxy;
            m_iso = iso;
            m_conn = conn;
            m_proxy.BeginTransaction(iso);
        }

        #region DbTransaction

        public override void Commit()
        {
            m_proxy.CommitTransaction();
        }

        protected override DbConnection DbConnection
        {
            get { return m_conn; }
        }

        public override IsolationLevel IsolationLevel
        {
            get { return m_iso; }
        }

        public override void Rollback()
        {
            m_proxy.RollbackTransaction();
        }

        #endregion
    }
}
