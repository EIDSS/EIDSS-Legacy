using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;

namespace bv.model.BLToolkit.RemoteProvider.Client
{

    public class RemoteSqlCommand : DbCommand, ICloneable
    {
        private RemoteSqlClient m_proxy;
        private SqlCommand m_command = new SqlCommand();
        private RemoteSqlConnection m_connection;
        private RemoteSqlTransaction m_transaction;

        public RemoteSqlCommand(RemoteSqlClient proxy, RemoteSqlConnection conn)
        {
            m_proxy = proxy;
            m_connection = conn;
        }

        private byte[] Serialize()
        {
            return SqlCommandSerializer.ToByteArray(m_command);
        }

        public void DeriveParameters()
        {
            m_command.Parameters.AddRange(m_proxy.DeriveParameters(Serialize()));
        }

        #region DbCommand

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override string CommandText
        {
            get
            {
                return m_command.CommandText;
            }
            set
            {
                m_command.CommandText = value;
            }
        }

        public override int CommandTimeout
        {
            get
            {
                return m_command.CommandTimeout;
            }
            set
            {
                m_command.CommandTimeout = value;
            }
        }

        public override CommandType CommandType
        {
            get
            {
                return m_command.CommandType;
            }
            set
            {
                m_command.CommandType = value;
            }
        }

        protected override DbParameter CreateDbParameter()
        {
            return m_command.CreateParameter();
        }

        protected override DbConnection DbConnection
        {
            get
            {
                return m_connection;
            }
            set
            {
                m_connection = value as RemoteSqlConnection;
            }
        }

        protected override DbParameterCollection DbParameterCollection
        {
            get { return m_command.Parameters; }
        }

        protected override DbTransaction DbTransaction
        {
            get
            {
                return m_transaction;
            }
            set
            {
                m_transaction = value as RemoteSqlTransaction;
            }
        }

        public override bool DesignTimeVisible
        {
            get
            {
                return m_command.DesignTimeVisible;
            }
            set
            {
                m_command.DesignTimeVisible = value;
            }
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            byte[] outcmd;
            var ret = m_proxy.ExecuteDbDataReader(Serialize(), behavior, out outcmd);
            var cmd = SqlCommandSerializer.FromByteArray(outcmd);
            MergePars(cmd.Parameters.Cast<SqlParameter>());
            return ret;
        }

        private void MergePars(IEnumerable<SqlParameter> pars)
        {
            var list = m_command.Parameters.Cast<SqlParameter>().Join(pars, c => c.ParameterName, r => r.ParameterName,
                                                               (c, r) => new { par = c, val = r.Value }).Where(
                                                                   c => c.par.Direction == ParameterDirection.InputOutput || c.par.Direction == ParameterDirection.Output || c.par.Direction == ParameterDirection.ReturnValue);
            foreach (var i in list)
                i.par.Value = i.val;
        }

        public override int ExecuteNonQuery()
        {
            int ret = 0;
            SqlParameter[] pars = m_proxy.ExecuteNonQuery(Serialize(), out ret);
            MergePars(pars);
            return ret;
        }

        public override object ExecuteScalar()
        {
            return m_proxy.ExecuteScalar(Serialize());
        }

        public override void Prepare()
        {
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
