using System;
using bv.common.Core;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class ErrorReport : XtraReport
    {
        public ErrorReport()
        {
            InitializeComponent();
        }

        public ErrorReport(Exception ex) : this()
        {
            Utils.CheckNotNull(ex, "ex");
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string StackTrace
        {
            get { return lblStackTrace.Text; }
            set { lblStackTrace.Text = value; }
        }
    }
}