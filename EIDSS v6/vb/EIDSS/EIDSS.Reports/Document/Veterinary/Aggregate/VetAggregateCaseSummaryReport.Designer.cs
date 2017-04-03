using EIDSS.Reports.BaseControls.Aggregate;
using EIDSS.Reports.Document.Human.Aggregate;

namespace EIDSS.Reports.Document.Veterinary.Aggregate
{
    partial class VetAggregateCaseSummaryReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetAggregateCaseSummaryReport));
            this.xrSubreportAdmUnit = new DevExpress.XtraReports.UI.XRSubreport();
            this.FlexSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
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
            // 
            // PageHeader
            // 
            this.PageHeader.StylePriority.UseBorders = false;
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UsePadding = false;
            this.PageHeader.StylePriority.UseTextAlignment = false;
            // 
            // PageFooter
            // 
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.StylePriority.UseBorders = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.FlexSubreport,
            this.xrSubreportAdmUnit});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.StylePriority.UseFont = false;
            this.ReportHeader.Controls.SetChildIndex(this.tableBaseHeader, 0);
            this.ReportHeader.Controls.SetChildIndex(this.xrSubreportAdmUnit, 0);
            this.ReportHeader.Controls.SetChildIndex(this.FlexSubreport, 0);
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
            // xrSubreportAdmUnit
            // 
            this.xrSubreportAdmUnit.Id = 0;
            resources.ApplyResources(this.xrSubreportAdmUnit, "xrSubreportAdmUnit");
            this.xrSubreportAdmUnit.Name = "xrSubreportAdmUnit";
            this.xrSubreportAdmUnit.ReportSource = new EIDSS.Reports.BaseControls.Aggregate.AdmUnitReport();
            // 
            // FlexSubreport
            // 
            this.FlexSubreport.Id = 0;
            resources.ApplyResources(this.FlexSubreport, "FlexSubreport");
            this.FlexSubreport.Name = "FlexSubreport";
            // 
            // VetAggregateCaseSummaryReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader});
            this.ExportOptions.Xls.SheetName = resources.GetString("VetAggregateCaseSummaryReport.ExportOptions.Xls.SheetName");
            this.ExportOptions.Xlsx.SheetName = resources.GetString("VetAggregateCaseSummaryReport.ExportOptions.Xlsx.SheetName");
            resources.ApplyResources(this, "$this");
            this.Version = "13.1";
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRSubreport xrSubreportAdmUnit;
        private DevExpress.XtraReports.UI.XRSubreport FlexSubreport;




    }
}