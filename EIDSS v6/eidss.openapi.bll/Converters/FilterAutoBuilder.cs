using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using bv.model.Model.Core;
using eidss.openapi.contract;

namespace eidss.openapi.bll.Converters
{
    internal class FilterAutoBuilder
    {
        public static FilterParams BuildFilter<C>(C obj, IFieldConverter<C> converter)
            where C : class
        {
            var ret = new FilterParams();
            foreach (PropertyDescriptor p in TypeDescriptor.GetProperties(obj))
            {
                var val = p.GetValue(obj);
                if (val == null || val.ToString().Length == 0) continue;
                if (val is long? && (!(val as long?).HasValue || (val as long?).Value == 0)) continue;
                if (val is long && (long)val == 0) continue;
                if (val is int && (int)val == 0) continue;
                if (val is short && (short)val == 0) continue;

                var field = converter.Match(p.Name);
                if (field == null) continue;

                AddExpression(ret, field.Item1, val, field.Item2);
            }
            return ret;
        }

        static string Oper(OperationType oper)
        {
            switch (oper)
            {
                case OperationType.Equal:
                    return "=";
                case OperationType.Like:
                    return "like";
                case OperationType.LessThan:
                    return "<";
                case OperationType.LessOrEqualThan:
                    return "<=";
                case OperationType.MoreThan:
                    return ">";
                case OperationType.MoreOrEqualThan:
                    return ">=";
                default:
                    return "";
            }
        }

        static void AddExpression(FilterParams pars, string fieldName, object val, OperationType oper)
        {
            if (val is string)
            {
                pars.Add(fieldName, Oper(oper), val);
            }
            else if (val is long)
            {
                pars.Add(fieldName, Oper(oper), (long)val);
            }
            else if (val is DateTime)
            {
                pars.Add(fieldName, Oper(oper), ((DateTime)val).Date);
            }
            else if (val is Reference)
            {
                long id = ((Reference)val).RecordID;
                if (id != 0)
                {
                    pars.Add(fieldName, Oper(oper), id);
                }
            }
            else if (val is GisReference)
            {
                long id = ((GisReference)val).RecordID;
                if (id != 0)
                {
                    pars.Add(fieldName, Oper(oper), id);
                }
            }
            else if (val is Diagnosis)
            {
                long id = ((Diagnosis)val).RecordID;
                if (id != 0)
                {
                    pars.Add(fieldName, Oper(oper), id);
                }
            }
        }
    }

}