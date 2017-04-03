using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Resources;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.webclient.Utils
{
    class AggregateHelper
    {
        private static string GetPeriodTypeName(long periodType)
        {
            using (DbManagerProxy managerProxy = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var singleOrDefault =
                    BaseReference.Accessor.Instance(null)
                                 .rftStatisticPeriodType_SelectList(managerProxy)
                                 .SingleOrDefault(c => c.idfsBaseReference == periodType);
                if (singleOrDefault != null)
                {
                    return
                        singleOrDefault.name;
                }
            }

            return string.Empty;
        }
        private static string GetAdministrativeUnitName(long areaType)
        {
            using (DbManagerProxy managerProxy = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var singleOrDefault =
                    BaseReference.Accessor.Instance(null)
                                 .rftStatisticAreaType_SelectList(managerProxy)
                                 .SingleOrDefault(c => c.idfsBaseReference == areaType);
                if (singleOrDefault != null)
                {
                    return
                        singleOrDefault.name;
                }
            }

            return string.Empty;
        }

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
                errorMessage = string.Format(EidssMessages.Get("errPeriodTypeDiffer"), GetPeriodTypeName(firstPeriodType), GetPeriodTypeName(periodType));
                return false;
            }
            //Check if first selected pecord has period type that corresponds report period type
            if (!ValidatePeriodTypeViaReportPeriodType(firstPeriodType, reportPeriodType))
            {
                errorMessage = string.Format(EidssMessages.Get("errPeriodTypeInvalid"), GetPeriodTypeName(firstPeriodType), GetPeriodTypeName(reportPeriodType));
                return false;
            }
            //Check if first selected record has the same area type as already selected records
            var firstAreaType = (long)firstItem.GetValue("idfsAreaType");
            if (areaType > 0 && !areaType.Equals(firstAreaType))
            {
                errorMessage = string.Format(EidssMessages.Get("errAreaTypeDiffer"), GetAdministrativeUnitName(firstAreaType), GetAdministrativeUnitName(areaType));
                return false;
            }

            //Check if first selected pecord has area type that corresponds report area type
            if (!ValidateAreaTypeViaReportAreaType(firstAreaType, reportAreaType))
            {
                errorMessage = string.Format(EidssMessages.Get("errAreaTypeInvalid"), GetAdministrativeUnitName(firstAreaType), GetAdministrativeUnitName(reportAreaType));
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
