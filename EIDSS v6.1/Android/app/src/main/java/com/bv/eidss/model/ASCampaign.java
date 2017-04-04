package com.bv.eidss.model;

import android.content.ContentValues;
import android.database.Cursor;
import android.support.annotation.NonNull;

import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.web.VectorASCampaign;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import java.io.IOException;
import java.text.Format;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

public class ASCampaign {
    public long idfCampaign;
    public int intRowStatus;
    public String strCampaignName;
    public long idfsCampaignType;
    public Date datCampaignDateStart;
    public Date datCampaignDateEnd;

    public List<ASDisease> asDiseases;

    @Override
    public String toString()
    {
        return strCampaignName;
    }

    public static ASCampaign FromCursor(Cursor cursor)
    {
        Format formatterDate = DateHelpers.getDateFormatter();
        ASCampaign ret = new ASCampaign();
        try {
            ret.idfCampaign = cursor.getLong(cursor.getColumnIndex("idfCampaign"));
            ret.intRowStatus = cursor.getInt(cursor.getColumnIndex("intRowStatus"));
            ret.strCampaignName = cursor.getString(cursor.getColumnIndex("strCampaignName"));
            ret.idfsCampaignType = cursor.getLong(cursor.getColumnIndex("idfsCampaignType"));
            ret.datCampaignDateStart = EidssUtils.ParseDate(cursor, formatterDate, "datCampaignDateStart");
            ret.datCampaignDateEnd = EidssUtils.ParseDate(cursor, formatterDate, "datCampaignDateEnd");
        }
        catch (ParseException e)
        {
            e.printStackTrace();
        }
        return ret;
    }

    public ASCampaign() {
        asDiseases = new ArrayList<ASDisease>();
    }

    public ASCampaign(JSONObject json) throws JSONException, ParseException {
        idfCampaign = json.getLong("idfCampaign");
        intRowStatus = json.getInt("intRowStatus");
        strCampaignName = json.getString("strCampaignName");
        idfsCampaignType = json.getLong("idfsCampaignType");
        datCampaignDateStart = DateHelpers.ParseWithT(json.getString("datCampaignDateStart"));
        datCampaignDateEnd = DateHelpers.ParseWithT(json.getString("datCampaignDateEnd"));

        asDiseases = new ArrayList<ASDisease>();
        JSONArray jsonArray = json.getJSONArray("asdiseases");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                ASDisease sp = ASDisease.CreateNewFromCampaign(idfCampaign);
                sp.FromJson(jsonArray.getJSONObject(i));
                asDiseases.add(sp);
            }
        }
    }


    public void FromAttr(Attributes attributes) throws SAXException, ParseException
    {
        idfCampaign = Long.parseLong(attributes.getValue("idfCampaign"));
        idfsCampaignType = Long.parseLong(attributes.getValue("idfsCampaignType"));
        strCampaignName = attributes.getValue("strCampaignName");
        datCampaignDateStart = DateHelpers.ParseWithT(attributes.getValue("datCampaignDateStart"));
        datCampaignDateEnd = DateHelpers.ParseWithT(attributes.getValue("datCampaignDateEnd"));
    }

    public static ASCampaign CreateFromAttr(Attributes attributes) throws SAXException, ParseException
    {
        ASCampaign ret = new ASCampaign();
        ret.FromAttr(attributes);
        return ret;
    }

}
