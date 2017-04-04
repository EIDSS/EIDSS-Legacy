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

public class VetCaseSample_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public VetCaseSample_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
    }
  public static String eidss_SampleType = "VetCaseSample.SampleType";
  public static String eidss_FieldBarcode = "VetCaseSample.FieldBarcode";
  public static String eidss_Animal = "strAnimalCode";
  public static String eidss_SpeciesType = "Species";
  public static String eidss_BirdStatus = "strBirdStatus";
  public static String eidss_FieldCollectionDate = "datFieldCollectionDate";
  public static String eidss_SendToOffice = "VetCaseSample.SentTo";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_SampleType, R.string.VetCaseSample_idfsSampleType, new ICallable<Long, VetCaseSample_object>() { public Long call(VetCaseSample_object t) { return t.getSampleType(); }}));
        add(new FieldMetadata(eidss_FieldBarcode, R.string.VetCaseSample_strFieldBarcode, new ICallable<String, VetCaseSample_object>() { public String call(VetCaseSample_object t) { return t.getFieldBarcode(); }}));
        add(new FieldMetadata(eidss_Animal, R.string.VetCaseSample_idfAnimal, new ICallable<Long, VetCaseSample_object>() { public Long call(VetCaseSample_object t) { return t.getAnimal(); }}));
        add(new FieldMetadata(eidss_SpeciesType, R.string.VetCaseSample_idfsSpeciesType, new ICallable<Long, VetCaseSample_object>() { public Long call(VetCaseSample_object t) { return t.getSpeciesType(); }}));
        add(new FieldMetadata(eidss_BirdStatus, R.string.VetCaseSample_idfsBirdStatus, new ICallable<Long, VetCaseSample_object>() { public Long call(VetCaseSample_object t) { return t.getBirdStatus(); }}));
        add(new FieldMetadata(eidss_FieldCollectionDate, R.string.VetCaseSample_datFieldCollectionDate, new ICallable<Date, VetCaseSample_object>() { public Date call(VetCaseSample_object t) { return t.getFieldCollectionDate(); }}));
        add(new FieldMetadata(eidss_SendToOffice, R.string.VetCaseSample_idfSendToOffice, new ICallable<Long, VetCaseSample_object>() { public Long call(VetCaseSample_object t) { return t.getSendToOffice(); }}));
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
  protected long _idfAnimal;
  public long getAnimal(){return _idfAnimal;}
   public void setAnimal(long value) { bChanged = bChanged || _idfAnimal != value; _intChanged = ((_intChanged == 1) || _idfAnimal != value) ? 1 : 0; if (_idfAnimal != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfAnimal", _idfAnimal, value); } _idfAnimal = value; }}
  protected long _idfsSpeciesType;
  public long getSpeciesType(){return _idfsSpeciesType;}
   public void setSpeciesType(long value) { bChanged = bChanged || _idfsSpeciesType != value; _intChanged = ((_intChanged == 1) || _idfsSpeciesType != value) ? 1 : 0; if (_idfsSpeciesType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSpeciesType", _idfsSpeciesType, value); } _idfsSpeciesType = value; }}
  protected long _idfsBirdStatus;
  public long getBirdStatus(){return _idfsBirdStatus;}
   public void setBirdStatus(long value) { bChanged = bChanged || _idfsBirdStatus != value; _intChanged = ((_intChanged == 1) || _idfsBirdStatus != value) ? 1 : 0; if (_idfsBirdStatus != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsBirdStatus", _idfsBirdStatus, value); } _idfsBirdStatus = value; }}
  protected Date _datFieldCollectionDate;
  public Date getFieldCollectionDate(){return _datFieldCollectionDate;}
   public void setFieldCollectionDate(Date value) { if(_datFieldCollectionDate == null && value == null) return; bChanged = bChanged || _datFieldCollectionDate == null || value == null || !_datFieldCollectionDate.equals(value); _intChanged = ((_intChanged == 1) || _datFieldCollectionDate == null || value == null || !_datFieldCollectionDate.equals(value)) ? 1 : 0; if (_datFieldCollectionDate == null || value == null || !_datFieldCollectionDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datFieldCollectionDate", _datFieldCollectionDate, value); } _datFieldCollectionDate = value; }}
  protected long _idfSendToOffice;
  public long getSendToOffice(){return _idfSendToOffice;}
   public void setSendToOffice(long value) { bChanged = bChanged || _idfSendToOffice != value; _intChanged = ((_intChanged == 1) || _idfSendToOffice != value) ? 1 : 0; if (_idfSendToOffice != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfSendToOffice", _idfSendToOffice, value); } _idfSendToOffice = value; }}

protected static VetCaseSample_object FromCursor(Cursor cursor, VetCaseSample_object ret)
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
  ret._idfAnimal = cursor.getLong(cursor.getColumnIndex("idfAnimal"));
  ret._idfsSpeciesType = cursor.getLong(cursor.getColumnIndex("idfsSpeciesType"));
  ret._idfsBirdStatus = cursor.getLong(cursor.getColumnIndex("idfsBirdStatus"));
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
  ret.put("idfMaterial", _idfMaterial);
  ret.put("idfsSampleType", _idfsSampleType);
  ret.put("strFieldBarcode", _strFieldBarcode);
  ret.put("idfAnimal", _idfAnimal);
  ret.put("idfsSpeciesType", _idfsSpeciesType);
  ret.put("idfsBirdStatus", _idfsBirdStatus);
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
  _idfMaterial = source.readLong();
  _idfsSampleType = source.readLong();
  _strFieldBarcode = source.readString();
  _idfAnimal = source.readLong();
  _idfsSpeciesType = source.readLong();
  _idfsBirdStatus = source.readLong();
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
  dest.writeLong(_idfMaterial);
  dest.writeLong(_idfsSampleType);
  dest.writeString(_strFieldBarcode);
  dest.writeLong(_idfAnimal);
  dest.writeLong(_idfsSpeciesType);
  dest.writeLong(_idfsBirdStatus);
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
  if (_idfMaterial != 0)
      serializer.attribute("", "idfMaterial", String.valueOf(_idfMaterial));
  if (_idfsSampleType != 0)
      serializer.attribute("", "idfsSampleType", String.valueOf(_idfsSampleType));
  if (_strFieldBarcode != null)
      serializer.attribute("", "strFieldBarcode", _strFieldBarcode);
  if (_idfAnimal != 0)
      serializer.attribute("", "idfAnimal", String.valueOf(_idfAnimal));
  if (_idfsSpeciesType != 0)
      serializer.attribute("", "idfsSpeciesType", String.valueOf(_idfsSpeciesType));
  if (_idfsBirdStatus != 0)
      serializer.attribute("", "idfsBirdStatus", String.valueOf(_idfsBirdStatus));
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
  EidssUtils.putToJson(ret, "idfMaterial", _idfMaterial);
  EidssUtils.putToJson(ret, "idfsSampleType", _idfsSampleType);
  EidssUtils.putToJson(ret, "strFieldBarcode", _strFieldBarcode);
  EidssUtils.putToJson(ret, "idfAnimal", _idfAnimal);
  EidssUtils.putToJson(ret, "idfsSpeciesType", _idfsSpeciesType);
  EidssUtils.putToJson(ret, "idfsBirdStatus", _idfsBirdStatus);
  EidssUtils.putToJson(ret, "datFieldCollectionDate", _datFieldCollectionDate);
  EidssUtils.putToJson(ret, "idfSendToOffice", _idfSendToOffice);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _uidOfflineCaseID = json.getString("uidOfflineCaseID");
  _idParent = json.getLong("idParent");
  _idfMaterial = json.getLong("idfMaterial");
  _idfsSampleType = json.getLong("idfsSampleType");
  _strFieldBarcode = json.getString("strFieldBarcode");
  _idfAnimal = json.getLong("idfAnimal");
  _idfsSpeciesType = json.getLong("idfsSpeciesType");
  _idfsBirdStatus = json.getLong("idfsBirdStatus");
  _datFieldCollectionDate = DateHelpers.ParseWithT(json.getString("datFieldCollectionDate"));
  _idfSendToOffice = json.getLong("idfSendToOffice");
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _uidOfflineCaseID = parser.getAttributeValue("", "uidOfflineCaseID");
  _idParent = parser.getAttributeValue("", "idParent") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idParent"));
  _idfMaterial = parser.getAttributeValue("", "idfMaterial") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfMaterial"));
  _idfsSampleType = parser.getAttributeValue("", "idfsSampleType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSampleType"));
  _strFieldBarcode = parser.getAttributeValue("", "strFieldBarcode");
  _idfAnimal = parser.getAttributeValue("", "idfAnimal") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfAnimal"));
  _idfsSpeciesType = parser.getAttributeValue("", "idfsSpeciesType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSpeciesType"));
  _idfsBirdStatus = parser.getAttributeValue("", "idfsBirdStatus") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsBirdStatus"));
  _datFieldCollectionDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datFieldCollectionDate"));
  _idfSendToOffice = parser.getAttributeValue("", "idfSendToOffice") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfSendToOffice"));
}
}
