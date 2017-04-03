using System.Linq;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;

namespace eidss.model.Schema
{
    public partial class VetFarmTree
    {
        protected static void CustomValidations(VetFarmTree obj)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Validate(manager, obj.FFPresenterCs, true, false, true);
            }
        }

        public string GetHerdName()
        {
            switch (this.idfsPartyType)
            {
                case (int)PartyTypeEnum.Herd: return strName;
                case (int)PartyTypeEnum.Farm: return EidssMessages.Get("VetFarmTree_Total");
                case (int)PartyTypeEnum.Species:
                    if (VetFarmTreeList != null)
                    {
                        var list = VetFarmTreeList.Target as EditableList<VetFarmTree>;
                        if (list != null)
                        {
                            var f = list.FirstOrDefault(x => x.idfParty == this.idfParentParty);
                            if (f != null)
                            {
                                return f.strName;
                            }
                        }
                    }
                    return "";
                default: return "";
            }
        }
        protected static void TotalQuantityRule(VetFarmTree data)
        {
            //sum of dead and sick animals must not exceed total quantity
            if (data.intTotalAnimalQty.HasValue || data.intSickAnimalQty.HasValue || data.intDeadAnimalQty.HasValue)
            {
                int total = data.intTotalAnimalQty ?? 0;
                int sick = data.intSickAnimalQty ?? 0;
                int dead = data.intDeadAnimalQty ?? 0;

                if (sick + dead > total)
                    throw new ValidationModelException("VetFarmTree_TotalQuantityRule_Obeyed", "", "", new string[] {},
                                                       null, false, data);
            }
        }

        public static void UpdateTemplate(VetFarmTree obj)
        {
            var templateSpecies = FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID,
                                                                           obj.idfsDiagnosisForCs,
                                                                           (obj._HACode == (int)HACode.Livestock)
                                                                               ? FFTypeEnum.LivestockSpeciesCS
                                                                               : FFTypeEnum.AvianSpeciesCS);
            obj.FFPresenterCs.SetProperties(templateSpecies, obj.idfParty);
            obj.idfsFormTemplate = templateSpecies.idfsFormTemplate;
        }
    }


    public partial class RootFarmTree
    {
        protected static void TotalQuantityRule(RootFarmTree data)
        {
            //sum of dead and sick animals must not exceed total quantity
            if (data.intTotalAnimalQty.HasValue || data.intSickAnimalQty.HasValue || data.intDeadAnimalQty.HasValue)
            {
                int total = data.intTotalAnimalQty ?? 0;
                int sick = data.intSickAnimalQty ?? 0;
                int dead = data.intDeadAnimalQty ?? 0;

                if (sick + dead > total)
                    throw new ValidationModelException("VetFarmTree_TotalQuantityRule_Obeyed", "", "", new string[] { },
                                                       null, false, data);
            }
        }
    }
}
