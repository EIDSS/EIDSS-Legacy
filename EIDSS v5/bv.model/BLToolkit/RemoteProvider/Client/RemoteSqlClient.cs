//#define MONO

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


#if MONO
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IRemoteSql")]
public interface IRemoteSql
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRemoteSql/ExecuteDbDataReader", ReplyAction = "http://tempuri.org/IRemoteSql/ExecuteDbDataReaderResponse")]
    byte[][] ExecuteDbDataReader(System.Guid instance, byte[] comm, System.Data.CommandBehavior behavior);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRemoteSql/ExecuteNonQuery", ReplyAction = "http://tempuri.org/IRemoteSql/ExecuteNonQueryResponse")]
    byte[] ExecuteNonQuery(out int ret, System.Guid instance, byte[] comm);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRemoteSql/ExecuteScalar", ReplyAction = "http://tempuri.org/IRemoteSql/ExecuteScalarResponse")]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.CommandBehavior))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.IsolationLevel))]
    object ExecuteScalar(System.Guid instance, byte[] comm);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRemoteSql/DeriveParameters", ReplyAction = "http://tempuri.org/IRemoteSql/DeriveParametersResponse")]
    byte[] DeriveParameters(System.Guid instance, byte[] comm);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRemoteSql/BeginTransaction", ReplyAction = "http://tempuri.org/IRemoteSql/BeginTransactionResponse")]
    void BeginTransaction(System.Guid instance, System.Data.IsolationLevel iso);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRemoteSql/CommitTransaction", ReplyAction = "http://tempuri.org/IRemoteSql/CommitTransactionResponse")]
    void CommitTransaction(System.Guid instance);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRemoteSql/RollbackTransaction", ReplyAction = "http://tempuri.org/IRemoteSql/RollbackTransactionResponse")]
    void RollbackTransaction(System.Guid instance);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRemoteSql/CloseConnection", ReplyAction = "http://tempuri.org/IRemoteSql/CloseConnectionResponse")]
    void CloseConnection(System.Guid instance);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IRemoteSqlChannel : IRemoteSql, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class RemoteClient : System.ServiceModel.ClientBase<IRemoteSql>, IRemoteSql
{

    public RemoteClient()
    {
    }

    public RemoteClient(string endpointConfigurationName) :
        base(endpointConfigurationName)
    {
    }

    public RemoteClient(string endpointConfigurationName, string remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public RemoteClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public RemoteClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
        base(binding, remoteAddress)
    {
    }

    public byte[][] ExecuteDbDataReader(System.Guid instance, byte[] comm, System.Data.CommandBehavior behavior)
    {
        return base.Channel.ExecuteDbDataReader(instance, comm, behavior);
    }

    public byte[] ExecuteNonQuery(out int ret, System.Guid instance, byte[] comm)
    {
        return base.Channel.ExecuteNonQuery(out ret, instance, comm);
    }

    public object ExecuteScalar(System.Guid instance, byte[] comm)
    {
        return base.Channel.ExecuteScalar(instance, comm);
    }

    public byte[] DeriveParameters(System.Guid instance, byte[] comm)
    {
        return base.Channel.DeriveParameters(instance, comm);
    }

    public void BeginTransaction(System.Guid instance, System.Data.IsolationLevel iso)
    {
        base.Channel.BeginTransaction(instance, iso);
    }

    public void CommitTransaction(System.Guid instance)
    {
        base.Channel.CommitTransaction(instance);
    }

    public void RollbackTransaction(System.Guid instance)
    {
        base.Channel.RollbackTransaction(instance);
    }

    public void CloseConnection(System.Guid instance)
    {
        base.Channel.CloseConnection(instance);
    }
}
#endif

namespace bv.model.BLToolkit.RemoteProvider.Client
{
    public class RemoteSqlClient : IDisposable
    {
#if MONO
        private RemoteClient m_server;
#else
        private IRemoteSql m_server = new RemoteSqlServer();
#endif
        private Guid m_instance = Guid.NewGuid();

        public RemoteSqlClient(string serverUrl)
        {
#if MONO
            var binding = new BasicHttpBinding()
            {
                Name = "basicHttpBinding"
            };
            m_server = new RemoteClient(binding, new EndpointAddress(serverUrl));
#endif
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
#if MONO
            return GetParameters(m_server.ExecuteNonQuery(out ret, m_instance, comm));
#else
            return GetParameters(m_server.ExecuteNonQuery(m_instance, comm, out ret));
#endif

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
#if MONO
            m_server.Close();
#endif
        }

        #endregion
    }
}
