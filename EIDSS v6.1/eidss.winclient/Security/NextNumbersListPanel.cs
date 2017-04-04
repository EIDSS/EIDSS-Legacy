using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Security
{
    public partial class NextNumbersListPanel : BaseListPanel_NextNumbersListItem
    {
        public NextNumbersListPanel()
        {
            InitializeComponent();
        }

        public static void Register(Control parentControl)
        {
            MenuAction menuConfiguration = MenuActionManager.Instance.FindAction("MenuConfiguration",
                                                                                 MenuActionManager.Instance.System, 960, (int)MenuIconsSmall.Configuration, -1);
            new MenuAction(ShowMe, MenuActionManager.Instance, menuConfiguration,
                           "MenuNumberingService", 1010, false, (int) MenuIconsSmall.UniqueNumberingScheme,
                           -1)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.DocumentNumbering),
                    ShowInMenu = true,
                    BeginGroup = true
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (NextNumbersListPanel), BaseFormManager.MainForm,
                                       NextNumbersListItem.CreateInstance());
        }

    }
}