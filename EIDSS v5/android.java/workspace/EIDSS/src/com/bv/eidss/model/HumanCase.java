package com.bv.eidss.model;

import java.text.Format;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.UUID;

import com.bv.eidss.DateHelpers;
import com.bv.eidss.data.EidssDatabase;
import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

public class HumanCase implements Parcelable {
    private long _id;
    public long getId() { return _id; } 
    public void setId(long value) { _id = value; }
    private String _strLastSynError;
    public String getLastSynError() { return _strLastSynError; } 
    public void setLastSynError(String value) { _strLastSynError = value; }
    private int _intStatus; //  1 - new; 2 - synchronized; 3 - changed;
    public int getStatus() { return _intStatus; } 
    public void setStatusChanged() { _intStatus = HumanCaseStatus.CHANGED; } 
    public void setStatusSyn() { _intStatus = HumanCaseStatus.SYNCHRONIZED; } 
    private Date _datCreateDate;
    public Date getCreateDate() { return _datCreateDate; } 
    private String _uidOfflineCaseID;
    public String getOfflineCaseID() { return _uidOfflineCaseID; } 
    private String _strCaseID;
    public String getCaseID() { return _strCaseID; } 
    public void setCaseID(String value) { _strCaseID = value; }
    private long _idfCase;
    public long getCase() { return _idfCase; } 
    public void setCase(long value) { _idfCase = value; }

    private String _strLocalIdentifier;
    public String getLocalIdentifier() { return _strLocalIdentifier; } 
    public void setLocalIdentifier(String value) { bChanged = bChanged || _strLocalIdentifier != value; _strLocalIdentifier = value; }
    private long _idfsTentativeDiagnosis;
    public long getTentativeDiagnosis() { return _idfsTentativeDiagnosis; } 
    public void setTentativeDiagnosis(long value) { bChanged = bChanged || _idfsTentativeDiagnosis != value; _idfsTentativeDiagnosis = value; }
    private Date _datTentativeDiagnosisDate;
    public Date getTentativeDiagnosisDate() { return _datTentativeDiagnosisDate; } 
    public void setTentativeDiagnosisDate(Date value) { bChanged = bChanged || _datTentativeDiagnosisDate != value; _datTentativeDiagnosisDate = value; }
    private String _strFamilyName;
    public String getFamilyName() { return _strFamilyName; } 
    public void setFamilyName(String value) { bChanged = bChanged || _strFamilyName != value; _strFamilyName = value; }
    private String _strFirstName;
    public String getFirstName() { return _strFirstName; } 
    public void setFirstName(String value) { bChanged = bChanged || _strFirstName != value; _strFirstName = value; }
    private Date _datDateofBirth;
    public Date getDateofBirth() { return _datDateofBirth; } 
    public void setDateofBirth(Date value) { bChanged = bChanged || _datDateofBirth != value; _datDateofBirth = value; }
    private int _intPatientAge;
    public int getPatientAge() { return _intPatientAge; } 
    public void setPatientAge(int value) { bChanged = bChanged || _intPatientAge != value; _intPatientAge = value; }
    private long _idfsHumanAgeType;
    public long getHumanAgeType() { return _idfsHumanAgeType; } 
    public void setHumanAgeType(long value) { bChanged = bChanged || _idfsHumanAgeType != value; _idfsHumanAgeType = value; }
    private long _idfsHumanGender;
    public long getHumanGender() { return _idfsHumanGender; } 
    public void setHumanGender(long value) { bChanged = bChanged || _idfsHumanGender != value; _idfsHumanGender = value; }
    private long _idfsRegionCurrentResidence;
    public long getRegionCurrentResidence() { return _idfsRegionCurrentResidence; } 
    public void setRegionCurrentResidence(long value) { bChanged = bChanged || _idfsRegionCurrentResidence != value; _idfsRegionCurrentResidence = value; }
    private long _idfsRayonCurrentResidence;
    public long getRayonCurrentResidence() { return _idfsRayonCurrentResidence; } 
    public void setRayonCurrentResidence(long value) { bChanged = bChanged || _idfsRayonCurrentResidence != value; _idfsRayonCurrentResidence = value; }
    private long _idfsSettlementCurrentResidence;
    public long getSettlementCurrentResidence() { return _idfsSettlementCurrentResidence; } 
    public void setSettlementCurrentResidence(long value) { bChanged = bChanged || _idfsSettlementCurrentResidence != value; _idfsSettlementCurrentResidence = value; }
    private String _strBuilding;
    public String getBuilding() { return _strBuilding; } 
    public void setBuilding(String value) { bChanged = bChanged || _strBuilding != value; _strBuilding = value; }
    private String _strHouse;
    public String getHouse() { return _strHouse; } 
    public void setHouse(String value) { bChanged = bChanged || _strHouse != value; _strHouse = value; }
    private String _strApartment;
    public String getApartment() { return _strApartment; } 
    public void setApartment(String value) { bChanged = bChanged || _strApartment != value; _strApartment = value; }
    private String _strStreetName;
    public String getStreetName() { return _strStreetName; } 
    public void setStreetName(String value) { bChanged = bChanged || _strStreetName != value; _strStreetName = value; }
    private String _strPostCode;
    public String getPostCode() { return _strPostCode; } 
    public void setPostCode(String value) { bChanged = bChanged || _strPostCode != value; _strPostCode = value; }
    private String _strHomePhone;
    public String getHomePhone() { return _strHomePhone; } 
    public void setHomePhone(String value) { bChanged = bChanged || _strHomePhone != value; _strHomePhone = value; }
    private Date _datOnSetDate;
    public Date getOnSetDate() { return _datOnSetDate; } 
    public void setOnSetDate(Date value) { bChanged = bChanged || _datOnSetDate != value; _datOnSetDate = value; }
    private long _idfsFinalState;
    public long getFinalState()  { return _idfsFinalState; } 
    public void setFinalState(long value) { bChanged = bChanged || _idfsFinalState != value; _idfsFinalState = value; }
    private long _idfsHospitalizationStatus;
    public long getHospitalizationStatus() { return _idfsHospitalizationStatus; } 
    public void setHospitalizationStatus(long value) { bChanged = bChanged || _idfsHospitalizationStatus != value; _idfsHospitalizationStatus = value; }

    private Date _datNotificationDate;
    public Date getNotificationDate() { return _datNotificationDate; }
    public void setNotificationDate(Date value) { _datNotificationDate = value; }
    private String _strSentByOffice;
    public String getSentByOffice() { return _strSentByOffice; }
    public void setSentByOffice(String value) { _strSentByOffice = value; }
    private String _strSentByPerson;
    public String getSentByPerson() { return _strSentByPerson; }
    public void setSentByPerson(String value) { _strSentByPerson = value; }

    private Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    public String TentativeDiagnosis(EidssDatabase db)
    { 
    	List<BaseReference> list = db.Reference(BaseReferenceType.rftDiagnosis, db.getCurrentLanguage(), 2);
        for(int i = 0; i < list.size(); i++){
        	if (list.get(i).idfsBaseReference == getTentativeDiagnosis()){
        		return list.get(i).name;
        	}
        }
        return "";
    }


    private HumanCase()
    {
    }

    public static HumanCase CreateNew()
    {
    	HumanCase ret = new HumanCase();
        ret._intStatus = HumanCaseStatus.NEW;
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret._strCaseID = "(new)";
        ret._datCreateDate = new Date();
        ret.bChanged = true;
        return ret;
    }


    @SuppressWarnings("deprecation")
	private Date getD()
    {
    	Date ret;
        if (_datOnSetDate != null) ret = (Date)_datOnSetDate.clone();
        else if (_datNotificationDate != null) ret = (Date)_datNotificationDate.clone();
        else ret = (Date)_datCreateDate.clone();
        ret.setHours(0);
        ret.setMinutes(0);
        ret.setSeconds(0);
        return ret;
    }

    public int CalcPatientAge()
    {
    	GetDOBandAgeRet ret = GetDOBandAge();
        if (ret.result)
            return ret.intPatientAge;
        return this._intPatientAge;
    }

    public long CalcPatientAgeType()
    {
    	GetDOBandAgeRet ret = GetDOBandAge();
        if (ret.result)
            return ret.idfsHumanAgeType;
        return this._idfsHumanAgeType;
    }
    
    class GetDOBandAgeRet
    {
    	public boolean result;
    	public int intPatientAge;
    	public long idfsHumanAgeType;
    }

    private GetDOBandAgeRet GetDOBandAge()
    {
    	GetDOBandAgeRet ret = new GetDOBandAgeRet();
    	ret.result = true;
        double ddAge = -1;
        Date datUp = null;
        if (this.getDateofBirth() != null)
        {
            datUp = this.getD();
            long diff = this.getDateofBirth().getTime() - this.getD().getTime();
            ddAge = -diff / (1000L*60L*60L*24L);

            if (ddAge > -1)
            {
                long yyAge = DateHelpers.DateDifference(0, this._datDateofBirth, datUp);
                if (yyAge > 0)
                {
                    //'Years
                    ret.intPatientAge = (int)yyAge;
                    ret.idfsHumanAgeType = HumanAgeType.Years;
                    return ret;
                }
                else
                {
                    long mmAge = DateHelpers.DateDifference(1, this._datDateofBirth, datUp);
                    if (mmAge > 0)
                    {
                        //'Months
                    	ret.intPatientAge = (int)mmAge;
                    	ret.idfsHumanAgeType = HumanAgeType.Month;
                        return ret;
                    }
                    else
                    {
                        //'Days
                    	ret.intPatientAge = (int)ddAge;
                    	ret.idfsHumanAgeType = HumanAgeType.Days;
                        return ret;
                    }
                }
            }
        }
    	ret.result = false;
        return ret;
    }


    public static HumanCase FromCursor(Cursor cursor)
    {
    	HumanCase ret = new HumanCase();
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH.mm.ss", Locale.US);
    	Format formatterDate = new SimpleDateFormat("yyyy-MM-dd", Locale.US);
		try {
	    	ret._id = cursor.getLong(cursor.getColumnIndex("id"));
	    	ret._strLastSynError = cursor.getString(cursor.getColumnIndex("strLastSynError"));
	    	ret._intStatus = cursor.getInt(cursor.getColumnIndex("intStatus"));
	    	String strDate = cursor.getString(cursor.getColumnIndex("datCreateDate"));
	    	ret._datCreateDate = (Date)formatterDateTime.parseObject(strDate); 
	    	ret._uidOfflineCaseID = cursor.getString(cursor.getColumnIndex("uidOfflineCaseID"));
	    	ret._strCaseID = cursor.getString(cursor.getColumnIndex("strCaseID"));
	    	ret._idfCase = cursor.getLong(cursor.getColumnIndex("idfCase"));
	
	    	ret._strLocalIdentifier = cursor.getString(cursor.getColumnIndex("strLocalIdentifier"));
	    	ret._idfsTentativeDiagnosis = cursor.getLong(cursor.getColumnIndex("idfsTentativeDiagnosis"));
	    	strDate = cursor.getString(cursor.getColumnIndex("datTentativeDiagnosisDate"));
	    	if (strDate != null && strDate != "")
	    		ret._datTentativeDiagnosisDate = (Date)formatterDate.parseObject(strDate);
	    	ret._strFamilyName = cursor.getString(cursor.getColumnIndex("strFamilyName"));
	    	ret._strFirstName = cursor.getString(cursor.getColumnIndex("strFirstName"));
	    	strDate = cursor.getString(cursor.getColumnIndex("datDateofBirth"));
	    	if (strDate != null && strDate != "")
	    		ret._datDateofBirth = (Date)formatterDate.parseObject(strDate); 
	    	ret._intPatientAge = cursor.getInt(cursor.getColumnIndex("intPatientAge"));
	    	ret._idfsHumanAgeType = cursor.getLong(cursor.getColumnIndex("idfsHumanAgeType"));
	    	ret._idfsHumanGender = cursor.getLong(cursor.getColumnIndex("idfsHumanGender"));
	    	ret._idfsRegionCurrentResidence = cursor.getLong(cursor.getColumnIndex("idfsRegionCurrentResidence"));
	    	ret._idfsRayonCurrentResidence = cursor.getLong(cursor.getColumnIndex("idfsRayonCurrentResidence"));
	    	ret._idfsSettlementCurrentResidence = cursor.getLong(cursor.getColumnIndex("idfsSettlementCurrentResidence"));
	    	ret._strBuilding = cursor.getString(cursor.getColumnIndex("strBuilding"));
	    	ret._strHouse = cursor.getString(cursor.getColumnIndex("strHouse"));
	    	ret._strApartment = cursor.getString(cursor.getColumnIndex("strApartment"));
	    	ret._strStreetName = cursor.getString(cursor.getColumnIndex("strStreetName"));
	    	ret._strPostCode = cursor.getString(cursor.getColumnIndex("strPostCode"));
	    	ret._strHomePhone = cursor.getString(cursor.getColumnIndex("strHomePhone"));
	    	strDate = cursor.getString(cursor.getColumnIndex("datOnSetDate"));
	    	if (strDate != null && strDate != "")
	    		ret._datOnSetDate = (Date)formatterDate.parseObject(strDate); 
	    	ret._idfsFinalState = cursor.getLong(cursor.getColumnIndex("idfsFinalState"));
	    	ret._idfsHospitalizationStatus = cursor.getLong(cursor.getColumnIndex("idfsHospitalizationStatus"));
	    	strDate = cursor.getString(cursor.getColumnIndex("datNotificationDate"));
	    	if (strDate != null && strDate != "")
	    		ret._datNotificationDate = (Date)formatterDate.parseObject(strDate); 
	    	ret._strSentByOffice = cursor.getString(cursor.getColumnIndex("strSentByOffice"));
	    	ret._strSentByPerson = cursor.getString(cursor.getColumnIndex("strSentByPerson"));
	    	ret.bChanged = false;
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		} 
    	return ret;
    }


    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH.mm.ss", Locale.US);
    	Format formatterDate = new SimpleDateFormat("yyyy-MM-dd", Locale.US);
        if (_id != 0)
            ret.put("id", _id);
        ret.put("strLastSynError", _strLastSynError);
        ret.put("intStatus", _intStatus);
        String strDate = formatterDateTime.format(_datCreateDate);
        ret.put("datCreateDate", strDate);
        ret.put("uidOfflineCaseID", _uidOfflineCaseID);
        ret.put("strCaseID", _strCaseID);
        ret.put("idfCase", _idfCase);

        ret.put("strLocalIdentifier", _strLocalIdentifier);
        ret.put("idfsTentativeDiagnosis", _idfsTentativeDiagnosis);
        strDate = null;
        if (_datTentativeDiagnosisDate != null)
        	strDate = formatterDate.format(_datTentativeDiagnosisDate);
        ret.put("datTentativeDiagnosisDate", strDate);
        ret.put("strFamilyName", _strFamilyName);
        ret.put("strFirstName", _strFirstName);
        strDate = null;
        if (_datDateofBirth != null)
        	strDate = formatterDate.format(_datDateofBirth);
        ret.put("datDateofBirth", strDate);
        ret.put("intPatientAge", _intPatientAge);
        ret.put("idfsHumanAgeType", _idfsHumanAgeType);
        ret.put("idfsHumanGender", _idfsHumanGender);
        ret.put("idfsRegionCurrentResidence", _idfsRegionCurrentResidence);
        ret.put("idfsRayonCurrentResidence", _idfsRayonCurrentResidence);
        ret.put("idfsSettlementCurrentResidence", _idfsSettlementCurrentResidence);
        ret.put("strBuilding", _strBuilding);
        ret.put("strHouse", _strHouse);
        ret.put("strApartment", _strApartment);
        ret.put("strStreetName", _strStreetName);
        ret.put("strPostCode", _strPostCode);
        ret.put("strHomePhone", _strHomePhone);
        strDate = null;
        if (_datOnSetDate != null)
        	strDate = formatterDate.format(_datOnSetDate);
        ret.put("datOnSetDate", strDate);
        ret.put("idfsFinalState", _idfsFinalState);
        ret.put("idfsHospitalizationStatus", _idfsHospitalizationStatus);
        strDate = null;
        if (_datNotificationDate != null)
        	strDate = formatterDate.format(_datNotificationDate);
        ret.put("datNotificationDate", strDate);
        ret.put("strSentByOffice", _strSentByOffice);
        ret.put("strSentByPerson", _strSentByPerson);
        return ret;
    }

    public static final Parcelable.Creator<HumanCase> CREATOR = new Parcelable.Creator<HumanCase>()
    {
        public HumanCase createFromParcel(Parcel in) {
            return new HumanCase(in);
        }
 
        public HumanCase[] newArray(int size) {
            return new HumanCase[size];
        }
    };

    public HumanCase(Parcel source)
    {
        _id = source.readLong();
        _strLastSynError = source.readString();
        _intStatus = source.readInt();
        _datCreateDate = (Date)source.readSerializable();
        _uidOfflineCaseID = source.readString();
        _strCaseID = source.readString();
        _idfCase = source.readLong();

        _strLocalIdentifier = source.readString();
        _idfsTentativeDiagnosis = source.readLong();
        _datTentativeDiagnosisDate = (Date)source.readSerializable();
        _strFamilyName = source.readString();
        _strFirstName = source.readString();
        _datDateofBirth = (Date)source.readSerializable();
        _intPatientAge = source.readInt();
        _idfsHumanAgeType = source.readLong();
        _idfsHumanGender = source.readLong();
        _idfsRegionCurrentResidence = source.readLong();
        _idfsRayonCurrentResidence = source.readLong();
        _idfsSettlementCurrentResidence = source.readLong();
        _strBuilding = source.readString();
        _strHouse = source.readString();
        _strApartment = source.readString();
        _strStreetName = source.readString();
        _strPostCode = source.readString();
        _strHomePhone = source.readString();
        _datOnSetDate = (Date)source.readSerializable();
        _idfsFinalState = source.readLong();
        _idfsHospitalizationStatus = source.readLong();
        _datNotificationDate = (Date)source.readSerializable();
        _strSentByOffice = source.readString();
        _strSentByPerson = source.readString();
        bChanged = false;
    }
    
    @Override
	public int describeContents() {
        return 4;
	}
	
	@Override
	public void writeToParcel(Parcel dest, int arg1) {
		dest.writeLong(_id);
        dest.writeString(_strLastSynError);
        dest.writeInt(_intStatus);
        dest.writeSerializable(_datCreateDate);
        dest.writeString(_uidOfflineCaseID);
        dest.writeString(_strCaseID);
        dest.writeLong(_idfCase);

        dest.writeString(_strLocalIdentifier);
        dest.writeLong(_idfsTentativeDiagnosis);
        dest.writeSerializable(_datTentativeDiagnosisDate);
        dest.writeString(_strFamilyName);
        dest.writeString(_strFirstName);
        dest.writeSerializable(_datDateofBirth);
        dest.writeInt(_intPatientAge);
        dest.writeLong(_idfsHumanAgeType);
        dest.writeLong(_idfsHumanGender);
        dest.writeLong(_idfsRegionCurrentResidence);
        dest.writeLong(_idfsRayonCurrentResidence);
        dest.writeLong(_idfsSettlementCurrentResidence);
        dest.writeString(_strBuilding);
        dest.writeString(_strHouse);
        dest.writeString(_strApartment);
        dest.writeString(_strStreetName);
        dest.writeString(_strPostCode);
        dest.writeString(_strHomePhone);
        dest.writeSerializable(_datOnSetDate);
        dest.writeLong(_idfsFinalState);
        dest.writeLong(_idfsHospitalizationStatus);
        dest.writeSerializable(_datNotificationDate);
        dest.writeString(_strSentByOffice);
        dest.writeString(_strSentByPerson);
	}
}
