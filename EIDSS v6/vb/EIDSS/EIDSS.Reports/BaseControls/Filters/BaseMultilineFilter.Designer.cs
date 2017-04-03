namespace EIDSS.Reports.BaseControls.Filters
{
    partial class BaseMultilineFilter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any m_Resources being used.
        /// </summary>
        /// <param name="disposing">true if managed m_Resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseMultilineFilter));
            this.checkedComboBox = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblcheckedComboBoxName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BaseMultilineFilter), out resources);
            // Form Is Localizable: True
            // 
            // checkedComboBox
            // 
            resources.ApplyResources(this.checkedComboBox, "checkedComboBox");
            this.checkedComboBox.Name = "checkedComboBox";
            this.checkedComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("checkedComboBox.Properties.Buttons"))))});
            this.checkedComboBox.Properties.NullText = resources.GetString("checkedComboBox.Properties.NullText");
            this.checkedComboBox.EditValueChanged += new System.EventHandler(this.checkedComboBox_EditValueChanged);
            // 
            // lblcheckedComboBoxName
            // 
            resources.ApplyResources(this.lblcheckedComboBoxName, "lblcheckedComboBoxName");
            this.lblcheckedComboBoxName.Name = "lblcheckedComboBoxName";
            // 
            // BaseMultilineFilter
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("BaseMultilineFilter.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblcheckedComboBoxName);
            this.Controls.Add(this.checkedComboBox);
            this.Name = "BaseMultilineFilter";
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBox;
        protected DevExpress.XtraEditors.LabelControl lblcheckedComboBoxName;
    }
}
