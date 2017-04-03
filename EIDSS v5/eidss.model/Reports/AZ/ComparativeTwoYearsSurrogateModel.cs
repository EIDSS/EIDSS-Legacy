using System;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class ComparativeTwoYearsSurrogateModel : BaseModel
    {
        public ComparativeTwoYearsSurrogateModel
            (string language, int year1, int year2,
             int counter, long? diagnosisId, string diagnosisName,
             long? regionId, long? rayonId, string regionName, string rayonName,
             long? organizationChe, string organizationCheName,
             bool useArchive)
            : base(language, useArchive)
        {
            Counter = counter;
            DiagnosisId = diagnosisId;
            DiagnosisName = diagnosisName;

            Year1 = year1;
            Year2 = year2;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
            OrganizationCHE = organizationChe;
            OrganizationCHEName = organizationCheName;
        }

        public int Counter { get; set; }

        public int Year1 { get; set; }

        public int Year2 { get; set; }

        public long? DiagnosisId { get; set; }

        public string DiagnosisName { get; set; }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }

        public long? OrganizationCHE { get; set; }

        public string OrganizationCHEName { get; set; }
    }
}