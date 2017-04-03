using bv.common.Resources;
using bv.common.Core;


namespace eidss.model.Resources
{
    public class EidssMenu : BaseStringsStorage
    {
        private volatile static EidssMenu m_Instance;
        private static object syncRoot = new object();
        private EidssMenu() { }
        public override string ResourcePath
        {
            get { return m_ResFileName ?? (m_ResFileName = Utils.GetSolutionPath() + "eidss.model\\resources\\" + GetType().Name + ".resx"); }
        }

        public static EidssMenu Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (m_Instance == null)
                            m_Instance = new EidssMenu();
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
