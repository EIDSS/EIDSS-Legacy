using bv.common.Core;
using EIDSS.Reports.BaseControls.Form;
using bv.model.Model.Core;

namespace EIDSS.Reports.Factory
{
    public class BarcodeFactory : IBarcodeFactory
    {
        public void ShowPreview()
        {
            ShowPreviewInternal(null, null);
        }

        public void ShowPreview(long type)
        {
            ShowPreviewInternal(type, null);
        }

        public void ShowPreview(long type, long id)
        {
            ShowPreviewInternal(type, id);
        }

        public void ShowPreviewInternal(long? type, long? id)
        {
            BarCodeForm form = (type.HasValue)
                                   ? new BarCodeForm((NumberingObject) type, id)
                                   : new BarCodeForm();
            form.ShowDialog();
        }
    }
}