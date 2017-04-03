namespace eidss.winclient.Administration
{
    partial class PersonDetailPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonDetailPanel));
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpPersonalInformation = new DevExpress.XtraTab.XtraTabPage();
            this.lbPhone = new DevExpress.XtraEditors.LabelControl();
            this.lbPosition = new DevExpress.XtraEditors.LabelControl();
            this.lbDepartment = new DevExpress.XtraEditors.LabelControl();
            this.lbOrganization = new DevExpress.XtraEditors.LabelControl();
            this.lbLastName = new DevExpress.XtraEditors.LabelControl();
            this.lbMiddleName = new DevExpress.XtraEditors.LabelControl();
            this.lbFirstName = new DevExpress.XtraEditors.LabelControl();
            this.txtTelephone = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.txtMiddleName = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.cbOrganization = new DevExpress.XtraEditors.LookUpEdit();
            this.cbDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.cbRank = new DevExpress.XtraEditors.LookUpEdit();
            this.tpLogin = new DevExpress.XtraTab.XtraTabPage();
            this.tpGroups = new DevExpress.XtraTab.XtraTabPage();
            this.tbSystemFunctions = new DevExpress.XtraTab.XtraTabPage();
            this.pSystemFunctionsDown = new DevExpress.XtraEditors.PanelControl();
            this.pSystemFunctionsUp = new DevExpress.XtraEditors.PanelControl();
            this.leSites = new DevExpress.XtraEditors.LookUpEdit();
            this.lbSites = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpPersonalInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiddleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOrganization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRank.Properties)).BeginInit();
            this.tbSystemFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSystemFunctionsDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSystemFunctionsUp)).BeginInit();
            this.pSystemFunctionsUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leSites.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpPersonalInformation;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpPersonalInformation,
            this.tpLogin,
            this.tpGroups,
            this.tbSystemFunctions});
            // 
            // tpPersonalInformation
            // 
            this.tpPersonalInformation.Controls.Add(this.lbPhone);
            this.tpPersonalInformation.Controls.Add(this.lbPosition);
            this.tpPersonalInformation.Controls.Add(this.lbDepartment);
            this.tpPersonalInformation.Controls.Add(this.lbOrganization);
            this.tpPersonalInformation.Controls.Add(this.lbLastName);
            this.tpPersonalInformation.Controls.Add(this.lbMiddleName);
            this.tpPersonalInformation.Controls.Add(this.lbFirstName);
            this.tpPersonalInformation.Controls.Add(this.txtTelephone);
            this.tpPersonalInformation.Controls.Add(this.txtFirstName);
            this.tpPersonalInformation.Controls.Add(this.txtMiddleName);
            this.tpPersonalInformation.Controls.Add(this.txtLastName);
            this.tpPersonalInformation.Controls.Add(this.cbOrganization);
            this.tpPersonalInformation.Controls.Add(this.cbDepartment);
            this.tpPersonalInformation.Controls.Add(this.cbRank);
            this.tpPersonalInformation.Name = "tpPersonalInformation";
            resources.ApplyResources(this.tpPersonalInformation, "tpPersonalInformation");
            // 
            // lbPhone
            // 
            this.lbPhone.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbPhone.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbPhone.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbPhone, "lbPhone");
            this.lbPhone.Name = "lbPhone";
            // 
            // lbPosition
            // 
            this.lbPosition.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbPosition.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbPosition.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbPosition, "lbPosition");
            this.lbPosition.Name = "lbPosition";
            // 
            // lbDepartment
            // 
            this.lbDepartment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbDepartment.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbDepartment.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbDepartment, "lbDepartment");
            this.lbDepartment.Name = "lbDepartment";
            // 
            // lbOrganization
            // 
            this.lbOrganization.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbOrganization.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbOrganization.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbOrganization, "lbOrganization");
            this.lbOrganization.Name = "lbOrganization";
            // 
            // lbLastName
            // 
            this.lbLastName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbLastName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbLastName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbLastName, "lbLastName");
            this.lbLastName.Name = "lbLastName";
            // 
            // lbMiddleName
            // 
            this.lbMiddleName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbMiddleName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbMiddleName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbMiddleName, "lbMiddleName");
            this.lbMiddleName.Name = "lbMiddleName";
            // 
            // lbFirstName
            // 
            this.lbFirstName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbFirstName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbFirstName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbFirstName, "lbFirstName");
            this.lbFirstName.Name = "lbFirstName";
            // 
            // txtTelephone
            // 
            resources.ApplyResources(this.txtTelephone, "txtTelephone");
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Properties.Appearance.Options.UseFont = true;
            this.txtTelephone.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtTelephone.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtTelephone.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtTelephone.Tag = "{M}";
            // 
            // txtFirstName
            // 
            resources.ApplyResources(this.txtFirstName, "txtFirstName");
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.Appearance.Options.UseFont = true;
            this.txtFirstName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtFirstName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtFirstName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtFirstName.Tag = "{M}";
            // 
            // txtMiddleName
            // 
            resources.ApplyResources(this.txtMiddleName, "txtMiddleName");
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Properties.Appearance.Options.UseFont = true;
            this.txtMiddleName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtMiddleName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtMiddleName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtMiddleName.Tag = "";
            // 
            // txtLastName
            // 
            resources.ApplyResources(this.txtLastName, "txtLastName");
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.Appearance.Options.UseFont = true;
            this.txtLastName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtLastName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtLastName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtLastName.Tag = "{M}";
            // 
            // cbOrganization
            // 
            resources.ApplyResources(this.cbOrganization, "cbOrganization");
            this.cbOrganization.Name = "cbOrganization";
            this.cbOrganization.Properties.Appearance.Options.UseFont = true;
            this.cbOrganization.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbOrganization.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbOrganization.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbOrganization.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbOrganization.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbOrganization.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbOrganization.Properties.Buttons"))))});
            this.cbOrganization.Properties.NullText = resources.GetString("cbOrganization.Properties.NullText");
            this.cbOrganization.Tag = "{M}";
            // 
            // cbDepartment
            // 
            resources.ApplyResources(this.cbDepartment, "cbDepartment");
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Properties.Appearance.Options.UseFont = true;
            this.cbDepartment.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbDepartment.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbDepartment.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbDepartment.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbDepartment.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbDepartment.Properties.Buttons"))))});
            this.cbDepartment.Properties.NullText = resources.GetString("cbDepartment.Properties.NullText");
            // 
            // cbRank
            // 
            resources.ApplyResources(this.cbRank, "cbRank");
            this.cbRank.Name = "cbRank";
            this.cbRank.Properties.Appearance.Options.UseFont = true;
            this.cbRank.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cbRank.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbRank.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbRank.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbRank.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cbRank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbRank.Properties.Buttons"))))});
            this.cbRank.Properties.NullText = resources.GetString("cbRank.Properties.NullText");
            // 
            // tpLogin
            // 
            this.tpLogin.Name = "tpLogin";
            resources.ApplyResources(this.tpLogin, "tpLogin");
            // 
            // tpGroups
            // 
            this.tpGroups.Name = "tpGroups";
            resources.ApplyResources(this.tpGroups, "tpGroups");
            // 
            // tbSystemFunctions
            // 
            this.tbSystemFunctions.Controls.Add(this.pSystemFunctionsDown);
            this.tbSystemFunctions.Controls.Add(this.pSystemFunctionsUp);
            this.tbSystemFunctions.Name = "tbSystemFunctions";
            resources.ApplyResources(this.tbSystemFunctions, "tbSystemFunctions");
            // 
            // pSystemFunctionsDown
            // 
            resources.ApplyResources(this.pSystemFunctionsDown, "pSystemFunctionsDown");
            this.pSystemFunctionsDown.Name = "pSystemFunctionsDown";
            // 
            // pSystemFunctionsUp
            // 
            this.pSystemFunctionsUp.Controls.Add(this.leSites);
            this.pSystemFunctionsUp.Controls.Add(this.lbSites);
            resources.ApplyResources(this.pSystemFunctionsUp, "pSystemFunctionsUp");
            this.pSystemFunctionsUp.Name = "pSystemFunctionsUp";
            // 
            // leSites
            // 
            resources.ApplyResources(this.leSites, "leSites");
            this.leSites.Name = "leSites";
            this.leSites.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSites.Properties.Buttons"))))});
            this.leSites.Properties.NullText = resources.GetString("leSites.Properties.NullText");
            // 
            // lbSites
            // 
            this.lbSites.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbSites.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbSites, "lbSites");
            this.lbSites.Name = "lbSites";
            // 
            // PersonDetailPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMain);
            this.Icon = global::eidss.winclient.Properties.Resources.Employee_128_;
            this.Name = "PersonDetailPanel";
            this.Sizable = true;
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpPersonalInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiddleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOrganization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRank.Properties)).EndInit();
            this.tbSystemFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pSystemFunctionsDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSystemFunctionsUp)).EndInit();
            this.pSystemFunctionsUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leSites.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpPersonalInformation;
        private DevExpress.XtraTab.XtraTabPage tpLogin;
        private DevExpress.XtraTab.XtraTabPage tpGroups;
        private DevExpress.XtraTab.XtraTabPage tbSystemFunctions;
        internal DevExpress.XtraEditors.TextEdit txtFirstName;
        internal DevExpress.XtraEditors.TextEdit txtMiddleName;
        internal DevExpress.XtraEditors.TextEdit txtLastName;
        internal DevExpress.XtraEditors.LookUpEdit cbOrganization;
        internal DevExpress.XtraEditors.LookUpEdit cbDepartment;
        internal DevExpress.XtraEditors.LookUpEdit cbRank;
        internal DevExpress.XtraEditors.TextEdit txtTelephone;
        private DevExpress.XtraEditors.LabelControl lbPhone;
        private DevExpress.XtraEditors.LabelControl lbPosition;
        private DevExpress.XtraEditors.LabelControl lbDepartment;
        private DevExpress.XtraEditors.LabelControl lbOrganization;
        private DevExpress.XtraEditors.LabelControl lbLastName;
        private DevExpress.XtraEditors.LabelControl lbMiddleName;
        private DevExpress.XtraEditors.LabelControl lbFirstName;
        private DevExpress.XtraEditors.PanelControl pSystemFunctionsDown;
        private DevExpress.XtraEditors.PanelControl pSystemFunctionsUp;
        private DevExpress.XtraEditors.LookUpEdit leSites;
        private DevExpress.XtraEditors.LabelControl lbSites;
    }
}
