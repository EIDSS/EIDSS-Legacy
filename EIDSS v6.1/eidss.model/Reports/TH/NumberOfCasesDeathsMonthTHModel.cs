using System;
using System.Collections.Generic;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.TH
{
    [Serializable]
    public class NumberOfCasesDeathsMonthTHModel : BaseThaiYearModel
    {
        public NumberOfCasesDeathsMonthTHModel()
        {
            Diagnoses = new MultipleDiagnosisModel();
            Regions = new MultipleRegionTHModel();
            Zones = new MultipleZoneTHModel();
            Provinces = new MultipleProvinceTHModel();

            Language = ModelUserContext.CurrentLanguage;
            if (Language == Localizer.lngThai)
            {
                Year = ThaiCalendarHelper.GregorianYearToThai(Year);
            }
        }

        public NumberOfCasesDeathsMonthTHModel
            (string lang,
                int year,
                string[] diagnoses,
                string[] regions,
                string[] zones,
                string[] provinces,
                long? caseClassification,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(lang, year, useArchive)
        {
            Diagnoses = new MultipleDiagnosisModel(diagnoses);
            Regions = new MultipleRegionTHModel(regions);
            Zones = new MultipleZoneTHModel(zones);
            Provinces = new MultipleProvinceTHModel(provinces);
            CaseClassification = caseClassification;

            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public MultipleDiagnosisModel Diagnoses { get; set; }
        public MultipleRegionTHModel Regions { get; set; }
        public MultipleZoneTHModel Zones { get; set; }
        public MultipleProvinceTHModel Provinces { get; set; }
        public long? CaseClassification { get; set; }

        public string Diagnoses_CheckedItems { get; set; }
        public string ZoneFilter_CheckedItems { get; set; }
        public string RegionFilter_CheckedItems { get; set; }
        public string ProvinceFilter_CheckedItems { get; set; }

        public List<SelectListItemSurrogate> CaseClassificationsList
        {
            get { return FilterHelper.GetCaseClassificationsList(ModelUserContext.CurrentLanguage, (int) HACode.Human, true, true, true); }
        }

        public override string ToString()
        {
            return string.Format("{0}, Regions={1}, Zones = {2}, Diagnoses={3}, Case Classification={4}, Provinces = {5}",
                base.ToString(), Regions, Zones, Diagnoses, CaseClassification, Provinces);
        }
    }
}