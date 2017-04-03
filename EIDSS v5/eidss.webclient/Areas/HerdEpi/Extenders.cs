using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Areas.HerdEpi
{
    public static class Extenders
    {
        #region HerdEpi
        public static MvcHtmlString HerdSpeciesList(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VetFarmTree> items, bool readOnly)
        {

            var args = new RouteValueDictionary { { "area", "HerdEpi" }, { "root", root }, { "name", name }, { "items", items }, { "readOnly", readOnly } };
            return htmlHelper.Action("Index", "Herd", args);
        }

        public static string HtmlHerdSpeciesList(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VetFarmTree> items, bool readOnly)
        {
            return htmlHelper.HerdSpeciesList(root, name, items, readOnly).ToHtmlString();
        }

        public static MvcHtmlString FlockSpeciesList(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VetFarmTree> items, bool readOnly)
        {

            var args = new RouteValueDictionary { { "area", "HerdEpi" }, { "root", root }, { "name", name }, { "items", items }, {"readOnly", readOnly} };
            return htmlHelper.Action("Index", "Flock", args);
        }

        public static string HtmlFlockSpeciesList(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VetFarmTree> items, bool readOnly)
        {
            return htmlHelper.FlockSpeciesList(root, name, items, readOnly).ToHtmlString();
        }
        #endregion

        public static MvcHtmlString HerdSpeciesListByFarm(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VetFarmTree> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "HerdEpi" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ByFarm", "Herd", args);
        }

        public static string HtmlHerdSpeciesListByFarm(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.VetFarmTree> items, bool isReadOnly)
        {
            return htmlHelper.HerdSpeciesListByFarm(root, name, items, isReadOnly).ToHtmlString();
        }

        public static MvcHtmlString FlockSpeciesListByFarm(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.RootFarmTree> items, bool isReadOnly)
        {

            var args = new RouteValueDictionary { { "area", "HerdEpi" }, { "root", root }, { "name", name }, { "items", items }, { "isReadOnly", isReadOnly } };
            return htmlHelper.Action("ByFarm", "Flock", args);
        }

        public static string HtmlFlockSpeciesListByFarm(this HtmlHelper htmlHelper, long root, string name, EditableList<eidss.model.Schema.RootFarmTree> items, bool isReadOnly)
        {
            return htmlHelper.FlockSpeciesListByFarm(root, name, items, isReadOnly).ToHtmlString();
        }
    }
}