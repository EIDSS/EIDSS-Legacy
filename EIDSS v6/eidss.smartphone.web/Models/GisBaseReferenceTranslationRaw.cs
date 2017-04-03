using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema.Smartphone;

namespace eidss.smartphone.web.Models
{
    public class GisBaseReferenceTranslationRaw
    {
        public long id { get; set; }
        public string tr { get; set; }
        public string lg { get; set; }

        public static IEnumerable<GisBaseReferenceTranslationRaw> GetAll(string lang)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return SmphGisBaseReferenceTranslationLookup.Accessor.Instance(null).SelectLookupList(manager, EidssSiteContext.Instance.CountryID, lang)
                    .Select(c => new GisBaseReferenceTranslationRaw() { id = c.id, tr = c.tr, lg = c.lg });

/*                var list = new List<GisBaseReferenceTranslationRaw>();
                    list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as id, Isnull(o.strTextString, b.strDefault) as tr, @lang as lg
from gisBaseReference b
inner join gisCountry c on c.idfsCountry = b.idfsGISBaseReference
left join	dbo.gisStringNameTranslation as o
    on b.idfsGISBaseReference = o.idfsGISBaseReference and o.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                        , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID), manager.Parameter("@lang", lang))
                                      .ExecuteList<GisBaseReferenceTranslationRaw>());

                    list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as id, o.strTextString as tr, @lang as lg
from gisBaseReference b
inner join gisRegion c on c.idfsRegion = b.idfsGISBaseReference
left join	dbo.gisStringNameTranslation as o
    on b.idfsGISBaseReference = o.idfsGISBaseReference and o.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                        , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID), manager.Parameter("@lang", lang))
                                      .ExecuteList<GisBaseReferenceTranslationRaw>());

                    list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as id, Isnull(o.strTextString, b.strDefault) as tr, @lang as lg
from gisBaseReference b
inner join gisRayon d on d.idfsRayon = b.idfsGISBaseReference
inner join gisRegion c on c.idfsRegion = d.idfsRegion
left join	dbo.gisStringNameTranslation as o
    on b.idfsGISBaseReference = o.idfsGISBaseReference and o.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                        , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID), manager.Parameter("@lang", lang))
                                      .ExecuteList<GisBaseReferenceTranslationRaw>());

                    list.AddRange(manager.SetCommand(@"
select b.idfsGISBaseReference as id, Isnull(o.strTextString, b.strDefault) as tr, @lang as lg
from gisBaseReference b
inner join gisSettlement e on e.idfsSettlement = b.idfsGISBaseReference
inner join gisRayon d on d.idfsRayon = e.idfsRayon
inner join gisRegion c on c.idfsRegion = d.idfsRegion
left join	dbo.gisStringNameTranslation as o
    on b.idfsGISBaseReference = o.idfsGISBaseReference and o.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where b.intRowStatus = 0 and c.idfsCountry = @idfsCountry"
                        , manager.Parameter("@idfsCountry", EidssSiteContext.Instance.CountryID), manager.Parameter("@lang", lang))
                                      .ExecuteList<GisBaseReferenceTranslationRaw>());

                return list;*/
            }
        }
    }
}