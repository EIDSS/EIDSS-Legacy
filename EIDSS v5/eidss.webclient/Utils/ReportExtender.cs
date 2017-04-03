using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace eidss.webclient.Utils
{
    public static class ReportExtender
    {
        public static MvcHtmlString ReportTest(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Action("ShowInlineFreezerPicker", "Freezer");
        }
    }
}