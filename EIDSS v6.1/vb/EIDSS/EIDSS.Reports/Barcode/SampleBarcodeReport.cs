using System.Collections.Generic;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Factory;

namespace EIDSS.Reports.Barcode
{
    public partial class SampleBarcodeReport : BaseBarcodeReport
    {
        public SampleBarcodeReport()
        {
            InitializeComponent();
        }

        public override void GetBarcodeById(DbManagerProxy manager, long typeId, IList<long> idList)
        {
            spRepGetSampleBarcodeTableAdapter.Connection = (SqlConnection) manager.Connection;

            foreach (long id in idList)
            {
                var barcodeData = new SampleBarcodeDataSet.spRepGetSampleBarcodeDataTable();
                spRepGetSampleBarcodeTableAdapter.Fill(barcodeData, id, ModelUserContext.CurrentLanguage);
                sampleBarcodeDataSet1.spRepGetSampleBarcode.Merge(barcodeData);
            }
            EncodeBarcode();
        }

        public void GetBarcodeBySampleData(IList<SampleBarcodeDTO> samples)
        {
            ReportRebinder rebinder = this.GetDateRebinder(Localizer.lngEn);
            foreach (SampleBarcodeDTO id in samples)
            {
                sampleBarcodeDataSet1.spRepGetSampleBarcode.AddspRepGetSampleBarcodeRow(
                    id.OwnerId, id.Barcode, id.SpeciesCode, id.SpecimenCode, rebinder.ToDateString(id.CollectionDate), id.Barcode);
            }
            EncodeBarcode();
        }

        protected override void EncodeBarcode()
        {
            base.EncodeBarcode();
            foreach (SampleBarcodeDataSet.spRepGetSampleBarcodeRow row in sampleBarcodeDataSet1.spRepGetSampleBarcode)
            {
                if (!row.IsstrBarcodeNull())
                {
                    row.strBarcode = m_BarCode.Code128(row.strBarcode);
                }
            }
        }

        protected override void AppendDatasetWithNewRow(string newId)
        {
            sampleBarcodeDataSet1.spRepGetSampleBarcode.AddspRepGetSampleBarcodeRow(
                string.Empty, newId, string.Empty, string.Empty, string.Empty, newId);
        }
    }
}