namespace bv.winclient.Core.TranslationTool
{
    partial class FormTranslationsEditor
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
            this.translationsEditGrid = new DevExpress.XtraVerticalGrid.VGridControl();
            this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.commandPanel = new DevExpress.XtraEditors.PanelControl();
            this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.translationsEditGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandPanel)).BeginInit();
            this.commandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // translationsEditGrid
            // 
            this.translationsEditGrid.Appearance.RecordValue.Options.UseTextOptions = true;
            this.translationsEditGrid.Appearance.RecordValue.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.translationsEditGrid.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.translationsEditGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translationsEditGrid.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.translationsEditGrid.Location = new System.Drawing.Point(0, 0);
            this.translationsEditGrid.Name = "translationsEditGrid";
            this.translationsEditGrid.OptionsView.AutoScaleBands = true;
            this.translationsEditGrid.OptionsView.ShowButtons = false;
            this.translationsEditGrid.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.row});
            this.translationsEditGrid.Size = new System.Drawing.Size(397, 631);
            this.translationsEditGrid.TabIndex = 2;
            // 
            // row
            // 
            this.row.Height = 18;
            this.row.Name = "row";
            this.row.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.cmdOk);
            this.commandPanel.Controls.Add(this.cmdCancel);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandPanel.Location = new System.Drawing.Point(0, 631);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(397, 34);
            this.commandPanel.TabIndex = 3;
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
            // FormTranslationsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 665);
            this.Controls.Add(this.translationsEditGrid);
            this.Controls.Add(this.commandPanel);
            this.Name = "FormTranslationsEditor";
            this.Text = "Translations Editor";
            ((System.ComponentModel.ISupportInitialize)(this.translationsEditGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandPanel)).EndInit();
            this.commandPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl translationsEditGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;

        private DevExpress.XtraEditors.PanelControl commandPanel;
        private DevExpress.XtraEditors.SimpleButton cmdOk;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row;


    }
}