using System;
using System.Collections.Generic;
using eidss.model.Enums;
using eidss.model.Reports.TH;

namespace eidss.webclient.Models.Reports
{
    //[Serializable]
    //public class NumberOfCasesDeathsMonthTHWebModel : NumberOfCasesDeathsMonthTHModel
    //{
    //    public NumberOfCasesDeathsMonthTHWebModel()
    //    {
    //        Diagnoses.AddSelectAllItem = true;
    //    }

    //    public NumberOfCasesDeathsMonthTHWebModel
    //        (string lang,
    //            int year,
    //            string[] diagnoses,
    //            string[] regions,
    //            string[] zones,
    //            long? caseClassification,
    //            long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
    //        : base(lang, year, diagnoses, regions, zones, caseClassification, organizationId, forbiddenGroups, useArchive)
    //    {
    //        Diagnoses.AddSelectAllItem = true;
    //    }

    //    public string Diagnoses_CheckedItems { get; set; }
    //    public string ZoneFilter_CheckedItems { get; set; }
    //    public string RegionFilter_CheckedItems { get; set; }

    //    public NumberOfCasesDeathsMonthTHModel ConvertToBaseModel()
    //    {
    //        var baseModel = new NumberOfCasesDeathsMonthTHModel(Language, Year,
    //            Diagnoses.CheckedItems,
    //            Regions.CheckedItems,
    //            Zones.CheckedItems,
    //            CaseClassification,
    //            OrganizationId, ForbiddenGroups, UseArchive);
    //        return baseModel;
    //    }
    //}
}