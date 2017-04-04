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
public class FFRuleConstant {
    public int id;
    public long idfsRule;
    public String strConstant;

    public FFRuleConstant(){}

    public static FFRuleConstant FromCursor(Cursor cursor) {
        FFRuleConstant ret = new FFRuleConstant();
        ret.id = cursor.getInt(cursor.getColumnIndex("id"));
        ret.idfsRule = cursor.getLong(cursor.getColumnIndex("idfsRule"));
        ret.strConstant = cursor.getString(cursor.getColumnIndex("strConstant"));
        return ret;
    }

    public ContentValues ContentValues() {
        ContentValues ret = new ContentValues();
        ret.put("idfsRule", idfsRule);
        ret.put("strConstant", strConstant);
        return ret;
    }

    public FFRuleConstant(JSONObject json) throws JSONException {
        idfsRule = json.getLong("rl");
        strConstant = json.getString("cn");
    }

    public FFRuleConstant(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfsRule = Long.parseLong(parser.getAttributeValue("", "rl"));
        strConstant = parser.getAttributeValue("", "cn");
    }

    public static ArrayList<FFRuleConstant> FromXml(XmlPullParser parser)throws XmlPullParserException, IOException {
        ArrayList<FFRuleConstant> r = new ArrayList<>();
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("obj")){
                        r.add(new FFRuleConstant(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("cons")){
                        return r;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return r;
    }
}
