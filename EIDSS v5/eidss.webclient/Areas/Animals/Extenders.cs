using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Areas.Animals
{
    public static partial class Extenders
    {
        public static MvcHtmlString AnimalList(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AnimalListItem> items, bool readOnly)
        {

            var args = new RouteValueDictionary { { "area", "Animals" }, { "root", root }, { "name", name }, { "items", items }, {"readOnly", readOnly} };
            return htmlHelper.Action("List", "Animals", args);
        }

        public static string HtmlAnimalList(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.AnimalListItem> items, bool readOnly)
        {
            return htmlHelper.AnimalList(root, name, items, readOnly).ToHtmlString();
        }
    }
}