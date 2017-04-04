using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Barcode
{
    public static class BarcodeReportGenerator
    {
        public static BaseBarcodeReport GenerateBarcodeReport(long index)
        {
            switch ((NumberingObject)index)
            {
                case NumberingObject.Sample:
                    return new SampleBarcodeReport();
                case NumberingObject.FreezerBarcode:
                    return new FreezerBarcodeReport();
                case NumberingObject.Farm:
                    return new FarmBarcodeReport();
                default:
                    return new BaseBarcodeReport();
            }
        }
        public static SampleBarcodeReport GenerateSampleBarcodeReport()
        {
                    return new SampleBarcodeReport();
        }
    }
}