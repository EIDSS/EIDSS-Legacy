using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.mobileclient.Attributes;
using eidss.mobileclient.Utils;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.mobileclient.Controllers
{
    [Authorize]
    public class FarmController : Controller
    {
        [SessionExpireFilter]
        public ActionResult FarmDetails(FarmPanel farm, int? caseType = null)
        {
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.CanUpdate = vetCaseAccessor.CanUpdate;
            if (!caseType.HasValue)
            {
                caseType = (int)HACode.Livestock;
            }
            IObject initObject;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                initObject = vetCaseAccessor.CreateNew(manager, null, caseType.Value);
            }
            ViewBag.IsHiddenPersonalData = initObject.IsHiddenPersonalData("Vet_Farm");
            ViewBag.RootKey = farm.idfCase.Value;
            ViewBag.CaseType = caseType.Value;
            ModelStorage.Put(Session.SessionID, farm.idfCase.Value, farm.idfFarm, null, farm);
            return PartialView(farm);
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult EpidemiologicalInformation(long root)
        {
            var vc = ModelStorage.Get(Session.SessionID, root, null) as VetCase;
            if (vc.Farm.idfsFormTemplate.HasValue && vc.Farm.FFPresenterEpi != null)
            {
                vc.Farm.FFPresenterEpi.ReadOnly = vc.ReadOnly || vc.IsClosed;
            }
            VetCase.Accessor vetCaseAccessor = VetCase.Accessor.Instance(null);
            ViewBag.CanUpdate = vetCaseAccessor.CanUpdate;
            ViewBag.RootKey = vc.idfCase;
            Session["ReturnUrl"] = Url.Action("EpidemiologicalInformation", "Farm", new { root = vc.idfCase });
            return PartialView(vc.Farm);
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult FarmsList(long rootKey, long farmId)
        {
            ViewBag.IdfCase = rootKey;
            ViewBag.FarmId = farmId;
            var farmPanel = (FarmPanel)ModelStorage.Get(Session.SessionID, farmId, null);
            List<FarmListItem> farms = GetFarmsList(farmPanel);
            ViewBag.ItemsCount = farms == null ? 0 : farms.Count;
            List<FarmListItem> resultList = farms == null ? farms : farms.Take(100).ToList();
            return View(resultList);
        }

        private static List<FarmListItem> GetFarmsList(FarmPanel farmInfoForSearch)
        {
            var accessor = FarmListItem.Accessor.Instance(null);
            FilterParams filter = GetFilterForFarmsList(farmInfoForSearch);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<FarmListItem> farms = accessor.SelectListT(dbmanager, filter);
                return farms;
            }
        }

        private static FilterParams GetFilterForFarmsList(FarmPanel farmInfoForSearch)
        {
            var filter = new FilterParams();
            if (!string.IsNullOrEmpty(farmInfoForSearch.strContactPhone))
            {
                filter.Add("strContactPhone", "like", String.Format("%{0}%", farmInfoForSearch.strContactPhone));
            }
            if (farmInfoForSearch.idfsOwnershipStructure.HasValue)
            {
                filter.Add("idfsOwnershipStructure", "=", farmInfoForSearch.idfsOwnershipStructure);
            }
            if (farmInfoForSearch.idfsLivestockProductionType.HasValue)
            {
                filter.Add("idfsLivestockProductionType", "=", farmInfoForSearch.idfsLivestockProductionType);
            }
            if (farmInfoForSearch.Address.idfsCountry.HasValue)
            {
                filter.Add("idfsCountry", "=", farmInfoForSearch.Address.idfsCountry);
            }
            if (farmInfoForSearch.Address.idfsRegion.HasValue)
            {
                filter.Add("idfsRegion", "=", farmInfoForSearch.Address.idfsRegion);
            }
            if (farmInfoForSearch.Address.idfsRayon.HasValue)
            {
                filter.Add("idfsRayon", "=", farmInfoForSearch.Address.idfsRayon);
            }
            if (farmInfoForSearch.Address.idfsSettlement.HasValue)
            {
                filter.Add("idfsSettlement", "=", farmInfoForSearch.Address.idfsSettlement);
            }
            if (farmInfoForSearch.Address.idfsSettlement.HasValue)
            {
                filter.Add("idfsSettlement", "=", farmInfoForSearch.Address.idfsSettlement);
            }
            if (!string.IsNullOrEmpty(farmInfoForSearch.strOwnerFirstName))
            {
                filter.Add("strFirstName", "like", String.Format("%{0}%", farmInfoForSearch.strOwnerFirstName));
            }
            if (!string.IsNullOrEmpty(farmInfoForSearch.strOwnerMiddleName))
            {
                filter.Add("strSecondName", "like", String.Format("%{0}%", farmInfoForSearch.strOwnerMiddleName));
            }
            if (!string.IsNullOrEmpty(farmInfoForSearch.strOwnerLastName))
            {
                filter.Add("strLastName", "like", String.Format("%{0}%", farmInfoForSearch.strOwnerLastName));
            }
            if (!string.IsNullOrEmpty(farmInfoForSearch.strNationalName))
            {
                filter.Add("strNationalName", "like", String.Format("%{0}%", farmInfoForSearch.strNationalName));
            }
            return filter;
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult SetSelectedFarm(string root, string selectedId)
        {
            long key = long.Parse(root);
            long rootKey = (long)((IObject)ModelStorage.GetRoot(Session.SessionID, key, null)).Key;
            var vetCase = ModelStorage.Get(Session.SessionID, rootKey, null) as VetCase;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var cloneVetCase = (VetCase)vetCase.CloneWithSetup(manager);
                long idfFarm = string.IsNullOrEmpty(selectedId) ? 0 : long.Parse(selectedId);
                if (idfFarm == 0)
                {
                    var accessor = FarmPanel.Accessor.Instance(null);
                    vetCase.Farm = accessor.CreateByCase(manager, vetCase, vetCase);
                }
                else
                {
                    vetCase.Farm.idfRootFarm = idfFarm;
                }
                CompareModel data = vetCase.Compare(cloneVetCase);
                return new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data};
            }
        }
    }
}
