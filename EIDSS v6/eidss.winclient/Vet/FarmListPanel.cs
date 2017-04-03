using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;
using eidss.winclient.Security;

namespace eidss.winclient.Vet
{
    public partial class FarmListPanel : BaseListPanel_FarmListItem
    {
        public FarmListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return "FarmRootDetail";
        }

        public static void Register(Control parentControl)
        {
            //MenuAction menuAdministration = MenuActionManager.Instance.FindAction("MenuAdministration",
            //                                                                     MenuActionManager.Instance.System, 970);
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuFarm", 120, false, (int)MenuIconsSmall.Farm,
                           (int)MenuIcons.FarmList)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToFarmData),
                ShowInMenu = true,
                Group = (int)MenuGroup.MenuJournalsFarm
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(FarmListPanel), BaseFormManager.MainForm,
                                       FarmListItem.CreateInstance());
        }

        public override void InitDetailForm(object detailForm)
        {
            if(detailForm!=null)
                ReflectionHelper.SetProperty(detailForm,"IsRootFarm", true);
        }
    }
}
