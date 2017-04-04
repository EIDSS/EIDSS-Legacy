namespace eidss.winclient.Lab
{
    partial class LaboratorySectionCreateNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorySectionCreateNew));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lbNumber = new DevExpress.XtraEditors.LabelControl();
            this.seNumber = new DevExpress.XtraEditors.SpinEdit();
            this.leSampleTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.lbCase = new DevExpress.XtraEditors.LabelControl();
            this.lbSampleType = new DevExpress.XtraEditors.LabelControl();
            this.txtCaseSessionID = new DevExpress.XtraEditors.ButtonEdit();
            this.lblAddNote = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.seNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSampleTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaseSessionID.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LaboratorySectionCreateNew), out resources);
            // Form Is Localizable: True
            // 
            // lbNumber
            // 
            this.lbNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbNumber.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbNumber, "lbNumber");
            this.lbNumber.Name = "lbNumber";
            // 
            // seNumber
            // 
            resources.ApplyResources(this.seNumber, "seNumber");
            this.seNumber.Name = "seNumber";
            this.seNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seNumber.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seNumber.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // leSampleTypes
            // 
            resources.ApplyResources(this.leSampleTypes, "leSampleTypes");
            this.leSampleTypes.Name = "leSampleTypes";
            this.leSampleTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSampleTypes.Properties.Buttons"))))});
            this.leSampleTypes.Properties.NullText = resources.GetString("leSampleTypes.Properties.NullText");
            // 
            // lbCase
            // 
            this.lbCase.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbCase.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbCase, "lbCase");
            this.lbCase.Name = "lbCase";
            // 
            // lbSampleType
            // 
            this.lbSampleType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbSampleType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbSampleType, "lbSampleType");
            this.lbSampleType.Name = "lbSampleType";
            // 
            // txtCaseSessionID
            // 
            resources.ApplyResources(this.txtCaseSessionID, "txtCaseSessionID");
            this.txtCaseSessionID.Name = "txtCaseSessionID";
            serializableAppearanceObject1.Options.UseFont = true;
            this.txtCaseSessionID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtCaseSessionID.Properties.Buttons"))), resources.GetString("txtCaseSessionID.Properties.Buttons1"), ((int)(resources.GetObject("txtCaseSessionID.Properties.Buttons2"))), ((bool)(resources.GetObject("txtCaseSessionID.Properties.Buttons3"))), ((bool)(resources.GetObject("txtCaseSessionID.Properties.Buttons4"))), ((bool)(resources.GetObject("txtCaseSessionID.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("txtCaseSessionID.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("txtCaseSessionID.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("txtCaseSessionID.Properties.Buttons8"), ((object)(resources.GetObject("txtCaseSessionID.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("txtCaseSessionID.Properties.Buttons10"))), ((bool)(resources.GetObject("txtCaseSessionID.Properties.Buttons11"))))});
            this.txtCaseSessionID.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFarmOwner_ButtonClick);
            // 
            // lblAddNote
            // 
            this.lblAddNote.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAddNote.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblAddNote, "lblAddNote");
            this.lblAddNote.Name = "lblAddNote";
            // 
            // LaboratorySectionCreateNew
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAddNote);
            this.Controls.Add(this.txtCaseSessionID);
            this.Controls.Add(this.lbSampleType);
            this.Controls.Add(this.leSampleTypes);
            this.Controls.Add(this.lbCase);
            this.Controls.Add(this.seNumber);
            this.Controls.Add(this.lbNumber);
            this.FormID = "L35";
            this.HelpTopicID = "lab_l35";
            this.Icon = global::eidss.winclient.Properties.Resources.Sample__large_;
            this.Name = "LaboratorySectionCreateNew";
            ((System.ComponentModel.ISupportInitialize)(this.seNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSampleTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaseSessionID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbNumber;
        private DevExpress.XtraEditors.SpinEdit seNumber;
        private DevExpress.XtraEditors.LookUpEdit leSampleTypes;
        private DevExpress.XtraEditors.LabelControl lbCase;
        private DevExpress.XtraEditors.LabelControl lbSampleType;
        internal DevExpress.XtraEditors.ButtonEdit txtCaseSessionID;
        private DevExpress.XtraEditors.LabelControl lblAddNote;
    }
}
