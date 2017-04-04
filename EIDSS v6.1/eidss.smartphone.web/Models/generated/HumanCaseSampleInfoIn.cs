using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
public partial class HumanCaseSampleInfoIn
{
    public String lang { get; set; }
    public int intChanged { get; set; }
      public String uidOfflineCaseID { get; set; }
      public long idParent { get; set; }
      public long idfMaterial { get; set; }
      public long idfsSampleType { get; set; }
      public String strFieldBarcode { get; set; }
      public DateTime datFieldCollectionDate { get; set; }
      public long idfSendToOffice { get; set; }
      public DateTime datFieldSentDate { get; set; }

    public HumanCaseSampleInfoIn(XElement xml)
    {
          lang = GetString(xml, "lang", lang);
          intChanged = GetInt(xml, "intChanged", intChanged);
          uidOfflineCaseID = GetString(xml, "uidOfflineCaseID", uidOfflineCaseID);
          idParent = GetLong(xml, "idParent", idParent);
          idfMaterial = GetLong(xml, "idfMaterial", idfMaterial);
          idfsSampleType = GetLong(xml, "idfsSampleType", idfsSampleType);
          strFieldBarcode = GetString(xml, "strFieldBarcode", strFieldBarcode);
          datFieldCollectionDate = GetDateTime(xml, "datFieldCollectionDate", datFieldCollectionDate);
          idfSendToOffice = GetLong(xml, "idfSendToOffice", idfSendToOffice);
          datFieldSentDate = GetDateTime(xml, "datFieldSentDate", datFieldSentDate);
        }
    }
}
