using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Areas.Therapy
{
    public static class Extenders
    {
        public static MvcHtmlString HumanAntimicrobialTherapy(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AntimicrobialTherapy> antibiotic, bool isReadOnly)
        {
            var args = new RouteValueDictionary { { "area", "Therapy" }, { "root", root }, { "name", name }, { "antibiotic", antibiotic }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ShowHumanAntimicrobialTherapy", "Therapy", args);
        }

        public static string HtmlHumanAntimicrobialTherapy(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AntimicrobialTherapy> antibiotic, bool isReadOnly)
        {
            return htmlHelper.HumanAntimicrobialTherapy(root, name, antibiotic, isReadOnly).ToHtmlString();
        }

    }
}