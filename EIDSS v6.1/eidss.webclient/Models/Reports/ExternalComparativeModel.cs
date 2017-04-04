using System;
using System.Collections.Generic;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class ExternalComparativeModel : BaseModel
    {
        public ExternalComparativeModel()
        {
            StartMonth = 1;
            EndMonth = DateTime.Now.Month;
            Address = new TransportCHEModel(FilterHelper.GetDefaultRegion(true), FilterHelper.GetDefaultRayon(true));
            YearModel = new FromYearToYearModel()
            {
                IsYear1GreaterYear2 = true,
                ValidationMessage = "msgExternalComparativeReportCorrectYear"
            };
            YearModel.SetYearsIntervalFrom(2001);
            YearModel.SetYearsIntervalTo(2000, DateTime.Today.Year - 1);
        }

        public ExternalComparativeModel(TransportCHEModel address)
            : this()
        {
            Address = address;
        }

        public TransportCHEModel Address { get; set; }

        public FromYearToYearModel YearModel { get; set; }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month - 1, false); }
        }

        public List<SelectListItemSurrogate> SelectedJanuaryMonthList
        {
            get { return FilterHelper.GetWebMonthList(0, false); }
        }

        public static explicit operator ExternalComparativeSurrogateModel(ExternalComparativeModel model)
        {
            var result = new ExternalComparativeSurrogateModel(model.Language,
                model.Address.RegionId, model.Address.RegionId.HasValue ? model.Address.RayonId : null,
                model.Address.RegionName, model.Address.RegionId.HasValue ? model.Address.RayonName : null,
                model.YearModel.Year1, model.YearModel.Year2,
                model.EndMonth,
                model.OrganizationId, model.ForbiddenGroups,
                model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}