using System.Web.Mvc;
using eidss.model.Model.FlexibleForms.FlexNodes;

namespace eidss.webclient.Areas.FlexForms.Controllers.Components
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
