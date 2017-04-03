using bv.common.Core;
using DevExpress.XtraReports.UI;
using eidss.model.Resources;

namespace EIDSS.RAM.Components
{
    public partial class PivotReport : XtraReport
    {
        public PivotReport()
        {
            InitializeComponent();
            lblParamName.Text = EidssMessages.Get("msgReportParameters", "Parameters:");
        }

        public RamPivotReportGrid PivotGrid
        {
            get { return xrPivotGrid; }
        }

        public string HeaderText
        {
            get { return lblReportHeader.Text; }
            set
            {
                if (Utils.IsEmpty(value))
                {
                    value = EidssMessages.Get("msgNoReportHeader", "[Untitled]");
                }
                lblHeader.Text = value;
                lblReportHeader.Text = value;
            }
        }

        public string FilterText
        {
            get { return lblParamValue.Text; }
            set
            {
                lblParamName.Visible = !Utils.IsEmpty(value);
                lblParamValue.Text = value;
            }
        }

        public string Footer
        {
            get { return lblFooter.Text; }
            set { lblFooter.Text = value; }
        }
    }
}