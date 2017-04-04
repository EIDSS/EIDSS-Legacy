using System;
using System.Collections.Generic;
using System.Globalization;

namespace eidss.model.Core
{
    public struct WeekPeriod
    {
        public int Year { get; set; }
        public int WeekNumber { get; set; }
        public DateTime WeekStartDate { get; set; }
    }

    public class DatePeriodHelper
    {
        public static int GetWeekOfYear(DateTime date)
        {
            if (EidssSiteContext.Instance.WeekRule == CalendarWeekRule.FirstFourDayWeek)
            {
                DateTime cmp = GetFirstWeekOfYear(date.Year + 1);
                if (date < cmp)
                {
                    cmp = GetFirstWeekOfYear(date.Year);
                }
                if (date < cmp)
                {
                    cmp = GetFirstWeekOfYear(date.Year - 1);
                }

                return 1 + date.Subtract(cmp).Days / 7;
            }

            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
            return cultureInfo.Calendar.GetWeekOfYear(date, EidssSiteContext.Instance.WeekRule, EidssSiteContext.Instance.FirstDayOfWeek);
        }

        public static int GetWeekOfMonth(DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            if (EidssSiteContext.Instance.WeekRule == CalendarWeekRule.FirstFourDayWeek)
            {
                // move to the 4-th day in current week
                var cmp = (int) date.DayOfWeek;
                if (cmp < (int) EidssSiteContext.Instance.FirstDayOfWeek)
                {
                    cmp += 7;
                }
                date = date.AddDays(3 + (int) EidssSiteContext.Instance.FirstDayOfWeek - cmp);

                return 1 + date.Subtract(firstDayOfMonth).Days / 7;
            }
            if (EidssSiteContext.Instance.WeekRule == CalendarWeekRule.FirstDay)
            {
                return 1 + date.Subtract(firstDayOfMonth).Days / 7;
            }
            if (firstDayOfMonth.DayOfWeek == EidssSiteContext.Instance.FirstDayOfWeek)
            {
                return 1 + date.Subtract(firstDayOfMonth).Days / 7;
            }
            return 1 +
                   date.Subtract(
                       firstDayOfMonth.AddDays(7 - (int) firstDayOfMonth.DayOfWeek + (int) EidssSiteContext.Instance.FirstDayOfWeek))
                       .Days / 7;
        }

        public static DateTime GetFirstWeekOfYear(int year)
        {
            var firstDay = new DateTime(year, 1, 1);
            return GetStartOfWeek(firstDay);
        }

        public static DateTime GetStartOfWeek(DateTime date)
        {
            
            if (EidssSiteContext.Instance.WeekRule == CalendarWeekRule.FirstFourDayWeek)
            {
                // move to the 4-th day in current week
                var cmp = (int) date.DayOfWeek;
                if (cmp <= (int) EidssSiteContext.Instance.FirstDayOfWeek)
                {
                    cmp += 7;
                }
                DateTime fourthDate = date.AddDays(3 + (int) EidssSiteContext.Instance.FirstDayOfWeek - cmp);
                if (fourthDate < date)
                {
                    return fourthDate.AddDays(4);
                }
                return fourthDate.AddDays(-3);
            }
            if (EidssSiteContext.Instance.WeekRule == CalendarWeekRule.FirstDay)
            {
                return date;
            }
            var dayOfWeek = (int) date.DayOfWeek;
            if (dayOfWeek <= (int) EidssSiteContext.Instance.FirstDayOfWeek)
            {
                dayOfWeek += 7;
            }
            return date.AddDays((int) EidssSiteContext.Instance.FirstDayOfWeek - dayOfWeek);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="cutFutureDates">Отсекать ли те недели, которые ещё не наступили</param>
        /// <returns></returns>
        public static IList<WeekPeriod> GetWeeksList(int year, bool cutFutureDates = false)
        {
            var lastDay = (cutFutureDates && (DateTime.Now.Year == year)) 
                ? DateTime.Now
                : GetFirstWeekOfYear(year + 1);

            var ret = new List<WeekPeriod>();
            var week = 1;
            for (var weekFirstDay = GetFirstWeekOfYear(year); weekFirstDay < lastDay; weekFirstDay = weekFirstDay.AddDays(7))
            {
                var wp = new WeekPeriod
                {
                    Year = year, 
                    WeekNumber = week++, 
                    WeekStartDate = weekFirstDay
                };
                //wp.WeekFinishDate = weekFirstDay.AddDays(6);
                //wp.Name = weekFirstDay.ToShortDateString() + " - " + weekFirstDay.AddDays(6).ToShortDateString();
                ret.Add(wp);
            }
            return ret;
        }
    }
}