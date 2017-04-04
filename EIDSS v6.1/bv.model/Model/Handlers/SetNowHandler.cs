using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model.Handlers
{
    public class SetNowHandler
    {
        public Nullable<DateTime> Handler<T>(T t, Nullable<Int64> f, Nullable<Int64> prev, Nullable<DateTime> s, Func<T> setter)
        {
            return (f == null || f == 0) ? new DateTime?() : DateTime.Now;
        }
        public Nullable<DateTime> Handler<T>(T t, Nullable<Int32> f, Nullable<Int32> prev, Nullable<DateTime> s, Func<T> setter)
        {
            return (f == null || f == 0) ? new DateTime?() : DateTime.Now;
        }
        public Nullable<DateTime> Handler<T>(T t, Nullable<Int16> f, Nullable<Int16> prev, Nullable<DateTime> s, Func<T> setter)
        {
            return (f == null || f == 0) ? new DateTime?() : DateTime.Now;
        }
    }
}
