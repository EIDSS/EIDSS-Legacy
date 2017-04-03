using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Resources;

namespace eidss.winclient.Helpers
{
    class AggregateHelper
    {
        public static bool ValidateSelection<T>(IBasePanel panel, ActionMetaItem action)
        {
            var listPanel = (IBaseListPanel)panel;
            IList<T> selectedItems;
            if (action.ActionType == ActionTypes.SelectAll)
                selectedItems = ((IList<T>)listPanel.Grid.GridControl.DataSource).ToList();
            else if (action.ActionType == ActionTypes.Select)
                selectedItems = listPanel.SelectedItems.Cast<T>().ToList();
            else
                return true;
            if (selectedItems.Count == 0)
                return true;


            Dictionary<string, object> startUpParameters = panel.StartUpParameters;
            var periodType = (startUpParameters != null && startUpParameters.ContainsKey("PeriodType")) ? (long)startUpParameters["PeriodType"] : 0;
            var areaType = (startUpParameters != null && startUpParameters.ContainsKey("AreaType")) ? (long)startUpParameters["AreaType"] : 0;
            var reportPeriodType = (startUpParameters != null && startUpParameters.ContainsKey("ReportPeriodType")) ? (long)startUpParameters["ReportPeriodType"] : 0;
            var reportAreaType = (startUpParameters != null && startUpParameters.ContainsKey("ReportAreaType")) ? (long)startUpParameters["ReportAreaType"] : 0;

            return ValidateSelection(selectedItems, periodType, areaType, reportPeriodType, reportAreaType);
        }

        public static bool ValidateSelection<T>(IList<T> selectedItems, long periodType, long areaType, long reportPeriodType, long reportAreaType)
        {
            if (selectedItems == null || selectedItems.Count < 1)
                return false;

            var firstItem = selectedItems[0] as IObject;
            //Check if first selected record has the same period type as already selected records
            Debug.Assert(firstItem != null, "firstItem != null");
            var firstPeriodType = (long)firstItem.GetValue("idfsPeriodType");
            if (periodType > 0 && !periodType.Equals(firstPeriodType))
            {
                MessageForm.Show(EidssMessages.Get("errPeriodTypeDiffer", "Selected records contain Time Interval that differ from Time Interval in records on summary form. Only records with same Time Interval can be selected to summary form."), EidssMessages.Get("titleIncorrectSelection", "Incorrect selection"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Check if first selected pecord has period type that corresponds report period type
            if (!ValidatePeriodTypeViaReportPeriodType(firstPeriodType, reportPeriodType))
            {
                MessageForm.Show(EidssMessages.Get("errPeriodTypeInvalid", "Selected records contain Time Interval that is not allowed by Time Interval selected on summary form."), EidssMessages.Get("titleIncorrectSelection", "Incorrect selection"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Check if first selected record has the same area type as already selected records
            var firstAreaType = (long)firstItem.GetValue("idfsAreaType");
            if (areaType > 0 && !areaType.Equals(firstAreaType))
            {
                MessageForm.Show(EidssMessages.Get("errAreaTypeDiffer", "Selected records contain Adminstrative Level that differ from Adminstrative Level in records on summary form. Only records with same Adminstrative Level can be selected to summary form."), EidssMessages.Get("titleIncorrectSelection", "Incorrect selection"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Check if first selected pecord has area type that corresponds report area type
            if (!ValidateAreaTypeViaReportAreaType(firstAreaType, reportAreaType))
            {
                MessageForm.Show(EidssMessages.Get("errAreaTypeInvalid", "Selected records contain Administrative Level that is not allowed by Admnistrative Level selected on summary form."), EidssMessages.Get("titleIncorrectSelection", "Incorrect selection"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            foreach (IObject item in selectedItems)
            {
                //Check if each selected item has the same period type
                if (firstPeriodType != (long)item.GetValue("idfsPeriodType"))
                {
                    MessageForm.Show(EidssMessages.Get("errPeriodTypeMultiple", "Selected records contain different Time Intervals. Only records with same Time Interval can be selected to summary form."), EidssMessages.Get("titleIncorrectSelection", "Incorrect selection"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //Check if each selected item has the same area type
                if (firstAreaType != (long)item.GetValue("idfsAreaType"))
                {
                    MessageForm.Show(EidssMessages.Get("errAreaTypeMultiple", "Selected records contain different Adminstrative Levels. Only records with same Adminstrative Level can be selected to summary form."), EidssMessages.Get("titleIncorrectSelection", "Incorrect selection"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
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
