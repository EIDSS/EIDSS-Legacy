using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using bv.common.Core;
using bv.winclient.Core;

namespace EIDSS.Reports.Factory
{
    public class ReportRtlHelper : RtlHelper
    {
        public static void SetRTL(XtraReport report)
        {
            if (!Localizer.IsRtl)
            {
                return;
            }
            foreach (object ctl in report.Controls)
            {
                var xrControl = ctl as XRControl;
                if (xrControl != null)
                {
                    ApplyRTL(xrControl);
                }
                else
                {
                    var control = ctl as Control;
                    if (control != null)
                    {
                        ApplyRTL(control);
                    }
                }
            }
        }

        private static void ApplyRTL(XRControl parentControl)
        {
            if (parentControl == null)
                return;

            parentControl.SuspendLayout();
            //            ((System.ComponentModel.ISupportInitialize)(parentControl)).BeginInit();
            var row = parentControl as XRTableRow;
            if (row != null)
            {
                ReverseXRTableRow(row);
            }
            var subreport = parentControl as XRSubreport;
            if (subreport != null)
            {
                ApplyRTL(subreport.ReportSource);
            }
            foreach (XRControl control in parentControl.Controls)
            {
                Size parentSize = parentControl.Size;
                var band = parentControl as Band;
                if (band != null)
                {
                    XtraReportBase reportBase = band.Report;
                    while (reportBase != null && !(reportBase is XtraReport))
                    {
                        reportBase = reportBase.Report;
                    }
                    var report = reportBase as XtraReport;
                    if (report != null)
                    {
                        parentSize = new Size(report.PageWidth - report.Margins.Left - report.Margins.Right, band.Height);
                    }
                }

                control.Location = CalculateRTL(control.Location, parentSize, control.Size);
                control.TextAlignment = CalculateTextAlignment(control.TextAlignment);
                ReverseBorders(control);
                ReversePadding(control);

                ApplyRTL(control);
            }
            //((System.ComponentModel.ISupportInitialize)(parentControl)).EndInit();
            parentControl.ResumeLayout();
        }


        private static void ReverseXRTableRow(XRTableRow row)
        {
            XRControl[] cells = row.Controls.Cast<XRControl>().Reverse().ToArray();
            row.Controls.Clear();
            row.Controls.AddRange(cells);
        }

        private static TextAlignment CalculateTextAlignment(TextAlignment align)
        {
            switch (align)
            {
                case TextAlignment.BottomLeft:
                    return TextAlignment.BottomRight;
                case TextAlignment.BottomRight:
                    return TextAlignment.BottomLeft;
                case TextAlignment.MiddleLeft:
                    return TextAlignment.MiddleRight;
                case TextAlignment.MiddleRight:
                    return TextAlignment.MiddleLeft;
                case TextAlignment.TopLeft:
                    return TextAlignment.TopRight;
                case TextAlignment.TopRight:
                    return TextAlignment.TopLeft;
                default:
                    return align;
            }
        }

        private static void ReverseBorders(XRControl control)
        {
            bool isLeft = (control.Borders & BorderSide.Left) == BorderSide.Left;
            bool isRight = (control.Borders & BorderSide.Right) == BorderSide.Right;

            if (isLeft != isRight)
            {
                control.Borders = control.Borders ^ BorderSide.Left ^ BorderSide.Right;
            }
        }

        private static void ReversePadding(XRControl control)
        {
            var pd = control.Padding;
            if (pd.Left != pd.Right)
            {
                control.Padding = new PaddingInfo(pd.Right, pd.Left, pd.Top, pd.Bottom);
            }
        }
    }
}
