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
public class FFParameterForFunction {
    public int id;
    public long idfsParameter;
    public long idfsRule;
    public int intOrder;

    public FFParameterForFunction(){}

    public static FFParameterForFunction FromCursor(Cursor cursor) {
        FFParameterForFunction ret = new FFParameterForFunction();
        ret.id = cursor.getInt(cursor.getColumnIndex("id"));
        ret.idfsParameter = cursor.getLong(cursor.getColumnIndex("idfsParameter"));
        ret.idfsRule = cursor.getLong(cursor.getColumnIndex("idfsRule"));
        ret.intOrder = cursor.getInt(cursor.getColumnIndex("intOrder"));
        return ret;
    }

    public ContentValues ContentValues() {
        ContentValues ret = new ContentValues();
        ret.put("idfsParameter", idfsParameter);
        ret.put("idfsRule", idfsRule);
        ret.put("intOrder", intOrder);
        return ret;
    }

    public FFParameterForFunction(JSONObject json) throws JSONException {
        idfsParameter = json.getLong("pr");
        idfsRule = json.getLong("rl");
        intOrder = json.getInt("rd");
    }

    public FFParameterForFunction(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfsParameter = Long.parseLong(parser.getAttributeValue("", "pr"));
        idfsRule = Long.parseLong(parser.getAttributeValue("", "rl"));
        intOrder = Integer.parseInt(parser.getAttributeValue("", "rd"));
    }

    public static ArrayList<FFParameterForFunction> FromXml(XmlPullParser parser)throws XmlPullParserException, IOException {
        ArrayList<FFParameterForFunction> r = new ArrayList<>();
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("obj")){
                        r.add(new FFParameterForFunction(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("funs")){
                        return r;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return r;
    }
}
