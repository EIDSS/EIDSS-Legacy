using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.EditableObjects;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using bv.model.Model.Core;
using bv.model.BLToolkit;
using System.Web.Mvc;
using eidss.model.Resources;
using System.Collections.Specialized;

namespace eidss.mobileclient.Utils
{
    public class VetFarmTreeProcessor
    {
        private static string m_error;

        private static VetFarmTree CreateHerdOrFlock(string sessionId, long key, string name, HACode haCode)
        {
            var list = ModelStorage.Get(sessionId, key, name) as EditableList<VetFarmTree>;
            var rootobj = ModelStorage.GetRoot(sessionId, key, null) as IObject;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var item = VetFarmTree.Accessor.Instance(null).CreateHerd(manager, rootobj, list.Where(v => v.idfParentParty == null).FirstOrDefault());
                item._HACode = (int)haCode;
                return item;
            }
        }

        public static bool UpdateSpecies(string sessionId, long key, string name, bool isNew, FormCollection form, HACode haCode, out string error)
        {
            error = string.Empty; 
            m_error = string.Empty;
            long idfSpecies = Int64.Parse(form["idfParty"]);
            var farm = (ModelStorage.Get(sessionId, key, "") as VetCase).Farm;
            var spec = ModelStorage.Get(sessionId, idfSpecies, null) as VetFarmTree;
            var list = ModelStorage.Get(sessionId, key, name) as EditableList<VetFarmTree>;
            if (spec == null || list == null)
            {
                error = "VetFarmTree was not found.";
                return false;
            }

            string idfParentPartyKey = form.AllKeys.Where(x => x.EndsWith("_idfParentParty")).FirstOrDefault();
            VetFarmTree herd;

            Int64 idfParentParty = Convert.ToInt64(form[idfParentPartyKey]);
            if (idfParentParty == 0 && !isNew)
            {
                herd = CreateHerdOrFlock(sessionId, key, name, haCode);
            }
            else if(idfParentParty == 0 && isNew)
            {
                herd = ModelStorage.Get(sessionId, spec.idfParentParty.Value, null) as VetFarmTree;
            }
            else
            {
                herd = list.Where(x => x.idfParty == idfParentParty).FirstOrDefault();
            }
            var coll = form as NameValueCollection;
            coll.Remove(idfParentPartyKey);
            spec.idfParentParty = herd.idfParty;
            if (!list.Contains(herd))
            {
                list.Add(herd);
            }

            spec.Validation += object_ValidationDetails;                        
            spec.ParseFormCollection(coll);
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                VetFarmTree.Accessor.Instance(null).Validate(manager, spec, true, true, true);
            }
            spec.Validation -= object_ValidationDetails;

            if (!String.IsNullOrWhiteSpace(m_error))
            {
                if (list.Contains(herd))
                {
                    list.Remove(herd);
                }
                error = m_error;
                return false;
            }

            farm.Validation += object_ValidationDetails;
            if (isNew)
            {
                list.Add(spec);
            }
            farm.Validation -= object_ValidationDetails;

            if (!String.IsNullOrWhiteSpace(m_error))
            {
                error = m_error;
                return false;
            }
            
            spec.strHerdName = herd.strName;
            var allspecies = list.Where(x => x.idfParentParty == herd.idfParty && !x.IsMarkedToDelete);
            herd.intDeadAnimalQty = allspecies.Sum(x => x.intDeadAnimalQty);
            herd.intSickAnimalQty = allspecies.Sum(x => x.intSickAnimalQty);
            herd.intTotalAnimalQty = allspecies.Sum(x => x.intTotalAnimalQty);
            
            return true;
        }

        public static VetFarmTree GetSpecies(string sessionId, long key, string name, long? idfSpecies, HACode haCode)
        {
            var list = ModelStorage.Get(sessionId, key, name) as EditableList<VetFarmTree>;

            if (list == null)
            {
                return null;
            }

            var rootobj = ModelStorage.GetRoot(sessionId, key, null) as IObject;
            VetFarmTree item;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                VetFarmTree parent;
                if (idfSpecies == null || idfSpecies.Value == 0)
                {

                    parent = CreateHerdOrFlock(sessionId, key, name, haCode);
                    item = VetFarmTree.Accessor.Instance(null).CreateSpecies(manager, rootobj, parent);
                    item._HACode = (int)haCode;
                }
                else
                {
                    item = list.Where(t => t.idfParty == idfSpecies).First();
                    parent = list.Where(x => x.idfParty == item.idfParentParty).FirstOrDefault();
                }
                ModelStorage.Put(sessionId, key, item.idfParty, null, item);
                ModelStorage.Put(sessionId, key, parent.idfParty, null, parent);

                return item;
            }
        }

        public static IEnumerable<SelectListItem> GetHerdsOfCase(string sessionId, long idfCase, long selectedHerd)
        {
            var tree = ModelStorage.Get(sessionId, idfCase, "FarmTree") as IEnumerable<VetFarmTree>;
            var herds = new List<SelectListItem>();
            herds.Add(new SelectListItem { Text = Translator.GetMessageString("strNew"), Value = "0" });
            if (tree != null)
            {
                herds.AddRange(tree.Where(t => t.idfsPartyType == (long)PartyTypeEnum.Herd && !t.IsMarkedToDelete).Select(t =>
                    new SelectListItem
                    {
                        Value = t.idfParty.ToString(),
                        Text = t.strHerdName//String.Format("{0}/{1}", t.strHerdName, t.strSpeciesName),
                    }).ToList());
            }

            SelectListItem item = herds.Where(x => x.Value == selectedHerd.ToString()).SingleOrDefault();
            item.Selected = true;

            return herds;
        }
        
        static void object_ValidationDetails(object sender, ValidationEventArgs args)
        {
            m_error = Translator.GetErrorMessage(args);
        }

    }
}