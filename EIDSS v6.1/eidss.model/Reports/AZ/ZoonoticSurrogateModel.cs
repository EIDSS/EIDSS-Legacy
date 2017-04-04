using System;
using System.Collections.Generic;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class ZoonoticSurrogateModel : BaseYearModel
    {
        public ZoonoticSurrogateModel()
        {
        }

        public ZoonoticSurrogateModel
            (string language, int year,
                long? regionId, long? rayonId, string regionName, string rayonName,
                long? diagnosisId, string diagnosisName,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, year, useArchive)
        {
            Year = year;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
            DiagnosisId = diagnosisId;
            DiagnosisName = diagnosisName;
            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public long? RegionId { get; set; }
        public long? RayonId { get; set; }

        public string RegionName { get; set; }
        public string RayonName { get; set; }

        public long? DiagnosisId { get; set; }
        public string DiagnosisName { get; set; }

        public override string ToString()
        {
            string result = string.Format("{0},  Region='{1}', Rayon='{2}', Diagnosis={3}",
                base.ToString(), RegionName, RayonName, DiagnosisName);
            return result;
        }
    }
}