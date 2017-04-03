using bv.common.Core;
using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.db.Interfaces
{
    public interface IAvrMainFormView : IRelatedObjectView, IPostable
    {
        void CloseQueryLayoutStart();
        void DeleteQueryLayoutStart(QueryLayoutDeleteCommand deleteCommand);
    }
}