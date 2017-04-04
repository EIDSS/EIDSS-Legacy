using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.EditableObjects;
using bv.model.Model.Core;

namespace bv.model.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class NullableHelper
    {
        public static long ZeroValue(this Nullable<long> val)
        {
            if (val.HasValue) return val.Value;
            return 0;
        }

        public static T ValueOrDefault<T>(this Nullable<T> val)
            where T : struct
        {
            return val.HasValue ? val.Value : default(T);
        }
        public static string StrOrEmpty<T>(this Nullable<T> val)
            where T : struct
        {
            return val.HasValue ? val.Value.ToString() : "";
        }
        public static string StrOrEmpty<T>(this T val)
            where T : class
        {
            return val != null ? val.ToString() : "";
        }
    }
}

