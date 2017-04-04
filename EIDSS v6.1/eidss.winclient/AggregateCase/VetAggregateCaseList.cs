using System;
using System.Windows.Forms;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.winclient.Schema;
using eidss.model.Enums;
using bv.winclient.BasePanel;
using eidss.model.Schema;
using bv.common.Core;
using bv.winclient.Core;
using eidss.winclient.Helpers;
using bv.model.Model.Core;
namespace eidss.winclient.AggregateCase
{
    public partial class VetAggregateCaseList : BaseListPanel_VetAggregateCaseListItem
    {
        public VetAggregateCaseList()
        {
            InitializeComponent();
            AfterLayoutCreated += LayoutCreated;

        }

        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var vetCase = ((VetAggregateCaseListItem)FocusedItem);
                EidssSiteContext.ReportFactory.VetAggregateCase(new AggregateReportParameters(vetCase.idfAggrCase,
                                                                                              vetCase.idfsCaseFormTemplate ?? 0,
                                                                                              vetCase.idfCaseObservation ?? 0));
            }
        }
        public static void Register(Control parentControl)
        {
            RegisterItem(135, false);

        }
        private static void RegisterItem(int order, bool showInToolbar)
        {
            if (EidssSiteContext.Instance.IsAzerbaijanCustomization)
                return;
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuVetAggregateCaseList", order, showInToolbar, (int)MenuIconsSmall.VetAggregateCaseList)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToVetAggregateCase),
                BeginGroup = false,
                ShowInMenu = !showInToolbar,
                Group = (int)MenuGroup.MenuJournalsAggregate
            };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof(VetAggregateCaseList), BaseFormManager.MainForm,
                                       VetAggregateCaseListItem.CreateInstance());
        }

        public override string GetDetailFormName(IObject o)
        {
            return "VetAggregateCaseDetail";
        }

        private void BeforeSelectAction(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            cancel = !AggregateHelper.ValidateSelection<VetAggregateCaseListItem>(panel, action);

        }


        private void LayoutCreated()
        {
            var layout = GetLayout();
            layout.OnBeforeActionExecuting += BeforeSelectAction;
        }

    }
}
