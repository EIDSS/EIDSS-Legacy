using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bv.model.Model
{
    public static class ExprUtils
    {
        public static long? LongFromString(string str)
        {
            long ret = 0;
            if (long.TryParse(str, out ret)) return ret;
            return null;
        }

        public static string StringFromObject(object val)
        {
            if (val == null) return null;
            if (val is DBNull) return null;
            return Convert.ToString(val);
        }

        /*public static TRet Fold<TSource, TRet>(this IEnumerable<TSource> source, Func<TSource, TRet> func)
            where TRet : struct 
        {
            TRet ret = new TRet();
            foreach (TSource s in source)
                ret = func(s);
            return ret;
        }*/
    }
}
