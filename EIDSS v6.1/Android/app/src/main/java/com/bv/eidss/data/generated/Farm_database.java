package com.bv.eidss.data.generated;
 
public class Farm_database {
public static final String create_sql =
"CREATE TABLE Farm\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", intRowStatus INT NULL\n" + 
", uidOfflineCaseID TEXT NULL\n" + 
", idParent BIGINT NULL\n" + 
", idfFarm BIGINT NULL\n" + 
", idfsHerd BIGINT NULL\n" + 
", blnIsRoot INT NULL\n" + 
", strFarmName TEXT NULL\n" + 
", strFarmCode TEXT NULL\n" + 
", idfRootFarm BIGINT NULL\n" + 
", strOwnerLastName TEXT NULL\n" + 
", strOwnerFirstName TEXT NULL\n" + 
", strOwnerMiddleName TEXT NULL\n" + 
", strPhone TEXT NULL\n" + 
", strFax TEXT NULL\n" + 
", strEmail TEXT NULL\n" + 
", idfsRegion BIGINT NULL\n" + 
", idfsRayon BIGINT NULL\n" + 
", idfsSettlement BIGINT NULL\n" + 
", strStreetName TEXT NULL\n" + 
", strBuilding TEXT NULL\n" + 
", strHouse TEXT NULL\n" + 
", strApartment TEXT NULL\n" + 
", strPostCode TEXT NULL\n" + 
", dblLongitude  NULL\n" + 
", dblLatitude  NULL\n" + 
")";
}
