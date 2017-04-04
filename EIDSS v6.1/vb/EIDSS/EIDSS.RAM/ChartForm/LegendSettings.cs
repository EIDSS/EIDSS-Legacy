using System;
using DevExpress.Utils;

namespace eidss.avr.ChartForm
{
    public partial class LegendSettings : BaseChartSettings
    {
        public LegendSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public override void Init(object properties)
        {
            FromProperties(properties);
        }

        public override object ToProperties()
        {
            return ceLegendVisibility.Checked;
        }

        public override void FromProperties(object props)
        {
            ceLegendVisibility.Checked = (bool) props;
        }

        public void SetupChart(object props)
        {
            Init(props);
            ChartDetailPanel.ChartPlaceHolder.ChartControl.Legend.Visibility = (bool) props
                                                                                   ? DefaultBoolean.True
                                                                                   : DefaultBoolean.False;
        }

        private void ceLegendVisibility_CheckedChanged(object sender, EventArgs e)
        {
            ChartDetailPanel.ChartPlaceHolder.ChartControl.Legend.Visibility = ceLegendVisibility.Checked
                                                                                   ? DefaultBoolean.True
                                                                                   : DefaultBoolean.False;
        }
    }
}
