package com.bv.eidss.model;

import android.content.ContentValues;
import android.database.Cursor;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import java.io.IOException;
import java.util.ArrayList;

//
// Created by Vdovin on 09.05.2015.
//
public class FFParameterFixedPresetValue {

    public int id;
    public long idfsParameterFixedPresetValue;
    public long idfsParameterType;

    public FFParameterFixedPresetValue(){}

    public static FFParameterFixedPresetValue FromCursor(Cursor cursor) {
        FFParameterFixedPresetValue ret = new FFParameterFixedPresetValue();
        ret.id = cursor.getInt(cursor.getColumnIndex("id"));
        ret.idfsParameterFixedPresetValue = cursor.getLong(cursor.getColumnIndex("idfsParameterFixedPresetValue"));
        ret.idfsParameterType = cursor.getLong(cursor.getColumnIndex("idfsParameterType"));
        return ret;
    }

    public ContentValues ContentValues() {
        ContentValues ret = new ContentValues();
        ret.put("idfsParameterFixedPresetValue", idfsParameterFixedPresetValue);
        ret.put("idfsParameterType", idfsParameterType);
        return ret;
    }

    public FFParameterFixedPresetValue(JSONObject json) throws JSONException {
        idfsParameterFixedPresetValue = json.getLong("pv");
        idfsParameterType = json.getLong("pt");
    }

    public FFParameterFixedPresetValue(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfsParameterFixedPresetValue = Long.parseLong(parser.getAttributeValue("", "pv"));
        idfsParameterType = Long.parseLong(parser.getAttributeValue("", "pt"));
    }

    public static ArrayList<FFParameterFixedPresetValue> FromXml(XmlPullParser parser)throws XmlPullParserException, IOException {
        ArrayList<FFParameterFixedPresetValue> r = new ArrayList<>();
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("obj")){
                        r.add(new FFParameterFixedPresetValue(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("pfps")){
                        return r;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return r;
    }
}
