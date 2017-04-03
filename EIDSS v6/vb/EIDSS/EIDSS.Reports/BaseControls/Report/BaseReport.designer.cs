using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;

namespace EIDSS.Reports.BaseControls.Report
{
    partial class BaseReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected IContainer components;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(BaseReport));
            this.Detail = new DetailBand();
            this.PageHeader = new PageHeaderBand();
            this.PageFooter = new PageFooterBand();
            this.xrPageInfo1 = new XRPageInfo();
            this.formattingRule1 = new FormattingRule();
            this.m_BaseDataSet = new BaseDataSet();
            this.ReportHeader = new ReportHeaderBand();
            this.tableBaseHeader = new XRTable();
            this.rowReportName = new XRTableRow();
            this.cellBaseLeftHeader = new XRTableCell();
            this.tableBaseInnerHeader = new XRTable();
            this.rowBaseDate = new XRTableRow();
            this.cellDateHeader = new XRTableCell();
            this.cellDate = new XRTableCell();
            this.rowBaseTime = new XRTableRow();
            this.cellTimeHeader = new XRTableCell();
            this.cellTime = new XRTableCell();
            this.rowBaseLanguage = new XRTableRow();
            this.cellLanguageHeader = new XRTableCell();
            this.cellLanguage = new XRTableCell();
            this.cellReportHeader = new XRTableCell();
            this.lblReportName = new XRLabel();
            this.rowBaseCountrySite = new XRTableRow();
            this.cellBaseCountry = new XRTableCell();
            this.cellBaseSite = new XRTableCell();
            this.m_BaseAdapter = new BaseAdapter();
            this.topMarginBand1 = new TopMarginBand();
            this.bottomMarginBand1 = new BottomMarginBand();
            ((ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((ISupportInitialize)(this.tableBaseInnerHeader)).BeginInit();
            ((ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new PaddingInfo(0, 2, 0, 2, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            // 
            // PageHeader
            // 
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new PaddingInfo(2, 2, 2, 2, 100F);
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UsePadding = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Borders = ((BorderSide)((((BorderSide.Left | BorderSide.Top)
                        | BorderSide.Right)
                        | BorderSide.Bottom)));
            this.PageFooter.Controls.AddRange(new XRControl[] {
            this.xrPageInfo1});
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.StylePriority.UseBorders = false;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Borders = BorderSide.None;
            resources.ApplyResources(this.xrPageInfo1, "xrPageInfo1");
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.StylePriority.UseBorders = false;
            // 
            // formattingRule1
            // 
            this.formattingRule1.DataSource = this.m_BaseDataSet;
            this.formattingRule1.Name = "formattingRule1";
            // 
            // baseDataSet1
            // 
            this.m_BaseDataSet.DataSetName = "BaseDataSet";
            this.m_BaseDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new XRControl[] {
            this.tableBaseHeader});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Name = "ReportHeader";
            // 
            // tableBaseHeader
            // 
            this.tableBaseHeader.Borders = ((BorderSide)((((BorderSide.Left | BorderSide.Top)
                        | BorderSide.Right)
                        | BorderSide.Bottom)));
            this.tableBaseHeader.BorderWidth = 2;
            resources.ApplyResources(this.tableBaseHeader, "tableBaseHeader");
            this.tableBaseHeader.Name = "tableBaseHeader";
            this.tableBaseHeader.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            this.tableBaseHeader.Rows.AddRange(new XRTableRow[] {
            this.rowReportName,
            this.rowBaseCountrySite});
            this.tableBaseHeader.StylePriority.UseBorders = false;
            this.tableBaseHeader.StylePriority.UseBorderWidth = false;
            this.tableBaseHeader.StylePriority.UseFont = false;
            this.tableBaseHeader.StylePriority.UsePadding = false;
            this.tableBaseHeader.StylePriority.UseTextAlignment = false;
            // 
            // rowReportName
            // 
            this.rowReportName.Cells.AddRange(new XRTableCell[] {
            this.cellBaseLeftHeader,
            this.cellReportHeader});
            resources.ApplyResources(this.rowReportName, "rowReportName");
            this.rowReportName.Name = "rowReportName";
            this.rowReportName.Weight = 3.0454320987654322;
            // 
            // cellBaseLeftHeader
            // 
            this.cellBaseLeftHeader.Controls.AddRange(new XRControl[] {
            this.tableBaseInnerHeader});
            resources.ApplyResources(this.cellBaseLeftHeader, "cellBaseLeftHeader");
            this.cellBaseLeftHeader.Name = "cellBaseLeftHeader";
            this.cellBaseLeftHeader.Weight = 1.1309915624438993;
            // 
            // tableBaseInnerHeader
            // 
            this.tableBaseInnerHeader.Borders = ((BorderSide)((((BorderSide.Left | BorderSide.Top)
                        | BorderSide.Right)
                        | BorderSide.Bottom)));
            this.tableBaseInnerHeader.BorderWidth = 2;
            resources.ApplyResources(this.tableBaseInnerHeader, "tableBaseInnerHeader");
            this.tableBaseInnerHeader.Name = "tableBaseInnerHeader";
            this.tableBaseInnerHeader.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            this.tableBaseInnerHeader.Rows.AddRange(new XRTableRow[] {
            this.rowBaseDate,
            this.rowBaseTime,
            this.rowBaseLanguage});
            this.tableBaseInnerHeader.StylePriority.UseBorders = false;
            this.tableBaseInnerHeader.StylePriority.UseBorderWidth = false;
            this.tableBaseInnerHeader.StylePriority.UseFont = false;
            this.tableBaseInnerHeader.StylePriority.UsePadding = false;
            this.tableBaseInnerHeader.StylePriority.UseTextAlignment = false;
            // 
            // rowBaseDate
            // 
            this.rowBaseDate.Cells.AddRange(new XRTableCell[] {
            this.cellDateHeader,
            this.cellDate});
            resources.ApplyResources(this.rowBaseDate, "rowBaseDate");
            this.rowBaseDate.Name = "rowBaseDate";
            this.rowBaseDate.Weight = 1;
            // 
            // cellDateHeader
            // 
            resources.ApplyResources(this.cellDateHeader, "cellDateHeader");
            this.cellDateHeader.Name = "cellDateHeader";
            this.cellDateHeader.Weight = 0.40595618793024008;
            // 
            // cellDate
            // 
            resources.ApplyResources(this.cellDate, "cellDate");
            this.cellDate.Name = "cellDate";
            this.cellDate.Padding = new PaddingInfo(4, 4, 0, 0, 100F);
            this.cellDate.Weight = 0.2044202108490073;
            // 
            // rowBaseTime
            // 
            this.rowBaseTime.Cells.AddRange(new XRTableCell[] {
            this.cellTimeHeader,
            this.cellTime});
            resources.ApplyResources(this.rowBaseTime, "rowBaseTime");
            this.rowBaseTime.Name = "rowBaseTime";
            this.rowBaseTime.StylePriority.UseBorders = false;
            this.rowBaseTime.Weight = 1;
            // 
            // cellTimeHeader
            // 
            resources.ApplyResources(this.cellTimeHeader, "cellTimeHeader");
            this.cellTimeHeader.Name = "cellTimeHeader";
            this.cellTimeHeader.Weight = 0.40595618793024008;
            // 
            // cellTime
            // 
            resources.ApplyResources(this.cellTime, "cellTime");
            this.cellTime.Name = "cellTime";
            this.cellTime.Padding = new PaddingInfo(4, 4, 0, 0, 100F);
            this.cellTime.Weight = 0.2044202108490073;
            // 
            // rowBaseLanguage
            // 
            this.rowBaseLanguage.Cells.AddRange(new XRTableCell[] {
            this.cellLanguageHeader,
            this.cellLanguage});
            resources.ApplyResources(this.rowBaseLanguage, "rowBaseLanguage");
            this.rowBaseLanguage.Name = "rowBaseLanguage";
            this.rowBaseLanguage.Weight = 1;
            // 
            // cellLanguageHeader
            // 
            resources.ApplyResources(this.cellLanguageHeader, "cellLanguageHeader");
            this.cellLanguageHeader.Multiline = true;
            this.cellLanguageHeader.Name = "cellLanguageHeader";
            this.cellLanguageHeader.Weight = 0.40595618793024008;
            // 
            // cellLanguage
            // 
            this.cellLanguage.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "sprepGetBaseParameters.LanguageName")});
            resources.ApplyResources(this.cellLanguage, "cellLanguage");
            this.cellLanguage.Name = "cellLanguage";
            this.cellLanguage.Padding = new PaddingInfo(4, 4, 0, 0, 100F);
            this.cellLanguage.StylePriority.UseTextAlignment = false;
            this.cellLanguage.Weight = 0.2044202108490073;
            // 
            // cellReportHeader
            // 
            this.cellReportHeader.Controls.AddRange(new XRControl[] {
            this.lblReportName});
            resources.ApplyResources(this.cellReportHeader, "cellReportHeader");
            this.cellReportHeader.Name = "cellReportHeader";
            this.cellReportHeader.StylePriority.UseBorders = false;
            this.cellReportHeader.StylePriority.UseFont = false;
            this.cellReportHeader.StylePriority.UseTextAlignment = false;
            this.cellReportHeader.Weight = 2.8576386811082521;
            // 
            // lblReportName
            // 
            this.lblReportName.Borders = BorderSide.None;
            this.lblReportName.BorderWidth = 0;
            resources.ApplyResources(this.lblReportName, "lblReportName");
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReportName.StylePriority.UseBorders = false;
            this.lblReportName.StylePriority.UseBorderWidth = false;
            this.lblReportName.StylePriority.UseFont = false;
            this.lblReportName.StylePriority.UseTextAlignment = false;
            // 
            // rowBaseCountrySite
            // 
            this.rowBaseCountrySite.Cells.AddRange(new XRTableCell[] {
            this.cellBaseCountry,
            this.cellBaseSite});
            resources.ApplyResources(this.rowBaseCountrySite, "rowBaseCountrySite");
            this.rowBaseCountrySite.Name = "rowBaseCountrySite";
            this.rowBaseCountrySite.StylePriority.UseFont = false;
            this.rowBaseCountrySite.Weight = 0.95456790123456792;
            // 
            // cellBaseCountry
            // 
            this.cellBaseCountry.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "sprepGetBaseParameters.CountryName")});
            resources.ApplyResources(this.cellBaseCountry, "cellBaseCountry");
            this.cellBaseCountry.Name = "cellBaseCountry";
            this.cellBaseCountry.Weight = 1.1309915624438993;
            // 
            // cellBaseSite
            // 
            this.cellBaseSite.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "sprepGetBaseParameters.SiteName")});
            resources.ApplyResources(this.cellBaseSite, "cellBaseSite");
            this.cellBaseSite.Name = "cellBaseSite";
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
            this.cellBaseSite.Weight = 2.8576386811082521;
            // 
            // sp_rep_BaseParametersTableAdapter
            // 
            this.m_BaseAdapter.ClearBeforeFill = true;
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
            // BaseReport
            // 
            this.Bands.AddRange(new Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DataAdapter = this.m_BaseAdapter;
            this.DataMember = "sprepGetBaseParameters";
            this.DataSource = this.m_BaseDataSet;
            resources.ApplyResources(this, "$this");
            this.FormattingRuleSheet.AddRange(new FormattingRule[] {
            this.formattingRule1});
            this.Landscape = true;
            this.PageHeight = 827;
            this.PageWidth = 1169;

            this.Version = "10.1";
            ((ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((ISupportInitialize)(this.tableBaseInnerHeader)).EndInit();
            ((ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private FormattingRule formattingRule1;
        private XRTableRow rowBaseDate;
        private XRTableCell cellDateHeader;
        private XRTableCell cellDate;
        private XRTableRow rowBaseTime;
        private XRTableCell cellTimeHeader;
        private XRTableCell cellTime;
        private XRTableRow rowBaseLanguage;
        private XRTableCell cellLanguageHeader;
        protected XRTableCell cellLanguage;
        protected XRLabel lblReportName;
        protected DetailBand Detail;
        protected PageHeaderBand PageHeader;
        protected PageFooterBand PageFooter;
        protected BaseAdapter m_BaseAdapter;
        public ReportHeaderBand ReportHeader;
        protected XRPageInfo xrPageInfo1;
        protected BaseDataSet m_BaseDataSet;
        protected XRTableCell cellReportHeader;
        private XRTableRow rowReportName;
        private XRTableRow rowBaseCountrySite;
        private XRTable tableBaseInnerHeader;
        protected XRTableCell cellBaseSite;
        protected XRTableCell cellBaseCountry;
        protected XRTableCell cellBaseLeftHeader;
        protected XRTable tableBaseHeader;
        private TopMarginBand topMarginBand1;
        private BottomMarginBand bottomMarginBand1;
    }
}