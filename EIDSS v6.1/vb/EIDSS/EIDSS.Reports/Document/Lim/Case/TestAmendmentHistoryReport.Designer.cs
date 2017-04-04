using EIDSS.Reports.Document.Lim.TestResult;
using EIDSS.Reports.Document.Lim.TestResult.TestResultAmendmentHistoryDataSetTableAdapters;

namespace EIDSS.Reports.Document.Lim.Case
{
    partial class TestAmendmentHistoryReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestAmendmentHistoryReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailTable = new DevExpress.XtraReports.UI.XRTable();
            this.DetailTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.AmendmentDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.AmendedByOrganizationCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ChangedTestResultCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReasonOfAmendmentCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.m_DataSet = new EIDSS.Reports.Document.Lim.TestResult.TestResultAmendmentHistoryDataSet();
            this.m_Adapter = new EIDSS.Reports.Document.Lim.TestResult.TestResultAmendmentHistoryDataSetTableAdapters.TestResultsAmendmentHistoryAdapter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.HeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.FirstTestResultHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.FirstTestResultCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.AmendmentDateHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.AmendedByPersonHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.AmendedByOrganizationHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ChangedTestResultHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReasonOfAmendmentHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this.DetailTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DetailTable});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseTextAlignment = false;
            // 
            // DetailTable
            // 
            this.DetailTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            resources.ApplyResources(this.DetailTable, "DetailTable");
            this.DetailTable.Name = "DetailTable";
            this.DetailTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.DetailTableRow});
            this.DetailTable.StylePriority.UseBorders = false;
            // 
            // DetailTableRow
            // 
            this.DetailTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.AmendmentDateCell,
            this.xrTableCell15,
            this.AmendedByOrganizationCell,
            this.ChangedTestResultCell,
            this.xrTableCell2,
            this.ReasonOfAmendmentCell});
            this.DetailTableRow.Name = "DetailTableRow";
            this.DetailTableRow.StylePriority.UseBorders = false;
            this.DetailTableRow.StylePriority.UseFont = false;
            resources.ApplyResources(this.DetailTableRow, "DetailTableRow");
            // 
            // AmendmentDateCell
            // 
            this.AmendmentDateCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestResultsAmendmentHistory.datAmendmentDate", "{0:dd/MM/yyyy}")});
            this.AmendmentDateCell.Name = "AmendmentDateCell";
            resources.ApplyResources(this.AmendmentDateCell, "AmendmentDateCell");
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestResultsAmendmentHistory.strAmendedByPerson")});
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            resources.ApplyResources(this.xrTableCell15, "xrTableCell15");
            // 
            // AmendedByOrganizationCell
            // 
            this.AmendedByOrganizationCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestResultsAmendmentHistory.strAmendedByOrganization")});
            this.AmendedByOrganizationCell.Name = "AmendedByOrganizationCell";
            resources.ApplyResources(this.AmendedByOrganizationCell, "AmendedByOrganizationCell");
            // 
            // ChangedTestResultCell
            // 
            this.ChangedTestResultCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestResultsAmendmentHistory.strChangedTestResult")});
            this.ChangedTestResultCell.Name = "ChangedTestResultCell";
            resources.ApplyResources(this.ChangedTestResultCell, "ChangedTestResultCell");
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestResultsAmendmentHistory.srtNewCommentary")});
            this.xrTableCell2.Name = "xrTableCell2";
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            // 
            // ReasonOfAmendmentCell
            // 
            this.ReasonOfAmendmentCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestResultsAmendmentHistory.strReasonOfAmended")});
            this.ReasonOfAmendmentCell.Name = "ReasonOfAmendmentCell";
            resources.ApplyResources(this.ReasonOfAmendmentCell, "ReasonOfAmendmentCell");
            // 
            // TopMargin
            // 
            resources.ApplyResources(this.TopMargin, "TopMargin");
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // BottomMargin
            // 
            resources.ApplyResources(this.BottomMargin, "BottomMargin");
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // m_DataSet
            // 
            this.m_DataSet.DataSetName = "OutBreakDataSet";
            this.m_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // m_Adapter
            // 
            this.m_Adapter.ClearBeforeFill = true;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.HeaderTable});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.KeepTogether = true;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            resources.ApplyResources(this.xrLabel2, "xrLabel2");
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            // 
            // HeaderTable
            // 
            resources.ApplyResources(this.HeaderTable, "HeaderTable");
            this.HeaderTable.Name = "HeaderTable";
            this.HeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow3,
            this.xrTableRow2});
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.FirstTestResultHeaderCell,
            this.FirstTestResultCell});
            this.xrTableRow1.Name = "xrTableRow1";
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            // 
            // FirstTestResultHeaderCell
            // 
            this.FirstTestResultHeaderCell.Name = "FirstTestResultHeaderCell";
            this.FirstTestResultHeaderCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.FirstTestResultHeaderCell, "FirstTestResultHeaderCell");
            // 
            // FirstTestResultCell
            // 
            this.FirstTestResultCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.FirstTestResultCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TestResultsAmendmentHistory.strFirstTestResult")});
            this.FirstTestResultCell.Name = "FirstTestResultCell";
            this.FirstTestResultCell.StylePriority.UseBorders = false;
            this.FirstTestResultCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.FirstTestResultCell, "FirstTestResultCell");
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9});
            this.xrTableRow3.Name = "xrTableRow3";
            resources.ApplyResources(this.xrTableRow3, "xrTableRow3");
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            resources.ApplyResources(this.xrTableCell9, "xrTableCell9");
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.AmendmentDateHeaderCell,
            this.AmendedByPersonHeaderCell,
            this.AmendedByOrganizationHeaderCell,
            this.ChangedTestResultHeaderCell,
            this.xrTableCell1,
            this.ReasonOfAmendmentHeaderCell});
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseBorders = false;
            this.xrTableRow2.StylePriority.UseFont = false;
            // 
            // AmendmentDateHeaderCell
            // 
            this.AmendmentDateHeaderCell.Name = "AmendmentDateHeaderCell";
            resources.ApplyResources(this.AmendmentDateHeaderCell, "AmendmentDateHeaderCell");
            // 
            // AmendedByPersonHeaderCell
            // 
            this.AmendedByPersonHeaderCell.Multiline = true;
            this.AmendedByPersonHeaderCell.Name = "AmendedByPersonHeaderCell";
            resources.ApplyResources(this.AmendedByPersonHeaderCell, "AmendedByPersonHeaderCell");
            // 
            // AmendedByOrganizationHeaderCell
            // 
            this.AmendedByOrganizationHeaderCell.Name = "AmendedByOrganizationHeaderCell";
            resources.ApplyResources(this.AmendedByOrganizationHeaderCell, "AmendedByOrganizationHeaderCell");
            // 
            // ChangedTestResultHeaderCell
            // 
            this.ChangedTestResultHeaderCell.Name = "ChangedTestResultHeaderCell";
            resources.ApplyResources(this.ChangedTestResultHeaderCell, "ChangedTestResultHeaderCell");
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            // 
            // ReasonOfAmendmentHeaderCell
            // 
            this.ReasonOfAmendmentHeaderCell.Name = "ReasonOfAmendmentHeaderCell";
            resources.ApplyResources(this.ReasonOfAmendmentHeaderCell, "ReasonOfAmendmentHeaderCell");
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1});
            resources.ApplyResources(this.GroupHeader1, "GroupHeader1");
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeader1.RepeatEveryPage = true;
            this.GroupHeader1.StylePriority.UseBorders = false;
            this.GroupHeader1.StylePriority.UsePadding = false;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderWidth = 0F;
            resources.ApplyResources(this.xrLine1, "xrLine1");
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.StylePriority.UseBorderWidth = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2});
            resources.ApplyResources(this.GroupFooter1, "GroupFooter1");
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupFooter1.RepeatEveryPage = true;
            this.GroupFooter1.StylePriority.UsePadding = false;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderWidth = 0F;
            resources.ApplyResources(this.xrLine2, "xrLine2");
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.StylePriority.UseBorderWidth = false;
            // 
            // TestAmendmentHistoryReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupFooter1});
            this.DataAdapter = this.m_Adapter;
            this.DataMember = "TestResultsAmendmentHistory";
            this.DataSource = this.m_DataSet;
            resources.ApplyResources(this, "$this");
            this.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.DetailTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private TestResultAmendmentHistoryDataSet m_DataSet;

        private TestResultsAmendmentHistoryAdapter m_Adapter;
        private DevExpress.XtraReports.UI.XRTable HeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell FirstTestResultHeaderCell;
        private DevExpress.XtraReports.UI.XRTableCell FirstTestResultCell;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRTable DetailTable;
        private DevExpress.XtraReports.UI.XRTableRow DetailTableRow;
        private DevExpress.XtraReports.UI.XRTableCell AmendmentDateCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell AmendedByOrganizationCell;
        private DevExpress.XtraReports.UI.XRTableCell ChangedTestResultCell;
        private DevExpress.XtraReports.UI.XRTableCell ReasonOfAmendmentCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell AmendmentDateHeaderCell;
        private DevExpress.XtraReports.UI.XRTableCell AmendedByPersonHeaderCell;
        private DevExpress.XtraReports.UI.XRTableCell AmendedByOrganizationHeaderCell;
        private DevExpress.XtraReports.UI.XRTableCell ChangedTestResultHeaderCell;
        private DevExpress.XtraReports.UI.XRTableCell ReasonOfAmendmentHeaderCell;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
    }
}
