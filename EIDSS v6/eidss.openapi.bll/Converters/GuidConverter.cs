using System.Linq.Expressions;
using eidss.openapi.bll.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.bll.Converters
{
    /*
    internal class GuidConverter
    {
        public static string ToContract(Guid? m)
        {
            return !m.HasValue ? null : m.Value.ToString();
        }

        public static Guid? ToModel(Guid? m, Expression<Func<string>> expr)
        {
            var name = 
                expr.Body is MemberExpression 
                ? ((MemberExpression) expr.Body).Member.Name 
                : "";
            var c = expr.Compile()();
            if (!string.IsNullOrEmpty(c))
                try { m = Guid.Parse(c); }
                catch (FormatException) { throw new WrongFormatException(name); }
            return m;
        }
    }
    */
}