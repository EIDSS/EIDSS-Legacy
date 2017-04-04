using System;
using System.Collections.Generic;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.KZ
{
    [Serializable]
    public class InfectiousParasiticKZSurrogateModel : BaseYearModel
    {
        public InfectiousParasiticKZSurrogateModel()
        {
        }

        public InfectiousParasiticKZSurrogateModel
            (string language, int year, int? startMonth, int? endMonth,
            long? regionId, long? rayonId, string regionName, string rayonName,
            long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, year, useArchive)
        {
            StartMonth = startMonth;
            EndMonth = endMonth;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;

            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public int? StartMonth { get; set; }

        public int? EndMonth { get; set; }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }


        public static explicit operator BaseDateModel(InfectiousParasiticKZSurrogateModel model)
        {
            var result = new BaseDateModel(model.Language, model.Year, model.StartMonth, model.EndMonth, model.UseArchive)
                {
                    ExportFormat = model.ExportFormat,
                    IsOpenInNewWindow = model.IsOpenInNewWindow,
                    OrganizationId = model.OrganizationId,
                    ForbiddenGroups = model.ForbiddenGroups,
                    UserId = model.UserId,
                    IsArchiveMode = model.IsArchiveMode,
                };

            return result;
        }
    }
}