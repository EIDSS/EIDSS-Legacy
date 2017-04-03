using System;
using System.Collections.Generic;
using System.Threading;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.KZ
{
    [Serializable]
    public class ProphylacticModel : BaseIntervalModel
    {
        public ProphylacticModel()
        {
            RegionFilter = new RegionModel();
        }

        public ProphylacticModel
            (string lang, DateTime startDate, DateTime endDate, long? regionId,
             string[] checkedDiagnosis, string[] checkedSpecies, string[] checkedMeasureTypes, bool useArchive)
            : base(lang, startDate, endDate, useArchive)
        {
            CheckedMeasureTypes = checkedMeasureTypes;
            CheckedDiagnosis = checkedDiagnosis;
            CheckedSpecies = checkedSpecies;
            RegionFilter = new RegionModel(regionId);
        }

        [LocalizedDisplayName("strMeasureType")]
        public string[] CheckedMeasureTypes { get; set; }

        [LocalizedDisplayName("DiagnosisName")]
        public string[] CheckedDiagnosis { get; set; }

        [LocalizedDisplayName("idfsSpeciesType")]
        public string[] CheckedSpecies { get; set; }

        public RegionModel RegionFilter { get; set; }

        public List<SelectListItemSurrogate> MeasureTypeList
        {
            get
            {
                return FilterHelper.GetKzFilterList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                                                    ReportFilterType.ProphylacticMeasureType);
            }
        }

        public List<SelectListItemSurrogate> DiagnosisList
        {
            get
            {
                return FilterHelper.GetKzFilterList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                                                    ReportFilterType.ProphylacticDiagnosis);
            }
        }

        public List<SelectListItemSurrogate> SpeciesList
        {
            get
            {
                return FilterHelper.GetKzFilterList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                                                    ReportFilterType.ProphylacticSpecies);
            }
        }
    }
}