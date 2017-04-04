package com.bv.eidss.data.generated;
 
public class Species_database {
public static final String create_sql =
"CREATE TABLE Species\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", idParent BIGINT NULL\n" + 
", idfsFormTemplate BIGINT NULL\n" + 
", idfObservation BIGINT NULL\n" + 
", idfsSpeciesType BIGINT NULL\n" + 
", intTotalAnimalQty INT NULL\n" + 
", intDeadAnimalQty INT NULL\n" + 
", intSickAnimalQty INT NULL\n" + 
", strNote TEXT NULL\n" + 
", intAverageAge INT NULL\n" + 
", datStartOfSignsDate DATE NULL\n" + 
")";
}
