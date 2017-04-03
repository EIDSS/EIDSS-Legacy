using System;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class VetLabSurrogateModel : AFPModel
    {
        public VetLabSurrogateModel
            (string language, int year, int period, int periodType,
             long? organizationEnteredById, string organizationEnteredByName,
             long? regionId, long? rayonId, 
             string regionName, string rayonName,
             bool useArchive)
            : base(language, year, period, periodType, useArchive)
        {
            OrganizationEnteredById = organizationEnteredById;
            OrganizationEnteredByName = organizationEnteredByName;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
        }

        public long? OrganizationEnteredById { get; set; }

        public string OrganizationEnteredByName { get; set; }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }

        public override string ToString()
        {
            return string.Format("{0},  Region={1}, Rayon={2}, Organization={3}",
                                 base.ToString(), RegionName, RayonName, OrganizationEnteredByName);
        }
    }
}