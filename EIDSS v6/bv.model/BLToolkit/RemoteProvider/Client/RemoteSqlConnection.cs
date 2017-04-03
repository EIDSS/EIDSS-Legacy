using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace bv.model.BLToolkit.RemoteProvider.Client
{
    public class RemoteSqlConnection : DbConnection, ICloneable
    {
        private string m_serverUrl;
        private RemoteSqlClient m_proxy;
        private ConnectionState m_state = ConnectionState.Closed;


        #region DbConnection

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return new RemoteSqlTransaction(m_proxy, isolationLevel, this);
        }

        public override void ChangeDatabase(string databaseName)
        {
        }

        public override void Close()
        {
            m_proxy.Dispose();
            m_state = ConnectionState.Closed;
        }

        public override string ConnectionString
        {
            get
            {
                return m_serverUrl;
            }
            set
            {
                m_serverUrl = value;
            }
        }

        protected override DbCommand CreateDbCommand()
        {
            return new RemoteSqlCommand(m_proxy, this);
        }

        public override string DataSource
        {
            get { return ""; }
        }

        public override string Database
        {
            get { return ""; }
        }

        public override void Open()
        {
            m_proxy = new RemoteSqlClient(m_serverUrl);
            m_state = ConnectionState.Open;
        }

        public override string ServerVersion
        {
            get { return ""; }
        }

        public override ConnectionState State
        {
            get { return m_state; }
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            RemoteSqlConnection ret = new RemoteSqlConnection();
            ret.m_serverUrl = m_serverUrl;
            ret.m_state = m_state;
            if (m_state == ConnectionState.Open)
                ret.Open();
            return ret;
        }

        #endregion

    }
}
