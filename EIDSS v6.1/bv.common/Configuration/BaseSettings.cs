using System;
using System.Drawing;
using System.IO;
using bv.common.Core;
using bv.common.Diagnostics;

namespace bv.common.Configuration
{
    public class SettingName
    {
        public const string ShowWarningForFinalCaseClassification = "ShowWarningForFinalCaseClassification";
        public const string FilterSamplesByDiagnosis = "FilterSamplesByDiagnosis";
        public const string WebAvrDataLifeTime = "WebAvrDataLifeTime";
        public const string WebAvrDataCheckInterval = "WebAvrDataCheckInterval";
    }
    public class BaseSettings
    {
        //private const int DefaultSqlTimeout = 200;
        //Possible values: Default, ClientID, User
        private static string m_SystemFontName;
        private static string m_GGSystemFontName = "";
        private static string m_THSystemFontName = "";
        private static string m_THReportsFontName = "";
        private static float m_SystemFontSize;
        private static float m_GGSystemFontSize;
        private static float m_THSystemFontSize;
        private static float m_THReportsDeltaFontSize = -1;

        public const string Asterisk = "*";

        public static bool DebugOutput
        {
            get { return Config.GetBoolSetting("DebugOutput", true); }
        }

        public static string DebugLogFile
        {
            get { return Config.GetSetting("DebugLogFile", null); }
        }

        public static bool TranslationMode
        {
            get { return Config.GetBoolSetting("TranslationMode"); }
        }

        public static bool ShowCBT
        {
            get { return Config.GetBoolSetting("ShowCBT"); }
        }

        public static int DebugDetailLevel
        {
            get
            {
                int level;
                if (Int32.TryParse(Config.GetSetting("DebugDetailLevel", "0"), out level))
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
            get { return Config.GetBoolSetting("UseDefaultLogin"); }
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
            get { return Config.GetSetting("SQLDatabase", "eidss"); }
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

        public static int WebBarcodePageWidth
        {
            get { return Config.GetIntSetting("WebBarcodePageWidth", 150); }
        }

        public static int WebBarcodePageHeight
        {
            get { return Config.GetIntSetting("WebBarcodePageHeight", 50); }
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

        public static string SystemFontName
        {
            get
            {
                if (Utils.Str(m_SystemFontName) == "")
                {
                    m_SystemFontName = Config.GetSetting("SystemFontName", FontFamily.GenericSansSerif.Name);
                }
                return m_SystemFontName;
            }
        }

        public static string GGSystemFontName
        {
            get
            {
                if (Utils.Str(m_GGSystemFontName) == "")
                {
                    m_GGSystemFontName = Config.GetSetting("GeorgianSystemFontName", "Sylfaen");
                }
                return m_GGSystemFontName;
            }
        }

        public static float SystemFontSize
        {
            get
            {
                if (m_SystemFontSize < 1)
                {
                    string fontSizeStr = Config.GetSetting("SystemFontSize", null);
                    if (fontSizeStr != null)
                    {
                        Single.TryParse(fontSizeStr, out m_SystemFontSize);
                    }
                }
                if (m_SystemFontSize < 1)
                {
                    m_SystemFontSize = (float) (8.25);
                }
                return m_SystemFontSize;
            }
        }

        public static float GGSystemFontSize
        {
            get
            {
                if (m_GGSystemFontSize < 1)
                {
                    string fontSizeStr = Config.GetSetting("GeorgianSystemFontSize", null);
                    if (fontSizeStr != null)
                    {
                        Single.TryParse(fontSizeStr, out m_GGSystemFontSize);
                    }
                }
                if (m_GGSystemFontSize < 1)
                {
                    m_GGSystemFontSize = (float) (8.25);
                }
                return m_GGSystemFontSize;
            }
        }

        public static string THReportsFontName
        {
            get
            {
                if (Utils.Str(m_THReportsFontName) == "")
                {
                    m_THReportsFontName = Config.GetSetting("ThaiReportsFontName");
                }
                if (Utils.Str(m_THReportsFontName) == "")
                {
                    m_THReportsFontName = THSystemFontName;
                }
                return m_THReportsFontName;
            }
        }

        public static float THReportsDeltaFontSize
        {
            get
            {
                if (m_THReportsDeltaFontSize < 0)
                {
                    string fontSizeStr = Config.GetSetting("ThaiReportsDeltaFontSize", null);
                    if (fontSizeStr != null)
                    {
                        Single.TryParse(fontSizeStr, out m_THReportsDeltaFontSize);
                    }
                }
                if (m_THReportsDeltaFontSize < 0)
                {
                    m_THReportsDeltaFontSize = 2;
                }
                return m_THReportsDeltaFontSize;
            }
        }

        public static string THSystemFontName
        {
            get
            {
                if (Utils.Str(m_THSystemFontName) == "")
                {
                    m_THSystemFontName = Config.GetSetting("ThaiSystemFontName");
                }
                if (Utils.Str(m_THSystemFontName) == "")
                {
                    m_THSystemFontName = SystemFontName;
                }
                return m_THSystemFontName;
            }
        }

        public static float THSystemFontSize
        {
            get
            {
                if (m_THSystemFontSize < 1)
                {
                    string fontSizeStr = Config.GetSetting("ThaiSystemFontSize", null);
                    if (fontSizeStr != null)
                    {
                        Single.TryParse(fontSizeStr, out m_THSystemFontSize);
                    }
                }
                if (m_THSystemFontSize < 1)
                {
                    m_THSystemFontSize = (float) (8.25);
                }
                return m_THSystemFontSize;
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

     
        public static bool ShowBigLayoutWarning
        {
            get { return Config.GetBoolSetting("ShowBigLayoutWarning"); }
        }

        public static int AvrWarningMemoryLimit
        {
            get { return Config.GetIntSetting("AvrWarningMemoryLimit", 2048); }
        }

        public static int AvrErrorMemoryLimit
        {
            get { return Math.Max(AvrWarningMemoryLimit, Config.GetIntSetting("AvrErrorMemoryLimit", 4096)); }
        }

        public static int AvrWarningCellCountLimit
        {
            get { return Config.GetIntSetting("AvrWarningCellCountLimit", 1000000); }
        }

        public static int AvrErrorCellCountLimit
        {
            get { return Config.GetIntSetting("AvrErrorCellCountLimit", 2000000); }
        }

        public static int AvrWarningLayoutComplexity
        {
            get { return Config.GetIntSetting("AvrWarningLayoutComplexity", 60); }
        }
        public static int AvrErrorLayoutComplexity
        {
            get { return Config.GetIntSetting("AvrErrorLayoutComplexity", 180); }
        }

        public static string AvrExportUtilX86
        {
            get { return Config.GetSetting("AvrExportUtilX86", "eidss.avr.export.x86.exe"); }
        }

        public static string AvrExportUtilX64
        {
            get { return Config.GetSetting("AvrExportUtilX64", "eidss.avr.export.x64.exe"); }
        }

        public static string AvrServiceHostURL
        {
            get { return Config.GetSetting("AVRServiceHostURL", "http://localhost:8071/"); }
        }
        public static string ReportServiceHostURL
        {
            get { return Config.GetSetting("ReportServiceHostURL", "http://localhost:8097/"); }
        }

        public static int AvrRowsPerPage
        {
            get { return Config.GetIntSetting("AvrRowsPerPage", 20); }
        }

        public static bool ThrowExceptionOnError
        {
            get
            {
                bool fromUnitTest = Utils.IsCalledFromUnitTest();
                return Config.GetBoolSetting("ThrowExceptionOnError", fromUnitTest);
            }
        }

        public static bool PrintMapInVetReports
        {
            get { return Config.GetBoolSetting("PrintMapInVetReports", true); }
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
            get { return Config.GetSetting("SkinName", "eidss money twins"); }
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
            get { return Config.GetBoolSetting("LabSimplifiedMode"); }
        }

        public static string EpiInfoPath
        {
            get { return Config.GetSetting("EpiInfoPath"); }
        }

        public static int CheckNotificationSeconds
        {
            get { return Config.GetIntSetting("CheckNotificationSeconds", 10); }
        }

        public static int AutoHideNotificationSeconds
        {
            get { return Config.GetIntSetting("AutoHideNotificationSeconds", 1200); }
        }

        public static int SelectTopMaxCount
        {
            get { return Config.GetIntSetting("SelectTopMaxCount", 10000); }
        }

        public static int DefaultDateFilter
        {
            get { return Config.GetIntSetting("DefaultDateFilter", 14); }
        }

        public static bool ScanFormsMode
        {
            get { return Config.GetBoolSetting("ScanFormsMode"); }
        }

        public static bool UpdateConnectionInfo
        {
            get { return Config.GetBoolSetting("UpdateConnectionInfo", true); }
        }

        public static bool PlaySoundForAlerts
        {
            get { return Config.GetBoolSetting("PlaySoundForAlerts"); }
        }

        public static bool DefaultRegionInSearch
        {
            get { return Config.GetBoolSetting("DefaultRegionInSearch", true); }
        }

        public static bool RecalcFiltration
        {
            get { return Config.GetBoolSetting("RecalcFiltration"); }
        }

        public static string DefaultMapProject
        {
            get { return Config.GetSetting("DefaultMapProject"); }
        }

        public static int TicketExpiration
        {
            get { return Config.GetIntSetting("TicketExpiration", 30); }
        }

        public static int EventLogListenInterval
        {
            get { return Config.GetIntSetting("EventLogListenInterval", 500); }
        }

        public static int DelayedReplicationPeriod
        {
            get { return Config.GetIntSetting("DelayedReplicationPeriod", 60000); }
        }

        public static bool UseOrganizationInLogin
        {
            get { return Config.GetBoolSetting("UseOrganizationInLogin"); }
        }

        public static int LabSectionPageSize
        {
            get
            {
                int ret = Config.GetIntSetting("LabSectionPageSize", 50);
                if (ret > 200)
                {
                    ret = 200;
                }
                return ret;
            }
        }

        public static int ListGridPageSize
        {
            get { return Config.GetIntSetting("ListGridPageSize", 50); }
        }

        public static int PopupGridPageSize
        {
            get { return Config.GetIntSetting("PopupGridPageSize", 50); }
        }

        public static int DetailGridPageSize
        {
            get { return Config.GetIntSetting("DetailGridPageSize", 10); }
        }

        public static bool CollectUsedXtraResources
        {
            get { return Config.GetBoolSetting("CollectUsedXtraResources"); }
        }

        public static bool ShowAllLoginTabs
        {
            get { return Config.GetBoolSetting("ShowAllLoginTabs"); }
        }

        public static bool ForceLeftToRight
        {
            get { return Config.GetBoolSetting("ForceLeftToRight"); }
        }

        public static bool ForceRightToLeft
        {
            get { return Config.GetBoolSetting("ForceRightToLeft"); }
        }

        public static string ErrorLogPath
        {
            get { return Config.GetSetting("ErrorLogPath", "ErrorLog"); }
        }

        public static bool DoNotShowSplash
        {
            get { return Config.GetBoolSetting("DoNotShowSplash"); }
        }

        public static int DeadlockDelay
        {
            get { return Config.GetIntSetting("DeadlockDelay ", 2000); }
        }

        public static int DeadlockAttemptsCount
        {
            get { return Config.GetIntSetting("DeadlockAttemptsCount", 2); }
        }

        public static bool ValidateObject
        {
            get { return Config.GetBoolSetting("ValidateObject"); }
        }

        public static bool UseDebugTimer
        {
            get { return Config.GetBoolSetting("UseDebugTimer"); }
        }

        public static bool SuppressGettingModifiedLookupTables
        {
            get { return Config.GetBoolSetting("SuppressGettingModifiedLookupTables"); }
        }

        public static bool SearchDuplicatesAutomatically
        {
            get { return Config.GetBoolSetting("SearchDuplicatesAutomatically", true); }
        }
        public static bool LanguageMenuWithoutFlags
        {
            get { return Config.GetBoolSetting("LangMenuWithoutFlags", true); }
        }
        public static bool ShowWarningForFinalCaseClassification 
        {
            get { return Config.GetBoolSetting(SettingName.ShowWarningForFinalCaseClassification, false); }
        }
        public static bool FilterSamplesByDiagnosis  
        {
            get { return Config.GetBoolSetting(SettingName.FilterSamplesByDiagnosis); }
        }

        public static int WebAvrDataLifeTime
        {
            get { return Config.GetIntSetting(SettingName.WebAvrDataLifeTime, 3); }
        }
        public static int WebAvrDataCheckInterval
        {
            get { return Config.GetIntSetting(SettingName.WebAvrDataCheckInterval, 5); }
        }
    }
}