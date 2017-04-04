using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class ASSampleInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public String uidOfflineCaseID { get; set; }
      public long idParent { get; set; }
      public long idfMonitoringSession { get; set; }
      public long idfFarm { get; set; }
      public long idfsSpeciesType { get; set; }
      public long idfAnimal { get; set; }
      public String strAnimalCode { get; set; }
      public long idfsAnimalAge { get; set; }
      public String strColor { get; set; }
      public long idfsAnimalGender { get; set; }
      public String strName { get; set; }
      public String strDescription { get; set; }
      public long idfMaterial { get; set; }
      public long idfsSampleType { get; set; }
      public String strFieldBarcode { get; set; }
      public DateTime datFieldCollectionDate { get; set; }
      public long idfSendToOffice { get; set; }

    public ASSampleInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          uidOfflineCaseID = GetString(xml, "uidOfflineCaseID", uidOfflineCaseID);
          idParent = GetLong(xml, "idParent", idParent);
          idfMonitoringSession = GetLong(xml, "idfMonitoringSession", idfMonitoringSession);
          idfFarm = GetLong(xml, "idfFarm", idfFarm);
          idfsSpeciesType = GetLong(xml, "idfsSpeciesType", idfsSpeciesType);
          idfAnimal = GetLong(xml, "idfAnimal", idfAnimal);
          strAnimalCode = GetString(xml, "strAnimalCode", strAnimalCode);
          idfsAnimalAge = GetLong(xml, "idfsAnimalAge", idfsAnimalAge);
          strColor = GetString(xml, "strColor", strColor);
          idfsAnimalGender = GetLong(xml, "idfsAnimalGender", idfsAnimalGender);
          strName = GetString(xml, "strName", strName);
          strDescription = GetString(xml, "strDescription", strDescription);
          idfMaterial = GetLong(xml, "idfMaterial", idfMaterial);
          idfsSampleType = GetLong(xml, "idfsSampleType", idfsSampleType);
          strFieldBarcode = GetString(xml, "strFieldBarcode", strFieldBarcode);
          datFieldCollectionDate = GetDateTime(xml, "datFieldCollectionDate", datFieldCollectionDate);
          idfSendToOffice = GetLong(xml, "idfSendToOffice", idfSendToOffice);
        }
    }
}
