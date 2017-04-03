using System.Web.Mvc;
using eidss.model.Schema;
using BLToolkit.EditableObjects;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Resources;

namespace eidss.webclient.Areas.ActiveSurveillence.Controllers
{
    [AuthorizeEIDSS]
    public class SessionController : Controller
    {
        //
        // GET: /ActiveSurveillence/Session/

        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }

        public ActionResult ByCampaign(long root, string name, EditableList<AsMonitoringSession> items,  bool isReadOnly)
        {
            SetViewData(root, name);
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new AsMonitoringSession.AsMonitoringSessionGridModelList(root, items);
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult RemoveSession(long root, long idfSession)
        {
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SelectSession(long root, long idfSession)
        {
            string msg = null;
            try
            {
                AsCampaign campaign = ModelStorage.Get(Session.SessionID, root, "") as AsCampaign;

                if (AsCampaign.AssignCampaignToSession(campaign, idfSession))
                    msg = "ok";
            }
            catch (ValidationModelException ex)
            {
                msg = EidssMessages.GetValidationErrorMessage(ex);
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}
