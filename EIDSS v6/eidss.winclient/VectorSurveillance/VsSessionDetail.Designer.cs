using bv.winclient.ActionPanel;

namespace eidss.winclient.VectorSurveillance
{
    sealed partial class VsSessionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsSessionDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pcGeneralSession = new DevExpress.XtraEditors.PanelControl();
            this.seCollectionEffort = new DevExpress.XtraEditors.SpinEdit();
            this.leSessionStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.bppLocation = new eidss.winclient.Location.LocationLookup();
            this.gbDiagnoses = new DevExpress.XtraEditors.GroupControl();
            this.lbDiagnoses = new DevExpress.XtraEditors.ListBoxControl();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.beOutbreakID = new DevExpress.XtraEditors.ButtonEdit();
            this.lblOutbreak = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.txtVectors = new DevExpress.XtraEditors.TextEdit();
            this.txtFieldSessionID = new DevExpress.XtraEditors.TextEdit();
            this.dtCloseDate = new DevExpress.XtraEditors.DateEdit();
            this.dtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.txtSessionID = new DevExpress.XtraEditors.TextEdit();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.lblVectors = new DevExpress.XtraEditors.LabelControl();
            this.lblSessionStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblFieldSessionID = new DevExpress.XtraEditors.LabelControl();
            this.lblSessionID = new DevExpress.XtraEditors.LabelControl();
            this.lblStartDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCloseDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCollectionEffort = new DevExpress.XtraEditors.LabelControl();
            this.pcData = new DevExpress.XtraEditors.PanelControl();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpDetailedInfo = new DevExpress.XtraTab.XtraTabPage();
            this.tcData = new DevExpress.XtraTab.XtraTabControl();
            this.tpPools = new DevExpress.XtraTab.XtraTabPage();
            this.panelPools = new DevExpress.XtraEditors.PanelControl();
            this.tpSamples = new DevExpress.XtraTab.XtraTabPage();
            this.panelSamples = new DevExpress.XtraEditors.PanelControl();
            this.tpFieldTests = new DevExpress.XtraTab.XtraTabPage();
            this.panelFieldTests = new DevExpress.XtraEditors.PanelControl();
            this.tpLabTests = new DevExpress.XtraTab.XtraTabPage();
            this.panelLabTests = new DevExpress.XtraEditors.PanelControl();
            this.tpSummaryInfo = new DevExpress.XtraTab.XtraTabPage();
            this.remoteSqlConnection1 = new bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection();
            this.remoteSqlConnection2 = new bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection();
            this.remoteSqlConnection3 = new bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection();
            ((System.ComponentModel.ISupportInitialize)(this.pcGeneralSession)).BeginInit();
            this.pcGeneralSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seCollectionEffort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSessionStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bppLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDiagnoses)).BeginInit();
            this.gbDiagnoses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbDiagnoses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beOutbreakID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVectors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldSessionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCloseDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCloseDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSessionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcData)).BeginInit();
            this.pcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpDetailedInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcData)).BeginInit();
            this.tcData.SuspendLayout();
            this.tpPools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelPools)).BeginInit();
            this.tpSamples.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSamples)).BeginInit();
            this.tpFieldTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFieldTests)).BeginInit();
            this.tpLabTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelLabTests)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VsSessionDetail), out resources);
            // Form Is Localizable: True
            // 
            // pcGeneralSession
            // 
            resources.ApplyResources(this.pcGeneralSession, "pcGeneralSession");
            this.pcGeneralSession.Appearance.FontSizeDelta = ((int)(resources.GetObject("pcGeneralSession.Appearance.FontSizeDelta")));
            this.pcGeneralSession.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("pcGeneralSession.Appearance.FontStyleDelta")));
            this.pcGeneralSession.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pcGeneralSession.Appearance.GradientMode")));
            this.pcGeneralSession.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("pcGeneralSession.Appearance.Image")));
            this.pcGeneralSession.Appearance.Options.UseFont = true;
            this.pcGeneralSession.Controls.Add(this.seCollectionEffort);
            this.pcGeneralSession.Controls.Add(this.leSessionStatus);
            this.pcGeneralSession.Controls.Add(this.bppLocation);
            this.pcGeneralSession.Controls.Add(this.gbDiagnoses);
            this.pcGeneralSession.Controls.Add(this.txtDescription);
            this.pcGeneralSession.Controls.Add(this.beOutbreakID);
            this.pcGeneralSession.Controls.Add(this.lblOutbreak);
            this.pcGeneralSession.Controls.Add(this.lblLocation);
            this.pcGeneralSession.Controls.Add(this.txtVectors);
            this.pcGeneralSession.Controls.Add(this.txtFieldSessionID);
            this.pcGeneralSession.Controls.Add(this.dtCloseDate);
            this.pcGeneralSession.Controls.Add(this.dtStartDate);
            this.pcGeneralSession.Controls.Add(this.txtSessionID);
            this.pcGeneralSession.Controls.Add(this.lblDescription);
            this.pcGeneralSession.Controls.Add(this.lblVectors);
            this.pcGeneralSession.Controls.Add(this.lblSessionStatus);
            this.pcGeneralSession.Controls.Add(this.lblFieldSessionID);
            this.pcGeneralSession.Controls.Add(this.lblSessionID);
            this.pcGeneralSession.Controls.Add(this.lblStartDate);
            this.pcGeneralSession.Controls.Add(this.lblCloseDate);
            this.pcGeneralSession.Controls.Add(this.lblCollectionEffort);
            this.pcGeneralSession.Name = "pcGeneralSession";
            // 
            // seCollectionEffort
            // 
            resources.ApplyResources(this.seCollectionEffort, "seCollectionEffort");
            this.seCollectionEffort.Name = "seCollectionEffort";
            this.seCollectionEffort.Properties.AccessibleDescription = resources.GetString("seCollectionEffort.Properties.AccessibleDescription");
            this.seCollectionEffort.Properties.AccessibleName = resources.GetString("seCollectionEffort.Properties.AccessibleName");
            this.seCollectionEffort.Properties.AutoHeight = ((bool)(resources.GetObject("seCollectionEffort.Properties.AutoHeight")));
            this.seCollectionEffort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seCollectionEffort.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("seCollectionEffort.Properties.Mask.AutoComplete")));
            this.seCollectionEffort.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("seCollectionEffort.Properties.Mask.BeepOnError")));
            this.seCollectionEffort.Properties.Mask.EditMask = resources.GetString("seCollectionEffort.Properties.Mask.EditMask");
            this.seCollectionEffort.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("seCollectionEffort.Properties.Mask.IgnoreMaskBlank")));
            this.seCollectionEffort.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("seCollectionEffort.Properties.Mask.MaskType")));
            this.seCollectionEffort.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("seCollectionEffort.Properties.Mask.PlaceHolder")));
            this.seCollectionEffort.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("seCollectionEffort.Properties.Mask.SaveLiteral")));
            this.seCollectionEffort.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("seCollectionEffort.Properties.Mask.ShowPlaceHolders")));
            this.seCollectionEffort.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("seCollectionEffort.Properties.Mask.UseMaskAsDisplayFormat")));
            this.seCollectionEffort.Properties.NullValuePrompt = resources.GetString("seCollectionEffort.Properties.NullValuePrompt");
            this.seCollectionEffort.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("seCollectionEffort.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // leSessionStatus
            // 
            resources.ApplyResources(this.leSessionStatus, "leSessionStatus");
            this.leSessionStatus.Name = "leSessionStatus";
            this.leSessionStatus.Properties.AccessibleDescription = resources.GetString("leSessionStatus.Properties.AccessibleDescription");
            this.leSessionStatus.Properties.AccessibleName = resources.GetString("leSessionStatus.Properties.AccessibleName");
            this.leSessionStatus.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("leSessionStatus.Properties.Appearance.FontSizeDelta")));
            this.leSessionStatus.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSessionStatus.Properties.Appearance.FontStyleDelta")));
            this.leSessionStatus.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.Appearance.GradientMode")));
            this.leSessionStatus.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.Appearance.Image")));
            this.leSessionStatus.Properties.Appearance.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("leSessionStatus.Properties.AppearanceDisabled.FontSizeDelta")));
            this.leSessionStatus.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSessionStatus.Properties.AppearanceDisabled.FontStyleDelta")));
            this.leSessionStatus.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceDisabled.GradientMode")));
            this.leSessionStatus.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceDisabled.Image")));
            this.leSessionStatus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDropDown.FontSizeDelta = ((int)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDown.FontSizeDelta")));
            this.leSessionStatus.Properties.AppearanceDropDown.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDown.FontStyleDelta")));
            this.leSessionStatus.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDown.GradientMode")));
            this.leSessionStatus.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDown.Image")));
            this.leSessionStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDropDownHeader.FontSizeDelta = ((int)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDownHeader.FontSizeDelta")));
            this.leSessionStatus.Properties.AppearanceDropDownHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDownHeader.FontStyleDelta")));
            this.leSessionStatus.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leSessionStatus.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDownHeader.Image")));
            this.leSessionStatus.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("leSessionStatus.Properties.AppearanceFocused.FontSizeDelta")));
            this.leSessionStatus.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSessionStatus.Properties.AppearanceFocused.FontStyleDelta")));
            this.leSessionStatus.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceFocused.GradientMode")));
            this.leSessionStatus.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceFocused.Image")));
            this.leSessionStatus.Properties.AppearanceFocused.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("leSessionStatus.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.leSessionStatus.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("leSessionStatus.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.leSessionStatus.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceReadOnly.GradientMode")));
            this.leSessionStatus.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceReadOnly.Image")));
            this.leSessionStatus.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.leSessionStatus.Properties.AutoHeight = ((bool)(resources.GetObject("leSessionStatus.Properties.AutoHeight")));
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseFont = true;
            this.leSessionStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSessionStatus.Properties.Buttons"))), resources.GetString("leSessionStatus.Properties.Buttons1"), ((int)(resources.GetObject("leSessionStatus.Properties.Buttons2"))), ((bool)(resources.GetObject("leSessionStatus.Properties.Buttons3"))), ((bool)(resources.GetObject("leSessionStatus.Properties.Buttons4"))), ((bool)(resources.GetObject("leSessionStatus.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leSessionStatus.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("leSessionStatus.Properties.Buttons8"), ((object)(resources.GetObject("leSessionStatus.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leSessionStatus.Properties.Buttons10"))), ((bool)(resources.GetObject("leSessionStatus.Properties.Buttons11"))))});
            this.leSessionStatus.Properties.NullText = resources.GetString("leSessionStatus.Properties.NullText");
            this.leSessionStatus.Properties.NullValuePrompt = resources.GetString("leSessionStatus.Properties.NullValuePrompt");
            this.leSessionStatus.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leSessionStatus.Properties.NullValuePromptShowForEmptyValue")));
            this.leSessionStatus.EditValueChanged += new System.EventHandler(this.OnSessionStatusEditValueChanged);
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
            this.bppLocation.Properties.PopupSizeable = false;
            this.bppLocation.Properties.ReadOnly = true;
            this.bppLocation.Properties.ShowPopupCloseButton = false;
            // 
            // gbDiagnoses
            // 
            resources.ApplyResources(this.gbDiagnoses, "gbDiagnoses");
            this.gbDiagnoses.Controls.Add(this.lbDiagnoses);
            this.gbDiagnoses.Name = "gbDiagnoses";
            // 
            // lbDiagnoses
            // 
            resources.ApplyResources(this.lbDiagnoses, "lbDiagnoses");
            this.lbDiagnoses.Name = "lbDiagnoses";
            this.lbDiagnoses.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.AccessibleDescription = resources.GetString("txtDescription.Properties.AccessibleDescription");
            this.txtDescription.Properties.AccessibleName = resources.GetString("txtDescription.Properties.AccessibleName");
            this.txtDescription.Properties.AutoHeight = ((bool)(resources.GetObject("txtDescription.Properties.AutoHeight")));
            this.txtDescription.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtDescription.Properties.Mask.AutoComplete")));
            this.txtDescription.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtDescription.Properties.Mask.BeepOnError")));
            this.txtDescription.Properties.Mask.EditMask = resources.GetString("txtDescription.Properties.Mask.EditMask");
            this.txtDescription.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtDescription.Properties.Mask.IgnoreMaskBlank")));
            this.txtDescription.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtDescription.Properties.Mask.MaskType")));
            this.txtDescription.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtDescription.Properties.Mask.PlaceHolder")));
            this.txtDescription.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtDescription.Properties.Mask.SaveLiteral")));
            this.txtDescription.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtDescription.Properties.Mask.ShowPlaceHolders")));
            this.txtDescription.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtDescription.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtDescription.Properties.NullValuePrompt = resources.GetString("txtDescription.Properties.NullValuePrompt");
            this.txtDescription.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtDescription.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // beOutbreakID
            // 
            resources.ApplyResources(this.beOutbreakID, "beOutbreakID");
            this.beOutbreakID.Name = "beOutbreakID";
            this.beOutbreakID.Properties.AccessibleDescription = resources.GetString("beOutbreakID.Properties.AccessibleDescription");
            this.beOutbreakID.Properties.AccessibleName = resources.GetString("beOutbreakID.Properties.AccessibleName");
            this.beOutbreakID.Properties.AutoHeight = ((bool)(resources.GetObject("beOutbreakID.Properties.AutoHeight")));
            this.beOutbreakID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("beOutbreakID.Properties.Buttons"))))});
            this.beOutbreakID.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("beOutbreakID.Properties.Mask.AutoComplete")));
            this.beOutbreakID.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("beOutbreakID.Properties.Mask.BeepOnError")));
            this.beOutbreakID.Properties.Mask.EditMask = resources.GetString("beOutbreakID.Properties.Mask.EditMask");
            this.beOutbreakID.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("beOutbreakID.Properties.Mask.IgnoreMaskBlank")));
            this.beOutbreakID.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("beOutbreakID.Properties.Mask.MaskType")));
            this.beOutbreakID.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("beOutbreakID.Properties.Mask.PlaceHolder")));
            this.beOutbreakID.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("beOutbreakID.Properties.Mask.SaveLiteral")));
            this.beOutbreakID.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("beOutbreakID.Properties.Mask.ShowPlaceHolders")));
            this.beOutbreakID.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("beOutbreakID.Properties.Mask.UseMaskAsDisplayFormat")));
            this.beOutbreakID.Properties.NullValuePrompt = resources.GetString("beOutbreakID.Properties.NullValuePrompt");
            this.beOutbreakID.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("beOutbreakID.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblOutbreak
            // 
            resources.ApplyResources(this.lblOutbreak, "lblOutbreak");
            this.lblOutbreak.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblOutbreak.Appearance.DisabledImage")));
            this.lblOutbreak.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblOutbreak.Appearance.FontSizeDelta")));
            this.lblOutbreak.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblOutbreak.Appearance.FontStyleDelta")));
            this.lblOutbreak.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblOutbreak.Appearance.GradientMode")));
            this.lblOutbreak.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblOutbreak.Appearance.HoverImage")));
            this.lblOutbreak.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblOutbreak.Appearance.Image")));
            this.lblOutbreak.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblOutbreak.Appearance.PressedImage")));
            this.lblOutbreak.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblOutbreak.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblOutbreak.Name = "lblOutbreak";
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblLocation.Appearance.DisabledImage")));
            this.lblLocation.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblLocation.Appearance.FontSizeDelta")));
            this.lblLocation.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblLocation.Appearance.FontStyleDelta")));
            this.lblLocation.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblLocation.Appearance.GradientMode")));
            this.lblLocation.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblLocation.Appearance.HoverImage")));
            this.lblLocation.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblLocation.Appearance.Image")));
            this.lblLocation.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblLocation.Appearance.PressedImage")));
            this.lblLocation.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblLocation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblLocation.Name = "lblLocation";
            // 
            // txtVectors
            // 
            resources.ApplyResources(this.txtVectors, "txtVectors");
            this.txtVectors.Name = "txtVectors";
            this.txtVectors.Properties.AccessibleDescription = resources.GetString("txtVectors.Properties.AccessibleDescription");
            this.txtVectors.Properties.AccessibleName = resources.GetString("txtVectors.Properties.AccessibleName");
            this.txtVectors.Properties.AutoHeight = ((bool)(resources.GetObject("txtVectors.Properties.AutoHeight")));
            this.txtVectors.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtVectors.Properties.Mask.AutoComplete")));
            this.txtVectors.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtVectors.Properties.Mask.BeepOnError")));
            this.txtVectors.Properties.Mask.EditMask = resources.GetString("txtVectors.Properties.Mask.EditMask");
            this.txtVectors.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtVectors.Properties.Mask.IgnoreMaskBlank")));
            this.txtVectors.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtVectors.Properties.Mask.MaskType")));
            this.txtVectors.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtVectors.Properties.Mask.PlaceHolder")));
            this.txtVectors.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtVectors.Properties.Mask.SaveLiteral")));
            this.txtVectors.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtVectors.Properties.Mask.ShowPlaceHolders")));
            this.txtVectors.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtVectors.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtVectors.Properties.NullValuePrompt = resources.GetString("txtVectors.Properties.NullValuePrompt");
            this.txtVectors.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtVectors.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // txtFieldSessionID
            // 
            resources.ApplyResources(this.txtFieldSessionID, "txtFieldSessionID");
            this.txtFieldSessionID.Name = "txtFieldSessionID";
            this.txtFieldSessionID.Properties.AccessibleDescription = resources.GetString("txtFieldSessionID.Properties.AccessibleDescription");
            this.txtFieldSessionID.Properties.AccessibleName = resources.GetString("txtFieldSessionID.Properties.AccessibleName");
            this.txtFieldSessionID.Properties.AutoHeight = ((bool)(resources.GetObject("txtFieldSessionID.Properties.AutoHeight")));
            this.txtFieldSessionID.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtFieldSessionID.Properties.Mask.AutoComplete")));
            this.txtFieldSessionID.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtFieldSessionID.Properties.Mask.BeepOnError")));
            this.txtFieldSessionID.Properties.Mask.EditMask = resources.GetString("txtFieldSessionID.Properties.Mask.EditMask");
            this.txtFieldSessionID.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtFieldSessionID.Properties.Mask.IgnoreMaskBlank")));
            this.txtFieldSessionID.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtFieldSessionID.Properties.Mask.MaskType")));
            this.txtFieldSessionID.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtFieldSessionID.Properties.Mask.PlaceHolder")));
            this.txtFieldSessionID.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtFieldSessionID.Properties.Mask.SaveLiteral")));
            this.txtFieldSessionID.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtFieldSessionID.Properties.Mask.ShowPlaceHolders")));
            this.txtFieldSessionID.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtFieldSessionID.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtFieldSessionID.Properties.NullValuePrompt = resources.GetString("txtFieldSessionID.Properties.NullValuePrompt");
            this.txtFieldSessionID.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtFieldSessionID.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // dtCloseDate
            // 
            resources.ApplyResources(this.dtCloseDate, "dtCloseDate");
            this.dtCloseDate.Name = "dtCloseDate";
            this.dtCloseDate.Properties.AccessibleDescription = resources.GetString("dtCloseDate.Properties.AccessibleDescription");
            this.dtCloseDate.Properties.AccessibleName = resources.GetString("dtCloseDate.Properties.AccessibleName");
            this.dtCloseDate.Properties.AutoHeight = ((bool)(resources.GetObject("dtCloseDate.Properties.AutoHeight")));
            this.dtCloseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtCloseDate.Properties.Buttons"))))});
            this.dtCloseDate.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtCloseDate.Properties.CalendarTimeProperties.AccessibleDescription");
            this.dtCloseDate.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtCloseDate.Properties.CalendarTimeProperties.AccessibleName");
            this.dtCloseDate.Properties.CalendarTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.AutoHeight")));
            this.dtCloseDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.Mask.AutoComplete")));
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.Mask.BeepOnError")));
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtCloseDate.Properties.CalendarTimeProperties.Mask.EditMask");
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.Mask.MaskType")));
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.Mask.PlaceHolder")));
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.Mask.SaveLiteral")));
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders")));
            this.dtCloseDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtCloseDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtCloseDate.Properties.CalendarTimeProperties.NullValuePrompt");
            this.dtCloseDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCloseDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue")));
            this.dtCloseDate.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCloseDate.Properties.Mask.AutoComplete")));
            this.dtCloseDate.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCloseDate.Properties.Mask.BeepOnError")));
            this.dtCloseDate.Properties.Mask.EditMask = resources.GetString("dtCloseDate.Properties.Mask.EditMask");
            this.dtCloseDate.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCloseDate.Properties.Mask.IgnoreMaskBlank")));
            this.dtCloseDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCloseDate.Properties.Mask.MaskType")));
            this.dtCloseDate.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCloseDate.Properties.Mask.PlaceHolder")));
            this.dtCloseDate.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCloseDate.Properties.Mask.SaveLiteral")));
            this.dtCloseDate.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCloseDate.Properties.Mask.ShowPlaceHolders")));
            this.dtCloseDate.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCloseDate.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtCloseDate.Properties.NullValuePrompt = resources.GetString("dtCloseDate.Properties.NullValuePrompt");
            this.dtCloseDate.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCloseDate.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // dtStartDate
            // 
            resources.ApplyResources(this.dtStartDate, "dtStartDate");
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Properties.AccessibleDescription = resources.GetString("dtStartDate.Properties.AccessibleDescription");
            this.dtStartDate.Properties.AccessibleName = resources.GetString("dtStartDate.Properties.AccessibleName");
            this.dtStartDate.Properties.AutoHeight = ((bool)(resources.GetObject("dtStartDate.Properties.AutoHeight")));
            this.dtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtStartDate.Properties.Buttons"))))});
            this.dtStartDate.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtStartDate.Properties.CalendarTimeProperties.AccessibleDescription");
            this.dtStartDate.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtStartDate.Properties.CalendarTimeProperties.AccessibleName");
            this.dtStartDate.Properties.CalendarTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.AutoHeight")));
            this.dtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.AutoComplete")));
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.BeepOnError")));
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtStartDate.Properties.CalendarTimeProperties.Mask.EditMask");
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.MaskType")));
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.PlaceHolder")));
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral")));
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders")));
            this.dtStartDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtStartDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtStartDate.Properties.CalendarTimeProperties.NullValuePrompt");
            this.dtStartDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue")));
            this.dtStartDate.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtStartDate.Properties.Mask.AutoComplete")));
            this.dtStartDate.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtStartDate.Properties.Mask.BeepOnError")));
            this.dtStartDate.Properties.Mask.EditMask = resources.GetString("dtStartDate.Properties.Mask.EditMask");
            this.dtStartDate.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtStartDate.Properties.Mask.IgnoreMaskBlank")));
            this.dtStartDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtStartDate.Properties.Mask.MaskType")));
            this.dtStartDate.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtStartDate.Properties.Mask.PlaceHolder")));
            this.dtStartDate.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtStartDate.Properties.Mask.SaveLiteral")));
            this.dtStartDate.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtStartDate.Properties.Mask.ShowPlaceHolders")));
            this.dtStartDate.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtStartDate.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtStartDate.Properties.NullValuePrompt = resources.GetString("dtStartDate.Properties.NullValuePrompt");
            this.dtStartDate.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtStartDate.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // txtSessionID
            // 
            resources.ApplyResources(this.txtSessionID, "txtSessionID");
            this.txtSessionID.Name = "txtSessionID";
            this.txtSessionID.Properties.AccessibleDescription = resources.GetString("txtSessionID.Properties.AccessibleDescription");
            this.txtSessionID.Properties.AccessibleName = resources.GetString("txtSessionID.Properties.AccessibleName");
            this.txtSessionID.Properties.AutoHeight = ((bool)(resources.GetObject("txtSessionID.Properties.AutoHeight")));
            this.txtSessionID.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtSessionID.Properties.Mask.AutoComplete")));
            this.txtSessionID.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.BeepOnError")));
            this.txtSessionID.Properties.Mask.EditMask = resources.GetString("txtSessionID.Properties.Mask.EditMask");
            this.txtSessionID.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.IgnoreMaskBlank")));
            this.txtSessionID.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtSessionID.Properties.Mask.MaskType")));
            this.txtSessionID.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtSessionID.Properties.Mask.PlaceHolder")));
            this.txtSessionID.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.SaveLiteral")));
            this.txtSessionID.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.ShowPlaceHolders")));
            this.txtSessionID.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtSessionID.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtSessionID.Properties.NullValuePrompt = resources.GetString("txtSessionID.Properties.NullValuePrompt");
            this.txtSessionID.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtSessionID.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblDescription.Appearance.DisabledImage")));
            this.lblDescription.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblDescription.Appearance.FontSizeDelta")));
            this.lblDescription.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblDescription.Appearance.FontStyleDelta")));
            this.lblDescription.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblDescription.Appearance.GradientMode")));
            this.lblDescription.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblDescription.Appearance.HoverImage")));
            this.lblDescription.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblDescription.Appearance.Image")));
            this.lblDescription.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblDescription.Appearance.PressedImage")));
            this.lblDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDescription.Name = "lblDescription";
            // 
            // lblVectors
            // 
            resources.ApplyResources(this.lblVectors, "lblVectors");
            this.lblVectors.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblVectors.Appearance.DisabledImage")));
            this.lblVectors.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblVectors.Appearance.FontSizeDelta")));
            this.lblVectors.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblVectors.Appearance.FontStyleDelta")));
            this.lblVectors.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblVectors.Appearance.GradientMode")));
            this.lblVectors.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblVectors.Appearance.HoverImage")));
            this.lblVectors.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblVectors.Appearance.Image")));
            this.lblVectors.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblVectors.Appearance.PressedImage")));
            this.lblVectors.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblVectors.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblVectors.Name = "lblVectors";
            // 
            // lblSessionStatus
            // 
            resources.ApplyResources(this.lblSessionStatus, "lblSessionStatus");
            this.lblSessionStatus.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblSessionStatus.Appearance.DisabledImage")));
            this.lblSessionStatus.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblSessionStatus.Appearance.FontSizeDelta")));
            this.lblSessionStatus.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblSessionStatus.Appearance.FontStyleDelta")));
            this.lblSessionStatus.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblSessionStatus.Appearance.GradientMode")));
            this.lblSessionStatus.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblSessionStatus.Appearance.HoverImage")));
            this.lblSessionStatus.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblSessionStatus.Appearance.Image")));
            this.lblSessionStatus.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblSessionStatus.Appearance.PressedImage")));
            this.lblSessionStatus.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSessionStatus.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSessionStatus.Name = "lblSessionStatus";
            // 
            // lblFieldSessionID
            // 
            resources.ApplyResources(this.lblFieldSessionID, "lblFieldSessionID");
            this.lblFieldSessionID.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblFieldSessionID.Appearance.DisabledImage")));
            this.lblFieldSessionID.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblFieldSessionID.Appearance.FontSizeDelta")));
            this.lblFieldSessionID.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblFieldSessionID.Appearance.FontStyleDelta")));
            this.lblFieldSessionID.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblFieldSessionID.Appearance.GradientMode")));
            this.lblFieldSessionID.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblFieldSessionID.Appearance.HoverImage")));
            this.lblFieldSessionID.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblFieldSessionID.Appearance.Image")));
            this.lblFieldSessionID.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblFieldSessionID.Appearance.PressedImage")));
            this.lblFieldSessionID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFieldSessionID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblFieldSessionID.Name = "lblFieldSessionID";
            // 
            // lblSessionID
            // 
            resources.ApplyResources(this.lblSessionID, "lblSessionID");
            this.lblSessionID.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblSessionID.Appearance.DisabledImage")));
            this.lblSessionID.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblSessionID.Appearance.FontSizeDelta")));
            this.lblSessionID.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblSessionID.Appearance.FontStyleDelta")));
            this.lblSessionID.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblSessionID.Appearance.GradientMode")));
            this.lblSessionID.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblSessionID.Appearance.HoverImage")));
            this.lblSessionID.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblSessionID.Appearance.Image")));
            this.lblSessionID.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblSessionID.Appearance.PressedImage")));
            this.lblSessionID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSessionID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSessionID.Name = "lblSessionID";
            // 
            // lblStartDate
            // 
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblStartDate.Appearance.DisabledImage")));
            this.lblStartDate.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblStartDate.Appearance.FontSizeDelta")));
            this.lblStartDate.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblStartDate.Appearance.FontStyleDelta")));
            this.lblStartDate.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblStartDate.Appearance.GradientMode")));
            this.lblStartDate.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblStartDate.Appearance.HoverImage")));
            this.lblStartDate.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblStartDate.Appearance.Image")));
            this.lblStartDate.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblStartDate.Appearance.PressedImage")));
            this.lblStartDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStartDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblStartDate.Name = "lblStartDate";
            // 
            // lblCloseDate
            // 
            resources.ApplyResources(this.lblCloseDate, "lblCloseDate");
            this.lblCloseDate.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCloseDate.Appearance.DisabledImage")));
            this.lblCloseDate.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblCloseDate.Appearance.FontSizeDelta")));
            this.lblCloseDate.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblCloseDate.Appearance.FontStyleDelta")));
            this.lblCloseDate.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCloseDate.Appearance.GradientMode")));
            this.lblCloseDate.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCloseDate.Appearance.HoverImage")));
            this.lblCloseDate.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCloseDate.Appearance.Image")));
            this.lblCloseDate.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCloseDate.Appearance.PressedImage")));
            this.lblCloseDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCloseDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCloseDate.Name = "lblCloseDate";
            // 
            // lblCollectionEffort
            // 
            resources.ApplyResources(this.lblCollectionEffort, "lblCollectionEffort");
            this.lblCollectionEffort.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionEffort.Appearance.DisabledImage")));
            this.lblCollectionEffort.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblCollectionEffort.Appearance.FontSizeDelta")));
            this.lblCollectionEffort.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblCollectionEffort.Appearance.FontStyleDelta")));
            this.lblCollectionEffort.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCollectionEffort.Appearance.GradientMode")));
            this.lblCollectionEffort.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionEffort.Appearance.HoverImage")));
            this.lblCollectionEffort.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCollectionEffort.Appearance.Image")));
            this.lblCollectionEffort.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionEffort.Appearance.PressedImage")));
            this.lblCollectionEffort.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionEffort.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionEffort.Name = "lblCollectionEffort";
            // 
            // pcData
            // 
            resources.ApplyResources(this.pcData, "pcData");
            this.pcData.Controls.Add(this.tcMain);
            this.pcData.Name = "pcData";
            // 
            // tcMain
            // 
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpDetailedInfo;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpDetailedInfo,
            this.tpSummaryInfo});
            // 
            // tpDetailedInfo
            // 
            resources.ApplyResources(this.tpDetailedInfo, "tpDetailedInfo");
            this.tpDetailedInfo.Controls.Add(this.tcData);
            this.tpDetailedInfo.Name = "tpDetailedInfo";
            // 
            // tcData
            // 
            resources.ApplyResources(this.tcData, "tcData");
            this.tcData.Name = "tcData";
            this.tcData.SelectedTabPage = this.tpPools;
            this.tcData.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpPools,
            this.tpSamples,
            this.tpFieldTests,
            this.tpLabTests});
            // 
            // tpPools
            // 
            resources.ApplyResources(this.tpPools, "tpPools");
            this.tpPools.Controls.Add(this.panelPools);
            this.tpPools.Name = "tpPools";
            // 
            // panelPools
            // 
            resources.ApplyResources(this.panelPools, "panelPools");
            this.panelPools.Name = "panelPools";
            // 
            // tpSamples
            // 
            resources.ApplyResources(this.tpSamples, "tpSamples");
            this.tpSamples.Controls.Add(this.panelSamples);
            this.tpSamples.Name = "tpSamples";
            // 
            // panelSamples
            // 
            resources.ApplyResources(this.panelSamples, "panelSamples");
            this.panelSamples.Name = "panelSamples";
            // 
            // tpFieldTests
            // 
            resources.ApplyResources(this.tpFieldTests, "tpFieldTests");
            this.tpFieldTests.Controls.Add(this.panelFieldTests);
            this.tpFieldTests.Name = "tpFieldTests";
            // 
            // panelFieldTests
            // 
            resources.ApplyResources(this.panelFieldTests, "panelFieldTests");
            this.panelFieldTests.Name = "panelFieldTests";
            // 
            // tpLabTests
            // 
            resources.ApplyResources(this.tpLabTests, "tpLabTests");
            this.tpLabTests.Controls.Add(this.panelLabTests);
            this.tpLabTests.Name = "tpLabTests";
            // 
            // panelLabTests
            // 
            resources.ApplyResources(this.panelLabTests, "panelLabTests");
            this.panelLabTests.Name = "panelLabTests";
            // 
            // tpSummaryInfo
            // 
            resources.ApplyResources(this.tpSummaryInfo, "tpSummaryInfo");
            this.tpSummaryInfo.Name = "tpSummaryInfo";
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
            // VsSessionDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcData);
            this.Controls.Add(this.pcGeneralSession);
            this.HelpTopicID = "vs_w02";
            this.Icon = global::eidss.winclient.Properties.Resources.Vector_Surveillance_Session__large__01_1;
            this.Name = "VsSessionDetail";
            this.Load += new System.EventHandler(this.OnVsSessionDetailLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pcGeneralSession)).EndInit();
            this.pcGeneralSession.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seCollectionEffort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSessionStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bppLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDiagnoses)).EndInit();
            this.gbDiagnoses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbDiagnoses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beOutbreakID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVectors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldSessionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCloseDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCloseDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSessionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcData)).EndInit();
            this.pcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpDetailedInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcData)).EndInit();
            this.tcData.ResumeLayout(false);
            this.tpPools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelPools)).EndInit();
            this.tpSamples.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSamples)).EndInit();
            this.tpFieldTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelFieldTests)).EndInit();
            this.tpLabTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelLabTests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcGeneralSession;
        private DevExpress.XtraEditors.LabelControl lblSessionID;
        private DevExpress.XtraEditors.DateEdit dtCloseDate;
        private DevExpress.XtraEditors.DateEdit dtStartDate;
        private DevExpress.XtraEditors.LabelControl lblCloseDate;
        private DevExpress.XtraEditors.LabelControl lblStartDate;
        private DevExpress.XtraEditors.TextEdit txtSessionID;
        private DevExpress.XtraEditors.TextEdit txtFieldSessionID;
        private DevExpress.XtraEditors.LabelControl lblFieldSessionID;
        private DevExpress.XtraEditors.LabelControl lblSessionStatus;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.TextEdit txtVectors;
        private DevExpress.XtraEditors.LabelControl lblVectors;
        private DevExpress.XtraEditors.GroupControl gbDiagnoses;
        private DevExpress.XtraEditors.ListBoxControl lbDiagnoses;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.ButtonEdit beOutbreakID;
        private DevExpress.XtraEditors.LabelControl lblOutbreak;
        private DevExpress.XtraEditors.PanelControl pcData;
        private eidss.winclient.Location.LocationLookup bppLocation;
        private DevExpress.XtraEditors.LookUpEdit leSessionStatus;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection1;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection2;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection3;
        private DevExpress.XtraEditors.LabelControl lblCollectionEffort;
        private DevExpress.XtraEditors.SpinEdit seCollectionEffort;
        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpDetailedInfo;
        private DevExpress.XtraTab.XtraTabControl tcData;
        private DevExpress.XtraTab.XtraTabPage tpPools;
        private DevExpress.XtraEditors.PanelControl panelPools;
        private DevExpress.XtraTab.XtraTabPage tpSamples;
        private DevExpress.XtraEditors.PanelControl panelSamples;
        private DevExpress.XtraTab.XtraTabPage tpLabTests;
        private DevExpress.XtraEditors.PanelControl panelLabTests;
        private DevExpress.XtraTab.XtraTabPage tpSummaryInfo;
        private DevExpress.XtraTab.XtraTabPage tpFieldTests;
        private DevExpress.XtraEditors.PanelControl panelFieldTests;
    }
}
