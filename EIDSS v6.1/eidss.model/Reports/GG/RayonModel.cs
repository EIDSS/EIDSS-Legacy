using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class RayonModel
    {
        public RayonModel()
        {
            RegionRayonComplexId = String.Empty;
            IsCurrentRayonSelected = false;
        }


        [LocalizedDisplayName("idfsRayon")]
        public string RegionRayonComplexId { get; set; }

        public long? RegionId
        {
            get { return FilterHelper.GetRegionIdFromComplexId(RegionRayonComplexId); }
        }

        public long? RayonId
        {
            get { return FilterHelper.GetRayonIdFromComplexId(RegionRayonComplexId); }
        }

        public bool IsCurrentRayonSelected { get; set; }

        public List<SelectListItemSurrogate> RayonList
        {
            get { return FilterHelper.GetAllRayons(Localizer.CurrentCultureLanguageID, (IsCurrentRayonSelected && RayonId.HasValue) ? RayonId.Value : 0); }
        }
    }
}