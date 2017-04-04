package com.bv.eidss.data;

import com.bv.eidss.data.generated.ASDisease_database;
import com.bv.eidss.data.generated.ASSample_database;
import com.bv.eidss.data.generated.ASSession_database;
import com.bv.eidss.data.generated.Animal_database;
import com.bv.eidss.data.generated.Farm_database;
import com.bv.eidss.data.generated.HumanCaseSample_database;
import com.bv.eidss.data.generated.HumanCase_database;
import com.bv.eidss.data.generated.VetCaseSample_database;
import com.bv.eidss.data.generated.VetCase_database;
import com.bv.eidss.data.generated.Species_database;
import com.bv.eidss.model.ASCampaign;
import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.ActivityParameter;
import com.bv.eidss.model.Animal;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.FFModel;
import com.bv.eidss.model.FFReferences;
import com.bv.eidss.model.FFTemplateElement;
import com.bv.eidss.model.Farm;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.GisBaseReferenceType;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.HumanCaseSample;
import com.bv.eidss.model.InvisibleFields;
import com.bv.eidss.model.MandatoryFields;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.Options;

import java.text.Format;
import java.util.ArrayList;
import java.util.List;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.database.sqlite.SQLiteStatement;
import android.support.v4.util.SimpleArrayMap;


import com.bv.eidss.model.VetCaseSample;
import com.bv.eidss.model.generated.ASSession_object;
import com.bv.eidss.model.generated.Farm_object;
import com.bv.eidss.model.interfaces.ISpeciesParent;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.web.BaseReferenceRaw;
import com.bv.eidss.web.BaseReferenceTranslationRaw;
import com.bv.eidss.web.GisBaseReferenceRaw;
import com.bv.eidss.web.GisBaseReferenceTranslationRaw;
import com.bv.eidss.web.InvisibleFieldsRaw;
import com.bv.eidss.web.MandatoryFieldsRaw;


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
                    ", strDefLang TEXT NULL\n" +
                    ", datLastOnlineSyn DATE NULL\n" +
                    ", datLastRefUpdt DATE NULL\n" +
                    ", datLastListUpdt DATE NULL\n" +
                    ", intApplicationMode INT NULL\n" +
                    ", intApplicationModeDef INT NULL\n" +
                    ", intPageSize INT NULL\n" +
                    ", intPageSizeDef INT NULL\n" +
                    ", intLockTimeout INT NULL\n" +
                    ", intLockTimeoutDef INT NULL\n" +
                    ", intResponseTimeout INT NULL\n" +
                    ", intResponseTimeoutDef INT NULL\n" +
                    ", idfsRegionDef BIGINT NULL\n" +
                    ", idfsRegionDefDef BIGINT NULL\n" +
                    ", idfsRayonDef BIGINT NULL\n" +
                    ", idfsRayonDefDef BIGINT NULL\n" +
                    ", blnFltrByDgn INT NULL\n" +
                    ")";
    private static final String create_sql_mandatory_fields =
            "CREATE TABLE MandatoryFields\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfMandatoryField BIGINT NULL\n" +
                    ", strFieldAlias TEXT NULL\n" +
                    ")";
    private static final String create_sql_invisible_fields =
            "CREATE TABLE InvisibleFields\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfInvisibleField BIGINT NULL\n" +
                    ", strFieldAlias TEXT NULL\n" +
                    ")";

    private static final String create_sql_references =
            "CREATE TABLE BaseReference\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfsBaseReference BIGINT NULL\n" +
                    ", idfsReferenceType BIGINT NULL\n" +
                    ", intHACode INT NULL\n" +
                    ", strDefault TEXT NULL\n" +
                    ", intRowStatus INT NULL\n" +
                    ", intOrder INT NULL\n" +
                    ", intFeature1 INT NULL\n" +
                    ", intFeature2 INT NULL\n" +
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
                    ", intRowStatus INT NULL\n" +
                    ", intOrder INT NULL\n" +
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
    private static final String create_sql_ff_activity_parameters =
            "CREATE TABLE FFActivityParameter\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfObservation BIGINT NULL\n" +
                    ", idfsParameter BIGINT NULL\n" +
                    ", idfRow BIGINT NULL\n" +
                    ", strValue TEXT NULL\n" +
                    ")";
    private static final String create_sql_ff_template =
            "CREATE TABLE FFTemplate\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfsBaseReference BIGINT NULL\n" +
                    ", idfsFormTemplate BIGINT NULL\n" +
                    ", idfsBaseReferenceParent BIGINT NULL\n" +
                    ", intElementType INTEGER NULL\n" +
                    ", idfsEditor BIGINT NULL\n" +
                    ", intReadOnly INT NULL\n" +
                    ", intMandatory INT NULL\n" +
                    ", idfsParameterType BIGINT NULL\n" +
                    ", intOrder INT NULL\n" +
                    ", idfsParameterCaption BIGINT NULL\n" +
                    ")";
    private static final String create_sql_ff_determinant =
            "CREATE TABLE FFDeterminant\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfDeterminantValue BIGINT NULL\n" +
                    ", idfsFormType BIGINT NULL\n" +
                    ", idfsFormTemplate BIGINT NULL\n" +
                    ")";
    private static final String create_sql_ff_rule =
            "CREATE TABLE FFRule\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfsRule BIGINT NULL\n" +
                    ", idfsFormTemplate BIGINT NULL\n" +
                    ", idfsCheckPoint BIGINT NULL\n" +
                    ", idfsRuleMessage BIGINT NULL\n" +
                    ", idfsRuleFunction BIGINT NULL\n" +
                    ", intNot INT NULL\n" +
                    ")";
    private static final String create_sql_ff_rule_constant =
            "CREATE TABLE FFRuleConstant\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfsRule BIGINT NULL\n" +
                    ", strConstant TEXT NULL\n" +
                    ")";
    private static final String create_sql_ff_parameter_for_function =
            "CREATE TABLE FFParameterForFunction\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfsParameter BIGINT NULL\n" +
                    ", idfsRule BIGINT NULL\n" +
                    ", intOrder INT NULL\n" +
                    ")";
    private static final String create_sql_ff_parameter_for_action =
            "CREATE TABLE FFParameterForAction\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfsParameter BIGINT NULL\n" +
                    ", idfsRule BIGINT NULL\n" +
                    ", idfsRuleAction BIGINT NULL\n" +
                    ")";
    private static final String create_sql_ff_parameter_fixed_preset_value =
            "CREATE TABLE FFParameterFixedPresetValue\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfsParameterFixedPresetValue BIGINT NULL\n" +
                    ", idfsParameterType BIGINT NULL\n" +
                    ")";
    private static final String create_sql_observation =
            "CREATE TABLE Observation\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", idfObservation BIGINT NULL\n" +
                    ", idfsFormTemplate BIGINT NULL\n" +
                    ")";

    private static final String create_sql_as_campaign =
            "CREATE TABLE ASCampaign\n" +
                    "(\n" +
                    "  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
                    ", intRowStatus INT NULL\n" +
                    ", idfCampaign BIGINT NULL\n" +
                    ", strCampaignName TEXT NULL\n" +
                    ", idfsCampaignType BIGINT NULL\n" +
                    ", datCampaignDateStart DATE NULL\n" +
                    ", datCampaignDateEnd DATE NULL\n" +
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
                    "strDefLang,\n" +
                    "datLastOnlineSyn,\n" +
                    "datLastRefUpdt,\n" +
                    "datLastListUpdt,\n" +
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

    public static final String insert_sql_as_campaign =
            "insert into ASCampaign(intRowStatus,idfCampaign,strCampaignName,idfsCampaignType,datCampaignDateStart,datCampaignDateEnd) values (?, ?, ?, ?, ?, ?)";
    public static final String update_sql_as_campaign =
            "update ASCampaign set intRowStatus=?,strCampaignName=?,idfsCampaignType=?,datCampaignDateStart=?,datCampaignDateEnd=? where idfCampaign=?";
    public static final String insert_sql_as_disease =
            "insert into ASDisease(idfCampaign,idfsDiagnosis,idfsSpeciesType,idfsSampleType) values (?, ?, ?, ?)";
    public static final String delete_sql_as_disease =
            "delete from ASDisease where idfCampaign = ?";

    private static final String select_sql_mandatory_fields =
            "SELECT idfMandatoryField, strFieldAlias\n" +
                    "FROM MandatoryFields";
    public static final String insert_sql_mandatory_fields =
        "insert into MandatoryFields(idfMandatoryField,strFieldAlias) values (?, ?)";
    private static final String select_sql_invisible_fields =
            "SELECT idfInvisibleField, strFieldAlias\n" +
                    "FROM InvisibleFields";
    public static final String insert_sql_invisible_fields =
            "insert into InvisibleFields(idfInvisibleField,strFieldAlias) values (?, ?)";
    public static final String select_sql_references =
            "SELECT br.idfsBaseReference as _id, br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM BaseReference br\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = ?\n" +
                    "and (br.intRowStatus = 0 or br.idfsBaseReference = ?)" +
                    "ORDER BY br.intOrder, name";
    public static final String select_sql_references_hacodable =
            "SELECT br.idfsBaseReference as _id, br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM BaseReference br\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = ? and br.intHACode & ?<>0\n" +
                    "and (br.intRowStatus = 0 or br.idfsBaseReference = ?)\n" +
                    "ORDER BY br.intOrder, name";
    public static final String select_sql_references_hacodable_f1 =
        "SELECT distinct br.idfsBaseReference as _id, br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
            "FROM BaseReference br\n" +
            "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
            "WHERE br.idfsReferenceType = ? and (ifnull(br.intHACode,0) =0 or br.intHACode & ?<>0)\n" +
            "and ((br.intRowStatus = 0\n" +
            "and br.intFeature1 = ?\n" +
            ") or br.idfsBaseReference = ?)\n" +
            "ORDER BY br.intOrder, name";
    public static final String select_sql_references_hacodable_f1_f2 =
        "SELECT distinct br.idfsBaseReference as _id, br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
            "FROM BaseReference br\n" +
            "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
            "WHERE br.idfsReferenceType = ? and (ifnull(br.intHACode,0) =0 or br.intHACode & ?<>0)\n" +
            "and ((br.intRowStatus = 0 \n" +
            "and br.intFeature1 = ?\n" +
            "and br.intFeature2 = ?\n" +
            ") or br.idfsBaseReference = ?)\n" +
            "ORDER BY br.intOrder, name";
    public static final String insert_sql_references =
            "insert into BaseReference(idfsBaseReference,idfsReferenceType,intHACode,strDefault,intRowStatus,intOrder) values (?, ?, ?, ?, ?, ?)";
    public static final String insert_sql_references_wf =
            "insert into BaseReference(idfsBaseReference,idfsReferenceType,intHACode,strDefault,intRowStatus,intOrder,intFeature1,intFeature2) values (?, ?, ?, ?, ?, ?, ?, ?)";
    public static final String insert_sql_references_trans =
            "insert into BaseReferenceTranslation(idfsBaseReference,strTranslation,strLanguage) values (?, ?, ?)";
    public static final String insert_sql_gisreferences =
            "insert into GisBaseReference(idfsBaseReference,idfsReferenceType,idfsCountry,idfsRegion,idfsRayon,strDefault,intRowStatus,intOrder) values (?, ?, ?, ?, ?, ?, ?, ?)";
    public static final String insert_sql_gisreferences_trans =
            "insert into GisBaseReferenceTranslation(idfsBaseReference,strTranslation,strLanguage) values (?, ?, ?)";
    public static final String select_sql_reference =
            "SELECT br.idfsBaseReference as _id, br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM BaseReference br\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsBaseReference = ?";
    public static final String select_sql_references_ff =
            "SELECT br.idfsBaseReference as _id, br.idfsBaseReference as idfsBaseReference, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM BaseReference br\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType in (" +
                    BaseReferenceType.rftParameter + "," +
                    BaseReferenceType.rftParameterTooltip + "," +
                    BaseReferenceType.rftSection + "," +
                    BaseReferenceType.rftFFParameterType + "," +
                    BaseReferenceType.rftFlexibleFormLabelText + ")\n" +
                    "and br.intRowStatus = 0\n" +
                    "ORDER BY br.idfsReferenceType";
    private static final String select_sql_country =
            "SELECT br.idfsBaseReference as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM GisBaseReference br\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = 19000001\n" +
                    "ORDER BY br.intOrder, name";
    public static final String select_sql_regions =
            "SELECT br.idfsBaseReference as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM GisBaseReference br\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = 19000003\n" +
                    "and (br.intRowStatus = 0 or br.idfsBaseReference = ?)" +
                    "ORDER BY br.intOrder, name";
    public static final String select_sql_region =
            "SELECT br.idfsBaseReference as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM GisBaseReference br\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = 19000003\n" +
                    "and br.idfsBaseReference = ?";

    public static final String select_sql_rayons =
            "SELECT br.idfsBaseReference as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM GisBaseReference br\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = 19000002 and (br.idfsRegion = ? or br.idfsBaseReference = 0)\n" +
                    "and (br.intRowStatus = 0 or br.idfsBaseReference = ?)" +
                    "ORDER BY br.intOrder, name";
    public static final String select_sql_rayon =
            "SELECT br.idfsBaseReference as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM GisBaseReference br\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = 19000002\n" +
                    "and br.idfsBaseReference = ?";

    public static final String select_sql_settlements =
            "SELECT br.idfsBaseReference as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM GisBaseReference br\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = 19000004 and (br.idfsRayon = ? or br.idfsBaseReference = 0)\n" +
                    "and (br.intRowStatus = 0 or br.idfsBaseReference = ?)" +
                    "ORDER BY br.intOrder, name";
    public static final String select_sql_settlement =
            "SELECT br.idfsBaseReference as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM GisBaseReference br\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE br.idfsReferenceType = 19000004\n" +
                    "and br.idfsBaseReference = ?";

    public static final String select_sql_campaign =
            "SELECT idfCampaign as _id, ifnull(strCampaignName,'') || ifnull(' (' || strftime('%Y-%m-%d', datCampaignDateStart) || ')', '') as name, ifnull(idfsCampaignType,0) as idfsCampaignType\n" +
                    "FROM ASCampaign\n" +
                    "WHERE idfCampaign = ?";
    public static final String select_sql_campaigns =
            "SELECT idfCampaign as _id, ifnull(strCampaignName,'') || ifnull(' (' || strftime('%Y-%m-%d', datCampaignDateStart) || ')', '') as name\n" +
                    "FROM ASCampaign\n" +
                    "WHERE (intRowStatus = 0 or idfCampaign = ?)" +
                    "ORDER BY name";

    public static final String select_sql_farm =
            "SELECT idfFarm as _id, ifnull(strFarmName || ' / ', '') || ifnull(strOwnerLastName || ' ', '') || ifnull(strOwnerFirstName || ' ', '') || ifnull(strOwnerMiddleName || ' ', '') as name\n" +
                    "FROM Farm\n" +
                    "WHERE idfFarm = ?";
    public static final String select_sql_farms_prov =
            "SELECT 0 as idfsBaseReference, '[NewFarm]' as name\n" +
            "UNION ALL\n" +
            "SELECT idfsBaseReference, name FROM (\n" +
            "SELECT idfFarm as idfsBaseReference, ifnull(strFarmName, '') || ' / ' || ifnull(strOwnerLastName || ' ', '') || ifnull(strOwnerFirstName || ' ', '') || ifnull(strOwnerMiddleName || ' ', '') as name\n" +
            //"SELECT idfFarm as idfsBaseReference, strFarmName as name\n" +
                    "FROM Farm\n" +
                    "WHERE blnIsRoot = 1 and (intRowStatus = 0 or idfFarm = ?)" +
                    "ORDER BY name)";


    public static final String select_sql_campaign_diagnosis_one =
            "SELECT DISTINCT ad.idfsDiagnosis as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM ASDisease ad\n" +
                    "INNER JOIN BaseReference br on br.idfsBaseReference = ad.idfsDiagnosis\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE ad.idfCampaign = ? AND ad.idfsDiagnosis = ?\n" +
                    "ORDER BY name";
    public static final String select_sql_campaign_diagnosis_list =
            "SELECT 0 as _id, '' as name\n" +
            "UNION ALL\n" +
            "SELECT DISTINCT ad.idfsDiagnosis as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM ASDisease ad\n" +
                    "INNER JOIN BaseReference br on br.idfsBaseReference = ad.idfsDiagnosis\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE ad.idfCampaign = ? OR ad.idfsDiagnosis = ?\n" +
                    "ORDER BY name";

    public static final String select_sql_campaign_species_one =
            "SELECT DISTINCT ad.idfsSpeciesType as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM ASDisease ad\n" +
                    "INNER JOIN BaseReference br on br.idfsBaseReference = ad.idfsSpeciesType\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE ad.idfCampaign = ? AND ad.idfsDiagnosis = ? AND ad.idfsSpeciesType = ?\n" +
                    "ORDER BY name";
    public static final String select_sql_campaign_species_list =
            "SELECT DISTINCT ad.idfsSpeciesType as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM ASDisease ad\n" +
                    "INNER JOIN BaseReference br on br.idfsBaseReference = ad.idfsSpeciesType\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE ad.idfCampaign = ? AND ad.idfsDiagnosis = ? OR ad.idfsSpeciesType = ?\n" +
                    "ORDER BY name";

    public static final String select_sql_campaign_samples_one =
            "SELECT DISTINCT ad.idfsSampleType as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM ASDisease ad\n" +
                    "INNER JOIN BaseReference br on br.idfsBaseReference = ad.idfsSampleType\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE ad.idfCampaign = ? AND ad.idfsDiagnosis = ? AND ad.idfsSpeciesType = ? AND ad.idfsSampleType = ?\n" +
                    "ORDER BY name";
    public static final String select_sql_campaign_samples_list =
            "SELECT DISTINCT ad.idfsSampleType as _id, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM ASDisease ad\n" +
                    "INNER JOIN BaseReference br on br.idfsBaseReference = ad.idfsSampleType\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE ad.idfCampaign = ? AND ad.idfsDiagnosis = ? AND ad.idfsSpeciesType = ? OR ad.idfsSampleType = ?\n" +
                    "ORDER BY name";


        private static final String select_sql_vetcase =
            "SELECT distinct v.*, \n" +
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

    private static final String select_sql_assession =
            "SELECT distinct v.*, \n" +
                    "ifnull(ret.strTranslation, re.strDefault) as strRegion,\n" +
                    "ifnull(rat.strTranslation, ra.strDefault) as strRayon,\n" +
                    "ifnull(stt.strTranslation, st.strDefault) as strSettlement,\n" +
                    "ifnull(ca.strCampaignName, '') as strCampaignName,\n" +
                    "ifnull(sst.strTranslation, ss.strDefault) as strSesionStatus\n" +
                    "FROM ASSession v\n" +
                    "INNER JOIN BaseReference ss on ss.idfsBaseReference = v.idfsMonitoringSessionStatus\n" +
                    "INNER JOIN GisBaseReference re on re.idfsBaseReference = v.idfsRegion and re.idfsReferenceType = 19000003\n" +
                    "INNER JOIN GisBaseReference ra on ra.idfsBaseReference = v.idfsRayon and ra.idfsReferenceType = 19000002\n" +
                    "LEFT OUTER JOIN GisBaseReference st on st.idfsBaseReference = v.idfsSettlement and st.idfsReferenceType = 19000004\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation sst on sst.idfsBaseReference = ss.idfsBaseReference and sst.strLanguage = ?\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation ret on ret.idfsBaseReference = re.idfsBaseReference and ret.strLanguage = ?\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation rat on rat.idfsBaseReference = ra.idfsBaseReference and rat.strLanguage = ?\n" +
                    "LEFT OUTER JOIN GisBaseReferenceTranslation stt on stt.idfsBaseReference = st.idfsBaseReference and stt.strLanguage = ?\n" +
                    "LEFT OUTER JOIN ASCampaign ca on ca.idfCampaign = v.idfCampaign\n" +
                    "ORDER BY datCreateDate";

    private static final String select_sql_species =
            "SELECT * " +
                    "FROM Species " +
                    "WHERE idfVetCase = ? " +
                    "ORDER BY id";
    private static final String select_sql_animals =
            "SELECT * " +
                    "FROM Animal " +
                    "WHERE idfCase = ? " +
                    "ORDER BY id";
    private static final String select_sql_vetsamples =
            "SELECT * " +
                    "FROM VetCaseSample " +
                    "WHERE idfCase = ? " +
                    "ORDER BY id";
    private static final String select_sql_humsamples =
            "SELECT * " +
                    "FROM HumanCaseSample " +
                    "WHERE idfCase = ? " +
                    "ORDER BY id";
    private static final String select_sql_as_diseases =
            "SELECT * " +
                    "FROM ASDisease " +
                    "WHERE idParent = ? " +
                    "ORDER BY id";


    //Flexible Forms
    private static final String select_sql_ff_determinants =
            "SELECT idfsFormTemplate " +
                    "FROM FFDeterminant " +
                    "WHERE idfDeterminantValue = ? " +
                    "and idfsFormType = ? ";
    public static final String insert_sql_ff_determinants =
            "insert into FFDeterminant(idfDeterminantValue,idfsFormType,idfsFormTemplate) values (?, ?, ?)";
    private static final String select_sql_ff_determinants_simple =
            "SELECT idfsFormTemplate " +
                    "FROM FFDeterminant " +
                    "WHERE idfsFormType = ? ";

    private static final String select_sql_ff_template_elements =
            "SELECT * FROM FFTemplate WHERE idfsFormTemplate = ? ORDER BY intOrder";
    public static final String insert_sql_ff_template_elements =
            "insert into FFTemplate(idfsBaseReference,idfsFormTemplate,idfsBaseReferenceParent,intElementType,idfsEditor,intReadOnly,intMandatory,idfsParameterType,intOrder,idfsParameterCaption) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

    private static final String select_sql_ff_parameter_fixed_values =
            "SELECT FPV.idfsParameterFixedPresetValue, ifnull(bt.strTranslation, br.strDefault) as name\n" +
                    "FROM FFParameterFixedPresetValue FPV\n" +
                    "INNER JOIN BaseReference br on FPV.idfsParameterFixedPresetValue = bt.idfsBaseReference\n" +
                    "LEFT OUTER JOIN BaseReferenceTranslation bt on bt.idfsBaseReference = br.idfsBaseReference and bt.strLanguage = ?\n" +
                    "WHERE FPV.idfsParameterType = ?\n" +
                    "and (br.intRowStatus = 0 or FPV.idfsParameterType = ?)" +
                    "ORDER BY br.intOrder, name";
    public static final String insert_sql_ff_rules =
            "insert into FFRule(idfsRule,idfsFormTemplate,idfsCheckPoint,idfsRuleMessage,idfsRuleFunction,intNot) values (?, ?, ?, ?, ?, ?)";
    public static final String insert_sql_ff_constants =
            "insert into FFRuleConstant(idfsRule,strConstant) values (?, ?)";
    public static final String insert_sql_ff_parsforf =
            "insert into FFParameterForFunction(idfsParameter,idfsRule,intOrder) values (?, ?, ?)";
    public static final String insert_sql_ff_parsfora =
            "insert into FFParameterForAction(idfsParameter,idfsRule,idfsRuleAction) values (?, ?, ?)";
    public static final String insert_sql_ff_parsprefixed =
            "insert into FFParameterFixedPresetValue(idfsParameterFixedPresetValue,idfsParameterType) values (?, ?)";

    private static final String select_sql_min_observation_id =
            "SELECT Min(idfObservation) as [MinValue] FROM Observation";

    private final static String DatabaseName = "eidss.db";
    private final static int DatabaseVersion = 1;

    private String defServerUrl;
    private String defLoginOrganization = "";
    private String defLoginUser = "";
    private final static String strDefLang = "def";
    private final static int defApplicationMode = 3;
    private final static int defPageSize = 30;
    private final static int defLockTimeout = 15;
    private final static int defResponseTimeout = 1;
    private static Options defOptions;
    private static List<String> defMandatoryFields;
    private static List<String> defInvisibleFields;
    private static GisBaseReference defGisCountry;
    private static SimpleArrayMap references;
    private static SimpleArrayMap gisreferences;
    private static SimpleArrayMap ffObjects; //such as the Parameters, the Sections and the Labels

    private static String AppLang;

    public EidssDatabase(Context context, String ServerUrl, String LoginOrganization, String LoginUser) {
        super(context, DatabaseName, null, DatabaseVersion);
        defServerUrl = ServerUrl;
        defLoginOrganization = LoginOrganization;
        defLoginUser = LoginUser;
    }

    public EidssDatabase(Context context) {
        super(context, DatabaseName, null, DatabaseVersion);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(create_sql_options);
        db.execSQL(String.format(insert_options_def, defServerUrl, defServerUrl, defLoginOrganization, defLoginOrganization, defLoginUser, defLoginUser,
                strDefLang, defApplicationMode, defApplicationMode, defPageSize, defPageSize,
                defLockTimeout, defLockTimeout, defResponseTimeout, defResponseTimeout));
        db.execSQL(create_sql_mandatory_fields);
        db.execSQL(create_sql_invisible_fields);
        db.execSQL(create_sql_references);
        db.execSQL(create_sql_references_lang);
        db.execSQL(create_sql_gis_references);
        db.execSQL(create_sql_gis_references_lang);
        db.execSQL(create_sql_ff_activity_parameters);
        db.execSQL(create_sql_ff_template);
        db.execSQL(create_sql_ff_determinant);
        db.execSQL(create_sql_ff_rule);
        db.execSQL(create_sql_ff_rule_constant);
        db.execSQL(create_sql_ff_parameter_for_function);
        db.execSQL(create_sql_ff_parameter_for_action);
        db.execSQL(create_sql_ff_parameter_fixed_preset_value);
        db.execSQL(create_sql_observation);
        db.execSQL(create_sql_as_campaign);
        db.execSQL(HumanCase_database.create_sql);
        db.execSQL(VetCase_database.create_sql);
        db.execSQL(Species_database.create_sql);
        db.execSQL(Animal_database.create_sql);
        db.execSQL(HumanCaseSample_database.create_sql);
        db.execSQL(VetCaseSample_database.create_sql);
        db.execSQL(ASSession_database.create_sql);
        db.execSQL(ASDisease_database.create_sql);
        db.execSQL(ASSample_database.create_sql);
        db.execSQL(Farm_database.create_sql);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
    }

    public Options Options() {
        if (defOptions == null) {
            SQLiteDatabase db = getReadableDatabase();
            Cursor cursor = db.query("Options", null, null, null, null, null, null);
            cursor.moveToFirst();
            defOptions = Options.FromCursor(cursor);
            db.close();
            setAppLang();
        }
        return defOptions;
    }

    // Options() is called during login - so defOptions is filled
    public static Options GetOptions() {
        return defOptions;
    }

    public static String getAppLang(){return AppLang;}
    public static void setAppLang(){
            AppLang = defOptions.getDefLang();
            if (AppLang.compareTo(strDefLang) == 0)
                    AppLang = EidssUtils.getLocale();
    }


    private void OptionsUpdateInternal(SQLiteDatabase db, Options o) {
        defOptions = o;
        db.replace("Options", null, defOptions.ContentValues());
    }

    public void OptionsUpdate(Options o) {
        SQLiteDatabase db = getWritableDatabase();
        OptionsUpdateInternal(db, o);
        db.close();
    }

    public ASCampaign GetCampaign(long id){
        ASCampaign ret = null;
        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor = db.query("ASCampaign", null, "idfCampaign=?", new String[]{String.valueOf(id)}, null, null, null);
        Boolean r = cursor.moveToFirst();
        if(r){
            ret = ASCampaign.FromCursor(cursor);
        }
        cursor.close();
        if (ret != null && id != 0){
            cursor = db.query("ASDisease", null, "idfCampaign=?", new String[]{String.valueOf(id)}, null, null, null);
            r = cursor.moveToFirst();
            while(r) {
                ASDisease it = ASDisease.FromCursor(cursor);
                if (it != null) {
                    ret.asDiseases.add(it);
                }
                r = cursor.moveToNext();
            }
            cursor.close();
        }
        db.close();
        return ret;
    }

    private void LoadCampaigns(SQLiteDatabase db, ArrayList<ASCampaign> campaign){
        ArrayList<ASCampaign> campaignToInsert = new ArrayList<>();
        ArrayList<ASCampaign> campaignToDelete = new ArrayList<>();
        ArrayList<ASCampaign> campaignToUpdate = new ArrayList<>();

        for (int i = 0; i < campaign.size(); i++) {
            campaignToInsert.add(campaign.get(i));
        }
        boolean bInsertEmpty = true;
        Cursor cursor = db.query("ASCampaign", null, null, null, null, null, null);
        Boolean r = cursor.moveToFirst();
        while(r)
        {
            ASCampaign cmp = ASCampaign.FromCursor(cursor);
            if (cmp.idfCampaign == 0){
                bInsertEmpty = false;
            }
            boolean bFound = false;
            for (int i = 0; i < campaign.size(); i++) {
                if (cmp.idfCampaign == campaign.get(i).idfCampaign){
                    bFound = true;
                    campaignToUpdate.add(campaign.get(i));
                    campaignToInsert.remove(campaign.get(i));
                }
            }
            if (!bFound && cmp.idfCampaign != 0){
                campaignToDelete.add(cmp);
            }
            r = cursor.moveToNext();
        }
        cursor.close();


        Format formatterDate = DateHelpers.getDateFormatter();
        SQLiteStatement stmt = db.compileStatement(insert_sql_as_campaign);
        if (bInsertEmpty) {
            stmt.clearBindings();
            stmt.bindLong(1, 0);
            stmt.bindLong(2, 0);
            stmt.bindString(3, "");
            stmt.bindLong(4, 0);
            stmt.bindString(5, "");
            stmt.bindString(6, "");
            stmt.executeInsert();
        }
        for (int i = 0; i < campaignToInsert.size(); i++) {
            stmt.clearBindings();
            stmt.bindLong(1, campaignToInsert.get(i).intRowStatus);
            stmt.bindLong(2, campaignToInsert.get(i).idfCampaign);
            stmt.bindString(3, campaignToInsert.get(i).strCampaignName);
            stmt.bindLong(4, campaignToInsert.get(i).idfsCampaignType);
            stmt.bindString(5, campaignToInsert.get(i).datCampaignDateStart == null ? "" : formatterDate.format(campaignToInsert.get(i).datCampaignDateStart));
            stmt.bindString(6, campaignToInsert.get(i).datCampaignDateEnd == null ? "" : formatterDate.format(campaignToInsert.get(i).datCampaignDateEnd));
            stmt.executeInsert();
            }
            stmt.close();

        stmt = db.compileStatement(delete_sql_as_disease);
        for (int i = 0; i < campaignToDelete.size(); i++) {
            stmt.clearBindings();
            stmt.bindLong(1, campaignToDelete.get(i).idfCampaign);
            stmt.execute();
        }
        for (int i = 0; i < campaignToUpdate.size(); i++) {
            stmt.clearBindings();
            stmt.bindLong(1, campaignToUpdate.get(i).idfCampaign);
            stmt.execute();
        }
        stmt.close();

        stmt = db.compileStatement(update_sql_as_campaign);
        for (int i = 0; i < campaignToDelete.size(); i++) {
            stmt.clearBindings();
            stmt.bindLong(1, 1);
            stmt.bindString(2, campaignToDelete.get(i).strCampaignName);
            stmt.bindLong(3, campaignToDelete.get(i).idfsCampaignType);
            stmt.bindString(4, campaignToDelete.get(i).datCampaignDateStart == null ? "" : formatterDate.format(campaignToDelete.get(i).datCampaignDateStart));
            stmt.bindString(5, campaignToDelete.get(i).datCampaignDateEnd == null ? "" : formatterDate.format(campaignToDelete.get(i).datCampaignDateEnd));
            stmt.bindLong(6, campaignToDelete.get(i).idfCampaign);
            stmt.execute();
        }
        for (int i = 0; i < campaignToUpdate.size(); i++) {
            stmt.clearBindings();
            stmt.bindLong(1, campaignToUpdate.get(i).intRowStatus);
            stmt.bindString(2, campaignToUpdate.get(i).strCampaignName);
            stmt.bindLong(3, campaignToUpdate.get(i).idfsCampaignType);
            stmt.bindString(4, campaignToUpdate.get(i).datCampaignDateStart == null ? "" : formatterDate.format(campaignToUpdate.get(i).datCampaignDateStart));
            stmt.bindString(5, campaignToUpdate.get(i).datCampaignDateEnd == null ? "" : formatterDate.format(campaignToUpdate.get(i).datCampaignDateEnd));
            stmt.bindLong(6, campaignToUpdate.get(i).idfCampaign);
            stmt.execute();
        }
        stmt.close();


        stmt = db.compileStatement(insert_sql_as_disease);
        for (int i = 0; i < campaignToInsert.size(); i++) {
            for (int j = 0; j < campaignToInsert.get(i).asDiseases.size(); j++) {
                stmt.clearBindings();
                stmt.bindLong(1, campaignToInsert.get(i).asDiseases.get(j).getCampaign());
                stmt.bindLong(2, campaignToInsert.get(i).asDiseases.get(j).getDiagnosis());
                stmt.bindLong(3, campaignToInsert.get(i).asDiseases.get(j).getSpeciesType());
                stmt.bindLong(4, campaignToInsert.get(i).asDiseases.get(j).getSampleType());
                stmt.executeInsert();
            }
        }
        for (int i = 0; i < campaignToUpdate.size(); i++) {
            for (int j = 0; j < campaignToUpdate.get(i).asDiseases.size(); j++) {
                stmt.clearBindings();
                stmt.bindLong(1, campaignToUpdate.get(i).asDiseases.get(j).getCampaign());
                stmt.bindLong(2, campaignToUpdate.get(i).asDiseases.get(j).getDiagnosis());
                stmt.bindLong(3, campaignToUpdate.get(i).asDiseases.get(j).getSpeciesType());
                stmt.bindLong(4, campaignToUpdate.get(i).asDiseases.get(j).getSampleType());
                stmt.executeInsert();
            }
        }
        stmt.close();

    }


    public boolean LoadLists(ArrayList<ASCampaign> campaign, ArrayList<ASSession> sessions, ArrayList<Farm> farms) {
        SQLiteDatabase db = getWritableDatabase();
        try {
            db.beginTransaction();

            EidssDatabaseFarm.LoadFarms(db, farms);

            LoadCampaigns(db, campaign);

            for (int i = 0; i < sessions.size(); i++) {
                ASSessionUpdateOrInsertInternal(db, sessions.get(i));
            }

            db.setTransactionSuccessful();
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        } finally {
            db.endTransaction();
        }
    }


    public boolean LoadReferences(ArrayList<MandatoryFieldsRaw> mandatory_fields, ArrayList<InvisibleFieldsRaw> invisible_fields,
                                  ArrayList<BaseReferenceRaw> refs, ArrayList<BaseReferenceTranslationRaw> refs_trans,
                                  ArrayList<GisBaseReferenceRaw> gis_refs, ArrayList<GisBaseReferenceTranslationRaw> gis_refs_trans,
                                  FFReferences ffRefs) {
        SQLiteDatabase db = getWritableDatabase();
        try {
            db.beginTransaction();
            db.delete("GisBaseReferenceTranslation", null, null);
            db.delete("GisBaseReference", null, null);
            db.delete("BaseReferenceTranslation", null, null);
            db.delete("BaseReference", null, null);
            db.delete("InvisibleFields", null, null);
            db.delete("MandatoryFields", null, null);

            SQLiteStatement stmt = db.compileStatement(insert_sql_mandatory_fields);
            for (int i = 0; i < mandatory_fields.size(); i++) {
                stmt.clearBindings();
                stmt.bindLong(1, mandatory_fields.get(i).idfMandatoryField);
                stmt.bindString(2, mandatory_fields.get(i).strFieldAlias);
                stmt.executeInsert();
                //db.insert("MandatoryFields", null, mandatory_fields.get(i).ContentValues());
            }
            stmt.close();

            stmt = db.compileStatement(insert_sql_invisible_fields);
            for (int i = 0; i < invisible_fields.size(); i++) {
                stmt.clearBindings();
                stmt.bindLong(1, invisible_fields.get(i).idfInvisibleField);
                stmt.bindString(2, invisible_fields.get(i).strFieldAlias);
                stmt.executeInsert();

                //db.insert("InvisibleFields", null, invisible_fields.get(i).ContentValues());
            }
            stmt.close();

            stmt = db.compileStatement(insert_sql_references_wf);
            for (int i = 0; i < refs.size(); i++) {
                stmt.clearBindings();
                stmt.bindLong(1, refs.get(i).idfsBaseReference);
                stmt.bindLong(2, refs.get(i).idfsReferenceType);
                stmt.bindLong(3, refs.get(i).intHACode);
                stmt.bindString(4, refs.get(i).strDefault);
                stmt.bindLong(5, refs.get(i).intRowStatus);
                stmt.bindLong(6, refs.get(i).intOrder);
                stmt.bindLong(7, refs.get(i).intFeature1);
                stmt.bindLong(8, refs.get(i).intFeature2);
                stmt.executeInsert();

                //db.insert("BaseReference", null, refs.get(i).ContentValues());
            }
            stmt.close();

            stmt = db.compileStatement(insert_sql_references_trans);
            for (int i = 0; i < refs_trans.size(); i++) {
                stmt.clearBindings();
                stmt.bindLong(1, refs_trans.get(i).idfsBaseReference);
                stmt.bindString(2, refs_trans.get(i).strTranslation);
                stmt.bindString(3, refs_trans.get(i).strLanguage);
                stmt.executeInsert();
                //db.insert("BaseReferenceTranslation", null, refs_trans.get(i).ContentValues());
            }
            stmt.close();

            stmt = db.compileStatement(insert_sql_gisreferences);
            for (int i = 0; i < gis_refs.size(); i++) {
                stmt.clearBindings();
                stmt.bindLong(1, gis_refs.get(i).idfsBaseReference);
                stmt.bindLong(2, gis_refs.get(i).idfsReferenceType);
                stmt.bindLong(3, gis_refs.get(i).idfsCountry);
                stmt.bindLong(4, gis_refs.get(i).idfsRegion);
                stmt.bindLong(5, gis_refs.get(i).idfsRayon);
                stmt.bindString(6, gis_refs.get(i).strDefault);
                stmt.bindLong(7, gis_refs.get(i).intRowStatus);
                stmt.bindLong(8, gis_refs.get(i).intOrder);
                stmt.executeInsert();

                //db.insert("GisBaseReference", null, gis_refs.get(i).ContentValues());
            }
            stmt.close();

            stmt = db.compileStatement(insert_sql_gisreferences_trans);
            for (int i = 0; i < gis_refs_trans.size(); i++) {
                stmt.clearBindings();
                stmt.bindLong(1, gis_refs_trans.get(i).idfsBaseReference);
                stmt.bindString(2, gis_refs_trans.get(i).strTranslation);
                stmt.bindString(3, gis_refs_trans.get(i).strLanguage);
                stmt.executeInsert();
                //db.insert("GisBaseReferenceTranslation", null, gis_refs_trans.get(i).ContentValues());
            }
            stmt.close();

            if (ffRefs != null)
                ffRefs.Update(db);

            db.setTransactionSuccessful();
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        } finally {
            db.endTransaction();
        }
    }

    public SQLiteDatabase BeginLoadReferences() {
        SQLiteDatabase db = getWritableDatabase();
        try {
            db.beginTransaction();
            db.delete("GisBaseReferenceTranslation", null, null);
            db.delete("GisBaseReference", null, null);
            db.delete("BaseReferenceTranslation", null, null);
            db.delete("BaseReference", null, null);
            db.delete("InvisibleFields", null, null);
            db.delete("MandatoryFields", null, null);

            db.delete("FFTemplate", null, null);
            db.delete("FFDeterminant", null, null);
            db.delete("FFRule", null, null);
            db.delete("FFRuleConstant", null, null);
            db.delete("FFParameterForFunction", null, null);
            db.delete("FFParameterForAction", null, null);
            db.delete("FFParameterFixedPresetValue", null, null);
        }catch (Exception e) {
            e.printStackTrace();
            db.endTransaction();
            return null;
        }
        return db;
    }

    public static List<String> GetMandatoryFields()
    {
        return defMandatoryFields;
    }
    public List<String> MandatoryFields() {
        if (defMandatoryFields == null) {
            defMandatoryFields = new ArrayList<>();
            SQLiteDatabase db = getReadableDatabase();
            String[] args = new String[0];
            Cursor cursor = db.rawQuery(select_sql_mandatory_fields, args);
            Boolean r = cursor.moveToFirst();
            while (r) {
                defMandatoryFields.add(MandatoryFields.FromCursor(cursor).strFieldAlias);
                r = cursor.moveToNext();
            }
            cursor.close();
            db.close();
        }
        return defMandatoryFields;
    }

    public static List<String> GetInvisibleFields()
    {
        return defInvisibleFields;
    }
    public List<String> InvisibleFields() {
        if (defInvisibleFields == null) {
            defInvisibleFields = new ArrayList<>();
            SQLiteDatabase db = getReadableDatabase();
            String[] args = new String[0];
            Cursor cursor = db.rawQuery(select_sql_invisible_fields, args);
            Boolean r = cursor.moveToFirst();
            while (r) {
                defInvisibleFields.add(InvisibleFields.FromCursor(cursor).strFieldAlias);
                r = cursor.moveToNext();
            }
            cursor.close();
            db.close();
        }
        return defInvisibleFields;
    }

    public static List<BaseReference> GetHospitals() {
      return  GetReferences(BaseReferenceType.rftInstitutionName);
    }
    public static void SetHospitals(Cursor data) {
        SetReferences(BaseReferenceType.rftInstitutionName, data);
    }

    public static String FFGetText(final long idfsBaseReference) {
        String result = "";
        if (ffObjects != null && ffObjects.containsKey(idfsBaseReference)){
            BaseReference br = (BaseReference)ffObjects.get(idfsBaseReference);
            result = br.name;
        }
        return result;
    }

    public static boolean IsFFLoaded(){
        return ffObjects != null && ffObjects.size() > 0;
    }

    public static void AddFFData(Cursor data) {
        if (ffObjects == null) ffObjects = new SimpleArrayMap<>();
        SimpleArrayMap list = GetSimpleArrayMapFromCursor(data);
            ffObjects.putAll(list);

        /*TODO
        SetReferences(BaseReferenceType.rftFFParameterCaption, data); //let it be first as most frequently used
        SetReferences(BaseReferenceType.rftParameterTooltip, data);
        SetReferences(BaseReferenceType.rftFFParameterControl, data);
        SetReferences(BaseReferenceType.rftFFParameterMode, data);
        SetReferences(BaseReferenceType.rftFFParameterValue, data);
        SetReferences(BaseReferenceType.rftFFParameterType, data);
        SetReferences(BaseReferenceType.rftFFSection, data);
        */
    }

    public static List<BaseReference> GetReferences(final long rft)
    {
        if (references != null && references.containsKey(rft))
            return (List<BaseReference>)(references.get(rft));
        else return null;
    }

    public static void SetReferences(final long rft, Cursor data) {
        if (references == null)
            references = new SimpleArrayMap<>();

        if (references.containsKey(rft))
            references.remove(rft);

        List<BaseReference> ret = EidssDatabase.GetReferenceListFromCursor(data);
        references.put(rft, ret);
    }

    public static List<GisBaseReference> GetRegions()
    {
        return  GetGisReferences(GisBaseReferenceType.rftRegion);
    }
    public static void SetRegions(Cursor data) {
        SetGisReferences(GisBaseReferenceType.rftRegion, data);
    }

    public static List<GisBaseReference> GetGisReferences(final long rft)
    {
        if (gisreferences != null && gisreferences.containsKey(rft))
            return (List<GisBaseReference>)(gisreferences.get(rft));
        else
            return null;
    }
    public static void SetGisReferences(final long rft, Cursor data) {
        if (gisreferences == null)
            gisreferences = new SimpleArrayMap<>();

        if (gisreferences.containsKey(rft))
            gisreferences.remove(rft);

        List<GisBaseReference> ret = EidssDatabase.GetGisReferenceListFromCursor(data);
        gisreferences.put(rft, ret);
    }

    public static void ClearPreloadedReferencies() {
        defMandatoryFields = null;
        defInvisibleFields = null;
        ClearLabels();
    }

    public static void ClearLabels() {
        if (references != null) {
            references.clear();
            references = null;
        }
        if (gisreferences != null) {
            gisreferences.clear();
            gisreferences = null;
        }
        if (ffObjects != null) {
            ffObjects.clear();
            ffObjects = null;
        }
    }

    public List<BaseReference> FFGetFixedPresetValues(long idParameterType) {
        ArrayList<BaseReference> ret = new ArrayList<>();
        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor = db.rawQuery(select_sql_ff_parameter_fixed_values, new String[]{EidssUtils.getCurrentLanguage(), String.valueOf(idParameterType), String.valueOf(idParameterType)});
        boolean rSp = cursor.moveToFirst();
        if (rSp){
            ret.add(BaseReference.Empty());
        }
        while(rSp) {
            ret.add(new BaseReference(cursor.getLong(cursor.getColumnIndex("idfsParameterFixedPresetValue")), cursor.getString(cursor.getColumnIndex("name"))));
            rSp = cursor.moveToNext();
        }
        cursor.close();
        db.close();
        return ret;
    }

    public List<BaseReference> Reference(long type, String lang, int hacode, long val) {
        SQLiteDatabase db = getReadableDatabase();
        String sql;
        String[] args;
        if (hacode == 0) {
            sql = select_sql_references;
            args = new String[3];
            args[0] = lang;
            args[1] = String.valueOf(type);
            args[2] = String.valueOf(val);
        } else {
            sql = select_sql_references_hacodable;
            args = new String[4];
            args[0] = lang;
            args[1] = String.valueOf(type);
            args[2] = String.valueOf(hacode);
            args[3] = String.valueOf(val);
        }
        Cursor cursor = db.rawQuery(sql, args);
        return GetReferenceListFromCursor(cursor);
    }

    public List<BaseReference> Reference(long type, String lang, int hacode, long val, long f1, long f2) {
        SQLiteDatabase db = getReadableDatabase();
        String sql;
        String[] args;
        if (f2 == 0) {
            sql = select_sql_references_hacodable_f1;
            args = new String[5];
            args[0] = lang;
            args[1] = String.valueOf(type);
            args[2] = String.valueOf(hacode);
            args[3] = String.valueOf(f1);
            args[4] = String.valueOf(val);
        } else {
            sql = select_sql_references_hacodable_f1_f2;
            args = new String[6];
            args[0] = lang;
            args[1] = String.valueOf(type);
            args[2] = String.valueOf(hacode);
            args[3] = String.valueOf(f1);
            args[4] = String.valueOf(f2);
            args[5] = String.valueOf(val);
        }
        Cursor cursor = db.rawQuery(sql, args);
        return GetReferenceListFromCursor(cursor);
    }

    public static List<BaseReference> GetReferenceListFromCursor(Cursor data) {
        List<BaseReference> ret = new ArrayList<>();
        Boolean r = data.moveToFirst();
        while(r) {
            ret.add(BaseReference.FromCursor(data));
            r = data.moveToNext();
        }

        data.close();
        if (ret.size() == 0 || ret.get(0).idfsBaseReference > 0L )
            ret.add(0, BaseReference.Empty());
        return ret;
    }

    public static List<GisBaseReference> GetGisReferenceListFromCursor(Cursor data) {
        List<GisBaseReference> ret = new ArrayList<>();
        Boolean r = data.moveToFirst();
        while(r) {
            ret.add(GisBaseReference.FromCursor(data));
            r = data.moveToNext();
        }
        data.close();
        return ret;
    }

    public static SimpleArrayMap GetSimpleArrayMapFromCursor(Cursor data) {
        SimpleArrayMap ret = new SimpleArrayMap<>();
        Boolean r = data.moveToFirst();
        while(r) {
            BaseReference br = BaseReference.FromCursor(data);
            ret.put(br.idfsBaseReference, br);
            r = data.moveToNext();
        }
        data.close();
        return ret;
    }

    public static GisBaseReference GetGisReferenceFromCursor(Cursor data) {
        GisBaseReference ret = null;
        Boolean r = data.moveToFirst();
        while(r) {
            ret = GisBaseReference.FromCursor(data);
            if (ret.idfsBaseReference != 0){
                break;
            }
            r = data.moveToNext();
        }
        data.close();
        return ret;
    }


    public GisBaseReference GisCountry(String lang)
    {
        if (defGisCountry == null) {
            defGisCountry = null;
            SQLiteDatabase db = getReadableDatabase();
            String[] args = new String[1];
            args[0] = lang;
            Cursor cursor = db.rawQuery(select_sql_country, args);
            defGisCountry = GetGisReferenceFromCursor(cursor);
                db.close();
        }
        return defGisCountry;
    }

///////////////// cases

    // Human cases with particular status (if status>0) or all Human cases (if status=0) WITHOUT samples
    public List<HumanCase> HumanCaseSelect(int status)
    {
    	List<HumanCase> ret = new ArrayList<>();
    	SQLiteDatabase db = getReadableDatabase();
    	Cursor cursor;
        if (status == 0)
            cursor = db.query("HumanCase", null, null, null, null, null, "datCreateDate");
        else
            cursor = db.query("HumanCase", null, "intStatus="+status, null, null, null, "datCreateDate");
    	Boolean r = cursor.moveToLast();
    	while(r)
    	{
    		HumanCase hc = HumanCase.FromCursor(cursor);
    		if (hc != null && (status == 0 || hc.getStatus() == status))
            {
                //load FF data
                hc.FFModelCS.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, hc.getCSObservation());
                hc.FFModelEpi.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, hc.getEpiObservation());
                ret.add(hc);
            }
    		r = cursor.moveToPrevious();
    	}
    	cursor.close();
        db.close();
        return ret;
    }
    // one Human case (if id>0) or all Human cases (if id=0) WITH samples
    public List<HumanCase> HumanCaseSelect(long id)
    {
    	List<HumanCase> ret = new ArrayList<>();
    	SQLiteDatabase db = getReadableDatabase();
        Cursor cursor;
        if (id == 0)
            cursor = db.query("HumanCase", null, null, null, null, null, "datCreateDate");
        else
            cursor = db.query("HumanCase", null, "id="+id, null, null, null, "datCreateDate");
    	Boolean r = cursor.moveToLast();
    	while(r)
    	{
    		HumanCase hc = HumanCase.FromCursor(cursor);
            if (hc != null && (id == 0 || hc.getId() == id))
            {
                //load FF data
                hc.FFModelCS.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, hc.getCSObservation());
                hc.FFModelEpi.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, hc.getEpiObservation());
                ret.add(hc);
            }
    		r = cursor.moveToPrevious();
    	}
    	cursor.close();
        db.close();

        if(ret.size() > 0) {
            HumSamplesSelect(ret, id);
        }
        return ret;
    }
    
    // list of vetcases WITHOUT all lists: species, animals, samples with particular status (if status>0)
    public List<VetCase> VetCaseSelect(int status)
    {
    	List<VetCase> ret = new ArrayList<>();
    	SQLiteDatabase db = getReadableDatabase();

        /*Cursor cursor = db.query("VetCase", null, null, null, null, null, "datCreateDate");*/
    	String[] args = new String[5];
    	args[0] = EidssUtils.getCurrentLanguage();
    	args[1] = args[0];
    	args[2] = args[0];
    	args[3] = args[0];
    	args[4] = args[0];
        Cursor cursor = db.rawQuery(select_sql_vetcase, args);

        Boolean r = cursor.moveToLast();
    	while(r)
    	{
    		VetCase vc = VetCase.FromCursor(cursor);
    		if (vc != null && (status == 0 || vc.getStatus() == status)) 
    		{
                vc.FFFarmEpi.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, vc.getObservationFarm());
                vc.FFControlMeasures.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, vc.getObservation());
                ret.add(vc);
            }
    		r = cursor.moveToPrevious();
    	}
    	cursor.close();
    	db.close();
        return ret;
    }

    // one vetcase (if id>0) or all vetcases (if id=0) WITH all lists: species, animals, samples
	public List<VetCase> VetCaseSelect(final long id)
	{
		List<VetCase> ret = new ArrayList<>();
		
    	SQLiteDatabase db = getReadableDatabase();
        Cursor cursor;
        if(id == 0)
            cursor = db.query("VetCase", null, null, null, null, null, "datCreateDate");
        else
            cursor = db.query("VetCase", null, "id="+id, null, null, null, "datCreateDate");
		Boolean r = cursor.moveToFirst();
		while(r)
		{
			VetCase vc = VetCase.FromCursor(cursor); 
			if (vc != null && (id == 0 || vc.getId() == id)) {
                vc.FFFarmEpi.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, vc.getObservationFarm());
                vc.FFControlMeasures.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, vc.getObservation());
                ret.add(vc);
			}
			r = cursor.moveToNext();
		}
		cursor.close();

        if(ret.size() > 0) {
            EidssDatabaseSpecies.SpeciesSelect(db, new ArrayList<ISpeciesParent>(ret), id);
        }

        db.close();

        if(ret.size() > 0) {
            AnimalsSelect(ret, id);
            VetSamplesSelect(ret, id);
        }

	    return ret;
	}

    //load lists of animals to cases in ret
    public void AnimalsSelect(final List<VetCase> ret, final long id)
    {
        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor;
        if(id == 0)
            cursor = db.query("Animal", null, null, null, null, null, "id");
        else
            cursor = db.query("Animal", null, "idParent=" + id, null, null, null, "id");
        Boolean rSp = cursor.moveToFirst();
        while(rSp)
        {
            Animal it = Animal.FromCursor(cursor);
            if (it != null)
            {
                for(VetCase vc : ret)
                {
                    if(it.getParent() == vc.getId()){
                        it.FFPresenterCs.ActivityParameters = EidssDatabaseFF.FFActivityParametersSelect(db, it.getObservation());
                        vc.animals.add(it);
                        break;
                    }
                }
            }
            rSp = cursor.moveToNext();
        }
        cursor.close();
        db.close();
    }

    //load lists of vet samples to cases in ret
    public void VetSamplesSelect(final List<VetCase> ret, final long id)
    {
        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor;
        if(id == 0)
            cursor = db.query("VetCaseSample", null, null, null, null, null, "id");
        else
            cursor = db.query("VetCaseSample", null, "idParent=" + id, null, null, null, "id");
        Boolean rSp = cursor.moveToFirst();
        while(rSp)
        {
            VetCaseSample it = VetCaseSample.FromCursor(cursor);
            if (it != null)
            {
                for(VetCase vc : ret)
                {
                    if(it.getParent() == vc.getId()){
                        vc.samples.add(it);
                        break;
                    }
                }
            }
            rSp = cursor.moveToNext();
        }
        cursor.close();
        db.close();
    }

    //load lists of human samples to cases in ret
    public void HumSamplesSelect(final List<HumanCase> ret, final long id)
    {
        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor;
        if(id == 0)
            cursor = db.query("HumanCaseSample", null, null, null, null, null, "id");
        else
            cursor = db.query("HumanCaseSample", null, "idParent=" + id, null, null, null, "id");
        Boolean rSp = cursor.moveToFirst();
        while(rSp)
        {
            HumanCaseSample it = HumanCaseSample.FromCursor(cursor);
            if (it != null)
            {
                for(HumanCase hc : ret)
                {
                    if(it.getParent() == hc.getId()){
                        hc.samples.add(it);
                        break;
                    }
                }
            }
            rSp = cursor.moveToNext();
        }
        cursor.close();
        db.close();
    }

    public List<ASSession> ASSessionSelect(int status)
    {
        List<ASSession> ret = new ArrayList<>();
        SQLiteDatabase db = getReadableDatabase();

        /*Cursor cursor = db.query("ASSession", null, null, null, null, null, "datCreateDate");*/
    	String[] args = new String[4];
    	args[0] = EidssUtils.getCurrentLanguage();
    	args[1] = args[0];
    	args[2] = args[0];
        args[3] = args[0];
        Cursor cursor = db.rawQuery(select_sql_assession, args);

        Boolean r = cursor.moveToLast();
        while(r)
        {
            ASSession vc = ASSession.FromCursor(cursor);
            if (vc != null && (status == 0 || vc.getStatus() == status))
            {
                ret.add(vc);
            }
            r = cursor.moveToPrevious();
        }
        cursor.close();
        db.close();
        return ret;
    }

    public List<ASSession> ASSessionSelect(final long id)
    {
        List<ASSession> ret = new ArrayList<>();

        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor = db.query("ASSession", null, null, null, null, null, "datCreateDate");
        Boolean r = cursor.moveToFirst();
        while(r)
        {
            ASSession vc = ASSession.FromCursor(cursor);
            if (vc != null && (id == 0 || vc.getId() == id)) {
                ret.add(vc);
            }
            r = cursor.moveToNext();
        }
        cursor.close();

        if(ret.size() > 0) {
            EidssDatabaseASSamples.ASSamplesSelect(db, ret, id);
        }

        db.close();

        if(ret.size() > 0) {
            ASDiseasesSelect(ret, id);
            EidssDatabaseFarm.FarmsSelect(this, ret, id);
        }

        return ret;
    }

    public void ASDiseasesSelect(final List<ASSession> ret, final long id)
    {
        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor;
        if(id == 0) {
            cursor = db.query("ASDisease", null, null, null, null, null, "id");
            Boolean rSp = cursor.moveToFirst();
            while(rSp)
            {
                ASDisease it = ASDisease.FromCursor(cursor);
                if (it != null)
                {
                    for(ASSession vc : ret)
                    {
                        if (vc.getMonitoringSession() == 0){
                            if (it.getParent() == vc.getId()) {
                                vc.asDiseases.add(it);
                                break;
                            }
                        } else {
                            if (it.getMonitoringSession() == vc.getMonitoringSession()) {
                                vc.asDiseases.add(it);
                                break;
                            }
                        }
                    }
                }
                rSp = cursor.moveToNext();
            }
            cursor.close();
        }
        else {
            for(ASSession vc : ret)
            {
                cursor = db.rawQuery(select_sql_as_diseases, new String [] {String.valueOf(vc.getId())} );
                Boolean rSp = cursor.moveToFirst();
                while(rSp)
                {
                    ASDisease it = ASDisease.FromCursor(cursor);
                    vc.asDiseases.add(it);
                    rSp = cursor.moveToNext();
                }
                cursor.close();
            }
        }
        db.close();
    }



    private long GetTemplate(final long idDeterminant, final long idFormType, SQLiteDatabase db){
        String request = select_sql_ff_determinants;
        String[] args = new String[]{String.valueOf(idDeterminant), String.valueOf(idFormType)};
        if (idDeterminant == 0) {
            request = select_sql_ff_determinants_simple;
            args = new String[]{String.valueOf(idFormType)};
        }
        Cursor cursor = db.rawQuery(request, args);
        Boolean rSp = cursor.moveToFirst();
        long idFormTemplate = 0;
        if (rSp)
        {
            idFormTemplate = cursor.getLong(cursor.getColumnIndex("idfsFormTemplate"));
        }
        cursor.close();
        return idFormTemplate;
    }

    public ArrayList<FFTemplateElement> FFTemplateElementsSelect(final long idDeterminant, final long idFormType)
    {
        ArrayList<FFTemplateElement> ret = new ArrayList<>();
        if (idFormType == 0) return ret;

        SQLiteDatabase db = getReadableDatabase();
        long idFormTemplate = GetTemplate(idDeterminant, idFormType, db);
        if (idDeterminant > 0 && idFormTemplate == 0){
            idFormTemplate = GetTemplate(0, idFormType, db);
        }

        if (idFormTemplate == 0) return ret;
        //
        Cursor cursor = db.rawQuery(select_sql_ff_template_elements, new String[]{String.valueOf(idFormTemplate)});
        Boolean rSp = cursor.moveToFirst();
        while(rSp) {
            FFTemplateElement te = FFTemplateElement.FromCursor(cursor);
            ret.add(te);
            rSp = cursor.moveToNext();
        }
        cursor.close();
            db.close();
        return ret;
    }



    private long ObservationSave(SQLiteDatabase db, long idfObservation, long idfsFormTemplate){
        long result = 0;
        ContentValues cv = new ContentValues();
        cv.put("idfObservation", idfObservation);
        cv.put("idfsFormTemplate", idfsFormTemplate);
        int affectedCount = db.update("Observation", cv, "idfObservation=?", new String[] {String.valueOf(idfObservation)});
        if (affectedCount == 0){
            result = db.insert("Observation", null, cv);
        }
        return result;
    }

    private HumanCase HumanCaseInsertInternal(SQLiteDatabase db, HumanCase hc) {
        hc.setId(db.insert("HumanCase", null, hc.ContentValues()));
        for (HumanCaseSample sp: hc.samples){
            sp.setParent(hc.getId());
            sp.setId(db.insert("HumanCaseSample", null, sp.ContentValues()));
        }
        //save observation
        //save its FF
        HumanCaseSaveFF(db, hc);
        return hc;
    }

	public HumanCase HumanCaseInsert(HumanCase hc)
	{
    	SQLiteDatabase db = getWritableDatabase();
        db.beginTransaction();
        hc = RecalculateIdObservation(db, hc);
        HumanCaseInsertInternal(db, hc);
        db.setTransactionSuccessful();
        db.endTransaction();
        db.close();
	    return hc;
	}

    private VetCase VetCaseInsertInternal(SQLiteDatabase db, VetCase vc) {

        // root farm
        if (vc.getRootFarm() != 0){
            // update root farm
            EidssDatabaseFarm.updateRootFarm(db, vc);
        } else {
            // insert root farm
            long lNewFarmCount = EidssDatabaseFarm.NewFarmRootCount(db) + 1;
            vc.setRootFarm(-lNewFarmCount);
            EidssDatabaseFarm.insertRootFarm(db, vc);
        }

        vc.setId(db.insert("VetCase", null, vc.ContentValues()));

        EidssDatabaseSpecies.UpdateList(db, vc.species, vc.getId());

        for (Animal sp: vc.animals){
            sp.setParent(vc.getId());
            sp.setId(db.insert("Animal", null, sp.ContentValues()));
        }
        for (VetCaseSample sp: vc.samples){
            sp.setParent(vc.getId());
            sp.setSpeciesTypeFromAnimal(vc);
            sp.setId(db.insert("VetCaseSample", null, sp.ContentValues()));
        }
        //FF
        VetCaseSaveFF(db, vc);
        return vc;
    }
	public VetCase VetCaseInsert(VetCase vc)
	{
    	try{
	    	SQLiteDatabase db = getWritableDatabase();
	    	db.beginTransaction();

            vc = RecalculateIdObservation(db, vc);
            VetCaseInsertInternal(db, vc);

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


    private ASSession ASSessionInsertInternal(SQLiteDatabase db, ASSession as) {
        as.setId(db.insert("ASSession", null, as.ContentValues()));
        as.SetIdForAllChildren();
        for (ASDisease ad:as.asDiseases) {
            ad.setId(db.insert("ASDisease", null, ad.ContentValues()));
        }
        for (Farm f:as.farms) {
            if (f.getRootFarm() != 0){
                // update root farm
                EidssDatabaseFarm.updateRootFarm(db, f);
            } else {
                // insert root farm
                long lNewFarmCount = EidssDatabaseFarm.NewFarmRootCount(db) + 1;
                f.setRootFarm(-lNewFarmCount);
                EidssDatabaseFarm.insertRootFarm(db, f);
            }

            EidssDatabaseFarm.InsertFarm(db, f);
            EidssDatabaseSpecies.UpdateList(db, f.species, f.getId());
        }

        EidssDatabaseASSamples.UpdateList(db, as.asSamples, as.getId());

        as.setUnchanged();
        return as;
    }
    public ASSession ASSessionInsert(ASSession as)
    {
        try{
            SQLiteDatabase db = getWritableDatabase();
            db.beginTransaction();

            ASSessionInsertInternal(db, as);

            db.setTransactionSuccessful();
            db.endTransaction();
            db.close();
            return as;
        }
        catch(Exception e){
            e.printStackTrace();
            return null;
        }
    }

    private HumanCase HumanCaseSaveFF(SQLiteDatabase db, HumanCase hc){
        if (hc.FFModelCS != null) {
            ObservationSave(db, hc.getCSObservation(), hc.FFModelCS.getTemplate());
            hc.FFModelCS = FFActivityParameterUpdateInternal(db, hc.getCSObservation(), hc.FFModelCS);
        }
        if (hc.FFModelEpi != null) {
            ObservationSave(db, hc.getEpiObservation(), hc.FFModelEpi.getTemplate());
            hc.FFModelEpi = FFActivityParameterUpdateInternal(db, hc.getEpiObservation(), hc.FFModelEpi);
        }
        return hc;
    }

    private VetCase VetCaseSaveFF(SQLiteDatabase db, VetCase vc){
        long idObservation;

        if (vc.FFFarmEpi != null) {
            idObservation = vc.getObservationFarm();
            ObservationSave(db, idObservation, vc.FFFarmEpi.getTemplate());
            vc.FFFarmEpi = FFActivityParameterUpdateInternal(db, idObservation, vc.FFFarmEpi);
        }

        if (vc.IsLivestockCase() && vc.FFControlMeasures != null) {
            idObservation = vc.getObservation();
            ObservationSave(db, idObservation, vc.FFControlMeasures.getTemplate());
            vc.FFControlMeasures = FFActivityParameterUpdateInternal(db, idObservation, vc.FFControlMeasures);
        }

        for (Species sp: vc.species){
            idObservation = sp.getObservation();
            ObservationSave(db, idObservation, sp.FFPresenterCs.getTemplate());
            sp.FFPresenterCs = FFActivityParameterUpdateInternal(db, idObservation, sp.FFPresenterCs);
        }

        for (Animal it: vc.animals){
            idObservation = it.getObservation();
            ObservationSave(db, idObservation, it.FFPresenterCs.getTemplate());
            it.FFPresenterCs = FFActivityParameterUpdateInternal(db, idObservation, it.FFPresenterCs);
        }

        return vc;
    }

    private HumanCase HumanCaseUpdateInternal(SQLiteDatabase db, HumanCase hc)
    {
        db.replace("HumanCase", null, hc.ContentValues());

        //Samples
        for (HumanCaseSample sp:hc.samples) {
            sp.setParent(hc.getId());
            if(sp.getId() == 0)
                sp.setId(db.insert("HumanCaseSample", null, sp.ContentValues()));
            else if(sp.getChanged())
                db.update("HumanCaseSample", sp.ContentValues(), "id=?", new String[] {String.valueOf(sp.getId())});
        }

        // delete everything that is not in vc.samples
        SQLiteStatement s;
        s = db.compileStatement("select count(*) from HumanCaseSample where idParent=" + String.valueOf(hc.getId()));
        long nSp = s.simpleQueryForLong();

        if (nSp > hc.samples.size())	{
            String ids = "";
            for (HumanCaseSample sp:hc.samples) {
                if (sp.getId() != 0) {
                    if (ids.length() != 0) ids += ", ";
                    ids += Long.toString(sp.getId());
                }
            }
            if (ids.length() != 0)
                db.delete("HumanCaseSample", "idParent= "+String.valueOf(hc.getId())+" AND id NOT IN ("+ids+")", null);
            else
                db.delete("HumanCaseSample", "idParent= "+String.valueOf(hc.getId()), null);
        }

        //save its FF
        HumanCaseSaveFF(db, hc);
        hc.setUnchanged();
        return hc;
    }

    private FFModel FFActivityParameterUpdateInternal(SQLiteDatabase db, long idObservation, FFModel ff) {
        ff.SetObservation(idObservation);
        ArrayList<ContentValues> cvList = ff.GetActivityParametersContentValues();
        for(int i = 0; i < cvList.size(); i++){
            ActivityParameter ap = ff.GetActivityParameter(i);
            ContentValues cv = cvList.get(i);
            long id = 0;
            if (cv.containsKey("id")) id = Long.valueOf(String.valueOf(cv.get("id")));
            Boolean isEmpty = cv.get("strValue") == null;
            if(id == 0 && !isEmpty){
                ap.id = db.insert("FFActivityParameter", null, cv);
            }
            else if (isEmpty){
                db.delete("FFActivityParameter", "id=?", new String[] {String.valueOf(id)});
            }
            else{
                db.update("FFActivityParameter", cv, "id=?", new String[] {String.valueOf(id)});
            }
        }
        return ff;
    }

    private long RecalculateIdObservationRoutines(SQLiteDatabase db){
        Cursor cursor = db.rawQuery(select_sql_min_observation_id, null);
        long idObsLast = 0;
        if (cursor.moveToFirst()){
            idObsLast = cursor.getLong(cursor.getColumnIndex("MinValue"));
        }
        cursor.close();

        if (idObsLast > 0) idObsLast = 0; //we need fake IDs here
        return idObsLast;
    }

    private VetCase RecalculateIdObservation(SQLiteDatabase db, VetCase vc) {

        long idObsLast = RecalculateIdObservationRoutines(db);
        idObsLast--;
        if (vc.getObservation() == 0) vc.setObservation(idObsLast);
        idObsLast--;
        if (vc.getObservationFarm() == 0) vc.setObservationFarm(idObsLast);
        idObsLast--;
        for (Species sp : vc.species) {
            if (sp.getObservation() == 0) sp.setObservation(idObsLast);
            idObsLast--;
        }
        for (Animal an : vc.animals) {
            if (an.getObservation() == 0) an.setObservation(idObsLast);
            idObsLast--;
        }

        return vc;
    }

    private HumanCase RecalculateIdObservation(SQLiteDatabase db, HumanCase hc){
        if (hc.getCSObservation() == 0 || hc.getEpiObservation() == 0){
            long idObsLast = RecalculateIdObservationRoutines(db);
            hc.setCSObservation(idObsLast - 1);
            hc.setEpiObservation(idObsLast - 2);
        }
        return hc;
    }

    public HumanCase HumanCaseUpdate(HumanCase hc)
    {
    	SQLiteDatabase db = getWritableDatabase();
        hc = RecalculateIdObservation(db, hc);
        HumanCaseUpdateInternal(db, hc);
        db.close();
        return hc;
    }

    private void VetCaseUpdateInternal(SQLiteDatabase db, VetCase vc)
    {
        // root farm
        if (vc.getRootFarm() != 0){
            // update root farm
            EidssDatabaseFarm.updateRootFarm(db, vc);
        } else {
            // insert root farm
            long lNewFarmCount = EidssDatabaseFarm.NewFarmRootCount(db) + 1;
            vc.setRootFarm(-lNewFarmCount);
            EidssDatabaseFarm.insertRootFarm(db, vc);
        }

        db.update("VetCase", vc.ContentValues(), "id=?", new String[] {String.valueOf(vc.getId())});

        //Species
        EidssDatabaseSpecies.UpdateList(db, vc.species, vc.getId());

        SQLiteStatement s;
        long nSp;

        //Animals
        for (Animal sp:vc.animals) {
            sp.setParent(vc.getId());
            if(sp.getId() == 0)
                sp.setId(db.insert("Animal", null, sp.ContentValues()));
            else if(sp.getChanged())
                db.update("Animal", sp.ContentValues(), "id=?", new String[] {String.valueOf(sp.getId())});
        }

        // delete everything that is not in vc.animals
        s = db.compileStatement("select count(*) from Animal where idParent=" + String.valueOf(vc.getId()));
        nSp = s.simpleQueryForLong();

        if (nSp > vc.animals.size())	{
            String ids = "";
            for (Animal sp:vc.animals) {
                if (sp.getId() != 0) {
                    if (ids.length() != 0) ids += ", ";
                    ids += Long.toString(sp.getId());
                }
            }
            if (ids.length() != 0)
                db.delete("Animal", "idParent= "+String.valueOf(vc.getId())+" AND id NOT IN ("+ids+")", null);
            else
                db.delete("Animal", "idParent= "+String.valueOf(vc.getId()), null);
        }

        //Samples
        for (VetCaseSample sp:vc.samples) {
            sp.setParent(vc.getId());
            sp.setSpeciesTypeFromAnimal(vc);
            if(sp.getId() == 0)
                sp.setId(db.insert("VetCaseSample", null, sp.ContentValues()));
            else if(sp.getChanged())
                db.update("VetCaseSample", sp.ContentValues(), "id=?", new String[] {String.valueOf(sp.getId())});
        }

        // delete everything that is not in vc.samples
        s = db.compileStatement("select count(*) from VetCaseSample where idParent=" + String.valueOf(vc.getId()));
        nSp = s.simpleQueryForLong();

        if (nSp > vc.samples.size())	{
            String ids = "";
            for (VetCaseSample sp:vc.samples) {
                if (sp.getId() != 0) {
                    if (ids.length() != 0) ids += ", ";
                    ids += Long.toString(sp.getId());
                }
            }
            if (ids.length() != 0)
                db.delete("VetCaseSample", "idParent= "+String.valueOf(vc.getId())+" AND id NOT IN ("+ids+")", null);
            else
                db.delete("VetCaseSample", "idParent= "+String.valueOf(vc.getId()), null);
        }

        //FF
        VetCaseSaveFF(db, vc);

        vc.setUnchanged();
    }

    public void VetCaseUpdate(VetCase vc)
    {
    	SQLiteDatabase db = getWritableDatabase();
    	try{
	    	db.beginTransaction();
            vc = RecalculateIdObservation(db, vc);
            VetCaseUpdateInternal(db, vc);
	        db.setTransactionSuccessful();
		}
		catch(Exception e){
	        e.printStackTrace();
		}
    	finally {
            db.endTransaction();
	        db.close();
    	}
    }

    private void ASSessionUpdateOrInsertInternal(SQLiteDatabase db, ASSession as)
    {
        ASSession fnd = null;
        Cursor cursor = db.query("ASSession", null, "idfMonitoringSession=" + as.getMonitoringSession(), null, null, null, null);
        Boolean r = cursor.moveToLast();
        if(r){
            fnd = ASSession.FromCursor(cursor);
        }
        cursor.close();

        if (fnd != null){
            if (fnd.getStatus() == CaseStatus.SYNCHRONIZED){
                as.setId(fnd.getId());
                db.update("ASSession", as.ContentValues(), "idfMonitoringSession=?", new String[]{String.valueOf(as.getMonitoringSession())});
            }
        } else {
            as.setId(db.insert("ASSession", null, as.ContentValues()));
        }

        db.delete("ASDisease", "idfMonitoringSession=?", new String[]{String.valueOf(as.getMonitoringSession())});
        as.SetIdForAllChildren();
        for (ASDisease ad:as.asDiseases) {
            ad.setId(db.insert("ASDisease", null, ad.ContentValues()));
        }

        for (Farm f:as.farms) {
            EidssDatabaseFarm.UpdateOrInsertFarm(db, f);
        }
    }


    private void ASSessionUpdateInternal(SQLiteDatabase db, ASSession as) {
        db.update("ASSession", as.ContentValues(), "id=?", new String[]{String.valueOf(as.getId())});
        db.delete("ASDisease", "idParent=?", new String[]{String.valueOf(as.getId())});
        as.SetIdForAllChildren();
        for (ASDisease ad:as.asDiseases) {
            ad.setId(db.insert("ASDisease", null, ad.ContentValues()));
        }

        for (Farm f:as.farms) {
            if (f.getRootFarm() != 0){
                // update root farm
                EidssDatabaseFarm.updateRootFarm(db, f);
            } else {
                // insert root farm
                long lNewFarmCount = EidssDatabaseFarm.NewFarmRootCount(db) + 1;
                f.setRootFarm(-lNewFarmCount);
                EidssDatabaseFarm.insertRootFarm(db, f);
            }

            if (f.getId() == 0){
                // insert
                f.setId(db.insert("Farm", null, f.ContentValues()));
            } else {
                // update
                db.update("Farm", f.ContentValues(), "id=?", new String[]{String.valueOf(f.getId())});
            }

            //Species
            EidssDatabaseSpecies.UpdateList(db, f.species, f.getId());
        }

        // delete everything that is not in as.farms
        SQLiteStatement s = db.compileStatement("select count(*) from Farm where idParent=" + String.valueOf(as.getId()));
        long nSp = s.simpleQueryForLong();

        if (nSp > as.farms.size())	{
            String ids = "";
            for (Farm f:as.farms) {
                if (f.getId() != 0) {
                    if (ids.length() != 0) ids += ", ";
                    ids += Long.toString(f.getId());
                }
            }
            if (ids.length() != 0)
                db.delete("Farm", "ifnull(blnIsRoot,0)=0 and idParent= "+String.valueOf(as.getId())+" AND id NOT IN ("+ids+")", null);
            else
                db.delete("Farm", "ifnull(blnIsRoot,0)=0 and idParent= "+String.valueOf(as.getId()), null);
        }

        EidssDatabaseASSamples.UpdateList(db, as.asSamples, as.getId());

        as.setUnchanged();
    }

    public long NewAnimalCount(){
        SQLiteDatabase db = getReadableDatabase();
        SQLiteStatement s = db.compileStatement("select count(*) from ASSample where ifnull(idfAnimal,0)<=0");
        long ret = s.simpleQueryForLong();
        db.close();
        return ret;
    }

    public void ASSessionUpdate(ASSession as)
    {
        SQLiteDatabase db = getWritableDatabase();
        try{
            db.beginTransaction();
            ASSessionUpdateInternal(db, as);
            db.setTransactionSuccessful();
        }
        catch(Exception e){
            e.printStackTrace();
        }
        finally {
            db.endTransaction();
            db.close();
        }
    }

    public Boolean HumanCaseDelete(final Long[] idd)
    {
        SQLiteDatabase db = getWritableDatabase();
        try {
            db.beginTransaction();

            for (long id : idd) {
                String[] ids = new String[]{String.valueOf(id)};
                db.delete("HumanCaseSample", "idParent in (SELECT id FROM VetCase where id = ?)", ids);
    	        db.delete("HumanCase", "id = ?", ids);
            }

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

    public Boolean VetCaseDelete(final Long[] idd)
    {
    	SQLiteDatabase db = getWritableDatabase();
    	try{
	    	db.beginTransaction();

            for (long id : idd) {
                String[] ids = new String[]{String.valueOf(id)};
                db.delete("Species", "idParent in (SELECT id FROM VetCase where id = ?)", ids);
                db.delete("Animal", "idParent in (SELECT id FROM VetCase where id = ?)", ids);
                db.delete("VetCaseSample", "idParent in (SELECT id FROM VetCase where id = ?)", ids);
                db.delete("VetCase", "id = ?", ids);
            }
	    	
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

    public Boolean ASSessionDelete(final Long[] idd)
    {
        SQLiteDatabase db = getWritableDatabase();
        try{
            db.beginTransaction();

            for (long id : idd) {
                String[] ids = new String[]{String.valueOf(id)};
                db.delete("Farm", "ifnull(blnIsRoot,0)=0 and idParent = ?", ids);
                db.delete("ASDisease", "idParent = ?", ids);
                db.delete("ASSession", "id = ?", ids);
            }

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
            db.delete("HumanCaseSample", "idParent in (SELECT id FROM VetCase where intStatus = ?)", ids);
	    	db.delete("HumanCase", "intStatus = ?", ids);
            db.delete("Species", "idParent in (SELECT id FROM VetCase where intStatus = ?)", ids);
            db.delete("Animal", "idParent in (SELECT id FROM VetCase where intStatus = ?)", ids);
            db.delete("VetCaseSample", "idParent in (SELECT id FROM VetCase where intStatus = ?)", ids);
	    	db.delete("VetCase", "intStatus = ?", ids);
            db.delete("ASSession", "intStatus = ?", ids);

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
