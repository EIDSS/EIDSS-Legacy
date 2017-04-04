using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class HumanCaseInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public String uidOfflineCaseID { get; set; }
      public long idfCase { get; set; }
      public long idfEpiObservation { get; set; }
      public long idfCSObservation { get; set; }
      public DateTime datModificationDate { get; set; }
      public String strCaseID { get; set; }
      public String strLocalIdentifier { get; set; }
      public DateTime datCompletionPaperFormDate { get; set; }
      public long idfsTentativeDiagnosis { get; set; }
      public DateTime datTentativeDiagnosisDate { get; set; }
      public DateTime datNotificationDate { get; set; }
      public long idfSentByOffice { get; set; }
      public String strSentByPerson { get; set; }
      public long idfReceivedByOffice { get; set; }
      public String strReceivedByPerson { get; set; }
      public long idfInvestigatedByOffice { get; set; }
      public String strEpidemiologistsName { get; set; }
      public DateTime datInvestigationStartDate { get; set; }
      public String strFamilyName { get; set; }
      public String strFirstName { get; set; }
      public String strSecondName { get; set; }
      public DateTime datDateofBirth { get; set; }
      public int intPatientAge { get; set; }
      public long idfsHumanAgeType { get; set; }
      public long idfsHumanGender { get; set; }
      public long idfsPersonIDType { get; set; }
      public String strPersonID { get; set; }
      public long idfsNationality { get; set; }
      public long idfsRegionCurrentResidence { get; set; }
      public long idfsRayonCurrentResidence { get; set; }
      public long idfsSettlementCurrentResidence { get; set; }
      public String strStreetName { get; set; }
      public String strBuilding { get; set; }
      public String strHouse { get; set; }
      public String strApartment { get; set; }
      public String strPostCode { get; set; }
      public double dblLongitude { get; set; }
      public double dblLatitude { get; set; }
      public String strHomePhone { get; set; }
      public String strPermanentResidencePhone { get; set; }
      public String strEmployerName { get; set; }
      public String strWorkPhone { get; set; }
      public long idfsFinalState { get; set; }
      public long idfsHospitalizationStatus { get; set; }
      public long idfHospital { get; set; }
      public long idfsInitialCaseStatus { get; set; }
      public DateTime datOnSetDate { get; set; }
      public DateTime datExposureDate { get; set; }
      public long idfSoughtCareFacility { get; set; }
      public DateTime datFirstSoughtCareDate { get; set; }
      public long idfsYNHospitalization { get; set; }
      public String strHospitalizationPlace { get; set; }
      public DateTime datHospitalizationDate { get; set; }
      public String strComment { get; set; }
      public long idfsYNSpecimenCollected { get; set; }
      public long idfsNotCollectedReason { get; set; }
      public long idfsYNTestsConducted { get; set; }
      public long idfsFinalCaseStatus { get; set; }
      public DateTime datFinalCaseClassificationDate { get; set; }
      public long idfsFinalDiagnosis { get; set; }
      public DateTime datFinalDiagnosisDate { get; set; }
      public bool blnClinicalDiagBasis { get; set; }
      public bool blnEpiDiagBasis { get; set; }
      public bool blnLabDiagBasis { get; set; }
      public long idfsOutcome { get; set; }
      public long idfsYNRelatedToOutbreak { get; set; }

    public HumanCaseInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          uidOfflineCaseID = GetString(xml, "uidOfflineCaseID", uidOfflineCaseID);
          idfCase = GetLong(xml, "idfCase", idfCase);
          idfEpiObservation = GetLong(xml, "idfEpiObservation", idfEpiObservation);
          idfCSObservation = GetLong(xml, "idfCSObservation", idfCSObservation);
          datModificationDate = GetDateTime(xml, "datModificationDate", datModificationDate);
          strCaseID = GetString(xml, "strCaseID", strCaseID);
          strLocalIdentifier = GetString(xml, "strLocalIdentifier", strLocalIdentifier);
          datCompletionPaperFormDate = GetDateTime(xml, "datCompletionPaperFormDate", datCompletionPaperFormDate);
          idfsTentativeDiagnosis = GetLong(xml, "idfsTentativeDiagnosis", idfsTentativeDiagnosis);
          datTentativeDiagnosisDate = GetDateTime(xml, "datTentativeDiagnosisDate", datTentativeDiagnosisDate);
          datNotificationDate = GetDateTime(xml, "datNotificationDate", datNotificationDate);
          idfSentByOffice = GetLong(xml, "idfSentByOffice", idfSentByOffice);
          strSentByPerson = GetString(xml, "strSentByPerson", strSentByPerson);
          idfReceivedByOffice = GetLong(xml, "idfReceivedByOffice", idfReceivedByOffice);
          strReceivedByPerson = GetString(xml, "strReceivedByPerson", strReceivedByPerson);
          idfInvestigatedByOffice = GetLong(xml, "idfInvestigatedByOffice", idfInvestigatedByOffice);
          strEpidemiologistsName = GetString(xml, "strEpidemiologistsName", strEpidemiologistsName);
          datInvestigationStartDate = GetDateTime(xml, "datInvestigationStartDate", datInvestigationStartDate);
          strFamilyName = GetString(xml, "strFamilyName", strFamilyName);
          strFirstName = GetString(xml, "strFirstName", strFirstName);
          strSecondName = GetString(xml, "strSecondName", strSecondName);
          datDateofBirth = GetDateTime(xml, "datDateofBirth", datDateofBirth);
          intPatientAge = GetInt(xml, "intPatientAge", intPatientAge);
          idfsHumanAgeType = GetLong(xml, "idfsHumanAgeType", idfsHumanAgeType);
          idfsHumanGender = GetLong(xml, "idfsHumanGender", idfsHumanGender);
          idfsPersonIDType = GetLong(xml, "idfsPersonIDType", idfsPersonIDType);
          strPersonID = GetString(xml, "strPersonID", strPersonID);
          idfsNationality = GetLong(xml, "idfsNationality", idfsNationality);
          idfsRegionCurrentResidence = GetLong(xml, "idfsRegionCurrentResidence", idfsRegionCurrentResidence);
          idfsRayonCurrentResidence = GetLong(xml, "idfsRayonCurrentResidence", idfsRayonCurrentResidence);
          idfsSettlementCurrentResidence = GetLong(xml, "idfsSettlementCurrentResidence", idfsSettlementCurrentResidence);
          strStreetName = GetString(xml, "strStreetName", strStreetName);
          strBuilding = GetString(xml, "strBuilding", strBuilding);
          strHouse = GetString(xml, "strHouse", strHouse);
          strApartment = GetString(xml, "strApartment", strApartment);
          strPostCode = GetString(xml, "strPostCode", strPostCode);
          dblLongitude = GetDouble(xml, "dblLongitude", dblLongitude);
          dblLatitude = GetDouble(xml, "dblLatitude", dblLatitude);
          strHomePhone = GetString(xml, "strHomePhone", strHomePhone);
          strPermanentResidencePhone = GetString(xml, "strPermanentResidencePhone", strPermanentResidencePhone);
          strEmployerName = GetString(xml, "strEmployerName", strEmployerName);
          strWorkPhone = GetString(xml, "strWorkPhone", strWorkPhone);
          idfsFinalState = GetLong(xml, "idfsFinalState", idfsFinalState);
          idfsHospitalizationStatus = GetLong(xml, "idfsHospitalizationStatus", idfsHospitalizationStatus);
          idfHospital = GetLong(xml, "idfHospital", idfHospital);
          idfsInitialCaseStatus = GetLong(xml, "idfsInitialCaseStatus", idfsInitialCaseStatus);
          datOnSetDate = GetDateTime(xml, "datOnSetDate", datOnSetDate);
          datExposureDate = GetDateTime(xml, "datExposureDate", datExposureDate);
          idfSoughtCareFacility = GetLong(xml, "idfSoughtCareFacility", idfSoughtCareFacility);
          datFirstSoughtCareDate = GetDateTime(xml, "datFirstSoughtCareDate", datFirstSoughtCareDate);
          idfsYNHospitalization = GetLong(xml, "idfsYNHospitalization", idfsYNHospitalization);
          strHospitalizationPlace = GetString(xml, "strHospitalizationPlace", strHospitalizationPlace);
          datHospitalizationDate = GetDateTime(xml, "datHospitalizationDate", datHospitalizationDate);
          strComment = GetString(xml, "strComment", strComment);
          idfsYNSpecimenCollected = GetLong(xml, "idfsYNSpecimenCollected", idfsYNSpecimenCollected);
          idfsNotCollectedReason = GetLong(xml, "idfsNotCollectedReason", idfsNotCollectedReason);
          idfsYNTestsConducted = GetLong(xml, "idfsYNTestsConducted", idfsYNTestsConducted);
          idfsFinalCaseStatus = GetLong(xml, "idfsFinalCaseStatus", idfsFinalCaseStatus);
          datFinalCaseClassificationDate = GetDateTime(xml, "datFinalCaseClassificationDate", datFinalCaseClassificationDate);
          idfsFinalDiagnosis = GetLong(xml, "idfsFinalDiagnosis", idfsFinalDiagnosis);
          datFinalDiagnosisDate = GetDateTime(xml, "datFinalDiagnosisDate", datFinalDiagnosisDate);
          blnClinicalDiagBasis = GetBool(xml, "blnClinicalDiagBasis", blnClinicalDiagBasis);
          blnEpiDiagBasis = GetBool(xml, "blnEpiDiagBasis", blnEpiDiagBasis);
          blnLabDiagBasis = GetBool(xml, "blnLabDiagBasis", blnLabDiagBasis);
          idfsOutcome = GetLong(xml, "idfsOutcome", idfsOutcome);
          idfsYNRelatedToOutbreak = GetLong(xml, "idfsYNRelatedToOutbreak", idfsYNRelatedToOutbreak);
        }
    }
}
