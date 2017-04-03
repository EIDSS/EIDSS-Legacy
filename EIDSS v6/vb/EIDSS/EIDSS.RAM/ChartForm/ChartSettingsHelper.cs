using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using eidss.model.Resources;
using System.Linq;
using System.Collections.Generic;

namespace eidss.avr.ChartForm
{
    public static class ChartSettingsHelper
    {
        public static void GetFont(FontDialog fontDialog, out Font font, out Color color)
        {
            var isSupported = fontDialog.Font.FontFamily.IsStyleAvailable(FontStyle.Regular);
            if (isSupported)
            {
                font = new Font(fontDialog.Font, FontStyle.Regular);
            }
            else
            {
                font = new Font(new FontFamily("Tahoma"), 8, FontStyle.Regular);
                fontDialog.Font = font;
            }
            color = Color.Black;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog.Font;
                color = fontDialog.Color;
            }
        }

        public static void SetAlignmentList(ComboBoxEdit ce, bool needCenter)
        {
            ce.Properties.Items.Clear();
            ce.Properties.Items.Add(EidssFields.Get("AlignmentLeft", "Left"));
            if (needCenter) ce.Properties.Items.Add(EidssFields.Get("AlignmentCenter", "Center"));
            ce.Properties.Items.Add(EidssFields.Get("AlignmentRight", "Right"));
        }

        public static void SetFillModeList(ComboBoxEdit ce)
        {
            ce.Properties.Items.Clear();
            ce.Properties.Items.Add(EidssFields.Get("FillModeEmpty", "Empty"));
            ce.Properties.Items.Add(EidssFields.Get("FillModeSolid", "Solid"));
        }

        public static void SetFormatList(ComboBoxEdit ce)
        {
            ce.Properties.Items.Clear();
            ce.Properties.Items.Add(EidssFields.Get("FormatGeneral", "General"));
            ce.Properties.Items.Add(EidssFields.Get("FormatPercent", "Percent"));
            ce.Properties.Items.Add(EidssFields.Get("FormatValues", "Values"));
        }

        public static void SetGridLineStylesList(ComboBoxEdit ce)
        {
            ce.Properties.Items.Clear();
            ce.Properties.Items.Add(EidssFields.Get("GridLinesStyleSolid", "Solid"));
            ce.Properties.Items.Add(EidssFields.Get("GridLinesStyleDash", "Dash"));
            ce.Properties.Items.Add(EidssFields.Get("GridLinesStyleDot", "Dot"));
            ce.Properties.Items.Add(EidssFields.Get("GridLinesStyleDashDot", "Dash Dot"));
            ce.Properties.Items.Add(EidssFields.Get("GridLinesStyleDashDotDot", "Dash Dot Dot"));
        }

        public static void SetPointMarkerKindList(ComboBoxEdit ce)
        {
            ce.Properties.Items.Clear();
            ce.Properties.Items.Add(EidssFields.Get("PointMarkerKindSquare", "Square"));
            ce.Properties.Items.Add(EidssFields.Get("PointMarkerKindDiamond", "Diamond"));
            ce.Properties.Items.Add(EidssFields.Get("PointMarkerKindTriangle", "Triangle"));
            ce.Properties.Items.Add(EidssFields.Get("PointMarkerKindCircle", "Circle"));
            ce.Properties.Items.Add(EidssFields.Get("PointMarkerPlus", "Plus"));
            ce.Properties.Items.Add(EidssFields.Get("PointMarkerKindCross", "Cross"));
        }

        public static StringAlignment GetAlignment(int index)
        {
            var result = StringAlignment.Near;
            switch (index)
            {
                case 1:
                    result = StringAlignment.Center;
                    break;
                case 2:
                    result = StringAlignment.Far;
                    break;
            }
            return result;
        }

        public static DashStyle GetDashStyle(int gridLineStyle)
        {
            var result = DashStyle.Solid;
            switch (gridLineStyle)
            {
                case 1:
                    result = DashStyle.Dash;
                    break;
                case 2:
                    result = DashStyle.Dot;
                    break;
                case 3:
                    result = DashStyle.DashDot;
                    break;
                case 4:
                    result = DashStyle.DashDotDot;
                    break;
            }
            return result;
        }

        public static FillMode GetFillMode(int fillMode)
        {
            return fillMode == 0 ? FillMode.Empty : FillMode.Solid;
        }

        public static MarkerKind GetMarkerKind(int markerKind)
        {
            var result = MarkerKind.Circle;
            switch (markerKind)
            {
                case 0:
                    result = MarkerKind.Square;
                    break;
                case 1:
                    result = MarkerKind.Diamond;
                    break;
                case 2:
                    result = MarkerKind.Triangle;
                    break;
                case 3:
                    result = MarkerKind.InvertedTriangle;
                    break;
                case 4:
                    result = MarkerKind.Circle;
                    break;
                case 5:
                    result = MarkerKind.Plus;
                    break;
                case 6:
                    result = MarkerKind.Cross;
                    break;
            }
            return result;
        }

        public static AxisAlignment GetAxisAlignment(int position)
        {
            var result = AxisAlignment.Zero;
            switch (position)
            {
                case 0:
                    result = AxisAlignment.Near;
                    break;
                case 1:
                    result = AxisAlignment.Far;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Пересчитывает видимый диапазон у оси (Range min/max)
        /// </summary>
        /// <param name="chartDetailPanel"></param>
        /// <param name="activeYIndex">Индекс оси</param>
        public static void RecalculateRangeAxis(ChartDetailPanel chartDetailPanel, int activeYIndex)
        {
            var props = chartDetailPanel.ChartProperties;
            //если ось не подлежит пересчёту, то выходим сразу
            //if (props.YAxes[activeYIndex].AutoRange) return;
            //пересчитываем видимый диапазон для этой оси
            //в расчёте участвуют все серии, которые привязаны к данной оси
            var seriesControls = new List<Series>();
            var seriesProp = props.Series.Where(s => s.AxisYIndex == activeYIndex).ToList();
            //те серии, которые подлежат анализу
            for (var i = 0; i < seriesProp.Count; i++)
            {
                if (seriesProp[i].AxisYIndex == activeYIndex)
                    seriesControls.Add(chartDetailPanel.ChartPlaceHolder.ChartControl.Series[seriesProp[i].Index]);
            }
            double rangeMin = 0;
            double rangeMax = 0;
            foreach (var series in seriesControls)
            {
                foreach (SeriesPoint point in series.Points)
                {
                    if (point.Values[0] < rangeMin) rangeMin = point.Values[0];
                    if (point.Values[0] > rangeMax) rangeMax = point.Values[0];
                }
            }
            //если не удалось найти значений
            if ((rangeMin == 0) && (rangeMax == 0)) rangeMax = 1;
            var axis = activeYIndex == 0 ?
                chartDetailPanel.ChartPlaceHolder.AxisY
                :
                (AxisBase)((XYDiagram)chartDetailPanel.ChartPlaceHolder.ChartControl.Diagram).SecondaryAxesY[activeYIndex - 1]
                ;
            if (axis != null)
            {
                axis.VisualRange.MaxValue = rangeMax;
                axis.VisualRange.MinValue = rangeMin;
                //переносим в настройки
                props.YAxes[activeYIndex].RangeMaxValue = rangeMax;
                props.YAxes[activeYIndex].RangeMinValue = rangeMin;
            }
        }

        /// <summary>
        /// Пересчитывает наличие дробных значений у оси
        /// </summary>
        /// <param name="chartDetailPanel"></param>
        /// <param name="activeYIndex">Индекс оси</param>
        /// <param name="dtSource">Источник данных с описанием серий</param>
        public static void RecalculateGridSpacingAxis(ChartDetailPanel chartDetailPanel, int activeYIndex, DataTable dtSource)
        {
            //надо, чтобы константы с полями соответствовали таковым в ChartDetailPanel
            const string seriesName = "Series"; 
            const string dataType = "DataType";

            var props = chartDetailPanel.ChartProperties;
            //в расчёте участвуют все серии, которые привязаны к данной оси
            var seriesControls = new List<Series>();
            var seriesProp = props.Series.Where(s => s.AxisYIndex == activeYIndex).ToList();
            //те серии, которые подлежат анализу
            for (var i = 0; i < seriesProp.Count; i++)
            {
                seriesControls.Add(chartDetailPanel.ChartPlaceHolder.ChartControl.Series[seriesProp[i].Index]);
            }

            //если все серии, привязанные к оси, целочисленные, то убираем промежуточные риски с оси
            //иначе выставляем их константой. Может быть, это кол-во надо пересчитывать, исходя из данных привязанных серий.
            var allSeriesIsInt = true;
            foreach (var series in seriesControls)
            {
                var rows = dtSource.Select(String.Format("[{0}]='{1}'", seriesName, series.Name));
                //если не найдена строка-серия, то это ошибка!
                if (rows.Length == 0) continue;
                var tp = (Type)rows[0][dataType];
                if (!(tp == typeof (int) || tp == typeof (long)))
                {
                    allSeriesIsInt = false;
                    break;
                }
            }
            var axis = activeYIndex == 0 ?
                chartDetailPanel.ChartPlaceHolder.AxisY
                :
                (AxisBase)((XYDiagram)chartDetailPanel.ChartPlaceHolder.ChartControl.Diagram).SecondaryAxesY[activeYIndex - 1]
                ;
            if (axis != null)
            {
                var maxValue = Convert.ToDouble(axis.VisualRange.MaxValue);
                var minValue = Convert.ToDouble(axis.VisualRange.MinValue);
                var val = GetGridSpacing(maxValue - minValue); //(Convert.ToInt32(maxValue - minValue) / 10);// *10;
                //if (val == 0) val = 1;
                if (allSeriesIsInt)
                {
                    axis.DateTimeScaleOptions.AutoGrid = false;
                    axis.DateTimeScaleOptions.GridSpacing = val;
                }
                else
                {
                    axis.DateTimeScaleOptions.AutoGrid = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        private static int GetGridSpacing(double range)
        {
            if (range < 10)
            {
                return 1;
            }
            var orderCount = (int)Math.Log10(range);
            var order = (int)Math.Pow(10, orderCount);
            var firstNum = (int)(range / order);
            if (firstNum < 4)
            {
                return (firstNum * order) / 10;
            }
            if (firstNum < 7)
            {
                return order / 2;
            }
            return order;
        }
    }
}
