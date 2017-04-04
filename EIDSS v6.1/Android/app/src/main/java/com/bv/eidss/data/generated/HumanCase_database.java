package com.bv.eidss.data.generated;
 
public class HumanCase_database {
public static final String create_sql =
"CREATE TABLE HumanCase\n" +
"(\n" + // system fields
"  id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE\n" +
", strLastSynError TEXT NULL\n" +
", intStatus INT NULL\n" +
", intChanged INT NULL\n" +
", datCreateDate DATE NULL\n" +
"\n" + // case fields
", uidOfflineCaseID TEXT NULL\n" + 
", idfCase BIGINT NULL\n" + 
", idfEpiObservation BIGINT NULL\n" + 
", idfCSObservation BIGINT NULL\n" + 
", datModificationDate DATE NULL\n" + 
", strCaseID TEXT NULL\n" + 
", strLocalIdentifier TEXT NULL\n" + 
", datCompletionPaperFormDate DATE NULL\n" + 
", idfsTentativeDiagnosis BIGINT NULL\n" + 
", datTentativeDiagnosisDate DATE NULL\n" + 
", datNotificationDate DATE NULL\n" + 
", idfSentByOffice BIGINT NULL\n" + 
", strSentByPerson TEXT NULL\n" + 
", idfReceivedByOffice BIGINT NULL\n" + 
", strReceivedByPerson TEXT NULL\n" + 
", idfInvestigatedByOffice BIGINT NULL\n" + 
", strEpidemiologistsName TEXT NULL\n" + 
", datInvestigationStartDate DATE NULL\n" + 
", strFamilyName TEXT NULL\n" + 
", strFirstName TEXT NULL\n" + 
", strSecondName TEXT NULL\n" + 
", datDateofBirth DATE NULL\n" + 
", intPatientAge INT NULL\n" + 
", idfsHumanAgeType BIGINT NULL\n" + 
", idfsHumanGender BIGINT NULL\n" + 
", idfsPersonIDType BIGINT NULL\n" + 
", strPersonID TEXT NULL\n" + 
", idfsNationality BIGINT NULL\n" + 
", idfsRegionCurrentResidence BIGINT NULL\n" + 
", idfsRayonCurrentResidence BIGINT NULL\n" + 
", idfsSettlementCurrentResidence BIGINT NULL\n" + 
", strStreetName TEXT NULL\n" + 
", strBuilding TEXT NULL\n" + 
", strHouse TEXT NULL\n" + 
", strApartment TEXT NULL\n" + 
", strPostCode TEXT NULL\n" + 
", dblLongitude  NULL\n" + 
", dblLatitude  NULL\n" + 
", strHomePhone TEXT NULL\n" + 
", strPermanentResidencePhone TEXT NULL\n" + 
", strEmployerName TEXT NULL\n" + 
", strWorkPhone TEXT NULL\n" + 
", idfsFinalState BIGINT NULL\n" + 
", idfsHospitalizationStatus BIGINT NULL\n" + 
", idfHospital BIGINT NULL\n" + 
", idfsInitialCaseStatus BIGINT NULL\n" + 
", datOnSetDate DATE NULL\n" + 
", datExposureDate DATE NULL\n" + 
", idfSoughtCareFacility BIGINT NULL\n" + 
", datFirstSoughtCareDate DATE NULL\n" + 
", idfsYNHospitalization BIGINT NULL\n" + 
", strHospitalizationPlace TEXT NULL\n" + 
", datHospitalizationDate DATE NULL\n" + 
", strComment TEXT NULL\n" + 
", idfsYNSpecimenCollected BIGINT NULL\n" + 
", idfsNotCollectedReason BIGINT NULL\n" + 
", idfsYNTestsConducted BIGINT NULL\n" + 
", idfsFinalCaseStatus BIGINT NULL\n" + 
", datFinalCaseClassificationDate DATE NULL\n" + 
", idfsFinalDiagnosis BIGINT NULL\n" + 
", datFinalDiagnosisDate DATE NULL\n" + 
", blnClinicalDiagBasis INT NULL\n" + 
", blnEpiDiagBasis INT NULL\n" + 
", blnLabDiagBasis INT NULL\n" + 
", idfsOutcome BIGINT NULL\n" + 
", idfsYNRelatedToOutbreak BIGINT NULL\n" + 
")";
}
