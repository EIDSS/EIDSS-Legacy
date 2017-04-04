using System;
using System.Collections.Generic;
using System.Text;
using bv.common.Configuration;
using bv.common.Core;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using eidss.model.Avr.Pivot;
using eidss.model.Avr.View;

namespace eidss.avr.db.Common
{
    public class DisplayTextHandler
    {
        private readonly DisplayTextTranslations m_Translations = new DisplayTextTranslations();

        public void DisplayStatisticsTotalCaption
            (BasePivotFieldDisplayTextEventArgs e, List<CustomSummaryType> summaryTypes)
        {
            if (e.ValueType == PivotGridValueType.Total && !e.IsColumn)
            {
                    string name = (e.Value == null) ? "" : e.Value.ToString();
                    e.DisplayText = string.Format("{0} {1}", name, GetGrandTotalDisplayText(summaryTypes, false));
            }
            else if (e.ValueType == PivotGridValueType.GrandTotal)
            {
                if ((e.DataField != null) && (e.DisplayText != e.DataField.Caption) && (!e.IsColumn))
                {
                    e.DisplayText = GetGrandTotalDisplayText(summaryTypes, true);
                }
            }
        }

        public string GetGrandTotalDisplayText(IList<CustomSummaryType> types, bool isGrand)
        {
            if (types.Count == 1)
            {
                return GetTotalCaption(types[0], isGrand);
            }

            var typeBuilder = new StringBuilder();
            bool isInserted = false;
            foreach (CustomSummaryType type in types)
            {
                if (isInserted)
                {
                    typeBuilder.AppendFormat(" | {0}", GetTotalCaption(type, isGrand));
                }
                else
                {
                    typeBuilder.Append(GetTotalCaption(type, isGrand));
                }

                isInserted = true;
            }
            return typeBuilder.ToString();
        }

        private string GetTotalCaption(CustomSummaryType type, bool isGrand)
        {
            string totalCaption = isGrand
                ? ((m_Translations.GrandTotalCaption.ContainsKey(type))
                    ? m_Translations.GrandTotalCaption[type]
                    : m_Translations.GrandTotalString)
                : ((m_Translations.TotalCaption.ContainsKey(type)) ? m_Translations.TotalCaption[type] : m_Translations.TotalString);
            return totalCaption;
        }

        public void DisplayCellText(BasePivotCellDisplayTextEventArgs e, CustomSummaryType summaryType, int? precision)
        {
            //format datetime
            PivotGroupInterval interval = e.GroupInterval;
            if (e.Value is DateTime)
            {
                var date = ((DateTime) e.Value);
                int formattedResult;
                // it's workaround for old devexpress
                // probably in devexpress 12 it doesn't needed
                if (date.TryToInt(interval, out formattedResult))
                {
                    e.DisplayText = precision.HasValue && precision.Value >= 0
                        ? ValueToString(formattedResult, precision.Value)
                        : formattedResult.ToString();
                    return;
                }
                //
                e.DisplayText = date.ToString(interval);
                return;
            }

            bool dontProcessPrecision = false;
            //display month or day of the week name
            if ((summaryType.IsMinMax()) &&
                !e.IsDataFieldNull &&
                (e.Value is int || e.Value is DayOfWeek))
            {
                dontProcessPrecision = interval.IsDate();
                var value = (int) e.Value;
                switch (interval)
                {
                    case PivotGroupInterval.DateMonth:
                        int monthIndex = value - 1;
                        if (monthIndex >= 0 && monthIndex < 12)
                        {
                            e.DisplayText = m_Translations.MonthValues[monthIndex];
                            return;
                        }
                        break;
                    case PivotGroupInterval.DateDayOfWeek:
                        int dayIndex = value - 1;
                        if (dayIndex >= 0 && dayIndex < 7)
                        {
                            e.DisplayText = m_Translations.DayOfWeekValues[dayIndex];
                            return;
                        }
                        break;
                }
            }
            //display bool value
            if (summaryType.IsMinMax() && e.Value is bool)
            {
                e.DisplayText = m_Translations.BooleanValues[(bool) e.Value];
            }
            //// display Asterisk of zero  or N/A when no value found
            if (Utils.IsEmpty(e.Value))
            {
//                e.DisplayText = BaseSettings.Asterisk;
//                return;
                if (summaryType.IsAdmUnitOrGender())
                {
                    e.DisplayText = e.HasDrillDownDataSource 
                        ? m_Translations.NotAvaliable 
                        : "0";
                }
                else if (!summaryType.IsMinMax())
                {
                    e.DisplayText = "0";
                }
                else if (BaseSettings.ShowAvrAsterisk)
                {
                    e.DisplayText = BaseSettings.Asterisk;
                }
                return;
            }

            if (precision.HasValue && precision.Value >= 0 && !dontProcessPrecision)
            {
                // display numbers with presision
                e.DisplayText = ValueToString(e.Value, precision.Value);
            }
        }

        public static string ValueToString(object value, int precision)
        {
            if (precision > 16 || precision < 0)
            {
                throw new ArgumentOutOfRangeException("precision", "Argument should have value from 0 to 16");
            }

            string format = "N" + precision; //m_NumberFormats[precision]);

            if ((value is double) || (value is float))
            {
                return ((double) value).ToString(format);
            }
            if (value is decimal)
            {
                return ((decimal) value).ToString(format);
            }
            if (value is long)
            {
                return ((long) value).ToString(format);
            }
            if (value is int)
            {
                return ((int) value).ToString(format);
            }
            return (value == null) ? string.Empty : value.ToString();
        }

        public void DisplayAsterisk(BasePivotFieldDisplayTextEventArgs e)
        {
            if (BaseSettings.ShowAvrAsterisk && Utils.IsEmpty(e.DisplayText))
            {
                e.DisplayText = BaseSettings.Asterisk;
            }
        }

        public void DisplayBool(BasePivotFieldDisplayTextEventArgs e)
        {
            if (e.Value is bool)
            {
                e.DisplayText = m_Translations.BooleanValues[(bool) e.Value];
            }
        }

        public void DisplayAsterisk(BasePivotCellDisplayTextEventArgs e)
        {
            if (BaseSettings.ShowAvrAsterisk && Utils.IsEmpty(e.Value))
            {
                e.DisplayText = BaseSettings.Asterisk;
            }
        }

        public void DisplayAsterisk(AvrViewColumn column, BaseGridViewCellDisplayTextEventArgs e)
        {
            if (column.IsAggregate || column.CustomSummaryType.IsAdmUnitOrGender())
            {
                if (e.Value == DBNull.Value ||
                    (e.Value is double && (double.IsNaN((double)e.Value) || double.IsInfinity((double)e.Value))))
                {
                    e.DisplayText = m_Translations.NotAvaliable;
                }
            }
            else if (e.Value == DBNull.Value && BaseSettings.ShowAvrAsterisk)
            {
                e.DisplayText = "*";
            }
        }

    }

}