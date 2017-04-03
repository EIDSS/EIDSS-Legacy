using System.Collections.Generic;
using System.Web.Mvc;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.webclient.Utils;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Enums;
using System.Collections.Specialized;
using System.Web;
using System;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class ASCampaignController : Controller
    {

        #region Campaign
        public ActionResult Index()
        {
            var accessor = AsCampaignListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            ViewBag.Filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);

            
            return View(accessor);         
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, AsCampaignListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            AsCampaignListItem.AsCampaignListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.AsCampaignList, AutoGridRoots.AsCampaignList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(long? id)
        {
            if (id == 0)
                id = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = AsCampaign.Accessor.Instance(null);
                var camp = id.HasValue ? acc.SelectByKey(manager, id.Value) : acc.CreateNewT(manager, null);
                ModelStorage.Put(Session.SessionID, camp.idfCampaign, camp.idfCampaign, null, camp);                                
                return View(camp);
            }

        }
        

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            var key = long.Parse(form["idfCampaign"]);
            var camp = ModelStorage.Get(Session.SessionID, key, null) as AsCampaign;

            var clone = (IObject)camp.Clone();

            ViewData["ErrorMessage"] = null;

            camp.ParseFormCollection(form, true, false);

            if (String.IsNullOrWhiteSpace(form["actualsave"])) // if not real submission
            {
                return Json("ok", JsonRequestBehavior.AllowGet);         
            }

            camp.Validation += object_ValidationDetails;

            if (ViewData["ErrorMessage"] == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = AsCampaign.Accessor.Instance(null);
                    acc.Post(manager, camp);
                }
            }

            camp.Validation -= object_ValidationDetails;


            CompareModel comparision = new CompareModel();

            if (ViewData["ErrorMessage"] != null)
            {
                comparision.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewData["ErrorMessage"].ToString(),
                                false, false, false);
            }
            else
            {
                comparision = camp.Compare(clone);
            }

            return Json(comparision, JsonRequestBehavior.AllowGet);         
        }

        [HttpGet]
        public ActionResult RemoveSession(long idfCampaign, long idfSession)
        {
            var camp = ModelStorage.Get(Session.SessionID, idfCampaign, null) as AsCampaign;

            int sessionIndexInList = camp.Sessions.FindIndex(x=>x.idfMonitoringSession == idfSession);
            if (sessionIndexInList > -1)
            {
                camp.Sessions[sessionIndexInList].MarkToDelete();
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Invalid input", JsonRequestBehavior.AllowGet);         
            }

        }

        #endregion

        void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            ViewData["ErrorMessage"] = EidssMessages.GetValidationErrorMessage(args);
        }

        

        public ActionResult Select()
        {
            var accessor = AsCampaignListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            filter.Add("idfsCampaignStatus", "=", (long)AsCampaignStatus.Open);
            ViewBag.Filter = filter;
            AsCampaignListItem.AsCampaignListItemGridModelList list = GetGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.AsCampaignSelectList, "Grid", list);

            return View(accessor);
        }


        [HttpPost]
        public ActionResult Select(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, AsCampaignListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            AsCampaignListItem.AsCampaignListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.AsCampaignList, AutoGridRoots.AsCampaignList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static AsCampaignListItem.AsCampaignListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<AsCampaignListItem> items = GetAsCampaignList(filter);
            var list = new AsCampaignListItem.AsCampaignListItemGridModelList(AutoGridRoots.AsCampaignSelectList, items);
            return list;
        }
        
        private static List<AsCampaignListItem> GetAsCampaignList(FilterParams filter)
        {
            var accessor = AsCampaignListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<AsCampaignListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }
    }
}
