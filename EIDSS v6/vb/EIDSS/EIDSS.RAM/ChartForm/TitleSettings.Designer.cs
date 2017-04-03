namespace eidss.avr.ChartForm
{
    partial class TitleSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleSettings));
            this.gcMain = new DevExpress.XtraEditors.GroupControl();
            this.cbVisible = new DevExpress.XtraEditors.CheckEdit();
            this.lblAlignment = new DevExpress.XtraEditors.LabelControl();
            this.cbAlignment = new DevExpress.XtraEditors.ComboBoxEdit();
            this.beFont = new DevExpress.XtraEditors.ButtonEdit();
            this.lblFont = new DevExpress.XtraEditors.LabelControl();
            this.tbText = new DevExpress.XtraEditors.TextEdit();
            this.lblTitleText = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            this.gcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAlignment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beFont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMain
            // 
            this.gcMain.Controls.Add(this.cbVisible);
            this.gcMain.Controls.Add(this.lblAlignment);
            this.gcMain.Controls.Add(this.cbAlignment);
            this.gcMain.Controls.Add(this.beFont);
            this.gcMain.Controls.Add(this.lblFont);
            this.gcMain.Controls.Add(this.tbText);
            this.gcMain.Controls.Add(this.lblTitleText);
            resources.ApplyResources(this.gcMain, "gcMain");
            this.gcMain.Name = "gcMain";
            // 
            // cbVisible
            // 
            resources.ApplyResources(this.cbVisible, "cbVisible");
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Properties.Caption = resources.GetString("cbVisible.Properties.Caption");
            this.cbVisible.CheckedChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // lblAlignment
            // 
            resources.ApplyResources(this.lblAlignment, "lblAlignment");
            this.lblAlignment.Name = "lblAlignment";
            // 
            // cbAlignment
            // 
            resources.ApplyResources(this.cbAlignment, "cbAlignment");
            this.cbAlignment.Name = "cbAlignment";
            this.cbAlignment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbAlignment.Properties.Buttons"))))});
            this.cbAlignment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAlignment.EditValueChanged += new System.EventHandler(this.cbTitleAlignment_SelectedIndexChanged);
            // 
            // beFont
            // 
            resources.ApplyResources(this.beFont, "beFont");
            this.beFont.Name = "beFont";
            this.beFont.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beFont.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beFont.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beFont_ButtonClick);
            // 
            // lblFont
            // 
            resources.ApplyResources(this.lblFont, "lblFont");
            this.lblFont.Name = "lblFont";
            // 
            // tbText
            // 
            resources.ApplyResources(this.tbText, "tbText");
            this.tbText.Name = "tbText";
            this.tbText.Properties.Appearance.Options.UseFont = true;
            this.tbText.Properties.AppearanceDisabled.Options.UseFont = true;
            this.tbText.Properties.AppearanceFocused.Options.UseFont = true;
            this.tbText.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.tbText.Tag = "{alwayseditable}";
            this.tbText.EditValueChanged += new System.EventHandler(this.tbChartName_EditValueChanged);
            // 
            // lblTitleText
            // 
            resources.ApplyResources(this.lblTitleText, "lblTitleText");
            this.lblTitleText.Name = "lblTitleText";
            // 
            // TitleSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcMain);
            this.Name = "TitleSettings";
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            this.gcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAlignment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beFont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcMain;
        private DevExpress.XtraEditors.CheckEdit cbVisible;
        private DevExpress.XtraEditors.LabelControl lblAlignment;
        private DevExpress.XtraEditors.ComboBoxEdit cbAlignment;
        private DevExpress.XtraEditors.ButtonEdit beFont;
        private DevExpress.XtraEditors.LabelControl lblFont;
        private DevExpress.XtraEditors.TextEdit tbText;
        private DevExpress.XtraEditors.LabelControl lblTitleText;
    }
}
