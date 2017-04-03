using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eidss.model.Reports.Common;

namespace eidss.webclient.Utils
{
    public static class SelectListItemExtender
    {
        public static SelectListItem ConvertToSelectListItem(this SelectListItemSurrogate source)
        {
            return new SelectListItem
                {
                    Text = source.Text,
                    Value = source.Value,
                    Selected = source.Selected
                };
        }

        public static IEnumerable<SelectListItem> ConvertToSelectListItem(this IEnumerable<SelectListItemSurrogate> source)
        {
            return source.Select(surrogate => surrogate.ConvertToSelectListItem());
        }
    }
}