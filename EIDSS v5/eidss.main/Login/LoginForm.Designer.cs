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
            this.TabPageArchive});
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
            resources.ApplyResources(this.TabPageMain, "TabPageMain");
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
            // 
            // lbPasswordLang
            // 
            resources.ApplyResources(this.lbPasswordLang, "lbPasswordLang");
            this.lbPasswordLang.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbPasswordLang.Appearance.BackColor")));
            this.lbPasswordLang.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbPasswordLang.Appearance.DisabledImage")));
            this.lbPasswordLang.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbPasswordLang.Appearance.ForeColor")));
            this.lbPasswordLang.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbPasswordLang.Appearance.GradientMode")));
            this.lbPasswordLang.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbPasswordLang.Appearance.HoverImage")));
            this.lbPasswordLang.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbPasswordLang.Appearance.Image")));
            this.lbPasswordLang.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbPasswordLang.Appearance.PressedImage")));
            this.lbPasswordLang.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbPasswordLang.Name = "lbPasswordLang";
            // 
            // lbUserLang
            // 
            resources.ApplyResources(this.lbUserLang, "lbUserLang");
            this.lbUserLang.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbUserLang.Appearance.BackColor")));
            this.lbUserLang.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbUserLang.Appearance.DisabledImage")));
            this.lbUserLang.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbUserLang.Appearance.ForeColor")));
            this.lbUserLang.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbUserLang.Appearance.GradientMode")));
            this.lbUserLang.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbUserLang.Appearance.HoverImage")));
            this.lbUserLang.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbUserLang.Appearance.Image")));
            this.lbUserLang.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbUserLang.Appearance.PressedImage")));
            this.lbUserLang.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.txtOrganization.Properties.AccessibleDescription = resources.GetString("txtOrganization.Properties.AccessibleDescription");
            this.txtOrganization.Properties.AccessibleName = resources.GetString("txtOrganization.Properties.AccessibleName");
            this.txtOrganization.Properties.AutoHeight = ((bool)(resources.GetObject("txtOrganization.Properties.AutoHeight")));
            this.txtOrganization.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtOrganization.Properties.Mask.AutoComplete")));
            this.txtOrganization.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.BeepOnError")));
            this.txtOrganization.Properties.Mask.EditMask = resources.GetString("txtOrganization.Properties.Mask.EditMask");
            this.txtOrganization.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.IgnoreMaskBlank")));
            this.txtOrganization.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtOrganization.Properties.Mask.MaskType")));
            this.txtOrganization.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtOrganization.Properties.Mask.PlaceHolder")));
            this.txtOrganization.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.SaveLiteral")));
            this.txtOrganization.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.ShowPlaceHolders")));
            this.txtOrganization.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtOrganization.Properties.NullValuePrompt = resources.GetString("txtOrganization.Properties.NullValuePrompt");
            this.txtOrganization.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtOrganization.Properties.NullValuePromptShowForEmptyValue")));
            this.txtOrganization.Tag = "{M}";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.AccessibleDescription = resources.GetString("txtUserName.Properties.AccessibleDescription");
            this.txtUserName.Properties.AccessibleName = resources.GetString("txtUserName.Properties.AccessibleName");
            this.txtUserName.Properties.AutoHeight = ((bool)(resources.GetObject("txtUserName.Properties.AutoHeight")));
            this.txtUserName.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtUserName.Properties.Mask.AutoComplete")));
            this.txtUserName.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtUserName.Properties.Mask.BeepOnError")));
            this.txtUserName.Properties.Mask.EditMask = resources.GetString("txtUserName.Properties.Mask.EditMask");
            this.txtUserName.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtUserName.Properties.Mask.IgnoreMaskBlank")));
            this.txtUserName.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtUserName.Properties.Mask.MaskType")));
            this.txtUserName.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtUserName.Properties.Mask.PlaceHolder")));
            this.txtUserName.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtUserName.Properties.Mask.SaveLiteral")));
            this.txtUserName.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtUserName.Properties.Mask.ShowPlaceHolders")));
            this.txtUserName.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtUserName.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtUserName.Properties.NullValuePrompt = resources.GetString("txtUserName.Properties.NullValuePrompt");
            this.txtUserName.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtUserName.Properties.NullValuePromptShowForEmptyValue")));
            this.txtUserName.Tag = "{M}";
            this.txtUserName.Enter += new System.EventHandler(this.Control_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.AccessibleDescription = resources.GetString("txtPassword.Properties.AccessibleDescription");
            this.txtPassword.Properties.AccessibleName = resources.GetString("txtPassword.Properties.AccessibleName");
            this.txtPassword.Properties.AutoHeight = ((bool)(resources.GetObject("txtPassword.Properties.AutoHeight")));
            this.txtPassword.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtPassword.Properties.Mask.AutoComplete")));
            this.txtPassword.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtPassword.Properties.Mask.BeepOnError")));
            this.txtPassword.Properties.Mask.EditMask = resources.GetString("txtPassword.Properties.Mask.EditMask");
            this.txtPassword.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtPassword.Properties.Mask.IgnoreMaskBlank")));
            this.txtPassword.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtPassword.Properties.Mask.MaskType")));
            this.txtPassword.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtPassword.Properties.Mask.PlaceHolder")));
            this.txtPassword.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtPassword.Properties.Mask.SaveLiteral")));
            this.txtPassword.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtPassword.Properties.Mask.ShowPlaceHolders")));
            this.txtPassword.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtPassword.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtPassword.Properties.NullValuePrompt = resources.GetString("txtPassword.Properties.NullValuePrompt");
            this.txtPassword.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtPassword.Properties.NullValuePromptShowForEmptyValue")));
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Tag = "{M}";
            this.txtPassword.Enter += new System.EventHandler(this.Control_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // lbOrganization
            // 
            resources.ApplyResources(this.lbOrganization, "lbOrganization");
            this.lbOrganization.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbOrganization.Appearance.DisabledImage")));
            this.lbOrganization.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbOrganization.Appearance.GradientMode")));
            this.lbOrganization.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbOrganization.Appearance.HoverImage")));
            this.lbOrganization.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbOrganization.Appearance.Image")));
            this.lbOrganization.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbOrganization.Appearance.PressedImage")));
            this.lbOrganization.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbOrganization.Name = "lbOrganization";
            // 
            // lbUserName
            // 
            resources.ApplyResources(this.lbUserName, "lbUserName");
            this.lbUserName.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbUserName.Appearance.DisabledImage")));
            this.lbUserName.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbUserName.Appearance.GradientMode")));
            this.lbUserName.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbUserName.Appearance.HoverImage")));
            this.lbUserName.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbUserName.Appearance.Image")));
            this.lbUserName.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbUserName.Appearance.PressedImage")));
            this.lbUserName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbUserName.Name = "lbUserName";
            // 
            // lbPassword
            // 
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbPassword.Appearance.DisabledImage")));
            this.lbPassword.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbPassword.Appearance.GradientMode")));
            this.lbPassword.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbPassword.Appearance.HoverImage")));
            this.lbPassword.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbPassword.Appearance.Image")));
            this.lbPassword.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbPassword.Appearance.PressedImage")));
            this.lbPassword.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbPassword.Name = "lbPassword";
            // 
            // TabPageSQL
            // 
            resources.ApplyResources(this.TabPageSQL, "TabPageSQL");
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
            // 
            // txtSQLServer
            // 
            resources.ApplyResources(this.txtSQLServer, "txtSQLServer");
            this.txtSQLServer.Name = "txtSQLServer";
            this.txtSQLServer.Properties.AccessibleDescription = resources.GetString("txtSQLServer.Properties.AccessibleDescription");
            this.txtSQLServer.Properties.AccessibleName = resources.GetString("txtSQLServer.Properties.AccessibleName");
            this.txtSQLServer.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtSQLServer.Properties.Appearance.BackColor")));
            this.txtSQLServer.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("txtSQLServer.Properties.Appearance.GradientMode")));
            this.txtSQLServer.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("txtSQLServer.Properties.Appearance.Image")));
            this.txtSQLServer.Properties.Appearance.Options.UseBackColor = true;
            this.txtSQLServer.Properties.AutoHeight = ((bool)(resources.GetObject("txtSQLServer.Properties.AutoHeight")));
            this.txtSQLServer.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtSQLServer.Properties.Mask.AutoComplete")));
            this.txtSQLServer.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtSQLServer.Properties.Mask.BeepOnError")));
            this.txtSQLServer.Properties.Mask.EditMask = resources.GetString("txtSQLServer.Properties.Mask.EditMask");
            this.txtSQLServer.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtSQLServer.Properties.Mask.IgnoreMaskBlank")));
            this.txtSQLServer.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtSQLServer.Properties.Mask.MaskType")));
            this.txtSQLServer.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtSQLServer.Properties.Mask.PlaceHolder")));
            this.txtSQLServer.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtSQLServer.Properties.Mask.SaveLiteral")));
            this.txtSQLServer.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtSQLServer.Properties.Mask.ShowPlaceHolders")));
            this.txtSQLServer.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtSQLServer.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtSQLServer.Properties.NullValuePrompt = resources.GetString("txtSQLServer.Properties.NullValuePrompt");
            this.txtSQLServer.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtSQLServer.Properties.NullValuePromptShowForEmptyValue")));
            this.txtSQLServer.Tag = "{M}";
            // 
            // txtSQLDatabase
            // 
            resources.ApplyResources(this.txtSQLDatabase, "txtSQLDatabase");
            this.txtSQLDatabase.Name = "txtSQLDatabase";
            this.txtSQLDatabase.Properties.AccessibleDescription = resources.GetString("txtSQLDatabase.Properties.AccessibleDescription");
            this.txtSQLDatabase.Properties.AccessibleName = resources.GetString("txtSQLDatabase.Properties.AccessibleName");
            this.txtSQLDatabase.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtSQLDatabase.Properties.Appearance.BackColor")));
            this.txtSQLDatabase.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("txtSQLDatabase.Properties.Appearance.GradientMode")));
            this.txtSQLDatabase.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("txtSQLDatabase.Properties.Appearance.Image")));
            this.txtSQLDatabase.Properties.Appearance.Options.UseBackColor = true;
            this.txtSQLDatabase.Properties.AutoHeight = ((bool)(resources.GetObject("txtSQLDatabase.Properties.AutoHeight")));
            this.txtSQLDatabase.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtSQLDatabase.Properties.Mask.AutoComplete")));
            this.txtSQLDatabase.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtSQLDatabase.Properties.Mask.BeepOnError")));
            this.txtSQLDatabase.Properties.Mask.EditMask = resources.GetString("txtSQLDatabase.Properties.Mask.EditMask");
            this.txtSQLDatabase.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtSQLDatabase.Properties.Mask.IgnoreMaskBlank")));
            this.txtSQLDatabase.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtSQLDatabase.Properties.Mask.MaskType")));
            this.txtSQLDatabase.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtSQLDatabase.Properties.Mask.PlaceHolder")));
            this.txtSQLDatabase.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtSQLDatabase.Properties.Mask.SaveLiteral")));
            this.txtSQLDatabase.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtSQLDatabase.Properties.Mask.ShowPlaceHolders")));
            this.txtSQLDatabase.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtSQLDatabase.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtSQLDatabase.Properties.NullValuePrompt = resources.GetString("txtSQLDatabase.Properties.NullValuePrompt");
            this.txtSQLDatabase.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtSQLDatabase.Properties.NullValuePromptShowForEmptyValue")));
            this.txtSQLDatabase.Tag = "{M}";
            // 
            // txtSQLUser
            // 
            resources.ApplyResources(this.txtSQLUser, "txtSQLUser");
            this.txtSQLUser.Name = "txtSQLUser";
            this.txtSQLUser.Properties.AccessibleDescription = resources.GetString("txtSQLUser.Properties.AccessibleDescription");
            this.txtSQLUser.Properties.AccessibleName = resources.GetString("txtSQLUser.Properties.AccessibleName");
            this.txtSQLUser.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtSQLUser.Properties.Appearance.BackColor")));
            this.txtSQLUser.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("txtSQLUser.Properties.Appearance.GradientMode")));
            this.txtSQLUser.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("txtSQLUser.Properties.Appearance.Image")));
            this.txtSQLUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtSQLUser.Properties.AutoHeight = ((bool)(resources.GetObject("txtSQLUser.Properties.AutoHeight")));
            this.txtSQLUser.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtSQLUser.Properties.Mask.AutoComplete")));
            this.txtSQLUser.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtSQLUser.Properties.Mask.BeepOnError")));
            this.txtSQLUser.Properties.Mask.EditMask = resources.GetString("txtSQLUser.Properties.Mask.EditMask");
            this.txtSQLUser.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtSQLUser.Properties.Mask.IgnoreMaskBlank")));
            this.txtSQLUser.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtSQLUser.Properties.Mask.MaskType")));
            this.txtSQLUser.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtSQLUser.Properties.Mask.PlaceHolder")));
            this.txtSQLUser.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtSQLUser.Properties.Mask.SaveLiteral")));
            this.txtSQLUser.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtSQLUser.Properties.Mask.ShowPlaceHolders")));
            this.txtSQLUser.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtSQLUser.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtSQLUser.Properties.NullValuePrompt = resources.GetString("txtSQLUser.Properties.NullValuePrompt");
            this.txtSQLUser.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtSQLUser.Properties.NullValuePromptShowForEmptyValue")));
            this.txtSQLUser.Tag = "{M}";
            // 
            // txtSQLPassword
            // 
            resources.ApplyResources(this.txtSQLPassword, "txtSQLPassword");
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.Properties.AccessibleDescription = resources.GetString("txtSQLPassword.Properties.AccessibleDescription");
            this.txtSQLPassword.Properties.AccessibleName = resources.GetString("txtSQLPassword.Properties.AccessibleName");
            this.txtSQLPassword.Properties.AutoHeight = ((bool)(resources.GetObject("txtSQLPassword.Properties.AutoHeight")));
            this.txtSQLPassword.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtSQLPassword.Properties.Mask.AutoComplete")));
            this.txtSQLPassword.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtSQLPassword.Properties.Mask.BeepOnError")));
            this.txtSQLPassword.Properties.Mask.EditMask = resources.GetString("txtSQLPassword.Properties.Mask.EditMask");
            this.txtSQLPassword.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtSQLPassword.Properties.Mask.IgnoreMaskBlank")));
            this.txtSQLPassword.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtSQLPassword.Properties.Mask.MaskType")));
            this.txtSQLPassword.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtSQLPassword.Properties.Mask.PlaceHolder")));
            this.txtSQLPassword.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtSQLPassword.Properties.Mask.SaveLiteral")));
            this.txtSQLPassword.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtSQLPassword.Properties.Mask.ShowPlaceHolders")));
            this.txtSQLPassword.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtSQLPassword.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtSQLPassword.Properties.NullValuePrompt = resources.GetString("txtSQLPassword.Properties.NullValuePrompt");
            this.txtSQLPassword.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtSQLPassword.Properties.NullValuePromptShowForEmptyValue")));
            this.txtSQLPassword.Properties.PasswordChar = '*';
            this.txtSQLPassword.Tag = "{M}";
            // 
            // lbSQLUserName
            // 
            resources.ApplyResources(this.lbSQLUserName, "lbSQLUserName");
            this.lbSQLUserName.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbSQLUserName.Appearance.DisabledImage")));
            this.lbSQLUserName.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbSQLUserName.Appearance.GradientMode")));
            this.lbSQLUserName.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbSQLUserName.Appearance.HoverImage")));
            this.lbSQLUserName.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbSQLUserName.Appearance.Image")));
            this.lbSQLUserName.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbSQLUserName.Appearance.PressedImage")));
            this.lbSQLUserName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbSQLUserName.Name = "lbSQLUserName";
            // 
            // lbSQLPassword
            // 
            resources.ApplyResources(this.lbSQLPassword, "lbSQLPassword");
            this.lbSQLPassword.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbSQLPassword.Appearance.DisabledImage")));
            this.lbSQLPassword.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbSQLPassword.Appearance.GradientMode")));
            this.lbSQLPassword.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbSQLPassword.Appearance.HoverImage")));
            this.lbSQLPassword.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbSQLPassword.Appearance.Image")));
            this.lbSQLPassword.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbSQLPassword.Appearance.PressedImage")));
            this.lbSQLPassword.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbSQLPassword.Name = "lbSQLPassword";
            // 
            // lbServer
            // 
            resources.ApplyResources(this.lbServer, "lbServer");
            this.lbServer.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbServer.Appearance.DisabledImage")));
            this.lbServer.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbServer.Appearance.GradientMode")));
            this.lbServer.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbServer.Appearance.HoverImage")));
            this.lbServer.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbServer.Appearance.Image")));
            this.lbServer.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbServer.Appearance.PressedImage")));
            this.lbServer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbServer.Name = "lbServer";
            // 
            // lbSQLDatabase
            // 
            resources.ApplyResources(this.lbSQLDatabase, "lbSQLDatabase");
            this.lbSQLDatabase.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbSQLDatabase.Appearance.DisabledImage")));
            this.lbSQLDatabase.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbSQLDatabase.Appearance.GradientMode")));
            this.lbSQLDatabase.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbSQLDatabase.Appearance.HoverImage")));
            this.lbSQLDatabase.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbSQLDatabase.Appearance.Image")));
            this.lbSQLDatabase.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbSQLDatabase.Appearance.PressedImage")));
            this.lbSQLDatabase.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbSQLDatabase.Name = "lbSQLDatabase";
            // 
            // TabPageArchive
            // 
            resources.ApplyResources(this.TabPageArchive, "TabPageArchive");
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
            // 
            // chkAllowArchiveConnection
            // 
            resources.ApplyResources(this.chkAllowArchiveConnection, "chkAllowArchiveConnection");
            this.chkAllowArchiveConnection.Name = "chkAllowArchiveConnection";
            this.chkAllowArchiveConnection.Properties.AccessibleDescription = resources.GetString("chkAllowArchiveConnection.Properties.AccessibleDescription");
            this.chkAllowArchiveConnection.Properties.AccessibleName = resources.GetString("chkAllowArchiveConnection.Properties.AccessibleName");
            this.chkAllowArchiveConnection.Properties.AutoHeight = ((bool)(resources.GetObject("chkAllowArchiveConnection.Properties.AutoHeight")));
            this.chkAllowArchiveConnection.Properties.Caption = resources.GetString("chkAllowArchiveConnection.Properties.Caption");
            this.chkAllowArchiveConnection.Properties.DisplayValueChecked = resources.GetString("chkAllowArchiveConnection.Properties.DisplayValueChecked");
            this.chkAllowArchiveConnection.Properties.DisplayValueGrayed = resources.GetString("chkAllowArchiveConnection.Properties.DisplayValueGrayed");
            this.chkAllowArchiveConnection.Properties.DisplayValueUnchecked = resources.GetString("chkAllowArchiveConnection.Properties.DisplayValueUnchecked");
            this.chkAllowArchiveConnection.CheckedChanged += new System.EventHandler(this.chkAllowArchiveConnection_CheckedChanged);
            // 
            // txtArchiveServer
            // 
            resources.ApplyResources(this.txtArchiveServer, "txtArchiveServer");
            this.txtArchiveServer.Name = "txtArchiveServer";
            this.txtArchiveServer.Properties.AccessibleDescription = resources.GetString("txtArchiveServer.Properties.AccessibleDescription");
            this.txtArchiveServer.Properties.AccessibleName = resources.GetString("txtArchiveServer.Properties.AccessibleName");
            this.txtArchiveServer.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtArchiveServer.Properties.Appearance.BackColor")));
            this.txtArchiveServer.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("txtArchiveServer.Properties.Appearance.GradientMode")));
            this.txtArchiveServer.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("txtArchiveServer.Properties.Appearance.Image")));
            this.txtArchiveServer.Properties.Appearance.Options.UseBackColor = true;
            this.txtArchiveServer.Properties.AutoHeight = ((bool)(resources.GetObject("txtArchiveServer.Properties.AutoHeight")));
            this.txtArchiveServer.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtArchiveServer.Properties.Mask.AutoComplete")));
            this.txtArchiveServer.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtArchiveServer.Properties.Mask.BeepOnError")));
            this.txtArchiveServer.Properties.Mask.EditMask = resources.GetString("txtArchiveServer.Properties.Mask.EditMask");
            this.txtArchiveServer.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtArchiveServer.Properties.Mask.IgnoreMaskBlank")));
            this.txtArchiveServer.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtArchiveServer.Properties.Mask.MaskType")));
            this.txtArchiveServer.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtArchiveServer.Properties.Mask.PlaceHolder")));
            this.txtArchiveServer.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtArchiveServer.Properties.Mask.SaveLiteral")));
            this.txtArchiveServer.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtArchiveServer.Properties.Mask.ShowPlaceHolders")));
            this.txtArchiveServer.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtArchiveServer.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtArchiveServer.Properties.NullValuePrompt = resources.GetString("txtArchiveServer.Properties.NullValuePrompt");
            this.txtArchiveServer.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtArchiveServer.Properties.NullValuePromptShowForEmptyValue")));
            this.txtArchiveServer.Tag = "";
            // 
            // txtArchiveDatabase
            // 
            resources.ApplyResources(this.txtArchiveDatabase, "txtArchiveDatabase");
            this.txtArchiveDatabase.Name = "txtArchiveDatabase";
            this.txtArchiveDatabase.Properties.AccessibleDescription = resources.GetString("txtArchiveDatabase.Properties.AccessibleDescription");
            this.txtArchiveDatabase.Properties.AccessibleName = resources.GetString("txtArchiveDatabase.Properties.AccessibleName");
            this.txtArchiveDatabase.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtArchiveDatabase.Properties.Appearance.BackColor")));
            this.txtArchiveDatabase.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("txtArchiveDatabase.Properties.Appearance.GradientMode")));
            this.txtArchiveDatabase.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("txtArchiveDatabase.Properties.Appearance.Image")));
            this.txtArchiveDatabase.Properties.Appearance.Options.UseBackColor = true;
            this.txtArchiveDatabase.Properties.AutoHeight = ((bool)(resources.GetObject("txtArchiveDatabase.Properties.AutoHeight")));
            this.txtArchiveDatabase.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtArchiveDatabase.Properties.Mask.AutoComplete")));
            this.txtArchiveDatabase.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtArchiveDatabase.Properties.Mask.BeepOnError")));
            this.txtArchiveDatabase.Properties.Mask.EditMask = resources.GetString("txtArchiveDatabase.Properties.Mask.EditMask");
            this.txtArchiveDatabase.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtArchiveDatabase.Properties.Mask.IgnoreMaskBlank")));
            this.txtArchiveDatabase.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtArchiveDatabase.Properties.Mask.MaskType")));
            this.txtArchiveDatabase.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtArchiveDatabase.Properties.Mask.PlaceHolder")));
            this.txtArchiveDatabase.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtArchiveDatabase.Properties.Mask.SaveLiteral")));
            this.txtArchiveDatabase.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtArchiveDatabase.Properties.Mask.ShowPlaceHolders")));
            this.txtArchiveDatabase.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtArchiveDatabase.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtArchiveDatabase.Properties.NullValuePrompt = resources.GetString("txtArchiveDatabase.Properties.NullValuePrompt");
            this.txtArchiveDatabase.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtArchiveDatabase.Properties.NullValuePromptShowForEmptyValue")));
            this.txtArchiveDatabase.Tag = "";
            // 
            // txtArchiveUser
            // 
            resources.ApplyResources(this.txtArchiveUser, "txtArchiveUser");
            this.txtArchiveUser.Name = "txtArchiveUser";
            this.txtArchiveUser.Properties.AccessibleDescription = resources.GetString("txtArchiveUser.Properties.AccessibleDescription");
            this.txtArchiveUser.Properties.AccessibleName = resources.GetString("txtArchiveUser.Properties.AccessibleName");
            this.txtArchiveUser.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtArchiveUser.Properties.Appearance.BackColor")));
            this.txtArchiveUser.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("txtArchiveUser.Properties.Appearance.GradientMode")));
            this.txtArchiveUser.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("txtArchiveUser.Properties.Appearance.Image")));
            this.txtArchiveUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtArchiveUser.Properties.AutoHeight = ((bool)(resources.GetObject("txtArchiveUser.Properties.AutoHeight")));
            this.txtArchiveUser.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtArchiveUser.Properties.Mask.AutoComplete")));
            this.txtArchiveUser.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtArchiveUser.Properties.Mask.BeepOnError")));
            this.txtArchiveUser.Properties.Mask.EditMask = resources.GetString("txtArchiveUser.Properties.Mask.EditMask");
            this.txtArchiveUser.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtArchiveUser.Properties.Mask.IgnoreMaskBlank")));
            this.txtArchiveUser.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtArchiveUser.Properties.Mask.MaskType")));
            this.txtArchiveUser.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtArchiveUser.Properties.Mask.PlaceHolder")));
            this.txtArchiveUser.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtArchiveUser.Properties.Mask.SaveLiteral")));
            this.txtArchiveUser.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtArchiveUser.Properties.Mask.ShowPlaceHolders")));
            this.txtArchiveUser.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtArchiveUser.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtArchiveUser.Properties.NullValuePrompt = resources.GetString("txtArchiveUser.Properties.NullValuePrompt");
            this.txtArchiveUser.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtArchiveUser.Properties.NullValuePromptShowForEmptyValue")));
            this.txtArchiveUser.Tag = "{M}";
            // 
            // txtArchivePassword
            // 
            resources.ApplyResources(this.txtArchivePassword, "txtArchivePassword");
            this.txtArchivePassword.Name = "txtArchivePassword";
            this.txtArchivePassword.Properties.AccessibleDescription = resources.GetString("txtArchivePassword.Properties.AccessibleDescription");
            this.txtArchivePassword.Properties.AccessibleName = resources.GetString("txtArchivePassword.Properties.AccessibleName");
            this.txtArchivePassword.Properties.AutoHeight = ((bool)(resources.GetObject("txtArchivePassword.Properties.AutoHeight")));
            this.txtArchivePassword.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtArchivePassword.Properties.Mask.AutoComplete")));
            this.txtArchivePassword.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtArchivePassword.Properties.Mask.BeepOnError")));
            this.txtArchivePassword.Properties.Mask.EditMask = resources.GetString("txtArchivePassword.Properties.Mask.EditMask");
            this.txtArchivePassword.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtArchivePassword.Properties.Mask.IgnoreMaskBlank")));
            this.txtArchivePassword.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtArchivePassword.Properties.Mask.MaskType")));
            this.txtArchivePassword.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtArchivePassword.Properties.Mask.PlaceHolder")));
            this.txtArchivePassword.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtArchivePassword.Properties.Mask.SaveLiteral")));
            this.txtArchivePassword.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtArchivePassword.Properties.Mask.ShowPlaceHolders")));
            this.txtArchivePassword.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtArchivePassword.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtArchivePassword.Properties.NullValuePrompt = resources.GetString("txtArchivePassword.Properties.NullValuePrompt");
            this.txtArchivePassword.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtArchivePassword.Properties.NullValuePromptShowForEmptyValue")));
            this.txtArchivePassword.Properties.PasswordChar = '*';
            this.txtArchivePassword.Tag = "{M}";
            // 
            // lbArchiveUser
            // 
            resources.ApplyResources(this.lbArchiveUser, "lbArchiveUser");
            this.lbArchiveUser.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveUser.Appearance.DisabledImage")));
            this.lbArchiveUser.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbArchiveUser.Appearance.GradientMode")));
            this.lbArchiveUser.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveUser.Appearance.HoverImage")));
            this.lbArchiveUser.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbArchiveUser.Appearance.Image")));
            this.lbArchiveUser.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveUser.Appearance.PressedImage")));
            this.lbArchiveUser.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbArchiveUser.Name = "lbArchiveUser";
            // 
            // lbArchivePassword
            // 
            resources.ApplyResources(this.lbArchivePassword, "lbArchivePassword");
            this.lbArchivePassword.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbArchivePassword.Appearance.DisabledImage")));
            this.lbArchivePassword.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbArchivePassword.Appearance.GradientMode")));
            this.lbArchivePassword.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbArchivePassword.Appearance.HoverImage")));
            this.lbArchivePassword.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbArchivePassword.Appearance.Image")));
            this.lbArchivePassword.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbArchivePassword.Appearance.PressedImage")));
            this.lbArchivePassword.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbArchivePassword.Name = "lbArchivePassword";
            // 
            // lbArchiveServer
            // 
            resources.ApplyResources(this.lbArchiveServer, "lbArchiveServer");
            this.lbArchiveServer.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveServer.Appearance.DisabledImage")));
            this.lbArchiveServer.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbArchiveServer.Appearance.GradientMode")));
            this.lbArchiveServer.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveServer.Appearance.HoverImage")));
            this.lbArchiveServer.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbArchiveServer.Appearance.Image")));
            this.lbArchiveServer.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveServer.Appearance.PressedImage")));
            this.lbArchiveServer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbArchiveServer.Name = "lbArchiveServer";
            // 
            // lbArchiveDatabase
            // 
            resources.ApplyResources(this.lbArchiveDatabase, "lbArchiveDatabase");
            this.lbArchiveDatabase.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveDatabase.Appearance.DisabledImage")));
            this.lbArchiveDatabase.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbArchiveDatabase.Appearance.GradientMode")));
            this.lbArchiveDatabase.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveDatabase.Appearance.HoverImage")));
            this.lbArchiveDatabase.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbArchiveDatabase.Appearance.Image")));
            this.lbArchiveDatabase.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbArchiveDatabase.Appearance.PressedImage")));
            this.lbArchiveDatabase.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbArchiveDatabase.Name = "lbArchiveDatabase";
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
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.VisibleChanged += new System.EventHandler(this.LoginForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
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
    }
}