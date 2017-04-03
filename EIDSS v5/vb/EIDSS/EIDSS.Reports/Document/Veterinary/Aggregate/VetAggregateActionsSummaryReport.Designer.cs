using EIDSS.Reports.BaseControls.Aggregate;
using EIDSS.Reports.Document.Human.Aggregate;

namespace EIDSS.Reports.Document.Veterinary.Aggregate
{
    partial class VetAggregateActionsSummaryReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetAggregateActionsSummaryReport));
            this.xrSubreportAdmUnit = new DevExpress.XtraReports.UI.XRSubreport();
            this.admUnitReport1 = new EIDSS.Reports.BaseControls.Aggregate.AdmUnitReport();
            this.xrSubreportTimeUnit = new DevExpress.XtraReports.UI.XRSubreport();
            this.timeUnitReport1 = new EIDSS.Reports.BaseControls.Aggregate.TimeUnitReport();
            this.FlexSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.FlexSubreportSan = new DevExpress.XtraReports.UI.XRSubreport();
            this.FlexSubreportPro = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrPageBreak2 = new DevExpress.XtraReports.UI.XRPageBreak();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admUnitReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUnitReport1)).BeginInit();
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
            resources.ApplyResources(this.PageHeader, "PageHeader");
            // 
            // PageFooter
            // 
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.StylePriority.UseBorders = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageBreak2,
            this.xrPageBreak1,
            this.FlexSubreportPro,
            this.FlexSubreportSan,
            this.FlexSubreport,
            this.xrSubreportTimeUnit,
            this.xrSubreportAdmUnit});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.StylePriority.UseFont = false;
            this.ReportHeader.Controls.SetChildIndex(this.tableBaseHeader, 0);
            this.ReportHeader.Controls.SetChildIndex(this.xrSubreportAdmUnit, 0);
            this.ReportHeader.Controls.SetChildIndex(this.xrSubreportTimeUnit, 0);
            this.ReportHeader.Controls.SetChildIndex(this.FlexSubreport, 0);
            this.ReportHeader.Controls.SetChildIndex(this.FlexSubreportSan, 0);
            this.ReportHeader.Controls.SetChildIndex(this.FlexSubreportPro, 0);
            this.ReportHeader.Controls.SetChildIndex(this.xrPageBreak1, 0);
            this.ReportHeader.Controls.SetChildIndex(this.xrPageBreak2, 0);
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
            this.cellReportHeader.Weight = 2.4334737611816486;
            // 
            // cellBaseSite
            // 
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
            this.cellBaseSite.Weight = 2.9090210436034161;
            // 
            // cellBaseCountry
            // 
            this.cellBaseCountry.Weight = 1.0796091999487354;
            // 
            // cellBaseLeftHeader
            // 
            this.cellBaseLeftHeader.Weight = 0.90214643196245714;
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
            resources.ApplyResources(this.xrSubreportAdmUnit, "xrSubreportAdmUnit");
            this.xrSubreportAdmUnit.Name = "xrSubreportAdmUnit";
            this.xrSubreportAdmUnit.ReportSource = this.admUnitReport1;
            // 
            // xrSubreportTimeUnit
            // 
            resources.ApplyResources(this.xrSubreportTimeUnit, "xrSubreportTimeUnit");
            this.xrSubreportTimeUnit.Name = "xrSubreportTimeUnit";
            this.xrSubreportTimeUnit.ReportSource = this.timeUnitReport1;
            // 
            // FlexSubreport
            // 
            resources.ApplyResources(this.FlexSubreport, "FlexSubreport");
            this.FlexSubreport.Name = "FlexSubreport";
            // 
            // FlexSubreportSan
            // 
            resources.ApplyResources(this.FlexSubreportSan, "FlexSubreportSan");
            this.FlexSubreportSan.Name = "FlexSubreportSan";
            // 
            // FlexSubreportPro
            // 
            resources.ApplyResources(this.FlexSubreportPro, "FlexSubreportPro");
            this.FlexSubreportPro.Name = "FlexSubreportPro";
            // 
            // xrPageBreak1
            // 
            resources.ApplyResources(this.xrPageBreak1, "xrPageBreak1");
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrPageBreak2
            // 
            resources.ApplyResources(this.xrPageBreak2, "xrPageBreak2");
            this.xrPageBreak2.Name = "xrPageBreak2";
            // 
            // VetAggregateActionsSummaryReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader});
            this.Landscape = true;
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admUnitReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUnitReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRSubreport xrSubreportTimeUnit;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreportAdmUnit;
        private TimeUnitReport timeUnitReport1;
        private AdmUnitReport admUnitReport1;
        private DevExpress.XtraReports.UI.XRSubreport FlexSubreportPro;
        private DevExpress.XtraReports.UI.XRSubreport FlexSubreportSan;
        private DevExpress.XtraReports.UI.XRSubreport FlexSubreport;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak2;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;




    }
}