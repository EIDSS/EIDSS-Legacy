using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.openapi.bll.Converters
{
    internal interface IFieldConverter<C>
        where C : class
    {
        Tuple<string, OperationType> Match(string name);
    }
}