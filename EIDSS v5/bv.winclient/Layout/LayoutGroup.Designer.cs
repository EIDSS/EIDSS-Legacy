namespace bv.winclient.Layout
{
    partial class LayoutGroup
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutGroup));
            this.ncSearchPanel = new DevExpress.XtraNavBar.NavBarControl();
            this.ngSearchPanel = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbccSearchPanel = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ncSearchPanel)).BeginInit();
            this.ncSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.SuspendLayout();
            // 
            // ncSearchPanel
            // 
            this.ncSearchPanel.ActiveGroup = this.ngSearchPanel;
            this.ncSearchPanel.Controls.Add(this.nbccSearchPanel);
            resources.ApplyResources(this.ncSearchPanel, "ncSearchPanel");
            this.ncSearchPanel.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.ngSearchPanel});
            this.ncSearchPanel.Name = "ncSearchPanel";
            this.ncSearchPanel.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.ncSearchPanel.OptionsNavPane.ShowOverflowButton = false;
            this.ncSearchPanel.OptionsNavPane.ShowOverflowPanel = false;
            this.ncSearchPanel.OptionsNavPane.ShowSplitter = false;
            this.ncSearchPanel.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.ncSearchPanel.NavPaneStateChanged += new System.EventHandler(this.ncSearchPanel_NavPaneStateChanged);
            // 
            // ngSearchPanel
            // 
            resources.ApplyResources(this.ngSearchPanel, "ngSearchPanel");
            this.ngSearchPanel.ControlContainer = this.nbccSearchPanel;
            this.ngSearchPanel.Expanded = true;
            this.ngSearchPanel.GroupClientHeight = 80;
            this.ngSearchPanel.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.ngSearchPanel.Name = "ngSearchPanel";
            this.ngSearchPanel.NavigationPaneVisible = false;
            // 
            // nbccSearchPanel
            // 
            this.nbccSearchPanel.Name = "nbccSearchPanel";
            resources.ApplyResources(this.nbccSearchPanel, "nbccSearchPanel");
            // 
            // panelMain
            // 
            resources.ApplyResources(this.panelMain, "panelMain");
            this.panelMain.Name = "panelMain";
            // 
            // splitterControl1
            // 
            resources.ApplyResources(this.splitterControl1, "splitterControl1");
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.TabStop = false;
            // 
            // panelTop
            // 
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // LayoutGroup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.ncSearchPanel);
            this.Name = "LayoutGroup";
            ((System.ComponentModel.ISupportInitialize)(this.ncSearchPanel)).EndInit();
            this.ncSearchPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl ncSearchPanel;
        private DevExpress.XtraNavBar.NavBarGroup ngSearchPanel;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbccSearchPanel;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelTop;
    }
}
