using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class BatchListPanel : BaseListPanel_LabBatchListItem
    {
        public BatchListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return "BatchDetail";
        }

        public static void Register(Control parentControl)
        {
            RegisterItem(185, false, MenuGroup.MenuJournalsLab);
            //Toolbar menu
            RegisterItem(100330, true, MenuGroup.ToolbarLab);
        }

        private static void RegisterItem(int order, bool showInToolbar, MenuGroup group = MenuGroup.None)
        {
            if (!BaseSettings.LabSimplifiedMode)
            {
                new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                               "MenuBatchList", order, showInToolbar, (int) MenuIconsSmall.BatchJournal,
                               (int) MenuIcons.BatcList)
                    {
                        SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Test),
                        ShowInMenu = !showInToolbar,
                        Group = (int)group
                    };
            }
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (BatchListPanel), BaseFormManager.MainForm,
                                       LabBatchListItem.CreateInstance());
        }

        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var batch = ((LabBatchListItem) FocusedItem);
                EidssSiteContext.ReportFactory.LimBatchTest(batch.idfBatchTest, batch.idfsTestName ?? -1);
            }
        }
    }
}