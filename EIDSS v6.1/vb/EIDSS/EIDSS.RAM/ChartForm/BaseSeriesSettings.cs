using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors.Controls;
using EIDSS.Core;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Avr.Chart;
using eidss.model.AVR.DataBase;
using eidss.model.Resources;

namespace eidss.avr.ChartForm
{
    public partial class BaseSeriesSettings : BaseChartSettings
    {
        public virtual void SwitchTo3D(bool is3D)
        {
            
        }

        /// <summary>
        /// Та ось Y, на которую замкнута редактируемая серия
        /// </summary>
        public AxisBase CurrentAxisY { get; set; }

        public BaseSeriesSettings()
        {
            InitializeComponent();
        }

        protected SeriesProperties ParentSeries { get; set; }

        public BaseSeriesSettings(ChartDetailPanel chartDetailPanel)
            : base(chartDetailPanel)
        {
            InitializeComponent();
        }

        public override void Init(object properties)
        {
            base.Init(properties);
            var prop = ((IParentSeries) properties);
            ParentSeries = prop.ParentSeries;

            RefreshAxisList();
            if (ParentSeries.AxisYIndex == 0)
            {
                CurrentAxisY = ChartPlaceHolder.AxisY;
            }
            else
            {
                var secondaryAxes = ((XYDiagram)ChartPlaceHolder.ChartControl.Diagram).SecondaryAxesY;
                CurrentAxisY = secondaryAxes[ParentSeries.AxisYIndex - 1];
            }
            ceSeriesLabelsVisibility.Checked = ParentSeries.SeriesLabelsVisibility;

            FillChartTypes();

        }

        /// <summary>
        /// Обновление списка осей и выставление активной для этой серии
        /// </summary>
        private void RefreshAxisList()
        {
            //заполняем список серий
            cbCurrentAxis.Properties.Items.Clear();
            if (ChartDetailPanel.ChartProperties.YAxes.Count == 0) return;
            //всегда первой идет первичная ось, потом вторичные
            cbCurrentAxis.Properties.Items.Add(EidssFields.Get("PrimaryAxisY"));
            var secTit = EidssFields.Get("SecondaryAxisY");
            for (var index = 1; index < ChartDetailPanel.ChartProperties.YAxes.Count; index++)
            {
                cbCurrentAxis.Properties.Items.Add(String.Format("{0} #{1}", secTit, index));
            }
            var currentAxisIndex = ChartDetailPanel.GetAxisYIndex(CurrentAxisY);
            if ((currentAxisIndex > -1) && (currentAxisIndex < cbCurrentAxis.Properties.Items.Count))
            {
                cbCurrentAxis.SelectedIndexChanged -= cbCurrentAxis_SelectedIndexChanged;
                cbCurrentAxis.SelectedIndex = currentAxisIndex;
                cbCurrentAxis.SelectedIndexChanged += cbCurrentAxis_SelectedIndexChanged;
            }

            //пересчитываем видимый диапазон для этой оси - this calculation is made only for 1 axis - so if there are 2 axis - range become wrong
            //в расчёте участвуют все серии, которые привязаны к данной оси
            //ChartSettingsHelper.RecalculateRangeAxis(ChartDetailPanel, ParentSeries.AxisYIndex);
            ChartSettingsHelper.RecalculateGridSpacingAxis(ChartDetailPanel, ParentSeries.AxisYIndex, ChartDetailPanel.DataTableSource);
        }
        /*
        /// <summary>
        /// Работа с осями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCurrentAxis_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var diagram = ChartDetailPanel.ChartControl.Diagram as XYDiagram;
            if (diagram == null) return;
            var secondaryAxes = diagram.SecondaryAxesY;
            var axesProps = ChartDetailPanel.ChartProperties.YAxes;
            var needRefreshAxis = false;
            if (e.Button.Kind.Equals(ButtonPredefines.Plus))
            {
                //согласно новым требованиям в 9413, может быть только одна дополнительная ось
                if (secondaryAxes.Count == 0)
                {
                    secondaryAxes.Add(new SecondaryAxisY());
                    var yAxis = new YAxisProperties { Position = 1 };
                    axesProps.Add(yAxis);
                    needRefreshAxis = true;
                }
            }
            else if (e.Button.Kind.Equals(ButtonPredefines.Delete))
            {
                //первичную ось удалять нельзя
                var index = cbCurrentAxis.SelectedIndex;
                if ((index > 0) && (index < axesProps.Count))
                {
                    //переносим серии, которые привязаны к удаляемой оси, на первичную ось
                    //те серии, которые привязаны к осям позже удаляемой, смещаем на 1
                    var series = ChartDetailPanel.ChartProperties.Series;
                    for (var i = 0; i < series.Count; i++)
                    {
                        var ser = series[i];
                        if (ser.AxisYIndex == index) ser.AxisYIndex = 0; //на первичную ось
                        if (ser.AxisYIndex > index) ser.AxisYIndex--;
                    }
                    //удаляем ось
                    if (index - 1 < secondaryAxes.Count)
                    {
                        secondaryAxes.Remove(secondaryAxes[index - 1]);
                        ChartDetailPanel.ChartProperties.YAxes.RemoveAt(index);
                    }
                    //поскольку серии, привязанные к удалённой, перенесены на первичную ось, то выставляем её выбранной
                    CurrentAxisY = ChartPlaceHolder.AxisY;
                    needRefreshAxis = true;
                }
            }
            if (needRefreshAxis) RefreshAxisList();
        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCurrentAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ParentSeries == null) return;
            var diagram = ChartPlaceHolder.ChartControl.Diagram as XYDiagram;
            if (diagram == null) return;
            var index = cbCurrentAxis.SelectedIndex;
            if (index < 0) return;
            if (index == 0)
            {
                CurrentAxisY = ChartPlaceHolder.AxisY;
            }
            else
            {
                var secondaryAxes = diagram.SecondaryAxesY;
                CurrentAxisY = secondaryAxes[index - 1];
            }
            var ser = ChartDetailPanel.ChartControl.Series[ParentSeries.Index];
            var view = (XYDiagramSeriesViewBase) ser.View;
            view.AxisY = (AxisYBase) CurrentAxisY;

            //при трансфере серии между осями нужно провести пересчёт видимых диапазонов для обеих осей, участвующих в трансфере
            //также пересчитываем промежуточные риски на оси
            var oldIndex = ParentSeries.AxisYIndex;
            if (index != oldIndex)
            {
                ParentSeries.AxisYIndex = index;
                ChartSettingsHelper.RecalculateRangeAxis(ChartDetailPanel, ParentSeries.AxisYIndex);
                ChartSettingsHelper.RecalculateGridSpacingAxis(ChartDetailPanel, ParentSeries.AxisYIndex, ChartDetailPanel.DataTableSource);
                ChartSettingsHelper.RecalculateRangeAxis(ChartDetailPanel, oldIndex);
                ChartSettingsHelper.RecalculateGridSpacingAxis(ChartDetailPanel, oldIndex, ChartDetailPanel.DataTableSource);
            }
            ChartDetailPanel.SetSecondaryAxisVisibilityState();
        }

        public override void FromProperties(object props)
        {
            base.FromProperties(props);

            cbCurrentAxis.SelectedIndexChanged -= cbCurrentAxis_SelectedIndexChanged;
            cbCurrentAxis.SelectedIndex = ParentSeries.AxisYIndex;
            cbCurrentAxis.SelectedIndexChanged += cbCurrentAxis_SelectedIndexChanged;

            ceSeriesLabelsVisibility.CheckedChanged -= ceSeriesLabelsVisibility_CheckedChanged;
            ceSeriesLabelsVisibility.Checked = ParentSeries.SeriesLabelsVisibility;
            ceSeriesLabelsVisibility.CheckedChanged += ceSeriesLabelsVisibility_CheckedChanged;

            SetParentSeriesViewType();
        }

        internal void SetParentSeriesViewType()
        {
            leChart.EditValueChanged -= leChart_EditValueChanged;
            var vt = GetParentSeriesViewType().ToString();
            var dt = Enum.Parse(typeof(DBChartType), "chr" + vt);
            leChart.EditValue = (long)dt;
            leChart.EditValueChanged += leChart_EditValueChanged;
        }

        internal void SetChangeAxisAbility(bool can)
        {
            cbCurrentAxis.Enabled = can;
        }

        public override object ToProperties()
        {
            var o = Activator.CreateInstance(PropertiesType);
            if (ParentSeries != null)
            {
                var ps = (IParentSeries)o;
                ps.ParentSeries = ParentSeries;
                ps.ParentSeries.AxisYIndex = cbCurrentAxis.SelectedIndex;
                ParentSeries.SeriesLabelsVisibility = ceSeriesLabelsVisibility.Checked;
            }
            return o;
        }

        private void ceSeriesLabelsVisibility_CheckedChanged(object sender, EventArgs e)
        {
            if (ParentSeries == null)return;
            ParentSeries.SeriesLabelsVisibility = ceSeriesLabelsVisibility.Checked;
            var ser = ChartDetailPanel.ChartControl.Series[ParentSeries.Index];
            ser.LabelsVisibility = ParentSeries.SeriesLabelsVisibility ? DefaultBoolean.True : DefaultBoolean.False;
        }

        internal static bool Is3DType(SeriesProperties ser)
        {
            return Is3DType((ViewType)Enum.Parse(typeof(ViewType), ser.ViewType.ToString()));
        }

        internal static bool Is3DType(ViewType vt)
        {
            return vt.ToString().Contains("3D");
        }

        public void FillChartTypes()
        {
            var types = LookupCache.Get(BaseReferenceType.rftChart);
            types.RowFilter = "[strDefault]" + (Is3DType(ParentSeries) ? String.Empty : " not") + " like '%3D%'";
            LookupBinder.SetDataSource(leChart, types, "name", "idfsReference");
            leChart.Properties.Columns.Clear();
            leChart.Properties.Columns.Add(new LookUpColumnInfo("name"));
        }

        internal static bool IsPieType(ViewType viewType)
        {
            return (viewType == ViewType.Pie
             || viewType == ViewType.Pie3D
             || viewType == ViewType.Doughnut
             || viewType == ViewType.Doughnut3D);
        }

        internal static bool IsFullStackedBarType(ViewType viewType)
        {
            return (viewType == ViewType.FullStackedBar
             || viewType == ViewType.FullStackedBar3D);
        }

        private void leChart_EditValueChanged(object sender, EventArgs e)
        {
            if (Utils.IsEmpty(leChart.EditValue))
            {
                leChart.EditValue = (long) DBChartType.chrBar;
                return;
            }
            var currentSeriesIndex = ParentSeries.Index;
            var ser = ChartDetailPanel.ChartControl.Series[currentSeriesIndex];
            var newViewType = ChartPresenter.GetChartType(leChart.EditValue);
            //для бубликов нужен свой тип диаграммы
            //в случае смены бублик/не бублик надо спросить, переделать ли все серии. Иначе они пропадут с диаграммы.
            var needConvertAllSeries = false;
            var serVt = SeriesViewFactory.GetViewType(ser.View);
            if (
                (IsPieType(newViewType) != IsPieType(serVt))
                ||
                (IsFullStackedBarType(newViewType) != IsFullStackedBarType(serVt))
                )
            {
                if (!ChartDetailPanel.SilenceMode)
                {
                    if (!WinUtils.ConfirmMessage(EidssMessages.Get("avrChart_ChangeSeriesType"), String.Empty))
                    {
                        //возвращаем прежнее значение
                        SetParentSeriesViewType();
                        return;
                    }
                }
                
                needConvertAllSeries = true;
                ChartDetailPanel.ChartControl.SeriesTemplate.ChangeView(newViewType);
                ChartDetailPanel.SetupDiagram();
            }

            var seriesForOperate = new List<Series>();
            if (needConvertAllSeries)
            {
                foreach (var s in ChartDetailPanel.ChartControl.Series)
                {
                    seriesForOperate.Add((Series)s);
                }
            }
            else
            {
                seriesForOperate.Add(ser);
            }

            for (var index = 0; index < seriesForOperate.Count; index++)
            {
                var series = seriesForOperate[index];
                series.ChangeView(newViewType);
                var seriesProperties = needConvertAllSeries ? ChartProperties.Series[index] : ParentSeries;
                
                //меняем на заданный тип, только если это не массовый пересчёт
                //if (!needConvertAllSeries) seriesProperties.ViewType = (int)newViewType;

                seriesProperties.ViewType = (int)newViewType;
                
                ChartDetailPanel.SetupSeries(series, seriesProperties);

                var dgm = ChartPlaceHolder.ChartControl.Diagram as XYDiagram;
                if (dgm != null)
                {
                    var axisYIndex = seriesProperties.AxisYIndex;
                    var xyview = (XYDiagramSeriesViewBase) series.View;
                    var secondaryAxes = ((XYDiagram) ChartPlaceHolder.ChartControl.Diagram).SecondaryAxesY;
                    xyview.AxisY = axisYIndex == 0
                                       ? ChartPlaceHolder.AxisY
                                       : (AxisYBase) secondaryAxes[axisYIndex - 1];
                    //ChartPlaceHolder.AxisX.VisualRange.AutoSideMargins = false;
                    //ChartPlaceHolder.AxisX.VisualRange.AutoSideMargins = true;
                }
            }

            //показываем панель настроек для этого типа серии
            ChartDetailPanel.ShowSettingsPanel(ChartDetailPanel.ChartControl.Series[ParentSeries.Index]);
        }

        private void bApplyAllSeries_Click(object sender, EventArgs e)
        {
            //Apply common properties to all series
            //and copy all properties (except color) to series with same type
            var p = ToProperties();
            if (ApplyToAllSeriesRoutines != null) ApplyToAllSeriesRoutines(GetParentSeriesViewType(), p);
        }

        private ViewType GetParentSeriesViewType()
        {
            return (ViewType)Enum.Parse(typeof(ViewType), ParentSeries.ViewType.ToString());
        }

        public ApplyToAllSeries ApplyToAllSeriesRoutines { get; set; }

        public delegate void ApplyToAllSeries(ViewType vt, object properties);
    }
}
