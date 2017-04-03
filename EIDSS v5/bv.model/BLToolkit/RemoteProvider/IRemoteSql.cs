using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace bv.model.BLToolkit.RemoteProvider
{
    [ServiceContract]
    public interface IRemoteSql
    {
        [OperationContract]
        byte[][] ExecuteDbDataReader(Guid instance, byte[] comm, CommandBehavior behavior);
        [OperationContract]
        byte[] ExecuteNonQuery(Guid instance, byte[] comm, out int ret);
        [OperationContract]
        object ExecuteScalar(Guid instance, byte[] comm);
        [OperationContract]
        byte[] DeriveParameters(Guid instance, byte[] comm);
        [OperationContract]
        void BeginTransaction(Guid instance, IsolationLevel iso);
        [OperationContract]
        void CommitTransaction(Guid instance);
        [OperationContract]
        void RollbackTransaction(Guid instance);
        [OperationContract]
        void CloseConnection(Guid instance);
    }
}
