using System;
using System.Linq;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient.Schema;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using eidss.winclient.Helpers;

namespace eidss.winclient.Security
{
    public partial class ObjectAccessListPanel : BaseGroupPanel_ObjectAccess
    {
        private const string FunctionNameColumnName = "FunctionName";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        private void AddCheckBox(GridColumn column)
        {
            if (column != null)
            {
                var checkEdit = column.SetCheckEditor();
                checkEdit.EditValueChanged += OnColumnEditEditValueChanged;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectAccessListPanel()
        {
            InitializeComponent();
            InlineMode = InlineMode.UseCreateButton;
            var column = Grid.GridView.Columns.ColumnByName(FunctionNameColumnName);
            if (column != null)
            {
                Grid.GridView.GroupCount = 1;
                Grid.GridView.SortInfo.AddRange(new[] { new GridColumnSortInfo(column, ColumnSortOrder.Ascending) });
                Grid.GridView.OptionsView.ShowGroupPanel = false;
            }
            AddCheckBox(Grid.GridView.Columns.ColumnByName("isDeny"));
            AddCheckBox(Grid.GridView.Columns.ColumnByName("isAllow"));

            Grid.GridView.CustomDrawGroupRow += OnGridViewCustomDrawGroupRow;
            Grid.GridView.RowCountChanged += OnGridViewOnRowCountChanged;
            Grid.GridControl.DataSourceChanged += OnDataSourceChanged;
        }

        private void OnDataSourceChanged(object sender, EventArgs e)
        {
            ExpandAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnColumnEditEditValueChanged(object sender, System.EventArgs e)
        {
            Grid.GridView.PostEditor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGridViewOnRowCountChanged(object sender, System.EventArgs e)
        {
            //Grid.GridView.ExpandAllGroups();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGridViewCustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            var info = e.Info as GridGroupRowInfo;
            if (info == null) return;
            if (info.Column.FieldName.Equals(FunctionNameColumnName))
            {
                var fnValue = view.GetGroupRowValue(e.RowHandle, info.Column);
                if (fnValue != null) info.GroupText = fnValue.ToString();
            }
        }

        public void ExpandAll()
        {
            Grid.GridView.ExpandAllGroups();
        }

        public void CollapsAll()
        {
            Grid.GridView.CollapseAllGroups();
        }
        public void ApplyToAllSites(EditableList<ObjectAccess> allSitesPermissions)
        {
            if (DataSource == null || allSitesPermissions == null)
                return;
            if (!WinUtils.ConfirmMessage(EidssMessages.Get("ObjectAccess_ApplyForAllSites"), String.Empty)) return;
            var currentPermissions = DataSource;

            foreach (var oa in currentPermissions)
            {
                var allow = oa.isAllow;
                var deny = oa.isDeny;
                var oaChange = allSitesPermissions.Where(c =>
                                                                      (c.idfsObjectOperation == oa.idfsObjectOperation)
                                                                      && (c.idfsObjectType == oa.idfsObjectType)
                                                                      && (c.idfsObjectID == oa.idfsObjectID)
                                                                      && (c.idfsSite != oa.idfsSite)
                                                                      && (c.isAllow != allow || c.isDeny != deny)
                    ).ToList();
                foreach (var objectAccess in oaChange)
                {
                    objectAccess.isAllow = allow;
                    objectAccess.isDeny = deny;
                }
            }
            MessageForm.Show(EidssMessages.Get("ObjectAccess_Complete"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
