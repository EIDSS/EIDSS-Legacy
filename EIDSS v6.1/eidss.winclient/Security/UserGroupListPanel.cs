using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
    public partial class UserGroupListPanel : BaseListPanel_UserGroupListItem
    {
        public UserGroupListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return "UserGroupDetailPanel";
        }

        public static void Register(Control parentControl)
        {
            if (BaseFormManager.ArchiveMode)
                return;
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Security,
                           "MenuUserGroups", 1010, false, (int)MenuIconsSmall.UserGroupList,
                           -1)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.UserGroup),
                BeginGroup = true,
                ShowInMenu = true
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(UserGroupListPanel), BaseFormManager.MainForm,
                                       UserGroupListItem.CreateInstance());
        }
    }
}
