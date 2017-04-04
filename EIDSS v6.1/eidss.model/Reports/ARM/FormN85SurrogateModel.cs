using System;
using System.Collections.Generic;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.ARM
{
    [Serializable]
    public class FormN85SurrogateModel : BaseDateModel
    {
        public FormN85SurrogateModel()
        {
        }

        public FormN85SurrogateModel
            (string language,
                int year, int? month,
                long? regionId, long? rayonId, string regionName, string rayonName,
                string userName,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups,
                bool useArchive)
            : base(language, year, month, useArchive)
        {
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;

            UserName = userName;

            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public long? RegionId { get; set; }
        public long? RayonId { get; set; }
        public string RegionName { get; set; }
        public string RayonName { get; set; }

        public string UserName { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, RegionId = {1}, RayonId={2}", base.ToString(), RegionId, RayonId);
        }
    }
}