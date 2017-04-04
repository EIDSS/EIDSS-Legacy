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
    public partial class PersonListPanel : BaseListPanel_PersonListItem
    {
        public PersonListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return "PersonDetailPanel";//"PersonDetail";
        }

        public static void Register(Control parentControl)
        {
            MenuAction menuAdministration = MenuActionManager.Instance.FindAction("MenuAdministration",
                                                                                  MenuActionManager.Instance.System, 970);
            new MenuAction(ShowMe, MenuActionManager.Instance, menuAdministration,
                           "MenuPerson", 476, false, (int) MenuIconsSmall.EmployeesList)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Person),
                    ShowInMenu = true,
                    BeginGroup = true,
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (PersonListPanel), BaseFormManager.MainForm,
                                       PersonListItem.CreateInstance());
        }
    }
}