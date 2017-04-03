using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;

namespace bv.winclient.BasePanel
{
    public class CustomPopupContainerEdit : PopupContainerEdit
    {
        static CustomPopupContainerEdit()
        {
            RepositoryItemCustomPopupContainerEdit.RegisterCustomEdtor();
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemCustomPopupContainerEdit.CustomName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomPopupContainerEdit Properties
        {
            get { return (RepositoryItemCustomPopupContainerEdit)base.Properties; }
        }

        protected override PopupBaseForm CreatePopupForm()
        {
            return Properties.PopupControl == null ? null : new CustomPopupContainerForm(this);
        }
    }
}
