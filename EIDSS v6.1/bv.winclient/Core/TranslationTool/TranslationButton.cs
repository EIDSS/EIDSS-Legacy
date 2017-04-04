using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using bv.common.Core;
using bv.common.Resources.TranslationTool;
using bv.winclient.ActionPanel;
using bv.winclient.BasePanel;

namespace bv.winclient.Core.TranslationTool
{
    public class TranslationButton : DropDownButton
    {
        private PopupMenu m_PopupActions;
        private ITranslationView m_View;
        public TranslationButton()
        {
            ParentChanged += OnMyParentChanged;
        }

        private void OnMyParentChanged(object sender, EventArgs e)
        {
            Init();
        }

        private BarButtonItem m_BtnDesignMode;
        private BarButtonItem m_BtnShowTranslationTool;
        private BarButtonItem m_BtnSave;
        private BarButtonItem m_BtnCancel;
        private BarButtonItem m_BtnShowHidden;
        private BarButtonItem m_BtnUndo;
        private List<BarButtonItem> m_TranslateButtons;

        private void Init()
        {
            if (Parent == null) return;
            if (WinUtils.IsComponentInDesignMode(Parent)) return;
            m_View = FindTraslationTool(Parent);
            if (m_View == null) return;

            m_PopupActions = new PopupMenu { Manager = BaseFormManager.MainBarManager ?? new BarManager() };
            m_PopupActions.BeforePopup += OnBeforePopup;
            DropDownControl = m_PopupActions;
            Click += ExecDefaultAction;
            m_BtnDesignMode = AddAction("Design",SwitchToDesignMode);
            m_BtnShowTranslationTool = AddAction("Show All Form Translations", ShowTranslationTool);
            m_BtnCancel = AddAction("Cancel Changes", CancelChanges);
            m_BtnSave = AddAction("Save Changes", CancelChanges);
            m_BtnShowHidden = AddAction("Show Hidden Controls", ShowHiddenControls);
            m_BtnUndo = AddAction("Undo", Undo);
            m_TranslateButtons = new List<BarButtonItem>();
            SetButtonsState(false);
        }

        // Show all form texts in one modal window to edit their translations
        private void ShowTranslationTool(object sender, ItemClickEventArgs e)
        {
            var bsi = e.Item;
            var f = new FormTranslationsEditor();
            if (f.EditTranslations(m_View.DCManager.Views) == DialogResult.OK)
            {
                var changes = f.GetChanges();
                foreach (var args in changes)
                {
                    m_View.DCManager.PushToUndoStack(null, args);
                }
            }
        }

        private void OnBeforePopup(object sender, CancelEventArgs e)
        {
            bool undoEnabled = false;
            if (m_View != null && m_View.DCManager != null)
            {
                undoEnabled = m_View.DCManager.IsDesignMode && m_View.DCManager.HasChanges;
            }
            m_BtnUndo.Enabled = undoEnabled;
        }

        private void Undo(object sender, ItemClickEventArgs e)
        {
            m_View.DCManager.Undo();
        }

        private void ExecDefaultAction(object sender, EventArgs e)
        {
            if (m_View == null) return;
            if (m_View.DCManager.IsDesignMode)
                SaveChanges(this, new ItemClickEventArgs(m_BtnSave, null));
            else
                SwitchToDesignMode(this, new ItemClickEventArgs(m_BtnDesignMode, null));
            
        }

        private ITranslationView FindTraslationTool(Control ctl)
        {
            if (ctl is BaseActionPanel)
                ctl = ((BaseActionPanel)ctl).ParentLayout.ParentBasePanel as Control;
            while (ctl != null)
            {
                if (ctl is ITranslationView)
                    return ctl as ITranslationView;
                ctl = ctl.Parent;
            }
            return null;
        }

        private BarButtonItem AddAction(string caption, ItemClickEventHandler handler)
        {
            var button = new BarButtonItem(m_PopupActions.Manager, caption);
            button.ItemClick += handler;
            m_PopupActions.AddItem(button);
            return button;
        }

        public void RefreshPopupMenu()
        {
            if (m_PopupActions.ItemLinks.Count == 0)
            {
                m_PopupActions.AddItem(m_BtnDesignMode);
                m_PopupActions.AddItem(m_BtnShowTranslationTool);
                m_PopupActions.AddItem(m_BtnCancel);
                m_PopupActions.AddItem(m_BtnSave);
                m_PopupActions.AddItem(m_BtnShowHidden);
                m_PopupActions.AddItem(m_BtnUndo);

            }
        }
        private void SwitchToDesignMode(object sender, ItemClickEventArgs e)
        {
            SetButtonsState(true);
            //
            //Create a special edit button for each Bar Menu 
            if (m_View.DCManager == null) return;
            var dockedBars = m_View.DCManager.GetControlsByType(typeof(DockedBarControl));
            var menuExclusions = m_View.ExclusionsList.Keys.ToList().Where(i => m_View.ExclusionsList[i].Source != ExclusionSource.Xml);
            foreach (var key in menuExclusions)
            {
                m_View.ExclusionsList.Remove(key);
                }
            if (dockedBars != null && dockedBars.Count > 0)
            {
                foreach (Bar bar in ((DockedBarControl)dockedBars[0]).Manager.Bars)
                {
                    if (bar.IsStatusBar)
                        continue;
                AddTranslateBarItem(bar.ItemLinks, bar.Manager);
            }
        }
        }

        private void AddTranslateBarItem(BarItemLinkCollection collection, BarManager manager)
        {
            var bi = new BarButtonItem(manager, "Translate");
            m_TranslateButtons.Add(bi);
            bi.ItemClick += TranslationBarItem_Click;
            bi.Tag = collection;
            foreach (BarItemLink il in collection)
            {
                var action = il.Item.Tag as MenuAction;
                if (action != null)
                {
                    if (string.IsNullOrEmpty(il.Item.Name))
                        il.Item.Name = GetUniqueMenuName();
                    m_View.ExclusionsList.Add(il.Item, new ExclusionItem()
                        {
                            Resource = CommonResource.EidssMenu,
                            Disabled = false,
                            Keys = new[] { action.ResourceKey },
                            Source = ExclusionSource.MenuAction
                        });
                    var propName = TranslationToolHelperWinClient.GetPropertyNameForComponent(il.Item,
                                                                                              DesignElement.Caption);
                    string englishCaption;
                    if (action.ItemsStorage != null)
                        englishCaption = action.ItemsStorage.GetString(action.ResourceKey, null, Localizer.lngEn);
                    else
                        englishCaption = il.Caption;
                    if (m_View.ResourcesList.ContainsKey(propName))
                    {

                        m_View.ResourcesList[propName].EnglishText = englishCaption;
                        m_View.ResourcesList[propName].ResourceName = CommonResource.EidssMenu.ToString();
                        m_View.ResourcesList[propName].SourceKey = action.ResourceKey;
                        m_View.ResourcesList[propName].Value = il.Caption;
                    }
                    else
                        m_View.ResourcesList.Add(propName, new ResourceValue()
                            {
                                EnglishText = englishCaption,
                                ResourceName = CommonResource.EidssMenu.ToString(),
                                SourceKey = action.ResourceKey,
                                Value = il.Caption
                            });
                }
                var bsi = il.Item as BarSubItem;
                if (bsi == null)
                {
                    il.Item.Enabled = false;
                    continue;
                }
                AddTranslateBarItem(bsi.ItemLinks, manager);
            }
            collection.Add(bi);
        }

        private int m_Counter = 1;
        private string GetUniqueMenuName()
        {
            return string.Format("___menuItem{0}", m_Counter++);
        }

        void TranslationBarItem_Click(object sender, ItemClickEventArgs e)
        {
            var bsi = e.Item;
            var collection = (BarItemLinkCollection)bsi.Tag;
            var f = new MenuEditor();
            if (f.EditMenu(collection) == DialogResult.OK)
            {
                var changes = f.GetChanges();
                foreach (var args in changes)
                {
                    m_View.DCManager.PushToUndoStack(null, args);
                }
            }

            //var f = new PropertyGrid();
            //f.RefreshPropertiesGrid(collection);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    var model = f.Model;
            //    for (var index = 0; index < model.MenuItems.Count; index++)
            //    {
            //        var ci = collection[index];
            //        var state = new UndoControlState { Element = ci.Item, Operation = UndoOperation.Text };
            //        var args = new ControlDesignerEventArgs { UndoState = state };
            //        m_View.DCManager.PushToUndoStack(null, args);
            //        ci.Item.Caption = model.MenuItems[index];
            //    }
            //}
        }

        private void SaveChanges(object sender, ItemClickEventArgs e)
        {
            if (m_View.DCManager.SaveTranslations())
            {
                m_View.DCManager.IsDesignMode = false;
                Text = m_BtnDesignMode.Caption;
                SetButtonsState(false);
            }
        }


        private void CancelChanges(object sender, ItemClickEventArgs e)
        {
            m_View.DCManager.CancelChanges();
            SetButtonsState(false);
        }


        private void ShowHiddenControls(object sender, ItemClickEventArgs e)
        {
            m_View.DCManager.ShowHiddenControls();
        }


        private void SetButtonsState(bool isDesignMode)
        {
            var undoEnabled = false;
            if (m_View != null && m_View.DCManager != null)
            {
                m_View.DCManager.IsDesignMode = isDesignMode;
                undoEnabled = isDesignMode && m_View.DCManager.HasChanges;
            }
            Text = isDesignMode ? m_BtnSave.Caption : m_BtnDesignMode.Caption;
            m_BtnDesignMode.Enabled = !isDesignMode;
            m_BtnShowTranslationTool.Enabled = isDesignMode;
            m_BtnShowHidden.Enabled = isDesignMode;
            m_BtnCancel.Enabled = isDesignMode;
            m_BtnSave.Enabled = isDesignMode;
            m_BtnUndo.Enabled = undoEnabled;
            if (!DesignMode)
            {
                foreach (var translationButton in m_TranslateButtons)
                {
                    foreach (BarItemLink il in (BarItemLinkCollection)(translationButton.Tag))
                        il.Item.Enabled = true;
                    translationButton.Dispose();
                }
                m_TranslateButtons.Clear();
            }
            BringToFront();
        }

    }
}