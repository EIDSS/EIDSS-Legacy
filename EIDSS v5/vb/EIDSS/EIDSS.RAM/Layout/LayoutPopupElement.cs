using bv.common.Core;

namespace EIDSS.RAM.Layout
{
    public class LayoutPopupElement
    {
        private readonly long m_ID;
        private readonly string m_Name;

        public LayoutPopupElement(long id, string name)
        {
            Utils.CheckNotNull(name, "name");
            m_ID = id;
            m_Name = name;
        }

        public long ID
        {
            get { return m_ID; }
        }

        public string Name
        {
            get { return m_Name; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}