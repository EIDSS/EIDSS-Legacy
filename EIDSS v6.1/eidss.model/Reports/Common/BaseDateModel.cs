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
            MonthPropertyName = "Month";
            YearPropertyName = "Year";

            Year = DateTime.Now.Year;
            IsMonthMandatory = false;
            IsCurrentMonthSelected = true;
        }

        public BaseDateModel(string language, int year, int? month, bool useArchive)
            : this(language, year, month, null, useArchive)
        {
            IsMonthMandatory = false;
            IsCurrentMonthSelected = true;
        }

        public BaseDateModel(string language, int year, int? month, int? monthEnd, bool useArchive)
            : base(language, useArchive)
        {
            MonthPropertyName = "Month";
            YearPropertyName = "Year";

            Year = year;

            Month = month > 0 && month < 13
                ? month
                : null;
            MonthEnd = monthEnd > 0 && monthEnd < 13
                ? monthEnd
                : null;

            IsMonthMandatory = false;
            IsCurrentMonthSelected = true;
        }

        [LocalizedDisplayName("YearForAggr")]
        public int Year { get; set; }

        public virtual int MinYear
        {
            get { return 2000; }
        }

        public virtual int MaxYear
        {
            get { return DateTime.Today.Year; }
        }

        [LocalizedDisplayName("MonthForAggr")]
        public int? Month { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? MonthEnd { get; set; }

        public bool IsMonthMandatory { get; set; }

        public bool IsCurrentMonthSelected { get; set; }

        public string YearPropertyName { get; set; }
        public string MonthPropertyName { get; set; }


        public virtual List<SelectListItemSurrogate> SelectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(IsCurrentMonthSelected ? DateTime.Now.Month : -1, IsMonthMandatory); }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Year={0}, Month={1}, MonthEnd={2}", Year, Month, MonthEnd);
        }
    }
}