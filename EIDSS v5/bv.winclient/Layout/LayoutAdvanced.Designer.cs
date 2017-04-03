namespace bv.winclient.Layout
{
    partial class LayoutAdvanced
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutAdvanced));
            this.ngSearchPanel = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbccSearchPanel = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.ncSearchPanel = new DevExpress.XtraNavBar.NavBarControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncSearchPanel)).BeginInit();
            this.ncSearchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            resources.ApplyResources(this.panelMain, "panelMain");
            // 
            // panelBottom
            // 
            resources.ApplyResources(this.panelBottom, "panelBottom");
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
            // panelTop
            // 
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
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
            this.ncSearchPanel.StoreDefaultPaintStyleName = true;
            this.ncSearchPanel.NavPaneStateChanged += new System.EventHandler(this.ncSearchPanel_NavPaneStateChanged);
            // 
            // splitterControl1
            // 
            resources.ApplyResources(this.splitterControl1, "splitterControl1");
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.TabStop = false;
            // 
            // LayoutAdvanced
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.ncSearchPanel);
            this.Controls.Add(this.panelTop);
            this.Name = "LayoutAdvanced";
            this.SizeChanged += new System.EventHandler(this.LayoutAdvanced_SizeChanged);
            this.Controls.SetChildIndex(this.panelTop, 0);
            this.Controls.SetChildIndex(this.panelBottom, 0);
            this.Controls.SetChildIndex(this.ncSearchPanel, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncSearchPanel)).EndInit();
            this.ncSearchPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraNavBar.NavBarControl ncSearchPanel;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbccSearchPanel;
        private DevExpress.XtraNavBar.NavBarGroup ngSearchPanel;
    }
}
