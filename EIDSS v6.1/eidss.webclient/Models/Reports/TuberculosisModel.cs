using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class TuberculosisModel : BaseModel
    {
        public DiagnosisModel DiagnosisModel { get; set; }

        public string MultipleYearsFilterCheckedItems { get; set; }

        public TuberculosisModel()
        {
            MultipleYears = new MultipleYearsModel(DateTime.Now.Year);
            DiagnosisModel = new DiagnosisModel();
            DiagnosisModel.SetDiagnoses(DiagnosisList);
            DiagnosisModel.AddEmptyDiagnosis();
            FromMonthToMonthModel = new FromMonthToMonthModel();
            FromMonthToMonthModel.StartMonth = FromMonthToMonthModel.EndMonth = DateTime.Now.Month;
        }

        public FromMonthToMonthModel FromMonthToMonthModel { get; set; }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        public MultipleYearsModel MultipleYears { get; set; }
        public string MultipleYears_CheckedItems { get; set; }

        [LocalizedDisplayName("DiagnosisName")]
        public long? DiagnosisId { get; set; }

        public string DiagnosisName
        {
            get
            {
                if (DiagnosisId.HasValue)
                {
                    SelectListItemSurrogate found = DiagnosisList.Find(d => d.Value == DiagnosisId.Value.ToString());
                    return found == null
                        ? string.Empty
                        : found.Text;
                }
                return string.Empty;
            }
        }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get
            {
                //Tuberculosis of lungs, Bacillary form of Tuberculosis of lungs, Tuberculosis of other organs
                //const string additionalFilter = "idfsDiagnosis in (7721290000000, 7718510000000, 7721280000000)";
                //return FilterHelper.GetHumanDiagnosisList(Localizer.CurrentCultureLanguageID, false, false, additionalFilter);
                return FilterHelper.GetTuberculosisDiagnosisList(Localizer.CurrentCultureLanguageID);
            }
        }

        public static explicit operator TuberculosisSurrogateModel(TuberculosisModel model)
        {
            var years = model.MultipleYearsFilterCheckedItems == null
                            ? null
                            : model.MultipleYearsFilterCheckedItems.Split(new[] {","},
                                                                          StringSplitOptions.RemoveEmptyEntries);

            var result = new TuberculosisSurrogateModel(model.Language,
                model.DiagnosisId, model.DiagnosisName,
                years, model.StartMonth, model.EndMonth,
                model.OrganizationId, model.ForbiddenGroups, model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}