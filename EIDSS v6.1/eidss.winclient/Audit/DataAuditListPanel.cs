using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Audit
{
    public partial class DataAuditListPanel : BaseListPanel_DataAuditListItem
    {
        public DataAuditListPanel()
        {
            InitializeComponent();
        }

        public static void Register(Control parentControl)
        {
            if (BaseFormManager.ArchiveMode)
                return;
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Security,
                           "MenuDataAuditEvent", 1060, false, (int)MenuIconsSmall.DataAuditTransactions,
                           -1)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToDataAudit),
                    ShowInMenu = true
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (DataAuditListPanel), BaseFormManager.MainForm,
                                       DataAuditListItem.CreateInstance());
        }

      
    }
}