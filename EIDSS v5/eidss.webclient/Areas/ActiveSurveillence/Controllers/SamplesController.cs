using System;
using System.Linq;
using System.Web.Mvc;
using eidss.model.Schema;
using eidss.webclient.Utils;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Resources;
using eidss.model.Enums;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace eidss.webclient.Areas.ActiveSurveillence.Controllers
{
    public class SamplesController : Controller
    {
        private void SetViewData(long root, string name)
        {
            ViewData["root"] = root;
            ViewData["name"] = name;
        }
        private const string KEY_FOR_TEMP_ITEM_STORAGE = "SampleListItemEditions";
        private const string KEY_FOR_TEMP_ANIMAL = "SampleListItemAnimal";
        //
        // GET: /ActiveSurveillence/Samples/

        public ActionResult List(long root, string name, EditableList<eidss.model.Schema.AsSessionTableViewItem> items, bool isReadOnly)
        {
            SetViewData(root, name);
            ViewData["IsReadOnly"] = isReadOnly;
            ModelStorage.Put(Session.SessionID, root, root, name, items);
            var model = new AsSessionTableViewItem.AsSessionTableViewItemGridModelList(root, items);
            return PartialView(model);
        }

        public ActionResult Copy(long root, string name, long idfSample, byte number)
        {
            var session = ModelStorage.GetRoot(Session.SessionID, root, "") as AsSession;
            session.CreateDetailsCopy(idfSample, number);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }

        [HttpGet]
        public ActionResult GetTotals(long root)
        {
            var session = ModelStorage.Get(Session.SessionID, root, "") as AsSession;
            Dictionary<string, int> totals = new Dictionary<string, int>();

            totals.Add(String.Format("#{0}intTotalDiagnosedAnimals", session.ObjectIdent), session.intTotalDiagnosedAnimals);
            totals.Add(String.Format("#{0}intTotalSamplesInDetails", session.ObjectIdent), session.intTotalSamplesInDetails);

            return Json(
                totals,
                JsonRequestBehavior.AllowGet
                );
        }


        public ActionResult Details(long root, string name, long idfTableViewItem)
        {
            SetViewData(root, name);
            ViewBag.Close = false;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var session = ModelStorage.GetRoot(Session.SessionID, root, "") as AsSession;
                AsSessionTableViewItem item = null;
                if (idfTableViewItem == 0)
                {
                    item = AsSessionTableViewItem.Accessor.Instance(null).CreateFromSession(manager, session, session);
                    item.id = session.DetailsTableView.Count() + 1;
                }
                else
                {
                    if (session != null && session.DetailsTableView.Count(x => x.id == idfTableViewItem) > 0)
                        item = session.DetailsTableView.Where(x => x.id == idfTableViewItem).First();
                }

                SetSpeciesAndAnimals(item, session);

                ModelStorage.Put(Session.SessionID, root, item.id, "", item);
                ModelStorage.Put(Session.SessionID, root, root, KEY_FOR_TEMP_ITEM_STORAGE, item);
                return View(item);
            }
        }

        #region helpers
        private void SetSpeciesAndAnimals(AsSessionTableViewItem item, AsSession session)
        {
            if (item != null && item.idfFarm > 0)
            {
                if (session.Diseases.Count(x => !x.IsMarkedToDelete) > 0
                   && session.Diseases.Count(x => !x.IsMarkedToDelete && !x.idfsSpeciesType.HasValue) == 0)
                {
                    ViewBag.SpeciesList = new SelectList(
                        session.ASSpecies
                            .Where(s => s.idfFarm == item.idfFarm)
                            .Join(
                                    session.Diseases.Where(d => d.idfsSpeciesType.HasValue && !d.IsMarkedToDelete),
                                    x => x.idfsReference,
                                    y => y.idfsSpeciesType.Value,
                                    (x, y) => x)
                            .Distinct()
                            .ToList(),
                        "idfSpecies", "DisplayName",
                        item.idfSpecies);
                }
                else
                {
                    ViewBag.SpeciesList = new SelectList(
                        session.ASSpecies.Where(s => s.idfFarm == item.idfFarm),
                        "idfSpecies", "DisplayName",
                        item.idfSpecies);
                }
                ViewBag.AnimalsList = new SelectList(
                    session.DetailsTableView.Where(x => x.idfFarm == item.idfFarm).Select(s => new { s.idfAnimal, s.strAnimalCode }).Distinct(),
                    "idfAnimal", "strAnimalCode",
                    item.idfAnimal);
            }
            else
            {
                ViewBag.SpeciesList = ViewBag.AnimalsList = new SelectList(new List<SelectListItem>());
            }

        }


        private AsSessionAnimal GetAnimal(DbManagerProxy manager, AsSession session, AsSessionTableViewItem line, string animalData)
        {
            var currentAnimal = ModelStorage.Get(Session.SessionID, session.idfMonitoringSession, KEY_FOR_TEMP_ANIMAL, false) as AsSessionAnimal;

            if (currentAnimal == null)
            {
                currentAnimal = (AsSessionAnimal)AsSessionAnimal.Accessor.Instance(null).CreateInSession(manager, session, line);
                int animalCount = session.ASAnimals.Count() + 1;
                currentAnimal.strAnimalCode = animalData == (animalCount * (-1)).ToString() ? string.Format("(new {0})", animalCount) : animalData;
            }

            return currentAnimal;
        }

        private AsSessionSample GetSample(DbManagerProxy manager, AsSession session, AsSessionTableViewItem line)
        {
            var sample = AsSessionSample.Accessor.Instance(null).Create(manager, session, (int)HACode.Livestock, line.idfsSpeciesType);
            sample.SampleType = line.SampleType;
            sample.strFieldBarcode = line.strFieldBarcode;
            sample.datFieldCollectionDate = line.datFieldCollectionDate;
            sample.idfsSpecimenType = line.idfsSpecimenType.Value;
            sample.idfMonitoringSession = session.idfMonitoringSession;
            sample.strFarmCode = line.strFarmCode;
            return sample;
        }
        #endregion

        [HttpPost]
        public ActionResult Details(long root, string name, long idfTableViewItem, FormCollection form)
        {
            SetViewData(root, name);
            ViewBag.Close = false;


            var line = ModelStorage.Get(Session.SessionID, root, KEY_FOR_TEMP_ITEM_STORAGE) as AsSessionTableViewItem;
            var session = ModelStorage.Get(Session.SessionID, line.idfMonitoringSession, "") as AsSession;


            if (String.IsNullOrEmpty(form[String.Format("{0}idfFarm", line.ObjectIdent)]) 
                    || form[String.Format("{0}idfFarm", line.ObjectIdent)] == "0")
            {
                SetSpeciesAndAnimals(line, session);
                ViewBag.ErrorMessage = EidssMessages.GetValidationErrorMessage(new ValidationEventArgs(
                    "idfFarm",
                    "idfFarm",
                    "idfFarm",
                    null,
                    typeof(bv.model.Model.Validators.RequiredValidator),
                    line, false));
                return View(line);
            }

            //check animal id
            long idfAnimal = line.idfAnimal ?? 0;
            string animalFormKey = String.Format("{0}idfAnimal", line.ObjectIdent);            

            line.Validation += object_validation;
            session.Validation += object_validation;

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (idfAnimal == 0 && line.idfSpecies.HasValue)
                {
                    var currentAnimal = GetAnimal(manager, session, line, form[animalFormKey]);
                    session.ASAnimals.Add(currentAnimal);
                    line.idfAnimal = currentAnimal.idfAnimal;
                }

                NameValueCollection collection = (form as NameValueCollection);
                collection.Remove(animalFormKey);
                
                line.ParseFormCollection(collection);
                                
                if (line.SampleType != null && !line.idfMaterial.HasValue)
                {
                    line.strSpecimenName = line.SampleType.name;
                    var sample = GetSample(manager, session, line);
                    session.ASSamples.Add(sample);
                    if (session.ASSamples.Contains(sample))
                    {
                        line.idfMaterial = sample.idfMaterial;
                    }
                }

                AsSessionTableViewItem.Accessor.Instance(null).Validate(manager, line, true, true, false);
                

                if (session.ASAnimals.Count(a => a.idfAnimal == line.idfAnimal) > 0)
                    line.UpdateAnimal(session.ASAnimals.Single(a => a.idfAnimal == line.idfAnimal));

                SetSpeciesAndAnimals(line, session);

                if (line.idfMaterial.HasValue)
                {
                    line.UpdateSample(session.ASSamples.Single(a => a.idfMaterial == line.idfMaterial));
                    if (!line.idfsSpecimenType.HasValue)
                    {
                        AsSessionSample sample = session.ASSamples.Single(m => m.idfMaterial == line.idfMaterial);
                        session.ASSamples.Remove(sample);
                        line.idfMaterial = null;
                    }
                }
                
                if (String.IsNullOrEmpty(ViewBag.ErrorMessage))
                {
                    line.id = line.idfMaterial ?? line.idfAnimal ?? line.idfFarm;                    
                    if (!session.DetailsTableView.Contains(line))
                    {                        
                        session.DetailsTableView.Add(line);
                        ModelStorage.Put(Session.SessionID, session.idfMonitoringSession, session.idfMonitoringSession, name, session.DetailsTableView);
                    }

                    if (String.IsNullOrEmpty(ViewBag.ErrorMessage))
                    {
                        ViewBag.Close = true;
                        ModelStorage.Remove(Session.SessionID, root, KEY_FOR_TEMP_ANIMAL);
                    }
                }

                line.Validation -= object_validation;
                session.Validation -= object_validation;

                try
                {
                    AsSession.NewTableItemIsValid(session, line);
                }
                catch (ValidationModelException e)
                {
                    ViewBag.ErrorMessage = EidssMessages.GetValidationErrorMessage(e);
                    ViewBag.Close = false;
                }


                if (!String.IsNullOrEmpty(ViewBag.ErrorMessage))
                    ViewBag.ErrorMessage = ViewBag.ErrorMessage.Replace("*Species*", line.strSpeciesType);
            }
            return View(line);
        }

        void object_validation(object sender, ValidationEventArgs args)
        {
            ViewBag.ErrorMessage = EidssMessages.GetValidationErrorMessage(args);
        }
        #region Ajax Data Population

        //public ActionResult GetSpeciesList(long idfMonitoringSession, string idValue)
        //{
        //    //idvalue == idfFarmActual
        //    var line = ModelStorage.Get(Session.SessionID, idfMonitoringSession, KEY_FOR_TEMP_ITEM_STORAGE) as AsSessionTableViewItem;
        //    var session = ModelStorage.Get(Session.SessionID, idfMonitoringSession, "") as AsSession;
        //    if (line == null || session == null)
        //        return Json(EidssMessages.Get("Error_SessionExpired"), JsonRequestBehavior.AllowGet);

        //    string[] farmKeys = idValue.Split(new char[] { ',' });
        //    long? idfFarm = null;
        //    long idfFarmRoot = 0;
        //    if (farmKeys.Length == 1)
        //        idfFarmRoot = Int64.Parse(idValue);
        //    else
        //    {
        //        idfFarmRoot = Int64.Parse(farmKeys[0]);
        //        idfFarm = Int64.Parse(farmKeys[1]);
        //    }
        //    line.idfFarm = session.GetNewFarmForChild(idfFarmRoot, idfFarm);

        //    return Json(data: eidss.webclient.Areas.ActiveSurveillence.Helpers.Utils.GetSpeciesListDictionarySessionChildRefresh(session, line.idfFarm, line.strFarmCode, line.ObjectIdent),
        //                behavior: JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetSpeciesList(long idfMonitoringSession, long? idfFarmActual, long? idfFarm)
        {
            var line = ModelStorage.Get(Session.SessionID, idfMonitoringSession, KEY_FOR_TEMP_ITEM_STORAGE) as AsSessionTableViewItem;
            var session = ModelStorage.Get(Session.SessionID, idfMonitoringSession, "") as AsSession;
            if (line == null || session == null)
                return Json(EidssMessages.Get("Error_SessionExpired"), JsonRequestBehavior.AllowGet);

            

            if (session.ASFarms.Count(f => f.idfRootFarm == idfFarmActual) == 0 && !idfFarm.HasValue)
            {
                line.idfFarm = session.GetNewFarmForChild(idfFarmActual.Value, idfFarm);
                return Json(line.idfFarm, JsonRequestBehavior.AllowGet);
            }

            line.idfFarm = session.GetNewFarmForChild(idfFarmActual.Value, idfFarm);
            return Json(data: eidss.webclient.Areas.ActiveSurveillence.Helpers.Utils.GetSpeciesListDictionarySessionChildRefresh(session, line.idfFarm, line.strFarmCode, line.ObjectIdent),
                        behavior: JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnimalsList(long idfMonitoringSession, long idValue)
        {
            var session = ModelStorage.Get(Session.SessionID, idfMonitoringSession, "") as AsSession;
            var line = ModelStorage.Get(Session.SessionID, idfMonitoringSession, KEY_FOR_TEMP_ITEM_STORAGE) as AsSessionTableViewItem;
            if (session == null || line == null)
                return Json(EidssMessages.Get("Error_SessionExpired"), JsonRequestBehavior.AllowGet);

            line.idfSpecies = idValue;

            var spec = session.ASSpecies.Where(x => x.idfSpecies == idValue).First().idfsReference;
            line.SpeciesType = line.SpeciesTypeLookup.Single(x => x.idfsBaseReference == spec);
            line.idfsSpeciesType = spec;

            var animals = session.ASAnimals.Where(x => x.idfSpecies == idValue).Distinct().Select(animal => new { idfAnimal = animal.idfAnimal, strAnimalCode = animal.strAnimalCode }).ToList();
            animals.Add(new { idfAnimal = (long)(-1 * (session.ASAnimals.Count + 1)), strAnimalCode = String.Format("(new {0})", (session.ASAnimals.Count + 1))});

            var animalAge = new SelectList(line.AnimalAgeLookup, "idfsReference", "name");
            return Json((new Dictionary<string, object> {
                                {String.Format("{0}idfAnimal",line.ObjectIdent), new SelectList(animals, "idfAnimal", "strAnimalCode")},
                                {String.Format("{0}AnimalAge", line.ObjectIdent), animalAge }
                            }).ToArray()
                        , JsonRequestBehavior.AllowGet);
        }

        public ActionResult AnimalIsSelected(long idfMonitoringSession, string idValue)
        {
            long idfAnimal = 0;
            var session = ModelStorage.Get(Session.SessionID, idfMonitoringSession, "") as AsSession;
            var line = ModelStorage.Get(Session.SessionID, idfMonitoringSession, KEY_FOR_TEMP_ITEM_STORAGE) as AsSessionTableViewItem;
            var currentAnimal = ModelStorage.Get(Session.SessionID, idfMonitoringSession, KEY_FOR_TEMP_ANIMAL, false) as AsSessionAnimal;

            AsSessionAnimal animal = null;

            if (long.TryParse(idValue, out idfAnimal) && idfAnimal > 0)
            {
                if (session.ASAnimals.Count(a => a.idfAnimal == idfAnimal) > 0)
                    animal = session.ASAnimals.Single(a => a.idfAnimal == idfAnimal);
            }

            if (animal == null && idfAnimal >= 0)
            {
                if (currentAnimal == null)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        animal = (AsSessionAnimal.Accessor.Instance(null).CreateInSession(manager, session, line));
                        animal.strAnimalCode = idValue;
                        idfAnimal = animal.idfAnimal;
                        ModelStorage.Put(Session.SessionID, idfMonitoringSession, idfAnimal, KEY_FOR_TEMP_ANIMAL, animal);
                        session.ASAnimals.Add(animal);
                    }
                }
                else
                {
                    currentAnimal.strAnimalCode = idValue;
                }
            }

            CompareModel data = new CompareModel();

            if (idfAnimal > 0)
            {
                IObject clone = (line as ICloneable).Clone() as IObject;
                line.idfAnimal = idfAnimal;
                data = line.Compare(clone);
            }

            return Json(data ?? new CompareModel(), JsonRequestBehavior.AllowGet);
        }
        #endregion


    }

}
