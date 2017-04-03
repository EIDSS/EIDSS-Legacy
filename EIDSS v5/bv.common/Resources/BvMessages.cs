
namespace bv.common.Resources
{
    public class BvMessages : BaseStringsStorage
    {

        private volatile static BvMessages m_Instance;
        private static readonly object m_SyncRoot = new object();
        private BvMessages() { }
        public static BvMessages Instance
        {
            get
            {
                if (m_Instance == null) 
                {
                    lock (m_SyncRoot)
                    {
                        if (m_Instance == null)
                            m_Instance = new BvMessages();
                    }
                }

                return m_Instance;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Shared method that returns translated string using Resourses\Messages.resx file as translation source
        /// </summary>
        /// <param name="stringName">
        /// the resource string key name
        /// </param>
        /// <param name="stringValue">
        /// the resource string default value, if it is not passed <i>stringName</i> is used as <i>stringValue</i>.
        /// </param>
        /// <param name="cultureName">
        /// the culture ID (defined by ClobalSettings.lngXXX properties) that defines target translation language.
        /// </param>
        /// <returns>
        /// Returns the translated string if the <i>stringName</i> is found in localized resource file or default <i>stringValue</i> in other case.
        /// </returns>
        /// <history>
        /// 	[Mike]	03.04.2006	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string Get(string stringName, string stringValue = null, string cultureName = null)
        {
            return Instance.GetString(stringName.Trim(), stringValue, cultureName);
        }
    }

}