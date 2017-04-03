namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    partial class BaseDataQualityIndicatorsReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDataQualityIndicatorsReport));
            this.HeaderLabal = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeaderRegion = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.DetailDynamicTable = new DevExpress.XtraReports.UI.XRTable();
            this.DetailDynamicTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.RegionDetailCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.RayonDetailCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DiagnosisDetailCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.TotalDynamicTable = new DevExpress.XtraReports.UI.XRTable();
            this.TotalDynamicRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DiagnosisTotalCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.m_DQIChartDataSet = new EIDSS.Reports.Parameterized.Human.AJ.DataSets.DQIChartDataSet();
            this.GroupFooterRayon = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.HeaderPeriodLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeaderRayon = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeaderLine = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooterLine = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooterRegion = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.MaximumDynamicTable = new DevExpress.XtraReports.UI.XRTable();
            this.MaximumDynamicRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DiagnosisMaxCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DiagnosisHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.RayonHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.RegionHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DynamicTopTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderDynamicTable = new DevExpress.XtraReports.UI.XRTable();
            this.m_DQIAdapter = new EIDSS.Reports.Parameterized.Human.AJ.DataSets.DQIDataSetTableAdapters.spRepHumDataQualityIndicatorsTableAdapter();
            this.m_DQIDataSet = new EIDSS.Reports.Parameterized.Human.AJ.DataSets.DQIDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.tableInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailDynamicTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDynamicTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DQIChartDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumDynamicTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDynamicTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DQIDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // tableInterval
            // 
            this.tableInterval.StylePriority.UseBorders = false;
            this.tableInterval.StylePriority.UseFont = false;
            this.tableInterval.StylePriority.UsePadding = false;
            // 
            // cellLanguage
            // 
            this.cellLanguage.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.cellLanguage, "cellLanguage");
            // 
            // lblReportName
            // 
            this.lblReportName.StylePriority.UseBorders = false;
            this.lblReportName.StylePriority.UseBorderWidth = false;
            this.lblReportName.StylePriority.UseFont = false;
            this.lblReportName.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.lblReportName, "lblReportName");
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DetailDynamicTable});
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
            this.MaximumDynamicTable,
            this.HeaderPeriodLabel,
            this.HeaderLabal,
            this.HeaderDynamicTable});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Controls.SetChildIndex(this.HeaderDynamicTable, 0);
            this.ReportHeader.Controls.SetChildIndex(this.HeaderLabal, 0);
            this.ReportHeader.Controls.SetChildIndex(this.HeaderPeriodLabel, 0);
            this.ReportHeader.Controls.SetChildIndex(this.MaximumDynamicTable, 0);
            this.ReportHeader.Controls.SetChildIndex(this.tableBaseHeader, 0);
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
            // HeaderLabal
            // 
            this.HeaderLabal.BorderWidth = 1;
            this.HeaderLabal.CanGrow = false;
            resources.ApplyResources(this.HeaderLabal, "HeaderLabal");
            this.HeaderLabal.Name = "HeaderLabal";
            this.HeaderLabal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderLabal.StylePriority.UseBorders = false;
            this.HeaderLabal.StylePriority.UseBorderWidth = false;
            this.HeaderLabal.StylePriority.UseFont = false;
            this.HeaderLabal.StylePriority.UseTextAlignment = false;
            // 
            // GroupHeaderRegion
            // 
            this.GroupHeaderRegion.BorderWidth = 0;
            this.GroupHeaderRegion.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("intRegionOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("strRegion", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            resources.ApplyResources(this.GroupHeaderRegion, "GroupHeaderRegion");
            this.GroupHeaderRegion.Level = 1;
            this.GroupHeaderRegion.Name = "GroupHeaderRegion";
            this.GroupHeaderRegion.StylePriority.UseBorderWidth = false;
            this.GroupHeaderRegion.StylePriority.UsePadding = false;
            // 
            // DetailDynamicTable
            // 
            this.DetailDynamicTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            resources.ApplyResources(this.DetailDynamicTable, "DetailDynamicTable");
            this.DetailDynamicTable.Name = "DetailDynamicTable";
            this.DetailDynamicTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.DetailDynamicTableRow});
            this.DetailDynamicTable.StylePriority.UseBorders = false;
            this.DetailDynamicTable.StylePriority.UsePadding = false;
            this.DetailDynamicTable.StylePriority.UseTextAlignment = false;
            // 
            // DetailDynamicTableRow
            // 
            this.DetailDynamicTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.RegionDetailCell,
            this.RayonDetailCell,
            this.DiagnosisDetailCell});
            this.DetailDynamicTableRow.Name = "DetailDynamicTableRow";
            this.DetailDynamicTableRow.Weight = 1.0595311402299177D;
            // 
            // RegionDetailCell
            // 
            this.RegionDetailCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepHumDataQualityIndicators.strRegion")});
            this.RegionDetailCell.Name = "RegionDetailCell";
            resources.ApplyResources(this.RegionDetailCell, "RegionDetailCell");
            this.RegionDetailCell.Weight = 0.078406197604553307D;
            this.RegionDetailCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.RegionDetailCell_BeforePrint);
            // 
            // RayonDetailCell
            // 
            this.RayonDetailCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepHumDataQualityIndicators.strRayon")});
            this.RayonDetailCell.Name = "RayonDetailCell";
            resources.ApplyResources(this.RayonDetailCell, "RayonDetailCell");
            this.RayonDetailCell.Weight = 0.11007024400446071D;
            this.RayonDetailCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.RayonDetailCell_BeforePrint);
            // 
            // DiagnosisDetailCell
            // 
            this.DiagnosisDetailCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepHumDataQualityIndicators.strDiagnosis")});
            this.DiagnosisDetailCell.Name = "DiagnosisDetailCell";
            this.DiagnosisDetailCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DiagnosisDetailCell.StylePriority.UsePadding = false;
            resources.ApplyResources(this.DiagnosisDetailCell, "DiagnosisDetailCell");
            this.DiagnosisDetailCell.Weight = 0.18395301770364617D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TotalDynamicTable});
            resources.ApplyResources(this.ReportFooter, "ReportFooter");
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ReportFooter.StylePriority.UsePadding = false;
            
            // 
            // TotalDynamicTable
            // 
            this.TotalDynamicTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.TotalDynamicTable, "TotalDynamicTable");
            this.TotalDynamicTable.Name = "TotalDynamicTable";
            this.TotalDynamicTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.TotalDynamicRow});
            this.TotalDynamicTable.StylePriority.UseBorders = false;
            this.TotalDynamicTable.StylePriority.UsePadding = false;
            this.TotalDynamicTable.StylePriority.UseTextAlignment = false;
            // 
            // TotalDynamicRow
            // 
            this.TotalDynamicRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell65,
            this.DiagnosisTotalCell});
            this.TotalDynamicRow.Name = "TotalDynamicRow";
            this.TotalDynamicRow.Weight = 1.0595311402299177D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Name = "xrTableCell65";
            resources.ApplyResources(this.xrTableCell65, "xrTableCell65");
            this.xrTableCell65.Weight = 0.188476441609014D;
            
            // 
            // DiagnosisTotalCell
            // 
            this.DiagnosisTotalCell.Name = "DiagnosisTotalCell";
            this.DiagnosisTotalCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DiagnosisTotalCell.StylePriority.UsePadding = false;
            this.DiagnosisTotalCell.Weight = 0.18395301770364617D;
            // 
            // m_DQIChartDataSet
            // 
            this.m_DQIChartDataSet.DataSetName = "DQIChartDataSet";
            this.m_DQIChartDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GroupFooterRayon
            // 
            this.GroupFooterRayon.BorderWidth = 0;
            resources.ApplyResources(this.GroupFooterRayon, "GroupFooterRayon");
            this.GroupFooterRayon.Name = "GroupFooterRayon";
            this.GroupFooterRayon.StylePriority.UseBorderWidth = false;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderWidth = 0;
            this.xrLine1.LineWidth = 0;
            resources.ApplyResources(this.xrLine1, "xrLine1");
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.StylePriority.UseBorderWidth = false;
            // 
            // HeaderPeriodLabel
            // 
            this.HeaderPeriodLabel.BorderWidth = 1;
            this.HeaderPeriodLabel.CanGrow = false;
            resources.ApplyResources(this.HeaderPeriodLabel, "HeaderPeriodLabel");
            this.HeaderPeriodLabel.Name = "HeaderPeriodLabel";
            this.HeaderPeriodLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderPeriodLabel.StylePriority.UseBorders = false;
            this.HeaderPeriodLabel.StylePriority.UseBorderWidth = false;
            this.HeaderPeriodLabel.StylePriority.UseFont = false;
            this.HeaderPeriodLabel.StylePriority.UseTextAlignment = false;
            // 
            // GroupHeaderRayon
            // 
            this.GroupHeaderRayon.BorderWidth = 0;
            this.GroupHeaderRayon.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("strRayon", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            resources.ApplyResources(this.GroupHeaderRayon, "GroupHeaderRayon");
            this.GroupHeaderRayon.Name = "GroupHeaderRayon";
            this.GroupHeaderRayon.StylePriority.UseBorderWidth = false;
            this.GroupHeaderRayon.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupHeaderRayon_BeforePrint);
            // 
            // GroupHeaderLine
            // 
            resources.ApplyResources(this.GroupHeaderLine, "GroupHeaderLine");
            this.GroupHeaderLine.Level = 2;
            this.GroupHeaderLine.Name = "GroupHeaderLine";
            // 
            // GroupFooterLine
            // 
            this.GroupFooterLine.BorderWidth = 0;
            this.GroupFooterLine.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1});
            resources.ApplyResources(this.GroupFooterLine, "GroupFooterLine");
            this.GroupFooterLine.Level = 2;
            this.GroupFooterLine.Name = "GroupFooterLine";
            this.GroupFooterLine.RepeatEveryPage = true;
            this.GroupFooterLine.StylePriority.UseBorderWidth = false;
            // 
            // GroupFooterRegion
            // 
            this.GroupFooterRegion.BorderWidth = 0;
            this.GroupFooterRegion.Expanded = false;
            resources.ApplyResources(this.GroupFooterRegion, "GroupFooterRegion");
            this.GroupFooterRegion.Level = 1;
            this.GroupFooterRegion.Name = "GroupFooterRegion";
            this.GroupFooterRegion.StylePriority.UseBorderWidth = false;
            this.GroupFooterRegion.StylePriority.UsePadding = false;
            this.GroupFooterRegion.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupFooterRegion_BeforePrint);
            // 
            // MaximumDynamicTable
            // 
            this.MaximumDynamicTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            resources.ApplyResources(this.MaximumDynamicTable, "MaximumDynamicTable");
            this.MaximumDynamicTable.Name = "MaximumDynamicTable";
            this.MaximumDynamicTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.MaximumDynamicRow});
            this.MaximumDynamicTable.StylePriority.UseBorders = false;
            this.MaximumDynamicTable.StylePriority.UsePadding = false;
            this.MaximumDynamicTable.StylePriority.UseTextAlignment = false;
            this.MaximumDynamicTable.AfterPrint += new System.EventHandler(this.MaximumDynamicTable_AfterPrint);
            // 
            // MaximumDynamicRow
            // 
            this.MaximumDynamicRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell66,
            this.DiagnosisMaxCell});
            this.MaximumDynamicRow.Name = "MaximumDynamicRow";
            this.MaximumDynamicRow.Weight = 1.0595311402299177D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Name = "xrTableCell66";
            resources.ApplyResources(this.xrTableCell66, "xrTableCell66");
            this.xrTableCell66.Weight = 0.188476441609014D;
            // 
            // DiagnosisMaxCell
            // 
            this.DiagnosisMaxCell.Name = "DiagnosisMaxCell";
            this.DiagnosisMaxCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DiagnosisMaxCell.StylePriority.UsePadding = false;
            this.DiagnosisMaxCell.Weight = 0.18395301770364617D;
            // 
            // DiagnosisHeaderCell
            // 
            resources.ApplyResources(this.DiagnosisHeaderCell, "DiagnosisHeaderCell");
            this.DiagnosisHeaderCell.Name = "DiagnosisHeaderCell";
            this.DiagnosisHeaderCell.StylePriority.UseFont = false;
            this.DiagnosisHeaderCell.StylePriority.UseTextAlignment = false;
            this.DiagnosisHeaderCell.Weight = 0.18395301770364617D;
            // 
            // RayonHeaderCell
            // 
            this.RayonHeaderCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            resources.ApplyResources(this.RayonHeaderCell, "RayonHeaderCell");
            this.RayonHeaderCell.Name = "RayonHeaderCell";
            this.RayonHeaderCell.StylePriority.UseBorders = false;
            this.RayonHeaderCell.StylePriority.UseFont = false;
            this.RayonHeaderCell.StylePriority.UseTextAlignment = false;
            this.RayonHeaderCell.Weight = 0.11022208304283897D;
            // 
            // RegionHeaderCell
            // 
            this.RegionHeaderCell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            resources.ApplyResources(this.RegionHeaderCell, "RegionHeaderCell");
            this.RegionHeaderCell.Name = "RegionHeaderCell";
            this.RegionHeaderCell.StylePriority.UseBorders = false;
            this.RegionHeaderCell.StylePriority.UseFont = false;
            this.RegionHeaderCell.StylePriority.UseTextAlignment = false;
            this.RegionHeaderCell.Weight = 0.07851436067682617D;
            // 
            // DynamicTopTableRow
            // 
            this.DynamicTopTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.RegionHeaderCell,
            this.RayonHeaderCell,
            this.DiagnosisHeaderCell});
            this.DynamicTopTableRow.Name = "DynamicTopTableRow";
            this.DynamicTopTableRow.Weight = 2.288587262896622D;
            // 
            // HeaderDynamicTable
            // 
            this.HeaderDynamicTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            resources.ApplyResources(this.HeaderDynamicTable, "HeaderDynamicTable");
            this.HeaderDynamicTable.Name = "HeaderDynamicTable";
            this.HeaderDynamicTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.HeaderDynamicTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.DynamicTopTableRow});
            this.HeaderDynamicTable.StylePriority.UseBorders = false;
            this.HeaderDynamicTable.StylePriority.UseFont = false;
            this.HeaderDynamicTable.StylePriority.UsePadding = false;
            this.HeaderDynamicTable.StylePriority.UseTextAlignment = false;
            // 
            // m_DQIAdapter
            // 
            this.m_DQIAdapter.ClearBeforeFill = true;
            // 
            // m_DQIDataSet
            // 
            this.m_DQIDataSet.DataSetName = "AFPIndicatorsDataSet";
            this.m_DQIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BaseDataQualityIndicatorsReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.GroupFooterRegion,
            this.GroupHeaderRegion,
            this.ReportFooter,
            this.GroupFooterRayon,
            this.GroupHeaderRayon,
            this.GroupFooterLine,
            this.GroupHeaderLine});
            this.CanWorkWithArchive = true;
            this.DataAdapter = this.m_DQIAdapter;
            this.DataMember = "spRepHumDataQualityIndicators";
            this.DataSource = this.m_DQIDataSet;
            resources.ApplyResources(this, "$this");
            this.Version = "11.1";
            this.Controls.SetChildIndex(this.GroupHeaderLine, 0);
            this.Controls.SetChildIndex(this.GroupFooterLine, 0);
            this.Controls.SetChildIndex(this.GroupHeaderRayon, 0);
            this.Controls.SetChildIndex(this.GroupFooterRayon, 0);
            this.Controls.SetChildIndex(this.ReportFooter, 0);
            this.Controls.SetChildIndex(this.GroupHeaderRegion, 0);
            this.Controls.SetChildIndex(this.GroupFooterRegion, 0);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.PageFooter, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tableInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailDynamicTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDynamicTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DQIChartDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumDynamicTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderDynamicTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DQIDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        
        protected EIDSS.Reports.Parameterized.Human.AJ.DataSets.DQIChartDataSet m_DQIChartDataSet;

        protected EIDSS.Reports.Parameterized.Human.AJ.DataSets.DQIDataSet m_DQIDataSet;

        protected EIDSS.Reports.Parameterized.Human.AJ.DataSets.DQIDataSetTableAdapters.spRepHumDataQualityIndicatorsTableAdapter m_DQIAdapter;


        protected DevExpress.XtraReports.UI.XRLabel HeaderLabal;
        protected DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderRegion;
        protected DevExpress.XtraReports.UI.XRTable DetailDynamicTable;
        protected DevExpress.XtraReports.UI.XRTableRow DetailDynamicTableRow;
        protected DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        protected DevExpress.XtraReports.UI.GroupFooterBand GroupFooterRayon;
        protected DevExpress.XtraReports.UI.XRLine xrLine1;
        protected DevExpress.XtraReports.UI.XRTableCell RegionDetailCell;
        protected DevExpress.XtraReports.UI.XRTableCell RayonDetailCell;
        protected DevExpress.XtraReports.UI.XRLabel HeaderPeriodLabel;
        protected DevExpress.XtraReports.UI.XRTableCell DiagnosisDetailCell;
        protected DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderRayon;
        protected DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderLine;
        protected DevExpress.XtraReports.UI.GroupFooterBand GroupFooterLine;
        protected DevExpress.XtraReports.UI.GroupFooterBand GroupFooterRegion;
        protected DevExpress.XtraReports.UI.XRTable MaximumDynamicTable;
        protected DevExpress.XtraReports.UI.XRTableRow MaximumDynamicRow;
        protected DevExpress.XtraReports.UI.XRTableCell xrTableCell66;
        protected DevExpress.XtraReports.UI.XRTableCell DiagnosisMaxCell;
        protected DevExpress.XtraReports.UI.XRTable TotalDynamicTable;
        protected DevExpress.XtraReports.UI.XRTableRow TotalDynamicRow;
        protected DevExpress.XtraReports.UI.XRTableCell xrTableCell65;
        protected DevExpress.XtraReports.UI.XRTableCell DiagnosisTotalCell;
        protected DevExpress.XtraReports.UI.XRTable HeaderDynamicTable;
        protected DevExpress.XtraReports.UI.XRTableRow DynamicTopTableRow;
        protected DevExpress.XtraReports.UI.XRTableCell RegionHeaderCell;
        protected DevExpress.XtraReports.UI.XRTableCell RayonHeaderCell;
        protected DevExpress.XtraReports.UI.XRTableCell DiagnosisHeaderCell;

    }
}
