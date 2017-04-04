using System;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class YAxisProperties
    {
        public AxisProperties AxisProperties { get; set; }
        public int Position { get; set; }
        public double RangeMaxValue { get; set; }
        public double RangeMinValue { get; set; }
        public bool AutoRange { get; set; }

        public YAxisProperties()
        {
            AxisProperties = new AxisProperties();
            Position = 0;
            AutoRange = true;
        }
    }
}
