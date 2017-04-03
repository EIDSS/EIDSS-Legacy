using System;
using System.Globalization;
using System.Threading;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Components;
using bv.common.Core;

namespace EIDSS.RAM.Presenters.RamPivotGrid
{
    public static class DateTimeExtender
    {
       

        public static bool IsDate(this PivotGroupInterval groupInterval)
        {
            bool isDate = (groupInterval.ToString().Contains("Date"));
            return isDate;
        }

        public static object ToString(this DateTime date, PivotGroupInterval groupInterval)
        {
            object result;
            switch (groupInterval)
            {
                case PivotGroupInterval.DateDay:
                    result = date.ToString("dd");
                    break;
                case PivotGroupInterval.DateDayOfWeek:
                    result = date.ToString("dddd");
                    break;
                case PivotGroupInterval.DateDayOfYear:
                    result = date.DayOfYear;
                    break;
                case PivotGroupInterval.DateMonth:
                    result = date.ToString("MMMM");
                    break;
                case PivotGroupInterval.DateQuarter:
                    result = date.ToQuarter();
                    break;
                case PivotGroupInterval.DateWeekOfYear:
                    Calendar calendarYear = Thread.CurrentThread.CurrentCulture.Calendar;
                    result = calendarYear.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    break;
                case PivotGroupInterval.DateWeekOfMonth:
                    result = date.ToWeekOfMonth();
                    break;
                case PivotGroupInterval.DateYear:
                    result = date.Year;
                    break;
                default:
                    result = date.ToString("d");
                    break;
            }
            return result;
        }

        public static int ToWeekOfMonth(this DateTime date)
        {
            var dateMonth = new DateTime(date.Year, date.Month, 1);
            int delta = 0;
            switch (dateMonth.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    delta = 1;
                    break;
                case DayOfWeek.Wednesday:
                    delta = 2;
                    break;
                case DayOfWeek.Thursday:
                    delta = 3;
                    break;
                case DayOfWeek.Friday:
                    delta = 4;
                    break;
                case DayOfWeek.Saturday:
                    delta = 5;
                    break;
                case DayOfWeek.Sunday:
                    delta = 6;
                    break;
            }
            Calendar calendarMonth = Thread.CurrentThread.CurrentCulture.Calendar;
            int result = 1 + ((calendarMonth.GetDayOfMonth(date) + delta - 1) / 7);
            return result;
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
    }
}