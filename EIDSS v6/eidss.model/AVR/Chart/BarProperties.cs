using System;
using System.Drawing;
using System.Xml.Serialization;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class BarProperties : IBarProperties, IParentSeries
    {
        public double BarWidth { get; set; }
        [XmlIgnore]
        public Color Color { get { return Color.FromArgb(ColorArgb); } }
        public int ColorArgb { get; set; }
        public int FillMode { get; set; }

        public BarProperties()
        {
            BarWidth = 0.75;
            FillMode = 1; //Solid
            ColorArgb = Color.Blue.ToArgb();
        }
        [XmlIgnore]
        public SeriesProperties ParentSeries { get; set; }
    }
}
