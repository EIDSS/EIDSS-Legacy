package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import android.content.ContentValues;

import java.io.IOException;

public class InvisibleFieldsRaw  {
    public long idfInvisibleField;
    public String strFieldAlias;

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfInvisibleField", idfInvisibleField);
        ret.put("strFieldAlias", strFieldAlias);
        return ret;
    }

    public InvisibleFieldsRaw(JSONObject json) throws JSONException{
        idfInvisibleField = json.getLong("id");
        strFieldAlias = json.getString("fn");
    }

    public InvisibleFieldsRaw(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfInvisibleField = Long.parseLong(parser.getAttributeValue("", "id"));
        strFieldAlias = parser.getAttributeValue("", "fn");
    }

    public static VectorInvisibleFieldsRaw FromXml(XmlPullParser parser) throws XmlPullParserException, IOException{
        VectorInvisibleFieldsRaw ref = new VectorInvisibleFieldsRaw();

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("field")){
                        ref.add(new InvisibleFieldsRaw(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("invisible")){
                        return ref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return ref;
    }
}
