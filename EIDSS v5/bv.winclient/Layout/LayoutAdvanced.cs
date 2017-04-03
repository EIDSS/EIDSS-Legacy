using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using DevExpress.XtraNavBar;
using System.ComponentModel;
using bv.winclient.SearchPanel;

namespace bv.winclient.Layout
{
    public partial class LayoutAdvanced : LayoutSimple
    {

        private int m_LayoutAdvancedSize;
        /// <summary>
        /// 
        /// </summary>
        public LayoutAdvanced()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="businessObject"></param>
        public LayoutAdvanced(IObject businessObject)
            : base(businessObject)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        protected ActionPanel.ActionPanel TopActionPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePanel"></param>
        public override void Init(IBasePanel basePanel)
        {
            base.Init(basePanel);
            //TODO добавить Search Panel
            var baseListPanel = basePanel as IBaseListPanel;
            if (baseListPanel != null)
            {
                AddSearchPanel((Control)baseListPanel.SearchPanel);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CreateActionPanels()
        {
            TopActionPanel = new ActionPanel.ActionPanel(BusinessObject, this);
            base.CreateActionPanels();
            AddActionPanel(TopActionPanel, ActionPanelPosition.Top);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionPanelControl"></param>
        /// <param name="position"></param>
        public override void AddActionPanel(Control actionPanelControl, ActionPanelPosition position)
        {
            base.AddActionPanel(actionPanelControl, position);

            if (actionPanelControl == null) return;

            //в базовом классе только нижняя панель
            if (position.Equals(ActionPanelPosition.Top))
            {
                panelTop.Controls.Add(actionPanelControl);
                panelTop.Height = actionPanelControl.Height;
                actionPanelControl.Dock = DockStyle.Fill;
            }
        }

        private int m_DefaultWidth;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchPanel"></param>
        protected void AddSearchPanel(Control searchPanel)
        {
            ncSearchPanel.Width = searchPanel.Width;
            //nbccSearchPanel.Dock = DockStyle.Fill;
            nbccSearchPanel.Width = ncSearchPanel.Width;
            ((BaseSearchPanel)searchPanel).SetRightAnchor(false);
            nbccSearchPanel.Controls.Add(searchPanel);
            searchPanel.Dock = DockStyle.Fill;
            ((BaseSearchPanel)searchPanel).SetRightAnchor(true);

            m_DefaultWidth = ncSearchPanel.Width;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void AddActions(List<ActionMetaItem> actions)
        {
            base.AddActions(actions);

            TopActionPanel.AddActionsRoutines(actions, ActionsPanelType.Top);
            
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {

                if(ncSearchPanel.OptionsNavPane.NavPaneState == NavPaneState.Expanded) {
                                
                    ncSearchPanel.OptionsNavPane.NavPaneState = NavPaneState.Collapsed;
                    return true;
                }
                if(ncSearchPanel.OptionsNavPane.NavPaneState == NavPaneState.Collapsed) {
                                
                    ncSearchPanel.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
                    return true;
                }
           
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private int m_storedSplitPosition = 0;
        private void LayoutAdvanced_SizeChanged(object sender, EventArgs e)
        {

            if (m_LayoutAdvancedSize != 0)
            {
                //decimal d = (decimal)this.Size.Width / (decimal)m_LayoutAdvancedSize;

                //if (this.Size.Width < m_LayoutAdvancedSize)
                //    splitterControl1.MinSize = (int)(ncSearchPanel.Width * d);
                //// splitterControl1.MinExtra = (int)(ncSearchPanel.Size.Width * d * 2);
                if (ncSearchPanel.OptionsNavPane.NavPaneState == NavPaneState.Expanded)
                {
                    if(IsMinimized())
                    {
                        m_storedSplitPosition = ncSearchPanel.Width;
                    }
                    else
                    {
                        if (splitterControl1.MinSize < ncSearchPanel.Width)
                        {
                            splitterControl1.MinSize = m_DefaultWidth; //422
                            splitterControl1.SplitPosition = m_storedSplitPosition;
                        }
                       
                    }
                }
            }

            m_LayoutAdvancedSize = Width;

        }

        private bool IsMinimized()
        {
            var frm = FindForm();

            return frm !=null && frm.WindowState == FormWindowState.Minimized;
        }
        public override void PerformAction(string actionName, List<object> parameters)
        {
            if (TopActionPanel.PerformAction(actionName, parameters))
                return;
            MainActionPanel.PerformAction(actionName, parameters);
        }

        public override void RefreshActionButtons(bool forceReadOnly = false)
        {
            TopActionPanel.RefreshActionButtons(forceReadOnly);
            MainActionPanel.RefreshActionButtons(forceReadOnly);
        }
        
        private void ncSearchPanel_NavPaneStateChanged(object sender, EventArgs e)
        {
            splitterControl1.Enabled = ncSearchPanel.OptionsNavPane.NavPaneState == NavPaneState.Expanded;
        }

        private bool m_SearchPanelVisible = true;
        [Browsable(true), DefaultValue (true), Localizable (false)]
        public override  bool SearchPanelVisible
        {
            get { return m_SearchPanelVisible; }
            set
            {
                splitterControl1.Visible = ncSearchPanel.Visible = m_SearchPanelVisible = value;
            }
        }


    }
}
