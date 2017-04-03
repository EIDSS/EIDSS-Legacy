using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Core;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrinting;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.model.Avr.Chart;
using eidss.model.Resources;
using eidss.model.WindowsService.Serialization;


namespace eidss.avr.ChartForm
{
    public sealed partial class ChartDetailPanel : BaseAvrDetailPresenterPanel, IChartView
    {
        /// <summary>
        /// В тихом режиме программа не спрашивает пользователя
        /// </summary>
        public bool SilenceMode { get; set; }

        private ChartPresenter m_ChartPresenter;

        public ChartDetailPanel()
        {
            try
            {
                
                InitializeComponent();
                if (IsDesignMode() || bv.common.Configuration.BaseSettings.ScanFormsMode)
                {
                    return;
                }
                m_ChartPresenter = (ChartPresenter) SharedPresenter[this];
                ChartControl.AppearanceName = "Nature Colors";
                ChartControl.PaletteName = "Nature Colors";
                ChartControl.PaletteBaseColorNumber = 0;
                ChartProperties = new AvrChartProperties();
                OnBeforePost += ChartDetailPanel_OnBeforePost;
                ChartTitle = XAxisTitle = String.Empty;
                SilenceMode = false;
                IsPosted = false;
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                eventManager.ClearAllReferences();
                if (m_ChartPresenter != null)
                {
                    if (m_ChartPresenter.SharedPresenter != null)
                    {
                        m_ChartPresenter.SharedPresenter.UnregisterView(this);
                    }
                    m_ChartPresenter.Dispose();
                    m_ChartPresenter = null;
                }

           
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
            
        }

        public override bool HasChanges()
        {
            EndEdit();
            var currentXml = AvrChartPropertiesSerializer.Serialize(ChartProperties);
            return InitialXml != currentXml;
        }

        public bool IsPosted { get; private set; }

        private void ChartDetailPanel_OnBeforePost(object sender, EventArgs e)
        {
            var tables = baseDataSet.Tables;
            if (tables.Count > 0 && tables[0].Rows.Count > 0)
            {
                EndEdit();
                var xmlForPost = AvrChartPropertiesSerializer.Serialize(ChartProperties);
                var zipForPost = BinaryCompressor.ZipString(xmlForPost);
                tables[0].Rows[0]["blbChartLocalSettings"] = zipForPost;
                IsPosted = true;
            }
        }

        private void EndEdit()
        {
            if (scrollableMain.Controls.Count > 0)
            {
                var settings = scrollableMain.Controls[0] as ISettingsPanel;
                if (settings != null)
                {
                    SaveDataFromSettingsPanel(settings);
                }
            }
        }

        public byte[] GetXml()
        {
            var xmlForPost = GetXmlString();
            var zipForPost = BinaryCompressor.ZipString(xmlForPost);
            return zipForPost;
        }

        public string GetXmlString()
        {
            EndEdit();
            return AvrChartPropertiesSerializer.Serialize(ChartProperties);
        }

        public string ChartName
        {
            get { return IsDesignMode() ? String.Empty : ChartPlaceHolder.ChartName; }
            set
            {
                if (IsDesignMode())
                {
                    return;
                }
                ChartPlaceHolder.ChartName = value;
            }
        }

        private string ChartTitle { get; set; }
        private string XAxisTitle { get; set; }
        internal DataTable DataTableSource { get; set; }

        private const string SeriesName = "Series";
        private const string SeriesCaption = "Caption";
        private const string ArgumentName = "Arguments";
        private const string ValueName = "Values";
        private const string DataType = "DataType";

        /// <summary>
        ///     Data source for chart control
        /// </summary>
        public object DataSource
        {
            get { return ChartControl.DataSource; }
            set
            {
                if (IsDesignMode())
                {
                    return;
                }
                var tbl = value as DataTable;
                if ((tbl != null) && (tbl.Columns.Count > 0))
                {
                    ChartTitle = tbl.TableName;
                    DataTableSource = new DataTable(ChartTitle);
                    DataTableSource.Columns.Add(SeriesName, typeof (string));
                    DataTableSource.Columns.Add(SeriesCaption, typeof (string));
                    DataTableSource.Columns.Add(ArgumentName, typeof (string));
                    DataTableSource.Columns.Add(ValueName, typeof (decimal));
                    DataTableSource.Columns.Add(DataType, typeof (Type));

                    XAxisTitle = tbl.Columns[0].Caption;//ColumnName
                    for (var i = 1; i < tbl.Columns.Count; i++)
                    {
                        var column = tbl.Columns[i];
                        if (column.DataType.IsNumeric())
                        {
                            foreach (DataRow row in tbl.Rows)
                            {
                                var dtRow = DataTableSource.NewRow();
                                dtRow[SeriesName] = column.ColumnName; //ColumnName
                                dtRow[SeriesCaption] = column.Caption;
                                dtRow[ArgumentName] = row[0].ToString();
                                dtRow[DataType] = column.DataType;

                                var val = row[i];
                                var badValue = Utils.IsEmpty(val) ||
                                       (val is double && (double.IsInfinity((double)val) || double.IsNaN((double)val)));

                                dtRow[ValueName] = badValue
                                    ? DBNull.Value
                                    : val;

                                DataTableSource.Rows.Add(dtRow);
                            }
                        }
                    }

                    ChartControl.DataSource = DataTableSource;
                    ChartControl.SeriesDataMember = SeriesName;
                    ChartControl.SeriesTemplate.ArgumentDataMember = ArgumentName;
                    ChartControl.SeriesTemplate.ValueDataMembers.AddRange(new[] {ValueName});
                }
            }
        }

        public ChartControl ChartControl
        {
            get
            {
                return IsDesignMode() ? new ChartControl() : ChartPlaceHolder.ChartControl;
            }
        }

        public PrintingSystem PrintingSystem
        {
            get { return printingSystem; }
        }

        internal AvrChartProperties ChartProperties { get; set; }

        public void SetInitialXml(string initialXml)
        {
            InitialXml = initialXml;
            if (!String.IsNullOrEmpty(InitialXml))
            {
                ChartProperties = AvrChartPropertiesSerializer.Deserialize(InitialXml);
                foreach (var series in ChartProperties.Series)
                {
                    series.SetParentSeries();
                }
            }
            else
            {
                InitialXml = AvrChartPropertiesSerializer.Serialize(ChartProperties);
            }
            SetupChart();
        }

        public void ChangeChartTypeForAllSeries(DBChartType chartType)
        {
            //количество серий и количестве свойств серий должно совпадать
            if (ChartControl.Series.Count != ChartProperties.Series.Count) return;

            var newViewType = ChartPresenter.GetChartType(chartType);
            for (var i = 0; i < ChartControl.Series.Count; i++)
            {
                var ser = ChartControl.Series[i];
                var serVt = SeriesViewFactory.GetViewType(ser.View);
                if (
                    (BaseSeriesSettings.IsPieType(newViewType) !=
                     BaseSeriesSettings.IsPieType(serVt))
                    ||
                    (BaseSeriesSettings.Is3DType(newViewType) !=
                     BaseSeriesSettings.Is3DType(serVt))
                    ||
                    (BaseSeriesSettings.IsFullStackedBarType(newViewType) !=
                     BaseSeriesSettings.IsFullStackedBarType(serVt)))
                {
                    //переделываем все серии на один тип
                    ChartControl.SeriesTemplate.ChangeView(newViewType);
                    SetupDiagram();
                    break;
                }
            }
            
            for (var index = 0; index < ChartControl.Series.Count; index++)
            {
                var series = ChartControl.Series[index];
                series.ChangeView(newViewType);
                var seriesProperties = ChartProperties.Series[index];

                //меняем на заданный тип, только если это не массовый пересчёт
                //if (!needConvertAllSeries) seriesProperties.ViewType = (int)newViewType;

                seriesProperties.ViewType = (int) newViewType;
                SetupSeries(series, seriesProperties);
            }
        }

        protected override void DefineBinding()
        {
            /*
            var tables = baseDataSet.Tables;
            byte[] zip = null;
            if (tables.Count > 0 && tables[0].Rows.Count > 0)
            {
                zip = tables[0].Rows[0]["blbChartLocalSettings"] as byte[];
                if (zip != null)
                {
                   
                }
            }

            SetInitialXml(zip != null ? BinaryCompressor.UnzipString(zip) : AvrChartPropertiesSerializer.Serialize(ChartProperties));
            */
            ChartControl.ObjectSelected += ChartControl_ObjectSelected;
        }

        public byte[] ExportToJpgBytes()
        {
            using (var stream = new MemoryStream())
            {
                ChartControl.ExportToImage(stream, ImageFormat.Jpeg);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                var buffer = new byte[stream.Length];
                int readed = stream.Read(buffer, 0, (int) stream.Length);
                Debug.Assert(stream.Length == readed, "not all bytes readed");

                return buffer;
            }
        }

        private string InitialXml { get; set; }

        private void ChartControl_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            ShowSettingsPanel(e.Object);
        }

        internal void ShowSettingsPanel(object o)
        {
            EndEdit();
            var index = -1;
            if (o is Series)
            {
                var series = (Series)o;
                o = series.View;
                index = ChartControl.Series.IndexOf(series);
            }
            else if (o is AxisY)
            {
                //TODO проверить для не-XY диаграммы
                index = 0; //основная ось Y (может не быть на XY диаграмме)
            }
            else if (o is AxisYBase)
            {
                index = ((XYDiagram)ChartControl.Diagram).SecondaryAxesY.IndexOf((AxisYBase)o) + 1; //потому что 0 индекс у Primary Axis Y
            }
            ShowSettingsPanel(o, index);
        }

        /// <summary>
        /// </summary>
        /// <param name="o">Объект, на который пришёлся клик</param>
        /// <param name="index">Если кликнули на серию, то индекс этой серии</param>
        private void ShowSettingsPanel(object o, int index)
        {
            if (o is ChartTitle)
            {
                ShowSettings(new TitleSettings(this)
                {
                    PropertiesType = typeof (TitleProperties),
                    CurrentTitle = ChartPlaceHolder.ChartControl.Titles[0]
                }, ChartProperties.Title);
            }
            else if (o is AxisX)
            {
                ShowSettings(new XAxisSettings(this) {PropertiesType = typeof (XAxisProperties)}, ChartProperties.XAxis);
            }
            else if ((o is AxisYBase) && (index >= 0))
            {
                ShowSettings(new YAxisSettings(this) {PropertiesType = typeof (YAxisProperties), Index = index},
                    ChartProperties.YAxes[index]);
            }
            else if (o is Legend)
            {
                ShowSettings(new LegendSettings(this) {PropertiesType = typeof (LegendSettings)}, ChartProperties.LegendVisibility);
                //отступление от общего принципа
            }
            /*
            else if (o is SeriesLabelBase)
            {
                ShowSettings(new SeriesValueLabelsSettings(this) {PropertiesType = typeof (SeriesValueLabelsSettings)},
                    ChartProperties.SeriesLabelsVisibility);
            }
            */
            else if ((o is AreaSeriesView) && (index >= 0))
            {
                var f = new AreaChartSettings(this)
                {
                    PropertiesType = typeof (AreaProperties),
                    AreaSeries = (AreaSeriesView) o,
                    Index = index
                };
                ShowSettings(f, ChartProperties.Series[index].Area);
            }
            else if ((o is FullStackedBarSeriesView) && (index >= 0))
            {
                var bar = new BarChartSettings(this)
                {
                    Title =
                        EidssFields.Get("FullStackedBarChartsSettingsCaption", "Full Stacked Bar Charts Settings"),
                    PropertiesType = typeof (FullStackedBarProperties),
                    BarSeries = (FullStackedBarSeriesView) o,
                    Index = index
                };
                ShowSettings(bar, ChartProperties.Series[index].FullStackedBar);
            }
            else if ((o is StackedBarSeriesView) && (index >= 0))
            {
                var bar = new BarChartSettings(this)
                {
                    Title =
                        EidssFields.Get("StackedBarChartsSettingsCaption", "Stacked Bar Charts Settings"),
                    PropertiesType = typeof (StackedBarProperties),
                    BarSeries = (StackedBarSeriesView) o,
                    Index = index
                };
                ShowSettings(bar, ChartProperties.Series[index].StackedBar);
            }
            else if ((o is BarSeriesView) && (index >= 0))
            {
                ShowSettings(new BarChartSettings(this)
                {
                    PropertiesType = typeof (BarProperties)
                    ,
                    BarSeries = (BarSeriesView) o,
                    Index = index
                },
                    ChartProperties.Series[index].Bar);
            }
            else if ((o is StepLineSeriesView) && (index >= 0))
            {
                var line = new LineChartSettings(this)
                {
                    Title = EidssFields.Get("StepLineChartsSettingsCaption", "StepLine Charts Settings"),
                    PropertiesType = typeof (StepLineProperties),
                    LineSeries = (StepLineSeriesView) o,
                    Index = index
                };
                ShowSettings(line, ChartProperties.Series[index].StepLine);
            }
            else if ((o is SplineSeriesView) && (index >= 0))
            {
                var line = new LineChartSettings(this)
                {
                    Title = EidssFields.Get("SplineChartsSettingsCaption", "Spline Charts Settings"),
                    PropertiesType = typeof (SplineProperties),
                    LineSeries = (SplineSeriesView) o,
                    Index = index
                };
                ShowSettings(line, ChartProperties.Series[index].Spline);
            }
            else if ((o is LineSeriesView) && (index >= 0))
            {
                ShowSettings(new LineChartSettings(this)
                {
                    PropertiesType = typeof (LineProperties)
                    ,
                    LineSeries = (LineSeriesView) o,
                    Index = index
                }, ChartProperties.Series[index].Line);
            }
            else if ((o is PointSeriesView) && (index >= 0))
            {
                ShowSettings(new PointChartSettings(this)
                {
                    PropertiesType = typeof (PointProperties)
                    ,
                    PointSeries = (PointSeriesView) o,
                    Index = index
                }, ChartProperties.Series[index].Point);
            }
            else if ((o is PieSeriesView) && (index >= 0))
            {
                ShowSettings(new PieChartSettings(this)
                {
                    PropertiesType = typeof(PieProperties)
                    ,
                    PieSeries = ChartControl.Series[index]
                    ,
                    Index = index
                }, ChartProperties.Series[index].Pie);
            }
        }

        private void SaveDataFromSettingsPanel(ISettingsPanel panel)
        {
            /*
            if (panel.PropertiesType == typeof (LegendSettings))
            {
                ChartProperties.LegendVisibility = (bool) panel.ToProperties();
            }
            else if (panel.PropertiesType == typeof (SeriesValueLabelsSettings))
            {
                ChartProperties.SeriesLabelsVisibility = (bool) panel.ToProperties();
            }
            else 
            */
            if (panel.PropertiesType == typeof (TitleProperties))
            {
                ChartProperties.Title = (TitleProperties) panel.ToProperties();
            }
            else if (panel.PropertiesType == typeof (XAxisProperties))
            {
                ChartProperties.XAxis = (XAxisProperties) panel.ToProperties();
            }
            else if (panel.PropertiesType == typeof (YAxisProperties))
            {
                ChartProperties.YAxes[panel.Index] = (YAxisProperties) panel.ToProperties();
            }
            else if (panel.PropertiesType == typeof (AreaProperties))
            {
                ChartProperties.Series[panel.Index].Area = (AreaProperties) panel.ToProperties();
            }
            else if (panel.PropertiesType == typeof (FullStackedBarProperties))
            {
                var obj = (IBarProperties) panel.ToProperties();
                ChartProperties.Series[panel.Index].FullStackedBar = (FullStackedBarProperties) obj;
            }
            else if (panel.PropertiesType == typeof (StackedBarProperties))
            {
                var obj = (IBarProperties) panel.ToProperties();
                ChartProperties.Series[panel.Index].StackedBar = (StackedBarProperties) obj;
            }
            else if (panel.PropertiesType == typeof (BarProperties))
            {
                var obj = (IBarProperties) panel.ToProperties();
                ChartProperties.Series[panel.Index].Bar = (BarProperties) obj;
            }
            else if (panel.PropertiesType == typeof (StepLineProperties))
            {
                var obj = (ILineProperties) panel.ToProperties();
                ChartProperties.Series[panel.Index].StepLine = (StepLineProperties) obj;
            }
            else if (panel.PropertiesType == typeof (SplineProperties))
            {
                var obj = (ILineProperties) panel.ToProperties();
                ChartProperties.Series[panel.Index].Spline = (SplineProperties) obj;
            }
            else if (panel.PropertiesType == typeof (LineProperties))
            {
                var obj = (ILineProperties) panel.ToProperties();
                ChartProperties.Series[panel.Index].Line = (LineProperties) obj;
            }
            else if (panel.PropertiesType == typeof (PointProperties))
            {
                ChartProperties.Series[panel.Index].Point = (PointProperties) panel.ToProperties();
            }
        }

        private void ShowSettings(ISettingsPanel panel, object properties)
        {
            //сохраняем настройки в объект
            if (scrollableMain.Controls.Count == 1) EndEdit();
            scrollableMain.SuspendLayout();
            scrollableMain.Controls.Clear();
            panel.Init(properties);
            var ctr = (Control) panel;
            scrollableMain.Controls.Add(ctr);
            ctr.Dock = DockStyle.Fill;
            scrollableMain.ResumeLayout();
        }

        /// <summary>
        /// </summary>
        public void SetupChart()
        {
            #region Актуализация серий

            //удаляем настройки серий, которых больше нет
            for (var index = ChartProperties.Series.Count; index > ChartControl.Series.Count; index--)
            {
                ChartProperties.Series.RemoveAt(index - 1);
            }

            //добавляем хранилища настроек для каждой серии
            var colorList = new[]
                {
                    Color.FromArgb(235, 210, 155)
                    , Color.FromArgb(190, 220, 145)
                    , Color.FromArgb(230, 175, 150)
                    , Color.FromArgb(195, 235, 170)
                    , Color.FromArgb(210, 165, 150)
                    , Color.FromArgb(140, 205, 140)
                    , Color.FromArgb(215, 215, 135)
                    , Color.FromArgb(235, 220, 165)
                    , Color.FromArgb(165, 215, 190)
                    , Color.FromArgb(235, 220, 190)
                    , Color.FromArgb(190, 230, 225)
                    , Color.FromArgb(250, 210, 195)
                };

            var colorIndex = 0;
            for (var index = ChartProperties.Series.Count; index < ChartControl.Series.Count; index++)
            {
                var series = new SeriesProperties();
                series.SetColors(colorList[colorIndex].ToArgb());
                ChartProperties.Series.Add(series);
                series.Index = ChartProperties.Series.Count - 1;
                colorIndex++;
                if (colorIndex > colorList.Length - 1)
                {
                    colorIndex = 0;
                }
            }

            #endregion

            if (!ChartProperties.Title.TextWasChanged)
            {
                ChartProperties.Title.Text = ChartTitle; //LayoutTitle.DataTitle;
            }

            if (!ChartProperties.XAxis.AxisProperties.Title.TextWasChanged)
            {
                ChartProperties.XAxis.AxisProperties.Title.Text = XAxisTitle; //LayoutTitle.RowTitle;
            }

            foreach (var axis in ChartProperties.YAxes)
            {
                if (!axis.AxisProperties.Title.TextWasChanged)
                {
                    axis.AxisProperties.Title.Text = String.Empty; //LayoutTitle.ColumnTitle;
                }
            }

            TitleSettings.SetupChart(ChartPlaceHolder.ChartControl.Titles[0], ChartProperties.Title);

            var axisX = ChartPlaceHolder.AxisX;
            if (axisX != null)
            {
                axisX.VisualRange.Auto = true;
                axisX.VisualRange.AutoSideMargins = true;
                XAxisSettings.SetupChart(axisX, ChartProperties.XAxis);
            }

            var axisY = ChartPlaceHolder.AxisY;
            var diagram = ChartPlaceHolder.ChartControl.Diagram as XYDiagram;
            if (axisY != null)
            {
                axisY.VisualRange.AutoSideMargins = true;

                if (ChartProperties.YAxes.Count == 0)
                {
                    //добавляем primary axis y, которая есть всегда
                    ChartProperties.YAxes.Add(new YAxisProperties());
                }
                
                if ((ChartProperties.YAxes.Count == 1) && (diagram != null))
                {
                    //также добавляем сразу одну вторичную ось, которая согласно задаче 9686 тоже есть всегда
                    ChartProperties.YAxes.Add(new YAxisProperties {Position = 1});
                    var secondaryAxes = diagram.SecondaryAxesY;
                    secondaryAxes.Add(new SecondaryAxisY());
                }

                YAxisSettings.SetupChart(this, axisY, ChartProperties.YAxes[0]);
            }
            if (diagram != null)
            {
                var secondaryAxes = ((XYDiagram) ChartPlaceHolder.ChartControl.Diagram).SecondaryAxesY;
                //если вторичных осей меньше, чем ранее сохранённых, то воссоздаём недостающие
                var cntAxis = secondaryAxes.Count;
                for (var index = cntAxis; index < ChartProperties.YAxes.Count - 1; index++)
                {
                    var a = new SecondaryAxisY();
                    a.VisualRange.AutoSideMargins = false;
                    //a.Range.SideMarginsEnabled = false;
                    secondaryAxes.Add(a);
                }
                //настраиваем каждую вторичную ось
                for (var index = 0; index < secondaryAxes.Count; index++)
                {
                    if (index + 1 > ChartProperties.YAxes.Count) break;
                    YAxisSettings.SetupChart(this, secondaryAxes[index], ChartProperties.YAxes[index + 1]);
                }
            }

            ceLegendVisibility.CheckedChanged -= ceLegendVisibility_CheckedChanged;
            ceLegendVisibility.Checked = ChartPlaceHolder.ChartControl.Legend.Visible = ChartProperties.LegendVisibility;
            ceLegendVisibility.CheckedChanged += ceLegendVisibility_CheckedChanged;

            ce3D.CheckedChanged -= ce3D_CheckedChanged;
            ce3D.Checked = false;
            if (ChartProperties.Series.Count > 0)
            {
                var serp = ChartProperties.Series[0];
                
                //либо все серии 3D, либо ни одна. Иначе никак.
                var vt = (ViewType) Enum.Parse(typeof (ViewType), serp.ViewType.ToString());
                ce3D.Checked = vt.ToString().Contains("3D");
                if (ce3D.Checked)
                {
                    ChartControl.SeriesTemplate.ChangeView(vt);
                    SetupDiagram();
                }
                else if (BaseSeriesSettings.IsPieType(vt) || BaseSeriesSettings.IsFullStackedBarType(vt))
                {
                    //определяем, какие серии, нужно ли делать кольцевую диаграмму
                    ChartControl.SeriesTemplate.ChangeView(vt);
                    SetupDiagram();
                }
            }
            ce3D.CheckedChanged += ce3D_CheckedChanged;

            //донастройка серий
            for (var index = 0; index < ChartControl.Series.Count; index++)
            {
                var series = ChartControl.Series[index];
                var props = ChartProperties.Series[index];
                series.LabelsVisibility = props.SeriesLabelsVisibility ? DefaultBoolean.True : DefaultBoolean.False;
                series.ChangeView((ViewType) Enum.Parse(typeof (ViewType), props.ViewType.ToString()));
                //
                SetupSeries(series, props);
            }

            SetupDiagram();
            SetSecondaryAxisVisibilityState();

            //встаём либо на первую серию, либо за заголовок диаграммы
            if (ChartControl.Series.Count > 0)
            {
                ShowSettingsPanel(ChartControl.Series[0].View, 0);
            }
            else if (ChartPlaceHolder.ChartControl.Titles.Count > 0)
            {
                ShowSettingsPanel(ChartPlaceHolder.ChartControl.Titles[0], 0);
            }

            //обновляем перечень серий в комбобоксе
            FillSeriesList();
        }

        internal void SetSecondaryAxisVisibilityState()
        {
            //чтобы вторичная ось была видимой, должна быть хотя бы одна серия, которая к ней привязана
            var diagram = ChartPlaceHolder.ChartControl.Diagram as XYDiagram;
            if (diagram == null) return;
            var secondaryAxes = diagram.SecondaryAxesY;
            if (secondaryAxes.Count < 1) return;
            secondaryAxes[0].Visible = ChartProperties.Series.Any(s => s.AxisYIndex == 1);
        }

        private void FillSeriesList()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Index", typeof (int)));
            dt.Columns.Add(new DataColumn("Text", typeof(string)));
            for (var index = 0; index < ChartControl.Series.Count; index++)
            {
                var ser = ChartControl.Series[index];
                var row = dt.NewRow();
                row["Index"] = index;
                row["Text"] = ser.LegendText;
                dt.Rows.Add(row);
            }
            leSeries.Properties.DataSource = dt;
            if (dt.Rows.Count > 0) leSeries.EditValue = 0;
        }

        internal void SetupSeries(Series series, SeriesProperties props)
        {
            var view = series.View;
            if (view is AreaSeriesView)
            {
                AreaChartSettings.SetupChart((AreaSeriesView) view, props.Area);
            }
            else if (view is FullStackedBarSeriesView)
            {
                BarChartSettings.SetupChart((FullStackedBarSeriesView) view, props.FullStackedBar);
            }
            else if (view is StackedBarSeriesView)
            {
                BarChartSettings.SetupChart((StackedBarSeriesView) view, props.StackedBar);
            }
            else if (view is BarSeriesView)
            {
                BarChartSettings.SetupChart((BarSeriesView) view, props.Bar);
            }
            else if (view is StepLineSeriesView)
            {
                LineChartSettings.SetupChart((StepLineSeriesView) view, props.StepLine);
            }
            else if (view is SplineSeriesView)
            {
                LineChartSettings.SetupChart((SplineSeriesView) view, props.Spline);
            }
            else if (view is LineSeriesView)
            {
                LineChartSettings.SetupChart((LineSeriesView) view, props.Line);
            }
            else if (view is PointSeriesView)
            {
                PointChartSettings.SetupChart((PointSeriesView) view, props.Point);
            }
            else if (view is PieSeriesView)
            {
                PieChartSettings.SetupChart(ChartControl, series/*(SimplePointOptions)series.LegendPointOptions*/, props.Pie);
            }
            //всем сериям проставляем правильные заголовки
            series.CrosshairEnabled = DefaultBoolean.True;
            var caption = GetSeriesCaption(series.Name);
            series.CrosshairLabelPattern = caption + ": {V}";
            series.LegendText = caption;
            //восстанавливаем настройки показа лейблов
            series.LabelsVisibility = props.SeriesLabelsVisibility ? DefaultBoolean.True : DefaultBoolean.False;
            //выставляем нужную ось
            var diagram = ChartPlaceHolder.ChartControl.Diagram as XYDiagram;
            if (diagram == null) return;
            var secondaryAxes = diagram.SecondaryAxesY;
            
            var axis = props.AxisYIndex == 0 ? diagram.AxisY : (AxisYBase)secondaryAxes[props.AxisYIndex - 1];
            var xyview = series.View as XYDiagramSeriesViewBase;
            if (xyview != null) xyview.AxisY = axis;
        }

        internal void SetupDiagram()
        {
            if (ChartControl.Diagram is Diagram3D)
            {
                var diagram = (Diagram3D)ChartControl.Diagram;
                diagram.RuntimeRotation = true;
                diagram.RuntimeZooming = true;
                diagram.RuntimeScrolling = true;
            }
            else if (ChartControl.Diagram is XYDiagram)
            {
                var diagram = (XYDiagram)ChartControl.Diagram;
                diagram.AxisX.Title.Visible = true;
                diagram.AxisY.Title.Visible = true;
                diagram.EnableAxisXScrolling = true;
                diagram.EnableAxisXZooming = true;
                diagram.EnableAxisYScrolling = true;
                diagram.EnableAxisYZooming = true;
            }
            /*
            else if (ChartControl.Diagram is SimpleDiagram)
                {
                var diagram = (SimpleDiagram)ChartControl.Diagram;
                }
            */
            }

        /// <summary>
        /// </summary>
        /// <param name="seriesName"></param>
        /// <returns></returns>
        internal string GetSeriesCaption(string seriesName)
            {
            var result = String.Empty;
            var rows = DataTableSource.Select(String.Format("[{0}]='{1}'", SeriesName, seriesName));
            if (rows.Length > 0)
            {
                result = rows[0][SeriesCaption].ToString();
            }
            return result;
        }

        /// <summary>
        ///     Определяет индекс указанной оси в общем списке
        /// </summary>
        /// <returns></returns>
        public int GetAxisYIndex(AxisBase axisYBase)
        {
            int result;
            if (ChartPlaceHolder.AxisY == axisYBase)
            {
                result = 0;
            }
            else
            {
                var secondaryAxes = ((XYDiagram) ChartPlaceHolder.ChartControl.Diagram).SecondaryAxesY;
                result = secondaryAxes.IndexOf(axisYBase) + 1;
            }
            return result;
        }

        public void ExportChart()
        {
            m_ChartPresenter.ExportChart();
        }

        public void PrintChart()
        {
            m_ChartPresenter.PrintChart(printingSystem);
        }

        private void ceLegendVisibility_CheckedChanged(object sender, EventArgs e)
        {
            ChartPlaceHolder.ChartControl.Legend.Visible = ChartProperties.LegendVisibility = ceLegendVisibility.Checked;
        }

        private void ce3D_CheckedChanged(object sender, EventArgs e)
        {
            EndEdit();
            if (ChartProperties.Series.Count == 0) return;
            //2D/3D ИД отличаются на 1
            //обходим все серии и переключаем их в другой режим
            var i = ce3D.Checked ? 1 : -1;
            var series0 = ChartProperties.Series[0];
            var vt = (ViewType)Enum.Parse(typeof(ViewType), series0.ViewType.ToString());
            ViewType vt2;
            if (vt == ViewType.Doughnut || vt == ViewType.Pie)
            {
                vt2 = ViewType.Pie3D;
            }
            else if (vt == ViewType.Doughnut3D || vt == ViewType.Pie3D)
            {
                vt2 = ViewType.Pie;
            }
            else if (vt == ViewType.Point)
            {
                vt2 = ViewType.Line3D;
            }
            else
            {
                vt2 = ce3D.Checked ? ViewType.Line3D : ViewType.Line;
            }

            ChartControl.SeriesTemplate.ChangeView(vt2);
            SetupDiagram();
            var diagram = ChartPlaceHolder.ChartControl.Diagram as XYDiagram;
            for (var index = 0; index < ChartProperties.Series.Count; index++)
            {
                var seriesProps = ChartProperties.Series[index];
                var series = ChartControl.Series[index];
                vt = (ViewType)Enum.Parse(typeof(ViewType), seriesProps.ViewType.ToString());
                if (vt == ViewType.Point) vt = ViewType.Line; //Point не поддерживает перевод в 3D и обратно, потому меняем его на Line
                var dt = Enum.Parse(typeof (DBChartType), "chr" + vt);
                var dtNew = Enum.Parse(typeof (DBChartType), ((long) dt + i).ToString());
                var viewType = ChartPresenter.GetChartType((long)dtNew);
                
                series.ChangeView(viewType);
                seriesProps.ViewType = (int) viewType;
                SetupSeries(series, seriesProps);
                //возвращает серии правильную вторичную ось
                if (diagram != null)
                {
                    var view = series.View as XYDiagramSeriesViewBase;
                    if ((view != null) && (seriesProps.AxisYIndex > 0))
                    {
                        view.AxisY = diagram.SecondaryAxesY[0];
                    } 
                }
            }
            //показываем адекватный перечень доступных типов графика
            if (scrollableMain.Controls.Count > 0)
            {
                var settings = scrollableMain.Controls[0] as BaseSeriesSettings;
                if (settings != null)
                {
                    settings.FillChartTypes();
                    settings.SetParentSeriesViewType();
                    settings.SetChangeAxisAbility(!ce3D.Checked);
                }
            }
            //возвращает диаграмму в "нулевой зум"
            var diag = ChartControl.Diagram as XYDiagram;
            if (diag != null)
            {
                diag.AxisX.VisualRange.Auto = false;
                diag.AxisX.VisualRange.Auto = true;
                diag.AxisY.VisualRange.Auto = false;
                diag.AxisY.VisualRange.Auto = true;
            }
        }

        private void leSeries_EditValueChanged(object sender, EventArgs e)
        {
            if (leSeries.EditValue == null) return;
            var index = Convert.ToInt32(leSeries.EditValue);
            var ser = ChartControl.Series[index];
            ShowSettingsPanel(ser);
        }
    }
}