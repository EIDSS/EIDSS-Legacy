
using EIDSS.Reports.Document.ActiveSurveillance.SessionReportDataSetTableAdapters;
using EIDSS.Reports.Document.Lim.Transfer;

namespace EIDSS.Reports.Document.ActiveSurveillance
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
            this.DetailReportDiagnosis = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DetailDiagnosis = new DevExpress.XtraReports.UI.DetailBand();
            this.m_DiagnosisSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.m_FarmSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.DetailReportAnimal = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DetailAnimal = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.m_SessionReportDataSet = new EIDSS.Reports.Document.ActiveSurveillance.SessionReportDataSet();
            this.m_SessionAdapter = new EIDSS.Reports.Document.ActiveSurveillance.SessionReportDataSetTableAdapters.SessionTableAdapter();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.SessionIDCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SessionIDCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SessionStatusCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SessionStatusCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SessionDateCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SessionStartDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SeparatorCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SessionEndDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.CampaignIDCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.CampaignIDCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.CampaignNameCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.CampaignNameCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.CampaignTypeCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.CampaignTypeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.SiteCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SiteCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.OfficerCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.OfficerCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DateCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.RegionCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.RegionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.RayonCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.RayonCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TownVillageCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SpaceCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TownVillageCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReportSummary = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DetailSummary = new DevExpress.XtraReports.UI.DetailBand();
            this.m_SummarySubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.DetailReportActions = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DetailActions = new DevExpress.XtraReports.UI.DetailBand();
            this.m_ActionsSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.DetailReportCases = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DetailCases = new DevExpress.XtraReports.UI.DetailBand();
            this.m_CasesSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_SessionReportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
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
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.Controls.SetChildIndex(this.tableBaseHeader, 0);
            this.ReportHeader.Controls.SetChildIndex(this.xrTable2, 0);
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
            // tableBaseHeader
            // 
            resources.ApplyResources(this.tableBaseHeader, "tableBaseHeader");
            this.tableBaseHeader.StylePriority.UseBorders = false;
            this.tableBaseHeader.StylePriority.UseBorderWidth = false;
            this.tableBaseHeader.StylePriority.UseFont = false;
            this.tableBaseHeader.StylePriority.UsePadding = false;
            this.tableBaseHeader.StylePriority.UseTextAlignment = false;
            // 
            // DetailReportDiagnosis
            // 
            this.DetailReportDiagnosis.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailDiagnosis});
            resources.ApplyResources(this.DetailReportDiagnosis, "DetailReportDiagnosis");
            this.DetailReportDiagnosis.Level = 0;
            this.DetailReportDiagnosis.Name = "DetailReportDiagnosis";
            this.DetailReportDiagnosis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            // 
            // DetailDiagnosis
            // 
            this.DetailDiagnosis.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.m_DiagnosisSubreport});
            resources.ApplyResources(this.DetailDiagnosis, "DetailDiagnosis");
            this.DetailDiagnosis.Name = "DetailDiagnosis";
            this.DetailDiagnosis.StylePriority.UseBorders = false;
            this.DetailDiagnosis.StylePriority.UseTextAlignment = false;
            // 
            // m_DiagnosisSubreport
            // 
            resources.ApplyResources(this.m_DiagnosisSubreport, "m_DiagnosisSubreport");
            this.m_DiagnosisSubreport.Name = "m_DiagnosisSubreport";
            this.m_DiagnosisSubreport.ReportSource = new EIDSS.Reports.Document.ActiveSurveillance.SessionDiagnosisReport();
            // 
            // m_FarmSubreport
            // 
            resources.ApplyResources(this.m_FarmSubreport, "m_FarmSubreport");
            this.m_FarmSubreport.Name = "m_FarmSubreport";
            this.m_FarmSubreport.ReportSource = new EIDSS.Reports.Document.ActiveSurveillance.SessionFarmReport();
            // 
            // DetailReportAnimal
            // 
            this.DetailReportAnimal.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailAnimal});
            this.DetailReportAnimal.Level = 1;
            this.DetailReportAnimal.Name = "DetailReportAnimal";
            // 
            // DetailAnimal
            // 
            this.DetailAnimal.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.m_FarmSubreport});
            resources.ApplyResources(this.DetailAnimal, "DetailAnimal");
            this.DetailAnimal.Name = "DetailAnimal";
            this.DetailAnimal.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
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
            // xrTable2
            // 
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4,
            this.xrTableRow5,
            this.xrTableRow6,
            this.xrTableRow7});
            this.xrTable2.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.SessionIDCaptionCell,
            this.SpaceCell1,
            this.SessionIDCell,
            this.SessionStatusCaptionCell,
            this.SpaceCell2,
            this.SessionStatusCell,
            this.SessionDateCaptionCell,
            this.SpaceCell3,
            this.SessionStartDateCell,
            this.SeparatorCell1,
            this.SessionEndDateCell});
            this.xrTableRow4.Name = "xrTableRow4";
            resources.ApplyResources(this.xrTableRow4, "xrTableRow4");
            // 
            // SessionIDCaptionCell
            // 
            this.SessionIDCaptionCell.Name = "SessionIDCaptionCell";
            this.SessionIDCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.SessionIDCaptionCell, "SessionIDCaptionCell");
            // 
            // SpaceCell1
            // 
            this.SpaceCell1.Name = "SpaceCell1";
            resources.ApplyResources(this.SpaceCell1, "SpaceCell1");
            // 
            // SessionIDCell
            // 
            this.SessionIDCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SessionIDCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strSessionID")});
            this.SessionIDCell.Name = "SessionIDCell";
            this.SessionIDCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.SessionIDCell, "SessionIDCell");
            // 
            // SessionStatusCaptionCell
            // 
            this.SessionStatusCaptionCell.Name = "SessionStatusCaptionCell";
            this.SessionStatusCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.SessionStatusCaptionCell, "SessionStatusCaptionCell");
            // 
            // SpaceCell2
            // 
            this.SpaceCell2.Name = "SpaceCell2";
            resources.ApplyResources(this.SpaceCell2, "SpaceCell2");
            // 
            // SessionStatusCell
            // 
            this.SessionStatusCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SessionStatusCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strSessionStatus")});
            this.SessionStatusCell.Name = "SessionStatusCell";
            this.SessionStatusCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.SessionStatusCell, "SessionStatusCell");
            // 
            // SessionDateCaptionCell
            // 
            this.SessionDateCaptionCell.Name = "SessionDateCaptionCell";
            this.SessionDateCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.SessionDateCaptionCell, "SessionDateCaptionCell");
            // 
            // SpaceCell3
            // 
            this.SpaceCell3.Name = "SpaceCell3";
            resources.ApplyResources(this.SpaceCell3, "SpaceCell3");
            // 
            // SessionStartDateCell
            // 
            this.SessionStartDateCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SessionStartDateCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.datStartDate", "{0:MM/dd/yyyy}")});
            this.SessionStartDateCell.Name = "SessionStartDateCell";
            this.SessionStartDateCell.StylePriority.UseBorders = false;
            this.SessionStartDateCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.SessionStartDateCell, "SessionStartDateCell");
            // 
            // SeparatorCell1
            // 
            this.SeparatorCell1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SeparatorCell1.Name = "SeparatorCell1";
            this.SeparatorCell1.StylePriority.UseBorders = false;
            this.SeparatorCell1.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.SeparatorCell1, "SeparatorCell1");
            // 
            // SessionEndDateCell
            // 
            this.SessionEndDateCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SessionEndDateCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.datEndDate", "{0:MM/dd/yyyy}")});
            this.SessionEndDateCell.Name = "SessionEndDateCell";
            this.SessionEndDateCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.SessionEndDateCell, "SessionEndDateCell");
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.CampaignIDCaptionCell,
            this.SpaceCell4,
            this.CampaignIDCell,
            this.CampaignNameCaptionCell,
            this.SpaceCell5,
            this.CampaignNameCell,
            this.CampaignTypeCaptionCell,
            this.SpaceCell6,
            this.CampaignTypeCell});
            this.xrTableRow5.Name = "xrTableRow5";
            resources.ApplyResources(this.xrTableRow5, "xrTableRow5");
            // 
            // CampaignIDCaptionCell
            // 
            this.CampaignIDCaptionCell.Name = "CampaignIDCaptionCell";
            this.CampaignIDCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.CampaignIDCaptionCell, "CampaignIDCaptionCell");
            // 
            // SpaceCell4
            // 
            this.SpaceCell4.Name = "SpaceCell4";
            resources.ApplyResources(this.SpaceCell4, "SpaceCell4");
            // 
            // CampaignIDCell
            // 
            this.CampaignIDCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.CampaignIDCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strCampaignID")});
            this.CampaignIDCell.Name = "CampaignIDCell";
            this.CampaignIDCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.CampaignIDCell, "CampaignIDCell");
            // 
            // CampaignNameCaptionCell
            // 
            this.CampaignNameCaptionCell.Name = "CampaignNameCaptionCell";
            this.CampaignNameCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.CampaignNameCaptionCell, "CampaignNameCaptionCell");
            // 
            // SpaceCell5
            // 
            this.SpaceCell5.Name = "SpaceCell5";
            resources.ApplyResources(this.SpaceCell5, "SpaceCell5");
            // 
            // CampaignNameCell
            // 
            this.CampaignNameCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.CampaignNameCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strCampaignName")});
            this.CampaignNameCell.Name = "CampaignNameCell";
            this.CampaignNameCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.CampaignNameCell, "CampaignNameCell");
            // 
            // CampaignTypeCaptionCell
            // 
            this.CampaignTypeCaptionCell.Name = "CampaignTypeCaptionCell";
            this.CampaignTypeCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.CampaignTypeCaptionCell, "CampaignTypeCaptionCell");
            // 
            // SpaceCell6
            // 
            this.SpaceCell6.Name = "SpaceCell6";
            resources.ApplyResources(this.SpaceCell6, "SpaceCell6");
            // 
            // CampaignTypeCell
            // 
            this.CampaignTypeCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.CampaignTypeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strCampaignType")});
            this.CampaignTypeCell.Name = "CampaignTypeCell";
            this.CampaignTypeCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.CampaignTypeCell, "CampaignTypeCell");
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.SiteCaptionCell,
            this.SpaceCell7,
            this.SiteCell,
            this.OfficerCaptionCell,
            this.SpaceCell8,
            this.OfficerCell,
            this.DateCaptionCell,
            this.SpaceCell9,
            this.DateCell});
            this.xrTableRow6.Name = "xrTableRow6";
            resources.ApplyResources(this.xrTableRow6, "xrTableRow6");
            // 
            // SiteCaptionCell
            // 
            this.SiteCaptionCell.Name = "SiteCaptionCell";
            this.SiteCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.SiteCaptionCell, "SiteCaptionCell");
            // 
            // SpaceCell7
            // 
            this.SpaceCell7.Name = "SpaceCell7";
            resources.ApplyResources(this.SpaceCell7, "SpaceCell7");
            // 
            // SiteCell
            // 
            this.SiteCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SiteCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strSite")});
            this.SiteCell.Name = "SiteCell";
            this.SiteCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.SiteCell, "SiteCell");
            // 
            // OfficerCaptionCell
            // 
            this.OfficerCaptionCell.Name = "OfficerCaptionCell";
            this.OfficerCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.OfficerCaptionCell, "OfficerCaptionCell");
            // 
            // SpaceCell8
            // 
            this.SpaceCell8.Name = "SpaceCell8";
            resources.ApplyResources(this.SpaceCell8, "SpaceCell8");
            // 
            // OfficerCell
            // 
            this.OfficerCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.OfficerCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strOfficer")});
            this.OfficerCell.Name = "OfficerCell";
            this.OfficerCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.OfficerCell, "OfficerCell");
            // 
            // DateCaptionCell
            // 
            this.DateCaptionCell.Name = "DateCaptionCell";
            this.DateCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.DateCaptionCell, "DateCaptionCell");
            // 
            // SpaceCell9
            // 
            this.SpaceCell9.Name = "SpaceCell9";
            resources.ApplyResources(this.SpaceCell9, "SpaceCell9");
            // 
            // DateCell
            // 
            this.DateCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.DateCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.datEnteredDate", "{0:MM/dd/yyyy}")});
            this.DateCell.Name = "DateCell";
            this.DateCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.DateCell, "DateCell");
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.RegionCaptionCell,
            this.SpaceCell10,
            this.RegionCell,
            this.RayonCaptionCell,
            this.SpaceCell11,
            this.RayonCell,
            this.TownVillageCaptionCell,
            this.SpaceCell12,
            this.TownVillageCell});
            this.xrTableRow7.Name = "xrTableRow7";
            resources.ApplyResources(this.xrTableRow7, "xrTableRow7");
            // 
            // RegionCaptionCell
            // 
            this.RegionCaptionCell.Name = "RegionCaptionCell";
            this.RegionCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.RegionCaptionCell, "RegionCaptionCell");
            // 
            // SpaceCell10
            // 
            this.SpaceCell10.Name = "SpaceCell10";
            resources.ApplyResources(this.SpaceCell10, "SpaceCell10");
            // 
            // RegionCell
            // 
            this.RegionCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.RegionCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strRegion")});
            this.RegionCell.Name = "RegionCell";
            this.RegionCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.RegionCell, "RegionCell");
            // 
            // RayonCaptionCell
            // 
            this.RayonCaptionCell.Name = "RayonCaptionCell";
            this.RayonCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.RayonCaptionCell, "RayonCaptionCell");
            // 
            // SpaceCell11
            // 
            this.SpaceCell11.Name = "SpaceCell11";
            resources.ApplyResources(this.SpaceCell11, "SpaceCell11");
            // 
            // RayonCell
            // 
            this.RayonCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.RayonCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strRayon")});
            this.RayonCell.Name = "RayonCell";
            this.RayonCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.RayonCell, "RayonCell");
            // 
            // TownVillageCaptionCell
            // 
            this.TownVillageCaptionCell.Name = "TownVillageCaptionCell";
            this.TownVillageCaptionCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.TownVillageCaptionCell, "TownVillageCaptionCell");
            // 
            // SpaceCell12
            // 
            this.SpaceCell12.Name = "SpaceCell12";
            resources.ApplyResources(this.SpaceCell12, "SpaceCell12");
            // 
            // TownVillageCell
            // 
            this.TownVillageCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.TownVillageCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.m_SessionReportDataSet, "Session.strSettlement")});
            this.TownVillageCell.Name = "TownVillageCell";
            this.TownVillageCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.TownVillageCell, "TownVillageCell");
            // 
            // DetailReportSummary
            // 
            this.DetailReportSummary.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailSummary});
            this.DetailReportSummary.Level = 2;
            this.DetailReportSummary.Name = "DetailReportSummary";
            // 
            // DetailSummary
            // 
            this.DetailSummary.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.m_SummarySubreport});
            resources.ApplyResources(this.DetailSummary, "DetailSummary");
            this.DetailSummary.Name = "DetailSummary";
            this.DetailSummary.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // m_SummarySubreport
            // 
            resources.ApplyResources(this.m_SummarySubreport, "m_SummarySubreport");
            this.m_SummarySubreport.Name = "m_SummarySubreport";
            this.m_SummarySubreport.ReportSource = new EIDSS.Reports.Document.ActiveSurveillance.SessionSummaryReport();
            // 
            // DetailReportActions
            // 
            this.DetailReportActions.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailActions});
            this.DetailReportActions.Level = 3;
            this.DetailReportActions.Name = "DetailReportActions";
            // 
            // DetailActions
            // 
            this.DetailActions.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.m_ActionsSubreport});
            resources.ApplyResources(this.DetailActions, "DetailActions");
            this.DetailActions.Name = "DetailActions";
            this.DetailActions.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // m_ActionsSubreport
            // 
            resources.ApplyResources(this.m_ActionsSubreport, "m_ActionsSubreport");
            this.m_ActionsSubreport.Name = "m_ActionsSubreport";
            this.m_ActionsSubreport.ReportSource = new EIDSS.Reports.Document.ActiveSurveillance.SessionActionsReport();
            // 
            // DetailReportCases
            // 
            this.DetailReportCases.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailCases});
            this.DetailReportCases.Level = 4;
            this.DetailReportCases.Name = "DetailReportCases";
            // 
            // DetailCases
            // 
            this.DetailCases.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.m_CasesSubreport});
            resources.ApplyResources(this.DetailCases, "DetailCases");
            this.DetailCases.Name = "DetailCases";
            this.DetailCases.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // m_CasesSubreport
            // 
            resources.ApplyResources(this.m_CasesSubreport, "m_CasesSubreport");
            this.m_CasesSubreport.Name = "m_CasesSubreport";
            this.m_CasesSubreport.ReportSource = new EIDSS.Reports.Document.ActiveSurveillance.SessionCasesReport();
            // 
            // SessionReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.DetailReportDiagnosis,
            this.DetailReportAnimal,
            this.ReportFooter,
            this.DetailReportSummary,
            this.DetailReportActions,
            this.DetailReportCases});
            resources.ApplyResources(this, "$this");
            this.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.Version = "14.1";
            this.Controls.SetChildIndex(this.DetailReportCases, 0);
            this.Controls.SetChildIndex(this.DetailReportActions, 0);
            this.Controls.SetChildIndex(this.DetailReportSummary, 0);
            this.Controls.SetChildIndex(this.ReportFooter, 0);
            this.Controls.SetChildIndex(this.DetailReportAnimal, 0);
            this.Controls.SetChildIndex(this.DetailReportDiagnosis, 0);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.PageFooter, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_SessionReportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailReportBand DetailReportDiagnosis;
        private DevExpress.XtraReports.UI.DetailBand DetailDiagnosis;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReportAnimal;
        private DevExpress.XtraReports.UI.DetailBand DetailAnimal;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private SessionReportDataSet m_SessionReportDataSet;
        private SessionTableAdapter m_SessionAdapter;
        private DevExpress.XtraReports.UI.XRSubreport m_FarmSubreport;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell SessionIDCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell1;
        private DevExpress.XtraReports.UI.XRTableCell SessionIDCell;
        private DevExpress.XtraReports.UI.XRTableCell SessionStatusCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell2;
        private DevExpress.XtraReports.UI.XRTableCell SessionStatusCell;
        private DevExpress.XtraReports.UI.XRTableCell SessionDateCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell3;
        private DevExpress.XtraReports.UI.XRTableCell SessionEndDateCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell CampaignIDCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell4;
        private DevExpress.XtraReports.UI.XRTableCell CampaignIDCell;
        private DevExpress.XtraReports.UI.XRTableCell CampaignNameCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell5;
        private DevExpress.XtraReports.UI.XRTableCell CampaignNameCell;
        private DevExpress.XtraReports.UI.XRTableCell CampaignTypeCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell6;
        private DevExpress.XtraReports.UI.XRTableCell CampaignTypeCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell SiteCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell7;
        private DevExpress.XtraReports.UI.XRTableCell SiteCell;
        private DevExpress.XtraReports.UI.XRTableCell OfficerCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell8;
        private DevExpress.XtraReports.UI.XRTableCell OfficerCell;
        private DevExpress.XtraReports.UI.XRTableCell DateCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell9;
        private DevExpress.XtraReports.UI.XRTableCell DateCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell RegionCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell10;
        private DevExpress.XtraReports.UI.XRTableCell RegionCell;
        private DevExpress.XtraReports.UI.XRTableCell RayonCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell11;
        private DevExpress.XtraReports.UI.XRTableCell RayonCell;
        private DevExpress.XtraReports.UI.XRTableCell TownVillageCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell SpaceCell12;
        private DevExpress.XtraReports.UI.XRTableCell TownVillageCell;
        private DevExpress.XtraReports.UI.XRSubreport m_DiagnosisSubreport;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReportSummary;
        private DevExpress.XtraReports.UI.DetailBand DetailSummary;
        private DevExpress.XtraReports.UI.XRSubreport m_SummarySubreport;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReportActions;
        private DevExpress.XtraReports.UI.DetailBand DetailActions;
        private DevExpress.XtraReports.UI.XRSubreport m_ActionsSubreport;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReportCases;
        private DevExpress.XtraReports.UI.DetailBand DetailCases;
        private DevExpress.XtraReports.UI.XRSubreport m_CasesSubreport;
        private DevExpress.XtraReports.UI.XRTableCell SessionStartDateCell;
        private DevExpress.XtraReports.UI.XRTableCell SeparatorCell1;




    }
}