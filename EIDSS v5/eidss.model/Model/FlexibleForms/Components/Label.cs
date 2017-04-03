namespace eidss.model.Schema
{
    public partial class Label
    {
        public int Width { get { return intWidth.HasValue ? intWidth.Value : 50; } }

        public int Height { get { return intHeight.HasValue ? intHeight.Value : 50; } }

        public int FontStyle { get { return intFontStyle.HasValue ? intFontStyle.Value : (int)System.Drawing.FontStyle.Regular; } }

        public int FontSize { get { return intFontSize.HasValue ? intFontSize.Value : 10; } }

        public int Color { get { return intColor.HasValue ? intColor.Value : 0; } } // System.Drawing.Color.Black.ToArgb(); } }
    }
}
