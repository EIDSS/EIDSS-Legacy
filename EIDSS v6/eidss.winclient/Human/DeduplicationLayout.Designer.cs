namespace eidss.winclient.Human
{
    partial class DeduplicationLayout
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeduplicationLayout));
            this.lblHCDeduplication = new DevExpress.XtraEditors.LabelControl();
            this.DeduplicationGrid = new DevExpress.XtraGrid.GridControl();
            this.DeduplicationView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnDeduplicate = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveCase = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeduplicationGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeduplicationView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnDeduplicate);
            this.panelTop.Controls.Add(this.btnRemoveCase);
            this.panelTop.Controls.Add(this.DeduplicationGrid);
            this.panelTop.Controls.Add(this.lblHCDeduplication);
            resources.ApplyResources(this.panelTop, "panelTop");
            // 
            // panelMain
            // 
            resources.ApplyResources(this.panelMain, "panelMain");
            // 
            // panelBottom
            // 
            resources.ApplyResources(this.panelBottom, "panelBottom");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(DeduplicationLayout), out resources);
            // Form Is Localizable: True
            // 
            // lblHCDeduplication
            // 
            this.lblHCDeduplication.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblHCDeduplication, "lblHCDeduplication");
            this.lblHCDeduplication.Name = "lblHCDeduplication";
            // 
            // DeduplicationGrid
            // 
            resources.ApplyResources(this.DeduplicationGrid, "DeduplicationGrid");
            this.DeduplicationGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("DeduplicationGrid.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.DeduplicationGrid.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("DeduplicationGrid.EmbeddedNavigator.Anchor")));
            this.DeduplicationGrid.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("DeduplicationGrid.EmbeddedNavigator.BackgroundImageLayout")));
            this.DeduplicationGrid.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("DeduplicationGrid.EmbeddedNavigator.ImeMode")));
            this.DeduplicationGrid.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("DeduplicationGrid.EmbeddedNavigator.TextLocation")));
            this.DeduplicationGrid.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("DeduplicationGrid.EmbeddedNavigator.ToolTipIconType")));
            this.DeduplicationGrid.MainView = this.DeduplicationView;
            this.DeduplicationGrid.Name = "DeduplicationGrid";
            this.DeduplicationGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DeduplicationView});
            // 
            // DeduplicationView
            // 
            this.DeduplicationView.GridControl = this.DeduplicationGrid;
            this.DeduplicationView.Name = "DeduplicationView";
            this.DeduplicationView.OptionsBehavior.Editable = false;
            this.DeduplicationView.OptionsBehavior.ReadOnly = true;
            this.DeduplicationView.OptionsBehavior.SmartVertScrollBar = false;
            this.DeduplicationView.OptionsCustomization.AllowFilter = false;
            this.DeduplicationView.OptionsCustomization.AllowGroup = false;
            this.DeduplicationView.OptionsCustomization.AllowSort = false;
            this.DeduplicationView.OptionsDetail.AllowZoomDetail = false;
            this.DeduplicationView.OptionsDetail.EnableMasterViewMode = false;
            this.DeduplicationView.OptionsDetail.ShowDetailTabs = false;
            this.DeduplicationView.OptionsDetail.SmartDetailExpand = false;
            this.DeduplicationView.OptionsMenu.EnableGroupPanelMenu = false;
            this.DeduplicationView.OptionsView.ShowGroupPanel = false;
            this.DeduplicationView.RowCountChanged += new System.EventHandler(this.DeduplicationView_RowCountChanged);
            // 
            // btnDeduplicate
            // 
            resources.ApplyResources(this.btnDeduplicate, "btnDeduplicate");
            this.btnDeduplicate.Image = global::eidss.winclient.Properties.Resources.Human_Case_De_duplication__small_;
            this.btnDeduplicate.Name = "btnDeduplicate";
            this.btnDeduplicate.Click += new System.EventHandler(this.btnDeduplicate_Click);
            // 
            // btnRemoveCase
            // 
            resources.ApplyResources(this.btnRemoveCase, "btnRemoveCase");
            this.btnRemoveCase.Image = global::eidss.winclient.Properties.Resources.Delete_Remove;
            this.btnRemoveCase.Name = "btnRemoveCase";
            this.btnRemoveCase.Click += new System.EventHandler(this.btnRemoveCase_Click);
            // 
            // DeduplicationLayout
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "DeduplicationLayout";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeduplicationGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeduplicationView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl lblHCDeduplication;
        internal DevExpress.XtraGrid.GridControl DeduplicationGrid;
        internal DevExpress.XtraGrid.Views.Grid.GridView DeduplicationView;
        internal DevExpress.XtraEditors.SimpleButton btnDeduplicate;
        internal DevExpress.XtraEditors.SimpleButton btnRemoveCase;
    }
}
