namespace eidss.winclient.Security
{
    partial class UserGroupDetailPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGroupDetailPanel));
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpUsersGroups = new DevExpress.XtraTab.XtraTabPage();
            this.tpSystemFunctions = new DevExpress.XtraTab.XtraTabPage();
            this.pSystemFunctionsDown = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblNameNational = new DevExpress.XtraEditors.LabelControl();
            this.txtNameNational = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpSystemFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSystemFunctionsDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameNational.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(UserGroupDetailPanel), out resources);
            // Form Is Localizable: True
            // 
            // tcMain
            // 
            this.tcMain.Appearance.Options.UseFont = true;
            this.tcMain.AppearancePage.Header.Options.UseFont = true;
            this.tcMain.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tcMain.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tcMain.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tcMain.AppearancePage.PageClient.Options.UseFont = true;
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpUsersGroups;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpUsersGroups,
            this.tpSystemFunctions});
            // 
            // tpUsersGroups
            // 
            this.tpUsersGroups.Appearance.Header.Options.UseFont = true;
            this.tpUsersGroups.Appearance.HeaderActive.Options.UseFont = true;
            this.tpUsersGroups.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tpUsersGroups.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tpUsersGroups.Appearance.PageClient.Options.UseFont = true;
            this.tpUsersGroups.Name = "tpUsersGroups";
            resources.ApplyResources(this.tpUsersGroups, "tpUsersGroups");
            // 
            // tpSystemFunctions
            // 
            this.tpSystemFunctions.Appearance.Header.Options.UseFont = true;
            this.tpSystemFunctions.Appearance.HeaderActive.Options.UseFont = true;
            this.tpSystemFunctions.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tpSystemFunctions.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tpSystemFunctions.Appearance.PageClient.Options.UseFont = true;
            this.tpSystemFunctions.Controls.Add(this.pSystemFunctionsDown);
            this.tpSystemFunctions.Name = "tpSystemFunctions";
            resources.ApplyResources(this.tpSystemFunctions, "tpSystemFunctions");
            // 
            // pSystemFunctionsDown
            // 
            this.pSystemFunctionsDown.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.pSystemFunctionsDown, "pSystemFunctionsDown");
            this.pSystemFunctionsDown.Name = "pSystemFunctionsDown";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.lblNameNational);
            this.groupControl1.Controls.Add(this.txtNameNational);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtDescription);
            this.groupControl1.Controls.Add(this.txtName);
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Name = "groupControl1";
            // 
            // lblNameNational
            // 
            resources.ApplyResources(this.lblNameNational, "lblNameNational");
            this.lblNameNational.Name = "lblNameNational";
            // 
            // txtNameNational
            // 
            resources.ApplyResources(this.txtNameNational, "txtNameNational");
            this.txtNameNational.Name = "txtNameNational";
            this.txtNameNational.Properties.Appearance.Options.UseFont = true;
            this.txtNameNational.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtNameNational.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtNameNational.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Appearance.Options.UseFont = true;
            this.txtDescription.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtDescription.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtDescription.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtName.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtName.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // UserGroupDetailPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.groupControl1);
            this.Icon = global::eidss.winclient.Properties.Resources.User_Group_133_;
            this.Name = "UserGroupDetailPanel";
            this.Sizable = true;
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpSystemFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pSystemFunctionsDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNameNational.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpUsersGroups;
        private DevExpress.XtraTab.XtraTabPage tpSystemFunctions;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.PanelControl pSystemFunctionsDown;
        private DevExpress.XtraEditors.LabelControl lblNameNational;
        private DevExpress.XtraEditors.TextEdit txtNameNational;
    }
}
