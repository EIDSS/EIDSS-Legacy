using System;
using System.Collections.Generic;
using System.Text;
using bv.common.Configuration;
using bv.common.Core;
using DevExpress.XtraPivotGrid;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using eidss.model.Avr.Pivot;
using eidss.model.Resources;

namespace eidss.avr.db.Common
{
    public class DisplayTextHandler
    {
        private readonly Dictionary<CustomSummaryType, string> m_GrandTotalCaption;
        private readonly Dictionary<CustomSummaryType, string> m_TotalCaption;
        private readonly string[] m_MonthValues;
        private readonly string[] m_DayOfWeekValues;
        private readonly string m_TotalString;
        private readonly string m_GrandTotalString;

        public DisplayTextHandler()
        {
            m_TotalString = EidssMessages.Get("msgRamTotal", "Total");
            m_GrandTotalString = EidssMessages.Get("msgRamGrandTotal", "Grand Total");

            m_GrandTotalCaption = new Dictionary<CustomSummaryType, string>
            {
                {CustomSummaryType.Average, EidssMessages.Get("msgRamGrandAverage", "Grand Average")},
                {CustomSummaryType.Variance, EidssMessages.Get("msgRamGrandVariance", "Grand Variance")},
                {CustomSummaryType.StdDev, EidssMessages.Get("msgRamGrandStdDev", "Grand Standard deviation")}
            };

            m_TotalCaption = new Dictionary<CustomSummaryType, string>
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
                EidssMessages.Get("December", "December")
            };

            m_DayOfWeekValues = new[]
            {
                EidssMessages.Get("Monday", "Monday"),
                EidssMessages.Get("Tuesday", "Tuesday"),
                EidssMessages.Get("Wednesday", "Wednesday"),
                EidssMessages.Get("Thursday", "Thursday"),
                EidssMessages.Get("Friday", "Friday"),
                EidssMessages.Get("Saturday", "Saturday"),
                EidssMessages.Get("Sunday", "Sunday")
            };
        }

        public void DisplayStatisticsTotalCaption
            (BasePivotFieldDisplayTextEventArgs e, List<CustomSummaryType> summaryTypes)
        {
            if (e.ValueType == PivotGridValueType.Total)
            {
                if (e.IsColumn)
                {
                    // todo: [ivan] implement correct translation of totals
//                    string name = (e.Value == null) ? "" : e.Value.ToString();
//                    e.DisplayText = string.Format("({0}) {1} {2}", e.DisplayText, name, m_TotalString);
                }
                else
                {
                    string name = (e.Value == null) ? "" : e.Value.ToString();
                    e.DisplayText = string.Format("{0} {1}", name, GetGrandTotalDisplayText(summaryTypes, false));
                }
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
                ? ((m_GrandTotalCaption.ContainsKey(type)) ? m_GrandTotalCaption[type] : m_GrandTotalString)
                : ((m_TotalCaption.ContainsKey(type)) ? m_TotalCaption[type] : m_TotalString);
            return totalCaption;
        }

        public void DisplayCellText(BasePivotCellDisplayTextEventArgs e, CustomSummaryType summaryType, int? precision)
        {
            //format datetime
            var interval = e.GroupInterval;
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
            if ((summaryType == CustomSummaryType.Max || summaryType == CustomSummaryType.Min) &&
                !e.IsDataFieldNull && e.Value is int)
            {
                dontProcessPrecision = interval.IsDate();

                var value = (int) e.Value;
                switch (interval)
                {
                    case PivotGroupInterval.DateMonth:
                        int monthIndex = value - 1;
                        if (monthIndex >= 0 && monthIndex < 12)
                        {
                            e.DisplayText = m_MonthValues[monthIndex];
                            return;
                        }
                        break;
                    case PivotGroupInterval.DateDayOfWeek:
                        int dayIndex = value - 1;
                        if (dayIndex >= 0 && dayIndex < 7)
                        {
                            e.DisplayText = m_DayOfWeekValues[dayIndex];
                            return;
                        }
                        break;
                }
            }
            //// display Asterisk of zero when no value found
            if (Utils.IsEmpty(e.Value))
            {
                if (summaryType != CustomSummaryType.Max && summaryType != CustomSummaryType.Min)
                {
                    e.DisplayText = "0";
                }
                else if (BaseSettings.ShowAvrAsterisk && Utils.IsEmpty(e.Value))
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

        public void DisplayAsterisk(BasePivotCellDisplayTextEventArgs e)
        {
            if (BaseSettings.ShowAvrAsterisk && Utils.IsEmpty(e.Value))
            {
                e.DisplayText = BaseSettings.Asterisk;
            }
        }
    }
}