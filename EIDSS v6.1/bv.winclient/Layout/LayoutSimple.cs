using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.common.Resources.TranslationTool;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Core.TranslationTool;

namespace bv.winclient.Layout
{
    public partial class LayoutSimple : LayoutEmpty
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessObject"></param>
        public LayoutSimple(IObject businessObject)
        {
            InitializeComponent();
            BusinessObject = businessObject;
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        public LayoutSimple()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            FormIcon.Properties.ShowMenu = false;
            FormIcon.Properties.AllowFocused = false;
            RtlHelper.SetRTL(FormIcon);
            RtlHelper.SetRTL(FormIDLabel);
            RtlHelper.SetRTL(CaptionLabel);
        }
        private ValidationErrorPanel m_ValidationErrorPanel;
        public override void DisplayValidationError()
        {
            if (BusinessObject == null)
                return;
            if (BusinessObject.IsValidObject)
            {
                if (m_ValidationErrorPanel != null)
                    m_ValidationErrorPanel.Visible = false;
                return;
            }
            if (m_ValidationErrorPanel == null)
                m_ValidationErrorPanel = ValidationErrorPanel.Show(panelCaption);
            else
                m_ValidationErrorPanel.Visible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void AddControlToMainContainer(Control control)
        {
            //panelMain.AutoSize = true;
            //AutoSize = true;
            ClientSize = new Size(control.Width + (Width - panelMain.Width) + panelMain.Margin.Left + panelMain.Margin.Right, control.Height + (Height - panelMain.Height) + panelMain.Margin.Top + panelMain.Margin.Bottom);
            //panelMain.Size = new Size(control.Width, control.Height);
            panelMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        public void SetPicture(Image image)
        {
            FormIcon.Image = image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public void SetCaption(string caption)
        {
            CaptionLabel.Text = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formID"></param>
        public void SetFormID(string formID)
        {
            FormIDLabel.Text = formID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionPanel"></param>
        /// <param name="position"></param>
        public override void AddActionPanel(Control actionPanel, ActionPanelPosition position)
        {
            if (actionPanel == null) return;

            base.AddActionPanel(actionPanel, position);

            //в базовом классе только нижняя панель
            if (position.Equals(ActionPanelPosition.Bottom))
            {
                panelBottom.SuspendLayout();
                panelBottom.Controls.Add(actionPanel);
                panelBottom.Height = actionPanel.Height;
                actionPanel.Dock = DockStyle.Fill;
                panelBottom.ResumeLayout();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected ActionPanel.ActionPanel MainActionPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void CreateActionPanels()
        {
            MainActionPanel = new ActionPanel.ActionPanel(BusinessObject, this);

            base.CreateActionPanels();

            AddActionPanel(MainActionPanel, ActionPanelPosition.Bottom);
        }

        /// <summary>
        /// Добавляет действия на Layout
        /// </summary>
        /// <param name="actions"></param>
        public override void AddActions(List<ActionMetaItem> actions)
        {
            base.AddActions(actions);

            //добавляем только те действия, которые можно разместить на панелях, принаддежащих данному Layout
            //действия, для которых нет панели, игнорируем

            //на простом Layout есть только Main-панель
            MainActionPanel.AddActionsRoutines(actions, ActionsPanelType.Main);
            if(BaseSettings.TranslationMode)
                MainActionPanel.AddCustomControl(new TranslationButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="parameters"></param>
        public override void PerformAction(string actionName, List<object> parameters)
        {
            MainActionPanel.PerformAction(actionName, parameters);
        }
        public override void RefreshActionButtons(bool forceReadOnly = false)
        {
            MainActionPanel.RefreshActionButtons(forceReadOnly);

        }
        public override bool ShowCaption
        {
            get { return panelCaption.Visible; }
            set { panelCaption.Visible = value; }
        }
        public bool ShowBottomPanel
        {
            get { return panelBottom.Visible; }
            set { panelBottom.Visible = value; }
        }

        #region ITranslationView

        public override void ApplyResources(string cultureCode)
        {
            base.ApplyResources(cultureCode);
            var resValues = TranslationToolHelper.ReadResxFile(ParentBasePanel.GetType().Name, cultureCode,
                                                                        null, null);
            if(resValues.ContainsKey("$this.Caption"))
            {
                CaptionLabel.Text = resValues["$this.Caption"].Value.ToString();
                if (!EditableControlsList.ContainsKey("$this.Caption"))
                    EditableControlsList.Add("$this.Caption", this);
            }
        }
        public override bool SaveChanges(Dictionary<object, DesignElement> changes, string cultureCode)
        {
            try
            {
                var captionChange = changes.First(c => c.Key == this.CaptionLabel);
                if(!captionChange.Equals(null))
                {
                    ParentBasePanel.Caption = CaptionLabel.Text;
                    var tmpChanges = new Dictionary<object, DesignElement> {{ParentBasePanel, DesignElement.Caption}};
                    TranslationToolHelperWinClient.SaveViewChanges(ParentBasePanel as ITranslationView, tmpChanges, cultureCode);
                    changes.Remove(captionChange.Key);
                }

                ((ITranslationView)panelMain.Controls[0]).SaveChanges(changes, cultureCode);
                ((ITranslationView)panelBottom.Controls[0]).SaveChanges(changes, cultureCode);
                return true;
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during translation saving", ex);
                return false;
            }
        }
        public override DesignElement GetDesignTypeForComponent(Component component)
        {
            if (component == CaptionLabel)
                return DesignElement.Caption;
            if(component is Control && ((Control)component).Parent == panelCaption)
            {
                return DesignElement.None;
            }
            return base.GetDesignTypeForComponent(component);
        }

        #endregion

    }
}
