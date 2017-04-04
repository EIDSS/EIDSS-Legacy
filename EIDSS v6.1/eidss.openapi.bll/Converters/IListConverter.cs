using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.openapi.contract;

namespace eidss.openapi.bll.Converters
{
    internal interface IListConverter<C, M>
        where C : class 
        where M : class, IObject
    {
        List<C> ToContract(DbManagerProxy manager, IList<M> m);
        EditableList<M> ToModel(DbManagerProxy manager, IObject parent, EditableList<M> m, List<C> c);
    }
}