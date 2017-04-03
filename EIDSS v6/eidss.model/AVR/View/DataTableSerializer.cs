using System.Data;
using eidss.model.Helpers;

namespace eidss.model.Avr.View
{
    public class DataTableSerializer
    {
        private static readonly EidssSerializer<DataTable> m_Singletone = new EidssSerializer<DataTable>();

        public static string Serialize(DataTable data)
        {
            return m_Singletone.Serialize(data);
        }

        public static DataTable Deserialize(string xml)
        {
            return m_Singletone.Deserialize(xml);
        }
    }
}