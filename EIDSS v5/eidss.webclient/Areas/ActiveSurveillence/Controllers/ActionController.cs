using System;
using System.Linq;
using System.Web.Mvc;
using eidss.model.Schema;
using eidss.webclient.Utils;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Resources;

namespace eidss.webclient.Areas.ActiveSurveillence.Controllers
{
    public class ActionController : Controller
    {
        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }
        private string m_errorMsg = "";
        private const string KEY_FOR_TEMP_ITEM_STORAGE = "ActionListItemEditions";
        public ActionResult Index(long root, string name, EditableList<AsSessionAction> items, bool isReadOnly)
        {
            SetViewData(root, name);
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new AsSessionAction.AsSessionActionGridModelList(root, items);
            return PartialView(model);
        }

        public ActionResult Details(long key, string name, long? idfAsAction)
        {
            idfAsAction = idfAsAction == 0 ? null : idfAsAction;

            SetViewData(key, name);
            AsSessionAction item = null;
            if (idfAsAction.HasValue && idfAsAction.Value > 0)
            {
                item = (ModelStorage.Get(Session.SessionID, key, name) as EditableList<AsSessionAction>)
                        .Where(a => a.idfMonitoringSessionAction == idfAsAction).FirstOrDefault();
            }
            else
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    item = (AsSessionAction)AsSessionAction.Accessor.Instance(null).CreateNew(manager, null);
                    item.idfMonitoringSession = key;
                    idfAsAction = item.idfMonitoringSessionAction;
                }
            }

            ModelStorage.Put(Session.SessionID, key, key, KEY_FOR_TEMP_ITEM_STORAGE, item);
            return View(item);
        }


        [HttpPost]
        public ActionResult Details(long key, string name, long? idfAsAction, FormCollection form)
        {
            var action = ModelStorage.Get(Session.SessionID, key, KEY_FOR_TEMP_ITEM_STORAGE) as AsSessionAction;
            
            action.Validation += object_ValidationDetails;
            action.ParseFormCollection(form);

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var acc = AsSessionAction.Accessor.Instance(null);
                acc.Validate(manager, action, true, false, false);
                
            }
            action.Validation -= object_ValidationDetails;
            if (!String.IsNullOrWhiteSpace(m_errorMsg))
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_errorMsg };
            }


            if (!idfAsAction.HasValue || idfAsAction == 0)
            {
                var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<AsSessionAction>;                

                list.Add(action);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            m_errorMsg = EidssMessages.GetValidationErrorMessage(args);
        }

    }
}
