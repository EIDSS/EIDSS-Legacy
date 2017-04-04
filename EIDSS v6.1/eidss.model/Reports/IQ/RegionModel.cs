using System.Collections.Generic;
using System.Linq;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.IQ
{
    public class RegionModel
    {
        public RegionModel()
        {
        }

        public RegionModel(long? regionId)
        {
            RegionId = regionId;
        }

        [LocalizedDisplayName("strProvince")]
        public long? RegionId { get; set; }

        public string RegionName
        {
            get
            {
                if (!RegionId.HasValue)
                {
                    return string.Empty;
                }

                SelectListItemSurrogate found = RegionList.FirstOrDefault(r => r.Value == RegionId.Value.ToString());
                return (found == null)
                    ? string.Empty
                    : found.Text;
            }
        }

        public List<SelectListItemSurrogate> RegionList
        {
            get { return FilterHelper.GetAllRegions(Localizer.CurrentCultureLanguageID); }
        }
    }
}