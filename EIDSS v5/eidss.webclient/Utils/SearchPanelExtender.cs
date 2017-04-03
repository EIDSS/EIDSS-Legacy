using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using eidss.webclient.Models;
using bv.model.BLToolkit;
using eidss.model.Core;
using bv.model.Model.Core;

namespace eidss.webclient.Utils
{
    public static partial class Extenders
    {
        public static MvcHtmlString SearchPanel(
            this HtmlHelper htmlHelper,
            IObjectAccessor accessor, FilterParams filter, IObject initSource = null)
        {
            bool defaultFilter = (initSource != null);
            if (initSource == null)
            { 
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    initSource = (accessor as IObjectCreator).CreateNew(manager, null, null);
                }
            }
            if (filter == null)
            {
                filter = SearchPanelHelper.GetDefaultFilter((accessor as IObjectMeta).SearchPanelMeta, initSource);
            }
            var model = new SearchPanelModel(
                (accessor as IObjectMeta).SearchPanelMeta,
                initSource,
                filter);
            model.IsDefaultFilter = defaultFilter;

            var args = new RouteValueDictionary { { "model", model } };
            return htmlHelper.Action("SearchPanelAlternative", "Search", args);

        }

        public static string HtmlSearchPanel(this HtmlHelper htmlHelper, IObjectAccessor accessor, FilterParams filter)
        {
            return htmlHelper.SearchPanel(accessor, filter).ToHtmlString();
        }
    }
}