using System;
using System.Collections.Generic;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class AddressModel
    {
        private const long OtherRayonsId = 1344340000000;

        private static readonly long[] m_CityList =
        {
            1344470000000,
            1344650000000,
            1344830000000,
            1344890000000,
            1344920000000
        };

        private Address m_InternalAddress;

        public AddressModel()
        {
        }

        public AddressModel(long? regionId, long? rayonId, long? settlementId = null) : this()
        {
            RegionId = regionId;
            RayonId = rayonId;
            SettlementId = settlementId;
            IsSettlementVisible = false;
        }

        public bool IsSettlementVisible { get; set; }

        [LocalizedDisplayName("idfsRegion")]
        public long? RegionId { get; set; }

        [LocalizedDisplayName("idfsRayon")]
        public long? RayonId { get; set; }

        [LocalizedDisplayName("idfsSettlement")]
        public long? SettlementId { get; set; }

        internal Address InternalAddress
        {
            get
            {
                if (m_InternalAddress == null)
                {
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        m_InternalAddress = Address.Accessor.Instance(null).CreateNewT(manager, null);
                    }
                }
                return m_InternalAddress;
            }
        }

        public string RegionName
        {
            get
            {
                var selectedRegon = InternalAddress.RegionLookup.FirstOrDefault(r => r.idfsRegion == RegionId);
                return (selectedRegon == null)
                           ? string.Empty
                           : selectedRegon.strRegionName;
            }
        }

        public string RayonName
        {
            get
            {
                InternalAddress.Region = InternalAddress.RegionLookup.SingleOrDefault(c => c.idfsRegion == RegionId);
                var selectedRayon = InternalAddress.RayonLookup.SingleOrDefault(r => r.idfsRayon == RayonId);
                return (selectedRayon == null)
                           ? string.Empty
                           : selectedRayon.strRayonName;
            }
        }

        public string SettlementName
        {
            get
            {
                InternalAddress.Rayon = InternalAddress.RayonLookup.SingleOrDefault(c => c.idfsRayon == RayonId);
                InternalAddress.Settlement = InternalAddress.SettlementLookup.SingleOrDefault(c => c.idfsSettlement == SettlementId);
                var selectedSettlement = InternalAddress.SettlementLookup.SingleOrDefault(r => r.idfsSettlement == SettlementId);
                return (selectedSettlement == null)
                           ? String.Empty
                           : selectedSettlement.strSettlementName;
            }
        }

        #region Helper Methods

        public List<SelectListItemSurrogate> GetSelectedRegions()
        {
            return GetInternalRegions(true);
        }

        public List<SelectListItemSurrogate> GetUnselectedRegions()
        {
            return GetInternalRegions(false);
        }

        private List<SelectListItemSurrogate> GetInternalRegions(bool isSelected)
        {
            var defaultRegionId = FilterHelper.GetDefaultRegion();
            return InternalAddress.RegionLookup.Select(region => new SelectListItemSurrogate
                {
                    Text = region.strRegionName,
                    Value = (region.idfsRegion > 0)
                                ? region.idfsRegion.ToString()
                                : null,
                    Selected = isSelected && (region.idfsRegion == defaultRegionId)
                }).ToList();
        }

        public List<SelectListItemSurrogate> GetRayons()
        {
            InternalAddress.Region = InternalAddress.RegionLookup.SingleOrDefault(c => c.idfsRegion == RegionId);
            var defaultRayonId = FilterHelper.GetDefaultRayon();
            return InternalAddress.RayonLookup.Select(rayon => new SelectListItemSurrogate
                {
                    Text = rayon.strRayonName,
                    Value = (rayon.idfsRayon > 0)
                                ? rayon.idfsRayon.ToString()
                                : null,
                    Selected = (rayon.idfsRayon == defaultRayonId)
                }).ToList();
        }

        public List<SelectListItemSurrogate> GetSettlements()
        {
            InternalAddress.Region = InternalAddress.RegionLookup.SingleOrDefault(c => c.idfsRegion == RegionId);
            InternalAddress.Rayon = InternalAddress.RayonLookup.SingleOrDefault(c => c.idfsRayon == RayonId);
            return InternalAddress.SettlementLookup.Select(s => new SelectListItemSurrogate
            {
                Text = s.strSettlementName,
                Value = (s.idfsSettlement > 0)
                            ? s.idfsSettlement.ToString()
                            : null
                //,Selected = (s.idfsRayon == RayonId)
            }).ToList();
        }

        public static string GetLocation
           (string language, string countryName, long? regionId, string regionName, long? rayonId, string rayonName)
        {
            string location;
            if (regionId.HasValue)
            {
                if (rayonId.HasValue)
                {
                    location = regionId.Value == OtherRayonsId
                        ? rayonName
                        : string.Format("{0}, {1}", regionName, rayonName);
                    if (language == Localizer.lngRu && !m_CityList.Contains(rayonId.Value))
                    {
                        location += (" " + EidssMessages.Get("report_rayon_suffix").Trim());
                    }
                }
                else
                {
                    location = regionName;
                }
            }
            else
            {
                location = countryName;
            }
            return location;
        }

        public static string GetLocation
            (string language, long? regionId, string regionName, long? rayonId, string rayonName, string settlementName)
        {
            var location = GetLocation(language, string.Empty, regionId, regionName, rayonId, rayonName);
            if (string.IsNullOrEmpty(location))
            {
                return settlementName;
            }
            if (string.IsNullOrEmpty(settlementName))
            {
                return location;
            }
            return string.Format("{0}, {1}", location, settlementName);
        }

       

        #endregion

        public override string ToString()
        {
            return string.Format("Region={0}, Rayon={1}, Settlement={2}", RegionName, RayonName, SettlementName);
        }
    }
}