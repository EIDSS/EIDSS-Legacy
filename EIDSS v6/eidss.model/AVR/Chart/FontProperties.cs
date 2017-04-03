using System;
using System.Drawing;
using System.Xml.Serialization;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class FontProperties
    {
        public string FontName { get; set; }
        public int FontSize { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public bool IsUnderline { get; set; }
        [XmlIgnore]
        public Color TextColor {get { return Color.FromArgb(TextColorArgb); }}
        public int TextColorArgb{ get; set; }

        public FontProperties()
        {
            FontName = "Tahoma";
            FontSize = 8;
            IsBold = IsItalic = IsUnderline = false;
            TextColorArgb = Color.Black.ToArgb();
        }

        public Font ToFont()
        {
            var fontFamily = new FontFamily(FontName);
            var fs = FontStyle.Regular;
            if (IsBold) fs = fs | FontStyle.Bold;
            if (IsItalic) fs = fs | FontStyle.Italic;
            if (IsUnderline) fs = fs | FontStyle.Underline;

            var font = new Font(fontFamily, FontSize, fs);
            return font;
        }

        public void FromFont(Font font, Color color)
        {
            FontName = font.Name;
            FontSize = Convert.ToInt32(font.Size);
            IsBold = font.Bold;
            IsItalic = font.Italic;
            IsUnderline = font.Underline;
            TextColorArgb = color.ToArgb();
        }
    }
}
