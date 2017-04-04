using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.ActiveSurveillance
{
    public partial class AsSessionListPanel : BaseListPanel_AsSessionListItem
    {
        public AsSessionListPanel()
        {
            InitializeComponent();
        }

        public override string GetDetailFormName(IObject o)
        {
            return "AsSessionDetail";
        }

        public FilterParams GetFilter()
        {
            return SearchPanel.Parameters;
        }

        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuASSessionList", 150, false, (int)MenuIconsSmall.ASSessionJournal,
                           (int) MenuIcons.ASSession)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.MonitoringSession),
                    BeginGroup = false,
                    ShowInMenu = true,
                    Group = (int)MenuGroup.MenuJournalsSession
                };
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuASSessionList", 100021, true, (int)MenuIconsSmall.ASSessionJournal,
                           (int)MenuIcons.ASSessionList)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.MonitoringSession),
                BeginGroup = false,
                ShowInMenu = false,
                Group = (int)MenuGroup.ToolbarJournals
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (AsSessionListPanel), BaseFormManager.MainForm,
                                       AsSessionListItem.CreateInstance());
        }
        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var session = ((AsSessionListItem)FocusedItem);
                EidssSiteContext.ReportFactory.VetActiveSurveillanceSampleCollected(session.idfMonitoringSession);
            }
        }
    }
}