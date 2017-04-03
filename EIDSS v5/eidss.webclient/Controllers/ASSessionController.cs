using System.Web.Mvc;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Resources;
using bv.model.BLToolkit;
using eidss.model.Core;
using System.Collections.Generic;
using System;
using BLToolkit.EditableObjects;


namespace eidss.webclient.Controllers
{
   [AuthorizeEIDSS]
    public class ASSessionController : Controller
    {

        #region Session
        public ActionResult Index()
        {
            var accessor = AsSessionListItem.Accessor.Instance(null);
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
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(form, AsSessionListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            AsSessionListItem.AsSessionListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, AutoGridRoots.AsSessionList, AutoGridRoots.AsSessionList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(long? id, long? idfCampaign = null)
        {
            if (id == 0)
                id = null;
            ViewBag.OpenVetCase = null;
            ViewBag.EnableCampaignSelection = !idfCampaign.HasValue;

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = AsSession.Accessor.Instance(null);
                AsSession session = null;
                if (id.HasValue)
                {
                    session = acc.SelectByKey(manager, id.Value);
                }
                else
                {
                    session = acc.CreateNewT(manager, null);
                    session.idfCampaign = idfCampaign;
                }

                ModelStorage.Put(Session.SessionID, session.idfMonitoringSession, session.idfMonitoringSession, null, session);
                ViewBag.IsReadOnly = session.idfsMonitoringSessionStatus == (long)AsSessionStatus.Closed;
                return View(session);
            }

        }


        [HttpGet]
        public ActionResult TryToSetCampaign(long idfSession, long? idfCampaign)
        {
            var session = ModelStorage.Get(Session.SessionID, idfSession, null) as AsSession;
            CompareModel data = null;
            ICloneable cloneable = session as ICloneable;
            IObject clone = cloneable.Clone() as IObject;
            session.Validation += object_ValidationDetails;
            session.SetValue("idfCampaign", idfCampaign.ToString());
            session.Validation -= object_ValidationDetails;
            data = session.Compare(clone);
            if (ViewData["ErrorMessage"] != null)
            {
                string name = "idfCampaign";
                object val = session.GetValue(name);
                string type = session.GetType(name);
                string valstr = val == null ? "" : val.ToString();
                data.Add(name, idfSession.ToString(), type, valstr, session.IsReadOnly(name), session.IsInvisible(name), session.IsRequired(name));
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                    String.Format("{0}:{1}",ViewData["ErrorType"].ToString(), ViewData["ErrorMessage"].ToString()),
                    false, false, false);
            }
            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        [HttpPost]
        public ActionResult Details(long? id, long? idfCampaign, FormCollection form)
        {
            var key = long.Parse(form["idfMonitoringSession"]);
            var session = ModelStorage.Get(Session.SessionID, key, null) as AsSession;
            var clone = (IObject)session.Clone();

            ViewData["ErrorMessage"] = null;

            session._blnAllowCampaignReload = false;
            ViewBag.EnableCampaignSelection = !idfCampaign.HasValue;
            session.Validation += object_ValidationDetails;
            session.ParseFormCollection(form);


            
            bool createCasesTry = session._idfFarmForCaseCreation.HasValue;

            if (ViewData["ErrorMessage"] == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = AsSession.Accessor.Instance(null);                    
                    acc.Post(manager, session);
                }
            }

            session.Validation -= object_ValidationDetails;
            long createdCases = 0;
            
            if (createCasesTry && !string.IsNullOrWhiteSpace(session._strCreatedCases) && session._strCreatedCases != AsSession.NO_CASES_CREATED)
            {
                string[] ids = session._strCreatedCases.Split(new char[] { ',' });
                if (ids.Length == 1)
                {
                    createdCases = Convert.ToInt64(ids[0]);
                }
                else
                {
                    createdCases = -1;
                }
            }
            else
            {
                if (createCasesTry && ViewData["ErrorMessage"] == null)
                {
                    createdCases = -2;
                }

            }

            if (ViewData["ErrorMessage"] == null)
            {
                using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    var acc = AsSession.Accessor.Instance(null);
                    session = acc.SelectByKey(manager, key);
                    ModelStorage.Put(Session.SessionID, session.idfMonitoringSession, session.idfMonitoringSession, null, session);
                }
            }

            CompareModel comparision = new CompareModel();

            if (ViewData["ErrorMessage"] != null)
            {
                comparision.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewData["ErrorMessage"].ToString(),
                                false, false, false);
            }
            else
            {
                comparision = session.Compare(clone);
                if (createCasesTry)
                {
                    comparision.Add("CasesCreated", "CasesCreated", "hidden", createdCases.ToString(), false, false, false);
                }
            }

            SessionRefreshHelper.RefreshObjectChildren(
                Session.SessionID, 
                session, 
                new Dictionary<string, EditableArrayList> { 
                    {session.ObjectIdent + "Diseases", session.Diseases},
                    {session.ObjectIdent + "SummaryItems", session.SummaryItems},
                    {session.ObjectIdent + "Actions", session.Actions},
                    {session.ObjectIdent + "Cases", session.Cases},
                    {session.ObjectIdent + "Samples", session.DetailsTableView},
                    {session.ObjectIdent + "CaseTests", session.CaseTests},
                    {session.ObjectIdent + "CaseTestValidations", session.CaseTestValidations}
                });
            return Json(comparision, JsonRequestBehavior.AllowGet);            
        }

        #endregion

        void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            ViewData["ErrorMessage"] = EidssMessages.GetValidationErrorMessage(args).Replace("*Species*", args.PropertyName);
            if (args.Pars != null && args.Pars.Length > 0)
            {
                ViewData["ErrorType"] = args.Pars[0];
            }
        }


        public ActionResult DetailsNonPostable(long idfSession, long idfCampaign)
        {
            ViewBag.OpenVetCase = null;

            var campaign = ModelStorage.Get(Session.SessionID, idfCampaign, null) as AsCampaign;

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = AsSession.Accessor.Instance(null);
                AsSession session = null;
                if (idfSession > 0)
                {
                    session = campaign.Sessions.Find(s => s.idfMonitoringSession == idfSession).FullSession;
                }
                else
                {
                    session = acc.CreateNewT(manager, null);                    
                    session.CampaignInRamOnly = campaign;
                    session.idfCampaign = idfCampaign;
                }

                ViewBag.EnableCampaignSelection = false;

                ModelStorage.Put(Session.SessionID, session.idfMonitoringSession, session.idfMonitoringSession, null, session);
                return View(session);
            }            
        }


        private bool ValidationHasErrors(CompareModel comparision)
        {
            if (ViewData["ErrorMessage"] != null)
            {
                comparision.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewData["ErrorMessage"].ToString(),
                                false, false, false);
                return true;
            }
            return false;
        }

        [HttpPost]
        public ActionResult DetailsNonPostable(long idfSession, long idfCampaign, FormCollection form)
        {
            var key = long.Parse(form["idfMonitoringSession"]);
            var session = ModelStorage.Get(Session.SessionID, key, null) as AsSession;            

            ViewData["ErrorMessage"] = null;

            session._blnAllowCampaignReload = false;
            ViewBag.EnableCampaignSelection = false;

            session.Validation += object_ValidationDetails;
            session.ParseFormCollection(form);

            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var acc = AsSession.Accessor.Instance(null);
                acc.Validate(manager, session, true, false, true);
            }

            session.Validation -= object_ValidationDetails;

            CompareModel comparision = new CompareModel();
            if (!ValidationHasErrors(comparision))
            {                
                var campaign = ModelStorage.Get(Session.SessionID, idfCampaign, null) as AsCampaign;                
                try
                {
                    
                    campaign.ValidateSessionAssignment(session);
                    
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                    {
                        session.idfCampaign = null;
                        AsSession.Accessor.Instance(null).Post(manager, session);
                    }

                    if (campaign.Sessions.Find(x => x.idfMonitoringSession == key) == null)
                    {
                        AsCampaign.AssignCampaignToSession(campaign, session);
                    }
                    else
                    {
                        AsMonitoringSession.UpdateFromASSession(
                            campaign.Sessions.Find(x => x.idfMonitoringSession == key), 
                            session, 
                            campaign.idfCampaign);
                    }
                }
                catch (ValidationModelException e)
                {                    
                    ViewData["ErrorMessage"] = EidssMessages.GetValidationErrorMessage(e);
                    if (e.Pars != null && e.Pars.Length > 0)
                    {
                        ViewData["ErrorType"] = e.Pars[0];
                    }
                }
                

                ValidationHasErrors(comparision);
                SessionRefreshHelper.RefreshObjectChildren(
                       Session.SessionID,
                       session,
                       new Dictionary<string, EditableArrayList> { 
                            {session.ObjectIdent + "Diseases", session.Diseases},
                            {session.ObjectIdent + "SummaryItems", session.SummaryItems},
                            {session.ObjectIdent + "Actions", session.Actions},
                            {session.ObjectIdent + "Cases", session.Cases},
                            {session.ObjectIdent + "Samples", session.DetailsTableView},
                            {session.ObjectIdent + "CaseTests", session.CaseTests},
                            {session.ObjectIdent + "CaseTestValidations", session.CaseTestValidations}
                        });
            }
            return Json(comparision, JsonRequestBehavior.AllowGet);
        }


        #region address methods

        [HttpPost]
        public ActionResult SelectRegion(long idfSession)
        {
            AsSession session = ModelStorage.Get(Session.SessionID, idfSession, null) as AsSession;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(session.RegionLookup, "idfsRegion", "strRegionName") };
        }

        [HttpPost]
        public ActionResult SelectRayon(long idfSession)
        {
            AsSession session = ModelStorage.Get(Session.SessionID, idfSession, null) as AsSession;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(session.RayonLookup, "idfsRayon", "strRayonName") };
        }

        [HttpPost]
        public ActionResult SelectSettlement(long idfSession)
        {
            AsSession session = ModelStorage.Get(Session.SessionID, idfSession, null) as AsSession;
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new SelectList(session.SettlementLookup, "idfsSettlement", "strSettlementName") };
        }
        #endregion

        [HttpGet]
        public ActionResult ASSessionPicker()
        {
            var accessor = AsSessionListItem.Accessor.Instance(null);
            IObject initObject = null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = accessor.CreateNew(manager, null);
            }
            ViewBag.InitObject = initObject;
            FilterParams filter = SearchPanelHelper.GetDefaultFilter(accessor.SearchPanelMeta, initObject);
            ViewBag.Filter = filter;
            AsSessionListItem.AsSessionListItemGridModelList list = GetGridModelList(filter);
            ViewBag.GridItems = list;
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.AsSessionSelectList, "Grid", list);

            return View(accessor);   
        }

        [HttpPost]
        public ActionResult ASSessionPicker(string formData)
        {
            FilterParams filter = SearchPanelHelper.SearchPanelParseValues(formData, AsSessionListItem.Accessor.Instance(null).SearchPanelMeta);
            ViewBag.Filter = filter;
            ViewBag.InitObject = null;
            AsSessionListItem.AsSessionListItemGridModelList list = GetGridModelList(filter);
            ModelStorage.Put(Session.SessionID, 0, AutoGridRoots.AsSessionSelectList, "Grid", list);
            int totalRows = list.Count;
            return Json(new { data = list, total = totalRows }, JsonRequestBehavior.AllowGet);
        }

        private static AsSessionListItem.AsSessionListItemGridModelList GetGridModelList(FilterParams filter)
        {
            List<AsSessionListItem> items = GetAsSessionList(filter);
            var list = new AsSessionListItem.AsSessionListItemGridModelList(AutoGridRoots.AsSessionSelectList, items);
            return list;
        }

        private static List<AsSessionListItem> GetAsSessionList(FilterParams filter)
        {
            var accessor = AsSessionListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<AsSessionListItem> items = accessor.SelectListT(dbmanager, filter);
                return items;
            }
        }

        [HttpGet]
        public ActionResult ReportAsSampleCollectedList(long id)
        {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                report = wrapper.Client.ExportVetActiveSurveillanceSampleCollected( new BaseIdModel(ModelUserContext.CurrentLanguage, id, ModelUserContext.Instance.IsArchiveMode));
            }
            const string fileName = "ReportAsSampleCollectedList.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }

        [HttpGet]
        public ActionResult ReportAsSessionTests(long id)
        {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new LimTestModel(ModelUserContext.CurrentLanguage, id, false, ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportLimTest( model);
            }
            const string fileName = "ReportAsSessionTests.pdf";
            Response.AppendHeader("content-disposition", "inline; filename=" + fileName);
            return File(report, "application/pdf", fileName);
        }





        
    }
}
