using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.ActiveSurveillance
{
    public partial class AsCampaignListPanel : BaseListPanel_AsCampaignListItem
    {
        public AsCampaignListPanel()
        {
            InitializeComponent();
        }
        public override string GetDetailFormName(IObject o)
        {
            return "AsCampaignDetail";
        }
        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuASCampaigns", 145, false, (int) MenuIconsSmall.ASCampaignJournal,
                           (int) MenuIcons.ASCampaign)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Campaign),
                    ShowInMenu = true,
                    Group = (int)MenuGroup.MenuJournalsSession
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (AsCampaignListPanel), BaseFormManager.MainForm,
                                       AsCampaignListItem.CreateInstance());
        }
    }
}