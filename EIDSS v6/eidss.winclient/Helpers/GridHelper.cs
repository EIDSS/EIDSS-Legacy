using System;
using System.Collections.Generic;
using bv.winclient.Core;
using bv.winclient.Localization;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using eidss.model.Schema;

namespace eidss.winclient.Helpers
{
    public static class GridHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static RepositoryItemLookUpEdit SetLookupEditor(this GridColumn column)
        {
            var lookupEdit = new RepositoryItemLookUpEdit
            {
                NullText = String.Empty
            };
            column.ColumnEdit = lookupEdit;
            return lookupEdit;
        }

        public static RepositoryItemLookUpEdit SetLookupEditor(this LayoutViewColumn column)
        {
            var lookupEdit = new RepositoryItemLookUpEdit
            {
                NullText = String.Empty
            };
            column.ColumnEdit = lookupEdit;
            return lookupEdit;
        }

        public static RepositoryItemCheckEdit SetCheckEditor(this GridColumn column)
        {
            var edit = new RepositoryItemCheckEdit
            {
                ValueChecked = true,
                ValueUnchecked = false
            };
            column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            column.ColumnEdit = edit;
            return edit;
        }

        public static RepositoryItemSpinEdit SetSpinEditor(this GridColumn column)
        {
            var edit = new RepositoryItemSpinEdit();
            column.ColumnEdit = edit;
            return edit;
        }

        public static RepositoryItemTextEdit SetTextEditor(this GridColumn column)
        {
            var edit = new RepositoryItemTextEdit();
            column.ColumnEdit = edit;
            return edit;
        }

        public static RepositoryItemPopupContainerEdit SetPopupContainerEdit(this GridColumn column)
        {
            var edit = new RepositoryItemPopupContainerEdit();
            column.ColumnEdit = edit;
            return edit;
        }

        public static RepositoryItemTextEdit SetEnglishTextEditor(this GridColumn column)
        {
            var edit = SetTextEditor(column);
            edit.Mask.SetEnglishEditorMask();
            return edit;
        }

        /// <summary>
        /// Добавляет таблицу векторов
        /// </summary>
        /// <param name="column"></param>
        /// <param name="dataSource"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        public static RepositoryItemGridLookUpEdit AddEditorForColumn(this GridColumn column, List<Vector> dataSource, string valueMember, string displayMember)
        {
            var gridEdit = new RepositoryItemGridLookUpEdit
            {
                NullText = String.Empty,
                ValueMember = valueMember,
                DisplayMember = displayMember,
                ShowFooter = false
            };
            var gridView = new GridView { FocusRectStyle = DrawFocusRectStyle.RowFocus };
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridEdit.View = gridView;
            gridEdit.DataSource = dataSource;
            gridEdit.View.Columns.AddField(valueMember);
            //TODO может быть есть другой способ задания заголовков столбцов, более правильный
            gridEdit.View.Columns.AddVisible(displayMember, WinClientContext.FieldCaptions.GetString("strFieldBarcode"));
            gridEdit.View.Columns.AddVisible("strVectorSubTypeName", WinClientContext.FieldCaptions.GetString("idfSpecies"));
            gridEdit.View.Columns.AddVisible("intQuantity", WinClientContext.FieldCaptions.GetString("intQuantity"));
            gridEdit.View.Columns.AddVisible("datCollectionDateTime", WinClientContext.FieldCaptions.GetString("datFieldCollectionDate"));
            gridEdit.View.Columns.AddVisible("strRegionName", WinClientContext.FieldCaptions.GetString("idfsRegion"));
            gridEdit.View.Columns.AddVisible("strRayonName", WinClientContext.FieldCaptions.GetString("idfsRayon"));
            gridEdit.PopupFormWidth = 600;
            gridEdit.View.BestFitColumns();

            column.ColumnEdit = gridEdit;
            return gridEdit;
        }

        /// <summary>
        /// Добавляет таблицу семплов
        /// </summary>
        /// <param name="column"></param>
        /// <param name="dataSource"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        public static RepositoryItemGridLookUpEdit AddEditorForColumn(this GridColumn column, List<VectorSample> dataSource, string valueMember, string displayMember)
        {
            var gridEdit = new RepositoryItemGridLookUpEdit
            {
                NullText = String.Empty,
                ValueMember = valueMember,
                DisplayMember = displayMember,
                ShowFooter = false
            };
            var gridView = new GridView { FocusRectStyle = DrawFocusRectStyle.RowFocus };
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridEdit.View = gridView;
            gridEdit.DataSource = dataSource;
            gridEdit.View.Columns.AddField(valueMember);
            //TODO может быть есть другой способ задания заголовков столбцов, более правильный
            gridEdit.View.Columns.AddVisible(displayMember, WinClientContext.FieldCaptions.GetString("strFieldBarcode"));
            gridEdit.View.Columns.AddVisible("strSampleName", WinClientContext.FieldCaptions.GetString("strSampleName"));
            gridEdit.PopupFormWidth = 250;
            gridEdit.View.BestFitColumns();

            column.ColumnEdit = gridEdit;
            return gridEdit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="readOnly"></param>
        /// <param name="columns"></param>
        public static void SetColumnState(this GridColumnCollection columns, string columnName, bool readOnly)
        {
            var column = columns.ColumnByName(columnName);
            if (column != null) SetColumnState(column, readOnly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="readOnly"></param>
        public static void SetColumnState(GridColumn column, bool readOnly)
        {
            column.OptionsColumn.AllowEdit = !readOnly;
            column.OptionsColumn.ReadOnly = readOnly;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="columnName"></param>
        public static void HideColumn(this GridColumnCollection columns, string columnName)
        {
            var column = columns.ColumnByName(columnName);
            if (column != null) column.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navBarControl"></param>
        /// <returns></returns>
        public static void RecalculateHeight(this NavBarControl navBarControl)
        {
            var result = 0;
            foreach (NavBarGroup group in navBarControl.Groups)
            {
                result += 60; //TODO придумать, как правильно вычислять высоту заголовка
                if (group.Expanded) result += group.GroupClientHeight;
            }
            navBarControl.Height = result;
        }
    }
}
