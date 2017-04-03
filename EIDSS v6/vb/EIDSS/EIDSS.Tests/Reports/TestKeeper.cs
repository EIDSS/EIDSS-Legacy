using System;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.Flexible;

namespace EIDSS.Tests.Reports
{
    public delegate FlexReport GenerateReportDelegate();

    public sealed partial class TestKeeper : BaseReportKeeper
    {
        private GenerateReportDelegate m_GenerateReportInjection;

        public TestKeeper()
        {
            InitializeComponent();
        }

        public GenerateReportDelegate GenerateReportInjection
        {
            get { return m_GenerateReportInjection; }
            set { m_GenerateReportInjection = value; }
        }

        protected override XtraReport GenerateReport()
        {
            FlexReport report = m_GenerateReportInjection == null
                                    ? new FlexReport()
                                    : GenerateReportInjection();
            return report;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_HasLoad = true;
            ReloadReport(true);
        }
    }
}