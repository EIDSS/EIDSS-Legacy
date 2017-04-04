using System.ComponentModel;
using DevExpress.XtraGrid;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    class BvGridControl : GridControl
    {
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowCustomization { get; set; }
    }
}
