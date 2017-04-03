using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Security
{
    public partial class SecurityEventLogListPanel : BaseListPanel_SecurityEventLogListItem
    {
        public SecurityEventLogListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return string.Empty;
        }

        public static void Register(Control parentControl)
        {
            if (BaseFormManager.ArchiveMode)
                return;
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Security,
                           "MenuSecurityEventLog", 1050, false, (int) MenuIconsSmall.SecurityEventLog,
                           -1)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.SecurityLog),
                    ShowInMenu = true,
                    BeginGroup = true
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (SecurityEventLogListPanel), BaseFormManager.MainForm,
                                       SecurityEventLogListItem.CreateInstance());
        }
    }
}