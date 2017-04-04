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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
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
            // 
            // lblFormID
            // 
            this.lblFormID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFormID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblFormID, "lblFormID");
            this.lblFormID.Name = "lblFormID";
            // 
            // lblYear
            // 
            this.lblYear.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblYear.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblYear, "lblYear");
            this.lblYear.Name = "lblYear";
            // 
            // lblDateEntered
            // 
            this.lblDateEntered.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDateEntered.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblDateEntered, "lblDateEntered");
            this.lblDateEntered.Name = "lblDateEntered";
            // 
            // lblDateLastSaved
            // 
            this.lblDateLastSaved.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDateLastSaved.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblDateLastSaved, "lblDateLastSaved");
            this.lblDateLastSaved.Name = "lblDateLastSaved";
            // 
            // txtCreatedBy
            // 
            resources.ApplyResources(this.txtCreatedBy, "txtCreatedBy");
            this.txtCreatedBy.Name = "txtCreatedBy";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCreatedBy.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblCreatedBy, "lblCreatedBy");
            this.lblCreatedBy.Name = "lblCreatedBy";
            // 
            // txtSite
            // 
            resources.ApplyResources(this.txtSite, "txtSite");
            this.txtSite.Name = "txtSite";
            // 
            // lblSite
            // 
            this.lblSite.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSite.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblSite, "lblSite");
            this.lblSite.Name = "lblSite";
            // 
            // lblWeek
            // 
            this.lblWeek.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblWeek.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblWeek, "lblWeek");
            this.lblWeek.Name = "lblWeek";
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
            this.cbYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbYear.Properties.Buttons"))))});
            // 
            // leWeek
            // 
            resources.ApplyResources(this.leWeek, "leWeek");
            this.leWeek.Name = "leWeek";
            this.leWeek.Properties.Appearance.Options.UseFont = true;
            this.leWeek.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leWeek.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leWeek.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leWeek.Properties.AppearanceFocused.Options.UseFont = true;
            this.leWeek.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject2.Options.UseFont = true;
            this.leWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leWeek.Properties.Buttons"))), resources.GetString("leWeek.Properties.Buttons1"), ((int)(resources.GetObject("leWeek.Properties.Buttons2"))), ((bool)(resources.GetObject("leWeek.Properties.Buttons3"))), ((bool)(resources.GetObject("leWeek.Properties.Buttons4"))), ((bool)(resources.GetObject("leWeek.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leWeek.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leWeek.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("leWeek.Properties.Buttons8"), ((object)(resources.GetObject("leWeek.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leWeek.Properties.Buttons10"))), ((bool)(resources.GetObject("leWeek.Properties.Buttons11"))))});
            this.leWeek.Properties.NullText = resources.GetString("leWeek.Properties.NullText");
            // 
            // txtDateLastSaved
            // 
            resources.ApplyResources(this.txtDateLastSaved, "txtDateLastSaved");
            this.txtDateLastSaved.Name = "txtDateLastSaved";
            // 
            // txtDateEntered
            // 
            resources.ApplyResources(this.txtDateEntered, "txtDateEntered");
            this.txtDateEntered.Name = "txtDateEntered";
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
            this.Icon = global::eidss.winclient.Properties.Resources.bss_aggregate_detail_32x32;
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
