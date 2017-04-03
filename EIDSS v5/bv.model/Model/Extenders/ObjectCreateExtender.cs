using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace bv.model.Model.Extenders
{
    public class ObjectCreateExtender<T, R> : ICreateExtender<T, R>
        where T : DataAccessor
        where R : class
    {
        #region ICreateExtender<T,R> Members

        public R Create(DbManagerProxy manager, IObject Parent, int? HACode, params object[] pars)
        {
            T acc = DataAccessor.CreateInstance<T>();
            IObjectCreator creator = acc as IObjectCreator;
            return creator.CreateNew(manager, Parent, HACode) as R;
        }

        #endregion
    }
}
