using System;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class XAxisProperties
    {
        public AxisProperties AxisProperties { get; set; }
        
        public int LeftIndent { get; set; }

        public XAxisProperties()
        {
            AxisProperties = new AxisProperties();

            LeftIndent = 0;
        }
    }
}
