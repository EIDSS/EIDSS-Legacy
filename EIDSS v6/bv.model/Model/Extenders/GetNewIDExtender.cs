using System;
using BLToolkit.Data;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace bv.model.Model.Extenders
{
    public class GetNewIDExtender<T> : IGetScalarExtender<T, long>
    {
        #region IGetScalarExtender<T,R> Members

        public long GetScalar(DbManagerProxy manager, T t, params object[] pars)
        {
            if (pars != null && pars.Length == 1 && pars[0] is bool && (bool) pars[0])
                return 0;

            return manager.SetSpCommand("dbo.spsysGetNewID", DBNull.Value).ExecuteScalar<long>(ScalarSourceType.OutputParameter);
        }

        public long GetScalar(T t, params object[] pars)
        {
            if (pars != null && pars.Length == 1 && pars[0] is bool && (bool)pars[0])
                return 0;

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                return manager.SetSpCommand("dbo.spsysGetNewID", DBNull.Value).ExecuteScalar<long>(ScalarSourceType.OutputParameter);
        }

        #endregion
    }
}