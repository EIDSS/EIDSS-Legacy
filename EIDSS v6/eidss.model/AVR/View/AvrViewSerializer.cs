using eidss.model.Helpers;

namespace eidss.model.Avr.View
{
    public class AvrViewSerializer
    {
        private static readonly EidssSerializer<AvrView> m_Singletone = new EidssSerializer<AvrView>();

        public static string Serialize(AvrView view)
        {
            return m_Singletone.Serialize(view);
        }

        public static AvrView Deserialize(string xml)
        {
            return m_Singletone.Deserialize(xml);
        }
    }
}