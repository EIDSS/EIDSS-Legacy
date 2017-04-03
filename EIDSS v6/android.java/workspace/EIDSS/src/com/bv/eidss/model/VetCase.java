package com.bv.eidss.model;

import java.io.IOException;
import java.text.Format;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.UUID;

import org.xmlpull.v1.XmlSerializer;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.utils.DateHelpers;

public class VetCase implements Parcelable, IValidatable {

    private long _id;
    public long getId() { return _id; } 
    public void setId(long value) { _id = value; }
    private String _strLastSynError;
    public String getLastSynError() { return _strLastSynError; } 
    public void setLastSynError(String value) { _strLastSynError = value; }
    private int _intStatus; //  1 - new; 2 - synchronized; 3 - changed; 4 - unloaded;
    public int getStatus() { return _intStatus; } 
    public void setStatusChanged() { _intStatus = CaseStatus.CHANGED; } 
    public void setStatusSyn() { _intStatus = CaseStatus.SYNCHRONIZED; } 
    public void setStatusUploaded() { _intStatus = CaseStatus.UNLOADED; } 
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
    private long _idfCaseType;
    public long getCaseType() { return _idfCaseType; } 
    public void setCaseType(long value) { _idfCaseType = value; }
    private String _strCaseType;
    public String getStrCaseType() { return _strCaseType; } 
    private long _idfCaseReportType;
    public long getCaseReportType() { return _idfCaseReportType; } 
    public void setCaseReportType(long value) { bChanged = bChanged || _idfCaseReportType != value; _idfCaseReportType = value; }

    private String _strLocalIdentifier;
    public String getLocalIdentifier() { return _strLocalIdentifier; } 
    public void setLocalIdentifier(String value) { bChanged = bChanged || _strLocalIdentifier != value; _strLocalIdentifier = value; }
    private long _idfsTentativeDiagnosis;
    public long getTentativeDiagnosis() { return _idfsTentativeDiagnosis; } 
    public void setTentativeDiagnosis(long value) { bChanged = bChanged || _idfsTentativeDiagnosis != value; _idfsTentativeDiagnosis = value; }
    private String _strTentativeDiagnosis;
    public String getStrTentativeDiagnosis() { return _strTentativeDiagnosis; } 
    private Date _datTentativeDiagnosisDate;
    public Date getTentativeDiagnosisDate() { return _datTentativeDiagnosisDate; } 
    public void setTentativeDiagnosisDate(Date value) { bChanged = bChanged || _datTentativeDiagnosisDate != value; _datTentativeDiagnosisDate = value; }
    private String _strFarmCode;
    public String getFarmCode() { return _strFarmCode; } 
    public void setFarmCode(String value) { bChanged = bChanged || _strFarmCode != value; _strFarmCode = value; }
    private String _strFarmName;
    public String getFarmName() { return _strFarmName; } 
    public void setFarmName(String value) { bChanged = bChanged || _strFarmName != value; _strFarmName = value; }
    private String _strOwnerLastName;
    public String getOwnerLastName() { return _strOwnerLastName; } 
    public void setOwnerLastName(String value) { bChanged = bChanged || _strOwnerLastName != value; _strOwnerLastName = value; }
    private String _strOwnerFirstName;
    public String getOwnerFirstName() { return _strOwnerFirstName; } 
    public void setOwnerFirstName(String value) { bChanged = bChanged || _strOwnerFirstName != value; _strOwnerFirstName = value; }
    private String _strOwnerMiddleName;
    public String getOwnerMiddleName() { return _strOwnerMiddleName; } 
    public void setOwnerMiddleName(String value) { bChanged = bChanged || _strOwnerMiddleName != value; _strOwnerMiddleName = value; }
    private long _idfsRegion;
    public long getRegion() { return _idfsRegion; } 
    public void setRegion(long value) { bChanged = bChanged || _idfsRegion != value; _idfsRegion = value; }
    private long _idfsRayon;
    public long getRayon() { return _idfsRayon; } 
    public void setRayon(long value) { bChanged = bChanged || _idfsRayon != value; _idfsRayon = value; }
    private long _idfsSettlement;
    public long getSettlement() { return _idfsSettlement; } 
    public void setSettlement(long value) { bChanged = bChanged || _idfsSettlement != value; _idfsSettlement = value; }
    private String _strAddress;
    public String getAddress() { return _strAddress; } 
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
    private String _strPhone;
    public String getPhone() { return _strPhone; } 
    public void setPhone(String value) { bChanged = bChanged || _strPhone != value; _strPhone = value; }
    private double _dblLongitude;
    public double getLongitude()  { return _dblLongitude; } 
    public void setLongitude(double value) { bChanged = bChanged || _dblLongitude != value; if(value>180) _dblLongitude = 180; else if(value<-180) _dblLongitude = -180; else  _dblLongitude = value; }
    private double _dblLatitude;
    public double getLatitude() { return _dblLatitude; } 
    public void setLatitude(double value) { bChanged = bChanged || _dblLatitude != value; if(value>85) _dblLatitude = 85; else if(value<-85) _dblLatitude = -85; else  _dblLatitude = value; }

    private Date _datReportDate;
    public Date getReportDate() { return _datReportDate; }
    public void setReportDate(Date value) { _datReportDate = value; }
    private String _strSentByOffice;
    public String getSentByOffice() { return _strSentByOffice; }
    public void setSentByOffice(String value) { _strSentByOffice = value; }
    private String _strSentByPerson;
    public String getSentByPerson() { return _strSentByPerson; }
    public void setSentByPerson(String value) { _strSentByPerson = value; }
    
    public List<Species> species;
    public int species_selection;

    private Boolean bChanged;
    public Boolean getChanged() { 
        for(Species s:species)
        	bChanged = bChanged || s.getChanged();
    	return bChanged;
    }
    public void setUnchanged() {
        for(Species s:species)
        	s.setUnchanged();
    	bChanged = false;
    }
    public void deleteSpecies(int pos) {
    	species.remove(pos);
    	bChanged = true;
    }

    private VetCase()
    {
        species = new ArrayList<Species>();
    }

    public static VetCase CreateNew(long CaseType)
    {
    	VetCase ret = new VetCase();
    	ret._idfCaseType = CaseType;
        ret._intStatus = CaseStatus.NEW;
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret._strCaseID = "(new)";
        ret.species.add(Species.CreateNew(0));
        ret._datCreateDate = new Date();
        ret.bChanged = true;
        return ret;
    }

    public static VetCase FromCursor(Cursor cursor)
    {
    	VetCase ret = new VetCase();
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
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
	    	ret._idfCaseType = cursor.getLong(cursor.getColumnIndex("idfCaseType"));
	    	if(cursor.getColumnIndex("strCaseType") >= 0)
	    		ret._strCaseType = cursor.getString(cursor.getColumnIndex("strCaseType"));
	    	ret._idfCaseReportType = cursor.getLong(cursor.getColumnIndex("idfCaseReportType"));
	
	    	ret._strLocalIdentifier = cursor.getString(cursor.getColumnIndex("strLocalIdentifier"));
	    	ret._idfsTentativeDiagnosis = cursor.getLong(cursor.getColumnIndex("idfsTentativeDiagnosis"));
	    	if(cursor.getColumnIndex("strTentativeDiagnosis") >= 0)
	    		ret._strTentativeDiagnosis = cursor.getString(cursor.getColumnIndex("strTentativeDiagnosis"));
	    	strDate = cursor.getString(cursor.getColumnIndex("datTentativeDiagnosisDate"));
	    	if (strDate != null && strDate != "")
	    		ret._datTentativeDiagnosisDate = (Date)formatterDate.parseObject(strDate);
	    	ret._strFarmCode = cursor.getString(cursor.getColumnIndex("strFarmCode"));
	    	ret._strFarmName = cursor.getString(cursor.getColumnIndex("strFarmName"));
	    	ret._strOwnerLastName = cursor.getString(cursor.getColumnIndex("strOwnerLastName"));
	    	ret._strOwnerFirstName = cursor.getString(cursor.getColumnIndex("strOwnerFirstName"));
	    	ret._strOwnerMiddleName = cursor.getString(cursor.getColumnIndex("strOwnerMiddleName"));
	    	ret._idfsRegion = cursor.getLong(cursor.getColumnIndex("idfsRegion"));
	    	ret._idfsRayon = cursor.getLong(cursor.getColumnIndex("idfsRayon"));
	    	ret._idfsSettlement = cursor.getLong(cursor.getColumnIndex("idfsSettlement"));
	    	if(cursor.getColumnIndex("strRegion") >= 0) {
		    	String region = cursor.getString(cursor.getColumnIndex("strRegion"));
		    	String rayon = cursor.getString(cursor.getColumnIndex("strRayon"));
		    	String settlement = cursor.getString(cursor.getColumnIndex("strSettlement"));
		    	ret._strAddress = region + ", " + rayon;
		    	if(!settlement.isEmpty())
		    		ret._strAddress += ", " + settlement;
	    	}
	    	ret._strBuilding = cursor.getString(cursor.getColumnIndex("strBuilding"));
	    	ret._strHouse = cursor.getString(cursor.getColumnIndex("strHouse"));
	    	ret._strApartment = cursor.getString(cursor.getColumnIndex("strApartment"));
	    	ret._strStreetName = cursor.getString(cursor.getColumnIndex("strStreetName"));
	    	ret._strPostCode = cursor.getString(cursor.getColumnIndex("strPostCode"));
	    	ret._strPhone = cursor.getString(cursor.getColumnIndex("strPhone"));
	    	ret._dblLongitude = cursor.getDouble(cursor.getColumnIndex("dblLongitude"));
	    	ret._dblLatitude = cursor.getDouble(cursor.getColumnIndex("dblLatitude"));
	    	strDate = cursor.getString(cursor.getColumnIndex("datEnteredDate"));
	    	if (strDate != null && strDate != "")
	    		ret._datReportDate = (Date)formatterDate.parseObject(strDate); 
	    	ret._strSentByOffice = cursor.getString(cursor.getColumnIndex("strSentByOffice"));
	    	ret._strSentByPerson = cursor.getString(cursor.getColumnIndex("strSentByPerson"));
	        ret.species = new ArrayList<Species>();
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
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
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
        ret.put("idfCaseType", _idfCaseType);
        ret.put("idfCaseReportType", _idfCaseReportType);

        ret.put("strLocalIdentifier", _strLocalIdentifier);
        ret.put("idfsTentativeDiagnosis", _idfsTentativeDiagnosis);
        strDate = null;
        if (_datTentativeDiagnosisDate != null)
        	strDate = formatterDate.format(_datTentativeDiagnosisDate);
        ret.put("datTentativeDiagnosisDate", strDate);
        ret.put("strFarmCode", _strFarmCode);
        ret.put("strFarmName", _strFarmName);
        ret.put("strOwnerLastName", _strOwnerLastName);
        ret.put("strOwnerFirstName", _strOwnerFirstName);
        ret.put("strOwnerMiddleName", _strOwnerMiddleName);
        ret.put("idfsRegion", _idfsRegion);
        ret.put("idfsRayon", _idfsRayon);
        ret.put("idfsSettlement", _idfsSettlement);
        ret.put("strBuilding", _strBuilding);
        ret.put("strHouse", _strHouse);
        ret.put("strApartment", _strApartment);
        ret.put("strStreetName", _strStreetName);
        ret.put("strPostCode", _strPostCode);
        ret.put("strPhone", _strPhone);
        ret.put("dblLongitude", _dblLongitude);
        ret.put("dblLatitude", _dblLatitude);
        strDate = null;
        if (_datReportDate != null)
        	strDate = formatterDate.format(_datReportDate);
        ret.put("datEnteredDate", strDate);
        ret.put("strSentByOffice", _strSentByOffice);
        ret.put("strSentByPerson", _strSentByPerson);
        return ret;
    }

    public static final Parcelable.Creator<VetCase> CREATOR = new Parcelable.Creator<VetCase>()
    {
        public VetCase createFromParcel(Parcel in) {
            return new VetCase(in);
        }
 
        public VetCase[] newArray(int size) {
            return new VetCase[size];
        }
    };

    private VetCase(Parcel source)
    {
    	this();
        _id = source.readLong();
        _strLastSynError = source.readString();
        _intStatus = source.readInt();
        _datCreateDate = (Date)source.readSerializable();
        _uidOfflineCaseID = source.readString();
        _strCaseID = source.readString();
        _idfCase = source.readLong();
        _idfCaseType = source.readLong();
        _idfCaseReportType = source.readLong();

        _strLocalIdentifier = source.readString();
        _idfsTentativeDiagnosis = source.readLong();
        _datTentativeDiagnosisDate = (Date)source.readSerializable();
        _strFarmCode = source.readString();
        _strFarmName = source.readString();
        _strOwnerLastName = source.readString();
        _strOwnerFirstName = source.readString();
        _strOwnerMiddleName = source.readString();
        _idfsRegion = source.readLong();
        _idfsRayon = source.readLong();
        _idfsSettlement = source.readLong();
        _strBuilding = source.readString();
        _strHouse = source.readString();
        _strApartment = source.readString();
        _strStreetName = source.readString();
        _strPostCode = source.readString();
        _strPhone = source.readString();
        _dblLongitude = source.readDouble();
        _dblLatitude = source.readDouble();

        _datReportDate = (Date)source.readSerializable();
        _strSentByOffice = source.readString();
        _strSentByPerson = source.readString();
        
        source.readTypedList(species, Species.CREATOR);

        bChanged = source.readByte() == 1;
    }
    
    @Override
	public int describeContents() {
        return 0;
	}
	
	@Override
	public void writeToParcel(Parcel dest, int flag) {
		dest.writeLong(_id);
        dest.writeString(_strLastSynError);
        dest.writeInt(_intStatus);
        dest.writeSerializable(_datCreateDate);
        dest.writeString(_uidOfflineCaseID);
        dest.writeString(_strCaseID);
        dest.writeLong(_idfCase);
        dest.writeLong(_idfCaseType);
        dest.writeLong(_idfCaseReportType);

        dest.writeString(_strLocalIdentifier);
        dest.writeLong(_idfsTentativeDiagnosis);
        dest.writeSerializable(_datTentativeDiagnosisDate);
        dest.writeString(_strFarmCode);
        dest.writeString(_strFarmName);
        dest.writeString(_strOwnerLastName);
        dest.writeString(_strOwnerFirstName);
        dest.writeString(_strOwnerMiddleName);
        dest.writeLong(_idfsRegion);
        dest.writeLong(_idfsRayon);
        dest.writeLong(_idfsSettlement);
        dest.writeString(_strBuilding);
        dest.writeString(_strHouse);
        dest.writeString(_strApartment);
        dest.writeString(_strStreetName);
        dest.writeString(_strPostCode);
        dest.writeString(_strPhone);
        dest.writeDouble(_dblLatitude);
        dest.writeDouble(_dblLongitude);

        dest.writeSerializable(_datReportDate);
        dest.writeString(_strSentByOffice);
        dest.writeString(_strSentByPerson);
        
        dest.writeTypedList(species);
        
        dest.writeByte((byte) (bChanged ? 1 : 0));     
        }

	@Override
	public ValidateCode Validate() {
        if (getCaseReportType() == 0)
        	return ValidateCode.ReportTypeMandatory;
        if (getTentativeDiagnosis() == 0)
            return ValidateCode.DiagnosisMandatory;
        if (getOwnerLastName() == null || getOwnerLastName().trim().length() == 0)
        	return ValidateCode.LastNameMandatory;
        if (getRegion() == 0)
        	return ValidateCode.RegionMandatory;
        if (getRayon() == 0)
        	return ValidateCode.RayonMandatory;
        if (getTentativeDiagnosisDate() != null && getTentativeDiagnosisDate().after(DateHelpers.Today()))
        	return ValidateCode.DateOfDiagnosisCheckCurrent;
        if (getTentativeDiagnosisDate() != null && getReportDate() != null && getReportDate().after(getTentativeDiagnosisDate()))
        	return ValidateCode.DateOfEnteredCheckDiagnosis;
        if (getReportDate() != null && getReportDate().after(DateHelpers.Today()))
        	return ValidateCode.DateOfReportCheckCurrent;
        //if (species.size() == 0)
        //	return ValidateCode.SpeciesMandatory;
        for(Species s:species)
        {
			ValidateCode vc = s.Validate();
			if (vc != ValidateCode.OK)
				return vc;
        }
		return ValidateCode.OK;
	}

	public void writeXml(long country, XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
    	Format formatterDateTime = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
        serializer.startTag("", "case");
        if (getCase() != 0) 
        	serializer.attribute("", "id", String.valueOf(getCase()));
        if (getCaseType() != 0) {
        	serializer.attribute("", "caseType", String.valueOf(getCaseType()));
        	serializer.attribute("", "caseHACode", String.valueOf(GetVetCaseHaCode(getCaseType())));
        }
        if (getCaseReportType() != 0) 
        	serializer.attribute("", "reportType", String.valueOf(getCaseReportType()));
        if (getCaseID() != null) 
        	serializer.attribute("", "caseID", getCaseID());
        if (getOfflineCaseID() != null) 
        	serializer.attribute("", "offlineCaseID", getOfflineCaseID());
        if (getLocalIdentifier() != null) 
        	serializer.attribute("", "localIdentifier", getLocalIdentifier());
        if (getTentativeDiagnosis() != 0) 
	        serializer.attribute("", "tentativeDiagnosis", String.valueOf(getTentativeDiagnosis()));
        if (getTentativeDiagnosisDate() != null) 
	        serializer.attribute("", "tentativeDiagnosisDate", formatterDateTime.format(getTentativeDiagnosisDate()).replace(' ', 'T'));
        if (getFarmCode() != null) 
	        serializer.attribute("", "farmCode", getFarmCode());
        if (getFarmName() != null) 
	        serializer.attribute("", "farmName", getFarmName());
        if (getOwnerLastName() != null) 
	        serializer.attribute("", "ownerLastName", getOwnerLastName());
        if (getOwnerFirstName() != null) 
	        serializer.attribute("", "ownerFirstName", getOwnerFirstName());
        if (getOwnerMiddleName() != null) 
	        serializer.attribute("", "ownerMiddleName", getOwnerMiddleName());

        serializer.attribute("", "country", String.valueOf(country));
        if (getRegion() != 0) 
	        serializer.attribute("", "region", String.valueOf(getRegion()));
        if (getRayon() != 0) 
	        serializer.attribute("", "rayon", String.valueOf(getRayon()));
        if (getSettlement() != 0) 
	        serializer.attribute("", "settlement", String.valueOf(getSettlement()));
        if (getBuilding() != null) 
			serializer.attribute("", "building", getBuilding());
        if (getHouse() != null) 
			serializer.attribute("", "house", getHouse());
        if (getApartment() != null) 
			serializer.attribute("", "apartment", getApartment());
        if (getStreetName() != null) 
			serializer.attribute("", "street", getStreetName());
        if (getPostCode() != null) 
			serializer.attribute("", "zipCode", getPostCode());
        if (getPhone() != null) 
			serializer.attribute("", "phone", getPhone());
        if (getLatitude() != 0) 
			serializer.attribute("", "latitude", String.valueOf(getLatitude()));
        if (getLongitude() != 0) 
			serializer.attribute("", "longitude", String.valueOf(getLongitude()));
        if (getReportDate() != null) 
	        serializer.attribute("", "enteredDate", formatterDateTime.format(getReportDate()).replace(' ', 'T'));
        serializer.startTag("", "species");
        for (Species sp: species){
        		sp.writeXml(serializer);
        	}
        serializer.endTag("", "species");
        serializer.endTag("", "case");
	}
	
	public static void writeXml(List<VetCase> vcs, long country, XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "veterinary");
        for (VetCase vc: vcs){
        	if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED || vc.getStatus() == CaseStatus.UNLOADED){
        		vc.writeXml(country, serializer);
        	}
        }
        serializer.endTag("", "veterinary");
	}

	public static void updateStatusUploaded(List<VetCase> vcs){
        for (VetCase vc: vcs){
        	if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED){
        		vc.setStatusUploaded();
        	}
        }
	}
    
	public static int GetVetCaseHaCode(long caseType)
    {
    	if(caseType == CaseType.AVIAN) return CaseTypeHACode.AVIAN;
    	if(caseType == CaseType.LIVESTOCK) return CaseTypeHACode.LIVESTOCK;
    	return 0;
    }

}
