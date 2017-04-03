using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.openapi.bll.Converters
{
    internal enum OperationType
    {
        Equal = 0,
        Like,
        LessThan,
        LessOrEqualThan,
        MoreThan,
        MoreOrEqualThan
    }
}