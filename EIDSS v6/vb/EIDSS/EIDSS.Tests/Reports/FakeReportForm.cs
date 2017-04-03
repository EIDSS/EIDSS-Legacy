using System;
using System.Windows.Forms;
using EIDSS.Reports.BaseControls.Form;

namespace EIDSS.Tests.Reports
{
    public class FakeReportForm : IReportForm
    {
        public event FormClosedEventHandler FormClosed;

        public void ShowReport(Control reportKeeper)
        {
        }

        public void ApplyResources()
        {
            
        }

        public void Close()
        {
            
        }
    }
}