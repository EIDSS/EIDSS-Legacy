using eidss.model.Helpers;

namespace eidss.model.Avr.Chart
{
    public class AvrChartPropertiesSerializer
    {
        private static readonly EidssSerializer<AvrChartProperties> m_Singletone = new EidssSerializer<AvrChartProperties>();

        public static string Serialize(AvrChartProperties properties)
        {
            return m_Singletone.Serialize(properties);
        }

        public static AvrChartProperties Deserialize(string xml)
        {
            return m_Singletone.Deserialize(xml);
        }
    }
}