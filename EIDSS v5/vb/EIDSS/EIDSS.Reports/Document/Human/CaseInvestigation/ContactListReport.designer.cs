namespace EIDSS.Reports.Document.Human.CaseInvestigation
{
    partial class ContactListReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactListReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.contactListDataSet1 = new EIDSS.Reports.Document.Human.CaseInvestigation.ContactListDataSet();
            this.sp_rep_HUM_CaseForm_ContactsTableAdapter = new EIDSS.Reports.Document.Human.CaseInvestigation.ContactListDataSetTableAdapters.sp_rep_HUM_CaseForm_ContactsTableAdapter();
            this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactListDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Height = 40;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10});
            this.xrTableRow2.Name = "xrTableRow2";
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            this.xrTableRow2.Weight = 0.8;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepHumCaseFormContacts.ContactName", "")});
            this.xrTableCell6.Name = "xrTableCell6";
            resources.ApplyResources(this.xrTableCell6, "xrTableCell6");
            this.xrTableCell6.Weight = 0.63456464379947231;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepHumCaseFormContacts.Relation_Type", "")});
            this.xrTableCell7.Name = "xrTableCell7";
            resources.ApplyResources(this.xrTableCell7, "xrTableCell7");
            this.xrTableCell7.Weight = 0.63456464379947231;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepHumCaseFormContacts.ContactDate", "{0:dd/MM/yyyy}")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell8, "xrTableCell8");
            this.xrTableCell8.Weight = 0.4683377308707124;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepHumCaseFormContacts.PlaceOfContact", "")});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell9, "xrTableCell9");
            this.xrTableCell9.Weight = 0.63456464379947231;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepHumCaseFormContacts.ContactInformation", "")});
            this.xrTableCell10.Name = "xrTableCell10";
            resources.ApplyResources(this.xrTableCell10, "xrTableCell10");
            this.xrTableCell10.Weight = 0.62796833773087068;
            // 
            // PageHeader
            // 
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Height = 0;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.StylePriority.UseFont = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            resources.ApplyResources(this.PageFooter, "PageFooter");
            // 
            // contactListDataSet1
            // 
            this.contactListDataSet1.DataSetName = "ContactListDataSet";
            this.contactListDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_rep_HUM_CaseForm_ContactsTableAdapter
            // 
            this.sp_rep_HUM_CaseForm_ContactsTableAdapter.ClearBeforeFill = true;
            // 
            // xrCrossBandBox1
            // 
            this.xrCrossBandBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandBox1.BorderWidth = 1;
            this.xrCrossBandBox1.EndBand = this.ReportFooter;
            this.xrCrossBandBox1.EndPoint = new System.Drawing.Point(0, 11);
            this.xrCrossBandBox1.Name = "xrCrossBandBox1";
            this.xrCrossBandBox1.StartBand = this.ReportHeader;
            this.xrCrossBandBox1.StartPoint = new System.Drawing.Point(0, 0);
            resources.ApplyResources(this.xrCrossBandBox1, "xrCrossBandBox1");
            this.xrCrossBandBox1.Width = 774;
            // 
            // ReportFooter
            // 
            resources.ApplyResources(this.ReportFooter, "ReportFooter");
            this.ReportFooter.Height = 19;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseFont = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xrLabel3});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Height = 92;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.StylePriority.UseFont = false;
            this.ReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.xrTable1, "xrTable1");
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell1,
            this.xrTableCell5,
            this.xrTableCell2,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            this.xrTableRow1.Weight = 1;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            this.xrTableCell4.Weight = 0.63456464379947231;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            this.xrTableCell1.Weight = 0.63456464379947231;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            resources.ApplyResources(this.xrTableCell5, "xrTableCell5");
            this.xrTableCell5.Weight = 0.4683377308707124;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            this.xrTableCell2.Weight = 0.63456464379947231;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            resources.ApplyResources(this.xrTableCell3, "xrTableCell3");
            this.xrTableCell3.Weight = 0.62796833773087068;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            resources.ApplyResources(this.xrLabel3, "xrLabel3");
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            // 
            // ContactListReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.ReportFooter});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandBox1});
            this.DataAdapter = this.sp_rep_HUM_CaseForm_ContactsTableAdapter;
            this.DataMember = "spRepHumCaseFormContacts";
            this.DataSource = this.contactListDataSet1;
            this.ExportOptions.Csv.EncodingType = ((DevExpress.XtraPrinting.EncodingType)(resources.GetObject("ContactListReport.ExportOptions.Csv.EncodingType")));
            this.ExportOptions.Html.CharacterSet = resources.GetString("ContactListReport.ExportOptions.Html.CharacterSet");
            this.ExportOptions.Html.Title = resources.GetString("ContactListReport.ExportOptions.Html.Title");
            this.ExportOptions.Mht.CharacterSet = resources.GetString("ContactListReport.ExportOptions.Mht.CharacterSet");
            this.ExportOptions.Mht.Title = resources.GetString("ContactListReport.ExportOptions.Mht.Title");
            this.ExportOptions.Pdf.DocumentOptions.Application = resources.GetString("ContactListReport.ExportOptions.Pdf.DocumentOptions.Application");
            this.ExportOptions.Pdf.DocumentOptions.Author = resources.GetString("ContactListReport.ExportOptions.Pdf.DocumentOptions.Author");
            this.ExportOptions.Pdf.DocumentOptions.Keywords = resources.GetString("ContactListReport.ExportOptions.Pdf.DocumentOptions.Keywords");
            this.ExportOptions.Pdf.DocumentOptions.Subject = resources.GetString("ContactListReport.ExportOptions.Pdf.DocumentOptions.Subject");
            this.ExportOptions.Pdf.DocumentOptions.Title = resources.GetString("ContactListReport.ExportOptions.Pdf.DocumentOptions.Title");
            this.ExportOptions.Text.EncodingType = ((DevExpress.XtraPrinting.EncodingType)(resources.GetObject("ContactListReport.ExportOptions.Text.EncodingType")));
            this.ExportOptions.Xls.SheetName = resources.GetString("ContactListReport.ExportOptions.Xls.SheetName");
            this.ExportOptions.Xlsx.SheetName = resources.GetString("ContactListReport.ExportOptions.Xlsx.SheetName");
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
            this.Version = "9.1";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactListDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private ContactListDataSet contactListDataSet1;
        private ContactListDataSetTableAdapters.sp_rep_HUM_CaseForm_ContactsTableAdapter sp_rep_HUM_CaseForm_ContactsTableAdapter;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
    }
}