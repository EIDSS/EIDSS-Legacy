using System;
using System.Collections.Generic;
using System.Text;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class BorderRayonsSurrogateModel : BaseDateModel
    {
        public BorderRayonsSurrogateModel()
        {
            DiagnosisCheckedItems = new string[0];
            Counters = new string[0];
        }

        public BorderRayonsSurrogateModel
            (string language, int year, int? startMonth, int? endMonth,
                long? regionId, long? rayonId, string regionName, string rayonName,
                string[] checkedDiagnosis, string[] counters,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, year, startMonth, endMonth, useArchive)
        {
            Year = year;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
            DiagnosisCheckedItems = checkedDiagnosis ?? new string[0];
            Counters = counters ?? new string[0];
            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public long? RegionId { get; set; }
        public long? RayonId { get; set; }

        public string RegionName { get; set; }
        public string RayonName { get; set; }

        public string[] DiagnosisCheckedItems { get; set; }
        public string[] Counters { get; set; }

        public override string ToString()
        {
            var diagnosis = new StringBuilder();
            if (DiagnosisCheckedItems != null)
            {
                foreach (string item in DiagnosisCheckedItems)
                {
                    diagnosis.AppendFormat("{0},", item);
                }
            }

            var counter = new StringBuilder();
            if (Counters != null)
            {
                foreach (string item in Counters)
                {
                    counter.AppendFormat("{0},", item);
                }
            }
            string result = string.Format("{0}, Counters='{1}', Region='{2}', Rayon='{3}', Diagnosis={4}",
                base.ToString(), counter, RegionName, RayonName, diagnosis);
            return result;
        }
    }
}