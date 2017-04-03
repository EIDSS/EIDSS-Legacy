using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using bv.model.Model.Core;
using bv.winclient.ActionPanel;
using bv.winclient.BasePanel;
using bv.common.Enums;
using DevExpress.XtraNavBar;
using bv.winclient.SearchPanel;

namespace bv.winclient.Layout
{
    /// <summary>
    /// Слой с групповой панелью (для вложенных элементов форм)
    /// </summary>
    public partial class LayoutGroup : LayoutEmpty
    {
        public LayoutGroup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessObject"></param>
        public LayoutGroup(IObject businessObject)
        {
            //SearchPanelVisible = true;
            InitializeComponent();
            BusinessObject = businessObject;
            //Init();
        }

        [Browsable(true), DefaultValue(true), Localizable(false)]
        public override bool SearchPanelVisible
        {
            get { return ncSearchPanel.Visible; }
            set
            {
                splitterControl1.Visible = ncSearchPanel.Visible = value;
            }
        }

        [Browsable(true), DefaultValue(true), Localizable(false)]
        public bool SearchPanelExpanded
        {
            get { return ngSearchPanel.Expanded; }
            set
            {
                //if (!value && m_SearchPanel != null)
                //    m_SearchPanel.SetRightAnchor(false);
                ncSearchPanel.OptionsNavPane.NavPaneState = value ? NavPaneState.Expanded : NavPaneState.Collapsed;
                //if (value && m_SearchPanel != null)
                //    m_SearchPanel.SetRightAnchor(true);
            }
        }


        [Browsable(true)]
        public bool TopPanelVisible
        {
            get { return panelTop.Visible; }
            set
            {
                panelTop.Visible = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePanel"></param>
        public override void Init(IBasePanel basePanel)
        {
            base.Init(basePanel);
            var baseListPanel = basePanel as IBaseListPanel;
            if (baseListPanel != null)
            {
                AddSearchPanel((BaseSearchPanel)baseListPanel.SearchPanel);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void AddControlToMainContainer(Control control)
        {
            panelMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private BaseSearchPanel m_SearchPanel;
        private int m_DefaultWidth;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchPanel"></param>
        protected void AddSearchPanel(BaseSearchPanel searchPanel)
        {
            ncSearchPanel.Width = searchPanel.Width;
            nbccSearchPanel.Width = ncSearchPanel.Width;
            ((BaseSearchPanel)searchPanel).SetRightAnchor(false);
            nbccSearchPanel.Controls.Add(searchPanel);
            searchPanel.Dock = DockStyle.Fill;
            ((BaseSearchPanel)searchPanel).SetRightAnchor(true);
            m_SearchPanel = searchPanel;
            m_DefaultWidth = ncSearchPanel.Width;
            splitterControl1.MinSize = m_DefaultWidth;
        }

        private void LayoutHandleCreated(object sender, EventArgs e)
        {
            ncSearchPanel.Invoke(new CollapsePanelDelegate(CollapcsePanel));
        }

        public delegate void  CollapsePanelDelegate();
        private void CollapcsePanel()
        {
            ncSearchPanel.OptionsNavPane.NavPaneState = NavPaneState. Collapsed;
        }

        /// <summary>
        /// 
        /// </summary>
        public GroupActionPanel TopGroupActionPanel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public override void CreateActionPanels()
        {
            TopGroupActionPanel = new GroupActionPanel(BusinessObject, this);
            base.CreateActionPanels();
            AddActionPanel(TopGroupActionPanel, ActionPanelPosition.Top);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionPanelControl"></param>
        /// <param name="position"></param>
        public override void AddActionPanel(Control actionPanelControl, ActionPanelPosition position)
        {
            if (actionPanelControl == null) return;
            base.AddActionPanel(actionPanelControl, position);
            //);
            if (position.Equals(ActionPanelPosition.Top))
            {
                panelTop.Controls.Add(actionPanelControl);
                panelTop.Height = actionPanelControl.Height;
                actionPanelControl.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void AddActions(List<ActionMetaItem> actions)
        {
            base.AddActions(actions);

            TopGroupActionPanel.AddActionsRoutines(actions, ActionsPanelType.Group);
        }

        public override void PerformAction(string actionName, List<object> parameters)
        {
            TopGroupActionPanel.PerformAction(actionName, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="panelType"></param>
        public override void AddCustomControlToActionPanel(Control control, ActionsPanelType panelType)
        {
            if (panelType == ActionsPanelType.Group)
            {
                TopGroupActionPanel.AddCustomControl(control);
            }
        }
        public override void RefreshActionButtons(bool forceReadOnly = false)
        {
            TopGroupActionPanel.RefreshActionButtons(forceReadOnly);
        }

        private void ncSearchPanel_NavPaneStateChanged(object sender, System.EventArgs e)
        {
            splitterControl1.Enabled = ncSearchPanel.OptionsNavPane.NavPaneState == NavPaneState.Expanded;
        }

    }
}
