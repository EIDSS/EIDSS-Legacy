using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class ASDiseaseInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public long idParent { get; set; }
      public long idfMonitoringSession { get; set; }
      public long idfCampaign { get; set; }
      public long idfsDiagnosis { get; set; }
      public long idfsSpeciesType { get; set; }
      public long idfsSampleType { get; set; }

    public ASDiseaseInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          idParent = GetLong(xml, "idParent", idParent);
          idfMonitoringSession = GetLong(xml, "idfMonitoringSession", idfMonitoringSession);
          idfCampaign = GetLong(xml, "idfCampaign", idfCampaign);
          idfsDiagnosis = GetLong(xml, "idfsDiagnosis", idfsDiagnosis);
          idfsSpeciesType = GetLong(xml, "idfsSpeciesType", idfsSpeciesType);
          idfsSampleType = GetLong(xml, "idfsSampleType", idfsSampleType);
        }
    }
}
