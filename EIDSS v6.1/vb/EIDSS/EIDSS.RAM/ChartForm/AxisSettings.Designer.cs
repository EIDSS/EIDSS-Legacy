namespace eidss.avr.ChartForm
{
    partial class AxisSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AxisSettings));
            this.gcMain = new DevExpress.XtraEditors.GroupControl();
            this.cbReverse = new DevExpress.XtraEditors.CheckEdit();
            this.titleTitle = new eidss.avr.ChartForm.TitleSettings();
            this.seTickmarkMinorCount = new DevExpress.XtraEditors.SpinEdit();
            this.ceValueLabelStaggeredStyle = new DevExpress.XtraEditors.CheckEdit();
            this.beValueLabelFont = new DevExpress.XtraEditors.ButtonEdit();
            this.lblValueLabelFont = new DevExpress.XtraEditors.LabelControl();
            this.seValueLabelAngle = new DevExpress.XtraEditors.SpinEdit();
            this.lblValueLabelAngle = new DevExpress.XtraEditors.LabelControl();
            this.cbGridLinesVisible = new DevExpress.XtraEditors.CheckEdit();
            this.cbGridLinesStyles = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ceGridLinesColor = new DevExpress.XtraEditors.ColorEdit();
            this.seLineWidth = new DevExpress.XtraEditors.SpinEdit();
            this.ceLineColor = new DevExpress.XtraEditors.ColorEdit();
            this.lblTickmarkMinorCount = new DevExpress.XtraEditors.LabelControl();
            this.lblGridLinesStyles = new DevExpress.XtraEditors.LabelControl();
            this.lblGridLinesColor = new DevExpress.XtraEditors.LabelControl();
            this.lblLineWidth = new DevExpress.XtraEditors.LabelControl();
            this.lblLineColor = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            this.gcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbReverse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTickmarkMinorCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceValueLabelStaggeredStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beValueLabelFont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seValueLabelAngle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGridLinesVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGridLinesStyles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGridLinesColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLineWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLineColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMain
            // 
            this.gcMain.Controls.Add(this.cbReverse);
            this.gcMain.Controls.Add(this.titleTitle);
            this.gcMain.Controls.Add(this.seTickmarkMinorCount);
            this.gcMain.Controls.Add(this.ceValueLabelStaggeredStyle);
            this.gcMain.Controls.Add(this.beValueLabelFont);
            this.gcMain.Controls.Add(this.lblValueLabelFont);
            this.gcMain.Controls.Add(this.seValueLabelAngle);
            this.gcMain.Controls.Add(this.lblValueLabelAngle);
            this.gcMain.Controls.Add(this.cbGridLinesVisible);
            this.gcMain.Controls.Add(this.cbGridLinesStyles);
            this.gcMain.Controls.Add(this.ceGridLinesColor);
            this.gcMain.Controls.Add(this.seLineWidth);
            this.gcMain.Controls.Add(this.ceLineColor);
            this.gcMain.Controls.Add(this.lblTickmarkMinorCount);
            this.gcMain.Controls.Add(this.lblGridLinesStyles);
            this.gcMain.Controls.Add(this.lblGridLinesColor);
            this.gcMain.Controls.Add(this.lblLineWidth);
            this.gcMain.Controls.Add(this.lblLineColor);
            resources.ApplyResources(this.gcMain, "gcMain");
            this.gcMain.Name = "gcMain";
            // 
            // cbReverse
            // 
            resources.ApplyResources(this.cbReverse, "cbReverse");
            this.cbReverse.Name = "cbReverse";
            this.cbReverse.Properties.Caption = resources.GetString("cbReverse.Properties.Caption");
            this.cbReverse.EditValueChanged += new System.EventHandler(this.cbReverse_EditValueChanged);
            // 
            // titleTitle
            // 
            resources.ApplyResources(this.titleTitle, "titleTitle");
            this.titleTitle.ChartDetailPanel = null;
            this.titleTitle.CurrentTitle = null;
            this.titleTitle.Index = 0;
            this.titleTitle.Name = "titleTitle";
            this.titleTitle.PropertiesType = null;
            // 
            // seTickmarkMinorCount
            // 
            resources.ApplyResources(this.seTickmarkMinorCount, "seTickmarkMinorCount");
            this.seTickmarkMinorCount.Name = "seTickmarkMinorCount";
            this.seTickmarkMinorCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seTickmarkMinorCount.Properties.Buttons"))))});
            this.seTickmarkMinorCount.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seTickmarkMinorCount.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seTickmarkMinorCount.EditValueChanged += new System.EventHandler(this.seTickmarkMinorCount_EditValueChanged);
            // 
            // ceValueLabelStaggeredStyle
            // 
            resources.ApplyResources(this.ceValueLabelStaggeredStyle, "ceValueLabelStaggeredStyle");
            this.ceValueLabelStaggeredStyle.Name = "ceValueLabelStaggeredStyle";
            this.ceValueLabelStaggeredStyle.Properties.Caption = resources.GetString("ceValueLabelStaggeredStyle.Properties.Caption");
            this.ceValueLabelStaggeredStyle.CheckedChanged += new System.EventHandler(this.ceValueLabelStaggeredStyle_CheckedChanged);
            // 
            // beValueLabelFont
            // 
            resources.ApplyResources(this.beValueLabelFont, "beValueLabelFont");
            this.beValueLabelFont.Name = "beValueLabelFont";
            this.beValueLabelFont.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beValueLabelFont.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beValueLabelFont.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beValueLabelFont_ButtonClick);
            // 
            // lblValueLabelFont
            // 
            this.lblValueLabelFont.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblValueLabelFont, "lblValueLabelFont");
            this.lblValueLabelFont.Name = "lblValueLabelFont";
            // 
            // seValueLabelAngle
            // 
            resources.ApplyResources(this.seValueLabelAngle, "seValueLabelAngle");
            this.seValueLabelAngle.Name = "seValueLabelAngle";
            this.seValueLabelAngle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seValueLabelAngle.Properties.Buttons"))))});
            this.seValueLabelAngle.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seValueLabelAngle.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seValueLabelAngle.EditValueChanged += new System.EventHandler(this.seValueLabelAngle_EditValueChanged);
            // 
            // lblValueLabelAngle
            // 
            this.lblValueLabelAngle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblValueLabelAngle, "lblValueLabelAngle");
            this.lblValueLabelAngle.Name = "lblValueLabelAngle";
            // 
            // cbGridLinesVisible
            // 
            resources.ApplyResources(this.cbGridLinesVisible, "cbGridLinesVisible");
            this.cbGridLinesVisible.Name = "cbGridLinesVisible";
            this.cbGridLinesVisible.Properties.Caption = resources.GetString("cbGridLinesVisible.Properties.Caption");
            this.cbGridLinesVisible.CheckedChanged += new System.EventHandler(this.cbGridLinesVisible_CheckedChanged);
            // 
            // cbGridLinesStyles
            // 
            resources.ApplyResources(this.cbGridLinesStyles, "cbGridLinesStyles");
            this.cbGridLinesStyles.Name = "cbGridLinesStyles";
            this.cbGridLinesStyles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbGridLinesStyles.Properties.Buttons"))))});
            this.cbGridLinesStyles.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbGridLinesStyles.EditValueChanged += new System.EventHandler(this.cbGridLinesStyles_EditValueChanged);
            // 
            // ceGridLinesColor
            // 
            resources.ApplyResources(this.ceGridLinesColor, "ceGridLinesColor");
            this.ceGridLinesColor.Name = "ceGridLinesColor";
            this.ceGridLinesColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ceGridLinesColor.Properties.Buttons"))))});
            this.ceGridLinesColor.EditValueChanged += new System.EventHandler(this.ceGridLinesColor_EditValueChanged);
            // 
            // seLineWidth
            // 
            resources.ApplyResources(this.seLineWidth, "seLineWidth");
            this.seLineWidth.Name = "seLineWidth";
            this.seLineWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seLineWidth.Properties.Buttons"))))});
            this.seLineWidth.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seLineWidth.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seLineWidth.EditValueChanged += new System.EventHandler(this.seLineWidth_EditValueChanged);
            // 
            // ceLineColor
            // 
            resources.ApplyResources(this.ceLineColor, "ceLineColor");
            this.ceLineColor.Name = "ceLineColor";
            this.ceLineColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ceLineColor.Properties.Buttons"))))});
            this.ceLineColor.EditValueChanged += new System.EventHandler(this.ceLineColor_EditValueChanged);
            // 
            // lblTickmarkMinorCount
            // 
            this.lblTickmarkMinorCount.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblTickmarkMinorCount.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblTickmarkMinorCount, "lblTickmarkMinorCount");
            this.lblTickmarkMinorCount.Name = "lblTickmarkMinorCount";
            // 
            // lblGridLinesStyles
            // 
            this.lblGridLinesStyles.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblGridLinesStyles, "lblGridLinesStyles");
            this.lblGridLinesStyles.Name = "lblGridLinesStyles";
            // 
            // lblGridLinesColor
            // 
            this.lblGridLinesColor.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblGridLinesColor, "lblGridLinesColor");
            this.lblGridLinesColor.Name = "lblGridLinesColor";
            // 
            // lblLineWidth
            // 
            this.lblLineWidth.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblLineWidth, "lblLineWidth");
            this.lblLineWidth.Name = "lblLineWidth";
            // 
            // lblLineColor
            // 
            this.lblLineColor.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblLineColor, "lblLineColor");
            this.lblLineColor.Name = "lblLineColor";
            // 
            // AxisSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcMain);
            this.Name = "AxisSettings";
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            this.gcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbReverse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTickmarkMinorCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceValueLabelStaggeredStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beValueLabelFont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seValueLabelAngle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGridLinesVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGridLinesStyles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceGridLinesColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLineWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLineColor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcMain;
        private DevExpress.XtraEditors.ColorEdit ceLineColor;
        private DevExpress.XtraEditors.LabelControl lblLineColor;
        private DevExpress.XtraEditors.ColorEdit ceGridLinesColor;
        private DevExpress.XtraEditors.LabelControl lblGridLinesColor;
        private DevExpress.XtraEditors.SpinEdit seLineWidth;
        private DevExpress.XtraEditors.LabelControl lblLineWidth;
        private DevExpress.XtraEditors.LabelControl lblGridLinesStyles;
        private DevExpress.XtraEditors.ComboBoxEdit cbGridLinesStyles;
        private DevExpress.XtraEditors.CheckEdit cbGridLinesVisible;
        private DevExpress.XtraEditors.SpinEdit seValueLabelAngle;
        private DevExpress.XtraEditors.LabelControl lblValueLabelAngle;
        private DevExpress.XtraEditors.CheckEdit ceValueLabelStaggeredStyle;
        private DevExpress.XtraEditors.ButtonEdit beValueLabelFont;
        private DevExpress.XtraEditors.LabelControl lblValueLabelFont;
        private DevExpress.XtraEditors.SpinEdit seTickmarkMinorCount;
        private DevExpress.XtraEditors.LabelControl lblTickmarkMinorCount;
        private TitleSettings titleTitle;
        private DevExpress.XtraEditors.CheckEdit cbReverse;
    }
}
