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
    public partial class Diagnosis2DiagnosisAgeGroupMasterDetail : BaseDetailPanel_Diagnosis2DiagnosisAgeGroupMaster
    {
        /// <summary>
        /// 
        /// </summary>
        public Diagnosis2DiagnosisAgeGroupMasterDetail()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this)) return;

            cbDiagnosis.EditValueChanged += DiagnosisChanged;

            m_MatrixDetail = new DiagnosisAgeGroupToDiagnosisDetail();
            var layoutGroup = (LayoutGroup)m_MatrixDetail.GetLayout();
            layoutGroup.SearchPanelVisible = false;
            var layout = (Control)layoutGroup;
            panelBottom.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private readonly DiagnosisAgeGroupToDiagnosisDetail m_MatrixDetail;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            var category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "Diagnosis2DiagnosisAgeGroup", 996, false, (int)MenuIconsSmall.ReferenceMatrix)
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
            BaseFormManager.ShowNormal(new Diagnosis2DiagnosisAgeGroupMasterDetail(), ref id, null, 800, 600);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var diagnosis = BusinessObject as Diagnosis2DiagnosisAgeGroupMaster;
            if (diagnosis != null)
            {
                Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, diagnosis, diagnosis.DiagnosisLookup, "Diagnosis", HACode.Human);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteDiagnosisAgeGroup", DeleteDiagnosisAgeGroup);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult DeleteDiagnosisAgeGroup(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            m_MatrixDetail.PerformAction("Delete");
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            var diagnosis = BusinessObject as Diagnosis2DiagnosisAgeGroupMaster;
            if (diagnosis == null) return;

            m_MatrixDetail.SetDataSource(diagnosis, diagnosis.DiagnosisAgeGroupToDiagnoses);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiagnosisChanged(object sender, EventArgs e)
        {
            var diagnosis = BusinessObject as Diagnosis2DiagnosisAgeGroupMaster;
            if (diagnosis == null) return;
            if (Utils.IsEmpty(cbDiagnosis.EditValue))
            {
                m_MatrixDetail.IdfsDiagnosis = -1;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = true;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.Editable = false;
                m_MatrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                m_MatrixDetail.IdfsDiagnosis = ((DiagnosisLookup)cbDiagnosis.EditValue).idfsDiagnosis;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.ReadOnly = false;
                m_MatrixDetail.Grid.GridView.OptionsBehavior.Editable = true;
                m_MatrixDetail.Grid.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            }
        }
    }

}
