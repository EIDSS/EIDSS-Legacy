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
    public partial class OrganizationListPanel : BaseListPanel_OrganizationListItem
    {
        public OrganizationListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return "OrganizationDetail";
        }

        public static void Register(Control parentControl)
        {
            MenuAction menuAdministration = MenuActionManager.Instance.FindAction("MenuAdministration",
                                                                                  MenuActionManager.Instance.System, 970, (int)MenuIconsSmall.Administration, -1);
            new MenuAction(ShowMe, MenuActionManager.Instance, menuAdministration,
                           "MenuOrganizations", 478, false, (int)MenuIconsSmall.OrganizationsList, (int)MenuIcons.OrganizationsList)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Organization),
                    ShowInMenu = true,
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(OrganizationListPanel), BaseFormManager.MainForm,
                                       OrganizationListItem.CreateInstance());
        }

    }
}