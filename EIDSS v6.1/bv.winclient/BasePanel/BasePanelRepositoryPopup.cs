using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using bv.model.Model.Core;

namespace bv.winclient.BasePanel
{
    public class BasePanelRepositoryPopup : RepositoryItemPopupContainerEdit
    {
        private readonly BasePanelPopupHelper m_Helper;

        public delegate IObject GetBusinessObjectHandler();

        public BasePanelRepositoryPopup(GridColumn col, GetBusinessObjectHandler getRowObject)
        {
            m_Helper = new BasePanelPopupHelper(this, col, getRowObject);
            base.ReadOnly = false;
            base.TextEditStyle = TextEditStyles.DisableTextEditor;
        }
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPopupControl PopupPanel
        {
            get { return m_Helper.PopupControl; }
            set { m_Helper.PopupControl = value; }
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ValidationFieldName { get; set; }
        

    }
}
