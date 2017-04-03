using System.Windows.Forms;
using bv.common.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;
using eidss.model.Import;
using System.Collections.Generic;
using bv.model.Model.Core;
using bv.model.BLToolkit;
using eidss.model.Resources;
using System.Threading;
using System;
using bv.common.Enums;
using eidss.model.Core;

namespace eidss.winclient.Administration
{
    public partial class StatisticListPanel : BaseListPanel_StatisticListItem
    {
        public StatisticListPanel()
        {
            InitializeComponent();
        }

        public static void Register(Control parentControl)
        {
            MenuAction menuAdministration = MenuActionManager.Instance.FindAction("MenuAdministration",
                                                                                 MenuActionManager.Instance.System, 970);
            new MenuAction(ShowMe, MenuActionManager.Instance, menuAdministration,
                           "MenuStatistic", 989, false, (int)MenuIconsSmall.StatisticalDataList,
                           -1)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Statistic),
                ShowInMenu = true,
                BeginGroup = true
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(StatisticListPanel), BaseFormManager.MainForm,
                                       StatisticListItem.CreateInstance());
        }
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "ImportData", ImportData);
        }
        private ActResult ImportData(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.InitialDirectory = Application.ExecutablePath;
            if (dialog.ShowDialog(BaseFormManager.MainForm) == DialogResult.OK)
            {
                using (StatisticHelper helper = new StatisticHelper())
                {
                    helper.FileName = dialog.FileName;
                    helper.ForceImport = false;
                    using (StatisticAbort abortForm = new StatisticAbort(helper))
                    {
                        if (abortForm.ShowDialog(BaseFormManager.MainForm) == DialogResult.Abort)
                            return false;
                    }
                    if (helper.UnprocessedError != null)
                    {
                        ErrorForm.ShowError(StandardError.DataSavingtError, helper.UnprocessedError);
                        return false;
                    }
                    if (helper.Errors.Count == 0)
                    {
                        MessageForm.Show(helper.ResultMessage, EidssMessages.Get("titleStatisticImport", "Statistic Import"));
                        this.Refresh();
                        return true;
                    }
                    else if (helper.Errors.Count <= StatisticHelper.MaxErrorsQty)
                    {
                        if (ErrorForm.ShowConfirmationDialog(null, helper.ResultMessage, helper.ErrorMessage) == DialogResult.Yes)
                        {
                            helper.ForceImport = true;
                            using (StatisticAbort abortForm = new StatisticAbort(helper))
                            {
                                if (abortForm.ShowDialog(BaseFormManager.MainForm) == DialogResult.Abort)
                                    return false;
                            }
                        }
                        else
                            return false;
                    }
                    ErrorForm.ShowMessageDirect(helper.ResultMessage, ErrorForm.FormType.Error, helper.ErrorMessage);
                }
            }
            this.Refresh();
            return true;
        }
        /*perm!!
        public override void CheckActionPermission(ActionMetaItem action, ref bool showAction)
        {
            switch (action.Name)
            {
                case "ImportData":
                    showAction = showAction && EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Statistic));
                    return;

            }

        }*/


    }
}
