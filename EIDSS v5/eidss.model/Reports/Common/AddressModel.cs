using System;
using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Schema;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class AddressModel
    {
        private Address m_InternalAddress;

        public AddressModel()
        {
        }

        public AddressModel(long? regionId, long? rayonId) : this()
        {
            RegionId = regionId;
            RayonId = rayonId;
        }

        [LocalizedDisplayName("idfsRegion")]
        public long? RegionId { get; set; }

        [LocalizedDisplayName("idfsRayon")]
        public long? RayonId { get; set; }

        internal Address InternalAddress
        {
            get
            {
                if (m_InternalAddress == null)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
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
                RegionLookup selectedRegon = InternalAddress.RegionLookup.FirstOrDefault(r => r.idfsRegion == RegionId);
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
                RayonLookup selectedRayon = InternalAddress.RayonLookup.SingleOrDefault(r => r.idfsRayon == RayonId);
                return (selectedRayon == null)
                           ? string.Empty
                           : selectedRayon.strRayonName;
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
            long? defaultRegionId = FilterHelper.GetDefaultRegion();
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
            long? defaultRayonId = FilterHelper.GetDefaultRayon();
            return InternalAddress.RayonLookup.Select(rayon => new SelectListItemSurrogate
                {
                    Text = rayon.strRayonName,
                    Value = (rayon.idfsRayon > 0)
                                ? rayon.idfsRayon.ToString()
                                : null,
                    Selected = (rayon.idfsRayon == defaultRayonId)
                }).ToList();
        }

        #endregion
    }
}