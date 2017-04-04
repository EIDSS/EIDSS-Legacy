using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using bv.model.BLToolkit;

namespace bv.model.Model.Extenders
{
    public interface IGetScalarExtender<T, R>
    {
        R GetScalar(DbManagerProxy manager, T t, params object[] pars);
    }
}
