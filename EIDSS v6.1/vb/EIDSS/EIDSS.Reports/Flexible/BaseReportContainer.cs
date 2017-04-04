using System.Collections.Generic;
using bv.common.Core;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Flexible
{
    public abstract  class BaseReportContainer
    {
        private readonly XRControl m_ParentControl;
        private readonly List<XtraReportBase> m_Reports = new List<XtraReportBase>();
        private readonly List<XRSubreport> m_Subreports = new List<XRSubreport>();

        protected BaseReportContainer(XRControl parentControl)
        {
            Utils.CheckNotNull(parentControl, "parentControl");

            m_ParentControl = parentControl;
        }

        public XRControl ParentControl
        {
            get { return m_ParentControl; }
        }

        public List<XRSubreport> Subreports
        {
            get { return m_Subreports; }
        }

        public List<XtraReportBase> Reports
        {
            get { return m_Reports; }
        }

        protected virtual void ClearFFSubreports()
        {
            foreach (XRSubreport oldSubreport in m_Subreports)
            {
                m_ParentControl.Controls.Remove(oldSubreport);
            }
            m_Subreports.Clear();
        }

        protected XRSubreport CreateSubreport(long observation)
        {
            var subreport = new XRSubreport();
            m_Subreports.Add(subreport);
            m_ParentControl.Controls.Add(subreport);

            subreport.Name = "xrSubreport_" + observation;
            subreport.SendToBack();
            return subreport;
        }
    }
}