using System.Web.Mvc;
using eidss.webui.Areas.FlexForms.Models.FlexNodes;

namespace eidss.webui.Areas.FlexForms.Controllers.Components
{
    public class ParameterTemplateController : Controller
    {
        //
        // GET: /ParameterTemplate/

        //public ActionResult ParameterTemplateRender(FFRenderModel renderModel, ParameterTemplate parameterTemplate)
        public ActionResult ParameterTemplateRender(FlexNode flexNode)
        {
            //renderModel.ParameterList.Add(parameterTemplate);
            return PartialView(flexNode);
        }

    }
}
