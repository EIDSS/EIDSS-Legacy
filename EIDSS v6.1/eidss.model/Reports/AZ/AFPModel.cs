using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.AZ
{
    [Serializable]
    public class AFPModel : BaseYearModel
    {
        public AFPModel()
        {
        }

        public AFPModel(string language, int year, int period, int periodType, bool useArchive) : base(language, year, useArchive)
        {
            PeriodType = periodType;
            Period = period;
        }

        [LocalizedDisplayName("ReportingPeriodType")]
        public int PeriodType { get; set; }

        [LocalizedDisplayName("ReportingPeriod")]
        public int Period { get; set; }

        public DateTime StartDate
        {
            get
            {
                switch (PeriodType)
                {
                    case 0:
                        return new DateTime(Year, 1, 1);
                    case 1:
                        return new DateTime(Year, 1, 1).AddMonths(6 * Period);
                    case 2:
                        return new DateTime(Year, 1, 1).AddMonths(3 * Period);
                    case 3:
                        return new DateTime(Year, 1, 1).AddMonths(Period);
                    default:
                        return new DateTime(2000, 1, 1);
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                switch (PeriodType)
                {
                    case 0:
                        return StartDate.AddYears(1).AddDays(-1);
                    case 1:
                        return StartDate.AddMonths(6).AddDays(-1);
                    case 2:
                        return StartDate.AddMonths(3).AddDays(-1);
                    case 3:
                        return StartDate.AddMonths(1).AddDays(-1);
                    default:
                        return new DateTime(2000, 1, 1);
                }
            }
        }

        public string Header
        {
            get
            {
                switch (PeriodType)
                {
                    case 0:
                        return Year.ToString();
                    case 1:
                        return string.Format("{0}, {1} {2}", Year, PeriodName, PeriodTypeName);
                    case 2:
                        return string.Format("{0}, {1} {2}", Year, PeriodTypeName, PeriodName);
                    case 3:
                        return string.Format("{0}, {1}", Year, PeriodName);
                    default:
                        return string.Empty;
                }
            }
        }

        public List<SelectListItemSurrogate> PeriodTypeList
        {
            get { return FilterHelper.GetWebPeriodTypeList(0); }
        }

        public List<SelectListItemSurrogate> PeriodList
        {
            get
            {
                switch (PeriodType)
                {
                    case 1:
                        return FilterHelper.GetWebHalfYearList((DateTime.Now.Month - 1) / 6);

                    case 2:
                        return FilterHelper.GetWebQuarterList((DateTime.Now.Month - 1) / 3);
                    case 3:
                        return FilterHelper.GetWebMonthList(DateTime.Now.Month - 1);
                    default:
                        return new List<SelectListItemSurrogate>();
                }
            }
        }

        private string PeriodTypeName
        {
            get
            {
                using (CreateCurrentCultureInfoTransaction())
                {
                    List<SelectListItemSurrogate> list = PeriodTypeList;
                    return (PeriodType >= 0 && PeriodType < list.Count)
                        ? list[PeriodType].Text
                        : string.Empty;
                }
            }
        }

        private string PeriodName
        {
            get
            {
                using (CreateCurrentCultureInfoTransaction())
                {
                    List<SelectListItemSurrogate> list = PeriodList;
                    return (Period >= 0 && Period < list.Count)
                        ? list[Period].Text
                        : string.Empty;
                }
            }
        }

        public static explicit operator BaseIntervalModel(AFPModel model)
        {
            Utils.CheckNotNull(model, "model");
            var result = new BaseIntervalModel(model.Language, model.StartDate, model.EndDate, model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow,
                OrganizationId = model.OrganizationId,
                ForbiddenGroups = model.ForbiddenGroups,
                UserId = model.UserId,
                IsArchiveMode = model.IsArchiveMode,
            };

            return result;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Period: {0}, Period Type={1}", PeriodName, PeriodTypeName);
        }
    }
}