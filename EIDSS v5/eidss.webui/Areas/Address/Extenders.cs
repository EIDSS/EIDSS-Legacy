using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;
using eidss.model.Schema;

namespace eidss.webui.Areas.Address
{
    public static class Extenders
    {
        public static MvcHtmlString Address(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            var args = new RouteValueDictionary { { "area", "Address" }, { "root", root }, { "address", address } };
            return htmlHelper.Action("ShowAddress", "Address", args);
        }

        public static string HtmlAddress(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Address address)
        {
            return htmlHelper.Address(root, address).ToHtmlString();
        }

    }
}