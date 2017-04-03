package com.bv.eidss.oa;

import com.WSParser.WebServices.EidssService.BaseReferenceRaw;
import com.WSParser.WebServices.EidssService.EidssService;
import com.WSParser.WebServices.EidssService.GisBaseReferenceRaw;
import com.WSParser.WebServices.EidssService.VectorBaseReferenceRaw;
import com.WSParser.WebServices.EidssService.VectorBaseReferenceTranslationRaw;
import com.WSParser.WebServices.EidssService.VectorGisBaseReferenceRaw;
import com.WSParser.WebServices.EidssService.VectorGisBaseReferenceTranslationRaw;
import com.WSParser.WebServices.EidssService.VectorHumanCaseInfo;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.GisBaseReferenceType;

// http://www.ibm.com/developerworks/webservices/library/ws-android/index.html
// http://www.wsdl2code.com/Home.aspx

public class OaClient {
	public EidssService service; 
	private String _Organization; 
	private String _User; 
	private String _Password; 
	
	public OaClient(String url, String Organization,String User,String Password)	{
		service = new EidssService();
		service.setUrl(url);
		_Organization = Organization; 
		_User = User; 
		_Password = Password; 
	}
	
	public VectorHumanCaseInfo SynchronizeHumanCases(VectorHumanCaseInfo hcs, String lang)throws Exception{
		return service.SaveHumanCases2(_Organization, _User, _Password, lang, hcs);
	}

	public VectorBaseReferenceRaw LoadReferences() throws Exception{
        VectorBaseReferenceRaw allref = new VectorBaseReferenceRaw();
        AddRefType(allref, BaseReferenceType.rftDiagnosis);
        AddRefType(allref, BaseReferenceType.rftHumanAgeType);
        AddRefType(allref, BaseReferenceType.rftHumanGender);
        AddRefType(allref, BaseReferenceType.rftFinalState);
        AddRefType(allref, BaseReferenceType.rftHospStatus);
        allref.addAll(service.LoadReference(_Organization, _User, _Password, BaseReferenceType.rftDiagnosis));
        allref.addAll(service.LoadReference(_Organization, _User, _Password, BaseReferenceType.rftHumanAgeType));
        allref.addAll(service.LoadReference(_Organization, _User, _Password, BaseReferenceType.rftHumanGender));
        allref.addAll(service.LoadReference(_Organization, _User, _Password, BaseReferenceType.rftFinalState));
        allref.addAll(service.LoadReference(_Organization, _User, _Password, BaseReferenceType.rftHospStatus));
        return allref;
    }
	
	public VectorBaseReferenceTranslationRaw LoadReferenceTranslations() throws Exception{
		VectorBaseReferenceTranslationRaw allref = new VectorBaseReferenceTranslationRaw();
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftDiagnosis, "en"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftDiagnosis, "ru"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftDiagnosis, "ka"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHumanAgeType, "en"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHumanAgeType, "ru"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHumanAgeType, "ka"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHumanGender, "en"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHumanGender, "ru"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHumanGender, "ka"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftFinalState, "en"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftFinalState, "ru"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftFinalState, "ka"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHospStatus, "en"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHospStatus, "ru"));
		allref.addAll(service.LoadReferenceTranslation(_Organization, _User, _Password, BaseReferenceType.rftHospStatus, "ka"));
        return allref;
	}
	
	public VectorGisBaseReferenceRaw LoadGisReferences() throws Exception{
		VectorGisBaseReferenceRaw allref = new VectorGisBaseReferenceRaw();
		AddGisRefType(allref, GisBaseReferenceType.rftCountry);
		AddGisRefType(allref, GisBaseReferenceType.rftRegion);
		AddGisRefType(allref, GisBaseReferenceType.rftRayon);
		AddGisRefType(allref, GisBaseReferenceType.rftSettlement);
		allref.addAll(service.LoadGisReference(_Organization, _User, _Password));
        return allref;
	}

	public VectorGisBaseReferenceTranslationRaw LoadGisReferenceTranslations() throws Exception{
		VectorGisBaseReferenceTranslationRaw allref = new VectorGisBaseReferenceTranslationRaw();
		allref.addAll(service.LoadGisReferenceTranslation(_Organization, _User, _Password, "en"));
		allref.addAll(service.LoadGisReferenceTranslation(_Organization, _User, _Password, "ru"));
		allref.addAll(service.LoadGisReferenceTranslation(_Organization, _User, _Password, "ka"));
        return allref;
	}
	
	
	private void AddRefType(VectorBaseReferenceRaw ref, long type)	{
        BaseReferenceRaw r = new BaseReferenceRaw();
        r.idfsBaseReference = 0;
        r.idfsReferenceType = type;
        r.intHACode = -1;
        r.strDefault = "";
        ref.add(r);
	}
	
	private void AddGisRefType(VectorGisBaseReferenceRaw ref, long type)	{
		GisBaseReferenceRaw r = new GisBaseReferenceRaw();
        r.idfsBaseReference = 0;
        r.idfsReferenceType = type;
        r.strDefault = "";
        ref.add(r);
	}
	
}
