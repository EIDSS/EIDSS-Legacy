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
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // cellLanguage
            // 
            resources.ApplyResources(this.cellLanguage, "cellLanguage");
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
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.StylePriority.UseBorders = false;
            // 
            // ReportHeader
            // 
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            
            // 
            // xrPageInfo1
            // 
            resources.ApplyResources(this.xrPageInfo1, "xrPageInfo1");
            this.xrPageInfo1.StylePriority.UseBorders = false;
            // 
            // cellReportHeader
            // 
            this.cellReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tableInterval});
            resources.ApplyResources(this.cellReportHeader, "cellReportHeader");
            this.cellReportHeader.StylePriority.UseBorders = false;
            this.cellReportHeader.StylePriority.UseFont = false;
            this.cellReportHeader.StylePriority.UseTextAlignment = false;
            this.cellReportHeader.Controls.SetChildIndex(this.tableInterval, 0);
            this.cellReportHeader.Controls.SetChildIndex(this.lblReportName, 0);
            // 
            // cellBaseSite
            // 
            resources.ApplyResources(this.cellBaseSite, "cellBaseSite");
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
            // 
            // cellBaseCountry
            // 
            resources.ApplyResources(this.cellBaseCountry, "cellBaseCountry");
            this.cellBaseCountry.StylePriority.UseFont = false;
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
            resources.ApplyResources(this.xrTableRow10, "xrTableRow10");
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 0.26865671641791045D;
            // 
            // cellInputStartDate
            // 
            resources.ApplyResources(this.cellInputStartDate, "cellInputStartDate");
            this.cellInputStartDate.Name = "cellInputStartDate";
            this.cellInputStartDate.StylePriority.UseFont = false;
            this.cellInputStartDate.StylePriority.UseTextAlignment = false;
            this.cellInputStartDate.Weight = 0.88952849345181539D;
            // 
            // cellDefis
            // 
            resources.ApplyResources(this.cellDefis, "cellDefis");
            this.cellDefis.Name = "cellDefis";
            this.cellDefis.StylePriority.UseFont = false;
            this.cellDefis.StylePriority.UseTextAlignment = false;
            this.cellDefis.Weight = 0.031135701733142042D;
            // 
            // cellInputEndDate
            // 
            resources.ApplyResources(this.cellInputEndDate, "cellInputEndDate");
            this.cellInputEndDate.Name = "cellInputEndDate";
            this.cellInputEndDate.StylePriority.UseFont = false;
            this.cellInputEndDate.StylePriority.UseTextAlignment = false;
            this.cellInputEndDate.Weight = 0.936343821606215D;
            // 
            // BaseIntervalReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader});
            resources.ApplyResources(this, "$this");
            this.Version = "11.1";
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell cellInputStartDate;
        private DevExpress.XtraReports.UI.XRTableCell cellDefis;
        private DevExpress.XtraReports.UI.XRTableCell cellInputEndDate;
        protected DevExpress.XtraReports.UI.XRTable tableInterval;


    }
}