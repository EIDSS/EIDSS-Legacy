using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Reports.Common;
using eidss.model.Schema;

namespace eidss.model.Reports.TH
{
    [Serializable]
    public class MultipleRegionTHModel : BaseMultipleModel
    {
        public MultipleRegionTHModel()
        {
            CheckedItems = new string[0];
        }

        public MultipleRegionTHModel(string[] checkedItems)
        {
            CheckedItems = checkedItems ?? new string[0];
        }

        public static List<ThaiRegionLookup> GetDataSource()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return ThaiRegionLookup.Accessor.Instance(null).SelectList(manager);
            }
        }

        public override List<SelectListItemSurrogate> LoadItemList()
        {
            //Currently this method is used in web only
            //If it will be used in desktop too, it will be needed to make Select All item adding optional
            var result = new List<SelectListItemSurrogate>
            {
                FilterHelper.SelectAllItem
            };

            result.AddRange(
                GetDataSource().Select(region => new SelectListItemSurrogate
                {
                    Value = region.idfsBaseReference.ToString(CultureInfo.InvariantCulture),
                    Text = region.name,
                    Selected = false
                })
                );
            return result;
        }
    }
}