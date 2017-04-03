namespace eidss.winclient.BasicSyndromicSurveillance
{
    sealed partial class BasicSyndromicSurveillanceAggregateHeaderDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicSyndromicSurveillanceAggregateHeaderDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.remoteSqlConnection1 = new bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection();
            this.remoteSqlConnection2 = new bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection();
            this.remoteSqlConnection3 = new bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection();
            this.txtFormID = new DevExpress.XtraEditors.TextEdit();
            this.lblFormID = new DevExpress.XtraEditors.LabelControl();
            this.lblYear = new DevExpress.XtraEditors.LabelControl();
            this.lblDateEntered = new DevExpress.XtraEditors.LabelControl();
            this.lblDateLastSaved = new DevExpress.XtraEditors.LabelControl();
            this.txtCreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.lblCreatedBy = new DevExpress.XtraEditors.LabelControl();
            this.txtSite = new DevExpress.XtraEditors.TextEdit();
            this.lblSite = new DevExpress.XtraEditors.LabelControl();
            this.lblWeek = new DevExpress.XtraEditors.LabelControl();
            this.bppLocation = new eidss.winclient.Location.LocationLookup();
            this.panelDetails = new DevExpress.XtraEditors.PanelControl();
            this.cbYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.leWeek = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDateLastSaved = new DevExpress.XtraEditors.TextEdit();
            this.txtDateEntered = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bppLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateLastSaved.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEntered.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BasicSyndromicSurveillanceAggregateHeaderDetail), out resources);
            // Form Is Localizable: True
            // 
            // remoteSqlConnection1
            // 
            this.remoteSqlConnection1.ConnectionString = null;
            // 
            // remoteSqlConnection2
            // 
            this.remoteSqlConnection2.ConnectionString = null;
            // 
            // remoteSqlConnection3
            // 
            this.remoteSqlConnection3.ConnectionString = null;
            // 
            // txtFormID
            // 
            resources.ApplyResources(this.txtFormID, "txtFormID");
            this.txtFormID.Name = "txtFormID";
            this.txtFormID.Properties.AccessibleDescription = resources.GetString("txtFormID.Properties.AccessibleDescription");
            this.txtFormID.Properties.AccessibleName = resources.GetString("txtFormID.Properties.AccessibleName");
            this.txtFormID.Properties.AutoHeight = ((bool)(resources.GetObject("txtFormID.Properties.AutoHeight")));
            this.txtFormID.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtFormID.Properties.Mask.AutoComplete")));
            this.txtFormID.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtFormID.Properties.Mask.BeepOnError")));
            this.txtFormID.Properties.Mask.EditMask = resources.GetString("txtFormID.Properties.Mask.EditMask");
            this.txtFormID.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtFormID.Properties.Mask.IgnoreMaskBlank")));
            this.txtFormID.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtFormID.Properties.Mask.MaskType")));
            this.txtFormID.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtFormID.Properties.Mask.PlaceHolder")));
            this.txtFormID.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtFormID.Properties.Mask.SaveLiteral")));
            this.txtFormID.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtFormID.Properties.Mask.ShowPlaceHolders")));
            this.txtFormID.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtFormID.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtFormID.Properties.NullValuePrompt = resources.GetString("txtFormID.Properties.NullValuePrompt");
            this.txtFormID.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtFormID.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblFormID
            // 
            resources.ApplyResources(this.lblFormID, "lblFormID");
            this.lblFormID.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblFormID.Appearance.DisabledImage")));
            this.lblFormID.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblFormID.Appearance.FontSizeDelta")));
            this.lblFormID.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblFormID.Appearance.FontStyleDelta")));
            this.lblFormID.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblFormID.Appearance.GradientMode")));
            this.lblFormID.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblFormID.Appearance.HoverImage")));
            this.lblFormID.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblFormID.Appearance.Image")));
            this.lblFormID.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblFormID.Appearance.PressedImage")));
            this.lblFormID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblFormID.Name = "lblFormID";
            // 
            // lblYear
            // 
            resources.ApplyResources(this.lblYear, "lblYear");
            this.lblYear.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblYear.Appearance.DisabledImage")));
            this.lblYear.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblYear.Appearance.FontSizeDelta")));
            this.lblYear.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblYear.Appearance.FontStyleDelta")));
            this.lblYear.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblYear.Appearance.GradientMode")));
            this.lblYear.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblYear.Appearance.HoverImage")));
            this.lblYear.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblYear.Appearance.Image")));
            this.lblYear.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblYear.Appearance.PressedImage")));
            this.lblYear.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblYear.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblYear.Name = "lblYear";
            // 
            // lblDateEntered
            // 
            resources.ApplyResources(this.lblDateEntered, "lblDateEntered");
            this.lblDateEntered.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblDateEntered.Appearance.DisabledImage")));
            this.lblDateEntered.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblDateEntered.Appearance.FontSizeDelta")));
            this.lblDateEntered.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblDateEntered.Appearance.FontStyleDelta")));
            this.lblDateEntered.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblDateEntered.Appearance.GradientMode")));
            this.lblDateEntered.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblDateEntered.Appearance.HoverImage")));
            this.lblDateEntered.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblDateEntered.Appearance.Image")));
            this.lblDateEntered.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblDateEntered.Appearance.PressedImage")));
            this.lblDateEntered.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDateEntered.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDateEntered.Name = "lblDateEntered";
            // 
            // lblDateLastSaved
            // 
            resources.ApplyResources(this.lblDateLastSaved, "lblDateLastSaved");
            this.lblDateLastSaved.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblDateLastSaved.Appearance.DisabledImage")));
            this.lblDateLastSaved.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblDateLastSaved.Appearance.FontSizeDelta")));
            this.lblDateLastSaved.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblDateLastSaved.Appearance.FontStyleDelta")));
            this.lblDateLastSaved.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblDateLastSaved.Appearance.GradientMode")));
            this.lblDateLastSaved.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblDateLastSaved.Appearance.HoverImage")));
            this.lblDateLastSaved.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblDateLastSaved.Appearance.Image")));
            this.lblDateLastSaved.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblDateLastSaved.Appearance.PressedImage")));
            this.lblDateLastSaved.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDateLastSaved.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDateLastSaved.Name = "lblDateLastSaved";
            // 
            // txtCreatedBy
            // 
            resources.ApplyResources(this.txtCreatedBy, "txtCreatedBy");
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.AccessibleDescription = resources.GetString("txtCreatedBy.Properties.AccessibleDescription");
            this.txtCreatedBy.Properties.AccessibleName = resources.GetString("txtCreatedBy.Properties.AccessibleName");
            this.txtCreatedBy.Properties.AutoHeight = ((bool)(resources.GetObject("txtCreatedBy.Properties.AutoHeight")));
            this.txtCreatedBy.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtCreatedBy.Properties.Mask.AutoComplete")));
            this.txtCreatedBy.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtCreatedBy.Properties.Mask.BeepOnError")));
            this.txtCreatedBy.Properties.Mask.EditMask = resources.GetString("txtCreatedBy.Properties.Mask.EditMask");
            this.txtCreatedBy.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtCreatedBy.Properties.Mask.IgnoreMaskBlank")));
            this.txtCreatedBy.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtCreatedBy.Properties.Mask.MaskType")));
            this.txtCreatedBy.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtCreatedBy.Properties.Mask.PlaceHolder")));
            this.txtCreatedBy.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtCreatedBy.Properties.Mask.SaveLiteral")));
            this.txtCreatedBy.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtCreatedBy.Properties.Mask.ShowPlaceHolders")));
            this.txtCreatedBy.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtCreatedBy.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtCreatedBy.Properties.NullValuePrompt = resources.GetString("txtCreatedBy.Properties.NullValuePrompt");
            this.txtCreatedBy.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtCreatedBy.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblCreatedBy
            // 
            resources.ApplyResources(this.lblCreatedBy, "lblCreatedBy");
            this.lblCreatedBy.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCreatedBy.Appearance.DisabledImage")));
            this.lblCreatedBy.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblCreatedBy.Appearance.FontSizeDelta")));
            this.lblCreatedBy.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblCreatedBy.Appearance.FontStyleDelta")));
            this.lblCreatedBy.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCreatedBy.Appearance.GradientMode")));
            this.lblCreatedBy.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCreatedBy.Appearance.HoverImage")));
            this.lblCreatedBy.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCreatedBy.Appearance.Image")));
            this.lblCreatedBy.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCreatedBy.Appearance.PressedImage")));
            this.lblCreatedBy.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCreatedBy.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCreatedBy.Name = "lblCreatedBy";
            // 
            // txtSite
            // 
            resources.ApplyResources(this.txtSite, "txtSite");
            this.txtSite.Name = "txtSite";
            this.txtSite.Properties.AccessibleDescription = resources.GetString("txtSite.Properties.AccessibleDescription");
            this.txtSite.Properties.AccessibleName = resources.GetString("txtSite.Properties.AccessibleName");
            this.txtSite.Properties.AutoHeight = ((bool)(resources.GetObject("txtSite.Properties.AutoHeight")));
            this.txtSite.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtSite.Properties.Mask.AutoComplete")));
            this.txtSite.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtSite.Properties.Mask.BeepOnError")));
            this.txtSite.Properties.Mask.EditMask = resources.GetString("txtSite.Properties.Mask.EditMask");
            this.txtSite.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtSite.Properties.Mask.IgnoreMaskBlank")));
            this.txtSite.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtSite.Properties.Mask.MaskType")));
            this.txtSite.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtSite.Properties.Mask.PlaceHolder")));
            this.txtSite.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtSite.Properties.Mask.SaveLiteral")));
            this.txtSite.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtSite.Properties.Mask.ShowPlaceHolders")));
            this.txtSite.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtSite.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtSite.Properties.NullValuePrompt = resources.GetString("txtSite.Properties.NullValuePrompt");
            this.txtSite.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtSite.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblSite
            // 
            resources.ApplyResources(this.lblSite, "lblSite");
            this.lblSite.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblSite.Appearance.DisabledImage")));
            this.lblSite.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblSite.Appearance.FontSizeDelta")));
            this.lblSite.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblSite.Appearance.FontStyleDelta")));
            this.lblSite.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblSite.Appearance.GradientMode")));
            this.lblSite.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblSite.Appearance.HoverImage")));
            this.lblSite.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblSite.Appearance.Image")));
            this.lblSite.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblSite.Appearance.PressedImage")));
            this.lblSite.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSite.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSite.Name = "lblSite";
            // 
            // lblWeek
            // 
            resources.ApplyResources(this.lblWeek, "lblWeek");
            this.lblWeek.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblWeek.Appearance.DisabledImage")));
            this.lblWeek.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblWeek.Appearance.FontSizeDelta")));
            this.lblWeek.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblWeek.Appearance.FontStyleDelta")));
            this.lblWeek.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblWeek.Appearance.GradientMode")));
            this.lblWeek.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblWeek.Appearance.HoverImage")));
            this.lblWeek.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblWeek.Appearance.Image")));
            this.lblWeek.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblWeek.Appearance.PressedImage")));
            this.lblWeek.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblWeek.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblWeek.Name = "lblWeek";
            // 
            // bppLocation
            // 
            resources.ApplyResources(this.bppLocation, "bppLocation");
            this.bppLocation.Name = "bppLocation";
            this.bppLocation.Properties.AccessibleDescription = resources.GetString("bppLocation.Properties.AccessibleDescription");
            this.bppLocation.Properties.AccessibleName = resources.GetString("bppLocation.Properties.AccessibleName");
            this.bppLocation.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.Appearance.FontSizeDelta")));
            this.bppLocation.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.Appearance.FontStyleDelta")));
            this.bppLocation.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.Appearance.GradientMode")));
            this.bppLocation.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.Appearance.Image")));
            this.bppLocation.Properties.Appearance.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.FontSizeDelta")));
            this.bppLocation.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.FontStyleDelta")));
            this.bppLocation.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.GradientMode")));
            this.bppLocation.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.Image")));
            this.bppLocation.Properties.AppearanceDisabled.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.FontSizeDelta")));
            this.bppLocation.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.FontStyleDelta")));
            this.bppLocation.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.GradientMode")));
            this.bppLocation.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.Image")));
            this.bppLocation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.AppearanceFocused.FontSizeDelta")));
            this.bppLocation.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.AppearanceFocused.FontStyleDelta")));
            this.bppLocation.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceFocused.GradientMode")));
            this.bppLocation.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceFocused.Image")));
            this.bppLocation.Properties.AppearanceFocused.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("bppLocation.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.bppLocation.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bppLocation.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.bppLocation.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceReadOnly.GradientMode")));
            this.bppLocation.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceReadOnly.Image")));
            this.bppLocation.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.bppLocation.Properties.AutoHeight = ((bool)(resources.GetObject("bppLocation.Properties.AutoHeight")));
            this.bppLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("bppLocation.Properties.Buttons"))))});
            this.bppLocation.Properties.CloseOnOuterMouseClick = false;
            this.bppLocation.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("bppLocation.Properties.Mask.AutoComplete")));
            this.bppLocation.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("bppLocation.Properties.Mask.BeepOnError")));
            this.bppLocation.Properties.Mask.EditMask = resources.GetString("bppLocation.Properties.Mask.EditMask");
            this.bppLocation.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("bppLocation.Properties.Mask.IgnoreMaskBlank")));
            this.bppLocation.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("bppLocation.Properties.Mask.MaskType")));
            this.bppLocation.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("bppLocation.Properties.Mask.PlaceHolder")));
            this.bppLocation.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("bppLocation.Properties.Mask.SaveLiteral")));
            this.bppLocation.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("bppLocation.Properties.Mask.ShowPlaceHolders")));
            this.bppLocation.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("bppLocation.Properties.Mask.UseMaskAsDisplayFormat")));
            this.bppLocation.Properties.NullValuePrompt = resources.GetString("bppLocation.Properties.NullValuePrompt");
            this.bppLocation.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("bppLocation.Properties.NullValuePromptShowForEmptyValue")));
            this.bppLocation.Properties.PopupFormMinSize = new System.Drawing.Size(416, 349);
            this.bppLocation.Properties.PopupFormSize = new System.Drawing.Size(420, 328);
            this.bppLocation.Properties.PopupSizeable = false;
            this.bppLocation.Properties.ReadOnly = true;
            this.bppLocation.Properties.ShowPopupCloseButton = false;
            // 
            // panelDetails
            // 
            resources.ApplyResources(this.panelDetails, "panelDetails");
            this.panelDetails.Name = "panelDetails";
            // 
            // cbYear
            // 
            resources.ApplyResources(this.cbYear, "cbYear");
            this.cbYear.Name = "cbYear";
            this.cbYear.Properties.AccessibleDescription = resources.GetString("cbYear.Properties.AccessibleDescription");
            this.cbYear.Properties.AccessibleName = resources.GetString("cbYear.Properties.AccessibleName");
            this.cbYear.Properties.AutoHeight = ((bool)(resources.GetObject("cbYear.Properties.AutoHeight")));
            this.cbYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbYear.Properties.Buttons"))))});
            this.cbYear.Properties.NullValuePrompt = resources.GetString("cbYear.Properties.NullValuePrompt");
            this.cbYear.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbYear.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leWeek
            // 
            resources.ApplyResources(this.leWeek, "leWeek");
            this.leWeek.Name = "leWeek";
            this.leWeek.Properties.AccessibleDescription = resources.GetString("leWeek.Properties.AccessibleDescription");
            this.leWeek.Properties.AccessibleName = resources.GetString("leWeek.Properties.AccessibleName");
            this.leWeek.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leWeek.Properties.Appearance.FontSizeDelta")));
            this.leWeek.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leWeek.Properties.Appearance.FontStyleDelta")));
            this.leWeek.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leWeek.Properties.Appearance.GradientMode")));
            this.leWeek.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leWeek.Properties.Appearance.Image")));
            this.leWeek.Properties.Appearance.Options.UseFont = true;
            this.leWeek.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leWeek.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leWeek.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leWeek.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leWeek.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leWeek.Properties.AppearanceDisabled.GradientMode")));
            this.leWeek.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leWeek.Properties.AppearanceDisabled.Image")));
            this.leWeek.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leWeek.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leWeek.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leWeek.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leWeek.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leWeek.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leWeek.Properties.AppearanceDropDown.GradientMode")));
            this.leWeek.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leWeek.Properties.AppearanceDropDown.Image")));
            this.leWeek.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leWeek.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leWeek.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leWeek.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leWeek.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leWeek.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leWeek.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leWeek.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leWeek.Properties.AppearanceDropDownHeader.Image")));
            this.leWeek.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leWeek.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leWeek.Properties.AppearanceFocused.FontSizeDelta")));
            this.leWeek.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leWeek.Properties.AppearanceFocused.FontStyleDelta")));
            this.leWeek.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leWeek.Properties.AppearanceFocused.GradientMode")));
            this.leWeek.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leWeek.Properties.AppearanceFocused.Image")));
            this.leWeek.Properties.AppearanceFocused.Options.UseFont = true;
            this.leWeek.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leWeek.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leWeek.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leWeek.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leWeek.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leWeek.Properties.AppearanceReadOnly.GradientMode")));
            this.leWeek.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leWeek.Properties.AppearanceReadOnly.Image")));
            this.leWeek.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leWeek.Properties.AutoHeight = ((bool)(resources.GetObject("leWeek.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseFont = true;
            this.leWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leWeek.Properties.Buttons"))), resources.GetString("leWeek.Properties.Buttons1"), ((int)(resources.GetObject("leWeek.Properties.Buttons2"))), ((bool)(resources.GetObject("leWeek.Properties.Buttons3"))), ((bool)(resources.GetObject("leWeek.Properties.Buttons4"))), ((bool)(resources.GetObject("leWeek.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leWeek.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leWeek.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("leWeek.Properties.Buttons8"), ((object)(resources.GetObject("leWeek.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leWeek.Properties.Buttons10"))), ((bool)(resources.GetObject("leWeek.Properties.Buttons11"))))});
            this.leWeek.Properties.NullText = resources.GetString("leWeek.Properties.NullText");
            this.leWeek.Properties.NullValuePrompt = resources.GetString("leWeek.Properties.NullValuePrompt");
            this.leWeek.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leWeek.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // txtDateLastSaved
            // 
            resources.ApplyResources(this.txtDateLastSaved, "txtDateLastSaved");
            this.txtDateLastSaved.Name = "txtDateLastSaved";
            this.txtDateLastSaved.Properties.AccessibleDescription = resources.GetString("txtDateLastSaved.Properties.AccessibleDescription");
            this.txtDateLastSaved.Properties.AccessibleName = resources.GetString("txtDateLastSaved.Properties.AccessibleName");
            this.txtDateLastSaved.Properties.AutoHeight = ((bool)(resources.GetObject("txtDateLastSaved.Properties.AutoHeight")));
            this.txtDateLastSaved.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtDateLastSaved.Properties.Mask.AutoComplete")));
            this.txtDateLastSaved.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtDateLastSaved.Properties.Mask.BeepOnError")));
            this.txtDateLastSaved.Properties.Mask.EditMask = resources.GetString("txtDateLastSaved.Properties.Mask.EditMask");
            this.txtDateLastSaved.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtDateLastSaved.Properties.Mask.IgnoreMaskBlank")));
            this.txtDateLastSaved.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtDateLastSaved.Properties.Mask.MaskType")));
            this.txtDateLastSaved.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtDateLastSaved.Properties.Mask.PlaceHolder")));
            this.txtDateLastSaved.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtDateLastSaved.Properties.Mask.SaveLiteral")));
            this.txtDateLastSaved.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtDateLastSaved.Properties.Mask.ShowPlaceHolders")));
            this.txtDateLastSaved.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtDateLastSaved.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtDateLastSaved.Properties.NullValuePrompt = resources.GetString("txtDateLastSaved.Properties.NullValuePrompt");
            this.txtDateLastSaved.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtDateLastSaved.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // txtDateEntered
            // 
            resources.ApplyResources(this.txtDateEntered, "txtDateEntered");
            this.txtDateEntered.Name = "txtDateEntered";
            this.txtDateEntered.Properties.AccessibleDescription = resources.GetString("txtDateEntered.Properties.AccessibleDescription");
            this.txtDateEntered.Properties.AccessibleName = resources.GetString("txtDateEntered.Properties.AccessibleName");
            this.txtDateEntered.Properties.AutoHeight = ((bool)(resources.GetObject("txtDateEntered.Properties.AutoHeight")));
            this.txtDateEntered.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtDateEntered.Properties.Mask.AutoComplete")));
            this.txtDateEntered.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtDateEntered.Properties.Mask.BeepOnError")));
            this.txtDateEntered.Properties.Mask.EditMask = resources.GetString("txtDateEntered.Properties.Mask.EditMask");
            this.txtDateEntered.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtDateEntered.Properties.Mask.IgnoreMaskBlank")));
            this.txtDateEntered.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtDateEntered.Properties.Mask.MaskType")));
            this.txtDateEntered.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtDateEntered.Properties.Mask.PlaceHolder")));
            this.txtDateEntered.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtDateEntered.Properties.Mask.SaveLiteral")));
            this.txtDateEntered.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtDateEntered.Properties.Mask.ShowPlaceHolders")));
            this.txtDateEntered.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtDateEntered.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtDateEntered.Properties.NullValuePrompt = resources.GetString("txtDateEntered.Properties.NullValuePrompt");
            this.txtDateEntered.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtDateEntered.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // BasicSyndromicSurveillanceAggregateHeaderDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDateLastSaved);
            this.Controls.Add(this.txtDateEntered);
            this.Controls.Add(this.leWeek);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.lblWeek);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.lblCreatedBy);
            this.Controls.Add(this.lblDateLastSaved);
            this.Controls.Add(this.lblDateEntered);
            this.Controls.Add(this.txtFormID);
            this.Controls.Add(this.lblFormID);
            this.Controls.Add(this.lblYear);
            this.Icon = global::eidss.winclient.Properties.Resources.bss_aggregate_32x32;
            this.Name = "BasicSyndromicSurveillanceAggregateHeaderDetail";
            this.Load += new System.EventHandler(this.OnBasicSyndromicSurveillanceItemDetailLoad);
            ((System.ComponentModel.ISupportInitialize)(this.txtFormID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bppLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateLastSaved.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEntered.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private eidss.winclient.Location.LocationLookup bppLocation;
        
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection1;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection2;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection3;
        private DevExpress.XtraEditors.TextEdit txtFormID;
        private DevExpress.XtraEditors.LabelControl lblFormID;
        private DevExpress.XtraEditors.LabelControl lblYear;
        private DevExpress.XtraEditors.LabelControl lblDateEntered;
        private DevExpress.XtraEditors.LabelControl lblDateLastSaved;
        private DevExpress.XtraEditors.TextEdit txtCreatedBy;
        private DevExpress.XtraEditors.LabelControl lblCreatedBy;
        private DevExpress.XtraEditors.TextEdit txtSite;
        private DevExpress.XtraEditors.LabelControl lblSite;
        private DevExpress.XtraEditors.LabelControl lblWeek;
        private DevExpress.XtraEditors.PanelControl panelDetails;
        private DevExpress.XtraEditors.ComboBoxEdit cbYear;
        private DevExpress.XtraEditors.LookUpEdit leWeek;
        private DevExpress.XtraEditors.TextEdit txtDateLastSaved;
        private DevExpress.XtraEditors.TextEdit txtDateEntered;
    }
}
