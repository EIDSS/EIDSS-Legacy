using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eidss.webclient.Utils;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using bv.model.Model.Core;
using bv.model.BLToolkit;
using System.Web.Mvc;
using eidss.model.Resources;
using eidss.model.Enums;

namespace eidss.webclient.Areas.HerdEpi.Utils
{
    public class RootFarmTreeProcessor
    {
        private const string KEY_FOR_TEMP_ITEM_STORAGE = "Species_Item";
        private static string m_error;
        private static bool CreateHerdOrFlock(string sessionId, long key, string name, bool blnLvstck, out string error)
        {
            var list = ModelStorage.Get(sessionId, key, name) as EditableList<RootFarmTree>;
            var rootobj = ModelStorage.GetRoot(sessionId, key, null) as IObject;
            if (list == null)
            {
                error = EidssMessages.Get("Error_RootFarmTreeNotFound");
                return false;
            }
            error = string.Empty;
            try
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var item = RootFarmTree.Accessor.Instance(null).CreateHerd(manager, rootobj, list.Where(v => v.idfParentParty == null).FirstOrDefault());
                    item._HACode = blnLvstck ? (int)eidss.model.Enums.HACode.Livestock : (int)eidss.model.Enums.HACode.Avian;
                    item.strHerdName = item.strName = String.Format("(new {0})", 1 + list.Count(x => x.idfsPartyType == (long)PartyTypeEnum.Herd && !x.IsMarkedToDelete));
                    list.Add(item);
                    list.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
                    return true;
                }
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }



        public static bool CreateHerd(string sessionId, long key, string name, out string error)
        {
            return CreateHerdOrFlock(sessionId, key, name, true, out error);
        }

        public static bool CreateFlock(string sessionId, long key, string name, out string error)
        {
            return CreateHerdOrFlock(sessionId, key, name, false, out error);
        }


        public static bool UpdateSpecies(string sessionId, long key, string name, bool isNew, FormCollection form, out string error)
        {
            error = string.Empty;
            var spec = ModelStorage.Get(sessionId, key, KEY_FOR_TEMP_ITEM_STORAGE) as VetFarmTree;
            var list = ModelStorage.Get(sessionId, key, name) as EditableList<VetFarmTree>;
            if (spec == null || list == null)
            {
                error = EidssMessages.Get("Error_VetFarmTreeNotFound");
                return false;
            }
            spec.Validation += object_ValidationDetails;
            spec.ParseFormCollection(form);
            spec.Validate();
            spec.Validation -= object_ValidationDetails;

            if (!String.IsNullOrWhiteSpace(m_error))
            {
                error = m_error;
                return false;
            }

            if (isNew)
                list.Add(spec);

            var herd = list.Where(x => x.idfParty == spec.idfParentParty).FirstOrDefault();
            spec.strHerdName = herd.strName;
            list.Sort(System.ComponentModel.ListSortDirection.Ascending, new string[] { "strHerdName", "strSpeciesName" });
            return true;
        }

        public static VetFarmTree GetSpecies(string sessionId, long key, string name, long? idfSpecies)
        {
            var list = ModelStorage.Get(sessionId, key, name) as EditableList<VetFarmTree>;

            if (list == null)
                return null;

            var rootobj = ModelStorage.GetRoot(sessionId, key, null) as IObject;
            VetFarmTree item;
          //  list.Where(s=>!s._HACode.HasValue).ToList().ForEach(v => v._HACode = v._HACode ?? (rootobj as FarmPanel)._HACode);

            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                if (idfSpecies == null || idfSpecies.Value == 0)
                    item = VetFarmTree.Accessor.Instance(null).CreateSpecies(manager, rootobj, list.Where(v => v.idfParentParty != null).FirstOrDefault());
                else
                    item = list.Where(t => t.idfParty == idfSpecies).First();
                ModelStorage.Put(sessionId, key, key, KEY_FOR_TEMP_ITEM_STORAGE, item);
                return item;
            }
        }

        static void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            m_error = EidssMessages.GetValidationErrorMessage(args);
        }
    }
}
