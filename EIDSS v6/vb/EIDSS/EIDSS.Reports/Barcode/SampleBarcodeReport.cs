using System.Collections.Generic;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;

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
                //spRepGetSampleBarcodeTableAdapter.Fill(sampleBarcodeDataSet1.spRepGetSampleBarcode, id,ModelUserContext.CurrentLanguage);
            }
        }

        public void GetBarcodeBySampleData(IList<SampleBarcodeDTO> samples)
        {
            ReportRebinder rebinder = ReportRebinder.GetDateRebinder(Localizer.lngEn, this);
            foreach (SampleBarcodeDTO id in samples)
            {
                sampleBarcodeDataSet1.spRepGetSampleBarcode.AddspRepGetSampleBarcodeRow(
                    id.OwnerId, id.Barcode, id.SpeciesCode, id.SpecimenCode, rebinder.ToDateString(id.CollectionDate));
            }
        }

        protected override void AppendDatasetWithNewRow(string newId)
        {
            sampleBarcodeDataSet1.spRepGetSampleBarcode.AddspRepGetSampleBarcodeRow(
                string.Empty, newId, string.Empty,string.Empty, string.Empty);
        }
    }
}