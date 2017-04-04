using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Outbreaks
{
    public partial class OutbreakListPanel : BaseListPanel_OutbreakListItem
    {
        public OutbreakListPanel()
        {
            InitializeComponent();
        }

        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var item = ((OutbreakListItem)FocusedItem);
                EidssSiteContext.ReportFactory.Outbreak(item.idfOutbreak);
            }
        }

        public static void Register(Control parentControl)
        {
            RegisterItem(110, false);
        }

        private static void RegisterItem(int order, bool showInToolbar)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuOutbreak", order, showInToolbar, (int) MenuIconsSmall.OutbreakJournal)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Outbreak),
                    BeginGroup = false,
                    ShowInMenu = !showInToolbar,
                    Group = (int)MenuGroup.MenuJournalsCase
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (OutbreakListPanel), BaseFormManager.MainForm,
                                       OutbreakListItem.CreateInstance());
        }
        protected override void HidePersonalData(List<OutbreakListItem> list)
        {
            bool hidePatientName =
                    EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName);
            bool hideFarmOwnerName =
                    EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement) ||
                    EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details);

            if (hideFarmOwnerName || hidePatientName)
            {
                foreach (var item in list)
                {
                    if (hidePatientName && item.strHumanPatientName!=null)
                        item.strPatientName = "*";
                    if (hideFarmOwnerName && item.strFarmOwner != null)
                        item.strPatientName = "*";
                }
            }

        }

    }
}