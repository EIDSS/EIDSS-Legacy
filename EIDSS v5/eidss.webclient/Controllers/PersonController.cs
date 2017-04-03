using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Schema;
using bv.model.Model.Core;
using eidss.webclient.Utils;
using eidss.model.Resources;

namespace eidss.webclient.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            var accessor = PatientListItem.Accessor.Instance(null);
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
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, PatientListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            PatientListItem.PatientListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.PatientList, AutoGridRoots.PatientList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static PatientListItem.PatientListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<PatientListItem> items = GetPatientList(filter);
            var list = new PatientListItem.PatientListItemGridModelList(AutoGridRoots.PatientList, items);
            return list;
        }


        private static List<PatientListItem> GetPatientList(FilterParams filter)
        {
            var accessor = PatientListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<PatientListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }

        public ActionResult Details(long? id)
        {
            if (id == 0)
                id = null;
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = Patient.Accessor.Instance(null);

                var patient = id.HasValue ? acc.SelectByKey(manager, id.Value) : acc.CreateNewT(manager, null);
                ModelStorage.Put(Session.SessionID, patient.idfHuman, patient.idfHuman, string.Empty, patient);
                return View(patient);
            }            
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            if (!form.AllKeys.Contains("idfHuman")) return View();
            var key = long.Parse(form["idfHuman"]);
            
            var patient = ModelStorage.Get(Session.SessionID, key, null) as Patient;
            var clone = (IObject)patient.Clone();

            ViewData["ErrorMessage"] = null;

            patient.ParseFormCollection(form);
            patient.Validation += patient_ValidationDetails;

            if (ViewData["ErrorMessage"] == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = Patient.Accessor.Instance(null);
                    acc.Post(manager, patient);
                }
            }

            patient.Validation -= patient_ValidationDetails;



            CompareModel comparision = new CompareModel();

            if (ViewData["ErrorMessage"] != null)
            {
                comparision.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewData["ErrorMessage"].ToString(),
                                false, false, false);
            }
            else
            {
                comparision = patient.Compare(clone);
            }

            return Json(comparision, JsonRequestBehavior.AllowGet);
        }


        void patient_ValidationDetails(object sender, ValidationEventArgs args)
        {
            var message = EidssMessages.GetValidationErrorMessage(args);
            ViewData["ErrorMessage"] = message;
        }
    }
}
