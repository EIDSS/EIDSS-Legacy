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
public class FFParameterForAction {
    public int id;
    public long idfsParameter;
    public long idfsRule;
    public long idfsRuleAction;

    public FFParameterForAction(){}

    public static FFParameterForAction FromCursor(Cursor cursor) {
        FFParameterForAction ret = new FFParameterForAction();
        ret.id = cursor.getInt(cursor.getColumnIndex("id"));
        ret.idfsParameter = cursor.getLong(cursor.getColumnIndex("idfsParameter"));
        ret.idfsRule = cursor.getLong(cursor.getColumnIndex("idfsRule"));
        ret.idfsRuleAction = cursor.getLong(cursor.getColumnIndex("idfsRuleAction"));
        return ret;
    }

    public ContentValues ContentValues() {
        ContentValues ret = new ContentValues();
        ret.put("idfsParameter", idfsParameter);
        ret.put("idfsRule", idfsRule);
        ret.put("idfsRuleAction", idfsRuleAction);
        return ret;
    }

    public FFParameterForAction(JSONObject json) throws JSONException {
        idfsParameter = json.getLong("pr");
        idfsRule = json.getLong("rl");
        idfsRuleAction = json.getLong("ra");
    }

    public FFParameterForAction(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfsParameter = Long.parseLong(parser.getAttributeValue("", "pr"));
        idfsRule = Long.parseLong(parser.getAttributeValue("", "rl"));
        idfsRuleAction = Long.parseLong(parser.getAttributeValue("", "ra"));
    }

    public static ArrayList<FFParameterForAction> FromXml(XmlPullParser parser)throws XmlPullParserException, IOException {
        ArrayList<FFParameterForAction> r = new ArrayList<>();
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("obj")){
                        r.add(new FFParameterForAction(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("acts")){
                        return r;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return r;
    }

}
