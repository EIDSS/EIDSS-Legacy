using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.Model.Core;
using eidss.model.Resources;
using eidss.model.Enums;

namespace eidss.webclient.Utils
{
    class AggregateHelper
    {
        public static bool ValidateSelection(IList<IObject> selectedItems, Dictionary<string, object> parameters, out string errorMessage)
        {
            if (selectedItems == null || selectedItems.Count == 0)
            {
                errorMessage = string.Empty;
                return true;
            }

            long periodType = (parameters != null && parameters.ContainsKey("PeriodType")) ? (long)parameters["PeriodType"] : 0;
            long areaType = (parameters != null && parameters.ContainsKey("AreaType")) ? (long)parameters["AreaType"] : 0;
            long reportPeriodType = (parameters != null && parameters.ContainsKey("ReportPeriodType")) ? (long)parameters["ReportPeriodType"] : 0;
            long reportAreaType = (parameters != null && parameters.ContainsKey("ReportAreaType")) ? (long)parameters["ReportAreaType"] : 0;
            
            var firstItem = selectedItems[0];
            //Check if first selected record has the same period type as already selected records
            var firstPeriodType = (long)firstItem.GetValue("idfsPeriodType");
            if (periodType > 0 && !periodType.Equals(firstPeriodType))
            {
                errorMessage = EidssMessages.Get("errPeriodTypeDiffer", 
                    "Selected records contain Time Interval that differ from Time Interval in records on summary form. Only records with same Time Interval can be selected to summary form.");
                return false;
            }
            //Check if first selected pecord has period type that corresponds report period type
            if (!ValidatePeriodTypeViaReportPeriodType(firstPeriodType, reportPeriodType))
            {
                errorMessage = EidssMessages.Get("errPeriodTypeInvalid",
                    "Selected records contain Time Interval that is not allowed by Time Interval selected on summary form.");
                return false;
            }
            //Check if first selected record has the same area type as already selected records
            var firstAreaType = (long)firstItem.GetValue("idfsAreaType");
            if (areaType > 0 && !areaType.Equals(firstAreaType))
            {
                errorMessage = EidssMessages.Get("errAreaTypeDiffer", 
                    "Selected records contain Adminstrative Level that differ from Adminstrative Level in records on summary form. Only records with same Adminstrative Level can be selected to summary form.");
                return false;
            }

            //Check if first selected pecord has area type that corresponds report area type
            if (!ValidateAreaTypeViaReportAreaType(firstAreaType, reportAreaType))
            {
                errorMessage = EidssMessages.Get("errAreaTypeInvalid", "Selected records contain Administrative Level that is not allowed by Admnistrative Level selected on summary form.");
                return false;
            }
            foreach (IObject item in selectedItems)
            {
                //Check if each selected item has the same period type
                if (firstPeriodType != (long)item.GetValue("idfsPeriodType"))
                {
                    errorMessage = EidssMessages.Get("errPeriodTypeMultiple",
                        "Selected records contain different Time Intervals. Only records with same Time Interval can be selected to summary form.");
                    return false;
                }

                //Check if each selected item has the same area type
                if (firstAreaType != (long)item.GetValue("idfsAreaType"))
                {
                    errorMessage = EidssMessages.Get("errAreaTypeMultiple",
                        "Selected records contain different Adminstrative Levels. Only records with same Adminstrative Level can be selected to summary form.");
                    return false;
                }
            }
            errorMessage = string.Empty;
            return true;
        }
        
        private static bool ValidatePeriodTypeViaReportPeriodType(long periodType, long reportPeriodType)
        {
            return ValidatePeriodType((StatisticPeriodType)periodType, (StatisticPeriodType)reportPeriodType);
        }

        public static bool ValidatePeriodType(StatisticPeriodType periodType, StatisticPeriodType reportPeriodType)
        {
            switch (periodType)
            {
                case StatisticPeriodType.Day:
                    return true;
                case StatisticPeriodType.Month:
                    return reportPeriodType != StatisticPeriodType.Day && reportPeriodType != StatisticPeriodType.Week;
                case StatisticPeriodType.Quarter:
                    return reportPeriodType == StatisticPeriodType.Quarter || reportPeriodType == StatisticPeriodType.Year;
                case StatisticPeriodType.Week:
                    return reportPeriodType == StatisticPeriodType.Week || reportPeriodType == StatisticPeriodType.Year;
                case StatisticPeriodType.Year:
                    return reportPeriodType == StatisticPeriodType.Year;
                default:
                    return false;
            }
        }

        private static bool ValidateAreaTypeViaReportAreaType(long areaType, long reportAreaType)
        {
            return ValidateAreaType((StatisticAreaType)areaType, (StatisticAreaType)reportAreaType);
        }

        public static bool ValidateAreaType(StatisticAreaType areaType, StatisticAreaType reportAreaType)
        {
            switch (areaType)
            {
                case StatisticAreaType.Settlement:
                    return true;
                case StatisticAreaType.Rayon:
                    return reportAreaType != StatisticAreaType.Settlement;
                case StatisticAreaType.Region:
                    return reportAreaType == StatisticAreaType.Region || reportAreaType == StatisticAreaType.Country;
                case StatisticAreaType.Country:
                    return reportAreaType == StatisticAreaType.Country;
                default:
                    return false;
            }
        }
    }
}
