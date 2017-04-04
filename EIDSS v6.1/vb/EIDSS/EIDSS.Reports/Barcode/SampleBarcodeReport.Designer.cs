
namespace EIDSS.Reports.Barcode
{
    partial class SampleBarcodeReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleBarcodeReport));
            this.sampleBarcodeDataSet1 = new EIDSS.Reports.Barcode.SampleBarcodeDataSet();
            this.spRepGetSampleBarcodeTableAdapter = new EIDSS.Reports.Barcode.SampleBarcodeDataSetTableAdapters.spRepGetSampleBarcodeTableAdapter();
            this.lblDate = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCase = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSampleCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSampleTypeCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSampleBarcode = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleBarcodeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // lblBottom
            // 
            resources.ApplyResources(this.lblBottom, "lblBottom");
            this.lblBottom.StylePriority.UseFont = false;
            this.lblBottom.StylePriority.UsePadding = false;
            this.lblBottom.StylePriority.UseTextAlignment = false;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblSampleBarcode,
            this.lblSampleTypeCode,
            this.lblSampleCode,
            this.lblCase,
            this.lblDate});
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.Controls.SetChildIndex(this.lblBottom, 0);
            this.Detail.Controls.SetChildIndex(this.lblBarcode, 0);
            this.Detail.Controls.SetChildIndex(this.lblDate, 0);
            this.Detail.Controls.SetChildIndex(this.lblCase, 0);
            this.Detail.Controls.SetChildIndex(this.lblSampleCode, 0);
            this.Detail.Controls.SetChildIndex(this.lblSampleTypeCode, 0);
            this.Detail.Controls.SetChildIndex(this.lblSampleBarcode, 0);
            // 
            // lblBarcode
            // 
            resources.ApplyResources(this.lblBarcode, "lblBarcode");
            this.lblBarcode.StylePriority.UseFont = false;
            this.lblBarcode.StylePriority.UsePadding = false;
            this.lblBarcode.StylePriority.UseTextAlignment = false;
            // 
            // sampleBarcodeDataSet1
            // 
            this.sampleBarcodeDataSet1.DataSetName = "SampleBarcodeDataSet";
            this.sampleBarcodeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spRepGetSampleBarcodeTableAdapter
            // 
            this.spRepGetSampleBarcodeTableAdapter.ClearBeforeFill = true;
            // 
            // lblDate
            // 
            this.lblDate.CanGrow = false;
            this.lblDate.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetSampleBarcode.datCollectionDate")});
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            this.lblDate.StylePriority.UseFont = false;
            this.lblDate.StylePriority.UsePadding = false;
            // 
            // lblCase
            // 
            this.lblCase.CanGrow = false;
            this.lblCase.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetSampleBarcode.strCase")});
            resources.ApplyResources(this.lblCase, "lblCase");
            this.lblCase.Name = "lblCase";
            this.lblCase.StylePriority.UseFont = false;
            this.lblCase.StylePriority.UsePadding = false;
            // 
            // lblSampleCode
            // 
            this.lblSampleCode.CanGrow = false;
            this.lblSampleCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetSampleBarcode.strBarcodeLabel")});
            resources.ApplyResources(this.lblSampleCode, "lblSampleCode");
            this.lblSampleCode.Name = "lblSampleCode";
            this.lblSampleCode.StylePriority.UseFont = false;
            this.lblSampleCode.StylePriority.UsePadding = false;
            // 
            // lblSampleTypeCode
            // 
            this.lblSampleTypeCode.CanGrow = false;
            this.lblSampleTypeCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetSampleBarcode.strSampleCode")});
            resources.ApplyResources(this.lblSampleTypeCode, "lblSampleTypeCode");
            this.lblSampleTypeCode.Name = "lblSampleTypeCode";
            this.lblSampleTypeCode.StylePriority.UseFont = false;
            this.lblSampleTypeCode.StylePriority.UsePadding = false;
            // 
            // lblSampleBarcode
            // 
            this.lblSampleBarcode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetSampleBarcode.strBarcode")});
            resources.ApplyResources(this.lblSampleBarcode, "lblSampleBarcode");
            this.lblSampleBarcode.Name = "lblSampleBarcode";
            this.lblSampleBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSampleBarcode.StylePriority.UseFont = false;
            this.lblSampleBarcode.StylePriority.UseTextAlignment = false;
            // 
            // SampleBarcodeReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.DataAdapter = this.spRepGetSampleBarcodeTableAdapter;
            this.DataMember = "spRepGetSampleBarcode";
            this.DataSource = this.sampleBarcodeDataSet1;
            this.DesignerOptions.ShowExportWarnings = false;
            this.Version = "15.1";
            ((System.ComponentModel.ISupportInitialize)(this.barcodeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleBarcodeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private SampleBarcodeDataSet sampleBarcodeDataSet1;
        private SampleBarcodeDataSetTableAdapters.spRepGetSampleBarcodeTableAdapter spRepGetSampleBarcodeTableAdapter;
        private DevExpress.XtraReports.UI.XRLabel lblDate;
        private DevExpress.XtraReports.UI.XRLabel lblSampleCode;
        private DevExpress.XtraReports.UI.XRLabel lblCase;
        private DevExpress.XtraReports.UI.XRLabel lblSampleTypeCode;
        private DevExpress.XtraReports.UI.XRLabel lblSampleBarcode;




    }
}