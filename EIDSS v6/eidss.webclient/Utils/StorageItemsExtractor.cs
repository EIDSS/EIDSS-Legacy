using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eidss.model.Schema;
using eidss.model.Enums;
using System.Web.Mvc;
using eidss.web.common.Utils;

namespace eidss.webclient.Utils
{
    public static class StorageItemsExtractor
    {
        public static IEnumerable<SelectListItem> CurrentHerdAndSpeciesOfCase(string sessionId, long idfCase, long? value = null)
        {
            var parent = ModelStorage.GetRoot(sessionId, idfCase, null) as VetCase;

            var tree = parent.Farm.FarmTree;
            if (tree == null)
                return new List<SelectListItem>();

            foreach (var item in tree.Where(t => t.idfsPartyType == (long)PartyTypeEnum.Species))
            {
                item.strHerdName = tree.Where(t => t.idfParty == item.idfParentParty).First().strName;
            }
            
            return tree.Where(t => t.idfsPartyType == (long)PartyTypeEnum.Species && !t.IsMarkedToDelete).Select(t =>
                new SelectListItem
                {
                    Value = t.idfParty.ToString(),
                    Text = String.Format("{0}/{1}", t.strHerdName, t.strSpeciesName),
                    Selected = value.HasValue ? (t.idfParty == value.Value) : false
                });            
        }

        public static IEnumerable<SelectListItem> HerdsOfCase(string sessionId, long idfCase, string name, long? value = null)
        {
            var tree = ModelStorage.Get(sessionId, idfCase, name) as IEnumerable<VetFarmTree>;
            if (tree == null)
                return new List<SelectListItem>();

            return tree.Where(t => t.idfsPartyType == (long)PartyTypeEnum.Herd && !t.IsMarkedToDelete).Select(t =>
                new SelectListItem
                {
                    Value = t.idfParty.ToString(),
                    Text = t.strHerdName,//String.Format("{0}/{1}", t.strHerdName, t.strSpeciesName),
                    Selected = value.HasValue ? (t.idfParty == value.Value) : false
                });
        }

        public static IEnumerable<SelectListItem> HerdsOfRootFarm(string sessionId, long idfFarm, string name, long? value = null)
        {
            var tree = ModelStorage.Get(sessionId, idfFarm, name) as IEnumerable<VetFarmTree>;
            if (tree == null)
                return new List<SelectListItem>();

            return tree.Where(t => t.idfsPartyType == (long)PartyTypeEnum.Herd && !t.IsMarkedToDelete).Select(t =>
                new SelectListItem
                {
                    Value = t.idfParty.ToString(),
                    Text = t.strHerdName,//String.Format("{0}/{1}", t.strHerdName, t.strSpeciesName),
                    Selected = value.HasValue ? (t.idfParty == value.Value) : false
                });
        }
    }
}