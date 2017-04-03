using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
#if !MONO
using bv.common.Configuration;
#endif

namespace bv.model.BLToolkit.RemoteProvider.Server
{
    public class RemoteSqlInstance : IDisposable
    {
        public static string ConnectionString { get; set; }

        private SqlConnection m_conn;
        private SqlTransaction m_trans;
        private Guid m_key;

        public RemoteSqlInstance(Guid key)
        {
            m_key = key;
            m_conn = new SqlConnection();
#if MONO
            m_conn.ConnectionString = "";
#else
            m_conn.ConnectionString = ConnectionString ?? Config.GetSetting("TestConnectionString", "");
#endif
            m_conn.Open();
        }

        public void Close()
        {
            if (m_trans != null)
            {
                m_trans.Rollback();
                m_trans = null;
            }
            m_conn.Close();
        }

        public DataSet ExecuteDbDataReader(SqlCommand comm, CommandBehavior behavior)
        {
            comm.Connection = m_conn;
            comm.Transaction = m_trans;
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }
        public int ExecuteNonQuery(SqlCommand comm)
        {
            comm.Connection = m_conn;
            comm.Transaction = m_trans;
            return comm.ExecuteNonQuery();
        }
        public object ExecuteScalar(SqlCommand comm)
        {
            comm.Connection = m_conn;
            comm.Transaction = m_trans;
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            return reader[0];
        }
        public void DeriveParameters(SqlCommand comm)
        {
            comm.Connection = m_conn;
            comm.Transaction = m_trans;
            SqlCommandBuilder.DeriveParameters(comm);
        }

        public void BeginTransaction(IsolationLevel iso)
        {
            if (m_trans != null)
            {
                m_trans.Rollback();
                m_trans = null;
            }
            m_trans = m_conn.BeginTransaction(iso);
        }
        public void CommitTransaction()
        {
            if (m_trans != null)
            {
                m_trans.Commit();
                m_trans = null;
            }
        }
        public void RollbackTransaction()
        {
            if (m_trans != null)
            {
                m_trans.Rollback();
                m_trans = null;
            }
        }


        #region IDisposable Members

        public void Dispose()
        {
            Close();
        }

        #endregion
    }
}
