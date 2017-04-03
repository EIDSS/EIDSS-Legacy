using System;
using System.Collections.Generic;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class IntermediateInfectiousDiseaseSurrogateModel : BaseIntervalModel
    {
        public IntermediateInfectiousDiseaseSurrogateModel()
        {
        }

        public IntermediateInfectiousDiseaseSurrogateModel
            (string lang, DateTime startDate, DateTime endDate,
                long? regionId, long? rayonId, string regionName, string rayonName,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups,
                bool useArchive)
            : base(lang, startDate, endDate, useArchive)
        {
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
            OrganizationId = organizationId;
          ForbiddenGroups = forbiddenGroups;
        }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }
    }
}