package com.bv.eidss.model;

import java.io.IOException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.UUID;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.generated.HumanCaseSample_object;
import com.bv.eidss.model.generated.HumanCase_object;
import com.bv.eidss.model.interfaces.Constants;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.ICase;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.web.HumanCaseInfoOut;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

public class HumanCase
    extends HumanCase_object
    implements Parcelable, IValidatable, ICase {

    public List<HumanCaseSample> samples;

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }


    public FFModel FFModelCS;
    public FFModel FFModelEpi;


    private HumanCase()
    {
        samples = new ArrayList<>();
        bChanged = false;
    }
    public static HumanCase CreateNew()
    {
        HumanCase ret = new HumanCase();
        ret._intStatus = CaseStatus.NEW;
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret._strCaseID = "(new)";
        ret._idfsRegionCurrentResidence = EidssDatabase.GetOptions().getRegionDef();
        ret._idfsRayonCurrentResidence = EidssDatabase.GetOptions().getRayonDef();
        ret._datCreateDate = new Date();
        ret.bChanged = true;
        ret.FFModelCS = FFModel.CreateNew(ret.getCSObservation(), FFTypesEnum.HumanClinicalSigns);//0 for a new case
        ret.FFModelEpi = FFModel.CreateNew(ret.getEpiObservation(), FFTypesEnum.HumanEpiInvestigations);//0 for a new case
        return ret;
    }


    public Boolean getChanged()
    {
        for(HumanCaseSample s:samples)
            bChanged = bChanged || s.getChanged();
        return bChanged
                || (FFModelCS != null ? FFModelCS.getChanged() : false)
                || (FFModelEpi != null ? FFModelEpi.getChanged() : false)
                ;
    }
    public void setChanged(){
        bChanged = true;
    }
    public void setUnchanged()
    {
        for(HumanCaseSample s:samples)
            s.setUnchanged();
        bChanged = false;
    }

    public void SetFromOut(HumanCaseInfoOut ci){
        // Sync group 3
        setCase(ci.getCase());
        setCaseID(ci.getCaseID());
        setNotificationDate(ci.getNotificationDate());
        setSentByOffice(ci.getSentByOffice());
        setSentByPerson(ci.getSentByPerson());
        setReceivedByOffice(ci.getReceivedByOffice());
        setReceivedByPerson(ci.getReceivedByPerson());
        setInvestigatedByOffice(ci.getInvestigatedByOffice());
        setInvestigationStartDate(ci.getInvestigationStartDate());
        setYNTestsConducted(ci.getYNTestsConducted());
        setFinalCaseStatus(ci.getFinalCaseStatus());
        setFinalCaseClassificationDate(ci.getFinalCaseClassificationDate());
        setEpidemiologistsName(ci.getEpidemiologistsName());
        setFinalDiagnosis(ci.getFinalDiagnosis());
        setFinalDiagnosisDate(ci.getFinalDiagnosisDate());
        setClinicalDiagBasis(ci.getClinicalDiagBasis());
        setEpiDiagBasis(ci.getEpiDiagBasis());
        setLabDiagBasis(ci.getLabDiagBasis());
        setOutcome(ci.getOutcome());
        setYNRelatedToOutbreak(ci.getYNRelatedToOutbreak());
        setModificationDate(ci.getModificationDate());

        // Sync group 2
        setInitialCaseStatus(ci.getInitialCaseStatus());
        setSoughtCareFacility(ci.getSoughtCareFacility());
        setFirstSoughtCareDate(ci.getFirstSoughtCareDate());
        setYNHospitalization(ci.getYNHospitalization());
        setHospitalizationPlace(ci.getHospitalizationPlace());
        setHospitalizationDate(ci.getHospitalizationDate());
        setYNSpecimenCollected(ci.getYNSpecimenCollected());
        setNotCollectedReason(ci.getNotCollectedReason());

        // Sync for FF
        setCSObservation(ci.getCSObservation());
        setEpiObservation(ci.getEpiObservation());

        FFModelCS.SetObservation(getCSObservation());
        FFModelEpi.SetObservation(getEpiObservation());

        /*
        FFModelCS.ActivityParameters.clear();
        FFModelEpi.ActivityParameters.clear();
        for(int i = 0; i < ci.CsActivityParameters.size(); i++){
            ActivityParameter ap = ci.CsActivityParameters.get(i);
            FFModelCS.ActivityParameters.put(ap.GetKey(), ap);
        }
        for(int i = 0; i < ci.EpiActivityParameters.size(); i++){
            ActivityParameter ap = ci.EpiActivityParameters.get(i);
            FFModelEpi.ActivityParameters.put(ap.GetKey(), ap);
        }
        */
        for (HumanCaseSample_object an: ci.samples){
            boolean bFound = false;
            for(int i = 0; i < samples.size(); i++){
                HumanCaseSample vcs = samples.get(i);
                if (vcs.getOfflineCaseID().equals(an.getOfflineCaseID())) {
                    vcs.setParent(getId());
                    vcs.SetFromAnother(an);
                    bFound = true;
                    break;
                }
            }
            if (!bFound) {
                HumanCaseSample vcs = HumanCaseSample.CreateNew(getId());
                vcs.SetFromAnother(an);
                samples.add(vcs);
            }

        }
    }

	private Date getD()
    {
        Calendar cal = Calendar.getInstance();
        if (_datOnSetDate != null)
            cal.setTime(_datOnSetDate);
        else if (_datNotificationDate != null)
            cal.setTime(_datNotificationDate);
        else
            cal.setTime(_datCreateDate);

        cal.set(Calendar.HOUR_OF_DAY, 0);
        cal.set(Calendar.MINUTE, 0);
        cal.set(Calendar.SECOND, 0);
        cal.set(Calendar.MILLISECOND, 0);

        return cal.getTime();
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
        double ddAge;
        Date datUp;
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
    	//HumanCase ret = new HumanCase();
        HumanCase ret = CreateNew();
        if (FromCursor(cursor, ret) == null) return null;
        ret.FFModelCS.SetObservation(ret.getCSObservation());
        ret.FFModelEpi.SetObservation(ret.getEpiObservation());
    	return ret;
    }

    public ContentValues ContentValues()
    {
        return ContentValuesInternal();
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

    private HumanCase(Parcel source)
    {
        samples = new ArrayList<>();
        bChanged = false;
        FromParcel(source);
        source.readTypedList(samples, HumanCaseSample.CREATOR);
        FFModelCS = FFModel.CreateNew(source);
        FFModelEpi = FFModel.CreateNew(source);
    }
    
    @Override
	public int describeContents() {
        return 4;
	}
	
	@Override
	public void writeToParcel(Parcel dest, int flag) {
        ToParcel(dest, flag);
        dest.writeTypedList(samples);
        if (FFModelCS != null) FFModelCS.writeToParcel(dest, flag);
        if (FFModelEpi != null) FFModelEpi.writeToParcel(dest, flag);
	}
	
	@Override
	public ValidateResult Validate(List<String> mandatoryFields, List<String> invisibleFields) {
        // business rules
        ArrayList<String> mandatoryFieldsActual = new ArrayList<>(mandatoryFields);
        if (getPersonIDType() != 0 && getPersonIDType() != Constants.PersonalIDType_Unknown)
            mandatoryFieldsActual.add(eidss_PersonID);
        if (getYNSpecimenCollected() == Constants.YesNoUnknownValues_No)
            mandatoryFieldsActual.add(eidss_NotCollectedReason);

        for (FieldMetadata meta : fieldMetadata) {
            if (!meta.CheckMandatory(this, mandatoryFieldsActual, invisibleFields)) {
                return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
            }
        }

        if (getDateofBirth() != null && getDateofBirth().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateOfBirthCheckCurrent);
        if (getOnSetDate() != null && getOnSetDate().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateOfSymptomCheckCurrent);
        if (getTentativeDiagnosisDate() != null && getTentativeDiagnosisDate().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateOfDiagnosisCheckCurrent);
        if (getTentativeDiagnosisDate() != null && getNotificationDate() != null && getTentativeDiagnosisDate().after(getNotificationDate()))
        	return new ValidateResult(ValidateCode.DateOfDiagnosisCheckNotification);
        if (getDateofBirth() != null && getTentativeDiagnosisDate() != null && getDateofBirth().after(getTentativeDiagnosisDate()))
        	return new ValidateResult(ValidateCode.DateOfBirthCheckDiagnosis);
        if (getDateofBirth() != null && getNotificationDate() != null && getDateofBirth().after(getNotificationDate()))
        	return new ValidateResult(ValidateCode.DateOfBirthCheckNotification);
        if (getOnSetDate() != null && getTentativeDiagnosisDate() != null && getOnSetDate().after(getTentativeDiagnosisDate()))
        	return new ValidateResult(ValidateCode.DateOfSymptomCheckDiagnosis);
        if ((getHumanAgeType() == 0 && getPatientAge() != 0) || (getHumanAgeType() != 0 && getPatientAge() == 0))
        	return new ValidateResult(ValidateCode.AgeType);

        for(HumanCaseSample s:samples)
        {
            ValidateResult vc = s.Validate(mandatoryFields, invisibleFields);
            if (vc.getCode() != ValidateCode.OK)
                return vc;
        }

        if (FFModelCS != null) {
            ValidateResult vr = FFModelCS.Validate();
            if (vr.getCode() != ValidateCode.OK)
                return vr;
        }
        if (FFModelEpi != null) {
            ValidateResult vr = FFModelEpi.Validate();
            if (vr.getCode() != ValidateCode.OK)
                return vr;
        }
		return new ValidateResult(ValidateCode.OK);
	}

	private void ToXml(long country, XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "case");
        serializer.attribute("", "country", String.valueOf(country));
        ToXml(serializer);
        serializer.startTag("", "samples");
        for (HumanCaseSample sp: samples){
            sp.ToXml(serializer);
        }
        serializer.endTag("", "samples");
        FFModelCS.ToXml(serializer);
        FFModelEpi.ToXml(serializer);
        serializer.endTag("", "case");
	}

	public static void ToXml(List<HumanCase> hcs, long country, XmlSerializer serializer, Boolean bAll) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "human");
        for (HumanCase hc: hcs){
        	if (bAll || hc.getStatus() == CaseStatus.NEW || hc.getStatus() == CaseStatus.CHANGED || hc.getStatus() == CaseStatus.UNLOADED){
        		hc.ToXml(country, serializer);
        	}
        }
        serializer.endTag("", "human");
	}

    /*public static void FromXml(List<HumanCase> hcs, XmlPullParser parser)throws XmlPullParserException, IOException, ParseException {
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("case")){
                        HumanCase r = new HumanCase();
                        r.FromXml(parser);
                        hcs.add(r);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("human")){
                        return;
                    }
                    break;
            }
            eventType = parser.next();
        }
    }*/

    public void FromJson(JSONObject json) throws JSONException, ParseException
    {
        super.FromJson(json);
        JSONArray jsonArray = json.getJSONArray("samples");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                HumanCaseSample sp = HumanCaseSample.CreateNew(getId());
                sp.FromJson(jsonArray.getJSONObject(i));
            }
        }
    }

    @Override
    public JSONObject ToJson() throws JSONException {
        JSONObject ret = super.ToJson();
        JSONArray list = new JSONArray();
        for (HumanCaseSample sp: samples){
            list.put(sp.ToJson());
        }
        ret.put("samples", list);
        ret.put("FFModelCS", FFModelCS.ToJson());
        ret.put("FFModelEpi", FFModelEpi.ToJson());
        return ret;
    }

	public static void updateStatusUploaded(List<HumanCase> hcs){
        for (HumanCase hc: hcs){
        	if (hc.getStatus() == CaseStatus.NEW || hc.getStatus() == CaseStatus.CHANGED){
        		hc.setStatusUploaded();
        	}
        }
	}
}
