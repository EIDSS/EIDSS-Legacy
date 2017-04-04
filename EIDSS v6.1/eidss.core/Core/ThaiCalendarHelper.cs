using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace eidss.model.Core
{
    public class ThaiCalendarHelper
    {
        private static readonly ThaiBuddhistCalendar m_ThaiCalendar = new ThaiBuddhistCalendar();
        public static int GregorianYearToThai(int year)
        {
            return m_ThaiCalendar.GetYear(new DateTime(year, 1, 1));
        }

        public static DateTime GregorianDateToThai(DateTime date)
        {
            return new DateTime(GregorianYearToThai(date.Year), date.Month, date.Day, 0, 0, 0, 0);
        }

        public static int ThaiYearToGregorian(int year)
        {
            return m_ThaiCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0).Year;
        }
        public static DateTime ThaiDateToGriogorian(DateTime date)
        {
            return m_ThaiCalendar.ToDateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }
    }
}
