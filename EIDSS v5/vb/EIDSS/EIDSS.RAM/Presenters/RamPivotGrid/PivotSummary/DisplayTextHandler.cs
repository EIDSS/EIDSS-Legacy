using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.Views;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.Resources;

namespace EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary
{
    public class DisplayTextHandler
    {
        private readonly string m_UnknownTotal;
        private readonly Dictionary<CustomSummaryType, string> m_GrandTotalCaption;
        private readonly string[] m_MonthValues;
        private readonly string m_TotalString;
        private readonly string m_GrandTotalString;

        private readonly IRamPivotGridView m_RamPivotGrid;

        public DisplayTextHandler(IRamPivotGridView ramPivotGrid)
        {
            Utils.CheckNotNull(ramPivotGrid, "ramPivotGrid");

            m_RamPivotGrid = ramPivotGrid;

            m_UnknownTotal = EidssMessages.Get("msgRamUnknown", "Unknown:");
            m_TotalString = EidssMessages.Get("msgRamTotal", "Total");
            m_GrandTotalString = EidssMessages.Get("msgRamGrandTotal", "Grand Total");

            m_GrandTotalCaption = new Dictionary<CustomSummaryType, string>
                                      {
                                          {CustomSummaryType.Average, EidssMessages.Get("msgRamAverage", "Average")},
                                          {CustomSummaryType.Variance, EidssMessages.Get("msgRamVariance", "Variance")},
                                          {CustomSummaryType.StdDev, EidssMessages.Get("msgRamStdDev", "Standard deviation")}
                                      };
            m_MonthValues = new[]
                                {
                                    EidssMessages.Get("January", "January"),
                                    EidssMessages.Get("February", "February"),
                                    EidssMessages.Get("March", "March"),
                                    EidssMessages.Get("April", "April"),
                                    EidssMessages.Get("May", "May"),
                                    EidssMessages.Get("June", "June"),
                                    EidssMessages.Get("July", "July"),
                                    EidssMessages.Get("August", "August"),
                                    EidssMessages.Get("September", "September"),
                                    EidssMessages.Get("October", "October`"),
                                    EidssMessages.Get("November", "November"),
                                    EidssMessages.Get("December", "December"),
                                };
        }

        public void DisplayStatisticsTotalCaption
            (PivotFieldDisplayTextEventArgsWrapper e, List<CustomSummaryType> summaryTypes)
        {
            if (e.ValueType == PivotGridValueType.Total && (!e.IsColumn))
            {
                string name = (e.Value == null) ? "" : e.Value.ToString();
                e.DisplayText = string.Format("{0} {1}", name, GetGrandTotalDisplayText(summaryTypes, false));
            }
                // Note [ivan] commented to fix _bug 912. 
                // Uncomment it if grand total caption should be replaced by name of aggr function (like average, variance, etc.)
                // Update: Uncommented because it needs to show GrandTotal
            else if (e.ValueType == PivotGridValueType.GrandTotal)
            {
                if ((e.DataField != null) && (e.DisplayText != e.DataField.Caption) && (!e.IsColumn))
                {
                    e.DisplayText = GetGrandTotalDisplayText(summaryTypes, true);
                }
            }
            //
        }

        private string GetGrandTotalDisplayText(IList<CustomSummaryType> types, bool isGrand)
        {
            if (types.Count == 1)
            {
                return GetGrandTotalCaption(types[0], isGrand);
            }

            var typeBuilder = new StringBuilder();
            bool isInserted = false;
            foreach (CustomSummaryType type in types)
            {
                if (isInserted)
                {
                    typeBuilder.AppendFormat(" | {0}", GetGrandTotalCaption(type, isGrand));
                }
                else
                {
                    typeBuilder.Append(GetGrandTotalCaption(type, isGrand));
                }

                isInserted = true;
            }
            return typeBuilder.ToString();
        }

        private string GetGrandTotalCaption(CustomSummaryType type, bool isGrand)
        {
            string text = isGrand ? m_GrandTotalString : m_TotalString;
            return (m_GrandTotalCaption.ContainsKey(type)) ? m_GrandTotalCaption[type] : text;
        }

        public void DisplayProportionText
            (PivotCellDisplayTextEventArgsWrapper e, int denominatorColumn, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.Proportion)
            {
                return;
            }
            if ((denominatorColumn < 0) || (denominatorColumn == e.ColumnIndex))
            {
                return;
            }

            object value = e.GetCellValue(Math.Max(0, denominatorColumn), e.RowIndex);
            double denominator = GetValueFrom(value);
            double numerator = GetValueFrom(e.Value);

            e.DisplayText = (denominator != 0)
                                ? (numerator / denominator).ToString(CustomSummaryHandler.NumberFormat)
                                : m_UnknownTotal;
        }

        public void DisplayDateMonthText(PivotCellDisplayTextEventArgsWrapper e, CustomSummaryType summaryType)
        {
            if ((summaryType == CustomSummaryType.Max || summaryType == CustomSummaryType.Min) &&
                e.DataField != null && e.DataField.GroupInterval == PivotGroupInterval.DateMonth && 
                e.Value is int)
            {
                int monthIndex = (int) e.Value - 1;
                if (monthIndex >= 0 && monthIndex < 12)
                {
                    e.DisplayText = m_MonthValues[monthIndex];
                }
            }
        }

        public void DisplayAsterisk(PivotFieldDisplayTextEventArgsWrapper e)
        {
            if (BaseSettings.ShowAvrAsterisk && Utils.IsEmpty(e.DisplayText))
            {
                e.DisplayText = "*";
            }
        }

        public void DisplayAsterisk(PivotCellDisplayTextEventArgsWrapper e)
        {
            if (BaseSettings.ShowAvrAsterisk && Utils.IsEmpty(e.Value))
            {
                e.DisplayText = "*";
            }
        }

        internal static double GetValueFrom(object value)
        {
            double result = 0;
            if (value != null)
            {
                double.TryParse(value.ToString(), out result);
            }
            return result;
        }
    }
}