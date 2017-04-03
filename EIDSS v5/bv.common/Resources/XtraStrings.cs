using System.Reflection;
using System.Resources;
using bv.common.Core;

namespace bv.common.Resources
{
    public class XtraStrings : BaseStringsStorage
    {
        private volatile static XtraStrings m_Instance;
        private static object syncRoot = new object();
        private XtraStrings() { }
        public static XtraStrings Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (m_Instance == null)
                            m_Instance = new XtraStrings();
                    }
                }

                return m_Instance;
            }
        }
        public static string Get(string stringName, string stringValue, string CultureName = null)
        {
            return Instance.GetString(stringName.Trim(), stringValue, CultureName);
        }
    }
}