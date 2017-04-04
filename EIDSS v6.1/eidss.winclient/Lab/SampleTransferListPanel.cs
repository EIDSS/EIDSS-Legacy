using System.Windows.Forms;
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
    public partial class SampleTransferListPanel : BaseListPanel_LabSampleTransferListItem
    {
        public SampleTransferListPanel()
        {
            InitializeComponent();
        }
        public override string GetDetailFormName(IObject o)
        {
            return "SampleTransferDetail";
        }

        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuSampleTransfer", 170, false, (int) MenuIconsSmall.SampleTransferJournal,
                           (int) MenuIcons.SampleTransferList)
                {
                    SelectPermission = PermissionHelper.ExecutePermission(EIDSSPermissionObject.SampleTransfer),
                    ShowInMenu = true,
                    Group = (int)MenuGroup.MenuJournalsLab
                };
        }
        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var item = ((LabSampleTransferListItem)FocusedItem);
                EidssSiteContext.ReportFactory.LimSampleTransfer(item.idfTransferOut);
            }
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (SampleTransferListPanel), BaseFormManager.MainForm,
                                       LabSampleTransferListItem.CreateInstance());
        }
    }
}