namespace EIDSS.RAM.Layout
{
    partial class FilterForm
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
            if (m_FilterControlHelper != null)
            {
                m_FilterControlHelper.Dispose();
                m_FilterControlHelper = null;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.filterControl = new DevExpress.XtraEditors.FilterControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.chkApplyFilter = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkApplyFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // filterControl
            // 
            resources.ApplyResources(this.filterControl, "filterControl");
            this.filterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.filterControl.Name = "filterControl";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // chkApplyFilter
            // 
            resources.ApplyResources(this.chkApplyFilter, "chkApplyFilter");
            this.chkApplyFilter.Name = "chkApplyFilter";
            this.chkApplyFilter.Properties.Appearance.Options.UseFont = true;
            this.chkApplyFilter.Properties.AppearanceDisabled.Options.UseFont = true;
            this.chkApplyFilter.Properties.AppearanceFocused.Options.UseFont = true;
            this.chkApplyFilter.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.chkApplyFilter.Properties.Caption = resources.GetString("chkApplyFilter.Properties.Caption");
            this.chkApplyFilter.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkApplyFilter.Tag = "{alwayseditable}";
            // 
            // FilterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkApplyFilter);
            this.Controls.Add(this.filterControl);
            this.Name = "FilterForm";
            ((System.ComponentModel.ISupportInitialize)(this.chkApplyFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.FilterControl filterControl;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit chkApplyFilter;

    }
}