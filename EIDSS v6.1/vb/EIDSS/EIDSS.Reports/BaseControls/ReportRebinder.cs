using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using DevExpress.XtraReports.UI;
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

        public ReportRebinder(XtraReport report, string lang)
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

        public void RebindDateAndFontForReport()
        {
            var labels = new List<XRLabel>();
            GetLabels(labels, m_Report);

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
            if (Lang == Localizer.lngGe || Lang == Localizer.lngThai || Lang == Localizer.lngAr)
            {
                var fontName = BaseSettings.SystemFontName;

                float deltaFontSize = 0;

                if (Lang == Localizer.lngGe || Lang == Localizer.lngAr)
                {
                    fontName = BaseSettings.GGSystemFontName;
                }
                else if (Lang == Localizer.lngThai)
                {
                    fontName = BaseSettings.THReportsFontName;
                    deltaFontSize = BaseSettings.THReportsDeltaFontSize;
                }
                foreach (XRLabel label in labels)
                {
                    if (Utils.Str(label.Tag) != "UnchangebleFont")
                    {
                        Font oldFont = label.Font;
                        if (!oldFont.Name.Contains("IDAutomation"))
                        {
                            label.Font = new Font(fontName, oldFont.Size + deltaFontSize, oldFont.Style);
                        }
                    }
                }
            }
        }

        private void GetLabels(List<XRLabel> labels, XRControl parent)
        {
            if (parent == null)
            {
                return;
            }
            foreach (XRControl child in parent.Controls)
            {
                var label = (child as XRLabel);
                if (label != null)
                {
                    labels.Add(label);
                }

                var subreport = (child as XRSubreport);
                var childControl = subreport != null ? subreport.ReportSource : child;
                GetLabels(labels, childControl);
            }
        }

        public string ToDateString(DateTime dateTime)
        {
            return dateTime.ToString(m_DestFormat, Thread.CurrentThread.CurrentCulture);
        }

        public static string ToDateStringCurrentCulture(DateTime dateTime)
        {
            string destFormat = (CultureInfo.CurrentCulture).DateTimeFormat.ShortDatePattern;
            return dateTime.ToString(destFormat, Thread.CurrentThread.CurrentCulture);
        }

        public string ToTimeString(DateTime dateTime)
        {
            return dateTime.ToString(DefaultTimeFormat, Thread.CurrentThread.CurrentCulture);
        }

        public string ToDateTimeString(DateTime dateTime)
        {
            string format = string.Format("{0} {1}", m_DestFormat, DefaultTimeFormat);
            return dateTime.ToString(format, Thread.CurrentThread.CurrentCulture);
        }
    }
}