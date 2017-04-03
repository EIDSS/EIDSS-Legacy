using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using System.Collections.Generic;
using System;
using eidss.model.Resources;

namespace eidss.webclient.Areas.Animals.Controllers
{
    public class AnimalsController : Controller
    {
        
        #region Private Members
        private const string KEY_FOR_TEMP_ITEM_STORAGE = "AnimalListItemEditions";

        private string m_errorMsg = "";

        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }
        #endregion

        public ActionResult List(long root, string name, EditableList<AnimalListItem> items, bool readOnly)
        {
            SetViewData(root, name);
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            ViewData["ReadOnly"] = readOnly;
            var model = new AnimalListItem.AnimalListItemGridModelList(root, items);
            return PartialView(model);
        }

        public ActionResult Details(long key, string name, long? idfAnimal)
        {
            idfAnimal = idfAnimal == 0 ? null : idfAnimal;
            var speciesList = StorageItemsExtractor.CurrentHerdAndSpeciesOfCase(Session.SessionID, key, idfAnimal);
            var vetcase = ModelStorage.GetRoot(Session.SessionID, key, null) as VetCase;

            SetViewData(key, name);
            AnimalListItem item = null;
            if (idfAnimal.HasValue && idfAnimal.Value > 0)
            {
                item = (ModelStorage.Get(Session.SessionID, key, name) as EditableList<AnimalListItem>)
                        .Where(a => a.idfAnimal == idfAnimal).FirstOrDefault();              
            }
            else
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    item = (AnimalListItem)AnimalListItem.Accessor.Instance(null).CreateAnimal(manager, vetcase, vetcase.idfsDiagnosis);
                    idfAnimal = item.idfAnimal;                    
                }
            }
            ViewBag.SpeciesSelection = speciesList;
            ModelStorage.Put(Session.SessionID, idfAnimal.Value, idfAnimal.Value, string.Empty, item);
            return View(item);
        }

        [HttpPost]
        public ActionResult Details(long key, string name, long? idfAnimal, FormCollection form)
        {
            if (!idfAnimal.HasValue || idfAnimal == 0)
            {
                idfAnimal = Convert.ToInt64(form["idfAnimal"]);
            }

            var animal = ModelStorage.Get(Session.SessionID, idfAnimal.Value, string.Empty) as AnimalListItem;            
            animal.ParseFormCollection(form);
            animal.Validation += object_ValidationDetails;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                AnimalListItem.Accessor.Instance(null).Validate(manager, animal, true, true, false);                
            }

            animal.Validation -= object_ValidationDetails;
            if (!String.IsNullOrWhiteSpace(m_errorMsg))
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_errorMsg };
            }

            var parent = ModelStorage.GetRoot(Session.SessionID, key, null) as VetCase;
            
            var spec = parent.Farm.FarmTree.Where(s => s.idfParty == animal.idfSpecies).FirstOrDefault();

            if (spec != null)
            {
                animal.CopyMainProperties(spec);
            }

            var list = parent.AnimalList;
            if (list.Count(a=>a.idfAnimal == idfAnimal) == 0)
            {                
                list.Add(animal);
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }
        
        public ActionResult Delete(long key, string name, long? idfAnimal)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<AnimalListItem>;
            var item = list.Where(l => l.idfAnimal == idfAnimal).FirstOrDefault();
            item.Validation += object_ValidationDetails;
            if (item.MarkToDelete())
            {
                item.Validation -= object_ValidationDetails;
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
            }
            else
            {
                item.Validation -= object_ValidationDetails;
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = m_errorMsg };
            }
            
        }
        void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            m_errorMsg = EidssMessages.GetValidationErrorMessage(args);
        }

        public ActionResult SelectAnimalAge(long idfAnimal)
        {
            var animal = ModelStorage.Get(Session.SessionID, idfAnimal, null) as AnimalListItem;
            var lookup = animal.AnimalAgeLookup;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(lookup, "idfsReference", "name") };
        }
    }
}
