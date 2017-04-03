using System;

namespace eidss.avr.ChartForm
{
    public partial class SeriesValueLabelsSettings : BaseChartSettings
    {
        public SeriesValueLabelsSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public override void Init(object properties)
        {
            FromProperties(properties);
        }

        public override object ToProperties()
        {
            return ceSeriesValueLabelsVisible.Checked;
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);
            ceSeriesValueLabelsVisible.Checked = (bool)props;
        }

        public void SetupChart(object props)
        {
            Init(props);
            //TODO
        }

        private void ceSeriesValueLabelsVisible_CheckedChanged(object sender, EventArgs e)
        {
            //ChartDetailPanel.ChartPlaceHolder.ChartControl.
        }
    }
}
