using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using bv.model.BLToolkit;

namespace bv.model.Model.Extenders
{
    public class GetSiteIDExtender<T> : IGetScalarExtender<T, long>
    {
        #region IGetScalarExtender<T,R> Members

        public long GetScalar(DbManagerProxy manager, T t, params object[] pars)
        {
            return manager.SetCommand("select dbo.fnSiteID()").ExecuteScalar<long>();
        }

        #endregion
    }
}
