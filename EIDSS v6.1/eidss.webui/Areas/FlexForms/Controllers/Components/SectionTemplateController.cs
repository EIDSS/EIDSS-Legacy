using System.Web.Mvc;
using eidss.webui.Areas.FlexForms.Models.FlexNodes;

namespace eidss.webui.Areas.FlexForms.Controllers.Components
{
    public class SectionTemplateController : Controller
    {
        //
        // GET: /SectionTemplate/

        //public ActionResult SectionTemplateRender(FFRenderModel renderModel, SectionTemplate sectionTemplate)
        public ActionResult SectionTemplateRender(FlexNode flexNode)
        {
            //renderModel.SectionList.Add(sectionTemplate);
            return PartialView(flexNode);
        }

    }
}
