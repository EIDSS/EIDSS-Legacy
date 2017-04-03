using eidss.model.Schema;

namespace eidss.winclient.Administration
{
    partial class DAG2SAGMasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DAG2SAGMasterDetail));
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.cbDiagnosisAgeGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.lbDiagnosis = new DevExpress.XtraEditors.LabelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDiagnosisAgeGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("panelTop.Appearance.Font")));
            this.panelTop.Appearance.Options.UseFont = true;
            this.panelTop.Controls.Add(this.cbDiagnosisAgeGroup);
            this.panelTop.Controls.Add(this.lbDiagnosis);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // cbDiagnosisAgeGroup
            // 
            resources.ApplyResources(this.cbDiagnosisAgeGroup, "cbDiagnosisAgeGroup");
            this.cbDiagnosisAgeGroup.Name = "cbDiagnosisAgeGroup";
            this.cbDiagnosisAgeGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbDiagnosisAgeGroup.Properties.Buttons"))))});
            this.cbDiagnosisAgeGroup.Properties.NullText = resources.GetString("cbDiagnosisAgeGroup.Properties.NullText");
            // 
            // lbDiagnosis
            // 
            this.lbDiagnosis.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbDiagnosis.Appearance.Font")));
            this.lbDiagnosis.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbDiagnosis.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbDiagnosis, "lbDiagnosis");
            this.lbDiagnosis.Name = "lbDiagnosis";
            // 
            // panelBottom
            // 
            this.panelBottom.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("panelBottom.Appearance.Font")));
            this.panelBottom.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // DAG2SAGMasterDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Icon = global::eidss.winclient.Properties.Resources.Reference_Matrix__large__46_;
            this.Name = "DAG2SAGMasterDetail";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbDiagnosisAgeGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.LabelControl lbDiagnosis;
        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.LookUpEdit cbDiagnosisAgeGroup;
    }
}
