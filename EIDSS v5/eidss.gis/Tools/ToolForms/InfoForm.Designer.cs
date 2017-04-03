namespace eidss.gis.Tools.ToolForms
{
    partial class InfoForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.featureGrid = new DevExpress.XtraVerticalGrid.VGridControl();
            this.persistentRepos = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.featureGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // featureGrid
            // 
            this.featureGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featureGrid.ExternalRepository = this.persistentRepos;
            this.featureGrid.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.featureGrid.Location = new System.Drawing.Point(0, 0);
            this.featureGrid.Name = "featureGrid";
            this.featureGrid.OptionsBehavior.Editable = false;
            this.featureGrid.OptionsView.MaxRowAutoHeight = 100;
            this.featureGrid.Size = new System.Drawing.Size(284, 262);
            this.featureGrid.TabIndex = 0;
            // 
            // persistentRepos
            // 
            this.persistentRepos.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseBackColor = true;
            this.repositoryItemMemoEdit1.Appearance.Options.UseForeColor = true;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.featureGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InfoForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.featureGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl featureGrid;
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepos;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}