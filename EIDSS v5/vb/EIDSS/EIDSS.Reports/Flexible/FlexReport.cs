
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Flexible
{
    public partial class FlexReport : XtraReport
    {
        public FlexReport()
        {
            InitializeComponent();
            labelText.Height = 0;
 // Note: for  debug only
//            for (int i = 0; i < 17; i++)
//            {
//                XRLabel label = new XRLabel();
//                label.Text = (i * 100).ToString();
//
//                label.Borders = DevExpress.XtraPrinting.BorderSide.All;
//
//                label.Top = 200 + (i % 2) * 10;
//                label.Left = 100 * i;
//                label.Width = 100;
//                label.Height = 10;
//                HeaderBand.Controls.Add(label);
//            }
        }

        public DetailBand DetailBand
        {
            get { return Detail; }
        }

        public ReportHeaderBand HeaderBand
        {
            get { return ReportHeader; }
        }

        public override string Text
        {
            get { return labelText.Text; }
            set
            {
                labelText.Text = value;
                labelText.Visible = (!string.IsNullOrEmpty(value));
                labelText.Height = labelText.Visible ? 25 : 0;
            }
        }

        public new int Width
        {
            get { return PageWidth; }
            set
            {
                PageWidth = value;
                
                int innerWidth = value - Margins.Left - Margins.Right;
                labelText.Width = innerWidth;
               // BorderBox.Width = innerWidth;
            }
        }
    }
}