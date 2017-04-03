using System;
using System.Globalization;
using bv.common.Enums;
using bv.model.Model.Core;
using System.Text.RegularExpressions;

namespace bv.model.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ParsingHelper
    {
        private static DateTime MinDateTime = new DateTime(1900, 1, 1);

        public static DateTime ParseDateTime(string val)
        {
            if (string.IsNullOrEmpty(val)) return default(DateTime);
            DateTime ret = MinDateTime;
            bool bSuccess;
            if (val.Length == 10) bSuccess = DateTime.TryParseExact(val, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out ret);
            else bSuccess = DateTime.TryParseExact(val, "dd-MM-yyyyTHH:mm:ss", null, System.Globalization.DateTimeStyles.None, out ret);
            if (!bSuccess) bSuccess = DateTime.TryParse(val, out ret);
            if (ret < MinDateTime) ret = MinDateTime;
            return ret;
        }
        public static DateTime? ParseDateTimeNullable(string val)
        {
            if (string.IsNullOrEmpty(val)) return null;
            DateTime ret = MinDateTime;
            bool bSuccess;
            if (val.Length == 10) bSuccess = DateTime.TryParseExact(val, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out ret);
            else bSuccess = DateTime.TryParseExact(val, "dd-MM-yyyyTHH:mm:ss", null, System.Globalization.DateTimeStyles.None, out ret);
            if (!bSuccess) bSuccess = DateTime.TryParse(val, out ret);
            if (!bSuccess) return null;
            if (ret < MinDateTime) ret = MinDateTime;
            return ret;
        }
        public static Double ParseDouble(string val)
        {
            if (string.IsNullOrEmpty(val)) return 0;
            var ni1 = new NumberFormatInfo { NumberDecimalSeparator = "." };
            var ni2 = new NumberFormatInfo { NumberDecimalSeparator = "," };
            Double result;
            if (Double.TryParse(val, NumberStyles.AllowDecimalPoint, ni1, out result)) return result;
            if (Double.TryParse(val, NumberStyles.AllowDecimalPoint, ni2, out result)) return result;
            return 0;
        }
        public static Double? ParseDoubleNullable(string val)
        {
            if (string.IsNullOrEmpty(val)) return null;
            var ni1 = new NumberFormatInfo { NumberDecimalSeparator = "." };
            var ni2 = new NumberFormatInfo { NumberDecimalSeparator = "," };
            Double result;
            if (Double.TryParse(val, NumberStyles.AllowDecimalPoint, ni1, out result)) return result;
            if (Double.TryParse(val, NumberStyles.AllowDecimalPoint, ni2, out result)) return result;
            return null;
        }
        public static Int16 ParseInt16(string val)
        {
            if (string.IsNullOrEmpty(val)) return 0;
            Int16 result;
            if (!Int16.TryParse(val, out result)) return 0;
            return result;
        }
        public static Int16? ParseInt16Nullable(string val)
        {
            if (string.IsNullOrEmpty(val)) return null;
            Int16 result;
            if (!Int16.TryParse(val, out result)) return null;
            return result;
        }
        public static Int32 ParseInt32(string val)
        {
            if (string.IsNullOrEmpty(val)) return 0;
            Int32 result;
            if (!Int32.TryParse(val, out result)) return 0;
            return result;
        }
        public static Int32? ParseInt32Nullable(string val)
        {
            if (string.IsNullOrEmpty(val)) return null;
            Int32 result;
            if (!Int32.TryParse(val, out result)) return null;
            return result;
        }
        public static Int64 ParseInt64(string val)
        {
            if (string.IsNullOrEmpty(val)) return 0;
            Int64 result;
            if (!Int64.TryParse(val, out result)) return 0;
            return result;
        }
        public static Int64? ParseInt64Nullable(string val)
        {
            if (string.IsNullOrEmpty(val)) return null;
            Int64 result;
            if (!Int64.TryParse(val, out result)) return null;
            return result;
        }
        public static bool ParseBoolean(string val)
        {
            return string.IsNullOrEmpty(val) ? default(Boolean) : Boolean.Parse(val);
        }
        public static bool? ParseBooleanNullable(string val)
        {
            return string.IsNullOrEmpty(val) ? null : new Boolean?(Boolean.Parse(val));
        }
        public static string ParseString(string val)
        {
            return string.IsNullOrEmpty(val) ? "" : val;
        }


        private static Regex rexLike = new Regex(@"(?<prefix>^[\%\*])?((?<exp>.*)(?<suffix>[\%\*]$)|(?<exp>.*))");
        public static object CorrectLikeValue(string operation, object value)
        {
            if (operation == null) return value;
            if (operation.ToLowerInvariant() != "like") return value;
            if (!(value is string)) return value;

            string val = value as string;
            string likePrefix = "";
            string likeSuffix = "";
            string text = "";
            Match m  = rexLike.Match(val);

            if( m.Success)
            {
                likePrefix = m.Result("${prefix}");
                likeSuffix = m.Result("${suffix}");
                text = m.Result("${exp}");
            }
            else
            {
                text = val;
            }

            if (likePrefix != "")
            {
                likePrefix = "%";
            }
            if (likeSuffix != "")
            {
                likeSuffix = "%";
            }
            if (likeSuffix == "" && likePrefix == "")
            {
                likeSuffix = "%";
            }
            //text = FixLikeTextForDates(text, dataType)
            string fullText = String.Format("{0}{1}{2}", likePrefix, text, likeSuffix);
            //Return bv.common.db.SqlParser.GetFormattedValue(GetType(String), fullText)
            return fullText;
        }
        
    }
}

