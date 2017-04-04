namespace EidssConfigEditor
{
  partial class MainForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.lbconfigFileCaption = new System.Windows.Forms.Label();
      this.DatabaseTab = new System.Windows.Forms.TabPage();
      this.archiveDatabaseBox = new System.Windows.Forms.GroupBox();
      this.chkAllowArchiveConnection = new System.Windows.Forms.CheckBox();
      this.lbArchiveDatabase = new System.Windows.Forms.Label();
      this.lbArchiveServer = new System.Windows.Forms.Label();
      this.txtArchiveServer = new System.Windows.Forms.TextBox();
      this.lbArchivePassword = new System.Windows.Forms.Label();
      this.txtArchiveDatabase = new System.Windows.Forms.TextBox();
      this.lbArchiveUser = new System.Windows.Forms.Label();
      this.txtArchiveUser = new System.Windows.Forms.TextBox();
      this.txtArchivePassword = new System.Windows.Forms.TextBox();
      this.databaseBox = new System.Windows.Forms.GroupBox();
      this.lbServer = new System.Windows.Forms.Label();
      this.lbSQLDatabase = new System.Windows.Forms.Label();
      this.lbSQLPassword = new System.Windows.Forms.Label();
      this.lbSQLUserName = new System.Windows.Forms.Label();
      this.txtSQLPassword = new System.Windows.Forms.TextBox();
      this.txtSQLUser = new System.Windows.Forms.TextBox();
      this.txtSQLDatabase = new System.Windows.Forms.TextBox();
      this.txtSQLServer = new System.Windows.Forms.TextBox();
      this.Settings = new System.Windows.Forms.TabControl();
      this.ReportingServiceTab = new System.Windows.Forms.TabPage();
      this.lbReportingUrl = new System.Windows.Forms.Label();
      this.txtReportingUrl = new System.Windows.Forms.TextBox();
      this.lbRSDisplayName = new System.Windows.Forms.Label();
      this.txtRSDisplayName = new System.Windows.Forms.TextBox();
      this.lbRSName = new System.Windows.Forms.Label();
      this.txtRSName = new System.Windows.Forms.TextBox();
      this.WebSettingsTab = new System.Windows.Forms.TabPage();
      this.labelIdleTimeout = new System.Windows.Forms.Label();
      this.idleTimeoutInMinutes = new System.Windows.Forms.NumericUpDown();
      this.databaseBoxForAvr = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtSQLPasswordForAvr = new System.Windows.Forms.TextBox();
      this.txtSQLUserForAvr = new System.Windows.Forms.TextBox();
      this.txtSQLDatabaseForAvr = new System.Windows.Forms.TextBox();
      this.txtSQLServerForAvr = new System.Windows.Forms.TextBox();
      this.AvrServiceHostUrlLabel = new System.Windows.Forms.Label();
      this.avrServiceHostURL = new System.Windows.Forms.TextBox();
      this.avrUrl = new System.Windows.Forms.TextBox();
      this.AvrUrlLabel = new System.Windows.Forms.Label();
      this.mobileWebEidssPath = new System.Windows.Forms.TextBox();
      this.MobileWebEidssPathLabel = new System.Windows.Forms.Label();
      this.lbMapLocalUrl = new System.Windows.Forms.Label();
      this.txtMapLocalUrl = new System.Windows.Forms.TextBox();
      this.WebAppAdvancedTab = new System.Windows.Forms.TabPage();
      this.labSectionPageSize = new System.Windows.Forms.NumericUpDown();
      this.rowsOnLabSectionLabel = new System.Windows.Forms.Label();
      this.detailGridPageSize = new System.Windows.Forms.NumericUpDown();
      this.popupGridPageSize = new System.Windows.Forms.NumericUpDown();
      this.listGridPageSize = new System.Windows.Forms.NumericUpDown();
      this.rowsOnDetailFormLabel = new System.Windows.Forms.Label();
      this.forSelectModeLabel = new System.Windows.Forms.Label();
      this.forViewEditModeLabel = new System.Windows.Forms.Label();
      this.rowsInListFormLabel = new System.Windows.Forms.Label();
      this.defaultDateFilter = new System.Windows.Forms.NumericUpDown();
      this.DefaultDateFilterLabel = new System.Windows.Forms.Label();
      this.defaultRegionInSearch = new System.Windows.Forms.CheckBox();
      this.MiscellaneousTab = new System.Windows.Forms.TabPage();
      this.DefaultLanguageLabel = new System.Windows.Forms.Label();
      this.cbDefaultLanguage = new System.Windows.Forms.ComboBox();
      this.txtSupportedLanguages = new System.Windows.Forms.TextBox();
      this.lbSupportedLanguages = new System.Windows.Forms.Label();
      this.lbErrorLogPath = new System.Windows.Forms.Label();
      this.txtErrorLogPath = new System.Windows.Forms.TextBox();
      this.btnLoad = new System.Windows.Forms.Button();
      this.btnSaveAs = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.btSave = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.lbConfigFileName = new System.Windows.Forms.Label();
      this.DatabaseTab.SuspendLayout();
      this.archiveDatabaseBox.SuspendLayout();
      this.databaseBox.SuspendLayout();
      this.Settings.SuspendLayout();
      this.ReportingServiceTab.SuspendLayout();
      this.WebSettingsTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.idleTimeoutInMinutes)).BeginInit();
      this.databaseBoxForAvr.SuspendLayout();
      this.WebAppAdvancedTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.labSectionPageSize)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.detailGridPageSize)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupGridPageSize)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.listGridPageSize)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.defaultDateFilter)).BeginInit();
      this.MiscellaneousTab.SuspendLayout();
      this.SuspendLayout();
      // 
      // lbconfigFileCaption
      // 
      this.lbconfigFileCaption.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbconfigFileCaption.Location = new System.Drawing.Point(12, 12);
      this.lbconfigFileCaption.Name = "lbconfigFileCaption";
      this.lbconfigFileCaption.Size = new System.Drawing.Size(103, 13);
      this.lbconfigFileCaption.TabIndex = 46;
      this.lbconfigFileCaption.Text = "Configuration File:";
      // 
      // DatabaseTab
      // 
      this.DatabaseTab.BackColor = System.Drawing.SystemColors.Control;
      this.DatabaseTab.Controls.Add(this.archiveDatabaseBox);
      this.DatabaseTab.Controls.Add(this.databaseBox);
      this.DatabaseTab.Location = new System.Drawing.Point(4, 22);
      this.DatabaseTab.Name = "DatabaseTab";
      this.DatabaseTab.Padding = new System.Windows.Forms.Padding(3);
      this.DatabaseTab.Size = new System.Drawing.Size(612, 335);
      this.DatabaseTab.TabIndex = 0;
      this.DatabaseTab.Text = "Database Settings";
      // 
      // archiveDatabaseBox
      // 
      this.archiveDatabaseBox.Controls.Add(this.chkAllowArchiveConnection);
      this.archiveDatabaseBox.Controls.Add(this.lbArchiveDatabase);
      this.archiveDatabaseBox.Controls.Add(this.lbArchiveServer);
      this.archiveDatabaseBox.Controls.Add(this.txtArchiveServer);
      this.archiveDatabaseBox.Controls.Add(this.lbArchivePassword);
      this.archiveDatabaseBox.Controls.Add(this.txtArchiveDatabase);
      this.archiveDatabaseBox.Controls.Add(this.lbArchiveUser);
      this.archiveDatabaseBox.Controls.Add(this.txtArchiveUser);
      this.archiveDatabaseBox.Controls.Add(this.txtArchivePassword);
      this.archiveDatabaseBox.Location = new System.Drawing.Point(9, 164);
      this.archiveDatabaseBox.Name = "archiveDatabaseBox";
      this.archiveDatabaseBox.Size = new System.Drawing.Size(598, 161);
      this.archiveDatabaseBox.TabIndex = 43;
      this.archiveDatabaseBox.TabStop = false;
      this.archiveDatabaseBox.Text = "Archive Database Connection";
      // 
      // chkAllowArchiveConnection
      // 
      this.chkAllowArchiveConnection.Checked = true;
      this.chkAllowArchiveConnection.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAllowArchiveConnection.Location = new System.Drawing.Point(9, 21);
      this.chkAllowArchiveConnection.Name = "chkAllowArchiveConnection";
      this.chkAllowArchiveConnection.Size = new System.Drawing.Size(449, 19);
      this.chkAllowArchiveConnection.TabIndex = 39;
      this.chkAllowArchiveConnection.Text = "Allow connection to archive database";
      this.chkAllowArchiveConnection.CheckedChanged += new System.EventHandler(this.chkAllowArchiveConnection_CheckedChanged);
      // 
      // lbArchiveDatabase
      // 
      this.lbArchiveDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbArchiveDatabase.Location = new System.Drawing.Point(6, 81);
      this.lbArchiveDatabase.Name = "lbArchiveDatabase";
      this.lbArchiveDatabase.Size = new System.Drawing.Size(103, 13);
      this.lbArchiveDatabase.TabIndex = 37;
      this.lbArchiveDatabase.Text = "Database:";
      // 
      // lbArchiveServer
      // 
      this.lbArchiveServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbArchiveServer.Location = new System.Drawing.Point(6, 55);
      this.lbArchiveServer.Name = "lbArchiveServer";
      this.lbArchiveServer.Size = new System.Drawing.Size(103, 13);
      this.lbArchiveServer.TabIndex = 38;
      this.lbArchiveServer.Text = "SQL server:";
      // 
      // txtArchiveServer
      // 
      this.txtArchiveServer.Location = new System.Drawing.Point(132, 51);
      this.txtArchiveServer.Name = "txtArchiveServer";
      this.txtArchiveServer.Size = new System.Drawing.Size(452, 20);
      this.txtArchiveServer.TabIndex = 31;
      this.txtArchiveServer.Tag = "";
      // 
      // lbArchivePassword
      // 
      this.lbArchivePassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbArchivePassword.Location = new System.Drawing.Point(6, 133);
      this.lbArchivePassword.Name = "lbArchivePassword";
      this.lbArchivePassword.Size = new System.Drawing.Size(103, 13);
      this.lbArchivePassword.TabIndex = 36;
      this.lbArchivePassword.Text = "Password:";
      // 
      // txtArchiveDatabase
      // 
      this.txtArchiveDatabase.Location = new System.Drawing.Point(132, 77);
      this.txtArchiveDatabase.Name = "txtArchiveDatabase";
      this.txtArchiveDatabase.Size = new System.Drawing.Size(452, 20);
      this.txtArchiveDatabase.TabIndex = 32;
      this.txtArchiveDatabase.Tag = "";
      // 
      // lbArchiveUser
      // 
      this.lbArchiveUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbArchiveUser.Location = new System.Drawing.Point(6, 107);
      this.lbArchiveUser.Name = "lbArchiveUser";
      this.lbArchiveUser.Size = new System.Drawing.Size(103, 13);
      this.lbArchiveUser.TabIndex = 35;
      this.lbArchiveUser.Text = "User:";
      // 
      // txtArchiveUser
      // 
      this.txtArchiveUser.Location = new System.Drawing.Point(132, 103);
      this.txtArchiveUser.Name = "txtArchiveUser";
      this.txtArchiveUser.Size = new System.Drawing.Size(452, 20);
      this.txtArchiveUser.TabIndex = 33;
      this.txtArchiveUser.Tag = "{M}";
      // 
      // txtArchivePassword
      // 
      this.txtArchivePassword.Location = new System.Drawing.Point(132, 129);
      this.txtArchivePassword.Name = "txtArchivePassword";
      this.txtArchivePassword.PasswordChar = '*';
      this.txtArchivePassword.Size = new System.Drawing.Size(452, 20);
      this.txtArchivePassword.TabIndex = 34;
      this.txtArchivePassword.Tag = "{M}";
      // 
      // databaseBox
      // 
      this.databaseBox.Controls.Add(this.lbServer);
      this.databaseBox.Controls.Add(this.lbSQLDatabase);
      this.databaseBox.Controls.Add(this.lbSQLPassword);
      this.databaseBox.Controls.Add(this.lbSQLUserName);
      this.databaseBox.Controls.Add(this.txtSQLPassword);
      this.databaseBox.Controls.Add(this.txtSQLUser);
      this.databaseBox.Controls.Add(this.txtSQLDatabase);
      this.databaseBox.Controls.Add(this.txtSQLServer);
      this.databaseBox.Location = new System.Drawing.Point(9, 16);
      this.databaseBox.Name = "databaseBox";
      this.databaseBox.Size = new System.Drawing.Size(598, 129);
      this.databaseBox.TabIndex = 42;
      this.databaseBox.TabStop = false;
      this.databaseBox.Text = "Database Connection";
      // 
      // lbServer
      // 
      this.lbServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbServer.Location = new System.Drawing.Point(6, 25);
      this.lbServer.Name = "lbServer";
      this.lbServer.Size = new System.Drawing.Size(103, 13);
      this.lbServer.TabIndex = 30;
      this.lbServer.Text = "SQL server:";
      // 
      // lbSQLDatabase
      // 
      this.lbSQLDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbSQLDatabase.Location = new System.Drawing.Point(6, 51);
      this.lbSQLDatabase.Name = "lbSQLDatabase";
      this.lbSQLDatabase.Size = new System.Drawing.Size(103, 13);
      this.lbSQLDatabase.TabIndex = 29;
      this.lbSQLDatabase.Text = "Database:";
      // 
      // lbSQLPassword
      // 
      this.lbSQLPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbSQLPassword.Location = new System.Drawing.Point(6, 103);
      this.lbSQLPassword.Name = "lbSQLPassword";
      this.lbSQLPassword.Size = new System.Drawing.Size(103, 13);
      this.lbSQLPassword.TabIndex = 28;
      this.lbSQLPassword.Text = "Password:";
      // 
      // lbSQLUserName
      // 
      this.lbSQLUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbSQLUserName.Location = new System.Drawing.Point(6, 77);
      this.lbSQLUserName.Name = "lbSQLUserName";
      this.lbSQLUserName.Size = new System.Drawing.Size(103, 13);
      this.lbSQLUserName.TabIndex = 27;
      this.lbSQLUserName.Text = "User:";
      // 
      // txtSQLPassword
      // 
      this.txtSQLPassword.Location = new System.Drawing.Point(132, 99);
      this.txtSQLPassword.Name = "txtSQLPassword";
      this.txtSQLPassword.PasswordChar = '*';
      this.txtSQLPassword.Size = new System.Drawing.Size(452, 20);
      this.txtSQLPassword.TabIndex = 26;
      this.txtSQLPassword.Tag = "{M}";
      // 
      // txtSQLUser
      // 
      this.txtSQLUser.Location = new System.Drawing.Point(132, 73);
      this.txtSQLUser.Name = "txtSQLUser";
      this.txtSQLUser.Size = new System.Drawing.Size(452, 20);
      this.txtSQLUser.TabIndex = 25;
      this.txtSQLUser.Tag = "{M}";
      // 
      // txtSQLDatabase
      // 
      this.txtSQLDatabase.Location = new System.Drawing.Point(132, 47);
      this.txtSQLDatabase.Name = "txtSQLDatabase";
      this.txtSQLDatabase.Size = new System.Drawing.Size(452, 20);
      this.txtSQLDatabase.TabIndex = 24;
      this.txtSQLDatabase.Tag = "{M}";
      // 
      // txtSQLServer
      // 
      this.txtSQLServer.Location = new System.Drawing.Point(132, 21);
      this.txtSQLServer.Name = "txtSQLServer";
      this.txtSQLServer.Size = new System.Drawing.Size(452, 20);
      this.txtSQLServer.TabIndex = 23;
      this.txtSQLServer.Tag = "{M}";
      // 
      // Settings
      // 
      this.Settings.Controls.Add(this.DatabaseTab);
      this.Settings.Controls.Add(this.ReportingServiceTab);
      this.Settings.Controls.Add(this.WebSettingsTab);
      this.Settings.Controls.Add(this.WebAppAdvancedTab);
      this.Settings.Controls.Add(this.MiscellaneousTab);
      this.Settings.Location = new System.Drawing.Point(3, 50);
      this.Settings.Name = "Settings";
      this.Settings.SelectedIndex = 0;
      this.Settings.Size = new System.Drawing.Size(620, 361);
      this.Settings.TabIndex = 0;
      // 
      // ReportingServiceTab
      // 
      this.ReportingServiceTab.BackColor = System.Drawing.SystemColors.Control;
      this.ReportingServiceTab.Controls.Add(this.lbReportingUrl);
      this.ReportingServiceTab.Controls.Add(this.txtReportingUrl);
      this.ReportingServiceTab.Controls.Add(this.lbRSDisplayName);
      this.ReportingServiceTab.Controls.Add(this.txtRSDisplayName);
      this.ReportingServiceTab.Controls.Add(this.lbRSName);
      this.ReportingServiceTab.Controls.Add(this.txtRSName);
      this.ReportingServiceTab.Location = new System.Drawing.Point(4, 22);
      this.ReportingServiceTab.Name = "ReportingServiceTab";
      this.ReportingServiceTab.Size = new System.Drawing.Size(612, 335);
      this.ReportingServiceTab.TabIndex = 3;
      this.ReportingServiceTab.Text = "Reporting Service";
      // 
      // lbReportingUrl
      // 
      this.lbReportingUrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbReportingUrl.Location = new System.Drawing.Point(17, 199);
      this.lbReportingUrl.Name = "lbReportingUrl";
      this.lbReportingUrl.Size = new System.Drawing.Size(116, 13);
      this.lbReportingUrl.TabIndex = 31;
      this.lbReportingUrl.Text = "Reporting Url Address:";
      // 
      // txtReportingUrl
      // 
      this.txtReportingUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtReportingUrl.Location = new System.Drawing.Point(143, 195);
      this.txtReportingUrl.Name = "txtReportingUrl";
      this.txtReportingUrl.Size = new System.Drawing.Size(448, 20);
      this.txtReportingUrl.TabIndex = 32;
      this.txtReportingUrl.Tag = "{M}";
      // 
      // lbRSDisplayName
      // 
      this.lbRSDisplayName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbRSDisplayName.Location = new System.Drawing.Point(17, 150);
      this.lbRSDisplayName.Name = "lbRSDisplayName";
      this.lbRSDisplayName.Size = new System.Drawing.Size(99, 26);
      this.lbRSDisplayName.TabIndex = 35;
      this.lbRSDisplayName.Text = "Reporting Service Display Name:";
      // 
      // txtRSDisplayName
      // 
      this.txtRSDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtRSDisplayName.Location = new System.Drawing.Point(143, 154);
      this.txtRSDisplayName.Name = "txtRSDisplayName";
      this.txtRSDisplayName.Size = new System.Drawing.Size(448, 20);
      this.txtRSDisplayName.TabIndex = 36;
      this.txtRSDisplayName.Tag = "{M}";
      // 
      // lbRSName
      // 
      this.lbRSName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbRSName.Location = new System.Drawing.Point(17, 110);
      this.lbRSName.Name = "lbRSName";
      this.lbRSName.Size = new System.Drawing.Size(99, 26);
      this.lbRSName.TabIndex = 33;
      this.lbRSName.Text = "Reporting Service Name:";
      // 
      // txtRSName
      // 
      this.txtRSName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtRSName.Location = new System.Drawing.Point(143, 114);
      this.txtRSName.Name = "txtRSName";
      this.txtRSName.Size = new System.Drawing.Size(448, 20);
      this.txtRSName.TabIndex = 34;
      this.txtRSName.Tag = "{M}";
      // 
      // WebSettingsTab
      // 
      this.WebSettingsTab.BackColor = System.Drawing.SystemColors.Control;
      this.WebSettingsTab.Controls.Add(this.labelIdleTimeout);
      this.WebSettingsTab.Controls.Add(this.idleTimeoutInMinutes);
      this.WebSettingsTab.Controls.Add(this.databaseBoxForAvr);
      this.WebSettingsTab.Controls.Add(this.AvrServiceHostUrlLabel);
      this.WebSettingsTab.Controls.Add(this.avrServiceHostURL);
      this.WebSettingsTab.Controls.Add(this.avrUrl);
      this.WebSettingsTab.Controls.Add(this.AvrUrlLabel);
      this.WebSettingsTab.Controls.Add(this.mobileWebEidssPath);
      this.WebSettingsTab.Controls.Add(this.MobileWebEidssPathLabel);
      this.WebSettingsTab.Controls.Add(this.lbMapLocalUrl);
      this.WebSettingsTab.Controls.Add(this.txtMapLocalUrl);
      this.WebSettingsTab.Location = new System.Drawing.Point(4, 22);
      this.WebSettingsTab.Name = "WebSettingsTab";
      this.WebSettingsTab.Size = new System.Drawing.Size(612, 335);
      this.WebSettingsTab.TabIndex = 4;
      this.WebSettingsTab.Text = "Web Settings";
      // 
      // labelIdleTimeout
      // 
      this.labelIdleTimeout.AutoSize = true;
      this.labelIdleTimeout.Location = new System.Drawing.Point(21, 143);
      this.labelIdleTimeout.Name = "labelIdleTimeout";
      this.labelIdleTimeout.Size = new System.Drawing.Size(189, 13);
      this.labelIdleTimeout.TabIndex = 45;
      this.labelIdleTimeout.Text = "Inactivity Session Timeout (in minutes):";
      // 
      // idleTimeoutInMinutes
      // 
      this.idleTimeoutInMinutes.Location = new System.Drawing.Point(221, 139);
      this.idleTimeoutInMinutes.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
      this.idleTimeoutInMinutes.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
      this.idleTimeoutInMinutes.Name = "idleTimeoutInMinutes";
      this.idleTimeoutInMinutes.Size = new System.Drawing.Size(120, 20);
      this.idleTimeoutInMinutes.TabIndex = 44;
      this.idleTimeoutInMinutes.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
      // 
      // databaseBoxForAvr
      // 
      this.databaseBoxForAvr.Controls.Add(this.label1);
      this.databaseBoxForAvr.Controls.Add(this.label2);
      this.databaseBoxForAvr.Controls.Add(this.label3);
      this.databaseBoxForAvr.Controls.Add(this.label4);
      this.databaseBoxForAvr.Controls.Add(this.txtSQLPasswordForAvr);
      this.databaseBoxForAvr.Controls.Add(this.txtSQLUserForAvr);
      this.databaseBoxForAvr.Controls.Add(this.txtSQLDatabaseForAvr);
      this.databaseBoxForAvr.Controls.Add(this.txtSQLServerForAvr);
      this.databaseBoxForAvr.Location = new System.Drawing.Point(7, 184);
      this.databaseBoxForAvr.Name = "databaseBoxForAvr";
      this.databaseBoxForAvr.Size = new System.Drawing.Size(598, 129);
      this.databaseBoxForAvr.TabIndex = 43;
      this.databaseBoxForAvr.TabStop = false;
      this.databaseBoxForAvr.Text = "Database Connection for Web AVR Application";
      // 
      // label1
      // 
      this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.label1.Location = new System.Drawing.Point(6, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(103, 13);
      this.label1.TabIndex = 30;
      this.label1.Text = "SQL server:";
      // 
      // label2
      // 
      this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.label2.Location = new System.Drawing.Point(6, 51);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(103, 13);
      this.label2.TabIndex = 29;
      this.label2.Text = "Database:";
      // 
      // label3
      // 
      this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.label3.Location = new System.Drawing.Point(6, 103);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(103, 13);
      this.label3.TabIndex = 28;
      this.label3.Text = "Password:";
      // 
      // label4
      // 
      this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.label4.Location = new System.Drawing.Point(6, 77);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(103, 13);
      this.label4.TabIndex = 27;
      this.label4.Text = "User:";
      // 
      // txtSQLPasswordForAvr
      // 
      this.txtSQLPasswordForAvr.Location = new System.Drawing.Point(132, 99);
      this.txtSQLPasswordForAvr.Name = "txtSQLPasswordForAvr";
      this.txtSQLPasswordForAvr.PasswordChar = '*';
      this.txtSQLPasswordForAvr.Size = new System.Drawing.Size(452, 20);
      this.txtSQLPasswordForAvr.TabIndex = 26;
      this.txtSQLPasswordForAvr.Tag = "{M}";
      // 
      // txtSQLUserForAvr
      // 
      this.txtSQLUserForAvr.Location = new System.Drawing.Point(132, 73);
      this.txtSQLUserForAvr.Name = "txtSQLUserForAvr";
      this.txtSQLUserForAvr.Size = new System.Drawing.Size(452, 20);
      this.txtSQLUserForAvr.TabIndex = 25;
      this.txtSQLUserForAvr.Tag = "{M}";
      // 
      // txtSQLDatabaseForAvr
      // 
      this.txtSQLDatabaseForAvr.Location = new System.Drawing.Point(132, 47);
      this.txtSQLDatabaseForAvr.Name = "txtSQLDatabaseForAvr";
      this.txtSQLDatabaseForAvr.Size = new System.Drawing.Size(452, 20);
      this.txtSQLDatabaseForAvr.TabIndex = 24;
      this.txtSQLDatabaseForAvr.Tag = "{M}";
      // 
      // txtSQLServerForAvr
      // 
      this.txtSQLServerForAvr.Location = new System.Drawing.Point(132, 21);
      this.txtSQLServerForAvr.Name = "txtSQLServerForAvr";
      this.txtSQLServerForAvr.Size = new System.Drawing.Size(452, 20);
      this.txtSQLServerForAvr.TabIndex = 23;
      this.txtSQLServerForAvr.Tag = "{M}";
      // 
      // AvrServiceHostUrlLabel
      // 
      this.AvrServiceHostUrlLabel.AutoSize = true;
      this.AvrServiceHostUrlLabel.Location = new System.Drawing.Point(21, 115);
      this.AvrServiceHostUrlLabel.Name = "AvrServiceHostUrlLabel";
      this.AvrServiceHostUrlLabel.Size = new System.Drawing.Size(106, 13);
      this.AvrServiceHostUrlLabel.TabIndex = 26;
      this.AvrServiceHostUrlLabel.Text = "Avr Service Host Url:";
      // 
      // avrServiceHostURL
      // 
      this.avrServiceHostURL.Location = new System.Drawing.Point(166, 111);
      this.avrServiceHostURL.Name = "avrServiceHostURL";
      this.avrServiceHostURL.Size = new System.Drawing.Size(425, 20);
      this.avrServiceHostURL.TabIndex = 25;
      // 
      // avrUrl
      // 
      this.avrUrl.Location = new System.Drawing.Point(166, 83);
      this.avrUrl.Name = "avrUrl";
      this.avrUrl.Size = new System.Drawing.Size(425, 20);
      this.avrUrl.TabIndex = 24;
      // 
      // AvrUrlLabel
      // 
      this.AvrUrlLabel.AutoSize = true;
      this.AvrUrlLabel.Location = new System.Drawing.Point(21, 87);
      this.AvrUrlLabel.Name = "AvrUrlLabel";
      this.AvrUrlLabel.Size = new System.Drawing.Size(42, 13);
      this.AvrUrlLabel.TabIndex = 23;
      this.AvrUrlLabel.Text = "Avr Url:";
      // 
      // mobileWebEidssPath
      // 
      this.mobileWebEidssPath.Location = new System.Drawing.Point(166, 55);
      this.mobileWebEidssPath.Name = "mobileWebEidssPath";
      this.mobileWebEidssPath.Size = new System.Drawing.Size(425, 20);
      this.mobileWebEidssPath.TabIndex = 22;
      // 
      // MobileWebEidssPathLabel
      // 
      this.MobileWebEidssPathLabel.AutoSize = true;
      this.MobileWebEidssPathLabel.Location = new System.Drawing.Point(21, 59);
      this.MobileWebEidssPathLabel.Name = "MobileWebEidssPathLabel";
      this.MobileWebEidssPathLabel.Size = new System.Drawing.Size(117, 13);
      this.MobileWebEidssPathLabel.TabIndex = 21;
      this.MobileWebEidssPathLabel.Text = "Mobile WebEidss Path:";
      // 
      // lbMapLocalUrl
      // 
      this.lbMapLocalUrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbMapLocalUrl.Location = new System.Drawing.Point(21, 31);
      this.lbMapLocalUrl.Name = "lbMapLocalUrl";
      this.lbMapLocalUrl.Size = new System.Drawing.Size(120, 13);
      this.lbMapLocalUrl.TabIndex = 19;
      this.lbMapLocalUrl.Text = "Map Local Url Address:";
      // 
      // txtMapLocalUrl
      // 
      this.txtMapLocalUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMapLocalUrl.Location = new System.Drawing.Point(166, 27);
      this.txtMapLocalUrl.Name = "txtMapLocalUrl";
      this.txtMapLocalUrl.Size = new System.Drawing.Size(425, 20);
      this.txtMapLocalUrl.TabIndex = 20;
      this.txtMapLocalUrl.Tag = "{M}";
      // 
      // WebAppAdvancedTab
      // 
      this.WebAppAdvancedTab.BackColor = System.Drawing.SystemColors.Control;
      this.WebAppAdvancedTab.Controls.Add(this.labSectionPageSize);
      this.WebAppAdvancedTab.Controls.Add(this.rowsOnLabSectionLabel);
      this.WebAppAdvancedTab.Controls.Add(this.detailGridPageSize);
      this.WebAppAdvancedTab.Controls.Add(this.popupGridPageSize);
      this.WebAppAdvancedTab.Controls.Add(this.listGridPageSize);
      this.WebAppAdvancedTab.Controls.Add(this.rowsOnDetailFormLabel);
      this.WebAppAdvancedTab.Controls.Add(this.forSelectModeLabel);
      this.WebAppAdvancedTab.Controls.Add(this.forViewEditModeLabel);
      this.WebAppAdvancedTab.Controls.Add(this.rowsInListFormLabel);
      this.WebAppAdvancedTab.Controls.Add(this.defaultDateFilter);
      this.WebAppAdvancedTab.Controls.Add(this.DefaultDateFilterLabel);
      this.WebAppAdvancedTab.Controls.Add(this.defaultRegionInSearch);
      this.WebAppAdvancedTab.Location = new System.Drawing.Point(4, 22);
      this.WebAppAdvancedTab.Name = "WebAppAdvancedTab";
      this.WebAppAdvancedTab.Size = new System.Drawing.Size(612, 335);
      this.WebAppAdvancedTab.TabIndex = 5;
      this.WebAppAdvancedTab.Text = "Web Application Advanced Settings";
      // 
      // labSectionPageSize
      // 
      this.labSectionPageSize.Location = new System.Drawing.Point(335, 286);
      this.labSectionPageSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
      this.labSectionPageSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.labSectionPageSize.Name = "labSectionPageSize";
      this.labSectionPageSize.Size = new System.Drawing.Size(120, 20);
      this.labSectionPageSize.TabIndex = 53;
      this.labSectionPageSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      // 
      // rowsOnLabSectionLabel
      // 
      this.rowsOnLabSectionLabel.AutoSize = true;
      this.rowsOnLabSectionLabel.Location = new System.Drawing.Point(46, 290);
      this.rowsOnLabSectionLabel.Name = "rowsOnLabSectionLabel";
      this.rowsOnLabSectionLabel.Size = new System.Drawing.Size(196, 13);
      this.rowsOnLabSectionLabel.TabIndex = 52;
      this.rowsOnLabSectionLabel.Text = "Number of rows in the Lab Section form:";
      // 
      // detailGridPageSize
      // 
      this.detailGridPageSize.Location = new System.Drawing.Point(335, 237);
      this.detailGridPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.detailGridPageSize.Name = "detailGridPageSize";
      this.detailGridPageSize.Size = new System.Drawing.Size(120, 20);
      this.detailGridPageSize.TabIndex = 51;
      this.detailGridPageSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // popupGridPageSize
      // 
      this.popupGridPageSize.Location = new System.Drawing.Point(335, 185);
      this.popupGridPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.popupGridPageSize.Name = "popupGridPageSize";
      this.popupGridPageSize.Size = new System.Drawing.Size(120, 20);
      this.popupGridPageSize.TabIndex = 51;
      this.popupGridPageSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      // 
      // listGridPageSize
      // 
      this.listGridPageSize.Location = new System.Drawing.Point(335, 153);
      this.listGridPageSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.listGridPageSize.Name = "listGridPageSize";
      this.listGridPageSize.Size = new System.Drawing.Size(120, 20);
      this.listGridPageSize.TabIndex = 51;
      this.listGridPageSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      // 
      // rowsOnDetailFormLabel
      // 
      this.rowsOnDetailFormLabel.AutoSize = true;
      this.rowsOnDetailFormLabel.Location = new System.Drawing.Point(46, 241);
      this.rowsOnDetailFormLabel.Name = "rowsOnDetailFormLabel";
      this.rowsOnDetailFormLabel.Size = new System.Drawing.Size(188, 13);
      this.rowsOnDetailFormLabel.TabIndex = 50;
      this.rowsOnDetailFormLabel.Text = "Number of rows in grids on Detail form:";
      // 
      // forSelectModeLabel
      // 
      this.forSelectModeLabel.AutoSize = true;
      this.forSelectModeLabel.Location = new System.Drawing.Point(79, 189);
      this.forSelectModeLabel.Name = "forSelectModeLabel";
      this.forSelectModeLabel.Size = new System.Drawing.Size(85, 13);
      this.forSelectModeLabel.TabIndex = 49;
      this.forSelectModeLabel.Text = "For select mode:";
      // 
      // forViewEditModeLabel
      // 
      this.forViewEditModeLabel.AutoSize = true;
      this.forViewEditModeLabel.Location = new System.Drawing.Point(79, 157);
      this.forViewEditModeLabel.Name = "forViewEditModeLabel";
      this.forViewEditModeLabel.Size = new System.Drawing.Size(101, 13);
      this.forViewEditModeLabel.TabIndex = 48;
      this.forViewEditModeLabel.Text = "For view/edit mode:";
      // 
      // rowsInListFormLabel
      // 
      this.rowsInListFormLabel.AutoSize = true;
      this.rowsInListFormLabel.Location = new System.Drawing.Point(46, 125);
      this.rowsInListFormLabel.Name = "rowsInListFormLabel";
      this.rowsInListFormLabel.Size = new System.Drawing.Size(137, 13);
      this.rowsInListFormLabel.TabIndex = 47;
      this.rowsInListFormLabel.Text = "Number of rows in List form:";
      // 
      // defaultDateFilter
      // 
      this.defaultDateFilter.Location = new System.Drawing.Point(335, 72);
      this.defaultDateFilter.Name = "defaultDateFilter";
      this.defaultDateFilter.Size = new System.Drawing.Size(120, 20);
      this.defaultDateFilter.TabIndex = 46;
      this.defaultDateFilter.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
      // 
      // DefaultDateFilterLabel
      // 
      this.DefaultDateFilterLabel.AutoSize = true;
      this.DefaultDateFilterLabel.Location = new System.Drawing.Point(46, 76);
      this.DefaultDateFilterLabel.Name = "DefaultDateFilterLabel";
      this.DefaultDateFilterLabel.Size = new System.Drawing.Size(260, 13);
      this.DefaultDateFilterLabel.TabIndex = 45;
      this.DefaultDateFilterLabel.Text = "Number of days for which data is displayed by default:";
      // 
      // defaultRegionInSearch
      // 
      this.defaultRegionInSearch.Checked = true;
      this.defaultRegionInSearch.CheckState = System.Windows.Forms.CheckState.Checked;
      this.defaultRegionInSearch.Location = new System.Drawing.Point(50, 46);
      this.defaultRegionInSearch.Name = "defaultRegionInSearch";
      this.defaultRegionInSearch.Size = new System.Drawing.Size(449, 19);
      this.defaultRegionInSearch.TabIndex = 44;
      this.defaultRegionInSearch.Text = "Default Region in Search Panels";
      // 
      // MiscellaneousTab
      // 
      this.MiscellaneousTab.BackColor = System.Drawing.SystemColors.Control;
      this.MiscellaneousTab.Controls.Add(this.DefaultLanguageLabel);
      this.MiscellaneousTab.Controls.Add(this.cbDefaultLanguage);
      this.MiscellaneousTab.Controls.Add(this.txtSupportedLanguages);
      this.MiscellaneousTab.Controls.Add(this.lbSupportedLanguages);
      this.MiscellaneousTab.Controls.Add(this.lbErrorLogPath);
      this.MiscellaneousTab.Controls.Add(this.txtErrorLogPath);
      this.MiscellaneousTab.Location = new System.Drawing.Point(4, 22);
      this.MiscellaneousTab.Name = "MiscellaneousTab";
      this.MiscellaneousTab.Size = new System.Drawing.Size(612, 335);
      this.MiscellaneousTab.TabIndex = 2;
      this.MiscellaneousTab.Text = "Miscellaneous";
      // 
      // DefaultLanguageLabel
      // 
      this.DefaultLanguageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.DefaultLanguageLabel.Location = new System.Drawing.Point(20, 140);
      this.DefaultLanguageLabel.Name = "DefaultLanguageLabel";
      this.DefaultLanguageLabel.Size = new System.Drawing.Size(103, 13);
      this.DefaultLanguageLabel.TabIndex = 49;
      this.DefaultLanguageLabel.Text = "Default Language:";
      // 
      // cbDefaultLanguage
      // 
      this.cbDefaultLanguage.FormattingEnabled = true;
      this.cbDefaultLanguage.Location = new System.Drawing.Point(153, 138);
      this.cbDefaultLanguage.Name = "cbDefaultLanguage";
      this.cbDefaultLanguage.Size = new System.Drawing.Size(437, 21);
      this.cbDefaultLanguage.Sorted = true;
      this.cbDefaultLanguage.TabIndex = 50;
      // 
      // txtSupportedLanguages
      // 
      this.txtSupportedLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSupportedLanguages.Location = new System.Drawing.Point(153, 101);
      this.txtSupportedLanguages.Name = "txtSupportedLanguages";
      this.txtSupportedLanguages.Size = new System.Drawing.Size(437, 20);
      this.txtSupportedLanguages.TabIndex = 48;
      this.txtSupportedLanguages.Tag = "{M}";
      // 
      // lbSupportedLanguages
      // 
      this.lbSupportedLanguages.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbSupportedLanguages.Location = new System.Drawing.Point(20, 105);
      this.lbSupportedLanguages.Name = "lbSupportedLanguages";
      this.lbSupportedLanguages.Size = new System.Drawing.Size(119, 13);
      this.lbSupportedLanguages.TabIndex = 47;
      this.lbSupportedLanguages.Text = "Supported Languages:";
      // 
      // lbErrorLogPath
      // 
      this.lbErrorLogPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbErrorLogPath.Location = new System.Drawing.Point(20, 217);
      this.lbErrorLogPath.Name = "lbErrorLogPath";
      this.lbErrorLogPath.Size = new System.Drawing.Size(103, 13);
      this.lbErrorLogPath.TabIndex = 20;
      this.lbErrorLogPath.Text = "Error Log File Path:";
      // 
      // txtErrorLogPath
      // 
      this.txtErrorLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtErrorLogPath.Location = new System.Drawing.Point(153, 213);
      this.txtErrorLogPath.Name = "txtErrorLogPath";
      this.txtErrorLogPath.Size = new System.Drawing.Size(437, 20);
      this.txtErrorLogPath.TabIndex = 21;
      this.txtErrorLogPath.Tag = "{M}";
      // 
      // btnLoad
      // 
      this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.btnLoad.Location = new System.Drawing.Point(213, 422);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(75, 23);
      this.btnLoad.TabIndex = 52;
      this.btnLoad.Text = "Load";
      this.btnLoad.UseVisualStyleBackColor = true;
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // btnSaveAs
      // 
      this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveAs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.btnSaveAs.Location = new System.Drawing.Point(294, 422);
      this.btnSaveAs.Name = "btnSaveAs";
      this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
      this.btnSaveAs.TabIndex = 51;
      this.btnSaveAs.Text = "Save To ...";
      this.btnSaveAs.UseVisualStyleBackColor = true;
      this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.btCancel.Location = new System.Drawing.Point(537, 422);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(75, 23);
      this.btCancel.TabIndex = 50;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // btSave
      // 
      this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.btSave.Location = new System.Drawing.Point(375, 422);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(75, 23);
      this.btSave.TabIndex = 48;
      this.btSave.Text = "Save";
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.btOK.Location = new System.Drawing.Point(456, 422);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(75, 23);
      this.btOK.TabIndex = 49;
      this.btOK.Text = "OK";
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // lbConfigFileName
      // 
      this.lbConfigFileName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.lbConfigFileName.Location = new System.Drawing.Point(128, 12);
      this.lbConfigFileName.Name = "lbConfigFileName";
      this.lbConfigFileName.Size = new System.Drawing.Size(484, 30);
      this.lbConfigFileName.TabIndex = 53;
      this.lbConfigFileName.Text = "Config";
      this.lbConfigFileName.Click += new System.EventHandler(this.lbConfigFileName_Click);
      // 
      // MainForm
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(624, 456);
      this.Controls.Add(this.lbConfigFileName);
      this.Controls.Add(this.btnLoad);
      this.Controls.Add(this.btnSaveAs);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btSave);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.lbconfigFileCaption);
      this.Controls.Add(this.Settings);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.Text = "EIDSS Config File Editor";
      this.DatabaseTab.ResumeLayout(false);
      this.archiveDatabaseBox.ResumeLayout(false);
      this.archiveDatabaseBox.PerformLayout();
      this.databaseBox.ResumeLayout(false);
      this.databaseBox.PerformLayout();
      this.Settings.ResumeLayout(false);
      this.ReportingServiceTab.ResumeLayout(false);
      this.ReportingServiceTab.PerformLayout();
      this.WebSettingsTab.ResumeLayout(false);
      this.WebSettingsTab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.idleTimeoutInMinutes)).EndInit();
      this.databaseBoxForAvr.ResumeLayout(false);
      this.databaseBoxForAvr.PerformLayout();
      this.WebAppAdvancedTab.ResumeLayout(false);
      this.WebAppAdvancedTab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.labSectionPageSize)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.detailGridPageSize)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupGridPageSize)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.listGridPageSize)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.defaultDateFilter)).EndInit();
      this.MiscellaneousTab.ResumeLayout(false);
      this.MiscellaneousTab.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lbconfigFileCaption;
    private System.Windows.Forms.TabPage DatabaseTab;
    private System.Windows.Forms.GroupBox archiveDatabaseBox;
    private System.Windows.Forms.CheckBox chkAllowArchiveConnection;
    private System.Windows.Forms.Label lbArchiveDatabase;
    private System.Windows.Forms.Label lbArchiveServer;
    private System.Windows.Forms.TextBox txtArchiveServer;
    private System.Windows.Forms.Label lbArchivePassword;
    private System.Windows.Forms.TextBox txtArchiveDatabase;
    private System.Windows.Forms.Label lbArchiveUser;
    private System.Windows.Forms.TextBox txtArchiveUser;
    private System.Windows.Forms.TextBox txtArchivePassword;
    private System.Windows.Forms.GroupBox databaseBox;
    private System.Windows.Forms.Label lbServer;
    private System.Windows.Forms.Label lbSQLDatabase;
    private System.Windows.Forms.Label lbSQLPassword;
    private System.Windows.Forms.Label lbSQLUserName;
    private System.Windows.Forms.TextBox txtSQLPassword;
    private System.Windows.Forms.TextBox txtSQLUser;
    private System.Windows.Forms.TextBox txtSQLDatabase;
    private System.Windows.Forms.TextBox txtSQLServer;
    private System.Windows.Forms.TabControl Settings;
    private System.Windows.Forms.TabPage ReportingServiceTab;
    private System.Windows.Forms.Label lbReportingUrl;
    private System.Windows.Forms.TextBox txtReportingUrl;
    private System.Windows.Forms.Label lbRSDisplayName;
    private System.Windows.Forms.TextBox txtRSDisplayName;
    private System.Windows.Forms.Label lbRSName;
    private System.Windows.Forms.TextBox txtRSName;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Button btnSaveAs;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btSave;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.TabPage MiscellaneousTab;
    private System.Windows.Forms.CheckBox defaultRegionInSearch;
    private System.Windows.Forms.Label DefaultDateFilterLabel;
    private System.Windows.Forms.NumericUpDown defaultDateFilter;
    private System.Windows.Forms.Label lbErrorLogPath;
    private System.Windows.Forms.TextBox txtErrorLogPath;
    private System.Windows.Forms.TabPage WebSettingsTab;
    private System.Windows.Forms.TextBox mobileWebEidssPath;
    private System.Windows.Forms.Label MobileWebEidssPathLabel;
    private System.Windows.Forms.Label lbMapLocalUrl;
    private System.Windows.Forms.TextBox txtMapLocalUrl;
    private System.Windows.Forms.TabPage WebAppAdvancedTab;
    private System.Windows.Forms.Label lbConfigFileName;
    private System.Windows.Forms.TextBox avrUrl;
    private System.Windows.Forms.Label AvrUrlLabel;
    private System.Windows.Forms.Label AvrServiceHostUrlLabel;
    private System.Windows.Forms.TextBox avrServiceHostURL;
    private System.Windows.Forms.GroupBox databaseBoxForAvr;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtSQLPasswordForAvr;
    private System.Windows.Forms.TextBox txtSQLUserForAvr;
    private System.Windows.Forms.TextBox txtSQLDatabaseForAvr;
    private System.Windows.Forms.TextBox txtSQLServerForAvr;
    private System.Windows.Forms.ComboBox cbDefaultLanguage;
    private System.Windows.Forms.Label DefaultLanguageLabel;
    private System.Windows.Forms.TextBox txtSupportedLanguages;
    private System.Windows.Forms.Label lbSupportedLanguages;
    private System.Windows.Forms.Label rowsInListFormLabel;
    private System.Windows.Forms.Label rowsOnDetailFormLabel;
    private System.Windows.Forms.Label forSelectModeLabel;
    private System.Windows.Forms.Label forViewEditModeLabel;
    private System.Windows.Forms.NumericUpDown detailGridPageSize;
    private System.Windows.Forms.NumericUpDown popupGridPageSize;
    private System.Windows.Forms.NumericUpDown listGridPageSize;
    private System.Windows.Forms.Label labelIdleTimeout;
    private System.Windows.Forms.NumericUpDown idleTimeoutInMinutes;
    private System.Windows.Forms.NumericUpDown labSectionPageSize;
    private System.Windows.Forms.Label rowsOnLabSectionLabel;
  }
}