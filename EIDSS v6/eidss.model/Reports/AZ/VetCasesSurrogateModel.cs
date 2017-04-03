using System;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class VetCasesSurrogateModel : BaseModel
    {
        private const int MinYear = 2000;
        private int m_StartYear;
        private int m_EndYear;

        public VetCasesSurrogateModel
            (string language, long? regionId, long? rayonId, string regionName, string rayonName, long? organization,
             string organizationName, int startYear, int endYear,
             int? startMonth, int? endMonth, bool useArchive)
            : base(language, useArchive)
        {
            OrganizationEnteredById = organization;
            OrganizationEnteredByName = organizationName;
            StartMonth = startMonth;
            EndMonth = endMonth;
            StartYear = startYear;
            EndYear = endYear;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
        }

        public long? OrganizationEnteredById { get; set; }

        public string OrganizationEnteredByName { get; set; }

        public int? StartMonth { get; set; }

        public int? EndMonth { get; set; }

        public int StartYear
        {
            get { return m_StartYear; }
            set { m_StartYear = value < MinYear ? MinYear : value; }
        }

        public int EndYear

        {
            get { return m_EndYear; }
            set { m_EndYear = value < MinYear ? MinYear : value; }
        }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Start Year={1}, End Year = {2}, StartMonth={3}, EndMonth={4}, Region={5}, Rayon={6}",
                                 base.ToString(), StartYear, EndYear, StartMonth, EndMonth, RegionName, RayonName);
        }
    }
}