package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;

import android.content.ContentValues;

public class GisBaseReferenceRaw {

    public long idfsBaseReference;
    public long idfsReferenceType;
    public long idfsCountry;
    public long idfsRegion;
    public long idfsRayon;
    public String strDefault;
    
    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("idfsReferenceType", idfsReferenceType);
        ret.put("idfsCountry", idfsCountry);
        ret.put("idfsRegion", idfsRegion);
        ret.put("idfsRayon", idfsRayon);
        ret.put("strDefault", strDefault);
        return ret;
    }
    
    public GisBaseReferenceRaw(){}
    
    public GisBaseReferenceRaw(JSONObject json) throws JSONException{
		idfsBaseReference = json.getLong("id");
    	idfsReferenceType = json.getLong("tp");
    	idfsCountry = json.getLong("cn");
    	idfsRegion = json.getLong("rg");
    	idfsRayon = json.getLong("rn");
    	strDefault = json.getString("df");
    }
}
