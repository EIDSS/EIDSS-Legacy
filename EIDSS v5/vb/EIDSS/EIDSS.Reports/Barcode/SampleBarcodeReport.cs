using System.Data.SqlClient;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Barcode
{
    public partial class SampleBarcodeReport : BaseBarcodeReport
    {
        public SampleBarcodeReport()
        {
            InitializeComponent();
        }

        internal override void GetBarcodeById(DbManagerProxy manager, long typeId, long id)
        {
            spRepGetSampleBarcodeTableAdapter.Connection = (SqlConnection) manager.Connection;
            spRepGetSampleBarcodeTableAdapter.Fill(sampleBarcodeDataSet1.spRepGetSampleBarcode, id,
                                                   ModelUserContext.CurrentLanguage);
        }

        protected override void AppendDatasetWithNewRow(string newId)
        {
            sampleBarcodeDataSet1.spRepGetSampleBarcode.AddspRepGetSampleBarcodeRow(string.Empty, newId, string.Empty,
                                                                                    string.Empty, string.Empty);
        }
    }
}