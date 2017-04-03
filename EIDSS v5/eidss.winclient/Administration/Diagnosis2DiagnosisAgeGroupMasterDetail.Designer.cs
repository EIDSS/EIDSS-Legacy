using eidss.model.Schema;

namespace eidss.winclient.Administration
{
    partial class Diagnosis2DiagnosisAgeGroupMasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diagnosis2DiagnosisAgeGroupMasterDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.lbDiagnosis = new DevExpress.XtraEditors.LabelControl();
            this.cbDiagnosis = new DevExpress.XtraEditors.LookUpEdit();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDiagnosis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("panelTop.Appearance.Font")));
            this.panelTop.Appearance.Options.UseFont = true;
            this.panelTop.Controls.Add(this.lbDiagnosis);
            this.panelTop.Controls.Add(this.cbDiagnosis);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // lbDiagnosis
            // 
            this.lbDiagnosis.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbDiagnosis.Appearance.Font")));
            this.lbDiagnosis.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbDiagnosis.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbDiagnosis, "lbDiagnosis");
            this.lbDiagnosis.Name = "lbDiagnosis";
            // 
            // cbDiagnosis
            // 
            resources.ApplyResources(this.cbDiagnosis, "cbDiagnosis");
            this.cbDiagnosis.Name = "cbDiagnosis";
            this.cbDiagnosis.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cbDiagnosis.Properties.Appearance.Font")));
            this.cbDiagnosis.Properties.Appearance.Options.UseFont = true;
            this.cbDiagnosis.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("cbDiagnosis.Properties.AppearanceDisabled.Font")));
            this.cbDiagnosis.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbDiagnosis.Properties.AppearanceDropDown.Font = ((System.Drawing.Font)(resources.GetObject("cbDiagnosis.Properties.AppearanceDropDown.Font")));
            this.cbDiagnosis.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbDiagnosis.Properties.AppearanceDropDownHeader.Font = ((System.Drawing.Font)(resources.GetObject("cbDiagnosis.Properties.AppearanceDropDownHeader.Font")));
            this.cbDiagnosis.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbDiagnosis.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("cbDiagnosis.Properties.AppearanceFocused.Font")));
            this.cbDiagnosis.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbDiagnosis.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("cbDiagnosis.Properties.AppearanceReadOnly.Font")));
            this.cbDiagnosis.Properties.AppearanceReadOnly.Options.UseFont = true;
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseFont = true;
            this.cbDiagnosis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbDiagnosis.Properties.Buttons"))), resources.GetString("cbDiagnosis.Properties.Buttons1"), ((int)(resources.GetObject("cbDiagnosis.Properties.Buttons2"))), ((bool)(resources.GetObject("cbDiagnosis.Properties.Buttons3"))), ((bool)(resources.GetObject("cbDiagnosis.Properties.Buttons4"))), ((bool)(resources.GetObject("cbDiagnosis.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbDiagnosis.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbDiagnosis.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("cbDiagnosis.Properties.Buttons8"), ((object)(resources.GetObject("cbDiagnosis.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbDiagnosis.Properties.Buttons10"))), ((bool)(resources.GetObject("cbDiagnosis.Properties.Buttons11"))))});
            // 
            // panelBottom
            // 
            this.panelBottom.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("panelBottom.Appearance.Font")));
            this.panelBottom.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // Diagnosis2DiagnosisAgeGroupMasterDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Icon = global::eidss.winclient.Properties.Resources.Reference_Matrix__large__46_;
            this.Name = "Diagnosis2DiagnosisAgeGroupMasterDetail";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbDiagnosis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.LabelControl lbDiagnosis;
        private DevExpress.XtraEditors.LookUpEdit cbDiagnosis;
        private DevExpress.XtraEditors.PanelControl panelBottom;
    }
}
