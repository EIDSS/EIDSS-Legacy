using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using Microsoft.VisualBasic.Devices;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.common.Resources.TranslationTool;
using bv.model.Model.Core;
using bv.model.ResourcesUsage;
using bv.model.TranslationDictionary;
using bv.winclient.ActionPanel;
using bv.winclient.BasePanel;
using System.Linq;
using System.Drawing;
using bv.winclient.Layout;
using bv.winclient.SearchPanel;

namespace bv.winclient.Core.TranslationTool
{
    public class DesignControlManager
    {
        private enum AlignType
        {
            Top,
            Bottom,
            Middle,
            Left,
            Right,
            Center,
            Width,
            Height

        }
        private List<ControlDesigner> SelectedControls { get; set; }
        //private TranslationToolHelperWinClient ParentHelper { get; set; }
        readonly List<Control> m_SupportedControls;
        readonly List<Control> m_UnsupportedControls;
        readonly List<ControlDesignerProxy> m_ProxyList;
        internal DesktopResourceUsage ResUsage { get; set; }
        internal TrDictionary TranslationDictionary { get; set; }
        private readonly List<ITranslationView> m_Views;
        private readonly Control m_TopLevelControl;
        /// <summary>
        /// Контролы, которые были скрыты в ресурсах
        /// </summary>
        public List<Control> HiddenControls { get; set; }
        public string Culture { get; private set; }
        public event EventHandler OnControlBoundChange;
        private void RaiseControlBoundChangedEvent(ControlDesigner ctl)
        {
            if (OnControlBoundChange != null)
            {
                OnControlBoundChange(ctl, EventArgs.Empty);
            }
        }

        private readonly ITranslationView m_TranslationView;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ttForm"></param>
        public static void Create(ITranslationView ttForm)
        {
            ttForm.DCManager = new DesignControlManager(ttForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        private DesignControlManager(ITranslationView view)
        {
            if (view == null)
                return;
            if (TranslationToolHelper.TranslationsDir == null)
                TranslationToolHelper.TranslationsDir = Path.Combine(Application.StartupPath,
                                                                     TranslationToolHelper.TranslationsDirectoryName);
            Culture = CustomCultureHelper.SupportedLanguages[ModelUserContext.CurrentLanguage];
            m_Views = new List<ITranslationView>();
            view.AddButtons();
            m_TranslationView = view;
            OnControlBoundChange += view.ControlBoundChange;
            m_ProxyList = new List<ControlDesignerProxy>();
            SelectedControls = new List<ControlDesigner>();
            HiddenControls = new List<Control>();
            var xmlDict = Path.Combine(Path.Combine(Application.StartupPath, TranslationToolHelper.ResourceUsageDirectoryName), "TranslationDictionary.xml");
            var xmlCurrTranslations = Path.Combine(Path.Combine(Application.StartupPath, TranslationToolHelper.ResourceUsageDirectoryName),
                                                   "TranslationsCurrent.xml");
            TranslationDictionary = new TrDictionary();
            TranslationDictionary.Init(xmlDict, xmlCurrTranslations);


            var xmlForms = Path.Combine(Path.Combine(Application.StartupPath, TranslationToolHelper.ResourceUsageDirectoryName), "FormList.xml");
            var xmlResources = Path.Combine(Path.Combine(Application.StartupPath, TranslationToolHelper.ResourceUsageDirectoryName), "ResourceUsing.xml");
            ResUsage = new DesktopResourceUsage(xmlForms, xmlResources);

            m_TopLevelControl = view as Control;
            var panel = view as IBasePanel;
            if (panel != null)
                m_TopLevelControl = (Control)panel.GetLayout();
            if (!BaseSettings.TranslationMode || m_TopLevelControl == null) return;

            ApplyResources(m_TopLevelControl as ITranslationView);

            //создаём один экземпляр меню
            m_Menu = GetDefaultMenu();

            TranslationToolHelperWinClient.SeparateControls(m_TopLevelControl.Controls, out m_SupportedControls, out m_UnsupportedControls);

            var parentForm = m_TopLevelControl.FindForm();
            if (parentForm != null)
                parentForm.KeyDown += OnKeyDown;
        }
        /// <summary>
        /// Must be called when m_TranslationView is closed
        /// </summary>
        public void Release()
        {
            var parentForm = ((Control)m_TranslationView).FindForm();
            if (parentForm != null)
                parentForm.KeyDown -= OnKeyDown;
            m_UndoStack.Clear();
        }

        /// <summary>
        /// this event handler processes Ctrl-Z press for undo operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //In main form perform undo if active form owns current instance of DesignControlManager;
            if (e.Control && e.KeyCode == Keys.Z && IsDesignMode && HasChanges && (sender != BaseFormManager.MainForm || m_TranslationView == BaseFormManager.CurrentForm))
            {
                Undo();
                e.Handled = true;
            }

        }

        #region Design mode support
        private bool m_IsDesignMode;
        public bool IsDesignMode
        {
            get { return m_IsDesignMode; }
            set
            {
                if (value)
                {
                    if (!m_IsDesignMode)
                        SwitchToDesignTimeMode();
                }
                else if (m_IsDesignMode)
                    SwitchToRunTimeMode();
                m_IsDesignMode = value;
            }
        }


        public void SwitchToDesignTimeMode()
        {
            //
            foreach (var ctrl in m_SupportedControls)
            {
                if (ctrl is TranslationButton)
                    continue;
                if (!ctrl.Visible)
                    continue;
                var processedControl = ctrl;
                if (TranslationToolHelperWinClient.IsControlToBlock(processedControl))
                {
                    var proxy = new ControlDesignerProxy { HostControl = processedControl };
                    m_ProxyList.Add(proxy);
                    if (proxy.RelatedProxy != null)
                        foreach (var relProxy in proxy.RelatedProxy)
                        {
                            m_ProxyList.Add(relProxy);
                            if (TranslationToolHelperWinClient.IsEditableControl(relProxy))
                            {
                                relProxy.DoubleClick += OnDoubleClick;
                            }
                            relProxy.Click += OnClick;
                            //для групповых операций и для показа контекстного меню
                            relProxy.MouseDown += OnMouseDown;

                        }
                    processedControl = proxy;

                }
                //меню команд на выделенном контроле (из SelectedControls)
                //processedControl.ContextMenuStrip = GetContextMenu(processedControl);

                //для показа контрола редактирования 
                //если его можно редактировать
                if (TranslationToolHelperWinClient.IsEditableControl(processedControl))
                {
                    processedControl.DoubleClick += OnDoubleClick;
                }
                processedControl.Click += OnClick;
                //для групповых операций и для показа контекстного меню
                processedControl.MouseDown += OnMouseDown;
            }
            //проходим по всем прочим контролам
            ((Control)m_TranslationView).Click += OnUnselectAll;
            foreach (var control in m_UnsupportedControls)
            {
                if (control is TranslationButton)
                    continue;
                control.Click += OnUnselectAll;
            }

        }
        public void SwitchToRunTimeMode()
        {
            //
            UnSelectAll();
            foreach (var ctrl in m_SupportedControls)
            {
                if (ctrl is TranslationButton)
                    continue;
                if (!ctrl.Visible)
                    continue;
                var processedControl = ctrl;
                if (TranslationToolHelperWinClient.IsControlToBlock(processedControl))
                {
                    continue;
                }
                //меню команд на выделенном контроле (из SelectedControls)
                processedControl.ContextMenuStrip = null;

                //для показа контрола редактирования 
                //если его можно редактировать
                if (TranslationToolHelperWinClient.IsEditableControl(processedControl))
                {
                    processedControl.DoubleClick -= OnDoubleClick;
                }
                processedControl.Click -= OnClick;
                //для групповых операций
                processedControl.MouseDown -= OnMouseDown;
            }

            foreach (var ctrl in m_ProxyList)
            {
                //меню команд на выделенном контроле (из SelectedControls)
                ctrl.ContextMenuStrip = null;

                //для показа контрола редактирования 
                //если его можно редактировать
                if (TranslationToolHelperWinClient.IsEditableControl(ctrl))
                {
                    ctrl.DoubleClick -= OnDoubleClick;
                }
                //для групповых операций
                ctrl.MouseDown -= OnMouseDown;
                ctrl.Dispose();
            }
            m_ProxyList.Clear();
            //проходим по всем прочим контролам
            ((Control)m_TranslationView).Click -= OnUnselectAll;
            foreach (var control in m_UnsupportedControls)
            {
                if (control is TranslationButton)
                    continue;
                control.Click -= OnUnselectAll;
            }

        }
        #endregion

        #region Popup menu support
        private ContextMenuStrip m_Menu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip GetDefaultMenu()
        {
            miRename = new ToolStripMenuItem { Name = "miRename", Text = BvMessages.Get("TranslationTool_Rename") };
            miVerticalAlign = new ToolStripMenuItem { Name = "mi", Text = "Vertical Align" };
            var miAlignTops = new ToolStripMenuItem { Name = "miAlignTops", Text = "Align Tops" };
            var miAlignBottoms = new ToolStripMenuItem { Name = "miAlignBottoms", Text = "Align Bottoms" };
            var miAlignMiddles = new ToolStripMenuItem { Name = "miAlignMiddles", Text = BvMessages.Get("TranslationTool_AlignMiddles") };
            var miAlignHeights = new ToolStripMenuItem { Name = "miAlignHeights", Text = "Make Heights Equal" };
            miVerticalAlign.DropDownItems.Add(miAlignTops);
            miVerticalAlign.DropDownItems.Add(miAlignBottoms);
            miVerticalAlign.DropDownItems.Add(miAlignMiddles);
            miVerticalAlign.DropDownItems.Add(miAlignHeights);

            miHorizontalAlign = new ToolStripMenuItem { Name = "mi", Text = "Horizontal Align" };
            var miAlignLefts = new ToolStripMenuItem { Name = "miAlignLefts", Text = BvMessages.Get("TranslationTool_AlignLefts") };
            var miAlignRights = new ToolStripMenuItem { Name = "miAlignRights", Text = BvMessages.Get("TranslationTool_AlignRights") };
            var miAlignCenters = new ToolStripMenuItem { Name = "miAlignCenters", Text = "Align Centers" };
            var miAlignWidths = new ToolStripMenuItem { Name = "miAlignWidths", Text = "Make Widths Equal" };
            miHorizontalAlign.DropDownItems.Add(miAlignLefts);
            miHorizontalAlign.DropDownItems.Add(miAlignRights);
            miHorizontalAlign.DropDownItems.Add(miAlignCenters);
            miHorizontalAlign.DropDownItems.Add(miAlignWidths);

            miHide = new ToolStripMenuItem { Name = "miHide", Text = BvMessages.Get("TranslationTool_Hide") };
            miSeparatorRename = new ToolStripSeparator { Name = "miSeparatorRename" };

            miRename.Click += OnMiRenameClick;
            miAlignLefts.Click += OnMiAlignLeftsClick;
            miAlignRights.Click += OnMiAlignRightsClick;
            miAlignCenters.Click += OnMiAlignCentersClick;
            miAlignWidths.Click += OnMiAlignWidthsClick;

            miAlignTops.Click += OnMiAlignTopsClick;
            miAlignBottoms.Click += OnMiAlignBottomsClick;
            miAlignMiddles.Click += OnMiAlignMiddlesClick;
            miAlignHeights.Click += OnMiAlignHeightsClick;
            miHide.Click += OnMiHideClick;
            miDictionary = new ToolStripMenuItem { Name = "miDictValue", Text = "Rename to", Visible = false };
            miDictionary.Click += OnMiRenameToItemNameClick;
            miNonDictionary = new ToolStripMenuItem { Name = "miNonDictValue", Text = "All translations", Visible = false };
            var menu = new ContextMenuStrip();
            menu.Items.AddRange(new ToolStripItem[] { miRename, miSeparatorRename, miDictionary, miNonDictionary, miHorizontalAlign, miVerticalAlign, miHide });
            menu.Opening += OnMenuOpening;
            return menu;
        }
        /// <summary>
        /// Динамическое построение контекстного меню
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private ContextMenuStrip GetContextMenu(Control control)
        {
            miDictionary.Visible = false;
            miNonDictionary.Visible = false;
            miNonDictionary.DropDownItems.Clear();
            var engTxt = GetControlEnglishText(control);
            var currentText = GetControlText(control);
            if (string.IsNullOrEmpty(engTxt))
                return m_Menu;
            var engWord = TranslationDictionary[engTxt];
            // no translations - return default menu
            if (engWord == null)
                return m_Menu;

            string dictTxt = engWord.GetDictionaryTranslation(Culture);
            if (dictTxt != null && dictTxt != currentText)
            {
                miDictionary.Text = string.Format(BvMessages.Get("strRenameTo"), dictTxt);
                miDictionary.Tag = dictTxt;
            }
            List<string> notdicts = engWord.GetNotDictionaryTranslations(Culture).Where(c => c != currentText).ToList();
            if (notdicts.Count > 0)
            {
                miNonDictionary.Visible = true;
                foreach (string notdict in notdicts)
                {
                    var miNotDictsItem = new ToolStripMenuItem { Text = string.Format(BvMessages.Get("strRenameTo"), notdict), Tag = notdict };
                    miNotDictsItem.Click += OnMiRenameToItemNameClick;
                    miNonDictionary.DropDownItems.Add(miNotDictsItem);
                }
            }
            return m_Menu;
        }

        private string GetControlEnglishText(Control ctl)
        {
            var currentCursorPosition = new Point(Cursor.Position.X, Cursor.Position.Y);
            var relativePosition = ctl.PointToClient(currentCursorPosition);
            Control realControl = ctl;
            var proxy = ctl as ControlDesignerProxy;
            if (proxy != null /*&& IsComplexControl(proxy.HostControl)*/)
                realControl = proxy.HostControl;
            var propName = GetCaptionPropertyName(realControl, relativePosition);
            if (propName == string.Empty)
                return string.Empty;
            var view = GetControlView(realControl);
            if (view != null && view.ResourcesList.ContainsKey(propName) && !string.IsNullOrEmpty(view.ResourcesList[propName].EnglishText))
                return view.ResourcesList[propName].EnglishText;
            return realControl.Text;
        }
        private string GetControlText(Control ctl)
        {
            var currentCursorPosition = new Point(Cursor.Position.X, Cursor.Position.Y);
            var relativePosition = ctl.PointToClient(currentCursorPosition);
            Control realControl = ctl;
            var proxy = ctl as ControlDesignerProxy;
            if (proxy != null /*&& IsComplexControl(proxy.HostControl)*/)
                realControl = proxy.HostControl;
            Component editedObject = GetComponentUnderMouse(realControl, relativePosition);
            if (editedObject != null)
                return TranslationToolHelperWinClient.GetComponentText(editedObject);
            return string.Empty;
        }

        private Component GetComponentUnderMouse(Control ctl, Point relativePosition)
        {
            Component editedObject = null;
            if (ctl is TreeList)
                editedObject = GetTreeListColumnAtPoint((TreeList)ctl, relativePosition);
            else if (ctl is GridControl)
                editedObject = GetGridColumnAtPoint((GridControl)ctl, relativePosition);
            else if (ctl is XtraTabControl)
                editedObject = GetTabPageAtPoint((XtraTabControl)ctl, relativePosition);
            else if (ctl is GroupBox)
                editedObject = GetGroupBoxCaptionAtPoint(ctl, relativePosition);
            else if (ctl is GroupControl)
                editedObject = GetGroupControlCaptionAtPoint((GroupControl)ctl, relativePosition);
            else if (IsElementTranslatable(ctl))
                editedObject = ctl;
            return editedObject;

        }
        private string GetCaptionPropertyName(Control ctl, Point relativePosition)
        {
            Component editedObject = GetComponentUnderMouse(ctl, relativePosition);
            if (editedObject != null)
            {
                string text = "";
                return TranslationToolHelperWinClient.GetTextPropertyName(ctl, ref text);
            }
            return string.Empty;
        }

        private Component GetTreeListColumnAtPoint(TreeList tree, Point pt)
        {

            var hi = tree.CalcHitInfo(pt);
            if (hi.HitInfoType.Equals(HitInfoType.Column) && IsElementTranslatable(hi.Column))
                return hi.Column;
            return null;
        }

        //private string GetTreeListCaptionProperty(TreeList tree, Point pt)
        //{

        //    var hi = tree.CalcHitInfo(pt);
        //    if (hi.HitInfoType.Equals(HitInfoType.Column) && IsElementTranslatable(hi.Column))
        //        return TranslationToolHelper.GetPropertyName(hi.Column.Name, TranslationToolHelper.CaptionPropName);
        //    return string.Empty;
        //}

        private Component GetGridColumnAtPoint(GridControl grid, Point pt)
        {
            var hi = ((GridView)grid.FocusedView).CalcHitInfo(pt);
            if (hi.InColumn && IsElementTranslatable(hi.Column))
                return hi.Column;
            return null;
        }
        //private string GetGridCaptionProperty(GridControl grid, Point pt)
        //{
        //    var hi = ((GridView)grid.FocusedView).CalcHitInfo(pt);
        //    if (hi.InColumn && IsElementTranslatable(hi.Column))
        //        return TranslationToolHelper.GetPropertyName(hi.Column.Name, TranslationToolHelper.CaptionPropName);
        //    return string.Empty;
        //}

        //private string GetTabCaptionProperty(XtraTabControl tc, Point pt)
        //{
        //    var hi = tc.CalcHitInfo(pt);
        //    if (hi.HitTest == XtraTabHitTest.PageHeader && IsElementTranslatable(hi.Page))
        //        return TranslationToolHelper.GetPropertyName(hi.Page.Name, TranslationToolHelper.TextPropName);
        //    return string.Empty;
        //}
        private Component GetTabPageAtPoint(XtraTabControl tc, Point pt)
        {
            var hi = tc.CalcHitInfo(pt);
            if (hi.HitTest == XtraTabHitTest.PageHeader && IsElementTranslatable(hi.Page))
                return hi.Page;
            return null;
        }

        private Component GetGroupBoxCaptionAtPoint(Control ctl, Point pt)
        {
            if (pt.X >= 0 && pt.X <= ctl.Width && pt.Y >= 0 && pt.Y <= 23 && IsElementTranslatable(ctl))
            {
                return ctl;
            }
            return null;
        }

        //private string GetGroupBoxCaptionProperty(Control ctl, Point pt)
        //{
        //    if (pt.X >= 0 && pt.X <= ctl.Width && pt.Y >= 0 && pt.Y <= 23 && IsElementTranslatable(ctl))
        //    {
        //        return TranslationToolHelper.GetPropertyName(ctl.Name, TranslationToolHelper.TextPropName);
        //    }
        //    return string.Empty;
        //}
        private Component GetGroupControlCaptionAtPoint(GroupControl ctl, Point pt)
        {
            var info = ReflectionHelper.GetProperty(ctl, "ViewInfo", BindingFlags.NonPublic | BindingFlags.Instance) as DevExpress.Utils.Drawing.GroupObjectInfoArgs;
            if (info != null && IsElementTranslatable(ctl) && pt.X >= info.CaptionBounds.Location.X && pt.X <= info.CaptionBounds.Size.Width && pt.Y >= info.CaptionBounds.Location.Y && pt.Y <= info.CaptionBounds.Size.Height)
            {
                return ctl;
            }
            return null;
        }
        //private string GetGroupControlCaptionProperty(GroupControl ctl, Point pt)
        //{
        //    var info = ReflectionHelper.GetProperty(ctl, "ViewInfo", BindingFlags.NonPublic | BindingFlags.Instance) as DevExpress.Utils.Drawing.GroupObjectInfoArgs;
        //    if (info != null && IsElementTranslatable(ctl) && pt.X >= info.CaptionBounds.Location.X && pt.X <= info.CaptionBounds.Size.Width && pt.Y >= info.CaptionBounds.Location.Y && pt.Y <= info.CaptionBounds.Size.Height)
        //    {
        //        return TranslationToolHelper.GetPropertyName(ctl.Name, TranslationToolHelper.TextPropName);
        //    }
        //    return string.Empty;
        //}

        private Control m_MenuSourceControl;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMenuOpening(object sender, CancelEventArgs e)
        {
            var menu = sender as ContextMenuStrip;
            if (menu == null) return;
            m_MenuSourceControl = menu.SourceControl;
            if (menu.SourceControl == null) return;
            miHide.Visible = !TranslationToolHelperWinClient.IsMandatoryControl(menu.SourceControl);
            miRename.Enabled = TranslationToolHelperWinClient.IsEditableControl(menu.SourceControl);
            miSeparatorRename.Visible = miRename.Visible = miSeparatorRename.Enabled = miRename.Enabled;
            miHorizontalAlign.Enabled = SelectedControls.Count > 1 && SelectedControls.All(ctl => ctl.MovingEnabled | ctl.SizingEnabled);
            miVerticalAlign.Visible = miHorizontalAlign.Visible = miVerticalAlign.Enabled = miHorizontalAlign.Enabled;
            int count = menu.Items.Cast<ToolStripItem>().Count(item => item != null && item.Enabled);
            e.Cancel = menu.Items.Cast<ToolStripItem>().Count(item => item != null && item.Enabled) == 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMiHideClick(object sender, EventArgs e)
        {
            var mi = sender as ToolStripMenuItem;
            if (mi == null) return;
            var menu = mi.GetCurrentParent() as ContextMenuStrip;
            if (menu == null) return;
            if (menu.SourceControl == null) return;
            //отыскиваем контрол и прячем его
            var realControl = menu.SourceControl;
            if (realControl is ControlDesignerProxy)
                realControl = ((ControlDesignerProxy)realControl).HostControl;
            var view = GetControlView(realControl);
            if (view.CanHideControl(realControl))
            {
                m_UndoStack.Push(realControl, true);
                realControl.Visible = false;
                if (realControl != menu.SourceControl)
                    menu.SourceControl.Visible = false;
                HiddenControls.Add(realControl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMiRenameToItemNameClick(object sender, EventArgs e)
        {
            var mi = sender as ToolStripMenuItem;
            if (mi == null) return;
            //var menu = ((ToolStripDropDownMenu)mi.GetCurrentParent()).OwnerItem.GetCurrentParent() as ContextMenuStrip;
            //if (menu == null) return;
            //if (menu.SourceControl == null) return;
            if (m_MenuSourceControl == null)
                return;
            var realControl = m_MenuSourceControl;
            if (realControl is ControlDesignerProxy)
                realControl = ((ControlDesignerProxy)realControl).HostControl;
            m_UndoStack.Push(realControl, realControl.Text);
            realControl.Text = mi.Tag.ToString();
        }
        private void MoveControl(ControlDesigner ctl, int x, int y)
        {
            ctl.MoveControl(x, y);
            RaiseControlBoundChangedEvent(ctl);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="align"></param>
        private void AlignRoutines(AlignType align)
        {
            if (SelectedControls.Count < 2) return;
            //всё равняем по первому выбранному контролу
            var sc = SelectedControls[0];
            var screenRect = sc.ScreenRect;
            var state = new UndoControlState { Element = sc.ProcessedControl, Bounds = sc.RealControl.Bounds, Operation = UndoOperation.Position };
            CreateMultiSelectUndoState(sc, new ControlDesignerEventArgs { UndoState = state });
            switch (align)
            {
                case AlignType.Left: //left
                    foreach (var ctrl in SelectedControls)
                    {
                        if (ctrl == sc || !ctrl.MovingEnabled) continue;
                        int shift = (screenRect.Left - ctrl.LeftToScreen);
                        MoveControl(ctrl, ctrl.Left + shift, ctrl.Top);
                    }
                    break;
                case AlignType.Right: //right
                    var rightBorder = screenRect.Left + sc.Width;
                    foreach (var ctrl in SelectedControls)
                    {
                        if (ctrl == sc || !ctrl.MovingEnabled) continue;
                        int shift = rightBorder - (ctrl.LeftToScreen + ctrl.Width);
                        MoveControl(ctrl, ctrl.Left + shift, ctrl.Top);
                    }
                    break;
                case AlignType.Center:
                    var centerLevel = screenRect.Left + sc.Width / 2;
                    foreach (var ctrl in SelectedControls)
                    {
                        if (ctrl == sc || !ctrl.MovingEnabled) continue;
                        int shift =  centerLevel -  (ctrl.LeftToScreen + ctrl.Width / 2);
                        MoveControl(ctrl, ctrl.Left + shift, ctrl.Top);
                    }
                    break;
                case AlignType.Top: 
                    foreach (var ctrl in SelectedControls)
                    {
                        if (ctrl == sc || !ctrl.MovingEnabled) continue;
                        int shift = screenRect.Top - ctrl.TopToScreen;
                        MoveControl(ctrl, ctrl.Left, ctrl.Top + shift);
                    }
                    break;
                case AlignType.Bottom: //right
                    var bottom = screenRect.Top + sc.Height;
                    foreach (var ctrl in SelectedControls)
                    {
                        if (ctrl == sc || !ctrl.MovingEnabled) continue;
                        int shift = bottom - (ctrl.TopToScreen + ctrl.Height);
                        MoveControl(ctrl, ctrl.Left, ctrl.Top + shift);
                    }
                    break;
                case AlignType.Middle: //middle
                    var middleLevel = screenRect.Top + sc.Height / 2;
                    foreach (var ctrl in SelectedControls)
                    {
                        if (ctrl == sc || !ctrl.MovingEnabled) continue;
                        int shift = middleLevel - (ctrl.TopToScreen + ctrl.Height / 2);
                        MoveControl(ctrl, ctrl.Left, ctrl.Top + shift);
                    }
                    break;
                case AlignType.Width: //right
                    foreach (var ctrl in SelectedControls)
                    {
                        if (ctrl == sc || !ctrl.SizingEnabled) continue;
                        ctrl.SetWidth(sc.Width);
                        RaiseControlBoundChangedEvent(ctrl);
                    }
                    break;
                case AlignType.Height: //right
                    foreach (var ctrl in SelectedControls)
                    {
                        if (ctrl == sc || !ctrl.SizingEnabled) continue;
                        ctrl.SetHeight(sc.Height);
                        RaiseControlBoundChangedEvent(ctrl);
                    }
                    break;
            }
            PushToUndoStack(sc, new ControlDesignerEventArgs { UndoState = state });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMiAlignMiddlesClick(object sender, EventArgs e)
        {
            AlignRoutines(AlignType.Middle);
        }
        void OnMiAlignTopsClick(object sender, EventArgs e)
        {
            AlignRoutines(AlignType.Top);
        }
        void OnMiAlignBottomsClick(object sender, EventArgs e)
        {
            AlignRoutines(AlignType.Bottom);
        }
        void OnMiAlignWidthsClick(object sender, EventArgs e)
        {
            AlignRoutines(AlignType.Width);
        }
        void OnMiAlignHeightsClick(object sender, EventArgs e)
        {
            AlignRoutines(AlignType.Height);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMiAlignRightsClick(object sender, EventArgs e)
        {
            AlignRoutines(AlignType.Right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMiAlignLeftsClick(object sender, EventArgs e)
        {
            AlignRoutines(AlignType.Left);
        }
        void OnMiAlignCentersClick(object sender, EventArgs e)
        {
            AlignRoutines(AlignType.Center);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMiRenameClick(object sender, EventArgs e)
        {
            var mi = sender as ToolStripMenuItem;
            if (mi == null) return;
            var menu = mi.GetCurrentParent() as ContextMenuStrip;
            if (menu == null) return;
            if (menu.SourceControl == null) return;
            UnSelectAll();
            Translate(menu.SourceControl);
        }

        private ToolStripMenuItem miRename { get; set; }
        private ToolStripMenuItem miHide { get; set; }
        private ToolStripSeparator miSeparatorRename { get; set; }
        private ToolStripMenuItem miVerticalAlign { get; set; }
        private ToolStripMenuItem miHorizontalAlign { get; set; }
        private ToolStripMenuItem miDictionary { get; set; }
        private ToolStripMenuItem miNonDictionary { get; set; }

        #endregion
        private void UnSelectAll()
        {
            foreach (var selectedControl in SelectedControls)
                selectedControl.Release();
            SelectedControls.Clear();
        }

        private void UnSelect(Control ctl, bool save = true)
        {
            var designer = Find(ctl);
            if (designer != null)
            {
                designer.Release(save);
                SelectedControls.Remove(designer);
            }
        }

        private ControlDesigner Find(Control ctl)
        {
            return SelectedControls.FirstOrDefault(selectedControl => selectedControl.ProcessedControl == ctl);
        }

        /// <summary>
        /// Выбран контрол для движений и прочих операций
        /// </summary>
        /// <param name="ctl"></param>
        private void Select(Control ctl)
        {
            if (ctl == null) return;
            //if (SelectedControls.Count > 0)
            //{
            //    if (SelectedControls.Any(tmpDesigner => tmpDesigner.ProcessedControl.Parent != ctl.Parent))
            //    {
            //        return;
            //    }
            //}
            CreateTranslationDesignerForControl(ctl, true);
        }

        private void InitDesigner(ControlDesigner designer)
        {
            designer.UndoEvent += PushToUndoStack;
            designer.CreateUndoStateEvent += CreateMultiSelectUndoState;
            designer.SaveEvent += SaveTextChanges;
            designer.ResizeEvent += OnResize;
            designer.MoveEvent += OnResize;
            designer.CancelEvent += CancelChanges;

        }
        /// <summary>
        /// Отмена редактирования текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CancelChanges(object sender, ControlDesignerEventArgs e)
        {
            var designer = sender as ControlDesigner;
            if (designer != null && designer.TranslationEnabled)
            {
                designer.Undo();
                UnSelect(designer.ProcessedControl, false);
            }
        }

        /// <summary>
        /// Перевод контрола в режим ввода нового заголовка
        /// </summary>
        /// <param name="ctl"></param>
        private void Translate(Control ctl)
        {
            if (ctl == null) return;
            CreateTranslationDesignerForControl(ctl, false);
        }

        /// <summary>
        /// Получение правил, по которым обрабатывается контрол
        /// </summary>
        /// <param name="ctl"></param>
        /// <returns></returns>
        private DesignElement GetDesignType(Control ctl)
        {
            DesignElement de;
            var view = GetControlView(ctl);
            de = view.GetDesignTypeForComponent(ctl);
            return de;
        }

        private bool IsElementTranslatable(Component ctl)
        {
            var view = GetControlView(ctl);
            if (view != null)
                return (view.GetDesignTypeForComponent(ctl) & DesignElement.Caption) != 0;
            return false;
        }

        private ITranslationView GetControlView(Component component)
        {
            if (component == null)
                return null;
            var ctl = GetControlForComponent(component);
            while (ctl != null && ctl.Parent != null)
            {
                if (ctl.Parent is ITranslationView)
                    return ctl.Parent as ITranslationView;
                ctl = ctl.Parent;
            }
            return null;
        }

        private Control GetControlForComponent(Component component)
        {
            var ctl = component as Control;
            if (ctl != null)
                return ctl;
            if (component is GridColumn)
                return ((GridColumn)component).View.GridControl;
            if (component is TreeListColumn)
                return ((TreeListColumn)component).TreeList;
            if (component is NavBarGroup)
                return ((NavBarGroup)component).NavBar;

            return null;
        }
        private ControlEdge GetResizeType(Control ctl)
        {
            if (ctl is ControlDesignerProxy)
                return GetResizeType(((ControlDesignerProxy)ctl).HostControl);
            var view = GetControlView(ctl);
            var designType = view.GetDesignTypeForComponent(ctl);
            if ((designType & DesignElement.Sizing) == 0)
                return ControlEdge.None;
            if (ctl is MemoEdit)
                return ControlEdge.All;
            if (ctl is BaseEdit || TranslationToolHelperWinClient.IsLookupControl(ctl))
                return ControlEdge.Left | ControlEdge.Right;
            return ControlEdge.All;

        }
        private bool IsComplexControl(Control ctl)
        {
            if (ctl is GridControl || ctl is TreeList || ctl is XtraTabControl || ctl is GroupBox || ctl is GroupControl)
                return true;
            return false;
        }

        private ControlDesigner CreateTreeListDesigner(Control ctl, Point pt)
        {
            TreeList tree;
            var proxy = ctl as ControlDesignerProxy;
            if (proxy != null)
                tree = (TreeList)proxy.HostControl;
            else
                tree = (TreeList)ctl;

            var hi = tree.CalcHitInfo(pt);

            //если клик в заголовок столбца, то только редактируем. Иначе только двигаем и меняем размер.
            return hi.HitInfoType.Equals(HitInfoType.Column) && IsElementTranslatable(hi.Column)
                ? new ControlDesigner(ctl, ctl.Parent.PointToClient(ctl.PointToScreen(hi.Bounds.Location)), new Size(hi.Bounds.Width, hi.Bounds.Height), hi.Column.Caption, hi.Column)
                : new ControlDesigner(ctl, DesignElement.Moving | DesignElement.Sizing);
        }

        private ControlDesigner CreateNavBarDesigner(Control ctl, Point pt)
        {
            NavBarControl bar;
            var proxy = ctl as ControlDesignerProxy;
            if (proxy != null)
                bar = (NavBarControl)proxy.HostControl;
            else
                bar = (NavBarControl)ctl;
            var hi = bar.CalcHitInfo(pt);
            var bounds = Rectangle.Empty;
            NavBarGroup group = null;
            if (hi.HitTest == NavBarHitTest.NavigationPaneHeader)
            {
                bounds = NavBarControlHelper.GetHeaderBound(bar);
                group = bar.ActiveGroup;
            }
            else if (hi.HitTest == NavBarHitTest.GroupCaption)
            {
                bounds = NavBarControlHelper.GetGroupHeaderBound(bar, hi.Group);
                group = hi.Group;
            }
            //если клик в заголовок столбца, то только редактируем. Иначе только двигаем и меняем размер.

            return (hi.HitTest == NavBarHitTest.NavigationPaneHeader || hi.HitTest == NavBarHitTest.GroupCaption) && IsElementTranslatable(bar) && group != null
                ? new ControlDesigner(ctl, ctl.Parent.PointToClient(ctl.PointToScreen(bounds.Location)), bounds.Size, group.Caption, group)
                : new ControlDesigner(ctl, DesignElement.Moving | DesignElement.Sizing);

        }
        private ControlDesigner CreateGridDesigner(Control ctl, Point pt)
        {
            GridControl grid;
            var proxy = ctl as ControlDesignerProxy;
            if (proxy != null)
                grid = (GridControl)proxy.HostControl;
            else
                grid = (GridControl)ctl;
            var hi = ((GridView)grid.FocusedView).CalcHitInfo(pt);
            //если клик в заголовок столбца, то только редактируем. Иначе только двигаем и меняем размер.
            var bounds = hi.InColumn ? GetColumnBounds(grid, hi.Column) : Rectangle.Empty;
            return hi.InColumn && IsElementTranslatable(hi.Column)
                ? new ControlDesigner(ctl, ctl.Parent.PointToClient(ctl.PointToScreen(bounds.Location)), bounds.Size, hi.Column.Caption, hi.Column)
                : new ControlDesigner(ctl, DesignElement.Moving | DesignElement.Sizing);

        }

        private ControlDesigner CreateTabDesigner(Control ctl, Point pt)
        {
            XtraTabControl tc;
            var proxy = ctl as ControlDesignerProxy;
            if (proxy != null)
                tc = (XtraTabControl)proxy.HostControl;
            else
                tc = (XtraTabControl)ctl;
            var hi = tc.CalcHitInfo(pt);
            //если клик в заголовок nf,f, то только редактируем. Иначе только двигаем
            if (hi.HitTest == XtraTabHitTest.PageHeader && IsElementTranslatable(hi.Page))
            {
                IXtraTab iTab = tc;
                var bounds = iTab.ViewInfo.HeaderInfo.AllPages[hi.Page].Bounds;
                return new ControlDesigner(ctl, ctl.Parent.PointToClient(tc.PointToScreen(bounds.Location)), bounds.Size, hi.Page.Text, hi.Page);
            }
            //disable page control sizing - ot looks strange and unclear for end user
            //enable moving only
            return new ControlDesigner(ctl, DesignElement.Moving);//| DesignElement.Sizing
        }
        private ControlDesigner CreateGroupBoxDesigner(Control ctl, Point pt)
        {

            //если клик в заголовок nf,f, то только редактируем. Иначе только двигаем и меняем размер.
            if (pt.X >= 0 && pt.X <= ctl.Width && pt.Y >= 0 && pt.Y <= 23 && IsElementTranslatable(ctl))
            {
                return new ControlDesigner(ctl, ctl.Parent.PointToClient(ctl.PointToScreen(new Point(0, 0))), new Size(ctl.Width, 23), ctl.Text, null);
            }
            return new ControlDesigner(ctl, DesignElement.Moving | DesignElement.Sizing);
        }
        private ControlDesigner CreateGroupControlDesigner(GroupControl ctl, Point pt)
        {
            var info = ReflectionHelper.GetProperty(ctl, "ViewInfo", BindingFlags.NonPublic | BindingFlags.Instance) as DevExpress.Utils.Drawing.GroupObjectInfoArgs;




            //если клик в заголовок nf,f, то только редактируем. Иначе только двигаем и меняем размер.
            if (info != null && IsElementTranslatable(ctl) && pt.X >= info.CaptionBounds.Location.X && pt.X <= info.CaptionBounds.Size.Width && pt.Y >= info.CaptionBounds.Location.Y && pt.Y <= info.CaptionBounds.Size.Height)
            {
                return new ControlDesigner(ctl, ctl.Parent.PointToClient(ctl.PointToScreen(info.CaptionBounds.Location)), info.CaptionBounds.Size, ctl.Text, null);
            }
            return new ControlDesigner(ctl, DesignElement.Moving | DesignElement.Sizing);
        }

        /// <summary>
        /// Создание редактора поверх контрола
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="selectOnly"> </param>
        /// <returns></returns>
        private void CreateTranslationDesignerForControl(Control ctl, bool selectOnly)
        {
            var currentCursorPosition = new Point(Cursor.Position.X, Cursor.Position.Y);
            Control realControl = ctl;
            var proxy = ctl as ControlDesignerProxy;
            if (proxy != null)
                realControl = proxy.HostControl;
            if (Utils.IsEmpty(realControl.Name))
                return;
            var relativePosition = realControl.PointToClient(currentCursorPosition);
            ControlDesigner designer;
            var view = GetControlView(ctl);
            if (selectOnly)
            {
                var designType = view.GetDesignTypeForComponent(ctl);
                designType = designType & ~(DesignElement.Caption);
                if ((designType & DesignElement.Sizing) != 0)
                    designer = new ControlDesigner(ctl, designType, GetResizeType(ctl));
                else
                    designer = new ControlDesigner(ctl, designType, ControlEdge.None);
            }
            else if (realControl is TreeList)
                designer = CreateTreeListDesigner(ctl, relativePosition);
            else if (realControl is GridControl)
                designer = CreateGridDesigner(ctl, relativePosition);
            else if (realControl is XtraTabControl)
                designer = CreateTabDesigner(ctl, relativePosition);
            else if (realControl is GroupBox)
                designer = CreateGroupBoxDesigner(ctl, relativePosition);
            else if (realControl is GroupControl)
                designer = CreateGroupControlDesigner(realControl as GroupControl, relativePosition);
            else if (realControl is NavBarControl)
                designer = CreateNavBarDesigner(realControl as NavBarControl, relativePosition);
            else
                designer = new ControlDesigner(ctl, GetDesignType(ctl), GetResizeType(ctl), realControl.Text);
            InitDesigner(designer);
            var component = (Component)(designer.EditedObject ?? designer.RealControl);
            if (view.ExclusionsList.ContainsKey(component))
            {
                if (view.ExclusionsList[component].Disabled)
                {
                    designer.Release();
                    return;
                }
                string text = "";
                var propName =
                    TranslationToolHelperWinClient.GetTextPropertyName(component, ref text);
                foreach (var key in view.ExclusionsList[component].Keys)
                {
                    var resText = CommonResourcesCache.GetText(view.ExclusionsList[component].Resource.ToString(), Culture, key, true);
                    if (resText == text)
                    {
                        if (view.ResourcesList.ContainsKey(propName))
                        {
                            view.ResourcesList[propName].SourceKey = key;
                            view.ResourcesList[propName].ResourceName =
                                view.ExclusionsList[component].Resource.ToString();
                            if (string.IsNullOrEmpty(view.ResourcesList[propName].EnglishText))
                                view.ResourcesList[propName].EnglishText =
                                    TranslationToolHelper.GetDefaultText(
                                        view.ExclusionsList[component].Resource.ToString(), key);
                        }
                        else
                        {
                            var resValue = new ResourceValue
                                {
                                    Value = text,
                                    SourceKey = key,
                                    ResourceName =
                                        view.ExclusionsList[component].Resource.ToString(),
                                    EnglishText = TranslationToolHelper.GetDefaultText(view.ExclusionsList[component].Resource.ToString(), key)
                                };

                            view.ResourcesList.Add(propName, resValue);
                        }
                        //view.ResourcesList[propName].SourceFileName = TranslationToolHelper.GetResourceFilename(view.ExclusionsList[component].Resource.ToString(), Culture);
                        break;
                    }
                }
            }
            designer.Visible = true;
            SelectedControls.Add(designer);
        }

        private void PushToUndoStack(object sender, ControlDesignerEventArgs e)
        {
            if (e.UndoState != null)
                m_UndoStack.Push(e.UndoState);
            var designer = sender as ControlDesigner;
            if (designer != null)
            {
                var view = GetControlView(designer.RealControl);
                if (view != null && view.AfterDesignOperation != null)
                    view.AfterDesignOperation(sender, e);
            }
        }
        private void CreateMultiSelectUndoState(object sender, ControlDesignerEventArgs e)
        {
            if (e.UndoState == null)
                return;
            var designer = sender as ControlDesigner;
            var undoList = new List<UndoControlState>();
            foreach (var selectedControl in SelectedControls)
            {
                if (selectedControl != designer)
                    undoList.Add(new UndoControlState { Element = selectedControl.ProcessedControl, Operation = UndoOperation.Position, Bounds = selectedControl.ProcessedControl.Bounds });
            }
            if (undoList.Count > 0)
                e.UndoState.RelatedChanges = undoList.ToArray();
        }

        public static Rectangle GetColumnBounds(GridControl grid, GridColumn colum)
        {
            if (colum == null)
                return Rectangle.Empty;
            GridViewInfo info = getGridViewInfo((GridView)grid.FocusedView);
            info.GetColumnLeftCoord(colum);
            var colInfo = info.ColumnsInfo[colum];
            if (colInfo != null)
            {
                return colInfo.Bounds;
            }
            return new Rectangle(Point.Empty, new Size(colum.Width, 23));
        }


        private static GridViewInfo getGridViewInfo(GridView view)
        {
            var fi = typeof(GridView).GetField("fViewInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi != null)
            {
                return fi.GetValue(view) as GridViewInfo;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDoubleClick(object sender, EventArgs e)
        {
            UnSelectAll();
            Translate(sender as Control);
        }
        private void OnClick(object sender, EventArgs e)
        {
            if (Find(sender as Control) != null)
                return;
            UnSelectAll();
            Select(sender as Control);
        }

        private void OnUnselectAll(object sender, EventArgs e)
        {
            UnSelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            var keyboard = new Keyboard();
            if (keyboard.CtrlKeyDown && (e.Button.Equals(MouseButtons.Left)))
            {
                if (Find(sender as Control) != null)
                    UnSelect(sender as Control);
                else
                    Select(sender as Control);
            }
            else if (e.Button.Equals(MouseButtons.Right))
            {
                var ctl = sender as Control;
                if (ctl != null)
                    ctl.ContextMenuStrip = GetContextMenu(ctl);
            }
        }
        private List<UndoControlState> ChangeText(Component sourceComponent, string captionId, string caption)
        {
            var undoList = new List<UndoControlState>();
            foreach (var view in m_Views)
            {
                ChangeRelatedCaptions(view, sourceComponent, view as Control, captionId, caption, undoList);
            }
            return undoList;
        }
        private void ChangeRelatedCaptions(ITranslationView view, Component sourceComponent, Control ctl, string captionId, string caption, List<UndoControlState> undoList)
        {
            var resValues = view.ResourcesList.Where(v => v.Value.SourceKey == captionId).ToList();
            if (!resValues.Any())
                return;
            foreach (var resValue in resValues)
            {
                var s = resValue.Key.Split('.');
                var name = s[0];
                var component = TranslationToolHelperWinClient.FindComponentByName(ctl, name);
                if (component != null && component != sourceComponent)
                {
                    string oldText = TranslationToolHelperWinClient.GetComponentText(component);
                    var undoState = new UndoControlState { Caption = oldText, Element = component, Operation = UndoOperation.Text };
                    TranslationToolHelperWinClient.SetComponentText(component, caption);
                    undoList.Add(undoState);
                }
            }
        }


        /// <summary>
        /// Сохранение отредактированного заголовка контрола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveTextChanges(object sender, ControlDesignerEventArgs e)
        {
            var designer = sender as ControlDesigner;
            if (designer != null && designer.TranslationEnabled && !designer.InitialText.Equals(designer.Text))
            {
                if (designer.RealControl == null) return;

                //проверяем на предмет дублирования

                var formTypeFullName = m_TranslationView.GetType().FullName;
                var view = GetControlView(designer.RealControl);
                var resourceKey = view.GetKeyForComponent((Component)designer.EditedObject ?? designer.RealControl, DesignElement.Caption);
                var resourceName = view.GetResourceNameForComponent((Component)designer.EditedObject ?? designer.RealControl, DesignElement.Caption);
                string text = "";
                //string propName =
                //    TranslationToolHelperWinClient.GetTextPropertyName(
                //        (Component)designer.EditedObject ?? designer.RealControl, ref text);
                var acceptSplit = ResourceAction.Accept;
                if (view.ResourcesList.ContainsKey(resourceKey))
                {
                    if (view.ResourcesList[resourceKey].IsSplitted)
                        acceptSplit = ResourceAction.Split;
                    else
                        acceptSplit = ResUsage.DisplayResourceUsage(formTypeFullName, view.GetViewNameForResourceUsage(), resourceName,
                                                                resourceKey, designer.InitialText);
                }
                if (acceptSplit == ResourceAction.Split)
                {
                    text = view.FormatText((Component)designer.EditedObject ?? designer.RealControl, designer.Text,
                                               resourceKey);
                    if (view.ResourcesList.ContainsKey(resourceKey))
                        view.ResourcesList[resourceKey].IsSplitted = true;
                    else
                    {
                        view.ResourcesList.Add(resourceKey, new ResourceValue
                            {
                                IsSplitted = true,
                                ResourceName = resourceName,
                                SourceKey = resourceKey,
                                Value = text
                            });
                    }
                    m_UndoStack.Push((Component)designer.EditedObject ?? designer.RealControl, designer.InitialText);
                    ControlDesigner.SetControlText(designer.ProcessedControl, text, designer.EditedObject);
                }
                else if (acceptSplit == ResourceAction.Accept)
                {
                    var state = m_UndoStack.Push((Component)designer.EditedObject ?? designer.RealControl, designer.InitialText);
                    text = view.FormatText((Component)designer.EditedObject ?? designer.RealControl, designer.Text,
                                               resourceKey);
                    ControlDesigner.SetControlText(designer.ProcessedControl, text, designer.EditedObject);
                    var relatedChanges = ChangeText(state.Element, resourceKey, designer.Text);
                    if (relatedChanges.Count > 0)
                        state.RelatedChanges = relatedChanges.ToArray();
                }
                if (e.ForceEditorClosing)
                    UnSelect(designer.ProcessedControl, false);
            }
        }
        private string GetFormViewNameForComponent(Component component)
        {
            var view = GetControlView(component);
            if (view is BaseActionPanel)
                return ((BaseActionPanel)view).ParentLayout.ParentBasePanel.GetType().Name;
            if (view is BaseSearchPanel)
                return GetFormViewNameForView((BaseSearchPanel)view);
            if (view is ILayout)
                return ((ILayout)view).ParentBasePanel.GetType().Name;
            return view.GetType().Name;

        }

        private string GetFormViewNameForView(ITranslationView view)
        {
            var ctl = view as Control;
            while (ctl != null && ctl.Parent != null)
            {
                if (ctl.Parent is ILayout)
                    return ((ILayout)ctl.Parent).ParentBasePanel.GetType().Name;
                if (ctl.Parent is IApplicationForm)
                    return ctl.Parent.GetType().Name;
                ctl = ctl.Parent;
            }
            return view.GetType().Name;
        }

        private ITranslationView GetFormViewForComponent(Component component)
        {
            var view = GetControlView(component);
            if (view is BaseActionPanel)
                return ((BaseActionPanel)view).ParentLayout.ParentBasePanel as ITranslationView;
            if (view is BaseSearchPanel)
                return GetFormViewForComponent((BaseSearchPanel)view);
            if (view is ILayout)
                return ((ILayout)view).ParentBasePanel as ITranslationView;
            var ctl = view as Control;
            while (ctl != null && !(ctl is IApplicationForm))
            {
                ctl = ctl.Parent;
            }
            Dbg.Assert(ctl != null, "ITranslationView for component is not found");
            return ctl as ITranslationView;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResize(object sender, EventArgs e)
        {
            var designer = sender as ControlDesigner;
            if (designer != null)
            {
                foreach (var selectedControl in SelectedControls)
                {
                    if (selectedControl != designer)
                    {
                        selectedControl.SetRelativeBounds(designer);
                    }
                    RaiseControlBoundChangedEvent(selectedControl);
                }
            }
        }
        public void ApplyResources()
        {
            if(BaseSettings.TranslationMode)
                ApplyResources(m_TopLevelControl as ITranslationView);
        }
        private void ApplyResources(ITranslationView view, string cultureCode = null)
        {
            if (cultureCode == null)
                cultureCode = CustomCultureHelper.SupportedLanguages[ModelUserContext.CurrentLanguage];
            ApplyResourcesRecursively(view as Control, cultureCode);
        }
        private void ApplyResourcesRecursively(Control ctl, string cultureCode)
        {
            if (ctl == null)
                return;
            if (ctl is ITranslationView)
            {
                m_Views.Add(ctl as ITranslationView);
                (ctl as ITranslationView).ApplyResources(cultureCode);
            }
            foreach (Control c in ctl.Controls)
            {
                if (c is BaseEdit)
                    continue;
                ApplyResourcesRecursively(c, cultureCode);
            }
        }

        public bool SaveResources()
        {
            if (!m_UndoStack.CanUndo)
                return true;
            var changes = m_UndoStack.GetChangedElements();
            var views = GetChangedViews(changes);
            foreach (var view in views)
            {
                view.SaveChanges(changes, Culture);
            }
            return true;
        }

        private IEnumerable<ITranslationView> GetChangedViews(Dictionary<object, DesignElement> changes)
        {
            var list = new List<ITranslationView>();
            foreach (var change in changes)
            {
                var view = GetControlView((Component)change.Key);
                if (view != null && !list.Contains(view))
                    list.Add(view);
            }
            return list;
        }

        private static readonly object m_LockObj = new object();
        public bool SaveTranslations()
        {
            var ctl = m_TranslationView as Control;
            UnSelectAll();
            if (ctl == null || !m_UndoStack.CanUndo)
                return true;
            var dr = WinUtils.ConfirmSaveForTranslationTool();
            if (dr.Equals(DialogResult.Yes))
            {
                lock (m_LockObj)
                {
                    SaveResources();
                    m_UndoStack.Clear();
                    return true;
                }
            }
            if (dr.Equals(DialogResult.No))
                return true;
            return false;
        }
        public bool CancelChanges()
        {
            var ctl = m_TranslationView as Control;
            if (ctl == null)
                return true;
            ctl.SuspendLayout();
            while (HasChanges)
                Undo();
            ctl.ResumeLayout();
            return true;
        }
        public void ShowHiddenControls()
        {
            foreach (var ctrl in HiddenControls)
            {
                if (!ctrl.Visible)
                {
                    m_UndoStack.Push(ctrl, ctrl.Visible);
                    ctrl.Visible = true;
                }
            }
            HiddenControls.Clear();
        }

        #region Undo support
        readonly UndoStack m_UndoStack = new UndoStack();
        public bool HasChanges { get { return m_UndoStack.CanUndo; } }
        public void Undo()
        {
            if (HasChanges)
            {
                UnSelectAll();
                m_UndoStack.Undo();
            }
        }
        #endregion
    }
}
