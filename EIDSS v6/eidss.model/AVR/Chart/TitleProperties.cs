using System;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class TitleProperties
    {
        public FontProperties Font { get; set; }

        private string m_Text;
        public string Text
        {
            get { return m_Text; }
            set
            {
                if (m_Text != value) TextWasChanged = true;
                m_Text = value;
            }
        }

        public bool TextWasChanged { get; set; }
        public bool Visibility { get; set; }
        public int Alignment { get; set; }

        public TitleProperties()
        {
            m_Text = String.Empty;
            Font = new FontProperties();
            Alignment = 1; //Center
            Visibility = true;
        }
    }
}
