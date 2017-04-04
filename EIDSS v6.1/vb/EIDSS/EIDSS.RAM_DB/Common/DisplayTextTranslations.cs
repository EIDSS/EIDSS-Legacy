using System.Collections.Generic;
using eidss.model.Avr.Pivot;
using eidss.model.Resources;

namespace eidss.avr.db.Common
{
    public class DisplayTextTranslations
    {
        private Dictionary<CustomSummaryType, string> m_GrandTotalCaption;
        private Dictionary<CustomSummaryType, string> m_TotalCaption;
        private Dictionary<bool, string> m_Boolean;
        private string[] m_MonthValues;
        private string[] m_DayOfWeekValues;
        private string m_TotalString;
        private string m_GrandTotalString;
        private string m_NotAvaliable;

        public string[] DayOfWeekValues
        {
            get
            {
                return m_DayOfWeekValues ?? (m_DayOfWeekValues = new[]
                {
                    EidssMessages.Get("Monday", "Monday"),
                    EidssMessages.Get("Tuesday", "Tuesday"),
                    EidssMessages.Get("Wednesday", "Wednesday"),
                    EidssMessages.Get("Thursday", "Thursday"),
                    EidssMessages.Get("Friday", "Friday"),
                    EidssMessages.Get("Saturday", "Saturday"),
                    EidssMessages.Get("Sunday", "Sunday")
                });
            }
        }

        public string[] MonthValues
        {
            get
            {
                return m_MonthValues ?? (m_MonthValues = new[]
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
                });
            }
        }

        public Dictionary<bool, string> BooleanValues
        {
            get
            {
                return m_Boolean ?? (m_Boolean = new Dictionary<bool, string>
                {
                    {true, EidssMessages.Get("TrueValue", "True")},
                    {false, EidssMessages.Get("FalseValue", "False")},
                });
            }
        }

        public string NotAvaliable
        {
            get { return m_NotAvaliable ?? (m_NotAvaliable = EidssMessages.Get("strErrorCustomAggregate", "N/A")); }
        }


        public string GrandTotalString
        {
            get { return m_GrandTotalString ?? (m_GrandTotalString = EidssMessages.Get("msgRamGrandTotal", "Grand Total")); }
        }

        public string TotalString
        {
            get { return m_TotalString ?? (m_TotalString = EidssMessages.Get("msgRamTotal", "Total")); }
        }

        public Dictionary<CustomSummaryType, string> GrandTotalCaption
        {
            get
            {
                return m_GrandTotalCaption ?? (m_GrandTotalCaption = new Dictionary<CustomSummaryType, string>
                {
                    {CustomSummaryType.Average, EidssMessages.Get("msgRamGrandAverage", "Grand Average")},
                    {CustomSummaryType.Variance, EidssMessages.Get("msgRamGrandVariance", "Grand Variance")},
                    {CustomSummaryType.StdDev, EidssMessages.Get("msgRamGrandStdDev", "Grand Standard deviation")}
                });
            }
        }

        public Dictionary<CustomSummaryType, string> TotalCaption
        {
            get
            {
                return m_TotalCaption ?? (m_TotalCaption = new Dictionary<CustomSummaryType, string>
                {
                    {CustomSummaryType.Average, EidssMessages.Get("msgRamAverage", "Average")},
                    {CustomSummaryType.Variance, EidssMessages.Get("msgRamVariance", "Variance")},
                    {CustomSummaryType.StdDev, EidssMessages.Get("msgRamStdDev", "Standard deviation")}
                });
            }
        }
    }
}