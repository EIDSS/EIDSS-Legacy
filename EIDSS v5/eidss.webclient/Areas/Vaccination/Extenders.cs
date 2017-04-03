using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;


namespace eidss.webclient.Areas.Vaccination
{
    public static class Extenders
    {
        public static MvcHtmlString VaccinationList(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VaccinationListItem> items, bool readOnly = false)
        {
          
            var args = new RouteValueDictionary { { "area", "Vaccination" }, { "root", root }, { "name", name }, { "items", items }, {"readOnly", readOnly} };
            return htmlHelper.Action("VetCaseVaccination", "Vaccination", args);
        }

        public static string HtmlVaccinationList(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VaccinationListItem> items, bool readOnly = false)
        {
            return htmlHelper.VaccinationList(root, name, items, readOnly).ToHtmlString();
        }
    }
}