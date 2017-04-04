
package com.bv.eidss.model;

import java.io.IOException;
import java.text.Format;
import java.text.ParseException;
import java.util.Date;

import android.database.Cursor;
import android.content.ContentValues;

import com.bv.eidss.utils.DateHelpers;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;
import org.xmlpull.v1.XmlSerializer;

public class Options {

	private long id; 
    private String strServerUrl;
    private String strServerUrlDef;
    private String strLocalPassword;
    private String strLoginOrganization;
    private String strLoginOrganizationDef;
    private String strLoginUsername;
    private String strLoginUsernameDef;
    private String strDefLang;
    private Date datLastOnlineSyn;
    private Date datLastRefUpdt;
    private Date datLastListUpdt;
    private int intApplicationMode;
    private int intApplicationModeDef;
    private int intPageSize;
    private int intPageSizeDef;
    private int intLockTimeout;
    private int intLockTimeoutDef;
    private int intResponseTimeout;
    private int intResponseTimeoutDef;
    private long idfsRegionDef;
    private long idfsRegionDefDef;
    private long idfsRayonDef;
    private long idfsRayonDefDef;
    private boolean blnFltrByDgn;

    public long getId() { return id; } public void setId(long val) { id = val; }
	public String getServerUrl()    { return strServerUrl; }   public void setServerUrl(String val) { strServerUrl = val; } 
	public String getServerUrlDef() { return strServerUrlDef; } 
	public String getLocalPassword() { return strLocalPassword; } public void setLocalPassword(String val) { strLocalPassword = val; } 
	public String getLoginOrganization()    { return strLoginOrganization; }   public void setLoginOrganization(String val) { strLoginOrganization = val; } 
	public String getLoginUsername()    { return strLoginUsername; }   public void setLoginUsername(String val) { strLoginUsername = val; }
    public String getDefLang()    { return strDefLang; }   public void setDefLang(String val) { strDefLang = val; }
    public Date getLastOnlineSyn() { return datLastOnlineSyn; } public void setLastOnlineSyn(Date value) { datLastOnlineSyn = value; }
    public Date getLastRefUpdt() { return datLastRefUpdt; } public void setLastRefUpdt(Date value) { datLastRefUpdt = value; }
    public Date getLastListUpdt() { return datLastListUpdt; } public void setLastListUpdt(Date value) { datLastListUpdt = value; }
    public int getApplicationMode()    { return intApplicationMode; }   public void setApplicationMode(int value) { intApplicationMode = value; }
    public int getApplicationModeDef() { return intApplicationModeDef; }
    public int getPageSize()    { return intPageSize; }   public void setPageSize(int value) { intPageSize = value; }
    public int getPageSizeDef() { return intPageSizeDef; }
    public int getLockTimeout()    { return intLockTimeout; }   public void setLockTimeout(int value) { intLockTimeout = value; }
    public int getLockTimeoutDef() { return intLockTimeoutDef; }
    public int getResponseTimeout()    { return intResponseTimeout; }   public void setResponseTimeout(int value) { intResponseTimeout = value; }
    public int getResponseTimeoutDef() { return intResponseTimeoutDef; }
    public long getRegionDef() { return idfsRegionDef; }   public void setRegionDef(long value) { idfsRegionDef = value; }
    public long getRegionDefDef() { return idfsRegionDefDef; }   public void setRegionDefDef(long value) { idfsRegionDefDef = value; }
    public long getRayonDef() { return idfsRayonDef; }   public void setRayonDef(long value) { idfsRayonDef = value; }
    public long getRayonDefDef() { return idfsRayonDefDef; }   public void setRayonDefDef(long value) { idfsRayonDefDef = value; }
    public Boolean getFltrByDgn() { return blnFltrByDgn; }   public void setFltrByDgn(boolean value) { blnFltrByDgn = value; }


    private Options()
    {
    }

    public Options(JSONObject json) throws JSONException {
        idfsRegionDefDef = json.getLong("idfsRegionDefault");
        idfsRayonDefDef = json.getLong("idfsRayonDefault");
    }

    public static Options FromCursor(Cursor cursor)
    {
    	Format formatterDateTime = DateHelpers.getDateTimeFormatter();
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
            ret.strDefLang = cursor.getString(cursor.getColumnIndex("strDefLang"));
	        String strDate = cursor.getString(cursor.getColumnIndex("datLastOnlineSyn"));
	    	if (strDate != null && !strDate.isEmpty())
	    		ret.datLastOnlineSyn = (Date)formatterDateTime.parseObject(strDate);
	        strDate = cursor.getString(cursor.getColumnIndex("datLastRefUpdt"));
	    	if (strDate != null && !strDate.isEmpty())
	    		ret.datLastRefUpdt = (Date)formatterDateTime.parseObject(strDate);
            strDate = cursor.getString(cursor.getColumnIndex("datLastListUpdt"));
            if (strDate != null && !strDate.isEmpty())
                ret.datLastListUpdt = (Date)formatterDateTime.parseObject(strDate);
	        ret.intApplicationMode = cursor.getInt(cursor.getColumnIndex("intApplicationMode"));
	        ret.intApplicationModeDef = cursor.getInt(cursor.getColumnIndex("intApplicationModeDef"));
	        ret.intPageSize = cursor.getInt(cursor.getColumnIndex("intPageSize"));
	        ret.intPageSizeDef = cursor.getInt(cursor.getColumnIndex("intPageSizeDef"));
	        ret.intLockTimeout = cursor.getInt(cursor.getColumnIndex("intLockTimeout"));
	        ret.intLockTimeoutDef = cursor.getInt(cursor.getColumnIndex("intLockTimeoutDef"));
	        ret.intResponseTimeout = cursor.getInt(cursor.getColumnIndex("intResponseTimeout"));
            ret.intResponseTimeoutDef = cursor.getInt(cursor.getColumnIndex("intResponseTimeoutDef"));
            ret.idfsRegionDef = cursor.getLong(cursor.getColumnIndex("idfsRegionDef"));
            ret.idfsRegionDefDef = cursor.getLong(cursor.getColumnIndex("idfsRegionDefDef"));
            ret.idfsRayonDef = cursor.getLong(cursor.getColumnIndex("idfsRayonDef"));
            ret.idfsRayonDefDef = cursor.getLong(cursor.getColumnIndex("idfsRayonDefDef"));
            ret.blnFltrByDgn = cursor.getInt(cursor.getColumnIndex("blnFltrByDgn")) > 0;
        } catch (ParseException e) {
			e.printStackTrace();
			return null;
		} 
        return ret;
    }

    public ContentValues ContentValues()
    {
    	Format formatterDateTime = DateHelpers.getDateTimeFormatter();
    	
    	ContentValues ret = new ContentValues();
        ret.put("id", id);
        ret.put("strServerUrl",    strServerUrl);
        ret.put("strServerUrlDef", strServerUrlDef);
        ret.put("strLocalPassword", strLocalPassword);
        ret.put("strLoginOrganization",    strLoginOrganization);
        ret.put("strLoginOrganizationDef", strLoginOrganizationDef);
        ret.put("strLoginUsername",    strLoginUsername);
        ret.put("strLoginUsernameDef", strLoginUsernameDef);
        ret.put("strDefLang", strDefLang);
        String strDate = null;
        if (datLastOnlineSyn != null)
        	strDate = formatterDateTime.format(datLastOnlineSyn);
        ret.put("datLastOnlineSyn", strDate);
        strDate = null;
        if (datLastRefUpdt != null)
        	strDate = formatterDateTime.format(datLastRefUpdt);
        ret.put("datLastRefUpdt", strDate);
        if (datLastListUpdt != null)
            strDate = formatterDateTime.format(datLastListUpdt);
        ret.put("datLastListUpdt", strDate);
        ret.put("intApplicationMode",    intApplicationMode);
        ret.put("intApplicationModeDef", intApplicationModeDef);
        ret.put("intPageSize",    intPageSize);
        ret.put("intPageSizeDef", intPageSizeDef);
        ret.put("intLockTimeout",    intLockTimeout);
        ret.put("intLockTimeoutDef", intLockTimeoutDef);
        ret.put("intResponseTimeout",    intResponseTimeout);
        ret.put("intResponseTimeoutDef", intResponseTimeoutDef);
        ret.put("idfsRegionDefDef", idfsRegionDefDef);
        ret.put("idfsRegionDef", idfsRegionDef);
        ret.put("idfsRegionDefDef", idfsRegionDefDef);
        ret.put("idfsRayonDef", idfsRayonDef);
        ret.put("idfsRayonDefDef", idfsRayonDefDef);
        ret.put("blnFltrByDgn", blnFltrByDgn);
        return ret;
    }

    protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException
    {
        serializer.attribute("", "strServerUrl", strServerUrl == null ? "" : strServerUrl);
        serializer.attribute("", "strServerUrlDef", strServerUrlDef == null ? "" : strServerUrlDef);
        serializer.attribute("", "strLocalPassword", strLocalPassword == null ? "" : strLocalPassword);
        serializer.attribute("", "strLoginOrganization", strLoginOrganization == null ? "" : strLoginOrganization);
        serializer.attribute("", "strLoginOrganizationDef", strLoginOrganizationDef == null ? "" : strLoginOrganizationDef);
        serializer.attribute("", "strLoginUsername", strLoginUsername == null ? "" : strLoginUsername);
        serializer.attribute("", "strLoginUsernameDef", strLoginUsernameDef == null ? "" : strLoginUsernameDef);
        serializer.attribute("", "strDefLang", strDefLang == null ? "" : strDefLang);
        serializer.attribute("", "datLastOnlineSyn", datLastOnlineSyn == null ? "" : DateHelpers.FormatWithT(datLastOnlineSyn));
        serializer.attribute("", "datLastRefUpdt", datLastRefUpdt == null ? "" : DateHelpers.FormatWithT(datLastRefUpdt));
        serializer.attribute("", "datLastListUpdt", datLastListUpdt == null ? "" : DateHelpers.FormatWithT(datLastListUpdt));
        serializer.attribute("", "intApplicationMode", String.valueOf(intApplicationMode));
        serializer.attribute("", "intApplicationModeDef", String.valueOf(intApplicationModeDef));
        serializer.attribute("", "intPageSize", String.valueOf(intPageSize));
        serializer.attribute("", "intPageSizeDef", String.valueOf(intPageSizeDef));
        serializer.attribute("", "intLockTimeout", String.valueOf(intLockTimeout));
        serializer.attribute("", "intLockTimeoutDef", String.valueOf(intLockTimeoutDef));
        serializer.attribute("", "intResponseTimeout", String.valueOf(intResponseTimeout));
        serializer.attribute("", "intResponseTimeoutDef", String.valueOf(intResponseTimeoutDef));
        serializer.attribute("", "idfsRegionDef", String.valueOf(idfsRegionDef));
        serializer.attribute("", "idfsRegionDefDef", String.valueOf(idfsRegionDefDef));
        serializer.attribute("", "idfsRayonDef", String.valueOf(idfsRayonDef));
        serializer.attribute("", "idfsRayonDefDef", String.valueOf(idfsRayonDefDef));
        if (getFltrByDgn() != null)
            serializer.attribute("", "blnFltrByDgn", String.valueOf(getFltrByDgn() ? 1 : 0));
    }

    protected void FromXml(XmlPullParser parser)throws XmlPullParserException, IOException, ParseException{
        strServerUrl = parser.getAttributeValue("", "strServerUrl");
        strServerUrlDef = parser.getAttributeValue("", "strServerUrlDef");
        strLocalPassword = parser.getAttributeValue("", "strLocalPassword");
        strLoginOrganization = parser.getAttributeValue("", "strLoginOrganization");
        strLoginOrganizationDef = parser.getAttributeValue("", "strLoginOrganizationDef");
        strLoginUsername = parser.getAttributeValue("", "strLoginUsername");
        strLoginUsernameDef = parser.getAttributeValue("", "strLoginUsernameDef");
        strDefLang = parser.getAttributeValue("", "strDefLang");
        datLastOnlineSyn = DateHelpers.ParseWithT(parser.getAttributeValue("", "datLastOnlineSyn"));
        datLastRefUpdt = DateHelpers.ParseWithT(parser.getAttributeValue("", "datLastRefUpdt"));
        datLastListUpdt = DateHelpers.ParseWithT(parser.getAttributeValue("", "datLastListUpdt"));
        intApplicationMode = Integer.parseInt(parser.getAttributeValue("", "intApplicationMode"));
        intApplicationModeDef = Integer.parseInt(parser.getAttributeValue("", "intApplicationModeDef"));
        intPageSize = Integer.parseInt(parser.getAttributeValue("", "intPageSize"));
        intPageSizeDef = Integer.parseInt(parser.getAttributeValue("", "intPageSizeDef"));
        intLockTimeout = Integer.parseInt(parser.getAttributeValue("", "intLockTimeout"));
        intLockTimeoutDef = Integer.parseInt(parser.getAttributeValue("", "intLockTimeoutDef"));
        intResponseTimeout = Integer.parseInt(parser.getAttributeValue("", "intResponseTimeout"));
        intResponseTimeoutDef = Integer.parseInt(parser.getAttributeValue("", "intResponseTimeoutDef"));
        idfsRegionDef = Long.parseLong(parser.getAttributeValue("", "idfsRegionDef"));
        idfsRegionDefDef = Long.parseLong(parser.getAttributeValue("", "idfsRegionDefDef"));
        idfsRayonDef = Long.parseLong(parser.getAttributeValue("", "idfsRayonDef"));
        idfsRayonDefDef = Long.parseLong(parser.getAttributeValue("", "idfsRayonDefDef"));
        blnFltrByDgn = parser.getAttributeValue("", "blnFltrByDgn") == null ? null : Boolean.getBoolean(parser.getAttributeValue("", "blnFltrByDgn"));
    }

    public void writeXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException {
        serializer.startTag("", "options");
        ToXml(serializer);
        serializer.endTag("", "options");
    }

}
