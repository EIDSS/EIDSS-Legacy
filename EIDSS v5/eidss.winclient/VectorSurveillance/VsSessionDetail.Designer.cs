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
            this.tcData = new DevExpress.XtraTab.XtraTabControl();
            this.tpPools = new DevExpress.XtraTab.XtraTabPage();
            this.panelPoolSummary = new DevExpress.XtraEditors.PanelControl();
            this.gcSummary = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblQuantity = new DevExpress.XtraEditors.LabelControl();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.lblCollectionDateFrom = new DevExpress.XtraEditors.LabelControl();
            this.lblCollectionDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCollectionDateTo = new DevExpress.XtraEditors.LabelControl();
            this.dtCollectionDateTo = new DevExpress.XtraEditors.DateEdit();
            this.dtCollectionDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.treeSummarySpecies = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnSummary = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.panelPools = new DevExpress.XtraEditors.PanelControl();
            this.tpSamples = new DevExpress.XtraTab.XtraTabPage();
            this.panelSamples = new DevExpress.XtraEditors.PanelControl();
            this.tpFieldTests = new DevExpress.XtraTab.XtraTabPage();
            this.panelFieldTestsSummary = new DevExpress.XtraEditors.GroupControl();
            this.nvcFieldTestsSummary = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.panelFieldTests = new DevExpress.XtraEditors.PanelControl();
            this.tpLabTests = new DevExpress.XtraTab.XtraTabPage();
            this.panelLabTestsSummary = new DevExpress.XtraEditors.GroupControl();
            this.nvcLabTestsSummary = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.splitterControl4 = new DevExpress.XtraEditors.SplitterControl();
            this.panelLabTests = new DevExpress.XtraEditors.PanelControl();
            this.pcVectorTypeContainer = new DevExpress.XtraEditors.PanelControl();
            this.leVectorTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.lbVectorType = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtCloseDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCloseDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSessionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcData)).BeginInit();
            this.pcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcData)).BeginInit();
            this.tcData.SuspendLayout();
            this.tpPools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelPoolSummary)).BeginInit();
            this.panelPoolSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            this.gcSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeSummarySpecies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPools)).BeginInit();
            this.tpSamples.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSamples)).BeginInit();
            this.tpFieldTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFieldTestsSummary)).BeginInit();
            this.panelFieldTestsSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nvcFieldTestsSummary)).BeginInit();
            this.nvcFieldTestsSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFieldTests)).BeginInit();
            this.tpLabTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelLabTestsSummary)).BeginInit();
            this.panelLabTestsSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nvcLabTestsSummary)).BeginInit();
            this.nvcLabTestsSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelLabTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcVectorTypeContainer)).BeginInit();
            this.pcVectorTypeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leVectorTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pcGeneralSession
            // 
            resources.ApplyResources(this.pcGeneralSession, "pcGeneralSession");
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
            this.leSessionStatus.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.Appearance.GradientMode")));
            this.leSessionStatus.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.Appearance.Image")));
            this.leSessionStatus.Properties.Appearance.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceDisabled.GradientMode")));
            this.leSessionStatus.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceDisabled.Image")));
            this.leSessionStatus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDown.GradientMode")));
            this.leSessionStatus.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDown.Image")));
            this.leSessionStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDropDownHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDownHeader.GradientMode")));
            this.leSessionStatus.Properties.AppearanceDropDownHeader.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceDropDownHeader.Image")));
            this.leSessionStatus.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("leSessionStatus.Properties.AppearanceFocused.GradientMode")));
            this.leSessionStatus.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.AppearanceFocused.Image")));
            this.leSessionStatus.Properties.AppearanceFocused.Options.UseFont = true;
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
            this.bppLocation.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.Appearance.GradientMode")));
            this.bppLocation.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.Appearance.Image")));
            this.bppLocation.Properties.Appearance.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.GradientMode")));
            this.bppLocation.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceDisabled.Image")));
            this.bppLocation.Properties.AppearanceDisabled.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDropDown.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.GradientMode")));
            this.bppLocation.Properties.AppearanceDropDown.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceDropDown.Image")));
            this.bppLocation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bppLocation.Properties.AppearanceFocused.GradientMode")));
            this.bppLocation.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("bppLocation.Properties.AppearanceFocused.Image")));
            this.bppLocation.Properties.AppearanceFocused.Options.UseFont = true;
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
            this.dtCloseDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtCloseDate.Properties.VistaTimeProperties.AccessibleDescription");
            this.dtCloseDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtCloseDate.Properties.VistaTimeProperties.AccessibleName");
            this.dtCloseDate.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.AutoHeight")));
            this.dtCloseDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtCloseDate.Properties.VistaTimeProperties.Mask.EditMask");
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.Mask.MaskType")));
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.dtCloseDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtCloseDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtCloseDate.Properties.VistaTimeProperties.NullValuePrompt");
            this.dtCloseDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCloseDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
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
            this.dtStartDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtStartDate.Properties.VistaTimeProperties.AccessibleDescription");
            this.dtStartDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtStartDate.Properties.VistaTimeProperties.AccessibleName");
            this.dtStartDate.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.AutoHeight")));
            this.dtStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStartDate.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.dtStartDate.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.dtStartDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtStartDate.Properties.VistaTimeProperties.Mask.EditMask");
            this.dtStartDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtStartDate.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.Mask.MaskType")));
            this.dtStartDate.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.dtStartDate.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.dtStartDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.dtStartDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtStartDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtStartDate.Properties.VistaTimeProperties.NullValuePrompt");
            this.dtStartDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtStartDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
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
            this.lblStartDate.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblStartDate.Appearance.Font")));
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
            this.lblCloseDate.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblCloseDate.Appearance.Font")));
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
            this.lblCollectionEffort.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblCollectionEffort.Appearance.Font")));
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
            this.pcData.Controls.Add(this.tcData);
            this.pcData.Controls.Add(this.pcVectorTypeContainer);
            this.pcData.Name = "pcData";
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
            this.tpPools.Controls.Add(this.panelPoolSummary);
            this.tpPools.Controls.Add(this.splitterControl2);
            this.tpPools.Controls.Add(this.panelPools);
            this.tpPools.Name = "tpPools";
            // 
            // panelPoolSummary
            // 
            resources.ApplyResources(this.panelPoolSummary, "panelPoolSummary");
            this.panelPoolSummary.Controls.Add(this.gcSummary);
            this.panelPoolSummary.Name = "panelPoolSummary";
            // 
            // gcSummary
            // 
            resources.ApplyResources(this.gcSummary, "gcSummary");
            this.gcSummary.Controls.Add(this.panelControl1);
            this.gcSummary.Controls.Add(this.splitterControl1);
            this.gcSummary.Controls.Add(this.treeSummarySpecies);
            this.gcSummary.Name = "gcSummary";
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.lblQuantity);
            this.panelControl1.Controls.Add(this.txtQuantity);
            this.panelControl1.Controls.Add(this.lblCollectionDateFrom);
            this.panelControl1.Controls.Add(this.lblCollectionDate);
            this.panelControl1.Controls.Add(this.lblCollectionDateTo);
            this.panelControl1.Controls.Add(this.dtCollectionDateTo);
            this.panelControl1.Controls.Add(this.dtCollectionDateFrom);
            this.panelControl1.Name = "panelControl1";
            // 
            // lblQuantity
            // 
            resources.ApplyResources(this.lblQuantity, "lblQuantity");
            this.lblQuantity.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblQuantity.Appearance.DisabledImage")));
            this.lblQuantity.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblQuantity.Appearance.GradientMode")));
            this.lblQuantity.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblQuantity.Appearance.HoverImage")));
            this.lblQuantity.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblQuantity.Appearance.Image")));
            this.lblQuantity.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblQuantity.Appearance.PressedImage")));
            this.lblQuantity.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblQuantity.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblQuantity.Name = "lblQuantity";
            // 
            // txtQuantity
            // 
            resources.ApplyResources(this.txtQuantity, "txtQuantity");
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.AccessibleDescription = resources.GetString("txtQuantity.Properties.AccessibleDescription");
            this.txtQuantity.Properties.AccessibleName = resources.GetString("txtQuantity.Properties.AccessibleName");
            this.txtQuantity.Properties.AutoHeight = ((bool)(resources.GetObject("txtQuantity.Properties.AutoHeight")));
            this.txtQuantity.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtQuantity.Properties.Mask.AutoComplete")));
            this.txtQuantity.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtQuantity.Properties.Mask.BeepOnError")));
            this.txtQuantity.Properties.Mask.EditMask = resources.GetString("txtQuantity.Properties.Mask.EditMask");
            this.txtQuantity.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtQuantity.Properties.Mask.IgnoreMaskBlank")));
            this.txtQuantity.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtQuantity.Properties.Mask.MaskType")));
            this.txtQuantity.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtQuantity.Properties.Mask.PlaceHolder")));
            this.txtQuantity.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtQuantity.Properties.Mask.SaveLiteral")));
            this.txtQuantity.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtQuantity.Properties.Mask.ShowPlaceHolders")));
            this.txtQuantity.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtQuantity.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtQuantity.Properties.NullValuePrompt = resources.GetString("txtQuantity.Properties.NullValuePrompt");
            this.txtQuantity.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtQuantity.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblCollectionDateFrom
            // 
            resources.ApplyResources(this.lblCollectionDateFrom, "lblCollectionDateFrom");
            this.lblCollectionDateFrom.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDateFrom.Appearance.DisabledImage")));
            this.lblCollectionDateFrom.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCollectionDateFrom.Appearance.GradientMode")));
            this.lblCollectionDateFrom.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDateFrom.Appearance.HoverImage")));
            this.lblCollectionDateFrom.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCollectionDateFrom.Appearance.Image")));
            this.lblCollectionDateFrom.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDateFrom.Appearance.PressedImage")));
            this.lblCollectionDateFrom.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionDateFrom.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionDateFrom.Name = "lblCollectionDateFrom";
            // 
            // lblCollectionDate
            // 
            resources.ApplyResources(this.lblCollectionDate, "lblCollectionDate");
            this.lblCollectionDate.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDate.Appearance.DisabledImage")));
            this.lblCollectionDate.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCollectionDate.Appearance.GradientMode")));
            this.lblCollectionDate.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDate.Appearance.HoverImage")));
            this.lblCollectionDate.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCollectionDate.Appearance.Image")));
            this.lblCollectionDate.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDate.Appearance.PressedImage")));
            this.lblCollectionDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionDate.Name = "lblCollectionDate";
            // 
            // lblCollectionDateTo
            // 
            resources.ApplyResources(this.lblCollectionDateTo, "lblCollectionDateTo");
            this.lblCollectionDateTo.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDateTo.Appearance.DisabledImage")));
            this.lblCollectionDateTo.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblCollectionDateTo.Appearance.GradientMode")));
            this.lblCollectionDateTo.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDateTo.Appearance.HoverImage")));
            this.lblCollectionDateTo.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblCollectionDateTo.Appearance.Image")));
            this.lblCollectionDateTo.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblCollectionDateTo.Appearance.PressedImage")));
            this.lblCollectionDateTo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionDateTo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCollectionDateTo.Name = "lblCollectionDateTo";
            // 
            // dtCollectionDateTo
            // 
            resources.ApplyResources(this.dtCollectionDateTo, "dtCollectionDateTo");
            this.dtCollectionDateTo.Name = "dtCollectionDateTo";
            this.dtCollectionDateTo.Properties.AccessibleDescription = resources.GetString("dtCollectionDateTo.Properties.AccessibleDescription");
            this.dtCollectionDateTo.Properties.AccessibleName = resources.GetString("dtCollectionDateTo.Properties.AccessibleName");
            this.dtCollectionDateTo.Properties.AutoHeight = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.AutoHeight")));
            this.dtCollectionDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtCollectionDateTo.Properties.Buttons"))))});
            this.dtCollectionDateTo.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCollectionDateTo.Properties.Mask.AutoComplete")));
            this.dtCollectionDateTo.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.Mask.BeepOnError")));
            this.dtCollectionDateTo.Properties.Mask.EditMask = resources.GetString("dtCollectionDateTo.Properties.Mask.EditMask");
            this.dtCollectionDateTo.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.Mask.IgnoreMaskBlank")));
            this.dtCollectionDateTo.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCollectionDateTo.Properties.Mask.MaskType")));
            this.dtCollectionDateTo.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCollectionDateTo.Properties.Mask.PlaceHolder")));
            this.dtCollectionDateTo.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.Mask.SaveLiteral")));
            this.dtCollectionDateTo.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.Mask.ShowPlaceHolders")));
            this.dtCollectionDateTo.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtCollectionDateTo.Properties.NullValuePrompt = resources.GetString("dtCollectionDateTo.Properties.NullValuePrompt");
            this.dtCollectionDateTo.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.NullValuePromptShowForEmptyValue")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtCollectionDateTo.Properties.VistaTimeProperties.AccessibleDescription");
            this.dtCollectionDateTo.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtCollectionDateTo.Properties.VistaTimeProperties.AccessibleName");
            this.dtCollectionDateTo.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.AutoHeight")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.EditMask");
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.MaskType")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtCollectionDateTo.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtCollectionDateTo.Properties.VistaTimeProperties.NullValuePrompt");
            this.dtCollectionDateTo.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCollectionDateTo.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValu" +
        "e")));
            // 
            // dtCollectionDateFrom
            // 
            resources.ApplyResources(this.dtCollectionDateFrom, "dtCollectionDateFrom");
            this.dtCollectionDateFrom.Name = "dtCollectionDateFrom";
            this.dtCollectionDateFrom.Properties.AccessibleDescription = resources.GetString("dtCollectionDateFrom.Properties.AccessibleDescription");
            this.dtCollectionDateFrom.Properties.AccessibleName = resources.GetString("dtCollectionDateFrom.Properties.AccessibleName");
            this.dtCollectionDateFrom.Properties.AutoHeight = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.AutoHeight")));
            this.dtCollectionDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtCollectionDateFrom.Properties.Buttons"))))});
            this.dtCollectionDateFrom.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.AutoComplete")));
            this.dtCollectionDateFrom.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.BeepOnError")));
            this.dtCollectionDateFrom.Properties.Mask.EditMask = resources.GetString("dtCollectionDateFrom.Properties.Mask.EditMask");
            this.dtCollectionDateFrom.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.IgnoreMaskBlank")));
            this.dtCollectionDateFrom.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.MaskType")));
            this.dtCollectionDateFrom.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.PlaceHolder")));
            this.dtCollectionDateFrom.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.SaveLiteral")));
            this.dtCollectionDateFrom.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.ShowPlaceHolders")));
            this.dtCollectionDateFrom.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtCollectionDateFrom.Properties.NullValuePrompt = resources.GetString("dtCollectionDateFrom.Properties.NullValuePrompt");
            this.dtCollectionDateFrom.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.NullValuePromptShowForEmptyValue")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtCollectionDateFrom.Properties.VistaTimeProperties.AccessibleDescription");
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtCollectionDateFrom.Properties.VistaTimeProperties.AccessibleName");
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.AutoHeight")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.EditMask");
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.MaskType")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtCollectionDateFrom.Properties.VistaTimeProperties.NullValuePrompt");
            this.dtCollectionDateFrom.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtCollectionDateFrom.Properties.VistaTimeProperties.NullValuePromptShowForEmptyVa" +
        "lue")));
            // 
            // splitterControl1
            // 
            resources.ApplyResources(this.splitterControl1, "splitterControl1");
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.TabStop = false;
            // 
            // treeSummarySpecies
            // 
            resources.ApplyResources(this.treeSummarySpecies, "treeSummarySpecies");
            this.treeSummarySpecies.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnSummary});
            this.treeSummarySpecies.Name = "treeSummarySpecies";
            this.treeSummarySpecies.OptionsMenu.EnableColumnMenu = false;
            this.treeSummarySpecies.OptionsMenu.EnableFooterMenu = false;
            this.treeSummarySpecies.Click += new System.EventHandler(this.OnTreeSummarySpeciesClick);
            // 
            // treeListColumnSummary
            // 
            resources.ApplyResources(this.treeListColumnSummary, "treeListColumnSummary");
            this.treeListColumnSummary.Name = "treeListColumnSummary";
            this.treeListColumnSummary.OptionsColumn.AllowEdit = false;
            this.treeListColumnSummary.OptionsColumn.AllowMove = false;
            this.treeListColumnSummary.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.treeListColumnSummary.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // splitterControl2
            // 
            resources.ApplyResources(this.splitterControl2, "splitterControl2");
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.TabStop = false;
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
            this.tpFieldTests.Controls.Add(this.panelFieldTestsSummary);
            this.tpFieldTests.Controls.Add(this.splitterControl3);
            this.tpFieldTests.Controls.Add(this.panelFieldTests);
            this.tpFieldTests.Name = "tpFieldTests";
            // 
            // panelFieldTestsSummary
            // 
            resources.ApplyResources(this.panelFieldTestsSummary, "panelFieldTestsSummary");
            this.panelFieldTestsSummary.Controls.Add(this.nvcFieldTestsSummary);
            this.panelFieldTestsSummary.Name = "panelFieldTestsSummary";
            // 
            // nvcFieldTestsSummary
            // 
            resources.ApplyResources(this.nvcFieldTestsSummary, "nvcFieldTestsSummary");
            this.nvcFieldTestsSummary.ActiveGroup = this.navBarGroup1;
            this.nvcFieldTestsSummary.Controls.Add(this.navBarGroupControlContainer1);
            this.nvcFieldTestsSummary.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.nvcFieldTestsSummary.Name = "nvcFieldTestsSummary";
            this.nvcFieldTestsSummary.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.nvcFieldTestsSummary.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.nvcFieldTestsSummary.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
            this.nvcFieldTestsSummary.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.OnFieldTestsSummaryGroupExpandedCollapsed);
            this.nvcFieldTestsSummary.GroupCollapsed += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.OnFieldTestsSummaryGroupExpandedCollapsed);
            // 
            // navBarGroup1
            // 
            resources.ApplyResources(this.navBarGroup1, "navBarGroup1");
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 41;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroupControlContainer1
            // 
            resources.ApplyResources(this.navBarGroupControlContainer1, "navBarGroupControlContainer1");
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            // 
            // splitterControl3
            // 
            resources.ApplyResources(this.splitterControl3, "splitterControl3");
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.TabStop = false;
            // 
            // panelFieldTests
            // 
            resources.ApplyResources(this.panelFieldTests, "panelFieldTests");
            this.panelFieldTests.Name = "panelFieldTests";
            // 
            // tpLabTests
            // 
            resources.ApplyResources(this.tpLabTests, "tpLabTests");
            this.tpLabTests.Controls.Add(this.panelLabTestsSummary);
            this.tpLabTests.Controls.Add(this.splitterControl4);
            this.tpLabTests.Controls.Add(this.panelLabTests);
            this.tpLabTests.Name = "tpLabTests";
            // 
            // panelLabTestsSummary
            // 
            resources.ApplyResources(this.panelLabTestsSummary, "panelLabTestsSummary");
            this.panelLabTestsSummary.Controls.Add(this.nvcLabTestsSummary);
            this.panelLabTestsSummary.Name = "panelLabTestsSummary";
            // 
            // nvcLabTestsSummary
            // 
            resources.ApplyResources(this.nvcLabTestsSummary, "nvcLabTestsSummary");
            this.nvcLabTestsSummary.ActiveGroup = this.navBarGroup2;
            this.nvcLabTestsSummary.Controls.Add(this.navBarGroupControlContainer2);
            this.nvcLabTestsSummary.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup2});
            this.nvcLabTestsSummary.Name = "nvcLabTestsSummary";
            this.nvcLabTestsSummary.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth1")));
            this.nvcLabTestsSummary.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.nvcLabTestsSummary.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
            // 
            // navBarGroup2
            // 
            resources.ApplyResources(this.navBarGroup2, "navBarGroup2");
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupClientHeight = 41;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarGroupControlContainer2
            // 
            resources.ApplyResources(this.navBarGroupControlContainer2, "navBarGroupControlContainer2");
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            // 
            // splitterControl4
            // 
            resources.ApplyResources(this.splitterControl4, "splitterControl4");
            this.splitterControl4.Name = "splitterControl4";
            this.splitterControl4.TabStop = false;
            // 
            // panelLabTests
            // 
            resources.ApplyResources(this.panelLabTests, "panelLabTests");
            this.panelLabTests.Name = "panelLabTests";
            // 
            // pcVectorTypeContainer
            // 
            resources.ApplyResources(this.pcVectorTypeContainer, "pcVectorTypeContainer");
            this.pcVectorTypeContainer.Controls.Add(this.leVectorTypes);
            this.pcVectorTypeContainer.Controls.Add(this.lbVectorType);
            this.pcVectorTypeContainer.Name = "pcVectorTypeContainer";
            // 
            // leVectorTypes
            // 
            resources.ApplyResources(this.leVectorTypes, "leVectorTypes");
            this.leVectorTypes.Name = "leVectorTypes";
            this.leVectorTypes.Properties.AccessibleDescription = resources.GetString("leVectorTypes.Properties.AccessibleDescription");
            this.leVectorTypes.Properties.AccessibleName = resources.GetString("leVectorTypes.Properties.AccessibleName");
            this.leVectorTypes.Properties.AutoHeight = ((bool)(resources.GetObject("leVectorTypes.Properties.AutoHeight")));
            this.leVectorTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leVectorTypes.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.leVectorTypes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leVectorTypes.Properties.Columns"), resources.GetString("leVectorTypes.Properties.Columns1"))});
            this.leVectorTypes.Properties.DisplayMember = "VectorTypeNationalName";
            this.leVectorTypes.Properties.NullText = resources.GetString("leVectorTypes.Properties.NullText");
            this.leVectorTypes.Properties.NullValuePrompt = resources.GetString("leVectorTypes.Properties.NullValuePrompt");
            this.leVectorTypes.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("leVectorTypes.Properties.NullValuePromptShowForEmptyValue")));
            this.leVectorTypes.Properties.ShowFooter = false;
            this.leVectorTypes.Properties.ShowHeader = false;
            this.leVectorTypes.Properties.ShowLines = false;
            this.leVectorTypes.Properties.ValueMember = "idfsVectorType";
            this.leVectorTypes.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.OnVectorTypeButtonClick);
            this.leVectorTypes.EditValueChanged += new System.EventHandler(this.OnVectorTypesEditValueChanged);
            // 
            // lbVectorType
            // 
            resources.ApplyResources(this.lbVectorType, "lbVectorType");
            this.lbVectorType.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbVectorType.Appearance.DisabledImage")));
            this.lbVectorType.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbVectorType.Appearance.GradientMode")));
            this.lbVectorType.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbVectorType.Appearance.HoverImage")));
            this.lbVectorType.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbVectorType.Appearance.Image")));
            this.lbVectorType.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbVectorType.Appearance.PressedImage")));
            this.lbVectorType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbVectorType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbVectorType.Name = "lbVectorType";
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
            ((System.ComponentModel.ISupportInitialize)(this.dtCloseDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCloseDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSessionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcData)).EndInit();
            this.pcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcData)).EndInit();
            this.tcData.ResumeLayout(false);
            this.tpPools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelPoolSummary)).EndInit();
            this.panelPoolSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            this.gcSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCollectionDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeSummarySpecies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPools)).EndInit();
            this.tpSamples.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSamples)).EndInit();
            this.tpFieldTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelFieldTestsSummary)).EndInit();
            this.panelFieldTestsSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nvcFieldTestsSummary)).EndInit();
            this.nvcFieldTestsSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelFieldTests)).EndInit();
            this.tpLabTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelLabTestsSummary)).EndInit();
            this.panelLabTestsSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nvcLabTestsSummary)).EndInit();
            this.nvcLabTestsSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelLabTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcVectorTypeContainer)).EndInit();
            this.pcVectorTypeContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leVectorTypes.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lbVectorType;
        private DevExpress.XtraTab.XtraTabControl tcData;
        private DevExpress.XtraTab.XtraTabPage tpPools;
        private DevExpress.XtraTab.XtraTabPage tpSamples;
        private DevExpress.XtraTab.XtraTabPage tpFieldTests;
        private DevExpress.XtraTab.XtraTabPage tpLabTests;
        private eidss.winclient.Location.LocationLookup bppLocation;
        private DevExpress.XtraEditors.LookUpEdit leSessionStatus;
        private DevExpress.XtraEditors.PanelControl pcVectorTypeContainer;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection1;
        private DevExpress.XtraEditors.LookUpEdit leVectorTypes;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection2;
        private bv.model.BLToolkit.RemoteProvider.Client.RemoteSqlConnection remoteSqlConnection3;
        private DevExpress.XtraEditors.PanelControl panelSamples;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.PanelControl panelPoolSummary;
        private DevExpress.XtraEditors.GroupControl gcSummary;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.LabelControl lblCollectionDateFrom;
        private DevExpress.XtraEditors.LabelControl lblCollectionDate;
        private DevExpress.XtraEditors.LabelControl lblCollectionDateTo;
        private DevExpress.XtraEditors.DateEdit dtCollectionDateTo;
        private DevExpress.XtraEditors.DateEdit dtCollectionDateFrom;
        private DevExpress.XtraEditors.PanelControl panelPools;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraEditors.PanelControl panelFieldTests;
        private DevExpress.XtraEditors.PanelControl panelLabTests;
        private DevExpress.XtraEditors.GroupControl panelFieldTestsSummary;
        private DevExpress.XtraNavBar.NavBarControl nvcFieldTestsSummary;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraEditors.GroupControl panelLabTestsSummary;
        private DevExpress.XtraEditors.SplitterControl splitterControl4;
        private DevExpress.XtraEditors.LabelControl lblQuantity;
        private DevExpress.XtraEditors.LabelControl lblCollectionEffort;
        private DevExpress.XtraEditors.SpinEdit seCollectionEffort;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraTreeList.TreeList treeSummarySpecies;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnSummary;
        private DevExpress.XtraNavBar.NavBarControl nvcLabTestsSummary;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
    }
}
