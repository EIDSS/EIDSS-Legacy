using System;
using DevExpress.XtraCharts;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class LineChartSettings : BaseSeriesSettings
    {
        public LineChartSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public LineSeriesView LineSeries { get; set; }

        public string Title
        {
            get { return gcSettings.Text; }
            set { gcSettings.Text = value; }
        }
        
        public static void SetupChart(LineSeriesView lineSeries, object props)
        {
            var p = (ILineProperties)props;
            lineSeries.Color = p.Color;
            lineSeries.LineStyle.DashStyle = ChartSettingsHelper.GetDashStyle(p.LineStyle);
            lineSeries.LineStyle.Thickness = p.LineStyleWidth;
            lineSeries.Shadow.Visible = p.ShadowVisible;
        }

        public override void Init(object properties)
        {
            base.Init(properties);
            ChartSettingsHelper.SetGridLineStylesList(cbLineStyle);
            FromProperties(properties);
        }

        public override object ToProperties()
        {
            var p = (ILineProperties)base.ToProperties();
            p.ColorArgb = ceColor.Color.ToArgb();
            p.LineStyle = cbLineStyle.SelectedIndex;
            p.LineStyleWidth = Convert.ToInt32(seLineStyleWidth.Value);
            return p;
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);
            var p = (ILineProperties) props;
            ceColor.Color = p.Color;
            cbLineStyle.SelectedIndex = p.LineStyle;
            seLineStyleWidth.Value = p.LineStyleWidth;
        }

        private void ceColor_EditValueChanged(object sender, EventArgs e)
        {
            LineSeries.Color = ceColor.Color;
        }

        private void cbLineStyle_EditValueChanged(object sender, EventArgs e)
        {
            LineSeries.LineStyle.DashStyle = ChartSettingsHelper.GetDashStyle(cbLineStyle.SelectedIndex);
        }

        private void seLineStyleWidth_EditValueChanged(object sender, EventArgs e)
        {
            LineSeries.LineStyle.Thickness = Convert.ToInt32(seLineStyleWidth.Value);
        }

        private void cbShadowVisible_EditValueChanged(object sender, EventArgs e)
        {
            LineSeries.Shadow.Visible = cbShadowVisible.Checked;
        }
    }
}
