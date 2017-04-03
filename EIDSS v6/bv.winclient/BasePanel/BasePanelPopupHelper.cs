using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;

namespace bv.winclient.BasePanel
{
    public class BasePanelPopupHelper
    {
        private PopupContainerControl m_PopupContainer;
        private XtraPanel m_ActionPanel;
        private SimpleButton m_OkButton;
        private SimpleButton m_CancelButton;
        private PopupContainerEdit m_popupEdit;
        private RepositoryItemPopupContainerEdit m_repositoryPopupEdit;
        private BasePanelRepositoryPopup.GetBusinessObjectHandler m_GetObjectHandler;
        private GridColumn m_Column;
        public void Init()
        {
            m_PopupContainer = new PopupContainerControl();
            m_ActionPanel = new XtraPanel();
            m_PopupContainer.Padding = new Padding(4, 0, 4, 0);
            m_ActionPanel.Height = 31;
            m_ActionPanel.Parent = m_PopupContainer;
            m_ActionPanel.Dock = DockStyle.Bottom;
            AddButton(m_CancelButton = new SimpleButton(), BvMessages.Get("strCancel_Id"));
            AddButton(m_OkButton = new SimpleButton(), BvMessages.Get("strOK_Id"), m_CancelButton);
            m_OkButton.Click += OkClick;
            m_CancelButton.Click += CancelClick;

        }
        public BasePanelPopupHelper(PopupContainerEdit popupEdit)
        {
            Init();
            m_popupEdit = popupEdit;
            popupEdit.Properties.PropertiesChanged += Popup_Property_Changed;
            popupEdit.Properties.CloseOnOuterMouseClick = false;
            //Properties.CloseOnLostFocus = False
            popupEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            popupEdit.Properties.ReadOnly = true;
            popupEdit.Properties.ShowPopupCloseButton = false;
            popupEdit.Properties.AutoHeight = false;
            popupEdit.QueryPopUp += OnQueryPopUp;
            popupEdit.QueryCloseUp += OnQueryCloseUp;
            popupEdit.CloseUp += OnCloseUp;
            popupEdit.QueryDisplayText += OnQueryDisplayText;
        }
        public BasePanelPopupHelper(RepositoryItemPopupContainerEdit popupEdit, GridColumn col, BasePanelRepositoryPopup.GetBusinessObjectHandler getObjectHandler)
        {
            Init();
            m_Column = col;
            m_GetObjectHandler = getObjectHandler;
            m_repositoryPopupEdit = popupEdit;
            popupEdit.PropertiesChanged += Popup_Property_Changed;
            popupEdit.CloseOnOuterMouseClick = false;
            popupEdit.PopupSizeable = false;
            //Properties.CloseOnLostFocus = False
            popupEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
            popupEdit.ReadOnly = true;
            popupEdit.ShowPopupCloseButton = false;
            popupEdit.AutoHeight = false;
            popupEdit.QueryPopUp += OnQueryPopUp;
            popupEdit.QueryCloseUp += OnQueryCloseUp;
            popupEdit.CloseUp += OnCloseUp;
            popupEdit.QueryDisplayText += OnQueryDisplayText;
        }

        private void Popup_Property_Changed(object sender, EventArgs e)
        {

        }

        private void CancelClick(object sender, EventArgs e)
        {
            if (PopupEdit == null)
                return;
            m_SuppressValidation = true;
            CancelChanges();
            PopupEdit.CancelPopup();
        }

        private void OkClick(object sender, EventArgs e)
        {
            if (PopupEdit == null)
                return;
            if (PopupEdit.IsPopupOpen)
            {
                m_SuppressValidation = false;
                PopupEdit.ClosePopup();
                if (m_repositoryPopupEdit != null && m_Column != null)
                {
                    invalidateColumnAsync(m_Column);
                }
            }
        }

        private void InvalidateColumn(GridColumn col)
        {

            col.View.HideEditor();
            if (col.View.Columns.Count == 1)
                return;
            col.View.FocusedColumn = col.VisibleIndex > 0
                                         ? col.View.Columns[col.VisibleIndex - 1]
                                         : col.View.Columns[col.VisibleIndex + 1];
            col.View.FocusedColumn = col;

        }
        private void invalidateColumnAsync(GridColumn col)
        {
            var form = col.View.GridControl.FindForm();
            if (form != null)
                form.BeginInvoke(new MethodInvoker(() => InvalidateColumn(col)));
        }

        private void AddButton(SimpleButton button, string caption, SimpleButton previousButton = null)
        {
            button.Text = caption;
            LayoutCorrector.ApplySystemFont(button);
            SetControlWidth(button);
            button.Parent = m_ActionPanel;
            int right = previousButton == null ? m_ActionPanel.ClientSize.Width + 4 : previousButton.Left;
            button.Location = new Point(right - 4 - button.Width, 4);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        private static void SetControlWidth(SimpleButton button)
        {
            var g = button.CreateGraphics();
            var buttonWidth = (int)g.MeasureString(button.Text, button.Font).Width + 8;
            button.Size = new Size(buttonWidth >= 75 ? buttonWidth : 75, 23);
        }

        private IPopupControl m_PopupControl;
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPopupControl PopupControl
        {
            get { return m_PopupControl; }
            set
            {
                m_PopupControl = value;
                if (value != null)
                {
                    var ctl = (Control)value;
                    int height = ctl.Height + m_ActionPanel.Height +20;
                    int width = ctl.Width + 8;
                    if (m_popupEdit != null)
                    {
                        m_popupEdit.Properties.PopupFormSize = new Size(width, height);
                        m_popupEdit.Properties.PopupFormMinSize = new Size(width, height);
                        m_popupEdit.Properties.PopupControl = m_PopupContainer;
                        m_popupEdit.Visible = true;
                        m_popupEdit.TabStop = true;
                    }
                    else if (m_repositoryPopupEdit != null)
                    {

                        m_repositoryPopupEdit.PopupFormSize = new Size(width, height);
                        m_repositoryPopupEdit.PopupFormMinSize = new Size(width, height);
                        m_repositoryPopupEdit.PopupControl = m_PopupContainer;
                    }
                    m_PopupContainer.Size = new Size(width, height);
                    ctl.Parent = m_PopupContainer;
                    ctl.Location = new Point(4, 0);
                    ctl.SendToBack();
                    ctl.BringToFront();
                    ctl.Height += 16;
                    m_PopupControl.PopupEdit = this;
                    ((Control)m_PopupControl).BringToFront();
                }
            }
        }
        private void AssignKeyDownEvent(Control parent)
        {
            parent.KeyDown += Control_KeyDown;
            foreach (Control ctl in parent.Controls)
            {
                AssignKeyDownEvent(ctl);
            }
        }
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            var popupEdit = sender as PopupContainerEdit;
            if (popupEdit == null)
                return;
            if (e.KeyCode == Keys.Enter)
            {
                if (popupEdit.IsPopupOpen)
                {
                    popupEdit.ClosePopup();
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Escape)
                {
                    m_SuppressValidation = true;
                    popupEdit.CancelPopup();
                    e.Handled = true;
                }
            }
        }
        private void OnQueryPopUp(object sender, CancelEventArgs e)
        {
            //We should accept changes during popup if popup is opened manually
            //If popup is restored after temporary hiding we should skip this step
            if (m_GetObjectHandler != null)
            {
                PopupControl.BusinessObject = m_GetObjectHandler();
                if (PopupControl.BusinessObject == null && PopupEdit!=null)
                {
                    PopupEdit.IsModified = true;
                    PopupControl.BusinessObject = m_GetObjectHandler();
                }
            }
            if (!IsPopupTemporaryHidden)
                FixObjectChanges();
            m_SuppressValidation = true;
        }

        private bool m_HasChangesBeforePopup;
        private void FixObjectChanges()
        {
            if (PopupControl != null && PopupControl.BusinessObject != null)
            {
                m_HasChangesBeforePopup = PopupControl.BusinessObject.HasChanges;
                PopupControl.BusinessObject.DeepAcceptChanges();
            }
        }
        //This property should be set to true if any modal child window is opened from popup form
        //and returned back to false after this window closing and restoring popup
        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPopupTemporaryHidden { get; set; }

        private void OnQueryCloseUp(object sender, CancelEventArgs e)
        {
            if (IsPopupTemporaryHidden)
            {
                m_SuppressValidation = true;
            }
            if (ValidateData() == false)
            {
                e.Cancel = true;
            }
            m_SuppressValidation = true;
        }

        private void OnCloseUp(object sender, CloseUpEventArgs e)
        {
            //try
            //{
            //    Flash();
            //}
            //finally
            //{
            //    m_Flashed = false;
            //}
            if (IsPopupTemporaryHidden)
            {
                return;
            }
            if (m_HasChangesBeforePopup)
                PopupControl.BusinessObject.SetChange();
            if (e.CloseMode == PopupCloseMode.Cancel || e.CloseMode == PopupCloseMode.Immediate)
            {
                CancelChanges();
            }
            else
            {
                if (m_CloseUpEvent != null)
                    m_CloseUpEvent(sender, e);
                //SetLink();
            }
        }

        private void CancelChanges()
        {
            if (PopupControl != null && PopupControl.BusinessObject != null)
            {
                //m_HasChangesBeforePopup = PopupControl.BusinessObject.HasChanges;
                PopupControl.BusinessObject.RejectChanges();
                (m_PopupControl as IBasePanel).DefineBinding();
            }

        }

        bool m_SuppressValidation;
        public bool ValidateData()
        {
            if (m_SuppressValidation)
                return true;
            //TODO: force validation
            var acc = PopupControl.BusinessObject.GetAccessor();
            var objectValidate = acc as IObjectValidator;
            var success = true;
            if (objectValidate != null)
            {
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    success = objectValidate.Validate(manager, PopupControl.BusinessObject, true, true, true);
                }
            }

            return success;

            //return m_BusinessObjectCopy.Validate();
        }

        private CloseUpEventHandler m_CloseUpEvent;
        public event CloseUpEventHandler OnClose
        {
            add
            {
                m_CloseUpEvent = (CloseUpEventHandler)Delegate.Combine(m_CloseUpEvent, value);
            }
            remove
            {
                m_CloseUpEvent = (CloseUpEventHandler)Delegate.Remove(m_CloseUpEvent, value);
            }
        }
        private string m_DisplayTextInternal = "";
        private void OnQueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            //if (Closing)
            //{
            //    return;
            //}
            if (WinUtils.IsComponentInDesignMode(sender as Component) || m_repositoryPopupEdit !=null || PopupControl == null)
                return;
            e.DisplayText = PopupControl.GetDisplayText();
            var popupEdit = sender as PopupContainerEdit;
            if (m_DisplayTextInternal != e.DisplayText)
            {
                m_DisplayTextInternal = e.DisplayText;
                if(popupEdit!=null)
                    popupEdit.ToolTip = e.DisplayText;
                //if (OnDisplayTextChangedEvent != null)
                //    OnDisplayTextChangedEvent(this, EventArgs.Empty);
            }
            if (popupEdit != null)
                popupEdit.Text = e.DisplayText;
        }
        public void HidePopup()
        {
            if (PopupEdit == null)
                return;
            if (PopupEdit.IsPopupOpen)
            {
                m_SuppressValidation = true;
                PopupEdit.ClosePopup();
            }

        }

        private Form FindForm()
        {
            if (m_popupEdit != null)
                return m_popupEdit.FindForm();
            if (m_Column != null)
                return m_Column.View.GridControl.FindForm();
            return null;
        }
        public void RestorePopup()
        {
            var form = FindForm();
            if(form!=null)
                form.BeginInvoke(new MethodInvoker(delegate
                {
                    var edit = PopupEdit;
                    if (edit == null)
                        return;
                    edit.ShowPopup();
                }));

        }

        public PopupBaseEdit PopupEdit
        {
            get
            {
                var popupEdit = m_popupEdit as PopupBaseEdit;
                if (popupEdit == null && m_repositoryPopupEdit != null && m_repositoryPopupEdit.PopupControl!=null)
                    popupEdit = m_repositoryPopupEdit.PopupControl.OwnerEdit;
                if (popupEdit == null && m_Column != null)
                {
                    m_Column.View.FocusedColumn = m_Column;
                    m_Column.View.ShowEditor();
                    popupEdit = m_Column.View.ActiveEditor as PopupContainerEdit;
                }
                return popupEdit;
            }
        }


    }
}
