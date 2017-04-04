namespace EIDSS.Reports.BaseControls.Report
{
    partial class ErrorReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lblMessage = new DevExpress.XtraReports.UI.XRLabel();
            this.lblStackTrace = new DevExpress.XtraReports.UI.XRLabel();
            this.lblbHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 0;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            resources.ApplyResources(this.Detail, "Detail");
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblMessage,
            this.lblStackTrace,
            this.lblbHeader});
            this.PageHeader.Height = 572;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            resources.ApplyResources(this.PageHeader, "PageHeader");
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Multiline = true;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblMessage.StylePriority.UseFont = false;
            this.lblMessage.StylePriority.UseTextAlignment = false;
            // 
            // lblStackTrace
            // 
            resources.ApplyResources(this.lblStackTrace, "lblStackTrace");
            this.lblStackTrace.Multiline = true;
            this.lblStackTrace.Name = "lblStackTrace";
            this.lblStackTrace.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblStackTrace.StylePriority.UseFont = false;
            // 
            // lblbHeader
            // 
            resources.ApplyResources(this.lblbHeader, "lblbHeader");
            this.lblbHeader.Name = "lblbHeader";
            this.lblbHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblbHeader.StylePriority.UseFont = false;
            this.lblbHeader.StylePriority.UseTextAlignment = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            resources.ApplyResources(this.PageFooter, "PageFooter");
            // 
            // ErrorReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter});
            this.ExportOptions.Csv.EncodingType = ((DevExpress.XtraPrinting.EncodingType)(resources.GetObject("ErrorReport.ExportOptions.Csv.EncodingType")));
            this.ExportOptions.Html.CharacterSet = resources.GetString("ErrorReport.ExportOptions.Html.CharacterSet");
            this.ExportOptions.Html.Title = resources.GetString("ErrorReport.ExportOptions.Html.Title");
            this.ExportOptions.Mht.CharacterSet = resources.GetString("ErrorReport.ExportOptions.Mht.CharacterSet");
            this.ExportOptions.Mht.Title = resources.GetString("ErrorReport.ExportOptions.Mht.Title");
            this.ExportOptions.Pdf.DocumentOptions.Application = resources.GetString("ErrorReport.ExportOptions.Pdf.DocumentOptions.Application");
            this.ExportOptions.Pdf.DocumentOptions.Author = resources.GetString("ErrorReport.ExportOptions.Pdf.DocumentOptions.Author");
            this.ExportOptions.Pdf.DocumentOptions.Keywords = resources.GetString("ErrorReport.ExportOptions.Pdf.DocumentOptions.Keywords");
            this.ExportOptions.Pdf.DocumentOptions.Subject = resources.GetString("ErrorReport.ExportOptions.Pdf.DocumentOptions.Subject");
            this.ExportOptions.Pdf.DocumentOptions.Title = resources.GetString("ErrorReport.ExportOptions.Pdf.DocumentOptions.Title");
            this.ExportOptions.Text.EncodingType = ((DevExpress.XtraPrinting.EncodingType)(resources.GetObject("ErrorReport.ExportOptions.Text.EncodingType")));
            this.ExportOptions.Xls.SheetName = resources.GetString("ErrorReport.ExportOptions.Xls.SheetName");
            this.ExportOptions.Xlsx.SheetName = resources.GetString("ErrorReport.ExportOptions.Xlsx.SheetName");
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "9.1";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel lblStackTrace;
        private DevExpress.XtraReports.UI.XRLabel lblbHeader;
        private DevExpress.XtraReports.UI.XRLabel lblMessage;
    }
}
