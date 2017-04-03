namespace EIDSS.RAM.Components
{
    partial class PivotReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PivotReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid = new EIDSS.RAM.Components.RamPivotReportGrid();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lblHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.pageNumber = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblFooter = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lblParamValue = new DevExpress.XtraReports.UI.XRLabel();
            this.lblParamName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblReportHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrPivotGrid
            // 
            resources.ApplyResources(this.xrPivotGrid, "xrPivotGrid");
            this.xrPivotGrid.Name = "xrPivotGrid";
            this.xrPivotGrid.OptionsChartDataSource.UpdateDelay = 300;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblHeader});
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.PrintOn = DevExpress.XtraReports.UI.PrintOnPages.NotWithReportHeader;
            this.PageHeader.StylePriority.UseTextAlignment = false;
            // 
            // lblHeader
            // 
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.Multiline = true;
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblHeader.StylePriority.UseFont = false;
            this.lblHeader.StylePriority.UseTextAlignment = false;
            this.lblHeader.WordWrap = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageNumber,
            this.lblFooter});
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // pageNumber
            // 
            resources.ApplyResources(this.pageNumber, "pageNumber");
            this.pageNumber.Name = "pageNumber";
            this.pageNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageNumber.StylePriority.UseTextAlignment = false;
            // 
            // lblFooter
            // 
            resources.ApplyResources(this.lblFooter, "lblFooter");
            this.lblFooter.Multiline = true;
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblParamValue,
            this.lblParamName,
            this.lblReportHeader});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lblParamValue
            // 
            resources.ApplyResources(this.lblParamValue, "lblParamValue");
            this.lblParamValue.Multiline = true;
            this.lblParamValue.Name = "lblParamValue";
            this.lblParamValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblParamValue.StylePriority.UseFont = false;
            this.lblParamValue.StylePriority.UseTextAlignment = false;
            // 
            // lblParamName
            // 
            resources.ApplyResources(this.lblParamName, "lblParamName");
            this.lblParamName.Name = "lblParamName";
            this.lblParamName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblParamName.StylePriority.UseFont = false;
            this.lblParamName.StylePriority.UseTextAlignment = false;
            // 
            // lblReportHeader
            // 
            resources.ApplyResources(this.lblReportHeader, "lblReportHeader");
            this.lblReportHeader.Multiline = true;
            this.lblReportHeader.Name = "lblReportHeader";
            this.lblReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReportHeader.StylePriority.UseFont = false;
            this.lblReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.Name = "xrControlStyle1";
            this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
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
            // PivotReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "11.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private RamPivotReportGrid xrPivotGrid;
        private DevExpress.XtraReports.UI.XRLabel lblHeader;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule1;
        private DevExpress.XtraReports.UI.XRLabel lblFooter;
        private DevExpress.XtraReports.UI.XRPageInfo pageNumber;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblReportHeader;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.UI.XRLabel lblParamName;
        private DevExpress.XtraReports.UI.XRLabel lblParamValue;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}