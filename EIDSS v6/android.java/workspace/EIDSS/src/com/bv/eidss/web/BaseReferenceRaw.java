package com.bv.eidss.web;

import org.json.JSONException;
import org.json.JSONObject;

import android.content.ContentValues;

public class BaseReferenceRaw  {

    public long idfsBaseReference;
    public long idfsReferenceType;
    public int intHACode;
    public String strDefault;

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("idfsReferenceType", idfsReferenceType);
        ret.put("intHACode", intHACode);
        ret.put("strDefault", strDefault);
        return ret;
    }
    
    public BaseReferenceRaw(){}
    
    public BaseReferenceRaw(JSONObject json) throws JSONException{
		idfsBaseReference = json.getLong("id");
    	idfsReferenceType = json.getLong("tp");
    	intHACode = json.getInt("ha");
    	strDefault = json.getString("df");
    }
}
