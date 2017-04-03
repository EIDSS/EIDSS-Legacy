using DevExpress.XtraReports.UI;

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
    }
}