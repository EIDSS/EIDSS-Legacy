namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    partial class DataQualityIndicatorsChartReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataQualityIndicatorsChartReport));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.m_DQIChartDataSet = new EIDSS.Reports.Parameterized.Human.AJ.DataSets.DQIChartDataSet();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.OrganizationNameLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.DateTimeLabel = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DQIChartDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // cellLanguage
            // 
            this.cellLanguage.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.cellLanguage, "cellLanguage");
            // 
            // lblReportName
            // 
            resources.ApplyResources(this.lblReportName, "lblReportName");
            this.lblReportName.StylePriority.UseBorders = false;
            this.lblReportName.StylePriority.UseBorderWidth = false;
            this.lblReportName.StylePriority.UseFont = false;
            this.lblReportName.StylePriority.UseTextAlignment = false;
            // 
            // Detail
            // 
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            // 
            // PageHeader
            // 
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UsePadding = false;
            // 
            // PageFooter
            // 
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.StylePriority.UseBorders = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DateTimeLabel,
            this.OrganizationNameLabel,
            this.xrChart1});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Controls.SetChildIndex(this.xrChart1, 0);
            this.ReportHeader.Controls.SetChildIndex(this.tableBaseHeader, 0);
            this.ReportHeader.Controls.SetChildIndex(this.OrganizationNameLabel, 0);
            this.ReportHeader.Controls.SetChildIndex(this.DateTimeLabel, 0);
            // 
            // xrPageInfo1
            // 
            resources.ApplyResources(this.xrPageInfo1, "xrPageInfo1");
            this.xrPageInfo1.StylePriority.UseBorders = false;
            // 
            // cellReportHeader
            // 
            this.cellReportHeader.StylePriority.UseBorders = false;
            this.cellReportHeader.StylePriority.UseFont = false;
            this.cellReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // cellBaseSite
            // 
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.cellBaseSite, "cellBaseSite");
            // 
            // cellBaseCountry
            // 
            this.cellBaseCountry.StylePriority.UseFont = false;
            resources.ApplyResources(this.cellBaseCountry, "cellBaseCountry");
            // 
            // tableBaseHeader
            // 
            resources.ApplyResources(this.tableBaseHeader, "tableBaseHeader");
            this.tableBaseHeader.StylePriority.UseBorders = false;
            this.tableBaseHeader.StylePriority.UseBorderWidth = false;
            this.tableBaseHeader.StylePriority.UseFont = false;
            this.tableBaseHeader.StylePriority.UsePadding = false;
            this.tableBaseHeader.StylePriority.UseTextAlignment = false;
            // 
            // xrChart1
            // 
            resources.ApplyResources(this.xrChart1, "xrChart1");
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart1.DataMember = "ChartData";
            this.xrChart1.DataSource = this.m_DQIChartDataSet;
            xyDiagram1.AxisX.GridLines.MinorColor = System.Drawing.Color.White;
            xyDiagram1.AxisX.Label.Angle = ((int)(resources.GetObject("resource.Angle")));
            xyDiagram1.AxisX.Label.Antialiasing = true;
            xyDiagram1.AxisX.Label.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font")));
            xyDiagram1.AxisX.Label.TextAlignment = ((System.Drawing.StringAlignment)(resources.GetObject("resource.TextAlignment")));
            xyDiagram1.AxisX.MinorCount = 1;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisX.Title.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font1")));
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.GridSpacing = 0.2D;
            xyDiagram1.AxisY.GridSpacingAuto = false;
            xyDiagram1.AxisY.Label.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font2")));
            xyDiagram1.AxisY.MinorCount = 1;
            xyDiagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            xyDiagram1.AxisY.NumericOptions.Precision = 1;
            xyDiagram1.AxisY.Range.Auto = false;
            xyDiagram1.AxisY.Range.MaxValueSerializable = "5.9";
            xyDiagram1.AxisY.Range.MinValueSerializable = "0";
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisY.Title.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font3")));
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Name = "xrChart1";
            series1.ArgumentDataMember = "RayonName";
            sideBySideBarSeriesLabel1.LineVisible = true;
            sideBySideBarSeriesLabel1.Visible = false;
            series1.Label = sideBySideBarSeriesLabel1;
            resources.ApplyResources(series1, "series1");
            series1.ShowInLegend = false;
            series1.ValueDataMembersSerializable = "Value";
            sideBySideBarSeriesView1.BarWidth = 0.5D;
            sideBySideBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            sideBySideBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            sideBySideBarSeriesView1.Transparency = ((byte)(50));
            series1.View = sideBySideBarSeriesView1;
            series2.ArgumentDataMember = "RayonName";
            pointSeriesLabel1.LineVisible = true;
            pointSeriesLabel1.Visible = false;
            series2.Label = pointSeriesLabel1;
            resources.ApplyResources(series2, "series2");
            series2.ShowInLegend = false;
            series2.ValueDataMembersSerializable = "AverageValue";
            lineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            lineSeriesView1.LineMarkerOptions.Visible = false;
            lineSeriesView1.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dash;
            series2.View = lineSeriesView1;
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            sideBySideBarSeriesLabel2.LineVisible = true;
            this.xrChart1.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            // 
            // m_DQIChartDataSet
            // 
            this.m_DQIChartDataSet.DataSetName = "DQIChartDataSet";
            this.m_DQIChartDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Name = "ReportFooter";
            // 
            // OrganizationNameLabel
            // 
            this.OrganizationNameLabel.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.OrganizationNameLabel.CanGrow = false;
            this.OrganizationNameLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sprepGetBaseParameters.SiteName")});
            resources.ApplyResources(this.OrganizationNameLabel, "OrganizationNameLabel");
            this.OrganizationNameLabel.Name = "OrganizationNameLabel";
            this.OrganizationNameLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrganizationNameLabel.StylePriority.UseFont = false;
            this.OrganizationNameLabel.StylePriority.UseTextAlignment = false;
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.DateTimeLabel.CanGrow = false;
            resources.ApplyResources(this.DateTimeLabel, "DateTimeLabel");
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DateTimeLabel.StylePriority.UseFont = false;
            this.DateTimeLabel.StylePriority.UseTextAlignment = false;
            // 
            // DataQualityIndicatorsChartReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.ReportFooter});
            this.CanWorkWithArchive = true;
            resources.ApplyResources(this, "$this");
            this.Version = "11.1";
            this.Controls.SetChildIndex(this.ReportFooter, 0);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.PageFooter, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DQIChartDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion


        protected EIDSS.Reports.Parameterized.Human.AJ.DataSets.DQIChartDataSet m_DQIChartDataSet;
        protected DevExpress.XtraReports.UI.XRChart xrChart1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        protected DevExpress.XtraReports.UI.XRLabel DateTimeLabel;
        protected DevExpress.XtraReports.UI.XRLabel OrganizationNameLabel;

    }
}
