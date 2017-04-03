using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using eidss.model.Schema;

namespace eidss.webui.Areas.HumanCaseSamples
{
    public static class Extenders
    {
        public static string HtmlHumanCaseSamples(this HtmlHelper htmlHelper, long root, HumanCase hc)
        {
            var args = new RouteValueDictionary { { "area", "HumanCaseSamples" }, { "root", root }, { "hc", hc } };
            return htmlHelper.Action("ShowHumanCaseSamples", "HumanCaseSamples", args).ToHtmlString();
        }

    }
}