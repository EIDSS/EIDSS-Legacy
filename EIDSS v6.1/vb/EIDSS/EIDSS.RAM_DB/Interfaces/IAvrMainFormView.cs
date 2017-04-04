using bv.common.Core;
using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.db.Interfaces
{
    public interface IAvrMainFormView : IRelatedObjectView, IAvrInvokable, IPostable
    {
        void CloseQueryLayoutStart();
        void LayoutCopyStart();
        void LayoutNewStart();
        void DeleteQueryLayoutStart(QueryLayoutDeleteCommand deleteCommand);
        void ChangeFormCaption(RefreshCaptionCommand refreshCommand);
    }
}