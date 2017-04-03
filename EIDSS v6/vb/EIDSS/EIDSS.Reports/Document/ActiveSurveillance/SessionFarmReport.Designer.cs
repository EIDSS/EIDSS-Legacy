using EIDSS.Reports.Document.ActiveSurveillance.SessionFarmReportDataSetTableAdapters;

namespace EIDSS.Reports.Document.ActiveSurveillance
{
    partial class SessionFarmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionFarmReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.MainTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellFarm = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.m_SessionFarmReportDataSet = new EIDSS.Reports.Document.ActiveSurveillance.SessionFarmReportDataSet();
            this.m_SessionFarmAdapter = new EIDSS.Reports.Document.ActiveSurveillance.SessionFarmReportDataSetTableAdapters.SessionFarmAdapter();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_SessionFarmReportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellNo,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23});
            resources.ApplyResources(this.xrTableRow3, "xrTableRow3");
            this.xrTableRow3.Name = "xrTableRow3";
            // 
            // cellNo
            // 
            resources.ApplyResources(this.cellNo, "cellNo");
            this.cellNo.Multiline = true;
            this.cellNo.Name = "cellNo";
            this.cellNo.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.cellNo_BeforePrint);
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strAnimalCode")});
            resources.ApplyResources(this.xrTableCell15, "xrTableCell15");
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strSpeciesType")});
            resources.ApplyResources(this.xrTableCell16, "xrTableCell16");
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strAnimalAge")});
            resources.ApplyResources(this.xrTableCell17, "xrTableCell17");
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strAnimalColor")});
            resources.ApplyResources(this.xrTableCell18, "xrTableCell18");
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strAnimalName")});
            resources.ApplyResources(this.xrTableCell19, "xrTableCell19");
            this.xrTableCell19.Multiline = true;
            this.xrTableCell19.Name = "xrTableCell19";
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strAnimalGender")});
            resources.ApplyResources(this.xrTableCell20, "xrTableCell20");
            this.xrTableCell20.Multiline = true;
            this.xrTableCell20.Name = "xrTableCell20";
            // 
            // xrTableCell21
            // 
            resources.ApplyResources(this.xrTableCell21, "xrTableCell21");
            this.xrTableCell21.Multiline = true;
            this.xrTableCell21.Name = "xrTableCell21";
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strFieldBarcode")});
            resources.ApplyResources(this.xrTableCell22, "xrTableCell22");
            this.xrTableCell22.Multiline = true;
            this.xrTableCell22.Name = "xrTableCell22";
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strSpecimenName")});
            resources.ApplyResources(this.xrTableCell23, "xrTableCell23");
            this.xrTableCell23.Multiline = true;
            this.xrTableCell23.Name = "xrTableCell23";
            // 
            // TopMargin
            // 
            resources.ApplyResources(this.TopMargin, "TopMargin");
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // BottomMargin
            // 
            resources.ApplyResources(this.BottomMargin, "BottomMargin");
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.MainTable});
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            // 
            // MainTable
            // 
            this.MainTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.MainTable, "MainTable");
            this.MainTable.Name = "MainTable";
            this.MainTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.MainTable.StylePriority.UseBorders = false;
            this.MainTable.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell8,
            this.xrTableCell1,
            this.xrTableCell5,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell2,
            this.xrTableCell6,
            this.xrTableCell3});
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            this.xrTableRow1.Name = "xrTableRow1";
            // 
            // xrTableCell7
            // 
            resources.ApplyResources(this.xrTableCell7, "xrTableCell7");
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            // 
            // xrTableCell4
            // 
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            // 
            // xrTableCell8
            // 
            resources.ApplyResources(this.xrTableCell8, "xrTableCell8");
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            // 
            // xrTableCell1
            // 
            resources.ApplyResources(this.xrTableCell1, "xrTableCell1");
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            // 
            // xrTableCell5
            // 
            resources.ApplyResources(this.xrTableCell5, "xrTableCell5");
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            // 
            // xrTableCell9
            // 
            resources.ApplyResources(this.xrTableCell9, "xrTableCell9");
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            // 
            // xrTableCell10
            // 
            resources.ApplyResources(this.xrTableCell10, "xrTableCell10");
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            // 
            // xrTableCell2
            // 
            resources.ApplyResources(this.xrTableCell2, "xrTableCell2");
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            // 
            // xrTableCell6
            // 
            resources.ApplyResources(this.xrTableCell6, "xrTableCell6");
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            // 
            // xrTableCell3
            // 
            resources.ApplyResources(this.xrTableCell3, "xrTableCell3");
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            resources.ApplyResources(this.GroupHeader1, "GroupHeader1");
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("idfFarm", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable1
            // 
            resources.ApplyResources(this.xrTable1, "xrTable1");
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable1.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellFarm,
            this.xrTableCell12,
            this.xrTableCell13});
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            this.xrTableRow2.Name = "xrTableRow2";
            // 
            // cellFarm
            // 
            this.cellFarm.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.cellFarm.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strFarmCode")});
            resources.ApplyResources(this.cellFarm, "cellFarm");
            this.cellFarm.Name = "cellFarm";
            this.cellFarm.StylePriority.UseBorders = false;
            this.cellFarm.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.cellFarm_BeforePrint);
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strOwnerName")});
            resources.ApplyResources(this.xrTableCell12, "xrTableCell12");
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseBorders = false;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SessionFarm.strFarmAddress")});
            resources.ApplyResources(this.xrTableCell13, "xrTableCell13");
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseBorders = false;
            // 
            // m_SessionFarmReportDataSet
            // 
            this.m_SessionFarmReportDataSet.DataSetName = "SessionFarmReportDataSet";
            this.m_SessionFarmReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // m_SessionFarmAdapter
            // 
            this.m_SessionFarmAdapter.ClearBeforeFill = true;
            // 
            // GroupFooter1
            // 
            resources.ApplyResources(this.GroupFooter1, "GroupFooter1");
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // SessionFarmReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupFooter1});
            this.DataAdapter = this.m_SessionFarmAdapter;
            this.DataMember = "SessionFarm";
            this.DataSource = this.m_SessionFarmReportDataSet;
            resources.ApplyResources(this, "$this");
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_SessionFarmReportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable MainTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell cellFarm;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private SessionFarmReportDataSet m_SessionFarmReportDataSet;
        private SessionFarmAdapter m_SessionFarmAdapter;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell cellNo;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
    }
}
