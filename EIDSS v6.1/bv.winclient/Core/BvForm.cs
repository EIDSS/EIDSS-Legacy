using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList.Columns;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Resources.TranslationTool;
using bv.model.Helpers;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using DevExpress.XtraEditors;
using bv.winclient.Core.TranslationTool;
using DevExpress.XtraLayout;

namespace bv.winclient.Core
{
    public partial class BvForm : XtraForm, IApplicationForm, ITranslationView
    {
        public BvForm()
        {
            StoredAutoScaleFactor = new SizeF(1, 1);

            InitializeComponent();
            KeyDown += BaseForm_KeyDown;
            KeyPreview = true;
            RtlHelper.SetRTL(this);
        }

        public bool Close(FormClosingMode closeMode)
        {
            //сохраняем все переводы, если мы в режиме правки
            if (BaseSettings.TranslationMode && DCManager!=null && DCManager.HasChanges)
            {
                if (!DCManager.SaveTranslations())
                    return false;
            }

            Close();
            return true;
        }

        public new Control Activate()
        {
            base.Activate();
            BringToFront();
            return this;
        }

        [Browsable(true), Localizable(false)]
        public bool Sizable { get; set; }

        [Browsable(false)]
        public virtual string Caption
        {
            get { return Text; }
        }

        [Browsable(false)]
        public object Key
        {
            get { return null; }
        }
        public Dictionary<string, object> StartUpParameters { get; set; }


        public void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (!string.IsNullOrWhiteSpace(HelpTopicId))
                    ShowHelp(HelpTopicId);
            }
        }
        protected override bool ProcessCmdKey
            (
            ref Message msg,
            Keys keyData
            )
        {
            var dcManager = DCManager;
            if (dcManager == null && Controls.Count > 0 && Controls[0] is ITranslationView)
                dcManager = ((ITranslationView) Controls[0]).DCManager;

            if (dcManager!=null && dcManager.IsDesignMode)
                return dcManager.ProcessKey(keyData);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        [Browsable(true), Localizable(false)]
        public string HelpTopicId { get; set; }
        public void Release()
        {

        }
        protected void ShowHelp(string helpTopicID)
        {
            if (!WinClientContext.HelpNames.ContainsKey(ModelUserContext.CurrentLanguage))
                return;
            Help2.ShowHelp(this, WinClientContext.HelpNames[ModelUserContext.CurrentLanguage], helpTopicID);
        }



        public void ShowHelp()
        {
            ShowHelp(HelpTopicId);
        }

        [Browsable(false), DefaultValue(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DisableDelayedDisposing { get; set; }

        [Browsable(true), DefaultValue(0), Localizable(false)]
        public int MinHeight { get; set; }

        [Browsable(true), DefaultValue(0), Localizable(false)]
        public int MinWidth { get; set; }

        public virtual bool IsSingleTone
        {
            get { return true; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public int RtlRecalcWidth { get; set; }

        public ActionMetaItem GetLastExecutedAction()
        {
            return null; //TODO если на форме есть какие-то ActionPanel, то можно от них получать сведения о последнем действии
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DesignControlManager DCManager { get; set; }

        public virtual void ApplyResources(string cultureCode)
        {
            TranslationToolHelperWinClient.ApplyViewResources(this, cultureCode);
        }


        public virtual bool SaveChanges(Dictionary<object, DesignElement> changes, string cultureCode)
        {
            return TranslationToolHelperWinClient.SaveViewChanges(this, changes, cultureCode);
        }

        public virtual string SetExclusionText(Component component, string resourceName, string textId, string cultureCode)
        {
            throw new System.NotImplementedException();
        }
        private readonly Dictionary<Component, ExclusionItem> m_ExclusionsList = new Dictionary<Component, ExclusionItem>();
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<Component, ExclusionItem> ExclusionsList
        {
            get { return m_ExclusionsList; }
        }

        private readonly Dictionary<string, Component> m_EditableControlsList = new Dictionary<string, Component>();
        public Dictionary<string, Component> EditableControlsList
        {
            get { return m_EditableControlsList; }
        }

        public virtual string GetKeyForComponent(Component component, DesignElement designType)
        {
            return TranslationToolHelperWinClient.GetPropertyNameForComponent(component, designType);
        }
        public virtual string GetResourceNameForComponent(Component component, DesignElement designType)
        {
            if ((designType & DesignElement.Caption) != 0 && ExclusionsList.ContainsKey(component))
            {
                return ExclusionsList[component].Resource.ToString();
            }
            var propName = GetKeyForComponent(component, designType);
            var declaringType = TranslationToolHelperWinClient.GetControlViewDeclaringType(component, propName);
            if (declaringType != null)
                return declaringType.Name;
            return GetType().Name;
        }
        public virtual string FormatText(Component component, string text, string textId)
        {
            return text;
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual DesignElement GetDesignTypeForComponent(Component component)
        {
            var de = DesignElement.None;
            var ctl = component as Control;
            if(ctl!=null)
            {
            if (ctl.GetType().DeclaringType!=null && ctl.GetType().DeclaringType != GetType())
                return de;
            if (TranslationToolHelperWinClient.IsSelectableControl(ctl))
                de = de | DesignElement.Sizing | DesignElement.Moving;
            if (TranslationToolHelperWinClient.IsEditableControl(ctl))
                de = de | DesignElement.Caption;
            }
            else if (component is GridColumn || component is TreeListColumn || component is NavBarGroup || component is LayoutControlItem)
                de = de | DesignElement.Caption;
            return de;
        }

 
        public virtual void ApplyExclusions(Dictionary<string, ResourceValue> dict, string cultureCode)
        {

        }

        protected TranslationButton m_TranslationButton;
        public virtual void AddButtons()
        {
            if (!BaseSettings.TranslationMode)
                return;
            SuspendLayout();
            m_TranslationButton = new TranslationButton { Left = 4 };
            m_TranslationButton.Top = ClientSize.Height - m_TranslationButton.Height - 4;
            m_TranslationButton.Parent = this;
            ResumeLayout();
        }
        private readonly Dictionary<string, ResourceValue> m_ResourcesList = new Dictionary<string, ResourceValue>();
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, ResourceValue> ResourcesList
        {
            get { return m_ResourcesList; }
        }

        private readonly Dictionary<string, ResourceValue> m_DefaultResourcesList = new Dictionary<string, ResourceValue>();
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, ResourceValue> DefaultResourcesList { get { return m_DefaultResourcesList; } }

        public virtual bool CanHideControl(Control sourceControl)
        {
            return true;
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual DesignOperationHandler AfterDesignOperation
        {
            get { return null; }
        }

        public virtual string GetViewNameForSplittedResources()
        {
            return GetType().Name;
        }

        public virtual string GetViewNameForResourceUsage()
        {
            return GetType().Name;
        }

        public virtual void ControlBoundChange(object sender, EventArgs args)
        {
            
        }

        public SizeF StoredAutoScaleFactor { get; set; }

        private void BvForm_Load(object sender, EventArgs e)
        {
        }
    }
}