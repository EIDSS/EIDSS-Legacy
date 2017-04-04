using System;

namespace eidss.model.Avr.Chart
{
    [Serializable]
    public class SeriesProperties
    {
        public BarProperties Bar { get; set; }
        public StackedBarProperties StackedBar { get; set; }
        public FullStackedBarProperties FullStackedBar { get; set; }
        public PointProperties Point { get; set; }
        public LineProperties Line { get; set; }
        public SplineProperties Spline { get; set; }
        public StepLineProperties StepLine { get; set; }
        public AreaProperties Area { get; set; }
        public PieProperties Pie { get; set; }

        /// <summary>
        /// Место серии в коллекции серий
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Тип графика
        /// </summary>
        public int ViewType { get; set; }

        /// <summary>
        /// Индекс оси Y, которую использует данная серия
        /// </summary>
        public int AxisYIndex { get; set; }



        public SeriesProperties()
        {
            AxisYIndex = 0; //Primary Axis Y
            ViewType = 11;
            SeriesLabelsVisibility = true;

            Bar = new BarProperties();
            StackedBar = new StackedBarProperties();
            FullStackedBar = new FullStackedBarProperties();
            Point = new PointProperties();
            Line = new LineProperties();
            Spline = new SplineProperties();
            StepLine = new StepLineProperties();
            Area = new AreaProperties();
            Pie = new PieProperties();
            SetParentSeries();
        }

        public void SetParentSeries()
        {
            Bar.ParentSeries = StackedBar.ParentSeries = FullStackedBar.ParentSeries = Point.ParentSeries = Line.ParentSeries
                = Spline.ParentSeries = StepLine.ParentSeries = Area.ParentSeries = Pie.ParentSeries = this;
        }

        public void SetColors(int color)
        {
            Bar.ColorArgb = color;
            StackedBar.ColorArgb = color;
            FullStackedBar.ColorArgb = color;
            Point.ColorArgb = color;
            Line.ColorArgb = color;
            Spline.ColorArgb = color;
            StepLine.ColorArgb = color;
            Area.ColorArgb = color;
        }

        public bool SeriesLabelsVisibility { get; set; }
    }
}
