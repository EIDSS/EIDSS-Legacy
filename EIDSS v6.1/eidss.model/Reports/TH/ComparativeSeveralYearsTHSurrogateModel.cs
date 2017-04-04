using System;
using System.Collections.Generic;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.TH
{
    [Serializable]
    public class ComparativeSeveralYearsTHSurrogateModel : BaseModel
    {
        public ComparativeSeveralYearsTHSurrogateModel()
        {
            Diagnoses = new MultipleDiagnosisModel();
            YearFrom = DateTime.Now.Year - 1;
            YearTo = DateTime.Now.Year;
        }

        public ComparativeSeveralYearsTHSurrogateModel
            (string language, int yearFrom, int yearTo,
                string[] diagnosesId,int counter,
                long? regionId, long? rayonId, string regionName, string rayonName,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, useArchive)
        {
            Diagnoses = new MultipleDiagnosisModel(diagnosesId, (int) HACode.Human);

            YearFrom = yearFrom;
            YearTo = yearTo;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
            Counter = counter;

            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public int YearFrom { get; set; }

        public int YearTo { get; set; }

        public MultipleDiagnosisModel Diagnoses { get; set; }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }

        public int Counter { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, From={1}, To = {2}, Diagnoses={3}, Region= {4}, Rayon={5}, Counter={6}",
                base.ToString(), YearFrom, YearTo, Diagnoses, RegionName, RayonName,Counter);
        }
    }
}