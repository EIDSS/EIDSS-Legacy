namespace EIDSS.Reports.BaseControls.Filters
{
    partial class VetCaseTypeFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetCaseTypeFilter));
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VetCaseTypeFilter), out resources);
            // Form Is Localizable: True
            // 
            // radioGroup
            // 
            resources.ApplyResources(this.radioGroup, "radioGroup");
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("radioGroup.Properties.Items"))), resources.GetString("radioGroup.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("radioGroup.Properties.Items2"))), resources.GetString("radioGroup.Properties.Items3"))});
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // VetCaseTypeFilter
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.radioGroup);
            this.Name = "VetCaseTypeFilter";
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroup;
    }
}
