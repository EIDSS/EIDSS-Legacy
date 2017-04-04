using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets.LabTestingResultDataSetTableAdapters;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    partial class LabTestingTesultsReportNew
    {
        
        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabTestingTesultsReportNew));
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportDetailTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.TestedDiagnosisCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TestNameCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ResultCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ResultDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TestedByCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportDetailHeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell261 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.SecondReportHeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderInitialDiagnosisCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderPatientNameCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderSexCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderDOBCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderAgeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderAddressCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderSampleTypeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderCollectionDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderOrganizationSentCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell123 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderSentDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell161 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderLaboratoryReceivedCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell221 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderAccessionDateCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderSampleConditionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderSamleIdCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderCaseIDCaptionCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderCaseIDBarcodeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderCaseIDCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.m_Adapter = new EIDSS.Reports.Parameterized.Human.AJ.DataSets.LabTestingResultDataSetTableAdapters.LabTestingResultAdapter();
            this.m_DataSet = new EIDSS.Reports.Parameterized.Human.AJ.DataSets.LabTestingResultDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDetailTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDetailHeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondReportHeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // cellLanguage
            // 
            this.cellLanguage.StylePriority.UseTextAlignment = false;
            // 
            // lblReportName
            // 
            resources.ApplyResources(this.lblReportName, "lblReportName");
            this.lblReportName.Multiline = true;
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
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UsePadding = false;
            this.PageHeader.StylePriority.UseTextAlignment = false;
            // 
            // PageFooter
            // 
            this.PageFooter.StylePriority.UseBorders = false;
            resources.ApplyResources(this.PageFooter, "PageFooter");
            // 
            // ReportHeader
            // 
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            this.ReportHeader.StylePriority.UseFont = false;
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
            // 
            // cellBaseSite
            // 
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
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
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.ReportHeader1,
            this.ReportFooter});
            this.DetailReport.DataAdapter = this.m_Adapter;
            this.DetailReport.DataMember = "LabTestingResult";
            this.DetailReport.DataSource = this.m_DataSet;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            this.DetailReport.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ReportDetailTable});
            resources.ApplyResources(this.Detail1, "Detail1");
            this.Detail1.Name = "Detail1";
            // 
            // ReportDetailTable
            // 
            this.ReportDetailTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.ReportDetailTable, "ReportDetailTable");
            this.ReportDetailTable.Name = "ReportDetailTable";
            this.ReportDetailTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
            this.ReportDetailTable.StylePriority.UseBorders = false;
            this.ReportDetailTable.StylePriority.UseFont = false;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.TestedDiagnosisCell,
            this.TestNameCell,
            this.ResultCell,
            this.ResultDateCell,
            this.TestedByCell});
            this.xrTableRow9.Name = "xrTableRow9";
            resources.ApplyResources(this.xrTableRow9, "xrTableRow9");
            // 
            // TestedDiagnosisCell
            // 
            this.TestedDiagnosisCell.Name = "TestedDiagnosisCell";
            resources.ApplyResources(this.TestedDiagnosisCell, "TestedDiagnosisCell");
            // 
            // TestNameCell
            // 
            this.TestNameCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strTestName")});
            this.TestNameCell.Name = "TestNameCell";
            resources.ApplyResources(this.TestNameCell, "TestNameCell");
            // 
            // ResultCell
            // 
            this.ResultCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strResult")});
            this.ResultCell.Name = "ResultCell";
            resources.ApplyResources(this.ResultCell, "ResultCell");
            // 
            // ResultDateCell
            // 
            this.ResultDateCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.datResultDate", "{0:dd/MM/yyyy}")});
            this.ResultDateCell.Name = "ResultDateCell";
            resources.ApplyResources(this.ResultDateCell, "ResultDateCell");
            // 
            // TestedByCell
            // 
            this.TestedByCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strTestedBy")});
            this.TestedByCell.Name = "TestedByCell";
            resources.ApplyResources(this.TestedByCell, "TestedByCell");
            // 
            // ReportHeader1
            // 
            this.ReportHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ReportDetailHeaderTable,
            this.SecondReportHeaderTable,
            this.ReportHeaderTable});
            resources.ApplyResources(this.ReportHeader1, "ReportHeader1");
            this.ReportHeader1.Name = "ReportHeader1";
            this.ReportHeader1.StylePriority.UseFont = false;
            this.ReportHeader1.StylePriority.UseTextAlignment = false;
            // 
            // ReportDetailHeaderTable
            // 
            this.ReportDetailHeaderTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.ReportDetailHeaderTable, "ReportDetailHeaderTable");
            this.ReportDetailHeaderTable.Name = "ReportDetailHeaderTable";
            this.ReportDetailHeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
            this.ReportDetailHeaderTable.StylePriority.UseBorders = false;
            this.ReportDetailHeaderTable.StylePriority.UseFont = false;
            this.ReportDetailHeaderTable.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow15
            // 
            this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33,
            this.xrTableCell36,
            this.xrTableCell38,
            this.xrTableCell261,
            this.xrTableCell16});
            this.xrTableRow15.Name = "xrTableRow15";
            resources.ApplyResources(this.xrTableRow15, "xrTableRow15");
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Name = "xrTableCell33";
            resources.ApplyResources(this.xrTableCell33, "xrTableCell33");
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Name = "xrTableCell36";
            resources.ApplyResources(this.xrTableCell36, "xrTableCell36");
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Name = "xrTableCell38";
            resources.ApplyResources(this.xrTableCell38, "xrTableCell38");
            // 
            // xrTableCell261
            // 
            this.xrTableCell261.Name = "xrTableCell261";
            resources.ApplyResources(this.xrTableCell261, "xrTableCell261");
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            resources.ApplyResources(this.xrTableCell16, "xrTableCell16");
            // 
            // SecondReportHeaderTable
            // 
            resources.ApplyResources(this.SecondReportHeaderTable, "SecondReportHeaderTable");
            this.SecondReportHeaderTable.Name = "SecondReportHeaderTable";
            this.SecondReportHeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12,
            this.xrTableRow10,
            this.xrTableRow11,
            this.xrTableRow13,
            this.xrTableRow6,
            this.xrTableRow7,
            this.xrTableRow14,
            this.xrTableRow18});
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell1,
            this.HeaderInitialDiagnosisCell});
            this.xrTableRow12.Name = "xrTableRow12";
            resources.ApplyResources(this.xrTableRow12, "xrTableRow12");
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            resources.ApplyResources(this.xrTableCell18, "xrTableCell18");
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.StylePriority.UseBorders = false;
            resources.ApplyResources(this.xrTableCell19, "xrTableCell19");
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 2, 2, 2, 100F);
            this.xrTableCell1.StylePriority.UsePadding = false;
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            // 
            // HeaderInitialDiagnosisCell
            // 
            this.HeaderInitialDiagnosisCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderInitialDiagnosisCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strDiagnosis")});
            this.HeaderInitialDiagnosisCell.Name = "HeaderInitialDiagnosisCell";
            this.HeaderInitialDiagnosisCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderInitialDiagnosisCell, "HeaderInitialDiagnosisCell");
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.HeaderPatientNameCell,
            this.xrTableCell15,
            this.HeaderSexCell});
            this.xrTableRow10.Name = "xrTableRow10";
            resources.ApplyResources(this.xrTableRow10, "xrTableRow10");
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            resources.ApplyResources(this.xrTableCell14, "xrTableCell14");
            // 
            // HeaderPatientNameCell
            // 
            this.HeaderPatientNameCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderPatientNameCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strPatientName")});
            this.HeaderPatientNameCell.Name = "HeaderPatientNameCell";
            this.HeaderPatientNameCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderPatientNameCell, "HeaderPatientNameCell");
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 2, 2, 100F);
            this.xrTableCell15.StylePriority.UsePadding = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell15, "xrTableCell15");
            // 
            // HeaderSexCell
            // 
            this.HeaderSexCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderSexCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strSex")});
            this.HeaderSexCell.Name = "HeaderSexCell";
            this.HeaderSexCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderSexCell, "HeaderSexCell");
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.HeaderDOBCell,
            this.xrTableCell23,
            this.HeaderAgeCell});
            this.xrTableRow11.Name = "xrTableRow11";
            resources.ApplyResources(this.xrTableRow11, "xrTableRow11");
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            resources.ApplyResources(this.xrTableCell21, "xrTableCell21");
            // 
            // HeaderDOBCell
            // 
            this.HeaderDOBCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderDOBCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.datDateOfBirth", "{0:dd/MM/yyyy}")});
            this.HeaderDOBCell.Name = "HeaderDOBCell";
            this.HeaderDOBCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderDOBCell, "HeaderDOBCell");
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 2, 2, 100F);
            this.xrTableCell23.StylePriority.UsePadding = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell23, "xrTableCell23");
            // 
            // HeaderAgeCell
            // 
            this.HeaderAgeCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderAgeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strAge")});
            this.HeaderAgeCell.Name = "HeaderAgeCell";
            this.HeaderAgeCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderAgeCell, "HeaderAgeCell");
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell25,
            this.HeaderAddressCell});
            this.xrTableRow13.Name = "xrTableRow13";
            resources.ApplyResources(this.xrTableRow13, "xrTableRow13");
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            resources.ApplyResources(this.xrTableCell25, "xrTableCell25");
            // 
            // HeaderAddressCell
            // 
            this.HeaderAddressCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderAddressCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strAddress")});
            this.HeaderAddressCell.Name = "HeaderAddressCell";
            this.HeaderAddressCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderAddressCell, "HeaderAddressCell");
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell101,
            this.HeaderSampleTypeCell,
            this.xrTableCell112,
            this.HeaderCollectionDateCell});
            this.xrTableRow6.Name = "xrTableRow6";
            resources.ApplyResources(this.xrTableRow6, "xrTableRow6");
            // 
            // xrTableCell101
            // 
            this.xrTableCell101.Name = "xrTableCell101";
            resources.ApplyResources(this.xrTableCell101, "xrTableCell101");
            // 
            // HeaderSampleTypeCell
            // 
            this.HeaderSampleTypeCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderSampleTypeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strSampleType")});
            this.HeaderSampleTypeCell.Name = "HeaderSampleTypeCell";
            this.HeaderSampleTypeCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderSampleTypeCell, "HeaderSampleTypeCell");
            // 
            // xrTableCell112
            // 
            this.xrTableCell112.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell112.Multiline = true;
            this.xrTableCell112.Name = "xrTableCell112";
            this.xrTableCell112.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 2, 2, 100F);
            this.xrTableCell112.StylePriority.UseBorders = false;
            this.xrTableCell112.StylePriority.UsePadding = false;
            resources.ApplyResources(this.xrTableCell112, "xrTableCell112");
            // 
            // HeaderCollectionDateCell
            // 
            this.HeaderCollectionDateCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderCollectionDateCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.datCollectionDate", "{0:dd/MM/yyyy}")});
            this.HeaderCollectionDateCell.Name = "HeaderCollectionDateCell";
            this.HeaderCollectionDateCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderCollectionDateCell, "HeaderCollectionDateCell");
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell103,
            this.HeaderOrganizationSentCell,
            this.xrTableCell123,
            this.HeaderSentDateCell});
            this.xrTableRow7.Name = "xrTableRow7";
            resources.ApplyResources(this.xrTableRow7, "xrTableRow7");
            // 
            // xrTableCell103
            // 
            this.xrTableCell103.Name = "xrTableCell103";
            resources.ApplyResources(this.xrTableCell103, "xrTableCell103");
            // 
            // HeaderOrganizationSentCell
            // 
            this.HeaderOrganizationSentCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderOrganizationSentCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strSentOrganizationNameAddress")});
            this.HeaderOrganizationSentCell.Name = "HeaderOrganizationSentCell";
            this.HeaderOrganizationSentCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderOrganizationSentCell, "HeaderOrganizationSentCell");
            // 
            // xrTableCell123
            // 
            this.xrTableCell123.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell123.Name = "xrTableCell123";
            this.xrTableCell123.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 2, 2, 100F);
            this.xrTableCell123.StylePriority.UseBorders = false;
            this.xrTableCell123.StylePriority.UsePadding = false;
            resources.ApplyResources(this.xrTableCell123, "xrTableCell123");
            // 
            // HeaderSentDateCell
            // 
            this.HeaderSentDateCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderSentDateCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.datSentDate", "{0:dd/MM/yyyy}")});
            this.HeaderSentDateCell.Name = "HeaderSentDateCell";
            this.HeaderSentDateCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderSentDateCell, "HeaderSentDateCell");
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell161,
            this.HeaderLaboratoryReceivedCell,
            this.xrTableCell221,
            this.HeaderAccessionDateCell});
            this.xrTableRow14.Name = "xrTableRow14";
            resources.ApplyResources(this.xrTableRow14, "xrTableRow14");
            // 
            // xrTableCell161
            // 
            this.xrTableCell161.Name = "xrTableCell161";
            resources.ApplyResources(this.xrTableCell161, "xrTableCell161");
            // 
            // HeaderLaboratoryReceivedCell
            // 
            this.HeaderLaboratoryReceivedCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderLaboratoryReceivedCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strReceivedOrganizationNameAddress")});
            this.HeaderLaboratoryReceivedCell.Name = "HeaderLaboratoryReceivedCell";
            this.HeaderLaboratoryReceivedCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderLaboratoryReceivedCell, "HeaderLaboratoryReceivedCell");
            // 
            // xrTableCell221
            // 
            this.xrTableCell221.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell221.Name = "xrTableCell221";
            this.xrTableCell221.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 2, 2, 100F);
            this.xrTableCell221.StylePriority.UseBorders = false;
            this.xrTableCell221.StylePriority.UsePadding = false;
            resources.ApplyResources(this.xrTableCell221, "xrTableCell221");
            // 
            // HeaderAccessionDateCell
            // 
            this.HeaderAccessionDateCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderAccessionDateCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.datAccessionDate", "{0:dd/MM/yyyy}")});
            this.HeaderAccessionDateCell.Name = "HeaderAccessionDateCell";
            this.HeaderAccessionDateCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderAccessionDateCell, "HeaderAccessionDateCell");
            // 
            // xrTableRow18
            // 
            this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.HeaderSampleConditionCell,
            this.xrTableCell12,
            this.HeaderSamleIdCell});
            this.xrTableRow18.Name = "xrTableRow18";
            resources.ApplyResources(this.xrTableRow18, "xrTableRow18");
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            resources.ApplyResources(this.xrTableCell10, "xrTableCell10");
            // 
            // HeaderSampleConditionCell
            // 
            this.HeaderSampleConditionCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderSampleConditionCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strSampleConditionReceived")});
            this.HeaderSampleConditionCell.Name = "HeaderSampleConditionCell";
            this.HeaderSampleConditionCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderSampleConditionCell, "HeaderSampleConditionCell");
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 2, 2, 100F);
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            resources.ApplyResources(this.xrTableCell12, "xrTableCell12");
            // 
            // HeaderSamleIdCell
            // 
            this.HeaderSamleIdCell.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.HeaderSamleIdCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strSampleId")});
            this.HeaderSamleIdCell.Name = "HeaderSamleIdCell";
            this.HeaderSamleIdCell.StylePriority.UseBorders = false;
            resources.ApplyResources(this.HeaderSamleIdCell, "HeaderSamleIdCell");
            // 
            // ReportHeaderTable
            // 
            resources.ApplyResources(this.ReportHeaderTable, "ReportHeaderTable");
            this.ReportHeaderTable.Name = "ReportHeaderTable";
            this.ReportHeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow4,
            this.xrTableRow2,
            this.xrTableRow3,
            this.xrTableRow5,
            this.xrTableRow8});
            this.ReportHeaderTable.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.HeaderCaseIDCaptionCell,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            // 
            // HeaderCaseIDCaptionCell
            // 
            this.HeaderCaseIDCaptionCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.HeaderCaseIDCaptionCell, "HeaderCaseIDCaptionCell");
            this.HeaderCaseIDCaptionCell.Name = "HeaderCaseIDCaptionCell";
            this.HeaderCaseIDCaptionCell.StylePriority.UseBorders = false;
            this.HeaderCaseIDCaptionCell.StylePriority.UseFont = false;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            resources.ApplyResources(this.xrTableCell3, "xrTableCell3");
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.StylePriority.UseBorders = false;
            resources.ApplyResources(this.xrTableRow4, "xrTableRow4");
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBorders = false;
            resources.ApplyResources(this.xrTableCell5, "xrTableCell5");
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            resources.ApplyResources(this.xrTableCell6, "xrTableCell6");
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.HeaderCaseIDBarcodeCell,
            this.xrTableCell4});
            this.xrTableRow2.Name = "xrTableRow2";
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            // 
            // HeaderCaseIDBarcodeCell
            // 
            resources.ApplyResources(this.HeaderCaseIDBarcodeCell, "HeaderCaseIDBarcodeCell");
            this.HeaderCaseIDBarcodeCell.Name = "HeaderCaseIDBarcodeCell";
            this.HeaderCaseIDBarcodeCell.StylePriority.UseFont = false;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.HeaderCaseIDCell,
            this.xrTableCell2});
            this.xrTableRow3.Name = "xrTableRow3";
            resources.ApplyResources(this.xrTableRow3, "xrTableRow3");
            // 
            // HeaderCaseIDCell
            // 
            this.HeaderCaseIDCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LabTestingResult.strCaseId")});
            this.HeaderCaseIDCell.Name = "HeaderCaseIDCell";
            this.HeaderCaseIDCell.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.HeaderCaseIDCell, "HeaderCaseIDCell");
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8});
            this.xrTableRow5.Name = "xrTableRow5";
            resources.ApplyResources(this.xrTableRow5, "xrTableRow5");
            // 
            // xrTableCell7
            // 
            resources.ApplyResources(this.xrTableCell7, "xrTableCell7");
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            resources.ApplyResources(this.xrTableCell8, "xrTableCell8");
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9});
            this.xrTableRow8.Name = "xrTableRow8";
            resources.ApplyResources(this.xrTableRow8, "xrTableRow8");
            // 
            // xrTableCell9
            // 
            resources.ApplyResources(this.xrTableCell9, "xrTableCell9");
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseFont = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            resources.ApplyResources(this.ReportFooter, "ReportFooter");
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseTextAlignment = false;
            // 
            // xrTable1
            // 
            resources.ApplyResources(this.xrTable1, "xrTable1");
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow19});
            // 
            // xrTableRow19
            // 
            this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22,
            this.xrTableCell24});
            this.xrTableRow19.Name = "xrTableRow19";
            resources.ApplyResources(this.xrTableRow19, "xrTableRow19");
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            resources.ApplyResources(this.xrTableCell22, "xrTableCell22");
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBorders = false;
            resources.ApplyResources(this.xrTableCell24, "xrTableCell24");
            // 
            // m_Adapter
            // 
            this.m_Adapter.ClearBeforeFill = true;
            // 
            // m_DataSet
            // 
            this.m_DataSet.DataSetName = "AntibioticResistanceCardDataSet";
            this.m_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LabTestingTesultsReportNew
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.DetailReport});
            resources.ApplyResources(this, "$this");
            this.Version = "15.1";
            this.Controls.SetChildIndex(this.DetailReport, 0);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.PageFooter, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDetailTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDetailHeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondReportHeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private LabTestingResultAdapter m_Adapter;
        private LabTestingResultDataSet m_DataSet;
        private DevExpress.XtraReports.UI.XRTable ReportHeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell HeaderCaseIDBarcodeCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell HeaderCaseIDCaptionCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell HeaderCaseIDCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTable ReportDetailTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow9;
        private DevExpress.XtraReports.UI.XRTableCell TestNameCell;
        private DevExpress.XtraReports.UI.XRTableCell TestedByCell;
        private DevExpress.XtraReports.UI.XRTableCell TestedDiagnosisCell;
        private DevExpress.XtraReports.UI.XRTableCell ResultCell;
        private DevExpress.XtraReports.UI.XRTable ReportDetailHeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell33;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell36;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell38;
        private DevExpress.XtraReports.UI.XRTable SecondReportHeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell HeaderInitialDiagnosisCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell HeaderPatientNameCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell HeaderSexCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell HeaderDOBCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell HeaderAgeCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell HeaderAddressCell;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell101;
        private DevExpress.XtraReports.UI.XRTableCell HeaderSampleTypeCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell112;
        private DevExpress.XtraReports.UI.XRTableCell HeaderCollectionDateCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell103;
        private DevExpress.XtraReports.UI.XRTableCell HeaderOrganizationSentCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell123;
        private DevExpress.XtraReports.UI.XRTableCell HeaderSentDateCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell161;
        private DevExpress.XtraReports.UI.XRTableCell HeaderLaboratoryReceivedCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell221;
        private DevExpress.XtraReports.UI.XRTableCell HeaderAccessionDateCell;
        private DevExpress.XtraReports.UI.XRTableCell ResultDateCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell261;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell HeaderSampleConditionCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell HeaderSamleIdCell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
    }
}
