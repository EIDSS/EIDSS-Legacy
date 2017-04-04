using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;
using eidss.model.Schema;

namespace eidss.webui.Areas.Patient
{
    public static class Extenders
    {
        public static MvcHtmlString Patient(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Patient patient)
        {
            var args = new RouteValueDictionary { { "area", "Patient" }, { "root", root }, { "patient", patient } };
            return htmlHelper.Action("ShowPatient", "Patient", args);
        }

        public static string HtmlPatient(this HtmlHelper htmlHelper, long root, eidss.model.Schema.Patient patient)
        {
            return htmlHelper.Patient(root, patient).ToHtmlString();
        }
    }
}