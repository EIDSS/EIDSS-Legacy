using System;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.BaseComponents.Views
{
    public interface ILayoutDetailView : IRelatedObjectView
    {
        event EventHandler<CopyLayoutEventArgs> CopyLayoutCreating;

        void OnLayoutSelected(LayoutEventArgs e);

        void ProcessQueryLayoutCommand(QueryLayoutCommand queryLayoutCommand);

        IPivotDetailView PivotDetailView { get; }
    }
}