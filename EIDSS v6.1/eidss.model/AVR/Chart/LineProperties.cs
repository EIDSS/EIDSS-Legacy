using System;
using System.Drawing;
using System.Xml.Serialization;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class LineProperties : ILineProperties, IParentSeries
    {
        [XmlIgnore]
        public Color Color { get { return Color.FromArgb(ColorArgb); } }
        public int ColorArgb { get; set; }
        public int LineStyle { get; set; }
        public int LineStyleWidth { get; set; }
        public bool ShadowVisible { get; set; }

        public LineProperties()
        {
            LineStyle = 0; //Solid
            LineStyleWidth = 1;
            ShadowVisible = false;
            ColorArgb = Color.Blue.ToArgb();
        }

        [XmlIgnore]
        public SeriesProperties ParentSeries { get; set; }

        public void CopyFrom(ILineProperties line)
        {
            LineStyle = line.LineStyle;
            LineStyleWidth = line.LineStyleWidth;
            ShadowVisible = line.ShadowVisible;
        }
    }
}
