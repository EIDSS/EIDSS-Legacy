namespace eidss.avr.ChartForm
{
    partial class XAxisSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XAxisSettings));
            this.lblLeftIndent = new DevExpress.XtraEditors.LabelControl();
            this.seLeftIndent = new DevExpress.XtraEditors.SpinEdit();
            this.generalSettings = new eidss.avr.ChartForm.AxisSettings();
            ((System.ComponentModel.ISupportInitialize)(this.seLeftIndent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLeftIndent
            // 
            resources.ApplyResources(this.lblLeftIndent, "lblLeftIndent");
            this.lblLeftIndent.Name = "lblLeftIndent";
            // 
            // seLeftIndent
            // 
            resources.ApplyResources(this.seLeftIndent, "seLeftIndent");
            this.seLeftIndent.Name = "seLeftIndent";
            this.seLeftIndent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seLeftIndent.Properties.Buttons"))))});
            this.seLeftIndent.EditValueChanged += new System.EventHandler(this.seLeftIndent_EditValueChanged);
            // 
            // generalSettings
            // 
            this.generalSettings.ChartDetailPanel = null;
            this.generalSettings.CurrentAxis = null;
            resources.ApplyResources(this.generalSettings, "generalSettings");
            this.generalSettings.Index = 0;
            this.generalSettings.Name = "generalSettings";
            this.generalSettings.PropertiesType = null;
            // 
            // XAxisSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLeftIndent);
            this.Controls.Add(this.seLeftIndent);
            this.Controls.Add(this.generalSettings);
            this.Name = "XAxisSettings";
            ((System.ComponentModel.ISupportInitialize)(this.seLeftIndent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxisSettings generalSettings;
        private DevExpress.XtraEditors.SpinEdit seLeftIndent;
        private DevExpress.XtraEditors.LabelControl lblLeftIndent;
    }
}
