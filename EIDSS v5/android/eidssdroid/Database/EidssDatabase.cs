using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using bv.com.eidss;
using eidssdroid.Model;

namespace eidssdroid.model.Database
{
    public class EidssDatabase : SQLiteOpenHelper
    {
        private static readonly string create_sql_options = @"
CREATE TABLE Options
(
      id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE
    , strServerUrl TEXT NULL
    , strLocalPassword TEXT NULL
    , strLoginOrganization TEXT NULL
    , strLoginUsername TEXT NULL
)";
        private static readonly string create_sql_human_case = @"
CREATE TABLE HumanCase
(
      id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE
    , strLastSynError TEXT NULL
    , intStatus INT NULL
    , datCreateDate DATE NULL

    , uidOfflineCaseID TEXT NULL
    , strCaseID TEXT NULL
    , idfCase BIGINT NULL

    , strLocalIdentifier TEXT NULL
    , idfsTentativeDiagnosis BIGINT NULL
    , datTentativeDiagnosisDate DATE NULL
    , strFamilyName TEXT NULL
    , strFirstName TEXT NULL
    , datDateofBirth DATE NULL
    , intPatientAge INT NULL
    , idfsHumanAgeType BIGINT NULL
    , idfsHumanGender BIGINT NULL
    , idfsRegionCurrentResidence BIGINT NULL
    , idfsRayonCurrentResidence BIGINT NULL
    , idfsSettlementCurrentResidence BIGINT NULL
    , strBuilding TEXT NULL
    , strHouse TEXT NULL
    , strApartment TEXT NULL
    , strStreetName TEXT NULL
    , strPostCode TEXT NULL
    , strHomePhone TEXT NULL
    , datOnSetDate DATE NULL
    , idfsFinalState BIGINT NULL
    , idfsHospitalizationStatus BIGINT NULL
    , datNotificationDate DATE NULL
    , strSentByOffice TEXT NULL
    , strSentByPerson TEXT NULL
)";
        private static readonly string create_sql_references = @"
CREATE TABLE BaseReference
(
      id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE
    , idfsBaseReference BIGINT NULL
    , idfsReferenceType BIGINT NULL
    , intHACode INT NULL
    , strDefault TEXT NULL
)";
        private static readonly string create_sql_gis_references = @"
CREATE TABLE GisBaseReference
(
      id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE
    , idfsBaseReference BIGINT NULL
    , idfsReferenceType BIGINT NULL
    , idfsCountry BIGINT NULL
    , idfsRegion BIGINT NULL
    , idfsRayon BIGINT NULL
    , strDefault TEXT NULL
)";
        private static readonly string create_sql_references_lang = @"
CREATE TABLE BaseReferenceTranslation
(
      id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE
    , idfsBaseReference BIGINT NULL
    , strTranslation TEXT NULL
    , strLanguage TEXT NULL
)";
        private static readonly string create_sql_gis_references_lang = @"
CREATE TABLE GisBaseReferenceTranslation
(
      id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE
    , idfsBaseReference BIGINT NULL
    , strTranslation TEXT NULL
    , strLanguage TEXT NULL
)";
        private static readonly string insert_options_def = @"
INSERT INTO Options
(
    strServerUrl,
    strLocalPassword,
    strLoginOrganization,
    strLoginUsername
)
VALUES
(
    'http://192.168.10.34:8080/',
    '',
    'NCDC&PH',
    'test_admin'
)
";
        private static readonly string select_sql_reference = @"
SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name
FROM BaseReference br
LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?
WHERE br.idfsReferenceType = ?
";
        private static readonly string select_sql_reference_hacodable = @"
SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name
FROM BaseReference br
LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?
WHERE br.idfsReferenceType = ? and br.intHACode & ?
";
        private static readonly string select_sql_country = @"
SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name
FROM GisBaseReference br
LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?
WHERE br.idfsReferenceType = 19000001
";
        private static readonly string select_sql_regions = @"
SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name
FROM GisBaseReference br
LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?
WHERE br.idfsReferenceType = 19000003
";
        private static readonly string select_sql_rayons = @"
SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name
FROM GisBaseReference br
LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?
WHERE br.idfsReferenceType = 19000002 and (br.idfsRegion = ? or br.idfsBaseReference = 0)
";
        private static readonly string select_sql_settlements = @"
SELECT br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name
FROM GisBaseReference br
LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?
WHERE br.idfsReferenceType = 19000004 and (br.idfsRayon = ? or br.idfsBaseReference = 0)
";

        
        private static new readonly string DatabaseName = "eidss.db";
        private static readonly int DatabaseVersion = 1;  
        public EidssDatabase(Context context) : base(context, DatabaseName, null, DatabaseVersion) {}

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(create_sql_options);
            db.ExecSQL(insert_options_def);
            db.ExecSQL(create_sql_references);
            db.ExecSQL(create_sql_references_lang);
            db.ExecSQL(create_sql_gis_references);
            db.ExecSQL(create_sql_gis_references_lang);
            db.ExecSQL(create_sql_human_case);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {   // not required until second version :)
            throw new NotImplementedException();
        }

        public string CurrentLanguage
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower() == "ru")
                    return "ru";
                if (Thread.CurrentThread.CurrentUICulture.Name.ToLower() == "en-au")
                    return "ka";
                if (Thread.CurrentThread.CurrentUICulture.Name.ToLower() == "en-gb")
                    return "ka";
                return "en";
            }
        }


        public Options Options()
        {
            using(var cursor = ReadableDatabase.Query("Options", null, null, null, null, null, null))
            {
                cursor.MoveToFirst();
                var ret = eidssdroid.Model.Options.FromCursor(cursor);
                return ret;
            }
        }
        public Options OptionsUpdate(Options o)
        {
            WritableDatabase.Replace("Options", null, o.ContentValues());
            return o;
        }

        public bool LoadReferences(BaseReferenceRaw[] refs, BaseReferenceTranslationRaw[] refs_trans, 
            GisBaseReferenceRaw[] gis_refs, GisBaseReferenceTranslationRaw[] gis_refs_trans)
        {
            try
            {
                WritableDatabase.BeginTransaction();
                WritableDatabase.Delete("GisBaseReferenceTranslation", null, null);
                WritableDatabase.Delete("GisBaseReference", null, null);
                WritableDatabase.Delete("BaseReferenceTranslation", null, null);
                WritableDatabase.Delete("BaseReference", null, null);

                foreach (BaseReferenceRaw c in refs.GroupBy(c => c.idfsReferenceType).Select(
                            g => new BaseReferenceRaw()
                            {idfsBaseReference = 0, idfsReferenceType = g.Key, intHACode = -1, strDefault = ""}))
                    WritableDatabase.Insert("BaseReference", null, c.ContentValues());
                foreach (BaseReferenceRaw c in refs)
                    WritableDatabase.Insert("BaseReference", null, c.ContentValues());

                /*foreach (BaseReferenceTranslationRaw c in refs_trans.GroupBy(c => c.strLanguage).Select(
                            g => new BaseReferenceTranslationRaw() { idfsBaseReference = 0, strLanguage = g.Key, strTranslation = ""}))
                    WritableDatabase.Insert("BaseReferenceTranslation", null, c.ContentValues());*/
                foreach (BaseReferenceTranslationRaw c in refs_trans)
                    WritableDatabase.Insert("BaseReferenceTranslation", null, c.ContentValues());

                foreach (GisBaseReferenceRaw c in gis_refs.GroupBy(c => c.idfsReferenceType).Select(
                            g => new GisBaseReferenceRaw() { idfsBaseReference = 0, idfsReferenceType = g.Key, strDefault = "" }))
                    WritableDatabase.Insert("GisBaseReference", null, c.ContentValues());
                foreach (GisBaseReferenceRaw c in gis_refs)
                    WritableDatabase.Insert("GisBaseReference", null, c.ContentValues());

                /*foreach (GisBaseReferenceTranslationRaw c in gis_refs_trans.GroupBy(c => c.strLanguage).Select(
                            g => new GisBaseReferenceTranslationRaw() { idfsBaseReference = 0, strLanguage = g.Key, strTranslation = "" }))
                    WritableDatabase.Insert("BaseReferenceTranslation", null, c.ContentValues());*/
                foreach (GisBaseReferenceTranslationRaw c in gis_refs_trans)
                    WritableDatabase.Insert("GisBaseReferenceTranslation", null, c.ContentValues());

                WritableDatabase.SetTransactionSuccessful();
                WritableDatabase.EndTransaction();
                return true;
            }
            catch (Exception/* ex */)
            {
                WritableDatabase.EndTransaction();
                return false;
            }
        }

        public List<BaseReference> Reference(long type, string lang, int hacode)
        {
            var ret = new List<BaseReference>();
            using (var cursor = ReadableDatabase.RawQuery(
                hacode == 0 ? select_sql_reference : select_sql_reference_hacodable,
                hacode == 0 ? new[] { lang, type.ToString() } : new[] { lang, type.ToString(), hacode.ToString() }))
            {
                var r = cursor.MoveToFirst();
                while (r)
                {
                    ret.Add(BaseReference.FromCursor(cursor));
                    r = cursor.MoveToNext();
                }
                ret.Sort((a, b) => a.name.CompareTo(b.name));
                return ret;
            }
        }
        public GisBaseReference GisCountry(string lang)
        {
            GisBaseReference ret = null;
            using (var cursor = ReadableDatabase.RawQuery(select_sql_country, new[] { lang }))
            {
                var r = cursor.MoveToFirst();
                while (r)
                {
                    ret = GisBaseReference.FromCursor(cursor);
                    r = cursor.MoveToNext();
                }
            }
            return ret;
        }
        public List<GisBaseReference> GisRegions(string lang)
        {
            var ret = new List<GisBaseReference>();
            using (var cursor = ReadableDatabase.RawQuery(select_sql_regions, new[] { lang }))
            {
                var r = cursor.MoveToFirst();
                while (r)
                {
                    ret.Add(GisBaseReference.FromCursor(cursor));
                    r = cursor.MoveToNext();
                }
                ret.Sort((a, b) => a.name.CompareTo(b.name));
                return ret;
            }
        }
        public List<GisBaseReference> GisRayons(long region, string lang)
        {
            var ret = new List<GisBaseReference>();
            using (var cursor = ReadableDatabase.RawQuery(select_sql_rayons, new[] { lang, region.ToString() }))
            {
                var r = cursor.MoveToFirst();
                while (r)
                {
                    ret.Add(GisBaseReference.FromCursor(cursor));
                    r = cursor.MoveToNext();
                }
                ret.Sort((a, b) => a.name.CompareTo(b.name));
                return ret;
            }
        }
        public List<GisBaseReference> GisSettlements(long rayon, string lang)
        {
            var ret = new List<GisBaseReference>();
            using (var cursor = ReadableDatabase.RawQuery(select_sql_settlements, new[] { lang, rayon.ToString() }))
            {
                var r = cursor.MoveToFirst();
                while (r)
                {
                    ret.Add(GisBaseReference.FromCursor(cursor));
                    r = cursor.MoveToNext();
                }
                ret.Sort((a, b) => a.name.CompareTo(b.name));
                return ret;
            }
        }


        public List<HumanCase> HumanCaseSelect()
        {
            var ret = new List<HumanCase>();
            using (var cursor = ReadableDatabase.Query("HumanCase", null, null, null, null, null, null))
            {
                var r = cursor.MoveToFirst();
                while (r)
                {
                    ret.Add(HumanCase.FromCursor(cursor));
                    r = cursor.MoveToNext();
                }
                ret.Sort((a, b) => b.datCreateDate.CompareTo(a.datCreateDate));
                return ret;
            }
        }
        public HumanCase HumanCaseInsert(HumanCase hc)
        {
            hc.id = WritableDatabase.Insert("HumanCase", null, hc.ContentValues());
            return hc;
        }
        public HumanCase HumanCaseUpdate(HumanCase hc)
        {
            WritableDatabase.Replace("HumanCase", null, hc.ContentValues());
            return hc;
        }
        public void HumanCaseDelete(HumanCase hc)
        {
            WritableDatabase.Delete("HumanCase", "id = ?", new [] {hc.id.ToString()});
        }
    }

}

