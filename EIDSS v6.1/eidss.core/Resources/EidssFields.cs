using bv.common.Resources;

namespace eidss.model.Resources
{
    public class EidssFields : BaseStringsStorage
    {
        private volatile static EidssFields m_Instance;
        private static readonly object m_SyncRoot = new object();
        private EidssFields() { }

        public override string ResourcePath
        {
            get { return GetResourcePath("eidss.core\\resources\\"); }
        }

        public static EidssFields Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_SyncRoot)
                    {
                        if (m_Instance == null)
                            m_Instance = new EidssFields();
                    }
                }

                return m_Instance;
            }
        }

        public override string GetString(string stringName, string stringValue = null, string langId = null, string parentViewName = null)
        {
            var value = base.GetString(stringName, stringValue, langId, parentViewName);
            if (IsValueExists)
                return value;
            var s = stringName.Split('.');
            if (s.Length > 1)
            {
                var value1 = base.GetString(s[s.Length - 1].Trim(), stringValue, langId, parentViewName);
                if (Instance.IsValueExists)
                    return value1;
            }
            return value;
        }
        public static string Get(string stringName, string stringValue = null, string cultureName = null)
        {
            return Instance.GetString(stringName.Trim(), stringValue, cultureName);
        }

    }
}
