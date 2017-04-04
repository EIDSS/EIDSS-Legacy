using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using bv.common.Core;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using bv.winclient.BasePanel;

namespace bv.winclient.Core
{
    public class RtlHelper
    {
        public static void SetRTL(Control ctl, bool stepInForm = false)
        {
            if (!Localizer.IsRtl)
            {
                return;
            }
            var form = ctl as Form;
            if (form != null)
            {
                form.SuspendLayout();
                form.RightToLeft = RightToLeft.Yes;
                form.RightToLeftLayout = true;
                form.ResumeLayout();
                if(!stepInForm)
                    return;
            }
           ApplyRTL(ctl);
        }

        protected static void ApplyRTL(Control ctl, bool recalcLocation = true)
        {
            if (ctl == null)
                return;
            ctl.SuspendLayout();
            var appForm = ctl as IApplicationForm;
            if (appForm != null)
                appForm.RtlRecalcWidth = ctl.Width;
            var basePanel = ctl as IBasePanel;
            if (basePanel != null && basePanel.IsRtlApplied)
                recalcLocation = false;
            ctl.RightToLeft = RightToLeft.Yes;
            
            if (ctl.Parent != null && recalcLocation)
                ctl.Location = CalculateRTL(ctl.Location, ctl.Parent.ClientSize, ctl.Size);
            if (ctl.Dock == DockStyle.None)
            {
                var anchor = ctl.Anchor & (AnchorStyles.Top | AnchorStyles.Bottom);
                if ((ctl.Anchor & AnchorStyles.Left) == AnchorStyles.Left)
                    anchor |= AnchorStyles.Right;
                if ((ctl.Anchor & AnchorStyles.Right) == AnchorStyles.Right)
                    anchor |= AnchorStyles.Left;
                ctl.Anchor = anchor;
            }
            //Type type = Type.GetType("bv.common.win.BaseLookupForm, bvwin_common, Version=6.0.72.54, Culture=neutral, PublicKeyToken=null");
            //if (type != null && ctl.GetType().IsSubclassOf(type))
            //{
            //    return;
            //}
            var split = ctl as SplitContainer;
            if (split != null)
            {
                ApplyRTL(split.Panel1, false);
                ApplyRTL(split.Panel2, false);
            }
            else if (!(ctl is BaseEdit))
            {
                foreach (Control control in ctl.Controls)
                {
                    ApplyRTL(control);
                }
            }
            var btn = ctl as SimpleButton;
            if (btn != null)
                btn.ImageLocation = ImageLocation.MiddleRight;
            ctl.ResumeLayout();
            if (basePanel != null)
                basePanel.IsRtlApplied = true;
        }

        protected static Point CalculateRTL(Point location, Size parentSize, Size currentSize)
        {
            return new Point(parentSize.Width - currentSize.Width - location.X, location.Y);
        }
    }
}