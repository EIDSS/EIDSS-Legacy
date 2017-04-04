using System;
using System.Collections.Generic;
using System.Text;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class ComparativeTwoYearsSurrogateModel : BaseModel
    {
        public ComparativeTwoYearsSurrogateModel()
        {
            Counters = new string[0];
        }

        public ComparativeTwoYearsSurrogateModel
            (string language, int year1, int year2,
                string[] counters, long? diagnosisId, string diagnosisName,
                long? regionId, long? rayonId, string regionName, string rayonName,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, useArchive)
        {
            Counters = counters ?? new string[0];
            DiagnosisId = diagnosisId;
            DiagnosisName = diagnosisName;

            Year1 = year1;
            Year2 = year2;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;

            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public string[] Counters { get; set; }

        public int Year1 { get; set; }

        public int Year2 { get; set; }

        public long? DiagnosisId { get; set; }

        public string DiagnosisName { get; set; }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }

        public override string ToString()
        {
            var counter = new StringBuilder();
            if (Counters != null)
            {
                foreach (string item in Counters)
                {
                    counter.AppendFormat("{0},", item);
                }
            }
            string result = string.Format("{0}, Counters='{1}', Region='{2}', Rayon='{3}', Diagnosis={4}, Year1={5}, Year2={6}",
                base.ToString(), counter, RegionName, RayonName, DiagnosisName, Year1, Year2);
            return result;
        }
    }
}