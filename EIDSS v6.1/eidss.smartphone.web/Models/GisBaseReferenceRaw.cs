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
        public int rs { get; set; }
        public int rd { get; set; }

        public static IEnumerable<GisBaseReferenceRaw> GetAll()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return SmphGisBaseReferenceLookup.Accessor.Instance(null).SelectLookupList(manager, EidssSiteContext.Instance.CountryID)
                    .Select(c => new GisBaseReferenceRaw() { id = c.id, tp = c.tp, cn = c.cn, rg = c.rg, rn = c.rn, df = c.df, rs = c.rs, rd = c.rd });
            }
        }
    }
}