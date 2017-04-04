using System.Drawing;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Flexible
{
    public class BaseTestReportContainer : BaseReportContainer
    {
        private int m_Index;
        private readonly Size m_SubreportSize;
        private readonly Point m_SubreportLocation;

        public BaseTestReportContainer(XRControl parentControl, Size subreportSize, Point subreportLocation) : base(parentControl)
        {
            m_SubreportSize = subreportSize;
            m_SubreportLocation = subreportLocation;
        }

        public int Index
        {
            get { return m_Index; }
        }

        protected Point SubreportLocation
        {
            get { return m_SubreportLocation; }
        }


        protected Size SubreportSize
        {
            get { return m_SubreportSize; }
        }

        public void BeforePrintNextReport()
        {
            int maximum = Reports.Count;
            for (int index = 0; index < maximum; index++)
            {
                Reports[index].Visible = (index == m_Index % maximum);
            }
            m_Index++;
        }

        public void HideNextReport()
        {
            foreach (FlexReport report in Reports)
            {
                report.Visible = false;
            }
            m_Index++;
        }

        protected override void ClearFFSubreports()
        {
            base.ClearFFSubreports();
            m_Index = 0;
        }

       
    }
}