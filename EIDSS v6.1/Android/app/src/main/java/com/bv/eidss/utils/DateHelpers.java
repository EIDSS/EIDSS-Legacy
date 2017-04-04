package com.bv.eidss.utils;

import android.app.Activity;
import android.view.View;
import android.widget.TextView;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

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

    public static Date Now()
    {
        Calendar calendar = Calendar.getInstance();
        Date date = new Date();
        calendar.setTime(date);
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

    public static SimpleDateFormat getDateTimeFormatter()
    {
        return new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
    }
    public static String FormatWithT(Date date)
    {
        return getDateTimeFormatter().format(date).replace(' ', 'T');
    }
    public static Date ParseWithT(String str) throws ParseException
    {
        if (str != null && !str.isEmpty()){
            Date ret = getDateTimeFormatter().parse(str.replace('T', ' '));

            if (getYear(ret) < 1900)
                return null;
            return ret;
        }
        return null;
    }
    public static SimpleDateFormat getDateFormatter()
    {
        return new SimpleDateFormat("yyyy-MM-dd", Locale.US);
    }


    public static int getYear(Date d)
    {
        final Calendar calendar = Calendar.getInstance();
        if(d != null)
            calendar.setTime(d);
        return calendar.get(Calendar.YEAR);
    }

    public static int getMonth(Date d)
    {
        final Calendar calendar = Calendar.getInstance();
        if(d != null)
            calendar.setTime(d);
        return calendar.get(Calendar.MONTH);
    }

    public static int getDay(Date d)
    {
        final Calendar calendar = Calendar.getInstance();
        if(d != null)
            calendar.setTime(d);
        return calendar.get(Calendar.DAY_OF_MONTH);
    }

	
	public static long DateDifference(int interval, Date Date1, Date Date2)
    {
        if (Date1 == null || Date2 == null)
            return -1;
        int dd1 = getDay(Date1) + 1;
        int mm1 = getMonth(Date1) + 1;
        int yy1 = getYear(Date1) + 1900;

        int dd2 = getDay(Date2) + 1;
        int mm2 = getMonth(Date2) + 1;
        int yy2 = getYear(Date2) + 1900;

        if (dd2 <= 0 || dd1 <= 0 || mm2 <= 0 || mm1 <= 0 || yy2 <= 0 || yy1 <= 0)
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
                diff = sgnY * (yy2 - yy1 + sgnM * sgnM * ((sgnM * sgnY - 1) / 2)
                     + (1 - sgnM * sgnM) * sgnD * sgnD * ((sgnD * sgnY - 1) / 2));
                break;
            case 1:
                int sgnYM = sgnY + (1 - sgnY * sgnY) * sgnM;
                diff = sgnY * (yy2 - yy1) * 12 + sgnM * (mm2 - mm1) + 
                       sgnYM * sgnD * sgnD * ((sgnD * sgnYM - 1) / 2);
                break;
            default:
                break;
        }
        return diff;
    }


    public static void DisplayDate(final TextView ed, final Date dt)
    {
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(dt));
    }

    public static void DisplayDate(final int id, final View v, final Date dt)
    {
        final TextView ed = (TextView)(v.findViewById(id));
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(dt));
    }

    public static void DisplayDate(final int id, final Activity context, final Date dt)
    {
        final TextView ed = (TextView)(context.findViewById(id));
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(dt));
    }

}
