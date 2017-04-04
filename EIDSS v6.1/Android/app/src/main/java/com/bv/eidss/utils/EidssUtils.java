package com.bv.eidss.utils;

import android.content.ContentUris;
import android.content.Context;
import android.database.Cursor;
import android.net.Uri;
import android.util.Log;
import android.view.View;
import android.view.ViewParent;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.App;
import com.bv.eidss.R;
import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;

import org.json.JSONException;
import org.json.JSONObject;

import java.text.Format;
import java.text.ParseException;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class EidssUtils {
    public static Date ParseDate(Cursor cursor, Format formatterDate, String fieldName) throws ParseException {
        String strDate = cursor.getString(cursor.getColumnIndex(fieldName));
        if (strDate != null && !strDate.equals("")){
            return  (Date)formatterDate.parseObject(strDate);
        }
        return null;
    }

    public static void putToJson(JSONObject json, String name, String val) throws JSONException {
        if (val != null)
            json.put(name, val);
    }
    public static void putToJson(JSONObject json, String name, Date val) throws JSONException {
        if (val != null) {
            json.put(name, DateHelpers.FormatWithT(val));
        }
    }
    public static void putToJson(JSONObject json, String name, long val) throws JSONException {
        if (val != 0)
            json.put(name, val);
    }
    public static void putToJson(JSONObject json, String name, Double val) throws JSONException {
        if (val != 0)
            json.put(name, val);
    }

    public static String getCurrentLanguage()
    {
        return EidssDatabase.getAppLang();
    }

    public static String getLocale()
    {
        String lang = Locale.getDefault().getLanguage();
        //String country = Locale.getDefault().getCountry();
        if (lang.compareTo("ru") == 0)
            return "ru";
        else if (lang.compareTo("ar") == 0)
            return "ar";
        else if (lang.compareTo("az") == 0)
            return "az";
        else if (lang.compareTo("hy") == 0)
            return "hy";
        else if (lang.compareTo("ka") == 0)
            return "ka";
        else if (lang.compareTo("kk") == 0)
            return "kk";
        else if (lang.compareTo("th") == 0)
            return "th";
        else if (lang.compareTo("ua") == 0)
            return "ua";
        return "en";
    }

    public static String getReference(final long def, final String lang){
        String ret = "";
        Uri uri_sel = ContentUris.withAppendedId(ReferenciesProvider.CONTENT_URI, def);
        String[] sels = new String[2];
        sels[0] = lang;
        sels[1] = String.valueOf(def);
        Cursor c = App.getContentResolverStatic().query(uri_sel, null, null, sels, null);
        try {
            c.moveToFirst();
            if(!c.isAfterLast())
                ret = c.getString(c.getColumnIndex("name"));
        }
        catch(Exception e){
            Log.d("getReference", e.getMessage());
        }
        c.close();
        return ret;
    }

    private static void setReadOnlyHeader(View control, boolean isReadonly)
    {
        setHeader(control, isReadonly, false);
    }
    public static void SetMandatoryHeader(View control)
    {
        setHeader(control, false, true);
    }
    private static void setHeader(View control, boolean isReadonly, boolean isMandatory){
        ViewParent parent = control.getParent();
        while (parent != null){
            View v = (View)parent;
            if ("controlContainer".equals(v.getTag())){
                LinearLayout p = (LinearLayout)v;
                for(int i = 0; i < p.getChildCount(); i++){
                    View c = p.getChildAt(i);
                    if ("controlHeader".equals(c.getTag())) {
                        EidssContextUtils.setTextAppearance((TextView) c, isReadonly ? R.style.DetailItem_Header_Readonly :
                                (isMandatory ? R.style.DetailItem_Header_Mandatory :
                                        R.style.DetailItem_Header));
                        break;
                    }
                }
                break;
            }
            parent = parent.getParent();
        }
    }

    public static void setEnabled(Spinner spinner, boolean isEnabled)
    {
        setReadOnlyHeader(spinner, !isEnabled);
        spinner.setEnabled(isEnabled);
    }

    // most generic function to use
    public static void setEnabled(Spinner spinner, boolean isEnabled, boolean isMandatory)
    {
        setHeader(spinner, !isEnabled, isMandatory);
        spinner.setEnabled(isEnabled);
    }

    // most generic function to use
    public static void setEnabled(TextView text, boolean isEnabled, boolean isMandatory)
    {
        setHeader(text, !isEnabled, isMandatory);
        text.setTextColor(EidssContextUtils.getColorStatic(isEnabled
                ? R.color.DetailItem_TextColor
                : R.color.DetailItem_TextColorHint));
        text.setEnabled(isEnabled);
    }

    public static void setEnabled(TextView text, boolean isEnabled) {
        setEnabled(text, isEnabled, false);
    }

    public static Boolean SetMandatoryAndInvisible(final View control, final String fldName, final List<String> mandatoryFields, final List<String> invisibleFields, final boolean isReadonly){
        if (mandatoryFields != null && invisibleFields != null) {
            SetMandatoryAndInvisible(control,
                    fldName != null && mandatoryFields.contains(fldName),
                    fldName != null && invisibleFields.contains(fldName),
                    isReadonly);
            if(fldName != null && invisibleFields.contains(fldName))
                return false;
        }

        return true;
    }

    public static Boolean setInvisible(final View control)
    {
        ViewParent parent = control.getParent();
        while (parent != null) {
            View v = (View) parent;
            if ("controlContainer".equals(v.getTag())) {
                    v.setVisibility(View.GONE);
                    return false;
            }
            parent = parent.getParent();
        }
        return true;
    }

    public static void SetMandatoryAndInvisible(final View control, final Boolean isMandatory, final Boolean isInvisible, final boolean isReadonly) {
        if (isInvisible)
            setInvisible(control);
        else if (isMandatory && !isReadonly)
            SetMandatoryHeader(control);
        else if (isReadonly) {
            if (control instanceof TextView)
                setEnabled((TextView) control, false);
            else if (control instanceof Spinner)
                setEnabled((Spinner) control, false);
        }

    }

    // deprecated
    public static String getStringFromDB(final Context context, final Uri uri, final long def) {
        return getStringFromDB(uri, def);    }
    public static String getStringFromDB(final Uri uri, final long def) {
        String ret = "";
        if (def > 0L) {
            Uri uri_sel = ContentUris.withAppendedId(uri, def);
            String[] sels = new String[2];
            sels[0] = getCurrentLanguage();
            sels[1] = String.valueOf(def);
            Cursor c = App.getContentResolverStatic().query(uri_sel, null, null, sels, null);
            try {
                c.moveToFirst();
                if (!c.isAfterLast())
                    ret = c.getString(c.getColumnIndex("name"));
            } catch (Exception e) {
                Log.d("getStringFromDB", e.getMessage());
            }
            c.close();
        }
        return ret;
    }
}
