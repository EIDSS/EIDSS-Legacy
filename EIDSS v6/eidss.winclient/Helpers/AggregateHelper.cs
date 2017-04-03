using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using bv.common.Enums;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Helpers;
using eidss.model.Resources;
using eidss.model.Schema;
using System.Data;

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
                MessageForm.Show(string.Format(EidssMessages.Get("errPeriodTypeDiffer"), GetPeriodTypeName(firstPeriodType), GetPeriodTypeName(periodType)), BvMessages.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Check if first selected pecord has period type that corresponds report period type
            if (!ValidatePeriodTypeViaReportPeriodType(firstPeriodType, reportPeriodType))
            {
                MessageForm.Show(string.Format(EidssMessages.Get("errPeriodTypeInvalid"), GetPeriodTypeName(firstPeriodType), GetPeriodTypeName(reportPeriodType)), BvMessages.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Check if first selected record has the same area type as already selected records
            var firstAreaType = (long)firstItem.GetValue("idfsAreaType");
            if (areaType > 0 && !areaType.Equals(firstAreaType))
            {
                MessageForm.Show(string.Format(EidssMessages.Get("errAreaTypeDiffer"), GetAdministrativeUnitName(firstAreaType), GetAdministrativeUnitName(areaType)), BvMessages.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Check if first selected pecord has area type that corresponds report area type
            if (!ValidateAreaTypeViaReportAreaType(firstAreaType, reportAreaType))
            {
                MessageForm.Show(string.Format(EidssMessages.Get("errAreaTypeInvalid"), GetAdministrativeUnitName(firstAreaType), GetAdministrativeUnitName(reportAreaType)), BvMessages.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            foreach (IObject item in selectedItems)
            {
                //Check if each selected item has the same period type
                if (firstPeriodType != (long)item.GetValue("idfsPeriodType"))
                {
                    MessageForm.Show(EidssMessages.Get("errPeriodTypeMultiple", "Selected records contain different Time Intervals. Only records with same Time Interval can be selected to summary form."), BvMessages.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //Check if each selected item has the same area type
                if (firstAreaType != (long)item.GetValue("idfsAreaType"))
                {
                    MessageForm.Show(EidssMessages.Get("errAreaTypeMultiple", "Selected records contain different Adminstrative Levels. Only records with same Adminstrative Level can be selected to summary form."), BvMessages.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void BindPeriodTable(LookUpEdit cb, DataTable dt)
        {
            cb.Properties.Columns.Clear();
            cb.Properties.Columns.AddRange(new[]
                {
                    new LookUpColumnInfo("PeriodNumber", EidssMessages.Get("colPeriodNumber", "Period Number"), 50,
                                         FormatType.None, String.Empty, true, HorzAlignment.Near),
                    new LookUpColumnInfo("PeriodName", EidssMessages.Get("colPeriodName", "Period Name"), 200,
                                         FormatType.None, String.Empty, true, HorzAlignment.Near)
                }
                );
            cb.Properties.DataSource = new DataView(dt);
            cb.Properties.DisplayMember = "PeriodName";
            cb.Properties.ValueMember = "PeriodNumber";
        }

        private const int MinYear = 1900;

        public void FillYearList(ComboBoxEdit cbYear)
        {
            cbYear.Properties.Items.Clear();
            for (var i = DateTime.Now.Year; i >= MinYear; i--)
            {
                cbYear.Properties.Items.Add(i);
            }
        }

        public void FillWeekList(LookUpEdit cb, int year)
        {
            var dt = AggregateListHelper.CreateWeeksTable(year);
            BindPeriodTable(cb, dt);
            //если текущий год, то выставляем активной нынешнюю неделю
            var now = DateTime.Now;
            if (now.Year == year)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var d = (DateTime)row["StartDay"];
                    if ((now - d).Days <= 6)
                    {
                        cb.EditValue = row["PeriodNumber"];
                        break;
                    }
                }
            }
        }
    }
}
