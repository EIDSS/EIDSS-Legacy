
using EIDSS.Reports.Document.Lim.Transfer;
using EIDSS.Reports.Document.VectorSurveillance.VsSessionDataSetTableAdapters;

namespace EIDSS.Reports.Document.VectorSurveillance
{
    partial class SessionReport
    {


        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionReport));
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.m_SessionReportDataSet = new EIDSS.Reports.Document.VectorSurveillance.VsSessionDataSet();
            this.m_SessionAdapter = new EIDSS.Reports.Document.VectorSurveillance.VsSessionDataSetTableAdapters.SessionAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_SessionReportDataSet)).BeginInit();
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
            this.Detail.Expanded = false;
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PageHeader.Expanded = false;
            resources.ApplyResources(this.PageHeader, "PageHeader");
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
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
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
            this.cellReportHeader.Weight = 3.4885848808099285D;
            // 
            // cellBaseSite
            // 
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
            this.cellBaseSite.Weight = 4.1706899022784532D;
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
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            resources.ApplyResources(this.xrTableCell7, "xrTableCell7");
            this.xrTableCell7.Weight = 1.1593548387096773D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimSampleTransferForm.DateSent", "{0:dd/MM/yyyy}")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.Weight = 1.8406451612903227D;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            resources.ApplyResources(this.Detail1, "Detail1");
            this.Detail1.Name = "Detail1";
            // 
            // ReportFooter
            // 
            resources.ApplyResources(this.ReportFooter, "ReportFooter");
            this.ReportFooter.Name = "ReportFooter";
            // 
            // m_SessionReportDataSet
            // 
            this.m_SessionReportDataSet.DataSetName = "SessionReportDataSet";
            this.m_SessionReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // m_SessionAdapter
            // 
            this.m_SessionAdapter.ClearBeforeFill = true;
            // 
            // SessionReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.DetailReport,
            this.ReportFooter});
            this.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            resources.ApplyResources(this, "$this");
            this.Version = "11.1";
            this.Controls.SetChildIndex(this.ReportFooter, 0);
            this.Controls.SetChildIndex(this.DetailReport, 0);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.PageFooter, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.baseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_SessionReportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private VsSessionDataSet m_SessionReportDataSet;
        private SessionAdapter m_SessionAdapter;
        




    }
}