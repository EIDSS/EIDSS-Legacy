
namespace EIDSS.Reports.BaseControls.Report
{
    partial class BaseDateReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDateReport));
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellYear = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellInputYear = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellMonth = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellInputMonth = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
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
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            resources.ApplyResources(this.Detail, "Detail");
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
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.StylePriority.UseBorders = false;
            // 
            // cellReportHeader
            // 
            this.cellReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.cellReportHeader.StylePriority.UseBorders = false;
            this.cellReportHeader.StylePriority.UseFont = false;
            this.cellReportHeader.StylePriority.UseTextAlignment = false;
            this.cellReportHeader.Controls.SetChildIndex(this.xrTable4, 0);
            this.cellReportHeader.Controls.SetChildIndex(this.lblReportName, 0);
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
            // xrTable4
            // 
            this.xrTable4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            resources.ApplyResources(this.xrTable4, "xrTable4");
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UseFont = false;
            this.xrTable4.StylePriority.UsePadding = false;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellYear,
            this.cellInputYear,
            this.cellMonth,
            this.cellInputMonth});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 0.18599311136624569;
            // 
            // cellYear
            // 
            resources.ApplyResources(this.cellYear, "cellYear");
            this.cellYear.Name = "cellYear";
            this.cellYear.StylePriority.UseFont = false;
            this.cellYear.StylePriority.UseTextAlignment = false;
            this.cellYear.Weight = 0.86954574829697662;
            // 
            // cellInputYear
            // 
            this.cellInputYear.Name = "cellInputYear";
            this.cellInputYear.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.cellInputYear, "cellInputYear");
            this.cellInputYear.Weight = 0.34370177702772203;
            // 
            // cellMonth
            // 
            resources.ApplyResources(this.cellMonth, "cellMonth");
            this.cellMonth.Name = "cellMonth";
            this.cellMonth.StylePriority.UseFont = false;
            this.cellMonth.StylePriority.UseTextAlignment = false;
            this.cellMonth.Weight = 0.42021340034346494;
            // 
            // cellInputMonth
            // 
            this.cellInputMonth.Name = "cellInputMonth";
            this.cellInputMonth.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.cellInputMonth, "cellInputMonth");
            this.cellInputMonth.Weight = 1.0441309714525831;
            // 
            // BaseDateReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader});
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell cellYear;
        private DevExpress.XtraReports.UI.XRTableCell cellMonth;
        private DevExpress.XtraReports.UI.XRTableCell cellInputYear;
        private DevExpress.XtraReports.UI.XRTableCell cellInputMonth;
        protected DevExpress.XtraReports.UI.XRTable xrTable4;


    }
}