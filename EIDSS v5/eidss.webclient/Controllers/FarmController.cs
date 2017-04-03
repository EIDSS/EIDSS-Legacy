using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.webclient.Utils;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Enums;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class FarmController : Controller
    {
        //
        // GET: /Farm/
        #region Farms
        public ActionResult Select()
        {
            var accessor = FarmListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            FarmListItem.FarmListItemGridModelList list = GetGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.FarmSelectList, "Grid", list);

            return View(accessor);
        }


        [HttpPost]
        public ActionResult Select(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, FarmListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            FarmListItem.FarmListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.FarmSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static FarmListItem.FarmListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<FarmListItem> items = GetFarmList(filter);
            var list = new FarmListItem.FarmListItemGridModelList(AutoGridRoots.FarmSelectList, items);
            return list;
        }

        private static List<FarmListItem> GetFarmList(FilterParams filter)
        {
            var accessor = FarmListItem.Accessor.Instance(null);

            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<FarmListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }


        #endregion

        #region ROOT farms

        public ActionResult AsSessionFarmDetails(long? id, long? idfMonitoringSession)
        {
            ViewBag.NotifyOpener = false;
            if (id == 0)
                id = null;
            FarmPanel farm = null;
            if (id.HasValue && idfMonitoringSession.HasValue && idfMonitoringSession > 0)
            {
                var session = ModelStorage.Get(Session.SessionID, idfMonitoringSession.Value, "", false) as AsSession;
                if (session != null)
                {
                    if (session.ASFarms.Count(f => f.idfFarm == id) == 1)
                    {
                        farm = session.ASFarms.Single(f => f.idfFarm == id).Farm;
                        farm._HACode = farm._HACode ?? (int)HACode.Livestock;
                    }
                }
            }
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                if (farm == null)
                {

                    var acc = FarmPanel.Accessor.Instance(null);
                    farm = id.HasValue ? acc.SelectByKey(manager, id.Value) : acc.CreateByHACode(manager, null, (int?)HACode.Livestock);
                    farm._HACode = farm._HACode ?? (int)HACode.Livestock;
                    foreach (VetFarmTree farmTreeItem in farm.FarmTree)
                    {
                        farmTreeItem._HACode = farmTreeItem._HACode ?? farm._HACode;
                    }
                }
                if (farm.FarmTree.Count == 0)
                {
                    farm.FarmTree.Add(VetFarmTree.Accessor.Instance(null).CreateFarm(manager, farm, farm));
                }
            }




            ModelStorage.Put(Session.SessionID, farm.idfFarm, farm.idfFarm, null, farm);

            return View(farm);
        }

        [HttpPost]
        public ActionResult AsSessionFarmDetails(FormCollection form)
        {
            var key = long.Parse(form["idfFarm"]);
            var farm = ModelStorage.Get(Session.SessionID, key, null) as FarmPanel;

            var clone = (IObject)farm.Clone();
            ViewData["ErrorMessage"] = null;

            farm.ParseFormCollection(form);
            farm.Location.CopyAddressValues(farm.Address);
            farm.Validation += object_ValidationDetails;
            farm.blnRootFarm = false;
            farm._HACode = farm._HACode ?? (int)HACode.Livestock;

            farm.Location.CopyAddressValues(farm.Address);
            var idsession = farm.idfMonitoringSession;
            farm.idfMonitoringSession = null;
            if (ViewData["ErrorMessage"] == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = FarmPanel.Accessor.Instance(null);
                    acc.Post(manager, farm);
                }
            }
            farm.idfMonitoringSession = idsession;
            farm.Validation -= object_ValidationDetails;

            CompareModel comparision = new CompareModel();

            if (ViewData["ErrorMessage"] != null)
            {
                comparision = farm.Compare(clone);
                comparision.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewData["ErrorMessage"].ToString(),
                                false, false, false);
            }
            else
            {
                comparision = farm.Compare(clone);
            }

            return Json(comparision, JsonRequestBehavior.AllowGet);
        }

        void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            ViewData["ErrorMessage"] = EidssMessages.GetValidationErrorMessage(args);
        }


        #endregion
    }
}
