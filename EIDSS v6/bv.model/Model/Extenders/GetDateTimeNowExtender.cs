using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using bv.model.BLToolkit;

namespace bv.model.Model.Extenders
{
    public class GetDateTimeNowExtender<T> : IGetScalarExtender<T, DateTime>
    {
        #region IGetScalarExtender<T,R> Members

        public DateTime GetScalar(DbManagerProxy manager, T t, params object[] pars)
        {
            return DateTime.Now;
        }

        #endregion
    }
}
