namespace EIDSS.Reports.Document.Lim.Case
{
    partial class TestValidationReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestValidationReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellRule = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblRuleOut = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRuleIn = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.testValidationDataSet1 = new EIDSS.Reports.Document.Lim.Case.TestValidationDataSet();
            this.sp_rep_LIM_CaseTestsValidationTableAdapter1 = new EIDSS.Reports.Document.Lim.Case.TestValidationDataSetTableAdapters.sp_rep_LIM_CaseTestsValidationTableAdapter();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testValidationDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseBorders = false;
            this.Detail.StylePriority.UseTextAlignment = false;
            // 
            // xrTable2
            // 
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.cellRule,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22});
            this.xrTableRow2.Name = "xrTableRow2";
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Angle = 90F;
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.Diagnosis")});
            this.xrTableCell12.Name = "xrTableCell12";
            resources.ApplyResources(this.xrTableCell12, "xrTableCell12");
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Angle = 90F;
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.TestName")});
            this.xrTableCell13.Name = "xrTableCell13";
            resources.ApplyResources(this.xrTableCell13, "xrTableCell13");
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Angle = 90F;
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.TestType")});
            this.xrTableCell14.Name = "xrTableCell14";
            resources.ApplyResources(this.xrTableCell14, "xrTableCell14");
            // 
            // cellRule
            // 
            this.cellRule.Angle = 90F;
            this.cellRule.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblRuleOut,
            this.lblRuleIn});
            this.cellRule.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.intRuleStatus")});
            this.cellRule.Name = "cellRule";
            resources.ApplyResources(this.cellRule, "cellRule");
            this.cellRule.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.cellRule_BeforePrint);
            // 
            // lblRuleOut
            // 
            resources.ApplyResources(this.lblRuleOut, "lblRuleOut");
            this.lblRuleOut.Name = "lblRuleOut";
            this.lblRuleOut.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // lblRuleIn
            // 
            resources.ApplyResources(this.lblRuleIn, "lblRuleIn");
            this.lblRuleIn.Name = "lblRuleIn";
            this.lblRuleIn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Angle = 90F;
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.strRuleComment")});
            this.xrTableCell16.Name = "xrTableCell16";
            resources.ApplyResources(this.xrTableCell16, "xrTableCell16");
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Angle = 90F;
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.interpretedDate", "{0:dd/MM/yyyy}")});
            this.xrTableCell17.Name = "xrTableCell17";
            resources.ApplyResources(this.xrTableCell17, "xrTableCell17");
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Angle = 90F;
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.InterpretedBy")});
            this.xrTableCell18.Name = "xrTableCell18";
            resources.ApplyResources(this.xrTableCell18, "xrTableCell18");
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Angle = 90F;
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.intValidateStatus")});
            this.xrTableCell19.Name = "xrTableCell19";
            resources.ApplyResources(this.xrTableCell19, "xrTableCell19");
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Angle = 90F;
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.strValidateComment")});
            this.xrTableCell20.Name = "xrTableCell20";
            resources.ApplyResources(this.xrTableCell20, "xrTableCell20");
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Angle = 90F;
            this.xrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.validatedDate", "{0:dd/MM/yyyy}")});
            this.xrTableCell21.Name = "xrTableCell21";
            resources.ApplyResources(this.xrTableCell21, "xrTableCell21");
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Angle = 90F;
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepLimCaseTestsValidation.ValidatedBy")});
            this.xrTableCell22.Name = "xrTableCell22";
            resources.ApplyResources(this.xrTableCell22, "xrTableCell22");
            // 
            // PageHeader
            // 
            this.PageHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrTable1});
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.StylePriority.UseBorders = false;
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UseTextAlignment = false;
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
            // xrTable1
            // 
            resources.ApplyResources(this.xrTable1, "xrTable1");
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell10,
            this.xrTableCell1,
            this.xrTableCell9,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell2,
            this.xrTableCell5,
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Angle = 90F;
            this.xrTableCell11.Name = "xrTableCell11";
            resources.ApplyResources(this.xrTableCell11, "xrTableCell11");
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Angle = 90F;
            this.xrTableCell10.Name = "xrTableCell10";
            resources.ApplyResources(this.xrTableCell10, "xrTableCell10");
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Angle = 90F;
            this.xrTableCell1.Name = "xrTableCell1";
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Angle = 90F;
            this.xrTableCell9.Name = "xrTableCell9";
            resources.ApplyResources(this.xrTableCell9, "xrTableCell9");
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Angle = 90F;
            this.xrTableCell7.Name = "xrTableCell7";
            resources.ApplyResources(this.xrTableCell7, "xrTableCell7");
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Angle = 90F;
            this.xrTableCell8.Name = "xrTableCell8";
            resources.ApplyResources(this.xrTableCell8, "xrTableCell8");
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Angle = 90F;
            this.xrTableCell2.Name = "xrTableCell2";
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Angle = 90F;
            this.xrTableCell5.Name = "xrTableCell5";
            resources.ApplyResources(this.xrTableCell5, "xrTableCell5");
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Angle = 90F;
            this.xrTableCell4.Name = "xrTableCell4";
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Angle = 90F;
            this.xrTableCell6.Name = "xrTableCell6";
            resources.ApplyResources(this.xrTableCell6, "xrTableCell6");
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Angle = 90F;
            this.xrTableCell3.Name = "xrTableCell3";
            resources.ApplyResources(this.xrTableCell3, "xrTableCell3");
            // 
            // PageFooter
            // 
            resources.ApplyResources(this.PageFooter, "PageFooter");
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // testValidationDataSet1
            // 
            this.testValidationDataSet1.DataSetName = "TestValidationDataSet";
            this.testValidationDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_rep_LIM_CaseTestsValidationTableAdapter1
            // 
            this.sp_rep_LIM_CaseTestsValidationTableAdapter1.ClearBeforeFill = true;
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
            // TestValidationReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DataAdapter = this.sp_rep_LIM_CaseTestsValidationTableAdapter1;
            this.DataMember = "spRepLimCaseTestsValidation";
            this.DataSource = this.testValidationDataSet1;
            resources.ApplyResources(this, "$this");
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testValidationDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private TestValidationDataSet testValidationDataSet1;
        private EIDSS.Reports.Document.Lim.Case.TestValidationDataSetTableAdapters.sp_rep_LIM_CaseTestsValidationTableAdapter sp_rep_LIM_CaseTestsValidationTableAdapter1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell cellRule;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lblRuleIn;
        private DevExpress.XtraReports.UI.XRLabel lblRuleOut;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}
