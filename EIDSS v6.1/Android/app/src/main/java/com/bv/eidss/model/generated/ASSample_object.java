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

public class ASSample_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public ASSample_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
    }
  public static String eidss_Farm = "AsSession.Sample.Farm";
  public static String eidss_SpeciesType = "AsSession.Sample.Species";
  public static String eidss_Animal = "AsSession.Sample.AnimalCode";
  public static String eidss_AnimalAge = "AsSession.Sample.AnimalAge";
  public static String eidss_Color = "AsSession.Sample.AnimalColor";
  public static String eidss_AnimalGender = "AsSession.Sample.AnimalGender";
  public static String eidss_Name = "AsSession.Sample.AnimalName";
  public static String eidss_Description = "AsSession.Sample.AnimalComments";
  public static String eidss_SampleType = "AsSession.Sample.SampleType";
  public static String eidss_FieldBarcode = "AsSession.Sample.FieldBarcode";
  public static String eidss_FieldCollectionDate = "AsSession.Sample.FieldCollectionDate";
  public static String eidss_SendToOffice = "AsSession.Sample.SentTo";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_Farm, R.string.ASSample_idfFarm, new ICallable<Long, ASSample_object>() { public Long call(ASSample_object t) { return t.getFarm(); }}));
        add(new FieldMetadata(eidss_SpeciesType, R.string.ASSample_idfsSpeciesType, new ICallable<Long, ASSample_object>() { public Long call(ASSample_object t) { return t.getSpeciesType(); }}));
        add(new FieldMetadata(eidss_Animal, R.string.ASSample_idfAnimal, new ICallable<Long, ASSample_object>() { public Long call(ASSample_object t) { return t.getAnimal(); }}));
        add(new FieldMetadata(eidss_AnimalAge, R.string.ASSample_idfsAnimalAge, new ICallable<Long, ASSample_object>() { public Long call(ASSample_object t) { return t.getAnimalAge(); }}));
        add(new FieldMetadata(eidss_Color, R.string.ASSample_strColor, new ICallable<String, ASSample_object>() { public String call(ASSample_object t) { return t.getColor(); }}));
        add(new FieldMetadata(eidss_AnimalGender, R.string.ASSample_idfsAnimalGender, new ICallable<Long, ASSample_object>() { public Long call(ASSample_object t) { return t.getAnimalGender(); }}));
        add(new FieldMetadata(eidss_Name, R.string.ASSample_strName, new ICallable<String, ASSample_object>() { public String call(ASSample_object t) { return t.getName(); }}));
        add(new FieldMetadata(eidss_Description, R.string.ASSample_strDescription, new ICallable<String, ASSample_object>() { public String call(ASSample_object t) { return t.getDescription(); }}));
        add(new FieldMetadata(eidss_SampleType, R.string.ASSample_idfsSampleType, new ICallable<Long, ASSample_object>() { public Long call(ASSample_object t) { return t.getSampleType(); }}));
        add(new FieldMetadata(eidss_FieldBarcode, R.string.ASSample_strFieldBarcode, new ICallable<String, ASSample_object>() { public String call(ASSample_object t) { return t.getFieldBarcode(); }}));
        add(new FieldMetadata(eidss_FieldCollectionDate, R.string.ASSample_datFieldCollectionDate, new ICallable<Date, ASSample_object>() { public Date call(ASSample_object t) { return t.getFieldCollectionDate(); }}));
        add(new FieldMetadata(eidss_SendToOffice, R.string.ASSample_idfSendToOffice, new ICallable<Long, ASSample_object>() { public Long call(ASSample_object t) { return t.getSendToOffice(); }}));
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
  protected long _idfMonitoringSession;
  public long getMonitoringSession(){return _idfMonitoringSession;}
   public void setMonitoringSession(long value) { bChanged = bChanged || _idfMonitoringSession != value; _intChanged = ((_intChanged == 1) || _idfMonitoringSession != value) ? 1 : 0; if (_idfMonitoringSession != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfMonitoringSession", _idfMonitoringSession, value); } _idfMonitoringSession = value; }}
  protected long _idfFarm;
  public long getFarm(){return _idfFarm;}
   public void setFarm(long value) { bChanged = bChanged || _idfFarm != value; _intChanged = ((_intChanged == 1) || _idfFarm != value) ? 1 : 0; if (_idfFarm != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfFarm", _idfFarm, value); } _idfFarm = value; }}
  protected long _idfsSpeciesType;
  public long getSpeciesType(){return _idfsSpeciesType;}
   public void setSpeciesType(long value) { bChanged = bChanged || _idfsSpeciesType != value; _intChanged = ((_intChanged == 1) || _idfsSpeciesType != value) ? 1 : 0; if (_idfsSpeciesType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSpeciesType", _idfsSpeciesType, value); } _idfsSpeciesType = value; }}
  protected long _idfAnimal;
  public long getAnimal(){return _idfAnimal;}
   public void setAnimal(long value) { bChanged = bChanged || _idfAnimal != value; _intChanged = ((_intChanged == 1) || _idfAnimal != value) ? 1 : 0; if (_idfAnimal != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfAnimal", _idfAnimal, value); } _idfAnimal = value; }}
  protected String _strAnimalCode;
  public String getAnimalCode(){return _strAnimalCode;}
   public void setAnimalCode(String value) { if(_strAnimalCode == null && value == null) return; bChanged = bChanged || _strAnimalCode == null || value == null || !_strAnimalCode.equals(value); _intChanged = ((_intChanged == 1) || _strAnimalCode == null || value == null || !_strAnimalCode.equals(value)) ? 1 : 0; if (_strAnimalCode == null || value == null || !_strAnimalCode.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strAnimalCode", _strAnimalCode, value); } _strAnimalCode = value; }}
  protected long _idfsAnimalAge;
  public long getAnimalAge(){return _idfsAnimalAge;}
   public void setAnimalAge(long value) { bChanged = bChanged || _idfsAnimalAge != value; _intChanged = ((_intChanged == 1) || _idfsAnimalAge != value) ? 1 : 0; if (_idfsAnimalAge != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsAnimalAge", _idfsAnimalAge, value); } _idfsAnimalAge = value; }}
  protected String _strColor;
  public String getColor(){return _strColor;}
   public void setColor(String value) { if(_strColor == null && value == null) return; bChanged = bChanged || _strColor == null || value == null || !_strColor.equals(value); _intChanged = ((_intChanged == 1) || _strColor == null || value == null || !_strColor.equals(value)) ? 1 : 0; if (_strColor == null || value == null || !_strColor.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strColor", _strColor, value); } _strColor = value; }}
  protected long _idfsAnimalGender;
  public long getAnimalGender(){return _idfsAnimalGender;}
   public void setAnimalGender(long value) { bChanged = bChanged || _idfsAnimalGender != value; _intChanged = ((_intChanged == 1) || _idfsAnimalGender != value) ? 1 : 0; if (_idfsAnimalGender != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsAnimalGender", _idfsAnimalGender, value); } _idfsAnimalGender = value; }}
  protected String _strName;
  public String getName(){return _strName;}
   public void setName(String value) { if(_strName == null && value == null) return; bChanged = bChanged || _strName == null || value == null || !_strName.equals(value); _intChanged = ((_intChanged == 1) || _strName == null || value == null || !_strName.equals(value)) ? 1 : 0; if (_strName == null || value == null || !_strName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strName", _strName, value); } _strName = value; }}
  protected String _strDescription;
  public String getDescription(){return _strDescription;}
   public void setDescription(String value) { if(_strDescription == null && value == null) return; bChanged = bChanged || _strDescription == null || value == null || !_strDescription.equals(value); _intChanged = ((_intChanged == 1) || _strDescription == null || value == null || !_strDescription.equals(value)) ? 1 : 0; if (_strDescription == null || value == null || !_strDescription.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strDescription", _strDescription, value); } _strDescription = value; }}
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

protected static ASSample_object FromCursor(Cursor cursor, ASSample_object ret)
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
  ret._idfMonitoringSession = cursor.getLong(cursor.getColumnIndex("idfMonitoringSession"));
  ret._idfFarm = cursor.getLong(cursor.getColumnIndex("idfFarm"));
  ret._idfsSpeciesType = cursor.getLong(cursor.getColumnIndex("idfsSpeciesType"));
  ret._idfAnimal = cursor.getLong(cursor.getColumnIndex("idfAnimal"));
  ret._strAnimalCode = cursor.getString(cursor.getColumnIndex("strAnimalCode"));
  ret._idfsAnimalAge = cursor.getLong(cursor.getColumnIndex("idfsAnimalAge"));
  ret._strColor = cursor.getString(cursor.getColumnIndex("strColor"));
  ret._idfsAnimalGender = cursor.getLong(cursor.getColumnIndex("idfsAnimalGender"));
  ret._strName = cursor.getString(cursor.getColumnIndex("strName"));
  ret._strDescription = cursor.getString(cursor.getColumnIndex("strDescription"));
  ret._idfMaterial = cursor.getLong(cursor.getColumnIndex("idfMaterial"));
  ret._idfsSampleType = cursor.getLong(cursor.getColumnIndex("idfsSampleType"));
  ret._strFieldBarcode = cursor.getString(cursor.getColumnIndex("strFieldBarcode"));
  ret._datFieldCollectionDate = EidssUtils.ParseDate(cursor, formatterDate, "datFieldCollectionDate");
  ret._idfSendToOffice = cursor.getLong(cursor.getColumnIndex("idfSendToOffice"));
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
  ret.put("idfMonitoringSession", _idfMonitoringSession);
  ret.put("idfFarm", _idfFarm);
  ret.put("idfsSpeciesType", _idfsSpeciesType);
  ret.put("idfAnimal", _idfAnimal);
  ret.put("strAnimalCode", _strAnimalCode);
  ret.put("idfsAnimalAge", _idfsAnimalAge);
  ret.put("strColor", _strColor);
  ret.put("idfsAnimalGender", _idfsAnimalGender);
  ret.put("strName", _strName);
  ret.put("strDescription", _strDescription);
  ret.put("idfMaterial", _idfMaterial);
  ret.put("idfsSampleType", _idfsSampleType);
  ret.put("strFieldBarcode", _strFieldBarcode);
    strDate = null;
  if (_datFieldCollectionDate != null)
      strDate = formatterDate.format(_datFieldCollectionDate);
  ret.put("datFieldCollectionDate", strDate);
  ret.put("idfSendToOffice", _idfSendToOffice);

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
  _idfMonitoringSession = source.readLong();
  _idfFarm = source.readLong();
  _idfsSpeciesType = source.readLong();
  _idfAnimal = source.readLong();
  _strAnimalCode = source.readString();
  _idfsAnimalAge = source.readLong();
  _strColor = source.readString();
  _idfsAnimalGender = source.readLong();
  _strName = source.readString();
  _strDescription = source.readString();
  _idfMaterial = source.readLong();
  _idfsSampleType = source.readLong();
  _strFieldBarcode = source.readString();
  _datFieldCollectionDate = (Date)source.readSerializable();
  _idfSendToOffice = source.readLong();
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
  dest.writeLong(_idfMonitoringSession);
  dest.writeLong(_idfFarm);
  dest.writeLong(_idfsSpeciesType);
  dest.writeLong(_idfAnimal);
  dest.writeString(_strAnimalCode);
  dest.writeLong(_idfsAnimalAge);
  dest.writeString(_strColor);
  dest.writeLong(_idfsAnimalGender);
  dest.writeString(_strName);
  dest.writeString(_strDescription);
  dest.writeLong(_idfMaterial);
  dest.writeLong(_idfsSampleType);
  dest.writeString(_strFieldBarcode);
  dest.writeSerializable(_datFieldCollectionDate);
  dest.writeLong(_idfSendToOffice);
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
  if (_idfMonitoringSession != 0)
      serializer.attribute("", "idfMonitoringSession", String.valueOf(_idfMonitoringSession));
  if (_idfFarm != 0)
      serializer.attribute("", "idfFarm", String.valueOf(_idfFarm));
  if (_idfsSpeciesType != 0)
      serializer.attribute("", "idfsSpeciesType", String.valueOf(_idfsSpeciesType));
  if (_idfAnimal != 0)
      serializer.attribute("", "idfAnimal", String.valueOf(_idfAnimal));
  if (_strAnimalCode != null)
      serializer.attribute("", "strAnimalCode", _strAnimalCode);
  if (_idfsAnimalAge != 0)
      serializer.attribute("", "idfsAnimalAge", String.valueOf(_idfsAnimalAge));
  if (_strColor != null)
      serializer.attribute("", "strColor", _strColor);
  if (_idfsAnimalGender != 0)
      serializer.attribute("", "idfsAnimalGender", String.valueOf(_idfsAnimalGender));
  if (_strName != null)
      serializer.attribute("", "strName", _strName);
  if (_strDescription != null)
      serializer.attribute("", "strDescription", _strDescription);
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
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "uidOfflineCaseID", _uidOfflineCaseID);
  EidssUtils.putToJson(ret, "idParent", _idParent);
  EidssUtils.putToJson(ret, "idfMonitoringSession", _idfMonitoringSession);
  EidssUtils.putToJson(ret, "idfFarm", _idfFarm);
  EidssUtils.putToJson(ret, "idfsSpeciesType", _idfsSpeciesType);
  EidssUtils.putToJson(ret, "idfAnimal", _idfAnimal);
  EidssUtils.putToJson(ret, "strAnimalCode", _strAnimalCode);
  EidssUtils.putToJson(ret, "idfsAnimalAge", _idfsAnimalAge);
  EidssUtils.putToJson(ret, "strColor", _strColor);
  EidssUtils.putToJson(ret, "idfsAnimalGender", _idfsAnimalGender);
  EidssUtils.putToJson(ret, "strName", _strName);
  EidssUtils.putToJson(ret, "strDescription", _strDescription);
  EidssUtils.putToJson(ret, "idfMaterial", _idfMaterial);
  EidssUtils.putToJson(ret, "idfsSampleType", _idfsSampleType);
  EidssUtils.putToJson(ret, "strFieldBarcode", _strFieldBarcode);
  EidssUtils.putToJson(ret, "datFieldCollectionDate", _datFieldCollectionDate);
  EidssUtils.putToJson(ret, "idfSendToOffice", _idfSendToOffice);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _uidOfflineCaseID = json.getString("uidOfflineCaseID");
  _idParent = json.getLong("idParent");
  _idfMonitoringSession = json.getLong("idfMonitoringSession");
  _idfFarm = json.getLong("idfFarm");
  _idfsSpeciesType = json.getLong("idfsSpeciesType");
  _idfAnimal = json.getLong("idfAnimal");
  _strAnimalCode = json.getString("strAnimalCode");
  _idfsAnimalAge = json.getLong("idfsAnimalAge");
  _strColor = json.getString("strColor");
  _idfsAnimalGender = json.getLong("idfsAnimalGender");
  _strName = json.getString("strName");
  _strDescription = json.getString("strDescription");
  _idfMaterial = json.getLong("idfMaterial");
  _idfsSampleType = json.getLong("idfsSampleType");
  _strFieldBarcode = json.getString("strFieldBarcode");
  _datFieldCollectionDate = DateHelpers.ParseWithT(json.getString("datFieldCollectionDate"));
  _idfSendToOffice = json.getLong("idfSendToOffice");
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _uidOfflineCaseID = parser.getAttributeValue("", "uidOfflineCaseID");
  _idParent = parser.getAttributeValue("", "idParent") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idParent"));
  _idfMonitoringSession = parser.getAttributeValue("", "idfMonitoringSession") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfMonitoringSession"));
  _idfFarm = parser.getAttributeValue("", "idfFarm") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfFarm"));
  _idfsSpeciesType = parser.getAttributeValue("", "idfsSpeciesType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSpeciesType"));
  _idfAnimal = parser.getAttributeValue("", "idfAnimal") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfAnimal"));
  _strAnimalCode = parser.getAttributeValue("", "strAnimalCode");
  _idfsAnimalAge = parser.getAttributeValue("", "idfsAnimalAge") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsAnimalAge"));
  _strColor = parser.getAttributeValue("", "strColor");
  _idfsAnimalGender = parser.getAttributeValue("", "idfsAnimalGender") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsAnimalGender"));
  _strName = parser.getAttributeValue("", "strName");
  _strDescription = parser.getAttributeValue("", "strDescription");
  _idfMaterial = parser.getAttributeValue("", "idfMaterial") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfMaterial"));
  _idfsSampleType = parser.getAttributeValue("", "idfsSampleType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSampleType"));
  _strFieldBarcode = parser.getAttributeValue("", "strFieldBarcode");
  _datFieldCollectionDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datFieldCollectionDate"));
  _idfSendToOffice = parser.getAttributeValue("", "idfSendToOffice") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfSendToOffice"));
}
}
