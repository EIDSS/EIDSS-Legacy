using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Extenders
{
    public class SelectLookupExtender<R> : ISelectExtender<List<R>, R>
    {
        #region IObjectAssignExtender<T,R> Members

        public R Select(List<R> t, Func<R, bool> predicate)
        {
            return t
                .Where(predicate)
                .Single();
        }

        #endregion
    }
}
