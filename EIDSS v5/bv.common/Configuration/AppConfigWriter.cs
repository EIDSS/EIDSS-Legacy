using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.IO;


[assembly: InternalsVisibleTo("bv.tests")]
namespace bv.common.Configuration
{
    public class AppConfigWriter
    {
        private static List<string> m_Keys = new List<string>(new string[] {
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
                                             "EpiInfoPath"
                                         });
        internal static string m_TestAppConfigName = null;
        private static string m_AppConfigName = null;
        public static string DefaultConfigName { get; set;}
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
                            if (String.IsNullOrEmpty(DefaultConfigName))
                                m_AppConfigName = dir.FullName + " \\" + Config.AppConfigFileName;
                            else
                                m_AppConfigName = dir.FullName + " \\" + DefaultConfigName;
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
