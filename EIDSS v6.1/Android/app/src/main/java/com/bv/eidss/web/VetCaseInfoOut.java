package com.bv.eidss.web;

import com.bv.eidss.model.Animal;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.VetCaseSample;
import com.bv.eidss.model.generated.Animal_object;
import com.bv.eidss.model.generated.Species_object;
import com.bv.eidss.model.generated.VetCaseSample_object;
import com.bv.eidss.model.generated.VetCase_object;

import java.text.ParseException;
import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class VetCaseInfoOut extends VetCase_object {

    public String lastErrorDescription;

    public boolean isCreated;
    public boolean isUpdated;
    public boolean isFailed;

    public ArrayList<Species_object> species;
    public ArrayList<Animal_object> animals;
    public ArrayList<VetCaseSample_object> samples;

    public Boolean IsLivestockCase(){
        return getCaseType() == CaseType.LIVESTOCK;
    }

    public void FromJson(JSONObject json) throws JSONException, ParseException
    {
        super.FromJson(json);
        JSONArray jsonArray = json.getJSONArray("species");
        species = new ArrayList<>();
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                Species sp = Species.CreateNew(getId(), IsLivestockCase());
                sp.FromJson(jsonArray.getJSONObject(i));
                species.add(sp);
            }
        }
        jsonArray = json.getJSONArray("animals");
        animals = new ArrayList<>();
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                Animal sp = Animal.CreateNew(getId());
                sp.FromJson(jsonArray.getJSONObject(i));
                animals.add(sp);
            }
        }
        jsonArray = json.getJSONArray("samples");
        samples = new ArrayList<>();
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                VetCaseSample sp = VetCaseSample.CreateNew(getId());
                sp.FromJson(jsonArray.getJSONObject(i));
                samples.add(sp);
            }
        }
    }

    public VetCaseInfoOut(JSONObject json) throws JSONException, ParseException{
        FromJson(json);

    	lastErrorDescription = json.getString("lastErrorDescription");
    	isCreated = json.getBoolean("isCreated");
    	isUpdated = json.getBoolean("isUpdated");
    	isFailed = json.getBoolean("isFailed");
    }
}
