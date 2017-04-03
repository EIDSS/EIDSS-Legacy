using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Handlers
{
    public class SetScalarHandler
    {
        public S Handler<T, F, S>(T t, F f, F prev, S s, Func<T, F, F, S> setter)
        {
            return setter(t, f, prev);
        }
    }
}
