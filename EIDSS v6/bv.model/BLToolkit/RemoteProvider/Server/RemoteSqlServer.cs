using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace bv.model.BLToolkit.RemoteProvider.Server
{
    public class RemoteSqlServer : IRemoteSql
    {
        private static Dictionary<Guid, RemoteSqlInstance> g_instancies = new Dictionary<Guid, RemoteSqlInstance>();

        private SqlCommand Command(byte[] comm)
        {
            return SqlCommandSerializer.FromByteArray(comm);
        }
        private RemoteSqlInstance Sql(Guid instance)
        {
            RemoteSqlInstance sql = null;
            lock (g_instancies)
            {
                if (g_instancies.ContainsKey(instance))
                {
                    sql = g_instancies[instance];
                }
                if (sql == null)
                {
                    sql = new RemoteSqlInstance(instance);
                    g_instancies.Add(instance, sql);
                }
            }
            return sql;
        }


        public void CloseConnection(Guid instance)
        {
            lock (g_instancies)
            {
                if (g_instancies.ContainsKey(instance))
                {
                    RemoteSqlInstance o = g_instancies[instance];
                    o.Close();
                    g_instancies.Remove(instance);
                }
            }
        }


        public byte[][] ExecuteDbDataReader(Guid instance, byte[] comm, CommandBehavior behavior)
        {
            SqlCommand cmd = Command(comm);
            RemoteSqlInstance sql = Sql(instance);
            DataSet ds = sql.ExecuteDbDataReader(cmd, behavior);
            var ret = new byte[2][];
            ret[0] = Serializer.ToByteArray(ds);
            ret[1] = SqlCommandSerializer.ToByteArray(cmd);
            return ret;
        }

        public byte[] ExecuteNonQuery(Guid instance, byte[] comm, out int ret)
        {
            SqlCommand cmd = Command(comm);
            RemoteSqlInstance sql = Sql(instance);
            ret = sql.ExecuteNonQuery(cmd);
            return SqlCommandSerializer.ToByteArray(cmd); 
        }

        public object ExecuteScalar(Guid instance, byte[] comm)
        {
            SqlCommand cmd = Command(comm);
            RemoteSqlInstance sql = Sql(instance);
            object ret = sql.ExecuteScalar(cmd);
            return ret;
        }

        public byte[] DeriveParameters(Guid instance, byte[] comm)
        {
            SqlCommand cmd = Command(comm);
            RemoteSqlInstance sql = Sql(instance);
            sql.DeriveParameters(cmd);
            return SqlCommandSerializer.ToByteArray(cmd);
        }

        public void BeginTransaction(Guid instance, IsolationLevel iso)
        {
            RemoteSqlInstance sql = Sql(instance);
            sql.BeginTransaction(iso);
        }
        public void CommitTransaction(Guid instance)
        {
            RemoteSqlInstance sql = Sql(instance);
            sql.CommitTransaction();
        }
        public void RollbackTransaction(Guid instance)
        {
            RemoteSqlInstance sql = Sql(instance);
            sql.RollbackTransaction();
        }

    }

}
