using System.Collections.Generic;
using bv.common.Core;

namespace bv.model.Model.Core
{
    public interface IBarcodeFactory
    {
        void ShowPreview();
        void ShowPreview(long type);

        void ShowPreview(long type, long id);
        void ShowPreview(long type, IList<long> idList);

        void ShowSamplePreview(SampleBarcodeDTO sample);
        void ShowSamplePreview(IList<SampleBarcodeDTO> samples);
    }
}