using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using eidss.model.Core;

namespace eidss.model.Reports.Common
{
    public class WeeksModel
    {
        public WeeksModel()
        {
            Year = DateTime.Now.Year;
        }

        public WeeksModel(int? weekId)
        {
            WeekId = weekId;
            Year = DateTime.Now.Year;
        }

        [LocalizedDisplayName("WeekForAggr")]
        public int? WeekId { get; set; }

        public int Year { get; set; }

        public DateTime StartDate
        {
            get
            {
                var weeksList = DatePeriodHelper.GetWeeksList(Year);
                return weeksList.FirstOrDefault(w => w.WeekNumber == WeekId).WeekStartDate;
            }
        }
        public List<SelectListItemSurrogate> GetWeeksList(int year)
        {
            Year = year;
            var weeksList = DatePeriodHelper.GetWeeksList(year);
            var result = new List<SelectListItemSurrogate>();
            foreach (var week in weeksList)
            {
                var sli = new SelectListItemSurrogate
                    {
                        Text = String.Format("{0:00} ({1} - {2})"
                                , week.WeekNumber
                                , week.WeekStartDate.ToString("dd/MM/yyyy")
                                , week.WeekStartDate.AddDays(6).ToString("dd/MM/yyyy")),
                        Value = week.WeekNumber.ToString(CultureInfo.InvariantCulture),
                        Selected = WeekId.HasValue && week.WeekNumber == WeekId.Value

                    };
                result.Add(sli);
            }
            return result;
        }
    }
}
