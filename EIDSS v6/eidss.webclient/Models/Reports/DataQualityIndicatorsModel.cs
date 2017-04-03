using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class DataQualityIndicatorsModel : BaseYearModel
    {
        public DataQualityIndicatorsModel()
        {
            Address = new TransportCHEModel();
            MultipleDiagnosisFilter = new MultipleDiagnosisModel();
        }

        public DataQualityIndicatorsModel
            (string language, string[] checkedDiagnosis,
                int year, int? startMonth, int? endMonth,
                long? regionId, long? rayonId, bool arrangeRayons,
                bool useArchive)
            : base(language, year, useArchive)
        {
            StartMonth = startMonth;
            EndMonth = endMonth;
            MultipleDiagnosisFilter = new MultipleDiagnosisModel(checkedDiagnosis, (int) HACode.Human);
            Address = new TransportCHEModel(regionId, rayonId);
            ArrangeRayonsAlphabetically = arrangeRayons;
        }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        [LocalizedDisplayName("EnteredByOrganization")]
        public long? OrganizationCHE { get; set; }

        public string OrganizationCHEName
        {
            get
            {
                return !OrganizationCHE.HasValue
                    ? string.Empty
                    : FilterHelper.GetHumOrganizationName(OrganizationCHE.Value,
                        Localizer.CurrentCultureLanguageID);
            }
        }

        public TransportCHEModel Address { get; set; }
        public MultipleDiagnosisModel MultipleDiagnosisFilter { get; set; }
        public string MultipleDiagnosisFilter_CheckedItems { get; set; }
        public bool ArrangeRayonsAlphabetically { get; set; }
        public bool ShowRayonFilter { get; set; }

        public List<SelectListItemSurrogate> UnselectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(-1, false); }
        }

        public List<SelectListItemSurrogate> SelectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month - 1, false); }
        }

        public List<SelectListItemSurrogate> OrganizationList
        {
            get { return FilterHelper.GetHumOrganizationList(Localizer.CurrentCultureLanguageID); }
        }

        public static explicit operator DataQualityIndicatorsSurrogateModel(DataQualityIndicatorsModel model)
        {
            TransportCHEModel transportChe = model.Address ?? new TransportCHEModel();
            var result = new DataQualityIndicatorsSurrogateModel(model.Language,
                model.MultipleDiagnosisFilter.CheckedItems,
                model.Year, model.StartMonth, model.EndMonth,
                transportChe.RegionId, transportChe.RayonId,
                model.ArrangeRayonsAlphabetically,
                model.OrganizationId,
                model.ForbiddenGroups, model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}