using System;
using System.Drawing;
using System.Xml.Serialization;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class AxisProperties
    {
        [XmlIgnore]
        public Color LineColor { get; set; }
        public int LineColorArgb
        {
            get { return LineColor.ToArgb(); }
            set { LineColor = Color.FromArgb(value); }
        }
        public int LineWidth { get; set; }
        [XmlIgnore]
        public Color GridLinesColor { get; set; }
        public int GridLinesColorArgb
        {
            get { return GridLinesColor.ToArgb(); }
            set { GridLinesColor = Color.FromArgb(value); }
        }
        public int GridLinesStyle { get; set; }
        public bool GridLinesVisibility { get; set; }
        public int ValueLabelAngle { get; set; }
        public FontProperties ValueLabelFont { get; set; }
        public bool ValueLabelStaggeredStyle { get; set; }

        public TitleProperties Title { get; set; }

        public int TickmarkMinorCount { get; set; }
        public bool RangeReverse { get; set; }
        
        public AxisProperties()
        {
            Title = new TitleProperties();

            LineColor = Color.Gray;
            LineWidth = 2;
            GridLinesColor = Color.Gray;
            GridLinesStyle = 0; //Solid
            GridLinesVisibility = false;
            ValueLabelAngle = 20;
            ValueLabelFont = new FontProperties();
            ValueLabelStaggeredStyle = false;

            TickmarkMinorCount = 5;
            RangeReverse = false;
            //TODO Range Max  Range Min
        }
    }
}
