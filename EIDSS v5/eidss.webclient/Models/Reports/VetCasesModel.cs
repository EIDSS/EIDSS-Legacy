using System;
using System.Collections.Generic;
using System.Threading;
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
            Address = new AddressModel();
        }

        [LocalizedDisplayName("OrganizationLabel")]
        public long? OrganizationEnteredById { get; set; }

        public string OrganizationEnteredByName
        {
            get
            {
                return !OrganizationEnteredById.HasValue
                           ? string.Empty
                           : FilterHelper.GetVetOrganizationName(OrganizationEnteredById.Value,
                                                                 Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
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

        public AddressModel Address { get; set; }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetMonthList(DateTime.Now.Month - 1, false); }
        }

        public List<SelectListItemSurrogate> OrganizationList
        {
            get { return FilterHelper.GetVetOrganizationList(VetReportType.Case, Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName); }
        }

        public static explicit operator VetCasesSurrogateModel(VetCasesModel model)
        {
            var address = model.Address??new AddressModel();
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