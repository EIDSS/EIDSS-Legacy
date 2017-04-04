using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using bv.model.BLToolkit;

namespace bv.model.Model.Core
{
    public interface IObjectCreator
    {
        IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode);
        IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode);
        IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars);
    }

    public interface IObjectCreator<O>
        where O : IObject
    {
        O CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode);
        O CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode);
    }
}
