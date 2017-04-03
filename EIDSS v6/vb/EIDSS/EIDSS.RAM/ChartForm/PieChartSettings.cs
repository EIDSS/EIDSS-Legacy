using System;
using DevExpress.XtraCharts;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class PieChartSettings : BaseSeriesSettings
    {
        public Series PieSeries { get; set; }

        private static bool ShowArguments { get; set; }

        public PieChartSettings(ChartDetailPanel chartDetailPanel)
            : base(chartDetailPanel)
        {
            InitializeComponent();
            cbCurrentAxis.Enabled = false; //тут оси переключать нельзя
        }

        public string Title
        {
            get { return gcSettings.Text; }
            set { gcSettings.Text = value; }
        }

        public override void Init(object properties)
        {
            base.Init(properties);
            ChartSettingsHelper.SetFormatList(cbFormat);
            FromProperties(properties);
            ChartDetailPanel.ChartControl.CustomDrawSeriesPoint += ChartControl_CustomDrawSeriesPoint;
        }

        public override object ToProperties()
        {
            var p = (IPieProperties)base.ToProperties();
            p.ShowArguments = ceShowArguments.Checked;
            p.Format = cbFormat.SelectedIndex;
            return p;
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);
            var p = (IPieProperties)props;
            ShowArguments = ceShowArguments.Checked = p.ShowArguments;
            cbFormat.SelectedIndex = p.Format;
        }

        public static void SetupChart(ChartControl chartControl, Series series /*SimplePointOptions po*/, object props)
        {
            var p = (IPieProperties)props;
            ShowArguments = p.ShowArguments;
            //тип выводимых значений: дроби, проценты, исходные числа
            SetFormat(p.Format, (SimplePointOptions)series.Label.PointOptions);
            series.LegendPointOptions.PointView = PointView.Argument;
            //po.PointView = PointView.SeriesName;
        }

        private static void SetFormat(int format, SimplePointOptions po)
        {
            switch (format)
            {
                case 0:
                    //дроби
                    po.ValueNumericOptions.Format = NumericFormat.General;
                    po.PercentOptions.ValueAsPercent = true;
                    break;
                case 1:
                    //проценты
                    po.ValueNumericOptions.Format = NumericFormat.Percent;
                    po.PercentOptions.ValueAsPercent = true;
                    break;
                case 2:
                    //исходные числа
                    po.ValueNumericOptions.Format = NumericFormat.General;
                    po.PercentOptions.ValueAsPercent = false;
                    break;
            }
        }

        private string GetTruncatedArgument(string argument)
        {
            var complexArgument = argument.Split(new[] { @" | " }, StringSplitOptions.None);
            return complexArgument.Length < 2
                       ? argument
                       : complexArgument[complexArgument.Length - 1];
        }

        void ChartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            if (ShowArguments 
                &&
                ((ChartDetailPanel.ChartControl.Diagram is SimpleDiagram) || (ChartDetailPanel.ChartControl.Diagram is SimpleDiagram3D)))
            {
                e.LabelText = String.Format("{0} - {1}", e.LabelText, GetTruncatedArgument(e.SeriesPoint.Argument));
            }
        }

        private void ceShowArguments_CheckedChanged(object sender, EventArgs e)
        {
            ShowArguments = ceShowArguments.Checked;
            ChartDetailPanel.ChartControl.Invalidate();
        }

        private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFormat(cbFormat.SelectedIndex, (SimplePointOptions)PieSeries.Label.PointOptions);
        }
    }
}
