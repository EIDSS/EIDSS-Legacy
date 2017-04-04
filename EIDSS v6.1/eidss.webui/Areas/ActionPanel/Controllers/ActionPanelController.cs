using System.Web.Mvc;
using bv.common.Enums;
using bv.model.Model.Core;
using eidss.webui.Areas.ActionPanel.Models;

namespace eidss.webui.Areas.ActionPanel.Controllers
{
    public class ActionPanelController : Controller
    {
        //
        // GET: /ActionPanel/ActionPanel/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessor"></param>
        /// <param name="panelType"></param>
        /// <returns></returns>
        public ActionResult Index(IObjectAccessor accessor, ActionsPanelType panelType)
        {
            var rd = ControllerContext.ParentActionViewContext.RouteData;
            ViewBag.CurrentController = rd.GetRequiredString("controller");
            var meta= (IObjectMeta)accessor;
            var model = new ActionPanelModel(accessor, meta.Actions, panelType);
            return View(model);
        }

    }
}
