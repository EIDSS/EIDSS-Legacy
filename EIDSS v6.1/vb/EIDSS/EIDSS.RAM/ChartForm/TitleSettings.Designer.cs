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
            resources.ApplyResources(this.gcMain, "gcMain");
            this.gcMain.Controls.Add(this.cbVisible);
            this.gcMain.Controls.Add(this.lblAlignment);
            this.gcMain.Controls.Add(this.cbAlignment);
            this.gcMain.Controls.Add(this.beFont);
            this.gcMain.Controls.Add(this.lblFont);
            this.gcMain.Controls.Add(this.tbText);
            this.gcMain.Controls.Add(this.lblTitleText);
            this.gcMain.Name = "gcMain";
            // 
            // cbVisible
            // 
            resources.ApplyResources(this.cbVisible, "cbVisible");
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Properties.AccessibleDescription = resources.GetString("cbVisible.Properties.AccessibleDescription");
            this.cbVisible.Properties.AccessibleName = resources.GetString("cbVisible.Properties.AccessibleName");
            this.cbVisible.Properties.AutoHeight = ((bool)(resources.GetObject("cbVisible.Properties.AutoHeight")));
            this.cbVisible.Properties.Caption = resources.GetString("cbVisible.Properties.Caption");
            this.cbVisible.Properties.DisplayValueChecked = resources.GetString("cbVisible.Properties.DisplayValueChecked");
            this.cbVisible.Properties.DisplayValueGrayed = resources.GetString("cbVisible.Properties.DisplayValueGrayed");
            this.cbVisible.Properties.DisplayValueUnchecked = resources.GetString("cbVisible.Properties.DisplayValueUnchecked");
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
            this.cbAlignment.Properties.AccessibleDescription = resources.GetString("cbAlignment.Properties.AccessibleDescription");
            this.cbAlignment.Properties.AccessibleName = resources.GetString("cbAlignment.Properties.AccessibleName");
            this.cbAlignment.Properties.AutoHeight = ((bool)(resources.GetObject("cbAlignment.Properties.AutoHeight")));
            this.cbAlignment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbAlignment.Properties.Buttons"))))});
            this.cbAlignment.Properties.NullValuePrompt = resources.GetString("cbAlignment.Properties.NullValuePrompt");
            this.cbAlignment.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbAlignment.Properties.NullValuePromptShowForEmptyValue")));
            this.cbAlignment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAlignment.EditValueChanged += new System.EventHandler(this.cbTitleAlignment_SelectedIndexChanged);
            // 
            // beFont
            // 
            resources.ApplyResources(this.beFont, "beFont");
            this.beFont.Name = "beFont";
            this.beFont.Properties.AccessibleDescription = resources.GetString("beFont.Properties.AccessibleDescription");
            this.beFont.Properties.AccessibleName = resources.GetString("beFont.Properties.AccessibleName");
            this.beFont.Properties.AutoHeight = ((bool)(resources.GetObject("beFont.Properties.AutoHeight")));
            this.beFont.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beFont.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("beFont.Properties.Mask.AutoComplete")));
            this.beFont.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("beFont.Properties.Mask.BeepOnError")));
            this.beFont.Properties.Mask.EditMask = resources.GetString("beFont.Properties.Mask.EditMask");
            this.beFont.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("beFont.Properties.Mask.IgnoreMaskBlank")));
            this.beFont.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("beFont.Properties.Mask.MaskType")));
            this.beFont.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("beFont.Properties.Mask.PlaceHolder")));
            this.beFont.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("beFont.Properties.Mask.SaveLiteral")));
            this.beFont.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("beFont.Properties.Mask.ShowPlaceHolders")));
            this.beFont.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("beFont.Properties.Mask.UseMaskAsDisplayFormat")));
            this.beFont.Properties.NullValuePrompt = resources.GetString("beFont.Properties.NullValuePrompt");
            this.beFont.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("beFont.Properties.NullValuePromptShowForEmptyValue")));
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
            this.tbText.Properties.AccessibleDescription = resources.GetString("tbText.Properties.AccessibleDescription");
            this.tbText.Properties.AccessibleName = resources.GetString("tbText.Properties.AccessibleName");
            this.tbText.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("tbText.Properties.Appearance.FontSizeDelta")));
            this.tbText.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tbText.Properties.Appearance.FontStyleDelta")));
            this.tbText.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tbText.Properties.Appearance.GradientMode")));
            this.tbText.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("tbText.Properties.Appearance.Image")));
            this.tbText.Properties.Appearance.Options.UseFont = true;
            this.tbText.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("tbText.Properties.AppearanceDisabled.FontSizeDelta")));
            this.tbText.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tbText.Properties.AppearanceDisabled.FontStyleDelta")));
            this.tbText.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tbText.Properties.AppearanceDisabled.GradientMode")));
            this.tbText.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("tbText.Properties.AppearanceDisabled.Image")));
            this.tbText.Properties.AppearanceDisabled.Options.UseFont = true;
            this.tbText.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("tbText.Properties.AppearanceFocused.FontSizeDelta")));
            this.tbText.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tbText.Properties.AppearanceFocused.FontStyleDelta")));
            this.tbText.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tbText.Properties.AppearanceFocused.GradientMode")));
            this.tbText.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("tbText.Properties.AppearanceFocused.Image")));
            this.tbText.Properties.AppearanceFocused.Options.UseFont = true;
            this.tbText.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("tbText.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.tbText.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tbText.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.tbText.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tbText.Properties.AppearanceReadOnly.GradientMode")));
            this.tbText.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("tbText.Properties.AppearanceReadOnly.Image")));
            this.tbText.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.tbText.Properties.AutoHeight = ((bool)(resources.GetObject("tbText.Properties.AutoHeight")));
            this.tbText.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("tbText.Properties.Mask.AutoComplete")));
            this.tbText.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("tbText.Properties.Mask.BeepOnError")));
            this.tbText.Properties.Mask.EditMask = resources.GetString("tbText.Properties.Mask.EditMask");
            this.tbText.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("tbText.Properties.Mask.IgnoreMaskBlank")));
            this.tbText.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("tbText.Properties.Mask.MaskType")));
            this.tbText.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("tbText.Properties.Mask.PlaceHolder")));
            this.tbText.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("tbText.Properties.Mask.SaveLiteral")));
            this.tbText.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("tbText.Properties.Mask.ShowPlaceHolders")));
            this.tbText.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("tbText.Properties.Mask.UseMaskAsDisplayFormat")));
            this.tbText.Properties.NullValuePrompt = resources.GetString("tbText.Properties.NullValuePrompt");
            this.tbText.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("tbText.Properties.NullValuePromptShowForEmptyValue")));
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
