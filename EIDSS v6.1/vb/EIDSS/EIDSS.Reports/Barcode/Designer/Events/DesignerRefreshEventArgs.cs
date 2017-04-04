using System;
using bv.common;
using bv.common.Core;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Barcode.Designer.Events
{
    public class DesignerRefreshEventArgs : EventArgs
    {
        private readonly XtraReport m_Report;
        private readonly string m_LabelText;

        public DesignerRefreshEventArgs(XtraReport report, string labelText)
        {
            Utils.CheckNotNull(report, "report");

            m_Report = report;
            m_LabelText = labelText;
        }

        public XtraReport Report
        {
            get { return m_Report; }
        }

        public string LabelText
        {
            get { return m_LabelText; }
        }
    }
}