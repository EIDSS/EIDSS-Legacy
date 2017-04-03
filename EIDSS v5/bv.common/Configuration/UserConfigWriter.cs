using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("bv.tests")]

namespace bv.common.Configuration
{
    public class UserConfigWriter
    {
        private static readonly List<string> m_Keys = new List<string>(new[]
                                                                           {
                                                                               "SaveOnCancel",
                                                                               "DefaultLanguage",
                                                                               "ShowCaptionOnToolbar",
                                                                               "ShowEmptyListOnSearch",
                                                                               "ShowSaveDataPrompt",
                                                                               "Organization",
                                                                               "ClientID",
                                                                               "PromtReasonForChange",
                                                                               "DefaultDateFilter",
                                                                               "AsSessionTableView",
                                                                               "ShowNavigatorInH02Form",
                                                                               "ShowBigLayoutWarning",
                                                                               "ShowAvrAsterisk",
                                                                               "LabSimplifiedMode",
                                                                               "CollapseFilterPanel"
                                                                           });

        internal static string m_TestUserConfigName;
        private static string m_UserConfigName;

        private static string UserConfigFileName
        {
            get
            {
                lock (m_Lock)
                {
                    if (m_TestUserConfigName == null)
                    {
                        lock (m_Lock)
                        {
                            if (m_UserConfigName == null)
                            {
                                DirectoryInfo dir = Directory.GetParent(Application.LocalUserAppDataPath);
                                m_UserConfigName = dir.FullName + " \\" + Config.AppConfigFileName;
                            }
                            return m_UserConfigName;
                        }
                    }
                    return m_TestUserConfigName;
                }
            }
        }

        private static ConfigWriter m_Instance;
        private static readonly object m_Lock = new object();

        public static ConfigWriter Instance
        {
            get
            {
                lock (m_Lock)
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
            return new ConfigWriter(m_Keys, UserConfigFileName);
        }
    }
}