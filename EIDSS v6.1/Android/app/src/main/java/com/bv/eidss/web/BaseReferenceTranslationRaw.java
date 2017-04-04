package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import android.content.ContentValues;

import java.io.IOException;
import java.util.ArrayList;

public class BaseReferenceTranslationRaw {

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

    public BaseReferenceTranslationRaw(){}

    public BaseReferenceTranslationRaw(JSONObject json) throws JSONException{
    	idfsBaseReference = json.getLong("id");
    	strTranslation = json.getString("tr");
        strLanguage = json.getString("lg");
    }

    public BaseReferenceTranslationRaw(XmlPullParser parser)  throws XmlPullParserException, IOException {
        idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "id"));
        strTranslation = parser.getAttributeValue("", "tr");
        strLanguage = parser.getAttributeValue("", "lg");
    }

    public static VectorBaseReferenceTranslationRaw FromXml(XmlPullParser parser, ArrayList<String> langs)  throws XmlPullParserException, IOException{
        VectorBaseReferenceTranslationRaw allref = new VectorBaseReferenceTranslationRaw();

        String lang;

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("lang")){
                        lang = parser.getAttributeValue("", "lang");
                        if(langs.contains(lang))
                            BaseReferenceTranslationRaw.FromXml(parser, allref, lang);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("refsLang")){
                        return allref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return allref;
    }

    private static void FromXml(XmlPullParser parser, VectorBaseReferenceTranslationRaw allref, String lang)  throws XmlPullParserException, IOException{

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("refLang")){
                        BaseReferenceTranslationRaw gt = new BaseReferenceTranslationRaw(parser);
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
