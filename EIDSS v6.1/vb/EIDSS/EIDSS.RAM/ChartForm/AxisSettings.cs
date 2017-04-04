using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Controls;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class AxisSettings : BaseChartSettings
    {
        public AxisSettings()
        {
            InitializeComponent();
        }

        public AxisSettings(ChartDetailPanel chartDetailPanel) : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public Axis2D CurrentAxis { get; set; }

        [Browsable(true), Localizable(true)]
        public string Title
        {
            get { return gcMain.Text; }
            set { gcMain.Text = value; }
        }
       
        public override void Init(object axisProperties)
        {
            ChartSettingsHelper.SetGridLineStylesList(cbGridLinesStyles);
            titleTitle.ChartDetailPanel = ChartDetailPanel;
            titleTitle.CurrentTitle = CurrentAxis.Title;
            titleTitle.Init(((AxisProperties)axisProperties).Title);
        }

        public override object ToProperties()
        {
            if (CurrentAxis == null) return null;
            var p = new AxisProperties
                {
                    LineColor = ceLineColor.Color,
                    LineWidth = Convert.ToInt32(seLineWidth.Value),
                    GridLinesColor = ceGridLinesColor.Color,
                    GridLinesStyle = cbGridLinesStyles.SelectedIndex,
                    GridLinesVisibility = cbGridLinesVisible.Checked,
                    ValueLabelAngle = Convert.ToInt32(seValueLabelAngle.Value),
                    ValueLabelStaggeredStyle = ceValueLabelStaggeredStyle.Checked,
                    Title = (TitleProperties) titleTitle.ToProperties(),
                    TickmarkMinorCount = Convert.ToInt32(seTickmarkMinorCount.Value),
                    RangeReverse = cbReverse.Checked
                };

            p.ValueLabelFont.FromFont(CurrentAxis.Label.Font, CurrentAxis.Label.TextColor);

            return p;
        }

        public override void FromProperties(object props)
        {
            if (CurrentAxis == null) return;
            base.FromProperties(props);
            var p = (AxisProperties)props;
            ceLineColor.Color = p.LineColor;
            seLineWidth.Value = p.LineWidth;
            ceGridLinesColor.Color = p.GridLinesColor;
            cbGridLinesStyles.SelectedIndex = p.GridLinesStyle;
            cbGridLinesVisible.Checked = p.GridLinesVisibility;
            seValueLabelAngle.Value = p.ValueLabelAngle;
            ChartDetailPanel.fontDialog.Font = CurrentAxis.Label.Font = p.ValueLabelFont.ToFont();
            beValueLabelFont.Text = p.ValueLabelFont.FontName;
            CurrentAxis.Label.TextColor = p.ValueLabelFont.TextColor;
            ceValueLabelStaggeredStyle.Checked = p.ValueLabelStaggeredStyle;
            titleTitle.FromProperties(p.Title);
            if (CurrentAxis.Label.Staggered && (p.Title.Text.Length == 0)) CurrentAxis.Title.Text = " ";

            seTickmarkMinorCount.Value = p.TickmarkMinorCount;
            cbReverse.Checked = p.RangeReverse;
        }

        public static void SetupChart(Axis2D currentAxis, object props)
        {
            if (currentAxis == null) return;
            var p = (AxisProperties)props;
            currentAxis.Label.Font = p.ValueLabelFont.ToFont();
            currentAxis.Label.TextColor = p.ValueLabelFont.TextColor;
            var axis = currentAxis as Axis;
            if (axis != null)
            {
                axis.Color = p.LineColor;
                axis.Thickness = p.LineWidth;
                axis.Reverse = p.RangeReverse;
            }
            currentAxis.GridLines.Color = p.GridLinesColor;
            currentAxis.GridLines.LineStyle.DashStyle = ChartSettingsHelper.GetDashStyle(p.GridLinesStyle);
            currentAxis.GridLines.Visible = p.GridLinesVisibility;
            currentAxis.Label.Angle = p.ValueLabelAngle;
            currentAxis.Label.Staggered = p.ValueLabelStaggeredStyle;
            currentAxis.MinorCount = p.TickmarkMinorCount;
            TitleSettings.SetupChart(currentAxis.Title, p.Title);

            if (currentAxis.Label.Staggered && (p.Title.Text.Length == 0)) currentAxis.Title.Text = " ";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beValueLabelFont_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (CurrentAxis == null) return;
            Font font;
            Color color;
            ChartSettingsHelper.GetFont(ChartDetailPanel.fontDialog, out font, out color);
            beValueLabelFont.Text = font.Name;
            CurrentAxis.Label.Font = font;
            CurrentAxis.Label.TextColor = color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ceLineColor_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            var value = ceLineColor.Color;
            CurrentAxis.Color = value;
            //TODO другие виды диаграмм 
            //CurrentAxis.Label.TextColor = 
        }

        private void seLineWidth_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            var value = Convert.ToInt32(seLineWidth.Value);
            var axis = CurrentAxis as Axis;
            if (axis != null)
            {
                axis.Thickness = value;
            }
            //TODO другие виды диаграмм
        }

        private void ceGridLinesColor_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            CurrentAxis.GridLines.Color = ceGridLinesColor.Color;
        }

        private void cbGridLinesStyles_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            CurrentAxis.GridLines.LineStyle.DashStyle = ChartSettingsHelper.GetDashStyle(cbGridLinesStyles.SelectedIndex);
        }

        private void cbGridLinesVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            CurrentAxis.GridLines.Visible = cbGridLinesVisible.Checked;
        }

        private void seValueLabelAngle_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            CurrentAxis.Label.Angle = Convert.ToInt32(seValueLabelAngle.Value);
        }

        private void ceValueLabelStaggeredStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            CurrentAxis.Label.Staggered = ceValueLabelStaggeredStyle.Checked;
            //TODO workaround странного бага. Если staggered style и пустой заголовок, то риски рендерятся вне поля видимости
            if (CurrentAxis.Label.Staggered && (CurrentAxis.Title.Text.Length == 0)) CurrentAxis.Title.Text = " ";
            if (!CurrentAxis.Label.Staggered && (CurrentAxis.Title.Text == " ")) CurrentAxis.Title.Text = String.Empty;
        }

        private void seTickmarkMinorCount_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            CurrentAxis.MinorCount = Convert.ToInt32(seTickmarkMinorCount.Value);
        }

        private void cbReverse_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentAxis == null) return;
            var axis = CurrentAxis as Axis;
            if (axis != null) axis.Reverse = cbReverse.Checked;
            //TODO другие типы диаграмм
        }
    }
}
