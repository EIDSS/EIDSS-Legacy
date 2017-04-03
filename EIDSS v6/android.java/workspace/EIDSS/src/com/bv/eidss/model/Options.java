
package com.bv.eidss.model;

import java.text.Format;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import android.database.Cursor;
import android.content.ContentValues;

public class Options {

	private long id; 
    private String strServerUrl;
    private String strServerUrlDef;
    private String strLocalPassword;
    private String strLoginOrganization;
    private String strLoginOrganizationDef;
    private String strLoginUsername;
    private String strLoginUsernameDef;
    private String strEidssVersion;
    private Date datLastOnlineSyn;
    private Date datLastRefUpdt;
    private int intApplicationMode;
    private int intApplicationModeDef;
    private int intPageSize;
    private int intPageSizeDef;
    private int intLockTimeout;
    private int intLockTimeoutDef;
    private int intResponseTimeout;
    private int intResponseTimeoutDef;

	public long getId() { return id; } public void setId(long val) { id = val; } 
	public String getServerUrl()    { return strServerUrl; }   public void setServerUrl(String val) { strServerUrl = val; } 
	public String getServerUrlDef() { return strServerUrlDef; } 
	public String getLocalPassword() { return strLocalPassword; } public void setLocalPassword(String val) { strLocalPassword = val; } 
	public String getLoginOrganization()    { return strLoginOrganization; }   public void setLoginOrganization(String val) { strLoginOrganization = val; } 
	public String getLoginOrganizationDef() { return strLoginOrganizationDef; }
	public String getLoginUsername()    { return strLoginUsername; }   public void setLoginUsername(String val) { strLoginUsername = val; } 
	public String getLoginUsernameDef() { return strLoginUsernameDef; } 
	public String getEidssVersion() { return strEidssVersion; } public void setEidssVersion(String val) { strEidssVersion = val; } 
    public Date getLastOnlineSyn() { return datLastOnlineSyn; } public void setLastOnlineSyn(Date value) { datLastOnlineSyn = value; }
    public Date getLastRefUpdt() { return datLastRefUpdt; } public void setLastRefUpdt(Date value) { datLastRefUpdt = value; }
    public int getApplicationMode()    { return intApplicationMode; }   public void setApplicationMode(int value) { intApplicationMode = value; }
    public int getApplicationModeDef() { return intApplicationModeDef; }
    public int getPageSize()    { return intPageSize; }   public void setPageSize(int value) { intPageSize = value; }
    public int getPageSizeDef() { return intPageSizeDef; }
    public int getLockTimeout()    { return intLockTimeout; }   public void setLockTimeout(int value) { intLockTimeout = value; }
    public int getLockTimeoutDef() { return intLockTimeoutDef; }
    public int getResponseTimeout()    { return intResponseTimeout; }   public void setResponseTimeout(int value) { intResponseTimeout = value; }
    public int getResponseTimeoutDef() { return intResponseTimeoutDef; }
    

    public static Options FromCursor(Cursor cursor)
    {
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
        Options ret = new Options();
		try {
	        ret.id = cursor.getLong(cursor.getColumnIndex("id"));
	        ret.strServerUrl    = cursor.getString(cursor.getColumnIndex("strServerUrl"));
	        ret.strServerUrlDef = cursor.getString(cursor.getColumnIndex("strServerUrlDef"));
	        ret.strLocalPassword = cursor.getString(cursor.getColumnIndex("strLocalPassword"));
	        ret.strLoginOrganization    = cursor.getString(cursor.getColumnIndex("strLoginOrganization"));
	        ret.strLoginOrganizationDef = cursor.getString(cursor.getColumnIndex("strLoginOrganizationDef"));
	        ret.strLoginUsername    = cursor.getString(cursor.getColumnIndex("strLoginUsername"));
	        ret.strLoginUsernameDef = cursor.getString(cursor.getColumnIndex("strLoginUsernameDef"));
	        ret.strEidssVersion = cursor.getString(cursor.getColumnIndex("strEidssVersion"));
	        String strDate = cursor.getString(cursor.getColumnIndex("datLastOnlineSyn"));
	    	if (strDate != null && !strDate.isEmpty())
	    		ret.datLastOnlineSyn = (Date)formatterDateTime.parseObject(strDate);
	        strDate = cursor.getString(cursor.getColumnIndex("datLastRefUpdt"));
	    	if (strDate != null && !strDate.isEmpty())
	    		ret.datLastRefUpdt = (Date)formatterDateTime.parseObject(strDate);
	        ret.intApplicationMode = cursor.getInt(cursor.getColumnIndex("intApplicationMode"));
	        ret.intApplicationModeDef = cursor.getInt(cursor.getColumnIndex("intApplicationModeDef"));
	        ret.intPageSize = cursor.getInt(cursor.getColumnIndex("intPageSize"));
	        ret.intPageSizeDef = cursor.getInt(cursor.getColumnIndex("intPageSizeDef"));
	        ret.intLockTimeout = cursor.getInt(cursor.getColumnIndex("intLockTimeout"));
	        ret.intLockTimeoutDef = cursor.getInt(cursor.getColumnIndex("intLockTimeoutDef"));
	        ret.intResponseTimeout = cursor.getInt(cursor.getColumnIndex("intResponseTimeout"));
	        ret.intResponseTimeoutDef = cursor.getInt(cursor.getColumnIndex("intResponseTimeoutDef"));
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		} 
        return ret;
    }

    public ContentValues ContentValues()
    {
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
    	
    	ContentValues ret = new ContentValues();
        ret.put("id", id);
        ret.put("strServerUrl",    strServerUrl);
        ret.put("strServerUrlDef", strServerUrlDef);
        ret.put("strLocalPassword", strLocalPassword);
        ret.put("strLoginOrganization",    strLoginOrganization);
        ret.put("strLoginOrganizationDef", strLoginOrganizationDef);
        ret.put("strLoginUsername",    strLoginUsername);
        ret.put("strLoginUsernameDef", strLoginUsernameDef);
        ret.put("strEidssVersion", strEidssVersion);
        String strDate = null;
        if (datLastOnlineSyn != null)
        	strDate = formatterDateTime.format(datLastOnlineSyn);
        ret.put("datLastOnlineSyn", strDate);
        strDate = null;
        if (datLastRefUpdt != null)
        	strDate = formatterDateTime.format(datLastRefUpdt);
        ret.put("datLastRefUpdt", strDate);
        ret.put("intApplicationMode",    intApplicationMode);
        ret.put("intApplicationModeDef", intApplicationModeDef);
        ret.put("intPageSize",    intPageSize);
        ret.put("intPageSizeDef", intPageSizeDef);
        ret.put("intLockTimeout",    intLockTimeout);
        ret.put("intLockTimeoutDef", intLockTimeoutDef);
        ret.put("intResponseTimeout",    intResponseTimeout);
        ret.put("intResponseTimeoutDef", intResponseTimeoutDef);
        return ret;
    }
	
}
