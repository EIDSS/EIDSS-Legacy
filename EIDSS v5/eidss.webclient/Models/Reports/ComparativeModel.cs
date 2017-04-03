using System;
using System.Collections.Generic;
using System.Threading;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class ComparativeModel : BaseModel
    {
        public ComparativeModel()
        {
            Address1 = new AddressModel();
            Address2 = new AddressModel();

            YearModel = new FromYearToYearModel();
        }

        [LocalizedDisplayName("Counter")]
        public int Counter { get; set; }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        public FromYearToYearModel YearModel { get; set; }

        public AddressModel Address1 { get; set; }

        public AddressModel Address2 { get; set; }

        [LocalizedDisplayName("EnteredByOrganization")]
        public long? OrganizationCHE { get; set; }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetMonthList(DateTime.Now.Month - 1, false); }
        }

        public List<SelectListItemSurrogate> SelectedJanuaryMonthList
        {
            get { return FilterHelper.GetMonthList(0, false); }
        }

        public List<SelectListItemSurrogate> CounterList
        {
            get { return FilterHelper.GetCounterList(0); }
        }

        public List<SelectListItemSurrogate> OrganizationList
        {
            get { return FilterHelper.GetHumOrganizationList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName); }
        }

        public static explicit operator ComparativeSurrogateModel(ComparativeModel model)
        {
            var result = new ComparativeSurrogateModel(model.Language, model.Counter, model.StartMonth, model.EndMonth,
                                                       model.YearModel.Year1, model.YearModel.Year2,
                                                       model.Address1.RegionId, model.Address1.RayonId,
                                                       model.Address2.RegionId, model.Address2.RayonId,
                                                       model.OrganizationCHE, model.UseArchive)
                {
                    ExportFormat = model.ExportFormat,
                    IsOpenInNewWindow = model.IsOpenInNewWindow
                };

            return result;
        }
    }
}