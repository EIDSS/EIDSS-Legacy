package com.bv.eidss.model.generated;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;

import com.bv.eidss.R;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.interfaces.IFieldChanged;
import com.bv.eidss.model.interfaces.ICallable;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.text.Format;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;
import java.util.List;
import java.util.ArrayList;

public class ASSession_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public ASSession_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
    }
  public static String eidss_MonitoringSessionStatus = "AsSession.MonitoringSessionStatus";
  public static String eidss_StartDate = "AsSession.datStartDate";
  public static String eidss_EndDate = "AsSession.datEndDate";
  public static String eidss_Campaign = "AsSession.Campaign";
  public static String eidss_CampaignType = "AsSession.CampaignType";
  public static String eidss_Region = "AsSession.Address.Region";
  public static String eidss_Rayon = "AsSession.Address.Rayon";
  public static String eidss_Settlement = "AsSession.Address.Settlement";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_MonitoringSessionStatus, R.string.ASSession_idfsMonitoringSessionStatus, new ICallable<Long, ASSession_object>() { public Long call(ASSession_object t) { return t.getMonitoringSessionStatus(); }}));
        add(new FieldMetadata(eidss_StartDate, R.string.ASSession_datStartDate, new ICallable<Date, ASSession_object>() { public Date call(ASSession_object t) { return t.getStartDate(); }}));
        add(new FieldMetadata(eidss_EndDate, R.string.ASSession_datEndDate, new ICallable<Date, ASSession_object>() { public Date call(ASSession_object t) { return t.getEndDate(); }}));
        add(new FieldMetadata(eidss_Campaign, R.string.ASSession_idfCampaign, new ICallable<Long, ASSession_object>() { public Long call(ASSession_object t) { return t.getCampaign(); }}));
        add(new FieldMetadata(eidss_Region, R.string.ASSession_idfsRegion, new ICallable<Long, ASSession_object>() { public Long call(ASSession_object t) { return t.getRegion(); }}));
        add(new FieldMetadata(eidss_Rayon, R.string.ASSession_idfsRayon, new ICallable<Long, ASSession_object>() { public Long call(ASSession_object t) { return t.getRayon(); }}));
        add(new FieldMetadata(eidss_Settlement, R.string.ASSession_idfsSettlement, new ICallable<Long, ASSession_object>() { public Long call(ASSession_object t) { return t.getSettlement(); }}));
    }}}};

    // system fields
    protected long _id;
    public long getId() { return _id; }
    public void setId(long value) { _id = value; }
    protected String _strLastSynError;
    public String getLastSynError() { return _strLastSynError; }
    public void setLastSynError(String value) { _strLastSynError = value; }
    protected int _intStatus; //  1 - new; 2 - synchronized; 3 - changed; 4 - unloaded;
    public int getStatus() { return _intStatus; }
    public void setStatusChanged() { _intStatus = CaseStatus.CHANGED; }
    public void setStatusSyn() { _intStatus = CaseStatus.SYNCHRONIZED; }
    public void setStatusUploaded() { _intStatus = CaseStatus.UNLOADED; }
    protected int _intChanged; //  0 - not; 1 - yes;
    public void clearChanged() { _intChanged = 0; }
    protected Date _datCreateDate;
    public Date getCreateDate() { return _datCreateDate; }

//fields
  protected String _uidOfflineCaseID;
  public String getOfflineCaseID(){return _uidOfflineCaseID;}
  public void setOfflineCaseID(String value) { _uidOfflineCaseID = value; }
  protected Date _datModificationDate;
  public Date getModificationDate(){return _datModificationDate;}
   public void setModificationDate(Date value) { if(_datModificationDate == null && value == null) return; bChanged = bChanged || _datModificationDate == null || value == null || !_datModificationDate.equals(value); _intChanged = ((_intChanged == 1) || _datModificationDate == null || value == null || !_datModificationDate.equals(value)) ? 1 : 0; if (_datModificationDate == null || value == null || !_datModificationDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datModificationDate", _datModificationDate, value); } _datModificationDate = value; }}
  protected String _strMonitoringSessionID;
  public String getMonitoringSessionID(){return _strMonitoringSessionID;}
  public void setMonitoringSessionID(String value) { _strMonitoringSessionID = value; }
  protected long _idfMonitoringSession;
  public long getMonitoringSession(){return _idfMonitoringSession;}
   public void setMonitoringSession(long value) { bChanged = bChanged || _idfMonitoringSession != value; _intChanged = ((_intChanged == 1) || _idfMonitoringSession != value) ? 1 : 0; if (_idfMonitoringSession != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfMonitoringSession", _idfMonitoringSession, value); } _idfMonitoringSession = value; }}
  protected long _idfsMonitoringSessionStatus;
  public long getMonitoringSessionStatus(){return _idfsMonitoringSessionStatus;}
   public void setMonitoringSessionStatus(long value) { bChanged = bChanged || _idfsMonitoringSessionStatus != value; _intChanged = ((_intChanged == 1) || _idfsMonitoringSessionStatus != value) ? 1 : 0; if (_idfsMonitoringSessionStatus != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsMonitoringSessionStatus", _idfsMonitoringSessionStatus, value); } _idfsMonitoringSessionStatus = value; }}
  protected Date _datStartDate;
  public Date getStartDate(){return _datStartDate;}
   public void setStartDate(Date value) { if(_datStartDate == null && value == null) return; bChanged = bChanged || _datStartDate == null || value == null || !_datStartDate.equals(value); _intChanged = ((_intChanged == 1) || _datStartDate == null || value == null || !_datStartDate.equals(value)) ? 1 : 0; if (_datStartDate == null || value == null || !_datStartDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datStartDate", _datStartDate, value); } _datStartDate = value; }}
  protected Date _datEndDate;
  public Date getEndDate(){return _datEndDate;}
   public void setEndDate(Date value) { if(_datEndDate == null && value == null) return; bChanged = bChanged || _datEndDate == null || value == null || !_datEndDate.equals(value); _intChanged = ((_intChanged == 1) || _datEndDate == null || value == null || !_datEndDate.equals(value)) ? 1 : 0; if (_datEndDate == null || value == null || !_datEndDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datEndDate", _datEndDate, value); } _datEndDate = value; }}
  protected long _idfCampaign;
  public long getCampaign(){return _idfCampaign;}
   public void setCampaign(long value) { bChanged = bChanged || _idfCampaign != value; _intChanged = ((_intChanged == 1) || _idfCampaign != value) ? 1 : 0; if (_idfCampaign != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfCampaign", _idfCampaign, value); } _idfCampaign = value; }}
  protected long _idfsCampaignType;
  public long getCampaignType(){return _idfsCampaignType;}
  public void setCampaignType(long value) { _idfsCampaignType = value; }
  protected long _idfsRegion;
  public long getRegion(){return _idfsRegion;}
   public void setRegion(long value) { bChanged = bChanged || _idfsRegion != value; _intChanged = ((_intChanged == 1) || _idfsRegion != value) ? 1 : 0; if (_idfsRegion != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsRegion", _idfsRegion, value); } _idfsRegion = value; }}
  protected long _idfsRayon;
  public long getRayon(){return _idfsRayon;}
   public void setRayon(long value) { bChanged = bChanged || _idfsRayon != value; _intChanged = ((_intChanged == 1) || _idfsRayon != value) ? 1 : 0; if (_idfsRayon != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsRayon", _idfsRayon, value); } _idfsRayon = value; }}
  protected long _idfsSettlement;
  public long getSettlement(){return _idfsSettlement;}
   public void setSettlement(long value) { bChanged = bChanged || _idfsSettlement != value; _intChanged = ((_intChanged == 1) || _idfsSettlement != value) ? 1 : 0; if (_idfsSettlement != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSettlement", _idfsSettlement, value); } _idfsSettlement = value; }}

protected static ASSession_object FromCursor(Cursor cursor, ASSession_object ret)
{

Format formatterDateTime = DateHelpers.getDateTimeFormatter();
Format formatterDate = DateHelpers.getDateFormatter();

try {
    ret._id = cursor.getLong(cursor.getColumnIndex("id"));
    ret._strLastSynError = cursor.getString(cursor.getColumnIndex("strLastSynError"));
    ret._intStatus = cursor.getInt(cursor.getColumnIndex("intStatus"));
    ret._intChanged = cursor.getInt(cursor.getColumnIndex("intChanged"));
    String strDate = cursor.getString(cursor.getColumnIndex("datCreateDate"));
    if (strDate != null) ret._datCreateDate = (Date)formatterDateTime.parseObject(strDate);
  ret._uidOfflineCaseID = cursor.getString(cursor.getColumnIndex("uidOfflineCaseID"));
  ret._datModificationDate = EidssUtils.ParseDate(cursor, formatterDateTime, "datModificationDate");
  ret._strMonitoringSessionID = cursor.getString(cursor.getColumnIndex("strMonitoringSessionID"));
  ret._idfMonitoringSession = cursor.getLong(cursor.getColumnIndex("idfMonitoringSession"));
  ret._idfsMonitoringSessionStatus = cursor.getLong(cursor.getColumnIndex("idfsMonitoringSessionStatus"));
  ret._datStartDate = EidssUtils.ParseDate(cursor, formatterDate, "datStartDate");
  ret._datEndDate = EidssUtils.ParseDate(cursor, formatterDate, "datEndDate");
  ret._idfCampaign = cursor.getLong(cursor.getColumnIndex("idfCampaign"));
  ret._idfsCampaignType = cursor.getLong(cursor.getColumnIndex("idfsCampaignType"));
  ret._idfsRegion = cursor.getLong(cursor.getColumnIndex("idfsRegion"));
  ret._idfsRayon = cursor.getLong(cursor.getColumnIndex("idfsRayon"));
  ret._idfsSettlement = cursor.getLong(cursor.getColumnIndex("idfsSettlement"));
    ret.bChanged = false;
}
catch (ParseException e)
{
    e.printStackTrace();
    return ret;
}
return ret;
}

protected ContentValues ContentValuesInternal()
{
    String strDate = null;
    ContentValues ret = new ContentValues();
    Format formatterDateTime = DateHelpers.getDateTimeFormatter();
    Format formatterDate = DateHelpers.getDateFormatter();
    if (_id != 0)
        ret.put("id", _id);
    ret.put("strLastSynError", _strLastSynError);
    ret.put("intStatus", _intStatus);
    ret.put("intChanged", _intChanged);
    if (_datCreateDate != null)
        strDate = formatterDateTime.format(_datCreateDate);
    ret.put("datCreateDate", strDate);
    strDate = null;
  ret.put("uidOfflineCaseID", _uidOfflineCaseID);
    strDate = null;
  if (_datModificationDate != null)
      strDate = formatterDateTime.format(_datModificationDate);
  ret.put("datModificationDate", strDate);
  ret.put("strMonitoringSessionID", _strMonitoringSessionID);
  ret.put("idfMonitoringSession", _idfMonitoringSession);
  ret.put("idfsMonitoringSessionStatus", _idfsMonitoringSessionStatus);
    strDate = null;
  if (_datStartDate != null)
      strDate = formatterDate.format(_datStartDate);
  ret.put("datStartDate", strDate);
    strDate = null;
  if (_datEndDate != null)
      strDate = formatterDate.format(_datEndDate);
  ret.put("datEndDate", strDate);
  ret.put("idfCampaign", _idfCampaign);
  ret.put("idfsCampaignType", _idfsCampaignType);
  ret.put("idfsRegion", _idfsRegion);
  ret.put("idfsRayon", _idfsRayon);
  ret.put("idfsSettlement", _idfsSettlement);

return ret;
}

protected void FromParcel(Parcel source)
{
    _id = source.readLong();
    _strLastSynError = source.readString();
    _intStatus = source.readInt();
    _intChanged = source.readInt();
    _datCreateDate = (Date)source.readSerializable();
  _uidOfflineCaseID = source.readString();
  _datModificationDate = (Date)source.readSerializable();
  _strMonitoringSessionID = source.readString();
  _idfMonitoringSession = source.readLong();
  _idfsMonitoringSessionStatus = source.readLong();
  _datStartDate = (Date)source.readSerializable();
  _datEndDate = (Date)source.readSerializable();
  _idfCampaign = source.readLong();
  _idfsCampaignType = source.readLong();
  _idfsRegion = source.readLong();
  _idfsRayon = source.readLong();
  _idfsSettlement = source.readLong();
    bChanged = source.readInt() == 1;
}
protected void ToParcel(Parcel dest, int flag)
{
  dest.writeLong(_id);
  dest.writeString(_strLastSynError);
  dest.writeInt(_intStatus);
  dest.writeInt(_intChanged);
  dest.writeSerializable(_datCreateDate);
  dest.writeString(_uidOfflineCaseID);
  dest.writeSerializable(_datModificationDate);
  dest.writeString(_strMonitoringSessionID);
  dest.writeLong(_idfMonitoringSession);
  dest.writeLong(_idfsMonitoringSessionStatus);
  dest.writeSerializable(_datStartDate);
  dest.writeSerializable(_datEndDate);
  dest.writeLong(_idfCampaign);
  dest.writeLong(_idfsCampaignType);
  dest.writeLong(_idfsRegion);
  dest.writeLong(_idfsRayon);
  dest.writeLong(_idfsSettlement);
  dest.writeInt(bChanged ? 1 : 0);
}

protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException
{
serializer.attribute("", "lang", EidssUtils.getCurrentLanguage());
serializer.attribute("", "intChanged", String.valueOf(_intChanged));
  if (_uidOfflineCaseID != null)
      serializer.attribute("", "uidOfflineCaseID", _uidOfflineCaseID);
  if (_datModificationDate != null)
      serializer.attribute("", "datModificationDate", DateHelpers.FormatWithT(_datModificationDate));
  if (_strMonitoringSessionID != null)
      serializer.attribute("", "strMonitoringSessionID", _strMonitoringSessionID);
  if (_idfMonitoringSession != 0)
      serializer.attribute("", "idfMonitoringSession", String.valueOf(_idfMonitoringSession));
  if (_idfsMonitoringSessionStatus != 0)
      serializer.attribute("", "idfsMonitoringSessionStatus", String.valueOf(_idfsMonitoringSessionStatus));
  if (_datStartDate != null)
      serializer.attribute("", "datStartDate", DateHelpers.FormatWithT(_datStartDate));
  if (_datEndDate != null)
      serializer.attribute("", "datEndDate", DateHelpers.FormatWithT(_datEndDate));
  if (_idfCampaign != 0)
      serializer.attribute("", "idfCampaign", String.valueOf(_idfCampaign));
  if (_idfsCampaignType != 0)
      serializer.attribute("", "idfsCampaignType", String.valueOf(_idfsCampaignType));
  if (_idfsRegion != 0)
      serializer.attribute("", "idfsRegion", String.valueOf(_idfsRegion));
  if (_idfsRayon != 0)
      serializer.attribute("", "idfsRayon", String.valueOf(_idfsRayon));
  if (_idfsSettlement != 0)
      serializer.attribute("", "idfsSettlement", String.valueOf(_idfsSettlement));
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "uidOfflineCaseID", _uidOfflineCaseID);
  EidssUtils.putToJson(ret, "datModificationDate", _datModificationDate);
  EidssUtils.putToJson(ret, "strMonitoringSessionID", _strMonitoringSessionID);
  EidssUtils.putToJson(ret, "idfMonitoringSession", _idfMonitoringSession);
  EidssUtils.putToJson(ret, "idfsMonitoringSessionStatus", _idfsMonitoringSessionStatus);
  EidssUtils.putToJson(ret, "datStartDate", _datStartDate);
  EidssUtils.putToJson(ret, "datEndDate", _datEndDate);
  EidssUtils.putToJson(ret, "idfCampaign", _idfCampaign);
  EidssUtils.putToJson(ret, "idfsCampaignType", _idfsCampaignType);
  EidssUtils.putToJson(ret, "idfsRegion", _idfsRegion);
  EidssUtils.putToJson(ret, "idfsRayon", _idfsRayon);
  EidssUtils.putToJson(ret, "idfsSettlement", _idfsSettlement);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _uidOfflineCaseID = json.getString("uidOfflineCaseID");
  _datModificationDate = DateHelpers.ParseWithT(json.getString("datModificationDate"));
  _strMonitoringSessionID = json.getString("strMonitoringSessionID");
  _idfMonitoringSession = json.getLong("idfMonitoringSession");
  _idfsMonitoringSessionStatus = json.getLong("idfsMonitoringSessionStatus");
  _datStartDate = DateHelpers.ParseWithT(json.getString("datStartDate"));
  _datEndDate = DateHelpers.ParseWithT(json.getString("datEndDate"));
  _idfCampaign = json.getLong("idfCampaign");
  _idfsCampaignType = json.getLong("idfsCampaignType");
  _idfsRegion = json.getLong("idfsRegion");
  _idfsRayon = json.getLong("idfsRayon");
  _idfsSettlement = json.getLong("idfsSettlement");
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _uidOfflineCaseID = parser.getAttributeValue("", "uidOfflineCaseID");
  _datModificationDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datModificationDate"));
  _strMonitoringSessionID = parser.getAttributeValue("", "strMonitoringSessionID");
  _idfMonitoringSession = parser.getAttributeValue("", "idfMonitoringSession") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfMonitoringSession"));
  _idfsMonitoringSessionStatus = parser.getAttributeValue("", "idfsMonitoringSessionStatus") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsMonitoringSessionStatus"));
  _datStartDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datStartDate"));
  _datEndDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datEndDate"));
  _idfCampaign = parser.getAttributeValue("", "idfCampaign") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfCampaign"));
  _idfsCampaignType = parser.getAttributeValue("", "idfsCampaignType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsCampaignType"));
  _idfsRegion = parser.getAttributeValue("", "idfsRegion") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsRegion"));
  _idfsRayon = parser.getAttributeValue("", "idfsRayon") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsRayon"));
  _idfsSettlement = parser.getAttributeValue("", "idfsSettlement") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSettlement"));
}
}
