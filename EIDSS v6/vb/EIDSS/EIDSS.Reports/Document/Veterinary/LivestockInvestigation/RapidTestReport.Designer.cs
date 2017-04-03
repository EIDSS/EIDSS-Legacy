namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    partial class RapidTestReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RapidTestReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.DeatilTable = new DevExpress.XtraReports.UI.XRTable();
            this.DetailRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.HeaderRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.rapidTestDataSet1 = new EIDSS.Reports.Document.Veterinary.LivestockInvestigation.RapidTestDataSet();
            this.sp_Rep_VET_PensideTestsListTableAdapter = new EIDSS.Reports.Document.Veterinary.LivestockInvestigation.RapidTestDataSetTableAdapters.sp_Rep_VET_PensideTestsListTableAdapter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.DeatilTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapidTestDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DeatilTable});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.Detail.StylePriority.UseBorders = false;
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            // 
            // DeatilTable
            // 
            this.DeatilTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.DeatilTable, "DeatilTable");
            this.DeatilTable.Name = "DeatilTable";
            this.DeatilTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.DetailRow});
            this.DeatilTable.StylePriority.UseBorders = false;
            // 
            // DetailRow
            // 
            this.DetailRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5});
            resources.ApplyResources(this.DetailRow, "DetailRow");
            this.DetailRow.Name = "DetailRow";
            this.DetailRow.StylePriority.UseBackColor = false;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepVetPensideTestsList.strTestName")});
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            this.xrTableCell1.Name = "xrTableCell1";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepVetPensideTestsList.strFieldSampleID")});
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            this.xrTableCell2.Name = "xrTableCell2";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepVetPensideTestsList.strSampleType")});
            resources.ApplyResources(this.xrTableCell3, "xrTableCell3");
            this.xrTableCell3.Name = "xrTableCell3";
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepVetPensideTestsList.strSpecies")});
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            this.xrTableCell4.Name = "xrTableCell4";
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepVetPensideTestsList.strTestResult")});
            resources.ApplyResources(this.xrTableCell5, "xrTableCell5");
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            // 
            // HeaderTable
            // 
            this.HeaderTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.HeaderTable, "HeaderTable");
            this.HeaderTable.Name = "HeaderTable";
            this.HeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.HeaderRow});
            this.HeaderTable.StylePriority.UseBorders = false;
            // 
            // HeaderRow
            // 
            this.HeaderRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell6,
            this.xrTableCell12});
            resources.ApplyResources(this.HeaderRow, "HeaderRow");
            this.HeaderRow.Name = "HeaderRow";
            // 
            // xrTableCell13
            // 
            resources.ApplyResources(this.xrTableCell13, "xrTableCell13");
            this.xrTableCell13.Name = "xrTableCell13";
            // 
            // xrTableCell14
            // 
            resources.ApplyResources(this.xrTableCell14, "xrTableCell14");
            this.xrTableCell14.Name = "xrTableCell14";
            // 
            // xrTableCell15
            // 
            resources.ApplyResources(this.xrTableCell15, "xrTableCell15");
            this.xrTableCell15.Name = "xrTableCell15";
            // 
            // xrTableCell6
            // 
            resources.ApplyResources(this.xrTableCell6, "xrTableCell6");
            this.xrTableCell6.Name = "xrTableCell6";
            // 
            // xrTableCell12
            // 
            resources.ApplyResources(this.xrTableCell12, "xrTableCell12");
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseFont = false;
            // 
            // PageHeader
            // 
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.StylePriority.UseFont = false;
            // 
            // PageFooter
            // 
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.StylePriority.UseFont = false;
            // 
            // rapidTestDataSet1
            // 
            this.rapidTestDataSet1.DataSetName = "RapidTestDataSet";
            this.rapidTestDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_Rep_VET_PensideTestsListTableAdapter
            // 
            this.sp_Rep_VET_PensideTestsListTableAdapter.ClearBeforeFill = true;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.HeaderTable});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.StylePriority.UseFont = false;
            this.ReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            resources.ApplyResources(this.xrLabel1, "xrLabel1");
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            // 
            // topMarginBand1
            // 
            resources.ApplyResources(this.topMarginBand1, "topMarginBand1");
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            resources.ApplyResources(this.bottomMarginBand1, "bottomMarginBand1");
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // RapidTestReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DataAdapter = this.sp_Rep_VET_PensideTestsListTableAdapter;
            this.DataMember = "spRepVetPensideTestsList";
            this.DataSource = this.rapidTestDataSet1;
            resources.ApplyResources(this, "$this");
            this.ExportOptions.Xls.SheetName = resources.GetString("RapidTestReport.ExportOptions.Xls.SheetName");
            this.ExportOptions.Xlsx.SheetName = resources.GetString("RapidTestReport.ExportOptions.Xlsx.SheetName");
            this.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.DeatilTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapidTestDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private RapidTestDataSet rapidTestDataSet1;
        private EIDSS.Reports.Document.Veterinary.LivestockInvestigation.RapidTestDataSetTableAdapters.sp_Rep_VET_PensideTestsListTableAdapter sp_Rep_VET_PensideTestsListTableAdapter;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRTable HeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow HeaderRow;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTable DeatilTable;
        private DevExpress.XtraReports.UI.XRTableRow DetailRow;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
    }
}
