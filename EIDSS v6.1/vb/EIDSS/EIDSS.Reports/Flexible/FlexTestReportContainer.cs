using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Flexible
{
    public class FlexTestReportContainer : BaseTestReportContainer
    {
        public FlexTestReportContainer(XRControl parentControl, Size subreportSize, Point subreportLocation)
            : base(parentControl, subreportSize, subreportLocation)
        {
        }

        public void SetObservations(IEnumerable<long> observationList, long? determinant)
        {
            ClearFFSubreports();

            foreach (long observation in observationList)
            {
                AddFFSubreport(observation, determinant);
            }
        }

        public void SetObservations(List<KeyValuePair<long, long>> observationDeterminants)
        {
            ClearFFSubreports();

            foreach (KeyValuePair<long, long> observationDeterminant in observationDeterminants)
            {
                AddFFSubreport(observationDeterminant.Key, observationDeterminant.Value);
            }
        }

        private void AddFFSubreport(long observation, long? determinant)
        {
            XRSubreport subreport = CreateSubreport(observation);
            subreport.Location = SubreportLocation;
            subreport.Size = SubreportSize;

            FlexFactory.CreateLimTestReport(subreport, observation, determinant);
            Reports.Add(subreport.ReportSource);
        }
    }
}