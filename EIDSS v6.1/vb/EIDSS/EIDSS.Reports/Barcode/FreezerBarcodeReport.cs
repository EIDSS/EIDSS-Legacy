using System.Collections.Generic;
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

        public override void GetBarcodeById(DbManagerProxy manager, long typeId, IList<long> idList)
        {
            spRepGetFreezerBarcodeTableAdapter.Connection = (SqlConnection) manager.Connection;

            foreach (long id in idList)
            {
                var barcodeData = new FreezerBarcodeDataSet.spRepGetFreezerBarcodeDataTable();
                spRepGetFreezerBarcodeTableAdapter.Fill(barcodeData, id);
                freezerBarcodeDataSet1.spRepGetFreezerBarcode.Merge(barcodeData);
            }
            EncodeBarcode();
        }

        protected override void EncodeBarcode()
        {
            base.EncodeBarcode();
            foreach (FreezerBarcodeDataSet.spRepGetFreezerBarcodeRow row in freezerBarcodeDataSet1.spRepGetFreezerBarcode)
            {
                if (!row.IsstrBarcodeNull())
                {
                    row.strBarcode = m_BarCode.Code128(row.strBarcode);
                }
            }
        }

        protected override void AppendDatasetWithNewRow(string newId)
        {
            freezerBarcodeDataSet1.spRepGetFreezerBarcode.AddspRepGetFreezerBarcodeRow(string.Empty, string.Empty, newId, newId);
        }
    }
}