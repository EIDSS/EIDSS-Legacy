using System;
using System.Collections.Generic;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class AvrChartProperties
    {
        public AvrChartProperties()
        {
            Title = new TitleProperties();
            XAxis = new XAxisProperties();
            YAxes = new List<YAxisProperties>();
            Series = new List<SeriesProperties>();
            LegendVisibility = true;
            SeriesLabelsVisibility = true;
        }
        
        public TitleProperties Title { get; set; }
        public XAxisProperties XAxis { get; set; }
        public List<YAxisProperties> YAxes { get; set; }
        public bool LegendVisibility { get; set; }
        public bool SeriesLabelsVisibility { get; set; }
        public List<SeriesProperties> Series { get; set; }

    }
}