using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Control;

namespace EIDSS.Reports.BaseControls
{
    public class ReportPrintControl : PrintControl
    {
        public HScrollBar HScrollBar
        {
            get { return hScrollBar; }
            set { hScrollBar = value; }
        }

        public VScrollBar VScrollBar
        {
            get { return vScrollBar; }
            set { vScrollBar = value; }
        }

    }
}