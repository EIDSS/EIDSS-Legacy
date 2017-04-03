using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Enums;
using System;
using eidss.webclient.Areas.HerdEpi.Utils;


namespace eidss.webclient.Areas.HerdEpi.Controllers
{
    public class FlockController : Controller
    {
        #region Private Members
        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }

        // commented because these fields are assigned but never used
        //private const string KEY_FOR_TEMP_ITEM_STORAGE = "Species_Item";
        //private string m_errorMsg = "";
        #endregion

        #region HerdEpi
        public ActionResult Index(long root, string name, EditableList<VetFarmTree> items, bool readOnly)
        {
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            ViewData["ReadOnly"] = readOnly;
            SetViewData(root, name);
            items.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
            var model = new VetFarmTree.VetFarmTreeGridModelList(root, items);
            return PartialView(model);
        }


        public ActionResult Create(long key, string name)
        {
            string errorMsg = string.Empty;
            if (VetFarmTreeProcessor.CreateFlock(Session.SessionID, key, name, out errorMsg))
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
            else
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = errorMsg };
        }

        public ActionResult SpeciesDetail(long key, string name, long? idfParty, long? idfSpecies)
        {
            SetViewData(key, name);
            ViewBag.ParentPartySelection = StorageItemsExtractor.HerdsOfCase(Session.SessionID, key, name);
            return View(VetFarmTreeProcessor.GetSpecies(Session.SessionID, key, name, idfParty, idfSpecies));
        }

        [HttpPost]
        public ActionResult SpeciesDetail(long key, string name, long? idfParty, long? idfSpecies, FormCollection form)
        {
            SetViewData(key, name);
            string errormsg = string.Empty;
            if (VetFarmTreeProcessor.UpdateSpecies(Session.SessionID, key, name, !(idfSpecies.HasValue && idfSpecies.Value > 0), form, out errormsg))
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
            else
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = errormsg };
        }

        #endregion
        #region ROOTFARM
        public ActionResult ByFarm(long root, string name, EditableList<RootFarmTree> items, bool isReadOnly)
        {
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            items.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
            SetViewData(root, name);
            var model = new RootFarmTree.RootFarmTreeGridModelList(root, items);
            return PartialView(model);
        }

        public ActionResult CreateRoot(long key, string name)
        {
            string errorMsg = string.Empty;
            if (RootFarmTreeProcessor.CreateFlock(Session.SessionID, key, name, out errorMsg))
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
            else
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = errorMsg };
        }

        public ActionResult RootSpeciesDetail(long key, string name, long? idfSpecies)
        {
            SetViewData(key, name);
            ViewBag.ParentPartySelection = StorageItemsExtractor.HerdsOfRootFarm(Session.SessionID, key, name);
            return View(RootFarmTreeProcessor.GetSpecies(Session.SessionID, key, name, idfSpecies));
        }

        [HttpPost]
        public ActionResult RootSpeciesDetail(long key, string name, long? idfSpecies, FormCollection form)
        {
            SetViewData(key, name);
            string errormsg = string.Empty;
            if (RootFarmTreeProcessor.UpdateSpecies(Session.SessionID, key, name, !(idfSpecies.HasValue && idfSpecies.Value > 0), form, out errormsg))
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
            else
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = errormsg };
        }
        #endregion
    }
}
