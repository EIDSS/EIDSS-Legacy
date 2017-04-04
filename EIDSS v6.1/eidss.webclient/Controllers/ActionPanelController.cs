using System.Collections.Generic;
using System.Web.Mvc;
using bv.common.Enums;
using bv.model.Model.Core;
using eidss.webclient.Models;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
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
            var model = new ActionPanelModel(accessor, obj, new List<ActionMetaItem>(meta.Actions), panelType);
            return View(model);
        }

    }
}
