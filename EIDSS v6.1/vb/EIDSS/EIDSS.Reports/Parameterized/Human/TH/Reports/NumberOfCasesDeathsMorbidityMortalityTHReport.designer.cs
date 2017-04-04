
using EIDSS.Reports.Parameterized.Uni.EventLog;

namespace EIDSS.Reports.Parameterized.Human.TH.Reports
{
    partial class NumberOfCasesDeathsMorbidityMortalityTHReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumberOfCasesDeathsMorbidityMortalityTHReport));
            this.HeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.rowHeader1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellDateTime = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DeathsHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellType = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellPerson = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.ReportingAreaCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.CasesCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.MorbidityRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DeathsCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.CFRCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.MortalityRateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.PopulationCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeaderLine = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.m_Adapter = new EIDSS.Reports.Parameterized.Human.TH.DataSets.NumberOfCasesDeathsMorbidityMortalityTHDataSetTableAdapters.NumberOfCasesAdapter();
            this.m_DataSet = new EIDSS.Reports.Parameterized.Human.TH.DataSets.NumberOfCasesDeathsMorbidityMortalityTHDataSet();
            this.ReportHeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.HeaderRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.SignatureTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.OrganizationNameCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DateTimeCell = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.tableInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignatureTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // tableInterval
            // 
            resources.ApplyResources(this.tableInterval, "tableInterval");
            this.tableInterval.StylePriority.UseBorders = false;
            this.tableInterval.StylePriority.UseFont = false;
            this.tableInterval.StylePriority.UsePadding = false;
            // 
            // cellInputStartDate
            // 
            this.cellInputStartDate.StylePriority.UseFont = false;
            this.cellInputStartDate.StylePriority.UseTextAlignment = false;
            // 
            // cellInputEndDate
            // 
            this.cellInputEndDate.StylePriority.UseFont = false;
            this.cellInputEndDate.StylePriority.UseTextAlignment = false;
            // 
            // cellDefis
            // 
            this.cellDefis.StylePriority.UseFont = false;
            this.cellDefis.StylePriority.UseTextAlignment = false;
            // 
            // cellLanguage
            // 
            this.cellLanguage.StylePriority.UseTextAlignment = false;
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
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            // 
            // PageHeader
            // 
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UsePadding = false;
            // 
            // PageFooter
            // 
            this.PageFooter.StylePriority.UseBorders = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ReportHeaderTable,
            this.HeaderTable});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Controls.SetChildIndex(this.HeaderTable, 0);
            this.ReportHeader.Controls.SetChildIndex(this.tableBaseHeader, 0);
            this.ReportHeader.Controls.SetChildIndex(this.ReportHeaderTable, 0);
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
            resources.ApplyResources(this.cellReportHeader, "cellReportHeader");
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
            // cellBaseLeftHeader
            // 
            resources.ApplyResources(this.cellBaseLeftHeader, "cellBaseLeftHeader");
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
            // HeaderTable
            // 
            this.HeaderTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            resources.ApplyResources(this.HeaderTable, "HeaderTable");
            this.HeaderTable.Name = "HeaderTable";
            this.HeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.rowHeader1});
            this.HeaderTable.StylePriority.UseBorders = false;
            this.HeaderTable.StylePriority.UseFont = false;
            this.HeaderTable.StylePriority.UseTextAlignment = false;
            // 
            // rowHeader1
            // 
            this.rowHeader1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellDateTime,
            this.xrTableCell5,
            this.xrTableCell3,
            this.DeathsHeaderCell,
            this.cellType,
            this.xrTableCell4,
            this.cellPerson});
            this.rowHeader1.Name = "rowHeader1";
            this.rowHeader1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rowHeader1.StylePriority.UseFont = false;
            this.rowHeader1.StylePriority.UsePadding = false;
            this.rowHeader1.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.rowHeader1, "rowHeader1");
            // 
            // cellDateTime
            // 
            resources.ApplyResources(this.cellDateTime, "cellDateTime");
            this.cellDateTime.Name = "cellDateTime";
            this.cellDateTime.StylePriority.UseFont = false;
            // 
            // xrTableCell5
            // 
            resources.ApplyResources(this.xrTableCell5, "xrTableCell5");
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCell3
            // 
            resources.ApplyResources(this.xrTableCell3, "xrTableCell3");
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            // 
            // DeathsHeaderCell
            // 
            resources.ApplyResources(this.DeathsHeaderCell, "DeathsHeaderCell");
            this.DeathsHeaderCell.Name = "DeathsHeaderCell";
            this.DeathsHeaderCell.StylePriority.UseFont = false;
            this.DeathsHeaderCell.StylePriority.UseTextAlignment = false;
            // 
            // cellType
            // 
            resources.ApplyResources(this.cellType, "cellType");
            this.cellType.Name = "cellType";
            this.cellType.StylePriority.UseFont = false;
            this.cellType.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCell4
            // 
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            // 
            // cellPerson
            // 
            resources.ApplyResources(this.cellPerson, "cellPerson");
            this.cellPerson.Name = "cellPerson";
            this.cellPerson.StylePriority.UseFont = false;
            this.cellPerson.StylePriority.UseTextAlignment = false;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupHeaderLine});
            this.DetailReport.DataAdapter = this.m_Adapter;
            this.DetailReport.DataMember = "NumberOfCasesTable";
            this.DetailReport.DataSource = this.m_DataSet;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            resources.ApplyResources(this.Detail1, "Detail1");
            this.Detail1.Name = "Detail1";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.xrTable1, "xrTable1");
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.ReportingAreaCell,
            this.CasesCell,
            this.MorbidityRateCell,
            this.DeathsCell,
            this.CFRCell,
            this.MortalityRateCell,
            this.PopulationCell});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.StylePriority.UsePadding = false;
            this.xrTableRow1.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            // 
            // ReportingAreaCell
            // 
            this.ReportingAreaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "NumberOfCasesTable.strReportingArea")});
            resources.ApplyResources(this.ReportingAreaCell, "ReportingAreaCell");
            this.ReportingAreaCell.Name = "ReportingAreaCell";
            this.ReportingAreaCell.StylePriority.UseFont = false;
            this.ReportingAreaCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReportingAreaCell_BeforePrint);
            // 
            // CasesCell
            // 
            this.CasesCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "NumberOfCasesTable.intCases")});
            resources.ApplyResources(this.CasesCell, "CasesCell");
            this.CasesCell.Name = "CasesCell";
            this.CasesCell.StylePriority.UseFont = false;
            this.CasesCell.StylePriority.UseTextAlignment = false;
            this.CasesCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.CasesCell_BeforePrint);
            // 
            // MorbidityRateCell
            // 
            resources.ApplyResources(this.MorbidityRateCell, "MorbidityRateCell");
            this.MorbidityRateCell.Name = "MorbidityRateCell";
            this.MorbidityRateCell.StylePriority.UseFont = false;
            this.MorbidityRateCell.StylePriority.UseTextAlignment = false;
            this.MorbidityRateCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MorbidityRateCell_BeforePrint);
            // 
            // DeathsCell
            // 
            this.DeathsCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "NumberOfCasesTable.intDeath")});
            resources.ApplyResources(this.DeathsCell, "DeathsCell");
            this.DeathsCell.Name = "DeathsCell";
            this.DeathsCell.StylePriority.UseFont = false;
            this.DeathsCell.StylePriority.UseTextAlignment = false;
            this.DeathsCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.DeathsCell_BeforePrint);
            // 
            // CFRCell
            // 
            resources.ApplyResources(this.CFRCell, "CFRCell");
            this.CFRCell.Name = "CFRCell";
            this.CFRCell.StylePriority.UseFont = false;
            this.CFRCell.StylePriority.UseTextAlignment = false;
            this.CFRCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.CFRCell_BeforePrint);
            // 
            // MortalityRateCell
            // 
            resources.ApplyResources(this.MortalityRateCell, "MortalityRateCell");
            this.MortalityRateCell.Multiline = true;
            this.MortalityRateCell.Name = "MortalityRateCell";
            this.MortalityRateCell.StylePriority.UseFont = false;
            this.MortalityRateCell.StylePriority.UseTextAlignment = false;
            this.MortalityRateCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MortalityRateCell_BeforePrint);
            // 
            // PopulationCell
            // 
            this.PopulationCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "NumberOfCasesTable.intPopulation")});
            resources.ApplyResources(this.PopulationCell, "PopulationCell");
            this.PopulationCell.Name = "PopulationCell";
            this.PopulationCell.StylePriority.UseFont = false;
            this.PopulationCell.StylePriority.UseTextAlignment = false;
            this.PopulationCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PopulationCell_BeforePrint);
            this.PopulationCell.AfterPrint += new System.EventHandler(this.PopulationCell_AfterPrint);
            // 
            // GroupHeaderLine
            // 
            this.GroupHeaderLine.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2});
            resources.ApplyResources(this.GroupHeaderLine, "GroupHeaderLine");
            this.GroupHeaderLine.Name = "GroupHeaderLine";
            this.GroupHeaderLine.RepeatEveryPage = true;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderWidth = 0F;
            this.xrLine2.LineWidth = 0;
            resources.ApplyResources(this.xrLine2, "xrLine2");
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.StylePriority.UseBorderWidth = false;
            // 
            // m_Adapter
            // 
            this.m_Adapter.ClearBeforeFill = true;
            // 
            // m_DataSet
            // 
            this.m_DataSet.DataSetName = "EventLogDataSet";
            this.m_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportHeaderTable
            // 
            resources.ApplyResources(this.ReportHeaderTable, "ReportHeaderTable");
            this.ReportHeaderTable.Name = "ReportHeaderTable";
            this.ReportHeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.HeaderRow1,
            this.HeaderRow2,
            this.HeaderRow3});
            this.ReportHeaderTable.StylePriority.UseTextAlignment = false;
            // 
            // HeaderRow1
            // 
            this.HeaderRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.HeaderCell1});
            this.HeaderRow1.Name = "HeaderRow1";
            resources.ApplyResources(this.HeaderRow1, "HeaderRow1");
            // 
            // HeaderCell1
            // 
            resources.ApplyResources(this.HeaderCell1, "HeaderCell1");
            this.HeaderCell1.Name = "HeaderCell1";
            this.HeaderCell1.StylePriority.UseFont = false;
            // 
            // HeaderRow2
            // 
            this.HeaderRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.HeaderCell2});
            this.HeaderRow2.Name = "HeaderRow2";
            resources.ApplyResources(this.HeaderRow2, "HeaderRow2");
            // 
            // HeaderCell2
            // 
            resources.ApplyResources(this.HeaderCell2, "HeaderCell2");
            this.HeaderCell2.Name = "HeaderCell2";
            this.HeaderCell2.StylePriority.UseFont = false;
            // 
            // HeaderRow3
            // 
            this.HeaderRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.HeaderCell3});
            this.HeaderRow3.Name = "HeaderRow3";
            resources.ApplyResources(this.HeaderRow3, "HeaderRow3");
            // 
            // HeaderCell3
            // 
            resources.ApplyResources(this.HeaderCell3, "HeaderCell3");
            this.HeaderCell3.Name = "HeaderCell3";
            this.HeaderCell3.StylePriority.UseFont = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SignatureTable});
            resources.ApplyResources(this.ReportFooter, "ReportFooter");
            this.ReportFooter.Name = "ReportFooter";
            // 
            // SignatureTable
            // 
            resources.ApplyResources(this.SignatureTable, "SignatureTable");
            this.SignatureTable.Name = "SignatureTable";
            this.SignatureTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.SignatureTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.SignatureTable.StylePriority.UseFont = false;
            this.SignatureTable.StylePriority.UsePadding = false;
            this.SignatureTable.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.OrganizationNameCell,
            this.xrTableCell1,
            this.DateTimeCell});
            this.xrTableRow7.Name = "xrTableRow7";
            resources.ApplyResources(this.xrTableRow7, "xrTableRow7");
            // 
            // OrganizationNameCell
            // 
            this.OrganizationNameCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sprepGetBaseParameters.SiteName", "{0}, Ministry of Public Health")});
            resources.ApplyResources(this.OrganizationNameCell, "OrganizationNameCell");
            this.OrganizationNameCell.Name = "OrganizationNameCell";
            this.OrganizationNameCell.StylePriority.UseFont = false;
            // 
            // xrTableCell1
            // 
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            // 
            // DateTimeCell
            // 
            resources.ApplyResources(this.DateTimeCell, "DateTimeCell");
            this.DateTimeCell.Name = "DateTimeCell";
            this.DateTimeCell.StylePriority.UseFont = false;
            // 
            // NumberOfCasesDeathsMorbidityMortalityTHReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.DetailReport,
            this.ReportHeader,
            this.ReportFooter});
            resources.ApplyResources(this, "$this");
            this.Version = "15.1";
            this.Controls.SetChildIndex(this.ReportFooter, 0);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.DetailReport, 0);
            this.Controls.SetChildIndex(this.PageFooter, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tableInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignatureTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRTable HeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow rowHeader1;
        private DevExpress.XtraReports.UI.XRTableCell cellType;
        private DevExpress.XtraReports.UI.XRTableCell cellPerson;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.XRTableCell cellDateTime;
        private EIDSS.Reports.Parameterized.Human.TH.DataSets.NumberOfCasesDeathsMorbidityMortalityTHDataSet m_DataSet;
        private EIDSS.Reports.Parameterized.Human.TH.DataSets.NumberOfCasesDeathsMorbidityMortalityTHDataSetTableAdapters.NumberOfCasesAdapter m_Adapter;
        private DevExpress.XtraReports.UI.XRTable ReportHeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow HeaderRow1;
        private DevExpress.XtraReports.UI.XRTableCell HeaderCell1;
        private DevExpress.XtraReports.UI.XRTableRow HeaderRow2;
        private DevExpress.XtraReports.UI.XRTableCell HeaderCell2;
        private DevExpress.XtraReports.UI.XRTableRow HeaderRow3;
        private DevExpress.XtraReports.UI.XRTableCell HeaderCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell DeathsHeaderCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell ReportingAreaCell;
        private DevExpress.XtraReports.UI.XRTableCell CasesCell;
        private DevExpress.XtraReports.UI.XRTableCell MorbidityRateCell;
        private DevExpress.XtraReports.UI.XRTableCell DeathsCell;
        private DevExpress.XtraReports.UI.XRTableCell CFRCell;
        private DevExpress.XtraReports.UI.XRTableCell MortalityRateCell;
        private DevExpress.XtraReports.UI.XRTableCell PopulationCell;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderLine;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRTable SignatureTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell OrganizationNameCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell DateTimeCell;


    }
}