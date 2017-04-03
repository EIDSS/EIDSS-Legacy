namespace EIDSS.RAM_DB.Views
{
    public interface IQueryInfoView : IRelatedObjectView
    {
        void CreateQuery();
        void EditQuery();
        void DeleteQuery();

        void RaiseQuerySelectedEvent(long queryId);
    }
}