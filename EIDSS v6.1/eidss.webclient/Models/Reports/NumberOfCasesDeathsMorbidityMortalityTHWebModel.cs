using System;
using System.Collections.Generic;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.Reports.TH;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class NumberOfCasesDeathsMorbidityMortalityTHWebModel : NumberOfCasesDeathsMorbidityMortalityTHModel
    {
        public NumberOfCasesDeathsMorbidityMortalityTHWebModel()
        {
            Language = ModelUserContext.CurrentLanguage;
            Diagnoses.AddSelectAllItem = true;
            StartDate = new DateTime(DateTime.Today.Year, 1, 1);
        }
        public NumberOfCasesDeathsMorbidityMortalityTHWebModel
            (string lang,
             DateTime startDate, DateTime endDate,
             string[] diagnoses,
             string[] regions,
             string[] zones,
            string[] provinces,
             long? caseClassification,
             long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(lang, startDate, endDate, diagnoses, regions, zones, provinces, caseClassification, organizationId, forbiddenGroups, useArchive)
        {
            Language = ModelUserContext.CurrentLanguage;
            StartDate = new DateTime(DateTime.Today.Year, 1, 1);
            Diagnoses.AddSelectAllItem = true;
        }
        public override  string Diagnoses_CheckedItems { get; set; }
        public override string ZoneFilter_CheckedItems { get; set; }
        public override string RegionFilter_CheckedItems { get; set; }
        public override string ProvinceFilter_CheckedItems { get; set; }

        public NumberOfCasesDeathsMorbidityMortalityTHModel ConvertToBaseModel()
        {
            var baseModel = new NumberOfCasesDeathsMorbidityMortalityTHModel(Language, StartDate, EndDate,
                Diagnoses.CheckedItems,
                Regions.CheckedItems,
                Zones.CheckedItems,
                Provinces.CheckedItems,
                CaseClassification,
                OrganizationId, ForbiddenGroups, UseArchive);
            return baseModel;
        }
    }
}