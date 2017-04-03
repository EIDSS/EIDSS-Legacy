using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using BLToolkit.EditableObjects;
using bv.model.Model.Core;

namespace eidss.model.Schema
{
    public partial class FarmRootPanel
    {

        private static string[] COPY_EXTENSIONS = { 
                "idfFarm", 
                "idfFarmAddress", 
                "idfFarmLocation",
                "idfRootFarm",
                "ObjectIdent", 
                "ObjectName", 
                "Key"
                };

        public FarmPanel GetFarmFromRoot()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(eidss.model.Core.EidssUserContext.Instance))
            {
                return CopyRootValues(manager, this);
            }
        }
        public static FarmPanel GetFarmFromRoot(long? idfRootFarm = null)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(eidss.model.Core.EidssUserContext.Instance))
            {                             
                var parent = (FarmRootPanel)FarmRootPanel.Accessor.Instance(null).SelectDetail(manager, idfRootFarm.Value);
                return CopyRootValues(manager, parent);
            }
        }


        public static void CopyFromNonRoot(FarmRootPanel target, FarmPanel source)
        {            
            
            // fill all value-fields except idftarget
            foreach (var prop in target.GetType().GetProperties().Select(x => x.Name))
            {
                if (COPY_EXTENSIONS.Contains(prop))
                    continue;

                object val = source.GetValue(prop);
                target.SetValue(prop, val == null ? "" : val.ToString());
            }

            source.Location.CopyFieldsTo(target.Location);
            source.Address.CopyFieldsTo(target.Address);

            source._blnAllowFarmReload = false;
            source.idfRootFarm = target.idfFarm;

        }
        private static FarmPanel CopyRootValues(DbManagerProxy manager, FarmRootPanel parent, bool copyAvianTree = true, bool copyLivestockTree = true, long? idfCase = null)
        {
            int? hacode = parent._HACode.HasValue ? parent._HACode.Value : (copyLivestockTree ? (int)eidss.model.Enums.HACode.Livestock : (int)eidss.model.Enums.HACode.Avian);
            var farm = FarmPanel.Accessor.Instance(null).CreateByHACode(manager, parent, hacode);
            farm._blnAllowFarmReload = false;
            farm.idfRootFarm = parent.idfFarm;
            
            // fill all value-fields except idfFarm
            foreach (var prop in farm.GetType().GetProperties().Select(x => x.Name))
            {
                if (COPY_EXTENSIONS.Contains(prop))
                    continue;

                object val = parent.GetValue(prop);
                farm.SetValue(prop, val == null ? "" : val.ToString());
            }

            parent.Location.CopyFieldsTo(farm.Location);
            parent.Address.CopyFieldsTo(farm.Address);
            farm.idfCase = idfCase;
            //copy vetfarmtree
            var vetTreeBase = farm.FarmTree[0];
            farm.FarmTree.Clear();

            if (parent.FarmAvianTree.Count > 1 && copyAvianTree)
                farm.FarmTree.AddRange(RootTreeToFarm(manager, parent, parent.FarmAvianTree, idfCase));
            if (parent.FarmLivestockTree.Count > 1 && copyLivestockTree)
                farm.FarmTree.AddRange(RootTreeToFarm(manager, parent, parent.FarmLivestockTree, idfCase));

            if (farm.FarmTree.Count == 0)
                farm.FarmTree.Add(vetTreeBase);
            return farm;
        }


        public static FarmPanel CopyToLivestockFarm(long? idfRootFarm = null, long? idfCase = null)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(eidss.model.Core.EidssUserContext.Instance))
            {                             
                var parent = (FarmRootPanel)FarmRootPanel.Accessor.Instance(null).SelectDetail(manager, idfRootFarm.Value);
                return CopyRootValues(manager, parent, false, true, idfCase);
            }
        }

        private static EditableList<VetFarmTree> RootTreeToFarm(DbManagerProxy manager, IObject Parent, EditableList<RootFarmTree> roots, long? idfCase = null)
        {
            var farmTree = new EditableList<VetFarmTree>();
            var treeAccessor = VetFarmTree.Accessor.Instance(null);
            foreach (var farmroot in roots.Where(x => x.idfParentParty == null))
            {
                VetFarmTree farmItem = treeAccessor.CreateNewT(manager, Parent, farmroot._HACode);                
                farmTree.Add(farmItem);
                foreach (var herdroot in roots.Where(x => x.idfParentParty == farmroot.idfParty))
                {
                    VetFarmTree herdItem = treeAccessor.CreateHerd(manager, Parent, farmItem);
                    herdItem.strName = herdroot.strName;
                    farmTree.Add(herdItem);
                    foreach (var speciesroot in roots.Where(x => x.idfParentParty == herdroot.idfParty))
                    {
                        VetFarmTree species = treeAccessor.CreateSpecies(manager, Parent, herdItem);
                        species.idfsSpeciesTypeReference = speciesroot.idfsSpeciesTypeReference;
                        species.SpeciesType = speciesroot.SpeciesType;
                        species.strHerdName = herdItem.strName;
                        farmTree.Add(species);
                    }
                }
            }
            if (idfCase.HasValue) farmTree.ForEach(x => x.idfCase = idfCase.Value);
            return farmTree;
        }
    }
}
