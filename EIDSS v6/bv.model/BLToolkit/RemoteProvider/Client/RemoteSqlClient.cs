using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using bv.model.BLToolkit.RemoteProvider.Server;
using System.ServiceModel;



namespace bv.model.BLToolkit.RemoteProvider.Client
{
    public class RemoteSqlClient : IDisposable
    {
        private IRemoteSql m_server = new RemoteSqlServer();
        private Guid m_instance = Guid.NewGuid();

        public RemoteSqlClient(string serverUrl)
        {
        }

        public DbDataReader ExecuteDbDataReader(byte[] comm, CommandBehavior behavior, out byte[] cmd)
        {
            byte[][] ret = m_server.ExecuteDbDataReader(m_instance, comm, behavior);
            DataSet ds = Serializer.FromByteArray<DataSet>(ret[0]);
            if (ds.Tables.Count == 0)
                ds.Tables.Add();
            cmd = ret[1];
            return new DataTableReader(ds.Tables.Cast<DataTable>().ToArray());
        }

        public SqlParameter[] ExecuteNonQuery(byte[] comm, out int ret)
        {
            return GetParameters(m_server.ExecuteNonQuery(m_instance, comm, out ret));
        }

        public object ExecuteScalar(byte[] comm)
        {
            return m_server.ExecuteScalar(m_instance, comm);
        }

        public SqlParameter[] DeriveParameters(byte[] comm)
        {
            return GetParameters(m_server.DeriveParameters(m_instance, comm));
        }

        public void BeginTransaction(IsolationLevel iso)
        {
            m_server.BeginTransaction(m_instance, iso);
        }
        public void CommitTransaction()
        {
            m_server.CommitTransaction(m_instance);
        }
        public void RollbackTransaction()
        {
            m_server.RollbackTransaction(m_instance);
        }

        
        private SqlParameter[] GetParameters(byte[] buf)
        {
            SqlCommand com = SqlCommandSerializer.FromByteArray(buf);
            return com.Parameters.Cast<SqlParameter>().Select(c =>
                new SqlParameter
                {
                    ParameterName = c.ParameterName,
                    DbType = c.DbType,
                    Direction = c.Direction,
                    Value = c.Value,
                    Size = c.Size,
                    IsNullable = c.IsNullable
                }
                ).ToArray();
        }



        #region IDisposable Members

        public void Dispose()
        {
            m_server.CloseConnection(m_instance);
        }

        #endregion
    }
}
