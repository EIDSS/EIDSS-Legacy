using EIDSS.Reports.Document.ActiveSurveillance.SessionDiagnosisDataSetTableAdapters;
using EIDSS.Reports.Document.ActiveSurveillance.SessionFarmReportDataSetTableAdapters;

namespace EIDSS.Reports.Document.ActiveSurveillance
{
    partial class SessionDiagnosisReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionDiagnosisReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.DiseasesCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpeciesCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.MainTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.EmptyCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.DiseasesHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpeciesHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.m_DataSet = new EIDSS.Reports.Document.ActiveSurveillance.SessionDiagnosisDataSet();
            this.m_Adapter = new EIDSS.Reports.Document.ActiveSurveillance.SessionDiagnosisDataSetTableAdapters.SessionDiagnosisAdapter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.DiseasesCell,
            this.SpeciesCell});
            this.xrTableRow3.Name = "xrTableRow3";
            resources.ApplyResources(this.xrTableRow3, "xrTableRow3");
            // 
            // DiseasesCell
            // 
            this.DiseasesCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionDiagnosis.strDiagnosis")});
            this.DiseasesCell.Multiline = true;
            this.DiseasesCell.Name = "DiseasesCell";
            resources.ApplyResources(this.DiseasesCell, "DiseasesCell");
            // 
            // SpeciesCell
            // 
            this.SpeciesCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionDiagnosis.strSpecies")});
            this.SpeciesCell.Multiline = true;
            this.SpeciesCell.Name = "SpeciesCell";
            resources.ApplyResources(this.SpeciesCell, "SpeciesCell");
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
            // PageHeader
            // 
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            // 
            // MainTable
            // 
            this.MainTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.MainTable, "MainTable");
            this.MainTable.Name = "MainTable";
            this.MainTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5,
            this.xrTableRow4,
            this.xrTableRow1});
            this.MainTable.StylePriority.UseBorders = false;
            this.MainTable.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.HeaderCell});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.StylePriority.UseBorders = false;
            resources.ApplyResources(this.xrTableRow5, "xrTableRow5");
            // 
            // HeaderCell
            // 
            resources.ApplyResources(this.HeaderCell, "HeaderCell");
            this.HeaderCell.Name = "HeaderCell";
            this.HeaderCell.StylePriority.UseBorders = false;
            this.HeaderCell.StylePriority.UseFont = false;
            this.HeaderCell.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.EmptyCell});
            this.xrTableRow4.Name = "xrTableRow4";
            resources.ApplyResources(this.xrTableRow4, "xrTableRow4");
            // 
            // EmptyCell
            // 
            this.EmptyCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.EmptyCell.Name = "EmptyCell";
            this.EmptyCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.EmptyCell, "EmptyCell");
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.DiseasesHeaderCell,
            this.SpeciesHeaderCell});
            this.xrTableRow1.Name = "xrTableRow1";
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            // 
            // DiseasesHeaderCell
            // 
            resources.ApplyResources(this.DiseasesHeaderCell, "DiseasesHeaderCell");
            this.DiseasesHeaderCell.Multiline = true;
            this.DiseasesHeaderCell.Name = "DiseasesHeaderCell";
            this.DiseasesHeaderCell.StylePriority.UseFont = false;
            // 
            // SpeciesHeaderCell
            // 
            resources.ApplyResources(this.SpeciesHeaderCell, "SpeciesHeaderCell");
            this.SpeciesHeaderCell.Name = "SpeciesHeaderCell";
            this.SpeciesHeaderCell.StylePriority.UseFont = false;
            // 
            // m_DataSet
            // 
            this.m_DataSet.DataSetName = "SessionFarmReportDataSet";
            this.m_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // m_Adapter
            // 
            this.m_Adapter.ClearBeforeFill = true;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.MainTable});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Name = "ReportHeader";
            // 
            // SessionDiagnosisReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportHeader});
            this.DataAdapter = this.m_Adapter;
            this.DataMember = "SessionDiagnosis";
            this.DataSource = this.m_DataSet;
            resources.ApplyResources(this, "$this");
            this.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable MainTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell DiseasesHeaderCell;
        private SessionDiagnosisDataSet m_DataSet;
        private SessionDiagnosisAdapter m_Adapter;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell DiseasesCell;
        private DevExpress.XtraReports.UI.XRTableCell SpeciesCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell HeaderCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell EmptyCell;
        private DevExpress.XtraReports.UI.XRTableCell SpeciesHeaderCell;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
    }
}
