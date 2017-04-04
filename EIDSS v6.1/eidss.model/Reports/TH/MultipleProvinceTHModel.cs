using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Schema;

namespace eidss.model.Reports.TH
{
    public class MultipleProvinceTHModel : BaseMultipleModel
    {
        public MultipleProvinceTHModel()
        {
            CheckedItems = new string[0];
        }

        public MultipleProvinceTHModel(string[] checkedItems)
        {
            CheckedItems = checkedItems ?? new string[0];
        }

        public static List<RegionLookup> GetDataSource()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return RegionLookup.Accessor.Instance(null).SelectList(manager, EidssSiteContext.Instance.CountryID, null);
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
                    Value = region.idfsRegion.ToString(CultureInfo.InvariantCulture),
                    Text = region.strRegionName,
                    Selected = false
                })
                );
            return result;
        }
    }
}