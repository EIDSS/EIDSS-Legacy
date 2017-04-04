using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class ComparativeTwoYearsModel : BaseModel
    {
        public ComparativeTwoYearsModel()
        {
            Address = new TransportCHEModel(FilterHelper.GetDefaultRegion(true), FilterHelper.GetDefaultRayon(true));

            YearModel = new FromYearToYearModel();

            DiagnosisModel = new DiagnosisModel();
            DiagnosisModel.SetDiagnoses(DiagnosisList);
            DiagnosisModel.AddEmptyDiagnosis();

            Counter = new MultipleCounterModel() {IsRequired = true};
        }

        public DiagnosisModel DiagnosisModel { get; set; }

        [LocalizedDisplayName("Counter")]
        public MultipleCounterModel Counter { get; set; }

        public string MultipleCounterFilter_CheckedItems { get; set; }

        public FromYearToYearModel YearModel { get; set; }

        public TransportCHEModel Address { get; set; }

        [LocalizedDisplayName("DiagnosisName")]
        public long? DiagnosisId { get; set; }

        public string DiagnosisName
        {
            get
            {
                if (DiagnosisId.HasValue)
                {
                    var found = DiagnosisList.Find(d => d.Value == DiagnosisId.Value.ToString());
                    return found == null
                        ? string.Empty
                        : found.Text;
                }
                return string.Empty;
            }
        }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get { return FilterHelper.GetHumanDiagnosisList(Localizer.CurrentCultureLanguageID, true, false, "[intRowStatus] = 0"); }
        }

        public static explicit operator ComparativeTwoYearsSurrogateModel(ComparativeTwoYearsModel model)
        {
            var address = model.Address ?? new TransportCHEModel();
            var result = new ComparativeTwoYearsSurrogateModel(model.Language,
                model.YearModel.Year1, model.YearModel.Year2,
                model.Counter.CheckedItems,
                model.DiagnosisId, model.DiagnosisName,
                address.RegionId, address.RegionId.HasValue ? address.RayonId : null,
                address.RegionName, address.RegionId.HasValue ? address.RayonName : null,
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