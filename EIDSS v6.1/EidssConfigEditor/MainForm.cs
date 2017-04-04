namespace EidssConfigEditor
{
  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Diagnostics;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using System.Windows.Forms;
  using bv.common.Configuration;
  using bv.common.Core;
  using Properties;


  public partial class MainForm : Form
  {
    private const string ConnectionSource = "ConnectionSource";
    private const string SqlServer = "SQLServer";
    private const string SqlDatabase = "SQLDatabase";
    private const string SqlUser = "SQLUser";
    private const string SqlPassword = "SQLPassword";
    private const string ArchiveServer = "ArchiveServer";
    private const string ArchiveDatabase = "ArchiveDatabase";
    private const string ArchiveUser = "ArchiveUser";
    private const string ArchivePassword = "ArchivePassword";

    private const string ServiceSystemName = "ServiceSystemName";
    private const string ServiceDisplayName = "ServiceDisplayName";
    private const string ReportServiceHostUrl = "ReportServiceHostURL";

    private const string MapLocalUrl = "MapLocalUrl";
    private const string MobileWebEidssPath = "MobileWebEidssPath";
    private const string LifetimeSeconds = "LifetimeSeconds";
    private const int IdleTimeoutInSecondsDefault = 60 * 60;
    private const string AvrUrl = "AvrUrl";
    private const string AvrServiceHostUrl = "AVRServiceHostURL";
    private const string AvrConnectionString = "AvrConnectionString";
    private const string AvrConnectionStringValue =
      @"Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};server={3};Asynchronous Processing=True;";
    private const string AvrServer = "AvrServer";
    private const string AvrUser = "AvrUser";
    private const string AvrPassword = "AvrPassword";
    private const string AvrDatabase = "AvrDatabase";

    private const string DefaultRegionInSearch = "DefaultRegionInSearch";
    private const string DefaultDateFilter = "DefaultDateFilter";
    private const string ListGridPageSize = "ListGridPageSize";
    private const string PopupGridPageSize = "PopupGridPageSize";
    private const string DetailGridPageSize = "DetailGridPageSize";
    private const string LabSectionPageSize = "LabSectionPageSize";

    private const string SupportedLanguages = "SupportedLanguages";
    private const string DefaultLanguage = "DefaultLanguage";
    private const string ErrorLogPath = "ErrorLogPath";

    private readonly List<string> m_availableLanguages = new List<string>
    {
      "en",
      "ru",
      "ka",
      "kk",
      "uz-C",
      "uz-L",
      "az-L",
      "hy",
      "uk",
      "ar",
      "lo",
      "vi",
      "th"
    };

    private ConfigWriter m_config;

    public MainForm()
    {
      InitializeComponent();
      Init(null);
    }

    // Начальная загрузка строк из конфигурационного файла
    private void Init(string configName)
    {
      try
      {
        LoadConfig(configName);

        InitDbSettingsTab();
        InitReportingServiceFields();
        InitWebSettingsTab();
        InitWebAdvancedSettingsTab();
        InitMiscellaneousTab();
      }
      catch (Exception)
      {
      }
    }

    private void LoadConfig(string configName)
    {
      m_config = ConfigWriter.Instance;
      if (string.IsNullOrEmpty(configName))
      {
        configName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Config.GeneralConfigName);
      }
      m_config.Read(File.Exists(configName) ? configName : Config.DefaultGeneralConfigPath);
      lbConfigFileName.Text = m_config.FileName;
    }

    private void InitWebAdvancedSettingsTab()
    {
      var defRegion = m_config.GetItem(DefaultRegionInSearch).ToLowerInvariant();
      defaultRegionInSearch.Checked = (defRegion == "true" || defRegion.Trim() == String.Empty);
      defaultDateFilter.Text = m_config.GetItem(DefaultDateFilter);
      listGridPageSize.Text = m_config.GetItem(ListGridPageSize);
      popupGridPageSize.Text = m_config.GetItem(PopupGridPageSize);
      detailGridPageSize.Text = m_config.GetItem(DetailGridPageSize);
      labSectionPageSize.Text = m_config.GetItem(LabSectionPageSize);
    }

    private void InitMiscellaneousTab()
    {
      foreach (var lng in m_availableLanguages)
      {
        if (!cbDefaultLanguage.Items.Contains(lng))
        {
          cbDefaultLanguage.Items.Add(lng);
        }
      }
      cbDefaultLanguage.SelectedItem = m_config.GetItem(DefaultLanguage);
      txtSupportedLanguages.Text = m_config.GetItem(SupportedLanguages);
      txtErrorLogPath.Text = m_config.GetItem(ErrorLogPath);
    }

    private void InitReportingServiceFields()
    {
      txtRSName.Text = m_config.GetItem(ServiceSystemName);
      txtRSDisplayName.Text = m_config.GetItem(ServiceDisplayName);
      txtReportingUrl.Text = m_config.GetItem(ReportServiceHostUrl);
    }

    private void InitDbSettingsTab()
    {
      InitSqlDbFields();
      InitArchiveDbFields();
    }

    private void InitWebSettingsTab()
    {
      txtMapLocalUrl.Text = m_config.GetItem(MapLocalUrl);
      mobileWebEidssPath.Text = m_config.GetItem(MobileWebEidssPath);
      avrUrl.Text = m_config.GetItem(AvrUrl);
      avrServiceHostURL.Text = m_config.GetItem(AvrServiceHostUrl);
      InitLifetimeSeconds();
      InitDbForAvrFields();
    }

    private void InitLifetimeSeconds()
    {
      var lifetimesecondsValue = m_config.GetItem(LifetimeSeconds);
      var lifetimeSeconds = IdleTimeoutInSecondsDefault;
      if (!string.IsNullOrEmpty(lifetimesecondsValue)
        && !int.TryParse(m_config.GetItem(LifetimeSeconds), out lifetimeSeconds))
      {
        MessageBox.Show(
          this,
          string.Format(Resources.InitLifetimeSeconds_InitializatinErrorMessage, lifetimesecondsValue),
          Resources.InitLifetimeSeconds_InitializatinErrorTitle,
          MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
      }
      else
      {
        idleTimeoutInMinutes.Text = (lifetimeSeconds / 60).ToString(CultureInfo.InvariantCulture);
      }
    }

    private void InitArchiveDbFields()
    {
      txtArchiveServer.Text = m_config.GetItem(ArchiveServer);
      txtArchiveDatabase.Text = m_config.GetItem(ArchiveDatabase);
      txtArchiveUser.Text = m_config.GetItem(ArchiveUser);
      txtArchivePassword.Text = m_config.GetItem(ArchivePassword);
      try
      {
        if (!string.IsNullOrEmpty(txtArchiveUser.Text))
        {
          txtArchiveUser.Text = Cryptor.Decrypt(txtArchiveUser.Text);
        }
        if (!string.IsNullOrEmpty(txtArchivePassword.Text) && !string.IsNullOrEmpty(txtArchiveUser.Text))
        {
          txtArchivePassword.Text = Cryptor.Decrypt(txtArchivePassword.Text, txtArchiveUser.Text);
        }
      }
      catch (Exception)
      {
      }

      chkAllowArchiveConnection.Checked = TestConnection(
        txtArchiveServer.Text,
        txtArchiveDatabase.Text,
        txtArchiveUser.Text,
        txtArchivePassword.Text);
    }

    private void InitSqlDbFields()
    {
      txtSQLServer.Text = m_config.GetItem(SqlServer);
      txtSQLDatabase.Text = m_config.GetItem(SqlDatabase);
      txtSQLUser.Text = m_config.GetItem(SqlUser);
      txtSQLPassword.Text = m_config.GetItem(SqlPassword);

      try
      {
        if (!string.IsNullOrEmpty(txtSQLUser.Text))
        {
          txtSQLUser.Text = Cryptor.Decrypt(txtSQLUser.Text);
        }
        if (!string.IsNullOrEmpty(txtSQLPassword.Text) && !string.IsNullOrEmpty(txtSQLUser.Text))
        {
          txtSQLPassword.Text = Cryptor.Decrypt(txtSQLPassword.Text, txtSQLUser.Text);
        }
      }
      catch (Exception)
      {
      }
    }

    private void InitDbForAvrFields()
    {
      txtSQLServerForAvr.Text = m_config.GetItem(AvrServer);
      txtSQLDatabaseForAvr.Text = m_config.GetItem(AvrDatabase);
      txtSQLUserForAvr.Text = m_config.GetItem(AvrUser);
      txtSQLPasswordForAvr.Text = m_config.GetItem(AvrPassword);

      try
      {
        if (!string.IsNullOrEmpty(txtSQLUserForAvr.Text))
        {
          txtSQLUserForAvr.Text = Cryptor.Decrypt(txtSQLUserForAvr.Text);
        }
        if (!string.IsNullOrEmpty(txtSQLPasswordForAvr.Text) && !string.IsNullOrEmpty(txtSQLUserForAvr.Text))
        {
          txtSQLPasswordForAvr.Text = Cryptor.Decrypt(txtSQLPasswordForAvr.Text, txtSQLUserForAvr.Text);
        }
      }
      catch (Exception)
      {
      }

    }

    private void EnableArchive(bool enable)
    {
      txtArchiveServer.Enabled = enable;
      txtArchiveDatabase.Enabled = enable;
      txtArchiveUser.Enabled = enable;
      txtArchivePassword.Enabled = enable;
    }

    private bool Save(string fileName = null)
    {
      Cursor = Cursors.WaitCursor;
      try
      {
        if (!ValidateConnection() || !ValidateArchiveConnection() || !ValidateLanguages() || !ValidateConnectionForAvr())
        {
          return false;
        }

        SaveDbConnection();
        SaveArchiveConnection();
        SaveReportsServiceSettings();
        SaveWebSettings();
        SaveWebAdvancedSettings();
        SaveMiscellaneousSettings();

        if (fileName == null)
        {
          m_config.Save(true, true);
        }
        else
        {
          m_config.SaveAs(fileName, true, true);
        }
        return true;
      }
      catch (Exception e)
      {
        MessageBox.Show(this, "Can't save configuration file: " + e.Message);
        return false;
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }

    private bool ValidateConnection()
    {
      return TestConnection(txtSQLServer.Text, txtSQLDatabase.Text, txtSQLUser.Text, txtSQLPassword.Text);
    }

    private bool ValidateArchiveConnection()
    {
      return !chkAllowArchiveConnection.Checked ||
             TestConnection(txtArchiveServer.Text, txtArchiveDatabase.Text, txtArchiveUser.Text, txtArchivePassword.Text);
    }

    private bool ValidateConnectionForAvr()
    {
      if (string.IsNullOrEmpty(txtSQLServerForAvr.Text)
          && string.IsNullOrEmpty(txtSQLDatabaseForAvr.Text)
          && string.IsNullOrEmpty(txtSQLUserForAvr.Text)
          && string.IsNullOrEmpty(txtSQLPasswordForAvr.Text))
      {
        return true;
      }

      return TestConnection(txtSQLServerForAvr.Text, txtSQLDatabaseForAvr.Text, txtSQLUserForAvr.Text, txtSQLPasswordForAvr.Text, AvrConnectionStringValue);
    }

    private void SaveArchiveConnection()
    {
      if (!chkAllowArchiveConnection.Checked)
      {
        txtArchiveServer.Text = "";
        txtArchiveDatabase.Text = "";
        txtArchiveUser.Text = "";
        txtArchivePassword.Text = "";
        m_config.SetItem(ArchiveDatabase, "");
        m_config.SetItem(ArchiveServer, "");
        m_config.SetItem(ArchiveUser, "");
        m_config.SetItem(ArchivePassword, "");
      }
      else
      {
        m_config.SetItem(ArchiveDatabase, txtArchiveDatabase.Text);
        m_config.SetItem(ArchiveServer, txtArchiveServer.Text);
        m_config.SetItem(ArchiveUser, Cryptor.Encrypt(txtArchiveUser.Text));
        m_config.SetItem(ArchivePassword, Cryptor.Encrypt(txtArchivePassword.Text, txtArchiveUser.Text));
      }
    }

    private void SaveDbConnection()
    {
      m_config.SetItem(ConnectionSource, "1");
      m_config.SetItem(SqlDatabase, txtSQLDatabase.Text);
      m_config.SetItem(SqlServer, txtSQLServer.Text);
      m_config.SetItem(SqlUser, Cryptor.Encrypt(txtSQLUser.Text));
      m_config.SetItem(SqlPassword, Cryptor.Encrypt(txtSQLPassword.Text, txtSQLUser.Text));
    }

    private void SaveDbConnectionForAvr()
    {
      if (string.IsNullOrEmpty(txtSQLServerForAvr.Text)
          && string.IsNullOrEmpty(txtSQLDatabaseForAvr.Text)
          && string.IsNullOrEmpty(txtSQLUserForAvr.Text)
          && string.IsNullOrEmpty(txtSQLPasswordForAvr.Text))
      {
        txtSQLDatabaseForAvr.Text = txtSQLDatabase.Text;
        txtSQLServerForAvr.Text = txtSQLServer.Text;
        txtSQLUserForAvr.Text = txtSQLUser.Text;
        txtSQLPasswordForAvr.Text = txtSQLPassword.Text;
      }

      m_config.SetItem(AvrConnectionString, AvrConnectionStringValue);
      m_config.SetItem(AvrDatabase, txtSQLDatabaseForAvr.Text);
      m_config.SetItem(AvrServer, txtSQLServerForAvr.Text);
      m_config.SetItem(AvrUser, Cryptor.Encrypt(txtSQLUserForAvr.Text));
      m_config.SetItem(AvrPassword, Cryptor.Encrypt(txtSQLPasswordForAvr.Text, txtSQLUserForAvr.Text));
    }

    private bool ValidateLanguages()
    {
      try
      {
        string[] langList = txtSupportedLanguages.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (langList.All(IsValidLanguage))
        {
          return true;
        }
        MessageBox.Show(
          "Supported languages list is in invalid format. It must contain comma separated list of languages. Only languages listed in Default Language combo box can be used for this list");
        return false;
      }
      catch (Exception)
      {
        MessageBox.Show(
          "Supported languages list is in invalid format. It must contain comma separated list of languages. Only languages listed in Default Language combo box can be used for this list");
        return false;
      }
    }

    private bool IsValidLanguage(string lng)
    {
      return m_availableLanguages.Contains(lng.Trim());
    }

    private void SaveWebAdvancedSettings()
    {
      m_config.SetItem(DefaultRegionInSearch, defaultRegionInSearch.Checked.ToString());
      m_config.SetItem(DefaultDateFilter, defaultDateFilter.Text);
      m_config.SetItem(ListGridPageSize, listGridPageSize.Text);
      m_config.SetItem(PopupGridPageSize, popupGridPageSize.Text);
      m_config.SetItem(DetailGridPageSize, detailGridPageSize.Text);
      m_config.SetItem(LabSectionPageSize, labSectionPageSize.Text);
    }

    private void SaveMiscellaneousSettings()
    {
      m_config.SetItem(SupportedLanguages, txtSupportedLanguages.Text);
      m_config.SetItem(DefaultLanguage, cbDefaultLanguage.Text);
      m_config.SetItem(ErrorLogPath, txtErrorLogPath.Text);
    }

    private void SaveReportsServiceSettings()
    {
      m_config.SetItem(ServiceSystemName, txtRSName.Text);
      m_config.SetItem(ServiceDisplayName, txtRSDisplayName.Text);
      m_config.SetItem(ReportServiceHostUrl, txtReportingUrl.Text);
    }

    private void SaveWebSettings()
    {
      m_config.SetItem(MapLocalUrl, txtMapLocalUrl.Text);
      m_config.SetItem(MobileWebEidssPath, mobileWebEidssPath.Text);
      m_config.SetItem(AvrUrl, avrUrl.Text);
      m_config.SetItem(AvrServiceHostUrl, avrServiceHostURL.Text);
      SetLifetimeSeconds();
      SaveDbConnectionForAvr();
    }

    private void SetLifetimeSeconds()
    {
      m_config.SetItem(LifetimeSeconds, (int.Parse(idleTimeoutInMinutes.Text) * 60).ToString(CultureInfo.InvariantCulture));
    }

    private static bool IsCorrect(string server, string database, string user, string password)
    {
      return !string.IsNullOrEmpty(server) &&
             !string.IsNullOrEmpty(database) &&
             !string.IsNullOrEmpty(user) &&
             !string.IsNullOrEmpty(password);
    }

    private static bool TestConnection(
      string server,
      string database,
      string user,
      string password,
      string connectionStringFormat = "Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};Data Source={3};Connection timeout = 2")
    {
      if (!IsCorrect(server, database, user, password))
      {
        return false;
      }

      try
      {
        var connectionString = string.Format(connectionStringFormat, user, password, database, server);
        var connection = new SqlConnection(connectionString);
        var cmd = new SqlCommand("Select 0", connection) { CommandTimeout = 3 };
        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
        return true;
      }
      catch (SqlException ex)
      {
        MessageBox.Show(ex.Message, "Connection failed!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
      }
      return false;
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btnSaveAs_Click(object sender, EventArgs e)
    {
      string dir = Path.GetDirectoryName(m_config.FileName);
      var dlg = new FolderBrowserDialog
      {
        SelectedPath = dir,
        Description = "Select folder where you want to place configuration file.",
        RootFolder = Environment.SpecialFolder.MyComputer,
        ShowNewFolderButton = false
      };
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Save(dlg.SelectedPath + "\\eidss_general.config");
        lbConfigFileName.Text = m_config.FileName;
      }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      var dlg = new OpenFileDialog
      {
        FileName = m_config.FileName,
        DefaultExt = "config",
        Filter = "Configuration files|*.config"
      };
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Init(dlg.FileName);
        //lbConfigFileName.Text = m_Config.FileName;
      }
    }

    private void lbConfigFileName_Click(object sender, EventArgs e)
    {
      var configFolder = Path.GetDirectoryName(lbConfigFileName.Text);
      if (!string.IsNullOrEmpty(configFolder) && Directory.Exists(configFolder))
      {
        Process.Start(configFolder);
      }
    }

    #region InterfaceHandlers

    private void btOK_Click(object sender, EventArgs e)
    {
      if (Save())
      {
        Close();
      }
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      Save();
    }

    private void chkAllowArchiveConnection_CheckedChanged(object sender, EventArgs e)
    {
      if (chkAllowArchiveConnection.Checked)
      {
        if (string.IsNullOrEmpty(txtArchiveServer.Text))
        {
          txtArchiveServer.Text = txtSQLServer.Text;
        }
        if (string.IsNullOrEmpty(txtArchiveDatabase.Text) && !string.IsNullOrEmpty(txtSQLDatabase.Text))
        {
          txtArchiveDatabase.Text = txtSQLDatabase.Text + "_Archive";
        }
        if (string.IsNullOrEmpty(txtArchiveUser.Text))
        {
          txtArchiveUser.Text = txtSQLUser.Text;
        }
        if (string.IsNullOrEmpty(txtArchivePassword.Text))
        {
          txtArchivePassword.Text = txtSQLPassword.Text;
        }
      }
      else
      {
        txtArchiveServer.Text = "";
        txtArchiveDatabase.Text = "";
        txtArchiveUser.Text = "";
        txtArchivePassword.Text = "";
      }
      EnableArchive(chkAllowArchiveConnection.Checked);
    }

    #endregion
  }
}