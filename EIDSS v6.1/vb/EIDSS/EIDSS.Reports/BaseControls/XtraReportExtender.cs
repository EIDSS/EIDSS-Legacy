using System;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using DevExpress.XtraReports.UI;
using eidss.model.Enums;
using eidss.model.Reports;

namespace EIDSS.Reports.BaseControls
{
    public static class XtraReportExtender
    {
        public static void SetAdaptersNull(this XtraReport report)
        {
            Type reportType = report.GetType();
            object[] attributes = reportType.GetCustomAttributes(typeof (NullableAdaptersAttribute), true);
            if (attributes.Length > 0)
            {
                report.DataAdapter = null;

                // Get labels on report
                const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
                Type childReportType = typeof (XtraReportBase);
                Type subreportType = typeof (XRSubreport);
                FieldInfo[] fields = report.GetType().GetFields(flags);

                foreach (FieldInfo info in fields)
                {
                    if (childReportType.IsAssignableFrom(info.FieldType))
                    {
                        object child = info.GetValue(report);

                        ((XtraReportBase) child).DataAdapter = null;
                    }
                    if (subreportType.IsAssignableFrom(info.FieldType))
                    {
                        object subreport = info.GetValue(report);
                        XtraReport child = ((XRSubreport) subreport).ReportSource;
                        if (child != null)
                        {
                            child.SetAdaptersNull();
                        }
                    }
                }
            }
        }

        public static ReportRebinder GetDateRebinder(this XtraReport report, string lang)
        {
            return new ReportRebinder(report, lang);
        }

        public static void RebindDateAndFont(this XtraReport report, string lang)
        {
            ReportRebinder rebinder = report.GetDateRebinder(lang);
            rebinder.RebindDateAndFontForReport();
        }

        public static void RebindAccessRigths(this XtraReport report)
        {
            var rebinder = new AccessRigthsRebinder(report);
            rebinder.Process();
        }

        public static byte[] ExportToBytes(this XtraReport report, ReportExportType exportType)
        {
            using (var stream = new MemoryStream())
            {
                switch (exportType)
                {
                    case ReportExportType.Xlsx:
                        report.ExportToXlsx(stream);
                        break;
                    case ReportExportType.Jpeg:
                        report.ExportToImage(stream, ImageFormat.Jpeg);
                        break;
                    case ReportExportType.Pdf:
                        report.ExportToPdf(stream);
                        break;
                    case ReportExportType.Rtf:
                        report.ExportToRtf(stream);
                        break;
                    default:
                        throw new ArgumentException(String.Format("Unsupported export type {0}", exportType));
                }
                stream.Flush();
                return stream.ToArray();
            }
        }
    }
}