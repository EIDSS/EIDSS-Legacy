using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class ASSessionInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public String uidOfflineCaseID { get; set; }
      public DateTime datModificationDate { get; set; }
      public String strMonitoringSessionID { get; set; }
      public long idfMonitoringSession { get; set; }
      public long idfsMonitoringSessionStatus { get; set; }
      public DateTime datStartDate { get; set; }
      public DateTime datEndDate { get; set; }
      public long idfCampaign { get; set; }
      public long idfsCampaignType { get; set; }
      public long idfsRegion { get; set; }
      public long idfsRayon { get; set; }
      public long idfsSettlement { get; set; }

    public ASSessionInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          uidOfflineCaseID = GetString(xml, "uidOfflineCaseID", uidOfflineCaseID);
          datModificationDate = GetDateTime(xml, "datModificationDate", datModificationDate);
          strMonitoringSessionID = GetString(xml, "strMonitoringSessionID", strMonitoringSessionID);
          idfMonitoringSession = GetLong(xml, "idfMonitoringSession", idfMonitoringSession);
          idfsMonitoringSessionStatus = GetLong(xml, "idfsMonitoringSessionStatus", idfsMonitoringSessionStatus);
          datStartDate = GetDateTime(xml, "datStartDate", datStartDate);
          datEndDate = GetDateTime(xml, "datEndDate", datEndDate);
          idfCampaign = GetLong(xml, "idfCampaign", idfCampaign);
          idfsCampaignType = GetLong(xml, "idfsCampaignType", idfsCampaignType);
          idfsRegion = GetLong(xml, "idfsRegion", idfsRegion);
          idfsRayon = GetLong(xml, "idfsRayon", idfsRayon);
          idfsSettlement = GetLong(xml, "idfsSettlement", idfsSettlement);
        }
    }
}
