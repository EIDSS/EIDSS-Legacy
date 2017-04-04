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
            resources.ApplyResources(this.pcGeneralSession, "pcGeneralSession");
            this.pcGeneralSession.Name = "pcGeneralSession";
            // 
            // seCollectionEffort
            // 
            resources.ApplyResources(this.seCollectionEffort, "seCollectionEffort");
            this.seCollectionEffort.Name = "seCollectionEffort";
            this.seCollectionEffort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // leSessionStatus
            // 
            resources.ApplyResources(this.leSessionStatus, "leSessionStatus");
            this.leSessionStatus.Name = "leSessionStatus";
            this.leSessionStatus.Properties.Appearance.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceFocused.Options.UseFont = true;
            this.leSessionStatus.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseFont = true;
            this.leSessionStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSessionStatus.Properties.Buttons"))), resources.GetString("leSessionStatus.Properties.Buttons1"), ((int)(resources.GetObject("leSessionStatus.Properties.Buttons2"))), ((bool)(resources.GetObject("leSessionStatus.Properties.Buttons3"))), ((bool)(resources.GetObject("leSessionStatus.Properties.Buttons4"))), ((bool)(resources.GetObject("leSessionStatus.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leSessionStatus.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leSessionStatus.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("leSessionStatus.Properties.Buttons8"), ((object)(resources.GetObject("leSessionStatus.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leSessionStatus.Properties.Buttons10"))), ((bool)(resources.GetObject("leSessionStatus.Properties.Buttons11"))))});
            this.leSessionStatus.Properties.NullText = resources.GetString("leSessionStatus.Properties.NullText");
            this.leSessionStatus.EditValueChanged += new System.EventHandler(this.OnSessionStatusEditValueChanged);
            // 
            // bppLocation
            // 
            resources.ApplyResources(this.bppLocation, "bppLocation");
            this.bppLocation.Name = "bppLocation";
            this.bppLocation.Properties.Appearance.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDisabled.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceFocused.Options.UseFont = true;
            this.bppLocation.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.bppLocation.Properties.AutoHeight = ((bool)(resources.GetObject("bppLocation.Properties.AutoHeight")));
            this.bppLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("bppLocation.Properties.Buttons"))))});
            this.bppLocation.Properties.CloseOnOuterMouseClick = false;
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
            // 
            // beOutbreakID
            // 
            resources.ApplyResources(this.beOutbreakID, "beOutbreakID");
            this.beOutbreakID.Name = "beOutbreakID";
            this.beOutbreakID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("beOutbreakID.Properties.Buttons"))))});
            this.beOutbreakID.TextChanged += new System.EventHandler(this.beOutbreakID_TextChanged);
            // 
            // lblOutbreak
            // 
            this.lblOutbreak.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblOutbreak.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblOutbreak, "lblOutbreak");
            this.lblOutbreak.Name = "lblOutbreak";
            // 
            // lblLocation
            // 
            this.lblLocation.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblLocation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // txtVectors
            // 
            resources.ApplyResources(this.txtVectors, "txtVectors");
            this.txtVectors.Name = "txtVectors";
            // 
            // txtFieldSessionID
            // 
            resources.ApplyResources(this.txtFieldSessionID, "txtFieldSessionID");
            this.txtFieldSessionID.Name = "txtFieldSessionID";
            // 
            // dtCloseDate
            // 
            resources.ApplyResources(this.dtCloseDate, "dtCloseDate");
            this.dtCloseDate.Name = "dtCloseDate";
            this.dtCloseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtCloseDate.Properties.Buttons"))))});
            this.dtCloseDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // dtStartDate
            // 
            resources.ApplyResources(this.dtStartDate, "dtStartDate");
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtStartDate.Properties.Buttons"))))});
            this.dtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // txtSessionID
            // 
            resources.ApplyResources(this.txtSessionID, "txtSessionID");
            this.txtSessionID.Name = "txtSessionID";
            // 
            // lblDescription
            // 
            this.lblDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // lblVectors
            // 
            this.lblVectors.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblVectors.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblVectors, "lblVectors");
            this.lblVectors.Name = "lblVectors";
            // 
            // lblSessionStatus
            // 
            this.lblSessionStatus.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSessionStatus.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblSessionStatus, "lblSessionStatus");
            this.lblSessionStatus.Name = "lblSessionStatus";
            // 
            // lblFieldSessionID
            // 
            this.lblFieldSessionID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFieldSessionID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblFieldSessionID, "lblFieldSessionID");
            this.lblFieldSessionID.Name = "lblFieldSessionID";
            // 
            // lblSessionID
            // 
            this.lblSessionID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSessionID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblSessionID, "lblSessionID");
            this.lblSessionID.Name = "lblSessionID";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStartDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Name = "lblStartDate";
            // 
            // lblCloseDate
            // 
            this.lblCloseDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCloseDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblCloseDate, "lblCloseDate");
            this.lblCloseDate.Name = "lblCloseDate";
            // 
            // lblCollectionEffort
            // 
            this.lblCollectionEffort.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCollectionEffort.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblCollectionEffort, "lblCollectionEffort");
            this.lblCollectionEffort.Name = "lblCollectionEffort";
            // 
            // pcData
            // 
            this.pcData.Controls.Add(this.tcMain);
            resources.ApplyResources(this.pcData, "pcData");
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
            this.tpDetailedInfo.Controls.Add(this.tcData);
            this.tpDetailedInfo.Name = "tpDetailedInfo";
            resources.ApplyResources(this.tpDetailedInfo, "tpDetailedInfo");
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
            this.tpPools.Controls.Add(this.panelPools);
            this.tpPools.Name = "tpPools";
            resources.ApplyResources(this.tpPools, "tpPools");
            // 
            // panelPools
            // 
            resources.ApplyResources(this.panelPools, "panelPools");
            this.panelPools.Name = "panelPools";
            // 
            // tpSamples
            // 
            this.tpSamples.Controls.Add(this.panelSamples);
            this.tpSamples.Name = "tpSamples";
            resources.ApplyResources(this.tpSamples, "tpSamples");
            // 
            // panelSamples
            // 
            resources.ApplyResources(this.panelSamples, "panelSamples");
            this.panelSamples.Name = "panelSamples";
            // 
            // tpFieldTests
            // 
            this.tpFieldTests.Controls.Add(this.panelFieldTests);
            this.tpFieldTests.Name = "tpFieldTests";
            resources.ApplyResources(this.tpFieldTests, "tpFieldTests");
            // 
            // panelFieldTests
            // 
            resources.ApplyResources(this.panelFieldTests, "panelFieldTests");
            this.panelFieldTests.Name = "panelFieldTests";
            // 
            // tpLabTests
            // 
            this.tpLabTests.Controls.Add(this.panelLabTests);
            this.tpLabTests.Name = "tpLabTests";
            resources.ApplyResources(this.tpLabTests, "tpLabTests");
            // 
            // panelLabTests
            // 
            resources.ApplyResources(this.panelLabTests, "panelLabTests");
            this.panelLabTests.Name = "panelLabTests";
            // 
            // tpSummaryInfo
            // 
            this.tpSummaryInfo.Name = "tpSummaryInfo";
            resources.ApplyResources(this.tpSummaryInfo, "tpSummaryInfo");
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
