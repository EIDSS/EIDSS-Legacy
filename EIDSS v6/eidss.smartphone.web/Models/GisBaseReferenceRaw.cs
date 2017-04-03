using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.model.Schema.Smartphone;

namespace eidss.smartphone.web.Models
{
    public class GisBaseReferenceRaw
    {
        public long id { get; set; }
        public long tp { get; set; }
        public long cn { get; set; }
        public long rg { get; set; }
        public long rn { get; set; }
        public string df { get; set; }

        public static IEnumerable<GisBaseReferenceRaw> GetAll()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return SmphGisBaseReferenceLookup.Accessor.Instance(null).SelectLookupList(manager, EidssSiteContext.Instance.CountryID)
                    .Select(c => new GisBaseReferenceRaw() { id = c.id, tp = c.tp, cn = c.cn, rg = c.rg, rn = c.rn, df = c.df });

/*                var list = new List<GisBaseReferenceRaw>();

                list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as id, b.idfsGISReferenceType as tp, 
c.idfsCountry as cn, 0 as rg, 0 as rn, b.strDefault as df
from gisBaseReference b
inner join gisCountry c on c.idfsCountry = b.idfsGISBaseReference
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                    , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID))
                                  .ExecuteList<GisBaseReferenceRaw>());

                list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as id, b.idfsGISReferenceType as tp, 
c.idfsCountry as cn, c.idfsRegion as rg, 0 as rn, b.strDefault as df
from gisBaseReference b
inner join gisRegion c on c.idfsRegion = b.idfsGISBaseReference
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                    , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID))
                                  .ExecuteList<GisBaseReferenceRaw>());

                list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as id, b.idfsGISReferenceType as tp, 
c.idfsCountry as cn, d.idfsRegion as rg, d.idfsRayon as rn, b.strDefault as df
from gisBaseReference b
inner join gisRayon d on d.idfsRayon = b.idfsGISBaseReference
inner join gisRegion c on c.idfsRegion = d.idfsRegion
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                    , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID))
                                  .ExecuteList<GisBaseReferenceRaw>());

                list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as id, b.idfsGISReferenceType as tp, 
c.idfsCountry as cn, c.idfsRegion as rg, d.idfsRayon as rn, b.strDefault as df
from gisBaseReference b
inner join gisSettlement e on e.idfsSettlement = b.idfsGISBaseReference
inner join gisRayon d on d.idfsRayon = e.idfsRayon
inner join gisRegion c on c.idfsRegion = d.idfsRegion
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                    , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID))
                                  .ExecuteList<GisBaseReferenceRaw>());

                return list;*/
            }
        }
    }
}