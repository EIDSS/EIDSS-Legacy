using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema.Smartphone;

namespace eidss.smartphone.web.Models
{
    public class BaseReferenceTranslationRaw
    {
        public long id { get; set; }
        public string tr { get; set; }
        public string lg { get; set; }

        public static IEnumerable<BaseReferenceTranslationRaw> GetList(long type, string lang)
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                if (type == (long)BaseReferenceType.rftInstitutionName)
                {
                    return SmphOrganizationTranslationLookup.Accessor.Instance(null).SelectLookupList(manager, lang)
                        .Select(c => new BaseReferenceTranslationRaw() { id = c.id, tr = c.tr, lg = c.lg });
                }
                else
                {
                    return SmphBaseReferenceTranslationLookup.Accessor.Instance(null).SelectLookupList(manager, type, lang)
                        .Select(c => new BaseReferenceTranslationRaw() { id = c.id, tr = c.tr, lg = c.lg });
                }
            }
        }
    }
}