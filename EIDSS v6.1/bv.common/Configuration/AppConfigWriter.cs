using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("bv.tests")]

namespace bv.common.Configuration
{
    public class AppConfigWriter
    {
        private static readonly List<string> m_Keys = new List<string>(new[]
        {
            "SQLDatabase",
            "SQLServer",
            "SQLUser",
            "SQLPassword",
            "ArchiveDatabase",
            "ArchiveServer",
            "ArchiveUser",
            "ArchivePassword",
            "DocumentPrinter",
            "BarcodePrinter",
            "EpiInfoPath",
            "AVRServiceHostURL",
            "ReportServiceHostURL",
            "DefaultMapProject",
            "AvrMemoryEconomyMode",
            SettingName.ShowWarningForFinalCaseClassification,
            SettingName.FilterSamplesByDiagnosis 
        });

        internal static string m_TestAppConfigName = null;
        private static string m_AppConfigName;

        private static string AppConfigFileName
        {
            get
            {
                lock (m_lock)
                {
                    if (m_TestAppConfigName == null)
                    {
                        if (m_AppConfigName == null)
                        {
                            DirectoryInfo dir = Directory.GetParent(Application.CommonAppDataPath);
                            m_AppConfigName = dir.FullName + " \\" + Config.DefaultGlobalConfigFileName;
                        }
                        return m_AppConfigName;
                    }
                    return m_TestAppConfigName;
                }
            }
        }

        private static ConfigWriter m_Instance;
        private static object m_lock = new object();

        public static ConfigWriter Instance
        {
            get
            {
                lock (m_lock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = CreateConfigWriter();
                        m_Instance.Read(null);
                    }
                }

                return m_Instance;
            }
        }

        public static ConfigWriter CreateConfigWriter()
        {
            return new ConfigWriter(m_Keys, AppConfigFileName);
        }
    }
}