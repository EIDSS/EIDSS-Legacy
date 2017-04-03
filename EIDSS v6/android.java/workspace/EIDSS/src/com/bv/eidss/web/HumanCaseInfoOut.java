package com.bv.eidss.web;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import org.json.JSONException;
import org.json.JSONObject;

public class HumanCaseInfoOut {

    public Long id;
    public String offlineCaseID;
    public String caseID;
    public Date notificationDate;
    public String notificationSentBy;
    public String notificationSentByPerson;

    public String lastErrorDescription;

    public boolean isCreated;
    public boolean isUpdated;
    public boolean isFailed;
    
    public HumanCaseInfoOut(JSONObject json) throws JSONException, ParseException{
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
        id = json.getLong("id");
    	offlineCaseID = json.getString("offlineCaseID");
    	caseID = json.getString("caseID");
    	notificationDate = format.parse(json.getString("notificationDate").replace('T', ' '));
    	notificationSentBy = json.getString("notificationSentBy");
    	notificationSentByPerson = json.getString("notificationSentByPerson");
    	lastErrorDescription = json.getString("lastErrorDescription");
    	isCreated = json.getBoolean("isCreated");
    	isUpdated = json.getBoolean("isUpdated");
    	isFailed = json.getBoolean("isFailed");
    }
}
