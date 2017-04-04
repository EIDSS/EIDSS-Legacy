using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraLayout;
using bv.common.Diagnostics;
using bv.common.Resources;
using DevExpress.XtraEditors;
using bv.common.Core;
using bv.common.Resources.TranslationTool;
using bv.winclient.BasePanel;
using bv.model.Model.Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Layout;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraBars.Controls;

namespace bv.winclient.Core.TranslationTool
{
    [CLSCompliant(true)]
    public class TranslationToolHelperWinClient : TranslationToolHelper
    {

        /// <summary>
        /// Типы, которые можно двигать и у которых можно изменять размер
        /// </summary>
        static readonly List<Type> m_SelectableTypes = new List<Type>
                                  {
                                     typeof (LabelControl)
                                    ,typeof (Label)
                                    ,typeof (SimpleButton)
                                    ,Type.GetType("bv.common.win.PopUpButton, bvwin_common")
                                    ,typeof (DropDownButton)
                                    ,typeof (TextBoxMaskBox)
                                    ,typeof (LookUpEdit)
                                    ,typeof (CheckBox)
                                    ,typeof (CheckEdit)
                                    ,typeof (RadioButton)
                                    ,typeof (GroupBox)
                                    ,typeof (GroupControl)
                                    ,typeof (GridControl)
                                    ,typeof (BvGridControl)
                                    ,typeof (XtraTabControl)
                                    ,typeof (NavBarControl)
                                    ,typeof (PanelControl)
                                    ,typeof (TreeList)
                                    ,typeof (PopUpButton)
                                    ,typeof (BarDockControl)
                                    //,typeof (LayoutControl)
                                  };

        /// <summary>
        /// Те типы, у которых можно редактировать какие-либо заголовки
        /// </summary>
        static readonly List<Type> m_EditableTypes = new List<Type>
                                {
                                     typeof (LabelControl)
                                    ,typeof (Label)
                                    ,typeof (TreeList)
                                    ,typeof (GridControl)
                                    ,typeof (BvGridControl)
                                    ,typeof (SimpleButton)
                                    ,Type.GetType("bv.common.win.PopUpButton, bvwin_common")                           
                                    ,typeof (DropDownButton)
                                    ,typeof (XtraTabControl)
                                    ,typeof (XtraTabPage)
                                    ,typeof (CheckBox)
                                    ,typeof (CheckEdit)
                                    ,typeof (RadioButton)
                                    ,typeof (GroupBox)
                                    ,typeof (GroupControl)
                                    ,typeof (NavBarControl)
                                    ,typeof (LayoutControl)
                                    ,typeof (LookUpEdit)
                               };

        /// <summary>
        /// Те типы, у которых можно редактировать какие-либо заголовки только в FormTranslationsEditor
        /// </summary>
        static readonly List<Type> m_EditableInFormTypes = new List<Type>
                                {
                                     typeof (LayoutControl)
                               };

        /// <summary>
        /// Те типы, которые надо блокировать от нажатия мыши.
        /// Они должны прятаться под ControlDesignerProxy
        /// </summary>
        static readonly List<Type> m_BlockedTypes = new List<Type> {
                                     typeof (SimpleButton)
                                    ,Type.GetType("bv.common.win.PopUpButton, bvwin_common")
                                    ,typeof (DropDownButton)
                                    ,typeof (CheckBox)
                                    ,typeof (CheckEdit)
                                    ,typeof (RadioButton)
                                    ,typeof (TreeList)
                                    ,typeof (GridControl)
                                    ,typeof (BvGridControl)
                                    ,typeof (NavBarControl)
                                    ,typeof (XtraTabControl)
                                    ,typeof (LayoutControl)
                                    //,typeof (BarDockControl)
                               };

        public static bool IsMandatoryControl(Control control)
        {
            if (control == null)
                return false;
            var controlDesignerProxy = control as ControlDesignerProxy;
            if (controlDesignerProxy != null)
                return IsMandatoryControl((controlDesignerProxy).HostControl);
            if (!(control is BaseEdit))
                return false;
            return (((BaseEdit)control).StyleController).IsMandatory();
        }

        /// <summary>
        /// Можно ли для этого контрола показывать окно редактирования текста
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsEditableControl(Control control)
        {
            if (control == null)
                return false;
            var controlDesignerProxy = control as ControlDesignerProxy;
            if (controlDesignerProxy != null)
                return IsEditableControl((controlDesignerProxy).HostControl);
            return m_EditableTypes.Contains(control.GetType());
        }

        /// <summary>
        /// Если для этого контрола нельзя показывать окно редактирования текста, но его все-таки можно редактировать в FormTranslationsEditor
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsEditableInFormControl(Control control)
        {
            if (control == null)
                return false;
            return m_EditableInFormTypes.Contains(control.GetType());
        }

        /// <summary>
        /// Можно ли двигать этот контрол
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsSelectableControl(Control control)
        {
            var controlDesignerProxy = control as ControlDesignerProxy;
            if (controlDesignerProxy != null)
                return IsSelectableControl(controlDesignerProxy.HostControl);

            if (control is BaseEdit || control is BaseListBoxControl || m_SelectableTypes.Contains(control.GetType()) || IsLookupControl(control))
                return true;
            return false;
        }

        /// <summary>
        /// Можно ли к этому контролу применять тул для редактирования на лету
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsSupportedControl(Control control)
        {
            if (control is ControlDesignerProxy || IsSelectableControl(control) || IsEditableControl(control))
                return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formControlCollection"></param>
        /// <param name="supportedControls"> </param>
        /// <param name="unsupportedControls"> </param>
        /// <returns></returns>
        public static void SeparateControls(Control.ControlCollection formControlCollection
            , out List<Control> supportedControls
            , out List<Control> unsupportedControls
            )
        {
            supportedControls = new List<Control>();
            unsupportedControls = new List<Control>();
            foreach (Control control in formControlCollection)
            {
                if (IsSupportedControl(control))
                    supportedControls.Add(control);
                else
                    unsupportedControls.Add(control);
                if (control.Controls.Count > 0 && !(control is BaseEdit))
                {
                    List<Control> supportedControlsX;
                    List<Control> unsupportedControlsX;
                    SeparateControls(control.Controls, out supportedControlsX, out unsupportedControlsX);
                    supportedControls.AddRange(supportedControlsX);
                    unsupportedControls.AddRange(unsupportedControlsX);
                }
            }
        }

        public static bool IsControlToBlock(Control control)
        {
            if (control is TranslationButton)
                return false;
            if (control is BaseEdit || m_BlockedTypes.Contains(control.GetType()) || IsLookupControl(control))
                return true;

            return false;
        }

        public static bool IsLookupControl(Control control)
        {
            if (control is PopupBaseEdit)
                return true;
            if (control.GetType().Name == "AddressLookup" || control.GetType().Name == "LocationLookup" || control.GetType().Name == "AreaLookup")
            {
                var prop = ReflectionHelper.GetProperty(control, "LookupLayout");
                if (prop != null && prop.ToString() == "DropDownList")
                    return true;
            }
            return false;
        }



        public static void CollectViewResources(ITranslationView view, string cultureCode)
        {
            var viewType = view.GetType();
            view.ResourcesList.Clear();
            view.ExclusionsList.Clear();
            while (viewType != null && viewType.GetInterface("ITranslationView") != null)
            {
                ReadResxFile(viewType.Name, cultureCode, view.ResourcesList, view.DefaultResourcesList);
                ReadExclusions(view, view.ResourcesList, cultureCode);
                viewType = viewType.BaseType;
            }
            if (view.ResourcesList.ContainsKey(ThisAutoScaleDimensions))
                SetAutoScaleDimensions(view, (SizeF)view.ResourcesList[ThisAutoScaleDimensions].Value);
            else if (view.DefaultResourcesList != null && view.DefaultResourcesList.ContainsKey(ThisAutoScaleDimensions))
                SetAutoScaleDimensions(view, (SizeF)view.DefaultResourcesList[ThisAutoScaleDimensions].Value);

        }
        static void SetAutoScaleDimensions(ITranslationView view, SizeF size)
        {
            var control = view as ContainerControl;
            if (control == null)
                return;
            SizeF cSize = control.CurrentAutoScaleDimensions;
            view.StoredAutoScaleFactor = new SizeF(1F, 1F);//(cSize.Width / size.Width, cSize.Height / size.Height);
        }

        private static BarManager m_BarManager;
        public static void ApplyViewResources(ITranslationView view, string cultureCode)
        {
            m_BarManager = null;
            CollectViewResources(view, cultureCode);

            view.EditableControlsList.Clear();

            //if (view.ResourcesList.Count == 0)
            //    return;
            foreach (var ctl in ((Control)view).Controls)
            {
                if (ctl is ITranslationView)
                    continue;
                ApplyResources((Control)ctl, view, cultureCode);
            }

        }
        public static Component FindComponentByName(Control parentControl, string name)
        {
            Component result = null;
            foreach (Control c in parentControl.Controls)
            {
                var realControl = c;
                if (c is ControlDesignerProxy)
                    realControl = ((ControlDesignerProxy)c).HostControl;
                if (realControl.Name == name)
                    return realControl;

                if (realControl is GridControl)
                    result = FindGridColumnByName(realControl as GridControl, name);
                else if (realControl is TreeList)
                    result = FindTreeColumnByName(realControl as TreeList, name);
                else if (realControl is NavBarControl)
                    result = FindNavBarControlComponent(realControl as NavBarControl, name);
                else if (realControl is XtraTabControl)
                    result = FindTabByName(realControl as XtraTabControl, name);
                else if (realControl is LayoutControl)
                    result = FindLayoutItemByName((realControl as LayoutControl).Root, name);

                if (result == null)
                    result = FindComponentByName(realControl, name);
                if (result != null)
                    return result;
            }
            return null;
        }

        private static Component FindTabByName(XtraTabControl xtraTabControl, string name)
        {
            if (xtraTabControl.Name == name)
                return xtraTabControl;
            foreach (XtraTabPage page in xtraTabControl.TabPages)
            {
                if (page.Name == name)
                    return page;
            }
            return null;
        }

        private static Component FindNavBarControlComponent(NavBarControl navBarControl, string name)
        {
            if (navBarControl.Name == name)
                return navBarControl;
            foreach (NavBarGroup group in navBarControl.Groups)
            {
                if (group.Name == name)
                    return group;
            }
            return null;
        }

        private static Component FindTreeColumnByName(TreeList treeList, string name)
        {
            return treeList.Columns.Cast<TreeListColumn>().FirstOrDefault(col => col.Name == name);
        }

        private static Component FindGridColumnByName(GridControl gridControl, string name)
        {
            return ((GridView)gridControl.FocusedView).Columns.Cast<GridColumn>().FirstOrDefault(col => col.Name == name);
        }

        private static Component FindLayoutItemByName(BaseLayoutItem layoutItem, string name)
        {
            if (layoutItem.Name == name)
                return layoutItem;
            if (layoutItem is LayoutControlItem)
            {
                if (((LayoutControlItem)layoutItem).Control != null)
                {
                    var it = FindComponentByName(((LayoutControlItem)layoutItem).Control, name);
                    if (it != null)
                        return it;
                }
            }
            else if (layoutItem is LayoutControlGroup)
            {
                foreach (BaseLayoutItem item in ((LayoutControlGroup)layoutItem).Items)
                {
                    var it = FindLayoutItemByName(item, name);
                    if (it != null)
                        return it;
                }
            }
            else if (layoutItem is TabbedControlGroup)
            {
                foreach (BaseLayoutItem item in ((TabbedControlGroup)layoutItem).TabPages)
                {
                    var it = FindLayoutItemByName(item, name);
                    if (it != null)
                        return it;
                }
            }
            return null;
        }

        public static void ReadExclusions(ITranslationView view, Dictionary<string, ResourceValue> dict, string cultureCode)
        {
            //есть ли файл исключений. Если есть, то из него возьмем текст
            string viewName = view.GetType().Name;
            var exclusionFullPath = GetFullPathToXml(ExclusionsDirectoryName, viewName, null);
            if (!File.Exists(exclusionFullPath)) return;

            using (var reader = new XmlTextReader(exclusionFullPath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name.Equals("data")))
                    {
                        var name = reader.GetAttribute("name") ?? String.Empty;
                        var file = reader.GetAttribute("file") ?? String.Empty;
                        var key = reader.GetAttribute("key") ?? String.Empty;
                        var diasbledAttr = reader.GetAttribute("disabled") ?? String.Empty;
                        bool disabled = "true".Equals(diasbledAttr.ToLowerInvariant());
                        var component = FindComponentByName(view as Control, name);
                        if (component == null)
                            Dbg.Debug("Exclusions reading: component {0} is not found in {1}", name, viewName);
                        if (((file.Length > 0 && key.Length > 0) || disabled) && component != null)
                        {
                            var exclusionItem = new ExclusionItem()
                                                    {
                                                        Resource = file.Length > 0 ?
                                                            (CommonResource)Enum.Parse(typeof(CommonResource), file) : CommonResource.BvMessages,
                                                        Keys = key.Split(','),
                                                        Disabled = disabled,
                                                        Source = ExclusionSource.Xml
                                                    };
                            if (!view.ExclusionsList.ContainsKey(component))
                                view.ExclusionsList.Add(component, exclusionItem);
                            else
                            {
                                Dbg.Debug("Exclusions reading: duplicate component {0} found for {1}", name, viewName);
                            }
                        }
                    }
                }
            }


        }

        //private static readonly Dictionary<string, BaseStringsStorage> m_Storages =
        //    new Dictionary<string, BaseStringsStorage>();

        //private static string GetExclusionValue(string exclusionFileName, string key, string cultureCode)
        //{
        //    if (!m_Storages.ContainsKey(exclusionFileName))
        //    {
        //        switch (exclusionFileName)
        //        {
        //            case "BvMessages":
        //                m_Storages.Add(exclusionFileName, BvMessages.Instance);
        //                break;
        //            case "XtraStrings":
        //                m_Storages.Add(exclusionFileName, XtraStrings.Instance);
        //                break;
        //            default:
        //                var type = ClassLoader.FindType(exclusionFileName);
        //                if (type != null)
        //                {
        //                    var storage = type.GetProperty("Instance",
        //                                                   BindingFlags.Public | BindingFlags.Static |
        //                                                   BindingFlags.FlattenHierarchy);
        //                    if (storage != null)
        //                        m_Storages.Add(exclusionFileName, (BaseStringsStorage)storage.GetValue(null, null));
        //                }
        //                break;
        //        }
        //    }
        //    if (m_Storages.ContainsKey(exclusionFileName))
        //        return m_Storages[exclusionFileName].GetString(key, null, cultureCode);
        //    return null;
        //}


        public static void ApplyResources(Control control, ITranslationView view, string cultureCode)
        {
            foreach (var ctl in control.Controls)
            {
                if (ctl is ITranslationView)
                    continue;
                ApplyResources((Control)ctl, view, cultureCode);
            }
            if (!IsSupportedControl(control) && !IsEditableInFormControl(control))
                return;
            if (view.ExclusionsList.ContainsKey(control))
                return;
            ApplyColumnCaptions(control as TreeList, view);
            ApplyColumnCaptions(control as GridControl, view);
            ApplyTabPageText(control as XtraTabControl, view);
            ApplyNavGroupCaption(control as NavBarControl, view);
            ApplyRadioGroupCaption(control as RadioGroup, view);
            ApplyLayoutText(control as LayoutControl, view);
            ApplyCheckEditCaption(control as CheckEdit, view);
            ApplyMenuCaptions(control as BarDockControl, view);
            foreach (var prop in SupportedProperties)
            {
                var propName = GetPropertyName(control.Name, prop);

                if (prop == CaptionPropName || prop == TextPropName)
                {
                    if (!view.EditableControlsList.ContainsKey(propName))
                        view.EditableControlsList.Add(propName, control);
                }

                if (view.ResourcesList.ContainsKey(propName))
                    ApplyProperty(view, control, prop, view.ResourcesList[propName].Value);

            }

        }

        private static void ApplyCheckEditCaption(CheckEdit checkEdit, ITranslationView view)
        {
            if (checkEdit == null)
                return;
            if (view.ExclusionsList.ContainsKey(checkEdit))
                return;
            var propName = GetPropertyName(checkEdit.Name + ".Properties", CaptionPropName);
            if (!view.EditableControlsList.ContainsKey(propName))
                view.EditableControlsList.Add(propName, checkEdit);
            if (view.ResourcesList.ContainsKey(propName))
                checkEdit.Properties.Caption = Utils.Str(view.ResourcesList[propName].Value);
        }

        private static void ApplyProperty(ITranslationView view, Control ctl, string propName, object value)
        {
            switch (propName)
            {
                case TextPropName:
                    ctl.Text = Utils.Str(value);
                    break;
                case LocationPropName:
                    SetControlLocation(view, ctl, (Point)value);
                    break;
                case SizePropName:
                    SetControlSize(view, ctl, (Size)value);
                    break;
                case VisiblePropName:
                    ctl.Visible = (bool)value;
                    break;
            }
        }

        protected static Size AutoScaleSize(ITranslationView view, Size size)
        {
            size.Width = (int)Math.Round(size.Width * view.StoredAutoScaleFactor.Width);
            size.Height = (int)Math.Round(size.Height * view.StoredAutoScaleFactor.Height);
            return size;
        }

        protected static Point AutoScalePoint(ITranslationView view, Point point)
        {
            point.X = (int)Math.Round(point.X * view.StoredAutoScaleFactor.Width);
            point.Y = (int)Math.Round(point.Y * view.StoredAutoScaleFactor.Height);
            return point;
        }

        private const AnchorStyles AnchorLeftRight = AnchorStyles.Left | AnchorStyles.Right;
        private const AnchorStyles AnchorTopBottom = AnchorStyles.Top | AnchorStyles.Bottom;
        private const AnchorStyles AnchorAll = AnchorLeftRight | AnchorTopBottom;

        protected static void SetControlSize(ITranslationView view, Control control, Size size)
        {
            // if the control is a form and we are preserving form size then exit
            //
            //if (control is Form && PreserveFormSize) return;

            // if dock fill or anchor all is set then don't change the size
            //
            if (control.Dock == DockStyle.Fill ||
                control.Anchor == AnchorAll) return;

            size = AutoScaleSize(view, size);

            // if docked top/bottom or anchored left/right don't change the width
            //
            if (control.Dock == DockStyle.Top || control.Dock == DockStyle.Bottom ||
               (control.Anchor & AnchorLeftRight) == AnchorLeftRight)
            {
                size.Width = control.Width;
            }

            // if docked left/right or anchored top/bottom don't change the height
            //
            if (control.Dock == DockStyle.Left || control.Dock == DockStyle.Right ||
               (control.Anchor & AnchorTopBottom) == AnchorTopBottom)
            {
                size.Height = control.Height;
            }
            control.Size = size;
        }

        protected static void SetControlLocation(ITranslationView view, Control control, Point location)
        {
            // if the control is a form and we are preserving form location then exit
            //
            //if (control is Form && PreserveFormLocation) return;

            // if dock is set then don't change the location
            //
            if (control.Dock != DockStyle.None) return;

            location = AutoScalePoint(view, location);

            // if anchored to the right (but not left) then don't change x coord
            //
            if ((control.Anchor & AnchorLeftRight) == AnchorStyles.Right)
            {
                location.X = control.Left;
            }

            // if anchored to the bottom (but not top) then don't change y coord
            //
            if ((control.Anchor & AnchorTopBottom) == AnchorStyles.Bottom)
            {
                location.Y = control.Top;
            }
            control.Location = location;
        }

        private static void ApplyMenuCaptions(BarDockControl bar, ITranslationView view)
        {
            if (bar == null)
                return;
            foreach (DockedBarControl ctl in bar.Controls)
            {
                ApplyBarCaptions(ctl, view);
            }



            if (m_BarManager == bar.Manager)
                return;
            m_BarManager = bar.Manager;
            foreach (BarItem item in bar.Manager.Items)
            {
                ApplyMenuItemCaption(item, view);
            }
        }
        private static void ApplyMenuItemCaption(BarItem item, ITranslationView view)
        {
            if (!view.ExclusionsList.ContainsKey(item))
            {
                var propName = GetPropertyName(item.Name, CaptionPropName);
                if (!view.EditableControlsList.ContainsKey(propName))
                    view.EditableControlsList.Add(propName, item);
                if (view.ResourcesList.ContainsKey(propName))
                    item.Caption = Utils.Str(view.ResourcesList[propName].Value);
            }
        }

        private static void ApplyBarCaptions(DockedBarControl bar, ITranslationView view)
        {
            if (bar == null)
                return;
            foreach (BarItemLink item in bar.Bar.ItemLinks)
            {
                ApplyBarItemCaption(item.Item, view);
            }
        }
        private static void ApplyBarItemCaption(BarItem item, ITranslationView view)
        {
            if (!view.ExclusionsList.ContainsKey(item))
            {
                var propName = GetPropertyName(item.Name, CaptionPropName);
                if (!view.EditableControlsList.ContainsKey(propName))
                    view.EditableControlsList.Add(propName, item);
                if (view.ResourcesList.ContainsKey(propName))
                    item.Caption = Utils.Str(view.ResourcesList[propName].Value);
            }
        }

        private static void ApplyColumnCaptions(TreeList tree, ITranslationView view)
        {
            if (tree == null)
                return;
            foreach (TreeListColumn col in tree.Columns)
            {
                if (view.ExclusionsList.ContainsKey(col))
                    continue;
                var propName = GetPropertyName(col.Name, CaptionPropName);
                if (!view.EditableControlsList.ContainsKey(propName))
                    view.EditableControlsList.Add(propName, col);
                if (view.ResourcesList.ContainsKey(propName))
                    col.Caption = Utils.Str(view.ResourcesList[propName].Value);
            }
        }
        private static void ApplyColumnCaptions(GridControl grid, ITranslationView view)
        {
            if (grid == null)
                return;
            foreach (GridColumn col in ((GridView)grid.MainView).Columns)
            {
                if (view.ExclusionsList.ContainsKey(col))
                    continue;
                var propName = GetPropertyName(col.Name, CaptionPropName);
                if (!view.EditableControlsList.ContainsKey(propName))
                    view.EditableControlsList.Add(propName, col);
                if (view.ResourcesList.ContainsKey(propName))
                    col.Caption = Utils.Str(view.ResourcesList[propName].Value);
            }
        }
        // doesn't work now
        private static void ApplyRadioGroupCaption(RadioGroup radio, ITranslationView view)
        {
            if (radio == null)
                return;
            var propName = GetPropertyName(radio.Name, DescriptionPropName);
            for ( int i = 0; i < radio.Properties.Items.Count; i++)
            {
                DevExpress.XtraEditors.Controls.RadioGroupItem item = radio.Properties.Items[i];
                if (view.ExclusionsList.ContainsKey(radio))
                    continue;
                var propName1 = propName + (i * 2 + 1).ToString();
                if (!view.EditableControlsList.ContainsKey(propName1))
                    view.EditableControlsList.Add(propName1, radio);
                if (view.ResourcesList.ContainsKey(propName1))
                    item.Description = Utils.Str(view.ResourcesList[propName1].Value);
            }
        }
        private static void ApplyNavGroupCaption(NavBarControl bar, ITranslationView view)
        {
            if (bar == null)
                return;
            foreach (NavBarGroup group in bar.Groups)
            {
                if (view.ExclusionsList.ContainsKey(group))
                    continue;
                var propName = GetPropertyName(group.Name, CaptionPropName);
                if (!view.EditableControlsList.ContainsKey(propName))
                    view.EditableControlsList.Add(propName, group);
                if (view.ResourcesList.ContainsKey(propName))
                    group.Caption = Utils.Str(view.ResourcesList[propName].Value);
            }
        }

        private static void ApplyTabPageText(XtraTabControl tabControl, ITranslationView view)
        {
            if (tabControl == null)
                return;
            foreach (XtraTabPage page in tabControl.TabPages)
            {
                if (view.ExclusionsList.ContainsKey(page))
                    continue;
                var propName = GetPropertyName(page.Name, TextPropName);
                if (!view.EditableControlsList.ContainsKey(propName))
                    view.EditableControlsList.Add(propName, page);
                if (view.ResourcesList.ContainsKey(propName))
                    page.Text = Utils.Str(view.ResourcesList[propName].Value);
            }
        }

        private static void ApplyLayoutText(LayoutControl lControl, ITranslationView view)
        {
            if (lControl == null)
                return;
            foreach (BaseLayoutItem item in lControl.Items)
                ApplyLayoutText(item, view);
        }
        private static void ApplyLayoutText(BaseLayoutItem item, ITranslationView view)
        {
            if (view.ExclusionsList.ContainsKey(item))
                return;
            var propName = GetPropertyName(item.Name, TextPropName);
            if (!view.EditableControlsList.ContainsKey(propName))
                view.EditableControlsList.Add(propName, item);
            if (view.ResourcesList.ContainsKey(propName))
                item.Text = Utils.Str(view.ResourcesList[propName].Value);

            if (item is LayoutControlGroup)
            {
                foreach (BaseLayoutItem it in ((LayoutControlGroup)item).Items)
                    ApplyLayoutText(it, view);
            }
            else if (item is TabbedControlGroup)
            {
                foreach (BaseLayoutItem it in ((TabbedControlGroup)item).TabPages)
                    ApplyLayoutText(it, view);
            }
        }
        public static string GetControlResourceName(Component component, string propertyName)
        {
            var barItem = component as BarItem;
            if (barItem != null)
            {
                var a = barItem.Tag as MenuAction;
                if (a != null)
                {
                    if (a.ItemsStorage != null)
                        return a.ItemsStorage.ResourceName;
                    if (a.Manager.ItemsStorage != null)
                        return a.Manager.ItemsStorage.ResourceName;
                }
            }
            var type = GetControlViewDeclaringType(component, propertyName);
            if (type != null)
                return type.Name;
            return null;
        }
        public static Type GetControlViewDeclaringType(Component component, string propertyName)
        {
            if (component == null)
                return null;
            if (component is ITranslationView)
                return component.GetType();
            var ctl = component as Control;

            var originalCtl = ctl;

            var barItem = component as BarItem;
            if (barItem != null && barItem.Manager != null)
                return barItem.Manager.Form.GetType();
            if (component is GridColumn)
                return GetControlViewDeclaringType(((GridColumn)component).View.GridControl, propertyName);
            if (component is TreeListColumn)
                return GetControlViewDeclaringType(((TreeListColumn)component).TreeList, propertyName);
            if (component is NavBarGroup)
                return GetControlViewDeclaringType(((NavBarGroup)component).NavBar, propertyName);
            if (component is BaseLayoutItem)
                return GetControlViewDeclaringType((LayoutControl)((BaseLayoutItem)component).Owner, propertyName);
            while (ctl != null && ctl.Parent != null)
            {
                var view = ctl.Parent as ITranslationView;
                if (view != null)
                {
                    var type = ctl.Parent.GetType();
                    while (type != null && type.GetInterface("ITranslationView") != null)
                    {
                        if (ctl.Parent is IBaseListPanel || type.Name == "BarcodeButton")
                            return type;

                        if (view.DefaultResourcesList.ContainsKey(propertyName) && view.DefaultResourcesList[propertyName].ResourceName.ToLowerInvariant() == type.Name.ToLowerInvariant())
                            return type;
                        //var pi = type.GetProperty(originalCtl.Name, BindingFlags.NonPublic | BindingFlags.Instance);
                        //if (type.GetInterface("ITranslationView") != null && pi != null && pi.DeclaringType == type)
                        //    return type;
                        //var fi = type.GetField(originalCtl.Name, BindingFlags.NonPublic | BindingFlags.Instance);
                        //if (type.GetInterface("ITranslationView") != null && fi != null && fi.DeclaringType == type)
                        //    return type;

                        type = type.BaseType;
                    }
                }
                ctl = ctl.Parent;
            }
            return null;
        }

        public static ITranslationView GetComponentView(Component component)
        {
            if (component == null)
                return null;
            var view = component as ITranslationView;
            if (view != null)
                return view;
            var ctl = component as Control;
            if (ctl != null)
            {
                while (ctl.Parent != null)
                {
                    if (ctl.Parent is ITranslationView)
                        return ctl.Parent as ITranslationView;
                    ctl = ctl.Parent;
                }
            }
            else if (component is GridColumn)
                return GetComponentView((component as GridColumn).View.GridControl);
            else if (component is TreeListColumn)
                return GetComponentView((component as TreeListColumn).TreeList);
            else if (component is NavBarGroup)
                return GetComponentView(((NavBarGroup)component).NavBar);
            else if (component is BarItem)
                return ((BarItem)component).Manager.Form as ITranslationView;
            else if (component is BaseLayoutItem)
                return GetComponentView((LayoutControl)((BaseLayoutItem)component).Owner);
            return null;
        }

        public static string GetControlFullViewName(Component component, string propertyName)
        {
            var type = GetControlViewDeclaringType(component, propertyName);
            if (type != null)
                return type.FullName;
            return null;
        }

        public static bool SaveViewChanges(ITranslationView view, Dictionary<object, DesignElement> changes, string cultureCode)
        {
            var resourceNames = new List<string>();
            foreach (var change in changes)
            {
                string resourceName = null;
                if (view.ExclusionsList.ContainsKey((Component)change.Key))
                {
                    resourceName = view.ExclusionsList[(Component)change.Key].Resource.ToString();
                    if (!string.IsNullOrEmpty(resourceName) && !resourceNames.Contains(resourceName))
                        resourceNames.Add(resourceName);
                }
                else
                {
                    var propNames = GetChangedProperties(change.Key, change.Value);
                    foreach (var propName in propNames)
                    {
                        resourceName = GetControlResourceName(change.Key as Component, propName.Key);
                        if (!string.IsNullOrEmpty(resourceName) && !resourceNames.Contains(resourceName))
                            resourceNames.Add(resourceName);
                    }
                }
            }

            // Execute the query and access items in each group
            return resourceNames.All(resourceName => SaveViewChanges(view, resourceName, changes, cultureCode));
        }

        public static bool SaveViewChanges(ITranslationView view, string resourceName, Dictionary<object, DesignElement> changes, string cultureCode, bool validateViewName = true)
        {
            try
            {

                //var viewResources = view.ResourcesList.Where(v => v.Value.ResourceName == resourceName);
                //if (!viewResources.Any())
                //    return true;
                var baseResFile = GetFullPathToResX(resourceName, null);
                if (baseResFile.Length == 0)
                    return false;
                Dictionary<object, DesignElement> resourceChanges = GetChangesInResource(view, resourceName, changes);
                if (resourceChanges.Count == 0)
                    return true;
                var customEnFile = GetFullPathToResX(resourceName, CustomCultureHelper.SupportedLanguages[Localizer.lngEn]);
                var customEnDict = new Dictionary<string, ResourceValue>();
                ResourceHelper.GetResxDictionary(resourceName, customEnFile, ref customEnDict);

                Dictionary<string, ResourceValue> nationalDict = null;
                var nationalFile = GetFullPathToResX(resourceName, cultureCode);
                //national resources are saved when current language is not English
                if (ModelUserContext.CurrentLanguage != Localizer.lngEn)
                    nationalDict = new Dictionary<string, ResourceValue>();
                ResourceHelper.GetResxDictionary(resourceName, nationalFile, ref nationalDict);

                MergeViewChanges(view, resourceName, resourceChanges, customEnDict, nationalDict, validateViewName);
                ResourceHelper.WriteToResx(customEnFile, customEnDict, view.StoredAutoScaleFactor);
                ResourceHelper.WriteToResx(nationalFile, nationalDict, view.StoredAutoScaleFactor);
                SaveSplittedResources(view, resourceChanges);
                if (customEnDict.Count > 0 || (nationalDict != null && nationalDict.Count > 0))
                    CommonResourcesCache.Refresh(resourceName, cultureCode);
                foreach (var change in resourceChanges)
                {
                    changes.Remove(change.Key);
                }
                return true;
            }
            catch (Exception)
            {
                ErrorForm.ShowError("msgNotPossibleToSave");
            }
            return false;
        }

        private static Dictionary<object, DesignElement> GetChangesInResource(ITranslationView view, string resourceName, Dictionary<object, DesignElement> changes)
        {
            var resourceChanges = new Dictionary<object, DesignElement>();
            foreach (var change in changes)
            {
                var targetView = GetComponentView(change.Key as Component);
                if (targetView == null)
                {
                    Dbg.DbgAssert(true, "can't find ITranslationView for component {0}", (Component)(change.Key));
                    continue;
                }
                if (view != targetView)
                    continue;
                if (change.Value != DesignElement.None)
                {
                    string changeResourceName = view.GetResourceNameForComponent(change.Key as Component, change.Value);
                    if (resourceName.Equals(changeResourceName))
                    {
                        if (resourceChanges.ContainsKey(change.Key))
                            resourceChanges[change.Key] |= change.Value;
                        else
                            resourceChanges.Add(change.Key, change.Value);
                    }
                }
                //else if (resourceName.Equals(view.GetType().Name))
                //{
                //    resourceChanges.Add(change.Key, change.Value);
                //}
            }

            return resourceChanges;
        }


        public static void SaveSplittedResources(ITranslationView view, Dictionary<object, DesignElement> changes)
        {
            var viewName = view.GetViewNameForSplittedResources();
            foreach (var change in changes)
            {
                var propNames = GetChangedProperties(change.Key, change.Value);
                foreach (var property in propNames)
                {
                    var key = property.Key;
                    if (view.ResourcesList.ContainsKey(key))
                    {
                        var resValue = view.ResourcesList[key];
                        if (resValue.IsSplitted)
                        {
                            resValue.Value = property.Value;
                            ResourceSplitter.Split(viewName, resValue.ResourceName, resValue.SourceKey,
                                                   property.Value.ToString());

                        }

                    }
                }
            }
        }

        private static void MergeViewChanges(ITranslationView view, string viewName,
            Dictionary<object, DesignElement> changes,
            Dictionary<string, ResourceValue> customEnDict,
            Dictionary<string, ResourceValue> nationalDict,
            bool validateViewName
            )
        {
            foreach (var change in changes)
            {
                //if (validateViewName && viewName != GetControlResourceName(change.Key as Component))
                //    continue;
                var propNames = GetChangedProperties(change.Key, change.Value);
                foreach (var property in propNames)
                {
                    //string key = null;
                    //if((change.Value & DesignElement.Caption)!=0)
                    //    key = view.GetKeyForComponentText(change.Key as Component);
                    Type viewType = GetControlViewDeclaringType((Component)change.Key, property.Key);
                    var key = property.Key;
                    ResourceValue resValue = null;
                    if (view.ResourcesList.ContainsKey(key))
                        resValue = view.ResourcesList[key];
                    else if (viewType != null && (view.GetType() == viewType || view.GetType().IsSubclassOf(viewType)))// == viewName.ToLowerInvariant()This should be possible for form resources only, for common resources view.ResourcesList MUST contain key
                    {
                        resValue = new ResourceValue()
                                       {
                                           Value = property.Value,
                                           ResourceName = viewName
                                       };
                    }
                    else
                        continue;
                    if (resValue.ResourceName.ToLowerInvariant() != viewName.ToLowerInvariant() || resValue.IsSplitted)
                        continue;
                    var dict = IsCustomEnProperty(key) ? customEnDict : nationalDict;
                    if (dict == null)
                        continue;
                    if (!string.IsNullOrEmpty(resValue.SourceKey) && key != resValue.SourceKey)
                        key = resValue.SourceKey;
                    if (dict.ContainsKey(key))
                    {
                        dict[key].Value = property.Value;
                    }
                    else
                    {
                        resValue.Value = property.Value;
                        dict.Add(key, resValue);
                    }
                    dict[key].Modified = true;
                }
            }

        }
        public static bool IsCustomEnProperty(string propName)
        {
            return ModelUserContext.CurrentLanguage == Localizer.lngEn || propName.EndsWith(".Visible");
        }
        public bool IsCustomNationalProperty(string propName)
        {
            return ModelUserContext.CurrentLanguage == Localizer.lngEn || propName.EndsWith(".Visible");
        }

        public static string GetPropertyNameForComponent(object component, DesignElement designType)
        {
            var propNames = GetChangedProperties(component, designType);
            if (propNames != null && propNames.Count > 0)
                return propNames.FirstOrDefault().Key;
            return string.Empty;
        }
        private static Dictionary<string, object> GetChangedProperties(object component, DesignElement changeType)
        {
            var propNames = new Dictionary<string, object>();
            var ctl = component as Control;
            if ((changeType & DesignElement.Caption) != 0)
            {
                string text = string.Empty;
                var propName = GetTextPropertyName(component, ref text);
                if (propName != null)
                    propNames.Add(propName, text);
            }
            if (ctl != null && (changeType & DesignElement.Moving) != 0)
            {
                propNames.Add(GetPropertyName(ctl.Name, LocationPropName), ctl.Location);
            }
            if (ctl != null && (changeType & DesignElement.Sizing) != 0)
            {
                propNames.Add(GetPropertyName(ctl.Name, SizePropName), ctl.Size);
            }
            if (ctl != null && (changeType & DesignElement.Visibility) != 0)
            {
                propNames.Add(GetPropertyName(ctl.Name, VisiblePropName), ctl.Visible);
            }
            return propNames;
        }
        public static string GetTextPropertyName(object component, ref string text)
        {
            if (component is IApplicationForm)
            {
                text = ((IApplicationForm)component).Caption;
                return "$this.Caption";
            }
            if (component is GridColumn)
            {
                text = ((GridColumn)component).Caption;
                return GetPropertyName(((GridColumn)component).Name, CaptionPropName);
            }
            if (component is GridBand)
            {
                text = ((GridBand)component).Caption;
                return GetPropertyName(((GridBand)component).Name, CaptionPropName);
            }
            if (component is TreeListColumn)
            {
                text = ((TreeListColumn)component).Caption;
                return GetPropertyName(((TreeListColumn)component).Name, CaptionPropName);
            }
            if (component is NavBarGroup)
            {
                text = ((NavBarGroup)component).Caption;
                return GetPropertyName(((NavBarGroup)component).Name, CaptionPropName);
            }
            if (component is CheckEdit)
            {
                text = ((CheckEdit)component).Properties.Caption;
                return GetPropertyName(((CheckEdit)component).Name + ".Properties", CaptionPropName);
            }
            if (component is BaseLayoutItem)
            {
                text = ((BaseLayoutItem)component).Text;
                return GetPropertyName(((BaseLayoutItem)component).Name, TextPropName);
            }
            if (component is Control)
            {
                text = ((Control)component).Text;
                return GetPropertyName(((Control)component).Name, TextPropName);
            }
            if (component is BarItem)
            {
                text = ((BarItem)component).Caption;
                return GetPropertyName(((BarItem)component).Name, CaptionPropName);
            }
            return null;
        }
        public static string GetComponentText(object component)
        {
            string text = string.Empty;
            GetTextPropertyName(component, ref text);
            return text;
        }
        public static void SetComponentText(object component, string text)
        {

            //if (component is IApplicationForm)
            //{
            //    ((IApplicationForm)component).Caption = text;
            //}
            //else
            if (component is Control)
            {
                ((Control)component).Text = text;
            }
            else if (component is GridColumn)
            {
                ((GridColumn)component).Caption = text;
            }
            else if (component is GridBand)
            {
                ((GridBand)component).Caption = text;
            }
            else if (component is TreeListColumn)
            {
                ((TreeListColumn)component).Caption = text;
            }
            else if (component is NavBarGroup)
            {
                ((NavBarGroup)component).Caption = text;
            }
            else if (component is BarItem)
            {
                ((BarItem)component).Caption = text;
            }
            else if (component is BaseLayoutItem)
            {
                ((BaseLayoutItem)component).Text = text;
            }
            else
            {
                Dbg.Debug("SetComponentText method ignores component {0}");
            }
        }

    }
}
