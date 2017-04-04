using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class FarmInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public int intRowStatus { get; set; }
      public String uidOfflineCaseID { get; set; }
      public long idParent { get; set; }
      public long idfFarm { get; set; }
      public long idfsHerd { get; set; }
      public bool blnIsRoot { get; set; }
      public String strFarmName { get; set; }
      public String strFarmCode { get; set; }
      public long idfRootFarm { get; set; }
      public String strOwnerLastName { get; set; }
      public String strOwnerFirstName { get; set; }
      public String strOwnerMiddleName { get; set; }
      public String strPhone { get; set; }
      public String strFax { get; set; }
      public String strEmail { get; set; }
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

    public FarmInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          intRowStatus = GetInt(xml, "intRowStatus", intRowStatus);
          uidOfflineCaseID = GetString(xml, "uidOfflineCaseID", uidOfflineCaseID);
          idParent = GetLong(xml, "idParent", idParent);
          idfFarm = GetLong(xml, "idfFarm", idfFarm);
          idfsHerd = GetLong(xml, "idfsHerd", idfsHerd);
          blnIsRoot = GetBool(xml, "blnIsRoot", blnIsRoot);
          strFarmName = GetString(xml, "strFarmName", strFarmName);
          strFarmCode = GetString(xml, "strFarmCode", strFarmCode);
          idfRootFarm = GetLong(xml, "idfRootFarm", idfRootFarm);
          strOwnerLastName = GetString(xml, "strOwnerLastName", strOwnerLastName);
          strOwnerFirstName = GetString(xml, "strOwnerFirstName", strOwnerFirstName);
          strOwnerMiddleName = GetString(xml, "strOwnerMiddleName", strOwnerMiddleName);
          strPhone = GetString(xml, "strPhone", strPhone);
          strFax = GetString(xml, "strFax", strFax);
          strEmail = GetString(xml, "strEmail", strEmail);
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
        }
    }
}
