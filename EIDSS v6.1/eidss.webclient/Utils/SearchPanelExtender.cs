using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using eidss.web.common.Utils;
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
            IObjectAccessor accessor, FilterParams filter, IObject initSource = null, FilterParams staticFilter = null, object objAdditional = null, bool isSearchWithCheckChange = false,
            Action<IObject> initAction = null
            )
        {
            bool defaultFilter = (initSource != null);
            if (initSource == null)
            { 
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    initSource = (accessor as IObjectCreator).CreateNew(manager, null, null);
                    if (initAction != null)
                        initAction(initSource);
                }
            }
            if (filter == null)
            {
                filter = SearchPanelHelper.GetDefaultFilter((accessor as IObjectMeta).SearchPanelMeta, initSource);
            }
            var model = new SearchPanelModel(
                (accessor as IObjectMeta).SearchPanelMeta,
                initSource,
                filter,
                staticFilter,
                objAdditional,
                isSearchWithCheckChange);
            model.IsDefaultFilter = defaultFilter;

            var args = new RouteValueDictionary { { "model", model } };
            return htmlHelper.Action("SearchPanelAlternative", "Search", args);
        }

        public static MvcHtmlString SearchPanelSimple(
            this HtmlHelper htmlHelper, IObjectAccessor accessor, Action<IObject> initAction = null)
        {
            if (accessor != null)
            {
                IObject initSource = null;
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    initSource = (accessor as IObjectCreator).CreateNew(manager, null, null);
                    if (initAction != null)
                        initAction(initSource);
                }
                FilterParams filter = SearchPanelHelper.GetDefaultFilter((accessor as IObjectMeta).SearchPanelMeta,
                                                                         initSource);
                var model = new SearchPanelModel(
                    (accessor as IObjectMeta).SearchPanelMeta,
                    initSource,
                    filter,
                    null,
                    null);

                var args = new RouteValueDictionary {{"model", model}};
                return htmlHelper.Action("SearchPanelSimple", "Search", args);
            }
            return new MvcHtmlString("");
        }

        public static MvcHtmlString SearchPanelOperator(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Action("SearchPanelOperator", "Search");
        }

        public static string HtmlSearchPanel(this HtmlHelper htmlHelper, IObjectAccessor accessor, FilterParams filter)
        {
            return htmlHelper.SearchPanel(accessor, filter).ToHtmlString();
        }

        public static string HtmlSearchPanelOperator(this HtmlHelper htmlHelper, IObjectAccessor accessor, FilterParams filter)
        {
            return htmlHelper.SearchPanelOperator().ToHtmlString();
        }
    }
}