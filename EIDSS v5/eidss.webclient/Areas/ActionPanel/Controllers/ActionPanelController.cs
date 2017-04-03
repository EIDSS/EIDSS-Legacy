using System.Web.Mvc;
using bv.common.Enums;
using bv.model.Model.Core;
using eidss.webclient.Areas.ActionPanel.Models;

namespace eidss.webclient.Areas.ActionPanel.Controllers
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
        public ActionResult Index(IObjectAccessor accessor, IObject obj, ActionsPanelType panelType)
        {
            var rd = ControllerContext.ParentActionViewContext.RouteData;
            ViewBag.CurrentController = rd.GetRequiredString("controller");
            var meta= (IObjectMeta)accessor;
            var model = new ActionPanelModel(accessor, obj, meta.Actions, panelType);
            return View(model);
        }

    }
}
