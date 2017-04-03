namespace bv.winclient.Core
{
    public class LabelControlColumn
    {
        public delegate void PropertyChangedHandler();

        private int m_Left;
        private int m_LabelWidth;
        private int m_ControlWidth;

        public int Left { get { return m_Left; } set { m_Left = value; OnChanged(); } }
        public int LabelWidth { get { return m_LabelWidth; } set { m_LabelWidth = value; OnChanged(); } }
        public int ControlWidth { get { return m_ControlWidth; } set { m_ControlWidth = value; OnChanged(); } }
        
        public event PropertyChangedHandler Changed;
        private void OnChanged()
        {
            if (Changed != null)
                Changed();
        }

    }

}
