using System;
using bv.common.Enums;
using bv.model.Model.Core;
using System.Text.RegularExpressions;
using bv.common.Core;

namespace bv.model.Helpers
{

    public enum DateInterval
    {
        Year = 0,
        Month,
        Day,
        Hour,
        Minute,
        Second
    }

    /// <summary>
    /// 
    /// </summary>
    public static class DateHelper
    {
        private static void ChangeValues(ref int Value1, ref int Value2)
        {
            int i = Value1;
            Value1 = Value2;
            Value2 = i;
        }

        public static long DateDifference(DateInterval Interval, DateTime Date1, DateTime Date2)
        {
            if (Utils.IsEmpty(Date1) || Utils.IsEmpty(Date2))
                return -1;
            int dd1 = Date1.Day;
            int mm1 = Date1.Month;
            int yy1 = Date1.Year;

            int dd2 = Date2.Day;
            int mm2 = Date2.Month;
            int yy2 = Date2.Year;

            if ((dd2 <= 0) || (dd1 <= 0) || (mm2 <= 0) || (mm1 <= 0) || (yy2 <= 0) || (yy1 <= 0))
                return -1;

            long diff = -1;

            int sgnY = 1;
            int sgnM = 1;
            int sgnD = 1;
            if (yy2 < yy1)
            {
                sgnY = sgnY * (-1);
                ChangeValues(ref yy2, ref yy1);
            }
            else if (yy2 == yy1)
            {
                sgnY = 0;
            }

            if (mm2 < mm1)
            {
                sgnM = sgnM * (-1);
                ChangeValues(ref mm2, ref mm1);
            }
            else if (mm2 == mm1)
            {
                sgnM = 0;
            }

            if (dd2 < dd1) 
            {
                sgnD = sgnD * (-1);
                //'ChangeValues(dd2, dd1)
            }
            else if (dd2 == dd1)
            {
                sgnD = 0;
            }

            switch(Interval)
            {
                case DateInterval.Year:
                    diff = sgnY * (yy2 - yy1 + sgnM * sgnM * (System.Convert.ToInt16((sgnM * sgnY - 1) / 2)) 
                         + (1 - sgnM * sgnM) * sgnD * sgnD * (System.Convert.ToInt16((sgnD * sgnY - 1) / 2)));
                    break;
                case DateInterval.Month:
                    int sgnYM = sgnY + (1 - sgnY * sgnY) * sgnM;
                    diff = sgnY * (yy2 - yy1) * 12 + sgnM * (mm2 - mm1) + 
                           sgnYM * sgnD * sgnD * (System.Convert.ToInt16((sgnD * sgnYM - 1) / 2));
                    break;
                case DateInterval.Day:
                    diff = System.Convert.ToInt64(-Date1.Subtract(Date2).TotalDays);
                    break;
                case DateInterval.Hour:
                    diff = System.Convert.ToInt64(-Date1.Subtract(Date2).TotalHours);
                    break;
                case DateInterval.Minute:
                    diff = System.Convert.ToInt64(-Date1.Subtract(Date2).TotalMinutes);
                    break;
                case DateInterval.Second:
                    diff = System.Convert.ToInt64(-Date1.Subtract(Date2).TotalSeconds);
                    break;
                default:
                    //diff = DateDiff(DateInterval.Day, Date1, Date2);
                    break;
            }
            return diff;
        }

    }
}

