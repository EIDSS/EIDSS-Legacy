using System.Windows.Forms;
using eidss.winclient.Schema;
using bv.winclient.Core;
using bv.common.Core;
using bv.winclient.BasePanel;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.winclient.Human
{
    public partial class PatientListPanel : BaseListPanel_PatientListItem
    {
        public PatientListPanel()
        {
            InitializeComponent();
        }

        public static void Register(Control parentControl)
        {
            RegisterItem(303, false);
        }

        private static void RegisterItem(int order, bool showInToolbar)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuPatient", order, showInToolbar, (int) MenuIconsSmall.PersonsJournal)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Patient),
                    BeginGroup = true,
                    ShowInMenu = true
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(PatientListPanel), BaseFormManager.MainForm,
                                       PatientListItem.CreateInstance());
        }

        public override void InitDetailForm(object detailForm)
        {
            if (detailForm != null)
                ReflectionHelper.SetProperty(detailForm, "IsSharedAddress", true);
        }
    }
}
