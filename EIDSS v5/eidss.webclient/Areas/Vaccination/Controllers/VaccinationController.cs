using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using Telerik.Web.Mvc.UI;
using eidss.model.Enums;
using System.Collections.Generic;
using System;
using eidss.model.Resources;

namespace eidss.webclient.Areas.Vaccination.Controllers
{
    public class VaccinationController : Controller
    {
        //
        // GET: /Vaccination/Vaccination/
        private const string KEY_FOR_TEMP_ITEM_STORAGE = "VaccinationListItem";
        private string m_errorMsg;
        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }

        public ActionResult VetCaseVaccination(long root, string name, EditableList<VaccinationListItem> items, bool readOnly = false)
        {
            SetViewData(root, name);
            ViewData["ReadOnly"] = readOnly;            
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new VaccinationListItem.VaccinationListItemGridModelList(root, items);
            return PartialView(model);
        }



        public ActionResult Details(long key, string name, long? idfVaccination)
        {
            SetViewData(key, name);
            VaccinationListItem item = null;
            if (idfVaccination.HasValue && idfVaccination.Value > 0)
            {
                item = (ModelStorage.Get(Session.SessionID, key, name) as EditableList<VaccinationListItem>)
                        .Where(a => a.idfVaccination == idfVaccination).FirstOrDefault();
                ViewBag.Title = Translator.GetMessageString("titleEditVaccination");
            }
            else
            {
                var vc = ModelStorage.GetRoot(Session.SessionID, key, name) as VetCase;
                var _hacode = vc._HACode;
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    item = (VaccinationListItem)VaccinationListItem.Accessor.Instance(null).CreateNew(manager, vc, _hacode);
                    item.idfVetCase = key;                      
                }
                ViewBag.Title = Translator.GetMessageString("titleAddVaccination");
            }
            ViewBag.HerdsAndSpecies = StorageItemsExtractor.CurrentHerdAndSpeciesOfCase(Session.SessionID, key);
            ModelStorage.Put(Session.SessionID, key, key, KEY_FOR_TEMP_ITEM_STORAGE, item);
            return View(item);
        }


        [HttpPost]
        public ActionResult Details(long key, string name, long? idfVaccination, FormCollection form)
        {
            var vaccination = ModelStorage.Get(Session.SessionID, key, KEY_FOR_TEMP_ITEM_STORAGE) as VaccinationListItem;            
            vaccination.ParseFormCollection(form);
            vaccination.Validation += object_ValidationDetails;
            
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                VaccinationListItem.Accessor.Instance(null).Validate(manager, vaccination, true, true, false);
            }
            vaccination.Validation -= object_ValidationDetails;            
            
            if (!String.IsNullOrWhiteSpace(m_errorMsg))
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_errorMsg };
            }

            var parent = ModelStorage.GetRoot(Session.SessionID, key, null) as VetCase;           

            var spec = parent.Farm.FarmTree.Where(s => s.idfParty == vaccination.idfSpecies).FirstOrDefault();

            if (spec != null)
            {
                vaccination.strSpecies = String.Format("{0}/{1}", spec.strHerdName, spec.strSpeciesName);
            }

            if (!idfVaccination.HasValue || idfVaccination == 0)
            {
                var list = parent.Vaccination;
                list.Add(vaccination);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };            
        }


        public ActionResult Add(long key, string name)
        {            
            var root = ModelStorage.GetRoot(Session.SessionID, key, name) as VetCase;
            ViewData["root"] = key;
            ViewData["name"] = name;
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var item = VaccinationListItem.Accessor.Instance(null).CreateNewT(manager, root, root._HACode);
                    item.idfVetCase = key;
                    ModelStorage.Put(Session.SessionID, key, key, KEY_FOR_TEMP_ITEM_STORAGE, item);
                    ViewBag.HerdsAndSpecies = StorageItemsExtractor.CurrentHerdAndSpeciesOfCase(Session.SessionID, key);
                    return View(item);
                }       
        }

        [HttpPost]
        public ActionResult Add(long key, string name, FormCollection form)
        {
            var vaccination = ModelStorage.Get(Session.SessionID, key, KEY_FOR_TEMP_ITEM_STORAGE) as VaccinationListItem;
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<VaccinationListItem>;
            vaccination.ParseFormCollection(form);
            vaccination.Validation += object_ValidationDetails;
            vaccination.Validate();
            vaccination.Validation -= object_ValidationDetails;                      
            list.Add(vaccination);
            
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "All ok" };
        }

        void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            m_errorMsg = String.Format(EidssMessages.Get(args.MessageId), args.PropertyName);
        }
    }
}
