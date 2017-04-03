using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace eidss.webclient.Areas.Freezer
{
    public static class Extenders
    {
        public static MvcHtmlString InlineFreezerPicker(this HtmlHelper htmlHelper, long root, eidss.model.Schema.LabSample sample)
        {
            var args = new RouteValueDictionary { { "area", "Freezer" }, { "root", root }, { "sample", sample } };
            return htmlHelper.Action("ShowInlineFreezerPicker", "Freezer", args);
        }

        public static string HtmlInlineFreezerPicker(this HtmlHelper htmlHelper, long root, eidss.model.Schema.LabSample sample)
        {
            return htmlHelper.InlineFreezerPicker(root, sample).ToHtmlString();
        }
    }
}
