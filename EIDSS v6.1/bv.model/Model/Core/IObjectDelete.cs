using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;

namespace bv.model.Model.Core
{
    public interface IObjectDelete
    {
        bool DeleteObject(DbManagerProxy manager
                            , object ident
            );
    }
}
