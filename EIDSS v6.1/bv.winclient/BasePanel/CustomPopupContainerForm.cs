using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;

namespace bv.winclient.BasePanel
{
    public class CustomPopupContainerForm : PopupContainerForm
    {
        public CustomPopupContainerForm(PopupContainerEdit ownerEdit) : base(ownerEdit) { }


        public override bool AllowMouseClick(Control control, Point mousePosition)
        {
            return false;
        }
    }
}
