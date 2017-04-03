using System;
using System.Drawing.Imaging;
using System.IO;
using DevExpress.XtraReports.UI;
using eidss.model.Enums;

namespace EIDSS.Reports.BaseControls
{
    public static class XtraReportExtender
    {
        public static void RebindDateAndFont(this XtraReport report, string lang)
        {
            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(lang, report);
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
                        throw new ArgumentException(string.Format("Unsupported export type {0}", exportType));
                }
                stream.Flush();
                return stream.ToArray();
            }
        }
    }
}