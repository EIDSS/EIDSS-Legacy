using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;

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
            //Init();
        }

        /// <summary>
        /// 
        /// </summary>
        public LayoutSimple()
        {
            InitializeComponent();
            FormIcon.Properties.ShowMenu = false;
            FormIcon.Properties.AllowFocused = false;

            //Init();
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
                panelBottom.Controls.Add(actionPanel);
                panelBottom.Height = actionPanel.Height;
                actionPanel.Dock = DockStyle.Fill;
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
    }
}
