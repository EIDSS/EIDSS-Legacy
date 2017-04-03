using System;
using System.Collections.Generic;
using System.Threading;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.KZ
{
    [Serializable]
    public class SanitaryModel : BaseIntervalModel
    {
        public SanitaryModel()
        {
            RegionFilter = new RegionModel();
        }

        public SanitaryModel
            (string lang, DateTime startDate, DateTime endDate, long? regionId, string[] checkedMeasureTypes, bool useArchive)
            : base(lang, startDate, endDate, useArchive)
        {
            CheckedMeasureTypes = checkedMeasureTypes;
            RegionFilter = new RegionModel(regionId);
        }

        [LocalizedDisplayName("strMeasureType")]
        public string[] CheckedMeasureTypes { get; set; }

        public RegionModel RegionFilter { get; set; }

        public List<SelectListItemSurrogate> MeasureTypeList
        {
            get
            {
                return FilterHelper.GetKzFilterList(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                                                    ReportFilterType.SanitaryMeasureTypeName);
            }
        }
    }
}