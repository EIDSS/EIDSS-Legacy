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
            Address = new AddressModel();
            YearModel = new FromYearToYearModel();
        }

        public ExternalComparativeModel(AddressModel address) : this()
        {
            Address = address;
        }

        public AddressModel Address { get; set; }

        public FromYearToYearModel YearModel { get; set; }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetMonthList(DateTime.Now.Month - 1, false); }
        }

        public List<SelectListItemSurrogate> SelectedJanuaryMonthList
        {
            get { return FilterHelper.GetMonthList(0, false); }
        }

        public static explicit operator ExternalComparativeSurrogateModel(ExternalComparativeModel model)
        {
            var result = new ExternalComparativeSurrogateModel(model.Language,
                                                               model.Address.RegionId, model.Address.RayonId,
                                                               model.YearModel.Year1, model.YearModel.Year2,
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