
using EIDSS.Reports.Document.Lim.ContainerContent;
using EIDSS.Reports.Document.Lim.SampleDestruction.SampleDestructionDataSetTableAdapters;

namespace EIDSS.Reports.Document.Lim.SampleDestruction
{
    partial class SampleDestructionReport
    {


        #region Designer generated code
         
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleDestructionReport));
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.SampleDestructionDetail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SampleIdTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SampleDestructionReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.tableFreezer = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.FreezerNumberCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.FreezerBarcodeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SampleDestructionAdapter = new EIDSS.Reports.Document.Lim.SampleDestruction.SampleDestructionDataSetTableAdapters.SampleDestructionAdapter();
            this.SampleDestructionDataSet = new EIDSS.Reports.Document.Lim.SampleDestruction.SampleDestructionDataSet();
            this.SampleDestructionReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleIdTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableFreezer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleDestructionDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // cellLanguage
            // 
            this.cellLanguage.StylePriority.UseTextAlignment = false;
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
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            // 
            // PageHeader
            // 
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UsePadding = false;
            // 
            // PageFooter
            // 
            this.PageFooter.StylePriority.UseBorders = false;
            // 
            // ReportHeader
            // 
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            // 
            // xrPageInfo1
            // 
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
            // 
            // tableBaseHeader
            // 
            this.tableBaseHeader.StylePriority.UseBorders = false;
            this.tableBaseHeader.StylePriority.UseBorderWidth = false;
            this.tableBaseHeader.StylePriority.UseFont = false;
            this.tableBaseHeader.StylePriority.UsePadding = false;
            this.tableBaseHeader.StylePriority.UseTextAlignment = false;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.SampleDestructionDetail,
            this.SampleDestructionReportHeader});
            this.DetailReport.DataAdapter = this.SampleDestructionAdapter;
            this.DetailReport.DataMember = "SampleDestruction";
            this.DetailReport.DataSource = this.SampleDestructionDataSet;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            this.DetailReport.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            resources.ApplyResources(this.DetailReport, "DetailReport");
            // 
            // SampleDestructionDetail
            // 
            this.SampleDestructionDetail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            resources.ApplyResources(this.SampleDestructionDetail, "SampleDestructionDetail");
            this.SampleDestructionDetail.KeepTogether = true;
            this.SampleDestructionDetail.Name = "SampleDestructionDetail";
            this.SampleDestructionDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.SampleDestructionDetail.StylePriority.UseFont = false;
            this.SampleDestructionDetail.StylePriority.UsePadding = false;
            this.SampleDestructionDetail.StylePriority.UseTextAlignment = false;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.xrTable1, "xrTable1");
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell5,
            this.xrTableCell2});
            this.xrTableRow5.Name = "xrTableRow5";
            resources.ApplyResources(this.xrTableRow5, "xrTableRow5");
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SampleIdTable});
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell13, "xrTableCell13");
            // 
            // SampleIdTable
            // 
            this.SampleIdTable.Borders = DevExpress.XtraPrinting.BorderSide.None;
            resources.ApplyResources(this.SampleIdTable, "SampleIdTable");
            this.SampleIdTable.Name = "SampleIdTable";
            this.SampleIdTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2});
            this.SampleIdTable.StylePriority.UseBorders = false;
            this.SampleIdTable.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleDestruction.strLabSampleIDBarcode")});
            resources.ApplyResources(this.xrTableCell3, "xrTableCell3");
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4});
            this.xrTableRow2.Name = "xrTableRow2";
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleDestruction.strLabSampleID")});
            this.xrTableCell4.Name = "xrTableCell4";
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleDestruction.strSampleType")});
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell14, "xrTableCell14");
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleDestruction.strCondition")});
            this.xrTableCell5.Name = "xrTableCell5";
            resources.ApplyResources(this.xrTableCell5, "xrTableCell5");
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SampleDestruction.strDestructionMethod")});
            this.xrTableCell2.Name = "xrTableCell2";
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            // 
            // SampleDestructionReportHeader
            // 
            this.SampleDestructionReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tableFreezer});
            resources.ApplyResources(this.SampleDestructionReportHeader, "SampleDestructionReportHeader");
            this.SampleDestructionReportHeader.KeepTogether = true;
            this.SampleDestructionReportHeader.Name = "SampleDestructionReportHeader";
            this.SampleDestructionReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.SampleDestructionReportHeader.StylePriority.UseFont = false;
            this.SampleDestructionReportHeader.StylePriority.UsePadding = false;
            this.SampleDestructionReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // tableFreezer
            // 
            this.tableFreezer.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.tableFreezer, "tableFreezer");
            this.tableFreezer.Name = "tableFreezer";
            this.tableFreezer.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.tableFreezer.StylePriority.UseBorders = false;
            this.tableFreezer.StylePriority.UseFont = false;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell10,
            this.FreezerNumberCell,
            this.FreezerBarcodeCell});
            this.xrTableRow10.Name = "xrTableRow10";
            resources.ApplyResources(this.xrTableRow10, "xrTableRow10");
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell10, "xrTableCell10");
            // 
            // FreezerNumberCell
            // 
            this.FreezerNumberCell.Name = "FreezerNumberCell";
            resources.ApplyResources(this.FreezerNumberCell, "FreezerNumberCell");
            // 
            // FreezerBarcodeCell
            // 
            this.FreezerBarcodeCell.Name = "FreezerBarcodeCell";
            resources.ApplyResources(this.FreezerBarcodeCell, "FreezerBarcodeCell");
            // 
            // SampleDestructionAdapter
            // 
            this.SampleDestructionAdapter.ClearBeforeFill = true;
            // 
            // SampleDestructionDataSet
            // 
            this.SampleDestructionDataSet.DataSetName = "ContainerContentDataSet";
            this.SampleDestructionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SampleDestructionReportFooter
            // 
            this.SampleDestructionReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            resources.ApplyResources(this.SampleDestructionReportFooter, "SampleDestructionReportFooter");
            this.SampleDestructionReportFooter.Name = "SampleDestructionReportFooter";
            this.SampleDestructionReportFooter.StylePriority.UseTextAlignment = false;
            // 
            // xrTable2
            // 
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3,
            this.xrTableRow4});
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell8});
            this.xrTableRow3.Name = "xrTableRow3";
            resources.ApplyResources(this.xrTableRow3, "xrTableRow3");
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            resources.ApplyResources(this.xrTableCell6, "xrTableCell6");
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.SampleDestructionDataSet, "SampleDestruction.strSentForDestructionBy")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            resources.ApplyResources(this.xrTableCell8, "xrTableCell8");
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell9});
            this.xrTableRow4.Name = "xrTableRow4";
            resources.ApplyResources(this.xrTableRow4, "xrTableRow4");
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            resources.ApplyResources(this.xrTableCell7, "xrTableCell7");
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.SampleDestructionDataSet, "SampleDestruction.strDestructionApprovedBy")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            resources.ApplyResources(this.xrTableCell9, "xrTableCell9");
            // 
            // SampleDestructionReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.DetailReport,
            this.SampleDestructionReportFooter});
            resources.ApplyResources(this, "$this");
            this.Version = "14.1";
            this.Controls.SetChildIndex(this.SampleDestructionReportFooter, 0);
            this.Controls.SetChildIndex(this.DetailReport, 0);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.PageFooter, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleIdTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableFreezer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleDestructionDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion 

        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand SampleDestructionDetail;
        private DevExpress.XtraReports.UI.XRTable tableFreezer;
        private DevExpress.XtraReports.UI.ReportHeaderBand SampleDestructionReportHeader;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private SampleDestructionAdapter SampleDestructionAdapter;
        private SampleDestructionDataSet SampleDestructionDataSet;
        private DevExpress.XtraReports.UI.XRTableCell FreezerBarcodeCell;
        private DevExpress.XtraReports.UI.XRTableCell FreezerNumberCell;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTable SampleIdTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.ReportFooterBand SampleDestructionReportFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;



    }
}