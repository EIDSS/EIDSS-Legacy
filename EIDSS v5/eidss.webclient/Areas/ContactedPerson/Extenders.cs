using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Areas.ContactedPerson
{
    public static class Extenders
    {
        public static MvcHtmlString HumanContactedPerson(this HtmlHelper htmlHelper, long root, string name, EditableList<model.Schema.ContactedCasePerson> personList, bool isReadOnly)
        {
            var args = new RouteValueDictionary { { "area", "ContactedPerson" }, { "root", root }, { "name", name }, { "personList", personList }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ShowHumanContactedPerson", "ContactedPerson", args);
        }

        public static string HtmlHumanContactedPerson(this HtmlHelper htmlHelper, long root, string name, EditableList<model.Schema.ContactedCasePerson> personList, bool isReadOnly)
        {
            return htmlHelper.HumanContactedPerson(root, name, personList, isReadOnly).ToHtmlString();
        }
    }
}