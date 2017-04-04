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
public class FFRule {
    public int id;
    public long idfsRule;
    public long idfsFormTemplate;
    public long idfsCheckPoint;
    public long idfsRuleMessage;
    public long idfsRuleFunction;
    public int intNot;

    public FFRule(){}

    public static FFRule FromCursor(Cursor cursor) {
        FFRule ret = new FFRule();
        ret.id = cursor.getInt(cursor.getColumnIndex("id"));
        ret.idfsRule = cursor.getLong(cursor.getColumnIndex("idfsRule"));
        ret.idfsFormTemplate = cursor.getLong(cursor.getColumnIndex("idfsFormTemplate"));
        ret.idfsCheckPoint = cursor.getLong(cursor.getColumnIndex("idfsCheckPoint"));
        ret.idfsRuleMessage = cursor.getLong(cursor.getColumnIndex("idfsRuleMessage"));
        ret.idfsRuleFunction = cursor.getLong(cursor.getColumnIndex("idfsRuleFunction"));
        ret.intNot = cursor.getInt(cursor.getColumnIndex("intNot"));
        return ret;
    }

    public ContentValues ContentValues() {
        ContentValues ret = new ContentValues();
        ret.put("idfsRule", idfsRule);
        ret.put("idfsFormTemplate", idfsFormTemplate);
        ret.put("idfsCheckPoint", idfsCheckPoint);
        ret.put("idfsRuleMessage", idfsRuleMessage);
        ret.put("idfsRuleFunction", idfsRuleFunction);
        ret.put("intNot", intNot);
        return ret;
    }

    public FFRule(JSONObject json) throws JSONException {
        idfsRule = json.getLong("rl");
        idfsFormTemplate = json.getLong("ft");
        idfsCheckPoint = json.getLong("cp");
        idfsRuleMessage = json.getLong("rm");
        idfsRuleFunction = json.getLong("rf");
        intNot = json.getInt("nt");
    }

    public FFRule(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfsRule = Long.parseLong(parser.getAttributeValue("", "rl"));
        idfsFormTemplate = Long.parseLong(parser.getAttributeValue("", "ft"));
        idfsCheckPoint = Long.parseLong(parser.getAttributeValue("", "cp"));
        idfsRuleMessage = Long.parseLong(parser.getAttributeValue("", "rm"));
        idfsRuleFunction = Long.parseLong(parser.getAttributeValue("", "rf"));
        intNot = Integer.parseInt(parser.getAttributeValue("", "nt"));

    }

    public static ArrayList<FFRule> FromXml(XmlPullParser parser)throws XmlPullParserException, IOException {
        ArrayList<FFRule> r = new ArrayList<>();
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("obj")){
                        r.add(new FFRule(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("ruls")){
                        return r;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return r;
    }

}
