package com.bv.eidss.data.generated;
 
public class ASSession_database {
public static final String create_sql =
"CREATE TABLE ASSession\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", uidOfflineCaseID TEXT NULL\n" + 
", datModificationDate DATE NULL\n" + 
", strMonitoringSessionID TEXT NULL\n" + 
", idfMonitoringSession BIGINT NULL\n" + 
", idfsMonitoringSessionStatus BIGINT NULL\n" + 
", datStartDate DATE NULL\n" + 
", datEndDate DATE NULL\n" + 
", idfCampaign BIGINT NULL\n" + 
", idfsCampaignType BIGINT NULL\n" + 
", idfsRegion BIGINT NULL\n" + 
", idfsRayon BIGINT NULL\n" + 
", idfsSettlement BIGINT NULL\n" + 
")";
}
