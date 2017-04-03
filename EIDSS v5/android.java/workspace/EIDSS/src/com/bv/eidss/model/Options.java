package com.bv.eidss.model;

import android.database.Cursor;
import android.content.ContentValues;

public class Options {

	private long id; 
    private String strServerUrl;
    private String strLocalPassword;
    private String strLoginOrganization;
    private String strLoginUsername;

	public long getId() { return id; } public void setId(long val) { id = val; } 
	public String getServerUrl() { return strServerUrl; } public void setServerUrl(String val) { strServerUrl = val; } 
	public String getLocalPassword() { return strLocalPassword; } public void setLocalPassword(String val) { strLocalPassword = val; } 
	public String getLoginOrganization() { return strLoginOrganization; } public void setLoginOrganization(String val) { strLoginOrganization = val; } 
	public String getLoginUsername() { return strLoginUsername; } public void setLoginUsername(String val) { strLoginUsername = val; } 
    

    public static Options FromCursor(Cursor cursor)
    {
        Options ret = new Options();
        ret.id = cursor.getLong(cursor.getColumnIndex("id"));
        ret.strServerUrl = cursor.getString(cursor.getColumnIndex("strServerUrl"));
        ret.strLocalPassword = cursor.getString(cursor.getColumnIndex("strLocalPassword"));
        ret.strLoginOrganization = cursor.getString(cursor.getColumnIndex("strLoginOrganization"));
        ret.strLoginUsername = cursor.getString(cursor.getColumnIndex("strLoginUsername"));
        return ret;
    }

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("id", id);
        ret.put("strServerUrl", strServerUrl);
        ret.put("strLocalPassword", strLocalPassword);
        ret.put("strLoginOrganization", strLoginOrganization);
        ret.put("strLoginUsername", strLoginUsername);
        return ret;
    }
	
}
