using System;
using System.Collections.Generic;
using System.Threading;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.KZ
{
    [Serializable]
    public class DiagnosticInvestigationModel : BaseIntervalModel
    {
        public DiagnosticInvestigationModel()
        {
            RegionFilter = new RegionModel();
        }

        public DiagnosticInvestigationModel
            (string lang, DateTime startDate, DateTime endDate, long? regionId,
             string[] checkedDiagnosis, string[] checkedSpecies, string[] checkedInvestigationTypes, bool useArchive)
            : base(lang, startDate, endDate, useArchive)
        {
            CheckedInvestigationTypes = checkedInvestigationTypes;
            CheckedDiagnosis = checkedDiagnosis;
            CheckedSpecies = checkedSpecies;
            RegionFilter = new RegionModel(regionId);
        }

        [LocalizedDisplayName("strInvestionType")]
        public string[] CheckedInvestigationTypes { get; set; }

        [LocalizedDisplayName("DiagnosisName")]
        public string[] CheckedDiagnosis { get; set; }

        [LocalizedDisplayName("idfsSpeciesType")]
        public string[] CheckedSpecies { get; set; }

        public RegionModel RegionFilter { get; set; }

        public List<SelectListItemSurrogate> InvestigationTypeList
        {
            get
            {
                return FilterHelper.GetKzFilterList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                                                    ReportFilterType.DiagnosticInvestigationType);
            }
        }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get
            {
                return FilterHelper.GetKzFilterList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                                                    ReportFilterType.DiagnosticInvestigationDiagnosis);
            }
        }

        public List<SelectListItemSurrogate> SpeciesList
        {
            get
            {
                return FilterHelper.GetKzFilterList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                                                    ReportFilterType.DiagnosticInvestigationSpecies);
            }
        }
    }
}