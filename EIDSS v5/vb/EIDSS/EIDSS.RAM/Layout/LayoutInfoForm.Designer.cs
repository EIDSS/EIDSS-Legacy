namespace EIDSS.RAM.Layout
{
    partial class LayoutInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutInfoForm));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewFolder = new DevExpress.XtraEditors.SimpleButton();
            this.m_LayoutTreeListKeeper = new EIDSS.RAM.Layout.LayoutTreeListKeeper();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeleteFolder
            // 
            resources.ApplyResources(this.btnDeleteFolder, "btnDeleteFolder");
            this.btnDeleteFolder.Appearance.Options.UseFont = true;
            this.btnDeleteFolder.Name = "btnDeleteFolder";
            this.btnDeleteFolder.Click += new System.EventHandler(this.btnDeleteFolder_Click);
            // 
            // btnNewFolder
            // 
            resources.ApplyResources(this.btnNewFolder, "btnNewFolder");
            this.btnNewFolder.Appearance.Options.UseFont = true;
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // m_LayoutTreeListKeeper
            // 
            resources.ApplyResources(this.m_LayoutTreeListKeeper, "m_LayoutTreeListKeeper");
            this.m_LayoutTreeListKeeper.Appearance.Options.UseFont = true;
            this.m_LayoutTreeListKeeper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            this.m_LayoutTreeListKeeper.Name = "m_LayoutTreeListKeeper";
            
            
            // 
            // LayoutInfoForm
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNewFolder);
            this.Controls.Add(this.btnDeleteFolder);
            this.Controls.Add(this.m_LayoutTreeListKeeper);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "LayoutInfoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private LayoutTreeListKeeper m_LayoutTreeListKeeper;
        private DevExpress.XtraEditors.SimpleButton btnDeleteFolder;
        private DevExpress.XtraEditors.SimpleButton btnNewFolder;

    }
}