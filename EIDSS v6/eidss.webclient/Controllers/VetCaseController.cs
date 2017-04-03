using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using Kendo.Mvc.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Resources;
using eidss.model.Enums;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class VetCaseController : BvController
    {

        public ActionResult Index()
        {
            return IndexInternal<VetCaseListItem.Accessor, VetCaseListItem, VetCaseListItem.VetCaseListItemGridModelList>
                (VetCaseListItem.Accessor.Instance(null), AutoGridRoots.VetCaseList, false);
            }

        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<VetCaseListItem.Accessor, VetCaseListItem, VetCaseListItem.VetCaseListItemGridModelList>
                (form, VetCaseListItem.Accessor.Instance(null), AutoGridRoots.VetCaseList, request);
        }

        public ActionResult Details(string type, long? id)
        {
            var hacode = (int)HACode.Livestock;
            if (!String.IsNullOrWhiteSpace(type) && type.Equals("avian", StringComparison.InvariantCultureIgnoreCase))
                    hacode = (int)HACode.Avian;
            return DetailsInternal<VetCase.Accessor, VetCase>(id, VetCase.Accessor.Instance(null), hacode, null, null, null,
                c =>
            {
                    ModelStorage.Put(Session.SessionID, c.idfCase, c.Farm.idfFarm, null, c.Farm);
                    ViewBag.Title = Translator.GetMessageString((c._HACode == (int)HACode.Avian) ? "pageTitleAvianDetails" : "pageTitleLvstkDetails");
                    ViewBag.DiagnosisId = c.idfsFinalDiagnosis ?? c.idfsTentativeDiagnosis;
                });

            }
            
        public ActionResult CreateLivestock(long? id)
        {
            return RedirectToAction("Details", new { type = "Lvstck" });
        }

        public ActionResult CreateAvian(long? id)
        {
            return RedirectToAction("Details", new { type = "Avian"});         
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            return DetailsInternalAjax<VetCase.Accessor, VetCase>(form, VetCase.Accessor.Instance(null), null,
                (o, c) =>
                    {
                        if (c.idfsCaseProgressStatus == (long)CaseStatusEnum.Closed)
                            c.SetChange();

                        if (o != null)
                        {
                            //Леонов: для Avian Cases FFPresenterControlMeasures не задан, но создаётся "пустым" ввиду relation
                            if ((o.FFPresenterControlMeasures != null) && (o.FFPresenterControlMeasures.CurrentTemplate != null))
                                o.FFPresenterControlMeasures.ParseFormCollection(form);
                            if ((o.Farm.FFPresenterEpi != null) && (o.Farm.FFPresenterEpi.CurrentTemplate != null))
                                o.Farm.FFPresenterEpi.ParseFormCollection(form);
                            o.Farm.Address.bCancelCoordinationValidation = true;
                        }
                    }, 
                c =>
            {
                        c.Farm.Address.bCancelCoordinationValidation = true;
                    },
                c =>
                {
                        ViewBag.Title = Translator.GetMessageString((c._HACode == (int)HACode.Avian) ? "pageTitleAvianDetails" : "pageTitleLvstkDetails");
                        ViewBag.DiagnosisId = c.idfsFinalDiagnosis ?? c.idfsTentativeDiagnosis;
            ViewBag.ShowCIVetCaseReportClick = form["ShowCIVetCaseReportClick"];
            ViewBag.ShowTestsReportClick = form["ShowTestsReportClick"];
                    });
        }

        [HttpPost]
        public ActionResult StoreCase(FormCollection form)
        {
            var key = long.Parse(form["idfCase"]);
            var vetCase = (VetCase)ModelStorage.Get(Session.SessionID, key, null);
            vetCase.ParseFormCollection(form);
            return new JsonResult { Data = "", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public ActionResult GetEpiFlexForm(long root)
        {
            var vc = ModelStorage.Get(Session.SessionID, root, null) as VetCase;
            if ((vc != null) && (vc.Farm.FFPresenterEpi != null) && (vc.Farm.idfsFormTemplate.HasValue))
            {
                VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
                vc.Farm.FFPresenterEpi.ReadOnly = vetCaseAccessor.IsReadOnlyForEdit || vc.IsClosed;
                ModelStorage.Put(Session.SessionID, vc.idfCase, vc.idfCase, vc.Farm.FFPresenterEpi.CurrentObservation.Value.ToString(), vc.Farm.FFPresenterEpi);
                var ffDivContent = this.RenderPartialView("EpiFFHolder", vc.Farm);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

        public ActionResult GetCMFlexForm(long root)
        {
            var vc = ModelStorage.Get(Session.SessionID, root, null) as VetCase;
            if ((vc != null) && (vc.idfsFormTemplate.HasValue && vc.FFPresenterControlMeasures != null))
            {
                VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
                vc.FFPresenterControlMeasures.ReadOnly = vetCaseAccessor.IsReadOnlyForEdit || vc.IsClosed;
                ModelStorage.Put(Session.SessionID, vc.idfCase, vc.idfCase, vc.FFPresenterControlMeasures.CurrentObservation.Value.ToString(), vc.FFPresenterControlMeasures);
                var ffDivContent = this.RenderPartialView("ControlMeasures", vc);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
        }

        
        private ActionResult _VetCasePicker(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow, FilterParams filter)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.FunctionName = functionName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;
            ViewBag.IsMultiSelection = isMultiSelection;

            return IndexInternal<VetCaseListItem.Accessor, VetCaseListItem, VetCaseListItem.VetCaseListItemGridModelList>
                (VetCaseListItem.Accessor.Instance(null), AutoGridRoots.VetCasePopUpSelectList, true, filter, "VetCasePicker");
        }

        [HttpGet]
        public ActionResult VetCasePickerForOutbreak(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow)
        {
            var rootObject = (Outbreak)ModelStorage.Get(Session.SessionID, long.Parse(objectId), null);
            FilterParams filter = null;
            if (rootObject.Diagnosis != null)
            {
                ViewBag.SearchHint = Translator.GetMessageString("msgCasesWithDiagnosis");
                ViewBag.StaticFilter = new FilterParams().Add("bWithDiagnosisOnly", "=", true);

                filter = new FilterParams();
                if (rootObject.Diagnosis.blnGroup.HasValue && rootObject.Diagnosis.blnGroup.Value)
                    filter.Add("idfsDiagnosisGroup", "=", rootObject.Diagnosis.idfsDiagnosisOrDiagnosisGroup);
                else if (rootObject.Diagnosis.idfsDiagnosisGroup.HasValue && rootObject.Diagnosis.idfsDiagnosisGroup.Value != 0)
                    filter.Add("idfsDiagnosisGroup", "=", rootObject.Diagnosis.idfsDiagnosisGroup);
                else
                    filter.Add("idfsDiagnosis", "=", rootObject.Diagnosis.idfsDiagnosisOrDiagnosisGroup);
            }
            return _VetCasePicker(objectId, functionName, isMultiSelection, showInInternalWindow, filter);
        }

        [HttpGet]
        public ActionResult VetCasePicker(string objectId, string functionName, bool isMultiSelection, bool showInInternalWindow)
        {
            return _VetCasePicker(objectId, functionName, isMultiSelection, showInInternalWindow, null);
        }

        public ActionResult HerdOrFlockList(long root, string listName, EditableList<VetFarmTree> items, bool readOnly, bool isFlock = false)
        {
            ModelStorage.Put(Session.SessionID, root, root, listName, items);
            ViewBag.IsReadOnly = readOnly;
            ViewBag.Root = root;
            ViewBag.ListName = listName;
            ViewBag.IsFlock = isFlock;
            items.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
            return PartialView(items);
        }

        public ActionResult CreateHerdOrFlock(long key, string listName, bool isFlock = false)
        {
            string errorMsg = string.Empty;
            VetFarmTree newHerdOrFlock = VetFarmTreeProcessor.CreateHerdOrFlock(Session.SessionID, key, listName, out errorMsg);
            if (newHerdOrFlock!=null)
            {
                ViewBag.IsReadOnly = false;
                return ShowHerdOrFlock(key, listName, newHerdOrFlock, false, isFlock);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { ErrorMessage = errorMsg } };
        }

        public ActionResult ShowHerdOrFlock(long key, string listName, VetFarmTree herdOrFlock, bool isReadOnly, bool isFlock = false)
        {
            var list = ModelStorage.Get(Session.SessionID, key, listName, true) as EditableList<VetFarmTree>;
            list.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
            var items = list.Where(x => x.idfsPartyType == (long) PartyTypeEnum.Species&& x.idfParentParty == herdOrFlock.idfParty).ToList();
            var speciesList = new VetFarmTree.VetFarmTreeGridModelList(key, items);
            var gridName = string.Format("SpeciesList_{0}", herdOrFlock.idfParty);
            ModelStorage.Put(Session.SessionID, key, key, gridName, EditableList <VetFarmTree>.Adapter(items));
            ViewBag.IdfVetCase = key;
            ViewBag.GridName = gridName;
            ViewBag.ListName = listName;
            ViewBag.SpeciesList = speciesList;
            ViewBag.IsReadOnly = isReadOnly;
            ViewBag.IsFlock = isFlock;
            return PartialView("ShowHerdOrFlock", herdOrFlock);
        }

        public ActionResult SpeciesDetail(long listKey, string gridName, long? idfSpecies, long? idfHerdParty, long idfCase)
        {
            ViewBag.GridName = gridName;
            ViewBag.ListKey = listKey;
            ViewBag.IdfCase = idfCase;
            return PickerInternal<VetFarmTree.Accessor, VetFarmTree, VetCase>(idfCase, idfSpecies.HasValue ? idfSpecies.Value : 0,
                gridName, VetFarmTree.Accessor.Instance(null),
                null,
                null,
                (m, a, p) =>
                {
                    var prnt = p.Farm.FarmTree.FirstOrDefault(x => x.idfsPartyType == (int)PartyTypeEnum.Herd && x.idfParty == idfHerdParty && !x.IsMarkedToDelete);
                    return VetFarmTree.Accessor.Instance(null).CreateSpeciesWithDiagnosis(m, p.Farm, prnt, p.idfsDiagnosis);
                },
                null
                );
        }

        [HttpPost]
        public ActionResult SpeciesDetail(long idfCase, long? idfSpecies, string gridName, FormCollection form)
        {
            bool bEdit = false;
            return PickerInternal<VetFarmTree.Accessor, VetFarmTree, FarmPanel>(form, VetFarmTree.Accessor.Instance(null),
                null, 
                p => p.FarmTree,
                (o, i) => { var ret = o.idfParty == i.idfParty; if (ret) bEdit = true; return ret; },
                null,
                (o, p) =>
                    {
                        if (!bEdit)
                        {
                            var speciesGridItems = ModelStorage.Get(Session.SessionID, idfCase, gridName) as EditableList<VetFarmTree>;
                            speciesGridItems.Add(o);
                        }
                        p.FarmTree.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
                    },
                null
                );
        }

        [HttpGet]
        public ActionResult VetInvestigationReport(long caseId, long diagnosisId)
        {
            var vc = ModelStorage.Get(Session.SessionID, caseId, null) as VetCase;
            if (vc == null)
            {
                throw new BvModelException(@"Can't get Vet Case");
            }
            try
            {
                byte[] report;
            using (var wrapper = new ReportClientWrapper())
            {
                var model = new VetIdModel(ModelUserContext.CurrentLanguage, caseId, diagnosisId, ModelUserContext.Instance.IsArchiveMode);
                report = vc._HACode == (int) HACode.Livestock
                             ? wrapper.Client.ExportVetLivestockInvestigation( model)
                             : wrapper.Client.ExportVetAvianInvestigation( model);
            }
            return ReportResponse(report, "VetInvestigationReport.pdf");
        }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }
    }
}
