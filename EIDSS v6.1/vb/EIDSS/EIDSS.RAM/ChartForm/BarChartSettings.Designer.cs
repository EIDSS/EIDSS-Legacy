namespace eidss.avr.ChartForm
{
    partial class BarChartSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarChartSettings));
            this.gcSettings = new DevExpress.XtraEditors.GroupControl();
            this.seBarWidth = new DevExpress.XtraEditors.SpinEdit();
            this.ceColor = new DevExpress.XtraEditors.ColorEdit();
            this.lblColor = new DevExpress.XtraEditors.LabelControl();
            this.lblBarWidth = new DevExpress.XtraEditors.LabelControl();
            this.lblFillMode = new DevExpress.XtraEditors.LabelControl();
            this.cbFillMode = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).BeginInit();
            this.gcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seBarWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFillMode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSettings
            // 
            resources.ApplyResources(this.gcSettings, "gcSettings");
            this.gcSettings.Controls.Add(this.seBarWidth);
            this.gcSettings.Controls.Add(this.ceColor);
            this.gcSettings.Controls.Add(this.lblColor);
            this.gcSettings.Controls.Add(this.lblBarWidth);
            this.gcSettings.Controls.Add(this.lblFillMode);
            this.gcSettings.Controls.Add(this.cbFillMode);
            this.gcSettings.Name = "gcSettings";
            // 
            // seBarWidth
            // 
            resources.ApplyResources(this.seBarWidth, "seBarWidth");
            this.seBarWidth.Name = "seBarWidth";
            this.seBarWidth.Properties.AccessibleDescription = resources.GetString("seBarWidth.Properties.AccessibleDescription");
            this.seBarWidth.Properties.AccessibleName = resources.GetString("seBarWidth.Properties.AccessibleName");
            this.seBarWidth.Properties.AutoHeight = ((bool)(resources.GetObject("seBarWidth.Properties.AutoHeight")));
            this.seBarWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seBarWidth.Properties.Buttons"))))});
            this.seBarWidth.Properties.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.seBarWidth.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("seBarWidth.Properties.Mask.AutoComplete")));
            this.seBarWidth.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("seBarWidth.Properties.Mask.BeepOnError")));
            this.seBarWidth.Properties.Mask.EditMask = resources.GetString("seBarWidth.Properties.Mask.EditMask");
            this.seBarWidth.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("seBarWidth.Properties.Mask.IgnoreMaskBlank")));
            this.seBarWidth.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("seBarWidth.Properties.Mask.MaskType")));
            this.seBarWidth.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("seBarWidth.Properties.Mask.PlaceHolder")));
            this.seBarWidth.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("seBarWidth.Properties.Mask.SaveLiteral")));
            this.seBarWidth.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("seBarWidth.Properties.Mask.ShowPlaceHolders")));
            this.seBarWidth.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seBarWidth.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seBarWidth.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seBarWidth.Properties.MinValue = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.seBarWidth.Properties.NullValuePrompt = resources.GetString("seBarWidth.Properties.NullValuePrompt");
            this.seBarWidth.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("seBarWidth.Properties.NullValuePromptShowForEmptyValue")));
            this.seBarWidth.EditValueChanged += new System.EventHandler(this.seBarWidth_EditValueChanged);
            // 
            // ceColor
            // 
            resources.ApplyResources(this.ceColor, "ceColor");
            this.ceColor.Name = "ceColor";
            this.ceColor.Properties.AccessibleDescription = resources.GetString("ceColor.Properties.AccessibleDescription");
            this.ceColor.Properties.AccessibleName = resources.GetString("ceColor.Properties.AccessibleName");
            this.ceColor.Properties.AutoHeight = ((bool)(resources.GetObject("ceColor.Properties.AutoHeight")));
            this.ceColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ceColor.Properties.Buttons"))))});
            this.ceColor.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ceColor.Properties.Mask.AutoComplete")));
            this.ceColor.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("ceColor.Properties.Mask.BeepOnError")));
            this.ceColor.Properties.Mask.EditMask = resources.GetString("ceColor.Properties.Mask.EditMask");
            this.ceColor.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ceColor.Properties.Mask.IgnoreMaskBlank")));
            this.ceColor.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ceColor.Properties.Mask.MaskType")));
            this.ceColor.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("ceColor.Properties.Mask.PlaceHolder")));
            this.ceColor.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("ceColor.Properties.Mask.SaveLiteral")));
            this.ceColor.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ceColor.Properties.Mask.ShowPlaceHolders")));
            this.ceColor.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ceColor.Properties.Mask.UseMaskAsDisplayFormat")));
            this.ceColor.Properties.NullValuePrompt = resources.GetString("ceColor.Properties.NullValuePrompt");
            this.ceColor.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ceColor.Properties.NullValuePromptShowForEmptyValue")));
            this.ceColor.EditValueChanged += new System.EventHandler(this.ceColor_EditValueChanged);
            // 
            // lblColor
            // 
            resources.ApplyResources(this.lblColor, "lblColor");
            this.lblColor.Name = "lblColor";
            // 
            // lblBarWidth
            // 
            resources.ApplyResources(this.lblBarWidth, "lblBarWidth");
            this.lblBarWidth.Name = "lblBarWidth";
            // 
            // lblFillMode
            // 
            resources.ApplyResources(this.lblFillMode, "lblFillMode");
            this.lblFillMode.Name = "lblFillMode";
            // 
            // cbFillMode
            // 
            resources.ApplyResources(this.cbFillMode, "cbFillMode");
            this.cbFillMode.Name = "cbFillMode";
            this.cbFillMode.Properties.AccessibleDescription = resources.GetString("cbFillMode.Properties.AccessibleDescription");
            this.cbFillMode.Properties.AccessibleName = resources.GetString("cbFillMode.Properties.AccessibleName");
            this.cbFillMode.Properties.AutoHeight = ((bool)(resources.GetObject("cbFillMode.Properties.AutoHeight")));
            this.cbFillMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbFillMode.Properties.Buttons"))))});
            this.cbFillMode.Properties.NullValuePrompt = resources.GetString("cbFillMode.Properties.NullValuePrompt");
            this.cbFillMode.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbFillMode.Properties.NullValuePromptShowForEmptyValue")));
            this.cbFillMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbFillMode.EditValueChanged += new System.EventHandler(this.cbFillMode_EditValueChanged);
            // 
            // BarChartSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSettings);
            this.Name = "BarChartSettings";
            this.Controls.SetChildIndex(this.gcSettings, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).EndInit();
            this.gcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seBarWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFillMode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcSettings;
        private DevExpress.XtraEditors.LabelControl lblFillMode;
        private DevExpress.XtraEditors.ComboBoxEdit cbFillMode;
        private DevExpress.XtraEditors.ColorEdit ceColor;
        private DevExpress.XtraEditors.LabelControl lblColor;
        private DevExpress.XtraEditors.LabelControl lblBarWidth;
        private DevExpress.XtraEditors.SpinEdit seBarWidth;
    }
}
