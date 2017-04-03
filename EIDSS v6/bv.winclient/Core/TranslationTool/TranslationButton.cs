using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
        private BarButtonItem m_BtnSave;
        private BarButtonItem m_BtnCancel;
        private BarButtonItem m_BtnShowHidden;
        private BarButtonItem m_BtnUndo;
        private void Init()
        {
            if (Parent == null)
                return;
            if (WinUtils.IsComponentInDesignMode(Parent))
                return;
            m_View = FindTraslationTool(Parent);
            if (m_View == null)
                return;
            m_PopupActions = new PopupMenu { Manager = BaseFormManager.MainBarManager ?? new BarManager() };
            m_PopupActions.BeforePopup += OnBeforePopup;
            DropDownControl = m_PopupActions;
            Click += ExecDefaultAction;
            m_BtnDesignMode = AddAction("Design",SwitchToDesignMode);
            m_BtnCancel = AddAction("Cancel Changes", CancelChanges);
            m_BtnSave = AddAction("Save Changes", CancelChanges);
            m_BtnShowHidden = AddAction("Show Hidden Controls", ShowHiddenControls);
            m_BtnUndo = AddAction("Undo", Undo);
            SetButtonsState(false);
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
            if(m_View==null)
                return;
            if (m_View.DCManager.IsDesignMode)
                SaveChanges(this, new ItemClickEventArgs(m_BtnSave,null));
            else
                SwitchToDesignMode(this, new ItemClickEventArgs(m_BtnDesignMode, null));
            
        }

        private ITranslationView FindTraslationTool(Control ctl)
        {
            if (ctl is BaseActionPanel)
                ctl = ((BaseActionPanel)ctl).ParentLayout.ParentBasePanel as Control;
            while(ctl!=null)
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

        private void SwitchToDesignMode(object sender, ItemClickEventArgs e)
        {
            SetButtonsState(true);
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
            bool undoEnabled = false;
            if (m_View!=null && m_View.DCManager != null)
            {
                m_View.DCManager.IsDesignMode = isDesignMode;
                undoEnabled = isDesignMode && m_View.DCManager.HasChanges;
            }
            Text = isDesignMode ? m_BtnSave.Caption : m_BtnDesignMode.Caption;
            m_BtnDesignMode.Enabled = !isDesignMode;
            m_BtnShowHidden.Enabled = isDesignMode;
            m_BtnCancel.Enabled = isDesignMode;
            m_BtnSave.Enabled = isDesignMode;
            m_BtnUndo.Enabled = undoEnabled;
            BringToFront();
        }

    }
}