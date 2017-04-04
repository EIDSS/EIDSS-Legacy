namespace bv.common.Resources
{
    public class XtraStrings : BaseStringsStorage
    {
        private static volatile XtraStrings m_Instance;
        private static readonly object m_SyncRoot = new object();

        private XtraStrings()
        {
        }

        public static XtraStrings Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_SyncRoot)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new XtraStrings();
                        }
                    }
                }

                return m_Instance;
            }
        }

        public static string Get(string stringName, string stringValue, string cultureName = null)
        {
            string result = Instance.GetString(stringName.Trim(), stringValue, cultureName);
            return result;
        }
    }
}