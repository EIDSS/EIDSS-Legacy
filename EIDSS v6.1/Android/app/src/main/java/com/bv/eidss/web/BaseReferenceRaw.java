package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import android.content.ContentValues;

import java.io.IOException;

public class BaseReferenceRaw  {

    public long idfsBaseReference;
    public long idfsReferenceType;
    public int intHACode;
    public String strDefault;
    public int intRowStatus;
    public int intOrder;
    public long intFeature1;
    public long intFeature2;

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("idfsReferenceType", idfsReferenceType);
        ret.put("intHACode", intHACode);
        ret.put("strDefault", strDefault);
        ret.put("intRowStatus", intRowStatus);
        ret.put("intOrder", intOrder);
        ret.put("intFeature1", intFeature1);
        ret.put("intFeature2", intFeature2);
        return ret;
    }
    
    public BaseReferenceRaw(){}

    public BaseReferenceRaw(JSONObject json) throws JSONException{
        idfsBaseReference = json.getLong("id");
        idfsReferenceType = json.getLong("tp");
        intHACode = json.getInt("ha");
        strDefault = json.getString("df");
        intRowStatus = json.getInt("rs");
        intOrder = json.getInt("rd");
        intFeature1 = json.optLong("f1");
        intFeature2 = json.optLong("f2");
    }

    public BaseReferenceRaw(XmlPullParser parser)  throws XmlPullParserException, IOException {
        idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "id"));
        idfsReferenceType = Long.parseLong(parser.getAttributeValue("", "tp"));
        intHACode = Integer.parseInt(parser.getAttributeValue("", "ha"));
        strDefault = parser.getAttributeValue("", "df");
        intRowStatus = Integer.parseInt(parser.getAttributeValue("", "rs"));
        intOrder = Integer.parseInt(parser.getAttributeValue("", "rd"));
    }

    public static VectorBaseReferenceRaw FromXml(XmlPullParser parser) throws XmlPullParserException, IOException{
        VectorBaseReferenceRaw allref = new VectorBaseReferenceRaw(null);

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("ref")){
                        allref.add(new BaseReferenceRaw(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("refs")){
                        return allref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return allref;
    }
}
