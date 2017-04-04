using System;
using System.Collections;

namespace bv.model.Model.Core
{
    public class DateTimeWrap : IComparable<DateTimeWrap>
    {
        [CLSCompliant(false)]
        public string _tostring;
        [CLSCompliant(false)]
        public DateTime? _date;
        protected DateTimeWrap(DateTime? date, string format)
        {
            _date = date;
            _tostring = _date.HasValue ? _date.Value.ToString(format) : "";
        }
        protected DateTimeWrap(DateTime date, string format)
        {
            _date = date;
            _tostring = _date.Value.ToString(format);
        }
        public DateTimeWrap(string tostring)
        {
            _date = null;
            _tostring = tostring;
        }
        public DateTimeWrap(DateTime date)
        {
            _date = date;
            _tostring = _date.Value.ToString("d");
        }
        public DateTimeWrap(DateTime? date)
        {
            _date = date;
            _tostring = _date.HasValue ? _date.Value.ToString("d") : "";
        }

        public static implicit operator DateTimeWrap(DateTime o)
        {
            return new DateTimeWrap(o, "d");
        }
        public static implicit operator DateTimeWrap(DateTime? o)
        {
            return new DateTimeWrap(o, "d");
        }
        public static implicit operator DateTimeWrap(string o)
        {
            return new DateTimeWrap(o);
        }

        int IComparable<DateTimeWrap>.CompareTo(DateTimeWrap other)
        {
            return (_date.HasValue ? _date.Value : DateTime.MinValue).CompareTo(other._date.HasValue ? other._date.Value : DateTime.MinValue);
        }
    }

    public class DateTimeWrapG : DateTimeWrap
    {
        protected DateTimeWrapG(DateTime? date, string format)
            : base(date, format)
        {
        }
        protected DateTimeWrapG(DateTime date, string format)
            : base(date, format)
        {
        }

        public static implicit operator DateTimeWrapG(DateTime o)
        {
            return new DateTimeWrapG(o, "G");
        }
        public static implicit operator DateTimeWrapG(DateTime? o)
        {
            return new DateTimeWrapG(o, "G");
        }
    }
}