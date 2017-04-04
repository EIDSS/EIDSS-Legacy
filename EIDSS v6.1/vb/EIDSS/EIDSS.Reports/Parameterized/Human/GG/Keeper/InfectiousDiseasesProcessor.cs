using System;
using eidss.model.Reports;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public static class InfectiousDiseasesProcessorExtender
    {
        public static Type GetReportType(this InfectiousDiseasesProcessor processor)
        {
            switch (processor.Version)
            {
                case ReportVersion.Version4:
                    return typeof (InfectiousDiseasesMonthV4);
                case ReportVersion.Version5:
                    return typeof (InfectiousDiseasesMonthV5);
                case ReportVersion.Version6:
                    return typeof (InfectiousDiseasesMonthV6);
                case ReportVersion.Version61:
                    return typeof (InfectiousDiseasesMonthV61);
                default:
                    throw new NotSupportedException(string.Format("Unsupported report version {0}", processor.Version));
            }
        }
    }
}