using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BLToolkit.EditableObjects;
using eidss.model.Schema;

namespace eidss.webui.Areas.FlexForms
{
    public static class Extenders
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="root"></param>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="activityParameters"></param>
        /// <returns></returns>
        public static MvcHtmlString ShowFlexibleFormHTML(this HtmlHelper htmlHelper, long root, Template template, long? idfObservation, EditableList<ActivityParameter> activityParameters)
        {
            //#1
            return htmlHelper.Action("ShowFlexibleForm", "FFPresenter", GetArgs(root, template, idfObservation, activityParameters));

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
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="activityParameters"></param>
        /// <returns></returns>
        private static RouteValueDictionary GetArgs(long root, Template template, long? idfObservation, EditableList<ActivityParameter> activityParameters)
        {
            return new RouteValueDictionary { { "root", root }, { "area", "FlexForms" }, { "template", template }, { "activityParameters", activityParameters }, { "idfObservation", idfObservation } };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="root"></param>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        /// <param name="activityParameters"></param>
        public static void ShowFlexibleForm(this HtmlHelper htmlHelper, long root, Template template, long? idfObservation, EditableList<ActivityParameter> activityParameters)
        {
            //#1
            htmlHelper.RenderAction("ShowFlexibleForm", "FFPresenter", GetArgs(root, template, idfObservation, activityParameters));

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