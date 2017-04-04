using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;

namespace bv.model.Model.Extenders
{
    public class AutoIncrementExtender<T> : IGetScalarExtender<T, long>
    {
        private static long m_Seed = -1;
        public long GetScalar(DbManagerProxy manager, T t, params object[] pars)
        {
            return m_Seed--;
        }

   }
}
