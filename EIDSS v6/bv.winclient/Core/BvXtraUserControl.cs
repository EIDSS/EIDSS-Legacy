using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraTab;
using bv.common.Resources;
using bv.common.Resources.TranslationTool;
using bv.winclient.BasePanel;
using bv.winclient.Core.TranslationTool;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList.Columns;

[assembly: CLSCompliant(true)]
namespace bv.winclient.Core
{
    public class BvXtraUserControl : XtraUserControl, ITranslationView
    {
        public BvXtraUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private readonly IContainer components = null;

        protected BvResourceManagerChanger bvResourceManagerChanger1;

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bvResourceManagerChanger1 = new bv.common.Resources.BvResourceManagerChanger();
            this.SuspendLayout();
            // Form Is Localizable: False
            // 
            // BvXtraUserControl
            // 
            this.Name = "BvXtraUserControl";
            this.ResumeLayout(false);
        }

        #endregion

        public string GetResourceString(string resourceName)
        {
            var resources = new BvResourceManager(GetType());
            return resources.GetString(resourceName);
        }

        /// <summary>
        ///     Добавляем специальные кнопки-действия на панель управления
        /// </summary>
        public virtual void AddButtons()
        {
            //Does nothing, translation button is added to SimpleLayout explicitly
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

        public string SetExclusionText(Component component, string resourceName, string textId, string cultureCode)
        {
            throw new NotImplementedException();
        }

        private readonly Dictionary<Component, ExclusionItem> m_ExclusionsList = new Dictionary<Component, ExclusionItem>();

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<Component, ExclusionItem> ExclusionsList
        {
            get { return m_ExclusionsList; }
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
            Type declaringType = TranslationToolHelperWinClient.GetControlViewDeclaringType(component, propName);
            if (declaringType != null)
            {
                return declaringType.Name;
            }
            return GetType().Name;
        }

        public virtual string FormatText(Component component, string text, string textId)
        {
            return text;
        }

        public virtual DesignElement GetDesignTypeForComponent(Component component)
        {
            var de = DesignElement.None;
            var ctl = component as Control;
            if (ctl != null)
            {
                if (ctl.GetType().DeclaringType != null && ctl.GetType().DeclaringType != GetType())
                {
                    return de;
                }
                if (TranslationToolHelperWinClient.IsSelectableControl(ctl))
                {
                    if (ctl is XtraTabControl)
                        de = de | DesignElement.Moving;
                    else
                        de = de | DesignElement.Sizing | DesignElement.Moving;
                }
                if (TranslationToolHelperWinClient.IsEditableControl(ctl))
                {
                    de = de | DesignElement.Caption;
                }
            }
            else if (component is GridColumn || component is TreeListColumn || component is NavBarGroup)
            {
                de = de | DesignElement.Caption;
            }
            return de;
        }

        //[Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public virtual bool IsElementTranslatable(Component component)
        //{
        //    return true;
        //}

        //[Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public virtual bool IsControlSelectable(Control ctl)
        //{
        //    return true;
        //}

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

        protected string m_ViewNameForSplittedResources;

        public virtual string GetViewNameForSplittedResources()
        {
            if (!string.IsNullOrEmpty(m_ViewNameForSplittedResources))
            {
                return m_ViewNameForSplittedResources;
            }
            m_ViewNameForSplittedResources = GetType().Name;
            Control ctl = Parent;
            while (ctl != null)
            {
                if (ctl is ITranslationView)
                {
                    m_ViewNameForSplittedResources = ctl.GetType().Name + "." + m_ViewNameForSplittedResources;
                }
                ctl = ctl.Parent;
                if (ctl is IApplicationForm)
                {
                    break;
                }
            }
            return m_ViewNameForSplittedResources;
        }

        public virtual string GetViewNameForResourceUsage()
        {
            return GetType().Name;
        }

        public virtual void ControlBoundChange(object sender, EventArgs args)
        {

        }

        public virtual void ApplyExclusions(Dictionary<string, ResourceValue> dict, string cultureCode)
        {
            //NOOP;
        }
    }
}