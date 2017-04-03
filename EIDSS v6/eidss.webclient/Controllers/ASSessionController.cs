using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Kendo.Mvc.UI;
using bv.model.Model.Core;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using eidss.model.Resources;
using BLToolkit.EditableObjects;
using bv.model.Helpers;


namespace eidss.webclient.Controllers
{
   [AuthorizeEIDSS]
    public class ASSessionController : BvController
    {

        #region Session
        public ActionResult Index()
        {
            return IndexInternal<AsSessionListItem.Accessor, AsSessionListItem, AsSessionListItem.AsSessionListItemGridModelList>
                (AsSessionListItem.Accessor.Instance(null), AutoGridRoots.AsSessionList, false);
        }

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<AsSessionListItem.Accessor, AsSessionListItem, AsSessionListItem.AsSessionListItemGridModelList>
                (form, AsSessionListItem.Accessor.Instance(null), AutoGridRoots.AsSessionList, request);
        }

        public ActionResult Details(long? id, int? isret, long? idfCampaign = null, bool fromCampaign = false, bool readOnly = false, int iSetPagable = 0)
        {
            ViewBag.OpenVetCase = null;
            ViewBag.FromCampaign = fromCampaign;
            if (idfCampaign.HasValue)
            {
                ViewBag.IdfCampaign = idfCampaign.Value;
            }
/*
            ViewBag.AsDetailsSelectedTab = 0;
            ViewBag.AsDetailsInfoSelectedTab = 0;
            if (id.HasValue && id.Value != 0 && Session["AsDetailsSelectedTab"] != null)
            {
                ViewBag.AsDetailsSelectedTab = (int) Session["AsDetailsSelectedTab"];
                Session["AsDetailsSelectedTab"] = null;
            }
            if (Session["iSetPagable" + id] == null || (!isret.HasValue || isret.Value == 0))
            {
                Session["iSetPagable" + id] = 2; // by default - unchecked (1 - checked, 2 - unchecked)
            }
            if (iSetPagable > 0)
            {
                ViewBag.AsDetailsSelectedTab = 1;
                ViewBag.AsDetailsInfoSelectedTab = 1;
                Session["iSetPagable" + id] = iSetPagable;
            }
*/

            return DetailsInternal<AsSession.Accessor, AsSession>(id, AsSession.Accessor.Instance(null), (int)HACode.Livestock
                , null
                , id.HasValue && isret.HasValue && isret == 1
                  ? (proxy, accessor) => (AsSession)ModelStorage.GetRoot(Session.SessionID, id.Value, String.Empty)
                  : (Func<DbManagerProxy, AsSession.Accessor, AsSession>)null
                , null
                , c =>
                {
                    ViewBag.AsDetailsSelectedTab = 0;
                    ViewBag.AsDetailsInfoSelectedTab = 0;
                    if (Session["AsDetailsSelectedTab"] != null)
                    {
                        ViewBag.AsDetailsSelectedTab = (int)Session["AsDetailsSelectedTab"];
                        Session["AsDetailsSelectedTab"] = null;
                    }
                    if (Session["iSetPagable" + c.idfMonitoringSession] == null || (!isret.HasValue || isret.Value == 0))
                    {
                        Session["iSetPagable" + c.idfMonitoringSession] = 2; // by default - unchecked (1 - checked, 2 - unchecked)
                    }
                    if (iSetPagable > 0)
                    {
                        ViewBag.AsDetailsSelectedTab = 1;
                        ViewBag.AsDetailsInfoSelectedTab = 1;
                        Session["iSetPagable" + c.idfMonitoringSession] = iSetPagable;
                    }


                    if (!readOnly && idfCampaign.HasValue)
                    {
                        AsCampaign campaign = ModelStorage.Get(Session.SessionID, idfCampaign.Value, "") as AsCampaign;
                        AsCampaign.AssignCampaignToSession(campaign, c);
                    }
                    if (readOnly)
                        c.blnOnlyView = true;
                });
        }


        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            return DetailsInternalAjax<AsSession.Accessor, AsSession>(form, AsSession.Accessor.Instance(null), null, null, null, null, bCloneWithSetup: false);
        }

        #endregion


        private ActionResult _ASSessionPicker(string functionName, FilterParams filter)
        {
            ViewBag.OnPickerSelect = functionName;

            return IndexInternal<AsSessionListItem.Accessor, AsSessionListItem, AsSessionListItem.AsSessionListItemGridModelList>
                (AsSessionListItem.Accessor.Instance(null), AutoGridRoots.AsSessionSelectList, true, filter, "ASSessionPicker");
        }

        [HttpGet]
        public ActionResult ASSessionPicker(string functionName)
        {
            return _ASSessionPicker(functionName, null);
        }

        #region session diseases
        [HttpGet]
        public ActionResult ASSessionDisease(long key, string name, long id)
        {
            return PickerInternal<AsSessionDisease.Accessor, AsSessionDisease, AsSession>(key, id, name, AsSessionDisease.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateNewT(m, p),
                null);
        }

        [HttpPost]
        public ActionResult SetASSessionDiseases(FormCollection form)
        {
            return PickerInternal<AsSessionDisease.Accessor, AsSessionDisease, AsSession>(form, AsSessionDisease.Accessor.Instance(null), null,
                p => p.Diseases,
                (i, o) => i.idfMonitoringSessionToDiagnosis == o.idfMonitoringSessionToDiagnosis,
                null);
        }

        public ActionResult MoveItem(long key, string name, long? idfAsDisease, int moveDirection)
        {
            var list = ModelStorage.Get(Session.SessionID, key, name) as EditableList<AsSessionDisease>;
            if (list.Count(d => !d.IsMarkedToDelete) > 0)
            {
                var d1 = list.Single(d => d.idfMonitoringSessionToDiagnosis == idfAsDisease);
                if (moveDirection > 0)
                {
                    var list1 = list.Where(d => d.intOrder > d1.intOrder && !d.IsMarkedToDelete);
                    if (list1.Count() > 0)
                    {
                        var newseq = list1.Min(c => c.intOrder);
                        var d2 = list1.Single(d => d.intOrder == newseq);
                        d2.intOrder = d1.intOrder;
                        d1.intOrder = newseq;
                    }
                }
                else
                {
                    var list1 = list.Where(d => d.intOrder < d1.intOrder && !d.IsMarkedToDelete);
                    if (list1.Count() > 0)
                    {
                        var newseq = list1.Max(c => c.intOrder);
                        var d2 = list1.Single(d => d.intOrder == newseq);
                        d2.intOrder = d1.intOrder;
                        d1.intOrder = newseq;
                    }
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "ok" };
        }
        #endregion

        [HttpGet]
        public ActionResult ReportAsSampleCollectedList(long id)
        {
            byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new BaseIdModel(ModelUserContext.CurrentLanguage, id, ModelUserContext.Instance.IsArchiveMode);
                report = wrapper.Client.ExportVetActiveSurveillanceSampleCollected( model);
            }
            return ReportResponse(report, "ReportAsSampleCollectedList.pdf");
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
            return ReportResponse(report, "ReportAsSessionTests.pdf");
        }

        #region session actions
        [HttpGet]
        public ActionResult ASSessionAction(long key, string name, long id)
        {
            return PickerInternal<AsSessionAction.Accessor, AsSessionAction, AsSession>(key, id, name, AsSessionAction.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateNewT(m, p),
                null);
        }

        [HttpPost]
        public ActionResult SetASSessionAction(FormCollection form)
        {
            return PickerInternal<AsSessionAction.Accessor, AsSessionAction, AsSession>(form, AsSessionAction.Accessor.Instance(null), null,
                p => p.Actions,
                (i, o) => i.idfMonitoringSessionAction == o.idfMonitoringSessionAction,
                null);
        }
        #endregion

        [HttpPost]
        public ActionResult StoreInSession(FormCollection form)
        {
            if (form.AllKeys.Contains("idfMonitoringSession"))
            {
                var key = long.Parse(form["idfMonitoringSession"]);
                var session = (AsSession)ModelStorage.Get(Session.SessionID, key, null);
                session.ParseFormCollection(form);
            }
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult SetASSessionCases(long key, long item)
        {
            var session = (AsSession)ModelStorage.Get(Session.SessionID, key, null);
            var acc = AsSession.Accessor.Instance(null);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var idfTesting = session.CaseTestValidations.SingleOrDefault(c => c.idfTestValidation == item, c => c.idfTesting);
                var idfFarm = session.CaseTests.SingleOrDefault(c => c.idfTesting == idfTesting, c => c.idfFarm);
                session._idfFarmForCaseCreation = idfFarm;
                session.Validation += ValidationDetails;
                acc.CreateCases(manager, session);
                session.Validation -= ValidationDetails;
            }

            var data = new CompareModel();
            if (ViewData["ErrorMessage"] != null)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewBag.ErrorMessage.ToString(),
                                false, false, false);
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        private ValidationEventArgs validation = null;
        void ValidationDetails(object sender, ValidationEventArgs args)
        {
            validation = args;
            ViewData["ErrorMessage"] = Translator.GetErrorMessage(args);
        }


        private void AddChange(CompareModel data, AsSession asSession, int val, string field)
        {
            data.Add(field,
                asSession.ObjectIdent + field,
                asSession.ObjectIdent2 + field,
                asSession.ObjectIdent3 + field, 
                "int",
                val.ToString(),
                asSession.IsReadOnly(field),
                asSession.IsInvisible(field),
                asSession.IsRequired(field));
        }
        public ActionResult DeleteAnimalSample(long asSessionId, long animalSampleId)
        {
            var asSession = (AsSession)ModelStorage.Get(Session.SessionID, asSessionId, null);
            var animalSample = asSession.ASAnimalsSamples.FirstOrDefault(c => c.id == animalSampleId && !c.IsMarkedToDelete);
            var data = new CompareModel();
            ViewBag.ErrorMessage = null;
            if (animalSample != null)
            {
                animalSample.Validation += ValidationDetails;
                animalSample.MarkToDelete();
                animalSample.Validation -= ValidationDetails;
            }

            if (ViewBag.ErrorMessage != null)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewBag.ErrorMessage.ToString(),
                                false, false, false);
            }
            else
            {
                AddChange(data, asSession, asSession.intTotalSamples, "intTotalSamples");
                AddChange(data, asSession, asSession.intTotalSampledAnimals, "intTotalSampledAnimals");
            }

            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
