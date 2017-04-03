using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using eidss.web.common.Utils;
using eidss.webclient.Models;
using bv.model.BLToolkit;
using eidss.model.Core;
using bv.model.Model.Core;

namespace eidss.webclient.Utils
{
    public static partial class Extenders
    {

        public static MvcHtmlString PopuMenu(this HtmlHelper htmlHelper, IObjectAccessor accessor, string selector)
        {
            if (accessor != null)
            {
                var model = accessor as IObjectMeta;
                var args = new RouteValueDictionary { { "meta", model }, { "selector", selector } };
                return htmlHelper.Action("PopupMenu", "PopupMenu", args);
            }
            return new MvcHtmlString("");
        }

    }
}