using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports;
using eidss.model.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.AggregateCase
{
    public partial class HumanAggregateCaseList : BaseListPanel_HumanAggregateCaseListItem
    {
        public HumanAggregateCaseList()
        {
            InitializeComponent();
            AfterLayoutCreated += LayoutCreated;
        }

        public static void Register(Control parentControl)
        {
            RegisterItem(125, false);
        }

        private static void RegisterItem(int order, bool showInToolbar)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals,
                           "MenuHumanAggregateCaseList", order, showInToolbar, (int) MenuIconsSmall.HumanAggregateCaseList)
                {
                    SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToHumanAggregateCase),
                    Group = (int)MenuGroup.MenuJournalsAggregate
                };
        }

        private static void ShowMe()
        {
            BaseFormManager.ShowClient(typeof (HumanAggregateCaseList), BaseFormManager.MainForm,
                                       HumanAggregateCaseListItem.CreateInstance());
        }

        public override string GetDetailFormName(IObject o)
        {
            return "AggregateCaseDetail";
        }

        public override void ShowReport()
        {
            if (FocusedItem != null)
            {
                var humanCase = ((HumanAggregateCaseListItem)FocusedItem);

                EidssSiteContext.ReportFactory.HumAggregateCase(new AggregateReportParameters(humanCase.idfAggrCase,
                                                                                              humanCase.idfsCaseFormTemplate ?? 0,
                                                                                              humanCase.idfCaseObservation ?? 0));
            }
        }

        private void LayoutCreated()
        {
            ILayout layout = GetLayout();
            layout.OnBeforeActionExecuting += BeforeSelectAction;
        }

        private static void BeforeSelectAction(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            cancel = !AggregateHelper.ValidateSelection<HumanAggregateCaseListItem>(panel, action);
        }

    }
}