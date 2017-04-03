﻿using System;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class ExternalComparativeSurrogateModel : BaseModel
    {
        public ExternalComparativeSurrogateModel
            (string language, long? regionId, long? rayonId, int year1, int year2, int? startMonth, int? endMonth, bool useArchive)
            : base(language, useArchive)
        {
            RegionId = regionId;
            RayonId = rayonId;
            Year1 = year1;
            Year2 = year2;
            StartMonth = startMonth;
            EndMonth = endMonth;
        }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public int Year1 { get; set; }

        public int Year2 { get; set; }

        public int? StartMonth { get; set; }

        public int? EndMonth { get; set; }
    }
}