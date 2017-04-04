package com.bv.eidss.data.generated;
 
public class ASSample_database {
public static final String create_sql =
"CREATE TABLE ASSample\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", uidOfflineCaseID TEXT NULL\n" + 
", idParent BIGINT NULL\n" + 
", idfMonitoringSession BIGINT NULL\n" + 
", idfFarm BIGINT NULL\n" + 
", idfsSpeciesType BIGINT NULL\n" + 
", idfAnimal BIGINT NULL\n" + 
", strAnimalCode TEXT NULL\n" + 
", idfsAnimalAge BIGINT NULL\n" + 
", strColor TEXT NULL\n" + 
", idfsAnimalGender BIGINT NULL\n" + 
", strName TEXT NULL\n" + 
", strDescription TEXT NULL\n" + 
", idfMaterial BIGINT NULL\n" + 
", idfsSampleType BIGINT NULL\n" + 
", strFieldBarcode TEXT NULL\n" + 
", datFieldCollectionDate DATE NULL\n" + 
", idfSendToOffice BIGINT NULL\n" + 
")";
}
