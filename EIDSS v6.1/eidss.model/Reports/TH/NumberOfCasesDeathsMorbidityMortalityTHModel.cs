using System;
using System.Collections.Generic;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.TH
{
    [Serializable]
    public class NumberOfCasesDeathsMorbidityMortalityTHModel : BaseIntervalModel
    {
        public NumberOfCasesDeathsMorbidityMortalityTHModel()
        {
            Diagnoses = new MultipleDiagnosisModel();
            Regions = new MultipleRegionTHModel();
            Zones = new MultipleZoneTHModel();
            Provinces = new MultipleProvinceTHModel();
        }

        public NumberOfCasesDeathsMorbidityMortalityTHModel
            (string lang,
                DateTime startDate, DateTime endDate,
                string[] diagnoses,
                string[] regions,
                string[] zones,
                string[] provinces,
                long? caseClassification,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(lang, startDate, endDate, useArchive)
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

        public virtual string Diagnoses_CheckedItems { get; set; }
        public virtual string ZoneFilter_CheckedItems { get; set; }
        public virtual string RegionFilter_CheckedItems { get; set; }
        public virtual string ProvinceFilter_CheckedItems { get; set; }

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