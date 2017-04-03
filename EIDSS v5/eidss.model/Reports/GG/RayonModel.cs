using System;
using System.Collections.Generic;
using System.Threading;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class RayonModel
    {
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

        public List<SelectListItemSurrogate> RayonList
        {
            get { return FilterHelper.GetAllRayons(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName); }
        }
    }
}