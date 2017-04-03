using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace eidss.openapi.bll.Converters
{
    internal interface IConverter<C, M>
        where C : class 
        where M : class, IObject
    {
        C ToContract(DbManagerProxy manager, M m);
        M ToModel(DbManagerProxy manager, M m, C c);
    }
}