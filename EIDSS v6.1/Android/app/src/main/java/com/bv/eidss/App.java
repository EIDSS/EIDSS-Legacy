package com.bv.eidss;

import android.content.ContentResolver;
import android.content.Context;
import android.content.res.Resources;

public class App extends android.app.Application {
    private static Context context;

    public static Resources getResourcesStatic() {
        return context.getResources();
    }

    public static String getPackageNameStatic() {
        return context.getPackageName();
    }

    public static ContentResolver getContentResolverStatic(){
        return context.getContentResolver();
    }

    // be careful: don't use this instead of Activity context
    protected static Context getAppContextStatic() {
        return context;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        context = getApplicationContext();
    }
}
