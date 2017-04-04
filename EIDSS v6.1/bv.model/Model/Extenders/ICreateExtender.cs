using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace bv.model.Model.Extenders
{
    public interface ICreateExtender<T, R>
    {
        R Create(DbManagerProxy manager, IObject Parent, int? HACode, params object[] pars);
    }
}
