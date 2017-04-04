using System;
using System.Windows.Forms;
using bv.common.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.BasicSyndromicSurveillance
{
    public sealed partial class BasicSyndromicSurveillanceAggregateHeaderDetail : BaseDetailPanel_BasicSyndromicSurveillanceAggregateHeader
    {
        public BasicSyndromicSurveillanceAggregateHeaderDetail()
        {
            InitializeComponent();

            DetailPanel = AddDetailPanel(panelDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerControl"></param>
        public static BasicSyndromicSurveillanceAggregateDetailListPanel AddDetailPanel(Control ownerControl)
        {
            var panel = new BasicSyndromicSurveillanceAggregateDetailListPanel();
            var layout = (LayoutGroup)panel.GetLayout();
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            layout.SearchPanelVisible = false;
            return panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            RegisterItem(MenuActionManager.Instance.Create, "MenuNewBasicSyndromicSurveillanceAggregateItem", 225, false, false, MenuGroup.CreateAggregate);
            //Toolbar menu
            //RegisterItem(MenuActionManager.Instance.Journals, "ToolbarNewBasicSyndromicSurveillanceAggregateItem", 207, true, true, MenuGroup.ToolbarCreate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuAction"></param>
        /// <param name="resourceKey"></param>
        /// <param name="order"></param>
        /// <param name="showInToolbar"></param>
        /// <param name="beginGroup"></param>
        private static void RegisterItem
            (IMenuAction menuAction, string resourceKey, int order, bool showInToolbar, bool beginGroup, MenuGroup group = MenuGroup.None)
        {
            new MenuAction(ShowMe, MenuActionManager.Instance, menuAction,
                           resourceKey, order, showInToolbar, (int) MenuIconsSmall.BssAggregate,
                           (int) MenuIcons.BssAggregate)
                {
                    SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.AccessToBssModule),
                    BeginGroup = beginGroup,
                    ShowInMenu = !showInToolbar,
                    Group = (int)group
                };
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowNormal(typeof(BasicSyndromicSurveillanceAggregateHeaderDetail), ref id);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            base.DefineBinding();

            var bss = BusinessObject as BasicSyndromicSurveillanceAggregateHeader;
            if (bss == null) return;

            LookupBinder.BindTextEdit(txtFormID, bss, "strFormID");
            LookupBinder.BindTextEdit(txtDateEntered, bss, "datDateEntered");//dtDateEntered
            LookupBinder.BindTextEdit(txtDateLastSaved, bss, "datDateLastSaved");//dtDateLastSaved
            LookupBinder.BindTextEdit(txtCreatedBy, bss, "strEnteredBy");
            LookupBinder.BindTextEdit(txtSite, bss, "strSite");

            var ah = new AggregateHelper();
            ah.FillYearList(cbYear);
            ah.FillWeekList(leWeek, DateTime.Now.Year);

            LookupBinder.AddBinding(cbYear, bss, "intYear", false);
            LookupBinder.AddBinding(leWeek, bss, "intWeek", false);

            cbYear.EditValueChanged += cbYear_EditValueChanged;
        }

        void cbYear_EditValueChanged(object sender, EventArgs e)
        {
            var year = (int)cbYear.EditValue;
            (new AggregateHelper()).FillWeekList(leWeek, year);
        }

        private BasicSyndromicSurveillanceAggregateDetailListPanel DetailPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            if (BusinessObject == null)
            {
                bppLocation.PopupControl.BusinessObject = null;
                DetailPanel.BusinessObject = null;
            }
            else
            {
                var bss = BusinessObject as BasicSyndromicSurveillanceAggregateHeader;
                if (bss != null)
                {
                    DetailPanel.SetDataSource(bss, bss.BSSAggregateDetail);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBasicSyndromicSurveillanceItemDetailLoad(object sender, EventArgs e)
        {
            LayoutCorrector.SetStyleController(bppLocation, LayoutCorrector.MandatoryStyleController);
        }
    }
}
