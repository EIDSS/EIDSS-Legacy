using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList.Nodes;
using bv.common.Configuration;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Core;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;

namespace bv.winclient.Localization
{
    public static class DxControlsHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static void InitDefaultFont()
        {
            if (AppearanceObject.DefaultFont != WinClientContext.CurrentFont)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="showDateTimeFormatAsNullText"></param>
        public static void InitXtraGridAppearance(this GridControl grid, bool showDateTimeFormatAsNullText)
        {
            InitDefaultFont();
            if (grid.MainView is GridView)
            {
                var view = (GridView)grid.MainView;
                view.OptionsFilter.AllowColumnMRUFilterList = false;
                view.OptionsFilter.AllowMRUFilterList = false;
                var isOldFramework = !(grid.Parent is BaseListGridControl);
                if (isOldFramework)
                {
                    view.OptionsMenu.EnableColumnMenu = false;
                    view.OptionsCustomization.AllowQuickHideColumns = false;
                    view.OptionsCustomization.AllowColumnMoving = false;
                }
                view.OptionsMenu.EnableFooterMenu = false;
                view.OptionsMenu.EnableGroupPanelMenu = false;
                view.InvalidRowException -= InvalidRowException;
                view.InvalidRowException += InvalidRowException;
            }
            //For Each item As Repository.RepositoryItem In grid.RepositoryItems
            //    If TypeOf item Is Repository.RepositoryItemLookUpEdit Then
            //        InitReposiroryLookupItemAppearance(CType(item, Repository.RepositoryItemLookUpEdit))
            //    Else
            //        InitReposiroryItemAppearance(item)
            //        If TypeOf item Is Repository.RepositoryItemDateEdit Then
            //            If ShowDateTimeFormatAsNullText Then
            //                CType(item, Repository.RepositoryItemDateEdit).NullText = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            //            End If
            //            If CType(item, Repository.RepositoryItemDateEdit).MinValue = DateTime.MinValue Then
            //                CType(item, Repository.RepositoryItemDateEdit).MinValue = New Date(1900, 1, 1)
            //            End If
            //            If CType(item, Repository.RepositoryItemDateEdit).MaxValue = DateTime.MinValue Then
            //                CType(item, Repository.RepositoryItemDateEdit).MaxValue = New Date(2050, 1, 1)
            //            End If
            //        End If
            //    End If
            //Next
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
                    if (col.ColumnEdit is RepositoryItemDateEdit)
                    {
                        if (showDateTimeFormatAsNullText)
                        {
                            col.ColumnEdit.NullText = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        }
                        if (((RepositoryItemDateEdit)col.ColumnEdit).MinValue == DateTime.MinValue)
                        {
                            ((RepositoryItemDateEdit)col.ColumnEdit).MinValue = new DateTime(1900, 1, 1);
                        }
                        if (((RepositoryItemDateEdit)col.ColumnEdit).MaxValue == DateTime.MinValue)
                        {
                            ((RepositoryItemDateEdit)col.ColumnEdit).MaxValue = new DateTime(2050, 1, 1);
                        }
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
            InitDefaultFont();
            tree.Font = WinClientContext.CurrentFont; //
            tree.LookAndFeel.UseDefaultLookAndFeel = true;
            tree.LookAndFeel.Style = LookAndFeelStyle.Skin;
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
            if (string.IsNullOrWhiteSpace(edit.Text))
                edit.Properties.FullFocusRect = true;

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
            if(table == null && meta == null)
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
        public static int GetFieldLength( DataTable table, string fieldName)
        {
            DataColumn col = table.Columns[fieldName];
            if(col ==null)
                return 0;
            if (col.DataType == typeof(string) && col.MaxLength > 0 )
                return col.MaxLength;
            return 0;
        }
        public static RepositoryItemTextEdit GetTextColumnEdit(int len)
        {
            return new RepositoryItemTextEdit() { MaxLength = len };
        }
    }
}
