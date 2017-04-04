package com.bv.eidss.web;

import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.ASSample;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.Farm;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.generated.ASDisease_object;
import com.bv.eidss.model.generated.ASSample_object;
import com.bv.eidss.model.generated.ASSession_object;
import com.bv.eidss.model.generated.Farm_object;
import com.bv.eidss.model.generated.Species_object;
import com.bv.eidss.model.generated.VetCase_object;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;

public class ASSessionInfoOut extends ASSession_object {

    public String lastErrorDescription;

    public boolean isCreated;
    public boolean isUpdated;
    public boolean isFailed;

    public List<ASDisease_object> asDiseases;
    public List<Farm_object> farms;
    public List<ASSample_object> asSamples;

    public void FromJson(JSONObject json) throws JSONException, ParseException
    {
        super.FromJson(json);

        JSONArray jsonArray = json.getJSONArray("asdiseases");
        asDiseases = new ArrayList<>();
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                ASDisease sp = ASDisease.CreateNew(getMonitoringSession(), getId());
                sp.FromJson(jsonArray.getJSONObject(i));
                sp.setParent(getId());
                asDiseases.add(sp);
            }
        }

        jsonArray = json.getJSONArray("farms");
        farms = new ArrayList<>();
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                Farm f = Farm.CreateNew(getId());
                f.FromJson(jsonArray.getJSONObject(i));
                f.setParent(getId());
                farms.add(f);
            }
        }

        jsonArray = json.getJSONArray("assamples");
        asSamples = new ArrayList<>();
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                ASSample sp = ASSample.CreateNew(getMonitoringSession(), getId());
                sp.FromJson(jsonArray.getJSONObject(i));
                sp.setParent(getId());
                asSamples.add(sp);
            }
        }
    }

    public ASSessionInfoOut(JSONObject json) throws JSONException, ParseException{
        FromJson(json);

    	lastErrorDescription = json.getString("lastErrorDescription");
    	isCreated = json.getBoolean("isCreated");
    	isUpdated = json.getBoolean("isUpdated");
    	isFailed = json.getBoolean("isFailed");
    }
}
