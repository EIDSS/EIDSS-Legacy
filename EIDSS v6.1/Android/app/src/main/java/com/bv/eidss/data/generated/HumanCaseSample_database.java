package com.bv.eidss.data.generated;
 
public class HumanCaseSample_database {
public static final String create_sql =
"CREATE TABLE HumanCaseSample\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", uidOfflineCaseID TEXT NULL\n" + 
", idParent BIGINT NULL\n" + 
", idfMaterial BIGINT NULL\n" + 
", idfsSampleType BIGINT NULL\n" + 
", strFieldBarcode TEXT NULL\n" + 
", datFieldCollectionDate DATE NULL\n" + 
", idfSendToOffice BIGINT NULL\n" + 
", datFieldSentDate DATE NULL\n" + 
")";
}
