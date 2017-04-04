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

namespace eidss.winclient.Administration
{
    public partial class SettlementListPanel : BaseListPanel_SettlementListItem
    {
        public SettlementListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return "SettlementDetail";
        }

        public static void Register(Control parentControl)
        {
            MenuAction menuAdministration = MenuActionManager.Instance.FindAction("MenuAdministration",
                                                                                 MenuActionManager.Instance.System, 970);
            new MenuAction(ShowMe, MenuActionManager.Instance, menuAdministration,
                           "MenuSettlementList", 949, false, (int)MenuIconsSmall.SettlementsList,
                           -1)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.GisReference),
                ShowInMenu = true,
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(SettlementListPanel), BaseFormManager.MainForm,
                                       SettlementListItem.CreateInstance());
        }

    }
}
