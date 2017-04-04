package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import android.content.ContentValues;

import java.io.IOException;

public class GisBaseReferenceRaw {

    public long idfsBaseReference;
    public long idfsReferenceType;
    public long idfsCountry;
    public long idfsRegion;
    public long idfsRayon;
    public String strDefault;
    public int intRowStatus;
    public int intOrder;

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("idfsReferenceType", idfsReferenceType);
        ret.put("idfsCountry", idfsCountry);
        ret.put("idfsRegion", idfsRegion);
        ret.put("idfsRayon", idfsRayon);
        ret.put("strDefault", strDefault);
        ret.put("intRowStatus", intRowStatus);
        ret.put("intOrder", intOrder);
        return ret;
    }
    
    public GisBaseReferenceRaw(){}
    
    public GisBaseReferenceRaw(JSONObject json) throws JSONException{
		idfsBaseReference = json.getLong("id");
    	idfsReferenceType = json.getLong("tp");
    	idfsCountry = json.getLong("cn");
    	idfsRegion = json.getLong("rg");
    	idfsRayon = json.getLong("rn");
    	strDefault = json.getString("df");
        intRowStatus = json.getInt("rs");
        intOrder = json.getInt("rd");
    }

    public GisBaseReferenceRaw(XmlPullParser parser)  throws XmlPullParserException, IOException {
        idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "id"));
        idfsReferenceType = Long.parseLong(parser.getAttributeValue("", "tp"));
        idfsCountry = Long.parseLong(parser.getAttributeValue("", "cn"));
        idfsRegion = Long.parseLong(parser.getAttributeValue("", "rg"));
        idfsRayon = Long.parseLong(parser.getAttributeValue("", "rn"));
        strDefault = parser.getAttributeValue("", "df");
        intRowStatus = Integer.parseInt(parser.getAttributeValue("", "rs"));
        intOrder = Integer.parseInt(parser.getAttributeValue("", "rd"));
    }

    public static VectorGisBaseReferenceRaw FromXml(XmlPullParser parser) throws XmlPullParserException, IOException{
        VectorGisBaseReferenceRaw allref = new VectorGisBaseReferenceRaw();

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("gis")){
                        allref.add(new GisBaseReferenceRaw(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("giss")){
                        return allref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return allref;
    }
}
