using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Diagnosis2DiagnosisGroupMasterDetail : BaseDetailPanel_Diagnosis2DiagnosisGroupMaster
    {
        /// <summary>
        /// 
        /// </summary>
        public Diagnosis2DiagnosisGroupMasterDetail()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this)) return;

            cbDiagnosisGroups.EditValueChanged += DiagnosisGroupChanged;

            m_MatrixDetail = new Diagnosis2DiagnosisGroupDetail();
            var layoutGroup = (LayoutGroup)m_MatrixDetail.GetLayout();
            layoutGroup.SearchPanelVisible = false;
            var layout = (Control)layoutGroup;
            panelBottom.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private readonly Diagnosis2DiagnosisGroupDetail m_MatrixDetail;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            var category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "MenuDiagnosesGroup2DiagnosisGroup", 997, false, (int)MenuIconsSmall.ReferenceMatrix)
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
            BaseFormManager.ShowNormal(new Diagnosis2DiagnosisGroupMasterDetail(), ref id, null, 800, 600);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var d = BusinessObject as Diagnosis2DiagnosisGroupMaster;
            if (d != null)
            {
                Core.LookupBinder.BindBaseLookup(cbDiagnosisGroups, d, "DiagnosisGroup", d.DiagnosisGroupLookup, true, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteDiagnosis", DeleteDiagnosis);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult DeleteDiagnosis(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            m_MatrixDetail.PerformAction("Delete");
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            var d = BusinessObject as Diagnosis2DiagnosisGroupMaster;
            if (d == null) return;

            m_MatrixDetail.SetDataSource(d, d.Diagnosis2DiagnosisGroups);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiagnosisGroupChanged(object sender, EventArgs e)
        {
            var d = BusinessObject as Diagnosis2DiagnosisGroupMaster;
            if (d == null) return;
            
            if (Utils.IsEmpty(cbDiagnosisGroups.EditValue))
            {
                m_MatrixDetail.idfsDiagnosisGroup = -1;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = true;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.Editable = false;
                m_MatrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                m_MatrixDetail.idfsDiagnosisGroup = ((BaseReference)cbDiagnosisGroups.EditValue).idfsBaseReference;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = false;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.Editable = true;
                m_MatrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            }
        }
    }

}
