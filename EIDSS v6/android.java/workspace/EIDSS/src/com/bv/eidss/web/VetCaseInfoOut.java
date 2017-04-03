package com.bv.eidss.web;

import java.text.ParseException;

import org.json.JSONException;
import org.json.JSONObject;

public class VetCaseInfoOut {

    public Long id;
    public String offlineCaseID;
    public String caseID;
    public String farmCode;
    public Long herd;
    public String reportedByOrganization;
    public String reportedByPerson;

    public String lastErrorDescription;

    public boolean isCreated;
    public boolean isUpdated;
    public boolean isFailed;
    
    public VetCaseInfoOut(JSONObject json) throws JSONException, ParseException{
        id = json.getLong("id");
    	offlineCaseID = json.getString("offlineCaseID");
    	caseID = json.getString("caseID");
    	farmCode = json.getString("farmCode");
    	herd = json.getLong("herd");
    	reportedByOrganization = json.getString("reportedByOrganization");
    	reportedByPerson = json.getString("reportedByPerson");
    	lastErrorDescription = json.getString("lastErrorDescription");
    	isCreated = json.getBoolean("isCreated");
    	isUpdated = json.getBoolean("isUpdated");
    	isFailed = json.getBoolean("isFailed");
    }
}
