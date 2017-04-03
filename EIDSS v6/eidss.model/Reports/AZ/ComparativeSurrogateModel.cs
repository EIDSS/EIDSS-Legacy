using System;
using System.Collections.Generic;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class ComparativeSurrogateModel : BaseModel
    {
        public ComparativeSurrogateModel
            (string language, int counter, int? startMonth, int? endMonth, int year1, int year2,
                long? region1Id, long? rayon1Id, long? region2Id, long? rayon2Id, long? organizationChe,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, useArchive)
        {
            Counter = counter;
            StartMonth = startMonth;
            EndMonth = endMonth;
            Year1 = year1;
            Year2 = year2;
            Region1Id = region1Id;
            Rayon1Id = rayon1Id;
            Region2Id = region2Id;
            Rayon2Id = rayon2Id;
            OrganizationCHE = organizationChe;
            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public int Counter { get; set; }

        public int? StartMonth { get; set; }

        public int? EndMonth { get; set; }

        public int Year1 { get; set; }

        public int Year2 { get; set; }

        public long? Region1Id { get; set; }

        public long? Rayon1Id { get; set; }

        public long? Region2Id { get; set; }

        public long? Rayon2Id { get; set; }

        public long? OrganizationCHE { get; set; }
    }
}