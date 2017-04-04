using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Helpers;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using bv.winclient.ActionPanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using Localizer = bv.common.Core.Localizer;

namespace bv.winclient.BasePanel
{

    public class BasePanel<T> : BvXtraUserControl, IBasePanel, IApplicationForm, IObjectEnvironment
        where T : class, IObject
    {
        protected readonly ActionLocker m_ActionLocker = new ActionLocker();


        /// <summary>
        /// 
        /// </summary>
        public BasePanel()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
                return;
            LifeTimeState = LifeTimeState.NotInitialized;
            InitRoutines();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BasePanel";
            this.Load += new System.EventHandler(this.BasePanel_Load);
            this.VisibleChanged += new System.EventHandler(this.BasePanel_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="businessObject"></param>
        //public BasePanel(T businessObject)
        //{
        //    InitializeComponent();
        //    LifeTimeState = LifeTimeState.NotInitialized;
        //    BusinessObject = businessObject;
        //    InitRoutines();
        //}

        /// <summary>
        /// 
        /// </summary>
        private void InitRoutines()
        {
            CustomActions = new List<ActionMetaItem>();
        }


        #region Properties

        private void ClearBusinesObjectEvents()
        {
            if (m_BusinessObject != null)
            {
                m_BusinessObject.Validation -= ShowValidationError;
                m_BusinessObject.ValidationEnd -= ValidationEnd;
                m_BusinessObject.AfterPost -= AfterPost;
            }
        }
        private IObject m_BusinessObject;

        protected void SetEnvironment(IObject bo)
        {
            if (bo != null)
            {
                bo.Environment = GetCurrentEnvironment();
            }
        }

        private IObjectEnvironment GetCurrentEnvironment()
        {
            return this;
            //IObjectEnvironment currentEnvironment= this;
            //IBasePanel parent = ParentBasePanel;
            //while (parent != null)
            //{
            //    var environment = parent as IObjectEnvironment;
            //    if (environment != null)
            //        currentEnvironment = environment;
            //    parent = parent.ParentBasePanel;
            //}
            //return currentEnvironment;
        }

        protected bool m_ControlsInitialized;

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IObject BusinessObject
        {
            get { return m_BusinessObject; }
            set
            {
                ClearBusinesObjectEvents();
                ClearBinding();
                m_BusinessObject = value;
                SetEnvironment(m_BusinessObject);
                //here we assign BusinessObject to all child panels
                //and define binding in child panels
                InitChildren();
                if (m_BusinessObject != null)
                {
                    m_BusinessObject.ValidationEnd += ValidationEnd;
                    m_BusinessObject.Validation += ShowValidationError;
                    m_BusinessObject.AfterPost += AfterPost;
                    DefineBinding();
                    if (!m_ReadOnly && Permissions != null)
                    {
                        if ((m_BusinessObject.IsNew && !Permissions.CanInsert) || (!m_BusinessObject.IsNew && !Permissions.CanUpdate))
                            m_ReadOnly = true;
                    }
                    m_BusinessObject.ReadOnly = m_ReadOnly;
                    if (!BaseSettings.ScanFormsMode)
                    {
                        DisplayReadOnly(false);
                        if (ParentBasePanel == null && !m_ControlsInitialized)
                        {
                            VisitControls(this, null, new VisitControlFunction[] { SetControlFont, CheckMandatoryField }, true);
                            m_ControlsInitialized = true;
                        }
                    }

                    VisualizePermissions();
                    LifeTimeState = LifeTimeState.DataLoaded;
                }
                else
                {
                    LifeTimeState = LifeTimeState.NotInitialized;
                }
            }
        }

        protected IObjectPermissions Permissions
        {
            get
            {
                IObjectPermissions permissions = null;
                if (RootPanel != null)
                    permissions = RootPanel.BusinessObject != null ? RootPanel.BusinessObject.GetAccessor() as IObjectPermissions : null;
                if (permissions == null)
                    permissions = BusinessObject != null ? BusinessObject.GetAccessor() as IObjectPermissions : null;
                return permissions;
            }
        }

        /// <summary>
        /// Возвращает последнее выполненное действие на любой панели, которая находится на том же Layout, что и эта панель
        /// </summary>
        /// <returns></returns>
        public ActionMetaItem GetLastExecutedAction()
        {
            ActionMetaItem result = null;
            if (ParentLayout != null)
            {
                result = ParentLayout.LastExecutedAction;
            }
            return result;
        }
        private void ClearLastExecutedAction()
        {
            if (ParentLayout != null)
            {
                ParentLayout.ClearLastExecutedAction();
            }
        }

        private string m_HelpTopicId;
        [Browsable(true), Localizable(false)]
        public string HelpTopicID
        {
            get
            {
                if (!Utils.IsEmpty(m_HelpTopicId))
                    return m_HelpTopicId;
                if (RootPanel.BusinessObject != null)
                {
                    var meta = RootPanel.BusinessObject.GetAccessor() as IObjectMeta;
                    if (meta != null)
                        return meta.HelpIdWin;
                }
                return "";
            }

            set { m_HelpTopicId = value; }
        }

        [Browsable(true), Localizable(true)]
        public virtual string Caption { get; set; }

        [Browsable(true), Localizable(false)]
        public string FormID { get; set; }

        [Browsable(true), Localizable(false)]
        public Image Icon { get; set; }

        [Browsable(true), Localizable(false)]
        public bool Sizable { get; set; }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, object> StartUpParameters { get; set; }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LifeTimeState LifeTimeState { get; set; }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static string BaseHelpFileName { get; set; }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IBasePanel ParentBasePanel
        {
            get { return GetParentBasePanel(this); }
        }

        private IBasePanel m_Root;

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IBasePanel RootPanel
        {
            get
            {
                if (m_Root == null)
                {
                    Control parent = Parent;
                    while (parent != null)
                    {
                        var basePanel = parent as IBasePanel;
                        if (basePanel != null)
                            m_Root = basePanel;
                        parent = parent.Parent;
                    }
                }
                return m_Root ?? this;
            }
        }

        protected IBasePanel GetParentBasePanel(Control ctl)
        {
            Control parent = ctl.Parent;
            while (parent != null)
            {
                var parentBasePanel = parent as IBasePanel;
                if (parentBasePanel != null)
                    return parentBasePanel;
                parent = parent.Parent;
            }
            return null;
        }

        protected bool m_ReadOnly;

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool ReadOnly
        {
            get { return m_ReadOnly; }
            set
            {
                m_ReadOnly = value;
                if (BusinessObject != null)
                {
                    BusinessObject.ReadOnly = value;
                    DisplayReadOnly(false);
                }
            }
        }

        protected bool m_Collapsed;

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool Collapsed
        {
            get { return m_Collapsed; }
            set { m_Collapsed = value; }
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Func<IObject, IObject> AdjustObject
        {
            get { return null; }
        }

        /// <summary>
        /// Default Layout (на котором лежит данная панель)
        /// </summary>
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected LayoutEmpty ParentLayout { get; set; }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLayoutCreated { get { return ParentLayout != null; } }

        #endregion

        #region IApplicationForm

        /// <summary>
        /// Подготавливает панель к отображению. Либо создаёт ок
        /// </summary>
        public virtual Control Activate()
        {
            Control container = this;
            //пробуем отыскать форму, на которой расположена панель
            Form form = FindForm();
            //если форму отыскать не удалось, то это её первый показ, и требуется инициализация
            if (form != null)
            {
                //последовательно поднимаем наверх подложку панели, а затем саму панель
                container = (Control)GetLayout();
                form.Activate();
                if (container != null)
                {
                    container.BringToFront();
                }
                BringToFront();
            }
            var layout = GetLayout();
            layout.DisplayValidationError();
            return container;
        }
        public virtual void SaveGridLayout()
        {
            foreach (var bp in m_ChildPanels)
            {
                var listPanel = bp as IBaseListPanel;
                if (listPanel != null)
                    listPanel.SaveGridLayout();
            }
        }

        public virtual bool Close(FormClosingMode closeMode)
        {
            //if (LifeTimeState == LifeTimeState.Closing)
            //    return;

            if (closeMode != FormClosingMode.NoSave)
            {
                if (closeMode == FormClosingMode.SaveWithConfirmation)
                {
                    if (!BaseActionPanel.ConfirmCancel(BusinessObject, FindForm()))
                        return false;
                    ClearLastExecutedAction();
                }
                else if (!Post())
                    return false;
            }


            //сохраняем все переводы, если мы в режиме правки
            if (BaseSettings.TranslationMode && DCManager != null && DCManager.HasChanges)
            {
                if (!DCManager.SaveTranslations())
                    return false;
                //ttForm.DCManager.Release();
            }
            SaveGridLayout();
            Release();

            var form = FindForm();
            if (form != null && form != BaseFormManager.MainForm)
            {
                form.Close();
                return true;
            }

            if (ParentLayout != null)
            {
                ParentLayout.Dispose();
            }
            Dispose();
            return true;
        }


        public virtual void Release()
        {
            ClearBusinesObjectEvents();
            ClearBinding();
            VisibleChanged -= BasePanel_VisibleChanged;
        }

        #endregion

        #region Actions support

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Type GetBusinessObjectType()
        {
            return typeof(T);
        }

        public List<ActionMetaItem> CustomActions { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void SetCustomActions(List<ActionMetaItem> actions)
        {
            if (!BaseSettings.TranslationMode) return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        protected void AddCustomAction(ActionMetaItem action)
        {
            CustomActions.Add(action);
        }

        #endregion

        #region Layout support

        /// <summary>
        /// Get current Layout
        /// </summary>
        /// <returns></returns>
        public virtual ILayout GetLayout()
        {
            //для базовой панели создаём самый простой Layout
            if (ParentLayout == null)
            {
                ParentLayout = this.CreateLayoutEmpty(BusinessObject);
                OnAfterLayoutCreated();
            }
            return ParentLayout;
        }

        public delegate void AfterLayoutCreatedDelegate();
        public event AfterLayoutCreatedDelegate AfterLayoutCreated;

        /// <summary>
        /// 
        /// </summary>
        protected void OnAfterLayoutCreated()
        {
            if (AfterLayoutCreated != null) AfterLayoutCreated();
        }


        #endregion

        protected static DbManagerProxy CreateDbManagerProxy()
        {
            Dbg.Assert(DbManagerFactory.Factory != null, "DbManagerFactory.Factory not initialized");
            // ReSharper disable PossibleNullReferenceException
            return DbManagerFactory.Factory.Create(ModelUserContext.Instance);
            // ReSharper restore PossibleNullReferenceException
        }

        #region Virtual methods

        public virtual void CheckPermissions()
        {
        }

        public virtual void DefineBinding()
        {
        }

        protected virtual void InitChildren()
        {
        }

        public virtual void LoadData(ref object id, int? hAcode = null)
        {
        }

        public virtual bool Post()
        {
            return true;
        }

        public virtual bool Delete(object key)
        {
            return true;
        }

        protected virtual void VisualizePermissions()
        {
        }

        public virtual void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //e.Handled = True
                Control focusedControl = ActiveControl;
                if (focusedControl == null)
                    return;
                while ((focusedControl) is ContainerControl && ((ContainerControl)focusedControl).ActiveControl != null)
                {
                    focusedControl = ((ContainerControl)focusedControl).ActiveControl;
                }
                if ((focusedControl) is GridControl)
                {
                    return;
                }
                if (focusedControl.Parent != null && (focusedControl.Parent) is GridControl)
                {
                    return;
                }
                if (focusedControl.Parent != null && focusedControl.Parent.Parent != null &&
                    (focusedControl.Parent.Parent) is GridControl)
                {
                    return;
                }
                //if ((FocusedControl) is bv.winclient.SearchPanel.BaseSearchPanel)
                //{
                //    ((bv.winclient.SearchPanel.BaseSearchPanel)FocusedControl).BaseSearchPanel_KeyDown(((BaseSearchPanel)FocusedControl).ActiveControl, e);
                //    return;
                //}
                // Not TypeOf (FocusedControl) Is LookUpEdit AndAlso _
                if ((focusedControl) is PopupBaseEdit && ((PopupBaseEdit)focusedControl).IsPopupOpen)
                {
                    return;
                }
                if ((focusedControl) is MemoEdit ||
                    ((focusedControl) is TextBoxMaskBox) &&
                    (focusedControl.Parent != null && (focusedControl.Parent) is MemoEdit))
                {
                    return;
                }
                //if (((FocusedControl) is TextBoxMaskBox) && (FocusedControl.Parent != null) && ((FocusedControl.Parent) is ButtonEdit))
                //{
                //    ButtonEdit edit = (ButtonEdit)FocusedControl.Parent;
                //    if ((edit.Tag != null) && ((edit.Tag) is TagHelper))
                //    {
                //        TagHelper helper = (TagHelper)edit.Tag;
                //        if (helper.IsBarcode)
                //        {
                //            edit.SelectAll();
                //            return;
                //        }
                //    }
                //}
                SelectNextControl(focusedControl, true, true, true, true);
            }
            else if (e.KeyCode == Keys.F1)
            {
                ShowHelp();
            }
            //else if (e.KeyCode == Keys.Escape)
            //{
            //  FindForm().Close();
            //}
        }

        public virtual void ShowReport()
        {
            // Should be overriden in child classes
            // ReSharper disable LocalizableElement
            MessageBox.Show("This is reports stub", "Stub", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // ReSharper restore LocalizableElement
        }

        #endregion

        #region Readonly support

        protected bool m_ReadonlyStateUpdated = false;
        public virtual void DisplayReadOnly(bool recursive)
        {
            if (Handle != IntPtr.Zero && Created && Parent != null)
            {
                VisitOwnControls(null, null, new VisitControlFunction[] { SetControlReadOnly });
                var layout = GetLayout();
                if (layout != null)
                    layout.RefreshActionButtons();
                m_ReadonlyStateUpdated = true;
            }
        }


        public void UpdateControlsState()
        {
            DisplayReadOnly(true);
        }

        protected Control SetControlReadOnly(string boName, Control ctl)
        {
            if (ctl is GridControl)
            {
                SetGridControlReadOnly(ctl as GridControl);
            }
            else if (ctl is TreeList)
            {
                SetTreeListReadOnly(ctl as TreeList);
            }
            else if (ctl is CheckedListBoxControl)
            {
                SetCheckedListBoxReadOnly(ctl as CheckedListBoxControl);
            }
            else if (ctl is BaseEdit)
            {
                SetBaseEditReadOnly(boName, ctl as BaseEdit);
            }
            else if (ctl is SimpleButton)
            {
                SetButtonReadOnly(ctl as SimpleButton);
            }
            return ctl;
        }

        private void SetButtonReadOnly(SimpleButton simpleButton)
        {
            var action = simpleButton.Tag as ActionMetaItem;
            if (action == null)
            {
                if (!m_ReadOnly || ShouldIgnoreReadonly(simpleButton.Tag))
                {
                    simpleButton.Enabled = true;
                }
                else
                {
                    simpleButton.Enabled = false;
                }
            }
            else
            {
                simpleButton.Enabled = action.IsEnable(BusinessObject, Permissions);
            }
        }

        private void SetBaseEditReadOnly(string boName, BaseEdit baseEdit)
        {
            string fieldName = GetBoundFieldName(boName, baseEdit);
            SetBaseEditStyle(baseEdit, fieldName);
        }

        private void SetCheckedListBoxReadOnly(CheckedListBoxControl checkedListBoxControl)
        {
            checkedListBoxControl.Enabled = !m_ReadOnly;
        }

        private void SetTreeListReadOnly(TreeList treeList)
        {
            if (ShouldIgnoreReadonly(treeList.Tag))
            {
                return;
            }
            treeList.OptionsBehavior.Editable = !m_ReadOnly;
            foreach (RepositoryItem item in treeList.RepositoryItems)
            {
                SetRepositoryItemReadOnly(item, m_ReadOnly);
            }
        }

        private void SetGridControlReadOnly(GridControl gridControl)
        {
            if (ShouldIgnoreReadonly(gridControl.Tag) || (this is IBaseListPanel && ((IBaseListPanel)this).InlineMode == InlineMode.None))
            {
                return;
            }
            if (gridControl.FocusedView is GridView)
            {
                var view = gridControl.FocusedView as GridView;
                view.OptionsBehavior.Editable = !m_ReadOnly;
            }
            foreach (RepositoryItem item in gridControl.RepositoryItems)
            {
                SetRepositoryItemReadOnly(item, m_ReadOnly);
            }
        }

        private static void SetRepositoryItemReadOnly(RepositoryItem c, bool readOnly)
        {
            c.ReadOnly = readOnly;
            var repositoryItemPopupBase = c as RepositoryItemPopupBase;
            if (repositoryItemPopupBase != null)
            {
                (repositoryItemPopupBase).ShowDropDown = readOnly ? ShowDropDown.Never : ShowDropDown.SingleClick;
                foreach (EditorButton btn in (repositoryItemPopupBase).Buttons)
                {
                    btn.Enabled = !readOnly;
                }
            }
        }

        protected void SetBaseEditStyle(BaseEdit c, string fielName)
        {
            var readOnly = IsReadOnlyField(fielName);
            c.TabStop = !readOnly;
            c.Properties.ReadOnly = readOnly;
            c.ShowToolTips = !readOnly;
            if (IsRequiredField(fielName))
            {
                LayoutCorrector.SetStyleController(c, LayoutCorrector.MandatoryStyleController);
            }
            else if (readOnly)
            {
                LayoutCorrector.SetStyleController(c, LayoutCorrector.ReadOnlyStyleController);
            }
            else if ((c) is PopupBaseEdit)
            {
                LayoutCorrector.SetStyleController(c, LayoutCorrector.DropDownStyleController);
            }
            else
            {
                LayoutCorrector.SetStyleController(c, LayoutCorrector.EditorStyleController);
            }
            var buttonEdit = c as ButtonEdit;
            if (buttonEdit != null)
            {
                foreach (EditorButton btn in buttonEdit.Properties.Buttons)
                {
                    if (ShouldIgnoreReadonly(btn.Tag)) continue;
                    //if (buttonEdit.StyleController is MandatoryStyleController && btn.Kind == ButtonPredefines.Delete)
                    //    btn.Visible = false;
                    //else
                    btn.Enabled = !readOnly;//btn.Visible = 
                }

                var popupBaseEdit = c as PopupBaseEdit;
                if (popupBaseEdit != null)
                {
                    if (readOnly)
                    {
                        // popupBaseEdit.Properties.ShowDropDown = ShowDropDown.Never;
                        //popupBaseEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
                    }
                    else
                    {
                        popupBaseEdit.SetPopupControlBehavior(false);

                        //popupBaseEdit.Properties.TextEditStyle = ((c) is PopupBaseEdit) ? TextEditStyles.DisableTextEditor : TextEditStyles.Standard;
                    }
                }
            }
        }

        private static bool ShouldIgnoreReadonly(object tag)
        {
            if (Utils.Str(tag).ToLowerInvariant().IndexOf("{alwayseditable}", StringComparison.Ordinal) >= 0)
            {
                return true;
            }
            //else if (IsStatusReadOnly && Utils.str[tag].ToLowerInvariant().IndexOf("{statuscontrol}") >= 0)
            //{
            //    return true;
            //}
            return false;
        }

        #endregion

        #region Help Support

        public virtual void ShowHelp()
        {
            ShowHelp(HelpTopicID);
        }

        [Browsable(false), DefaultValue(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DisableDelayedDisposing { get; set; }

        [Browsable(true), DefaultValue(0), Localizable(false)]
        public int MinHeight { get; set; }

        [Browsable(true), DefaultValue(0), Localizable(false)]
        public int MinWidth { get; set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public virtual bool IsSingleTone
        {
            get { return false; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public int RtlRecalcWidth { get; set; }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public bool IsRtlApplied { get; set; }

        public bool IsControlsInitialized { get { return m_ControlsInitialized; } }

        protected void ShowHelp(string topicID)
        {
            string language = ModelUserContext.CurrentLanguage;
            if (WinClientContext.HelpNames.ContainsKey(language) == false)
            {
                return;
            }
            if (!Utils.IsEmpty(topicID))
            {
                Help2.ShowHelp(this, WinClientContext.HelpNames[language], topicID);
            }
            else
            {
                Help2.ShowHelp(this, WinClientContext.HelpNames[language]);
            }
        }

        #endregion

        #region Validation Support

        public virtual void ValidationEnd(object sender, ValidationEventArgs args)
        {
            object ctl = FindControlByPropertyName(this, null, args);
            if (ctl != null)
            {
                var c = ctl as BaseEdit;
                if (c != null && c.DataBindings.Count > 0)
                {
                    var o = (IObject)sender;
                    c.EditValue = o.GetValue(c.DataBindings[0].BindingMemberInfo.BindingField);
                }
                FocusControl(ctl);
            }
        }

        public object ShowValidationErrorWithoutSetFocus(object sender, ValidationEventArgs args, string prefix = "")
        {
            object ctl = FindControlByPropertyName(this, null, args);
            if (ctl != null)
            {
                if (args.Type == typeof(RequiredValidator))
                {
                    string fieldCaption = GetControlLabel(ctl);
                    if (args.Pars[0].ToString() != fieldCaption)
                    {
                        Dbg.Debug(
                            "different field captions for field {0}.{1}. Label caption - {2}, resource caption={3}",
                            BusinessObject.ObjectName, args.FieldName, fieldCaption, args.Pars[0].ToString());
                    }
                }
            }
            ErrorForm.ShowWarningFormatWithPrefix(args.MessageId, null, prefix, args.Pars);
            return ctl;
        }

        public virtual void ShowValidationError(object sender, ValidationEventArgs args)
        {
            object ctl = ShowValidationErrorWithoutSetFocus(sender, args);

            if (ctl != null)
            {
                FocusControl(ctl);
            }
        }

        /// <summary>
        /// Returns the name of the field in the format BusnessObjectType.Field Name
        /// /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        protected string GetFieldResourceName(string fieldName)
        {
            string[] s = fieldName.Split('.');
            fieldName = s[s.Length - 1];
            return string.Format("{0}.{1}", BusinessObject.GetType().Name, fieldName);
        }

        protected virtual string GetControlLabel(object o)
        {
            if (o is Control)
            {
                var ctl = o as Control;
                Control p = (ctl).Parent;
                if (p != null)
                {
                    foreach (Control c in p.Controls)
                    {
                        if (((c) is Label || (c) is LabelControl) && (c.Visible || p.Visible == false))
                        {
                            double middle = c.Top + c.Height / 2;
                            if (middle >= ctl.Top && middle <= (ctl.Top + ctl.Height) && c.Left < ctl.Left &&
                                (ctl.Left - c.Left - c.Width) < 100)
                            {
                                return c.Text;
                            }
                        }
                    }
                }
                return (ctl).Name;
            }
            if (o is GridColumn)
            {
                return (o as GridColumn).Caption;
            }
            return "";
        }

        protected void CheckBusinessObjectName(Control ctl, ref string boName)
        {
            var bp = ctl as IBasePanel;
            if (bp==null || bp.BusinessObject == null)
                return;
            if (!m_ChildPanels.Contains(bp))
                m_ChildPanels.Add(bp);
            IObject bo = bp.BusinessObject;
            if (boName == null) boName = "";
            while (bo.Parent != null)
            {
                if (string.IsNullOrEmpty(boName))
                    boName = bo.ObjectName;
                else
                    boName = string.Format("{0}.{1}", bo.ObjectName, boName);
                bo = bo.Parent;
            }
        }

        protected string GetBusinessObjectPath()
        {
            if ((ParentBasePanel == null) || (BusinessObject == null))
            {
                return "";
            }
            string boName = "";
            CheckBusinessObjectName(this, ref boName);
            //IBasePanel panel = ParentBasePanel;
            //IBasePanel parentPanel = GetParentBasePanel((Control)panel);
            //while (parentPanel != null)
            //{
            //    boName = panel.BusinessObject.ObjectName + "." + boName;
            //    panel = parentPanel;
            //    parentPanel = GetParentBasePanel((Control)panel);
            //}
            return boName;
        }

        protected object FindControlByPropertyName(Control ctl, string boName, ValidationEventArgs ve)
        {
            if (ctl == null)
            {
                return null;
            }
            CheckBusinessObjectName(ctl, ref boName);
            if (ctl is GridControl)
            {
                return FindColumnByPropertyName(ctl as GridControl, boName, ve.FieldName);
            }
            string fieldPath = ve.PropertyName == "CurrentDate" ? ve.FieldName : ve.PropertyName;
            string fieldName = GetBoundFieldName(boName, ctl);
            if (fieldName == fieldPath)
            {
                return ctl;
            }
            return (from Control c in ctl.Controls
                    select FindControlByPropertyName(c, boName, ve)).FirstOrDefault(result => result != null);
        }

        protected object FindColumnByPropertyName(GridControl grid, string boName, string fieldName)
        {
            if (grid.FocusedView is GridView)
            {
                GridColumn col = ((GridView)grid.FocusedView).Columns.ColumnByFieldName(fieldName);
                if (col != null)
                {
                    return col;
                }
                if (boName != null)
                {
                    col = ((GridView)grid.FocusedView).Columns.ColumnByFieldName(boName + "." + fieldName);
                }
                return col;
            }
            return null;
        }

        private static void FocusControl(object ctl)
        {
            if (ctl != null)
            {
                if (ctl is Control)
                {
                    BringUpCurrentTab(ctl as Control);
                    (ctl as Control).Select();
                }
                else if (ctl is GridColumn)
                {
                    var view = (ctl as GridColumn).View as GridView;
                    if (view != null)
                    {
                        BringUpCurrentTab(view.GridControl);
                        view.FocusedColumn = ctl as GridColumn;
                        view.ShowEditor();
                    }
                }
                else
                {
                    Dbg.DbgAssert(false, "invalid object is passed for focusing");
                }
            }
        }

        protected static void BringUpCurrentTab(Control ctl)
        {
            Control page = TabPage.GetTabPageOfComponent(ctl);
            //process standard tab control
            if (page != null)
            {
                ((TabControl)page.Parent).SelectedTab = (TabPage)page;
                BringUpCurrentTab(page.Parent.Parent);
                return;
            }
            //XtraTabControl
            page = ctl; //.Parent
            while (page != null)
            {
                var selectedTabPage = page as XtraTabPage;
                if (selectedTabPage != null)
                {
                    (selectedTabPage).TabControl.SelectedTabPage = selectedTabPage;
                    BringUpCurrentTab((selectedTabPage).TabControl.Parent);
                    return;
                }
                page = page.Parent;
            }
        }

        #endregion

        #region Recursive controls visiting
        private List<IBasePanel> m_ChildPanels = new List<IBasePanel>();

        /// <summary>
        /// This method is called only for top level panel
        /// It recursevly scans all panel controls and peforms passed operations to each control
        /// </summary>
        /// <param name="ctl"> Control to be processed</param>
        /// <param name="boName">Business object name related with this control. For Top level business object is empty.
        /// For child objects consits of object relation names separated by point., i.e for current patient address on the human case form
        /// it will be equal Patient.CurrentResidenceAddress
        /// </param>
        /// <param name="functions"> List of functions that should be applied to the control
        /// </param>
        /// <param name="skipIfInitialized"></param>
        public void VisitControls(Control ctl, string boName, VisitControlFunction[] functions, bool skipIfInitialized)
        {
            if (ctl == null || ParentBasePanel != null)
            {
                return;
            }
            var bp = ctl as IBasePanel;
            if (bp != null && skipIfInitialized && bp.IsControlsInitialized)
                return;
            CheckBusinessObjectName(ctl, ref boName);
            foreach (VisitControlFunction visitControlFunction in functions)
            {
                visitControlFunction(boName, ctl);
            }
            //if (ctl is BasePanelPopup)
            //    ((ctl as BasePanelPopup).PopupControl as IBasePanel).VisitControls((ctl as BasePanelPopup).PopupControl as Control, "", functions);
            //else
            foreach (Control c in ctl.Controls)
            {
                VisitControls(c, boName, functions, skipIfInitialized);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public virtual KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>> GetFirstUIFunc(string actionName)
        {
            return new KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>>(null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public virtual KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>> GetSecondUIFunc(string actionName)
        {
            return new KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>>(null, null);
        }

        public virtual void Cleanup()
        {

        }

        protected void VisitOwnControls(Control ctl, string boName, VisitControlFunction[] functions)
        {
            if (ctl != null && (ctl is IBasePanel || ctl is ILayout || ctl is BaseActionPanel))
            {
                return;
            }
            if (ctl == null)
            {
                ctl = this;
                boName = GetBusinessObjectPath();
            }
            foreach (VisitControlFunction visitControlFunction in functions)
            {
                visitControlFunction(boName, ctl);
            }
            foreach (Control c in ctl.Controls)
            {
                VisitOwnControls(c, boName, functions);
            }
        }

        private void ClearBinding()
        {
            VisitControls(this, null, new VisitControlFunction[] { RemoveControlBindings }, false);
        }

        private static Control RemoveControlBindings(string boName, Control ctl)
        {
            if (ctl.DataBindings.Count > 0)
            {
                ctl.DataBindings.Clear();
            }
            return null;
        }

        protected Control SetControlFont(string boName, Control ctl)
        {
            LayoutCorrector.SetControlFont(ctl);
            return ctl;
        }

        protected Control AttachEditValueChangedEvent(string boName, Control ctl)
        {
            //ctl.BeginInvoke(new MethodInvoker(delegate
            //{
            if (ctl is PopupBaseEdit)
            {
                AddEditValueChangedHandler((BaseEdit)ctl);
            }
            //}));
            return ctl;
        }

        protected void AddEditValueChangedHandler(BaseEdit edit)
        {
            try
            {
                edit.EditValueChanged -= BaseEdit_EditValueChanged;
            }
            finally
            {
                edit.EditValueChanged += BaseEdit_EditValueChanged;
            }
        }

        private void BaseEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (LifeTimeState == LifeTimeState.Closed)
                return;
            ((Control)sender).BeginInvoke(new MethodInvoker(delegate
                                                                 {
                                                                     if (((Control)sender).DataBindings.Count > 0)
                                                                     {
                                                                         //Binding binding =
                                                                         //    ((Control)sender).DataBindings[0];
                                                                         //var bo = binding.DataSource as IObject;
                                                                         //if (bo != null && !bo.GetValue(binding.BindingMemberInfo.BindingField).Equals(((BaseEdit)sender).EditValue))
                                                                         //   binding.BindingManagerBase.EndCurrentEdit();
                                                                         UpdateControlsState();
                                                                     }
                                                                 }));
        }

        protected Control CheckMandatoryField(string boName, Control ctl)
        {
            string fieldName = GetBoundFieldName(boName, ctl);
            if (string.IsNullOrEmpty(fieldName))
            {
                return null;
            }
            if (IsRequiredField(fieldName))
            {
                if (ctl is BaseEdit)
                {
                    LayoutCorrector.SetStyleController(ctl as BaseEdit, LayoutCorrector.MandatoryStyleController);
                }
                return ctl;
            }
            return null;
        }

        private Control SetControlStyle(string boName, Control ctl)
        {
            var edit = ctl as BaseEdit;
            if (edit != null)
            {
                string fieldName = GetBoundFieldName(boName, edit);
                SetBaseEditStyle(edit, fieldName);
            }
            return ctl;
        }

        private static string GetBoundFieldName(string boName, Control ctl)
        {
            if (ctl is BasePanelPopup)
            {
                string validationField = (ctl as BasePanelPopup).ValidationFieldName;
                if (string.IsNullOrEmpty(validationField))
                    return null;
                if (string.IsNullOrEmpty(boName))
                    return (ctl as BasePanelPopup).PopupControl.BusinessObject.ObjectName + "." + validationField;
                return boName + "." + (ctl as BasePanelPopup).PopupControl.BusinessObject.ObjectName + "." + validationField;

            }
            if (ctl.DataBindings.Count == 0)
            {
                return null;
            }
            string fieldName = ctl.DataBindings[0].BindingMemberInfo.BindingField;

            if (string.IsNullOrEmpty(boName))
            {
                return fieldName;
            }
            return boName + "." + fieldName;
        }

        private bool IsRequiredField(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return false;
            }
            if (RootPanel.BusinessObject == null)
            {
                return false;
            }
            var accessor = RootPanel.BusinessObject.GetAccessor() as IObjectMeta;
            if (accessor != null)
            {
                return accessor.RequiredByProperty(fieldName, BusinessObject);
            }
            return false;
        }

        protected virtual bool IsReadOnlyField(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return false;
            }
            if (BusinessObject != null)
            {
                return BusinessObject.IsReadOnly(GetUnqualifiedFieldName(fieldName));
            }
            return false;
        }

        private static string GetUnqualifiedFieldName(string fieldName)
        {
            if (!fieldName.Contains("."))
            {
                return fieldName;
            }
            string[] s = fieldName.Split('.');
            return s[s.Length - 1];
        }

        #endregion

        private void BasePanel_Load(object sender, EventArgs e)
        {
            if (!WinUtils.IsComponentInDesignMode(this))
            {
                VisitOwnControls(null, null, new VisitControlFunction[] { AttachEditValueChangedEvent });
            }
        }

        private void BasePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (WinUtils.IsComponentInDesignMode(this) || BaseSettings.ScanFormsMode)
                return;
            if (Visible && !m_ReadonlyStateUpdated)
                DisplayReadOnly(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<object> GetParamsAction(IObject o)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<object> GetParamsAction()
        {
            return GetParamsAction(null);
        }

        public virtual void AfterPost(object senter, EventArgs e)
        {
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object Key
        {
            get
            {
                if (BusinessObject != null)
                {
                    return BusinessObject.Key;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        /// <param name="actionName"></param>
        /// <param name="actionFunction"></param>
        /// <param name="parameters">Параметры для произвольного действия</param>
        protected ActionMetaItem SetActionFunction(List<ActionMetaItem> actions, string actionName, Func<DbManagerProxy, IObject, List<object>, ActResult> actionFunction, List<object> parameters = null, IObject obj = null)
        {
            var action = Find(actions, actionName, obj);
            if (action != null)
            {
                action.AddFirstUIFunc(actionFunction, parameters);
            }
            return action;
        }

        protected ActionMetaItem SetPostActionFunction(List<ActionMetaItem> actions, string actionName, Func<DbManagerProxy, IObject, List<object>, ActResult> actionFunction, List<object> parameters = null, IObject obj = null)
        {
            var action = Find(actions, actionName, obj);
            if (action != null)
            {
                action.AddSecondUIFunc(actionFunction, parameters);
            }
            return action;
        }

        private ActionMetaItem Find(List<ActionMetaItem> actions, string actionName, IObject obj)
        {
            foreach (var action in actions)
            {
                if (action.Name == actionName)
                    return action;
                var ret = Find(action.Children(obj), actionName, obj);
                if (ret != null)
                    return ret;
            }
            return null;
        }

        public bool FindAction(string actionName)
        {
            var layout = GetLayout();
            if (layout != null)
                return layout.Actions.Find(a => a.Name == actionName) != null;
            return false;
        }

        public void PerformAction(string actionName, List<object> parameters = null)
        {
            var layout = GetLayout();
            if (layout != null)
                layout.PerformAction(actionName, parameters);
        }


        /*perm!!
        public virtual void CheckActionPermission(ActionMetaItem action, ref bool showAction)
        {
            return;
        }*/
        protected bool FormCloseButtonClicked()
        {
            var f = FindForm();
            if (f != null)
            {
                var p = Cursor.Position;
                p = f.PointToClient(p);
                f.GetChildAtPoint(p);
                return p.X < f.Width && p.X >= f.Width - 40 && p.Y < 0;
            }
            return false;
        }

    }
}
