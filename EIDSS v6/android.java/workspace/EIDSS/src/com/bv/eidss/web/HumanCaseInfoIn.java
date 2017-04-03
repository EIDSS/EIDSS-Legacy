package com.bv.eidss.web;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import org.json.JSONException;
import org.json.JSONObject;

import com.bv.eidss.model.HumanCase;

public class HumanCaseInfoIn {

    public String lang;
	
    public Long id;
    public String offlineCaseID;
    public String caseID;
    public String localIdentifier;
    public Long tentativeDiagnosis;
    public Date tentativeDiagnosisDate;
    public String firstName;
    public String lastName;
    public Date dateOfBirth;
    public Integer patientAge;
    public Long patientAgeType;
    public Long patientGender;
    public Long country;
    public Long region;
    public Long rayon;
    public Long settlement;
    public String building;
    public String house;
    public String apartment;
    public String street;
    public String zipCode;
    public String homePhone;
    public Date onsetDate;
    public Long patientState;
    public Long hospitalization;
    
    public HumanCaseInfoIn(){}
    
    public HumanCaseInfoIn(HumanCase hc, String lng, long cntry){
        lang = lng;
		id = hc.getCase();
		caseID = hc.getCaseID();
		offlineCaseID = hc.getOfflineCaseID();
		localIdentifier = hc.getLocalIdentifier();
        tentativeDiagnosis = hc.getTentativeDiagnosis();
        tentativeDiagnosisDate = hc.getTentativeDiagnosisDate();
        firstName = hc.getFirstName();
        lastName = hc.getFamilyName();
        dateOfBirth = hc.getDateofBirth();
        patientAge = hc.getPatientAge();
        patientAgeType = hc.getHumanAgeType();
        patientGender = hc.getHumanGender();
        country = cntry;
        region = hc.getRegionCurrentResidence();
        rayon = hc.getRayonCurrentResidence();
        settlement = hc.getSettlementCurrentResidence();
        building = hc.getBuilding();
        house = hc.getHouse();
        apartment = hc.getApartment();
        street = hc.getStreetName();
        zipCode = hc.getPostCode();
        homePhone = hc.getHomePhone();
        onsetDate = hc.getOnSetDate();
        patientState = hc.getFinalState();
        hospitalization = hc.getHospitalizationStatus();
    }
    
    public JSONObject json() throws JSONException{
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
    	JSONObject ret = new JSONObject();
    	ret.put("lang", lang);
    	ret.put("id", id);
    	ret.put("offlineCaseID", offlineCaseID);
    	ret.put("caseID", caseID);
    	if (localIdentifier != null)
    		ret.put("localIdentifier", localIdentifier);
    	if (tentativeDiagnosis != null)
        	ret.put("tentativeDiagnosis", tentativeDiagnosis.longValue());
    	if (tentativeDiagnosisDate != null)
        	ret.put("tentativeDiagnosisDate", format.format(tentativeDiagnosisDate).replace(' ', 'T'));
    	if (firstName != null)
    		ret.put("firstName", firstName);
    	if (lastName != null)
    		ret.put("lastName", lastName);
    	if (dateOfBirth != null)
        	ret.put("dateOfBirth", format.format(dateOfBirth));
    	if (patientAge != null)
        	ret.put("patientAge", patientAge.intValue());
    	if (patientAgeType != null)
        	ret.put("patientAgeType", patientAgeType.longValue());
    	if (patientGender != null)
        	ret.put("patientGender", patientGender.longValue());
    	if (country != null)
        	ret.put("country", country.longValue());
    	if (region != null)
        	ret.put("region", region.longValue());
    	if (rayon != null)
        	ret.put("rayon", rayon.longValue());
    	if (settlement != null)
        	ret.put("settlement", settlement.longValue());
    	if (building != null)
    		ret.put("building", building);
    	if (house != null)
    		ret.put("house", house);
    	if (apartment != null)
    		ret.put("apartment", apartment);
    	if (street != null)
    		ret.put("street", street);
    	if (zipCode != null)
    		ret.put("zipCode", zipCode);
    	if (homePhone != null)
    		ret.put("homePhone", homePhone);
    	if (onsetDate != null)
        	ret.put("onsetDate", format.format(onsetDate));
    	if (patientState != null)
        	ret.put("patientState", patientState.longValue());
    	if (hospitalization != null)
        	ret.put("hospitalization", hospitalization.longValue());
    	return ret;
    }
}
