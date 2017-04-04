using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.m_BaseDataSet = new EIDSS.Reports.BaseControls.BaseDataSet();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.tableBaseHeader = new DevExpress.XtraReports.UI.XRTable();
            this.rowReportName = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellBaseLeftHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableBaseInnerHeader = new DevExpress.XtraReports.UI.XRTable();
            this.rowBaseDate = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellDateHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowBaseTime = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellTimeHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellTime = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowBaseLanguage = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellLanguageHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellLanguage = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellReportHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblReportName = new DevExpress.XtraReports.UI.XRLabel();
            this.rowBaseCountrySite = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellBaseCountry = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellBaseSite = new DevExpress.XtraReports.UI.XRTableCell();
            this.m_BaseAdapter = new EIDSS.Reports.BaseControls.BaseDataSetTableAdapters.BaseAdapter();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseInnerHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            // 
            // PageHeader
            // 
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UsePadding = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.StylePriority.UseBorders = false;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            resources.ApplyResources(this.xrPageInfo1, "xrPageInfo1");
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.StylePriority.UseBorders = false;
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // m_BaseDataSet
            // 
            this.m_BaseDataSet.DataSetName = "BaseDataSet";
            this.m_BaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tableBaseHeader});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Name = "ReportHeader";
            // 
            // tableBaseHeader
            // 
            this.tableBaseHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableBaseHeader.BorderWidth = 2F;
            resources.ApplyResources(this.tableBaseHeader, "tableBaseHeader");
            this.tableBaseHeader.Name = "tableBaseHeader";
            this.tableBaseHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableBaseHeader.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
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
            this.rowReportName.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellBaseLeftHeader,
            this.cellReportHeader});
            this.rowReportName.Name = "rowReportName";
            resources.ApplyResources(this.rowReportName, "rowReportName");
            // 
            // cellBaseLeftHeader
            // 
            this.cellBaseLeftHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tableBaseInnerHeader});
            this.cellBaseLeftHeader.Name = "cellBaseLeftHeader";
            resources.ApplyResources(this.cellBaseLeftHeader, "cellBaseLeftHeader");
            // 
            // tableBaseInnerHeader
            // 
            this.tableBaseInnerHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableBaseInnerHeader.BorderWidth = 2F;
            resources.ApplyResources(this.tableBaseInnerHeader, "tableBaseInnerHeader");
            this.tableBaseInnerHeader.Name = "tableBaseInnerHeader";
            this.tableBaseInnerHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableBaseInnerHeader.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
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
            this.rowBaseDate.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellDateHeader,
            this.cellDate});
            this.rowBaseDate.Name = "rowBaseDate";
            resources.ApplyResources(this.rowBaseDate, "rowBaseDate");
            // 
            // cellDateHeader
            // 
            this.cellDateHeader.Name = "cellDateHeader";
            resources.ApplyResources(this.cellDateHeader, "cellDateHeader");
            // 
            // cellDate
            // 
            this.cellDate.Name = "cellDate";
            this.cellDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100F);
            resources.ApplyResources(this.cellDate, "cellDate");
            // 
            // rowBaseTime
            // 
            this.rowBaseTime.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellTimeHeader,
            this.cellTime});
            this.rowBaseTime.Name = "rowBaseTime";
            this.rowBaseTime.StylePriority.UseBorders = false;
            resources.ApplyResources(this.rowBaseTime, "rowBaseTime");
            // 
            // cellTimeHeader
            // 
            this.cellTimeHeader.Name = "cellTimeHeader";
            resources.ApplyResources(this.cellTimeHeader, "cellTimeHeader");
            // 
            // cellTime
            // 
            this.cellTime.Name = "cellTime";
            this.cellTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100F);
            resources.ApplyResources(this.cellTime, "cellTime");
            // 
            // rowBaseLanguage
            // 
            this.rowBaseLanguage.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellLanguageHeader,
            this.cellLanguage});
            this.rowBaseLanguage.Name = "rowBaseLanguage";
            resources.ApplyResources(this.rowBaseLanguage, "rowBaseLanguage");
            // 
            // cellLanguageHeader
            // 
            this.cellLanguageHeader.Multiline = true;
            this.cellLanguageHeader.Name = "cellLanguageHeader";
            resources.ApplyResources(this.cellLanguageHeader, "cellLanguageHeader");
            // 
            // cellLanguage
            // 
            this.cellLanguage.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sprepGetBaseParameters.LanguageName")});
            this.cellLanguage.Name = "cellLanguage";
            this.cellLanguage.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100F);
            this.cellLanguage.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.cellLanguage, "cellLanguage");
            // 
            // cellReportHeader
            // 
            this.cellReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblReportName});
            resources.ApplyResources(this.cellReportHeader, "cellReportHeader");
            this.cellReportHeader.Name = "cellReportHeader";
            this.cellReportHeader.StylePriority.UseBorders = false;
            this.cellReportHeader.StylePriority.UseFont = false;
            this.cellReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // lblReportName
            // 
            this.lblReportName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblReportName.BorderWidth = 0F;
            resources.ApplyResources(this.lblReportName, "lblReportName");
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReportName.StylePriority.UseBorders = false;
            this.lblReportName.StylePriority.UseBorderWidth = false;
            this.lblReportName.StylePriority.UseFont = false;
            this.lblReportName.StylePriority.UseTextAlignment = false;
            // 
            // rowBaseCountrySite
            // 
            this.rowBaseCountrySite.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellBaseCountry,
            this.cellBaseSite});
            this.rowBaseCountrySite.Name = "rowBaseCountrySite";
            this.rowBaseCountrySite.StylePriority.UseFont = false;
            resources.ApplyResources(this.rowBaseCountrySite, "rowBaseCountrySite");
            // 
            // cellBaseCountry
            // 
            this.cellBaseCountry.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sprepGetBaseParameters.CountryName")});
            this.cellBaseCountry.Name = "cellBaseCountry";
            resources.ApplyResources(this.cellBaseCountry, "cellBaseCountry");
            // 
            // cellBaseSite
            // 
            this.cellBaseSite.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sprepGetBaseParameters.SiteName")});
            resources.ApplyResources(this.cellBaseSite, "cellBaseSite");
            this.cellBaseSite.Name = "cellBaseSite";
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
            // 
            // m_BaseAdapter
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
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
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
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1});
            this.Version = "15.1";
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseInnerHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

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