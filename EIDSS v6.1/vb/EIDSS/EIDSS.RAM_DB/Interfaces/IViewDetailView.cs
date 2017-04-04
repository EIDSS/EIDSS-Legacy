using eidss.model.Avr.Commands.Export;
using eidss.model.Avr.Commands.Layout;

namespace eidss.avr.db.Interfaces
{
    public interface IViewDetailView : IRelatedObjectView
    {
        void OnPivotDataLoaded(PivotGridDataLoadedCommand command);
        void OnPrint();
        void OnExport(ExportType exportType);
    }
}