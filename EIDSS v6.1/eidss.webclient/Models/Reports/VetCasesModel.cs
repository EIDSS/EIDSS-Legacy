using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class VetCasesModel : BaseModel
    {
        public VetCasesModel()
        {
            Address = new TransportCHEModel(false);
        }

        [LocalizedDisplayName("OrganizationLabel")]
        public long? OrganizationEnteredById { get; set; }

        public string OrganizationEnteredByName
        {
            get
            {
                return !OrganizationEnteredById.HasValue
                    ? string.Empty
                    : FilterHelper.GetVetOrganizationName(OrganizationEnteredById.Value, Localizer.CurrentCultureLanguageID);
            }
        }

        [LocalizedDisplayName("FromMonthLabel")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonthLabel")]
        public int? EndMonth { get; set; }

        [LocalizedDisplayName("FromYearLabel")]
        public int StartYear { get; set; }

        [LocalizedDisplayName("ToYearLabel")]
        public int EndYear { get; set; }

        public TransportCHEModel Address { get; set; }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month - 1, false); }
        }

        public List<SelectListItemSurrogate> OrganizationList
        {
            get { return FilterHelper.GetVetOrganizationList(VetReportType.Case, Localizer.CurrentCultureLanguageID); }
        }

        public static explicit operator VetCasesSurrogateModel(VetCasesModel model)
        {
            TransportCHEModel address = model.Address ?? new TransportCHEModel(false);
            var result = new VetCasesSurrogateModel(model.Language,
                address.RegionId, address.RayonId,
                address.RegionName, address.RayonName,
                model.OrganizationEnteredById, model.OrganizationEnteredByName,
                model.StartYear, model.EndYear,
                model.StartMonth, model.EndMonth,
                model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}