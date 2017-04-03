using System.Web.Mvc;
using eidss.webui.Areas.FlexForms.Models.FlexNodes;

namespace eidss.webui.Areas.FlexForms.Controllers.Components
{
    public class LabelController : Controller
    {
        //
        // GET: /Label/

        public ActionResult LabelRender(FlexNode flexNode)
        {
            return PartialView(flexNode);
        }

    }
}
