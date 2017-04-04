namespace eidss.model.Schema
{
    public partial class Label
    {
        public int Width { get { return intWidth ?? 50; } }

        public int Height { get { return intHeight ?? 50; } }

        public int FontStyle { get { return intFontStyle ?? (int)System.Drawing.FontStyle.Regular; } }

        public int FontSize { get { return intFontSize ?? 10; } }

        public int Color { get { return intColor ?? 0; } } // System.Drawing.Color.Black.ToArgb(); } }

        public int TopAbsolute { get; set; }
    }
}
