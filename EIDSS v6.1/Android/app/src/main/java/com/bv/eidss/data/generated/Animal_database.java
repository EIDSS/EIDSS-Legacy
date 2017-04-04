package com.bv.eidss.data.generated;
 
public class Animal_database {
public static final String create_sql =
"CREATE TABLE Animal\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", uidOfflineCaseID TEXT NULL\n" + 
", idParent BIGINT NULL\n" + 
", idfHerd BIGINT NULL\n" + 
", idfAnimal BIGINT NULL\n" + 
", idfsSpeciesType BIGINT NULL\n" + 
", strAnimalCode TEXT NULL\n" + 
", idfsAnimalAge BIGINT NULL\n" + 
", idfsAnimalGender BIGINT NULL\n" + 
", idfsAnimalCondition BIGINT NULL\n" + 
", idfObservation BIGINT NULL\n" + 
")";
}
