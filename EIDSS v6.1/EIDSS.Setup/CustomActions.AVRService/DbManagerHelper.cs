namespace CustomActions
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Globalization;
  using System.IO;
  using System.Xml.Linq;
  using System.Xml.XPath;
  using Ionic.Zip;
  using Microsoft.Deployment.WindowsInstaller;
  using Microsoft.SqlServer.Management.Common;
  using Microsoft.SqlServer.Management.Smo;


  public class DbManagerHelper
  {
    private const string DbManagerFileName = "DB.Manager.exe";
    private const string AVRDbInstallationSettingsConfig = "AVR_Db_Installation_Settings.config";
    private const string DbManagerExeConfig = "DB.Manager.exe.config";
    private const string DbManagerZipFile = "DB.Manager.zip";

    [CustomAction]
    public static ActionResult PrepareAvrDbDeplymentConfig(Session session)
    {
      session.Log("Begin PrepareAvrDbDeplymentConfig");

      PrepareInstallerConfig(session);
      PrepareDbManagerExeConfig(session);

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult DeployAvrDatabase(Session session)
    {
      session.Log("Begin DeployAvrDatabase");

      DropExistingDatabase(session);

      var executable = session[InstallerProperties.DbManagerPath];
      var arguments = string.Format("-i \"{0}\" -q", session[InstallerProperties.AVRDbInstallationSettingsConfig]);

      var startInfo = new ProcessStartInfo
      {
        WorkingDirectory = session[InstallerProperties.DbManagerFolder],
        CreateNoWindow = true,
        UseShellExecute = false,
        FileName = executable,
        WindowStyle = ProcessWindowStyle.Hidden,
        Arguments = arguments
      };

      session.Log("Running command: {0} {1}", executable, arguments);
      using (var exeProcess = Process.Start(startInfo))
      {
        exeProcess.WaitForExit();
        LogDbManagerLog(session);
        if (0 == exeProcess.ExitCode)
        {
          return ActionResult.Success;
        }
        session.Log("{0} {1} finished with code {2}", executable, arguments, exeProcess.ExitCode);
        return ActionResult.Failure;
      }
    }

    [CustomAction]
    public static ActionResult DropAvrDatabase(Session session)
    {
      session.Log("Begin DropAvrDatabase");

      DropExistingDatabase(session);

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult SearchForDbManagerArchive(Session session)
    {
      session.Log("Begin SearchForDbManagerArchive");

      session[InstallerProperties.DbManagerArchive] = SearchForDbManagerArchivePath(session);

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult PrepareDbManagerToExtract(Session session)
    {
      session.Log("Begin PrepareDbManagerToExtract");

      var dbManagerFodler = BuildDbManagerFolder();
      SetDbManagerProperties(session, dbManagerFodler);

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult ExtractDbManager(Session session)
    {
      session.Log("Begin ExtractDbManager");

      TryExtractDbManager(session, GetDbManagerArchivePath(session), session[InstallerProperties.DbManagerFolder]);

      return ActionResult.Success;
    }

    [CustomAction]
    public static ActionResult RemoveDbManager(Session session)
    {
      session.Log("Begin RemoveDbManager");

      DeleteDbManagerFolder(GetDbManagerFolder(session));

      return ActionResult.Success;
    }

    #region Implementation

    private static void PrepareDbManagerExeConfig(Session session)
    {
      var dbManagerExeConfig = Path.Combine(session[InstallerProperties.DbManagerFolder], DbManagerExeConfig);
      var dbManagerConfigDoc = XDocument.Load(dbManagerExeConfig);

      var avrCryptor = new Utils.CryptorWrapper(session);
      avrCryptor.EncryptAccountDetails(InstallerProperties.AvrUser, InstallerProperties.AvrPassword);
      AddSetting(dbManagerConfigDoc, "/configuration/appSettings", "AvrDbSQLAccountName", avrCryptor.ResultUser);
      AddSetting(dbManagerConfigDoc, "/configuration/appSettings", "AvrDbSQLAccountPass", avrCryptor.ResultPassword);

      session.Log("Saving \"{0}\"", dbManagerExeConfig);
      dbManagerConfigDoc.Save(dbManagerExeConfig);
    }

    private static void PrepareInstallerConfig(Session session)
    {
      var dbManagerInstallerDoc = XDocument.Parse(Properties.Resources.AVR_Db_Installation_Settings);

      SetSetting(dbManagerInstallerDoc, "server_name", session[InstallerProperties.DbServer]);
      SetSetting(dbManagerInstallerDoc, "database_name", session[InstallerProperties.SqlDatabase]);

      var adminCryptor = new Utils.CryptorWrapper(session);
      adminCryptor.EncryptAccountDetails(InstallerProperties.AdminDbUser, InstallerProperties.AdminDbPassword);
      session[InstallerProperties.EncryptedAdminDbUser] = adminCryptor.ResultUser;
      session[InstallerProperties.EncryptedAdminDbPassword] = adminCryptor.ResultPassword;
      SetSetting(dbManagerInstallerDoc, "{user_name}", adminCryptor.ResultUser);
      SetSetting(dbManagerInstallerDoc, "{user_name_password}", adminCryptor.ResultPassword);

      SetSetting(dbManagerInstallerDoc, "avr_server_name", session[InstallerProperties.AvrDbServer]);
      SetSetting(dbManagerInstallerDoc, "avr_database_name", session[InstallerProperties.AvrDatabase]);

      var avrAdminCryptor = new Utils.CryptorWrapper(session);
      avrAdminCryptor.EncryptAccountDetails(InstallerProperties.AdminAvrUser, InstallerProperties.AdminAvrPassword);
      session[InstallerProperties.EncryptedAdminAvrUser] = avrAdminCryptor.ResultUser;
      session[InstallerProperties.EncryptedAdminAvrPassword] = avrAdminCryptor.ResultPassword;
      SetSetting(dbManagerInstallerDoc, "{avr_server_user_name}", avrAdminCryptor.ResultUser);
      SetSetting(dbManagerInstallerDoc, "{avr_server_user_name_password}", avrAdminCryptor.ResultPassword);

      SetSetting(dbManagerInstallerDoc, "avr_backup_file", session[InstallerProperties.AvrBackup]);

      var avrDbInstallationSettingsConfig = Path.Combine(session[InstallerProperties.DbManagerFolder],
        AVRDbInstallationSettingsConfig);
      session.Log("Saving database installation config {0}", avrDbInstallationSettingsConfig);
      session[InstallerProperties.AVRDbInstallationSettingsConfig] = avrDbInstallationSettingsConfig;
      dbManagerInstallerDoc.Save(avrDbInstallationSettingsConfig);
    }

    private static void LogDbManagerLog(Session session)
    {
      var dbManagerLog = Path.Combine(session[InstallerProperties.DbManagerFolder], Environment.MachineName) + ".log";
      foreach (var dbMangerLogLine in ReadFrom(dbManagerLog))
      {
        session.Log(dbMangerLogLine);
      }
    }

    private static IEnumerable<string> ReadFrom(string file)
    {
      using (var reader = File.OpenText(file))
      {
        string line;
        while (null != (line = reader.ReadLine()))
        {
          yield return line;
        }
      }
    }

    private static void DropExistingDatabase(Session session)
    {
      var server = new Server(session[InstallerProperties.AvrDbServer]);
      var databaseName = session[InstallerProperties.AvrDatabase];
      try
      {
        if (null != server.Databases[databaseName])
        {
          server.KillAllProcesses(databaseName);
          var avrDatabase = server.Databases[databaseName];
          avrDatabase.Refresh();
          avrDatabase.Drop();

          DropExistingUser(session, server);
        }
      }
      catch (ConnectionException exception)
      {
        session.Log(exception.Message);
      }
    }

    private static void DropExistingUser(Session session, Server server)
    {
      var avrUserLogon = server.Logins[session[InstallerProperties.AvrUser]];
      if (null != avrUserLogon)
      {
        avrUserLogon.Drop();
      }
    }

    private static void SetSetting(XDocument doc, string setting, string value)
    {
      doc.Root.XPathSelectElement(string.Format("//add[@key='{0}']", setting)).Attribute("value").SetValue(value);
    }

    private static void AddSetting(XDocument doc, string parentPath, string setting, string value)
    {
      var parentKey = doc.Root.XPathSelectElement(parentPath);
      parentKey.Add(new XElement("add", new XAttribute("key", setting), new XAttribute("value", value)));
    }

    private static void SetDbManagerProperties(Session session, string dbManagerFolder)
    {
      session[InstallerProperties.DbManagerFolder] = dbManagerFolder;
      session[InstallerProperties.DbManagerPath] = Path.Combine(dbManagerFolder, DbManagerFileName);
    }

    private static void TryExtractDbManager(Session session, string archivePath, string dbManagerFolder)
    {
      using (var archive = new ZipFile(archivePath))
      {
        try
        {
          CreateDbManagerExtractFolder(dbManagerFolder);
          archive.ExtractAll(dbManagerFolder);
        }
        catch (Exception ex)
        {
          session.Log(ex.Message);
          throw new InstallerException(ex.Message);
        }
      }
    }

    private static void CreateDbManagerExtractFolder(string dbManagerFolder)
    {
      DeleteDbManagerFolder(dbManagerFolder);
      Directory.CreateDirectory(dbManagerFolder);
    }

    private static void DeleteDbManagerFolder(string dbManagerFolder)
    {
      if (!string.IsNullOrEmpty(dbManagerFolder) && Directory.Exists(dbManagerFolder))
      {
        Directory.Delete(dbManagerFolder, true);
      }
    }

    private static string BuildDbManagerFolder()
    {
      return Path.Combine(
        Path.GetPathRoot(Environment.SystemDirectory),
        Path.GetRandomFileName());
    }

    private static string GetDbManagerArchivePath(Session session)
    {
      var archivePath = session[InstallerProperties.DbManagerArchive];
      if (!string.IsNullOrEmpty(archivePath) && File.Exists(archivePath))
      {
        return archivePath;
      }
      var errorMessage = string.Format(CultureInfo.InvariantCulture, "DB.Manager archive file not found.");
      session.Log(errorMessage);
      throw new InstallerException(errorMessage);
    }

    private static string SearchForDbManagerArchivePath(Session session)
    {
      var archivePath = Path.Combine(session[InstallerProperties.SourceDir], DbManagerZipFile);
      if (!string.IsNullOrEmpty(archivePath) && File.Exists(archivePath))
      {
        return archivePath;
      }
      return string.Empty;
    }

    private static string GetDbManagerFolder(Session session)
    {
      try
      {
        return session[InstallerProperties.DbManagerFolder];
      }
      catch (InstallerException)
      {
      }

      var dbManagerFolder = session.CustomActionData[InstallerProperties.DbManagerFolder];
      if (!string.IsNullOrEmpty(dbManagerFolder))
      {
        return dbManagerFolder;
      }

      var errorMessage = string.Format(
        CultureInfo.InvariantCulture,
        "Not set extraction folder for DB.Manager archive! Specify it in {0} deferred property.",
        InstallerProperties.DbManagerFolder);
      session.Log(errorMessage);
      throw new InstallerException(errorMessage);
    }

    #endregion Implementation
  }
}