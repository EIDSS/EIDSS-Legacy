using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Lab
{
    public partial class SampleDispositionListPanel : BaseListPanel_LabSampleDispositionListItem
    {
        public SampleDispositionListPanel()
        {
            InitializeComponent();
        }
        public override string GetDetailFormName(IObject o)
        {
            return "SampleDestructionDetail";
        }
        public static void Register(Control parentControl)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuSampleDestruction", 175, false, (int) MenuIconsSmall.SampleDispositionJournal,
                           (int) MenuIcons.SampleList)
                {
                    SelectPermission = PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanValidateSampleDestruction),
                    ShowInMenu = true,
                    Group = (int)MenuGroup.MenuJournalsLab
                };
        }

       
        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (SampleDispositionListPanel), BaseFormManager.MainForm,
                                       LabSampleDispositionListItem.CreateInstance());
        }

        public override void ShowReport()
        {
            IEnumerable<long> idList = SelectedItems.Cast<LabSampleDispositionListItem>()
                .Select(item => item.idfMaterial);
            EidssSiteContext.ReportFactory.LimSampleDestruction(idList);
        }


        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "Accept", Accept);
            SetActionFunction(actions, "Reject", Reject);
        }

        private static ActResult Reject(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            return parameters[0] != null && WinUtils.ConfirmMessage(EidssMessages.Get("msgConfirmSampleDispositionReject"));
        }

        private static ActResult Accept(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (parameters[0] != null)
            {
                var s = parameters[2] as SampleDispositionListPanel;
                var selectedItems = s.SelectedItems;

                var currentPanel = ((Control)parameters[2]);
                object key = selectedItems;
                if (key == null)
                    return false;
                object destructionForm = ClassLoader.LoadClass("SampleDestructionDetail");
                if (BaseFormManager.ShowModal(destructionForm as IApplicationForm, currentPanel.FindForm(), ref key, null, null, 900, 600))
                {
                    return true;
                }
            }
            return false;
        }
        public override IApplicationForm Edit(object key, List<object> parameters, ActionTypes actionType, bool readOnly)
        {
            this.PerformAction("Accept", parameters);
            return null;
        }

    }
}