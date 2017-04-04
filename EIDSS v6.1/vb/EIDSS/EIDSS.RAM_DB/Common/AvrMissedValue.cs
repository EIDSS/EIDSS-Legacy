using System.Collections.Generic;
using bv.common.Core;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.Common
{
    public class AvrMissedValue
    {
        private static readonly IEqualityComparer<AvrMissedValue> m_FieldValueComparerInstance = new FieldValueEqualityComparer();

        public AvrMissedValue(object fieldValue, bool isHistorical = false)
        {
            FieldValue = fieldValue;
            IsHistorical = isHistorical;
            LinkedFieldValues = new Dictionary<string, object>();
            FilteredRows = new List<AvrDataRowBase>();
            FilteredIndexes = new List<int>();
        }

        public object FieldValue { get; private set; }
        public bool IsHistorical { get; private set; }
        public IDictionary<string, object> LinkedFieldValues { get; set; }
        public IList<AvrDataRowBase> FilteredRows { get; private set; }
        public IList<int> FilteredIndexes { get; private set; }

        public static IEqualityComparer<AvrMissedValue> FieldValueComparer
        {
            get { return m_FieldValueComparerInstance; }
        }

        public override string ToString()
        {
            return Utils.Str(FieldValue);
        }

        private sealed class FieldValueEqualityComparer : IEqualityComparer<AvrMissedValue>
        {
            public bool Equals(AvrMissedValue x, AvrMissedValue y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }
                if (ReferenceEquals(x, null))
                {
                    return false;
                }
                if (ReferenceEquals(y, null))
                {
                    return false;
                }
                if (x.GetType() != y.GetType())
                {
                    return false;
                }
                return Equals(x.FieldValue, y.FieldValue);
            }

            public int GetHashCode(AvrMissedValue obj)
            {
                return (obj.FieldValue != null ? obj.FieldValue.GetHashCode() : 0);
            }
        }
    }
}