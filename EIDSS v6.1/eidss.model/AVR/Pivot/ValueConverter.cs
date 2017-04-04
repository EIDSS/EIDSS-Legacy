using System;
using bv.common.Core;

namespace eidss.model.Avr.Pivot
{
    public static  class ValueConverter
    {
        public static int ConvertValueToInt(object oValue)
        {
            return (int)ConvertValueToLong(oValue);
        }

        public static long ConvertValueToLong(object oValue)
        {
            long value = 0;

            if (!Utils.IsEmpty(oValue))
            {
                double dValue;
                if (Double.TryParse(oValue.ToString(), out dValue))
                {
                    value = (long)Math.Round(dValue);
                }
            }
            return value;
        }

        public static double ConvertValueToDouble(object oValue)
        {
            if (!Utils.IsEmpty(oValue))
            {
                double dValue;
                if (Double.TryParse(oValue.ToString(), out dValue))
                {
                    return dValue;
                }
            }
            return 0;
        }

        public static double GetValueFrom(object value)
        {
            double result = 0;
            if (value != null)
            {
                Double.TryParse(value.ToString(), out result);
            }
            return result;
        }
    }
}