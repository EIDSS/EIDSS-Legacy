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

public class VetCase_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public VetCase_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
        _dblLongitude = 0d;
        _dblLatitude = 0d;
    }
  public static String eidss_LocalIdentifier = "VetCase.LocalIdentifier";
  public static String eidss_CaseReportType = "VetCase.CaseReportType";
  public static String eidss_TentativeDiagnosis = "VetCase.TentativeDiagnosis";
  public static String eidss_TentativeDiagnosisDate = "VetCase.TentativeDiagnosisDate";
  public static String eidss_ReportDate = "VetCase.InitialReportDate";
  public static String eidss_SentByOffice = "VetCase.ReportedByOffice";
  public static String eidss_SentByPerson = "VetCase.PersonReportedBy";
  public static String eidss_InvestigatedByPerson = "VetCase.Investigator";
  public static String eidss_AssignedDate = "VetCase.AssignedDate";
  public static String eidss_InvestigationDate = "VetCase.InvestigationDate";
  public static String eidss_FinalCaseStatus = "VetCase.CaseClassification";
  public static String eidss_FinalDiagnosis = "VetCase.FinalDiagnosis";
  public static String eidss_FinalDiagnosisDate = "VetCase.FinalDiagnosisDate";
  public static String eidss_Comment = "VetCase.Comments";
  public static String eidss_YNTestsConducted = "VetCase.TestConducted";
  public static String eidss_FarmCode = "VetCase.Farm.FarmID";
  public static String eidss_RootFarm = "VetCase.Farm.RootFarm";
  public static String eidss_OwnerLastName = "VetCase.Farm.FarmOwnerLastName";
  public static String eidss_OwnerFirstName = "VetCase.Farm.FarmOwnerFirstName";
  public static String eidss_OwnerMiddleName = "VetCase.Farm.FarmOwnerMiddleName";
  public static String eidss_Region = "VetCase.Farm.Address.Region";
  public static String eidss_Rayon = "VetCase.Farm.Address.Rayon";
  public static String eidss_Settlement = "VetCase.Farm.Address.Settlement";
  public static String eidss_StreetName = "VetCase.Farm.Address.Street";
  public static String eidss_Building = "VetCase.Farm.Address.Building";
  public static String eidss_House = "VetCase.Farm.Address.House";
  public static String eidss_Apartment = "VetCase.Farm.Address.Apt";
  public static String eidss_PostCode = "VetCase.Farm.Address.PostalCode";
  public static String eidss_Longitude = "VetCase.Farm.Address.PointGeoLocation.Longitude";
  public static String eidss_Latitude = "VetCase.Farm.Address.PointGeoLocation.Latitude";
  public static String eidss_Phone = "VetCase.Farm.Address.Phone";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_LocalIdentifier, R.string.VetCase_strLocalIdentifier, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getLocalIdentifier(); }}));
        add(new FieldMetadata(eidss_CaseReportType, R.string.VetCase_idfsCaseReportType, new ICallable<Long, VetCase_object>() { public Long call(VetCase_object t) { return t.getCaseReportType(); }}));
        add(new FieldMetadata(eidss_TentativeDiagnosis, R.string.VetCase_idfsTentativeDiagnosis, new ICallable<Long, VetCase_object>() { public Long call(VetCase_object t) { return t.getTentativeDiagnosis(); }}));
        add(new FieldMetadata(eidss_TentativeDiagnosisDate, R.string.VetCase_datTentativeDiagnosisDate, new ICallable<Date, VetCase_object>() { public Date call(VetCase_object t) { return t.getTentativeDiagnosisDate(); }}));
        add(new FieldMetadata(eidss_ReportDate, R.string.VetCase_datReportDate, new ICallable<Date, VetCase_object>() { public Date call(VetCase_object t) { return t.getReportDate(); }}));
        add(new FieldMetadata(eidss_Comment, R.string.VetCase_strComment, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getComment(); }}));
        add(new FieldMetadata(eidss_RootFarm, R.string.VetCase_idfRootFarm, new ICallable<Long, VetCase_object>() { public Long call(VetCase_object t) { return t.getRootFarm(); }}));
        add(new FieldMetadata(eidss_OwnerLastName, R.string.VetCase_strOwnerLastName, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getOwnerLastName(); }}));
        add(new FieldMetadata(eidss_OwnerFirstName, R.string.VetCase_strOwnerFirstName, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getOwnerFirstName(); }}));
        add(new FieldMetadata(eidss_OwnerMiddleName, R.string.VetCase_strOwnerMiddleName, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getOwnerMiddleName(); }}));
        add(new FieldMetadata(eidss_Region, R.string.VetCase_idfsRegion, new ICallable<Long, VetCase_object>() { public Long call(VetCase_object t) { return t.getRegion(); }}));
        add(new FieldMetadata(eidss_Rayon, R.string.VetCase_idfsRayon, new ICallable<Long, VetCase_object>() { public Long call(VetCase_object t) { return t.getRayon(); }}));
        add(new FieldMetadata(eidss_Settlement, R.string.VetCase_idfsSettlement, new ICallable<Long, VetCase_object>() { public Long call(VetCase_object t) { return t.getSettlement(); }}));
        add(new FieldMetadata(eidss_StreetName, R.string.VetCase_strStreetName, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getStreetName(); }}));
        add(new FieldMetadata(eidss_Building, R.string.VetCase_strBuilding, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getBuilding(); }}));
        add(new FieldMetadata(eidss_House, R.string.VetCase_strHouse, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getHouse(); }}));
        add(new FieldMetadata(eidss_Apartment, R.string.VetCase_strApartment, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getApartment(); }}));
        add(new FieldMetadata(eidss_PostCode, R.string.VetCase_strPostCode, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getPostCode(); }}));
        add(new FieldMetadata(eidss_Longitude, R.string.VetCase_dblLongitude, new ICallable<Double, VetCase_object>() { public Double call(VetCase_object t) { return t.getLongitude(); }}));
        add(new FieldMetadata(eidss_Latitude, R.string.VetCase_dblLatitude, new ICallable<Double, VetCase_object>() { public Double call(VetCase_object t) { return t.getLatitude(); }}));
        add(new FieldMetadata(eidss_Phone, R.string.VetCase_strPhone, new ICallable<String, VetCase_object>() { public String call(VetCase_object t) { return t.getPhone(); }}));
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
  protected long _idfCase;
  public long getCase(){return _idfCase;}
   public void setCase(long value) { bChanged = bChanged || _idfCase != value; _intChanged = ((_intChanged == 1) || _idfCase != value) ? 1 : 0; if (_idfCase != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfCase", _idfCase, value); } _idfCase = value; }}
  protected long _idfsHerd;
  public long getHerd(){return _idfsHerd;}
   public void setHerd(long value) { bChanged = bChanged || _idfsHerd != value; _intChanged = ((_intChanged == 1) || _idfsHerd != value) ? 1 : 0; if (_idfsHerd != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsHerd", _idfsHerd, value); } _idfsHerd = value; }}
  protected long _idfsFormTemplate;
  public long getFormTemplate(){return _idfsFormTemplate;}
   public void setFormTemplate(long value) { bChanged = bChanged || _idfsFormTemplate != value; _intChanged = ((_intChanged == 1) || _idfsFormTemplate != value) ? 1 : 0; if (_idfsFormTemplate != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsFormTemplate", _idfsFormTemplate, value); } _idfsFormTemplate = value; }}
  protected long _idfObservation;
  public long getObservation(){return _idfObservation;}
   public void setObservation(long value) { bChanged = bChanged || _idfObservation != value; _intChanged = ((_intChanged == 1) || _idfObservation != value) ? 1 : 0; if (_idfObservation != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfObservation", _idfObservation, value); } _idfObservation = value; }}
  protected long _idfObservationFarm;
  public long getObservationFarm(){return _idfObservationFarm;}
   public void setObservationFarm(long value) { bChanged = bChanged || _idfObservationFarm != value; _intChanged = ((_intChanged == 1) || _idfObservationFarm != value) ? 1 : 0; if (_idfObservationFarm != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfObservationFarm", _idfObservationFarm, value); } _idfObservationFarm = value; }}
  protected Date _datModificationDate;
  public Date getModificationDate(){return _datModificationDate;}
   public void setModificationDate(Date value) { if(_datModificationDate == null && value == null) return; bChanged = bChanged || _datModificationDate == null || value == null || !_datModificationDate.equals(value); _intChanged = ((_intChanged == 1) || _datModificationDate == null || value == null || !_datModificationDate.equals(value)) ? 1 : 0; if (_datModificationDate == null || value == null || !_datModificationDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datModificationDate", _datModificationDate, value); } _datModificationDate = value; }}
  protected long _idfCaseType;
  public long getCaseType(){return _idfCaseType;}
   public void setCaseType(long value) { bChanged = bChanged || _idfCaseType != value; _intChanged = ((_intChanged == 1) || _idfCaseType != value) ? 1 : 0; if (_idfCaseType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfCaseType", _idfCaseType, value); } _idfCaseType = value; }}
  protected String _strCaseID;
  public String getCaseID(){return _strCaseID;}
  public void setCaseID(String value) { _strCaseID = value; }
  protected String _strLocalIdentifier;
  public String getLocalIdentifier(){return _strLocalIdentifier;}
   public void setLocalIdentifier(String value) { if(_strLocalIdentifier == null && value == null) return; bChanged = bChanged || _strLocalIdentifier == null || value == null || !_strLocalIdentifier.equals(value); _intChanged = ((_intChanged == 1) || _strLocalIdentifier == null || value == null || !_strLocalIdentifier.equals(value)) ? 1 : 0; if (_strLocalIdentifier == null || value == null || !_strLocalIdentifier.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strLocalIdentifier", _strLocalIdentifier, value); } _strLocalIdentifier = value; }}
  protected long _idfsCaseReportType;
  public long getCaseReportType(){return _idfsCaseReportType;}
   public void setCaseReportType(long value) { bChanged = bChanged || _idfsCaseReportType != value; _intChanged = ((_intChanged == 1) || _idfsCaseReportType != value) ? 1 : 0; if (_idfsCaseReportType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsCaseReportType", _idfsCaseReportType, value); } _idfsCaseReportType = value; }}
  protected long _idfsTentativeDiagnosis;
  public long getTentativeDiagnosis(){return _idfsTentativeDiagnosis;}
   public void setTentativeDiagnosis(long value) { bChanged = bChanged || _idfsTentativeDiagnosis != value; _intChanged = ((_intChanged == 1) || _idfsTentativeDiagnosis != value) ? 1 : 0; if (_idfsTentativeDiagnosis != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsTentativeDiagnosis", _idfsTentativeDiagnosis, value); } _idfsTentativeDiagnosis = value; }}
  protected Date _datTentativeDiagnosisDate;
  public Date getTentativeDiagnosisDate(){return _datTentativeDiagnosisDate;}
   public void setTentativeDiagnosisDate(Date value) { if(_datTentativeDiagnosisDate == null && value == null) return; bChanged = bChanged || _datTentativeDiagnosisDate == null || value == null || !_datTentativeDiagnosisDate.equals(value); _intChanged = ((_intChanged == 1) || _datTentativeDiagnosisDate == null || value == null || !_datTentativeDiagnosisDate.equals(value)) ? 1 : 0; if (_datTentativeDiagnosisDate == null || value == null || !_datTentativeDiagnosisDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datTentativeDiagnosisDate", _datTentativeDiagnosisDate, value); } _datTentativeDiagnosisDate = value; }}
  protected Date _datReportDate;
  public Date getReportDate(){return _datReportDate;}
   public void setReportDate(Date value) { if(_datReportDate == null && value == null) return; bChanged = bChanged || _datReportDate == null || value == null || !_datReportDate.equals(value); _intChanged = ((_intChanged == 1) || _datReportDate == null || value == null || !_datReportDate.equals(value)) ? 1 : 0; if (_datReportDate == null || value == null || !_datReportDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datReportDate", _datReportDate, value); } _datReportDate = value; }}
  protected String _strSentByOffice;
  public String getSentByOffice(){return _strSentByOffice;}
  public void setSentByOffice(String value) { _strSentByOffice = value; }
  protected String _strSentByPerson;
  public String getSentByPerson(){return _strSentByPerson;}
  public void setSentByPerson(String value) { _strSentByPerson = value; }
  protected long _idfInvestigatedByPerson;
  public long getInvestigatedByPerson(){return _idfInvestigatedByPerson;}
  public void setInvestigatedByPerson(long value) { _idfInvestigatedByPerson = value; }
  protected Date _datAssignedDate;
  public Date getAssignedDate(){return _datAssignedDate;}
  public void setAssignedDate(Date value) { _datAssignedDate = value; }
  protected Date _datInvestigationDate;
  public Date getInvestigationDate(){return _datInvestigationDate;}
  public void setInvestigationDate(Date value) { _datInvestigationDate = value; }
  protected long _idfsFinalCaseStatus;
  public long getFinalCaseStatus(){return _idfsFinalCaseStatus;}
  public void setFinalCaseStatus(long value) { _idfsFinalCaseStatus = value; }
  protected String _strFinalDiagnosis;
  public String getFinalDiagnosis(){return _strFinalDiagnosis;}
  public void setFinalDiagnosis(String value) { _strFinalDiagnosis = value; }
  protected Date _datFinalDiagnosisDate;
  public Date getFinalDiagnosisDate(){return _datFinalDiagnosisDate;}
  public void setFinalDiagnosisDate(Date value) { _datFinalDiagnosisDate = value; }
  protected String _strComment;
  public String getComment(){return _strComment;}
   public void setComment(String value) { if(_strComment == null && value == null) return; bChanged = bChanged || _strComment == null || value == null || !_strComment.equals(value); _intChanged = ((_intChanged == 1) || _strComment == null || value == null || !_strComment.equals(value)) ? 1 : 0; if (_strComment == null || value == null || !_strComment.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strComment", _strComment, value); } _strComment = value; }}
  protected long _idfsYNTestsConducted;
  public long getYNTestsConducted(){return _idfsYNTestsConducted;}
  public void setYNTestsConducted(long value) { _idfsYNTestsConducted = value; }
  protected long _idfFarm;
  public long getFarm(){return _idfFarm;}
   public void setFarm(long value) { bChanged = bChanged || _idfFarm != value; _intChanged = ((_intChanged == 1) || _idfFarm != value) ? 1 : 0; if (_idfFarm != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfFarm", _idfFarm, value); } _idfFarm = value; }}
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
  protected String _strPhone;
  public String getPhone(){return _strPhone;}
   public void setPhone(String value) { if(_strPhone == null && value == null) return; bChanged = bChanged || _strPhone == null || value == null || !_strPhone.equals(value); _intChanged = ((_intChanged == 1) || _strPhone == null || value == null || !_strPhone.equals(value)) ? 1 : 0; if (_strPhone == null || value == null || !_strPhone.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strPhone", _strPhone, value); } _strPhone = value; }}

protected static VetCase_object FromCursor(Cursor cursor, VetCase_object ret)
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
  ret._idfCase = cursor.getLong(cursor.getColumnIndex("idfCase"));
  ret._idfsHerd = cursor.getLong(cursor.getColumnIndex("idfsHerd"));
  ret._idfsFormTemplate = cursor.getLong(cursor.getColumnIndex("idfsFormTemplate"));
  ret._idfObservation = cursor.getLong(cursor.getColumnIndex("idfObservation"));
  ret._idfObservationFarm = cursor.getLong(cursor.getColumnIndex("idfObservationFarm"));
  ret._datModificationDate = EidssUtils.ParseDate(cursor, formatterDateTime, "datModificationDate");
  ret._idfCaseType = cursor.getLong(cursor.getColumnIndex("idfCaseType"));
  ret._strCaseID = cursor.getString(cursor.getColumnIndex("strCaseID"));
  ret._strLocalIdentifier = cursor.getString(cursor.getColumnIndex("strLocalIdentifier"));
  ret._idfsCaseReportType = cursor.getLong(cursor.getColumnIndex("idfsCaseReportType"));
  ret._idfsTentativeDiagnosis = cursor.getLong(cursor.getColumnIndex("idfsTentativeDiagnosis"));
  ret._datTentativeDiagnosisDate = EidssUtils.ParseDate(cursor, formatterDate, "datTentativeDiagnosisDate");
  ret._datReportDate = EidssUtils.ParseDate(cursor, formatterDate, "datReportDate");
  ret._strSentByOffice = cursor.getString(cursor.getColumnIndex("strSentByOffice"));
  ret._strSentByPerson = cursor.getString(cursor.getColumnIndex("strSentByPerson"));
  ret._idfInvestigatedByPerson = cursor.getLong(cursor.getColumnIndex("idfInvestigatedByPerson"));
  ret._datAssignedDate = EidssUtils.ParseDate(cursor, formatterDate, "datAssignedDate");
  ret._datInvestigationDate = EidssUtils.ParseDate(cursor, formatterDate, "datInvestigationDate");
  ret._idfsFinalCaseStatus = cursor.getLong(cursor.getColumnIndex("idfsFinalCaseStatus"));
  ret._strFinalDiagnosis = cursor.getString(cursor.getColumnIndex("strFinalDiagnosis"));
  ret._datFinalDiagnosisDate = EidssUtils.ParseDate(cursor, formatterDate, "datFinalDiagnosisDate");
  ret._strComment = cursor.getString(cursor.getColumnIndex("strComment"));
  ret._idfsYNTestsConducted = cursor.getLong(cursor.getColumnIndex("idfsYNTestsConducted"));
  ret._idfFarm = cursor.getLong(cursor.getColumnIndex("idfFarm"));
  ret._strFarmName = cursor.getString(cursor.getColumnIndex("strFarmName"));
  ret._strFarmCode = cursor.getString(cursor.getColumnIndex("strFarmCode"));
  ret._idfRootFarm = cursor.getLong(cursor.getColumnIndex("idfRootFarm"));
  ret._strOwnerLastName = cursor.getString(cursor.getColumnIndex("strOwnerLastName"));
  ret._strOwnerFirstName = cursor.getString(cursor.getColumnIndex("strOwnerFirstName"));
  ret._strOwnerMiddleName = cursor.getString(cursor.getColumnIndex("strOwnerMiddleName"));
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
  ret._strPhone = cursor.getString(cursor.getColumnIndex("strPhone"));
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
  ret.put("idfCase", _idfCase);
  ret.put("idfsHerd", _idfsHerd);
  ret.put("idfsFormTemplate", _idfsFormTemplate);
  ret.put("idfObservation", _idfObservation);
  ret.put("idfObservationFarm", _idfObservationFarm);
    strDate = null;
  if (_datModificationDate != null)
      strDate = formatterDateTime.format(_datModificationDate);
  ret.put("datModificationDate", strDate);
  ret.put("idfCaseType", _idfCaseType);
  ret.put("strCaseID", _strCaseID);
  ret.put("strLocalIdentifier", _strLocalIdentifier);
  ret.put("idfsCaseReportType", _idfsCaseReportType);
  ret.put("idfsTentativeDiagnosis", _idfsTentativeDiagnosis);
    strDate = null;
  if (_datTentativeDiagnosisDate != null)
      strDate = formatterDate.format(_datTentativeDiagnosisDate);
  ret.put("datTentativeDiagnosisDate", strDate);
    strDate = null;
  if (_datReportDate != null)
      strDate = formatterDate.format(_datReportDate);
  ret.put("datReportDate", strDate);
  ret.put("strSentByOffice", _strSentByOffice);
  ret.put("strSentByPerson", _strSentByPerson);
  ret.put("idfInvestigatedByPerson", _idfInvestigatedByPerson);
    strDate = null;
  if (_datAssignedDate != null)
      strDate = formatterDate.format(_datAssignedDate);
  ret.put("datAssignedDate", strDate);
    strDate = null;
  if (_datInvestigationDate != null)
      strDate = formatterDate.format(_datInvestigationDate);
  ret.put("datInvestigationDate", strDate);
  ret.put("idfsFinalCaseStatus", _idfsFinalCaseStatus);
  ret.put("strFinalDiagnosis", _strFinalDiagnosis);
    strDate = null;
  if (_datFinalDiagnosisDate != null)
      strDate = formatterDate.format(_datFinalDiagnosisDate);
  ret.put("datFinalDiagnosisDate", strDate);
  ret.put("strComment", _strComment);
  ret.put("idfsYNTestsConducted", _idfsYNTestsConducted);
  ret.put("idfFarm", _idfFarm);
  ret.put("strFarmName", _strFarmName);
  ret.put("strFarmCode", _strFarmCode);
  ret.put("idfRootFarm", _idfRootFarm);
  ret.put("strOwnerLastName", _strOwnerLastName);
  ret.put("strOwnerFirstName", _strOwnerFirstName);
  ret.put("strOwnerMiddleName", _strOwnerMiddleName);
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
  ret.put("strPhone", _strPhone);

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
  _idfCase = source.readLong();
  _idfsHerd = source.readLong();
  _idfsFormTemplate = source.readLong();
  _idfObservation = source.readLong();
  _idfObservationFarm = source.readLong();
  _datModificationDate = (Date)source.readSerializable();
  _idfCaseType = source.readLong();
  _strCaseID = source.readString();
  _strLocalIdentifier = source.readString();
  _idfsCaseReportType = source.readLong();
  _idfsTentativeDiagnosis = source.readLong();
  _datTentativeDiagnosisDate = (Date)source.readSerializable();
  _datReportDate = (Date)source.readSerializable();
  _strSentByOffice = source.readString();
  _strSentByPerson = source.readString();
  _idfInvestigatedByPerson = source.readLong();
  _datAssignedDate = (Date)source.readSerializable();
  _datInvestigationDate = (Date)source.readSerializable();
  _idfsFinalCaseStatus = source.readLong();
  _strFinalDiagnosis = source.readString();
  _datFinalDiagnosisDate = (Date)source.readSerializable();
  _strComment = source.readString();
  _idfsYNTestsConducted = source.readLong();
  _idfFarm = source.readLong();
  _strFarmName = source.readString();
  _strFarmCode = source.readString();
  _idfRootFarm = source.readLong();
  _strOwnerLastName = source.readString();
  _strOwnerFirstName = source.readString();
  _strOwnerMiddleName = source.readString();
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
  _strPhone = source.readString();
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
  dest.writeLong(_idfCase);
  dest.writeLong(_idfsHerd);
  dest.writeLong(_idfsFormTemplate);
  dest.writeLong(_idfObservation);
  dest.writeLong(_idfObservationFarm);
  dest.writeSerializable(_datModificationDate);
  dest.writeLong(_idfCaseType);
  dest.writeString(_strCaseID);
  dest.writeString(_strLocalIdentifier);
  dest.writeLong(_idfsCaseReportType);
  dest.writeLong(_idfsTentativeDiagnosis);
  dest.writeSerializable(_datTentativeDiagnosisDate);
  dest.writeSerializable(_datReportDate);
  dest.writeString(_strSentByOffice);
  dest.writeString(_strSentByPerson);
  dest.writeLong(_idfInvestigatedByPerson);
  dest.writeSerializable(_datAssignedDate);
  dest.writeSerializable(_datInvestigationDate);
  dest.writeLong(_idfsFinalCaseStatus);
  dest.writeString(_strFinalDiagnosis);
  dest.writeSerializable(_datFinalDiagnosisDate);
  dest.writeString(_strComment);
  dest.writeLong(_idfsYNTestsConducted);
  dest.writeLong(_idfFarm);
  dest.writeString(_strFarmName);
  dest.writeString(_strFarmCode);
  dest.writeLong(_idfRootFarm);
  dest.writeString(_strOwnerLastName);
  dest.writeString(_strOwnerFirstName);
  dest.writeString(_strOwnerMiddleName);
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
  dest.writeString(_strPhone);
  dest.writeInt(bChanged ? 1 : 0);
}

protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException
{
serializer.attribute("", "lang", EidssUtils.getCurrentLanguage());
serializer.attribute("", "intChanged", String.valueOf(_intChanged));
  if (_uidOfflineCaseID != null)
      serializer.attribute("", "uidOfflineCaseID", _uidOfflineCaseID);
  if (_idfCase != 0)
      serializer.attribute("", "idfCase", String.valueOf(_idfCase));
  if (_idfsHerd != 0)
      serializer.attribute("", "idfsHerd", String.valueOf(_idfsHerd));
  if (_idfsFormTemplate != 0)
      serializer.attribute("", "idfsFormTemplate", String.valueOf(_idfsFormTemplate));
  if (_idfObservation != 0)
      serializer.attribute("", "idfObservation", String.valueOf(_idfObservation));
  if (_idfObservationFarm != 0)
      serializer.attribute("", "idfObservationFarm", String.valueOf(_idfObservationFarm));
  if (_datModificationDate != null)
      serializer.attribute("", "datModificationDate", DateHelpers.FormatWithT(_datModificationDate));
  if (_idfCaseType != 0)
      serializer.attribute("", "idfCaseType", String.valueOf(_idfCaseType));
  if (_strCaseID != null)
      serializer.attribute("", "strCaseID", _strCaseID);
  if (_strLocalIdentifier != null)
      serializer.attribute("", "strLocalIdentifier", _strLocalIdentifier);
  if (_idfsCaseReportType != 0)
      serializer.attribute("", "idfsCaseReportType", String.valueOf(_idfsCaseReportType));
  if (_idfsTentativeDiagnosis != 0)
      serializer.attribute("", "idfsTentativeDiagnosis", String.valueOf(_idfsTentativeDiagnosis));
  if (_datTentativeDiagnosisDate != null)
      serializer.attribute("", "datTentativeDiagnosisDate", DateHelpers.FormatWithT(_datTentativeDiagnosisDate));
  if (_datReportDate != null)
      serializer.attribute("", "datReportDate", DateHelpers.FormatWithT(_datReportDate));
  if (_strSentByOffice != null)
      serializer.attribute("", "strSentByOffice", _strSentByOffice);
  if (_strSentByPerson != null)
      serializer.attribute("", "strSentByPerson", _strSentByPerson);
  if (_idfInvestigatedByPerson != 0)
      serializer.attribute("", "idfInvestigatedByPerson", String.valueOf(_idfInvestigatedByPerson));
  if (_datAssignedDate != null)
      serializer.attribute("", "datAssignedDate", DateHelpers.FormatWithT(_datAssignedDate));
  if (_datInvestigationDate != null)
      serializer.attribute("", "datInvestigationDate", DateHelpers.FormatWithT(_datInvestigationDate));
  if (_idfsFinalCaseStatus != 0)
      serializer.attribute("", "idfsFinalCaseStatus", String.valueOf(_idfsFinalCaseStatus));
  if (_strFinalDiagnosis != null)
      serializer.attribute("", "strFinalDiagnosis", _strFinalDiagnosis);
  if (_datFinalDiagnosisDate != null)
      serializer.attribute("", "datFinalDiagnosisDate", DateHelpers.FormatWithT(_datFinalDiagnosisDate));
  if (_strComment != null)
      serializer.attribute("", "strComment", _strComment);
  if (_idfsYNTestsConducted != 0)
      serializer.attribute("", "idfsYNTestsConducted", String.valueOf(_idfsYNTestsConducted));
  if (_idfFarm != 0)
      serializer.attribute("", "idfFarm", String.valueOf(_idfFarm));
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
  if (_strPhone != null)
      serializer.attribute("", "strPhone", _strPhone);
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "uidOfflineCaseID", _uidOfflineCaseID);
  EidssUtils.putToJson(ret, "idfCase", _idfCase);
  EidssUtils.putToJson(ret, "idfsHerd", _idfsHerd);
  EidssUtils.putToJson(ret, "idfsFormTemplate", _idfsFormTemplate);
  EidssUtils.putToJson(ret, "idfObservation", _idfObservation);
  EidssUtils.putToJson(ret, "idfObservationFarm", _idfObservationFarm);
  EidssUtils.putToJson(ret, "datModificationDate", _datModificationDate);
  EidssUtils.putToJson(ret, "idfCaseType", _idfCaseType);
  EidssUtils.putToJson(ret, "strCaseID", _strCaseID);
  EidssUtils.putToJson(ret, "strLocalIdentifier", _strLocalIdentifier);
  EidssUtils.putToJson(ret, "idfsCaseReportType", _idfsCaseReportType);
  EidssUtils.putToJson(ret, "idfsTentativeDiagnosis", _idfsTentativeDiagnosis);
  EidssUtils.putToJson(ret, "datTentativeDiagnosisDate", _datTentativeDiagnosisDate);
  EidssUtils.putToJson(ret, "datReportDate", _datReportDate);
  EidssUtils.putToJson(ret, "strSentByOffice", _strSentByOffice);
  EidssUtils.putToJson(ret, "strSentByPerson", _strSentByPerson);
  EidssUtils.putToJson(ret, "idfInvestigatedByPerson", _idfInvestigatedByPerson);
  EidssUtils.putToJson(ret, "datAssignedDate", _datAssignedDate);
  EidssUtils.putToJson(ret, "datInvestigationDate", _datInvestigationDate);
  EidssUtils.putToJson(ret, "idfsFinalCaseStatus", _idfsFinalCaseStatus);
  EidssUtils.putToJson(ret, "strFinalDiagnosis", _strFinalDiagnosis);
  EidssUtils.putToJson(ret, "datFinalDiagnosisDate", _datFinalDiagnosisDate);
  EidssUtils.putToJson(ret, "strComment", _strComment);
  EidssUtils.putToJson(ret, "idfsYNTestsConducted", _idfsYNTestsConducted);
  EidssUtils.putToJson(ret, "idfFarm", _idfFarm);
  EidssUtils.putToJson(ret, "strFarmName", _strFarmName);
  EidssUtils.putToJson(ret, "strFarmCode", _strFarmCode);
  EidssUtils.putToJson(ret, "idfRootFarm", _idfRootFarm);
  EidssUtils.putToJson(ret, "strOwnerLastName", _strOwnerLastName);
  EidssUtils.putToJson(ret, "strOwnerFirstName", _strOwnerFirstName);
  EidssUtils.putToJson(ret, "strOwnerMiddleName", _strOwnerMiddleName);
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
  EidssUtils.putToJson(ret, "strPhone", _strPhone);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _uidOfflineCaseID = json.getString("uidOfflineCaseID");
  _idfCase = json.getLong("idfCase");
  _idfsHerd = json.getLong("idfsHerd");
  _idfsFormTemplate = json.getLong("idfsFormTemplate");
  _idfObservation = json.getLong("idfObservation");
  _idfObservationFarm = json.getLong("idfObservationFarm");
  _datModificationDate = DateHelpers.ParseWithT(json.getString("datModificationDate"));
  _idfCaseType = json.getLong("idfCaseType");
  _strCaseID = json.getString("strCaseID");
  _strLocalIdentifier = json.getString("strLocalIdentifier");
  _idfsCaseReportType = json.getLong("idfsCaseReportType");
  _idfsTentativeDiagnosis = json.getLong("idfsTentativeDiagnosis");
  _datTentativeDiagnosisDate = DateHelpers.ParseWithT(json.getString("datTentativeDiagnosisDate"));
  _datReportDate = DateHelpers.ParseWithT(json.getString("datReportDate"));
  _strSentByOffice = json.getString("strSentByOffice");
  _strSentByPerson = json.getString("strSentByPerson");
  _idfInvestigatedByPerson = json.getLong("idfInvestigatedByPerson");
  _datAssignedDate = DateHelpers.ParseWithT(json.getString("datAssignedDate"));
  _datInvestigationDate = DateHelpers.ParseWithT(json.getString("datInvestigationDate"));
  _idfsFinalCaseStatus = json.getLong("idfsFinalCaseStatus");
  _strFinalDiagnosis = json.getString("strFinalDiagnosis");
  _datFinalDiagnosisDate = DateHelpers.ParseWithT(json.getString("datFinalDiagnosisDate"));
  _strComment = json.getString("strComment");
  _idfsYNTestsConducted = json.getLong("idfsYNTestsConducted");
  _idfFarm = json.getLong("idfFarm");
  _strFarmName = json.getString("strFarmName");
  _strFarmCode = json.getString("strFarmCode");
  _idfRootFarm = json.getLong("idfRootFarm");
  _strOwnerLastName = json.getString("strOwnerLastName");
  _strOwnerFirstName = json.getString("strOwnerFirstName");
  _strOwnerMiddleName = json.getString("strOwnerMiddleName");
  _idfsRegion = json.getLong("idfsRegion");
  _idfsRayon = json.getLong("idfsRayon");
  _idfsSettlement = json.getLong("idfsSettlement");
  _strStreetName = json.getString("strStreetName");
  _strBuilding = json.getString("strBuilding");
  _strHouse = json.getString("strHouse");
  _strApartment = json.getString("strApartment");
  _strPostCode = json.getString("strPostCode");
  _strPhone = json.getString("strPhone");
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _uidOfflineCaseID = parser.getAttributeValue("", "uidOfflineCaseID");
  _idfCase = parser.getAttributeValue("", "idfCase") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfCase"));
  _idfsHerd = parser.getAttributeValue("", "idfsHerd") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsHerd"));
  _idfsFormTemplate = parser.getAttributeValue("", "idfsFormTemplate") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsFormTemplate"));
  _idfObservation = parser.getAttributeValue("", "idfObservation") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfObservation"));
  _idfObservationFarm = parser.getAttributeValue("", "idfObservationFarm") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfObservationFarm"));
  _datModificationDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datModificationDate"));
  _idfCaseType = parser.getAttributeValue("", "idfCaseType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfCaseType"));
  _strCaseID = parser.getAttributeValue("", "strCaseID");
  _strLocalIdentifier = parser.getAttributeValue("", "strLocalIdentifier");
  _idfsCaseReportType = parser.getAttributeValue("", "idfsCaseReportType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsCaseReportType"));
  _idfsTentativeDiagnosis = parser.getAttributeValue("", "idfsTentativeDiagnosis") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsTentativeDiagnosis"));
  _datTentativeDiagnosisDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datTentativeDiagnosisDate"));
  _datReportDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datReportDate"));
  _strSentByOffice = parser.getAttributeValue("", "strSentByOffice");
  _strSentByPerson = parser.getAttributeValue("", "strSentByPerson");
  _idfInvestigatedByPerson = parser.getAttributeValue("", "idfInvestigatedByPerson") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfInvestigatedByPerson"));
  _datAssignedDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datAssignedDate"));
  _datInvestigationDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datInvestigationDate"));
  _idfsFinalCaseStatus = parser.getAttributeValue("", "idfsFinalCaseStatus") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsFinalCaseStatus"));
  _strFinalDiagnosis = parser.getAttributeValue("", "strFinalDiagnosis");
  _datFinalDiagnosisDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datFinalDiagnosisDate"));
  _strComment = parser.getAttributeValue("", "strComment");
  _idfsYNTestsConducted = parser.getAttributeValue("", "idfsYNTestsConducted") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsYNTestsConducted"));
  _idfFarm = parser.getAttributeValue("", "idfFarm") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfFarm"));
  _strFarmName = parser.getAttributeValue("", "strFarmName");
  _strFarmCode = parser.getAttributeValue("", "strFarmCode");
  _idfRootFarm = parser.getAttributeValue("", "idfRootFarm") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfRootFarm"));
  _strOwnerLastName = parser.getAttributeValue("", "strOwnerLastName");
  _strOwnerFirstName = parser.getAttributeValue("", "strOwnerFirstName");
  _strOwnerMiddleName = parser.getAttributeValue("", "strOwnerMiddleName");
  _idfsRegion = parser.getAttributeValue("", "idfsRegion") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsRegion"));
  _idfsRayon = parser.getAttributeValue("", "idfsRayon") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsRayon"));
  _idfsSettlement = parser.getAttributeValue("", "idfsSettlement") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSettlement"));
  _strStreetName = parser.getAttributeValue("", "strStreetName");
  _strBuilding = parser.getAttributeValue("", "strBuilding");
  _strHouse = parser.getAttributeValue("", "strHouse");
  _strApartment = parser.getAttributeValue("", "strApartment");
  _strPostCode = parser.getAttributeValue("", "strPostCode");
  _strPhone = parser.getAttributeValue("", "strPhone");
}
}
