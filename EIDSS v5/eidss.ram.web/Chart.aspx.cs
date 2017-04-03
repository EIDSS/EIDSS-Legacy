using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using DevExpress.XtraCharts;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.DBService.Enumerations;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using eidss.model.Resources;
using eidss.ram.web.Components;
using eidss.ram.web.Components.Export;

namespace eidss.ram.web
{
    public partial class Chart : BasePage
    {
        private WebChartExporter m_ChartExporter;

        public WebRamFormView WebRamForm
        {
            get
            {
                if (Session[WebRamFormView.SessionObjectName] == null)
                {
                    Session[WebRamFormView.SessionObjectName] = new WebRamFormView(this, PivotGrid, false);
                }
                return (WebRamFormView) Session[WebRamFormView.SessionObjectName];
            }
        }

        private WebExportFormat WebExportFormat
        {
            get { return ((WebExportFormat) int.Parse(listExportFormat.SelectedItem.Value.ToString())); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RamPivotGrid winPivotGrid = WebRamForm.WinPivotGrid;

            bool isToBig = winPivotGrid.Cells.ColumnCount * winPivotGrid.Cells.RowCount > RamPivotGrid.MaxChartItemCount;
            if (isToBig)
            {
                WarningLabel.Text = string.Format(EidssMessages.Get("msgTooBigLayoutForChart"), RamPivotGrid.MaxChartItemCount);
                MainPanel.Visible = false;
                winPivotGrid.Cells.Selection = new Rectangle(0, 0, 1, 1);
            }
            else
            {
                winPivotGrid.Cells.Selection = new Rectangle(0, 0, winPivotGrid.Cells.ColumnCount, winPivotGrid.Cells.RowCount);
            }

            PivotGrid.CreateWebPivotGridFrom(winPivotGrid);
            if (!IsPostBack && !Page.IsCallback)
            {
                PivotGrid.Criteria = (WebRamForm.IsChartCriteriaChanged)
                                         ? WebRamForm.ChartCriteria
                                         : winPivotGrid.Criteria;

                if (string.IsNullOrEmpty(CaptionTextBox.Text))
                {
                    CaptionTextBox.Text = WebRamForm.ChartName;
                }
                PivotDiagramAxis.Checked = WebRamForm.PivotAxis;
                PointLabels.Checked = WebRamForm.ShowPointLabels;

                SetHeader();

                InitChartTypeItems(WebRamForm.ChartType);

                SetChartType(WebRamForm.ChartType);

                FilterCaption.Text = PivotGrid.FriendlyCriteriaString;

                PivotGrid.OptionsView.ShowFilterHeaders = false;
                PivotGrid.OptionsChartDataSource.ProvideColumnGrandTotals = ShowColumnGrandTotals.Checked;
                PivotGrid.OptionsChartDataSource.ProvideRowGrandTotals = ShowRowGrandTotals.Checked;
                PivotGrid.OptionsChartDataSource.ProvideDataByColumns = !PivotDiagramAxis.Checked;
                WebChart.SeriesTemplate.Label.Visible = PointLabels.Checked;
            }

            PivotGrid.AggregateTable = WebRamForm.AggregateTable;
            PivotGrid.DenominatorIndexes = PivotPresenter.GetIndexesDictionary(WebRamForm.AggregateTable,
                                                                               PivotGrid.Fields);
            //
            if (!isToBig)
            {
                PivotGrid.DataSource = WebRamForm.PivotPreparedDataSource;
            }
            PivotGrid.NameSummaryTypeDictionary = WebRamForm.PreparedNameSummaryTypeDictionary;

            m_ChartExporter = new WebChartExporter(this, WebChart);

            WebChart.CustomDrawAxisLabel += WebChart_CustomDrawAxisLabel;
            WebChart.CustomDrawSeries += WebChart_CustomDrawSeries;
            WebChart.CustomDrawSeriesPoint += WebChart_CustomDrawSeriesPoint;

            SetChartTitles(winPivotGrid.ChartTitle);

            if (!string.IsNullOrEmpty(Request.QueryString["open"]))
            {
                int formatId = int.Parse(Request.QueryString["open"]);
                m_ChartExporter.Export(((WebExportFormat) formatId),
                                       PivotGrid.DataSource.TableName,
                                       new List<string> {CaptionTextBox.Text, FilterCaption.Text},
                                       false);
            }
        }

        protected void PivotGrid_PrefilterCriteriaChanged(object sender, EventArgs e)
        {
            WebRamForm.ChartCriteria = PivotGrid.Criteria;
            WebRamForm.WinPivotGrid.Criteria = PivotGrid.Criteria;
            FilterCaption.Text = PivotGrid.FriendlyCriteriaString;
        }

        protected void UseArchive_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void buttonSaveAs_Click(object sender, EventArgs e)
        {
            m_ChartExporter.Export(WebExportFormat,
                                   PivotGrid.DataSource.TableName,
                                   new List<string> {CaptionTextBox.Text, FilterCaption.Text},
                                   true);
        }

        private void InitChartTypeItems(DBChartType value)
        {
            DataView chartType = LookupCache.Get(BaseReferenceType.rftChart.ToString());

            ChartType.DataSource = chartType;
            ChartType.ValueField = "idfsReference";
            ChartType.TextField = "name";
            ChartType.DataBind();

            string strvalue = ((long) value).ToString(CultureInfo.InvariantCulture);
            ChartType.SelectedItem = ChartType.Items.FindByValue(strvalue);
        }

        private void SetChartTitles(PivotChartTitle title)
        {
            var xyDiagram = WebChart.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                AxisX axisX = (xyDiagram).AxisX;
                axisX.Title.Visible = true;
                axisX.Title.Text = PivotDiagramAxis.Checked ? title.ColumnTitle : title.RowTitle;

                AxisY axisY = (xyDiagram).AxisY;
                axisY.Title.Visible = true;
                axisY.Title.Text = title.DataTitle;
            }
        }

        private void SetChartType(DBChartType value)
        {
            ViewType chartType = ChartPresenter.GetChartType(value);
            WebChart.SeriesTemplate.ChangeView(chartType);
            if (WebChart.SeriesTemplate.Label != null)
            {
                PointLabels.Enabled = true;
                WebChart.SeriesTemplate.Label.Visible = PointLabels.Checked;
            }
            else
            {
                PointLabels.Enabled = false;
            }

            var xyDiagram = WebChart.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                AxisX axisX = (xyDiagram).AxisX;
                axisX.Label.Angle = 20;
                axisX.Label.Antialiasing = true;
                axisX.Range.SideMarginsEnabled = false;

                AxisY axisY = (xyDiagram).AxisY;
                axisY.Label.Antialiasing = true;
                axisY.Range.SideMarginsEnabled = true;
            }
        }

        protected void WebChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            ChartControlMediator.ChartControl_CustomDrawSeriesPoint(sender, WebChart.Diagram, e);
        }

        protected static void WebChart_CustomDrawSeries(object sender, CustomDrawSeriesEventArgs e)
        {
            ChartControlMediator.ChartControl_CustomDrawSeries(sender, e);
        }

        protected static void WebChart_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            ChartControlMediator.ChartControl_CustomDrawAxisLabel(sender, e);
        }

        protected void ASPxPivotGrid_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // SetFilter(fieldCategoryName, 4);
            }
        }

        protected void PointLabels_CheckedChanged(object sender, EventArgs e)
        {
            WebChart.SeriesTemplate.Label.Visible = PointLabels.Checked;
        }

        protected void ChartType_ValueChanged(object sender, EventArgs e)
        {
            if (ChartType.SelectedItem != null)
            {
                string selectedValue = ChartType.SelectedItem.Value.ToString();
                var chartType = (DBChartType) long.Parse(selectedValue);
                SetChartType(chartType);

                var diagram = WebChart.Diagram as XYDiagram;
                if (diagram != null)
                {
                    diagram.AxisX.Range.SideMarginsEnabled = (chartType == DBChartType.chrBar);
                }
            }
        }

        protected void ShowColumnGrandTotals_CheckedChanged(object sender, EventArgs e)
        {
            PivotGrid.OptionsChartDataSource.ProvideColumnGrandTotals = ShowColumnGrandTotals.Checked;
        }

        protected void ShowRowGrandTotals_CheckedChanged(object sender, EventArgs e)
        {
            PivotGrid.OptionsChartDataSource.ProvideRowGrandTotals = ShowRowGrandTotals.Checked;
        }

        protected void PivotDiagramAxis_CheckedChanged(object sender, EventArgs e)
        {
            PivotGrid.OptionsChartDataSource.ProvideDataByColumns = !PivotDiagramAxis.Checked;
        }

        private void SetHeader()
        {
            if (Master != null)
            {
                string queryPath = string.Format("{0}->{1}", "AVR", WebRamForm.QueryName);
                string layoutPath = string.Format("{0}->{1}", queryPath, WebRamForm.LayoutName);
                var master = ((SiteMaster) Master);
                master.QueryPathText = queryPath;
                master.LayoutHeaderText = layoutPath;
                if (!Utils.IsEmpty(Session[WebRamFormView.LayoutWarning]))
                {
                    master.LayoutWarningText = Session[WebRamFormView.LayoutWarning].ToString();
                }
            }
        }
    }
}