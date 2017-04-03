using System;
using DevExpress.XtraCharts;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class AreaChartSettings : BaseSeriesSettings
    {
        public AreaChartSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public AreaSeriesView AreaSeries { get; set; }

        public override void Init(object properties)
        {
            CurrentAxisY = AreaSeries.AxisY;
            base.Init(properties);
            ChartSettingsHelper.SetFillModeList(cbFillMode);
            FromProperties(properties);
        }

        public override object ToProperties()
        {
            var p = (AreaProperties)base.ToProperties();
            p.ColorArgb = ceColor.Color.ToArgb();
            p.FillMode = cbFillMode.SelectedIndex;
            return p;
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);
            var p = (AreaProperties) props;
            ceColor.Color = p.Color;
            cbFillMode.SelectedIndex = p.FillMode;
        }

        public static void SetupChart(AreaSeriesView areaSeries, object props)
        {
            var p = (AreaProperties) props;
            areaSeries.Color = p.Color;
            areaSeries.FillStyle.FillMode = ChartSettingsHelper.GetFillMode(p.FillMode);
        }

        private void ceColor_EditValueChanged(object sender, EventArgs e)
        {
            AreaSeries.Color = ceColor.Color;
        }

        private void cbFillMode_EditValueChanged(object sender, EventArgs e)
        {
            AreaSeries.FillStyle.FillMode = ChartSettingsHelper.GetFillMode(cbFillMode.SelectedIndex);
        }
    }
}