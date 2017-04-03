using eidss.model.Schema;

namespace eidss.winclient.Administration
{
    partial class Diagnosis2DiagnosisGroupMasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diagnosis2DiagnosisGroupMasterDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.lbDiagnosisGroup = new DevExpress.XtraEditors.LabelControl();
            this.cbDiagnosisGroups = new DevExpress.XtraEditors.LookUpEdit();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDiagnosisGroups.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(Diagnosis2DiagnosisGroupMasterDetail), out resources);
            // Form Is Localizable: True
            // 
            // panelTop
            // 
            this.panelTop.Appearance.Options.UseFont = true;
            this.panelTop.Controls.Add(this.lbDiagnosisGroup);
            this.panelTop.Controls.Add(this.cbDiagnosisGroups);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // lbDiagnosisGroup
            // 
            this.lbDiagnosisGroup.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbDiagnosisGroup.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbDiagnosisGroup, "lbDiagnosisGroup");
            this.lbDiagnosisGroup.Name = "lbDiagnosisGroup";
            // 
            // cbDiagnosisGroups
            // 
            resources.ApplyResources(this.cbDiagnosisGroups, "cbDiagnosisGroups");
            this.cbDiagnosisGroups.Name = "cbDiagnosisGroups";
            this.cbDiagnosisGroups.Properties.Appearance.Options.UseFont = true;
            this.cbDiagnosisGroups.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbDiagnosisGroups.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbDiagnosisGroups.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbDiagnosisGroups.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbDiagnosisGroups.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseFont = true;
            this.cbDiagnosisGroups.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons"))), resources.GetString("cbDiagnosisGroups.Properties.Buttons1"), ((int)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons2"))), ((bool)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons3"))), ((bool)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons4"))), ((bool)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("cbDiagnosisGroups.Properties.Buttons8"), ((object)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons10"))), ((bool)(resources.GetObject("cbDiagnosisGroups.Properties.Buttons11"))))});
            this.cbDiagnosisGroups.Properties.NullText = resources.GetString("cbDiagnosisGroups.Properties.NullText");
            // 
            // panelBottom
            // 
            this.panelBottom.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // Diagnosis2DiagnosisGroupMasterDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Icon = global::eidss.winclient.Properties.Resources.Reference_Matrix__large__46_;
            this.Name = "Diagnosis2DiagnosisGroupMasterDetail";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbDiagnosisGroups.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.LabelControl lbDiagnosisGroup;
        private DevExpress.XtraEditors.LookUpEdit cbDiagnosisGroups;
        private DevExpress.XtraEditors.PanelControl panelBottom;
    }
}
