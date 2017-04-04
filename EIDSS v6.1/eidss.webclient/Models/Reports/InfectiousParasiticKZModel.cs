using System;
using System.Collections.Generic;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using eidss.model.Resources;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class InfectiousParasiticKZModel : BaseYearModel
    {
        public InfectiousParasiticKZModel()
        {
            Address = new AddressModel();
        }

        public InfectiousParasiticKZModel(long? regionId, long? rayonId)
        {
            Address = new AddressModel(regionId, rayonId);
        }

        public InfectiousParasiticKZModel
            (string language, int year, int? startMonth, int? endMonth, long? regionId, long? rayonId, bool useArchive)
            : base(language, year, useArchive)
        {
            StartMonth = startMonth;
            EndMonth = endMonth;
            Address = new AddressModel(regionId, rayonId);
        }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        public AddressModel Address { get; set; }

        public List<SelectListItemSurrogate> UnselectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(-1, false); }
        }

        public string CountryLabel
        {
            get { return EidssFields.Get("idfsCountry"); }
        }

        public string CountryValue
        {
            get { return EidssFields.Get("Kazakhstan"); }
        }

        public List<SelectListItemSurrogate> SelectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month - 1, false); }
        }

        public static explicit operator InfectiousParasiticKZSurrogateModel(InfectiousParasiticKZModel model)
        {
            var address = model.Address ?? new AddressModel();
            var result = new InfectiousParasiticKZSurrogateModel(model.Language, model.Year, model.StartMonth, model.EndMonth,
                address.RegionId, address.RayonId,
                address.RegionName, address.RayonName,
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