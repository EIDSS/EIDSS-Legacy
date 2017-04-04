using System;
using System.Collections.Generic;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.TH;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class ComparativeSeveralYearsTHModel : BaseModel
    {
        public ComparativeSeveralYearsTHModel()
        {
            District = new ThaiDistrictModel();

            YearModel = new FromYearToYearModel();

            MultipleDiagnosisFilter = new MultipleDiagnosisModel {AddSelectAllItem = true};

            Counter = 1;
        }

        public MultipleDiagnosisModel MultipleDiagnosisFilter { get; set; }
        public string MultipleDiagnosisFilter_CheckedItems { get; set; }

        public FromYearToYearModel YearModel { get; set; }

        public ThaiDistrictModel District { get; set; }

        [LocalizedDisplayName("Counter")]
        public int Counter { get; set; }

        public List<SelectListItemSurrogate> CounterList
        {
            get { return FilterHelper.GetWebCounterThaiList(1); }
        }

        public static explicit operator ComparativeSeveralYearsTHSurrogateModel(ComparativeSeveralYearsTHModel model)
        {
            var district = model.District ?? new ThaiDistrictModel();
            var result = new ComparativeSeveralYearsTHSurrogateModel(model.Language,
                model.YearModel.ThaiToGrigorean(model.YearModel.StartYear), model.YearModel.ThaiToGrigorean(model.YearModel.EndYear),
                model.MultipleDiagnosisFilter.CheckedItems,
                model.Counter,
                district.ProvinceId, district.DistrictId,
                district.ProvinceName, district.DistrictName,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}