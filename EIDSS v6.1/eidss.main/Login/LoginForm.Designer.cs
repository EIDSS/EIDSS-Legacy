using System.Windows.Forms;
namespace eidss.main.Login
{
    partial class LoginForm
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
            Application.Idle -= UpdateLangIndicators;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.TabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.ImageListMain = new System.Windows.Forms.ImageList(this.components);
            this.TabPageMain = new DevExpress.XtraTab.XtraTabPage();
            this.lbPasswordLang = new DevExpress.XtraEditors.LabelControl();
            this.lbUserLang = new DevExpress.XtraEditors.LabelControl();
            this.lForgetPass = new System.Windows.Forms.LinkLabel();
            this.txtOrganization = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbOrganization = new DevExpress.XtraEditors.LabelControl();
            this.lbUserName = new DevExpress.XtraEditors.LabelControl();
            this.lbPassword = new DevExpress.XtraEditors.LabelControl();
            this.TabPageSQL = new DevExpress.XtraTab.XtraTabPage();
            this.txtSQLServer = new DevExpress.XtraEditors.TextEdit();
            this.txtSQLDatabase = new DevExpress.XtraEditors.TextEdit();
            this.txtSQLUser = new DevExpress.XtraEditors.TextEdit();
            this.txtSQLPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbSQLUserName = new DevExpress.XtraEditors.LabelControl();
            this.lbSQLPassword = new DevExpress.XtraEditors.LabelControl();
            this.lbServer = new DevExpress.XtraEditors.LabelControl();
            this.lbSQLDatabase = new DevExpress.XtraEditors.LabelControl();
            this.TabPageArchive = new DevExpress.XtraTab.XtraTabPage();
            this.chkAllowArchiveConnection = new DevExpress.XtraEditors.CheckEdit();
            this.txtArchiveServer = new DevExpress.XtraEditors.TextEdit();
            this.txtArchiveDatabase = new DevExpress.XtraEditors.TextEdit();
            this.txtArchiveUser = new DevExpress.XtraEditors.TextEdit();
            this.txtArchivePassword = new DevExpress.XtraEditors.TextEdit();
            this.lbArchiveUser = new DevExpress.XtraEditors.LabelControl();
            this.lbArchivePassword = new DevExpress.XtraEditors.LabelControl();
            this.lbArchiveServer = new DevExpress.XtraEditors.LabelControl();
            this.lbArchiveDatabase = new DevExpress.XtraEditors.LabelControl();
            this.TabPageAVRService = new DevExpress.XtraTab.XtraTabPage();
            this.txtAvrServiceUrl = new DevExpress.XtraEditors.TextEdit();
            this.txtAvrServicePort = new DevExpress.XtraEditors.TextEdit();
            this.lbAvrServiceUrl = new DevExpress.XtraEditors.LabelControl();
            this.lbAvrServicePort = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmdChangePassword = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlMain)).BeginInit();
            this.TabControlMain.SuspendLayout();
            this.TabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.TabPageSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLPassword.Properties)).BeginInit();
            this.TabPageArchive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowArchiveConnection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchiveServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchiveDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchiveUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivePassword.Properties)).BeginInit();
            this.TabPageAVRService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvrServiceUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvrServicePort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControlMain
            // 
            resources.ApplyResources(this.TabControlMain, "TabControlMain");
            this.TabControlMain.Images = this.ImageListMain;
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedTabPage = this.TabPageMain;
            this.TabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageMain,
            this.TabPageSQL,
            this.TabPageArchive,
            this.TabPageAVRService});
            // 
            // ImageListMain
            // 
            this.ImageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListMain.ImageStream")));
            this.ImageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListMain.Images.SetKeyName(0, "Chem16.ico");
            this.ImageListMain.Images.SetKeyName(1, "mdf_ndf_dbfiles.ico");
            this.ImageListMain.Images.SetKeyName(2, "logo-small.png");
            // 
            // TabPageMain
            // 
            this.TabPageMain.Controls.Add(this.lbPasswordLang);
            this.TabPageMain.Controls.Add(this.lbUserLang);
            this.TabPageMain.Controls.Add(this.lForgetPass);
            this.TabPageMain.Controls.Add(this.txtOrganization);
            this.TabPageMain.Controls.Add(this.txtUserName);
            this.TabPageMain.Controls.Add(this.txtPassword);
            this.TabPageMain.Controls.Add(this.lbOrganization);
            this.TabPageMain.Controls.Add(this.lbUserName);
            this.TabPageMain.Controls.Add(this.lbPassword);
            this.TabPageMain.ImageIndex = 2;
            this.TabPageMain.Name = "TabPageMain";
            resources.ApplyResources(this.TabPageMain, "TabPageMain");
            // 
            // lbPasswordLang
            // 
            this.lbPasswordLang.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbPasswordLang.Appearance.BackColor")));
            this.lbPasswordLang.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbPasswordLang.Appearance.ForeColor")));
            this.lbPasswordLang.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lbPasswordLang, "lbPasswordLang");
            this.lbPasswordLang.Name = "lbPasswordLang";
            // 
            // lbUserLang
            // 
            this.lbUserLang.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbUserLang.Appearance.BackColor")));
            this.lbUserLang.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbUserLang.Appearance.ForeColor")));
            this.lbUserLang.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lbUserLang, "lbUserLang");
            this.lbUserLang.Name = "lbUserLang";
            // 
            // lForgetPass
            // 
            resources.ApplyResources(this.lForgetPass, "lForgetPass");
            this.lForgetPass.Name = "lForgetPass";
            this.lForgetPass.TabStop = true;
            // 
            // txtOrganization
            // 
            resources.ApplyResources(this.txtOrganization, "txtOrganization");
            this.txtOrganization.Name = "txtOrganization";
            this.txtOrganization.Tag = "{M}";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Tag = "{M}";
            this.txtUserName.Enter += new System.EventHandler(this.Control_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Tag = "{M}";
            this.txtPassword.Enter += new System.EventHandler(this.Control_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // lbOrganization
            // 
            this.lbOrganization.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbOrganization, "lbOrganization");
            this.lbOrganization.Name = "lbOrganization";
            // 
            // lbUserName
            // 
            this.lbUserName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbUserName, "lbUserName");
            this.lbUserName.Name = "lbUserName";
            // 
            // lbPassword
            // 
            this.lbPassword.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Name = "lbPassword";
            // 
            // TabPageSQL
            // 
            this.TabPageSQL.Controls.Add(this.txtSQLServer);
            this.TabPageSQL.Controls.Add(this.txtSQLDatabase);
            this.TabPageSQL.Controls.Add(this.txtSQLUser);
            this.TabPageSQL.Controls.Add(this.txtSQLPassword);
            this.TabPageSQL.Controls.Add(this.lbSQLUserName);
            this.TabPageSQL.Controls.Add(this.lbSQLPassword);
            this.TabPageSQL.Controls.Add(this.lbServer);
            this.TabPageSQL.Controls.Add(this.lbSQLDatabase);
            this.TabPageSQL.ImageIndex = 1;
            this.TabPageSQL.Name = "TabPageSQL";
            resources.ApplyResources(this.TabPageSQL, "TabPageSQL");
            // 
            // txtSQLServer
            // 
            resources.ApplyResources(this.txtSQLServer, "txtSQLServer");
            this.txtSQLServer.Name = "txtSQLServer";
            this.txtSQLServer.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtSQLServer.Properties.Appearance.BackColor")));
            this.txtSQLServer.Properties.Appearance.Options.UseBackColor = true;
            this.txtSQLServer.Tag = "{M}";
            // 
            // txtSQLDatabase
            // 
            resources.ApplyResources(this.txtSQLDatabase, "txtSQLDatabase");
            this.txtSQLDatabase.Name = "txtSQLDatabase";
            this.txtSQLDatabase.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtSQLDatabase.Properties.Appearance.BackColor")));
            this.txtSQLDatabase.Properties.Appearance.Options.UseBackColor = true;
            this.txtSQLDatabase.Tag = "{M}";
            // 
            // txtSQLUser
            // 
            resources.ApplyResources(this.txtSQLUser, "txtSQLUser");
            this.txtSQLUser.Name = "txtSQLUser";
            this.txtSQLUser.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtSQLUser.Properties.Appearance.BackColor")));
            this.txtSQLUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtSQLUser.Tag = "{M}";
            // 
            // txtSQLPassword
            // 
            resources.ApplyResources(this.txtSQLPassword, "txtSQLPassword");
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.Properties.PasswordChar = '*';
            this.txtSQLPassword.Tag = "{M}";
            // 
            // lbSQLUserName
            // 
            this.lbSQLUserName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbSQLUserName, "lbSQLUserName");
            this.lbSQLUserName.Name = "lbSQLUserName";
            // 
            // lbSQLPassword
            // 
            this.lbSQLPassword.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbSQLPassword, "lbSQLPassword");
            this.lbSQLPassword.Name = "lbSQLPassword";
            // 
            // lbServer
            // 
            this.lbServer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbServer, "lbServer");
            this.lbServer.Name = "lbServer";
            // 
            // lbSQLDatabase
            // 
            this.lbSQLDatabase.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbSQLDatabase, "lbSQLDatabase");
            this.lbSQLDatabase.Name = "lbSQLDatabase";
            // 
            // TabPageArchive
            // 
            this.TabPageArchive.Controls.Add(this.chkAllowArchiveConnection);
            this.TabPageArchive.Controls.Add(this.txtArchiveServer);
            this.TabPageArchive.Controls.Add(this.txtArchiveDatabase);
            this.TabPageArchive.Controls.Add(this.txtArchiveUser);
            this.TabPageArchive.Controls.Add(this.txtArchivePassword);
            this.TabPageArchive.Controls.Add(this.lbArchiveUser);
            this.TabPageArchive.Controls.Add(this.lbArchivePassword);
            this.TabPageArchive.Controls.Add(this.lbArchiveServer);
            this.TabPageArchive.Controls.Add(this.lbArchiveDatabase);
            this.TabPageArchive.Name = "TabPageArchive";
            resources.ApplyResources(this.TabPageArchive, "TabPageArchive");
            // 
            // chkAllowArchiveConnection
            // 
            resources.ApplyResources(this.chkAllowArchiveConnection, "chkAllowArchiveConnection");
            this.chkAllowArchiveConnection.Name = "chkAllowArchiveConnection";
            this.chkAllowArchiveConnection.Properties.Caption = resources.GetString("chkAllowArchiveConnection.Properties.Caption");
            this.chkAllowArchiveConnection.CheckedChanged += new System.EventHandler(this.chkAllowArchiveConnection_CheckedChanged);
            // 
            // txtArchiveServer
            // 
            resources.ApplyResources(this.txtArchiveServer, "txtArchiveServer");
            this.txtArchiveServer.Name = "txtArchiveServer";
            this.txtArchiveServer.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtArchiveServer.Properties.Appearance.BackColor")));
            this.txtArchiveServer.Properties.Appearance.Options.UseBackColor = true;
            this.txtArchiveServer.Tag = "";
            // 
            // txtArchiveDatabase
            // 
            resources.ApplyResources(this.txtArchiveDatabase, "txtArchiveDatabase");
            this.txtArchiveDatabase.Name = "txtArchiveDatabase";
            this.txtArchiveDatabase.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtArchiveDatabase.Properties.Appearance.BackColor")));
            this.txtArchiveDatabase.Properties.Appearance.Options.UseBackColor = true;
            this.txtArchiveDatabase.Tag = "";
            // 
            // txtArchiveUser
            // 
            resources.ApplyResources(this.txtArchiveUser, "txtArchiveUser");
            this.txtArchiveUser.Name = "txtArchiveUser";
            this.txtArchiveUser.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtArchiveUser.Properties.Appearance.BackColor")));
            this.txtArchiveUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtArchiveUser.Tag = "{M}";
            // 
            // txtArchivePassword
            // 
            resources.ApplyResources(this.txtArchivePassword, "txtArchivePassword");
            this.txtArchivePassword.Name = "txtArchivePassword";
            this.txtArchivePassword.Properties.PasswordChar = '*';
            this.txtArchivePassword.Tag = "{M}";
            // 
            // lbArchiveUser
            // 
            this.lbArchiveUser.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbArchiveUser, "lbArchiveUser");
            this.lbArchiveUser.Name = "lbArchiveUser";
            // 
            // lbArchivePassword
            // 
            this.lbArchivePassword.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbArchivePassword, "lbArchivePassword");
            this.lbArchivePassword.Name = "lbArchivePassword";
            // 
            // lbArchiveServer
            // 
            this.lbArchiveServer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbArchiveServer, "lbArchiveServer");
            this.lbArchiveServer.Name = "lbArchiveServer";
            // 
            // lbArchiveDatabase
            // 
            this.lbArchiveDatabase.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbArchiveDatabase, "lbArchiveDatabase");
            this.lbArchiveDatabase.Name = "lbArchiveDatabase";
            // 
            // TabPageAVRService
            // 
            this.TabPageAVRService.Controls.Add(this.txtAvrServiceUrl);
            this.TabPageAVRService.Controls.Add(this.txtAvrServicePort);
            this.TabPageAVRService.Controls.Add(this.lbAvrServiceUrl);
            this.TabPageAVRService.Controls.Add(this.lbAvrServicePort);
            this.TabPageAVRService.Name = "TabPageAVRService";
            resources.ApplyResources(this.TabPageAVRService, "TabPageAVRService");
            // 
            // txtAvrServiceUrl
            // 
            resources.ApplyResources(this.txtAvrServiceUrl, "txtAvrServiceUrl");
            this.txtAvrServiceUrl.Name = "txtAvrServiceUrl";
            this.txtAvrServiceUrl.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtAvrServiceUrl.Properties.Appearance.BackColor")));
            this.txtAvrServiceUrl.Properties.Appearance.Options.UseBackColor = true;
            this.txtAvrServiceUrl.Tag = "";
            // 
            // txtAvrServicePort
            // 
            resources.ApplyResources(this.txtAvrServicePort, "txtAvrServicePort");
            this.txtAvrServicePort.Name = "txtAvrServicePort";
            this.txtAvrServicePort.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtAvrServicePort.Properties.Appearance.BackColor")));
            this.txtAvrServicePort.Properties.Appearance.Options.UseBackColor = true;
            this.txtAvrServicePort.Tag = "";
            // 
            // lbAvrServiceUrl
            // 
            this.lbAvrServiceUrl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbAvrServiceUrl, "lbAvrServiceUrl");
            this.lbAvrServiceUrl.Name = "lbAvrServiceUrl";
            // 
            // lbAvrServicePort
            // 
            this.lbAvrServicePort.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbAvrServicePort, "lbAvrServicePort");
            this.lbAvrServicePort.Name = "lbAvrServicePort";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmdChangePassword
            // 
            resources.ApplyResources(this.cmdChangePassword, "cmdChangePassword");
            this.cmdChangePassword.Name = "cmdChangePassword";
            this.cmdChangePassword.Click += new System.EventHandler(this.cmdChangePassword_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmdChangePassword);
            this.Controls.Add(this.TabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpTopicId = "Logging_on";
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.VisibleChanged += new System.EventHandler(this.LoginForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.TabControlMain)).EndInit();
            this.TabControlMain.ResumeLayout(false);
            this.TabPageMain.ResumeLayout(false);
            this.TabPageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.TabPageSQL.ResumeLayout(false);
            this.TabPageSQL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLPassword.Properties)).EndInit();
            this.TabPageArchive.ResumeLayout(false);
            this.TabPageArchive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowArchiveConnection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchiveServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchiveDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchiveUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivePassword.Properties)).EndInit();
            this.TabPageAVRService.ResumeLayout(false);
            this.TabPageAVRService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvrServiceUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvrServicePort.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl lbPasswordLang;
        internal DevExpress.XtraEditors.LabelControl lbUserLang;
        private DevExpress.XtraTab.XtraTabControl TabControlMain;
        private DevExpress.XtraTab.XtraTabPage TabPageMain;
        private System.Windows.Forms.LinkLabel lForgetPass;
        private DevExpress.XtraEditors.TextEdit txtOrganization;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lbOrganization;
        private DevExpress.XtraEditors.LabelControl lbUserName;
        private DevExpress.XtraEditors.LabelControl lbPassword;
        private DevExpress.XtraTab.XtraTabPage TabPageSQL;
        private DevExpress.XtraEditors.TextEdit txtSQLServer;
        private DevExpress.XtraEditors.TextEdit txtSQLDatabase;
        private DevExpress.XtraEditors.TextEdit txtSQLUser;
        private DevExpress.XtraEditors.TextEdit txtSQLPassword;
        private DevExpress.XtraEditors.LabelControl lbSQLUserName;
        private DevExpress.XtraEditors.LabelControl lbSQLPassword;
        private DevExpress.XtraEditors.LabelControl lbServer;
        private DevExpress.XtraEditors.LabelControl lbSQLDatabase;
        internal System.Windows.Forms.ImageList ImageListMain;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton cmdChangePassword;
        private DevExpress.XtraTab.XtraTabPage TabPageArchive;
        private DevExpress.XtraEditors.TextEdit txtArchiveServer;
        private DevExpress.XtraEditors.TextEdit txtArchiveDatabase;
        private DevExpress.XtraEditors.TextEdit txtArchiveUser;
        private DevExpress.XtraEditors.TextEdit txtArchivePassword;
        private DevExpress.XtraEditors.LabelControl lbArchiveUser;
        private DevExpress.XtraEditors.LabelControl lbArchivePassword;
        private DevExpress.XtraEditors.LabelControl lbArchiveServer;
        private DevExpress.XtraEditors.LabelControl lbArchiveDatabase;
        private DevExpress.XtraEditors.CheckEdit chkAllowArchiveConnection;
        private DevExpress.XtraTab.XtraTabPage TabPageAVRService;
        private DevExpress.XtraEditors.TextEdit txtAvrServiceUrl;
        private DevExpress.XtraEditors.TextEdit txtAvrServicePort;
        private DevExpress.XtraEditors.LabelControl lbAvrServiceUrl;
        private DevExpress.XtraEditors.LabelControl lbAvrServicePort;
    }
}