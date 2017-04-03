using System;
using System.Collections.Generic;
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
    public partial class DAG2SAGMasterDetail : BaseDetailPanel_DiagnosisAgeGroup2StatisticalAgeGroupMaster
    {
        /// <summary>
        /// 
        /// </summary>
        public DAG2SAGMasterDetail()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this)) return;

            cbDiagnosisAgeGroup.EditValueChanged += DiagnosisAgeGroupChanged;

            m_MatrixDetail = new DAG2SAGDetail();
            var layoutGroup = (LayoutGroup)m_MatrixDetail.GetLayout();
            layoutGroup.SearchPanelVisible = false;
            var layout = (Control)layoutGroup;
            panelBottom.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private readonly DAG2SAGDetail m_MatrixDetail;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            var category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "DAG2SAGGroup", 997, false, (int)MenuIconsSmall.ReferenceMatrix)
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
            BaseFormManager.ShowNormal(new DAG2SAGMasterDetail(), ref id, null, 800, 600);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var dag2SAG = BusinessObject as DiagnosisAgeGroup2StatisticalAgeGroupMaster;
            if (dag2SAG != null)
            {
                Core.LookupBinder.BindDiagnosisAgeGroupLookup(cbDiagnosisAgeGroup, dag2SAG, "DiagnosisAgeGroup", dag2SAG.DiagnosisAgeGroupLookup);
                DiagnosisAgeGroupChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteStatisticalAgeGroup", DeleteStatisticalAgeGroup);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult DeleteStatisticalAgeGroup(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            m_MatrixDetail.PerformAction("Delete");
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            var dag = BusinessObject as DiagnosisAgeGroup2StatisticalAgeGroupMaster;
            if (dag == null) return;
            m_MatrixDetail.SetDataSource(dag, dag.DAG2SAG);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiagnosisAgeGroupChanged(object sender, EventArgs e)
        {
            if (Utils.IsEmpty(cbDiagnosisAgeGroup.EditValue))
            {
                m_MatrixDetail.IdfsDiagnosisAgeGroup = -1;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = true;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.Editable = false;
                m_MatrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                m_MatrixDetail.IdfsDiagnosisAgeGroup = (long)cbDiagnosisAgeGroup.EditValue;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = false;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.Editable = true;
                m_MatrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            }
        }
    }

}
