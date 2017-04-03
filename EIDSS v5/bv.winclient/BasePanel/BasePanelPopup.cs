using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using bv.common.Core;
using bv.common.Resources;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using bv.model.BLToolkit;

namespace bv.winclient.BasePanel
{
    public class BasePanelPopup : PopupContainerEdit
    {
        private readonly PopupContainerControl m_PopupContainer;
        private readonly XtraPanel m_ActionPanel;
        private readonly SimpleButton m_OkButton;
        private readonly SimpleButton m_CancelButton;
        public BasePanelPopup()
        {
            m_PopupContainer = new PopupContainerControl();
            m_ActionPanel = new XtraPanel();
            m_PopupContainer.Padding = new Padding(4, 0, 4, 0);
            Properties.CloseOnOuterMouseClick = false;
            //Properties.CloseOnLostFocus = False
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.ReadOnly = true;
            Properties.ShowPopupCloseButton = false;
            Properties.AutoHeight = false;         
            QueryPopUp += OnQueryPopUp;
            QueryCloseUp += OnQueryCloseUp;
            CloseUp += OnCloseUp;
            QueryDisplayText += OnQueryDisplayText;
            m_ActionPanel.Height = 31;
            m_ActionPanel.Parent = m_PopupContainer;
            m_ActionPanel.Dock = DockStyle.Bottom;
            AddButton(m_CancelButton = new SimpleButton(), BvMessages.Get("strCancel_Id"));
            AddButton(m_OkButton = new SimpleButton(), BvMessages.Get("strOK_Id"), m_CancelButton);
            m_OkButton.Click += OkClick;
            m_CancelButton.Click += CancelClick;
            Properties.PropertiesChanged+=Popup_Property_Changed;


        }
        private void Popup_Property_Changed(object sender, EventArgs e)
        {

        }
 
        private void CancelClick(object sender, EventArgs e)
        {
            m_SuppressValidation = true;
            CancelChanges();
            CancelPopup();
        }

        private void OkClick(object sender, EventArgs e)
        {
            if (IsPopupOpen)
            {
                m_SuppressValidation = false;
                ClosePopup();
            }
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

                    Properties.PopupFormSize = new Size(ctl.Width + 8, ctl.Height + m_ActionPanel.Height + 20);
                    Properties.PopupFormMinSize = new Size(ctl.Width + 8, ctl.Height + m_ActionPanel.Height + 20);
                    //Properties.UsePopupControlMinSize = true;
                    m_PopupContainer.Size = new Size(ctl.Width + 8, ctl.Height + m_ActionPanel.Height + 20);
                    Properties.PopupControl = m_PopupContainer;
                    //Properties.PopupFormWidth = m_PopupContainer.Width;
                    //Properties.PopupSizeable = true;
                    ctl.Parent = m_PopupContainer;
                    ctl.Location = new Point(4, 0);
                    //ctl.Dock = DockStyle.Fill;
                    ctl.SendToBack();
                    ctl.BringToFront();
                    ctl.Height += 16;
                    //m_PopupContainer.BringToFront();
                    //m_PopupContainer.BackColor = Color.Bisque;
                    Visible = true;
                    TabStop = true;
                    m_PopupControl.PopupEdit = this;
                    ((Control) m_PopupControl).BringToFront();
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
            if (e.KeyCode == Keys.Enter)
            {
                if (IsPopupOpen)
                {
                    ClosePopup();
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Escape)
                {
                    m_SuppressValidation = true;
                    CancelPopup();
                    e.Handled = true;
                }
            }
        }
        private void OnQueryPopUp(object sender, CancelEventArgs e)
        {
            //We should accept changes during popup if popup is opened manually
            //If popup is restored after temporary hiding we should skip this step
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
            if (WinUtils.IsComponentInDesignMode(this) || PopupControl == null)
                return;
            e.DisplayText = PopupControl.GetDisplayText();
            if (m_DisplayTextInternal != e.DisplayText)
            {
                ToolTip = e.DisplayText;
                //if (OnDisplayTextChangedEvent != null)
                //    OnDisplayTextChangedEvent(this, EventArgs.Empty);
                m_DisplayTextInternal = e.DisplayText;
            }
            Text = e.DisplayText;
        }
        public void HidePopup()
        {
            if (IsPopupOpen)
            {
                m_SuppressValidation = true;
                ClosePopup();
            }

        }
        public void RestorePopup()
        {
            ShowPopup();
        }

        [Browsable(false), Localizable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ValidationFieldName { get; set; }



    }
}
