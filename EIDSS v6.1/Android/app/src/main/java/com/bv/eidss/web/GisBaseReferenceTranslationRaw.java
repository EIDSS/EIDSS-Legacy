package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import android.content.ContentValues;
import android.content.res.Configuration;
import android.content.res.Resources;

import com.bv.eidss.R;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Locale;

public class GisBaseReferenceTranslationRaw {

    public long idfsBaseReference;
    public String strTranslation;
    public String strLanguage;
    
    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("strTranslation", strTranslation);
        ret.put("strLanguage", strLanguage);
        return ret;
    }

    public GisBaseReferenceTranslationRaw(){}

    public GisBaseReferenceTranslationRaw(Resources res, String lang){
        idfsBaseReference = 0;
        Configuration conf = res.getConfiguration();
        Locale savedLocale = conf.locale;
        conf.locale = new Locale(lang);
        res.updateConfiguration(conf, null);
        strTranslation = res.getString(R.string.EmptyValue);
        conf.locale = savedLocale;
        res.updateConfiguration(conf, null);
        strLanguage = lang;
    }

    public GisBaseReferenceTranslationRaw(JSONObject json) throws JSONException{
        idfsBaseReference = json.getLong("id");
        strTranslation = json.getString("tr");
        strLanguage = json.getString("lg");
    }

    public GisBaseReferenceTranslationRaw(XmlPullParser parser)  throws XmlPullParserException, IOException {
        idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "id"));
        strTranslation = parser.getAttributeValue("", "tr");
        strLanguage = parser.getAttributeValue("", "lg");
    }

    public static VectorGisBaseReferenceTranslationRaw FromXml(XmlPullParser parser, ArrayList<String> langs) throws XmlPullParserException, IOException{
        VectorGisBaseReferenceTranslationRaw allref = new VectorGisBaseReferenceTranslationRaw();
        String lang;

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("lang")){
                        lang = parser.getAttributeValue("", "lang");
                        if(langs.contains(lang))
                            GisBaseReferenceTranslationRaw.FromXml(parser, allref, lang);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("gissLang")){
                        return allref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return allref;
    }

    private static void FromXml(XmlPullParser parser, VectorGisBaseReferenceTranslationRaw allref, String lang)  throws XmlPullParserException, IOException{

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("gisLang")){
                        GisBaseReferenceTranslationRaw gt = new GisBaseReferenceTranslationRaw(parser);
                        gt.strLanguage = lang;
                        allref.add(gt);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("lang")){
                        return;
                    }
                    break;
            }
            eventType = parser.next();
        }
    }
}
