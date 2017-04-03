using System;
using System.IO;
using bv.common.Core;
using bv.common.Diagnostics;
#if !MONO
using System.Drawing;
#endif

namespace bv.common.Configuration
{
    public class BaseSettings
    {
        private const int DefaultSqlTimeout = 200;

#if !MONO
        public static bool DebugOutput
        {
            get { return Config.GetBoolSetting("DebugOutput", true); }
        }

        public static string DebugLogFile
        {
            get { return Config.GetSetting("DebugLogFile", null); }
        }

        public static int DebugDetailLevel
        {
            get
            {
                int level;
                if (int.TryParse(Config.GetSetting("DebugDetailLevel", "0"), out level))
                {
                    return level;
                }
                return 0;
            }
        }

        public static string ObjectsSchemaPath
        {
            get
            {
                string path = Config.GetSetting("SchemaPath", "..\\..\\Schema") + "\\Objects\\";
                Dbg.Assert(Directory.Exists(path), "objects schema path <{0}> doesn\'t exists", path);
                return path;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return Config.GetSetting("SQLConnectionString",
                                         "Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};Data Source={3};Asynchronous Processing=True;");
            }
        }

        public static int SqlCommandTimeout
        {
            get { return Config.GetIntSetting("SqlCommandTimeout", 200); }
        }

        public static bool UseDefaultLogin
        {
            get { return Config.GetBoolSetting("UseDefaultLogin", false); }
        }

        public static string DefaultOrganization
        {
            get { return Config.GetSetting("DefaultOrganization", null); }
        }

        public static string DefaultUser
        {
            get { return Config.GetSetting("DefaultUser", null); }
        }

        public static string DefaultPassword
        {
            get { return Config.GetSetting("DefaultPassword", null); }
        }

        public static string SqlServer
        {
            get { return Config.GetSetting("SQLServer", "(local)"); }
        }

        public static string SqlDatabase
        {
            get { return Config.GetSetting("SQLDatabase", "eidss_v4"); }
        }

        public static string SqlUser
        {
            get { return Config.GetSetting("SQLUser", null); }
        }

        public static string SqlPassword
        {
            get { return Config.GetSetting("SQLPassword", null); }
        }

        public static string InplaceShowDropDown
        {
            get { return Config.GetSetting("InplaceShowDropDown", null); }
        }

        public static string ShowDropDown
        {
            get { return Config.GetSetting("ShowDropDown", null); }
        }

        public static int LookupCacheRefreshInterval
        {
            get { return Config.GetIntSetting("LookupCacheRefreshInterval", 500); }
        }

        public static int LookupCacheIdleRefreshInterval
        {
            get { return Config.GetIntSetting("LookupCacheIdleRefreshInterval", 500); }
        }

        public static bool ForceMemoryFlush
        {
            get { return Config.GetBoolSetting("ForceMemoryFlush", true); }
        }

        public static bool ForceFormsDisposing
        {
            get { return Config.GetBoolSetting("ForceFormsDisposing", true); }
        }

        public static int PagerPageSize
        {
            get { return Config.GetIntSetting("PagerPageSize", 50); }
        }

        public static int PagerPageCount
        {
            get { return Config.GetIntSetting("PagerPageCount", 10); }
        }

        public static bool DontStartClient
        {
            get { return Config.GetBoolSetting("DontStartClient"); }
        }

        public static int ConnectionSource
        {
            get { return Config.GetIntSetting("ConnectionSource", 0); }
        }

        public static int TcpPort
        {
            get { return Config.GetIntSetting("TcpPort", 4005); }
        }

        //Possible values: Default, ClientID, User

        private static string s_SystemFontName;

        public static string SystemFontName
        {
            get
            {
                if (Utils.Str(s_SystemFontName) == "")
                {
                    s_SystemFontName = Config.GetSetting("SystemFontName", FontFamily.GenericSansSerif.Name);
                }
                return s_SystemFontName;
            }
        }

        private static string s_GGSystemFontName = "";

        public static string GGSystemFontName
        {
            get
            {
                if (Utils.Str(s_GGSystemFontName) == "")
                {
                    s_GGSystemFontName = Config.GetSetting("GeorgianSystemFontName", "Sylfaen");
                }
                return s_GGSystemFontName;
            }
        }

        private static float s_SystemFontSize;

        public static float SystemFontSize
        {
            get
            {
                if (s_SystemFontSize == 0)
                {
                    string fontSizeStr = Config.GetSetting("SystemFontSize", null);
                    if (fontSizeStr != null)
                    {
                        Single.TryParse(fontSizeStr, out s_SystemFontSize);
                    }
                }
                if (s_SystemFontSize == 0)
                {
                    s_SystemFontSize = (float) (8.25);
                }
                return s_SystemFontSize;
            }
        }

        private static float s_GGSystemFontSize;

        public static float GGSystemFontSize
        {
            get
            {
                if (s_GGSystemFontSize == 0)
                {
                    string fontSizeStr = Config.GetSetting("GeorgianSystemFontSize", null);
                    if (fontSizeStr != null)
                    {
                        Single.TryParse(fontSizeStr, out s_GGSystemFontSize);
                    }
                }
                if (s_GGSystemFontSize == 0)
                {
                    s_GGSystemFontSize = (float) (8.25);
                }
                return s_GGSystemFontSize;
            }
        }

        public static string DefaultLanguage
        {
            get { return Config.GetSetting("DefaultLanguage", "en"); }
        }

        public static string BarcodePrinter
        {
            get { return Config.GetSetting("BarcodePrinter", null); }
        }

        public static string DocumentPrinter
        {
            get { return Config.GetSetting("DocumentPrinter", null); }
        }

        public static int LookupCacheTimeout
        {
            get { return Config.GetIntSetting("LookupTimeout", 300); }
        }

        public static bool IgnoreAbsentResources
        {
            get { return Config.GetBoolSetting("IgnoreAbsentResources"); }
        }

        public static bool ShowClearLookupButton
        {
            get { return Config.GetBoolSetting("ShowClearLookupButton", true); }
        }

        public static bool ShowClearRepositoryLookupButton
        {
            get { return Config.GetBoolSetting("ShowClearRepositoryLookupButton"); }
        }

        public static string DetailFormType
        {
            get { return Config.GetSetting("DetailFormType", "Normal"); }
        }

        public static bool ShowDeleteButtonOnDetailForm
        {
            get { return Config.GetBoolSetting("ShowDeleteButtonOnDetailForm"); }
        }

        public static bool ShowSaveButtonOnDetailForm
        {
            get { return Config.GetBoolSetting("ShowSaveButtonOnDetailForm"); }
        }

        public static bool ShowNewButtonOnDetailForm
        {
            get { return Config.GetBoolSetting("ShowNewButtonOnDetailForm"); }
        }

        public static bool DirectDataAccess
        {
            get { return Config.GetBoolSetting("DirectDataAccess", true); }
        }

        public static string OneInstanceMethod
        {
            get { return Config.GetSetting("OneInstanceMethod"); }
        }

        public static bool ShowCaptionOnToolbar
        {
            get { return Config.GetBoolSetting("ShowCaptionOnToolbar"); }
        }

        public static bool ShowEmptyListOnSearch
        {
            get { return Config.GetBoolSetting("ShowEmptyListOnSearch", true); }
        }
        public static bool ShowAvrAsterisk
        {
            get { return Config.GetBoolSetting("ShowAvrAsterisk", true); }
        }
        
        public static bool ShowDateTimeFormatAsNullText
        {
            get { return Config.GetBoolSetting("ShowDateTimeFormatAsNullText", true); }
        }

        public static bool ShowSaveDataPrompt
        {
            get { return Config.GetBoolSetting("ShowSaveDataPrompt", true); }
        }

        public static bool ShowNavigatorInH02Form
        {
            get { return Config.GetBoolSetting("ShowNavigatorInH02Form"); }
        }

           public static bool ShowBigLayoutWarning
        {
            get { return Config.GetBoolSetting("ShowBigLayoutWarning"); }
        }
      

        public static bool ThrowExceptionOnError
        {
            get
            {
                bool fromUnitTest = Utils.IsCalledFromUnitTest();
                return Config.GetBoolSetting("ThrowExceptionOnError", fromUnitTest);
            }
        }

        public static bool SaveOnCancel
        {
            get { return Config.GetBoolSetting("SaveOnCancel", true); }
        }

        public static bool ShowDeletePrompt
        {
            get { return Config.GetBoolSetting("ShowDeletePrompt", true); }
        }

        public static bool ShowRecordsFromCurrentSiteForNewCase
        {
            get { return Config.GetBoolSetting("ShowRecordsFromCurrentSiteForNewCase", true); }
        }

        public static bool AutoClickDuplicateSearchButton
        {
            get { return Config.GetBoolSetting("AutoClickDuplicateSearchButton", true); }
        }

        public static string SkinName
        {
            get { return Config.GetSetting("SkinName", "Money Twins"); }
        }

        public static string ServerPath
        {
            get { return Config.GetSetting("ServerPath"); }
        }

        public static string SkinAssembly
        {
            get { return Config.GetSetting("SkinAssembly"); }
        }

        public static bool IgnoreTopMaxCount
        {
            get { return Config.GetBoolSetting("IgnoreTopMaxCount"); }
        }

     
        public static bool AsSessionTableView
        {
            get { return Config.GetBoolSetting("AsSessionTableView"); }
        }

        public static string ArchiveConnectionString
        {
            get { return Config.GetSetting("ArchiveConnectionString"); }
        }
        public static bool WarnIfResourceEmpty
        {
            get { return Config.GetBoolSetting("WarnIfResourceEmpty"); }
        }
        public static bool LabSimplifiedMode
        {
            get { return Config.GetBoolSetting("LabSimplifiedMode", false); }
        }
        public static string EpiInfoPath
        {
            get { return Config.GetSetting("EpiInfoPath"); }
        }

#endif

        public static int SelectTopMaxCount
        {
#if MONO
            get { return 10000; }
#else
            get { return Config.GetIntSetting("SelectTopMaxCount", 10000); }
#endif
        }

        public static int DefaultDateFilter
        {
#if MONO
            get { return 14; }
#else
            get { return Config.GetIntSetting("DefaultDateFilter", 14); }
#endif
        }
        public static bool UpdateConnectionInfo
        {
            get { return Config.GetBoolSetting("UpdateConnectionInfo", true); }
        }

    }
}
