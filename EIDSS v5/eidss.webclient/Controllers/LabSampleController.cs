using System;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Enums;
using System.Collections.Generic;
using System.Collections;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class LabSampleController : Controller
    {
        private ValidationEventArgs m_validation = null;
        //
        // GET: /LabSample/

        public ActionResult Index()
        {
            //Session["chkShowMyPref"] = "false";
            var accessor = LabSampleLogBookListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            ViewBag.Filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);

            return View(accessor);
        }

        public ActionResult IndexByPreferences()
        {
            //Session["chkShowMyPref"] = "true";
            var accessor = LabSampleLogBookMyPrefListItem.Accessor.Instance(null);
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
        public ActionResult IndexByPreferences(FormCollection form)
        {
            IObjectAccessor accessor = LabSampleLogBookMyPrefListItem.Accessor.Instance(null);
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, ((IObjectMeta)accessor).SearchPanelMeta);

            ViewBag.Filter = filter;
            ViewBag.InitObject = null;

            int totalRows = 0;

            IGridModelList list = GetPreferenceGridModelList(filter, out totalRows);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.LabSampleBookPreference, AutoGridRoots.LabSampleBookPreference, "Grid", list);

            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            IObjectAccessor accessor = LabSampleLogBookListItem.Accessor.Instance(null);

            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, ((IObjectMeta)accessor).SearchPanelMeta);

            ViewBag.Filter = filter;
            ViewBag.InitObject = null;

            int totalRows = 0;

            IGridModelList list = GetGridModelList(filter, out totalRows);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.LabSampleBook, AutoGridRoots.LabSampleBook, "Grid", list);

            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        #region static helpers

        private static FilterParams GetDefailtFilter(IObjectAccessor accessor)
        {
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = ((IObjectCreator)accessor).CreateNew(manager, null, null);
            }

            return SearchPanelHelper.GetDefaultFilter(((IObjectMeta)accessor).SearchPanelMeta, initObject);
        }


        private static LabSampleLogBookMyPrefListItem.LabSampleLogBookMyPrefListItemGridModelList GetPreferenceGridModelList(FilterParams filter, out int totalRows)
        {
            List<LabSampleLogBookMyPrefListItem> items = GetLabSampleWithMyPreferences(filter);
            totalRows = items.Count;
            var list = new LabSampleLogBookMyPrefListItem.LabSampleLogBookMyPrefListItemGridModelList(AutoGridRoots.LabSampleBookPreference, items);
            return list;
        }

        private static List<LabSampleLogBookMyPrefListItem> GetLabSampleWithMyPreferences(FilterParams filter)
        {
            var accessor = LabSampleLogBookMyPrefListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<LabSampleLogBookMyPrefListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }

        private static LabSampleLogBookListItem.LabSampleLogBookListItemGridModelList GetGridModelList(FilterParams filter, out int totalRows)
        {
            List<LabSampleLogBookListItem> items = GetLabSample(filter);
            totalRows = items.Count;
            var list = new LabSampleLogBookListItem.LabSampleLogBookListItemGridModelList(AutoGridRoots.LabSampleBookPreference, items);
            return list;
        }

        private static List<LabSampleLogBookListItem> GetLabSample(FilterParams filter)
        {
            var accessor = LabSampleLogBookListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<LabSampleLogBookListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }

        #endregion

        [HttpGet]
        public ActionResult Details(long? id)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabSample.Accessor.Instance(null);
                var hc = acc.SelectByKey(manager, id.Value);

                ModelStorage.Put(Session.SessionID, hc.idfContainer, hc.idfContainer, null, hc);
                return View(hc);
            }
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            var key = long.Parse(form["ID"]);
            var hc = ModelStorage.Get(Session.SessionID, key, null) as LabSample;

            ViewData["ErrorMessage"] = null;
            hc.Validation += hc_ValidationDetails;
            hc.ParseFormCollection(form);
            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabSample.Accessor acc = LabSample.Accessor.Instance(null);
                    acc.Post(manager, hc);
                }
            }
            hc.Validation -= hc_ValidationDetails;

            ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];

            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabSample.Accessor acc = LabSample.Accessor.Instance(null);
                    hc = acc.SelectByKey(manager, hc.idfContainer);
                    ModelStorage.Remove(Session.SessionID, hc.idfContainer, null);
                    ModelStorage.Put(Session.SessionID, hc.idfContainer, hc.idfContainer, null, hc);
                }
            }

            return View(hc);
        }

        [HttpGet]
        public ActionResult EditSample(long? id)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabSample.Accessor.Instance(null);
                var hc = acc.SelectByKey(manager, id.Value) as LabSample;
                if (hc == null) // test
                {
                    var acct = LabTest.Accessor.Instance(null);
                    var hct = acct.SelectByKey(manager, id.Value) as LabTest;
                    hc = hct.Sample;
                }

                ModelStorage.Put(Session.SessionID, hc.idfContainer, hc.idfContainer, null, hc);
                return View("Details", hc);
            }
        }

        [HttpPost]
        public ActionResult EditSample(FormCollection form)
        {
            var key = long.Parse(form["ID"]);
            var hc = ModelStorage.Get(Session.SessionID, key, null) as LabSample;

            ViewData["ErrorMessage"] = null;
            hc.Validation += hc_ValidationDetails;
            hc.ParseFormCollection(form);
            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabSample.Accessor acc = LabSample.Accessor.Instance(null);
                    acc.Post(manager, hc);
                }
            }
            hc.Validation -= hc_ValidationDetails;

            ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];

            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabSample.Accessor acc = LabSample.Accessor.Instance(null);
                    hc = acc.SelectByKey(manager, hc.idfContainer);
                    ModelStorage.Remove(Session.SessionID, hc.idfContainer, null);
                    ModelStorage.Put(Session.SessionID, hc.idfContainer, hc.idfContainer, null, hc);
                }
            }

            return View("Details", hc);
        }


        [HttpGet]
        public ActionResult EditTest(long? id)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabTest.Accessor.Instance(null);
                var hc = acc.SelectByKey(manager, id.Value) as LabTest;
                if (hc == null) // sample
                {
                    hc = acc.Create(manager, null, id.Value) as LabTest;
                }

                ModelStorage.Put(Session.SessionID, hc.idfTesting, hc.idfTesting, null, hc);
                return View("SelectTest", hc);
            }
        }

        [HttpPost]
        public ActionResult EditTest(FormCollection form)
        {
            var key = long.Parse(form["idfTesting"]);
            var hc = ModelStorage.Get(Session.SessionID, key, null) as LabTest;

            ViewData["ErrorMessage"] = null;
            hc.Validation += hc_ValidationDetailsIgnoreAsk;
            hc.ParseFormCollection(form);

            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabTest.Accessor acc = LabTest.Accessor.Instance(null);
                    acc.Post(manager, hc);
                }
            }
            hc.Validation -= hc_ValidationDetailsIgnoreAsk;

            ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
            ViewBag.ShowTestResultReportClick = form["ShowTestResultReportClick"];

            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabTest.Accessor acc = LabTest.Accessor.Instance(null);
                    hc = acc.SelectByKey(manager, hc.idfTesting);
                    ModelStorage.Remove(Session.SessionID, hc.idfTesting, null);
                    ModelStorage.Put(Session.SessionID, hc.idfTesting, hc.idfTesting, null, hc);
                }
            }

            return View("SelectTest", hc);
        }

        //[HttpGet]
        public ActionResult DeleteTest(long? id)
        {
            bool isSuccess = false;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabTest.Accessor.Instance(null);
                var hc = acc.SelectByKey(manager, id.Value) as LabTest;
                if (hc != null) // test
                {
                    hc.Validation += hc_ValidationDetails;
                    if (hc.MarkToDelete())
                    {
                        isSuccess = acc.Post(manager, hc);
                    }
                    hc.Validation -= hc_ValidationDetails;
                }

                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isSuccess };
            }
        }

        [HttpGet]
        public ActionResult AmendTest(long? id)
        {
            var test = ModelStorage.Get(Session.SessionID, id.Value, null) as LabTest;
            var item = test.AmendmentHistory.Where(c => c.IsNew).SingleOrDefault();
            if (item == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    LabTestAmendmentHistory.Accessor acc = LabTestAmendmentHistory.Accessor.Instance(null);
                    item = acc.Create(manager, test, test.idfTesting, test.idfsTestResult, test.strNote);
                }
            }
            ModelStorage.Put(Session.SessionID, id.Value, item.idfTestAmendmentHistory, null, item);
            return View(item);
        }

        [HttpPost]
        public ActionResult AmendTest(FormCollection form)
        {
            long idfTestAmendmentHistory = long.Parse(form["idfTestAmendmentHistory"]);
            var item = ModelStorage.Get(Session.SessionID, idfTestAmendmentHistory, null) as LabTestAmendmentHistory;
            var test = ModelStorage.Get(Session.SessionID, item.idfTesting, null) as LabTest;
            CompareModel data = new CompareModel();

            item.Validation += obj_Validation;
            item.ParseFormCollection(form);
            if (m_validation == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabTestAmendmentHistory.Accessor acch = LabTestAmendmentHistory.Accessor.Instance(null);
                    acch.Validate(manager, item, true, true, true);
                    if (m_validation == null)
                    {
                        LabTest.Accessor acc = LabTest.Accessor.Instance(null);
                        ICloneable cloneable = test as ICloneable;
                        IObject clone = cloneable.Clone() as IObject;
                        acc.AmendTest(manager, test, item);
                        data = test.Compare(clone);
                    }
                }
            }
            item.Validation -= obj_Validation;

            if (m_validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfTestAmendmentHistory, null);
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }


        [HttpGet]
        public ActionResult SelectTest(long? id)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabTest.Accessor.Instance(null);
                var accs = LabSample.Accessor.Instance(null);
                var hcs = accs.SelectByKey(manager, id.Value) as LabSample;
                if (hcs == null) // test
                {
                    var hct = acc.SelectByKey(manager, id.Value) as LabTest;
                    id = hct.idfContainer;
                }

                var hc = acc.Create(manager, null, id.Value) as LabTest;

                ModelStorage.Put(Session.SessionID, hc.idfTesting, hc.idfTesting, null, hc);
                return View(hc);
            }
        }

        [HttpPost]
        public ActionResult SelectTest(FormCollection form)
        {
            var key = long.Parse(form["idfTesting"]);
            var hc = ModelStorage.Get(Session.SessionID, key, null) as LabTest;

            ViewData["ErrorMessage"] = null;
            hc.Validation += hc_ValidationDetails;
            hc.ParseFormCollection(form);
            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabTest.Accessor acc = LabTest.Accessor.Instance(null);
                    acc.Post(manager, hc);
                }
            }
            hc.Validation -= hc_ValidationDetails;

            ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
            ViewBag.ShowTestResultReportClick = form["ShowTestResultReportClick"];

            if (ViewData["ErrorMessage"] == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    LabTest.Accessor acc = LabTest.Accessor.Instance(null);
                    hc = acc.SelectByKey(manager, hc.idfTesting);
                    ModelStorage.Remove(Session.SessionID, hc.idfTesting, null);
                    ModelStorage.Put(Session.SessionID, hc.idfTesting, hc.idfTesting, null, hc);
                }
            }

            return View(hc);
        }


        [HttpGet]
        public ActionResult HumanAccessionIn()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabSampleReceive.Accessor.Instance(null);
                var hc = acc.CreateNewT(manager, null);

                ModelStorage.Put(Session.SessionID, hc.ID, hc.ID, null, hc);

                ViewData["ShowCasePicker"] = "true";
                ViewData["OnlyReload"] = "false";

                return View(hc);
            }
        }

        [HttpPost]
        public ActionResult HumanAccessionIn(FormCollection form)
        {
            var idforselect = form["idforselect"];
            ViewData["ShowCasePicker"] = "false";

            if (idforselect != "")
            {
                var key = long.Parse(idforselect);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = LabSampleReceive.Accessor.Instance(null);
                    var hc = acc.SelectByKey(manager, key);

                    ModelStorage.Put(Session.SessionID, hc.ID, hc.ID, null, hc);
                    return View(hc);
                }
            }
            else
            {
                var key = long.Parse(form["ID"]);
                var hc = ModelStorage.Get(Session.SessionID, key, null) as LabSampleReceive;

                if (form["OnlyReload"] == "true")
                {
                    ViewData["OnlyReload"] = "false";
                    return View(hc);
                }

                ViewData["ErrorMessage"] = null;
                hc.Validation += hc_ValidationDetails;
                hc.ParseFormCollection(form);
                if (ViewData["ErrorMessage"] == null)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        var acc = LabSampleReceive.Accessor.Instance(null);
                        acc.Post(manager, hc);
                    }
                }
                hc.Validation -= hc_ValidationDetails;

                ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
                ViewBag.ShowAccessionInReportClick = form["ShowAccessionInReportClick"];

                return View(hc);
            }
        }

        [HttpGet]
        public ActionResult VetAccessionIn()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabSampleReceive.Accessor.Instance(null);
                var hc = acc.CreateNewT(manager, null);

                ModelStorage.Put(Session.SessionID, hc.ID, hc.ID, null, hc);

                ViewData["ShowCasePicker"] = "true";
                ViewData["OnlyReload"] = "false";

                return View(hc);
            }
        }

        [HttpPost]
        public ActionResult VetAccessionIn(FormCollection form)
        {
            var idforselect = form["idforselect"];
            ViewData["ShowCasePicker"] = "false";

            if (idforselect != "")
            {
                var key = long.Parse(idforselect);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = LabSampleReceive.Accessor.Instance(null);
                    var hc = acc.SelectByKey(manager, key);

                    ModelStorage.Put(Session.SessionID, hc.ID, hc.ID, null, hc);
                    return View(hc);
                }
            }
            else
            {
                var key = long.Parse(form["ID"]);
                var hc = ModelStorage.Get(Session.SessionID, key, null) as LabSampleReceive;

                if (form["OnlyReload"] == "true")
                {
                    ViewData["OnlyReload"] = "false";
                    return View(hc);
                }

                ViewData["ErrorMessage"] = null;
                hc.Validation += hc_ValidationDetails;
                hc.ParseFormCollection(form);
                if (ViewData["ErrorMessage"] == null)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        var acc = LabSampleReceive.Accessor.Instance(null);
                        acc.Post(manager, hc);
                    }
                }
                hc.Validation -= hc_ValidationDetails;

                ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
                ViewBag.ShowAccessionInReportClick = form["ShowAccessionInReportClick"];

                return View(hc);
            }
        }


        [HttpGet]
        public ActionResult AsAccessionIn()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabSampleReceive.Accessor.Instance(null);
                var hc = acc.CreateNewT(manager, null);

                ModelStorage.Put(Session.SessionID, hc.ID, hc.ID, null, hc);

                ViewData["ShowCasePicker"] = "true";
                ViewData["OnlyReload"] = "false";

                return View(hc);
            }
        }

        [HttpPost]
        public ActionResult AsAccessionIn(FormCollection form)
        {
            var idforselect = form["idforselect"];
            ViewData["ShowCasePicker"] = "false";

            if (idforselect != "")
            {
                var key = long.Parse(idforselect);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = LabSampleReceive.Accessor.Instance(null);
                    var hc = acc.SelectByKey(manager, key);

                    ModelStorage.Put(Session.SessionID, hc.ID, hc.ID, null, hc);
                    return View(hc);
                }
            }
            else
            {
                var key = long.Parse(form["ID"]);
                var hc = ModelStorage.Get(Session.SessionID, key, null) as LabSampleReceive;

                if (form["OnlyReload"] == "true")
                {
                    ViewData["OnlyReload"] = "false";
                    return View(hc);
                }

                ViewData["ErrorMessage"] = null;
                hc.Validation += hc_ValidationDetails;
                hc.ParseFormCollection(form);
                if (ViewData["ErrorMessage"] == null)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        var acc = LabSampleReceive.Accessor.Instance(null);
                        acc.Post(manager, hc);
                    }
                }
                hc.Validation -= hc_ValidationDetails;

                ViewData["SaveAndExitClick"] = form["SaveAndExitClick"];
                ViewBag.ShowAccessionInReportClick = form["ShowAccessionInReportClick"];

                return View(hc);
            }
        }


        [HttpGet]
        public ActionResult LabSampleReceiveItemPicker(long key, int accession, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<LabSampleReceiveItem>;
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            var parent = ModelStorage.Get(Session.SessionID, key, null) as LabSampleReceive;
            if (id == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    LabSampleReceiveItem.Accessor acc = LabSampleReceiveItem.Accessor.Instance(null);
                    var item = acc.Create(manager, parent, parent.idfCase, parent.idfMonitoringSession, parent.idfsCaseType, parent.Animals, parent.Diagnosis);
                    item.NewObject = true;
                    ModelStorage.Put(Session.SessionID, root, item.idfMaterial, null, item);
                    return View(item);
                }
            }
            else
            {
                var item = list.Where(c => c.idfMaterial == id).SingleOrDefault();
                var cloneItem = item.CloneWithSetup();
                if (accession == 1)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        LabSampleReceiveItem.Accessor acc = LabSampleReceiveItem.Accessor.Instance(null);
                        acc.AccessionIn(manager, cloneItem);
                    }
                }
                ModelStorage.Put(Session.SessionID, root, cloneItem.idfMaterial, null, cloneItem);
                return View(cloneItem);
            }
        }

        [HttpPost]
        public ActionResult LabSampleReceiveItemPicker(FormCollection form)
        {
            long idfMaterial = long.Parse(form["idfMaterial"]);
            var sample = ModelStorage.Get(Session.SessionID, idfMaterial, null) as LabSampleReceiveItem;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                LabSampleReceiveItem.Accessor acc = LabSampleReceiveItem.Accessor.Instance(null);
                acc.AccessionIn(manager, sample);
            }
            //return View(sample);
            return SetSample(form);
        }


        [HttpGet]
        public ActionResult CaseTestValidationItemPicker(long key, string name, long id_test, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<CaseTestValidation>;
            var rootobj = (IObject)ModelStorage.GetRoot(Session.SessionID, key, null);
            var root = (long)rootobj.Key;
            if (id == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    CaseTestValidation.Accessor acc = CaseTestValidation.Accessor.Instance(null);
                    CaseTest test = null;
                    var hc = ModelStorage.Get(Session.SessionID, key, null) as HumanCase;
                    if (hc != null)
                    {
                        test = hc.CaseTests.Where(c => c.idfTesting == id_test).Single();
                    }
                    else
                    {
                        var vc = ModelStorage.Get(Session.SessionID, key, null) as VetCase;
                        if (vc != null)
                        {
                            test = vc.CaseTests.Where(c => c.idfTesting == id_test).Single();
                        }
                        else
                        {
                            var ass = ModelStorage.Get(Session.SessionID, key, null) as AsSession;
                            if (ass != null)
                            {
                                test = ass.CaseTests.Where(c => c.idfTesting == id_test).Single();
                            }
                        }
                    }
                    if (test != null)
                    {
                        var item = acc.Create(manager, rootobj, key, id_test, test.TestName, test.TestType, test.idfsDiagnosis);
                        item.NewObject = true;
                        ModelStorage.Put(Session.SessionID, root, item.idfTestValidation, null, item);
                        return View(item);
                    }
                    return View();
                }
            }
            else
            {
                var item = list.Where(c => c.idfTestValidation == id).SingleOrDefault();
                var cloneItem = item.CloneWithSetup();
                ModelStorage.Put(Session.SessionID, root, cloneItem.idfTestValidation, null, cloneItem);
                return View(cloneItem);
            }
        }

        [HttpPost]
        public ActionResult CaseTestValidationItemPicker(FormCollection form)
        {
            long idfTestValidation = long.Parse(form["idfTestValidation"]);
            var validation = ModelStorage.Get(Session.SessionID, idfTestValidation, null) as CaseTestValidation;
            CompareModel data = new CompareModel();
            if (validation.NewObject)
            {
                validation.Validation += obj_Validation;
                validation.ParseFormCollection(form);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    CaseTestValidation.Accessor acc = CaseTestValidation.Accessor.Instance(null);
                    acc.Validate(manager, validation, true, true, true);
                }
                validation.Validation -= obj_Validation;
                if (m_validation == null)
                {
                    validation.NewObject = false;
                    var hc = ModelStorage.Get(Session.SessionID, validation.idfCase, null) as HumanCase;
                    if (hc != null)
                    {
                        hc.CaseTestValidations.Add(validation);
                    }
                    else
                    {
                        var vc = ModelStorage.Get(Session.SessionID, validation.idfCase, null) as VetCase;
                        if (vc != null)
                        {
                            vc.CaseTestValidations.Add(validation);
                        }
                        else
                        {
                            var ass = ModelStorage.Get(Session.SessionID, validation.idfCase, null) as AsSession;
                            if (ass != null)
                            {
                                ass.CaseTestValidations.Add(validation);
                            }
                        }
                    }
                }
            }
            else
            {
                validation.Validation += obj_Validation;
                validation.ParseFormCollection(form);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    CaseTestValidation.Accessor acc = CaseTestValidation.Accessor.Instance(null);
                    acc.Validate(manager, validation, true, true, true);
                }
                validation.Validation -= obj_Validation;

                if (m_validation == null)
                {
                    var hc = ModelStorage.Get(Session.SessionID, validation.idfCase, null) as HumanCase;
                    if (hc != null)
                    {
                        var originalvalidation = hc.CaseTestValidations.Where(c => c.idfTestValidation == idfTestValidation).SingleOrDefault();
                        originalvalidation.ParseFormCollection(form);
                    }
                    else
                    {
                        var vc = ModelStorage.Get(Session.SessionID, validation.idfCase, null) as VetCase;
                        if (vc != null)
                        {
                            var originalvalidation = vc.CaseTestValidations.Where(c => c.idfTestValidation == idfTestValidation).SingleOrDefault();
                            originalvalidation.ParseFormCollection(form);
                        }
                        else
                        {
                            var ass = ModelStorage.Get(Session.SessionID, validation.idfCase, null) as AsSession;
                            if (ass != null)
                            {
                                var originalvalidation = ass.CaseTestValidations.Where(c => c.idfTestValidation == idfTestValidation).SingleOrDefault();
                                originalvalidation.ParseFormCollection(form);
                            }
                        }
                    }
                }
            }

            if (m_validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfTestValidation, null);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        [HttpGet]
        public ActionResult FindSampleByFieldId(long idfSession, string fieldId)
        {
            var session = ModelStorage.Get(Session.SessionID, idfSession, null) as AsSession;
            AsSessionSample sample = session.ASSamples.FirstOrDefault(x => x.strFieldBarcode == fieldId);
            long? idfMaterial = null;
            if (sample != null)
            {
                idfMaterial = sample.idfMaterial;
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = idfMaterial };
        }

        [HttpGet]
        public ActionResult CaseTestItemPicker(long key, string name, long id, long? idfMaterial)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<CaseTest>;
            var rootobj = (IObject)ModelStorage.GetRoot(Session.SessionID, key, null);
            var root = (long)rootobj.Key;
            var vet = rootobj as VetCase;
            var human = rootobj as HumanCase;
            var assession = rootobj as AsSession;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                CaseTest.Accessor acc = CaseTest.Accessor.Instance(null);
                CaseTest item = null;
                if (vet != null)
                {
                    item = vet.CaseTests.SingleOrDefault(c => c.idfTesting == id);
                    if (item != null)
                        item.VetCaseSample = item.VetCaseSamples.SingleOrDefault(c => c.idfMaterial == item.idfContainerVet);
                }
                else if (human != null)
                {
                    item = human.CaseTests.SingleOrDefault(c => c.idfTesting == id);
                    if (item != null)
                        item.HumanCaseSample = item.HumanCaseSamples.SingleOrDefault(c => c.idfMaterial == item.idfContainerHuman);
                }
                else if (assession != null)
                {
                    item = assession.CaseTests.SingleOrDefault(c => c.idfTesting == id);
                    if (item != null)
                        item.AsSessionSample = item.AsSessionSamples.SingleOrDefault(c => c.idfMaterial == item.idfContainerAsSession);
                }
                if (item == null)
                {
                    item = acc.Create(manager, rootobj, vet != null ? vet.idfCase : (human != null ? human.idfCase : (assession != null ? assession.idfMonitoringSession : 0)));
                }
                item.Diagnosis = item.DiagnosisLookup.SingleOrDefault(c => c != null && c.idfsDiagnosis == item.idfsDiagnosis);
                ModelStorage.Put(Session.SessionID, root, item.idfTesting, null, item);
                if (idfMaterial.HasValue)
                {
                    item.AsSessionSample = item.AsSessionSampleLookup.SingleOrDefault(i => i.idfMaterial == idfMaterial.Value);
                }
                return View(item);
            }
        }

        [HttpPost]
        public ActionResult CaseTestItemPicker(FormCollection form)
        {
            long idfTesting = long.Parse(form["idfTesting"]);
            var item = ModelStorage.Get(Session.SessionID, idfTesting, null) as CaseTest;
            var vet = ModelStorage.Get(Session.SessionID, item.idfCase.Value, null) as VetCase;
            var human = ModelStorage.Get(Session.SessionID, item.idfCase.Value, null) as HumanCase;
            var assession = ModelStorage.Get(Session.SessionID, item.idfCase.Value, null) as AsSession;
            CompareModel data = new CompareModel();
            IObject copy = null;
            if (vet != null) copy = vet.Clone() as IObject;
            if (human != null) copy = human.Clone() as IObject;
            if (assession != null) copy = assession.Clone() as IObject;

            item.Validation += obj_Validation;
            item.ParseFormCollection(form);
            if (m_validation == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    CaseTest.Accessor acc = CaseTest.Accessor.Instance(null);
                    acc.Validate(manager, item, true, true, true);
                }
            }
            item.Validation -= obj_Validation;

            if (m_validation == null)
            {
                if (vet != null && vet.CaseTests.SingleOrDefault(c => c.idfTesting == idfTesting) == null)
                {
                    vet.CaseTests.Add(item);
                    ModelStorage.Put(Session.SessionID, vet.idfCase, vet.idfCase, String.Format("{0}CaseTests", vet.ObjectIdent), vet.CaseTests);
                }
                if (human != null && human.CaseTests.SingleOrDefault(c => c.idfTesting == idfTesting) == null)
                {
                    human.CaseTests.Add(item);
                    ModelStorage.Put(Session.SessionID, human.idfCase, human.idfCase, String.Format("{0}CaseTests", human.ObjectIdent), human.CaseTests);
                }
                if (assession != null && assession.CaseTests.SingleOrDefault(c => c.idfTesting == idfTesting) == null)
                {
                    assession.CaseTests.Add(item);
                    ModelStorage.Put(Session.SessionID, assession.idfMonitoringSession, assession.idfMonitoringSession, String.Format("{0}CaseTests", assession.ObjectIdent), assession.CaseTests);
                }
            }

            if (m_validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfTesting, null);
                if (vet != null) data = vet.Compare(copy);
                if (human != null) data = human.Compare(copy);
                if (assession != null) data = assession.Compare(copy);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        [HttpPost]
        public ActionResult SelectDiagnosisForTest(long idfTesting)
        {
            var item = ModelStorage.Get(Session.SessionID, idfTesting, null) as CaseTest;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(item.DiagnosisLookup, "idfsDiagnosis", "name") };
        }



        [HttpGet]
        public ActionResult PensideTestPicker(long key, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<PensideTest>;
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            var parent = ModelStorage.Get(Session.SessionID, key, null) as VetCase;
            if (id == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    PensideTest.Accessor acc = PensideTest.Accessor.Instance(null);
                    var item = acc.Create(manager, parent);
                    item.NewObject = true;
                    ModelStorage.Put(Session.SessionID, root, item.idfPensideTest, null, item);
                    return View(item);
                }
            }
            else
            {
                var item = list.Where(c => c.idfPensideTest == id).SingleOrDefault();
                var cloneItem = item.CloneWithSetup();
                ModelStorage.Put(Session.SessionID, root, cloneItem.idfPensideTest, null, cloneItem);
                return View(cloneItem);
            }
        }

        [HttpPost]
        public ActionResult PensideTestPicker(FormCollection form)
        {
            long idfPensideTest = long.Parse(form["idfPensideTest"]);
            var item = ModelStorage.Get(Session.SessionID, idfPensideTest, null) as PensideTest;
            var root = ModelStorage.Get(Session.SessionID, item.idfVetCase.Value, null) as VetCase;
            CompareModel data = new CompareModel();

            item.Validation += obj_Validation;
            item.ParseFormCollection(form);
            if (m_validation == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    PensideTest.Accessor acc = PensideTest.Accessor.Instance(null);
                    acc.Validate(manager, item, true, true, true);
                }
            }
            item.Validation -= obj_Validation;

            if (m_validation == null)
            {
                if (item.NewObject)
                {
                    item.NewObject = false;
                    root.PensideTests.Add(item);
                }
                else
                {
                    var original = root.PensideTests.Where(c => c.idfPensideTest == idfPensideTest).SingleOrDefault();
                    original.ParseFormCollection(form);
                }
            }

            if (m_validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfPensideTest, null);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }



        [HttpPost]
        public ActionResult SetSample(FormCollection form)
        {
            //var form = formstr.Split('&').Aggregate(new FormCollection(), (f, c) => { var m = c.Split('='); f.Add(m[0], m[1]); return f; });
            long idfMaterial = long.Parse(form["idfMaterial"]);
            //string isAccession = form["isAccession"];
            var sample = ModelStorage.Get(Session.SessionID, idfMaterial, null) as LabSampleReceiveItem;
            var root = ModelStorage.Get(Session.SessionID, sample.idfCase.HasValue ? sample.idfCase.Value + 1 : sample.idfMonitoringSession.Value + 1, null) as LabSampleReceive;
            CompareModel data = new CompareModel();
            if (sample.NewObject)
            {
                sample.Validation += obj_Validation;
                sample.ParseFormCollection(form);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    LabSampleReceiveItem.Accessor acc = LabSampleReceiveItem.Accessor.Instance(null);
                    acc.Validate(manager, sample, true, true, true);
                }
                sample.Validation -= obj_Validation;
                if (m_validation == null)
                {
                    sample.NewObject = false;
                    root.Samples.Add(sample);
                }
            }
            else
            {
                sample.Validation += obj_Validation;
                sample.ParseFormCollection(form);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    LabSampleReceiveItem.Accessor acc = LabSampleReceiveItem.Accessor.Instance(null);
                    //if (isAccession == "true")
                    //{
                    //    acc.AccessionIn(manager, sample);
                    //}
                    acc.Validate(manager, sample, true, true, true);
                }
                sample.Validation -= obj_Validation;

                if (m_validation == null)
                {
                    var originalSample = root.Samples.Where(c => c.idfMaterial == idfMaterial).SingleOrDefault();
                    originalSample.ParseFormCollection(form);
                    originalSample.IsNewAcceeded = sample.IsNewAcceeded;
                    //if (isAccession == "true")
                    //{
                    //    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    //    {
                    //        LabSampleReceiveItem.Accessor acc = LabSampleReceiveItem.Accessor.Instance(null);
                    //        acc.AccessionIn(manager, originalSample);
                    //    }
                    //}
                }
            }

            if (m_validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfMaterial, null);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }


        [HttpPost]
        public ActionResult SetAccession(long idfId, long idfMaterial)
        {
            var root = ModelStorage.Get(Session.SessionID, idfId, null) as LabSampleReceive;
            var sample = root.Samples.Where(c => c.idfMaterial == idfMaterial).SingleOrDefault();
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                LabSampleReceiveItem.Accessor acc = LabSampleReceiveItem.Accessor.Instance(null);
                acc.AccessionIn(manager, sample);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
        }




        [HttpGet]
        public ActionResult HumanCaseSamplePicker(long key, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<HumanCaseSample>;
            var hc = ModelStorage.Get(Session.SessionID, key, null) as HumanCase;
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            if (id == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    HumanCaseSample.Accessor acc = HumanCaseSample.Accessor.Instance(null);
                    var lastSample = hc.Samples.LastOrDefault(c => !c.IsMarkedToDelete);
                    var item = acc.Create(manager, hc
                        , lastSample == null ? null : lastSample.idfSendToOffice
                        , lastSample == null ? null : lastSample.idfFieldCollectedByOffice
                        , lastSample == null ? null : lastSample.idfFieldCollectedByPerson
                        , lastSample == null ? null : lastSample.strSendToOffice
                        , lastSample == null ? null : lastSample.strFieldCollectedByOffice
                        , lastSample == null ? null : lastSample.strFieldCollectedByPerson
                        );
                    item.NewObject = true;
                    ModelStorage.Put(Session.SessionID, root, item.idfMaterial, null, item);
                    return View(item);
                }
            }
            else
            {
                var item = list.Where(c => c.idfMaterial == id).SingleOrDefault();
                var cloneItem = item.CloneWithSetup();
                ModelStorage.Put(Session.SessionID, root, cloneItem.idfMaterial, null, cloneItem);
                return View(cloneItem);
            }
        }


        [HttpPost]
        public ActionResult SetHumanSample(FormCollection form)
        {
            //var form = formstr.Split('&').Aggregate(new FormCollection(), (f, c) => { var m = c.Split('='); f.Add(m[0], m[1]); return f; });
            long idfMaterial = long.Parse(form["idfMaterial"]);
            var sample = ModelStorage.Get(Session.SessionID, idfMaterial, null) as HumanCaseSample;
            var root = ModelStorage.Get(Session.SessionID, sample.idfCase.Value, null) as HumanCase;
            CompareModel data = new CompareModel();

            sample.Validation += obj_Validation;
            sample.ParseFormCollection(form);
            if (m_validation == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    HumanCaseSample.Accessor acc = HumanCaseSample.Accessor.Instance(null);
                    acc.Validate(manager, sample, true, true, true);
                }
            }
            sample.Validation -= obj_Validation;

            if (m_validation == null)
            {
                if (sample.NewObject)
                {
                    root.Validation += obj_Validation;
                    sample.NewObject = false;
                    root.Samples.Add(sample);
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        HumanCase.Accessor acc = HumanCase.Accessor.Instance(null);
                        acc.Validate(manager, root, false, true, false);
                    }
                    root.Validation -= obj_Validation;
                    if (m_validation != null)
                    {
                        sample.NewObject = true;
                        root.Samples.Remove(sample);

                        var copy_sample = sample.CloneWithSetup();
                        sample.MarkToDelete();
                        ModelStorage.Put(Session.SessionID, copy_sample.idfCase.Value, copy_sample.idfMaterial, null, copy_sample);
                    }
                }
                else
                {
                    root.Validation += obj_Validation;
                    var originalSample = root.Samples.Where(c => c.idfMaterial == idfMaterial).SingleOrDefault();
                    originalSample.ParseFormCollection(form);
                    SetSampleOrganizationsAndEmpoyee(originalSample, sample);
                    root.Validation -= obj_Validation;
                }
            }

            if (m_validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfMaterial, null);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }


        [HttpGet]
        public ActionResult VetCaseSamplePicker(long key, string name, long id)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<VetCaseSample>;
            var hc = ModelStorage.Get(Session.SessionID, key, null) as VetCase;
            var root = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            if (id == 0)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    VetCaseSample.Accessor acc = VetCaseSample.Accessor.Instance(null);
                    var lastSample = hc.Samples.LastOrDefault(c => !c.IsMarkedToDelete);
                    var item = acc.Create(manager, hc
                        , lastSample == null ? null : lastSample.idfSendToOffice
                        , lastSample == null ? null : lastSample.idfFieldCollectedByOffice
                        , lastSample == null ? null : lastSample.idfFieldCollectedByPerson
                        , lastSample == null ? null : lastSample.strSendToOffice
                        , lastSample == null ? null : lastSample.strFieldCollectedByOffice
                        , lastSample == null ? null : lastSample.strFieldCollectedByPerson
                        );
                    item.NewObject = true;
                    ModelStorage.Put(Session.SessionID, root, item.idfMaterial, null, item);
                    return View(item);
                }
            }
            else
            {
                var item = list.Where(c => c.idfMaterial == id).SingleOrDefault();

                if (item._HACode == (int)eidss.model.Enums.HACode.Livestock)
                    item.Animal = (item.idfParty == null || item.AnimalListFromCase == null) ? null : item.AnimalListFromCase.Where(a => a.idfAnimal == item.idfParty).SingleOrDefault();
                if (item._HACode == (int)eidss.model.Enums.HACode.Avian)
                    item.FarmTree = (item.idfParty == null || item.VetFarmTreeFromCase == null) ? null : item.VetFarmTreeFromCase.Where(a => a.idfParty == item.idfParty).SingleOrDefault();

                var cloneItem = item.CloneWithSetup();
                ModelStorage.Put(Session.SessionID, root, cloneItem.idfMaterial, null, cloneItem);
                return View(cloneItem);
            }
        }

        [HttpPost]
        public ActionResult SetVetSample(FormCollection form)
        {
            long idfMaterial = long.Parse(form["idfMaterial"]);
            var sample = ModelStorage.Get(Session.SessionID, idfMaterial, null) as VetCaseSample;
            var root = ModelStorage.Get(Session.SessionID, sample.idfCase.Value, null) as VetCase;
            CompareModel data = new CompareModel();

            sample.Validation += obj_Validation;
            sample.ParseFormCollection(form);
            if (m_validation == null)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    VetCaseSample.Accessor acc = VetCaseSample.Accessor.Instance(null);
                    acc.Validate(manager, sample, true, true, true);
                }
            }
            sample.Validation -= obj_Validation;

            if (m_validation == null)
            {
                if (sample.NewObject)
                {
                    sample.NewObject = false;
                    root.Samples.Add(sample);
                }
                else
                {
                    var originalSample = root.Samples.Where(c => c.idfMaterial == idfMaterial).SingleOrDefault();
                    originalSample.ParseFormCollection(form);
                    SetSampleOrganizationsAndEmpoyee(originalSample, sample);
                }
            }

            if (m_validation != null)
            {
                string errorMessage = Translator.GetErrorMessage(m_validation);
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage", errorMessage, false, false, false);
            }
            else
            {
                ModelStorage.Remove(Session.SessionID, idfMaterial, null);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }


        private static void SetSampleOrganizationsAndEmpoyee(HumanCaseSample originalSample, HumanCaseSample tempSample)
        {
            originalSample.idfFieldCollectedByOffice = tempSample.idfFieldCollectedByOffice;
            originalSample.strFieldCollectedByOffice = tempSample.strFieldCollectedByOffice;

            originalSample.idfFieldCollectedByPerson = tempSample.idfFieldCollectedByPerson;
            originalSample.strFieldCollectedByPerson = tempSample.strFieldCollectedByPerson;

            originalSample.idfSendToOffice = tempSample.idfSendToOffice;
        }

        private static void SetSampleOrganizationsAndEmpoyee(VetCaseSample originalSample, VetCaseSample tempSample)
        {
            originalSample.idfFieldCollectedByOffice = tempSample.idfFieldCollectedByOffice;
            originalSample.strFieldCollectedByOffice = tempSample.strFieldCollectedByOffice;

            originalSample.idfFieldCollectedByPerson = tempSample.idfFieldCollectedByPerson;
            originalSample.strFieldCollectedByPerson = tempSample.strFieldCollectedByPerson;

            originalSample.idfSendToOffice = tempSample.idfSendToOffice;
        }

        public ActionResult AddToPreferences(long id)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabSampleLogBookListItem.Accessor.Instance(null);
                acc.AddToPreferences(manager, null, id);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }
        public ActionResult RemoveFromPreferences(long id)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = LabSampleLogBookMyPrefListItem.Accessor.Instance(null);
                acc.RemoveFromPreferences(manager, null, id);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }



        void hc_ValidationDetails(object sender, ValidationEventArgs args)
        {
            ViewData["ErrorMessage"] = Translator.GetErrorMessage(args);
        }
        void hc_ValidationDetailsIgnoreAsk(object sender, ValidationEventArgs args)
        {
            if (!args.ShouldAsk)
                ViewData["ErrorMessage"] = Translator.GetErrorMessage(args);
            else
                args.Continue = true;
        }

        void obj_Validation(object sender, ValidationEventArgs args)
        {
            m_validation = args;
        }


        [HttpPost]
        public ActionResult SelectTestResult(long idfTesting)
        {
            LabTest labtest = ModelStorage.Get(Session.SessionID, idfTesting, null) as LabTest;
            CaseTest casetest = ModelStorage.Get(Session.SessionID, idfTesting, null) as CaseTest;
            List<TestResultLookup> lookup = labtest != null ? labtest.TestResultRefLookup : (casetest != null ? casetest.TestResultRefLookup : null);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(lookup, "idfsReference", "name") };
        }


        [HttpGet]
        public ActionResult TestResultReport(long ObjID, long CSObjID, long TypeID)
        {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new LimTestResultModel(ModelUserContext.CurrentLanguage, ObjID, CSObjID, TypeID, ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportLimTestResult( model);
            }
            const string fileName = "TestResultReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }

        [HttpGet]
        public ActionResult AccessionInReport(long ObjID)
        {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                report = wrapper.Client.ExportLimAccessionIn(new BaseIdModel(ModelUserContext.CurrentLanguage, ObjID, ModelUserContext.Instance.IsArchiveMode));
            }
            const string fileName = "AccessionInReport.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }

    }
}

