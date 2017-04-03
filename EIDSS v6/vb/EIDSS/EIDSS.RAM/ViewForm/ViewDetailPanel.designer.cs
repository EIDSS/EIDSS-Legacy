namespace eidss.avr.ViewForm
{
    partial class ViewDetailPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

      

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDetailPanel));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grcMain = new DevExpress.XtraEditors.GroupControl();
            this.grcSettings = new DevExpress.XtraEditors.GroupControl();
            this.cbAggregate = new DevExpress.XtraEditors.LookUpEdit();
            this.cbMapDefAdminUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.cbMapDefDataGradient = new DevExpress.XtraEditors.LookUpEdit();
            this.cbMapDefDataChart = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cbChartDefSeries = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblNumerator = new System.Windows.Forms.Label();
            this.lblDenominator = new System.Windows.Forms.Label();
            this.cbColumn = new DevExpress.XtraEditors.LookUpEdit();
            this.lblColumn = new System.Windows.Forms.Label();
            this.cbDenominator = new DevExpress.XtraEditors.LookUpEdit();
            this.btRefreshDataButton = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonsImageList = new System.Windows.Forms.ImageList(this.components);
            this.btOpenMapButton = new DevExpress.XtraEditors.SimpleButton();
            this.btOpenChartButton = new DevExpress.XtraEditors.SimpleButton();
            this.btResetViewButton = new DevExpress.XtraEditors.SimpleButton();
            this.spinPrecision = new DevExpress.XtraEditors.SpinEdit();
            this.lblChartDefXaxis = new System.Windows.Forms.Label();
            this.lblMapDefAdminUnit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMapDefData = new System.Windows.Forms.Label();
            this.lblChartDefSeries = new System.Windows.Forms.Label();
            this.lblAggregate = new System.Windows.Forms.Label();
            this.tbAggregateColumnName = new DevExpress.XtraEditors.TextEdit();
            this.lblParameters = new System.Windows.Forms.Label();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.lblForColumn = new System.Windows.Forms.Label();
            this.cbChartDefXaxis = new DevExpress.XtraEditors.LookUpEdit();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            this.grcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSettings)).BeginInit();
            this.grcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAggregate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMapDefAdminUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMapDefDataGradient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMapDefDataChart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChartDefSeries.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbColumn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDenominator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrecision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAggregateColumnName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChartDefXaxis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ViewDetailPanel), out resources);
            // Form Is Localizable: True
            // 
            // grcMain
            // 
            resources.ApplyResources(this.grcMain, "grcMain");
            this.grcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcMain.Controls.Add(this.grcSettings);
            this.grcMain.Controls.Add(this.grid);
            this.grcMain.Name = "grcMain";
            this.grcMain.ShowCaption = false;
            // 
            // grcSettings
            // 
            resources.ApplyResources(this.grcSettings, "grcSettings");
            this.grcSettings.Controls.Add(this.cbAggregate);
            this.grcSettings.Controls.Add(this.cbMapDefAdminUnit);
            this.grcSettings.Controls.Add(this.cbMapDefDataGradient);
            this.grcSettings.Controls.Add(this.cbMapDefDataChart);
            this.grcSettings.Controls.Add(this.cbChartDefSeries);
            this.grcSettings.Controls.Add(this.lblNumerator);
            this.grcSettings.Controls.Add(this.lblDenominator);
            this.grcSettings.Controls.Add(this.cbColumn);
            this.grcSettings.Controls.Add(this.lblColumn);
            this.grcSettings.Controls.Add(this.cbDenominator);
            this.grcSettings.Controls.Add(this.btRefreshDataButton);
            this.grcSettings.Controls.Add(this.btOpenMapButton);
            this.grcSettings.Controls.Add(this.btOpenChartButton);
            this.grcSettings.Controls.Add(this.btResetViewButton);
            this.grcSettings.Controls.Add(this.spinPrecision);
            this.grcSettings.Controls.Add(this.lblChartDefXaxis);
            this.grcSettings.Controls.Add(this.lblMapDefAdminUnit);
            this.grcSettings.Controls.Add(this.label1);
            this.grcSettings.Controls.Add(this.lblMapDefData);
            this.grcSettings.Controls.Add(this.lblChartDefSeries);
            this.grcSettings.Controls.Add(this.lblAggregate);
            this.grcSettings.Controls.Add(this.tbAggregateColumnName);
            this.grcSettings.Controls.Add(this.lblParameters);
            this.grcSettings.Controls.Add(this.lblPrecision);
            this.grcSettings.Controls.Add(this.lblForColumn);
            this.grcSettings.Controls.Add(this.cbChartDefXaxis);
            this.grcSettings.Name = "grcSettings";
            this.grcSettings.ShowCaption = false;
            // 
            // cbAggregate
            // 
            resources.ApplyResources(this.cbAggregate, "cbAggregate");
            this.cbAggregate.Name = "cbAggregate";
            this.cbAggregate.Properties.AccessibleDescription = resources.GetString("cbAggregate.Properties.AccessibleDescription");
            this.cbAggregate.Properties.AccessibleName = resources.GetString("cbAggregate.Properties.AccessibleName");
            this.cbAggregate.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("cbAggregate.Properties.Appearance.FontSizeDelta")));
            this.cbAggregate.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbAggregate.Properties.Appearance.FontStyleDelta")));
            this.cbAggregate.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAggregate.Properties.Appearance.GradientMode")));
            this.cbAggregate.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cbAggregate.Properties.Appearance.Image")));
            this.cbAggregate.Properties.Appearance.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("cbAggregate.Properties.AppearanceDisabled.FontSizeDelta")));
            this.cbAggregate.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbAggregate.Properties.AppearanceDisabled.FontStyleDelta")));
            this.cbAggregate.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAggregate.Properties.AppearanceDisabled.GradientMode")));
            this.cbAggregate.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cbAggregate.Properties.AppearanceDisabled.Image")));
            this.cbAggregate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("cbAggregate.Properties.AppearanceDropDown.FontSizeDelta")));
            this.cbAggregate.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbAggregate.Properties.AppearanceDropDown.FontStyleDelta")));
            this.cbAggregate.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAggregate.Properties.AppearanceDropDown.GradientMode")));
            this.cbAggregate.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cbAggregate.Properties.AppearanceDropDown.Image")));
            this.cbAggregate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("cbAggregate.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.cbAggregate.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbAggregate.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.cbAggregate.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAggregate.Properties.AppearanceDropDownHeader.GradientMode")));
            this.cbAggregate.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("cbAggregate.Properties.AppearanceDropDownHeader.Image")));
            this.cbAggregate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("cbAggregate.Properties.AppearanceFocused.FontSizeDelta")));
            this.cbAggregate.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbAggregate.Properties.AppearanceFocused.FontStyleDelta")));
            this.cbAggregate.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAggregate.Properties.AppearanceFocused.GradientMode")));
            this.cbAggregate.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("cbAggregate.Properties.AppearanceFocused.Image")));
            this.cbAggregate.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbAggregate.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("cbAggregate.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.cbAggregate.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbAggregate.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.cbAggregate.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbAggregate.Properties.AppearanceReadOnly.GradientMode")));
            this.cbAggregate.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("cbAggregate.Properties.AppearanceReadOnly.Image")));
            this.cbAggregate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbAggregate.Properties.AutoHeight = ((bool)(resources.GetObject("cbAggregate.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject7, "serializableAppearanceObject7");
            serializableAppearanceObject7.Options.UseFont = true;
            this.cbAggregate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbAggregate.Properties.Buttons"))), resources.GetString("cbAggregate.Properties.Buttons1"), ((int)(resources.GetObject("cbAggregate.Properties.Buttons2"))), ((bool)(resources.GetObject("cbAggregate.Properties.Buttons3"))), ((bool)(resources.GetObject("cbAggregate.Properties.Buttons4"))), ((bool)(resources.GetObject("cbAggregate.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbAggregate.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbAggregate.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, resources.GetString("cbAggregate.Properties.Buttons8"), ((object)(resources.GetObject("cbAggregate.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbAggregate.Properties.Buttons10"))), ((bool)(resources.GetObject("cbAggregate.Properties.Buttons11"))))});
            this.cbAggregate.Properties.DropDownRows = 13;
            this.cbAggregate.Properties.NullText = resources.GetString("cbAggregate.Properties.NullText");
            this.cbAggregate.Properties.NullValuePrompt = resources.GetString("cbAggregate.Properties.NullValuePrompt");
            this.cbAggregate.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbAggregate.Properties.NullValuePromptShowForEmptyValue")));
            this.cbAggregate.Properties.PopupWidth = 200;
            // 
            // cbMapDefAdminUnit
            // 
            resources.ApplyResources(this.cbMapDefAdminUnit, "cbMapDefAdminUnit");
            this.cbMapDefAdminUnit.Name = "cbMapDefAdminUnit";
            this.cbMapDefAdminUnit.Properties.AccessibleDescription = resources.GetString("cbMapDefAdminUnit.Properties.AccessibleDescription");
            this.cbMapDefAdminUnit.Properties.AccessibleName = resources.GetString("cbMapDefAdminUnit.Properties.AccessibleName");
            this.cbMapDefAdminUnit.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("cbMapDefAdminUnit.Properties.Appearance.FontSizeDelta")));
            this.cbMapDefAdminUnit.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefAdminUnit.Properties.Appearance.FontStyleDelta")));
            this.cbMapDefAdminUnit.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefAdminUnit.Properties.Appearance.GradientMode")));
            this.cbMapDefAdminUnit.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefAdminUnit.Properties.Appearance.Image")));
            this.cbMapDefAdminUnit.Properties.Appearance.Options.UseFont = true;
            this.cbMapDefAdminUnit.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDisabled.FontSizeDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDisabled.FontStyleDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDisabled.GradientMode")));
            this.cbMapDefAdminUnit.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDisabled.Image")));
            this.cbMapDefAdminUnit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbMapDefAdminUnit.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDropDown.FontSizeDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDropDown.FontStyleDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDropDown.GradientMode")));
            this.cbMapDefAdminUnit.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDropDown.Image")));
            this.cbMapDefAdminUnit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.GradientMode")));
            this.cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.Image")));
            this.cbMapDefAdminUnit.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbMapDefAdminUnit.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceFocused.FontSizeDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceFocused.FontStyleDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceFocused.GradientMode")));
            this.cbMapDefAdminUnit.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceFocused.Image")));
            this.cbMapDefAdminUnit.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbMapDefAdminUnit.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.cbMapDefAdminUnit.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceReadOnly.GradientMode")));
            this.cbMapDefAdminUnit.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefAdminUnit.Properties.AppearanceReadOnly.Image")));
            this.cbMapDefAdminUnit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbMapDefAdminUnit.Properties.AutoHeight = ((bool)(resources.GetObject("cbMapDefAdminUnit.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseFont = true;
            this.cbMapDefAdminUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons"))), resources.GetString("cbMapDefAdminUnit.Properties.Buttons1"), ((int)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons2"))), ((bool)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons3"))), ((bool)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons4"))), ((bool)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("cbMapDefAdminUnit.Properties.Buttons8"), ((object)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons10"))), ((bool)(resources.GetObject("cbMapDefAdminUnit.Properties.Buttons11"))))});
            this.cbMapDefAdminUnit.Properties.DropDownRows = 13;
            this.cbMapDefAdminUnit.Properties.NullText = resources.GetString("cbMapDefAdminUnit.Properties.NullText");
            this.cbMapDefAdminUnit.Properties.NullValuePrompt = resources.GetString("cbMapDefAdminUnit.Properties.NullValuePrompt");
            this.cbMapDefAdminUnit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbMapDefAdminUnit.Properties.NullValuePromptShowForEmptyValue")));
            this.cbMapDefAdminUnit.Properties.PopupWidth = 200;
            // 
            // cbMapDefDataGradient
            // 
            resources.ApplyResources(this.cbMapDefDataGradient, "cbMapDefDataGradient");
            this.cbMapDefDataGradient.Name = "cbMapDefDataGradient";
            this.cbMapDefDataGradient.Properties.AccessibleDescription = resources.GetString("cbMapDefDataGradient.Properties.AccessibleDescription");
            this.cbMapDefDataGradient.Properties.AccessibleName = resources.GetString("cbMapDefDataGradient.Properties.AccessibleName");
            this.cbMapDefDataGradient.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("cbMapDefDataGradient.Properties.Appearance.FontSizeDelta")));
            this.cbMapDefDataGradient.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefDataGradient.Properties.Appearance.FontStyleDelta")));
            this.cbMapDefDataGradient.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefDataGradient.Properties.Appearance.GradientMode")));
            this.cbMapDefDataGradient.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefDataGradient.Properties.Appearance.Image")));
            this.cbMapDefDataGradient.Properties.Appearance.Options.UseFont = true;
            this.cbMapDefDataGradient.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDisabled.FontSizeDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDisabled.FontStyleDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDisabled.GradientMode")));
            this.cbMapDefDataGradient.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDisabled.Image")));
            this.cbMapDefDataGradient.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbMapDefDataGradient.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDropDown.FontSizeDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDropDown.FontStyleDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDropDown.GradientMode")));
            this.cbMapDefDataGradient.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDropDown.Image")));
            this.cbMapDefDataGradient.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbMapDefDataGradient.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDropDownHeader.GradientMode")));
            this.cbMapDefDataGradient.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceDropDownHeader.Image")));
            this.cbMapDefDataGradient.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbMapDefDataGradient.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceFocused.FontSizeDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceFocused.FontStyleDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceFocused.GradientMode")));
            this.cbMapDefDataGradient.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceFocused.Image")));
            this.cbMapDefDataGradient.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbMapDefDataGradient.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.cbMapDefDataGradient.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceReadOnly.GradientMode")));
            this.cbMapDefDataGradient.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("cbMapDefDataGradient.Properties.AppearanceReadOnly.Image")));
            this.cbMapDefDataGradient.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbMapDefDataGradient.Properties.AutoHeight = ((bool)(resources.GetObject("cbMapDefDataGradient.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject2, "serializableAppearanceObject2");
            serializableAppearanceObject2.Options.UseFont = true;
            this.cbMapDefDataGradient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons"))), resources.GetString("cbMapDefDataGradient.Properties.Buttons1"), ((int)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons2"))), ((bool)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons3"))), ((bool)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons4"))), ((bool)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("cbMapDefDataGradient.Properties.Buttons8"), ((object)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons10"))), ((bool)(resources.GetObject("cbMapDefDataGradient.Properties.Buttons11"))))});
            this.cbMapDefDataGradient.Properties.DropDownRows = 13;
            this.cbMapDefDataGradient.Properties.NullText = resources.GetString("cbMapDefDataGradient.Properties.NullText");
            this.cbMapDefDataGradient.Properties.NullValuePrompt = resources.GetString("cbMapDefDataGradient.Properties.NullValuePrompt");
            this.cbMapDefDataGradient.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbMapDefDataGradient.Properties.NullValuePromptShowForEmptyValue")));
            this.cbMapDefDataGradient.Properties.PopupWidth = 200;
            // 
            // cbMapDefDataChart
            // 
            resources.ApplyResources(this.cbMapDefDataChart, "cbMapDefDataChart");
            this.cbMapDefDataChart.Name = "cbMapDefDataChart";
            this.cbMapDefDataChart.Properties.AccessibleDescription = resources.GetString("cbMapDefDataChart.Properties.AccessibleDescription");
            this.cbMapDefDataChart.Properties.AccessibleName = resources.GetString("cbMapDefDataChart.Properties.AccessibleName");
            this.cbMapDefDataChart.Properties.AutoHeight = ((bool)(resources.GetObject("cbMapDefDataChart.Properties.AutoHeight")));
            this.cbMapDefDataChart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbMapDefDataChart.Properties.Buttons"))))});
            this.cbMapDefDataChart.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("cbMapDefDataChart.Properties.Mask.AutoComplete")));
            this.cbMapDefDataChart.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("cbMapDefDataChart.Properties.Mask.BeepOnError")));
            this.cbMapDefDataChart.Properties.Mask.EditMask = resources.GetString("cbMapDefDataChart.Properties.Mask.EditMask");
            this.cbMapDefDataChart.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("cbMapDefDataChart.Properties.Mask.IgnoreMaskBlank")));
            this.cbMapDefDataChart.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("cbMapDefDataChart.Properties.Mask.MaskType")));
            this.cbMapDefDataChart.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("cbMapDefDataChart.Properties.Mask.PlaceHolder")));
            this.cbMapDefDataChart.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("cbMapDefDataChart.Properties.Mask.SaveLiteral")));
            this.cbMapDefDataChart.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("cbMapDefDataChart.Properties.Mask.ShowPlaceHolders")));
            this.cbMapDefDataChart.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("cbMapDefDataChart.Properties.Mask.UseMaskAsDisplayFormat")));
            this.cbMapDefDataChart.Properties.NullValuePrompt = resources.GetString("cbMapDefDataChart.Properties.NullValuePrompt");
            this.cbMapDefDataChart.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbMapDefDataChart.Properties.NullValuePromptShowForEmptyValue")));
            this.cbMapDefDataChart.Properties.SelectAllItemVisible = false;
            // 
            // cbChartDefSeries
            // 
            resources.ApplyResources(this.cbChartDefSeries, "cbChartDefSeries");
            this.cbChartDefSeries.Name = "cbChartDefSeries";
            this.cbChartDefSeries.Properties.AccessibleDescription = resources.GetString("cbChartDefSeries.Properties.AccessibleDescription");
            this.cbChartDefSeries.Properties.AccessibleName = resources.GetString("cbChartDefSeries.Properties.AccessibleName");
            this.cbChartDefSeries.Properties.AutoHeight = ((bool)(resources.GetObject("cbChartDefSeries.Properties.AutoHeight")));
            this.cbChartDefSeries.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbChartDefSeries.Properties.Buttons"))))});
            this.cbChartDefSeries.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("cbChartDefSeries.Properties.Mask.AutoComplete")));
            this.cbChartDefSeries.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("cbChartDefSeries.Properties.Mask.BeepOnError")));
            this.cbChartDefSeries.Properties.Mask.EditMask = resources.GetString("cbChartDefSeries.Properties.Mask.EditMask");
            this.cbChartDefSeries.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("cbChartDefSeries.Properties.Mask.IgnoreMaskBlank")));
            this.cbChartDefSeries.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("cbChartDefSeries.Properties.Mask.MaskType")));
            this.cbChartDefSeries.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("cbChartDefSeries.Properties.Mask.PlaceHolder")));
            this.cbChartDefSeries.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("cbChartDefSeries.Properties.Mask.SaveLiteral")));
            this.cbChartDefSeries.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("cbChartDefSeries.Properties.Mask.ShowPlaceHolders")));
            this.cbChartDefSeries.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("cbChartDefSeries.Properties.Mask.UseMaskAsDisplayFormat")));
            this.cbChartDefSeries.Properties.NullValuePrompt = resources.GetString("cbChartDefSeries.Properties.NullValuePrompt");
            this.cbChartDefSeries.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbChartDefSeries.Properties.NullValuePromptShowForEmptyValue")));
            this.cbChartDefSeries.Properties.SelectAllItemVisible = false;
            // 
            // lblNumerator
            // 
            resources.ApplyResources(this.lblNumerator, "lblNumerator");
            this.lblNumerator.Name = "lblNumerator";
            // 
            // lblDenominator
            // 
            resources.ApplyResources(this.lblDenominator, "lblDenominator");
            this.lblDenominator.Name = "lblDenominator";
            // 
            // cbColumn
            // 
            resources.ApplyResources(this.cbColumn, "cbColumn");
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Properties.AccessibleDescription = resources.GetString("cbColumn.Properties.AccessibleDescription");
            this.cbColumn.Properties.AccessibleName = resources.GetString("cbColumn.Properties.AccessibleName");
            this.cbColumn.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("cbColumn.Properties.Appearance.FontSizeDelta")));
            this.cbColumn.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbColumn.Properties.Appearance.FontStyleDelta")));
            this.cbColumn.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbColumn.Properties.Appearance.GradientMode")));
            this.cbColumn.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cbColumn.Properties.Appearance.Image")));
            this.cbColumn.Properties.Appearance.Options.UseFont = true;
            this.cbColumn.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("cbColumn.Properties.AppearanceDisabled.FontSizeDelta")));
            this.cbColumn.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbColumn.Properties.AppearanceDisabled.FontStyleDelta")));
            this.cbColumn.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbColumn.Properties.AppearanceDisabled.GradientMode")));
            this.cbColumn.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cbColumn.Properties.AppearanceDisabled.Image")));
            this.cbColumn.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbColumn.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("cbColumn.Properties.AppearanceDropDown.FontSizeDelta")));
            this.cbColumn.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbColumn.Properties.AppearanceDropDown.FontStyleDelta")));
            this.cbColumn.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbColumn.Properties.AppearanceDropDown.GradientMode")));
            this.cbColumn.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cbColumn.Properties.AppearanceDropDown.Image")));
            this.cbColumn.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbColumn.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("cbColumn.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.cbColumn.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbColumn.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.cbColumn.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbColumn.Properties.AppearanceDropDownHeader.GradientMode")));
            this.cbColumn.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("cbColumn.Properties.AppearanceDropDownHeader.Image")));
            this.cbColumn.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbColumn.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("cbColumn.Properties.AppearanceFocused.FontSizeDelta")));
            this.cbColumn.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbColumn.Properties.AppearanceFocused.FontStyleDelta")));
            this.cbColumn.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbColumn.Properties.AppearanceFocused.GradientMode")));
            this.cbColumn.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("cbColumn.Properties.AppearanceFocused.Image")));
            this.cbColumn.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbColumn.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("cbColumn.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.cbColumn.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbColumn.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.cbColumn.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbColumn.Properties.AppearanceReadOnly.GradientMode")));
            this.cbColumn.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("cbColumn.Properties.AppearanceReadOnly.Image")));
            this.cbColumn.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbColumn.Properties.AutoHeight = ((bool)(resources.GetObject("cbColumn.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject3, "serializableAppearanceObject3");
            serializableAppearanceObject3.Options.UseFont = true;
            this.cbColumn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbColumn.Properties.Buttons"))), resources.GetString("cbColumn.Properties.Buttons1"), ((int)(resources.GetObject("cbColumn.Properties.Buttons2"))), ((bool)(resources.GetObject("cbColumn.Properties.Buttons3"))), ((bool)(resources.GetObject("cbColumn.Properties.Buttons4"))), ((bool)(resources.GetObject("cbColumn.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbColumn.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbColumn.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, resources.GetString("cbColumn.Properties.Buttons8"), ((object)(resources.GetObject("cbColumn.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbColumn.Properties.Buttons10"))), ((bool)(resources.GetObject("cbColumn.Properties.Buttons11"))))});
            this.cbColumn.Properties.DropDownRows = 5;
            this.cbColumn.Properties.NullText = resources.GetString("cbColumn.Properties.NullText");
            this.cbColumn.Properties.NullValuePrompt = resources.GetString("cbColumn.Properties.NullValuePrompt");
            this.cbColumn.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbColumn.Properties.NullValuePromptShowForEmptyValue")));
            this.cbColumn.Properties.PopupWidth = 200;
            // 
            // lblColumn
            // 
            resources.ApplyResources(this.lblColumn, "lblColumn");
            this.lblColumn.Name = "lblColumn";
            // 
            // cbDenominator
            // 
            resources.ApplyResources(this.cbDenominator, "cbDenominator");
            this.cbDenominator.Name = "cbDenominator";
            this.cbDenominator.Properties.AccessibleDescription = resources.GetString("cbDenominator.Properties.AccessibleDescription");
            this.cbDenominator.Properties.AccessibleName = resources.GetString("cbDenominator.Properties.AccessibleName");
            this.cbDenominator.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("cbDenominator.Properties.Appearance.FontSizeDelta")));
            this.cbDenominator.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbDenominator.Properties.Appearance.FontStyleDelta")));
            this.cbDenominator.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbDenominator.Properties.Appearance.GradientMode")));
            this.cbDenominator.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cbDenominator.Properties.Appearance.Image")));
            this.cbDenominator.Properties.Appearance.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("cbDenominator.Properties.AppearanceDisabled.FontSizeDelta")));
            this.cbDenominator.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbDenominator.Properties.AppearanceDisabled.FontStyleDelta")));
            this.cbDenominator.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbDenominator.Properties.AppearanceDisabled.GradientMode")));
            this.cbDenominator.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cbDenominator.Properties.AppearanceDisabled.Image")));
            this.cbDenominator.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("cbDenominator.Properties.AppearanceDropDown.FontSizeDelta")));
            this.cbDenominator.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbDenominator.Properties.AppearanceDropDown.FontStyleDelta")));
            this.cbDenominator.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbDenominator.Properties.AppearanceDropDown.GradientMode")));
            this.cbDenominator.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cbDenominator.Properties.AppearanceDropDown.Image")));
            this.cbDenominator.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("cbDenominator.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.cbDenominator.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbDenominator.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.cbDenominator.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbDenominator.Properties.AppearanceDropDownHeader.GradientMode")));
            this.cbDenominator.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("cbDenominator.Properties.AppearanceDropDownHeader.Image")));
            this.cbDenominator.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("cbDenominator.Properties.AppearanceFocused.FontSizeDelta")));
            this.cbDenominator.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbDenominator.Properties.AppearanceFocused.FontStyleDelta")));
            this.cbDenominator.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbDenominator.Properties.AppearanceFocused.GradientMode")));
            this.cbDenominator.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("cbDenominator.Properties.AppearanceFocused.Image")));
            this.cbDenominator.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbDenominator.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("cbDenominator.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.cbDenominator.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbDenominator.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.cbDenominator.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbDenominator.Properties.AppearanceReadOnly.GradientMode")));
            this.cbDenominator.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("cbDenominator.Properties.AppearanceReadOnly.Image")));
            this.cbDenominator.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbDenominator.Properties.AutoHeight = ((bool)(resources.GetObject("cbDenominator.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject4, "serializableAppearanceObject4");
            serializableAppearanceObject4.Options.UseFont = true;
            this.cbDenominator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbDenominator.Properties.Buttons"))), resources.GetString("cbDenominator.Properties.Buttons1"), ((int)(resources.GetObject("cbDenominator.Properties.Buttons2"))), ((bool)(resources.GetObject("cbDenominator.Properties.Buttons3"))), ((bool)(resources.GetObject("cbDenominator.Properties.Buttons4"))), ((bool)(resources.GetObject("cbDenominator.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbDenominator.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbDenominator.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, resources.GetString("cbDenominator.Properties.Buttons8"), ((object)(resources.GetObject("cbDenominator.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbDenominator.Properties.Buttons10"))), ((bool)(resources.GetObject("cbDenominator.Properties.Buttons11"))))});
            this.cbDenominator.Properties.DropDownRows = 5;
            this.cbDenominator.Properties.NullText = resources.GetString("cbDenominator.Properties.NullText");
            this.cbDenominator.Properties.NullValuePrompt = resources.GetString("cbDenominator.Properties.NullValuePrompt");
            this.cbDenominator.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbDenominator.Properties.NullValuePromptShowForEmptyValue")));
            this.cbDenominator.Properties.PopupWidth = 200;
            // 
            // btRefreshDataButton
            // 
            resources.ApplyResources(this.btRefreshDataButton, "btRefreshDataButton");
            this.btRefreshDataButton.ImageIndex = 1;
            this.btRefreshDataButton.ImageList = this.ButtonsImageList;
            this.btRefreshDataButton.Name = "btRefreshDataButton";
            this.btRefreshDataButton.Click += new System.EventHandler(this.RefreshDataButton_Click);
            // 
            // ButtonsImageList
            // 
            this.ButtonsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonsImageList.ImageStream")));
            this.ButtonsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ButtonsImageList.Images.SetKeyName(0, "filter_16x16.png");
            this.ButtonsImageList.Images.SetKeyName(1, "refresh_data_16x16.png");
            this.ButtonsImageList.Images.SetKeyName(2, "chart_editor_16x16.png");
            this.ButtonsImageList.Images.SetKeyName(3, "map_editor_16x16.png");
            // 
            // btOpenMapButton
            // 
            resources.ApplyResources(this.btOpenMapButton, "btOpenMapButton");
            this.btOpenMapButton.ImageIndex = 3;
            this.btOpenMapButton.ImageList = this.ButtonsImageList;
            this.btOpenMapButton.Name = "btOpenMapButton";
            this.btOpenMapButton.Click += new System.EventHandler(this.OpenMapButton_Click);
            // 
            // btOpenChartButton
            // 
            resources.ApplyResources(this.btOpenChartButton, "btOpenChartButton");
            this.btOpenChartButton.ImageIndex = 2;
            this.btOpenChartButton.ImageList = this.ButtonsImageList;
            this.btOpenChartButton.Name = "btOpenChartButton";
            this.btOpenChartButton.Click += new System.EventHandler(this.OpenChartButton_Click);
            // 
            // btResetViewButton
            // 
            resources.ApplyResources(this.btResetViewButton, "btResetViewButton");
            this.btResetViewButton.ImageList = this.ButtonsImageList;
            this.btResetViewButton.Name = "btResetViewButton";
            this.btResetViewButton.Click += new System.EventHandler(this.ResetViewButton_Click);
            // 
            // spinPrecision
            // 
            resources.ApplyResources(this.spinPrecision, "spinPrecision");
            this.spinPrecision.Name = "spinPrecision";
            this.spinPrecision.Properties.AccessibleDescription = resources.GetString("spinPrecision.Properties.AccessibleDescription");
            this.spinPrecision.Properties.AccessibleName = resources.GetString("spinPrecision.Properties.AccessibleName");
            this.spinPrecision.Properties.AutoHeight = ((bool)(resources.GetObject("spinPrecision.Properties.AutoHeight")));
            this.spinPrecision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("spinPrecision.Properties.Buttons"))))});
            this.spinPrecision.Properties.IsFloatValue = false;
            this.spinPrecision.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("spinPrecision.Properties.Mask.AutoComplete")));
            this.spinPrecision.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("spinPrecision.Properties.Mask.BeepOnError")));
            this.spinPrecision.Properties.Mask.EditMask = resources.GetString("spinPrecision.Properties.Mask.EditMask");
            this.spinPrecision.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("spinPrecision.Properties.Mask.IgnoreMaskBlank")));
            this.spinPrecision.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spinPrecision.Properties.Mask.MaskType")));
            this.spinPrecision.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("spinPrecision.Properties.Mask.PlaceHolder")));
            this.spinPrecision.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("spinPrecision.Properties.Mask.SaveLiteral")));
            this.spinPrecision.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("spinPrecision.Properties.Mask.ShowPlaceHolders")));
            this.spinPrecision.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("spinPrecision.Properties.Mask.UseMaskAsDisplayFormat")));
            this.spinPrecision.Properties.MaxValue = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.spinPrecision.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinPrecision.Properties.NullText = resources.GetString("spinPrecision.Properties.NullText");
            this.spinPrecision.Properties.NullValuePrompt = resources.GetString("spinPrecision.Properties.NullValuePrompt");
            this.spinPrecision.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("spinPrecision.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblChartDefXaxis
            // 
            resources.ApplyResources(this.lblChartDefXaxis, "lblChartDefXaxis");
            this.lblChartDefXaxis.Name = "lblChartDefXaxis";
            // 
            // lblMapDefAdminUnit
            // 
            resources.ApplyResources(this.lblMapDefAdminUnit, "lblMapDefAdminUnit");
            this.lblMapDefAdminUnit.Name = "lblMapDefAdminUnit";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblMapDefData
            // 
            resources.ApplyResources(this.lblMapDefData, "lblMapDefData");
            this.lblMapDefData.Name = "lblMapDefData";
            // 
            // lblChartDefSeries
            // 
            resources.ApplyResources(this.lblChartDefSeries, "lblChartDefSeries");
            this.lblChartDefSeries.Name = "lblChartDefSeries";
            // 
            // lblAggregate
            // 
            resources.ApplyResources(this.lblAggregate, "lblAggregate");
            this.lblAggregate.Name = "lblAggregate";
            // 
            // tbAggregateColumnName
            // 
            resources.ApplyResources(this.tbAggregateColumnName, "tbAggregateColumnName");
            this.tbAggregateColumnName.Name = "tbAggregateColumnName";
            this.tbAggregateColumnName.Properties.AccessibleDescription = resources.GetString("tbAggregateColumnName.Properties.AccessibleDescription");
            this.tbAggregateColumnName.Properties.AccessibleName = resources.GetString("tbAggregateColumnName.Properties.AccessibleName");
            this.tbAggregateColumnName.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("tbAggregateColumnName.Properties.Appearance.FontSizeDelta")));
            this.tbAggregateColumnName.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tbAggregateColumnName.Properties.Appearance.FontStyleDelta")));
            this.tbAggregateColumnName.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tbAggregateColumnName.Properties.Appearance.GradientMode")));
            this.tbAggregateColumnName.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("tbAggregateColumnName.Properties.Appearance.Image")));
            this.tbAggregateColumnName.Properties.Appearance.Options.UseFont = true;
            this.tbAggregateColumnName.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceDisabled.FontSizeDelta")));
            this.tbAggregateColumnName.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceDisabled.FontStyleDelta")));
            this.tbAggregateColumnName.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceDisabled.GradientMode")));
            this.tbAggregateColumnName.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceDisabled.Image")));
            this.tbAggregateColumnName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.tbAggregateColumnName.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceFocused.FontSizeDelta")));
            this.tbAggregateColumnName.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceFocused.FontStyleDelta")));
            this.tbAggregateColumnName.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceFocused.GradientMode")));
            this.tbAggregateColumnName.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceFocused.Image")));
            this.tbAggregateColumnName.Properties.AppearanceFocused.Options.UseFont = true;
            this.tbAggregateColumnName.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.tbAggregateColumnName.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.tbAggregateColumnName.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceReadOnly.GradientMode")));
            this.tbAggregateColumnName.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("tbAggregateColumnName.Properties.AppearanceReadOnly.Image")));
            this.tbAggregateColumnName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.tbAggregateColumnName.Properties.AutoHeight = ((bool)(resources.GetObject("tbAggregateColumnName.Properties.AutoHeight")));
            this.tbAggregateColumnName.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("tbAggregateColumnName.Properties.Mask.AutoComplete")));
            this.tbAggregateColumnName.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("tbAggregateColumnName.Properties.Mask.BeepOnError")));
            this.tbAggregateColumnName.Properties.Mask.EditMask = resources.GetString("tbAggregateColumnName.Properties.Mask.EditMask");
            this.tbAggregateColumnName.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("tbAggregateColumnName.Properties.Mask.IgnoreMaskBlank")));
            this.tbAggregateColumnName.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("tbAggregateColumnName.Properties.Mask.MaskType")));
            this.tbAggregateColumnName.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("tbAggregateColumnName.Properties.Mask.PlaceHolder")));
            this.tbAggregateColumnName.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("tbAggregateColumnName.Properties.Mask.SaveLiteral")));
            this.tbAggregateColumnName.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("tbAggregateColumnName.Properties.Mask.ShowPlaceHolders")));
            this.tbAggregateColumnName.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("tbAggregateColumnName.Properties.Mask.UseMaskAsDisplayFormat")));
            this.tbAggregateColumnName.Properties.NullValuePrompt = resources.GetString("tbAggregateColumnName.Properties.NullValuePrompt");
            this.tbAggregateColumnName.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("tbAggregateColumnName.Properties.NullValuePromptShowForEmptyValue")));
            this.tbAggregateColumnName.Properties.ReadOnly = true;
            this.tbAggregateColumnName.Tag = "{R}";
            // 
            // lblParameters
            // 
            resources.ApplyResources(this.lblParameters, "lblParameters");
            this.lblParameters.Name = "lblParameters";
            // 
            // lblPrecision
            // 
            resources.ApplyResources(this.lblPrecision, "lblPrecision");
            this.lblPrecision.Name = "lblPrecision";
            // 
            // lblForColumn
            // 
            resources.ApplyResources(this.lblForColumn, "lblForColumn");
            this.lblForColumn.Name = "lblForColumn";
            // 
            // cbChartDefXaxis
            // 
            resources.ApplyResources(this.cbChartDefXaxis, "cbChartDefXaxis");
            this.cbChartDefXaxis.Name = "cbChartDefXaxis";
            this.cbChartDefXaxis.Properties.AccessibleDescription = resources.GetString("cbChartDefXaxis.Properties.AccessibleDescription");
            this.cbChartDefXaxis.Properties.AccessibleName = resources.GetString("cbChartDefXaxis.Properties.AccessibleName");
            this.cbChartDefXaxis.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("cbChartDefXaxis.Properties.Appearance.FontSizeDelta")));
            this.cbChartDefXaxis.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbChartDefXaxis.Properties.Appearance.FontStyleDelta")));
            this.cbChartDefXaxis.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbChartDefXaxis.Properties.Appearance.GradientMode")));
            this.cbChartDefXaxis.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cbChartDefXaxis.Properties.Appearance.Image")));
            this.cbChartDefXaxis.Properties.Appearance.Options.UseFont = true;
            this.cbChartDefXaxis.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDisabled.FontSizeDelta")));
            this.cbChartDefXaxis.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDisabled.FontStyleDelta")));
            this.cbChartDefXaxis.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDisabled.GradientMode")));
            this.cbChartDefXaxis.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDisabled.Image")));
            this.cbChartDefXaxis.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbChartDefXaxis.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDropDown.FontSizeDelta")));
            this.cbChartDefXaxis.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDropDown.FontStyleDelta")));
            this.cbChartDefXaxis.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDropDown.GradientMode")));
            this.cbChartDefXaxis.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDropDown.Image")));
            this.cbChartDefXaxis.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbChartDefXaxis.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.cbChartDefXaxis.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.cbChartDefXaxis.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDropDownHeader.GradientMode")));
            this.cbChartDefXaxis.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceDropDownHeader.Image")));
            this.cbChartDefXaxis.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbChartDefXaxis.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceFocused.FontSizeDelta")));
            this.cbChartDefXaxis.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceFocused.FontStyleDelta")));
            this.cbChartDefXaxis.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceFocused.GradientMode")));
            this.cbChartDefXaxis.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceFocused.Image")));
            this.cbChartDefXaxis.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbChartDefXaxis.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.cbChartDefXaxis.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.cbChartDefXaxis.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceReadOnly.GradientMode")));
            this.cbChartDefXaxis.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("cbChartDefXaxis.Properties.AppearanceReadOnly.Image")));
            this.cbChartDefXaxis.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbChartDefXaxis.Properties.AutoHeight = ((bool)(resources.GetObject("cbChartDefXaxis.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject5, "serializableAppearanceObject5");
            serializableAppearanceObject5.Options.UseFont = true;
            this.cbChartDefXaxis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbChartDefXaxis.Properties.Buttons"))), resources.GetString("cbChartDefXaxis.Properties.Buttons1"), ((int)(resources.GetObject("cbChartDefXaxis.Properties.Buttons2"))), ((bool)(resources.GetObject("cbChartDefXaxis.Properties.Buttons3"))), ((bool)(resources.GetObject("cbChartDefXaxis.Properties.Buttons4"))), ((bool)(resources.GetObject("cbChartDefXaxis.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbChartDefXaxis.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbChartDefXaxis.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, resources.GetString("cbChartDefXaxis.Properties.Buttons8"), ((object)(resources.GetObject("cbChartDefXaxis.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbChartDefXaxis.Properties.Buttons10"))), ((bool)(resources.GetObject("cbChartDefXaxis.Properties.Buttons11"))))});
            this.cbChartDefXaxis.Properties.DropDownRows = 13;
            this.cbChartDefXaxis.Properties.NullText = resources.GetString("cbChartDefXaxis.Properties.NullText");
            this.cbChartDefXaxis.Properties.NullValuePrompt = resources.GetString("cbChartDefXaxis.Properties.NullValuePrompt");
            this.cbChartDefXaxis.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbChartDefXaxis.Properties.NullValuePromptShowForEmptyValue")));
            this.cbChartDefXaxis.Properties.PopupWidth = 200;
            // 
            // grid
            // 
            resources.ApplyResources(this.grid, "grid");
            this.grid.Cursor = System.Windows.Forms.Cursors.Default;
            this.grid.EmbeddedNavigator.AccessibleDescription = resources.GetString("grid.EmbeddedNavigator.AccessibleDescription");
            this.grid.EmbeddedNavigator.AccessibleName = resources.GetString("grid.EmbeddedNavigator.AccessibleName");
            this.grid.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("grid.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.grid.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("grid.EmbeddedNavigator.Anchor")));
            this.grid.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grid.EmbeddedNavigator.BackgroundImage")));
            this.grid.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("grid.EmbeddedNavigator.BackgroundImageLayout")));
            this.grid.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("grid.EmbeddedNavigator.ImeMode")));
            this.grid.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("grid.EmbeddedNavigator.MaximumSize")));
            this.grid.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("grid.EmbeddedNavigator.TextLocation")));
            this.grid.EmbeddedNavigator.ToolTip = resources.GetString("grid.EmbeddedNavigator.ToolTip");
            this.grid.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("grid.EmbeddedNavigator.ToolTipIconType")));
            this.grid.EmbeddedNavigator.ToolTipTitle = resources.GetString("grid.EmbeddedNavigator.ToolTipTitle");
            this.grid.MainView = this.bandedGridView1;
            this.grid.Name = "grid";
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1,
            this.gridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            resources.ApplyResources(this.bandedGridView1, "bandedGridView1");
            this.bandedGridView1.GridControl = this.grid;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsBehavior.ReadOnly = true;
            this.bandedGridView1.OptionsFilter.AllowFilterEditor = false;
            this.bandedGridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.bandedGridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.bandedGridView1.OptionsMenu.ShowSplitItem = false;
            this.bandedGridView1.OptionsPrint.PrintDetails = true;
            this.bandedGridView1.OptionsPrint.PrintFooter = false;
            this.bandedGridView1.OptionsPrint.PrintGroupFooter = false;
            this.bandedGridView1.OptionsSelection.MultiSelect = true;
            this.bandedGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.bandedGridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.OptionsView.ShowIndicator = false;
            this.bandedGridView1.BandWidthChanged += new DevExpress.XtraGrid.Views.BandedGrid.BandEventHandler(this.bandedGridView1_BandWidthChanged);
            this.bandedGridView1.DragObjectDrop += new DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(this.bandedGridView1_DragObjectDrop);
            this.bandedGridView1.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.bandedGridView1_ColumnWidthChanged);
            this.bandedGridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.bandedGridView1_PopupMenuShowing);
            this.bandedGridView1.EndSorting += new System.EventHandler(this.bandedGridView1_EndSorting);
            this.bandedGridView1.ColumnPositionChanged += new System.EventHandler(this.bandedGridView1_ColumnPositionChanged);
            this.bandedGridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.bandedGridView1_FocusedColumnChanged);
            this.bandedGridView1.ColumnFilterChanged += new System.EventHandler(this.bandedGridView1_ColumnFilterChanged);
            this.bandedGridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.bandedGridView1_CustomUnboundColumnData);
            this.bandedGridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.bandedGridView1_CustomColumnDisplayText);
            this.bandedGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bandedGridView1_MouseDown);
            this.bandedGridView1.Layout += new System.EventHandler(this.bandedGridView1_Layout);
            // 
            // gridBand1
            // 
            resources.ApplyResources(this.gridBand1, "gridBand1");
            this.gridBand1.VisibleIndex = 0;
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView1.OptionsMenu.ShowSplitItem = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.DragObjectDrop += new DevExpress.XtraGrid.Views.Base.DragObjectDropEventHandler(this.bandedGridView1_DragObjectDrop);
            this.gridView1.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.bandedGridView1_ColumnWidthChanged);
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.bandedGridView1_PopupMenuShowing);
            this.gridView1.EndSorting += new System.EventHandler(this.bandedGridView1_EndSorting);
            this.gridView1.ColumnPositionChanged += new System.EventHandler(this.bandedGridView1_ColumnPositionChanged);
            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.bandedGridView1_FocusedColumnChanged);
            this.gridView1.ColumnFilterChanged += new System.EventHandler(this.bandedGridView1_ColumnFilterChanged);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.bandedGridView1_CustomUnboundColumnData);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.bandedGridView1_CustomColumnDisplayText);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bandedGridView1_MouseDown);
            // 
            // ViewDetailPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMain);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "ViewDetailPanel";
            this.Status = bv.common.win.FormStatus.Draft;
            this.Load += new System.EventHandler(this.ViewDetailPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            this.grcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSettings)).EndInit();
            this.grcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbAggregate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMapDefAdminUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMapDefDataGradient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMapDefDataChart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChartDefSeries.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbColumn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDenominator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPrecision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAggregateColumnName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChartDefXaxis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcMain;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraEditors.GroupControl grcSettings;
        private DevExpress.XtraEditors.SpinEdit spinPrecision;
        private System.Windows.Forms.Label lblAggregate;
        private DevExpress.XtraEditors.TextEdit tbAggregateColumnName;
        private System.Windows.Forms.Label lblPrecision;
        private System.Windows.Forms.Label lblForColumn;
        private DevExpress.XtraEditors.LookUpEdit cbAggregate;
        private System.Windows.Forms.Label lblChartDefXaxis;
        private System.Windows.Forms.Label lblMapDefAdminUnit;
        private System.Windows.Forms.Label lblMapDefData;
        private System.Windows.Forms.Label lblChartDefSeries;
        private System.Windows.Forms.Label lblParameters;
        private DevExpress.XtraEditors.SimpleButton btRefreshDataButton;
        private DevExpress.XtraEditors.SimpleButton btResetViewButton;
        private DevExpress.XtraEditors.SimpleButton btOpenMapButton;
        private DevExpress.XtraEditors.SimpleButton btOpenChartButton;
        private DevExpress.XtraEditors.LookUpEdit cbMapDefAdminUnit;
        private DevExpress.XtraEditors.LookUpEdit cbChartDefXaxis;
        private DevExpress.XtraEditors.LookUpEdit cbColumn;
        private System.Windows.Forms.Label lblColumn;
        private DevExpress.XtraEditors.LookUpEdit cbDenominator;
        private System.Windows.Forms.Label lblDenominator;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbChartDefSeries;
        private DevExpress.XtraEditors.LookUpEdit cbMapDefDataGradient;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbMapDefDataChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumerator;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ImageList ButtonsImageList;
        
    }
}