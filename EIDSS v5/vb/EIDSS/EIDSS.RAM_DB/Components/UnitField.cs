namespace EIDSS.RAM_DB.Components
{
    public class UnitField
    {
        private readonly string m_UnitFieldName;
        private readonly string m_DateFieldName;

        public UnitField(string unitFieldName, string dateFieldName)
        {
            m_UnitFieldName = unitFieldName;
            m_DateFieldName = dateFieldName;
        }

        public string UnitFieldName
        {
            get { return m_UnitFieldName; }
        }

        public string DateFieldName
        {
            get { return m_DateFieldName; }
        }
    }
}