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

public class Animal_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public Animal_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
    }
  public static String eidss_SpeciesType = "Animal.SpeciesType";
  public static String eidss_AnimalCode = "strAnimalCode";
  public static String eidss_AnimalAge = "strAnimalAge";
  public static String eidss_AnimalGender = "strAnimalGender";
  public static String eidss_AnimalCondition = "strAnimalCondition";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_SpeciesType, R.string.Animal_idfsSpeciesType, new ICallable<Long, Animal_object>() { public Long call(Animal_object t) { return t.getSpeciesType(); }}));
        add(new FieldMetadata(eidss_AnimalCode, R.string.Animal_strAnimalCode, new ICallable<String, Animal_object>() { public String call(Animal_object t) { return t.getAnimalCode(); }}));
        add(new FieldMetadata(eidss_AnimalAge, R.string.Animal_idfsAnimalAge, new ICallable<Long, Animal_object>() { public Long call(Animal_object t) { return t.getAnimalAge(); }}));
        add(new FieldMetadata(eidss_AnimalGender, R.string.Animal_idfsAnimalGender, new ICallable<Long, Animal_object>() { public Long call(Animal_object t) { return t.getAnimalGender(); }}));
        add(new FieldMetadata(eidss_AnimalCondition, R.string.Animal_idfsAnimalCondition, new ICallable<Long, Animal_object>() { public Long call(Animal_object t) { return t.getAnimalCondition(); }}));
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
  protected long _idfHerd;
  public long getHerd(){return _idfHerd;}
   public void setHerd(long value) { bChanged = bChanged || _idfHerd != value; _intChanged = ((_intChanged == 1) || _idfHerd != value) ? 1 : 0; if (_idfHerd != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfHerd", _idfHerd, value); } _idfHerd = value; }}
  protected long _idfAnimal;
  public long getAnimal(){return _idfAnimal;}
   public void setAnimal(long value) { bChanged = bChanged || _idfAnimal != value; _intChanged = ((_intChanged == 1) || _idfAnimal != value) ? 1 : 0; if (_idfAnimal != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfAnimal", _idfAnimal, value); } _idfAnimal = value; }}
  protected long _idfsSpeciesType;
  public long getSpeciesType(){return _idfsSpeciesType;}
   public void setSpeciesType(long value) { bChanged = bChanged || _idfsSpeciesType != value; _intChanged = ((_intChanged == 1) || _idfsSpeciesType != value) ? 1 : 0; if (_idfsSpeciesType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSpeciesType", _idfsSpeciesType, value); } _idfsSpeciesType = value; }}
  protected String _strAnimalCode;
  public String getAnimalCode(){return _strAnimalCode;}
   public void setAnimalCode(String value) { if(_strAnimalCode == null && value == null) return; bChanged = bChanged || _strAnimalCode == null || value == null || !_strAnimalCode.equals(value); _intChanged = ((_intChanged == 1) || _strAnimalCode == null || value == null || !_strAnimalCode.equals(value)) ? 1 : 0; if (_strAnimalCode == null || value == null || !_strAnimalCode.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strAnimalCode", _strAnimalCode, value); } _strAnimalCode = value; }}
  protected long _idfsAnimalAge;
  public long getAnimalAge(){return _idfsAnimalAge;}
   public void setAnimalAge(long value) { bChanged = bChanged || _idfsAnimalAge != value; _intChanged = ((_intChanged == 1) || _idfsAnimalAge != value) ? 1 : 0; if (_idfsAnimalAge != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsAnimalAge", _idfsAnimalAge, value); } _idfsAnimalAge = value; }}
  protected long _idfsAnimalGender;
  public long getAnimalGender(){return _idfsAnimalGender;}
   public void setAnimalGender(long value) { bChanged = bChanged || _idfsAnimalGender != value; _intChanged = ((_intChanged == 1) || _idfsAnimalGender != value) ? 1 : 0; if (_idfsAnimalGender != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsAnimalGender", _idfsAnimalGender, value); } _idfsAnimalGender = value; }}
  protected long _idfsAnimalCondition;
  public long getAnimalCondition(){return _idfsAnimalCondition;}
   public void setAnimalCondition(long value) { bChanged = bChanged || _idfsAnimalCondition != value; _intChanged = ((_intChanged == 1) || _idfsAnimalCondition != value) ? 1 : 0; if (_idfsAnimalCondition != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsAnimalCondition", _idfsAnimalCondition, value); } _idfsAnimalCondition = value; }}
  protected long _idfObservation;
  public long getObservation(){return _idfObservation;}
   public void setObservation(long value) { bChanged = bChanged || _idfObservation != value; _intChanged = ((_intChanged == 1) || _idfObservation != value) ? 1 : 0; if (_idfObservation != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfObservation", _idfObservation, value); } _idfObservation = value; }}

protected static Animal_object FromCursor(Cursor cursor, Animal_object ret)
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
  ret._idfHerd = cursor.getLong(cursor.getColumnIndex("idfHerd"));
  ret._idfAnimal = cursor.getLong(cursor.getColumnIndex("idfAnimal"));
  ret._idfsSpeciesType = cursor.getLong(cursor.getColumnIndex("idfsSpeciesType"));
  ret._strAnimalCode = cursor.getString(cursor.getColumnIndex("strAnimalCode"));
  ret._idfsAnimalAge = cursor.getLong(cursor.getColumnIndex("idfsAnimalAge"));
  ret._idfsAnimalGender = cursor.getLong(cursor.getColumnIndex("idfsAnimalGender"));
  ret._idfsAnimalCondition = cursor.getLong(cursor.getColumnIndex("idfsAnimalCondition"));
  ret._idfObservation = cursor.getLong(cursor.getColumnIndex("idfObservation"));
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
  ret.put("idfHerd", _idfHerd);
  ret.put("idfAnimal", _idfAnimal);
  ret.put("idfsSpeciesType", _idfsSpeciesType);
  ret.put("strAnimalCode", _strAnimalCode);
  ret.put("idfsAnimalAge", _idfsAnimalAge);
  ret.put("idfsAnimalGender", _idfsAnimalGender);
  ret.put("idfsAnimalCondition", _idfsAnimalCondition);
  ret.put("idfObservation", _idfObservation);

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
  _idfHerd = source.readLong();
  _idfAnimal = source.readLong();
  _idfsSpeciesType = source.readLong();
  _strAnimalCode = source.readString();
  _idfsAnimalAge = source.readLong();
  _idfsAnimalGender = source.readLong();
  _idfsAnimalCondition = source.readLong();
  _idfObservation = source.readLong();
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
  dest.writeLong(_idfHerd);
  dest.writeLong(_idfAnimal);
  dest.writeLong(_idfsSpeciesType);
  dest.writeString(_strAnimalCode);
  dest.writeLong(_idfsAnimalAge);
  dest.writeLong(_idfsAnimalGender);
  dest.writeLong(_idfsAnimalCondition);
  dest.writeLong(_idfObservation);
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
  if (_idfHerd != 0)
      serializer.attribute("", "idfHerd", String.valueOf(_idfHerd));
  if (_idfAnimal != 0)
      serializer.attribute("", "idfAnimal", String.valueOf(_idfAnimal));
  if (_idfsSpeciesType != 0)
      serializer.attribute("", "idfsSpeciesType", String.valueOf(_idfsSpeciesType));
  if (_strAnimalCode != null)
      serializer.attribute("", "strAnimalCode", _strAnimalCode);
  if (_idfsAnimalAge != 0)
      serializer.attribute("", "idfsAnimalAge", String.valueOf(_idfsAnimalAge));
  if (_idfsAnimalGender != 0)
      serializer.attribute("", "idfsAnimalGender", String.valueOf(_idfsAnimalGender));
  if (_idfsAnimalCondition != 0)
      serializer.attribute("", "idfsAnimalCondition", String.valueOf(_idfsAnimalCondition));
  if (_idfObservation != 0)
      serializer.attribute("", "idfObservation", String.valueOf(_idfObservation));
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "uidOfflineCaseID", _uidOfflineCaseID);
  EidssUtils.putToJson(ret, "idParent", _idParent);
  EidssUtils.putToJson(ret, "idfHerd", _idfHerd);
  EidssUtils.putToJson(ret, "idfAnimal", _idfAnimal);
  EidssUtils.putToJson(ret, "idfsSpeciesType", _idfsSpeciesType);
  EidssUtils.putToJson(ret, "strAnimalCode", _strAnimalCode);
  EidssUtils.putToJson(ret, "idfsAnimalAge", _idfsAnimalAge);
  EidssUtils.putToJson(ret, "idfsAnimalGender", _idfsAnimalGender);
  EidssUtils.putToJson(ret, "idfsAnimalCondition", _idfsAnimalCondition);
  EidssUtils.putToJson(ret, "idfObservation", _idfObservation);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _uidOfflineCaseID = json.getString("uidOfflineCaseID");
  _idParent = json.getLong("idParent");
  _idfHerd = json.getLong("idfHerd");
  _idfAnimal = json.getLong("idfAnimal");
  _idfsSpeciesType = json.getLong("idfsSpeciesType");
  _strAnimalCode = json.getString("strAnimalCode");
  _idfsAnimalAge = json.getLong("idfsAnimalAge");
  _idfsAnimalGender = json.getLong("idfsAnimalGender");
  _idfsAnimalCondition = json.getLong("idfsAnimalCondition");
  _idfObservation = json.getLong("idfObservation");
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _uidOfflineCaseID = parser.getAttributeValue("", "uidOfflineCaseID");
  _idParent = parser.getAttributeValue("", "idParent") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idParent"));
  _idfHerd = parser.getAttributeValue("", "idfHerd") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfHerd"));
  _idfAnimal = parser.getAttributeValue("", "idfAnimal") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfAnimal"));
  _idfsSpeciesType = parser.getAttributeValue("", "idfsSpeciesType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSpeciesType"));
  _strAnimalCode = parser.getAttributeValue("", "strAnimalCode");
  _idfsAnimalAge = parser.getAttributeValue("", "idfsAnimalAge") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsAnimalAge"));
  _idfsAnimalGender = parser.getAttributeValue("", "idfsAnimalGender") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsAnimalGender"));
  _idfsAnimalCondition = parser.getAttributeValue("", "idfsAnimalCondition") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsAnimalCondition"));
  _idfObservation = parser.getAttributeValue("", "idfObservation") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfObservation"));
}
}
