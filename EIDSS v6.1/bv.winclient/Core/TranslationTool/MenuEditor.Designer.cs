namespace bv.winclient.Core.TranslationTool
{
    partial class MenuEditor
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
            this.menuEditoGrid = new DevExpress.XtraVerticalGrid.VGridControl();
            this.commandPanel = new DevExpress.XtraEditors.PanelControl();
            this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.menuEditoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandPanel)).BeginInit();
            this.commandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuEditoGrid
            // 
            this.menuEditoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuEditoGrid.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.menuEditoGrid.Location = new System.Drawing.Point(0, 0);
            this.menuEditoGrid.Name = "menuEditoGrid";
            this.menuEditoGrid.OptionsView.AutoScaleBands = true;
            this.menuEditoGrid.OptionsView.ShowButtons = false;
            this.menuEditoGrid.Size = new System.Drawing.Size(397, 327);
            this.menuEditoGrid.TabIndex = 0;
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.cmdOk);
            this.commandPanel.Controls.Add(this.cmdCancel);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandPanel.Location = new System.Drawing.Point(0, 327);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(397, 34);
            this.commandPanel.TabIndex = 1;
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Location = new System.Drawing.Point(236, 5);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 1;
            this.cmdOk.Text = "Ok";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(317, 5);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 22);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            // 
            // MenuEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 361);
            this.Controls.Add(this.menuEditoGrid);
            this.Controls.Add(this.commandPanel);
            this.Name = "MenuEditor";
            this.Text = "Menu Editor";
            ((System.ComponentModel.ISupportInitialize)(this.menuEditoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandPanel)).EndInit();
            this.commandPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl menuEditoGrid;
        private DevExpress.XtraEditors.PanelControl commandPanel;
        private DevExpress.XtraEditors.SimpleButton cmdOk;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
    }
}