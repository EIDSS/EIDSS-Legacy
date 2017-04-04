using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using bv.model.Model.Core;

namespace bv.model.Model.Validators
{

//    public class DuplicateListValidatorItem<T>

    public class DuplicateListValidator : BaseFieldValidator
    {
        public DuplicateListValidator(string fld)
            : base(fld)
        {
        }

        protected static string GetDisplayName(Type t, string p)
        {
            if (t != null && !string.IsNullOrEmpty(p))
            {
                var pi = t.GetProperty(p);
                if (pi != null)
                {
                    var attrs = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    if (attrs.Length > 0)
                    {
                        var atr = attrs[0] as DisplayNameAttribute;
                        if (atr != null)
                        {
                            return atr.DisplayName;
                        }
                    }
                }
            }
            var ret = FieldCaptions == null ? null : FieldCaptions.GetString(p);
            return string.IsNullOrEmpty(ret) ? p : ret;
        }

        /*
                        new DuplicateListValidator("")
                        .Validate(obj, 
                            o => o.VectorType2PensideTest.Where(c => !c.IsMarkedToDelete)
                                .Aggregate(new List<Tuple<VectorType2PensideTest, int>>(), (list, test) => 
                                { 
                                    var item = list.Find(c => true
                                        && c.Item1.idfsPensideTestName == test.idfsPensideTestName
                                        && c.Item1.idfsVectorType == test.idfsVectorType
                                        );
                                    if (item == null)
                                        list.Add(new Tuple<VectorType2PensideTest, int>(test, 1));
                                    else
                                    {
                                        list.Remove(item);
                                        list.Add(new Tuple<VectorType2PensideTest, int>(test, item.Item2 + 1));
                                    }
                                    return list;
                                })
                                .Where(c => c.Item2 > 1).Select(c => c.Item1).FirstOrDefault(),
                            (o, i) => new Tuple<string, string>("idfsPensideTestName", i.PensideTestLookup.First(c => c.Key.Equals(i.idfsPensideTestName)).ToStringProp)
                        );
        */

        protected string FormatValue(object val)
        {
            if (val == null)
                return "(null)";
            if (val is DateTime)
                return ((DateTime) val).ToShortDateString();
            return val.ToString();
        }

        public void Validate<T, I>(T t, Func<T, I> predicate, Func<T, I, Tuple<string, object>> values)
            where I : class
            where T : IObject
        {
            var i = predicate(t);
            if (i != null)
            {
                var v = values(t, i);
                object[] pairs = new []
                {
                    GetDisplayName(typeof(I), v.Item1),
                    FormatValue(v.Item2)
                };

                throw new ValidationModelException("ErrUniqueness1", m_FldName, m_PrpName, pairs, GetType(), m_ValidationType, t);
            }
        }

        public void Validate<T, I>(T t, Func<T, I> predicate, Func<T, I, Tuple<string, object, string, object>> values)
            where I : class
            where T : IObject
        {
            var i = predicate(t);
            if (i != null)
            {
                var v = values(t, i);
                object[] pairs = new[]
                {
                    GetDisplayName(typeof(I), v.Item1),
                    FormatValue(v.Item2),
                    GetDisplayName(typeof(I), v.Item3),
                    FormatValue(v.Item4)
                };

                throw new ValidationModelException("ErrUniqueness2", m_FldName, m_PrpName, pairs, GetType(), m_ValidationType, t);
            }
        }

        public void Validate<T, I>(T t, Func<T, I> predicate, Func<T, I, Tuple<string, object, string, object, string, object>> values)
            where I : class
            where T : IObject
        {
            var i = predicate(t);
            if (i != null)
            {
                var v = values(t, i);
                object[] pairs = new[]
                {
                    GetDisplayName(typeof(I), v.Item1),
                    FormatValue(v.Item2),
                    GetDisplayName(typeof(I), v.Item3),
                    FormatValue(v.Item4),
                    GetDisplayName(typeof(I), v.Item5),
                    FormatValue(v.Item6)
                };

                throw new ValidationModelException("ErrUniqueness3", m_FldName, m_PrpName, pairs, GetType(), m_ValidationType, t);
            }
        }
    }


}
