package com.bv.eidss.data.generated;
 
public class ASDisease_database {
public static final String create_sql =
"CREATE TABLE ASDisease\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", idParent BIGINT NULL\n" + 
", idfMonitoringSession BIGINT NULL\n" + 
", idfCampaign BIGINT NULL\n" + 
", idfsDiagnosis BIGINT NULL\n" + 
", idfsSpeciesType BIGINT NULL\n" + 
", idfsSampleType BIGINT NULL\n" + 
")";
}
