using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Core
{
    public interface IGridModelListLoad
    {
        void Load(long key, IEnumerable items, string errMes);
    }
}
