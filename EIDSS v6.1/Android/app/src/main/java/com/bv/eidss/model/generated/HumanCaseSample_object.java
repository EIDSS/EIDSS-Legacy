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

public class HumanCaseSample_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public HumanCaseSample_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
    }
  public static String eidss_SampleType = "HumanCaseSample.SampleType";
  public static String eidss_FieldBarcode = "HumanCaseSample.FieldBarcode";
  public static String eidss_FieldCollectionDate = "HumanCaseSample.CollectionDate";
  public static String eidss_SendToOffice = "HumanCaseSample.SentTo";
  public static String eidss_FieldSentDate = "HumanCaseSample.SentDate";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_SampleType, R.string.HumanCaseSample_idfsSampleType, new ICallable<Long, HumanCaseSample_object>() { public Long call(HumanCaseSample_object t) { return t.getSampleType(); }}));
        add(new FieldMetadata(eidss_FieldBarcode, R.string.HumanCaseSample_strFieldBarcode, new ICallable<String, HumanCaseSample_object>() { public String call(HumanCaseSample_object t) { return t.getFieldBarcode(); }}));
        add(new FieldMetadata(eidss_FieldCollectionDate, R.string.HumanCaseSample_datFieldCollectionDate, new ICallable<Date, HumanCaseSample_object>() { public Date call(HumanCaseSample_object t) { return t.getFieldCollectionDate(); }}));
        add(new FieldMetadata(eidss_SendToOffice, R.string.HumanCaseSample_idfSendToOffice, new ICallable<Long, HumanCaseSample_object>() { public Long call(HumanCaseSample_object t) { return t.getSendToOffice(); }}));
        add(new FieldMetadata(eidss_FieldSentDate, R.string.HumanCaseSample_datFieldSentDate, new ICallable<Date, HumanCaseSample_object>() { public Date call(HumanCaseSample_object t) { return t.getFieldSentDate(); }}));
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
  protected long _idParent;
  public long getParent(){return _idParent;}
   public void setParent(long value) { bChanged = bChanged || _idParent != value; _intChanged = ((_intChanged == 1) || _idParent != value) ? 1 : 0; if (_idParent != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idParent", _idParent, value); } _idParent = value; }}
  protected long _idfMaterial;
  public long getMaterial(){return _idfMaterial;}
   public void setMaterial(long value) { bChanged = bChanged || _idfMaterial != value; _intChanged = ((_intChanged == 1) || _idfMaterial != value) ? 1 : 0; if (_idfMaterial != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfMaterial", _idfMaterial, value); } _idfMaterial = value; }}
  protected long _idfsSampleType;
  public long getSampleType(){return _idfsSampleType;}
   public void setSampleType(long value) { bChanged = bChanged || _idfsSampleType != value; _intChanged = ((_intChanged == 1) || _idfsSampleType != value) ? 1 : 0; if (_idfsSampleType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSampleType", _idfsSampleType, value); } _idfsSampleType = value; }}
  protected String _strFieldBarcode;
  public String getFieldBarcode(){return _strFieldBarcode;}
   public void setFieldBarcode(String value) { if(_strFieldBarcode == null && value == null) return; bChanged = bChanged || _strFieldBarcode == null || value == null || !_strFieldBarcode.equals(value); _intChanged = ((_intChanged == 1) || _strFieldBarcode == null || value == null || !_strFieldBarcode.equals(value)) ? 1 : 0; if (_strFieldBarcode == null || value == null || !_strFieldBarcode.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strFieldBarcode", _strFieldBarcode, value); } _strFieldBarcode = value; }}
  protected Date _datFieldCollectionDate;
  public Date getFieldCollectionDate(){return _datFieldCollectionDate;}
   public void setFieldCollectionDate(Date value) { if(_datFieldCollectionDate == null && value == null) return; bChanged = bChanged || _datFieldCollectionDate == null || value == null || !_datFieldCollectionDate.equals(value); _intChanged = ((_intChanged == 1) || _datFieldCollectionDate == null || value == null || !_datFieldCollectionDate.equals(value)) ? 1 : 0; if (_datFieldCollectionDate == null || value == null || !_datFieldCollectionDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datFieldCollectionDate", _datFieldCollectionDate, value); } _datFieldCollectionDate = value; }}
  protected long _idfSendToOffice;
  public long getSendToOffice(){return _idfSendToOffice;}
   public void setSendToOffice(long value) { bChanged = bChanged || _idfSendToOffice != value; _intChanged = ((_intChanged == 1) || _idfSendToOffice != value) ? 1 : 0; if (_idfSendToOffice != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfSendToOffice", _idfSendToOffice, value); } _idfSendToOffice = value; }}
  protected Date _datFieldSentDate;
  public Date getFieldSentDate(){return _datFieldSentDate;}
   public void setFieldSentDate(Date value) { if(_datFieldSentDate == null && value == null) return; bChanged = bChanged || _datFieldSentDate == null || value == null || !_datFieldSentDate.equals(value); _intChanged = ((_intChanged == 1) || _datFieldSentDate == null || value == null || !_datFieldSentDate.equals(value)) ? 1 : 0; if (_datFieldSentDate == null || value == null || !_datFieldSentDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datFieldSentDate", _datFieldSentDate, value); } _datFieldSentDate = value; }}

protected static HumanCaseSample_object FromCursor(Cursor cursor, HumanCaseSample_object ret)
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
  ret._idParent = cursor.getLong(cursor.getColumnIndex("idParent"));
  ret._idfMaterial = cursor.getLong(cursor.getColumnIndex("idfMaterial"));
  ret._idfsSampleType = cursor.getLong(cursor.getColumnIndex("idfsSampleType"));
  ret._strFieldBarcode = cursor.getString(cursor.getColumnIndex("strFieldBarcode"));
  ret._datFieldCollectionDate = EidssUtils.ParseDate(cursor, formatterDate, "datFieldCollectionDate");
  ret._idfSendToOffice = cursor.getLong(cursor.getColumnIndex("idfSendToOffice"));
  ret._datFieldSentDate = EidssUtils.ParseDate(cursor, formatterDate, "datFieldSentDate");
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
  ret.put("idParent", _idParent);
  ret.put("idfMaterial", _idfMaterial);
  ret.put("idfsSampleType", _idfsSampleType);
  ret.put("strFieldBarcode", _strFieldBarcode);
    strDate = null;
  if (_datFieldCollectionDate != null)
      strDate = formatterDate.format(_datFieldCollectionDate);
  ret.put("datFieldCollectionDate", strDate);
  ret.put("idfSendToOffice", _idfSendToOffice);
    strDate = null;
  if (_datFieldSentDate != null)
      strDate = formatterDate.format(_datFieldSentDate);
  ret.put("datFieldSentDate", strDate);

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
  _idParent = source.readLong();
  _idfMaterial = source.readLong();
  _idfsSampleType = source.readLong();
  _strFieldBarcode = source.readString();
  _datFieldCollectionDate = (Date)source.readSerializable();
  _idfSendToOffice = source.readLong();
  _datFieldSentDate = (Date)source.readSerializable();
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
  dest.writeLong(_idParent);
  dest.writeLong(_idfMaterial);
  dest.writeLong(_idfsSampleType);
  dest.writeString(_strFieldBarcode);
  dest.writeSerializable(_datFieldCollectionDate);
  dest.writeLong(_idfSendToOffice);
  dest.writeSerializable(_datFieldSentDate);
  dest.writeInt(bChanged ? 1 : 0);
}

protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException
{
serializer.attribute("", "lang", EidssUtils.getCurrentLanguage());
serializer.attribute("", "intChanged", String.valueOf(_intChanged));
  if (_uidOfflineCaseID != null)
      serializer.attribute("", "uidOfflineCaseID", _uidOfflineCaseID);
  if (_idParent != 0)
      serializer.attribute("", "idParent", String.valueOf(_idParent));
  if (_idfMaterial != 0)
      serializer.attribute("", "idfMaterial", String.valueOf(_idfMaterial));
  if (_idfsSampleType != 0)
      serializer.attribute("", "idfsSampleType", String.valueOf(_idfsSampleType));
  if (_strFieldBarcode != null)
      serializer.attribute("", "strFieldBarcode", _strFieldBarcode);
  if (_datFieldCollectionDate != null)
      serializer.attribute("", "datFieldCollectionDate", DateHelpers.FormatWithT(_datFieldCollectionDate));
  if (_idfSendToOffice != 0)
      serializer.attribute("", "idfSendToOffice", String.valueOf(_idfSendToOffice));
  if (_datFieldSentDate != null)
      serializer.attribute("", "datFieldSentDate", DateHelpers.FormatWithT(_datFieldSentDate));
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "uidOfflineCaseID", _uidOfflineCaseID);
  EidssUtils.putToJson(ret, "idParent", _idParent);
  EidssUtils.putToJson(ret, "idfMaterial", _idfMaterial);
  EidssUtils.putToJson(ret, "idfsSampleType", _idfsSampleType);
  EidssUtils.putToJson(ret, "strFieldBarcode", _strFieldBarcode);
  EidssUtils.putToJson(ret, "datFieldCollectionDate", _datFieldCollectionDate);
  EidssUtils.putToJson(ret, "idfSendToOffice", _idfSendToOffice);
  EidssUtils.putToJson(ret, "datFieldSentDate", _datFieldSentDate);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _uidOfflineCaseID = json.getString("uidOfflineCaseID");
  _idParent = json.getLong("idParent");
  _idfMaterial = json.getLong("idfMaterial");
  _idfsSampleType = json.getLong("idfsSampleType");
  _strFieldBarcode = json.getString("strFieldBarcode");
  _datFieldCollectionDate = DateHelpers.ParseWithT(json.getString("datFieldCollectionDate"));
  _idfSendToOffice = json.getLong("idfSendToOffice");
  _datFieldSentDate = DateHelpers.ParseWithT(json.getString("datFieldSentDate"));
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _uidOfflineCaseID = parser.getAttributeValue("", "uidOfflineCaseID");
  _idParent = parser.getAttributeValue("", "idParent") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idParent"));
  _idfMaterial = parser.getAttributeValue("", "idfMaterial") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfMaterial"));
  _idfsSampleType = parser.getAttributeValue("", "idfsSampleType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSampleType"));
  _strFieldBarcode = parser.getAttributeValue("", "strFieldBarcode");
  _datFieldCollectionDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datFieldCollectionDate"));
  _idfSendToOffice = parser.getAttributeValue("", "idfSendToOffice") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfSendToOffice"));
  _datFieldSentDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datFieldSentDate"));
}
}
