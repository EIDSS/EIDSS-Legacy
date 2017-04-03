using System;
using DevExpress.XtraCharts;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class BarChartSettings : BaseSeriesSettings
    {
        public BarSeriesView BarSeries { get; set; }

        public BarChartSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return gcSettings.Text; }
            set { gcSettings.Text = value; }
        }

        public override void Init(object properties)
        {
            CurrentAxisY = BarSeries.AxisY;
            base.Init(properties);
            ChartSettingsHelper.SetFillModeList(cbFillMode);
            FromProperties(properties);
        }

        public override object ToProperties()
        {
            var p = (IBarProperties)base.ToProperties();
            p.BarWidth = Convert.ToDouble(seBarWidth.Value);
            p.ColorArgb = ceColor.Color.ToArgb();
            p.FillMode = cbFillMode.SelectedIndex;
            return p;
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);
            var p = (IBarProperties) props;
            seBarWidth.Value = Convert.ToDecimal(p.BarWidth);
            ceColor.Color = p.Color;
            cbFillMode.SelectedIndex = p.FillMode;
        }

        public static void SetupChart(BarSeriesView barSeries, object props)
        {
            var p = (IBarProperties)props;
            barSeries.BarWidth = p.BarWidth;
            barSeries.Color = p.Color;
            barSeries.FillStyle.FillMode = ChartSettingsHelper.GetFillMode(p.FillMode);
        }

        private void seBarWidth_EditValueChanged(object sender, EventArgs e)
        {
            var d = Convert.ToDouble(seBarWidth.Value);
            if (d <= 0) d = 0.25;
            BarSeries.BarWidth = d;
        }

        private void ceColor_EditValueChanged(object sender, EventArgs e)
        {
            BarSeries.Color = ceColor.Color;
        }

        private void cbFillMode_EditValueChanged(object sender, EventArgs e)
        {
            if (BarSeries.FillStyle == null) return;
            BarSeries.FillStyle.FillMode = ChartSettingsHelper.GetFillMode(cbFillMode.SelectedIndex);
        }
    }
}
