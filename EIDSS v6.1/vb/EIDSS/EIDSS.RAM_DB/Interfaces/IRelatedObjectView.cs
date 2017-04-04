using bv.common.db;

namespace eidss.avr.db.Interfaces
{
    public interface IRelatedObjectView : IBaseAvrView, IRelatedObject
    {
        bool UseParentDataset { get; }
    }
}