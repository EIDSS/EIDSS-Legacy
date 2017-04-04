using System;
using DevExpress.XtraCharts;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class XAxisSettings : BaseChartSettings
    {
        public XAxisSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public XAxisSettings()
        {
            InitializeComponent();
        }

        public override void Init(object properties)
        {
            generalSettings.CurrentAxis = ChartPlaceHolder.AxisX;
            generalSettings.ChartDetailPanel = ChartDetailPanel;
            var props = (XAxisProperties) properties;
            generalSettings.Init(props.AxisProperties);
            //Mike: commented to avoid 'obsolete' warning
            //generalSettings.CurrentAxis.Range.MinValueInternal = -props.LeftIndent;
            SetMinValueRange(generalSettings.CurrentAxis, -props.LeftIndent);
            FromProperties(properties);
        }

        public override object ToProperties()
        {
            var p = new XAxisProperties
                {
                    AxisProperties = (AxisProperties) generalSettings.ToProperties(),
                    LeftIndent = Convert.ToInt32(seLeftIndent.Value)
                };
            return p;
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);
            var p = (XAxisProperties) props;
            generalSettings.FromProperties(p.AxisProperties);
            seLeftIndent.EditValueChanged -= seLeftIndent_EditValueChanged;
            seLeftIndent.Value = p.LeftIndent;
            seLeftIndent.EditValueChanged += seLeftIndent_EditValueChanged;
        }

        public static void SetupChart(AxisX axisX, object props)
        {
            var p = (XAxisProperties)props;
            AxisSettings.SetupChart(axisX, p.AxisProperties);
            //axisX.VisualRange.MinValueInternal = -p.LeftIndent;
            axisX.VisualRange.AutoSideMargins = true;
        }

        private void seLeftIndent_EditValueChanged(object sender, EventArgs e)
        {
            var val = (int)seLeftIndent.Value;
            if (val < 0) val = 0;
            else val = -val;
            seLeftIndent.Value = -val;
            //должны быть отрицательные значения, чтобы правильно отображалось

            //Mike:commented to avoid 'obsolete' warning
            //generalSettings.CurrentAxis.Range.MinValueInternal = val == 0 ? -0.5 : val;
            SetMinValueRange(generalSettings.CurrentAxis, val == 0 ? -0.5 : val);
        }

        private void SetMinValueRange(Axis2D axis, double value)
        {
            var axisMaxValue = axis.VisualRange.MaxValueInternal -
                              axis.VisualRange.SideMarginsValue;
            var lastValue = axis.GetScaleValueFromInternal(axisMaxValue);
            var minValue = axis.GetScaleValueFromInternal(value);
            axis.VisualRange.SetMinMaxValues(minValue, lastValue);
            
        }
    }
}
