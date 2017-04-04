using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.model.Schema.Smartphone;
using bv.model.Model.Core;

namespace eidss.smartphone.web.Models
{
    public class ASCampaigns
    {
        public long idfCampaign { get; set; }
        public int intRowStatus { get; set; }
        public string strCampaignName { get; set; }
        public long idfsCampaignType { get; set; }
        public DateTime datCampaignDateStart { get; set; }
        public DateTime datCampaignDateEnd { get; set; }
        public List<ASDiseaseInfoIn> asdiseases { get; set; }

        public ASCampaigns(AsCampaign a)
        {
            intRowStatus = a.idfsCampaignStatus == (long)eidss.model.Enums.AsCampaignStatus.Open ? 0 : 1;
            idfCampaign = a.idfCampaign;
            strCampaignName = a.strCampaignName;
            idfsCampaignType = a.idfsCampaignType.GetValueOrDefault();
            datCampaignDateStart = a.datCampaignDateStart.GetValueOrDefault();
            datCampaignDateEnd = a.datCampaignDateEnd.GetValueOrDefault();

            asdiseases = new List<ASDiseaseInfoIn>();
            a.Diseases.ForEach(c => asdiseases.Add(new ASDiseaseInfoIn(c)));
        }

        public static IEnumerable<ASCampaigns> GetList()
        {
            var list = new List<long>();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                list = AsCampaignListItem.Accessor.Instance(null)
                    .SelectListT(manager)
                    .Select(c => c.idfCampaign).ToList();
                return list.Select(c => new ASCampaigns(AsCampaign.Accessor.Instance(null).SelectByKey(manager, c))).ToList();
            }
        }
    }
}