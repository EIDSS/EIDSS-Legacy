namespace EIDSS.Reports.BaseControls.Report
{
    partial class BaseBarcodeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseBarcodeReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lblBarcode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBottom = new DevExpress.XtraReports.UI.XRLabel();
            this.barcodeDataSet1 = new EIDSS.Reports.Barcode.BarcodeDataSet();
            this.spRepGetBarcodeTableAdapter = new EIDSS.Reports.Barcode.BarcodeDataSetTableAdapters.spRepGetBarcodeTableAdapter();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblBarcode,
            this.lblBottom});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseTextAlignment = false;
            // 
            // lblBarcode
            // 
            this.lblBarcode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetBarcode.strBarcode")});
            resources.ApplyResources(this.lblBarcode, "lblBarcode");
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lblBarcode.StylePriority.UseFont = false;
            this.lblBarcode.StylePriority.UsePadding = false;
            this.lblBarcode.StylePriority.UseTextAlignment = false;
            this.lblBarcode.WordWrap = false;
            // 
            // lblBottom
            // 
            this.lblBottom.CanGrow = false;
            this.lblBottom.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetBarcode.strBottom")});
            resources.ApplyResources(this.lblBottom, "lblBottom");
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.StylePriority.UseFont = false;
            this.lblBottom.StylePriority.UsePadding = false;
            this.lblBottom.StylePriority.UseTextAlignment = false;
            // 
            // barcodeDataSet1
            // 
            this.barcodeDataSet1.DataSetName = "BarcodeDataSet";
            this.barcodeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spRepGetBarcodeTableAdapter
            // 
            this.spRepGetBarcodeTableAdapter.ClearBeforeFill = true;
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
            // BaseBarcodeReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DataAdapter = this.spRepGetBarcodeTableAdapter;
            this.DataMember = "spRepGetBarcode";
            this.DataSource = this.barcodeDataSet1;
            this.DesignerOptions.ShowExportWarnings = false;
            resources.ApplyResources(this, "$this");
            this.Version = "15.1";
            ((System.ComponentModel.ISupportInitialize)(this.barcodeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        protected DevExpress.XtraReports.UI.XRLabel lblBottom;
        protected EIDSS.Reports.Barcode.BarcodeDataSet barcodeDataSet1;
        protected EIDSS.Reports.Barcode.BarcodeDataSetTableAdapters.spRepGetBarcodeTableAdapter spRepGetBarcodeTableAdapter;
        protected internal DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        protected DevExpress.XtraReports.UI.XRLabel lblBarcode;
    }
}
