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

public class HumanCase_object {
    protected Boolean bChanged;
    public Boolean getChanged() { return bChanged; }

    protected IFieldChanged _fieldChangedHandler;
    public IFieldChanged getFieldChangedHandler() { return _fieldChangedHandler; }
    public void setFieldChangedHandler(IFieldChanged value) { _fieldChangedHandler = value; }

    public HumanCase_object()
    {
        bChanged = false;
        _datCreateDate = DateHelpers.Today();
        _dblLongitude = 0d;
        _dblLatitude = 0d;
    }
  public static String eidss_LocalIdentifier = "HumanCase.LocalIdentifier";
  public static String eidss_TentativeDiagnosis = "HumanCase.Diagnosis";
  public static String eidss_TentativeDiagnosisDate = "HumanCase.DiagnosisDate";
  public static String eidss_NotificationDate = "HumanCase.NotificationDate";
  public static String eidss_SentByOffice = "HumanCase.NotificationSentByFacility";
  public static String eidss_SentByPerson = "HumanCase.NotificationSentByName";
  public static String eidss_ReceivedByOffice = "HumanCase.NotificationReceivedByFacility";
  public static String eidss_ReceivedByPerson = "HumanCase.NotificationReceivedByName";
  public static String eidss_InvestigatedByOffice = "HumanCase.ConductingInvestigationFacility";
  public static String eidss_EpidemiologistsName = "HumanCase.EpidemiologistName";
  public static String eidss_InvestigationStartDate = "HumanCase.InvestigationStartDate";
  public static String eidss_FamilyName = "HumanCase.Patient.LastName";
  public static String eidss_FirstName = "HumanCase.Patient.FirstName";
  public static String eidss_SecondName = "HumanCase.Patient.MiddleName";
  public static String eidss_DateofBirth = "HumanCase.Patient.DateOfBirth";
  public static String eidss_PatientAge = "HumanCase.Patient.Age";
  public static String eidss_HumanAgeType = "HumanCase.Patient.AgeType";
  public static String eidss_HumanGender = "HumanCase.Patient.Gender";
  public static String eidss_PersonIDType = "HumanCase.Patient.PersonIDType";
  public static String eidss_PersonID = "HumanCase.Patient.PersonID";
  public static String eidss_Nationality = "HumanCase.Patient.Citizenship";
  public static String eidss_RegionCurrentResidence = "HumanCase.Patient.CurrentResidenceAddress.Region";
  public static String eidss_RayonCurrentResidence = "HumanCase.Patient.CurrentResidenceAddress.Rayon";
  public static String eidss_SettlementCurrentResidence = "HumanCase.Patient.CurrentResidence.Settlement";
  public static String eidss_StreetName = "HumanCase.Patient.CurrentResidence.Street";
  public static String eidss_Building = "HumanCase.Patient.CurrentResidence.Building";
  public static String eidss_House = "HumanCase.Patient.CurrentResidence.House";
  public static String eidss_Apartment = "HumanCase.Patient.CurrentResidence.Apt";
  public static String eidss_PostCode = "HumanCase.Patient.CurrentResidence.PostalCode";
  public static String eidss_Longitude = "HumanCase.PointGeoLocation.Longitude";
  public static String eidss_Latitude = "HumanCase.PointGeoLocation.Latitude";
  public static String eidss_HomePhone = "HumanCase.Patient.CurrentResidence.Phone";
  public static String eidss_PermanentResidencePhone = "HumanCase.Patient.PermanentResidence.Phone";
  public static String eidss_EmployerName = "HumanCase.Patient.EmployerName";
  public static String eidss_WorkPhone = "HumanCase.Patient.EmployerPhone";
  public static String eidss_FinalState = "HumanCase.PatientStatus";
  public static String eidss_HospitalizationStatus = "HumanCase.PatientLocation";
  public static String eidss_Hospital = "HumanCase.Hospital";
  public static String eidss_InitialCaseStatus = "HumanCase.InitialCaseStatus";
  public static String eidss_OnSetDate = "HumanCase.DateOfSymptomsOnSet";
  public static String eidss_ExposureDate = "HumanCase.ExposureDate";
  public static String eidss_SoughtCareFacility = "HumanCase.FirstSoughtCareFacility";
  public static String eidss_FirstSoughtCareDate = "HumanCase.FirstSoughtCareDate";
  public static String eidss_YNHospitalization = "HumanCase.Hospitalization";
  public static String eidss_HospitalizationPlace = "HumanCase.HospitalizationPlace";
  public static String eidss_HospitalizationDate = "HumanCase.HospitalizationDate";
  public static String eidss_Comment = "HumanCase.Comments";
  public static String eidss_YNSpecimenCollected = "HumanCase.SampleCollected";
  public static String eidss_NotCollectedReason = "HumanCase.NotSampleCollectedReason";
  public static String eidss_YNTestsConducted = "HumanCase.TestConducted";
  public static String eidss_FinalCaseStatus = "HumanCase.FinalCaseStatus";
  public static String eidss_FinalCaseClassificationDate = "HumanCase.FinalCaseStatusDate";
  public static String eidss_FinalDiagnosis = "HumanCase.FinalDiagnosis";
  public static String eidss_FinalDiagnosisDate = "HumanCase.FinalDiagnosisDate";
  public static String eidss_ClinicalDiagBasis = "HumanCase.BasisOfDiagnosisClinical";
  public static String eidss_EpiDiagBasis = "HumanCase.BasisOfDiagnosisEpiLinks";
  public static String eidss_LabDiagBasis = "HumanCase.BasisOfDiagnosisLabTest";
  public static String eidss_Outcome = "HumanCase.Outcome";
  public static String eidss_YNRelatedToOutbreak = "HumanCase.IsRelatedToOutbreak";

    public static List<FieldMetadata> fieldMetadata = new ArrayList<FieldMetadata>() {{{{
        add(new FieldMetadata(eidss_LocalIdentifier, R.string.HumanCase_strLocalIdentifier, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getLocalIdentifier(); }}));
        add(new FieldMetadata(eidss_TentativeDiagnosis, R.string.HumanCase_idfsTentativeDiagnosis, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getTentativeDiagnosis(); }}));
        add(new FieldMetadata(eidss_TentativeDiagnosisDate, R.string.HumanCase_datTentativeDiagnosisDate, new ICallable<Date, HumanCase_object>() { public Date call(HumanCase_object t) { return t.getTentativeDiagnosisDate(); }}));
        add(new FieldMetadata(eidss_FamilyName, R.string.HumanCase_strFamilyName, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getFamilyName(); }}));
        add(new FieldMetadata(eidss_FirstName, R.string.HumanCase_strFirstName, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getFirstName(); }}));
        add(new FieldMetadata(eidss_SecondName, R.string.HumanCase_strSecondName, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getSecondName(); }}));
        add(new FieldMetadata(eidss_DateofBirth, R.string.HumanCase_datDateofBirth, new ICallable<Date, HumanCase_object>() { public Date call(HumanCase_object t) { return t.getDateofBirth(); }}));
        add(new FieldMetadata(eidss_PatientAge, R.string.HumanCase_intPatientAge, new ICallable<Integer, HumanCase_object>() { public Integer call(HumanCase_object t) { return t.getPatientAge(); }}));
        add(new FieldMetadata(eidss_HumanAgeType, R.string.HumanCase_idfsHumanAgeType, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getHumanAgeType(); }}));
        add(new FieldMetadata(eidss_HumanGender, R.string.HumanCase_idfsHumanGender, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getHumanGender(); }}));
        add(new FieldMetadata(eidss_PersonIDType, R.string.HumanCase_idfsPersonIDType, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getPersonIDType(); }}));
        add(new FieldMetadata(eidss_PersonID, R.string.HumanCase_strPersonID, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getPersonID(); }}));
        add(new FieldMetadata(eidss_Nationality, R.string.HumanCase_idfsNationality, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getNationality(); }}));
        add(new FieldMetadata(eidss_RegionCurrentResidence, R.string.HumanCase_idfsRegionCurrentResidence, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getRegionCurrentResidence(); }}));
        add(new FieldMetadata(eidss_RayonCurrentResidence, R.string.HumanCase_idfsRayonCurrentResidence, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getRayonCurrentResidence(); }}));
        add(new FieldMetadata(eidss_SettlementCurrentResidence, R.string.HumanCase_idfsSettlementCurrentResidence, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getSettlementCurrentResidence(); }}));
        add(new FieldMetadata(eidss_StreetName, R.string.HumanCase_strStreetName, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getStreetName(); }}));
        add(new FieldMetadata(eidss_Building, R.string.HumanCase_strBuilding, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getBuilding(); }}));
        add(new FieldMetadata(eidss_House, R.string.HumanCase_strHouse, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getHouse(); }}));
        add(new FieldMetadata(eidss_Apartment, R.string.HumanCase_strApartment, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getApartment(); }}));
        add(new FieldMetadata(eidss_PostCode, R.string.HumanCase_strPostCode, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getPostCode(); }}));
        add(new FieldMetadata(eidss_Longitude, R.string.HumanCase_dblLongitude, new ICallable<Double, HumanCase_object>() { public Double call(HumanCase_object t) { return t.getLongitude(); }}));
        add(new FieldMetadata(eidss_Latitude, R.string.HumanCase_dblLatitude, new ICallable<Double, HumanCase_object>() { public Double call(HumanCase_object t) { return t.getLatitude(); }}));
        add(new FieldMetadata(eidss_HomePhone, R.string.HumanCase_strHomePhone, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getHomePhone(); }}));
        add(new FieldMetadata(eidss_PermanentResidencePhone, R.string.HumanCase_strPermanentResidencePhone, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getPermanentResidencePhone(); }}));
        add(new FieldMetadata(eidss_EmployerName, R.string.HumanCase_strEmployerName, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getEmployerName(); }}));
        add(new FieldMetadata(eidss_WorkPhone, R.string.HumanCase_strWorkPhone, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getWorkPhone(); }}));
        add(new FieldMetadata(eidss_FinalState, R.string.HumanCase_idfsFinalState, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getFinalState(); }}));
        add(new FieldMetadata(eidss_HospitalizationStatus, R.string.HumanCase_idfsHospitalizationStatus, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getHospitalizationStatus(); }}));
        add(new FieldMetadata(eidss_Hospital, R.string.HumanCase_idfHospital, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getHospital(); }}));
        add(new FieldMetadata(eidss_InitialCaseStatus, R.string.HumanCase_idfsInitialCaseStatus, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getInitialCaseStatus(); }}));
        add(new FieldMetadata(eidss_OnSetDate, R.string.HumanCase_datOnSetDate, new ICallable<Date, HumanCase_object>() { public Date call(HumanCase_object t) { return t.getOnSetDate(); }}));
        add(new FieldMetadata(eidss_ExposureDate, R.string.HumanCase_datExposureDate, new ICallable<Date, HumanCase_object>() { public Date call(HumanCase_object t) { return t.getExposureDate(); }}));
        add(new FieldMetadata(eidss_SoughtCareFacility, R.string.HumanCase_idfSoughtCareFacility, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getSoughtCareFacility(); }}));
        add(new FieldMetadata(eidss_FirstSoughtCareDate, R.string.HumanCase_datFirstSoughtCareDate, new ICallable<Date, HumanCase_object>() { public Date call(HumanCase_object t) { return t.getFirstSoughtCareDate(); }}));
        add(new FieldMetadata(eidss_YNHospitalization, R.string.HumanCase_idfsYNHospitalization, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getYNHospitalization(); }}));
        add(new FieldMetadata(eidss_HospitalizationPlace, R.string.HumanCase_strHospitalizationPlace, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getHospitalizationPlace(); }}));
        add(new FieldMetadata(eidss_HospitalizationDate, R.string.HumanCase_datHospitalizationDate, new ICallable<Date, HumanCase_object>() { public Date call(HumanCase_object t) { return t.getHospitalizationDate(); }}));
        add(new FieldMetadata(eidss_Comment, R.string.HumanCase_strComment, new ICallable<String, HumanCase_object>() { public String call(HumanCase_object t) { return t.getComment(); }}));
        add(new FieldMetadata(eidss_YNSpecimenCollected, R.string.HumanCase_idfsYNSpecimenCollected, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getYNSpecimenCollected(); }}));
        add(new FieldMetadata(eidss_NotCollectedReason, R.string.HumanCase_idfsNotCollectedReason, new ICallable<Long, HumanCase_object>() { public Long call(HumanCase_object t) { return t.getNotCollectedReason(); }}));
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
  protected long _idfEpiObservation;
  public long getEpiObservation(){return _idfEpiObservation;}
   public void setEpiObservation(long value) { bChanged = bChanged || _idfEpiObservation != value; _intChanged = ((_intChanged == 1) || _idfEpiObservation != value) ? 1 : 0; if (_idfEpiObservation != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfEpiObservation", _idfEpiObservation, value); } _idfEpiObservation = value; }}
  protected long _idfCSObservation;
  public long getCSObservation(){return _idfCSObservation;}
   public void setCSObservation(long value) { bChanged = bChanged || _idfCSObservation != value; _intChanged = ((_intChanged == 1) || _idfCSObservation != value) ? 1 : 0; if (_idfCSObservation != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfCSObservation", _idfCSObservation, value); } _idfCSObservation = value; }}
  protected Date _datModificationDate;
  public Date getModificationDate(){return _datModificationDate;}
   public void setModificationDate(Date value) { if(_datModificationDate == null && value == null) return; bChanged = bChanged || _datModificationDate == null || value == null || !_datModificationDate.equals(value); _intChanged = ((_intChanged == 1) || _datModificationDate == null || value == null || !_datModificationDate.equals(value)) ? 1 : 0; if (_datModificationDate == null || value == null || !_datModificationDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datModificationDate", _datModificationDate, value); } _datModificationDate = value; }}
  protected String _strCaseID;
  public String getCaseID(){return _strCaseID;}
  public void setCaseID(String value) { _strCaseID = value; }
  protected String _strLocalIdentifier;
  public String getLocalIdentifier(){return _strLocalIdentifier;}
   public void setLocalIdentifier(String value) { if(_strLocalIdentifier == null && value == null) return; bChanged = bChanged || _strLocalIdentifier == null || value == null || !_strLocalIdentifier.equals(value); _intChanged = ((_intChanged == 1) || _strLocalIdentifier == null || value == null || !_strLocalIdentifier.equals(value)) ? 1 : 0; if (_strLocalIdentifier == null || value == null || !_strLocalIdentifier.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strLocalIdentifier", _strLocalIdentifier, value); } _strLocalIdentifier = value; }}
  protected Date _datCompletionPaperFormDate;
  public Date getCompletionPaperFormDate(){return _datCompletionPaperFormDate;}
   public void setCompletionPaperFormDate(Date value) { if(_datCompletionPaperFormDate == null && value == null) return; bChanged = bChanged || _datCompletionPaperFormDate == null || value == null || !_datCompletionPaperFormDate.equals(value); _intChanged = ((_intChanged == 1) || _datCompletionPaperFormDate == null || value == null || !_datCompletionPaperFormDate.equals(value)) ? 1 : 0; if (_datCompletionPaperFormDate == null || value == null || !_datCompletionPaperFormDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datCompletionPaperFormDate", _datCompletionPaperFormDate, value); } _datCompletionPaperFormDate = value; }}
  protected long _idfsTentativeDiagnosis;
  public long getTentativeDiagnosis(){return _idfsTentativeDiagnosis;}
   public void setTentativeDiagnosis(long value) { bChanged = bChanged || _idfsTentativeDiagnosis != value; _intChanged = ((_intChanged == 1) || _idfsTentativeDiagnosis != value) ? 1 : 0; if (_idfsTentativeDiagnosis != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsTentativeDiagnosis", _idfsTentativeDiagnosis, value); } _idfsTentativeDiagnosis = value; }}
  protected Date _datTentativeDiagnosisDate;
  public Date getTentativeDiagnosisDate(){return _datTentativeDiagnosisDate;}
   public void setTentativeDiagnosisDate(Date value) { if(_datTentativeDiagnosisDate == null && value == null) return; bChanged = bChanged || _datTentativeDiagnosisDate == null || value == null || !_datTentativeDiagnosisDate.equals(value); _intChanged = ((_intChanged == 1) || _datTentativeDiagnosisDate == null || value == null || !_datTentativeDiagnosisDate.equals(value)) ? 1 : 0; if (_datTentativeDiagnosisDate == null || value == null || !_datTentativeDiagnosisDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datTentativeDiagnosisDate", _datTentativeDiagnosisDate, value); } _datTentativeDiagnosisDate = value; }}
  protected Date _datNotificationDate;
  public Date getNotificationDate(){return _datNotificationDate;}
  public void setNotificationDate(Date value) { _datNotificationDate = value; }
  protected long _idfSentByOffice;
  public long getSentByOffice(){return _idfSentByOffice;}
  public void setSentByOffice(long value) { _idfSentByOffice = value; }
  protected String _strSentByPerson;
  public String getSentByPerson(){return _strSentByPerson;}
  public void setSentByPerson(String value) { _strSentByPerson = value; }
  protected long _idfReceivedByOffice;
  public long getReceivedByOffice(){return _idfReceivedByOffice;}
  public void setReceivedByOffice(long value) { _idfReceivedByOffice = value; }
  protected String _strReceivedByPerson;
  public String getReceivedByPerson(){return _strReceivedByPerson;}
  public void setReceivedByPerson(String value) { _strReceivedByPerson = value; }
  protected long _idfInvestigatedByOffice;
  public long getInvestigatedByOffice(){return _idfInvestigatedByOffice;}
  public void setInvestigatedByOffice(long value) { _idfInvestigatedByOffice = value; }
  protected String _strEpidemiologistsName;
  public String getEpidemiologistsName(){return _strEpidemiologistsName;}
  public void setEpidemiologistsName(String value) { _strEpidemiologistsName = value; }
  protected Date _datInvestigationStartDate;
  public Date getInvestigationStartDate(){return _datInvestigationStartDate;}
  public void setInvestigationStartDate(Date value) { _datInvestigationStartDate = value; }
  protected String _strFamilyName;
  public String getFamilyName(){return _strFamilyName;}
   public void setFamilyName(String value) { if(_strFamilyName == null && value == null) return; bChanged = bChanged || _strFamilyName == null || value == null || !_strFamilyName.equals(value); _intChanged = ((_intChanged == 1) || _strFamilyName == null || value == null || !_strFamilyName.equals(value)) ? 1 : 0; if (_strFamilyName == null || value == null || !_strFamilyName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strFamilyName", _strFamilyName, value); } _strFamilyName = value; }}
  protected String _strFirstName;
  public String getFirstName(){return _strFirstName;}
   public void setFirstName(String value) { if(_strFirstName == null && value == null) return; bChanged = bChanged || _strFirstName == null || value == null || !_strFirstName.equals(value); _intChanged = ((_intChanged == 1) || _strFirstName == null || value == null || !_strFirstName.equals(value)) ? 1 : 0; if (_strFirstName == null || value == null || !_strFirstName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strFirstName", _strFirstName, value); } _strFirstName = value; }}
  protected String _strSecondName;
  public String getSecondName(){return _strSecondName;}
   public void setSecondName(String value) { if(_strSecondName == null && value == null) return; bChanged = bChanged || _strSecondName == null || value == null || !_strSecondName.equals(value); _intChanged = ((_intChanged == 1) || _strSecondName == null || value == null || !_strSecondName.equals(value)) ? 1 : 0; if (_strSecondName == null || value == null || !_strSecondName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strSecondName", _strSecondName, value); } _strSecondName = value; }}
  protected Date _datDateofBirth;
  public Date getDateofBirth(){return _datDateofBirth;}
   public void setDateofBirth(Date value) { if(_datDateofBirth == null && value == null) return; bChanged = bChanged || _datDateofBirth == null || value == null || !_datDateofBirth.equals(value); _intChanged = ((_intChanged == 1) || _datDateofBirth == null || value == null || !_datDateofBirth.equals(value)) ? 1 : 0; if (_datDateofBirth == null || value == null || !_datDateofBirth.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datDateofBirth", _datDateofBirth, value); } _datDateofBirth = value; }}
  protected int _intPatientAge;
  public int getPatientAge(){return _intPatientAge;}
   public void setPatientAge(int value) { bChanged = bChanged || _intPatientAge != value; _intChanged = ((_intChanged == 1) || _intPatientAge != value) ? 1 : 0; if (_intPatientAge != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("intPatientAge", _intPatientAge, value); } _intPatientAge = value; }}
  protected long _idfsHumanAgeType;
  public long getHumanAgeType(){return _idfsHumanAgeType;}
   public void setHumanAgeType(long value) { bChanged = bChanged || _idfsHumanAgeType != value; _intChanged = ((_intChanged == 1) || _idfsHumanAgeType != value) ? 1 : 0; if (_idfsHumanAgeType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsHumanAgeType", _idfsHumanAgeType, value); } _idfsHumanAgeType = value; }}
  protected long _idfsHumanGender;
  public long getHumanGender(){return _idfsHumanGender;}
   public void setHumanGender(long value) { bChanged = bChanged || _idfsHumanGender != value; _intChanged = ((_intChanged == 1) || _idfsHumanGender != value) ? 1 : 0; if (_idfsHumanGender != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsHumanGender", _idfsHumanGender, value); } _idfsHumanGender = value; }}
  protected long _idfsPersonIDType;
  public long getPersonIDType(){return _idfsPersonIDType;}
   public void setPersonIDType(long value) { bChanged = bChanged || _idfsPersonIDType != value; _intChanged = ((_intChanged == 1) || _idfsPersonIDType != value) ? 1 : 0; if (_idfsPersonIDType != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsPersonIDType", _idfsPersonIDType, value); } _idfsPersonIDType = value; }}
  protected String _strPersonID;
  public String getPersonID(){return _strPersonID;}
   public void setPersonID(String value) { if(_strPersonID == null && value == null) return; bChanged = bChanged || _strPersonID == null || value == null || !_strPersonID.equals(value); _intChanged = ((_intChanged == 1) || _strPersonID == null || value == null || !_strPersonID.equals(value)) ? 1 : 0; if (_strPersonID == null || value == null || !_strPersonID.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strPersonID", _strPersonID, value); } _strPersonID = value; }}
  protected long _idfsNationality;
  public long getNationality(){return _idfsNationality;}
   public void setNationality(long value) { bChanged = bChanged || _idfsNationality != value; _intChanged = ((_intChanged == 1) || _idfsNationality != value) ? 1 : 0; if (_idfsNationality != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsNationality", _idfsNationality, value); } _idfsNationality = value; }}
  protected long _idfsRegionCurrentResidence;
  public long getRegionCurrentResidence(){return _idfsRegionCurrentResidence;}
   public void setRegionCurrentResidence(long value) { bChanged = bChanged || _idfsRegionCurrentResidence != value; _intChanged = ((_intChanged == 1) || _idfsRegionCurrentResidence != value) ? 1 : 0; if (_idfsRegionCurrentResidence != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsRegionCurrentResidence", _idfsRegionCurrentResidence, value); } _idfsRegionCurrentResidence = value; }}
  protected long _idfsRayonCurrentResidence;
  public long getRayonCurrentResidence(){return _idfsRayonCurrentResidence;}
   public void setRayonCurrentResidence(long value) { bChanged = bChanged || _idfsRayonCurrentResidence != value; _intChanged = ((_intChanged == 1) || _idfsRayonCurrentResidence != value) ? 1 : 0; if (_idfsRayonCurrentResidence != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsRayonCurrentResidence", _idfsRayonCurrentResidence, value); } _idfsRayonCurrentResidence = value; }}
  protected long _idfsSettlementCurrentResidence;
  public long getSettlementCurrentResidence(){return _idfsSettlementCurrentResidence;}
   public void setSettlementCurrentResidence(long value) { bChanged = bChanged || _idfsSettlementCurrentResidence != value; _intChanged = ((_intChanged == 1) || _idfsSettlementCurrentResidence != value) ? 1 : 0; if (_idfsSettlementCurrentResidence != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsSettlementCurrentResidence", _idfsSettlementCurrentResidence, value); } _idfsSettlementCurrentResidence = value; }}
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
  protected String _strHomePhone;
  public String getHomePhone(){return _strHomePhone;}
   public void setHomePhone(String value) { if(_strHomePhone == null && value == null) return; bChanged = bChanged || _strHomePhone == null || value == null || !_strHomePhone.equals(value); _intChanged = ((_intChanged == 1) || _strHomePhone == null || value == null || !_strHomePhone.equals(value)) ? 1 : 0; if (_strHomePhone == null || value == null || !_strHomePhone.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strHomePhone", _strHomePhone, value); } _strHomePhone = value; }}
  protected String _strPermanentResidencePhone;
  public String getPermanentResidencePhone(){return _strPermanentResidencePhone;}
   public void setPermanentResidencePhone(String value) { if(_strPermanentResidencePhone == null && value == null) return; bChanged = bChanged || _strPermanentResidencePhone == null || value == null || !_strPermanentResidencePhone.equals(value); _intChanged = ((_intChanged == 1) || _strPermanentResidencePhone == null || value == null || !_strPermanentResidencePhone.equals(value)) ? 1 : 0; if (_strPermanentResidencePhone == null || value == null || !_strPermanentResidencePhone.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strPermanentResidencePhone", _strPermanentResidencePhone, value); } _strPermanentResidencePhone = value; }}
  protected String _strEmployerName;
  public String getEmployerName(){return _strEmployerName;}
   public void setEmployerName(String value) { if(_strEmployerName == null && value == null) return; bChanged = bChanged || _strEmployerName == null || value == null || !_strEmployerName.equals(value); _intChanged = ((_intChanged == 1) || _strEmployerName == null || value == null || !_strEmployerName.equals(value)) ? 1 : 0; if (_strEmployerName == null || value == null || !_strEmployerName.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strEmployerName", _strEmployerName, value); } _strEmployerName = value; }}
  protected String _strWorkPhone;
  public String getWorkPhone(){return _strWorkPhone;}
   public void setWorkPhone(String value) { if(_strWorkPhone == null && value == null) return; bChanged = bChanged || _strWorkPhone == null || value == null || !_strWorkPhone.equals(value); _intChanged = ((_intChanged == 1) || _strWorkPhone == null || value == null || !_strWorkPhone.equals(value)) ? 1 : 0; if (_strWorkPhone == null || value == null || !_strWorkPhone.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strWorkPhone", _strWorkPhone, value); } _strWorkPhone = value; }}
  protected long _idfsFinalState;
  public long getFinalState(){return _idfsFinalState;}
   public void setFinalState(long value) { bChanged = bChanged || _idfsFinalState != value; _intChanged = ((_intChanged == 1) || _idfsFinalState != value) ? 1 : 0; if (_idfsFinalState != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsFinalState", _idfsFinalState, value); } _idfsFinalState = value; }}
  protected long _idfsHospitalizationStatus;
  public long getHospitalizationStatus(){return _idfsHospitalizationStatus;}
   public void setHospitalizationStatus(long value) { bChanged = bChanged || _idfsHospitalizationStatus != value; _intChanged = ((_intChanged == 1) || _idfsHospitalizationStatus != value) ? 1 : 0; if (_idfsHospitalizationStatus != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsHospitalizationStatus", _idfsHospitalizationStatus, value); } _idfsHospitalizationStatus = value; }}
  protected long _idfHospital;
  public long getHospital(){return _idfHospital;}
   public void setHospital(long value) { bChanged = bChanged || _idfHospital != value; _intChanged = ((_intChanged == 1) || _idfHospital != value) ? 1 : 0; if (_idfHospital != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfHospital", _idfHospital, value); } _idfHospital = value; }}
  protected long _idfsInitialCaseStatus;
  public long getInitialCaseStatus(){return _idfsInitialCaseStatus;}
   public void setInitialCaseStatus(long value) { bChanged = bChanged || _idfsInitialCaseStatus != value; _intChanged = ((_intChanged == 1) || _idfsInitialCaseStatus != value) ? 1 : 0; if (_idfsInitialCaseStatus != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsInitialCaseStatus", _idfsInitialCaseStatus, value); } _idfsInitialCaseStatus = value; }}
  protected Date _datOnSetDate;
  public Date getOnSetDate(){return _datOnSetDate;}
   public void setOnSetDate(Date value) { if(_datOnSetDate == null && value == null) return; bChanged = bChanged || _datOnSetDate == null || value == null || !_datOnSetDate.equals(value); _intChanged = ((_intChanged == 1) || _datOnSetDate == null || value == null || !_datOnSetDate.equals(value)) ? 1 : 0; if (_datOnSetDate == null || value == null || !_datOnSetDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datOnSetDate", _datOnSetDate, value); } _datOnSetDate = value; }}
  protected Date _datExposureDate;
  public Date getExposureDate(){return _datExposureDate;}
   public void setExposureDate(Date value) { if(_datExposureDate == null && value == null) return; bChanged = bChanged || _datExposureDate == null || value == null || !_datExposureDate.equals(value); _intChanged = ((_intChanged == 1) || _datExposureDate == null || value == null || !_datExposureDate.equals(value)) ? 1 : 0; if (_datExposureDate == null || value == null || !_datExposureDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datExposureDate", _datExposureDate, value); } _datExposureDate = value; }}
  protected long _idfSoughtCareFacility;
  public long getSoughtCareFacility(){return _idfSoughtCareFacility;}
   public void setSoughtCareFacility(long value) { bChanged = bChanged || _idfSoughtCareFacility != value; _intChanged = ((_intChanged == 1) || _idfSoughtCareFacility != value) ? 1 : 0; if (_idfSoughtCareFacility != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfSoughtCareFacility", _idfSoughtCareFacility, value); } _idfSoughtCareFacility = value; }}
  protected Date _datFirstSoughtCareDate;
  public Date getFirstSoughtCareDate(){return _datFirstSoughtCareDate;}
   public void setFirstSoughtCareDate(Date value) { if(_datFirstSoughtCareDate == null && value == null) return; bChanged = bChanged || _datFirstSoughtCareDate == null || value == null || !_datFirstSoughtCareDate.equals(value); _intChanged = ((_intChanged == 1) || _datFirstSoughtCareDate == null || value == null || !_datFirstSoughtCareDate.equals(value)) ? 1 : 0; if (_datFirstSoughtCareDate == null || value == null || !_datFirstSoughtCareDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datFirstSoughtCareDate", _datFirstSoughtCareDate, value); } _datFirstSoughtCareDate = value; }}
  protected long _idfsYNHospitalization;
  public long getYNHospitalization(){return _idfsYNHospitalization;}
   public void setYNHospitalization(long value) { bChanged = bChanged || _idfsYNHospitalization != value; _intChanged = ((_intChanged == 1) || _idfsYNHospitalization != value) ? 1 : 0; if (_idfsYNHospitalization != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsYNHospitalization", _idfsYNHospitalization, value); } _idfsYNHospitalization = value; }}
  protected String _strHospitalizationPlace;
  public String getHospitalizationPlace(){return _strHospitalizationPlace;}
   public void setHospitalizationPlace(String value) { if(_strHospitalizationPlace == null && value == null) return; bChanged = bChanged || _strHospitalizationPlace == null || value == null || !_strHospitalizationPlace.equals(value); _intChanged = ((_intChanged == 1) || _strHospitalizationPlace == null || value == null || !_strHospitalizationPlace.equals(value)) ? 1 : 0; if (_strHospitalizationPlace == null || value == null || !_strHospitalizationPlace.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strHospitalizationPlace", _strHospitalizationPlace, value); } _strHospitalizationPlace = value; }}
  protected Date _datHospitalizationDate;
  public Date getHospitalizationDate(){return _datHospitalizationDate;}
   public void setHospitalizationDate(Date value) { if(_datHospitalizationDate == null && value == null) return; bChanged = bChanged || _datHospitalizationDate == null || value == null || !_datHospitalizationDate.equals(value); _intChanged = ((_intChanged == 1) || _datHospitalizationDate == null || value == null || !_datHospitalizationDate.equals(value)) ? 1 : 0; if (_datHospitalizationDate == null || value == null || !_datHospitalizationDate.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("datHospitalizationDate", _datHospitalizationDate, value); } _datHospitalizationDate = value; }}
  protected String _strComment;
  public String getComment(){return _strComment;}
   public void setComment(String value) { if(_strComment == null && value == null) return; bChanged = bChanged || _strComment == null || value == null || !_strComment.equals(value); _intChanged = ((_intChanged == 1) || _strComment == null || value == null || !_strComment.equals(value)) ? 1 : 0; if (_strComment == null || value == null || !_strComment.equals(value)) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("strComment", _strComment, value); } _strComment = value; }}
  protected long _idfsYNSpecimenCollected;
  public long getYNSpecimenCollected(){return _idfsYNSpecimenCollected;}
   public void setYNSpecimenCollected(long value) { bChanged = bChanged || _idfsYNSpecimenCollected != value; _intChanged = ((_intChanged == 1) || _idfsYNSpecimenCollected != value) ? 1 : 0; if (_idfsYNSpecimenCollected != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsYNSpecimenCollected", _idfsYNSpecimenCollected, value); } _idfsYNSpecimenCollected = value; }}
  protected long _idfsNotCollectedReason;
  public long getNotCollectedReason(){return _idfsNotCollectedReason;}
   public void setNotCollectedReason(long value) { bChanged = bChanged || _idfsNotCollectedReason != value; _intChanged = ((_intChanged == 1) || _idfsNotCollectedReason != value) ? 1 : 0; if (_idfsNotCollectedReason != value) { if (_fieldChangedHandler != null) { _fieldChangedHandler.FieldChanged("idfsNotCollectedReason", _idfsNotCollectedReason, value); } _idfsNotCollectedReason = value; }}
  protected long _idfsYNTestsConducted;
  public long getYNTestsConducted(){return _idfsYNTestsConducted;}
  public void setYNTestsConducted(long value) { _idfsYNTestsConducted = value; }
  protected long _idfsFinalCaseStatus;
  public long getFinalCaseStatus(){return _idfsFinalCaseStatus;}
  public void setFinalCaseStatus(long value) { _idfsFinalCaseStatus = value; }
  protected Date _datFinalCaseClassificationDate;
  public Date getFinalCaseClassificationDate(){return _datFinalCaseClassificationDate;}
  public void setFinalCaseClassificationDate(Date value) { _datFinalCaseClassificationDate = value; }
  protected long _idfsFinalDiagnosis;
  public long getFinalDiagnosis(){return _idfsFinalDiagnosis;}
  public void setFinalDiagnosis(long value) { _idfsFinalDiagnosis = value; }
  protected Date _datFinalDiagnosisDate;
  public Date getFinalDiagnosisDate(){return _datFinalDiagnosisDate;}
  public void setFinalDiagnosisDate(Date value) { _datFinalDiagnosisDate = value; }
  protected Boolean _blnClinicalDiagBasis;
  public Boolean getClinicalDiagBasis(){return _blnClinicalDiagBasis;}
  public void setClinicalDiagBasis(Boolean value) { _blnClinicalDiagBasis = value; }
  protected Boolean _blnEpiDiagBasis;
  public Boolean getEpiDiagBasis(){return _blnEpiDiagBasis;}
  public void setEpiDiagBasis(Boolean value) { _blnEpiDiagBasis = value; }
  protected Boolean _blnLabDiagBasis;
  public Boolean getLabDiagBasis(){return _blnLabDiagBasis;}
  public void setLabDiagBasis(Boolean value) { _blnLabDiagBasis = value; }
  protected long _idfsOutcome;
  public long getOutcome(){return _idfsOutcome;}
  public void setOutcome(long value) { _idfsOutcome = value; }
  protected long _idfsYNRelatedToOutbreak;
  public long getYNRelatedToOutbreak(){return _idfsYNRelatedToOutbreak;}
  public void setYNRelatedToOutbreak(long value) { _idfsYNRelatedToOutbreak = value; }

protected static HumanCase_object FromCursor(Cursor cursor, HumanCase_object ret)
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
  ret._idfEpiObservation = cursor.getLong(cursor.getColumnIndex("idfEpiObservation"));
  ret._idfCSObservation = cursor.getLong(cursor.getColumnIndex("idfCSObservation"));
  ret._datModificationDate = EidssUtils.ParseDate(cursor, formatterDateTime, "datModificationDate");
  ret._strCaseID = cursor.getString(cursor.getColumnIndex("strCaseID"));
  ret._strLocalIdentifier = cursor.getString(cursor.getColumnIndex("strLocalIdentifier"));
  ret._datCompletionPaperFormDate = EidssUtils.ParseDate(cursor, formatterDate, "datCompletionPaperFormDate");
  ret._idfsTentativeDiagnosis = cursor.getLong(cursor.getColumnIndex("idfsTentativeDiagnosis"));
  ret._datTentativeDiagnosisDate = EidssUtils.ParseDate(cursor, formatterDate, "datTentativeDiagnosisDate");
  ret._datNotificationDate = EidssUtils.ParseDate(cursor, formatterDate, "datNotificationDate");
  ret._idfSentByOffice = cursor.getLong(cursor.getColumnIndex("idfSentByOffice"));
  ret._strSentByPerson = cursor.getString(cursor.getColumnIndex("strSentByPerson"));
  ret._idfReceivedByOffice = cursor.getLong(cursor.getColumnIndex("idfReceivedByOffice"));
  ret._strReceivedByPerson = cursor.getString(cursor.getColumnIndex("strReceivedByPerson"));
  ret._idfInvestigatedByOffice = cursor.getLong(cursor.getColumnIndex("idfInvestigatedByOffice"));
  ret._strEpidemiologistsName = cursor.getString(cursor.getColumnIndex("strEpidemiologistsName"));
  ret._datInvestigationStartDate = EidssUtils.ParseDate(cursor, formatterDate, "datInvestigationStartDate");
  ret._strFamilyName = cursor.getString(cursor.getColumnIndex("strFamilyName"));
  ret._strFirstName = cursor.getString(cursor.getColumnIndex("strFirstName"));
  ret._strSecondName = cursor.getString(cursor.getColumnIndex("strSecondName"));
  ret._datDateofBirth = EidssUtils.ParseDate(cursor, formatterDate, "datDateofBirth");
  ret._intPatientAge = cursor.getInt(cursor.getColumnIndex("intPatientAge"));
  ret._idfsHumanAgeType = cursor.getLong(cursor.getColumnIndex("idfsHumanAgeType"));
  ret._idfsHumanGender = cursor.getLong(cursor.getColumnIndex("idfsHumanGender"));
  ret._idfsPersonIDType = cursor.getLong(cursor.getColumnIndex("idfsPersonIDType"));
  ret._strPersonID = cursor.getString(cursor.getColumnIndex("strPersonID"));
  ret._idfsNationality = cursor.getLong(cursor.getColumnIndex("idfsNationality"));
  ret._idfsRegionCurrentResidence = cursor.getLong(cursor.getColumnIndex("idfsRegionCurrentResidence"));
  ret._idfsRayonCurrentResidence = cursor.getLong(cursor.getColumnIndex("idfsRayonCurrentResidence"));
  ret._idfsSettlementCurrentResidence = cursor.getLong(cursor.getColumnIndex("idfsSettlementCurrentResidence"));
  ret._strStreetName = cursor.getString(cursor.getColumnIndex("strStreetName"));
  ret._strBuilding = cursor.getString(cursor.getColumnIndex("strBuilding"));
  ret._strHouse = cursor.getString(cursor.getColumnIndex("strHouse"));
  ret._strApartment = cursor.getString(cursor.getColumnIndex("strApartment"));
  ret._strPostCode = cursor.getString(cursor.getColumnIndex("strPostCode"));
  ret._dblLongitude = cursor.getDouble(cursor.getColumnIndex("dblLongitude"));
  ret._dblLatitude = cursor.getDouble(cursor.getColumnIndex("dblLatitude"));
  ret._strHomePhone = cursor.getString(cursor.getColumnIndex("strHomePhone"));
  ret._strPermanentResidencePhone = cursor.getString(cursor.getColumnIndex("strPermanentResidencePhone"));
  ret._strEmployerName = cursor.getString(cursor.getColumnIndex("strEmployerName"));
  ret._strWorkPhone = cursor.getString(cursor.getColumnIndex("strWorkPhone"));
  ret._idfsFinalState = cursor.getLong(cursor.getColumnIndex("idfsFinalState"));
  ret._idfsHospitalizationStatus = cursor.getLong(cursor.getColumnIndex("idfsHospitalizationStatus"));
  ret._idfHospital = cursor.getLong(cursor.getColumnIndex("idfHospital"));
  ret._idfsInitialCaseStatus = cursor.getLong(cursor.getColumnIndex("idfsInitialCaseStatus"));
  ret._datOnSetDate = EidssUtils.ParseDate(cursor, formatterDate, "datOnSetDate");
  ret._datExposureDate = EidssUtils.ParseDate(cursor, formatterDate, "datExposureDate");
  ret._idfSoughtCareFacility = cursor.getLong(cursor.getColumnIndex("idfSoughtCareFacility"));
  ret._datFirstSoughtCareDate = EidssUtils.ParseDate(cursor, formatterDate, "datFirstSoughtCareDate");
  ret._idfsYNHospitalization = cursor.getLong(cursor.getColumnIndex("idfsYNHospitalization"));
  ret._strHospitalizationPlace = cursor.getString(cursor.getColumnIndex("strHospitalizationPlace"));
  ret._datHospitalizationDate = EidssUtils.ParseDate(cursor, formatterDate, "datHospitalizationDate");
  ret._strComment = cursor.getString(cursor.getColumnIndex("strComment"));
  ret._idfsYNSpecimenCollected = cursor.getLong(cursor.getColumnIndex("idfsYNSpecimenCollected"));
  ret._idfsNotCollectedReason = cursor.getLong(cursor.getColumnIndex("idfsNotCollectedReason"));
  ret._idfsYNTestsConducted = cursor.getLong(cursor.getColumnIndex("idfsYNTestsConducted"));
  ret._idfsFinalCaseStatus = cursor.getLong(cursor.getColumnIndex("idfsFinalCaseStatus"));
  ret._datFinalCaseClassificationDate = EidssUtils.ParseDate(cursor, formatterDate, "datFinalCaseClassificationDate");
  ret._idfsFinalDiagnosis = cursor.getLong(cursor.getColumnIndex("idfsFinalDiagnosis"));
  ret._datFinalDiagnosisDate = EidssUtils.ParseDate(cursor, formatterDate, "datFinalDiagnosisDate");
  ret._blnClinicalDiagBasis = cursor.getInt(cursor.getColumnIndex("blnClinicalDiagBasis")) > 0;
  ret._blnEpiDiagBasis = cursor.getInt(cursor.getColumnIndex("blnEpiDiagBasis")) > 0;
  ret._blnLabDiagBasis = cursor.getInt(cursor.getColumnIndex("blnLabDiagBasis")) > 0;
  ret._idfsOutcome = cursor.getLong(cursor.getColumnIndex("idfsOutcome"));
  ret._idfsYNRelatedToOutbreak = cursor.getLong(cursor.getColumnIndex("idfsYNRelatedToOutbreak"));
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
  ret.put("idfEpiObservation", _idfEpiObservation);
  ret.put("idfCSObservation", _idfCSObservation);
    strDate = null;
  if (_datModificationDate != null)
      strDate = formatterDateTime.format(_datModificationDate);
  ret.put("datModificationDate", strDate);
  ret.put("strCaseID", _strCaseID);
  ret.put("strLocalIdentifier", _strLocalIdentifier);
    strDate = null;
  if (_datCompletionPaperFormDate != null)
      strDate = formatterDate.format(_datCompletionPaperFormDate);
  ret.put("datCompletionPaperFormDate", strDate);
  ret.put("idfsTentativeDiagnosis", _idfsTentativeDiagnosis);
    strDate = null;
  if (_datTentativeDiagnosisDate != null)
      strDate = formatterDate.format(_datTentativeDiagnosisDate);
  ret.put("datTentativeDiagnosisDate", strDate);
    strDate = null;
  if (_datNotificationDate != null)
      strDate = formatterDate.format(_datNotificationDate);
  ret.put("datNotificationDate", strDate);
  ret.put("idfSentByOffice", _idfSentByOffice);
  ret.put("strSentByPerson", _strSentByPerson);
  ret.put("idfReceivedByOffice", _idfReceivedByOffice);
  ret.put("strReceivedByPerson", _strReceivedByPerson);
  ret.put("idfInvestigatedByOffice", _idfInvestigatedByOffice);
  ret.put("strEpidemiologistsName", _strEpidemiologistsName);
    strDate = null;
  if (_datInvestigationStartDate != null)
      strDate = formatterDate.format(_datInvestigationStartDate);
  ret.put("datInvestigationStartDate", strDate);
  ret.put("strFamilyName", _strFamilyName);
  ret.put("strFirstName", _strFirstName);
  ret.put("strSecondName", _strSecondName);
    strDate = null;
  if (_datDateofBirth != null)
      strDate = formatterDate.format(_datDateofBirth);
  ret.put("datDateofBirth", strDate);
  ret.put("intPatientAge", _intPatientAge);
  ret.put("idfsHumanAgeType", _idfsHumanAgeType);
  ret.put("idfsHumanGender", _idfsHumanGender);
  ret.put("idfsPersonIDType", _idfsPersonIDType);
  ret.put("strPersonID", _strPersonID);
  ret.put("idfsNationality", _idfsNationality);
  ret.put("idfsRegionCurrentResidence", _idfsRegionCurrentResidence);
  ret.put("idfsRayonCurrentResidence", _idfsRayonCurrentResidence);
  ret.put("idfsSettlementCurrentResidence", _idfsSettlementCurrentResidence);
  ret.put("strStreetName", _strStreetName);
  ret.put("strBuilding", _strBuilding);
  ret.put("strHouse", _strHouse);
  ret.put("strApartment", _strApartment);
  ret.put("strPostCode", _strPostCode);
  ret.put("dblLongitude", _dblLongitude);
  ret.put("dblLatitude", _dblLatitude);
  ret.put("strHomePhone", _strHomePhone);
  ret.put("strPermanentResidencePhone", _strPermanentResidencePhone);
  ret.put("strEmployerName", _strEmployerName);
  ret.put("strWorkPhone", _strWorkPhone);
  ret.put("idfsFinalState", _idfsFinalState);
  ret.put("idfsHospitalizationStatus", _idfsHospitalizationStatus);
  ret.put("idfHospital", _idfHospital);
  ret.put("idfsInitialCaseStatus", _idfsInitialCaseStatus);
    strDate = null;
  if (_datOnSetDate != null)
      strDate = formatterDate.format(_datOnSetDate);
  ret.put("datOnSetDate", strDate);
    strDate = null;
  if (_datExposureDate != null)
      strDate = formatterDate.format(_datExposureDate);
  ret.put("datExposureDate", strDate);
  ret.put("idfSoughtCareFacility", _idfSoughtCareFacility);
    strDate = null;
  if (_datFirstSoughtCareDate != null)
      strDate = formatterDate.format(_datFirstSoughtCareDate);
  ret.put("datFirstSoughtCareDate", strDate);
  ret.put("idfsYNHospitalization", _idfsYNHospitalization);
  ret.put("strHospitalizationPlace", _strHospitalizationPlace);
    strDate = null;
  if (_datHospitalizationDate != null)
      strDate = formatterDate.format(_datHospitalizationDate);
  ret.put("datHospitalizationDate", strDate);
  ret.put("strComment", _strComment);
  ret.put("idfsYNSpecimenCollected", _idfsYNSpecimenCollected);
  ret.put("idfsNotCollectedReason", _idfsNotCollectedReason);
  ret.put("idfsYNTestsConducted", _idfsYNTestsConducted);
  ret.put("idfsFinalCaseStatus", _idfsFinalCaseStatus);
    strDate = null;
  if (_datFinalCaseClassificationDate != null)
      strDate = formatterDate.format(_datFinalCaseClassificationDate);
  ret.put("datFinalCaseClassificationDate", strDate);
  ret.put("idfsFinalDiagnosis", _idfsFinalDiagnosis);
    strDate = null;
  if (_datFinalDiagnosisDate != null)
      strDate = formatterDate.format(_datFinalDiagnosisDate);
  ret.put("datFinalDiagnosisDate", strDate);
  ret.put("blnClinicalDiagBasis", _blnClinicalDiagBasis);
  ret.put("blnEpiDiagBasis", _blnEpiDiagBasis);
  ret.put("blnLabDiagBasis", _blnLabDiagBasis);
  ret.put("idfsOutcome", _idfsOutcome);
  ret.put("idfsYNRelatedToOutbreak", _idfsYNRelatedToOutbreak);

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
  _idfEpiObservation = source.readLong();
  _idfCSObservation = source.readLong();
  _datModificationDate = (Date)source.readSerializable();
  _strCaseID = source.readString();
  _strLocalIdentifier = source.readString();
  _datCompletionPaperFormDate = (Date)source.readSerializable();
  _idfsTentativeDiagnosis = source.readLong();
  _datTentativeDiagnosisDate = (Date)source.readSerializable();
  _datNotificationDate = (Date)source.readSerializable();
  _idfSentByOffice = source.readLong();
  _strSentByPerson = source.readString();
  _idfReceivedByOffice = source.readLong();
  _strReceivedByPerson = source.readString();
  _idfInvestigatedByOffice = source.readLong();
  _strEpidemiologistsName = source.readString();
  _datInvestigationStartDate = (Date)source.readSerializable();
  _strFamilyName = source.readString();
  _strFirstName = source.readString();
  _strSecondName = source.readString();
  _datDateofBirth = (Date)source.readSerializable();
  _intPatientAge = source.readInt();
  _idfsHumanAgeType = source.readLong();
  _idfsHumanGender = source.readLong();
  _idfsPersonIDType = source.readLong();
  _strPersonID = source.readString();
  _idfsNationality = source.readLong();
  _idfsRegionCurrentResidence = source.readLong();
  _idfsRayonCurrentResidence = source.readLong();
  _idfsSettlementCurrentResidence = source.readLong();
  _strStreetName = source.readString();
  _strBuilding = source.readString();
  _strHouse = source.readString();
  _strApartment = source.readString();
  _strPostCode = source.readString();
  _dblLongitude = source.readDouble();
  _dblLatitude = source.readDouble();
  _strHomePhone = source.readString();
  _strPermanentResidencePhone = source.readString();
  _strEmployerName = source.readString();
  _strWorkPhone = source.readString();
  _idfsFinalState = source.readLong();
  _idfsHospitalizationStatus = source.readLong();
  _idfHospital = source.readLong();
  _idfsInitialCaseStatus = source.readLong();
  _datOnSetDate = (Date)source.readSerializable();
  _datExposureDate = (Date)source.readSerializable();
  _idfSoughtCareFacility = source.readLong();
  _datFirstSoughtCareDate = (Date)source.readSerializable();
  _idfsYNHospitalization = source.readLong();
  _strHospitalizationPlace = source.readString();
  _datHospitalizationDate = (Date)source.readSerializable();
  _strComment = source.readString();
  _idfsYNSpecimenCollected = source.readLong();
  _idfsNotCollectedReason = source.readLong();
  _idfsYNTestsConducted = source.readLong();
  _idfsFinalCaseStatus = source.readLong();
  _datFinalCaseClassificationDate = (Date)source.readSerializable();
  _idfsFinalDiagnosis = source.readLong();
  _datFinalDiagnosisDate = (Date)source.readSerializable();
  _blnClinicalDiagBasis = source.readInt() == 1;
  _blnEpiDiagBasis = source.readInt() == 1;
  _blnLabDiagBasis = source.readInt() == 1;
  _idfsOutcome = source.readLong();
  _idfsYNRelatedToOutbreak = source.readLong();
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
  dest.writeLong(_idfEpiObservation);
  dest.writeLong(_idfCSObservation);
  dest.writeSerializable(_datModificationDate);
  dest.writeString(_strCaseID);
  dest.writeString(_strLocalIdentifier);
  dest.writeSerializable(_datCompletionPaperFormDate);
  dest.writeLong(_idfsTentativeDiagnosis);
  dest.writeSerializable(_datTentativeDiagnosisDate);
  dest.writeSerializable(_datNotificationDate);
  dest.writeLong(_idfSentByOffice);
  dest.writeString(_strSentByPerson);
  dest.writeLong(_idfReceivedByOffice);
  dest.writeString(_strReceivedByPerson);
  dest.writeLong(_idfInvestigatedByOffice);
  dest.writeString(_strEpidemiologistsName);
  dest.writeSerializable(_datInvestigationStartDate);
  dest.writeString(_strFamilyName);
  dest.writeString(_strFirstName);
  dest.writeString(_strSecondName);
  dest.writeSerializable(_datDateofBirth);
  dest.writeInt(_intPatientAge);
  dest.writeLong(_idfsHumanAgeType);
  dest.writeLong(_idfsHumanGender);
  dest.writeLong(_idfsPersonIDType);
  dest.writeString(_strPersonID);
  dest.writeLong(_idfsNationality);
  dest.writeLong(_idfsRegionCurrentResidence);
  dest.writeLong(_idfsRayonCurrentResidence);
  dest.writeLong(_idfsSettlementCurrentResidence);
  dest.writeString(_strStreetName);
  dest.writeString(_strBuilding);
  dest.writeString(_strHouse);
  dest.writeString(_strApartment);
  dest.writeString(_strPostCode);
  dest.writeDouble(_dblLongitude);
  dest.writeDouble(_dblLatitude);
  dest.writeString(_strHomePhone);
  dest.writeString(_strPermanentResidencePhone);
  dest.writeString(_strEmployerName);
  dest.writeString(_strWorkPhone);
  dest.writeLong(_idfsFinalState);
  dest.writeLong(_idfsHospitalizationStatus);
  dest.writeLong(_idfHospital);
  dest.writeLong(_idfsInitialCaseStatus);
  dest.writeSerializable(_datOnSetDate);
  dest.writeSerializable(_datExposureDate);
  dest.writeLong(_idfSoughtCareFacility);
  dest.writeSerializable(_datFirstSoughtCareDate);
  dest.writeLong(_idfsYNHospitalization);
  dest.writeString(_strHospitalizationPlace);
  dest.writeSerializable(_datHospitalizationDate);
  dest.writeString(_strComment);
  dest.writeLong(_idfsYNSpecimenCollected);
  dest.writeLong(_idfsNotCollectedReason);
  dest.writeLong(_idfsYNTestsConducted);
  dest.writeLong(_idfsFinalCaseStatus);
  dest.writeSerializable(_datFinalCaseClassificationDate);
  dest.writeLong(_idfsFinalDiagnosis);
  dest.writeSerializable(_datFinalDiagnosisDate);
  if (_blnClinicalDiagBasis == null) { dest.writeInt(0); } else { dest.writeInt(_blnClinicalDiagBasis ? 1 : 0); }
  if (_blnEpiDiagBasis == null) { dest.writeInt(0); } else { dest.writeInt(_blnEpiDiagBasis ? 1 : 0); }
  if (_blnLabDiagBasis == null) { dest.writeInt(0); } else { dest.writeInt(_blnLabDiagBasis ? 1 : 0); }
  dest.writeLong(_idfsOutcome);
  dest.writeLong(_idfsYNRelatedToOutbreak);
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
  if (_idfEpiObservation != 0)
      serializer.attribute("", "idfEpiObservation", String.valueOf(_idfEpiObservation));
  if (_idfCSObservation != 0)
      serializer.attribute("", "idfCSObservation", String.valueOf(_idfCSObservation));
  if (_datModificationDate != null)
      serializer.attribute("", "datModificationDate", DateHelpers.FormatWithT(_datModificationDate));
  if (_strCaseID != null)
      serializer.attribute("", "strCaseID", _strCaseID);
  if (_strLocalIdentifier != null)
      serializer.attribute("", "strLocalIdentifier", _strLocalIdentifier);
  if (_datCompletionPaperFormDate != null)
      serializer.attribute("", "datCompletionPaperFormDate", DateHelpers.FormatWithT(_datCompletionPaperFormDate));
  if (_idfsTentativeDiagnosis != 0)
      serializer.attribute("", "idfsTentativeDiagnosis", String.valueOf(_idfsTentativeDiagnosis));
  if (_datTentativeDiagnosisDate != null)
      serializer.attribute("", "datTentativeDiagnosisDate", DateHelpers.FormatWithT(_datTentativeDiagnosisDate));
  if (_datNotificationDate != null)
      serializer.attribute("", "datNotificationDate", DateHelpers.FormatWithT(_datNotificationDate));
  if (_idfSentByOffice != 0)
      serializer.attribute("", "idfSentByOffice", String.valueOf(_idfSentByOffice));
  if (_strSentByPerson != null)
      serializer.attribute("", "strSentByPerson", _strSentByPerson);
  if (_idfReceivedByOffice != 0)
      serializer.attribute("", "idfReceivedByOffice", String.valueOf(_idfReceivedByOffice));
  if (_strReceivedByPerson != null)
      serializer.attribute("", "strReceivedByPerson", _strReceivedByPerson);
  if (_idfInvestigatedByOffice != 0)
      serializer.attribute("", "idfInvestigatedByOffice", String.valueOf(_idfInvestigatedByOffice));
  if (_strEpidemiologistsName != null)
      serializer.attribute("", "strEpidemiologistsName", _strEpidemiologistsName);
  if (_datInvestigationStartDate != null)
      serializer.attribute("", "datInvestigationStartDate", DateHelpers.FormatWithT(_datInvestigationStartDate));
  if (_strFamilyName != null)
      serializer.attribute("", "strFamilyName", _strFamilyName);
  if (_strFirstName != null)
      serializer.attribute("", "strFirstName", _strFirstName);
  if (_strSecondName != null)
      serializer.attribute("", "strSecondName", _strSecondName);
  if (_datDateofBirth != null)
      serializer.attribute("", "datDateofBirth", DateHelpers.FormatWithT(_datDateofBirth));
  if (_intPatientAge != 0)
      serializer.attribute("", "intPatientAge", String.valueOf(_intPatientAge));
  if (_idfsHumanAgeType != 0)
      serializer.attribute("", "idfsHumanAgeType", String.valueOf(_idfsHumanAgeType));
  if (_idfsHumanGender != 0)
      serializer.attribute("", "idfsHumanGender", String.valueOf(_idfsHumanGender));
  if (_idfsPersonIDType != 0)
      serializer.attribute("", "idfsPersonIDType", String.valueOf(_idfsPersonIDType));
  if (_strPersonID != null)
      serializer.attribute("", "strPersonID", _strPersonID);
  if (_idfsNationality != 0)
      serializer.attribute("", "idfsNationality", String.valueOf(_idfsNationality));
  if (_idfsRegionCurrentResidence != 0)
      serializer.attribute("", "idfsRegionCurrentResidence", String.valueOf(_idfsRegionCurrentResidence));
  if (_idfsRayonCurrentResidence != 0)
      serializer.attribute("", "idfsRayonCurrentResidence", String.valueOf(_idfsRayonCurrentResidence));
  if (_idfsSettlementCurrentResidence != 0)
      serializer.attribute("", "idfsSettlementCurrentResidence", String.valueOf(_idfsSettlementCurrentResidence));
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
  if (_strHomePhone != null)
      serializer.attribute("", "strHomePhone", _strHomePhone);
  if (_strPermanentResidencePhone != null)
      serializer.attribute("", "strPermanentResidencePhone", _strPermanentResidencePhone);
  if (_strEmployerName != null)
      serializer.attribute("", "strEmployerName", _strEmployerName);
  if (_strWorkPhone != null)
      serializer.attribute("", "strWorkPhone", _strWorkPhone);
  if (_idfsFinalState != 0)
      serializer.attribute("", "idfsFinalState", String.valueOf(_idfsFinalState));
  if (_idfsHospitalizationStatus != 0)
      serializer.attribute("", "idfsHospitalizationStatus", String.valueOf(_idfsHospitalizationStatus));
  if (_idfHospital != 0)
      serializer.attribute("", "idfHospital", String.valueOf(_idfHospital));
  if (_idfsInitialCaseStatus != 0)
      serializer.attribute("", "idfsInitialCaseStatus", String.valueOf(_idfsInitialCaseStatus));
  if (_datOnSetDate != null)
      serializer.attribute("", "datOnSetDate", DateHelpers.FormatWithT(_datOnSetDate));
  if (_datExposureDate != null)
      serializer.attribute("", "datExposureDate", DateHelpers.FormatWithT(_datExposureDate));
  if (_idfSoughtCareFacility != 0)
      serializer.attribute("", "idfSoughtCareFacility", String.valueOf(_idfSoughtCareFacility));
  if (_datFirstSoughtCareDate != null)
      serializer.attribute("", "datFirstSoughtCareDate", DateHelpers.FormatWithT(_datFirstSoughtCareDate));
  if (_idfsYNHospitalization != 0)
      serializer.attribute("", "idfsYNHospitalization", String.valueOf(_idfsYNHospitalization));
  if (_strHospitalizationPlace != null)
      serializer.attribute("", "strHospitalizationPlace", _strHospitalizationPlace);
  if (_datHospitalizationDate != null)
      serializer.attribute("", "datHospitalizationDate", DateHelpers.FormatWithT(_datHospitalizationDate));
  if (_strComment != null)
      serializer.attribute("", "strComment", _strComment);
  if (_idfsYNSpecimenCollected != 0)
      serializer.attribute("", "idfsYNSpecimenCollected", String.valueOf(_idfsYNSpecimenCollected));
  if (_idfsNotCollectedReason != 0)
      serializer.attribute("", "idfsNotCollectedReason", String.valueOf(_idfsNotCollectedReason));
  if (_idfsYNTestsConducted != 0)
      serializer.attribute("", "idfsYNTestsConducted", String.valueOf(_idfsYNTestsConducted));
  if (_idfsFinalCaseStatus != 0)
      serializer.attribute("", "idfsFinalCaseStatus", String.valueOf(_idfsFinalCaseStatus));
  if (_datFinalCaseClassificationDate != null)
      serializer.attribute("", "datFinalCaseClassificationDate", DateHelpers.FormatWithT(_datFinalCaseClassificationDate));
  if (_idfsFinalDiagnosis != 0)
      serializer.attribute("", "idfsFinalDiagnosis", String.valueOf(_idfsFinalDiagnosis));
  if (_datFinalDiagnosisDate != null)
      serializer.attribute("", "datFinalDiagnosisDate", DateHelpers.FormatWithT(_datFinalDiagnosisDate));
  if (_blnClinicalDiagBasis != null)
      serializer.attribute("", "blnClinicalDiagBasis", String.valueOf(_blnClinicalDiagBasis ? 1 : 0));
  if (_blnEpiDiagBasis != null)
      serializer.attribute("", "blnEpiDiagBasis", String.valueOf(_blnEpiDiagBasis ? 1 : 0));
  if (_blnLabDiagBasis != null)
      serializer.attribute("", "blnLabDiagBasis", String.valueOf(_blnLabDiagBasis ? 1 : 0));
  if (_idfsOutcome != 0)
      serializer.attribute("", "idfsOutcome", String.valueOf(_idfsOutcome));
  if (_idfsYNRelatedToOutbreak != 0)
      serializer.attribute("", "idfsYNRelatedToOutbreak", String.valueOf(_idfsYNRelatedToOutbreak));
}

public JSONObject ToJson() throws JSONException
{
JSONObject ret = new JSONObject();
EidssUtils.putToJson(ret, "lang", EidssUtils.getCurrentLanguage());
EidssUtils.putToJson(ret, "intChanged", _intChanged);
  EidssUtils.putToJson(ret, "uidOfflineCaseID", _uidOfflineCaseID);
  EidssUtils.putToJson(ret, "idfCase", _idfCase);
  EidssUtils.putToJson(ret, "idfEpiObservation", _idfEpiObservation);
  EidssUtils.putToJson(ret, "idfCSObservation", _idfCSObservation);
  EidssUtils.putToJson(ret, "datModificationDate", _datModificationDate);
  EidssUtils.putToJson(ret, "strCaseID", _strCaseID);
  EidssUtils.putToJson(ret, "strLocalIdentifier", _strLocalIdentifier);
  EidssUtils.putToJson(ret, "datCompletionPaperFormDate", _datCompletionPaperFormDate);
  EidssUtils.putToJson(ret, "idfsTentativeDiagnosis", _idfsTentativeDiagnosis);
  EidssUtils.putToJson(ret, "datTentativeDiagnosisDate", _datTentativeDiagnosisDate);
  EidssUtils.putToJson(ret, "datNotificationDate", _datNotificationDate);
  EidssUtils.putToJson(ret, "idfSentByOffice", _idfSentByOffice);
  EidssUtils.putToJson(ret, "strSentByPerson", _strSentByPerson);
  EidssUtils.putToJson(ret, "idfReceivedByOffice", _idfReceivedByOffice);
  EidssUtils.putToJson(ret, "strReceivedByPerson", _strReceivedByPerson);
  EidssUtils.putToJson(ret, "idfInvestigatedByOffice", _idfInvestigatedByOffice);
  EidssUtils.putToJson(ret, "strEpidemiologistsName", _strEpidemiologistsName);
  EidssUtils.putToJson(ret, "datInvestigationStartDate", _datInvestigationStartDate);
  EidssUtils.putToJson(ret, "strFamilyName", _strFamilyName);
  EidssUtils.putToJson(ret, "strFirstName", _strFirstName);
  EidssUtils.putToJson(ret, "strSecondName", _strSecondName);
  EidssUtils.putToJson(ret, "datDateofBirth", _datDateofBirth);
  EidssUtils.putToJson(ret, "intPatientAge", _intPatientAge);
  EidssUtils.putToJson(ret, "idfsHumanAgeType", _idfsHumanAgeType);
  EidssUtils.putToJson(ret, "idfsHumanGender", _idfsHumanGender);
  EidssUtils.putToJson(ret, "idfsPersonIDType", _idfsPersonIDType);
  EidssUtils.putToJson(ret, "strPersonID", _strPersonID);
  EidssUtils.putToJson(ret, "idfsNationality", _idfsNationality);
  EidssUtils.putToJson(ret, "idfsRegionCurrentResidence", _idfsRegionCurrentResidence);
  EidssUtils.putToJson(ret, "idfsRayonCurrentResidence", _idfsRayonCurrentResidence);
  EidssUtils.putToJson(ret, "idfsSettlementCurrentResidence", _idfsSettlementCurrentResidence);
  EidssUtils.putToJson(ret, "strStreetName", _strStreetName);
  EidssUtils.putToJson(ret, "strBuilding", _strBuilding);
  EidssUtils.putToJson(ret, "strHouse", _strHouse);
  EidssUtils.putToJson(ret, "strApartment", _strApartment);
  EidssUtils.putToJson(ret, "strPostCode", _strPostCode);
  EidssUtils.putToJson(ret, "dblLongitude", _dblLongitude);
  EidssUtils.putToJson(ret, "dblLatitude", _dblLatitude);
  EidssUtils.putToJson(ret, "strHomePhone", _strHomePhone);
  EidssUtils.putToJson(ret, "strPermanentResidencePhone", _strPermanentResidencePhone);
  EidssUtils.putToJson(ret, "strEmployerName", _strEmployerName);
  EidssUtils.putToJson(ret, "strWorkPhone", _strWorkPhone);
  EidssUtils.putToJson(ret, "idfsFinalState", _idfsFinalState);
  EidssUtils.putToJson(ret, "idfsHospitalizationStatus", _idfsHospitalizationStatus);
  EidssUtils.putToJson(ret, "idfHospital", _idfHospital);
  EidssUtils.putToJson(ret, "idfsInitialCaseStatus", _idfsInitialCaseStatus);
  EidssUtils.putToJson(ret, "datOnSetDate", _datOnSetDate);
  EidssUtils.putToJson(ret, "datExposureDate", _datExposureDate);
  EidssUtils.putToJson(ret, "idfSoughtCareFacility", _idfSoughtCareFacility);
  EidssUtils.putToJson(ret, "datFirstSoughtCareDate", _datFirstSoughtCareDate);
  EidssUtils.putToJson(ret, "idfsYNHospitalization", _idfsYNHospitalization);
  EidssUtils.putToJson(ret, "strHospitalizationPlace", _strHospitalizationPlace);
  EidssUtils.putToJson(ret, "datHospitalizationDate", _datHospitalizationDate);
  EidssUtils.putToJson(ret, "strComment", _strComment);
  EidssUtils.putToJson(ret, "idfsYNSpecimenCollected", _idfsYNSpecimenCollected);
  EidssUtils.putToJson(ret, "idfsNotCollectedReason", _idfsNotCollectedReason);
  EidssUtils.putToJson(ret, "idfsYNTestsConducted", _idfsYNTestsConducted);
  EidssUtils.putToJson(ret, "idfsFinalCaseStatus", _idfsFinalCaseStatus);
  EidssUtils.putToJson(ret, "datFinalCaseClassificationDate", _datFinalCaseClassificationDate);
  EidssUtils.putToJson(ret, "idfsFinalDiagnosis", _idfsFinalDiagnosis);
  EidssUtils.putToJson(ret, "datFinalDiagnosisDate", _datFinalDiagnosisDate);
  EidssUtils.putToJson(ret, "blnClinicalDiagBasis", _blnClinicalDiagBasis ? 1 : 0);
  EidssUtils.putToJson(ret, "blnEpiDiagBasis", _blnEpiDiagBasis ? 1 : 0);
  EidssUtils.putToJson(ret, "blnLabDiagBasis", _blnLabDiagBasis ? 1 : 0);
  EidssUtils.putToJson(ret, "idfsOutcome", _idfsOutcome);
  EidssUtils.putToJson(ret, "idfsYNRelatedToOutbreak", _idfsYNRelatedToOutbreak);
return ret;
}


public void FromJson(JSONObject json) throws JSONException, ParseException
{
  _uidOfflineCaseID = json.getString("uidOfflineCaseID");
  _idfCase = json.getLong("idfCase");
  _idfEpiObservation = json.getLong("idfEpiObservation");
  _idfCSObservation = json.getLong("idfCSObservation");
  _datModificationDate = DateHelpers.ParseWithT(json.getString("datModificationDate"));
  _strCaseID = json.getString("strCaseID");
  _strLocalIdentifier = json.getString("strLocalIdentifier");
  _datCompletionPaperFormDate = DateHelpers.ParseWithT(json.getString("datCompletionPaperFormDate"));
  _idfsTentativeDiagnosis = json.getLong("idfsTentativeDiagnosis");
  _datTentativeDiagnosisDate = DateHelpers.ParseWithT(json.getString("datTentativeDiagnosisDate"));
  _datNotificationDate = DateHelpers.ParseWithT(json.getString("datNotificationDate"));
  _idfSentByOffice = json.getLong("idfSentByOffice");
  _strSentByPerson = json.getString("strSentByPerson");
  _idfReceivedByOffice = json.getLong("idfReceivedByOffice");
  _strReceivedByPerson = json.getString("strReceivedByPerson");
  _idfInvestigatedByOffice = json.getLong("idfInvestigatedByOffice");
  _strEpidemiologistsName = json.getString("strEpidemiologistsName");
  _datInvestigationStartDate = DateHelpers.ParseWithT(json.getString("datInvestigationStartDate"));
  _strFamilyName = json.getString("strFamilyName");
  _strFirstName = json.getString("strFirstName");
  _strSecondName = json.getString("strSecondName");
  _datDateofBirth = DateHelpers.ParseWithT(json.getString("datDateofBirth"));
  _intPatientAge = json.getInt("intPatientAge");
  _idfsHumanAgeType = json.getLong("idfsHumanAgeType");
  _idfsHumanGender = json.getLong("idfsHumanGender");
  _idfsPersonIDType = json.getLong("idfsPersonIDType");
  _strPersonID = json.getString("strPersonID");
  _idfsNationality = json.getLong("idfsNationality");
  _idfsRegionCurrentResidence = json.getLong("idfsRegionCurrentResidence");
  _idfsRayonCurrentResidence = json.getLong("idfsRayonCurrentResidence");
  _idfsSettlementCurrentResidence = json.getLong("idfsSettlementCurrentResidence");
  _strStreetName = json.getString("strStreetName");
  _strBuilding = json.getString("strBuilding");
  _strHouse = json.getString("strHouse");
  _strApartment = json.getString("strApartment");
  _strPostCode = json.getString("strPostCode");
  _strHomePhone = json.getString("strHomePhone");
  _strPermanentResidencePhone = json.getString("strPermanentResidencePhone");
  _strEmployerName = json.getString("strEmployerName");
  _strWorkPhone = json.getString("strWorkPhone");
  _idfsFinalState = json.getLong("idfsFinalState");
  _idfsHospitalizationStatus = json.getLong("idfsHospitalizationStatus");
  _idfHospital = json.getLong("idfHospital");
  _idfsInitialCaseStatus = json.getLong("idfsInitialCaseStatus");
  _datOnSetDate = DateHelpers.ParseWithT(json.getString("datOnSetDate"));
  _datExposureDate = DateHelpers.ParseWithT(json.getString("datExposureDate"));
  _idfSoughtCareFacility = json.getLong("idfSoughtCareFacility");
  _datFirstSoughtCareDate = DateHelpers.ParseWithT(json.getString("datFirstSoughtCareDate"));
  _idfsYNHospitalization = json.getLong("idfsYNHospitalization");
  _strHospitalizationPlace = json.getString("strHospitalizationPlace");
  _datHospitalizationDate = DateHelpers.ParseWithT(json.getString("datHospitalizationDate"));
  _strComment = json.getString("strComment");
  _idfsYNSpecimenCollected = json.getLong("idfsYNSpecimenCollected");
  _idfsNotCollectedReason = json.getLong("idfsNotCollectedReason");
  _idfsYNTestsConducted = json.getLong("idfsYNTestsConducted");
  _idfsFinalCaseStatus = json.getLong("idfsFinalCaseStatus");
  _datFinalCaseClassificationDate = DateHelpers.ParseWithT(json.getString("datFinalCaseClassificationDate"));
  _idfsFinalDiagnosis = json.getLong("idfsFinalDiagnosis");
  _datFinalDiagnosisDate = DateHelpers.ParseWithT(json.getString("datFinalDiagnosisDate"));
  _blnClinicalDiagBasis = json.getBoolean("blnClinicalDiagBasis");
  _blnEpiDiagBasis = json.getBoolean("blnEpiDiagBasis");
  _blnLabDiagBasis = json.getBoolean("blnLabDiagBasis");
  _idfsOutcome = json.getLong("idfsOutcome");
  _idfsYNRelatedToOutbreak = json.getLong("idfsYNRelatedToOutbreak");
}
public void FromXml(XmlPullParser parser) throws ParseException
{
  _uidOfflineCaseID = parser.getAttributeValue("", "uidOfflineCaseID");
  _idfCase = parser.getAttributeValue("", "idfCase") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfCase"));
  _idfEpiObservation = parser.getAttributeValue("", "idfEpiObservation") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfEpiObservation"));
  _idfCSObservation = parser.getAttributeValue("", "idfCSObservation") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfCSObservation"));
  _datModificationDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datModificationDate"));
  _strCaseID = parser.getAttributeValue("", "strCaseID");
  _strLocalIdentifier = parser.getAttributeValue("", "strLocalIdentifier");
  _datCompletionPaperFormDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datCompletionPaperFormDate"));
  _idfsTentativeDiagnosis = parser.getAttributeValue("", "idfsTentativeDiagnosis") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsTentativeDiagnosis"));
  _datTentativeDiagnosisDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datTentativeDiagnosisDate"));
  _datNotificationDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datNotificationDate"));
  _idfSentByOffice = parser.getAttributeValue("", "idfSentByOffice") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfSentByOffice"));
  _strSentByPerson = parser.getAttributeValue("", "strSentByPerson");
  _idfReceivedByOffice = parser.getAttributeValue("", "idfReceivedByOffice") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfReceivedByOffice"));
  _strReceivedByPerson = parser.getAttributeValue("", "strReceivedByPerson");
  _idfInvestigatedByOffice = parser.getAttributeValue("", "idfInvestigatedByOffice") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfInvestigatedByOffice"));
  _strEpidemiologistsName = parser.getAttributeValue("", "strEpidemiologistsName");
  _datInvestigationStartDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datInvestigationStartDate"));
  _strFamilyName = parser.getAttributeValue("", "strFamilyName");
  _strFirstName = parser.getAttributeValue("", "strFirstName");
  _strSecondName = parser.getAttributeValue("", "strSecondName");
  _datDateofBirth = DateHelpers.ParseWithT(parser.getAttributeValue("", "datDateofBirth"));
  _intPatientAge = parser.getAttributeValue("", "intPatientAge") == null ? 0 : Integer.getInteger(parser.getAttributeValue("", "intPatientAge"));
  _idfsHumanAgeType = parser.getAttributeValue("", "idfsHumanAgeType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsHumanAgeType"));
  _idfsHumanGender = parser.getAttributeValue("", "idfsHumanGender") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsHumanGender"));
  _idfsPersonIDType = parser.getAttributeValue("", "idfsPersonIDType") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsPersonIDType"));
  _strPersonID = parser.getAttributeValue("", "strPersonID");
  _idfsNationality = parser.getAttributeValue("", "idfsNationality") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsNationality"));
  _idfsRegionCurrentResidence = parser.getAttributeValue("", "idfsRegionCurrentResidence") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsRegionCurrentResidence"));
  _idfsRayonCurrentResidence = parser.getAttributeValue("", "idfsRayonCurrentResidence") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsRayonCurrentResidence"));
  _idfsSettlementCurrentResidence = parser.getAttributeValue("", "idfsSettlementCurrentResidence") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsSettlementCurrentResidence"));
  _strStreetName = parser.getAttributeValue("", "strStreetName");
  _strBuilding = parser.getAttributeValue("", "strBuilding");
  _strHouse = parser.getAttributeValue("", "strHouse");
  _strApartment = parser.getAttributeValue("", "strApartment");
  _strPostCode = parser.getAttributeValue("", "strPostCode");
  _strHomePhone = parser.getAttributeValue("", "strHomePhone");
  _strPermanentResidencePhone = parser.getAttributeValue("", "strPermanentResidencePhone");
  _strEmployerName = parser.getAttributeValue("", "strEmployerName");
  _strWorkPhone = parser.getAttributeValue("", "strWorkPhone");
  _idfsFinalState = parser.getAttributeValue("", "idfsFinalState") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsFinalState"));
  _idfsHospitalizationStatus = parser.getAttributeValue("", "idfsHospitalizationStatus") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsHospitalizationStatus"));
  _idfHospital = parser.getAttributeValue("", "idfHospital") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfHospital"));
  _idfsInitialCaseStatus = parser.getAttributeValue("", "idfsInitialCaseStatus") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsInitialCaseStatus"));
  _datOnSetDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datOnSetDate"));
  _datExposureDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datExposureDate"));
  _idfSoughtCareFacility = parser.getAttributeValue("", "idfSoughtCareFacility") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfSoughtCareFacility"));
  _datFirstSoughtCareDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datFirstSoughtCareDate"));
  _idfsYNHospitalization = parser.getAttributeValue("", "idfsYNHospitalization") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsYNHospitalization"));
  _strHospitalizationPlace = parser.getAttributeValue("", "strHospitalizationPlace");
  _datHospitalizationDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datHospitalizationDate"));
  _strComment = parser.getAttributeValue("", "strComment");
  _idfsYNSpecimenCollected = parser.getAttributeValue("", "idfsYNSpecimenCollected") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsYNSpecimenCollected"));
  _idfsNotCollectedReason = parser.getAttributeValue("", "idfsNotCollectedReason") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsNotCollectedReason"));
  _idfsYNTestsConducted = parser.getAttributeValue("", "idfsYNTestsConducted") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsYNTestsConducted"));
  _idfsFinalCaseStatus = parser.getAttributeValue("", "idfsFinalCaseStatus") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsFinalCaseStatus"));
  _datFinalCaseClassificationDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datFinalCaseClassificationDate"));
  _idfsFinalDiagnosis = parser.getAttributeValue("", "idfsFinalDiagnosis") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsFinalDiagnosis"));
  _datFinalDiagnosisDate = DateHelpers.ParseWithT(parser.getAttributeValue("", "datFinalDiagnosisDate"));
  _blnClinicalDiagBasis = parser.getAttributeValue("", "blnClinicalDiagBasis") == null ? null : Boolean.getBoolean(parser.getAttributeValue("", "blnClinicalDiagBasis"));
  _blnEpiDiagBasis = parser.getAttributeValue("", "blnEpiDiagBasis") == null ? null : Boolean.getBoolean(parser.getAttributeValue("", "blnEpiDiagBasis"));
  _blnLabDiagBasis = parser.getAttributeValue("", "blnLabDiagBasis") == null ? null : Boolean.getBoolean(parser.getAttributeValue("", "blnLabDiagBasis"));
  _idfsOutcome = parser.getAttributeValue("", "idfsOutcome") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsOutcome"));
  _idfsYNRelatedToOutbreak = parser.getAttributeValue("", "idfsYNRelatedToOutbreak") == null ? 0 : Long.getLong(parser.getAttributeValue("", "idfsYNRelatedToOutbreak"));
}
}
