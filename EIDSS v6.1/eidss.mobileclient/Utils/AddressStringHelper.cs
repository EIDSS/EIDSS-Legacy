using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.Model.Core;
using eidss.model.Schema;
using bv.model.BLToolkit;
using BLToolkit.EditableObjects;

namespace eidss.mobileclient.Utils
{
    public class AddressStringHelper
    {
        public static IEnumerable<T> RearrangeAddressDisplayString<T>(IObject obj, IEnumerable<T> list)
        {
            if (!obj.IsHiddenPersonalData("Street"))
                return list;
            bool includeSettlement = !obj.IsHiddenPersonalData("Settlement");
            string cultureString = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();

            if (list.GetType() == typeof(List<SmallHumanCaseListItem>))
            {
                var hcli = (SmallHumanCaseListItem)obj;
                foreach (var o in list)
                {
                    SetAddressString(o as SmallHumanCaseListItem, hcli, cultureString, includeSettlement);
                }

            }

            if (list.GetType() == typeof(List<SmallVetCaseListItem>))
            {
                var vcli = (SmallVetCaseListItem)obj;
                foreach (var o in list)
                {
                    SetAddressString(o as SmallVetCaseListItem, vcli, cultureString, includeSettlement);
                }
            }

            if (list.GetType() == typeof(EditableList<ContactedCasePerson>))
            {
                Address address = null;
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    address = Address.Accessor.Instance(null).CreateNewT(manager, obj);
                    address.idfsCountry = ((HumanCase)obj).Patient.CurrentResidenceAddress.idfsCountry;
                }

                foreach (var o in list)
                {
                    SetAddressString(o as ContactedCasePerson, address, cultureString, includeSettlement);
                }
            }
            return list;
        }

        private static void SetAddressString(SmallVetCaseListItem t, SmallVetCaseListItem obj, string cultureString, bool includeSettlement)
        {
            long? id = includeSettlement ? (t.idfsSettlement ?? t.idfsRayon) : (t.idfsRayon ?? t.idfsRegion) ?? obj.idfsCountry;

            string cacheKey = String.Format("Vet_{0}_{1}_{2}", //VetCase has different format of string display
                cultureString,
                id,
                includeSettlement ? "Include" : "Exclude");

            string addressString = (string)HttpContext.Current.Cache[cacheKey];

            if (addressString == null)
            {
                if (obj.RegionLookup.Count() == 0)
                {
                    var ctry = obj.idfsCountry;
                    obj.idfsCountry = null;
                    obj.idfsCountry = ctry;
                }

                obj.idfsRegion = t.idfsRegion;
                obj.idfsRayon = t.idfsRayon;
                obj.idfsSettlement = t.idfsSettlement;

                addressString = "";

                if (t.idfsSettlement.HasValue && includeSettlement)
                {
                    addressString += obj.SettlementLookup.Find(r => r.idfsSettlement == t.idfsSettlement).strSettlementName + ", ";
                }

                if (t.idfsRayon.HasValue)
                {
                    if (!includeSettlement) addressString += "*, ";
                    addressString += obj.RayonLookup.Find(r => r.idfsRayon == t.idfsRayon).strRayonName;
                }

                if (t.idfsRegion.HasValue)
                {
                    addressString += ", " + obj.RegionLookup.Find(r => r.idfsRegion == t.idfsRegion).strRegionName;
                }


                HttpContext.Current.Cache[cacheKey] = addressString;
            }

            t.AddressName = addressString;
        }
        private static void SetAddressString(SmallHumanCaseListItem t, SmallHumanCaseListItem obj, string cultureString, bool includeSettlement)
        {
            long? id = includeSettlement ? (t.idfsSettlement ?? t.idfsRayon) : (t.idfsRayon ?? t.idfsRegion) ?? obj.idfsCountry;

            string cacheKey = String.Format("{0}_{1}_{2}_WithCountry",
                cultureString,
                id,
                includeSettlement ? "Include" : "Exclude");

            string addressString = (string)HttpContext.Current.Cache[cacheKey];

            if (addressString == null)
            {
                if (obj.RegionLookup.Count() == 0)
                {
                    var ctry = obj.idfsCountry;
                    obj.idfsCountry = null;
                    obj.idfsCountry = ctry;
                }

                obj.idfsRegion = t.idfsRegion;
                obj.idfsRayon = t.idfsRayon;
                obj.idfsSettlement = t.idfsSettlement;

                addressString = obj.Country.ToString();
                if (t.idfsRegion.HasValue)
                {
                    addressString += ", " + obj.RegionLookup.Find(r => r.idfsRegion == t.idfsRegion).strRegionName;
                }

                if (t.idfsRayon.HasValue)
                {
                    addressString += ", " + obj.RayonLookup.Find(r => r.idfsRayon == t.idfsRayon).strRayonName;
                }

                if (t.idfsSettlement.HasValue && includeSettlement)
                {
                    addressString += ", " + obj.SettlementLookup.Find(r => r.idfsSettlement == t.idfsSettlement).strSettlementName;
                }

                addressString += ", *";

                HttpContext.Current.Cache[cacheKey] = addressString;
            }

            t.GeoLocationName = addressString;
        }

        private static void SetAddressString(ContactedCasePerson t, Address obj, string cultureString, bool includeSettlement)
        {
            long? id = includeSettlement
                ? ((t.idfsSettlement ?? t.idfsRayon) ?? t.idfsRegion) ?? obj.idfsCountry
                : (t.idfsRayon ?? t.idfsRegion) ?? obj.idfsCountry;

            string cacheKey = String.Format("{0}_{1}_{2}_WithCountry",
                cultureString,
                id,
                includeSettlement ? "Include" : "Exclude");

            string addressString = (string)HttpContext.Current.Cache[cacheKey];

            if (addressString == null)
            {
                if (obj.RegionLookup.Count() == 0)
                {
                    var ctry = obj.idfsCountry;
                    obj.idfsCountry = null;
                    obj.idfsCountry = ctry;
                }

                obj.idfsRegion = t.idfsRegion;
                obj.idfsRayon = t.idfsRayon;
                obj.idfsSettlement = t.idfsSettlement;

                addressString = obj.Country.ToString();
                if (t.idfsRegion.HasValue)
                {
                    addressString += ", " + obj.RegionLookup.Find(r => r.idfsRegion == t.idfsRegion).strRegionName;
                }

                if (t.idfsRayon.HasValue)
                {
                    addressString += ", " + obj.RayonLookup.Find(r => r.idfsRayon == t.idfsRayon).strRayonName;
                }

                if (t.idfsSettlement.HasValue && includeSettlement)
                {
                    addressString += ", " + obj.SettlementLookup.Find(r => r.idfsSettlement == t.idfsSettlement).strSettlementName;
                }

                addressString += ", *";

                HttpContext.Current.Cache[cacheKey] = addressString;
            }

            t.GeoLocationNameWithHiddenPersonalData = addressString;
        }
    }
}