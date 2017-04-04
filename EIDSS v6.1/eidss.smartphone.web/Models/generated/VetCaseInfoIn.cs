using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class VetCaseInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public String uidOfflineCaseID { get; set; }
      public long idfCase { get; set; }
      public long idfsHerd { get; set; }
      public long idfsFormTemplate { get; set; }
      public long idfObservation { get; set; }
      public long idfObservationFarm { get; set; }
      public DateTime datModificationDate { get; set; }
      public long idfCaseType { get; set; }
      public String strCaseID { get; set; }
      public String strLocalIdentifier { get; set; }
      public long idfsCaseReportType { get; set; }
      public long idfsTentativeDiagnosis { get; set; }
      public DateTime datTentativeDiagnosisDate { get; set; }
      public DateTime datReportDate { get; set; }
      public String strSentByOffice { get; set; }
      public String strSentByPerson { get; set; }
      public long idfInvestigatedByPerson { get; set; }
      public DateTime datAssignedDate { get; set; }
      public DateTime datInvestigationDate { get; set; }
      public long idfsFinalCaseStatus { get; set; }
      public String strFinalDiagnosis { get; set; }
      public DateTime datFinalDiagnosisDate { get; set; }
      public String strComment { get; set; }
      public long idfsYNTestsConducted { get; set; }
      public long idfFarm { get; set; }
      public String strFarmName { get; set; }
      public String strFarmCode { get; set; }
      public long idfRootFarm { get; set; }
      public String strOwnerLastName { get; set; }
      public String strOwnerFirstName { get; set; }
      public String strOwnerMiddleName { get; set; }
      public long idfsRegion { get; set; }
      public long idfsRayon { get; set; }
      public long idfsSettlement { get; set; }
      public String strStreetName { get; set; }
      public String strBuilding { get; set; }
      public String strHouse { get; set; }
      public String strApartment { get; set; }
      public String strPostCode { get; set; }
      public double dblLongitude { get; set; }
      public double dblLatitude { get; set; }
      public String strPhone { get; set; }

    public VetCaseInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          uidOfflineCaseID = GetString(xml, "uidOfflineCaseID", uidOfflineCaseID);
          idfCase = GetLong(xml, "idfCase", idfCase);
          idfsHerd = GetLong(xml, "idfsHerd", idfsHerd);
          idfsFormTemplate = GetLong(xml, "idfsFormTemplate", idfsFormTemplate);
          idfObservation = GetLong(xml, "idfObservation", idfObservation);
          idfObservationFarm = GetLong(xml, "idfObservationFarm", idfObservationFarm);
          datModificationDate = GetDateTime(xml, "datModificationDate", datModificationDate);
          idfCaseType = GetLong(xml, "idfCaseType", idfCaseType);
          strCaseID = GetString(xml, "strCaseID", strCaseID);
          strLocalIdentifier = GetString(xml, "strLocalIdentifier", strLocalIdentifier);
          idfsCaseReportType = GetLong(xml, "idfsCaseReportType", idfsCaseReportType);
          idfsTentativeDiagnosis = GetLong(xml, "idfsTentativeDiagnosis", idfsTentativeDiagnosis);
          datTentativeDiagnosisDate = GetDateTime(xml, "datTentativeDiagnosisDate", datTentativeDiagnosisDate);
          datReportDate = GetDateTime(xml, "datReportDate", datReportDate);
          strSentByOffice = GetString(xml, "strSentByOffice", strSentByOffice);
          strSentByPerson = GetString(xml, "strSentByPerson", strSentByPerson);
          idfInvestigatedByPerson = GetLong(xml, "idfInvestigatedByPerson", idfInvestigatedByPerson);
          datAssignedDate = GetDateTime(xml, "datAssignedDate", datAssignedDate);
          datInvestigationDate = GetDateTime(xml, "datInvestigationDate", datInvestigationDate);
          idfsFinalCaseStatus = GetLong(xml, "idfsFinalCaseStatus", idfsFinalCaseStatus);
          strFinalDiagnosis = GetString(xml, "strFinalDiagnosis", strFinalDiagnosis);
          datFinalDiagnosisDate = GetDateTime(xml, "datFinalDiagnosisDate", datFinalDiagnosisDate);
          strComment = GetString(xml, "strComment", strComment);
          idfsYNTestsConducted = GetLong(xml, "idfsYNTestsConducted", idfsYNTestsConducted);
          idfFarm = GetLong(xml, "idfFarm", idfFarm);
          strFarmName = GetString(xml, "strFarmName", strFarmName);
          strFarmCode = GetString(xml, "strFarmCode", strFarmCode);
          idfRootFarm = GetLong(xml, "idfRootFarm", idfRootFarm);
          strOwnerLastName = GetString(xml, "strOwnerLastName", strOwnerLastName);
          strOwnerFirstName = GetString(xml, "strOwnerFirstName", strOwnerFirstName);
          strOwnerMiddleName = GetString(xml, "strOwnerMiddleName", strOwnerMiddleName);
          idfsRegion = GetLong(xml, "idfsRegion", idfsRegion);
          idfsRayon = GetLong(xml, "idfsRayon", idfsRayon);
          idfsSettlement = GetLong(xml, "idfsSettlement", idfsSettlement);
          strStreetName = GetString(xml, "strStreetName", strStreetName);
          strBuilding = GetString(xml, "strBuilding", strBuilding);
          strHouse = GetString(xml, "strHouse", strHouse);
          strApartment = GetString(xml, "strApartment", strApartment);
          strPostCode = GetString(xml, "strPostCode", strPostCode);
          dblLongitude = GetDouble(xml, "dblLongitude", dblLongitude);
          dblLatitude = GetDouble(xml, "dblLatitude", dblLatitude);
          strPhone = GetString(xml, "strPhone", strPhone);
        }
    }
}
