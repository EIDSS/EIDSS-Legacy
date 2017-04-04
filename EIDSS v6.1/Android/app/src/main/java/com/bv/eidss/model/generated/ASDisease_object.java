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

public class ASDisease_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public ASDisease_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
    }
  public static String eidss_Diagnosis = "AsDisease.Diagnosis";
  public static String eidss_SpeciesType = "AsDisease.Species";
  public static String eidss_SampleType = "AsDisease.Sample";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_Diagnosis, R.string.ASDisease_idfsDiagnosis, new ICallable<Long, ASDisease_object>() { public Long call(ASDisease_object t) { return t.getDiagnosis(); }}));
        add(new FieldMetadata(eidss_SpeciesType, R.string.ASDisease_idfsSpeciesType, new ICallable<Long, ASDisease_object>() { public Long call(ASDisease_object t) { return t.getSpeciesType(); }}));
        add(new FieldMetadata(eidss_SampleType, R.string.ASDisease_idfsSampleType, new ICallable<Long, ASDisease_object>() { public Long call(ASDisease_object t) { return t.getSampleType(); }}));
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
  protected long _idParent;
  public long getParent(){return _idParent;}
   public void setParent(long value) { bChanged = bChanged || _idParent != value; _intChanged = ((_intChanged == 1) || _idParent != value) ? 1 : 0; if (_idParent != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idParent", _idParent, value); } _idParent = value; }}
  protected long _idfMonitoringSession;
  public long getMonitoringSession(){return _idfMonitoringSession;}
   public void setMonitoringSession(long value) { bChanged = bChanged || _idfMonitoringSession != value; _intChanged = ((_intChanged == 1) || _idfMonitoringSession != value) ? 1 : 0; if (_idfMonitoringSession != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfMonitoringSession", _idfMonitoringSession, value); } _idfMonitoringSession = value; }}
  protected long _idfCampaign;
  public long getCampaign(){return _idfCampaign;}
   public void setCampaign(long value) { bChanged = bChanged || _idfCampaign != value; _intChanged = ((_intChanged == 1) || _idfCampaign != value) ? 1 : 0; if (_idfCampaign != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfCampaign", _idfCampaign, value); } _idfCampaign = value; }}
  protected long _idfsDiagnosis;
  public long getDiagnosis(){return _idfsDiagnosis;}
   public void setDiagnosis(long value) { bChanged = bChanged || _idfsDiagnosis != value; _intChanged = ((_intChanged == 1) || _idfsDiagnosis != value) ? 1 : 0; if (_idfsDiagnosis != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsDiagnosis", _idfsDiagnosis, value); } _idfsDiagnosis = value; }}
  protected long _idfsSpeciesType;
  public long getSpeciesType(){return _idfsSpeciesType;}
   public void setSpeciesType(long value) { bChanged = bChanged || _idfsSpeciesType != value; _intChanged = ((_intChanged == 1) || _idfsSpeciesType != value) ? 1 : 0; if (_idfsSpeciesType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSpeciesType", _idfsSpeciesType, value); } _idfsSpeciesType = value; }}
  protected long _idfsSampleType;
  public long getSampleType(){return _idfsSampleType;}
   public void setSampleType(long value) { bChanged = bChanged || _idfsSampleType != value; _intChanged = ((_intChanged == 1) || _idfsSampleType != value) ? 1 : 0; if (_idfsSampleType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSampleType", _idfsSampleType, value); } _idfsSampleType = value; }}

protected static ASDisease_object FromCursor(Cursor cursor, ASDisease_object ret)
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
  ret._idParent = cursor.getLong(cursor.getColumnIndex("idParent"));
  ret._idfMonitoringSession = cursor.getLong(cursor.getColumnIndex("idfMonitoringSession"));
  ret._idfCampaign = cursor.getLong(cursor.getColumnIndex("idfCampaign"));
  ret._idfsDiagnosis = cursor.getLong(cursor.getColumnIndex("idfsDiagnosis"));
  ret._idfsSpeciesType = cursor.getLong(cursor.getColumnIndex("idfsSpeciesType"));
  ret._idfsSampleType = cursor.getLong(cursor.getColumnIndex("idfsSampleType"));
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
  ret.put("idParent", _idParent);
  ret.put("idfMonitoringSession", _idfMonitoringSession);
  ret.put("idfCampaign", _idfCampaign);
  ret.put("idfsDiagnosis", _idfsDiagnosis);
  ret.put("idfsSpeciesType", _idfsSpeciesType);
  ret.put("idfsSampleType", _idfsSampleType);

return ret;
}

protected void FromParcel(Parcel source)
{
    _id = source.readLong();
    _strLastSynError = source.readString();
    _intStatus = source.readInt();
    _intChanged = source.readInt();
    _datCreateDate = (Date)source.readSerializable();
  _idParent = source.readLong();
  _idfMonitoringSession = source.readLong();
  _idfCampaign = source.readLong();
  _idfsDiagnosis = source.readLong();
  _idfsSpeciesType = source.readLong();
  _idfsSampleType = source.readLong();
    bChanged = source.readInt() == 1;
}
protected void ToParcel(Parcel dest, int flag)
{
  dest.writeLong(_id);
  dest.writeString(_strLastSynError);
  dest.writeInt(_intStatus);
  dest.writeInt(_intChanged);
  dest.writeSerializable(_datCreateDate);
  dest.writeLong(_idParent);
  dest.writeLong(_idfMonitoringSession);
  dest.writeLong(_idfCampaign);
  dest.writeLong(_idfsDiagnosis);
  dest.writeLong(_idfsSpeciesType);
  dest.writeLong(_idfsSampleType);
  dest.writeInt(bChanged ? 1 : 0);
}

protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException
{
serializer.attribute("", "lang", EidssUtils.getCurrentLanguage());
serializer.attribute("", "intChanged", String.valueOf(_intChanged));
  if (_idParent != 0)
      serializer.attribute("", "idParent", String.valueOf(_idParent));
  if (_idfMonitoringSession != 0)
      serializer.attribute("", "idfMonitoringSession", String.valueOf(_idfMonitoringSession));
  if (_idfCampaign != 0)
      serializer.attribute("", "idfCampaign", String.valueOf(_idfCampaign));
  if (_idfsDiagnosis != 0)
      serializer.attribute("", "idfsDiagnosis", String.valueOf(_idfsDiagnosis));
  if (_idfsSpeciesType != 0)
      serializer.attribute("", "idfsSpeciesType", String.valueOf(_idfsSpeciesType));
  if (_idfsSampleType != 0)
      serializer.attribute("", "idfsSampleType", String.valueOf(_idfsSampleType));
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "idParent", _idParent);
  EidssUtils.putToJson(ret, "idfMonitoringSession", _idfMonitoringSession);
  EidssUtils.putToJson(ret, "idfCampaign", _idfCampaign);
  EidssUtils.putToJson(ret, "idfsDiagnosis", _idfsDiagnosis);
  EidssUtils.putToJson(ret, "idfsSpeciesType", _idfsSpeciesType);
  EidssUtils.putToJson(ret, "idfsSampleType", _idfsSampleType);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _idParent = json.getLong("idParent");
  _idfMonitoringSession = json.getLong("idfMonitoringSession");
  _idfCampaign = json.getLong("idfCampaign");
  _idfsDiagnosis = json.getLong("idfsDiagnosis");
  _idfsSpeciesType = json.getLong("idfsSpeciesType");
  _idfsSampleType = json.getLong("idfsSampleType");
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _idParent = parser.getAttributeValue("", "idParent") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idParent"));
  _idfMonitoringSession = parser.getAttributeValue("", "idfMonitoringSession") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfMonitoringSession"));
  _idfCampaign = parser.getAttributeValue("", "idfCampaign") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfCampaign"));
  _idfsDiagnosis = parser.getAttributeValue("", "idfsDiagnosis") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsDiagnosis"));
  _idfsSpeciesType = parser.getAttributeValue("", "idfsSpeciesType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSpeciesType"));
  _idfsSampleType = parser.getAttributeValue("", "idfsSampleType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSampleType"));
}
}
