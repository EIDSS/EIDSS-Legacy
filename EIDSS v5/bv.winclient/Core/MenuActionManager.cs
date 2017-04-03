using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.model.Model.Core;
using DevExpress.XtraBars;

namespace bv.winclient.Core
{
    public class MenuActionManager : MenuManagerBase
    {
        private readonly Form m_MainForm;
        private readonly BarManager m_BarManager;
        private readonly Bar m_Bar;
        private readonly IUser m_User;

        public MenuActionManager(Form mainForm, BarManager barManager, Bar bar, IUser user)
        {
            MenuItems = new List<IMenuAction>();
            m_BarManager = barManager;
            m_Bar = bar;
            m_MainForm = mainForm;
            m_User = user;
            Clear();
        }

        #region Public methods

        private static MenuActionManager m_Instance;

        public static MenuActionManager Instance
        {
            get
            {
                Dbg.DbgAssert(m_Instance != null,
                              "the instance of MenuActionManager must be explicitly initialized before using");
                return m_Instance;
            }
            set { m_Instance = value; }
        }

        private bool m_ShowButtonCaption;

        public void LoadAssemblyActions(string assemblyName)
        {
            try
            {
                Assembly a = Assembly.LoadFrom(assemblyName);
                Type[] mytypes = a.GetTypes();
                const BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance |
                                           BindingFlags.DeclaredOnly;
                foreach (Type tempType in mytypes)
                {
                    Type t = tempType;
                    MethodInfo m = t.GetMethod("Register", flags);
                    if (m != null)
                    {
                        var Params = new object[] { m_MainForm };
                        try
                        {
                            m.Invoke(null, @Params);
                        }
                        catch (Exception ex)
                        {
                            Dbg.Debug(ex.ToString());
                            if (ex.InnerException != null)
                            {
                                Dbg.Debug(ex.InnerException.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during loading assembly {0}: {1}", assemblyName, ex.ToString());
                if (ex is ReflectionTypeLoadException)
                    Dbg.Debug("LoaderException: {0}", (ex as ReflectionTypeLoadException).LoaderExceptions.ToString());

            }
        }


        public void DisplayActions()
        {
            PrepareActions();
            foreach (MenuAction category in MenuItems)
            {
                object categoryItem = AddTopMenuItem(category);
                foreach (MenuAction a in category.Items)
                {
                    AddAction(categoryItem, a);
                }
                var mi = categoryItem as MenuItem;
                if (mi != null && mi.MenuItems.Count == 0)
                {
                    mi.Dispose();
                }
                var barItem = categoryItem as BarSubItem;
                if (barItem != null)
                {
                    if (ClearEmptyItems(barItem) != null)
                    {
                        m_BarManager.MainMenu.AddItem(barItem);
                    }
                }
                if (m_Bar != null)
                {
                    for (int i = m_Bar.ItemLinks.Count - 1; i >= 0; i--)
                    {
                        BarItemLink li = m_Bar.ItemLinks[i];
                        if ((li.Item) is BarLargeButtonItem
                            && ((BarLargeButtonItem)li.Item).ButtonStyle == BarButtonStyle.DropDown
                            && (((BarLargeButtonItem)li.Item).DropDownControl == null
                                || ((PopupMenu)(((BarLargeButtonItem)li.Item).DropDownControl)).ItemLinks.Count == 0))
                        {
                            m_Bar.ItemLinks[i].Dispose();
                        }
                    }
                }
            }
        }

        public static BarSubItem ClearEmptyItems(BarSubItem barItem)
        {
            for (int i = barItem.ItemLinks.Count - 1; i >= 0; i--)
            {
                BarItemLink li = barItem.ItemLinks[i];
                if ((li.Item) is BarSubItem)
                {
                    ClearEmptyItems((BarSubItem)li.Item);
                }
            }
            if (barItem.ItemLinks.Count == 0)
            {
                barItem.Dispose();
                return null;
            }
            return barItem;
        }


        public bool LockActions()
        {
            return m_ActionLocker.Lock();
        }

        public void UnlockActions()
        {
            m_ActionLocker.Unlock();
        }

        public new MenuAction FindAction(string resourceKey)
        {
            return FindAction(MenuItems, resourceKey) as MenuAction;
        }

        public MenuAction FindAction(string resourceKey, IMenuAction parent, int order)
        {
            MenuAction action = FindAction(MenuItems, resourceKey) as MenuAction?? new MenuAction(this, parent, resourceKey, order);
            return action;
        }
        public MenuAction FindAction(string resourceKey, IMenuAction parent, int order, int smallImageIndex, int bigImageIndex)
        {
            MenuAction action = FindAction(MenuItems, resourceKey) as MenuAction ?? new MenuAction(this, parent, resourceKey, order);
            if (bigImageIndex >= 0 && action.BigIconIndex != bigImageIndex)
                action.BigIconIndex = bigImageIndex;
            if (smallImageIndex >= 0 && action.SmallIconIndex != smallImageIndex)
                action.SmallIconIndex = smallImageIndex;
            return action;

        }

        //public static void Restrict(string[] arrActions)
        //{
        //    bool find;
        //    int nIndexA;
        //    int nIndexC;
        //    MenuAction a;
        //    MenuCategory c;

        //    for (nIndexC = m_MenuItems.Count - 1; nIndexC >= 0; nIndexC--)
        //    {
        //        c = (MenuCategory)(m_MenuItems[nIndexC]);
        //        for (nIndexA = c.Items.Count - 1; nIndexA >= 0; nIndexA--)
        //        {
        //            a = (MenuAction)(c.Items[nIndexA]);
        //            find = RestrictAction(arrActions, a);
        //            if (find == false)
        //            {
        //                c.Items.RemoveAt(nIndexA);
        //            }
        //        }
        //        if (c.Items.Count == 0)
        //        {
        //            //m_MenuItems.RemoveAt(nIndexC)
        //        }
        //    }
        //}

        //protected static bool RestrictAction(string[] arrActions, MenuAction action)
        //{
        //    bool find;
        //    bool findSubaction;
        //    int nIndex;
        //    MenuAction subAction;

        //    find = false;

        //    foreach (string actionName in arrActions)
        //    {
        //        if (actionName.CompareTo(action.Caption) == 0)
        //        {
        //            find = true;
        //            break;
        //        }
        //    }

        //    //>>>> Added by Andrey 25-Sep-2007
        //    if (action.Name.IndexOf(".rpt") != -1)
        //    {
        //        find = true;
        //    }
        //    //<<<< Added by Andrey 25-Sep-2007

        //    if ((find == true) && (action.Items != null) && (action.Items.Count > 0))
        //    {
        //        for (nIndex = action.Items.Count - 1; nIndex >= 0; nIndex--)
        //        {
        //            subAction = (MenuAction)(action.Items[nIndex]);
        //            findSubaction = RestrictAction(arrActions, subAction);
        //            if (findSubaction == false)
        //            {
        //                action.Items.RemoveAt(nIndex);
        //            }
        //        }
        //    }
        //    return (find);
        //}

        #endregion

        #region Private methods

        public void Clear()
        {
            MenuItems.Clear(); 
            m_File = new MenuAction(this, null, "MenuFile", 1);
            m_Edit = new MenuAction(this, null, "MenuEdit", 100);
            m_View = new MenuAction(this, null, "MenuView", 200);
            m_Journals = new MenuAction(this, null, "MenuCatalogs", 300);
            m_Operations = new MenuAction(this, null, "MenuOperations", 400);
            m_Create = new MenuAction(this, null, "MenuCreate", 450);
            m_Search = new MenuAction(this, null, "MenuSearch", 500);
            m_Reports = new MenuAction(this, null, "MenuReports", 600);
            m_Maps = new MenuAction(this, null, "MenuMaps", 650);

            m_Documents = new MenuAction(this, null, "MenuDocuments", 700);
            m_Options = new MenuAction(this, null, "MenuOptions", 800);
            m_System = new MenuAction(this, null, "MenuSystem", 900);
            m_Avr = new MenuAction(this, null, "MenuRAM", 950);
            m_Security = new MenuAction(this, null, "MenuSecurity", 1000);
            m_DataExport = new MenuAction(this, null, "MenuDataExport", 1100);
            m_Window = new MenuAction(this, null, "MenuWindow", 999900);
            m_Help = new MenuAction(this, null, "MenuHelp", 1000000);
            m_ShowButtonCaption = BaseSettings.ShowCaptionOnToolbar;
            //If Not m_Toolbar Is Nothing Then m_Toolbar.Buttons.Clear()
            //If Not m_MainMenu Is Nothing Then m_MainMenu.MenuItems.Clear()
            if (m_BarManager != null)
            {
                int i;
                for (i = m_BarManager.Items.Count - 1; i >= 0; i--)
                {
                    if (
                        !(m_BarManager.Items[i].Links.Count > 0 && (m_BarManager.Items[i].Links[0].LinkedObject) is Bar &&
                          ((Bar)(m_BarManager.Items[i].Links[0].LinkedObject)).IsStatusBar))
                    {
                        m_BarManager.Items[i].Dispose();
                    }
                }
                //m_BarManager.Items.Clear()
            }
            //If Not m_Bar Is Nothing Then m_Bar.ClearLinks()
        }


        private static readonly Regex m_AppRegEx = new Regex("&(?!&)");

        private static string GetToolTipText(string caption)
        {
            return m_AppRegEx.Replace(caption, "");
        }

        private object AddTopMenuItem(MenuAction c)
        {
            if (m_BarManager != null)
            {
                var category = new BarSubItem { ImageIndex = c.SmallIconIndex, Caption = c.Caption};
                m_BarManager.Items.Add(category);
                if (c.ShowInToolbar)
                {
                    var toolbarButton = new BarLargeButtonItem(m_BarManager, c.Caption);
                    toolbarButton.Hint = GetToolTipText(toolbarButton.Caption);
                    toolbarButton.ImageIndex = c.SmallIconIndex;
                    toolbarButton.LargeImageIndex = c.BigIconIndex;
                    toolbarButton.ButtonStyle = BarButtonStyle.DropDown;
                    toolbarButton.DropDownControl = new PopupMenu();
                    toolbarButton.ShowCaptionOnBar = m_ShowButtonCaption;
                    toolbarButton.CaptionAlignment = BarItemCaptionAlignment.Bottom;
                    toolbarButton.PaintStyle = BarItemPaintStyle.CaptionInMenu;
                    category.Tag = toolbarButton;
                    BarItemLink bl = m_Bar.AddItem(toolbarButton);
                    if (m_IsGroup || c.BeginGroup)
                    {
                        bl.BeginGroup = true;
                    }
                }
                return category;
            }
            return null;
        }

        private static bool m_IsGroup;

        private void AddAction(object parentMenuItem, MenuAction a)
        {
            if (!m_User.HasPermission(a.SelectPermission))
            {
                return;
            }
            BarItem btn = null;
            if (parentMenuItem != null)
            {
                if (m_BarManager != null)
                {
                    var parentBarItem = parentMenuItem as BarSubItem;
                    if (a.ResourceKey == "MenuSeparator")
                    {
                        m_IsGroup = true;
                        return;
                    }
                    if (a.Items != null && a.Items.Count > 0 || a.IsCategory)
                    {
                        btn = new BarSubItem(m_BarManager, a.Caption);
                    }
                    else
                    {
                        if (a.ResourceKey == "MenuWindows")
                        {
                            btn = new BarMdiChildrenListItem();
                            m_IsGroup = true;
                        }
                        else if (a.IsCheckBoxAction)
                        {
                            btn = new BarCheckItem(m_BarManager, false) { Caption = a.Caption };
                            btn.ItemClick += a.BarClick;

                        }
                        else
                        {
                            btn = new BarLargeButtonItem(m_BarManager, a.Caption)
                                {
                                    LargeImageIndex = a.BigIconIndex,
                                    ImageIndex = a.SmallIconIndex
                                };
                            ((BarLargeButtonItem)btn).ShowCaptionOnBar = m_ShowButtonCaption;
                            if (btn.Width > 100)
                            {
                                btn.Width = 100;
                            }
                            btn.ItemClick += a.BarClick;
                        }
                    }
                    btn.ImageIndex = a.SmallIconIndex;
                    btn.Description = btn.Caption;
                    btn.Hint = GetToolTipText(btn.Caption);
                    BarItemLink bl;
                    if (a.ShowInMenu)
                    {
                        m_BarManager.Items.Add(btn);
                        a.MenuItem = btn;
                        if (parentBarItem != null)
                        {
                            bl = parentBarItem.AddItem(btn);
                            if (parentBarItem.Tag != null)
                            {
                                var cat1 = (BarLargeButtonItem)parentBarItem.Tag;
                                BarItemLink bl1 = ((PopupMenu)cat1.DropDownControl).ItemLinks.Add(btn);
                                if (m_IsGroup)
                                {
                                    bl1.BeginGroup = true;
                                }
                            }
                            if (m_IsGroup || a.BeginGroup)
                            {
                                bl.BeginGroup = true;
                            }
                        }
                    }
                    if (a.ShowInToolbar && m_Bar != null)
                    {
                        if ((btn) is BarSubItem)
                        {
                            var btn1 = new BarLargeButtonItem(m_BarManager, a.Caption);
                            btn1.Hint = GetToolTipText(btn1.Caption);
                            btn1.ImageIndex = a.SmallIconIndex;
                            btn1.LargeImageIndex = a.BigIconIndex;
                            btn1.ButtonStyle = BarButtonStyle.DropDown;
                            btn1.DropDownControl = new PopupMenu();
                            btn1.ShowCaptionOnBar = m_ShowButtonCaption;
                            btn1.CaptionAlignment = BarItemCaptionAlignment.Bottom;
                            btn.Tag = btn1;
                            bl = m_Bar.AddItem(btn1);
                            a.ToolbarItem = btn1;
                            if (m_IsGroup || a.BeginGroup)
                            {
                                bl.BeginGroup = true;
                            }
                        }
                        else
                        {
                            bl = m_Bar.AddItem(btn);
                            if (m_IsGroup || a.BeginGroup)
                            {
                                bl.BeginGroup = true;
                            }
                        }
                    }
                    m_IsGroup = false;
                }
                if (a.Items != null && a.Items.Count > 0)
                {
                    foreach (MenuAction a1 in a.Items)
                    {
                        AddAction(btn, a1);
                    }
                }
            }
        }

        #endregion
    }
}