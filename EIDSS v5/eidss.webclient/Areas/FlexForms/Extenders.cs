using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using eidss.model.Schema;

namespace eidss.webclient.Areas.FlexForms
{
    public static class Extenders
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="root"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MvcHtmlString ShowFlexibleFormHTML(this HtmlHelper htmlHelper, long root, FFPresenterModel model)
        {
            //#1
            return htmlHelper.Action("ShowFlexibleFormDirect", "FFPresenter", GetArgs(root, root, model));

            //#2
            //var model = new FFPresenterModel();
            //model.SetProperties(template, activityParameters);
            //htmlHelper.RenderPartial("~/Areas/FlexForms/Views/FFPresenter/ShowFlexibleForm.ascx", model);
            
            //#3
            //var ffPresenter = new FFPresenterController();
            //return ffPresenter.ShowFlexibleForm(template, activityParameters);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="ffpresenter"></param>
        /// <returns></returns>
        internal static RouteValueDictionary GetArgs(long root, long key, FFPresenterModel ffpresenter)
        {
            return new RouteValueDictionary { { "area", "FlexForms" }, { "root", root }, { "key", key }, { "ffpresenter", ffpresenter } };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="ffpresenterId"></param>
        /// <returns></returns>
        internal static RouteValueDictionary GetArgs(long root, long key, long ffpresenterId)
        {
            return new RouteValueDictionary { { "area", "FlexForms" }, { "root", root }, { "key", key }, { "ffpresenterId", ffpresenterId } };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="root"></param>
        /// <param name="model"></param>
        public static void ShowFlexibleForm(this HtmlHelper htmlHelper, long root, FFPresenterModel model)
        {
            //#1
            htmlHelper.RenderAction("ShowFlexibleForm", "FFPresenter", GetArgs(root, 0, model));

            //#2
            //var model = new FFPresenterModel();
            //model.SetProperties(template, activityParameters);
            //htmlHelper.RenderPartial("~/Areas/FlexForms/Views/FFPresenter/ShowFlexibleForm.ascx", model);

            //#3
            //var ffPresenter = new FFPresenterController();
            //return ffPresenter.ShowFlexibleForm(template, activityParameters);

        }

        public static MvcHtmlString ShowFlexibleFormHTML(this HtmlHelper htmlHelper, long root, long key, long ffpresenterId)
        {
            //#1
            return htmlHelper.Action("ShowFlexibleForm", "FFPresenter", GetArgs(root, key, ffpresenterId));

            //#2
            //var model = new FFPresenterModel();
            //model.SetProperties(template, activityParameters);
            //htmlHelper.RenderPartial("~/Areas/FlexForms/Views/FFPresenter/ShowFlexibleForm.ascx", model);

            //#3
            //var ffPresenter = new FFPresenterController();
            //return ffPresenter.ShowFlexibleForm(template, activityParameters);

        }
    }
}