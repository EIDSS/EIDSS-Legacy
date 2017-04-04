using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using bv.model.BLToolkit;

namespace bv.model.Model.Extenders
{
    public class GetNextNumberExtender<T> : IGetScalarExtender<T, string>
    {
        #region IGetScalarExtender<T,R> Members

        public string GetScalar(DbManagerProxy manager, T t, params object[] pars)
        {
            return manager.SetSpCommand("dbo.spGetNextNumber", pars[0], DBNull.Value, DBNull.Value).ExecuteScalar<string>(ScalarSourceType.OutputParameter);
        }

        #endregion
    }
}
