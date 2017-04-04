using System;
using DevExpress.XtraCharts;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class PointChartSettings : BaseSeriesSettings
    {
        public override void SwitchTo3D(bool is3D)
        {
            base.SwitchTo3D(is3D);
            gcSettings.Visible = !is3D;
        }

        public PointChartSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public PointSeriesView PointSeries { get; set; }

        public override void Init(object properties)
        {
            base.Init(properties);
            ChartSettingsHelper.SetPointMarkerKindList(cbPointMarker);
            FromProperties(properties);
        }

        public override object ToProperties()
        {
            var p = (PointProperties) base.ToProperties();
            p.Color = ceColor.Color;
            p.PointMarkerOptionsKind = cbPointMarker.SelectedIndex;
            return p;
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);
            var p = (PointProperties) props;
            ceColor.Color = p.Color;
            cbPointMarker.SelectedIndex = p.PointMarkerOptionsKind;
        }

        public static void SetupChart(PointSeriesView pointSeries, object props)
        {
            var p = (PointProperties) props;
            pointSeries.Color = p.Color;
            pointSeries.PointMarkerOptions.Kind = ChartSettingsHelper.GetMarkerKind(p.PointMarkerOptionsKind);
        }

        private void ceColor_EditValueChanged(object sender, EventArgs e)
        {
            PointSeries.Color = ceColor.Color;
        }

        private void cbPointMarker_EditValueChanged(object sender, EventArgs e)
        {
            PointSeries.PointMarkerOptions.Kind = ChartSettingsHelper.GetMarkerKind(cbPointMarker.SelectedIndex);
        }
    }
}