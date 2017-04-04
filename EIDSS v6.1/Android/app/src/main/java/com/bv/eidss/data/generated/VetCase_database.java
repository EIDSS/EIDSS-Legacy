package com.bv.eidss.data.generated;
 
public class VetCase_database {
public static final String create_sql =
"CREATE TABLE VetCase\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", uidOfflineCaseID TEXT NULL\n" + 
", idfCase BIGINT NULL\n" + 
", idfsHerd BIGINT NULL\n" + 
", idfsFormTemplate BIGINT NULL\n" + 
", idfObservation BIGINT NULL\n" + 
", idfObservationFarm BIGINT NULL\n" + 
", datModificationDate DATE NULL\n" + 
", idfCaseType BIGINT NULL\n" + 
", strCaseID TEXT NULL\n" + 
", strLocalIdentifier TEXT NULL\n" + 
", idfsCaseReportType BIGINT NULL\n" + 
", idfsTentativeDiagnosis BIGINT NULL\n" + 
", datTentativeDiagnosisDate DATE NULL\n" + 
", datReportDate DATE NULL\n" + 
", strSentByOffice TEXT NULL\n" + 
", strSentByPerson TEXT NULL\n" + 
", idfInvestigatedByPerson BIGINT NULL\n" + 
", datAssignedDate DATE NULL\n" + 
", datInvestigationDate DATE NULL\n" + 
", idfsFinalCaseStatus BIGINT NULL\n" + 
", strFinalDiagnosis TEXT NULL\n" + 
", datFinalDiagnosisDate DATE NULL\n" + 
", strComment TEXT NULL\n" + 
", idfsYNTestsConducted BIGINT NULL\n" + 
", idfFarm BIGINT NULL\n" + 
", strFarmName TEXT NULL\n" + 
", strFarmCode TEXT NULL\n" + 
", idfRootFarm BIGINT NULL\n" + 
", strOwnerLastName TEXT NULL\n" + 
", strOwnerFirstName TEXT NULL\n" + 
", strOwnerMiddleName TEXT NULL\n" + 
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
", strPhone TEXT NULL\n" + 
")";
}
