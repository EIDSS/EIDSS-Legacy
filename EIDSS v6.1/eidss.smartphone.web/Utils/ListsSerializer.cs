using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Utils
{
    public class ListsSerializer
    {
        public static string GetLists()
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("lists"
                , new XAttribute("date", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"))
                , new XAttribute("defRg", eidss.model.Core.EidssSiteContext.Instance.RegionID)
                , new XAttribute("defRn", eidss.model.Core.EidssSiteContext.Instance.RayonID)
                );
            doc.Add(root);
            root.Add(Farms());
            root.Add(Sessions());
            root.Add(Campaigns());
            return doc.ToString(SaveOptions.DisableFormatting);
        }

        private static XElement Farms()
        {
            return new XElement("farms",
                    eidss.smartphone.web.Models.FarmInfoIn.GetList(eidss.model.Core.EidssSiteContext.Instance.RegionID).Select(c =>
                        new XElement("farm",
                            new XAttribute("intRowStatus", c.intRowStatus),
                            new XAttribute("idParent", c.idParent),
                            new XAttribute("idfFarm", c.idfFarm),
                            new XAttribute("idfsHerd", c.idfsHerd),
                            new XAttribute("blnIsRoot", c.blnIsRoot),
                            new XAttribute("strFarmName", c.strFarmName),
                            new XAttribute("strFarmCode", c.strFarmCode),
                            new XAttribute("idfRootFarm", c.idfRootFarm),
                            new XAttribute("strOwnerLastName", c.strOwnerLastName),
                            new XAttribute("strOwnerFirstName", c.strOwnerFirstName),
                            new XAttribute("strOwnerMiddleName", c.strOwnerMiddleName),
                            new XAttribute("strPhone", c.strPhone),
                            new XAttribute("strFax", c.strFax),
                            new XAttribute("strEmail", c.strEmail),
                            new XAttribute("idfsRegion", c.idfsRegion),
                            new XAttribute("idfsRayon", c.idfsRayon),
                            new XAttribute("idfsSettlement", c.idfsSettlement),
                            new XAttribute("strStreetName", c.strStreetName),
                            new XAttribute("strBuilding", c.strBuilding),
                            new XAttribute("strHouse", c.strHouse),
                            new XAttribute("strApartment", c.strApartment),
                            new XAttribute("strPostCode", c.strPostCode),
                            new XAttribute("dblLongitude", c.dblLongitude),
                            new XAttribute("dblLatitude", c.dblLatitude)
                            )));
        }

        private static XElement Sessions()
        {
            return new XElement("sessions",
                    eidss.smartphone.web.Models.ASSessionInfoIn.GetList(eidss.model.Core.EidssSiteContext.Instance.RegionID).Select(c =>
                        new XElement("session",
                            new XAttribute("datModificationDate", c.datModificationDate),
                            new XAttribute("strMonitoringSessionID", c.strMonitoringSessionID),
                            new XAttribute("idfMonitoringSession", c.idfMonitoringSession),
                            new XAttribute("idfsMonitoringSessionStatus", c.idfsMonitoringSessionStatus),
                            new XAttribute("datStartDate", c.datStartDate),
                            new XAttribute("datEndDate", c.datEndDate),
                            new XAttribute("idfCampaign", c.idfCampaign),
                            new XAttribute("idfsCampaignType", c.idfsCampaignType),
                            new XAttribute("idfsRegion", c.idfsRegion),
                            new XAttribute("idfsRayon", c.idfsRayon),
                            new XAttribute("idfsSettlement", c.idfsSettlement),
                            new XElement("asdiseases", c.asdiseases.Select(d => 
                                new XElement("asdisease",
                                    new XAttribute("idfMonitoringSession", d.idfMonitoringSession),
                                    new XAttribute("idfCampaign", d.idfCampaign),
                                    new XAttribute("idfsDiagnosis", d.idfsDiagnosis),
                                    new XAttribute("idfsSpeciesType", d.idfsSpeciesType),
                                    new XAttribute("idfsSampleType", d.idfsSampleType)
                                    )
                                ))
                            )));
        }

        private static XElement Campaigns()
        {
            return new XElement("campaigns",
                    eidss.smartphone.web.Models.ASCampaigns.GetList().Select(c =>
                        new XElement("campaign",
                            new XAttribute("idfCampaign", c.idfCampaign),
                            new XAttribute("idfsCampaignType", c.idfsCampaignType),
                            new XAttribute("strCampaignName", c.strCampaignName),
                            new XAttribute("datCampaignDateStart", c.datCampaignDateStart),
                            new XAttribute("datCampaignDateEnd", c.datCampaignDateEnd),
                            new XElement("asdiseases", c.asdiseases.Select(d =>
                                new XElement("asdisease",
                                    new XAttribute("idfMonitoringSession", d.idfMonitoringSession),
                                    new XAttribute("idfCampaign", d.idfCampaign),
                                    new XAttribute("idfsDiagnosis", d.idfsDiagnosis),
                                    new XAttribute("idfsSpeciesType", d.idfsSpeciesType),
                                    new XAttribute("idfsSampleType", d.idfsSampleType)
                                    )
                                ))
                            )));
        }

    }
}