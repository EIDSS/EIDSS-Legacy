
namespace bv.model.Model.Core
{

    public interface IBarcodeFactory
    {
        void ShowPreview();
        void ShowPreview(long type);
        void ShowPreview(long type, long id);
    }

}
