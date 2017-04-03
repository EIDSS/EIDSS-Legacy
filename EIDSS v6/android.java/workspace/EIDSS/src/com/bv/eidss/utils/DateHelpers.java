package com.bv.eidss.utils;

import java.util.Calendar;
import java.util.Date;

public class DateHelpers {
	public static Date Today()
	{
		Calendar calendar = Calendar.getInstance();
		Date date = new Date();
		calendar.setTime(date);
		calendar.set(Calendar.HOUR_OF_DAY, 0);
		calendar.set(Calendar.MINUTE, 0);
		calendar.set(Calendar.SECOND, 0);
		calendar.set(Calendar.MILLISECOND, 0);
		return calendar.getTime();
	}

	public static Date Date(int year, int month, int day)
	{
		Calendar calendar = Calendar.getInstance();
		Date date = new Date();
		calendar.setTime(date);
		calendar.set(Calendar.YEAR, year);
		calendar.set(Calendar.MONTH, month);
		calendar.set(Calendar.DAY_OF_MONTH, day);
		calendar.set(Calendar.HOUR_OF_DAY, 0);
		calendar.set(Calendar.MINUTE, 0);
		calendar.set(Calendar.SECOND, 0);
		calendar.set(Calendar.MILLISECOND, 0);
		return calendar.getTime();
	}

	/*
	public static Date Date(Date d)
	{
		Calendar calendar = Calendar.getInstance();
		Date date = new Date();
		calendar.setTime(date);
		calendar.set(Calendar.YEAR, d.getYear());
		calendar.set(Calendar.MONTH, d.getMonth());
		calendar.set(Calendar.DAY_OF_MONTH, d.getDate());
		calendar.set(Calendar.HOUR_OF_DAY, 0);
		calendar.set(Calendar.MINUTE, 0);
		calendar.set(Calendar.SECOND, 0);
		calendar.set(Calendar.MILLISECOND, 0);
		return calendar.getTime();
	}
	*/
	
	public static long DateDifference(int interval, Date Date1, Date Date2)
    {
        if (Date1 == null || Date2 == null)
            return -1;
        int dd1 = Date1.getDate() + 1;
        int mm1 = Date1.getMonth() + 1;
        int yy1 = Date1.getYear() + 1900;

        int dd2 = Date2.getDate() + 1;
        int mm2 = Date2.getMonth() + 1;
        int yy2 = Date2.getYear() + 1900;

        if ((dd2 <= 0) || (dd1 <= 0) || (mm2 <= 0) || (mm1 <= 0) || (yy2 <= 0) || (yy1 <= 0))
            return -1;

        long diff = -1;

        int sgnY = 1;
        int sgnM = 1;
        int sgnD = 1;
        if (yy2 < yy1)
        {
            sgnY = sgnY * (-1);
            int i = yy2;
            yy2 = yy1;
            yy1 = i;
        }
        else if (yy2 == yy1)
        {
            sgnY = 0;
        }

        if (mm2 < mm1)
        {
            sgnM = sgnM * (-1);
            int i = mm2;
            mm2 = mm1;
            mm1 = i;
        }
        else if (mm2 == mm1)
        {
            sgnM = 0;
        }

        if (dd2 < dd1) 
        {
            sgnD = sgnD * (-1);
        }
        else if (dd2 == dd1)
        {
            sgnD = 0;
        }

        switch(interval)
        {
            case 0:
                diff = sgnY * (yy2 - yy1 + sgnM * sgnM * ((int)((sgnM * sgnY - 1) / 2)) 
                     + (1 - sgnM * sgnM) * sgnD * sgnD * ((int)((sgnD * sgnY - 1) / 2)));
                break;
            case 1:
                int sgnYM = sgnY + (1 - sgnY * sgnY) * sgnM;
                diff = sgnY * (yy2 - yy1) * 12 + sgnM * (mm2 - mm1) + 
                       sgnYM * sgnD * sgnD * ((int)((sgnD * sgnYM - 1) / 2));
                break;
            default:
                break;
        }
        return diff;
    }
	
}
