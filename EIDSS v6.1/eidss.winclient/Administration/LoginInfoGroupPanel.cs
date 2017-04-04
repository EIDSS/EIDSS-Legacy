using System.Collections.Generic;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class LoginInfoGroupPanel : BaseGroupPanel_LoginInfo
    {
        public LoginInfoGroupPanel()
        {
            InitializeComponent();
            TopPanelVisible = true;
            EditByDoubleClick = true;
            this.ActionButtonStateChanged+=LoginInfoGroupPanel_ActionButtonStateChanged;
        }

        private void LoginInfoGroupPanel_ActionButtonStateChanged(object sender, ActionButtonEventArgs<IObject> e)
        {
            var action = e.Button.Tag as ActionMetaItem;
            if (action != null && action.ActionType == ActionTypes.Create)
                e.Button.Enabled = (e.Button.Enabled && Grid.GridView.RowCount == 0);
        }

        public long idfPerson { get; set; }

      
    }
}
