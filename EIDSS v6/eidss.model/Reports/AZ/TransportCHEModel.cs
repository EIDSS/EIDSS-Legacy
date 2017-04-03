﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Schema;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class TransportCHEModel
    {
        private TransportCHE m_InternalAddress;
        public TransportCHEModel()
        {
        }

        public TransportCHEModel(long? regionId, long? rayonId)
            : this()
        {
            RegionId = regionId;
            RayonId = rayonId;
        }


        [LocalizedDisplayName("idfsRegion")]
        public long? RegionId { get; set; }

        [LocalizedDisplayName("idfsRayon")]
        public long? RayonId { get; set; }


        internal TransportCHE InternalAddress
        {
            get
            {
                if (m_InternalAddress == null)
                {
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        m_InternalAddress = TransportCHE.Accessor.Instance(null).CreateNewT(manager, null);
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
                                ? region.idfsRegion.ToString(CultureInfo.InvariantCulture)
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
                                ? rayon.idfsRayon.ToString(CultureInfo.InvariantCulture)
                                : null,
                    Selected = (rayon.idfsRayon == defaultRayonId)
                }).ToList();
        }


       

        #endregion

        public override string ToString()
        {
            return string.Format("Region={0}, Rayon={1}", RegionName, RayonName);
        }
    }
}
