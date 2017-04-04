namespace eidss.avr.db.Interfaces
{
    public interface IQueryInfoView : IRelatedObjectView
    {
        void CreateQuery();
        void EditQuery();
        void DeleteQuery();

        void RaiseQuerySelectedEvent(long queryId);
    }
}