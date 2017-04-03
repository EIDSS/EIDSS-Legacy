
namespace EIDSS.Reports.Barcode
{
    partial class FreezerBarcodeReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreezerBarcodeReport));
            this.lblFreezerCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFreezerBarcode = new DevExpress.XtraReports.UI.XRLabel();
            this.freezerBarcodeDataSet1 = new EIDSS.Reports.Barcode.FreezerBarcodeDataSet();
            this.spRepGetFreezerBarcodeTableAdapter = new EIDSS.Reports.Barcode.FreezerBarcodeDataSetTableAdapters.spRepGetFreezerBarcodeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freezerBarcodeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // lblTop
            // 
            resources.ApplyResources(this.lblTop, "lblTop");
            this.lblTop.StylePriority.UseFont = false;
            // 
            // lblBarcode
            // 
            resources.ApplyResources(this.lblBarcode, "lblBarcode");
            this.lblBarcode.StylePriority.UseFont = false;
            this.lblBarcode.StylePriority.UsePadding = false;
            this.lblBarcode.StylePriority.UseTextAlignment = false;
            // 
            // lblBottom
            // 
            resources.ApplyResources(this.lblBottom, "lblBottom");
            this.lblBottom.StylePriority.UseFont = false;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblFreezerCode,
            this.lblFreezerBarcode});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.Controls.SetChildIndex(this.lblFreezerBarcode, 0);
            this.Detail.Controls.SetChildIndex(this.lblFreezerCode, 0);
            this.Detail.Controls.SetChildIndex(this.lblBottom, 0);
            this.Detail.Controls.SetChildIndex(this.lblBarcode, 0);
            this.Detail.Controls.SetChildIndex(this.lblTop, 0);
            // 
            // lblFreezerCode
            // 
            this.lblFreezerCode.CanGrow = false;
            this.lblFreezerCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetFreezerBarcode.strBarcode")});
            resources.ApplyResources(this.lblFreezerCode, "lblFreezerCode");
            this.lblFreezerCode.Name = "lblFreezerCode";
            this.lblFreezerCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFreezerCode.StylePriority.UseFont = false;
            // 
            // lblFreezerBarcode
            // 
            this.lblFreezerBarcode.CanGrow = false;
            this.lblFreezerBarcode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "spRepGetFreezerBarcode.strBarcode", "*{0}*")});
            resources.ApplyResources(this.lblFreezerBarcode, "lblFreezerBarcode");
            this.lblFreezerBarcode.Name = "lblFreezerBarcode";
            this.lblFreezerBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFreezerBarcode.StylePriority.UseFont = false;
            // 
            // freezerBarcodeDataSet1
            // 
            this.freezerBarcodeDataSet1.DataSetName = "FreezerBarcodeDataSet";
            this.freezerBarcodeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spRepGetFreezerBarcodeTableAdapter
            // 
            this.spRepGetFreezerBarcodeTableAdapter.ClearBeforeFill = true;
            // 
            // FreezerBarcodeReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.DataAdapter = this.spRepGetFreezerBarcodeTableAdapter;
            this.DataMember = "spRepGetFreezerBarcode";
            this.DataSource = this.freezerBarcodeDataSet1;
            this.DesignerOptions.ShowExportWarnings = false;
            this.Version = "11.1";
            ((System.ComponentModel.ISupportInitialize)(this.barcodeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freezerBarcodeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRLabel lblFreezerCode;
        private DevExpress.XtraReports.UI.XRLabel lblFreezerBarcode;
        private FreezerBarcodeDataSet freezerBarcodeDataSet1;
        private EIDSS.Reports.Barcode.FreezerBarcodeDataSetTableAdapters.spRepGetFreezerBarcodeTableAdapter spRepGetFreezerBarcodeTableAdapter;




    }
}