using System.Collections.Generic;
using bv.common.Core;
using bv.model.Model.Core;
using EIDSS.Reports.BaseControls.Form;

namespace EIDSS.Reports.Factory
{
    public class BarcodeFactory : IBarcodeFactory
    {
        public void ShowPreview()
        {
            var form = new BarCodeForm();
            form.ShowDialog();
        }

        public void ShowPreview(long type)
        {
            var form = new BarCodeForm((NumberingObject) type, new long[0]);
            form.ShowDialog();
        }

        public void ShowPreview(long type, long id)
        {
            var form = new BarCodeForm((NumberingObject) type, new[] {id});
            form.ShowDialog();
        }

        public void ShowPreview(long type, IList<long> idList)
        {
            var form = new BarCodeForm((NumberingObject) type, idList);
            form.ShowDialog();
        }

        public void ShowSamplePreview(SampleBarcodeDTO sample)
        {
            var form = new BarCodeForm(new List<SampleBarcodeDTO> {sample});
            form.ShowDialog();
        }

        public void ShowSamplePreview(IList<SampleBarcodeDTO> samples)
        {
            var form = new BarCodeForm(samples);
            form.ShowDialog();
        }
    }
}