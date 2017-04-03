using System.Web.Mvc;
using eidss.model.Model.FlexibleForms.FlexNodes;

namespace eidss.webclient.Areas.FlexForms.Controllers.Components
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
