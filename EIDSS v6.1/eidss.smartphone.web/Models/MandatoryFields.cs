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
    public class MandatoryFields
    {
        public long id { get; set; }
        public string fn { get; set; }

        public static IEnumerable<MandatoryFields> GetList()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                return SmphMandatoryFieldsLookup.Accessor.Instance(null).SelectLookupList(manager, EidssSiteContext.Instance.CustomizationPackageID)
                    .Select(c => new MandatoryFields() { id = c.id, fn = c.fld });
            }
        }
    }
}