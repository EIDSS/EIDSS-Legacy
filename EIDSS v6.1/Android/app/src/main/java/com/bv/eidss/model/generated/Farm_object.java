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

public class Farm_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public Farm_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
        _dblLongitude = 0d;
        _dblLatitude = 0d;
    }
  public static String eidss_FarmCode = "Farm.FarmID";
  public static String eidss_RootFarm = "Farm.FarmName";
  public static String eidss_OwnerLastName = "Farm.FarmOwnerLastName";
  public static String eidss_OwnerFirstName = "Farm.FarmOwnerFirstName";
  public static String eidss_OwnerMiddleName = "Farm.FarmOwnerMiddleName";
  public static String eidss_Phone = "Farm.Address.Phone";
  public static String eidss_Fax = "Farm.Address.Fax";
  public static String eidss_Email = "Farm.Address.Email";
  public static String eidss_Region = "Farm.Address.Region";
  public static String eidss_Rayon = "Farm.Address.Rayon";
  public static String eidss_Settlement = "Farm.Address.Settlement";
  public static String eidss_StreetName = "Farm.Address.Street";
  public static String eidss_Building = "Farm.Address.Building";
  public static String eidss_House = "Farm.Address.House";
  public static String eidss_Apartment = "Farm.Address.Apt";
  public static String eidss_PostCode = "Farm.Address.PostalCode";
  public static String eidss_Longitude = "Farm.Address.PointGeoLocation.Longitude";
  public static String eidss_Latitude = "Farm.Address.PointGeoLocation.Latitude";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_RootFarm, R.string.Farm_idfRootFarm, new ICallable<Long, Farm_object>() { public Long call(Farm_object t) { return t.getRootFarm(); }}));
        add(new FieldMetadata(eidss_OwnerLastName, R.string.Farm_strOwnerLastName, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getOwnerLastName(); }}));
        add(new FieldMetadata(eidss_OwnerFirstName, R.string.Farm_strOwnerFirstName, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getOwnerFirstName(); }}));
        add(new FieldMetadata(eidss_OwnerMiddleName, R.string.Farm_strOwnerMiddleName, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getOwnerMiddleName(); }}));
        add(new FieldMetadata(eidss_Phone, R.string.Farm_strPhone, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getPhone(); }}));
        add(new FieldMetadata(eidss_Fax, R.string.Farm_strFax, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getFax(); }}));
        add(new FieldMetadata(eidss_Email, R.string.Farm_strEmail, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getEmail(); }}));
        add(new FieldMetadata(eidss_Region, R.string.Farm_idfsRegion, new ICallable<Long, Farm_object>() { public Long call(Farm_object t) { return t.getRegion(); }}));
        add(new FieldMetadata(eidss_Rayon, R.string.Farm_idfsRayon, new ICallable<Long, Farm_object>() { public Long call(Farm_object t) { return t.getRayon(); }}));
        add(new FieldMetadata(eidss_Settlement, R.string.Farm_idfsSettlement, new ICallable<Long, Farm_object>() { public Long call(Farm_object t) { return t.getSettlement(); }}));
        add(new FieldMetadata(eidss_StreetName, R.string.Farm_strStreetName, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getStreetName(); }}));
        add(new FieldMetadata(eidss_Building, R.string.Farm_strBuilding, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getBuilding(); }}));
        add(new FieldMetadata(eidss_House, R.string.Farm_strHouse, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getHouse(); }}));
        add(new FieldMetadata(eidss_Apartment, R.string.Farm_strApartment, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getApartment(); }}));
        add(new FieldMetadata(eidss_PostCode, R.string.Farm_strPostCode, new ICallable<String, Farm_object>() { public String call(Farm_object t) { return t.getPostCode(); }}));
        add(new FieldMetadata(eidss_Longitude, R.string.Farm_dblLongitude, new ICallable<Double, Farm_object>() { public Double call(Farm_object t) { return t.getLongitude(); }}));
        add(new FieldMetadata(eidss_Latitude, R.string.Farm_dblLatitude, new ICallable<Double, Farm_object>() { public Double call(Farm_object t) { return t.getLatitude(); }}));
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
  protected int _intRowStatus;
  public int getRowStatus(){return _intRowStatus;}
   public void setRowStatus(int value) { bChanged = bChanged || _intRowStatus != value; _intChanged = ((_intChanged == 1) || _intRowStatus != value) ? 1 : 0; if (_intRowStatus != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("intRowStatus", _intRowStatus, value); } _intRowStatus = value; }}
  protected String _uidOfflineCaseID;
  public String getOfflineCaseID(){return _uidOfflineCaseID;}
  public void setOfflineCaseID(String value) { _uidOfflineCaseID = value; }
  protected long _idParent;
  public long getParent(){return _idParent;}
   public void setParent(long value) { bChanged = bChanged || _idParent != value; _intChanged = ((_intChanged == 1) || _idParent != value) ? 1 : 0; if (_idParent != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idParent", _idParent, value); } _idParent = value; }}
  protected long _idfFarm;
  public long getFarm(){return _idfFarm;}
   public void setFarm(long value) { bChanged = bChanged || _idfFarm != value; _intChanged = ((_intChanged == 1) || _idfFarm != value) ? 1 : 0; if (_idfFarm != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfFarm", _idfFarm, value); } _idfFarm = value; }}
  protected long _idfsHerd;
  public long getHerd(){return _idfsHerd;}
   public void setHerd(long value) { bChanged = bChanged || _idfsHerd != value; _intChanged = ((_intChanged == 1) || _idfsHerd != value) ? 1 : 0; if (_idfsHerd != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsHerd", _idfsHerd, value); } _idfsHerd = value; }}
  protected Boolean _blnIsRoot;
  public Boolean getIsRoot(){return _blnIsRoot;}
   public void setIsRoot(Boolean value) { bChanged = bChanged || _blnIsRoot != value; _intChanged = ((_intChanged == 1) || _blnIsRoot != value) ? 1 : 0; if (_blnIsRoot != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("blnIsRoot", _blnIsRoot, value); } _blnIsRoot = value; }}
  protected String _strFarmName;
  public String getFarmName(){return _strFarmName;}
   public void setFarmName(String value) { if(_strFarmName == null && value == null) return; bChanged = bChanged || _strFarmName == null || value == null || !_strFarmName.equals(value); _intChanged = ((_intChanged == 1) || _strFarmName == null || value == null || !_strFarmName.equals(value)) ? 1 : 0; if (_strFarmName == null || value == null || !_strFarmName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strFarmName", _strFarmName, value); } _strFarmName = value; }}
  protected String _strFarmCode;
  public String getFarmCode(){return _strFarmCode;}
  public void setFarmCode(String value) { _strFarmCode = value; }
  protected long _idfRootFarm;
  public long getRootFarm(){return _idfRootFarm;}
   public void setRootFarm(long value) { bChanged = bChanged || _idfRootFarm != value; _intChanged = ((_intChanged == 1) || _idfRootFarm != value) ? 1 : 0; if (_idfRootFarm != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfRootFarm", _idfRootFarm, value); } _idfRootFarm = value; }}
  protected String _strOwnerLastName;
  public String getOwnerLastName(){return _strOwnerLastName;}
   public void setOwnerLastName(String value) { if(_strOwnerLastName == null && value == null) return; bChanged = bChanged || _strOwnerLastName == null || value == null || !_strOwnerLastName.equals(value); _intChanged = ((_intChanged == 1) || _strOwnerLastName == null || value == null || !_strOwnerLastName.equals(value)) ? 1 : 0; if (_strOwnerLastName == null || value == null || !_strOwnerLastName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strOwnerLastName", _strOwnerLastName, value); } _strOwnerLastName = value; }}
  protected String _strOwnerFirstName;
  public String getOwnerFirstName(){return _strOwnerFirstName;}
   public void setOwnerFirstName(String value) { if(_strOwnerFirstName == null && value == null) return; bChanged = bChanged || _strOwnerFirstName == null || value == null || !_strOwnerFirstName.equals(value); _intChanged = ((_intChanged == 1) || _strOwnerFirstName == null || value == null || !_strOwnerFirstName.equals(value)) ? 1 : 0; if (_strOwnerFirstName == null || value == null || !_strOwnerFirstName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strOwnerFirstName", _strOwnerFirstName, value); } _strOwnerFirstName = value; }}
  protected String _strOwnerMiddleName;
  public String getOwnerMiddleName(){return _strOwnerMiddleName;}
   public void setOwnerMiddleName(String value) { if(_strOwnerMiddleName == null && value == null) return; bChanged = bChanged || _strOwnerMiddleName == null || value == null || !_strOwnerMiddleName.equals(value); _intChanged = ((_intChanged == 1) || _strOwnerMiddleName == null || value == null || !_strOwnerMiddleName.equals(value)) ? 1 : 0; if (_strOwnerMiddleName == null || value == null || !_strOwnerMiddleName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strOwnerMiddleName", _strOwnerMiddleName, value); } _strOwnerMiddleName = value; }}
  protected String _strPhone;
  public String getPhone(){return _strPhone;}
   public void setPhone(String value) { if(_strPhone == null && value == null) return; bChanged = bChanged || _strPhone == null || value == null || !_strPhone.equals(value); _intChanged = ((_intChanged == 1) || _strPhone == null || value == null || !_strPhone.equals(value)) ? 1 : 0; if (_strPhone == null || value == null || !_strPhone.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strPhone", _strPhone, value); } _strPhone = value; }}
  protected String _strFax;
  public String getFax(){return _strFax;}
   public void setFax(String value) { if(_strFax == null && value == null) return; bChanged = bChanged || _strFax == null || value == null || !_strFax.equals(value); _intChanged = ((_intChanged == 1) || _strFax == null || value == null || !_strFax.equals(value)) ? 1 : 0; if (_strFax == null || value == null || !_strFax.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strFax", _strFax, value); } _strFax = value; }}
  protected String _strEmail;
  public String getEmail(){return _strEmail;}
   public void setEmail(String value) { if(_strEmail == null && value == null) return; bChanged = bChanged || _strEmail == null || value == null || !_strEmail.equals(value); _intChanged = ((_intChanged == 1) || _strEmail == null || value == null || !_strEmail.equals(value)) ? 1 : 0; if (_strEmail == null || value == null || !_strEmail.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strEmail", _strEmail, value); } _strEmail = value; }}
  protected long _idfsRegion;
  public long getRegion(){return _idfsRegion;}
   public void setRegion(long value) { bChanged = bChanged || _idfsRegion != value; _intChanged = ((_intChanged == 1) || _idfsRegion != value) ? 1 : 0; if (_idfsRegion != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsRegion", _idfsRegion, value); } _idfsRegion = value; }}
  protected long _idfsRayon;
  public long getRayon(){return _idfsRayon;}
   public void setRayon(long value) { bChanged = bChanged || _idfsRayon != value; _intChanged = ((_intChanged == 1) || _idfsRayon != value) ? 1 : 0; if (_idfsRayon != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsRayon", _idfsRayon, value); } _idfsRayon = value; }}
  protected long _idfsSettlement;
  public long getSettlement(){return _idfsSettlement;}
   public void setSettlement(long value) { bChanged = bChanged || _idfsSettlement != value; _intChanged = ((_intChanged == 1) || _idfsSettlement != value) ? 1 : 0; if (_idfsSettlement != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSettlement", _idfsSettlement, value); } _idfsSettlement = value; }}
  protected String _strStreetName;
  public String getStreetName(){return _strStreetName;}
   public void setStreetName(String value) { if(_strStreetName == null && value == null) return; bChanged = bChanged || _strStreetName == null || value == null || !_strStreetName.equals(value); _intChanged = ((_intChanged == 1) || _strStreetName == null || value == null || !_strStreetName.equals(value)) ? 1 : 0; if (_strStreetName == null || value == null || !_strStreetName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strStreetName", _strStreetName, value); } _strStreetName = value; }}
  protected String _strBuilding;
  public String getBuilding(){return _strBuilding;}
   public void setBuilding(String value) { if(_strBuilding == null && value == null) return; bChanged = bChanged || _strBuilding == null || value == null || !_strBuilding.equals(value); _intChanged = ((_intChanged == 1) || _strBuilding == null || value == null || !_strBuilding.equals(value)) ? 1 : 0; if (_strBuilding == null || value == null || !_strBuilding.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strBuilding", _strBuilding, value); } _strBuilding = value; }}
  protected String _strHouse;
  public String getHouse(){return _strHouse;}
   public void setHouse(String value) { if(_strHouse == null && value == null) return; bChanged = bChanged || _strHouse == null || value == null || !_strHouse.equals(value); _intChanged = ((_intChanged == 1) || _strHouse == null || value == null || !_strHouse.equals(value)) ? 1 : 0; if (_strHouse == null || value == null || !_strHouse.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strHouse", _strHouse, value); } _strHouse = value; }}
  protected String _strApartment;
  public String getApartment(){return _strApartment;}
   public void setApartment(String value) { if(_strApartment == null && value == null) return; bChanged = bChanged || _strApartment == null || value == null || !_strApartment.equals(value); _intChanged = ((_intChanged == 1) || _strApartment == null || value == null || !_strApartment.equals(value)) ? 1 : 0; if (_strApartment == null || value == null || !_strApartment.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strApartment", _strApartment, value); } _strApartment = value; }}
  protected String _strPostCode;
  public String getPostCode(){return _strPostCode;}
   public void setPostCode(String value) { if(_strPostCode == null && value == null) return; bChanged = bChanged || _strPostCode == null || value == null || !_strPostCode.equals(value); _intChanged = ((_intChanged == 1) || _strPostCode == null || value == null || !_strPostCode.equals(value)) ? 1 : 0; if (_strPostCode == null || value == null || !_strPostCode.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strPostCode", _strPostCode, value); } _strPostCode = value; }}
  protected double _dblLongitude;
  public double getLongitude(){return _dblLongitude;}
   public void setLongitude(double value) { bChanged = bChanged || _dblLongitude != value; _intChanged = ((_intChanged == 1) || _dblLongitude != value) ? 1 : 0; if (_dblLongitude != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("dblLongitude", _dblLongitude, value); } _dblLongitude = value; }}
  protected double _dblLatitude;
  public double getLatitude(){return _dblLatitude;}
   public void setLatitude(double value) { bChanged = bChanged || _dblLatitude != value; _intChanged = ((_intChanged == 1) || _dblLatitude != value) ? 1 : 0; if (_dblLatitude != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("dblLatitude", _dblLatitude, value); } _dblLatitude = value; }}

protected static Farm_object FromCursor(Cursor cursor, Farm_object ret)
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
  ret._intRowStatus = cursor.getInt(cursor.getColumnIndex("intRowStatus"));
  ret._uidOfflineCaseID = cursor.getString(cursor.getColumnIndex("uidOfflineCaseID"));
  ret._idParent = cursor.getLong(cursor.getColumnIndex("idParent"));
  ret._idfFarm = cursor.getLong(cursor.getColumnIndex("idfFarm"));
  ret._idfsHerd = cursor.getLong(cursor.getColumnIndex("idfsHerd"));
  ret._blnIsRoot = cursor.getInt(cursor.getColumnIndex("blnIsRoot")) > 0;
  ret._strFarmName = cursor.getString(cursor.getColumnIndex("strFarmName"));
  ret._strFarmCode = cursor.getString(cursor.getColumnIndex("strFarmCode"));
  ret._idfRootFarm = cursor.getLong(cursor.getColumnIndex("idfRootFarm"));
  ret._strOwnerLastName = cursor.getString(cursor.getColumnIndex("strOwnerLastName"));
  ret._strOwnerFirstName = cursor.getString(cursor.getColumnIndex("strOwnerFirstName"));
  ret._strOwnerMiddleName = cursor.getString(cursor.getColumnIndex("strOwnerMiddleName"));
  ret._strPhone = cursor.getString(cursor.getColumnIndex("strPhone"));
  ret._strFax = cursor.getString(cursor.getColumnIndex("strFax"));
  ret._strEmail = cursor.getString(cursor.getColumnIndex("strEmail"));
  ret._idfsRegion = cursor.getLong(cursor.getColumnIndex("idfsRegion"));
  ret._idfsRayon = cursor.getLong(cursor.getColumnIndex("idfsRayon"));
  ret._idfsSettlement = cursor.getLong(cursor.getColumnIndex("idfsSettlement"));
  ret._strStreetName = cursor.getString(cursor.getColumnIndex("strStreetName"));
  ret._strBuilding = cursor.getString(cursor.getColumnIndex("strBuilding"));
  ret._strHouse = cursor.getString(cursor.getColumnIndex("strHouse"));
  ret._strApartment = cursor.getString(cursor.getColumnIndex("strApartment"));
  ret._strPostCode = cursor.getString(cursor.getColumnIndex("strPostCode"));
  ret._dblLongitude = cursor.getDouble(cursor.getColumnIndex("dblLongitude"));
  ret._dblLatitude = cursor.getDouble(cursor.getColumnIndex("dblLatitude"));
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
  ret.put("intRowStatus", _intRowStatus);
  ret.put("uidOfflineCaseID", _uidOfflineCaseID);
  ret.put("idParent", _idParent);
  ret.put("idfFarm", _idfFarm);
  ret.put("idfsHerd", _idfsHerd);
  ret.put("blnIsRoot", _blnIsRoot);
  ret.put("strFarmName", _strFarmName);
  ret.put("strFarmCode", _strFarmCode);
  ret.put("idfRootFarm", _idfRootFarm);
  ret.put("strOwnerLastName", _strOwnerLastName);
  ret.put("strOwnerFirstName", _strOwnerFirstName);
  ret.put("strOwnerMiddleName", _strOwnerMiddleName);
  ret.put("strPhone", _strPhone);
  ret.put("strFax", _strFax);
  ret.put("strEmail", _strEmail);
  ret.put("idfsRegion", _idfsRegion);
  ret.put("idfsRayon", _idfsRayon);
  ret.put("idfsSettlement", _idfsSettlement);
  ret.put("strStreetName", _strStreetName);
  ret.put("strBuilding", _strBuilding);
  ret.put("strHouse", _strHouse);
  ret.put("strApartment", _strApartment);
  ret.put("strPostCode", _strPostCode);
  ret.put("dblLongitude", _dblLongitude);
  ret.put("dblLatitude", _dblLatitude);

return ret;
}

protected void FromParcel(Parcel source)
{
    _id = source.readLong();
    _strLastSynError = source.readString();
    _intStatus = source.readInt();
    _intChanged = source.readInt();
    _datCreateDate = (Date)source.readSerializable();
  _intRowStatus = source.readInt();
  _uidOfflineCaseID = source.readString();
  _idParent = source.readLong();
  _idfFarm = source.readLong();
  _idfsHerd = source.readLong();
  _blnIsRoot = source.readInt() == 1;
  _strFarmName = source.readString();
  _strFarmCode = source.readString();
  _idfRootFarm = source.readLong();
  _strOwnerLastName = source.readString();
  _strOwnerFirstName = source.readString();
  _strOwnerMiddleName = source.readString();
  _strPhone = source.readString();
  _strFax = source.readString();
  _strEmail = source.readString();
  _idfsRegion = source.readLong();
  _idfsRayon = source.readLong();
  _idfsSettlement = source.readLong();
  _strStreetName = source.readString();
  _strBuilding = source.readString();
  _strHouse = source.readString();
  _strApartment = source.readString();
  _strPostCode = source.readString();
  _dblLongitude = source.readDouble();
  _dblLatitude = source.readDouble();
    bChanged = source.readInt() == 1;
}
protected void ToParcel(Parcel dest, int flag)
{
  dest.writeLong(_id);
  dest.writeString(_strLastSynError);
  dest.writeInt(_intStatus);
  dest.writeInt(_intChanged);
  dest.writeSerializable(_datCreateDate);
  dest.writeInt(_intRowStatus);
  dest.writeString(_uidOfflineCaseID);
  dest.writeLong(_idParent);
  dest.writeLong(_idfFarm);
  dest.writeLong(_idfsHerd);
  if (_blnIsRoot == null) { dest.writeInt(0); } else { dest.writeInt(_blnIsRoot ? 1 : 0); }
  dest.writeString(_strFarmName);
  dest.writeString(_strFarmCode);
  dest.writeLong(_idfRootFarm);
  dest.writeString(_strOwnerLastName);
  dest.writeString(_strOwnerFirstName);
  dest.writeString(_strOwnerMiddleName);
  dest.writeString(_strPhone);
  dest.writeString(_strFax);
  dest.writeString(_strEmail);
  dest.writeLong(_idfsRegion);
  dest.writeLong(_idfsRayon);
  dest.writeLong(_idfsSettlement);
  dest.writeString(_strStreetName);
  dest.writeString(_strBuilding);
  dest.writeString(_strHouse);
  dest.writeString(_strApartment);
  dest.writeString(_strPostCode);
  dest.writeDouble(_dblLongitude);
  dest.writeDouble(_dblLatitude);
  dest.writeInt(bChanged ? 1 : 0);
}

protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException
{
serializer.attribute("", "lang", EidssUtils.getCurrentLanguage());
serializer.attribute("", "intChanged", String.valueOf(_intChanged));
  if (_intRowStatus != 0)
      serializer.attribute("", "intRowStatus", String.valueOf(_intRowStatus));
  if (_uidOfflineCaseID != null)
      serializer.attribute("", "uidOfflineCaseID", _uidOfflineCaseID);
  if (_idParent != 0)
      serializer.attribute("", "idParent", String.valueOf(_idParent));
  if (_idfFarm != 0)
      serializer.attribute("", "idfFarm", String.valueOf(_idfFarm));
  if (_idfsHerd != 0)
      serializer.attribute("", "idfsHerd", String.valueOf(_idfsHerd));
  if (_blnIsRoot != null)
      serializer.attribute("", "blnIsRoot", String.valueOf(_blnIsRoot ? 1 : 0));
  if (_strFarmName != null)
      serializer.attribute("", "strFarmName", _strFarmName);
  if (_strFarmCode != null)
      serializer.attribute("", "strFarmCode", _strFarmCode);
  if (_idfRootFarm != 0)
      serializer.attribute("", "idfRootFarm", String.valueOf(_idfRootFarm));
  if (_strOwnerLastName != null)
      serializer.attribute("", "strOwnerLastName", _strOwnerLastName);
  if (_strOwnerFirstName != null)
      serializer.attribute("", "strOwnerFirstName", _strOwnerFirstName);
  if (_strOwnerMiddleName != null)
      serializer.attribute("", "strOwnerMiddleName", _strOwnerMiddleName);
  if (_strPhone != null)
      serializer.attribute("", "strPhone", _strPhone);
  if (_strFax != null)
      serializer.attribute("", "strFax", _strFax);
  if (_strEmail != null)
      serializer.attribute("", "strEmail", _strEmail);
  if (_idfsRegion != 0)
      serializer.attribute("", "idfsRegion", String.valueOf(_idfsRegion));
  if (_idfsRayon != 0)
      serializer.attribute("", "idfsRayon", String.valueOf(_idfsRayon));
  if (_idfsSettlement != 0)
      serializer.attribute("", "idfsSettlement", String.valueOf(_idfsSettlement));
  if (_strStreetName != null)
      serializer.attribute("", "strStreetName", _strStreetName);
  if (_strBuilding != null)
      serializer.attribute("", "strBuilding", _strBuilding);
  if (_strHouse != null)
      serializer.attribute("", "strHouse", _strHouse);
  if (_strApartment != null)
      serializer.attribute("", "strApartment", _strApartment);
  if (_strPostCode != null)
      serializer.attribute("", "strPostCode", _strPostCode);
  if (_dblLongitude != 0)
      serializer.attribute("", "dblLongitude", String.valueOf(_dblLongitude));
  if (_dblLatitude != 0)
      serializer.attribute("", "dblLatitude", String.valueOf(_dblLatitude));
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "intRowStatus", _intRowStatus);
  EidssUtils.putToJson(ret, "uidOfflineCaseID", _uidOfflineCaseID);
  EidssUtils.putToJson(ret, "idParent", _idParent);
  EidssUtils.putToJson(ret, "idfFarm", _idfFarm);
  EidssUtils.putToJson(ret, "idfsHerd", _idfsHerd);
  EidssUtils.putToJson(ret, "blnIsRoot", _blnIsRoot ? 1 : 0);
  EidssUtils.putToJson(ret, "strFarmName", _strFarmName);
  EidssUtils.putToJson(ret, "strFarmCode", _strFarmCode);
  EidssUtils.putToJson(ret, "idfRootFarm", _idfRootFarm);
  EidssUtils.putToJson(ret, "strOwnerLastName", _strOwnerLastName);
  EidssUtils.putToJson(ret, "strOwnerFirstName", _strOwnerFirstName);
  EidssUtils.putToJson(ret, "strOwnerMiddleName", _strOwnerMiddleName);
  EidssUtils.putToJson(ret, "strPhone", _strPhone);
  EidssUtils.putToJson(ret, "strFax", _strFax);
  EidssUtils.putToJson(ret, "strEmail", _strEmail);
  EidssUtils.putToJson(ret, "idfsRegion", _idfsRegion);
  EidssUtils.putToJson(ret, "idfsRayon", _idfsRayon);
  EidssUtils.putToJson(ret, "idfsSettlement", _idfsSettlement);
  EidssUtils.putToJson(ret, "strStreetName", _strStreetName);
  EidssUtils.putToJson(ret, "strBuilding", _strBuilding);
  EidssUtils.putToJson(ret, "strHouse", _strHouse);
  EidssUtils.putToJson(ret, "strApartment", _strApartment);
  EidssUtils.putToJson(ret, "strPostCode", _strPostCode);
  EidssUtils.putToJson(ret, "dblLongitude", _dblLongitude);
  EidssUtils.putToJson(ret, "dblLatitude", _dblLatitude);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _intRowStatus = json.getInt("intRowStatus");
  _uidOfflineCaseID = json.getString("uidOfflineCaseID");
  _idParent = json.getLong("idParent");
  _idfFarm = json.getLong("idfFarm");
  _idfsHerd = json.getLong("idfsHerd");
  _blnIsRoot = json.getBoolean("blnIsRoot");
  _strFarmName = json.getString("strFarmName");
  _strFarmCode = json.getString("strFarmCode");
  _idfRootFarm = json.getLong("idfRootFarm");
  _strOwnerLastName = json.getString("strOwnerLastName");
  _strOwnerFirstName = json.getString("strOwnerFirstName");
  _strOwnerMiddleName = json.getString("strOwnerMiddleName");
  _strPhone = json.getString("strPhone");
  _strFax = json.getString("strFax");
  _strEmail = json.getString("strEmail");
  _idfsRegion = json.getLong("idfsRegion");
  _idfsRayon = json.getLong("idfsRayon");
  _idfsSettlement = json.getLong("idfsSettlement");
  _strStreetName = json.getString("strStreetName");
  _strBuilding = json.getString("strBuilding");
  _strHouse = json.getString("strHouse");
  _strApartment = json.getString("strApartment");
  _strPostCode = json.getString("strPostCode");
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _intRowStatus = parser.getAttributeValue("", "intRowStatus") == null ? 0 : Integer.getInteger(parser.getAttributeValue("", "intRowStatus"));
  _uidOfflineCaseID = parser.getAttributeValue("", "uidOfflineCaseID");
  _idParent = parser.getAttributeValue("", "idParent") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idParent"));
  _idfFarm = parser.getAttributeValue("", "idfFarm") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfFarm"));
  _idfsHerd = parser.getAttributeValue("", "idfsHerd") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsHerd"));
  _blnIsRoot = parser.getAttributeValue("", "blnIsRoot") == null ? null : Boolean.getBoolean(parser.getAttributeValue("", "blnIsRoot"));
  _strFarmName = parser.getAttributeValue("", "strFarmName");
  _strFarmCode = parser.getAttributeValue("", "strFarmCode");
  _idfRootFarm = parser.getAttributeValue("", "idfRootFarm") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfRootFarm"));
  _strOwnerLastName = parser.getAttributeValue("", "strOwnerLastName");
  _strOwnerFirstName = parser.getAttributeValue("", "strOwnerFirstName");
  _strOwnerMiddleName = parser.getAttributeValue("", "strOwnerMiddleName");
  _strPhone = parser.getAttributeValue("", "strPhone");
  _strFax = parser.getAttributeValue("", "strFax");
  _strEmail = parser.getAttributeValue("", "strEmail");
  _idfsRegion = parser.getAttributeValue("", "idfsRegion") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsRegion"));
  _idfsRayon = parser.getAttributeValue("", "idfsRayon") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsRayon"));
  _idfsSettlement = parser.getAttributeValue("", "idfsSettlement") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSettlement"));
  _strStreetName = parser.getAttributeValue("", "strStreetName");
  _strBuilding = parser.getAttributeValue("", "strBuilding");
  _strHouse = parser.getAttributeValue("", "strHouse");
  _strApartment = parser.getAttributeValue("", "strApartment");
  _strPostCode = parser.getAttributeValue("", "strPostCode");
}
}
