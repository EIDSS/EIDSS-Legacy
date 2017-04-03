namespace EIDSS.Reports.BaseControls.Report
{
    partial class BaseIntervalReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseIntervalReport));
            this.tableInterval = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellInputStartDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellDefis = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellInputEndDate = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableInterval)).BeginInit();
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
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.StylePriority.UseBorders = false;
            // 
            // cellReportHeader
            // 
            this.cellReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tableInterval});
            this.cellReportHeader.StylePriority.UseBorders = false;
            this.cellReportHeader.StylePriority.UseFont = false;
            this.cellReportHeader.StylePriority.UseTextAlignment = false;
            this.cellReportHeader.Controls.SetChildIndex(this.tableInterval, 0);
            this.cellReportHeader.Controls.SetChildIndex(this.lblReportName, 0);
            // 
            // cellBaseSite
            // 
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
            // 
            // cellBaseCountry
            // 
            this.cellBaseCountry.StylePriority.UseFont = false;
            // 
            // tableBaseHeader
            // 
            this.tableBaseHeader.StylePriority.UseBorders = false;
            this.tableBaseHeader.StylePriority.UseBorderWidth = false;
            this.tableBaseHeader.StylePriority.UseFont = false;
            this.tableBaseHeader.StylePriority.UsePadding = false;
            this.tableBaseHeader.StylePriority.UseTextAlignment = false;
            // 
            // tableInterval
            // 
            this.tableInterval.Borders = DevExpress.XtraPrinting.BorderSide.None;
            resources.ApplyResources(this.tableInterval, "tableInterval");
            this.tableInterval.Name = "tableInterval";
            this.tableInterval.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableInterval.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.tableInterval.StylePriority.UseBorders = false;
            this.tableInterval.StylePriority.UseFont = false;
            this.tableInterval.StylePriority.UsePadding = false;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellInputStartDate,
            this.cellDefis,
            this.cellInputEndDate});
            this.xrTableRow10.Name = "xrTableRow10";
            resources.ApplyResources(this.xrTableRow10, "xrTableRow10");
            // 
            // cellInputStartDate
            // 
            resources.ApplyResources(this.cellInputStartDate, "cellInputStartDate");
            this.cellInputStartDate.Name = "cellInputStartDate";
            this.cellInputStartDate.StylePriority.UseFont = false;
            this.cellInputStartDate.StylePriority.UseTextAlignment = false;
            // 
            // cellDefis
            // 
            resources.ApplyResources(this.cellDefis, "cellDefis");
            this.cellDefis.Name = "cellDefis";
            this.cellDefis.StylePriority.UseFont = false;
            this.cellDefis.StylePriority.UseTextAlignment = false;
            // 
            // cellInputEndDate
            // 
            resources.ApplyResources(this.cellInputEndDate, "cellInputEndDate");
            this.cellInputEndDate.Name = "cellInputEndDate";
            this.cellInputEndDate.StylePriority.UseFont = false;
            this.cellInputEndDate.StylePriority.UseTextAlignment = false;
            // 
            // BaseIntervalReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader});
            this.Version = "13.1";
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        protected DevExpress.XtraReports.UI.XRTable tableInterval;
        protected DevExpress.XtraReports.UI.XRTableCell cellInputStartDate;
        protected DevExpress.XtraReports.UI.XRTableCell cellInputEndDate;
        protected DevExpress.XtraReports.UI.XRTableCell cellDefis;


    }
}