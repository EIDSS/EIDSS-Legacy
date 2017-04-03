package com.bv.eidss.data;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.WSParser.WebServices.EidssService.VectorBaseReferenceRaw;
import com.WSParser.WebServices.EidssService.VectorBaseReferenceTranslationRaw;
import com.WSParser.WebServices.EidssService.VectorGisBaseReferenceRaw;
import com.WSParser.WebServices.EidssService.VectorGisBaseReferenceTranslationRaw;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.Options;


public class EidssDatabase extends SQLiteOpenHelper {

    private static final String create_sql_options = 
"CREATE TABLE Options\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strServerUrl TEXT NULL\n" +
", strLocalPassword TEXT NULL\n" +
", strLoginOrganization TEXT NULL\n" +
", strLoginUsername TEXT NULL\n" +
")";
    private static final String create_sql_human_case =
"CREATE TABLE HumanCase\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" +
", uidOfflineCaseID TEXT NULL\n" +
", strCaseID TEXT NULL\n" +
", idfCase BIGINT NULL\n" +
"\n" +
", strLocalIdentifier TEXT NULL\n" +
", idfsTentativeDiagnosis BIGINT NULL\n" +
", datTentativeDiagnosisDate DATE NULL\n" +
", strFamilyName TEXT NULL\n" +
", strFirstName TEXT NULL\n" +
", datDateofBirth DATE NULL\n" +
", intPatientAge INT NULL\n" +
", idfsHumanAgeType BIGINT NULL\n" +
", idfsHumanGender BIGINT NULL\n" +
", idfsRegionCurrentResidence BIGINT NULL\n" +
", idfsRayonCurrentResidence BIGINT NULL\n" +
", idfsSettlementCurrentResidence BIGINT NULL\n" +
", strBuilding TEXT NULL\n" +
", strHouse TEXT NULL\n" +
", strApartment TEXT NULL\n" +
", strStreetName TEXT NULL\n" +
", strPostCode TEXT NULL\n" +
", strHomePhone TEXT NULL\n" +
", datOnSetDate DATE NULL\n" +
", idfsFinalState BIGINT NULL\n" +
", idfsHospitalizationStatus BIGINT NULL\n" +
", datNotificationDate DATE NULL\n" +
", strSentByOffice TEXT NULL\n" +
", strSentByPerson TEXT NULL\n" +
")";
    private static final String create_sql_references = 
"CREATE TABLE BaseReference\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", idfsBaseReference BIGINT NULL\n" +
", idfsReferenceType BIGINT NULL\n" +
", intHACode INT NULL\n" +
", strDefault TEXT NULL\n" +
")";
    private static final String create_sql_gis_references = 
"CREATE TABLE GisBaseReference\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", idfsBaseReference BIGINT NULL\n" +
", idfsReferenceType BIGINT NULL\n" +
", idfsCountry BIGINT NULL\n" +
", idfsRegion BIGINT NULL\n" +
", idfsRayon BIGINT NULL\n" +
", strDefault TEXT NULL\n" +
")";
    private static final String create_sql_references_lang = 
"CREATE TABLE BaseReferenceTranslation\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", idfsBaseReference BIGINT NULL\n" +
", strTranslation TEXT NULL\n" +
", strLanguage TEXT NULL\n" +
")";
    private static final String create_sql_gis_references_lang = 
"CREATE TABLE GisBaseReferenceTranslation\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", idfsBaseReference BIGINT NULL\n" +
", strTranslation TEXT NULL\n" +
", strLanguage TEXT NULL\n" +
")";
    private static final String insert_options_def =
/*    		
"INSERT INTO Options\n" +
"(\n" +
"strServerUrl,\n" +
"strLocalPassword,\n" +
"strLoginOrganization,\n" +
"strLoginUsername\n" +
")\n" +
"VALUES\n" +
"(\n" +
"'http://95.167.107.83:8083/',\n" +
"'',\n" +
"'molhsa',\n" +
"'demo'\n" +
")";
*/
"INSERT INTO Options\n" +
"(\n" +
"strServerUrl,\n" +
"strLocalPassword,\n" +
"strLoginOrganization,\n" +
"strLoginUsername\n" +
")\n" +
"VALUES\n" +
"(\n" +
"'http://oa.eidss.info/',\n" +
//"'http://oa.eidss.or.tz/',\n" +
//"'https://192.168.10.34:1443/',\n" +
//"'http://192.168.10.34:8080/',\n" +
"'',\n" +
//"'NCDC&PH',\n" +
"'',\n" +
//"'test_admin'\n" +
"''\n" +
")";

    private static final String select_sql_reference = 
"SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
"FROM BaseReference br\n" +
"LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
"WHERE br.idfsReferenceType = ?\n" +
"ORDER BY name";
    private static final String select_sql_reference_hacodable = 
"SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
"FROM BaseReference br\n" +
"LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
"WHERE br.idfsReferenceType = ? and br.intHACode & ?\n" +
"ORDER BY name";
    private static final String select_sql_country = 
"SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
"FROM GisBaseReference br\n" +
"LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
"WHERE br.idfsReferenceType = 19000001\n" +
"ORDER BY name";
    private static final String select_sql_regions = 
"SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
"FROM GisBaseReference br\n" +
"LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
"WHERE br.idfsReferenceType = 19000003\n" +
"ORDER BY name";
    private static final String select_sql_rayons = 
"SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
"FROM GisBaseReference br\n" +
"LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
"WHERE br.idfsReferenceType = 19000002 and (br.idfsRegion = ? or br.idfsBaseReference = 0)\n" +
"ORDER BY name";
    private static final String select_sql_settlements = 
"SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
"FROM GisBaseReference br\n" +
"LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
"WHERE br.idfsReferenceType = 19000004 and (br.idfsRayon = ? or br.idfsBaseReference = 0)\n" +
"ORDER BY name";
	
    private final static String DatabaseName = "eidss.db";
    private final static int DatabaseVersion = 1;  
    public EidssDatabase(Context context) {
    	super(context, DatabaseName, null, DatabaseVersion);
    }
	
	@Override
	public void onCreate(SQLiteDatabase db) {
        db.execSQL(create_sql_options);
        db.execSQL(insert_options_def);
        db.execSQL(create_sql_references);
        db.execSQL(create_sql_references_lang);
        db.execSQL(create_sql_gis_references);
        db.execSQL(create_sql_gis_references_lang);
        db.execSQL(create_sql_human_case);
	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
	}
	
    public String getCurrentLanguage()
    {
    	String lang = Locale.getDefault().getLanguage();
    	String country = Locale.getDefault().getCountry();
        if (lang.compareTo("ru") == 0)
            return "ru";
        if (lang.compareTo("en") == 0){
            if (country.compareTo("AU") == 0){
                return "ka";
            }
            if (country.compareTo("GB") == 0){
                return "ka";
            }
        }
    	return "en";
    }
	

    public Options Options()
    {
    	Cursor cursor = getReadableDatabase().query("Options", null, null, null, null, null, null);
        cursor.moveToFirst();
        Options ret = Options.FromCursor(cursor);
        return ret;
    }
    public Options OptionsUpdate(Options o)
    {
        getWritableDatabase().replace("Options", null, o.ContentValues());
        return o;
    }
    
    public boolean LoadReferences(VectorBaseReferenceRaw refs, VectorBaseReferenceTranslationRaw refs_trans, 
    		VectorGisBaseReferenceRaw gis_refs, VectorGisBaseReferenceTranslationRaw gis_refs_trans)
    {
    	try{
	    	SQLiteDatabase db = getWritableDatabase();
	    	db.beginTransaction();
	    	db.delete("GisBaseReferenceTranslation", null, null);
	    	db.delete("GisBaseReference", null, null);
	    	db.delete("BaseReferenceTranslation", null, null);
	    	db.delete("BaseReference", null, null);
	    	
	    	for(int i = 0; i < refs.size(); i++){
	    		db.insert("BaseReference", null, refs.get(i).ContentValues());
	    	}
	    	for(int i = 0; i < refs_trans.size(); i++){
	    		db.insert("BaseReferenceTranslation", null, refs_trans.get(i).ContentValues());
	    	}
	    	for(int i = 0; i < gis_refs.size(); i++){
	    		db.insert("GisBaseReference", null, gis_refs.get(i).ContentValues());
	    	}
	    	for(int i = 0; i < gis_refs_trans.size(); i++){
	    		db.insert("GisBaseReferenceTranslation", null, gis_refs_trans.get(i).ContentValues());
	    	}
	    	
	        db.setTransactionSuccessful();
	        db.endTransaction();
	        return true;
    	}
    	catch(Exception e){
            e.printStackTrace();
    		return false;
    	}
    }

    public List<BaseReference> Reference(long type, String lang, int hacode)
    {
    	List<BaseReference> ret = new ArrayList<BaseReference>();
    	String sql;
    	String[] args;
    	if (hacode == 0) {
    		sql = select_sql_reference;
    		args = new String[2];
    		args[0] = lang;
    		args[1] = String.valueOf(type);
    	}
    	else {
    		sql = select_sql_reference_hacodable;
    		args = new String[3];
    		args[0] = lang;
    		args[1] = String.valueOf(type);
    		args[2] = String.valueOf(hacode);
    	}
    	Cursor cursor = getReadableDatabase().rawQuery(sql, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
            ret.add(BaseReference.FromCursor(cursor));
            r = cursor.moveToNext();
        }
        cursor.close();
        //ret.Sort((a, b) => a.name.CompareTo(b.name));
        return ret;
    }
    
    public GisBaseReference GisCountry(String lang)
    {
        GisBaseReference ret = null;
    	String[] args = new String[1];
    	args[0] = lang;
    	Cursor cursor = getReadableDatabase().rawQuery(select_sql_country, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
        	ret = GisBaseReference.FromCursor(cursor);
            r = cursor.moveToNext();
        }
        cursor.close();
        return ret;
    }
    public List<GisBaseReference> GisRegions(String lang)
    {
    	List<GisBaseReference> ret = new ArrayList<GisBaseReference>();
    	String[] args = new String[1];
    	args[0] = lang;
    	Cursor cursor = getReadableDatabase().rawQuery(select_sql_regions, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
            ret.add(GisBaseReference.FromCursor(cursor));
            r = cursor.moveToNext();
        }
        cursor.close();
        //ret.Sort((a, b) => a.name.CompareTo(b.name));
        return ret;
    }
    public List<GisBaseReference> GisRayons(long region, String lang)
    {
    	List<GisBaseReference> ret = new ArrayList<GisBaseReference>();
    	String[] args = new String[2];
    	args[0] = lang;
    	args[1] = String.valueOf(region);
    	Cursor cursor = getReadableDatabase().rawQuery(select_sql_rayons, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
            ret.add(GisBaseReference.FromCursor(cursor));
            r = cursor.moveToNext();
        }
        cursor.close();
        //ret.Sort((a, b) => a.name.CompareTo(b.name));
        return ret;
    }
    public List<GisBaseReference> GisSettlements(long rayon, String lang)
    {
    	List<GisBaseReference> ret = new ArrayList<GisBaseReference>();
    	String[] args = new String[2];
    	args[0] = lang;
    	args[1] = String.valueOf(rayon);
    	Cursor cursor = getReadableDatabase().rawQuery(select_sql_settlements, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
            ret.add(GisBaseReference.FromCursor(cursor));
            r = cursor.moveToNext();
        }
        cursor.close();
        //ret.Sort((a, b) => a.name.CompareTo(b.name));
        return ret;
    }

    public List<HumanCase> HumanCaseSelect(int status)
    {
    	List<HumanCase> ret = new ArrayList<HumanCase>();
    	Cursor cursor = getReadableDatabase().query("HumanCase", null, null, null, null, null, "datCreateDate");
    	Boolean r = cursor.moveToFirst();
    	while(r)
    	{
    		HumanCase hc = HumanCase.FromCursor(cursor); 
    		if (hc != null && (status == 0 || hc.getStatus() == status)) 
    			ret.add(hc);
    		r = cursor.moveToNext();
    	}
    	cursor.close();
        return ret;
    }
        
    public HumanCase HumanCaseInsert(HumanCase hc)
    {
        hc.setId(getWritableDatabase().insert("HumanCase", null, hc.ContentValues()));
        return hc;
    }
    public HumanCase HumanCaseUpdate(HumanCase hc)
    {
    	getWritableDatabase().replace("HumanCase", null, hc.ContentValues());
        return hc;
    }
    public void HumanCaseDelete(HumanCase hc)
    {
    	String[] ids = new String[1]; ids[0] = String.valueOf(hc.getId());
    	getWritableDatabase().delete("HumanCase", "id = ?", ids);
    }

}
