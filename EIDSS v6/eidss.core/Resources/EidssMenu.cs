using bv.common.Resources;

namespace eidss.model.Resources
{
    public class EidssMenu : BaseStringsStorage
    {
        private volatile static EidssMenu m_Instance;
        private static readonly object m_SyncRoot = new object();
        private EidssMenu() { }

        public override string ResourcePath
        {
            get { return GetResourcePath("eidss.core\\resources\\"); }
        }

        public static EidssMenu Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_SyncRoot)
                    {
                        if (m_Instance == null)
                            m_Instance = new EidssMenu();
                    }
                }

                return m_Instance;
            }
        }

        public static string Get(string stringName, string stringValue, string cultureName = null)
        {
            return Instance.GetString(stringName.Trim(), stringValue, cultureName);
        }

    }

}
