using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Schema;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class PrintBarcodesModel : BaseModel
    {
        public PrintBarcodesModel()
        {
            Quantity = 1;
            BarcodeType = long.Parse(GetBarcodeTypes().First().Value);
        }

        [LocalizedDisplayName("BarcodeType")]
        public long BarcodeType { get; set; } 

        [LocalizedDisplayName("Quantity")]
        public int Quantity { get; set; }

        public List<SelectListItemSurrogate> GetBarcodeTypes()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return BaseReference.Accessor.Instance(null).rftNumberingType_SelectList(manager)
                    .Where(c => c.intRowStatus == 0)
                    .OrderBy(c => c.name)
                    .Select(c => new SelectListItemSurrogate() { Text = c.name, Value = c.idfsBaseReference.ToString() })
                    .ToList();
            }
        }

    }
}