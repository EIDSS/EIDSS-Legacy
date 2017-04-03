using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Areas.HumanCaseSamples
{
    public static class Extenders
    {
        public static MvcHtmlString HumanCaseSamples(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.HumanCaseSample> samples, bool isReadOnly)
        {
            var args = new RouteValueDictionary { { "area", "HumanCaseSamples" }, { "root", root }, { "name", name }, { "samples", samples }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ShowHumanCaseSamples", "HumanCaseSamples", args);
        }

        public static string HtmlHumanCaseSamples(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.HumanCaseSample> samples, bool isReadOnly)
        {
            return htmlHelper.HumanCaseSamples(root, name, samples, isReadOnly).ToHtmlString();
        }

    }
}