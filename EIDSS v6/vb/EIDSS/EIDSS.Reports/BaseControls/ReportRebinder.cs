using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using DevExpress.XtraReports.UI;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls
{
    public class ReportRebinder
    {
        private const string InitialFormat = "dd/MM/yyyy";
        private const string DefaultTimeFormat = "HH:mm";
        private readonly string m_DestFormat;
        private readonly string m_DestFormatNational;
        private readonly string m_Lang;
        private readonly XtraReport m_Report;

        public ReportRebinder(string lang, XtraReport report)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNull(report, "report");
            m_Lang = lang;
            m_Report = report;

            string culture = CustomCultureHelper.SupportedLanguages.ContainsKey(lang)
                                 ? CustomCultureHelper.SupportedLanguages[lang]
                                 : "en-US";

            m_DestFormat = (new CultureInfo(culture)).DateTimeFormat.ShortDatePattern;

            
            m_DestFormatNational = m_DestFormat
                .ToLowerInvariant()
                .Replace("yyyy", EidssMessages.Get("msgYearPattern"))
                .Replace("mm", EidssMessages.Get("msgMonthPattern"))
                .Replace("dd", EidssMessages.Get("msgDayPattern"));
        }

        public string Lang
        {
            get { return m_Lang; }
        }

        public string DestFormatNational
        {
            get { return m_DestFormatNational; }
        }

        public static ReportRebinder GetDateRebinder(string lang, XtraReport report)
        {
            return new ReportRebinder(lang, report);
        }


        public void RebindDateAndFontForReport()
        {
            // Get labels on report
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            Type labelType = typeof (XRLabel);
            FieldInfo[] fields = m_Report.GetType().GetFields(flags);
            var labels = new List<XRLabel>();
            foreach (FieldInfo info in fields)
            {
                if (labelType.IsAssignableFrom(info.FieldType))
                {
                    object label = info.GetValue(m_Report);
                    labels.Add((XRLabel) label);
                }
            }

            // change binding for report labels
            foreach (XRLabel label in labels)
            {
                foreach (XRBinding binding in label.DataBindings)
                {
                    if ((!string.IsNullOrEmpty(binding.FormatString)) &&
                        binding.FormatString.Contains(InitialFormat))
                    {
                        binding.FormatString = binding.FormatString.Replace(InitialFormat, m_DestFormat);
                    }
                }
            }

            // change font for report labels
            if (Lang == Localizer.lngGe)
            {
                foreach (XRLabel label in labels)
                {
                    if (Utils.Str(label.Tag) != "UnchangebleFont")
                    {
                        Font oldFont = label.Font;
                        if ((oldFont.Name != "AdvC39c") && (oldFont.Name != "AdvC39d"))
                        {
                            label.Font = new Font(BaseSettings.GGSystemFontName, oldFont.Size, oldFont.Style);
                        }
                    }
                }
            }
        }

        public string ToDateString(DateTime dateTime)
        {
            return dateTime.ToString(m_DestFormat, CultureInfo.InvariantCulture);
        }

        public static string ToDateStringCurrentCulture(DateTime dateTime)
        {
            string destFormat = (CultureInfo.CurrentCulture).DateTimeFormat.ShortDatePattern;
            return dateTime.ToString(destFormat, CultureInfo.InvariantCulture);
        }

        public string ToTimeString(DateTime dateTime)
        {
            return dateTime.ToString(DefaultTimeFormat, CultureInfo.InvariantCulture);
        }

        public string ToDateTimeString(DateTime dateTime)
        {
            string format = string.Format("{0} {1}", m_DestFormat, DefaultTimeFormat);
            return dateTime.ToString(format, CultureInfo.InvariantCulture);
        }
    }
}
