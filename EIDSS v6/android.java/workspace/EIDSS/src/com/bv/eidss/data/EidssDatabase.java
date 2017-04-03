package com.bv.eidss.data;

import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.Options;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.database.sqlite.SQLiteStatement;


import com.bv.eidss.web.VectorBaseReferenceRaw;
import com.bv.eidss.web.VectorBaseReferenceTranslationRaw;
import com.bv.eidss.web.VectorGisBaseReferenceRaw;
import com.bv.eidss.web.VectorGisBaseReferenceTranslationRaw;


public class EidssDatabase extends SQLiteOpenHelper {

    private static final String create_sql_options = 
"CREATE TABLE Options\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strServerUrl TEXT NULL\n" +
", strServerUrlDef TEXT NULL\n" +
", strLocalPassword TEXT NULL\n" +
", strLoginOrganization TEXT NULL\n" +
", strLoginOrganizationDef TEXT NULL\n" +
", strLoginUsername TEXT NULL\n" +
", strLoginUsernameDef TEXT NULL\n" +
", strEidssVersion TEXT NULL\n" +
", datLastOnlineSyn DATE NULL\n" +
", datLastRefUpdt DATE NULL\n" +
", intApplicationMode INT NULL\n" +
", intApplicationModeDef INT NULL\n" +
", intPageSize INT NULL\n" +
", intPageSizeDef INT NULL\n" +
", intLockTimeout INT NULL\n" +
", intLockTimeoutDef INT NULL\n" +
", intResponseTimeout INT NULL\n" +
", intResponseTimeoutDef INT NULL\n" +
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
    private static final String create_sql_vet_case =
"CREATE TABLE VetCase\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" +
", uidOfflineCaseID TEXT NULL\n" +
", strCaseID TEXT NULL\n" +
", idfCase BIGINT NULL\n" +
", idfCaseType BIGINT NULL\n" +
", idfCaseReportType BIGINT NULL\n" +
"\n" +
", strLocalIdentifier TEXT NULL\n" +
", idfsTentativeDiagnosis BIGINT NULL\n" +
", datTentativeDiagnosisDate DATE NULL\n" +
", strFarmCode TEXT NULL\n" +
", strFarmName TEXT NULL\n" +
", strOwnerLastName TEXT NULL\n" +
", strOwnerFirstName TEXT NULL\n" +
", strOwnerMiddleName TEXT NULL\n" +
", idfsRegion BIGINT NULL\n" +
", idfsRayon BIGINT NULL\n" +
", idfsSettlement BIGINT NULL\n" +
", strBuilding TEXT NULL\n" +
", strHouse TEXT NULL\n" +
", strApartment TEXT NULL\n" +
", strStreetName TEXT NULL\n" +
", strPostCode TEXT NULL\n" +
", strPhone TEXT NULL\n" +
", dblLongitude FLOAT( 10, 6 ) NULL\n" +
", dblLatitude FLOAT( 10, 6 ) NULL\n" +
", datEnteredDate DATE NULL\n" +
", strSentByOffice TEXT NULL\n" +
", strSentByPerson TEXT NULL\n" +
")";
    private static final String create_sql_species = 
"CREATE TABLE Species\n" +
"(\n" +
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", idVetCase INT NOT NULL\n" +
", idfsHerd BIGINT NULL\n" +
", idfsSpeciesType BIGINT NULL\n" +
", datStartOfSignsDate DATE NULL\n" +
", intTotalAnimalQty INT NULL\n" +
", intDeadAnimalQty INT NULL\n" +
", intSickAnimalQty INT NULL\n" +
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
"INSERT INTO Options\n" +
"(\n" +
"strServerUrl,\n" +
"strServerUrlDef,\n" +
"strLocalPassword,\n" +
"strLoginOrganization,\n" +
"strLoginOrganizationDef,\n" +
"strLoginUsername,\n" +
"strLoginUsernameDef,\n" +
"strEidssVersion,\n" +
"datLastOnlineSyn,\n" +
"datLastRefUpdt,\n" +
"intApplicationMode,\n" +
"intApplicationModeDef,\n" +
"intPageSize,\n" +
"intPageSizeDef,\n" +
"intLockTimeout,\n" +
"intLockTimeoutDef,\n" +
"intResponseTimeout,\n" +
"intResponseTimeoutDef\n" +
")\n" +
"VALUES\n" +
"(\n" +
"'%s',\n" +
"'%s',\n" +
"'',\n" +
"'%s',\n" +
"'%s',\n" +
"'%s',\n" +
"'%s',\n" +
"'%s',\n" +
"'',\n" +
"'',\n" +
"%d,\n" +
"%d,\n" +
"%d,\n" +
"%d,\n" +
"%d,\n" +
"%d,\n" +
"%d,\n" +
"%d\n" +
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
"WHERE br.idfsReferenceType = ? and br.intHACode & ?<>0\n" +
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
    private static final String select_sql_vetcase = 
"SELECT v.*, \n" +
"ifnull(tyt.strTranslation, ty.strDefault) as strCaseType,\n" +
"ifnull(ret.strTranslation, re.strDefault) as strRegion,\n" +
"ifnull(rat.strTranslation, ra.strDefault) as strRayon,\n" +
"ifnull(stt.strTranslation, st.strDefault) as strSettlement,\n" +
"ifnull(dit.strTranslation, di.strDefault) as strTentativeDiagnosis " +
"FROM VetCase v\n" +
"INNER JOIN BaseReference ty on ty.idfsBaseReference = v.idfCaseType\n" +
"INNER JOIN BaseReference di on di.idfsBaseReference = v.idfsTentativeDiagnosis\n" +
"INNER JOIN GisBaseReference re on re.idfsBaseReference = v.idfsRegion and re.idfsReferenceType = 19000003\n" +
"INNER JOIN GisBaseReference ra on ra.idfsBaseReference = v.idfsRayon and ra.idfsReferenceType = 19000002\n" +
"LEFT OUTER JOIN GisBaseReference st on st.idfsBaseReference = v.idfsSettlement and st.idfsReferenceType = 19000004\n" +
"LEFT OUTER JOIN BaseReferenceTranslation tyt on tyt.idfsBaseReference = ty.idfsBaseReference and tyt.strLanguage = ?\n" +
"LEFT OUTER JOIN BaseReferenceTranslation dit on dit.idfsBaseReference = di.idfsBaseReference and dit.strLanguage = ?\n" +
"LEFT OUTER JOIN GisBaseReferenceTranslation ret on ret.idfsBaseReference = re.idfsBaseReference and ret.strLanguage = ?\n" +
"LEFT OUTER JOIN GisBaseReferenceTranslation rat on rat.idfsBaseReference = ra.idfsBaseReference and rat.strLanguage = ?\n" +
"LEFT OUTER JOIN GisBaseReferenceTranslation stt on stt.idfsBaseReference = st.idfsBaseReference and stt.strLanguage = ?\n" +
"ORDER BY datCreateDate";
    private static final String select_sql_species = 
"SELECT * " +
"FROM Species " +
"WHERE idVetCase = ? " +
"ORDER BY id";
	
    private final static String DatabaseName = "eidss.db";
    private final static int DatabaseVersion = 1;
    
    private String defServerUrl = "";
    private String defLoginOrganization = "";
    private String defLoginUser = "";
    private String defEidssVersion = "1.0";
    private int defApplicationMode = 3;
    private int defPageSize = 30;
    private int defLockTimeout = 15;
    private int defResponseTimeout = 1;
    
    public EidssDatabase(Context context, String defServerUrl, String defLoginOrganization, String defLoginUser) {
    	super(context, DatabaseName, null, DatabaseVersion);
    	this.defServerUrl = defServerUrl;
    	this.defLoginOrganization = defLoginOrganization;
    	this.defLoginUser= defLoginUser; 
    }

    public EidssDatabase(Context context) {
    	super(context, DatabaseName, null, DatabaseVersion);
    }
	
	@Override
	public void onCreate(SQLiteDatabase db) {
        db.execSQL(create_sql_options);
        db.execSQL(String.format(insert_options_def, defServerUrl, defServerUrl, defLoginOrganization, defLoginOrganization, defLoginUser, defLoginUser,
        		defEidssVersion, defApplicationMode, defApplicationMode, defPageSize, defPageSize,
        		defLockTimeout, defLockTimeout, defResponseTimeout, defResponseTimeout));
        db.execSQL(create_sql_references);
        db.execSQL(create_sql_references_lang);
        db.execSQL(create_sql_gis_references);
        db.execSQL(create_sql_gis_references_lang);
        db.execSQL(create_sql_human_case);
        db.execSQL(create_sql_vet_case);
        db.execSQL(create_sql_species);
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
    	SQLiteDatabase db = getReadableDatabase();
    	Cursor cursor = db.query("Options", null, null, null, null, null, null);
        cursor.moveToFirst();
        Options ret = Options.FromCursor(cursor);
    	db.close();
        return ret;
    }
    public Options OptionsUpdate(Options o)
    {
    	SQLiteDatabase db = getWritableDatabase();
        db.replace("Options", null, o.ContentValues());
    	db.close();
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
	    	db.close();
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
     	SQLiteDatabase db = getReadableDatabase();
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
    	Cursor cursor = db.rawQuery(sql, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
            ret.add(BaseReference.FromCursor(cursor));
            r = cursor.moveToNext();
        }
        cursor.close();
        //ret.Sort((a, b) => a.name.CompareTo(b.name));
    	db.close();
        return ret;
    }
    
    public GisBaseReference GisCountry(String lang)
    {
        GisBaseReference ret = null;
    	SQLiteDatabase db = getReadableDatabase();
    	String[] args = new String[1];
    	args[0] = lang;
    	Cursor cursor = db.rawQuery(select_sql_country, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
        	ret = GisBaseReference.FromCursor(cursor);
            r = cursor.moveToNext();
        }
        cursor.close();
    	db.close();
        return ret;
    }
    public List<GisBaseReference> GisRegions(String lang)
    {
    	List<GisBaseReference> ret = new ArrayList<GisBaseReference>();
    	SQLiteDatabase db = getReadableDatabase();
    	String[] args = new String[1];
    	args[0] = lang;
    	Cursor cursor = db.rawQuery(select_sql_regions, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
            ret.add(GisBaseReference.FromCursor(cursor));
            r = cursor.moveToNext();
        }
        cursor.close();
        //ret.Sort((a, b) => a.name.CompareTo(b.name));
    	db.close();
        return ret;
    }
    public List<GisBaseReference> GisRayons(long region, String lang)
    {
    	List<GisBaseReference> ret = new ArrayList<GisBaseReference>();
    	SQLiteDatabase db = getReadableDatabase();
    	String[] args = new String[2];
    	args[0] = lang;
    	args[1] = String.valueOf(region);
    	Cursor cursor = db.rawQuery(select_sql_rayons, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
            ret.add(GisBaseReference.FromCursor(cursor));
            r = cursor.moveToNext();
        }
        cursor.close();
        //ret.Sort((a, b) => a.name.CompareTo(b.name));
    	db.close();
    	return ret;
    }
    public List<GisBaseReference> GisSettlements(long rayon, String lang)
    {
    	List<GisBaseReference> ret = new ArrayList<GisBaseReference>();
    	SQLiteDatabase db = getReadableDatabase();
    	String[] args = new String[2];
    	args[0] = lang;
    	args[1] = String.valueOf(rayon);
    	Cursor cursor = db.rawQuery(select_sql_settlements, args);
        Boolean r = cursor.moveToFirst();
        while (r)
        {
            ret.add(GisBaseReference.FromCursor(cursor));
            r = cursor.moveToNext();
        }
        cursor.close();
        //ret.Sort((a, b) => a.name.CompareTo(b.name));
    	db.close();
        return ret;
    }
    
    public long HumanCaseCount(int status)
    {
    	SQLiteStatement s;
    	SQLiteDatabase db = getReadableDatabase();
    	if(status == 0)
    		s = db.compileStatement("select count(*) from HumanCase;");
    	else
    		s = db.compileStatement("select count(*) from HumanCase where intStatus="+Integer.toString(status));

    	long ret = s.simpleQueryForLong();
    	db.close();
    	return ret;
    }

    public long VetCaseCount(int status)
    {
    	SQLiteStatement s;
    	SQLiteDatabase db = getReadableDatabase();
    	if(status == 0)
    		s = db.compileStatement("select count(*) from VetCase;");
    	else
    		s = db.compileStatement("select count(*) from VetCase where intStatus="+Integer.toString(status));

    	long ret = s.simpleQueryForLong();
    	db.close();
    	return ret;
    }
    
    public long HumanCaseSynchCount()
    {
    	SQLiteStatement s;
    	SQLiteDatabase db = getReadableDatabase();
   		s = db.compileStatement("select count(*) from HumanCase where ifnull(idfCase,0)<>0");

    	long ret = s.simpleQueryForLong();
    	db.close();
    	return ret;
    }
    
    public long VetCaseSynchCount()
    {
    	SQLiteStatement s;
    	SQLiteDatabase db = getReadableDatabase();
   		s = db.compileStatement("select count(*) from VetCase where ifnull(idfCase,0)<>0");

    	long ret = s.simpleQueryForLong();
    	db.close();
    	return ret;
    }
    
    public List<HumanCase> HumanCaseSelect(int status, long id)
    {
    	List<HumanCase> ret = new ArrayList<HumanCase>();
    	SQLiteDatabase db = getReadableDatabase();
    	Cursor cursor = db.query("HumanCase", null, null, null, null, null, "datCreateDate");
    	Boolean r = cursor.moveToLast();
    	while(r)
    	{
    		HumanCase hc = HumanCase.FromCursor(cursor); 
    		if (hc != null && (status == 0 || hc.getStatus() == status) && (id == 0 || hc.getId() == id)) 
    			ret.add(hc);
    		r = cursor.moveToPrevious();
    	}
    	cursor.close();
        db.close();
        return ret;
    }
    
    public List<VetCase> VetCaseSelect(int status)
    {
    	List<VetCase> ret = new ArrayList<VetCase>();
    	
    	SQLiteDatabase db = getReadableDatabase();
    	String[] args = new String[5];
    	args[0] = getCurrentLanguage();
    	args[1] = args[0];
    	args[2] = args[0];
    	args[3] = args[0];
    	args[4] = args[0];
    	Cursor cursor = db.rawQuery(select_sql_vetcase + "", args);
    	Boolean r = cursor.moveToFirst();
    	while(r)
    	{
    		VetCase vc = VetCase.FromCursor(cursor);
    		if (vc != null && (status == 0 || vc.getStatus() == status)) 
    		{
    			ret.add(vc);
    		}
    		r = cursor.moveToNext();
    	}
    	cursor.close();
    	db.close();
        return ret;
    }

	public List<VetCase> VetCaseSelect(long id)
	{
		List<VetCase> ret = new ArrayList<VetCase>();
		
    	SQLiteDatabase db = getReadableDatabase();
    	Cursor cursor = db.query("VetCase", null, null, null, null, null, "datCreateDate");
		Boolean r = cursor.moveToFirst();
		while(r)
		{
			VetCase vc = VetCase.FromCursor(cursor); 
			if (vc != null && (id == 0 || vc.getId() == id))
			{
				ret.add(vc);
			}
			r = cursor.moveToNext();
		}
		cursor.close();
		
		if(ret.size() > 0)
		{
	    	if(id == 0)
	    		cursor = db.query("Species", null, null, null, null, null, "id");
	    	else
	    		cursor = db.rawQuery( select_sql_species, new String [] {String.valueOf(id)} );
			Boolean rSp = cursor.moveToFirst();
			while(rSp)
			{
				Species sp = Species.FromCursor(cursor); 
				if (sp != null) 
				{
					for(VetCase vc : ret)
					{
						if(sp.getIdVetCase() == vc.getId()){
							vc.species.add(sp);
							break;
						}
					}
				}
				rSp = cursor.moveToNext();
			}
			cursor.close();
		}
        db.close();
	    return ret;
	}
	        
	public HumanCase HumanCaseInsert(HumanCase hc)
	{
    	SQLiteDatabase db = getWritableDatabase();
	    hc.setId(db.insert("HumanCase", null, hc.ContentValues()));
        db.close();
	    return hc;
	}
	public VetCase VetCaseInsert(VetCase vc)
	{
    	try{
	    	SQLiteDatabase db = getWritableDatabase();
	    	db.beginTransaction();
	    	
		    vc.setId(db.insert("VetCase", null, vc.ContentValues()));
		    for (Species sp: vc.species){
		    	sp.setIdVetCase(vc.getId());
		    	sp.setId(db.insert("Species", null, sp.ContentValues()));
		    }
	    	
	        db.setTransactionSuccessful();
	        db.endTransaction();
	        db.close();
	        return vc;
		}
		catch(Exception e){
	        e.printStackTrace();
			return null;
		}
	}
    
    public HumanCase HumanCaseUpdate(HumanCase hc)
    {
    	SQLiteDatabase db = getWritableDatabase();
    	db.replace("HumanCase", null, hc.ContentValues());
        db.close();
        hc.setUnchanged();
        return hc;
    }
    public void VetCaseUpdate(VetCase vc)
    {
    	SQLiteDatabase db = getWritableDatabase();
    	try{
	    	db.beginTransaction();
	    	
			db.update("VetCase", vc.ContentValues(), "id=?", new String[] {String.valueOf(vc.getId())});
	    	
	    	for (Species sp:vc.species) {
		    	if(sp.getId() == 0)
			    	sp.setId(db.insert("Species", null, sp.ContentValues()));
		    	else if(sp.getChanged())
			    	db.update("Species", sp.ContentValues(), "id=?", new String[] {String.valueOf(sp.getId())});
	    	}
			
	    	// delete everything that is not in vc.species
	    	SQLiteStatement s;
	   		s = db.compileStatement("select count(*) from Species where idVetCase=" + String.valueOf(vc.getId()));
	    	long nSp = s.simpleQueryForLong();
	    	
	    	if(nSp > vc.species.size())	{
		    	String ids = "";
		    	for (Species sp:vc.species) {
			    	if(sp.getId() != 0) {
				    	if(ids.length() != 0) ids += ", ";
				    	ids += Long.toString(sp.getId());
			    	}
		    	}
		    	if(ids.length() != 0)
		    		db.delete("Species", "idVetCase= "+String.valueOf(vc.getId())+" AND id NOT IN ("+ids+")", null);
	    	}
	    	
	        db.setTransactionSuccessful();
	        vc.setUnchanged();
		}
		catch(Exception e){
	        e.printStackTrace();
		}
    	finally {
            db.endTransaction();
	        db.close();
    	}
    }
    
    public void HumanCaseDelete(HumanCase hc)
    {
    	String[] ids = new String[]{ String.valueOf(hc.getId()) };
    	SQLiteDatabase db = getWritableDatabase();
    	db.delete("HumanCase", "id = ?", ids);
        db.close();
    }
    public Boolean VetCaseDelete(VetCase vc)
    {
    	SQLiteDatabase db = getWritableDatabase();
    	try{
	    	db.beginTransaction();
	    	
	    	String[] ids = new String[]{ Long.toString(vc.getId()) };
	    	db.delete("Species", "idVetCase in (SELECT id FROM VetCase where id = ?)", ids);
	    	db.delete("VetCase", "id = ?", ids);
	    	
	        db.setTransactionSuccessful();
		}
		catch(Exception e){
	        e.printStackTrace();
			return false;
		}
    	finally {
            db.endTransaction();
	        db.close();
    	}
        return true;
    }

    public Boolean SinchronizedCasesDelete()
    {
    	try{
	    	SQLiteDatabase db = getWritableDatabase();
	    	db.beginTransaction();
	    	
	    	String[] ids = new String[]{ Integer.toString(CaseStatus.SYNCHRONIZED) };
	    	db.delete("HumanCase", "intStatus = ?", ids);
	    	db.delete("Species", "idVetCase in (SELECT id FROM VetCase where intStatus = ?)", ids);
	    	db.delete("VetCase", "intStatus = ?", ids);
	    	
	        db.setTransactionSuccessful();
	        db.endTransaction();
	        db.close();
	        return true;
		}
		catch(Exception e){
	        e.printStackTrace();
			return false;
		}
    }
}
