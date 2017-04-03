package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;

import android.content.ContentValues;

public class GisBaseReferenceTranslationRaw {

    public long idfsBaseReference;
    public String strTranslation;
    public String strLanguage;
    
    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("strTranslation", strTranslation);
        ret.put("strLanguage", strLanguage);
        return ret;
    }
    
    public GisBaseReferenceTranslationRaw(){}
    
    public GisBaseReferenceTranslationRaw(JSONObject json) throws JSONException{
    	idfsBaseReference = json.getLong("id");
    	strTranslation = json.getString("tr");
    	strLanguage = json.getString("lg");
    }
}
