using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;

namespace bv.model.Model.Core
{
    public interface IObjectPost
    {
        bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false);
    }
}
