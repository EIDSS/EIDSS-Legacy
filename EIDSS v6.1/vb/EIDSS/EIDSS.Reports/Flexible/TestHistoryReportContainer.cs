using System.Collections.Generic;
using System.Drawing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.Document.Lim.Case;

namespace EIDSS.Reports.Flexible
{
    public class TestHistoryReportContainer : BaseTestReportContainer
    {
        public TestHistoryReportContainer(XRControl parentControl, Size subreportSize, Point subreportLocation)
            : base(parentControl, subreportSize, subreportLocation)
        {
        }

        public void SetIdList(string lang, IEnumerable<long> idList, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            ClearFFSubreports();

            foreach (long id in idList)
            {
                XRSubreport subreport = CreateSubreport(id);
                subreport.Location = SubreportLocation;
                subreport.Size = SubreportSize;
                var report = new TestAmendmentHistoryReport();
                report.SetParameters(lang, id, manager, archiveManager);
                subreport.ReportSource = report;
                Reports.Add(report);
                report.SetAdaptersNull();
            }
        }
    }
}