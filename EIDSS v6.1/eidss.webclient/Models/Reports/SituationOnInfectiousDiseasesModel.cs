using System;
using eidss.model.Enums;
using eidss.model.Reports.Common;
using eidss.model.Reports.IQ;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class SituationOnInfectiousDiseasesModel : BaseYearModel
    {
        public SituationOnInfectiousDiseasesModel()
        {
            RegionFilter = new RegionModel(FilterHelper.GetDefaultRegion());
            WeeksFilter = new WeeksModel();
            MonthsFilter = new BaseDateModel
            {
                IsMonthMandatory = true,
                MonthPropertyName = "MonthsFilter.Month",
                YearPropertyName = "MonthsFilter.Year"
            };
        }

        public StatisticPeriodType PeriodType { get; set; }

        public int PeriodNumber
        {
            get
            {
                if (PeriodType == StatisticPeriodType.Week)
                {
                    WeeksFilter.Year = Year;
                    return WeeksFilter.WeekId.HasValue ? WeeksFilter.WeekId.Value : 0;
                }
                if (PeriodType == StatisticPeriodType.Month)
                {
                    return MonthsFilter.Month.HasValue ? MonthsFilter.Month.Value : 0;
                }
                return 0;
            }
            set
            {
                if (PeriodType == StatisticPeriodType.Week)
                {
                    WeeksFilter.WeekId = value;
                }
                if (PeriodType == StatisticPeriodType.Month)
                {
                    MonthsFilter.Month = value;
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                if (PeriodType == StatisticPeriodType.Week)
                {
                    WeeksFilter.Year = Year;
                    return WeeksFilter.StartDate;
                }
                if (PeriodType == StatisticPeriodType.Month)
                {
                    return MonthsFilter.Month.HasValue ? new DateTime(Year, MonthsFilter.Month.Value, 1) : DateTime.MinValue;
                }
                return DateTime.MinValue;
            }
        }

        public DateTime EndDate
        {
            get
            {
                switch (PeriodType)
                {
                    case StatisticPeriodType.Week:
                        return StartDate.AddDays(6);

                    case StatisticPeriodType.Month:
                        return StartDate.AddMonths(1).AddDays(-1);

                    default:
                        return StartDate;
                }
            }
        }

        public long? RegionId
        {
            get { return RegionFilter.RegionId; }
            set { RegionFilter.RegionId = value; }
        }

        public WeeksModel WeeksFilter { get; private set; }

        public BaseDateModel MonthsFilter { get; private set; }

        public RegionModel RegionFilter { get; private set; }

        public static explicit operator SituationOnInfectiousDiseasesSurrogateModel(SituationOnInfectiousDiseasesModel model)
        {
            var result = new SituationOnInfectiousDiseasesSurrogateModel(model.Language,
                model.Year, model.PeriodType, model.PeriodNumber, model.StartDate, model.EndDate,
                model.RegionFilter.RegionId, model.RegionFilter.RegionName,
                model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow,
                OrganizationId = model.OrganizationId,
                ForbiddenGroups = model.ForbiddenGroups,
            };

            return result;
        }
    }
}