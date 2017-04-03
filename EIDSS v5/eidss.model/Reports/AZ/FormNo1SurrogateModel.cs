using System;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class FormNo1SurrogateModel : BaseYearModel
    {
        public FormNo1SurrogateModel()
        {
        }

        public FormNo1SurrogateModel
            (string language, int year, int? startMonth, int? endMonth, bool isA3Format,
            long? regionId, long? rayonId, string regionName, string rayonName,
            long? organization,string organizationName, bool useArchive)
            : base(language, year, useArchive)
        {
            StartMonth = startMonth;
            EndMonth = endMonth;
            IsA3Format = isA3Format;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
            OrganizationCHE = organization;
            OrganizationCHEName = organizationName;
        }

        public int? StartMonth { get; set; }

        public int? EndMonth { get; set; }

        public bool IsA3Format { get; set; }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }

        public long? OrganizationCHE { get; set; }

        public string OrganizationCHEName { get; set; }

        public static explicit operator BaseDateModel(FormNo1SurrogateModel model)
        {
            var result = new BaseDateModel(model.Language, model.Year, model.StartMonth, model.EndMonth, model.UseArchive)
                {
                    ExportFormat = model.ExportFormat,
                    IsOpenInNewWindow = model.IsOpenInNewWindow
                };

            return result;
        }
    }
}