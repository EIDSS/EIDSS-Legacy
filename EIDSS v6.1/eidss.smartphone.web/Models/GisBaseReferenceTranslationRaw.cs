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
            }
        }
    }
}