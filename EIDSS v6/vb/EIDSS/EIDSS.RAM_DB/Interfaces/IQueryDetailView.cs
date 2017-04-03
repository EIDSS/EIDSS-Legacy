using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.db.Interfaces
{
    public interface IQueryDetailView : IRelatedObjectView
    {
        void ProcessQueryLayoutCommand(QueryLayoutCommand queryLayoutCommand);
    }
}