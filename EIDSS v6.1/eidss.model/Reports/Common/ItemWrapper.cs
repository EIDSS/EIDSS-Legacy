using bv.common.Core;

namespace eidss.model.Reports.Common
{
    public class ItemWrapper
    {
        private readonly string m_NativeName;
        private readonly int m_Number;

        public ItemWrapper(string nativeName, int number)
        {
            Utils.CheckNotNullOrEmpty(nativeName, "nativeName");
            m_NativeName = nativeName;
            m_Number = number;
        }

        public string NativeName
        {
            get { return m_NativeName; }
        }

        public int Number
        {
            get { return m_Number; }
        }

        public override string ToString()
        {
            return NativeName;
        }

    }
}