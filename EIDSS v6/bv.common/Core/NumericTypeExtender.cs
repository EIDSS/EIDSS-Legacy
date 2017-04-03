using System;

namespace bv.common.Core
{
    public static class NumericTypeExtender
    {
        public static bool IsNumeric(this Type dataType)
        {
            if (dataType == null)
            {
                throw new ArgumentNullException("dataType");
            }

            return (dataType == typeof (Int16) ||
                    dataType == typeof (Int32) ||
                    dataType == typeof (Int64) ||
                    dataType == typeof (UInt16) ||
                    dataType == typeof (UInt32) ||
                    dataType == typeof (UInt64) ||
                    dataType == typeof (SByte) ||
                    dataType == typeof (Single) ||
                    dataType == typeof (Double) ||
                    dataType == typeof (Decimal)
                );
        }
    }
}