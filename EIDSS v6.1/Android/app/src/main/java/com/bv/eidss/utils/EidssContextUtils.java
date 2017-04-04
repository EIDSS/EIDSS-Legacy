package com.bv.eidss.utils;

import android.support.v4.content.ContextCompat;
import android.widget.TextView;

import com.bv.eidss.App;

public class EidssContextUtils extends App {
    public static int getColorStatic(int color){
        return ContextCompat.getColor(App.getAppContextStatic(), color);
    }

    public static void setTextAppearance(TextView t, int style){
        t.setTextAppearance(App.getAppContextStatic(), style);
    }
}
