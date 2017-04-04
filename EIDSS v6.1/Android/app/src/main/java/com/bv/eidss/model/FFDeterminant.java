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
public class FFDeterminant {
    public int id;
    public long idfDeterminantValue;
    public long idfsFormType;
    public long idfsFormTemplate;

    public FFDeterminant(){}

    public static FFDeterminant FromCursor(Cursor cursor) {
        FFDeterminant ret = new FFDeterminant();
        ret.id = cursor.getInt(cursor.getColumnIndex("id"));
        ret.idfDeterminantValue = cursor.getLong(cursor.getColumnIndex("idfDeterminantValue"));
        ret.idfsFormType = cursor.getLong(cursor.getColumnIndex("idfsFormType"));
        ret.idfsFormTemplate = cursor.getLong(cursor.getColumnIndex("idfsFormTemplate"));
        return ret;
    }

    public ContentValues ContentValues() {
        ContentValues ret = new ContentValues();
        ret.put("idfDeterminantValue", idfDeterminantValue);
        ret.put("idfsFormType", idfsFormType);
        ret.put("idfsFormTemplate", idfsFormTemplate);
        return ret;
    }

    public FFDeterminant(JSONObject json) throws JSONException {
        idfDeterminantValue = json.getLong("dv");
        idfsFormType = json.getLong("tp");
        idfsFormTemplate = json.getLong("ft");
    }

    public FFDeterminant(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfDeterminantValue = Long.parseLong(parser.getAttributeValue("", "dv"));
        idfsFormType = Long.parseLong(parser.getAttributeValue("", "tp"));
        idfsFormTemplate = Long.parseLong(parser.getAttributeValue("", "ft"));
    }

    public static ArrayList<FFDeterminant> FromXml(XmlPullParser parser)throws XmlPullParserException, IOException {
        ArrayList<FFDeterminant> r = new ArrayList<>();
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("obj")){
                        r.add(new FFDeterminant(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("dets")){
                        return r;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return r;
    }

}
