using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;
using eidss.model.Enums;

namespace eidss.webclient.Areas.VetCaseSamples
{
    public static class Extenders
    {
        public static MvcHtmlString VetCaseSamples(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VetCaseSample> samples, bool isReadOnly, int? intHACode)
        {
            var args = new RouteValueDictionary { { "area", "VetCaseSamples" }, { "root", root }, { "name", name }, { "samples", samples }, { "isReadOnly", isReadOnly }, 
                { "exclude", intHACode.HasValue ? ((intHACode.Value & (int)HACode.Livestock) != 0 ? "strBirdStatus" : "AnimalID,strSendToOffice") : "" } };
            return htmlHelper.Action("ShowVetCaseSamples", "VetCaseSamples", args);
        }

        public static string HtmlVetCaseSamples(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VetCaseSample> samples, bool isReadOnly, int? intHACode)
        {
            return htmlHelper.VetCaseSamples(root, name, samples, isReadOnly, intHACode).ToHtmlString();
        }

    }
}