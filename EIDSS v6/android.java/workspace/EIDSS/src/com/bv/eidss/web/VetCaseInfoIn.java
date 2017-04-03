package com.bv.eidss.web;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import com.bv.eidss.model.Species;
import com.bv.eidss.model.VetCase;

public class VetCaseInfoIn {

    public String lang;
	
    public Long id;
    public String offlineCaseID;
    public String caseID;
    public Long caseType;
    public int caseHACode;
    public Long caseReportType;
    public String localIdentifier;
    public Long tentativeDiagnosis;
    public Date tentativeDiagnosisDate;
    public String farmCode;
    public String farmName;
    public String firstName;
    public String lastName;
    public String middleName;
    public Long country;
    public Long region;
    public Long rayon;
    public Long settlement;
    public String building;
    public String house;
    public String apartment;
    public String street;
    public String zipCode;
    public String phone;
    public Double longitude;
    public Double latitude;
    public Date enteredDate;
    public List<SpeciesInfoIn> species;
    
    public VetCaseInfoIn(){
        species = new ArrayList<SpeciesInfoIn>();
    }
    
    public VetCaseInfoIn(VetCase vc, String lng, long cntry){
        lang = lng;
		id = vc.getCase();
		caseID = vc.getCaseID();
		offlineCaseID = vc.getOfflineCaseID();
		caseType = vc.getCaseType();
		caseHACode = VetCase.GetVetCaseHaCode(vc.getCaseType());
		caseReportType = vc.getCaseReportType();
		localIdentifier = vc.getLocalIdentifier();
        tentativeDiagnosis = vc.getTentativeDiagnosis();
        tentativeDiagnosisDate = vc.getTentativeDiagnosisDate();
        farmCode = vc.getFarmCode();
        farmName = vc.getFarmName();
        firstName = vc.getOwnerFirstName();
        lastName = vc.getOwnerLastName();
        middleName = vc.getOwnerMiddleName();
        country = cntry;
        region = vc.getRegion();
        rayon = vc.getRayon();
        settlement = vc.getSettlement();
        building = vc.getBuilding();
        house = vc.getHouse();
        apartment = vc.getApartment();
        street = vc.getStreetName();
        zipCode = vc.getPostCode();
        phone = vc.getPhone();
        longitude = vc.getLongitude();
        latitude = vc.getLatitude();
        enteredDate = vc.getReportDate();
		
        species = new ArrayList<SpeciesInfoIn>();
        for(Species s:vc.species)
        {
        	species.add(new SpeciesInfoIn(s, lang));
        }
    }
    
    public JSONObject json() throws JSONException{
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
    	JSONObject ret = new JSONObject();
    	ret.put("lang", lang);
    	ret.put("id", id);
    	ret.put("offlineCaseID", offlineCaseID);
    	ret.put("caseID", caseID);
    	ret.put("caseType", caseType.longValue());
    	ret.put("caseHACode", caseHACode);
    	if (caseReportType != null)
    		ret.put("caseReportType", caseReportType.longValue());
    	if (localIdentifier != null)
    		ret.put("localIdentifier", localIdentifier);
    	if (tentativeDiagnosis != null)
        	ret.put("tentativeDiagnosis", tentativeDiagnosis.longValue());
    	if (tentativeDiagnosisDate != null)
        	ret.put("tentativeDiagnosisDate", format.format(tentativeDiagnosisDate).replace(' ', 'T'));
    	if (farmName != null)
    		ret.put("farmName", farmName);
    	if (firstName != null)
    		ret.put("ownerFirstName", firstName);
    	if (lastName != null)
    		ret.put("ownerLastName", lastName);
    	if (middleName != null)
    		ret.put("ownerMiddleName", middleName);
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
    	if (phone != null)
    		ret.put("phone", phone);
    	if (longitude != null)
        	ret.put("longitude", longitude.doubleValue());
    	if (latitude != null)
        	ret.put("latitude", latitude.doubleValue());
    	if (enteredDate != null)
        	ret.put("enteredDate", format.format(enteredDate).replace(' ', 'T'));
    	
    	JSONArray list = new JSONArray();
        for (SpeciesInfoIn sp: species){
        	list.put(sp.json());
    	}
    	ret.put("species", list);
     
    	return ret;
    }
}
