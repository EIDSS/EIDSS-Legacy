using bv.common.win;

namespace EIDSS.RAM_DB.Views
{
    public interface IRelatedObjectView : IView, IRelatedObject
    {
        bool UseParentDataset { get; }
    }
}