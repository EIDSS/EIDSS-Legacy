using System;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Enums;
using bv.model.Model.Core;
using bv.model.Model.Validators;

namespace eidss.model.Schema
{
    public partial class FarmPanel
    {
        protected static void CustomValidations(FarmPanel obj)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Validate(manager, obj.FFPresenterEpi, true, false, true);
            }
        }

        public void CopyFieldsFromRootFarm()
        {

            if (!idfRootFarm.HasValue || idfRootFarm.Value == 0)// && idfRootFarm_Previous.HasValue))// || (!idfRootFarm_Previous.HasValue && IsNew) )))
                return;

            string[] populateFarm = new string[] {
                      "strNationalName",
                      "strOwnerLastName",
                      "strOwnerFirstName",
                      "strOwnerMiddleName",
                      "strContactPhone",
                      "strFax",
                      "strEmail",                      
                      "idfsOwnershipStructure",
                      "idfsLivestockProductionType",
                      "idfsMovementPattern",
                      "idfsGrazingPattern",
                      "idfsAvianFarmType",
                      "idfsAvianProductionType",
                      "idfsIntendedUse",
                      "OwnershipStructure",
                      "LivestockProductionType",
                      "MovementPattern",
                      "GrazingPattern",
                      "AvianFarmType",
                      "AvianProductionType",
                      "IntendedUse",
                      "intBuildings",
                      "intBirdsPerBuilding",
                      "strFarmCode"
                      };
            using (var manager = DbManagerFactory.Factory.Create(Core.EidssUserContext.Instance))
            {
                var acc = Accessor.Instance(null);

                var farm = (FarmPanel)acc.SelectDetail(manager, this.idfRootFarm.Value);
                farm.Address.CopyFieldsTo(this.Address);
                //  Address.Key = this.idfFarmAddress;

                foreach (var prop in populateFarm)
                    if (farm.GetValue(prop) != null)
                        this.SetValue(prop, farm.GetValue(prop).ToString());

                // this.FarmTree.Where(x => x.idfsPartyType == (int)PartyTypeEnum.Farm).ToList().ForEach(f => f.strHerdName = this.strFarmCode);
            }
        }

        public static FarmPanel LivestockFarmFromRoot(long idfRootFarm, long idfMonitoringSession)
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var idfFarm = manager.SetSpCommand("dbo.spsysGetNewID", DBNull.Value).ExecuteScalar<long>(BLToolkit.Data.ScalarSourceType.OutputParameter);
                //spFarm_CopyRootToNormal
                manager.SetSpCommand("spFarm_CopyRootToNormal",
                     manager.Parameter("idfRootFarm", idfRootFarm),
                     manager.Parameter("idfTargetFarm", idfFarm),
                     manager.Parameter("idfMonitoringSession", DBNull.Value)).ExecuteNonQuery();

                var farm = FarmPanel.Accessor.Instance(null).SelectByKey(manager, idfFarm, (int)HACode.Livestock);
                farm.idfMonitoringSession = idfMonitoringSession;
                return farm;
            }
        }

        public static FarmPanel LivestockFarmRefreshFromRoot(long idfRootFarm, long idfFarm)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                //refresh normal farm's data from root
                manager.SetSpCommand("spFarm_CopyRootToNormal",
                     manager.Parameter("idfRootFarm", idfRootFarm),
                     manager.Parameter("idfTargetFarm", idfFarm),
                     manager.Parameter("idfMonitoringSession", DBNull.Value)).ExecuteNonQuery();

                return FarmPanel.Accessor.Instance(null).SelectByKey(manager, idfFarm, (int)HACode.Livestock);
            }
        }



        public static void DuplicateSpeciesRule(FarmPanel farm)
        {
            if (farm.FarmTree.Where(t => t.idfsPartyType == (int)PartyTypeEnum.Species).GroupBy(x => new { parent = x.idfParentParty, idfsSpecies = x.idfsSpeciesTypeReference }).Where(s => s.Count() > 1).Count() > 0)
            {
                byte counter = 0;
                foreach (var herd in farm.FarmTree.Where(t => t.idfsPartyType == (int)PartyTypeEnum.Species).GroupBy(x => new { parent = x.idfParentParty, idfsSpecies = x.idfsSpeciesTypeReference }).Where(s => s.Count() > 1))
                {
                    foreach (var spec in herd)
                    {
                        if (!spec.IsMarkedToDelete)
                            counter++;
                        if (counter > 1)
                        {
                            string errorMessage = spec._HACode == (int)HACode.Livestock ? "DuplicateSpeciesLivestock_msgId" : "DuplicateSpeciesAvian_msgId";
                            throw new ValidationModelException(errorMessage, "", "", new string[] { }, null, false, farm);
                        }
                    }
                }
            }


        }

        public static bool NewFarmTreeItemIsValid(FarmPanel panel, VetFarmTree item)
        {
            if (item.idfsPartyType != (int)PartyTypeEnum.Species)
                return true;

            if (panel.FarmTree.Count(
                x => x.idfsPartyType == (int)PartyTypeEnum.Species
                    && x.idfParentParty == item.idfParentParty
                    && x.idfsSpeciesTypeReference == item.idfsSpeciesTypeReference
                    && !x.IsMarkedToDelete) > 1)
            {
                string errorMessage = item._HACode == (int)HACode.Livestock ? "DuplicateSpeciesLivestock_msgId" : "DuplicateSpeciesAvian_msgId";
                throw new ValidationModelException(errorMessage, "", "", new object[] { }, null, false, panel);
            }
            FarmPanel.RecalcAllAnimalQty(panel, item);
                
            return true;
        }

        public static void RecalcTotalAnimalQty(FarmPanel obj, VetFarmTree item)
        {
            var itemsCount = obj.FarmTree.Count(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete && c.intTotalAnimalQty.HasValue);
            var sum = obj.FarmTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intTotalAnimalQty);
            var o = obj.FarmTree.Single(c => c.idfParty == item.idfParentParty);
            o.intTotalAnimalQty = sum == 0 && itemsCount == 0 ? null : sum;
        }
        public static void RecalcSickAnimalQty(FarmPanel obj, VetFarmTree item)
        {
            var sum = obj.FarmTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intSickAnimalQty);
            var o = obj.FarmTree.Single(c => c.idfParty == item.idfParentParty);
            o.intSickAnimalQty = sum == 0 ? null : sum;
        }
        public static void RecalcDeadAnimalQty(FarmPanel obj, VetFarmTree item)
        {
            var sum = obj.FarmTree.Where(c => c.idfParentParty == item.idfParentParty && !c.IsMarkedToDelete).Sum(c => c.intDeadAnimalQty);
            var o = obj.FarmTree.Single(c => c.idfParty == item.idfParentParty);
            o.intDeadAnimalQty = sum == 0 ? null : sum;
        }
        public static void RecalcAllAnimalQty(FarmPanel obj, VetFarmTree item)
        {
            RecalcTotalAnimalQty(obj, item);
            RecalcSickAnimalQty(obj, item);
            RecalcDeadAnimalQty(obj, item);
        }

        public static bool SpeciesContainsValidHerd(FarmPanel panel, VetFarmTree item)
        {
            if (item.idfsPartyType != (int)PartyTypeEnum.Species)
                return true;
            string par =  ((int)HACode.Livestock).Equals(item._HACode) ? "strHerd" : "strFlock";
            if (item.idfParentParty == null)
                throw new ValidationModelException("ErrMandatoryFieldRequired", "FarmTree", item._HACode == (int)HACode.Livestock ? "Herd" : "Flock", new object[] { par}, typeof(RequiredValidator), false, panel);
            if (panel.FarmTree.Count(x => x.idfParty == item.idfParentParty && !x.IsMarkedToDelete) == 0)
            {
                throw new ValidationModelException("ErrInvalidValue", "", "", new object[] { par }, null, false, panel);
            }
            return true;
        }

        public static void CheckAddressToSessionAddress(FarmPanel farm)
        {
            if (farm.ASSession != null)
            {
                if ((farm.ASSession.idfsSettlement.HasValue && farm.ASSession.idfsSettlement != farm.Address.idfsSettlement) ||
                    (farm.ASSession.idfsRayon.HasValue && farm.ASSession.idfsRayon != farm.Address.idfsRayon) ||
                    (farm.ASSession.idfsRegion.HasValue && farm.ASSession.idfsRegion != farm.Address.idfsRegion) ||
                    (farm.ASSession.idfsCountry.HasValue && farm.ASSession.idfsCountry != farm.Address.idfsCountry))
                            throw new ValidationModelException("msgAddressIsOutOfBoundaries", "", "", new string[] { }, null, true, farm);
            }
        }
    }
}
