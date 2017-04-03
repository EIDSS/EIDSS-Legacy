namespace eidss.winclient.Administration
{
    partial class Diagnosis2PensideTestMasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diagnosis2PensideTestMasterDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.cbDiagnosis = new DevExpress.XtraEditors.LookUpEdit();
            this.lbDiagnosis = new DevExpress.XtraEditors.LabelControl();
            this.matrixDetail = new eidss.winclient.Administration.Diagnosis2PensideTestDetail();
            ((System.ComponentModel.ISupportInitialize)(this.cbDiagnosis.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(Diagnosis2PensideTestMasterDetail), out resources);
            // Form Is Localizable: True
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
            // lbDiagnosis
            // 
            this.lbDiagnosis.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbDiagnosis.Appearance.Font")));
            this.lbDiagnosis.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbDiagnosis.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbDiagnosis, "lbDiagnosis");
            this.lbDiagnosis.Name = "lbDiagnosis";
            // 
            // matrixDetail
            // 
            resources.ApplyResources(this.matrixDetail, "matrixDetail");
            this.matrixDetail.DCManager = null;
            this.matrixDetail.EditByDoubleClick = false;
            this.matrixDetail.FormID = "";
            this.matrixDetail.HelpTopicID = "";
            this.matrixDetail.Icon = null;
            this.matrixDetail.InlineMode = bv.winclient.BasePanel.InlineMode.UseNewRow;
            this.matrixDetail.Name = "matrixDetail";
            this.matrixDetail.Sizable = true;
            // 
            // Diagnosis2PensideTestMasterDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.matrixDetail);
            this.Controls.Add(this.lbDiagnosis);
            this.Controls.Add(this.cbDiagnosis);
            this.Icon = global::eidss.winclient.Properties.Resources.Reference_Matrix__large__46_;
            this.Name = "Diagnosis2PensideTestMasterDetail";
            ((System.ComponentModel.ISupportInitialize)(this.cbDiagnosis.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cbDiagnosis;
        private DevExpress.XtraEditors.LabelControl lbDiagnosis;
        private Diagnosis2PensideTestDetail matrixDetail;
    }
}
