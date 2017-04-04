using System;
using DevExpress.XtraPivotGrid;
using eidss.model.Core;

namespace eidss.avr.db.Common
{
    public static class DateTimeExtender
    {
        public static bool IsDate(this PivotGroupInterval groupInterval)
        {
            bool isDate = (groupInterval.ToString().Contains("Date"));
            return isDate;
        }

        public static bool IsDate(this Type dataType)
        {
            bool isDate = (dataType == typeof(DateTime));
            return isDate;
        }

        public static object ToObject(this DateTime date, PivotGroupInterval groupInterval)
        {
            object result;
            switch (groupInterval)
            {
                case PivotGroupInterval.DateDayOfYear:
                case PivotGroupInterval.DateQuarter:
                case PivotGroupInterval.DateWeekOfYear:
                case PivotGroupInterval.DateWeekOfMonth:
                case PivotGroupInterval.DateYear:
                case PivotGroupInterval.DateDay:
                    int formattedResult;
                    result = date.TryToInt(groupInterval, out formattedResult)
                        ? formattedResult
                        : (object) date.ToString("d");
                    break;
                default:
                    result = date.ToString(groupInterval);
                    break;
            }
            return result;
        }

        public static string ToString(this DateTime date, PivotGroupInterval groupInterval)
        {
            string result;
            switch (groupInterval)
            {
                case PivotGroupInterval.DateDayOfWeek:
                    result = date.ToString("dddd");
                    break;
                case PivotGroupInterval.DateMonth:
                    result = date.ToString("MMMM");
                    break;
                default:
                    result = date.ToString("d");
                    break;
            }
            return result;
        }

        public static bool TryToInt(this DateTime date, PivotGroupInterval groupInterval, out int result)
        {
            switch (groupInterval)
            {
                case PivotGroupInterval.DateDay:
                    result = date.Day;
                    break;
                case PivotGroupInterval.DateDayOfYear:
                    result = date.DayOfYear;
                    break;
                case PivotGroupInterval.DateQuarter:
                    result = date.ToQuarter();
                    break;
                case PivotGroupInterval.DateWeekOfYear:
                    result = DatePeriodHelper.GetWeekOfYear(date);
                    break;
                case PivotGroupInterval.DateWeekOfMonth:
                    result = DatePeriodHelper.GetWeekOfMonth(date);
                    break;
                case PivotGroupInterval.DateYear:
                    result = date.Year;
                    break;
                default:
                    result = -1;
                    return false;
            }
            return true;
        }

        public static int ToQuarter(this DateTime date)
        {
            int result;
            if (date.Month <= 3)
            {
                result = 1;
            }
            else if (date.Month >= 10)
            {
                result = 4;
            }
            else if ((date.Month >= 4) && (date.Month <= 6))
            {
                result = 2;
            }
            else
            {
                result = 3;
            }
            return result;
        }

        public static DateTime TruncateToFirstDateInInterval(this DateTime date, PivotGroupInterval groupInterval)
        {
            DateTime result;
            switch (groupInterval)
            {
                case PivotGroupInterval.DateMonth:
                    result = new DateTime(date.Year, date.Month, 01);
                    break;
                case PivotGroupInterval.DateQuarter:
                    result = new DateTime(date.Year, 3 * date.ToQuarter() - 2, 01);
                    break;
                case PivotGroupInterval.DateYear:
                    result = new DateTime(date.Year, 01, 01);
                    break;
                case PivotGroupInterval.DateWeekOfMonth:
                case PivotGroupInterval.DateWeekOfYear:
                    int days = (int) EidssSiteContext.Instance.FirstDayOfWeek - (int) date.DayOfWeek;
                    if (days > 0)
                    {
                        days -= 7;
                    }
                    result = date.Date.AddDays(days);
                    break;

                default:
                    result = date.Date;
                    break;
            }
            return result;
        }
    }
}