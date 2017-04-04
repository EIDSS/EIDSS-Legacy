using System;

namespace eidss.avr.ChartForm
{
    interface ISettingsPanel
    {
        void Init(object properties);
        object ToProperties();
        void FromProperties(object props);
        Type PropertiesType { get; set; }
        int Index { get; set; }
    }
}
