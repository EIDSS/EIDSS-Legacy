using System;
using System.Collections.Generic;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class BaseDateModel : BaseModel
    {
        public BaseDateModel()
        {
            Year = DateTime.Now.Year;
        }

        public BaseDateModel(string language, int year, int? month, bool useArchive)
            : this(language, year, month, null, useArchive)
        {
        }

        public BaseDateModel(string language, int year, int? month, int? monthEnd, bool useArchive)
            : base(language, useArchive)
        {
            Year = year;

            Month = month > 0 && month < 13
                ? month
                : null;
            MonthEnd = monthEnd > 0 && monthEnd < 13
                ? monthEnd
                : null;

            IsMonthMandatory = false;
        }

        [LocalizedDisplayName("YearForAggr")]
        public int Year { get; set; }

        [LocalizedDisplayName("MonthForAggr")]
        public int? Month { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? MonthEnd { get; set; }

        public bool IsMonthMandatory { get; set; }

        public List<SelectListItemSurrogate> SelectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month - 1, false); }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Year={0}, Month={1}, MonthEnd={2}", Year, Month, MonthEnd);
        }
    }
}