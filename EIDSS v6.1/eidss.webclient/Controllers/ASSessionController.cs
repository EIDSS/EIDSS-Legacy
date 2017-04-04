using System;
using System.Globalization;
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

        [CompressFilter]
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

            return DetailsInternal<AsSession.Accessor, AsSession>(id, AsSession.Accessor.Instance(null), (int)HACode.Livestock
                , null
                , id.HasValue && isret.HasValue && isret == 1
                  ? (proxy, accessor) =>
                      {
                          //return (AsSession) ModelStorage.GetRoot(ModelUserContext.ClientID, id.Value, String.Empty);
                          return ObjectStorage.UsingRoot<AsSession, AsSession>(o => o, ModelUserContext.ClientID, id.Value, String.Empty);
                      }
                  : (Func<DbManagerProxy, AsSession.Accessor, AsSession>)null
                , null
                , c =>
                {
                    ViewBag.AsDetailsSelectedTab = 0;
                    ViewBag.AsDetailsInfoSelectedTab = 0;
                    //object AsDetailsSelectedTab = ModelStorage.Get(ModelUserContext.ClientID, 0, "AsDetailsSelectedTab", false);
                    ObjectStorage.Using<object, bool>(AsDetailsSelectedTab =>
                        {
                            if (AsDetailsSelectedTab != null)
                            {
                                ViewBag.AsDetailsSelectedTab = (int)AsDetailsSelectedTab;
                                ObjectStorage.Remove(ModelUserContext.ClientID, 0, "AsDetailsSelectedTab");
                            }
                            /*if (ModelStorage.Get(ModelUserContext.ClientID, c.idfMonitoringSession, "iSetPagable", false) == null || (!isret.HasValue || isret.Value == 0))
                            {
                                ObjectStorage.Put(ModelUserContext.ClientID, c.idfMonitoringSession, c.idfMonitoringSession, "iSetPagable", 2); // by default - unchecked (1 - checked, 2 - unchecked)
                            }*/
                            ObjectStorage.Using<object, bool>(isp =>
                            {
                                if (isp == null || (!isret.HasValue || isret.Value == 0))
                                {
                                    ObjectStorage.Put(ModelUserContext.ClientID, c.idfMonitoringSession, c.idfMonitoringSession, "iSetPagable", 2); // by default - unchecked (1 - checked, 2 - unchecked)
                                }
                                return false;
                            }, ModelUserContext.ClientID, c.idfMonitoringSession, "iSetPagable", false);
                            if (iSetPagable > 0)
                            {
                                ViewBag.AsDetailsSelectedTab = 1;
                                ViewBag.AsDetailsInfoSelectedTab = 1;
                                ObjectStorage.Put(ModelUserContext.ClientID, c.idfMonitoringSession, c.idfMonitoringSession, "iSetPagable", iSetPagable);
                            }


                            if (!readOnly && idfCampaign.HasValue)
                            {
                                //AsCampaign campaign = ModelStorage.Get(ModelUserContext.ClientID, idfCampaign.Value, "") as AsCampaign;
                                ObjectStorage.Using<AsCampaign, bool>(campaign =>
                                    {
                                        AsCampaign.AssignCampaignToSession(campaign, c);
                                        return false;
                                    }, ModelUserContext.ClientID, idfCampaign.Value, "", ForceLock: ForceReadWriteLockType.Write);
                            }
                            if (readOnly)
                                c.blnOnlyView = true;

                            return false;
                        }, ModelUserContext.ClientID, 0, "AsDetailsSelectedTab", false);
                });
        }


        [HttpPost]
        [CompressFilter]
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
                null,
                (o, p, c) =>
                { 
                    //o.Parent = p; 
                    return null; 
                }/*,
                bCompareParentForAdditional: true*/
                );
        }

        [HttpPost]
        public ActionResult MoveItem(long key, string name, long? idfAsDisease, int moveDirection)
        {
            //var list = ModelStorage.Get(ModelUserContext.ClientID, key, name) as EditableList<AsSessionDisease>;
            return ObjectStorage.Using<EditableList<AsSessionDisease>, ActionResult>(list =>
                {
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
                }, ModelUserContext.ClientID, key, name);
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
                //var session = (AsSession)ModelStorage.Get(ModelUserContext.ClientID, key, null);
                return ObjectStorage.Using<AsSession, ActionResult>(session =>
                    {
                        session.ParseFormCollection(form);
                        return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }, ModelUserContext.ClientID, key, null);
            }
            return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult SetASSessionCases(long key, long item)
        {
            //var session = (AsSession)ModelStorage.Get(ModelUserContext.ClientID, key, null);
            return ObjectStorage.Using<AsSession, ActionResult>(session =>
                {
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
                }, ModelUserContext.ClientID, key, null);
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

        [HttpPost]
        public ActionResult DeleteAnimalSample(long asSessionId, long animalSampleId)
        {
            //var asSession = (AsSession)ModelStorage.Get(ModelUserContext.ClientID, asSessionId, null);
            return ObjectStorage.Using<AsSession, ActionResult>(asSession =>
                {
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
                }, ModelUserContext.ClientID, asSessionId, null);
        }

        [HttpGet]
        public ActionResult EndEditAnimalSample(long asSessionId)
        {
            //var asSession = (AsSession)ModelStorage.Get(ModelUserContext.ClientID, asSessionId, null);
            return ObjectStorage.Using<AsSession, ActionResult>(asSession =>
            {
                var data = new CompareModel();
                AddChange(data, asSession, asSession.intTotalSamples, "intTotalSamples");
                AddChange(data, asSession, asSession.intTotalSampledAnimals, "intTotalSampledAnimals");

                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }, ModelUserContext.ClientID, asSessionId, null);
        }

    }
}
