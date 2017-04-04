using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class FromMonthToMonthModel : BaseModel
    {
        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        public List<SelectListItemSurrogate> UnselectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(-1, false); }
        }

        public List<SelectListItemSurrogate> SelectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month - 1, false); }
        }
    }
}
