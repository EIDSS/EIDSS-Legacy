package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import android.content.ContentValues;

import java.io.IOException;

public class MandatoryFieldsRaw  {
    public long idfMandatoryField;
    public String strFieldAlias;

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfMandatoryField", idfMandatoryField);
        ret.put("strFieldAlias", strFieldAlias);
        return ret;
    }

    public MandatoryFieldsRaw(JSONObject json) throws JSONException{
        idfMandatoryField = json.getLong("id");
        strFieldAlias = json.getString("fn");
    }

    public MandatoryFieldsRaw(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfMandatoryField = Long.parseLong(parser.getAttributeValue("", "id"));
        strFieldAlias = parser.getAttributeValue("", "fn");
    }

    public static VectorMandatoryFieldsRaw FromXml(XmlPullParser parser) throws XmlPullParserException, IOException{
        VectorMandatoryFieldsRaw ref = new VectorMandatoryFieldsRaw();

        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("field")){
                        ref.add(new MandatoryFieldsRaw(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("mandatory")){
                        return ref;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return ref;
    }
}
