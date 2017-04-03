using System;
using DevExpress.XtraCharts;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class YAxisSettings : BaseChartSettings
    {
        public YAxisSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        public override void Init(object properties)
        {
            ChartSettingsHelper.SetAlignmentList(cbPosition, false);
            if (Index == 0)
            {
                generalAxisSettings.CurrentAxis = ChartPlaceHolder.AxisY;
            }
            else
            {
                generalAxisSettings.CurrentAxis = ((XYDiagram)ChartPlaceHolder.ChartControl.Diagram).SecondaryAxesY[Index - 1];
            }
            generalAxisSettings.ChartDetailPanel = ChartDetailPanel;
            generalAxisSettings.Init(((YAxisProperties)properties).AxisProperties);
            FromProperties(properties);
        }

        public override object ToProperties()
        {
            var p = new YAxisProperties
                {
                    AxisProperties = (AxisProperties) generalAxisSettings.ToProperties(),
                    Position = cbPosition.SelectedIndex,
                    RangeMaxValue = Convert.ToInt32(seRangeMax.Value),
                    RangeMinValue = Convert.ToInt32(seRangeMin.Value),
                    AutoRange = cbAutoRange.Checked
                };
            return p;
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);
            var p = (YAxisProperties)props;
            generalAxisSettings.FromProperties(p.AxisProperties);
            cbPosition.SelectedIndex = p.Position;
            seRangeMax.Value = (decimal)p.RangeMaxValue;
            seRangeMin.Value = (decimal)p.RangeMinValue;
            if (cbAutoRange.Checked != p.AutoRange)
            {
                cbAutoRange.Checked = p.AutoRange;
            }
            else
            {
                cbAutoRange_CheckedChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chartDetailPanel"></param>
        /// <param name="axisY"></param>
        /// <param name="props"></param>
        public static void SetupChart(ChartDetailPanel chartDetailPanel, AxisYBase axisY, object props)
        {
            var p = (YAxisProperties) props;
            AxisSettings.SetupChart(axisY, p.AxisProperties);
            axisY.Alignment = ChartSettingsHelper.GetAxisAlignment(p.Position);
            if (p.AutoRange)
            {
                SetAutoRange(axisY);
            }
            else
            {
                var axisIndex = chartDetailPanel.GetAxisYIndex(axisY);
                //пересчёт диапазона
                ChartSettingsHelper.RecalculateRangeAxis(chartDetailPanel, axisIndex);
                var yAxis = chartDetailPanel.ChartProperties.YAxes[axisIndex];
                p.RangeMaxValue = yAxis.RangeMaxValue;
                p.RangeMinValue = yAxis.RangeMinValue;
                axisY.VisualRange.MaxValue = p.RangeMaxValue;
                axisY.VisualRange.MinValue = p.RangeMinValue;
            }
            /*
            axisY.Range.MaxValue = p.RangeMaxValue;
            axisY.Range.MinValue = p.RangeMinValue;
            axisY.Range.ScrollingRange.MaxValue = p.RangeMaxValue;
            axisY.Range.ScrollingRange.MinValue = p.RangeMinValue;
            */
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            var axis = generalAxisSettings.CurrentAxis;
            if (axis != null)
            {
                //right, left
                switch (cbPosition.SelectedIndex)
                {
                    case 0:
                        axis.Alignment = AxisAlignment.Near;
                        break;
                    case 1:
                        axis.Alignment = AxisAlignment.Far;
                        break;
                }
            }
        }

        private void seRangeMax_EditValueChanged(object sender, EventArgs e)
        {
            generalAxisSettings.CurrentAxis.VisualRange.MaxValue = Convert.ToInt32(seRangeMax.Value);
            generalAxisSettings.CurrentAxis.WholeRange.MaxValue = Convert.ToInt32(seRangeMax.Value);
        }

        private void seRangeMin_EditValueChanged(object sender, EventArgs e)
        {
            generalAxisSettings.CurrentAxis.VisualRange.MinValue = Convert.ToInt32(seRangeMin.Value);
            generalAxisSettings.CurrentAxis.WholeRange.MinValue = Convert.ToInt32(seRangeMin.Value);
        }

        private static void SetAutoRange(AxisBase axis)
        {
            var yaxisVr = axis.VisualRange;
            var yaxisWr = axis.WholeRange;
            yaxisVr.Auto = yaxisVr.AutoSideMargins = true;
            yaxisWr.AlwaysShowZeroLevel = true;
            yaxisWr.Auto = yaxisWr.AutoSideMargins = true;
        }

        private void cbAutoRange_CheckedChanged(object sender, EventArgs e)
        {
            var auto = cbAutoRange.Checked;
            seRangeMax.Enabled = seRangeMin.Enabled = !auto;
            var axisIndex = ChartDetailPanel.GetAxisYIndex(generalAxisSettings.CurrentAxis);
            var yAxis = ChartDetailPanel.ChartProperties.YAxes[axisIndex];
            yAxis.AutoRange = auto;
            if (auto)
            {
                SetAutoRange(generalAxisSettings.CurrentAxis);
                /*
                //пересчёт диапазона
                ChartSettingsHelper.RecalculateRangeAxis(ChartDetailPanel, axisIndex);
                var maxValue = (decimal)yAxis.RangeMaxValue;
                var minValue = (decimal)yAxis.RangeMinValue;
                range.MaxValue = maxValue;
                range.MinValue = minValue;
                range.ScrollingRange.MaxValue = maxValue;
                range.ScrollingRange.MinValue = minValue;
                seRangeMax.Value = maxValue;
                seRangeMin.Value = minValue;
                */
            }
            
        }
    }
}
