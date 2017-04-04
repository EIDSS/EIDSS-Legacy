using System;
using System.Drawing;
using System.Xml.Serialization;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class PointProperties: IParentSeries
    {
        [XmlIgnore]
        public Color Color { get; set; }
        public int ColorArgb
        {
            get { return Color.ToArgb(); }
            set { Color = Color.FromArgb(value); }
        }

        public int PointMarkerOptionsKind { get; set; }

        public PointProperties()
        {
            PointMarkerOptionsKind = 5; //Circle
        }

        [XmlIgnore]
        public SeriesProperties ParentSeries { get; set; }

        public void CopyFrom(PointProperties point)
        {
            PointMarkerOptionsKind = point.PointMarkerOptionsKind;
        }
    }
}
