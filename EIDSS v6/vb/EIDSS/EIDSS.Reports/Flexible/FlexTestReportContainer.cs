using System.Collections.Generic;
using System.Drawing;
using bv.common.Core;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Flexible
{
    public class FlexTestReportContainer
    {
        private int m_Index;

        private readonly XRControl m_ParentControl;
        private readonly List<FlexReport> m_TestCaseFFReports = new List<FlexReport>();
        private readonly List<XRSubreport> m_Subreports = new List<XRSubreport>();
        private readonly Size m_SubreportSize;
        private readonly Point m_SubreportLocation;

        public FlexTestReportContainer(XRControl parentControl, Size subreportSize, Point subreportLocation)
        {
            Utils.CheckNotNull(parentControl, "parentControl");

            m_ParentControl = parentControl;
            m_SubreportSize = subreportSize;
            m_SubreportLocation = subreportLocation;
        }

        public void SetObservations(IEnumerable<long> observationList, long? determinant)
        {
            ClearFFSubreports();

            foreach (long observation in observationList)
            {
                AddFFSubreport(observation, determinant);
            }
        }

        public void SetObservations(Dictionary<long, long> observationDeterminants)
        {
            ClearFFSubreports();

            foreach (KeyValuePair<long, long> observationDeterminant in observationDeterminants)
            {
                AddFFSubreport(observationDeterminant.Key, observationDeterminant.Value);
            }
        }

        public void BeforePrintNextReport()
        {
            int maximum = m_TestCaseFFReports.Count;
            for (int index = 0; index < maximum; index++)
            {
                m_TestCaseFFReports[index].Visible = (index == m_Index % maximum);
            }
            m_Index++;
        }

        private void ClearFFSubreports()
        {
            m_Index = 0;
            foreach (XRSubreport oldSubreport in m_Subreports)
            {
                m_ParentControl.Controls.Remove(oldSubreport);
            }
            m_Subreports.Clear();
        }

        private void AddFFSubreport(long observation, long? determinant)
        {
            var subreport = new XRSubreport();
            m_Subreports.Add(subreport);
            m_ParentControl.Controls.Add(subreport);

            subreport.Name = "xrSubreport_" + observation;
            subreport.Location = m_SubreportLocation;
            subreport.Size = m_SubreportSize;
            subreport.SendToBack();

            FlexFactory.CreateLimTestReport(subreport, observation, determinant);
            m_TestCaseFFReports.Add((FlexReport) subreport.ReportSource);
        }
    }
}