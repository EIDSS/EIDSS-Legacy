using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using bv.model.Model.Core;

namespace Eidss.Web
{
    public class FilterAutoBuilder
    {
        public static FilterParams BuildFilter(object obj)
        {
            var ret = new FilterParams();
            foreach (PropertyDescriptor p in TypeDescriptor.GetProperties(obj))
            {
                object val = p.GetValue(obj);
                if (val == null || val.ToString().Length == 0) continue;
                if (val is long && (long)val == 0) continue;
                if (val is int && (int)val == 0) continue;
                if (val is short && (short)val == 0) continue;

                var attr = p.Attributes[typeof(FieldNameAttribute)] as FieldNameAttribute;
                if (attr == null) continue;

                AddExpression(ret, attr.FieldName, val);
            }
            return ret;
        }

        static void AddExpression(FilterParams pars, string fieldName, object val)
        {
            if (val is string)
            {
                pars.Add(fieldName, "=", val);
            }
            else if (val is DateTime)
            {
                pars.Add(fieldName, ">=", ((DateTime)val).Date);
                pars.Add(fieldName, "<", ((DateTime)val).Date.AddDays(1));
            }
            else if (val is BaseReferenceItem)
            {
                long? id = ((BaseReferenceItem)val).Id;
                if (id != null && id.Value != 0)
                {
                    pars.Add(fieldName, "=", id);
                }
            }
        }
    }

}