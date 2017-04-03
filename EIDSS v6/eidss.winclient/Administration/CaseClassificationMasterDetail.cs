using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class CaseClassificationMasterDetail : BaseDetailPanel_CaseClassificationMaster
    {
        private void SetColumnControl(string columnName)
        {
            var column = matrixDetail.Grid.GridView.Columns.ColumnByName(columnName);
            if (column != null)
            {
                column.SetSpinEditor();
                var se = (RepositoryItemSpinEdit) column.ColumnEdit;
                //se.EditFormat.FormatType = FormatType.Numeric;
                se.EditMask = "n0";
                se.EditValueChanging += OnBoundariesEditValueChanging;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CaseClassificationMasterDetail()
        {
            InitializeComponent();
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                matrixDetail.DisplayLayout();
                ((LayoutGroup)matrixDetail.GetLayout()).SearchPanelVisible = false;
                SetColumnControl("intLowerBoundary");
                SetColumnControl("intUpperBoundary");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnBoundariesEditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue == null) return;
            int result;
            if (!Int32.TryParse(e.NewValue.ToString(), out result)) e.Cancel = true;
            if (result < 0) e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            var category = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 950);
            new MenuAction(ShowMe, MenuActionManager.Instance, category,
                           "MenuCaseClassification", 955, false, (int)MenuIconsSmall.References)
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
            BaseFormManager.ShowNormal(new CaseClassificationMasterDetail(), ref id, null, 800, 600);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "DeleteCaseClassification", DeleteGroup);
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
            matrixDetail.SetDataSource(BusinessObject, ((CaseClassificationMaster)BusinessObject).CaseClassifications);
        }
    }

}
