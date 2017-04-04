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

public class Species_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public Species_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
    }
  public static String eidss_SpeciesType = "VetCase.Species.SpeciesType";
  public static String eidss_TotalAnimalQty = "VetCase.Species.Total";
  public static String eidss_DeadAnimalQty = "VetCase.Species.Dead";
  public static String eidss_SickAnimalQty = "VetCase.Species.Sick";
  public static String eidss_Note = "VetCase.Species.strNote";
  public static String eidss_AverageAge = "VetCase.Species.strAverageAge";
  public static String eidss_StartOfSignsDate = "VetCase.Species.StartOfSign";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_SpeciesType, R.string.Species_idfsSpeciesType, new ICallable<Long, Species_object>() { public Long call(Species_object t) { return t.getSpeciesType(); }}));
        add(new FieldMetadata(eidss_TotalAnimalQty, R.string.Species_intTotalAnimalQty, new ICallable<Integer, Species_object>() { public Integer call(Species_object t) { return t.getTotalAnimalQty(); }}));
        add(new FieldMetadata(eidss_DeadAnimalQty, R.string.Species_intDeadAnimalQty, new ICallable<Integer, Species_object>() { public Integer call(Species_object t) { return t.getDeadAnimalQty(); }}));
        add(new FieldMetadata(eidss_SickAnimalQty, R.string.Species_intSickAnimalQty, new ICallable<Integer, Species_object>() { public Integer call(Species_object t) { return t.getSickAnimalQty(); }}));
        add(new FieldMetadata(eidss_Note, R.string.Species_strNote, new ICallable<String, Species_object>() { public String call(Species_object t) { return t.getNote(); }}));
        add(new FieldMetadata(eidss_AverageAge, R.string.Species_intAverageAge, new ICallable<Integer, Species_object>() { public Integer call(Species_object t) { return t.getAverageAge(); }}));
        add(new FieldMetadata(eidss_StartOfSignsDate, R.string.Species_datStartOfSignsDate, new ICallable<Date, Species_object>() { public Date call(Species_object t) { return t.getStartOfSignsDate(); }}));
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
  protected long _idfsFormTemplate;
  public long getFormTemplate(){return _idfsFormTemplate;}
   public void setFormTemplate(long value) { bChanged = bChanged || _idfsFormTemplate != value; _intChanged = ((_intChanged == 1) || _idfsFormTemplate != value) ? 1 : 0; if (_idfsFormTemplate != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsFormTemplate", _idfsFormTemplate, value); } _idfsFormTemplate = value; }}
  protected long _idfObservation;
  public long getObservation(){return _idfObservation;}
   public void setObservation(long value) { bChanged = bChanged || _idfObservation != value; _intChanged = ((_intChanged == 1) || _idfObservation != value) ? 1 : 0; if (_idfObservation != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfObservation", _idfObservation, value); } _idfObservation = value; }}
  protected long _idfsSpeciesType;
  public long getSpeciesType(){return _idfsSpeciesType;}
   public void setSpeciesType(long value) { bChanged = bChanged || _idfsSpeciesType != value; _intChanged = ((_intChanged == 1) || _idfsSpeciesType != value) ? 1 : 0; if (_idfsSpeciesType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSpeciesType", _idfsSpeciesType, value); } _idfsSpeciesType = value; }}
  protected int _intTotalAnimalQty;
  public int getTotalAnimalQty(){return _intTotalAnimalQty;}
   public void setTotalAnimalQty(int value) { bChanged = bChanged || _intTotalAnimalQty != value; _intChanged = ((_intChanged == 1) || _intTotalAnimalQty != value) ? 1 : 0; if (_intTotalAnimalQty != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("intTotalAnimalQty", _intTotalAnimalQty, value); } _intTotalAnimalQty = value; }}
  protected int _intDeadAnimalQty;
  public int getDeadAnimalQty(){return _intDeadAnimalQty;}
   public void setDeadAnimalQty(int value) { bChanged = bChanged || _intDeadAnimalQty != value; _intChanged = ((_intChanged == 1) || _intDeadAnimalQty != value) ? 1 : 0; if (_intDeadAnimalQty != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("intDeadAnimalQty", _intDeadAnimalQty, value); } _intDeadAnimalQty = value; }}
  protected int _intSickAnimalQty;
  public int getSickAnimalQty(){return _intSickAnimalQty;}
   public void setSickAnimalQty(int value) { bChanged = bChanged || _intSickAnimalQty != value; _intChanged = ((_intChanged == 1) || _intSickAnimalQty != value) ? 1 : 0; if (_intSickAnimalQty != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("intSickAnimalQty", _intSickAnimalQty, value); } _intSickAnimalQty = value; }}
  protected String _strNote;
  public String getNote(){return _strNote;}
   public void setNote(String value) { if(_strNote == null && value == null) return; bChanged = bChanged || _strNote == null || value == null || !_strNote.equals(value); _intChanged = ((_intChanged == 1) || _strNote == null || value == null || !_strNote.equals(value)) ? 1 : 0; if (_strNote == null || value == null || !_strNote.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strNote", _strNote, value); } _strNote = value; }}
  protected int _intAverageAge;
  public int getAverageAge(){return _intAverageAge;}
   public void setAverageAge(int value) { bChanged = bChanged || _intAverageAge != value; _intChanged = ((_intChanged == 1) || _intAverageAge != value) ? 1 : 0; if (_intAverageAge != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("intAverageAge", _intAverageAge, value); } _intAverageAge = value; }}
  protected Date _datStartOfSignsDate;
  public Date getStartOfSignsDate(){return _datStartOfSignsDate;}
   public void setStartOfSignsDate(Date value) { if(_datStartOfSignsDate == null && value == null) return; bChanged = bChanged || _datStartOfSignsDate == null || value == null || !_datStartOfSignsDate.equals(value); _intChanged = ((_intChanged == 1) || _datStartOfSignsDate == null || value == null || !_datStartOfSignsDate.equals(value)) ? 1 : 0; if (_datStartOfSignsDate == null || value == null || !_datStartOfSignsDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datStartOfSignsDate", _datStartOfSignsDate, value); } _datStartOfSignsDate = value; }}

protected static Species_object FromCursor(Cursor cursor, Species_object ret)
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
  ret._idfsFormTemplate = cursor.getLong(cursor.getColumnIndex("idfsFormTemplate"));
  ret._idfObservation = cursor.getLong(cursor.getColumnIndex("idfObservation"));
  ret._idfsSpeciesType = cursor.getLong(cursor.getColumnIndex("idfsSpeciesType"));
  ret._intTotalAnimalQty = cursor.getInt(cursor.getColumnIndex("intTotalAnimalQty"));
  ret._intDeadAnimalQty = cursor.getInt(cursor.getColumnIndex("intDeadAnimalQty"));
  ret._intSickAnimalQty = cursor.getInt(cursor.getColumnIndex("intSickAnimalQty"));
  ret._strNote = cursor.getString(cursor.getColumnIndex("strNote"));
  ret._intAverageAge = cursor.getInt(cursor.getColumnIndex("intAverageAge"));
  ret._datStartOfSignsDate = EidssUtils.ParseDate(cursor, formatterDate, "datStartOfSignsDate");
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
  ret.put("idfsFormTemplate", _idfsFormTemplate);
  ret.put("idfObservation", _idfObservation);
  ret.put("idfsSpeciesType", _idfsSpeciesType);
  ret.put("intTotalAnimalQty", _intTotalAnimalQty);
  ret.put("intDeadAnimalQty", _intDeadAnimalQty);
  ret.put("intSickAnimalQty", _intSickAnimalQty);
  ret.put("strNote", _strNote);
  ret.put("intAverageAge", _intAverageAge);
    strDate = null;
  if (_datStartOfSignsDate != null)
      strDate = formatterDate.format(_datStartOfSignsDate);
  ret.put("datStartOfSignsDate", strDate);

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
  _idfsFormTemplate = source.readLong();
  _idfObservation = source.readLong();
  _idfsSpeciesType = source.readLong();
  _intTotalAnimalQty = source.readInt();
  _intDeadAnimalQty = source.readInt();
  _intSickAnimalQty = source.readInt();
  _strNote = source.readString();
  _intAverageAge = source.readInt();
  _datStartOfSignsDate = (Date)source.readSerializable();
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
  dest.writeLong(_idfsFormTemplate);
  dest.writeLong(_idfObservation);
  dest.writeLong(_idfsSpeciesType);
  dest.writeInt(_intTotalAnimalQty);
  dest.writeInt(_intDeadAnimalQty);
  dest.writeInt(_intSickAnimalQty);
  dest.writeString(_strNote);
  dest.writeInt(_intAverageAge);
  dest.writeSerializable(_datStartOfSignsDate);
  dest.writeInt(bChanged ? 1 : 0);
}

protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException
{
serializer.attribute("", "lang", EidssUtils.getCurrentLanguage());
serializer.attribute("", "intChanged", String.valueOf(_intChanged));
  if (_idParent != 0)
      serializer.attribute("", "idParent", String.valueOf(_idParent));
  if (_idfsFormTemplate != 0)
      serializer.attribute("", "idfsFormTemplate", String.valueOf(_idfsFormTemplate));
  if (_idfObservation != 0)
      serializer.attribute("", "idfObservation", String.valueOf(_idfObservation));
  if (_idfsSpeciesType != 0)
      serializer.attribute("", "idfsSpeciesType", String.valueOf(_idfsSpeciesType));
  if (_intTotalAnimalQty != 0)
      serializer.attribute("", "intTotalAnimalQty", String.valueOf(_intTotalAnimalQty));
  if (_intDeadAnimalQty != 0)
      serializer.attribute("", "intDeadAnimalQty", String.valueOf(_intDeadAnimalQty));
  if (_intSickAnimalQty != 0)
      serializer.attribute("", "intSickAnimalQty", String.valueOf(_intSickAnimalQty));
  if (_strNote != null)
      serializer.attribute("", "strNote", _strNote);
  if (_intAverageAge != 0)
      serializer.attribute("", "intAverageAge", String.valueOf(_intAverageAge));
  if (_datStartOfSignsDate != null)
      serializer.attribute("", "datStartOfSignsDate", DateHelpers.FormatWithT(_datStartOfSignsDate));
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "idParent", _idParent);
  EidssUtils.putToJson(ret, "idfsFormTemplate", _idfsFormTemplate);
  EidssUtils.putToJson(ret, "idfObservation", _idfObservation);
  EidssUtils.putToJson(ret, "idfsSpeciesType", _idfsSpeciesType);
  EidssUtils.putToJson(ret, "intTotalAnimalQty", _intTotalAnimalQty);
  EidssUtils.putToJson(ret, "intDeadAnimalQty", _intDeadAnimalQty);
  EidssUtils.putToJson(ret, "intSickAnimalQty", _intSickAnimalQty);
  EidssUtils.putToJson(ret, "strNote", _strNote);
  EidssUtils.putToJson(ret, "intAverageAge", _intAverageAge);
  EidssUtils.putToJson(ret, "datStartOfSignsDate", _datStartOfSignsDate);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _idParent = json.getLong("idParent");
  _idfsFormTemplate = json.getLong("idfsFormTemplate");
  _idfObservation = json.getLong("idfObservation");
  _idfsSpeciesType = json.getLong("idfsSpeciesType");
  _intTotalAnimalQty = json.getInt("intTotalAnimalQty");
  _intDeadAnimalQty = json.getInt("intDeadAnimalQty");
  _intSickAnimalQty = json.getInt("intSickAnimalQty");
  _strNote = json.getString("strNote");
  _intAverageAge = json.getInt("intAverageAge");
  _datStartOfSignsDate = DateHelpers.ParseWithT(json.getString("datStartOfSignsDate"));
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _idParent = parser.getAttributeValue("", "idParent") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idParent"));
  _idfsFormTemplate = parser.getAttributeValue("", "idfsFormTemplate") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsFormTemplate"));
  _idfObservation = parser.getAttributeValue("", "idfObservation") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfObservation"));
  _idfsSpeciesType = parser.getAttributeValue("", "idfsSpeciesType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSpeciesType"));
  _intTotalAnimalQty = parser.getAttributeValue("", "intTotalAnimalQty") == null ? 0 : Integer.getInteger(parser.getAttributeValue("", "intTotalAnimalQty"));
  _intDeadAnimalQty = parser.getAttributeValue("", "intDeadAnimalQty") == null ? 0 : Integer.getInteger(parser.getAttributeValue("", "intDeadAnimalQty"));
  _intSickAnimalQty = parser.getAttributeValue("", "intSickAnimalQty") == null ? 0 : Integer.getInteger(parser.getAttributeValue("", "intSickAnimalQty"));
  _strNote = parser.getAttributeValue("", "strNote");
  _intAverageAge = parser.getAttributeValue("", "intAverageAge") == null ? 0 : Integer.getInteger(parser.getAttributeValue("", "intAverageAge"));
  _datStartOfSignsDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datStartOfSignsDate"));
}
}
