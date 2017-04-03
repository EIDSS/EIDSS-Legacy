using System.Drawing;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    public static class InfectiousDiseasesHelper
    {
        public static void CellBeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            if (cell == null)
            {
                return;
            }

            cell.BackColor = (string.IsNullOrEmpty(cell.Text)) ? Color.Silver : Color.Transparent;
            if (cell.Text == 0.ToString())
            {
                cell.Text = string.Empty;
            }
        }

        public static void CellTotalBeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            if (cell == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(cell.Text))
            {
                cell.Text = 0.ToString();
            }
        }

        public static void AjustHeaders
            (ReportHeaderBand headerBand, XRTable baseHeader, XRTable customHeader,
                ReportFooterBand footerBand, bool value)
        {
            const int deltaHeight = 8;
            if (value)
            {
                if (headerBand.Controls.Contains(customHeader))
                {
                    headerBand.Controls.Remove(customHeader);
                }
                if (!headerBand.Controls.Contains(baseHeader))
                {
                    headerBand.Controls.Add(baseHeader);
                }
                headerBand.Height = deltaHeight + baseHeader.Height + baseHeader.Top;
            }
            else
            {
                if (headerBand.Controls.Contains(baseHeader))
                {
                    headerBand.Controls.Remove(baseHeader);
                }
                if (!headerBand.Controls.Contains(customHeader))
                {
                    headerBand.Controls.Add(customHeader);
                }
                headerBand.Height = deltaHeight + customHeader.Height;
            }
            footerBand.Visible = !value;
        }
    }
}