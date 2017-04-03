using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Core;
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
                return SmphBaseReferenceTranslationLookup.Accessor.Instance(null).SelectLookupList(manager, type, lang)
                    .Select(c => new BaseReferenceTranslationRaw() { id = c.id, tr = c.tr, lg = c.lg });
/*                return manager.SetCommand(@"
select br.idfsBaseReference as id, Isnull(bt.strTextString, br.strDefault) as tr, @lang as lg
from trtBaseReference br
inner join trtStringNameTranslation bt on bt.idfsBaseReference = br.idfsBaseReference
and bt.idfsLanguage = dbo.fnGetLanguageCode(@lang)
where br.intRowStatus = 0 and br.idfsReferenceType = @idfsReferenceType
"
                    , manager.Parameter("@idfsReferenceType", type), manager.Parameter("@lang", lang))
                        .ExecuteList<BaseReferenceTranslationRaw>();*/
            }
        }
    }
}