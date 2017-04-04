using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.model.Model.Core;

namespace bv.model.Model.Validators
{

    public class ChainsValidator
        : BaseFieldValidator
    {
        public ChainsValidator(string fld)
            : base(fld)
        {
        }
    }

    public abstract class ChainsValidator<T, V>
        : ChainsValidator
        where T : IObject
    {
        public readonly T m_O;
        public readonly Func<T, bool> m_Predicate;
        public readonly V m_F;
        public readonly Type m_T;
        public readonly List<ChainsValidator<T, V>> m_Childs;
        public readonly bool m_Strict;

        public ChainsValidator(T o, string fld, Func<T, bool> predicate, V f, Type t, bool strict, Action<List<ChainsValidator<T, V>>> childs)
            : base(fld)
        {
            m_O = o;
            m_Predicate = predicate;
            m_F = f;
            m_T = t;
            m_Strict = strict;
            m_Childs = new List<ChainsValidator<T, V>>();
            childs(m_Childs);
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
            var ret = FieldCaptions == null ? null : FieldCaptions.GetString(p) ;
            return string.IsNullOrEmpty(ret) ? p : ret;
        }


        protected abstract bool HasValue(V v);
        protected abstract  int Compare(V v1, V v2);
        protected abstract void Throw(V f1, V f2, Type t1, Type t2, string fld1, string fld2, bool strict);

        private static void Process(ChainsValidator<T, V> _this, List<ChainsValidator<T, V>> childs)
        {
            childs.ForEach(c =>
            {
                if (_this.HasValue(_this.m_F))
                {
                    if (c.HasValue(c.m_F))
                    {
                        if (_this.m_Predicate(_this.m_O) && c.m_Predicate(c.m_O))
                        {
                            var comp = _this.Compare(_this.m_F, c.m_F);
                            if (comp > 0 || (_this.m_Strict && comp == 0))
                            {
                                _this.Throw(_this.m_F, c.m_F, _this.m_T, c.m_T, _this.m_FldName, c.m_FldName, _this.m_Strict);
                            }
                        }
                    }
                    else
                    {
                        Process(_this, c.m_Childs);
                    }
                }

                Process(c, c.m_Childs);
            });
        }

        public void Process()
        {
            Process(this, m_Childs);
        }

    }


    public class ChainsValidatorDateTime<T> : ChainsValidator<T, DateTime?>
        where T : IObject
    {
        protected override bool HasValue(DateTime? v)
        {
            return v.HasValue;
        }
        protected override int Compare(DateTime? v1, DateTime? v2)
        {
            return v1.Value.Date.CompareTo(v2.Value.Date);
        }
        protected override void Throw(DateTime? f1, DateTime? f2, Type t1, Type t2, string fld1, string fld2, bool strict)
        {
            throw new ValidationModelException(strict ? "ErrStrictChainDate" : "ErrUnstrictChainDate",
                fld1, fld2, GetPars(f1.Value, f2.Value, t1, t2, fld1, fld2), typeof(ChainsValidator), ValidationEventType.Error, m_O);
        }
        protected static object[] GetPars(DateTime f1, DateTime f2, Type t1, Type t2, string fld1, string fld2)
        {
            return new[]
            {
                (object)GetDisplayName(t1, fld1),
                f1.ToShortDateString(),
                GetDisplayName(t2, fld2),
                f2.ToShortDateString()
            };
        }

        public ChainsValidatorDateTime(T o, string fld, Func<T, bool> predicate, DateTime? f, Type t, bool strict, Action<List<ChainsValidator<T, DateTime?>>> childs)
            : base(o, fld, predicate, f, t, strict, childs)
        {
        }
    }

    public class ChainsValidatorNullableInt<T> : ChainsValidator<T, int?>
        where T : IObject
    {
        protected override bool HasValue(int? v)
        {
            return v.HasValue;
        }
        protected override int Compare(int? v1, int? v2)
        {
            return v1.Value.CompareTo(v2.Value);
        }
        protected override void Throw(int? f1, int? f2, Type t1, Type t2, string fld1, string fld2, bool strict)
        {
            throw new ValidationModelException(strict ? "ErrStrictChainNumeric" : "ErrUnstrictChainNumeric",
                fld1, fld2, GetPars(f1.Value, f2.Value, t1, t2, fld1, fld2), typeof(ChainsValidator), ValidationEventType.Error, m_O);
        }
        protected static object[] GetPars(int f1, int f2, Type t1, Type t2, string fld1, string fld2)
        {
            return new[]
            {
                (object)GetDisplayName(t1, fld1),
                f1.ToString(),
                GetDisplayName(t2, fld2),
                f2.ToString()
            };
        }

        public ChainsValidatorNullableInt(T o, string fld, Func<T, bool> predicate, int? f, Type t, bool strict, Action<List<ChainsValidator<T, int?>>> childs)
            : base(o, fld, predicate, f, t, strict, childs)
        {
        }
    }

    public class ChainsValidatorInt<T> : ChainsValidator<T, int>
        where T : IObject
    {
        protected override bool HasValue(int v)
        {
            return true;
        }
        protected override int Compare(int v1, int v2)
        {
            return v1.CompareTo(v2);
        }
        protected override void Throw(int f1, int f2, Type t1, Type t2, string fld1, string fld2, bool strict)
        {
            throw new ValidationModelException(strict ? "ErrStrictChainNumeric" : "ErrUnstrictChainNumeric",
                fld1, fld2, GetPars(f1, f2, t1, t2, fld1, fld2), typeof(ChainsValidator), ValidationEventType.Error, m_O);
        }
        protected static object[] GetPars(int f1, int f2, Type t1, Type t2, string fld1, string fld2)
        {
            return new[]
            {
                (object)GetDisplayName(t1, fld1),
                f1.ToString(),
                GetDisplayName(t2, fld2),
                f2.ToString()
            };
        }

        public ChainsValidatorInt(T o, string fld, Func<T, bool> predicate, int f, Type t, bool strict, Action<List<ChainsValidator<T, int>>> childs)
            : base(o, fld, predicate, f, t, strict, childs)
        {
        }
    }


    public class ChainsValidatorNullableLong<T> : ChainsValidator<T, long?>
        where T : IObject
    {
        protected override bool HasValue(long? v)
        {
            return v.HasValue;
        }
        protected override int Compare(long? v1, long? v2)
        {
            return v1.Value.CompareTo(v2.Value);
        }
        protected override void Throw(long? f1, long? f2, Type t1, Type t2, string fld1, string fld2, bool strict)
        {
            throw new ValidationModelException(strict ? "ErrStrictChainNumeric" : "ErrUnstrictChainNumeric",
                fld1, fld2, GetPars(f1.Value, f2.Value, t1, t2, fld1, fld2), typeof(ChainsValidator), ValidationEventType.Error, m_O);
        }
        protected static object[] GetPars(long f1, long f2, Type t1, Type t2, string fld1, string fld2)
        {
            return new[]
            {
                (object)GetDisplayName(t1, fld1),
                f1.ToString(),
                GetDisplayName(t2, fld2),
                f2.ToString()
            };
        }

        public ChainsValidatorNullableLong(T o, string fld, Func<T, bool> predicate, int? f, Type t, bool strict, Action<List<ChainsValidator<T, long?>>> childs)
            : base(o, fld, predicate, f, t, strict, childs)
        {
        }
    }

    public class ChainsValidatorLong<T> : ChainsValidator<T, long>
        where T : IObject
    {
        protected override bool HasValue(long v)
        {
            return true;
        }
        protected override int Compare(long v1, long v2)
        {
            return v1.CompareTo(v2);
        }
        protected override void Throw(long f1, long f2, Type t1, Type t2, string fld1, string fld2, bool strict)
        {
            throw new ValidationModelException(strict ? "ErrStrictChainNumeric" : "ErrUnstrictChainNumeric",
                fld1, fld2, GetPars(f1, f2, t1, t2, fld1, fld2), typeof(ChainsValidator), ValidationEventType.Error, m_O);
        }
        protected static object[] GetPars(long f1, long f2, Type t1, Type t2, string fld1, string fld2)
        {
            return new[]
            {
                (object)GetDisplayName(t1, fld1),
                f1.ToString(),
                GetDisplayName(t2, fld2),
                f2.ToString()
            };
        }

        public ChainsValidatorLong(T o, string fld, Func<T, bool> predicate, int f, Type t, bool strict, Action<List<ChainsValidator<T, long>>> childs)
            : base(o, fld, predicate, f, t, strict, childs)
        {
        }
    }


}
