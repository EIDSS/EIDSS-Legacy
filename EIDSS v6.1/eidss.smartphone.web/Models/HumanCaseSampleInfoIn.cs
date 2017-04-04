using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.model.Core;

namespace eidss.smartphone.web.Models
{
    public partial class HumanCaseSampleInfoIn : InfoInBase
    {
        public HumanCaseSampleInfoIn()
        {
        }

        public HumanCaseSampleInfoIn(HumanCaseSample s)
        {
            uidOfflineCaseID = s.uidOfflineCaseID.HasValue ? s.uidOfflineCaseID.Value.ToString("D") : "";
            idfMaterial = s.idfMaterial;
            idfsSampleType = s.idfsSampleType;
            strFieldBarcode = s.strFieldBarcode == null ? "" : s.strFieldBarcode;
            datFieldCollectionDate = s.datFieldCollectionDate.HasValue ? s.datFieldCollectionDate.Value : new DateTime();
            idfSendToOffice = s.idfSendToOffice.HasValue ? s.idfSendToOffice.Value : 0;
            datFieldSentDate = s.datFieldSentDate.HasValue ? s.datFieldSentDate.Value : new DateTime();
        }

        public static HumanCaseSampleInfoIn Init(XElement xml)
        {
            HumanCaseSampleInfoIn ret = new HumanCaseSampleInfoIn(xml);
            return ret;
        }

        public void FillHumanCaseSample(HumanCaseSample s)
        {
            s.uidOfflineCaseID = String.IsNullOrEmpty(uidOfflineCaseID) ? new Guid?() : new Guid(uidOfflineCaseID);
            s.SampleType = s.SampleTypeLookup.FirstOrDefault(c => c.idfsReference == idfsSampleType);
            s.strFieldBarcode = strFieldBarcode;
            s.datFieldCollectionDate = datFieldCollectionDate;
            if(datFieldSentDate.Ticks > 1000)
                s.datFieldSentDate = datFieldSentDate;
        }

    }
}