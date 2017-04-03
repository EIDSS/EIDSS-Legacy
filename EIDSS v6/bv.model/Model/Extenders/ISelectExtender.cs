using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace bv.model.Model.Extenders
{
    public interface ISelectExtender<T, R>
    {
        R Select(T t, Func<R, bool> predicate);
    }
}
