using System;
using System.Threading;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using BLToolkit.Data;

namespace bv.model.Model.Extenders
{
    public class GetNewIDExtender<T> : IGetScalarExtender<T, long>
        where T : IObject
    {
        #region IGetScalarExtender<T,R> Members

        public long GetScalar(DbManagerProxy manager, T t, params object[] pars)
        {
            if (pars != null && pars.Length == 1 && pars[0] is bool && (bool) pars[0])
            {
                return 0;
            }

            return _getNewId(manager, t);
        }

        public long GetScalar(T t, params object[] pars)
        {
            if (pars != null && pars.Length == 1 && pars[0] is bool && (bool) pars[0])
            {
                return 0;
            }

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return _getNewId(manager, t);
            }
        }

        #endregion

        private long _getNewId(DbManagerProxy manager, T obj)
        {
            Exception lastEx = null;
            int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
            for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
            {
                try
                {
                    return manager.SetSpCommand("dbo.spsysGetNewID", DBNull.Value).ExecuteScalar<long>(ScalarSourceType.OutputParameter);
                }
                catch (Exception e)
                {
                    lastEx = e;
                    if (!manager.IsTransactionStarted)
                    {
                        if (DbModelException.IsDeadlockException(e))
                        {
                            Thread.Sleep(BaseSettings.DeadlockDelay);
                            continue;
                        }
                    }

                    throw;
                }
            }

            throw lastEx;
        }
    }
}