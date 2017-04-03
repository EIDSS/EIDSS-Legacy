using System.Data.SqlClient;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Barcode
{
    public partial class FreezerBarcodeReport : BaseBarcodeReport
    {
        public FreezerBarcodeReport()
        {
            InitializeComponent();
        }

        internal override void GetBarcodeById(DbManagerProxy manager, long typeId, long id)
        {
            spRepGetFreezerBarcodeTableAdapter.Connection = (SqlConnection) manager.Connection;
            spRepGetFreezerBarcodeTableAdapter.Fill(freezerBarcodeDataSet1.spRepGetFreezerBarcode, id);
        }

        protected override void AppendDatasetWithNewRow(string newId)
        {
            freezerBarcodeDataSet1.spRepGetFreezerBarcode.AddspRepGetFreezerBarcodeRow(string.Empty, string.Empty, newId);
        }
    }
}