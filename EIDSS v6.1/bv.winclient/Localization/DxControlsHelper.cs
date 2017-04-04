using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.model.Helpers;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Core;
using bv.winclient.Properties;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Localization;
using DragObjectOverEventArgs = DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs;
using Localizer = bv.common.Core.Localizer;
using PopupMenuShowingEventArgs = DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs;

namespace bv.winclient.Localization
{
    public static class DxControlsHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static void InitDefaultFont()
        {
            if (!AppearanceObject.DefaultFont.Equals(WinClientContext.CurrentFont))
            {
                AppearanceObject.DefaultFont = WinClientContext.CurrentFont;
                AppearanceObject.ControlAppearance.Font = WinClientContext.CurrentFont;
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="controller"></param>
        public static void InitStyleController(this StyleController controller)
        {
            InitDefaultFont();
            InitAppearance(controller.Appearance);
            InitAppearance(controller.AppearanceDisabled);
            InitAppearance(controller.AppearanceDropDown);
            InitAppearance(controller.AppearanceDropDownHeader);
            InitAppearance(controller.AppearanceFocused);
            InitAppearance(controller.AppearanceReadOnly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        public static void InitTooltipController(this DefaultToolTipController controller)
        {
            InitDefaultFont();
            InitAppearance(controller.DefaultController.Appearance);
            InitAppearance(controller.DefaultController.AppearanceTitle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appearance"></param>
        public static void InitAppearance(this AppearanceObject appearance)
        {
            bool bold = appearance.Font.Bold;
            if (bold)
                appearance.Font = WinClientContext.CurrentBoldFont;
            else
                appearance.Font = WinClientContext.CurrentFont;
            appearance.Options.UseFont = true;
        }
        public static void InitXtraGridCustomization(this GridView view, IObject bo)
        {
            if (!IsGridCustomizationAllowed(view))
                return;
            var meta = (IObjectMeta)bo.GetAccessor();
            string[] nonHidableFields = meta.GridMeta.Where(col => col.Required || !col.Visible).Select(c => c.Name).ToArray();
            view.InitXtraGridCustomization(nonHidableFields);

        }

        private const string AllowCustomizationMark = "AllowCistomization";
        private static bool IsGridCustomizationAllowed(this GridView view)
        {
            if (view.GridControl == null) //this is possible if method is called after disposing. Do nothing in this case
                return false;
            var bvGrid = view.GridControl as BvGridControl;
            if (bvGrid != null && bvGrid.AllowCustomization)
                return true;
            if (AllowCustomizationMark.Equals(view.Tag))
                return true;
            return false;
        }
        private static bool IsTreeListCustomizationAllowed(this TreeList tree)
        {
            if (tree == null || tree.IsDisposed)
                return false;
            if (AllowCustomizationMark.Equals(tree.Tag))
                return true;
            return false;
        }
        public static void InitXtraGridCustomization(this GridView view, string[] unhidableFields)
        {
            view.OptionsMenu.EnableColumnMenu = true;
            view.OptionsCustomization.AllowQuickHideColumns = true;
            view.OptionsCustomization.AllowColumnMoving = true;
            view.PopupMenuShowing += OnGridViewPopupMenuShowing;
            view.ShowCustomizationForm += OnShowCustomizationForm;
            view.DragObjectOver += OnDragObjectOver;
            view.Tag = AllowCustomizationMark;
            view.CustomDrawRowIndicator += DrawCustomizationMark;
            if (view.GridControl.ToolTipController == null)
                view.GridControl.ToolTipController = new ToolTipController();
            view.GridControl.ToolTipController.GetActiveObjectInfo += ToolTipController_GetActiveObjectInfo;

            if (view.GridControl.MenuManager == null)
            {
                view.GridControl.MenuManager = new BarManager() { Form = view.GridControl };
            }
            foreach (GridColumn col in view.Columns)
            {
                if (!col.Visible || unhidableFields.Contains(col.FieldName) ||
                    (col.ColumnEdit is RepositoryItemLookUpEdit &&
                     unhidableFields.Contains(((RepositoryItemLookUpEdit)col.ColumnEdit).DisplayMember)))
                {
                    col.OptionsColumn.AllowShowHide = false;
                }
            }
        }

        private static void ShowHiddenFieldsTooltip(ToolTipControllerGetActiveObjectInfoEventArgs e, bool showTooltip)
        {
            ToolTipControlInfo info = null;
            if (e.ControlMousePosition.X < 12 && e.ControlMousePosition.Y < 12 && showTooltip)
            {
                //An object that uniquely identifies a row indicator cell
                object o = "HiddenIcon";
                info = new ToolTipControlInfo(o, BvMessages.Get("msgSomeFieldsAreHidden"));
            }
            //Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
            if (info != null)
                e.Info = info;

        }
        private static void ToolTipController_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            var grid = e.SelectedControl as GridControl;
            if (grid == null)
                return;
            //Get the view at the current mouse position
            GridView view = grid.GetViewAt(e.ControlMousePosition) as GridView;
            if (view == null) return;
            //Get the view's element information that resides at the current position
            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            //Display a hint for row indicator cells
            ShowHiddenFieldsTooltip(e, hi.RowHandle == GridControl.InvalidRowHandle && view.Columns.Count(c => !c.Visible && c.OptionsColumn.AllowShowHide) > 0);
        }

        private static void DrawHiddenFieldsIcon(Graphics g, Rectangle colRect)
        {
            g.DrawImage(Resources.warning12x12, new Rectangle(colRect.X + 1, colRect.Y + 5, 12, 12));
        }
        private static void DrawCustomizationMark(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            var view = sender as GridView;
            if (view != null && e.RowHandle == GridControl.InvalidRowHandle && view.Columns.Count(c => !c.Visible && c.OptionsColumn.AllowShowHide) > 0)
            {
                e.DefaultDraw();
                DrawHiddenFieldsIcon(e.Graphics, e.Bounds);
                e.Handled = true;
            }
        }

        public static void InitXtraTreeCustomization(this TreeList tree, string[] unhidableFields)
        {
            tree.OptionsMenu.EnableColumnMenu = true;
            tree.OptionsCustomization.AllowQuickHideColumns = true;
            tree.OptionsCustomization.AllowColumnMoving = true;
            tree.PopupMenuShowing += OnTreeListPopupMenuShowing;
            tree.ShowCustomizationForm += OnShowCustomizationForm;
            tree.DragObjectOver += OnTreeDragObjectOver;
            tree.Tag = AllowCustomizationMark;
            tree.CustomDrawColumnHeader += DrawTreeCustomizationMark;
            if (tree.MenuManager == null)
            {
                tree.MenuManager = new BarManager() { Form = tree };
            }
            if (tree.ToolTipController == null)
                tree.ToolTipController = new ToolTipController();
            tree.ToolTipController.GetActiveObjectInfo += TreeToolTipController_GetActiveObjectInfo;
            foreach (TreeListColumn col in tree.Columns)
            {
                if (!col.Visible || unhidableFields.Contains(col.FieldName) ||
                    (col.ColumnEdit is RepositoryItemLookUpEdit &&
                     unhidableFields.Contains(((RepositoryItemLookUpEdit)col.ColumnEdit).DisplayMember)))
                {
                    col.OptionsColumn.AllowMoveToCustomizationForm = false;
                    col.OptionsColumn.ShowInCustomizationForm = false;
                }
            }
        }

        private static void OnTreeListPopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            var tree = sender as TreeList;

            var hitInfo = tree.CalcHitInfo(e.Point);
            if (hitInfo.Column.OptionsColumn.AllowMoveToCustomizationForm)
            {
                int index = 0;
                for (; index < e.Menu.Items.Count - 1; index++)
                {
                    var it = e.Menu.Items[index];
                    if (TreeListStringId.MenuColumnColumnCustomization.Equals(it.Tag))
                    {
                        index ++;
                        break;
                    }
                }
                var item = new DXMenuItem(XtraStrings.Get("GridStringId.MenuColumnRemoveColumn", "Remove column"),
                    RemoveTreeListColumn);
                {
                    e.Menu.Items[index-1].BeginGroup = false;
                    e.Menu.Items.Insert(index - 1, item);
                    e.Menu.Items[index-1].BeginGroup = true;
                }
                item.Tag = hitInfo.Column;
            }
        }

        private static void RemoveTreeListColumn(object sender, EventArgs e)
        {
            var item = sender as DXMenuItem;
            if (item != null && item.Tag is TreeListColumn)
            {
                ((TreeListColumn) item.Tag).Visible = false;
            }
        }

        private static void TreeToolTipController_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            var tree = e.SelectedControl as TreeList;
            if (tree == null)
                return;
            //Display a hint for row indicator cells
            ShowHiddenFieldsTooltip(e, tree.Columns.Count(c => !c.Visible && c.OptionsColumn.ShowInCustomizationForm) > 0);
        }

        private static void DrawTreeCustomizationMark(object sender, CustomDrawColumnHeaderEventArgs e)
        {
            var tree = sender as TreeList;
            if (tree != null && e.Column == null && e.ColumnType == HitInfoType.ColumnButton && tree.Columns.Count(c => !c.Visible && c.OptionsColumn.ShowInCustomizationForm) > 0)
            {
                e.DefaultDraw();
                DrawHiddenFieldsIcon(e.Graphics, e.Bounds);
                e.Handled = true;
            }
        }


        private static void OnTreeDragObjectOver(object sender, DevExpress.XtraTreeList.DragObjectOverEventArgs e)
        {
            var column = e.DragObject as TreeListColumn;

            if (column != null && column.TreeList.VisibleColumns.Count == 1 && column.TreeList.VisibleColumns[0] == column && e.DropInfo.Index < 0)
            {
                e.DropInfo.Valid = false;
            }
        }

        //private static void OnTreeListPopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        //{
        //    if (e.Menu == null) return;
        //    if (e.Menu.MenuType != TreeListMenuType.Column) return;
        //    var treeList = sender as TreeList;
        //    if (treeList != null)
        //    {
        //        for (var i = e.Menu.Items.Count - 1; i >= 0; i--)
        //        {
        //            var it = e.Menu.Items[i];
        //            if (!it.Tag.ToString().Equals("MenuColumnRemoveColumn") &&
        //                !it.Tag.ToString().Equals("MenuColumnColumnCustomization"))
        //                e.Menu.Items.Remove(it);
        //            else if (treeList.VisibleColumns.Count == 1 &&
        //                     it.Tag.ToString().Equals("MenuColumnRemoveColumn"))
        //                e.Menu.Items.Remove(it);
        //        }
        //    }
        //}

        private static string GetGridLayoutFilename(string name)
        {
            var di = Directory.GetParent(Application.LocalUserAppDataPath);
            var dir = Path.Combine(di.FullName, "Grids");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            var filename = Path.Combine(dir, Path.ChangeExtension(name, "xml"));
            return filename;
        }

        /// <summary>
        /// Восстановление визуального представления таблицы
        /// </summary>
        public static void LoadGridLayout(this GridView view, string name)
        {
            if (!IsGridCustomizationAllowed(view))
                return;
            var filename = GetGridLayoutFilename(name);
            if ((filename.Length > 0) && (File.Exists(filename)))
            {
                try
                {
                    view.RestoreLayoutFromXml(filename);
                }
                catch
                {
                    //если файл битый, то удаляем его
                    File.Delete(filename);
                }
            }
        }
        public static void LoadTreeLayout(this TreeList tree, string name)
        {
            if (!IsTreeListCustomizationAllowed(tree))
                return;
            var filename = GetGridLayoutFilename(name);
            if ((filename.Length > 0) && (File.Exists(filename)))
            {
                try
                {
                    tree.RestoreLayoutFromXml(filename);
                }
                catch
                {
                    //если файл битый, то удаляем его
                    File.Delete(filename);
                }
            }
        }
        public static void SaveGridLayout(this GridView view, string name)
        {
            if (!IsGridCustomizationAllowed(view))
                return;
            var filename = GetGridLayoutFilename(name);
            try
            {
                if (filename.Length > 0)
                {
                    view.SaveLayoutToXml(filename);
                }

            }
            catch (Exception ex)
            {
                Dbg.Debug("error during layout saving. Layout:{0},\r\n path:{1},\r\n error: {2}", name, filename, ex);
            }
        }
        public static void SaveTreeLayout(this TreeList tree, string name)
        {
            if (!IsTreeListCustomizationAllowed(tree))
                return;
            var filename = GetGridLayoutFilename(name);
            try
            {
                if (filename.Length > 0)
                {
                    tree.SaveLayoutToXml(filename);
                }

            }
            catch (Exception ex)
            {
                Dbg.Debug("error during layout saving. Layout:{0},\r\n path:{1},\r\n error: {2}", name, filename, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="showDateTimeFormatAsNullText"></param>
        public static void InitXtraGridAppearance(this GridControl grid, bool showDateTimeFormatAsNullText)
        {
            grid.MainView.BeginUpdate();
            if (Localizer.IsRtl)
                grid.RightToLeft = RightToLeft.Yes;
            InitDefaultFont();
            if (grid.MainView is GridView)
            {
                var view = (GridView)grid.MainView;
                view.OptionsFilter.AllowColumnMRUFilterList = false;
                view.OptionsFilter.AllowMRUFilterList = false;
                view.OptionsMenu.EnableFooterMenu = false;
                view.OptionsMenu.EnableGroupPanelMenu = false;
                view.OptionsMenu.ShowAutoFilterRowItem = false;
                if (!IsGridCustomizationAllowed(view))
                {
                    view.OptionsMenu.EnableColumnMenu = false;
                    view.OptionsCustomization.AllowQuickHideColumns = false;
                    view.OptionsCustomization.AllowColumnMoving = false;
                }
                view.InvalidRowException -= InvalidRowException;
                view.InvalidRowException += InvalidRowException;
            }

            foreach (GridColumn col in ((GridView)grid.MainView).Columns)
            {
                if (col.ColumnEdit == null)
                {
                    continue;
                }
                if ((col.ColumnEdit) is RepositoryItemLookUpEdit)
                {
                    InitRepositoryLookupItemAppearance((RepositoryItemLookUpEdit)col.ColumnEdit);
                }
                else
                {
                    InitReposiroryItemAppearance(col.ColumnEdit);
                    var edit = col.ColumnEdit as RepositoryItemDateEdit;
                    if (edit != null)
                    {
                        InitRepositoryDateEdit(edit, showDateTimeFormatAsNullText);
                    }
                }
            }

            foreach (AppearanceObject apperance in grid.MainView.Appearance)
            {
                InitAppearance(apperance);
            }
            foreach (GridColumn col in ((GridView)grid.MainView).Columns)
            {
                InitAppearance(col.AppearanceCell);
                InitAppearance(col.AppearanceHeader);
            }

            grid.MainView.EndUpdate();
        }

        private static void OnDragObjectOver(object sender, DragObjectOverEventArgs e)
        {

            var column = e.DragObject as GridColumn;

            if (column != null && column.View.VisibleColumns.Count == 1 && column.View.VisibleColumns[0] == column && e.DropInfo.Index < 0)
            {
                e.DropInfo.Valid = false;
            }
        }

        static private void OnShowCustomizationForm(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
                view.CustomizationForm.Text = XtraStrings.Get("GridStringId.MenuColumnColumnCustomization", "Column Chooser");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void OnGridViewPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu == null) return;
            if (e.Menu.MenuType != GridMenuType.Column) return;
            var view = sender as GridView;
            if (view != null)
            {
                for (var i = e.Menu.Items.Count - 1; i >= 0; i--)
                {
                    var it = e.Menu.Items[i];
                    if (GridStringId.MenuColumnFindFilterShow.Equals(it.Tag)
                        || GridStringId.MenuColumnFilterEditor.Equals(it.Tag)
                        || GridStringId.MenuColumnFilterMode.Equals(it.Tag)
                        || GridStringId.MenuColumnGroupBox.Equals(it.Tag)
                        || GridStringId.MenuColumnGroup.Equals(it.Tag)
                        )
                        e.Menu.Items.Remove(it);
                    else if (it.Tag.ToString().Equals("MenuColumnRemoveColumn") &&
                             (view.VisibleColumns.Count == 1 || !it.Enabled))
                    {
                        e.Menu.Items.Remove(it);
                        e.Menu.Items[i].BeginGroup = true;
                    }
                }
            }
        }

        private static void InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.WindowCaption = BvMessages.Get("Warning");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="showDateTimeFormatAsNullText"></param>
        public static void InitXtraTreeAppearance(this TreeList tree, bool showDateTimeFormatAsNullText)
        {
            tree.BeginUpdate();

            InitDefaultFont();
            tree.Font = WinClientContext.CurrentFont; //
            tree.LookAndFeel.UseDefaultLookAndFeel = true;
            tree.LookAndFeel.Style = LookAndFeelStyle.Skin;
            if (Localizer.IsRtl)
                tree.RightToLeft = RightToLeft.Yes;
            foreach (RepositoryItem item in tree.RepositoryItems)
            {
                if (item is RepositoryItemLookUpEdit)
                {
                    InitRepositoryLookupItemAppearance((RepositoryItemLookUpEdit)item);
                }
                else
                {
                    InitReposiroryItemAppearance(item);
                    if (item is RepositoryItemDateEdit)
                    {
                        if (showDateTimeFormatAsNullText)
                        {
                            item.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        }
                        if (((RepositoryItemDateEdit)item).MinValue == DateTime.MinValue)
                        {
                            ((RepositoryItemDateEdit)item).MinValue = new DateTime(1900, 1, 1);
                        }
                        if (((RepositoryItemDateEdit)item).MaxValue == DateTime.MinValue)
                        {
                            ((RepositoryItemDateEdit)item).MaxValue = new DateTime(2050, 1, 1);
                        }
                    }
                }
            }
            foreach (AppearanceObject apperance in tree.Appearance)
            {
                InitAppearance(apperance);
            }
            tree.EndUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public static void InitXtraTabAppearance(this XtraTabPage page)
        {
            InitDefaultFont();
            page.Font = WinClientContext.CurrentFont; //
            InitAppearance(page.Appearance.Header);
            InitAppearance(page.Appearance.HeaderActive);
            InitAppearance(page.Appearance.HeaderHotTracked);
            InitAppearance(page.Appearance.HeaderDisabled);
        }
        public static void InitXtraTabControlAppearance(this XtraTabControl tab)
        {
            InitDefaultFont();
            tab.Font = WinClientContext.CurrentFont; //
            InitAppearance(tab.Appearance);
            InitAppearance(tab.AppearancePage.Header);
            InitAppearance(tab.AppearancePage.HeaderHotTracked);
            InitAppearance(tab.AppearancePage.HeaderDisabled);
            if (Localizer.IsRtl)
                tab.RightToLeft = RightToLeft.Yes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        public static void InitRadioGroupAppearance(this RadioGroup group)
        {
            InitDefaultFont();
            InitAppearance(group.Properties.Appearance);
            InitAppearance(group.Properties.AppearanceDisabled);
            InitAppearance(group.Properties.AppearanceFocused);
            InitAppearance(group.Properties.AppearanceReadOnly);
            if (Localizer.IsRtl)
                group.RightToLeft = RightToLeft.Yes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edit"></param>
        public static void InitCheckEditAppearance(this CheckEdit edit)
        {
            InitDefaultFont();
            edit.Font = WinClientContext.CurrentFont;
            InitAppearance(edit.Properties.Appearance);
            InitAppearance(edit.Properties.AppearanceDisabled);
            InitAppearance(edit.Properties.AppearanceFocused);
            InitAppearance(edit.Properties.AppearanceReadOnly);
            edit.Properties.AllowFocused = true;
            edit.Properties.FullFocusRect = true;
            //edit.Properties.CheckStyle = CheckStyles.Style1;
            if (string.IsNullOrWhiteSpace(edit.Text))
                edit.Properties.FullFocusRect = true;
            if (Localizer.IsRtl)
                edit.RightToLeft = RightToLeft.Yes;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public static void InitRepositoryLookupItemAppearance(this RepositoryItemLookUpEdit ctl)
        {
            InitDefaultFont();
            InitAppearance(ctl.Appearance);
            InitAppearance(ctl.AppearanceDisabled);
            InitAppearance(ctl.AppearanceDropDown);
            InitAppearance(ctl.AppearanceDropDownHeader);
            InitAppearance(ctl.AppearanceFocused);
            if (ctl.ShowDropDown != ShowDropDown.Never)
            {
                if (BaseSettings.InplaceShowDropDown == "DoubleClick")
                {
                    ctl.ShowDropDown = ShowDropDown.DoubleClick;
                }
                else
                {
                    ctl.ShowDropDown = ShowDropDown.SingleClick;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="force"></param>
        public static void SetPopupControlBehavior(this PopupBaseEdit ctl, bool force)
        {
            if (force || ctl.Properties.ShowDropDown != ShowDropDown.Never)
            {
                if (BaseSettings.ShowDropDown == "DoubleClick")
                {
                    ctl.Properties.ShowDropDown = ShowDropDown.DoubleClick;
                }
                else
                {
                    ctl.Properties.ShowDropDown = ShowDropDown.SingleClick;
                }
            }
            if (Localizer.IsRtl)
                ctl.RightToLeft = RightToLeft.Yes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public static void InitReposiroryItemAppearance(this RepositoryItem ctl)
        {
            InitDefaultFont();
            InitAppearance(ctl.Appearance);
            InitAppearance(ctl.AppearanceDisabled);
            InitAppearance(ctl.AppearanceFocused);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public static void InitGroupControlAppearance(this GroupControl ctl)
        {
            InitDefaultFont();
            InitAppearance(ctl.Appearance);
            InitAppearance(ctl.AppearanceCaption);
            ctl.AppearanceCaption.Reset();
            ctl.Appearance.Reset();
            ctl.LookAndFeel.Style = LookAndFeelStyle.Skin;
            ctl.LookAndFeel.UseDefaultLookAndFeel = true;
            if (Localizer.IsRtl)
                ctl.RightToLeft = RightToLeft.Yes;
        }

        public static void InitBarAppearance(this DefaultBarAndDockingController controller)
        {
            InitDefaultFont();
            InitAppearance(controller.Controller.AppearancesBar.Bar);
            InitAppearance(controller.Controller.AppearancesBar.Dock);
            InitAppearance(controller.Controller.AppearancesBar.MainMenu);
            InitAppearance(controller.Controller.AppearancesBar.StatusBar);
            InitAppearance(controller.Controller.AppearancesBar.SubMenu.Menu);
            InitAppearance(controller.Controller.AppearancesBar.SubMenu.MenuBar);
            InitAppearance(controller.Controller.AppearancesBar.SubMenu.SideStrip);
            InitAppearance(controller.Controller.AppearancesBar.SubMenu.SideStripNonRecent);
            InitAppearance(controller.Controller.AppearancesDocking.ActiveTab);
            InitAppearance(controller.Controller.AppearancesDocking.FloatFormCaption);
            InitAppearance(controller.Controller.AppearancesDocking.FloatFormCaptionActive);
            InitAppearance(controller.Controller.AppearancesDocking.HideContainer);
            InitAppearance(controller.Controller.AppearancesDocking.HidePanelButton);
            InitAppearance(controller.Controller.AppearancesDocking.HidePanelButtonActive);
            InitAppearance(controller.Controller.AppearancesDocking.Panel);
            InitAppearance(controller.Controller.AppearancesDocking.PanelCaption);
            InitAppearance(controller.Controller.AppearancesDocking.PanelCaptionActive);
            InitAppearance(controller.Controller.AppearancesDocking.Tabs);
            controller.Controller.AppearancesBar.ItemsFont = WinClientContext.CurrentFont;
            //New System.Drawing.Font(m_DefaultFontFamily, m_DefaultFontSize)
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        public static void InitPivotGridAppearance(this PivotGridControl grid)
        {
            InitDefaultFont();
            if (Localizer.IsRtl)
                grid.RightToLeft = RightToLeft.Yes;
            foreach (RepositoryItem item in grid.RepositoryItems)
            {
                if (item is RepositoryItemLookUpEdit)
                {
                    InitRepositoryLookupItemAppearance((RepositoryItemLookUpEdit)item);
                }
                else
                {
                    InitReposiroryItemAppearance(item);
                }
            }
            foreach (AppearanceObject apperance in grid.Appearance)
            {
                InitAppearance(apperance);
            }
            foreach (AppearanceObject apperance in grid.AppearancePrint)
            {
                InitAppearance(apperance);
            }
            foreach (AppearanceObject apperance in grid.PaintAppearance)
            {
                InitAppearance(apperance);
            }
            foreach (AppearanceObject apperance in grid.PaintAppearancePrint)
            {
                InitAppearance(apperance);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bar"></param>
        public static void InitNavAppearance(this NavBarControl bar)
        {
            InitDefaultFont();
            if (Localizer.IsRtl)
                bar.RightToLeft = RightToLeft.Yes;
            foreach (AppearanceObject apperance in bar.Appearance)
            {
                InitAppearance(apperance);
            }
            foreach (NavBarGroup group in bar.Groups)
            {
                InitAppearance(group.Appearance);
                InitAppearance(group.AppearanceBackground);
                InitAppearance(group.AppearanceHotTracked);
                InitAppearance(group.AppearancePressed);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbFont"></param>
        public static void InitFontItems(ImageComboBoxEdit cbFont)
        {
            const int width = 20;
            const int height = 16;
            const int offset = 1;

            var il = new ImageList { ImageSize = new Size(width, height) };

            var r = new Rectangle(offset, offset, width - offset * 2, height - offset * 2);

            cbFont.Properties.BeginUpdate();
            try
            {
                cbFont.Properties.Items.Clear();
                cbFont.Properties.SmallImages = il;

                int i;
                int j = 0;
                for (i = 0; i <= FontFamily.Families.Length - 1; i++)
                {
                    try
                    {
                        var f = new Font(FontFamily.Families[i].Name, 8);
                        string s = (FontFamily.Families[i].Name);
                        var im = new Bitmap(width, height);
                        using (Graphics g = Graphics.FromImage(im))
                        {
                            g.FillRectangle(Brushes.White, r);
                            g.DrawString("abc", f, Brushes.Black, offset, offset);
                            g.DrawRectangle(Pens.Black, r);
                        }

                        il.Images.Add(im);

                        cbFont.Properties.Items.Add(new ImageComboBoxItem(s, f, j));
                        j++;
                    }
                    catch (Exception ex)
                    {
                        Dbg.Debug("font items creation error:{0}", ex.ToString());
                    }
                }
            }
            finally
            {
                cbFont.Properties.CancelUpdate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbFont"></param>
        /// <param name="fontName"></param>
        /// <returns></returns>
        public static ImageComboBoxItem FindFontItem(ImageComboBoxEdit cbFont, string fontName)
        {
            return cbFont.Properties.Items.Cast<ImageComboBoxItem>().FirstOrDefault(item => item.Description == fontName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbFontSize"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        public static object FindFontSizeItem(ComboBoxEdit cbFontSize, float fontSize)
        {
            return cbFontSize.Properties.Items.Cast<string>().FirstOrDefault(item => fontSize.ToString().StartsWith(item));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="row"></param>
        /// <param name="pkColName"></param>
        public static void SetRowHandleForDataRow(GridView view, DataRow row, string pkColName)
        {
            for (int i = 0; i <= view.RowCount - 1; i++)
            {
                var gridRow = view.GetDataRow(i);
                if (gridRow[pkColName].Equals(row[pkColName]))
                {
                    view.FocusedRowHandle = i;
                    break;
                }
            }
            view.Focus();
        }

        public static bool SetRowHandleForDataRow(TreeList list, TreeListNodes nodes, DataRow row, string pkColName)
        {
            if (nodes == null)
                nodes = list.Nodes;
            if (nodes == null)
                return false;
            foreach (TreeListNode node in nodes)
            {
                var gridRow = list.GetDataRecordByNode(node) as DataRowView;
                if (gridRow != null && gridRow[pkColName].Equals(row[pkColName]))
                {
                    list.FocusedNode = node;
                    list.Focus();
                    return true;
                }
                if (SetRowHandleForDataRow(list, node.Nodes, row, pkColName))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnSpinEditEditValueChanging(Object sender, ChangingEventArgs e)
        {
            var ctl = (SpinEdit)sender;
            if (ctl.Properties.MinValue != 0 || ctl.Properties.MaxValue != 0)
            {
                e.Cancel = Convert.ToBoolean(ctl.Value < ctl.Properties.MinValue || ctl.Value > ctl.Properties.MaxValue);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public static void HidePlusButton(this ButtonEdit ctl)
        {
            foreach (EditorButton btn in ctl.Properties.Buttons)
            {
                if (btn.Kind == ButtonPredefines.Plus)
                {
                    btn.Visible = false;
                    break;
                }
            }
        }
        public static void SetButtonTooltip(this EditorButtonCollection buttons, ButtonPredefines kind, string tooltip)
        {
            foreach (EditorButton btn in buttons)
            {
                if (btn.Kind == kind)
                {
                    btn.ToolTip = tooltip;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public static void HidePlusButton(this RepositoryItemButtonEdit ctl)
        {
            foreach (EditorButton btn in ctl.Buttons)
            {
                if (btn.Kind == ButtonPredefines.Plus)
                {
                    btn.Visible = false;
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="enabled"></param>
        public static void EnableButtons(this ButtonEdit ctl, bool enabled)
        {
            foreach (EditorButton btn in ctl.Properties.Buttons)
            {
                btn.Enabled = enabled;
            }
        }
        public static void SetButtonsVisibility(this ButtonEdit ctl, bool visible)
        {
            foreach (EditorButton btn in ctl.Properties.Buttons)
            {
                btn.Visible = visible;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="enabled"></param>
        public static void EnableButtons(this RepositoryItemButtonEdit ctl, bool enabled)
        {
            foreach (EditorButton btn in ctl.Buttons)
            {
                btn.Enabled = enabled;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="editorMask"></param>
        public static void SetEnglishEditorMask(this MaskProperties editorMask)
        {
            editorMask.MaskType = MaskType.RegEx;
            editorMask.EditMask = @"[a-zA-Z0-9\+\-\ \(\)\.\,\;\_\/\>\<\=\&\!\@\#\%\^\&\*\~\?]*";
            editorMask.BeepOnError = true;
        }
        public static void SetGridConstraints(GridControl grid, IObjectMeta meta = null)
        {
            foreach (var view in grid.Views)
            {
                SetGridViewConstraints(view as GridView, meta);
            }
        }

        public static void SetGridViewConstraints(GridView grid, IObjectMeta meta = null)
        {
            if (grid == null || grid.GridControl.DataSource == null || !grid.OptionsBehavior.Editable || grid.OptionsBehavior.ReadOnly)
                return;
            DataTable table = null;

            if (grid.GridControl.DataSource is DataView)
                table = ((DataView)grid.GridControl.DataSource).Table;
            else if (grid.GridControl.DataSource is DataTable)
                table = (DataTable)grid.GridControl.DataSource;
            if (table == null && meta == null)
            {
                return;
            }
            foreach (GridColumn col in grid.Columns)
            {
                if (!string.IsNullOrEmpty(col.FieldName))
                {

                    int? len = 0;
                    if (meta != null)
                        len = meta.MaxSize(col.FieldName);
                    else
                        len = GetFieldLength(table, col.FieldName);

                    if (len.HasValue && len.Value > 0 && col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                    {
                        if (col.ColumnEdit == null)
                            col.ColumnEdit = GetTextColumnEdit(len.Value);
                        else if (col.ColumnEdit is RepositoryItemTextEdit)
                            ((RepositoryItemTextEdit)col.ColumnEdit).MaxLength = len.Value;
                    }
                }

            }

        }
        public static int GetFieldLength(DataTable table, string fieldName)
        {
            DataColumn col = table.Columns[fieldName];
            if (col == null)
                return 0;
            if (col.DataType == typeof(string) && col.MaxLength > 0)
                return col.MaxLength;
            return 0;
        }
        public static RepositoryItemTextEdit GetTextColumnEdit(int len)
        {
            return new RepositoryItemTextEdit() { MaxLength = len };
        }
        public static void InitDateEdit(DateEdit dateEdit)
        {
            if (BaseSettings.ShowDateTimeFormatAsNullText)
            {
                dateEdit.Properties.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            }
            if (dateEdit.Properties.MinValue == DateTime.MinValue)
            {
                dateEdit.Properties.MinValue = new DateTime(1900, 1, 1);
            }
            if (dateEdit.Properties.MaxValue == DateTime.MinValue)
            {
                dateEdit.Properties.MaxValue = new DateTime(2050, 1, 1);
            }
            if (Localizer.IsRtl)
                dateEdit.RightToLeft = RightToLeft.Yes;

        }
        public static void InitRepositoryDateEdit(RepositoryItemDateEdit dateEdit, bool showDateTimeFormatAsNullText)
        {
            if (showDateTimeFormatAsNullText)
            {
                dateEdit.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            }
            if (dateEdit.MinValue == DateTime.MinValue)
            {
                dateEdit.MinValue = new DateTime(1900, 1, 1);
            }
            if (dateEdit.MaxValue == DateTime.MinValue)
            {
                dateEdit.MaxValue = new DateTime(2050, 1, 1);
            }

        }
        public static void SetButtonEditButtonVisibility(ButtonEdit edit, ButtonPredefines buttonKind, bool visible)
        {
            if (edit == null)
                return;
            foreach (EditorButton button in edit.Properties.Buttons)
            {
                if (button.Kind == buttonKind)
                {
                    button.Visible = visible;
                    return;
                }
            }
        }
        public static void SetButtonEditButtonVisibility(RepositoryItemButtonEdit edit, ButtonPredefines buttonKind, bool visible)
        {
            if (edit == null)
                return;
            foreach (EditorButton button in edit.Buttons)
            {
                if (button.Kind == buttonKind)
                {
                    button.Visible = visible;
                    return;
                }
            }
        }


        public static void HideButtonEditButton(ButtonEdit edit, ButtonPredefines buttonKind)
        {
            SetButtonEditButtonVisibility(edit, buttonKind, false);
        }
        public static void ShowButtonEditButton(ButtonEdit edit, ButtonPredefines buttonKind)
        {
            SetButtonEditButtonVisibility(edit, buttonKind, true);
        }

        public static void SetButtonEditButtonEnabledState(ButtonEdit edit, ButtonPredefines buttonKind, bool enabled)
        {
            if (edit == null)
                return;
            foreach (EditorButton button in edit.Properties.Buttons)
            {
                if (button.Kind == buttonKind)
                {
                    button.Visible = enabled;
                    return;
                }
            }
        }
        public static void EnableButtonEditButton(ButtonEdit edit, ButtonPredefines buttonKind)
        {
            SetButtonEditButtonEnabledState(edit, buttonKind, true);
        }
        public static void DisableButtonEditButton(ButtonEdit edit, ButtonPredefines buttonKind)
        {
            SetButtonEditButtonEnabledState(edit, buttonKind, false);
        }
        public static void DisableClearButtonForEmptyEdit
            (ButtonEdit ctl, bool readOnly, params BaseEdit[] relatedControls)
        {
            bool isEmpty;
            if (relatedControls != null)
                isEmpty = relatedControls.All(c => string.IsNullOrEmpty(c.Text));
            else
                isEmpty = string.IsNullOrEmpty(ctl.Text);
            SetButtonEditButtonEnabledState(ctl, ButtonPredefines.Delete, !readOnly && !isEmpty);
        }
        public static void ApplyNullValueStyle(BaseEdit edit)
        {
            if (Utils.IsEmpty(edit.EditValue))
            {
                if (!edit.Properties.Appearance.Font.Italic)
                {
                    edit.Properties.Appearance.Font = new Font(WinClientContext.CurrentFont, FontStyle.Italic);
                    edit.Properties.Appearance.ForeColor = Color.Gray;
                }
            }
            else if (edit.Properties.Appearance.Font.Italic)
            {
                edit.Properties.Appearance.Reset();
                edit.Properties.Appearance.Font = WinClientContext.CurrentFont;

            }
        }

    }
}
