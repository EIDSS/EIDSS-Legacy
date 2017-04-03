using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using bv.common.Enums;
using bv.model.Model.Core;
using System.Web.Routing;

namespace eidss.webui.Areas.ActionPanel
{
    public static class Extenders
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="accessor"></param>
        /// <param name="panelType"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderActionPanelHTML(this HtmlHelper htmlHelper, IObjectAccessor accessor, ActionsPanelType panelType)
        {
            return (accessor != null) ? htmlHelper.Action("Index", "ActionPanel", GetArgs(accessor, panelType)) : new MvcHtmlString(String.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessor"></param>
        /// <param name="panelType"></param>
        /// <returns></returns>
        private static RouteValueDictionary GetArgs(IObjectAccessor accessor, ActionsPanelType panelType)
        {
            return new RouteValueDictionary { { "area", "ActionPanel" }, { "accessor", accessor }, { "panelType", panelType } };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="accessor"></param>
        /// <param name="panelType"></param>
        /// <returns></returns>
        public static void RenderActionPanel(this HtmlHelper htmlHelper, IObjectAccessor accessor, ActionsPanelType panelType)
        {
            if (accessor != null)
                htmlHelper.RenderAction("Index", "ActionPanel", GetArgs(accessor, panelType));
        }
    }
}