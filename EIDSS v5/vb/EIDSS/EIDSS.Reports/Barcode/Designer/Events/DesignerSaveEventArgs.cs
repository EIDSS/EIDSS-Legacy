using System;
using bv.common;
using bv.common.Core;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Barcode.Designer.Events
{
    public class DesignerSaveEventArgs : EventArgs
    {
        private readonly XtraReport m_Report;

        public DesignerSaveEventArgs(XtraReport report)
        {
            Utils.CheckNotNull(report, "report");

            m_Report = report;
        }

        public XtraReport Report
        {
            get { return m_Report; }
        }
    }
}