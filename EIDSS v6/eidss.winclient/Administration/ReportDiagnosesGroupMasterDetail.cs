using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class ReportDiagnosesGroupMasterDetail : BaseDetailPanel_ReportDiagnosesGroupMaster, IMasterDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public ReportDiagnosesGroupMasterDetail()
        {
            InitializeComponent();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                matrixDetail.DisplayLayout();
                ((LayoutGroup)matrixDetail.GetLayout()).SearchPanelVisible = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            var category = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 950);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "MenuReportDiagnosesGroup", 955, false, (int)MenuIconsSmall.References)
            {
                SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.Reference),
                ShowInMenu = true
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ShowMe()
        {
            object id = null;
            BaseFormManager.ShowNormal(new ReportDiagnosesGroupMasterDetail(), ref id, null, 800, 600);
        }

        public bool ShowModal(Control owner = null)
        {
            object id = null;
            return BaseFormManager.ShowModal(this, owner, ref id, null, null, 800, 600);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteGroup", DeleteGroup);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult DeleteGroup(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            matrixDetail.PerformAction("Delete");
            return true;
        }

        protected override void InitChildren()
        {
            matrixDetail.SetDataSource(BusinessObject, ((ReportDiagnosesGroupMaster)BusinessObject).ReportDiagnosesGroups);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IBasePanel Child
        {
            get { return matrixDetail; }
        }
    }

}
