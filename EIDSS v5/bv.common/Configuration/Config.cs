using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web;
using bv.common.Core;
using bv.common.Diagnostics;

//[assembly: InternalsVisibleTo("bv_tests")]

namespace bv.common.Configuration
{
    //This class loads configuration settings from <appSettings> section of several configuration classes using the next rules:
    //1. It searches the directory where the executable or bv_common.dll is placed (current directory)
    //2. It searches top level general config file (eidds_general.config) starting the current directory and MaxRecursiveLevel leveles up.
    //   if file is found the settings are readed from this file
    //2. It searches first machine dependant general_MACHINEMAME.config file starting the current directory and MaxRecursiveLevel leveles up.
    //   if file is found the settings are readed from this file
    //3. it searches executableName.config for windows app in the Application.UserAppDataPath directory
    //   if file is found the settings are readed from this file.
    //4. it searches executableName.config for windows app in the Application.CommonAppDataPath directory
    //   if file is found the settings are readed from this file.
    //5. It searches local congig file (executableName.config for windows app and web.config for ASP.NET app)
    //   starting the current directory and 3 leveles up.
    //   if file is found the settings are readed from this file.
    //5. Existing setings that are read already and exist in the current file are not overritten.
    // Configuration file priority is eidds_general.config ->general_MACHINEMAME.config->bv.config->local config.
    public class Config
    {
        private const int MaxRecursiveLevel = 4;
        internal static IDictionary<string, string> m_Settings;
        private static string m_ConfigFileName;
        private static string m_LocalConfigFileName;
        private static readonly string m_MachineConfigName = string.Format("general_{0}.config", Environment.MachineName);
        private const string GeneralConfigName = "eidss_general.config";
        private static string m_LocalConfigName = "";
        private static bool m_Intialized;
        private static int m_RecursiveLevel;


        private Config()
        {
            // NOOP
        }

        internal static IDictionary<string, string> Settings
        {
            get { return m_Settings; }
        }

        public static bool IsInitialized
        {
            get { return m_Intialized; }
        }

        internal static string AppConfigFileName
        {
            get
            {
                Assembly asm = Assembly.GetEntryAssembly();
                if (asm != null)
                {
                    return Path.GetFileName(asm.Location) + ".config";
                }
                return "";
            }
        }

        public static string FileName
        {
            get { return m_ConfigFileName; }
            set { m_LocalConfigFileName = value; }
        }

        public static string MachineConfigName
        {
            get { return m_MachineConfigName; }
        }

        public static void InitSettingsWithDir(string dir)
        {
            InitSettings(dir);
        }

        internal static void InitSettings(string dir = null)
        {
            if (m_Settings != null)
            {
                return;
            }
            m_Settings = new Dictionary<string, string>();
            if (m_LocalConfigFileName == null)
            {
                LoadGeneralSettings();
                LoadMachineGeneralSettings(dir);
                LoadWinUserSettings();
                LoadWinAppSettings();
            }
            LoadLocalSettings();
            m_Intialized = true;
        }

        public static void ReloadSettings()
        {
            m_Intialized = false;
            m_Settings = null;
            InitSettings();
        }

        private static void LoadSettings(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return;
            }
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = fileName };
            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                                        ConfigurationUserLevel
                                                                                                            .None);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                //Dbg.Assert(!Utils.IsEmpty(key), "setting key not specified", null);
                string value = config.AppSettings.Settings[key].Value;
                //Dbg.Assert(Not Utils.IsEmpty(value), "setting value not specified")
                if (!m_Settings.ContainsKey(key))
                {
                    m_Settings.Add(key, value);
                }
                else
                {
                    Dbg.Debug("duplicate key <{0}> in file {1}", key, fileName);
                }
            }
        }

        private static void LoadWinUserSettings()
        {
            if (HttpContext.Current == null &&
                !string.IsNullOrEmpty(UserConfigWriter.Instance.FileName))
            {
                LoadSettings(UserConfigWriter.Instance.FileName);
            }
        }

        private static void LoadWinAppSettings()
        {
            if (HttpContext.Current == null &&
                !string.IsNullOrEmpty(AppConfigWriter.Instance.FileName))
            {
                LoadSettings(AppConfigWriter.Instance.FileName);
            }
        }

        private static void LoadGeneralSettings()
        {
            FindGeneralConfigFile();
            if (!Utils.IsEmpty(m_ConfigFileName))
            {
                LoadSettings(m_ConfigFileName);
            }
        }
        private static void LoadMachineGeneralSettings(string dir)
        {
            FindMachineGeneralConfigFile(dir);
            if (!Utils.IsEmpty(m_ConfigFileName))
            {
                LoadSettings(m_ConfigFileName);
            }
        }

        private static void LoadLocalSettings()
        {
            if (Utils.IsEmpty(m_LocalConfigFileName))
            {
                FindLocalConfigFile();
            }
            else
            {
                m_ConfigFileName = m_LocalConfigFileName;
            }
            if (!Utils.IsEmpty(m_ConfigFileName))
            {
                LoadSettings(m_ConfigFileName);
            }
        }

        public static void FindMachineGeneralConfigFile(string appLocation)
        {
            m_ConfigFileName = null;
            appLocation = appLocation ?? GetConfigFileDir();
            string appPath = Path.GetDirectoryName(appLocation);
            if (appPath == null)
                return;
            var dir = new DirectoryInfo(appPath);
            if (!FindFileRecursive(dir, m_MachineConfigName))
            {
                Dbg.Debug("unable to locate machine config via application root path");
            }
        }

        private static readonly string m_CommonApplicationDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\EIDSS";
        private static readonly string m_DefaultGeneralConfigPath = m_CommonApplicationDataFolder + "\\" + GeneralConfigName;

        public string DefaultGeneralConfigPath
        {
            get { return m_DefaultGeneralConfigPath; }
        }

        public static void FindGeneralConfigFile()
        {
            m_ConfigFileName = null;
            string appLocation = GetConfigFileDir();
            string appPath = Path.GetDirectoryName(appLocation);
            if (appPath == null)
                return;
            var dir = new DirectoryInfo(appPath);
            if (!FindFileRecursive(dir, GeneralConfigName))
            {
                if (FindConfigFileInFolder(m_CommonApplicationDataFolder, GeneralConfigName))
                    return;
                if (CreateGeneralConfig())
                {
                    if (FindConfigFileInFolder(m_CommonApplicationDataFolder, GeneralConfigName))
                        return;
                }
                Dbg.Debug("unable to locate machine config via application root path");
            }
        }
        public static bool CreateGeneralConfig()
        {
            try
            {
                if (File.Exists(m_DefaultGeneralConfigPath))
                    return true;
                if (!Directory.Exists(m_CommonApplicationDataFolder))
                {
                    Directory.CreateDirectory(m_CommonApplicationDataFolder);
                }
                var config = new ConfigWriter();
                config.Read(m_DefaultGeneralConfigPath);
                return config.Save();
            }
            catch (Exception ex)
            {
                Dbg.Debug("Error during creating general config file {0}: {1}", m_DefaultGeneralConfigPath, ex);
                return false;
            }
        }
        public static void FindLocalConfigFile()
        {
            m_ConfigFileName = null;
            string appLocation = GetConfigFileDir();
            string appPath = Path.GetDirectoryName(appLocation);
            if (appPath == null)
                return;
            var dir = new DirectoryInfo(appPath);
            if (HttpContext.Current != null)
            {
                m_LocalConfigName = "Web.config";
            }
            else
            {
                m_LocalConfigName = AppConfigFileName;
                if (m_LocalConfigName == "")
                {
                    return;
                }
            }
            if (!FindFileRecursive(dir, m_LocalConfigName))
            {
                Dbg.Debug("unable to locate app config via application root path");
            }
        }

        public static string GetConfigFileDir()
        {
            return Utils.GetExecutingPath();
        }

        public static bool FindConfigFileInFolder(string dir, string fileName)
        {
            if (!dir.EndsWith("\\"))
            {
                dir = dir + "\\";
            }
            string configPath = dir + fileName;
            if (File.Exists(configPath))
            {
                m_ConfigFileName = configPath;
                return true;
            }
            return false;
        }

        public static string GetSetting(string key, string defaultValue = "")
        {
            InitSettings();
            if (m_Settings.ContainsKey(key))
            {
                return m_Settings[key];
            }
            return defaultValue;
        }

        public static bool GetBoolSetting(string key, bool defaultValue = false)
        {
            string setting = GetSetting(key, null);
            if (Utils.Str(setting).ToLowerInvariant() == "true")
            {
                return true;
            }
            if (Utils.Str(setting).ToLowerInvariant() == "false")
            {
                return false;
            }
            return defaultValue;
        }

        public static int GetIntSetting(string key, int defaultValue)
        {
            string setting = GetSetting(key, null);
            int value;
            if (int.TryParse(setting, out value))
            {
                return value;
            }
            return defaultValue;
        }

        public static double GetDoubleSetting(string key, double defaultValue)
        {
            string setting = GetSetting(key, null);
            double value;
            if (double.TryParse(setting, out value))
            {
                return value;
            }
            return defaultValue;
        }

        private static bool FindFileRecursive(DirectoryInfo dir, string fileName)
        {
            if (m_RecursiveLevel >= MaxRecursiveLevel || dir == null)
            {
                return false;
            }
            m_RecursiveLevel += 1;
            try
            {
                if (FindConfigFileInFolder(dir.FullName, fileName))
                {
                    return true;
                }

                if (dir.Parent == null)
                {
                    return false;
                }
                return FindFileRecursive(dir.Parent, fileName);
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during cofig reading: {0}", ex);
                return false;
            }
            finally
            {
                m_RecursiveLevel -= 1;
            }
        }
    }
}
