package com.bv.eidss.web;


import com.bv.eidss.model.ActivityParameter;
import com.bv.eidss.model.HumanCaseSample;
import com.bv.eidss.model.generated.HumanCaseSample_object;
import com.bv.eidss.model.generated.HumanCase_object;

import java.text.ParseException;
import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class HumanCaseInfoOut extends HumanCase_object {

    public String lastErrorDescription;

    public boolean isCreated;
    public boolean isUpdated;
    public boolean isFailed;

    public ArrayList<HumanCaseSample_object> samples;
    /*
    public ArrayList<ActivityParameter> CsActivityParameters;
    public ArrayList<ActivityParameter> EpiActivityParameters;
    */

    public void FromJson(JSONObject json) throws JSONException, ParseException
    {
        super.FromJson(json);
        JSONArray jsonArray = json.getJSONArray("samples");
        samples = new ArrayList<>();
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                HumanCaseSample sp = HumanCaseSample.CreateNew(getId());
                sp.FromJson(jsonArray.getJSONObject(i));
                samples.add(sp);
            }
        }
    }

    public HumanCaseInfoOut(JSONObject json) throws JSONException, ParseException{
        FromJson(json);

    	lastErrorDescription = json.getString("lastErrorDescription");
    	isCreated = json.getBoolean("isCreated");
    	isUpdated = json.getBoolean("isUpdated");
    	isFailed = json.getBoolean("isFailed");

        //CsActivityParameters = ExtractActivityParameters(json, "FFModelCs", json.getLong("idfCSObservation"));
        //EpiActivityParameters = ExtractActivityParameters(json, "FFModelEpi", json.getLong("idfEpiObservation"));
    }

    private ArrayList<ActivityParameter> ExtractActivityParameters(JSONObject json, String key, long idObservation) throws JSONException{
        ArrayList<ActivityParameter> ret = new ArrayList<>();
        JSONObject container = json.getJSONObject(key);
        //if (idObservation == 0) idObservation = container.getLong("idfObservation");
        JSONArray list = container.getJSONArray("parameters");
        for(int i = 0; i < list.length(); i++){
            ActivityParameter ap = ActivityParameter.FromJson(list.getJSONObject(i));
            ap.idfObservation = idObservation;
            ret.add(ap);
        }
        return ret;
    }
}
