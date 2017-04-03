using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLToolkit.Data;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.RepositorySchemes
{
    public partial class RepositorySchemeListPanel : BaseListPanel_RepositorySchemeListItem
    {
        public RepositorySchemeListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return "RepositorySchemeDetail";
        }

        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuRepositoryScheme", 190, false, (int)MenuIconsSmall.Freezer)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.RepositoryScheme),
                    ShowInMenu = true,
                    Group = (int)MenuGroup.MenuJournalsLab
                };
        }

        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "Copy", CreateCopy);
        }

        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var item = ((RepositorySchemeListItem)FocusedItem);
                EidssSiteContext.ReportFactory.LimContainerContent(null, item.idfFreezer);
            }
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(RepositorySchemeListPanel), BaseFormManager.MainForm,
                                       RepositorySchemeListItem.CreateInstance());
        }

        private ActResult CreateCopy(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (parameters == null || parameters.Count != 3 || parameters[0] == null)
                return true;
            string freezerName = InputForm.Input(EidssMessages.Get("MSG_EnterFreazerame"), EidssMessages.Get("MSG_CopyFreezer"), FindForm());
            if (!Utils.IsEmpty(freezerName))
            {
                int result = manager.SetSpCommand("spFreezer_ValidateName"
                                     , manager.Parameter("@idfFreezer", -1)
                                     , manager.Parameter("@strFreezerName", freezerName)).ExecuteScalar<int>(
                                         ScalarSourceType.ReturnValue);
                if(!1.Equals(result))
                {
                    ErrorForm.ShowWarning("errDuplicateFreezerName",
                                        "Freezer with such name exists already. Please enter other freezer name.");
                    return false;
                }
                
                var @params = new List<object> { (long)parameters[0], freezerName };
                PerformAction("CopyFreezer", @params);
                Refresh();
            }
            return true;
        }
    }
}
