using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using eidss.model.Schema;
using eidss.model.Resources;
using eidss.model.Enums;
using eidss.model.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using BLToolkit.EditableObjects;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class ASSessionFarmController : BvController
    {
        [HttpGet]
        public ActionResult Details(long key, string name, long item, bool details, bool summary)
        {
            Session["AsDetailsSelectedTab"] = details ? 1 : 2;
            var hacode = (int)HACode.Livestock;
            return PickerInternal<AsSessionFarm.Accessor, AsSessionFarm, AsSession>(key, item, name, AsSessionFarm.Accessor.Instance(null), hacode,
                (m, a, p) =>
                {
                    var ret = p.ASFarmsAll.Single(c => (long)c.Key == item).CloneWithSetup(m, true) as AsSessionFarm;
                    return ret;
                },
                (m, a, s) =>
                {
                    var acc = AsSessionFarm.Accessor.Instance(null);
                    return a.CreateNewT(m, s, hacode);
                },
                (m, a, c) =>
                {
                    ModelStorage.Put(Session.SessionID, key, c.idfFarm, null, c.Farm);
                    ViewBag.IdfRoot = c.idfFarm;
                });
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            bool details = form["ASFdetails"] == "true";
            bool summary = form["ASFsummary"] == "true";
            return PickerInternal<AsSessionFarm.Accessor, AsSessionFarm, AsSession>(form, AsSessionFarm.Accessor.Instance(null), null,
                p => p.ASFarmsAll,
                (i, o) => i.idfFarm == o.idfFarm,
                (to, from) =>
                {
                    to.Farm.FarmTree.Clear();
                    to.Farm.FarmTree.AddRange(from.Farm.FarmTree);
                    to.Farm.FarmTree.ForEach(i => i.SetChange());

                    if (details)
                        to.blnIsDetailsFarm = true;
                    if (summary)
                        to.blnIsSummaryFarm = true;
                },
                (o, p) =>
                {
                    if (details)
                        o.blnIsDetailsFarm = true;
                    if (summary)
                        o.blnIsSummaryFarm = true;
                });
        }

        public ActionResult DeleteFarm(long asSessionId, long farmId, bool bDeleteDetails)
        {
            var asSession = (AsSession)ModelStorage.Get(Session.SessionID, asSessionId, null);
            var farm = asSession.ASFarmsAll.FirstOrDefault(c => c.idfFarm == farmId && !c.IsMarkedToDelete);
            var data = new CompareModel();
            ViewBag.ErrorMessage = null;
            if (farm != null)
            {
                farm.bDeleteInDetails = bDeleteDetails;
                farm.bDeleteInSummary = !bDeleteDetails;
                farm.Validation += ValidationDeleteFarm;
                farm.MarkToDelete();
                farm.Validation -= ValidationDeleteFarm;
                farm.bDeleteInDetails = false;
                farm.bDeleteInSummary = false;
            }

            if (ViewBag.ErrorMessage != null)
            {
                data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                ViewBag.ErrorMessage.ToString(),
                                false, false, false);
            }

            ModelStorage.Put(Session.SessionID, asSessionId, asSessionId, asSession.ObjectIdent + (bDeleteDetails ? "ASFarmsDetails" : "ASFarmsSummary"), bDeleteDetails ? asSession.ASFarmsDetails : asSession.ASFarmsSummary);
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        void ValidationDeleteFarm(object sender, ValidationEventArgs args)
        {
            ViewBag.ErrorMessage = Translator.GetErrorMessage(args);
        }


        public ActionResult HerdOrFlockList(long root, string listName, EditableList<VetFarmTree> items, bool readOnly)
        {
            var prev = ModelStorage.Get(Session.SessionID, root, listName, false);
            if (prev == null)
                ModelStorage.Put(Session.SessionID, root, root, listName, items);
            ViewBag.IsReadOnly = readOnly;
            ViewBag.Root = root;
            ViewBag.ListName = listName;
            items.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
            return PartialView(items);
        }

        public ActionResult CreateHerdOrFlock(long key, string listName)
        {
            string errorMsg = string.Empty;
            VetFarmTree newHerdOrFlock = VetFarmTreeProcessor.CreateHerdOrFlockAsSession(Session.SessionID, key, listName, out errorMsg);
            if (newHerdOrFlock != null)
            {
                ViewBag.IsReadOnly = false;
                return ShowHerdOrFlock(key, listName, newHerdOrFlock, false);
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new { ErrorMessage = errorMsg } };
        }

        public ActionResult ShowHerdOrFlock(long key, string listName, VetFarmTree herdOrFlock, bool isReadOnly)
        {
            var list = ModelStorage.Get(Session.SessionID, key, listName, true) as EditableList<VetFarmTree>;
            list.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
            var items = list.Where(x => x.idfsPartyType == (long)PartyTypeEnum.Species && x.idfParentParty == herdOrFlock.idfParty).ToList();
            var speciesList = new VetFarmTree.VetFarmTreeGridModelList(key, items);
            var gridName = string.Format("SpeciesList_{0}", herdOrFlock.idfParty);
            ModelStorage.Put(Session.SessionID, key, key, gridName, EditableList<VetFarmTree>.Adapter(items));
            ViewBag.IdfRoot = key;
            ViewBag.GridName = gridName;
            ViewBag.ListName = listName;
            ViewBag.SpeciesList = speciesList;
            ViewBag.IsReadOnly = isReadOnly;
            return PartialView("ShowHerdOrFlock", herdOrFlock);
        }

        public ActionResult SpeciesDetail(long idfRoot, string gridName, long? idfSpecies, long? idfHerdParty, long idfMonitoringSession)
        {
            ViewBag.GridName = gridName;
            ViewBag.IdfMonitoringSession = idfMonitoringSession;
            ViewBag.IdfRoot = idfRoot;
            return PickerInternal<VetFarmTree.Accessor, VetFarmTree, AsSessionFarm>(idfRoot, idfSpecies.HasValue ? idfSpecies.Value : 0,
                gridName, VetFarmTree.Accessor.Instance(null),
                null,
                null,
                (m, a, p) =>
                {
                    var prnt = p.Farm.FarmTree.FirstOrDefault(x => x.idfsPartyType == (int)PartyTypeEnum.Herd && x.idfParty == idfHerdParty && !x.IsMarkedToDelete);
                    return VetFarmTree.Accessor.Instance(null).CreateSpecies(m, p.Farm, prnt);
                },
                null
                );
        }

        [HttpPost]
        public ActionResult SpeciesDetail(long idfMonitoringSession, long idfRoot, long? idfSpecies, string gridName, FormCollection form)
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
                        var speciesGridItems = ModelStorage.Get(Session.SessionID, idfRoot, gridName) as EditableList<VetFarmTree>;
                        speciesGridItems.Add(o);
                    }
                    p.FarmTree.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
                }
                );
        }

        public ActionResult AnimalSampleDetail(long idfMonitoringSession, string gridName, long? idfAnimalSample)
        {
            ViewBag.GridName = gridName;
            ViewBag.IdfMonitoringSession = idfMonitoringSession;
            ViewBag.IdfRoot = idfMonitoringSession;
            return PickerInternal<AsSessionAnimalSample.Accessor, AsSessionAnimalSample, AsSession>(idfMonitoringSession, idfAnimalSample.HasValue ? idfAnimalSample.Value : 0,
                gridName, AsSessionAnimalSample.Accessor.Instance(null), null,
                null,
                null,
                null
                );
        }

        [HttpPost]
        public ActionResult AnimalSampleDetail(long idfMonitoringSession, long idfAnimalSample, string gridName, FormCollection form)
        {
            //form.Remove(form.AllKeys.Single(c => c.EndsWith("Animals")));
            return PickerInternal<AsSessionAnimalSample.Accessor, AsSessionAnimalSample, AsSession>(form, AsSessionAnimalSample.Accessor.Instance(null),
                null,
                p => p.ASAnimalsSamples,
                (o, i) => o.id == i.id,
                null,
                /*(o, p) =>
                    o.ParentAnimalsSamples.ForEach(c =>
                        {
                            c.AnimalAge = (c.idfAnimal == o.idfAnimal ? o.AnimalAge : c.AnimalAge);
                            c.strColor = (c.idfAnimal == o.idfAnimal ? o.strColor : c.strColor);
                            c.AnimalGender = (c.idfAnimal == o.idfAnimal ? o.AnimalGender : c.AnimalGender);
                            c.strDescription = (c.idfAnimal == o.idfAnimal ? o.strDescription : c.strDescription);
                        })*/
                (o, p) => o.ParentAnimalsSamples.ForEach(c => c.Parent = p),
                bCompareParentForAdditional: true
                );
        }
        
        [HttpGet]
        public ActionResult NumberOfCopies(long root, string gridName, long idfSample)
        {
            ViewBag.GridName = gridName;
            ViewBag.IdfMonitoringSession = root;
            ViewBag.IdfRoot = idfSample;

            return PickerInternal<AsSessionAnimalSample.Accessor, AsSessionAnimalSample, AsSession>(root, idfSample, gridName, AsSessionAnimalSample.Accessor.Instance(null), null,
            null,
            null,
            null);
        }
        

        [HttpPost]
        public ActionResult NumberOfCopies(FormCollection form)
        {
            return PickerInternal<AsSessionAnimalSample.Accessor, AsSessionAnimalSample, AsSession>(form, AsSessionAnimalSample.Accessor.Instance(null), "IdfRoot",
                p => p.ASAnimalsSamples,
                (i, o) => i.id == o.id,
                null,
                (o, p) => 
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        for (int i = 0; i < o.NumOfCopies; i++)
                            p.ASAnimalsSamples.Add(AsSessionAnimalSample.Accessor.Instance(null).CreateCopy(manager, p, o));
                    }
                    o.ParentAnimalsSamples.ForEach(c => c.Parent = p);
                },
                bCompareParentForAdditional: true
                );
        }

    }
}
