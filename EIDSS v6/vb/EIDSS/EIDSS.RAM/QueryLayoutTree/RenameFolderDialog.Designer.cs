namespace eidss.avr.QueryLayoutTree
{
    partial class RenameFolderDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameFolderDialog));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.EnglishLabel = new DevExpress.XtraEditors.LabelControl();
            this.NationalLabel = new DevExpress.XtraEditors.LabelControl();
            this.EnglishText = new DevExpress.XtraEditors.TextEdit();
            this.NationalText = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EnglishLabel
            // 
            resources.ApplyResources(this.EnglishLabel, "EnglishLabel");
            this.EnglishLabel.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("EnglishLabel.Appearance.DisabledImage")));
            this.EnglishLabel.Appearance.FontSizeDelta = ((int)(resources.GetObject("EnglishLabel.Appearance.FontSizeDelta")));
            this.EnglishLabel.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("EnglishLabel.Appearance.FontStyleDelta")));
            this.EnglishLabel.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("EnglishLabel.Appearance.GradientMode")));
            this.EnglishLabel.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("EnglishLabel.Appearance.HoverImage")));
            this.EnglishLabel.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("EnglishLabel.Appearance.Image")));
            this.EnglishLabel.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("EnglishLabel.Appearance.PressedImage")));
            this.EnglishLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.EnglishLabel.Name = "EnglishLabel";
            // 
            // NationalLabel
            // 
            resources.ApplyResources(this.NationalLabel, "NationalLabel");
            this.NationalLabel.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("NationalLabel.Appearance.DisabledImage")));
            this.NationalLabel.Appearance.FontSizeDelta = ((int)(resources.GetObject("NationalLabel.Appearance.FontSizeDelta")));
            this.NationalLabel.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("NationalLabel.Appearance.FontStyleDelta")));
            this.NationalLabel.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("NationalLabel.Appearance.GradientMode")));
            this.NationalLabel.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("NationalLabel.Appearance.HoverImage")));
            this.NationalLabel.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("NationalLabel.Appearance.Image")));
            this.NationalLabel.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("NationalLabel.Appearance.PressedImage")));
            this.NationalLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.NationalLabel.Name = "NationalLabel";
            // 
            // EnglishText
            // 
            resources.ApplyResources(this.EnglishText, "EnglishText");
            this.EnglishText.Name = "EnglishText";
            this.EnglishText.Properties.AccessibleDescription = resources.GetString("EnglishText.Properties.AccessibleDescription");
            this.EnglishText.Properties.AccessibleName = resources.GetString("EnglishText.Properties.AccessibleName");
            this.EnglishText.Properties.AutoHeight = ((bool)(resources.GetObject("EnglishText.Properties.AutoHeight")));
            this.EnglishText.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("EnglishText.Properties.Mask.AutoComplete")));
            this.EnglishText.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("EnglishText.Properties.Mask.BeepOnError")));
            this.EnglishText.Properties.Mask.EditMask = resources.GetString("EnglishText.Properties.Mask.EditMask");
            this.EnglishText.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("EnglishText.Properties.Mask.IgnoreMaskBlank")));
            this.EnglishText.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("EnglishText.Properties.Mask.MaskType")));
            this.EnglishText.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("EnglishText.Properties.Mask.PlaceHolder")));
            this.EnglishText.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("EnglishText.Properties.Mask.SaveLiteral")));
            this.EnglishText.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("EnglishText.Properties.Mask.ShowPlaceHolders")));
            this.EnglishText.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("EnglishText.Properties.Mask.UseMaskAsDisplayFormat")));
            this.EnglishText.Properties.NullValuePrompt = resources.GetString("EnglishText.Properties.NullValuePrompt");
            this.EnglishText.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("EnglishText.Properties.NullValuePromptShowForEmptyValue")));
            this.EnglishText.EditValueChanged += new System.EventHandler(this.EnglishText_EditValueChanged);
            this.EnglishText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnglishText_KeyPress);
            // 
            // NationalText
            // 
            resources.ApplyResources(this.NationalText, "NationalText");
            this.NationalText.Name = "NationalText";
            this.NationalText.Properties.AccessibleDescription = resources.GetString("NationalText.Properties.AccessibleDescription");
            this.NationalText.Properties.AccessibleName = resources.GetString("NationalText.Properties.AccessibleName");
            this.NationalText.Properties.AutoHeight = ((bool)(resources.GetObject("NationalText.Properties.AutoHeight")));
            this.NationalText.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("NationalText.Properties.Mask.AutoComplete")));
            this.NationalText.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("NationalText.Properties.Mask.BeepOnError")));
            this.NationalText.Properties.Mask.EditMask = resources.GetString("NationalText.Properties.Mask.EditMask");
            this.NationalText.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("NationalText.Properties.Mask.IgnoreMaskBlank")));
            this.NationalText.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("NationalText.Properties.Mask.MaskType")));
            this.NationalText.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("NationalText.Properties.Mask.PlaceHolder")));
            this.NationalText.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("NationalText.Properties.Mask.SaveLiteral")));
            this.NationalText.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("NationalText.Properties.Mask.ShowPlaceHolders")));
            this.NationalText.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("NationalText.Properties.Mask.UseMaskAsDisplayFormat")));
            this.NationalText.Properties.NullValuePrompt = resources.GetString("NationalText.Properties.NullValuePrompt");
            this.NationalText.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("NationalText.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // RenameFolderDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NationalText);
            this.Controls.Add(this.EnglishText);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.NationalLabel);
            this.Controls.Add(this.EnglishLabel);
            this.Controls.Add(this.btnOK);
            this.Name = "RenameFolderDialog";
            ((System.ComponentModel.ISupportInitialize)(this.EnglishText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.SimpleButton btnOK;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.LabelControl EnglishLabel;
        protected DevExpress.XtraEditors.LabelControl NationalLabel;
        protected DevExpress.XtraEditors.TextEdit EnglishText;
        protected DevExpress.XtraEditors.TextEdit NationalText;

    }
}